﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using EtherDuels.Game.Model;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace EtherDuels.Game
{   
    /// <summary>
    /// The GameController is responsible for the communication between the GameModel and its GameView.
    /// It creates new worlds and its views via a GameBuilder and can remove and add objects to them.
    /// It also observes whether a game has ended or was paused and informs its GameHandler if necessary.
    /// </summary>
    public class GameController: CollisionHandler, PlayerHandler
    {
        private GameBuilder gameBuilder;
        private GameHandler gameHandler;
        private GameModel gameModel;
        private GameView gameView;
        private GameTime gameTime;
        private const int velocityLaser = 400;
        private const int velocityRocket = 200;

        public int VelocityLaser
        {
            get { return velocityLaser; }
        }

        public int VelocityRocket
        {
            get { return velocityRocket; }
        }

        /// <summary>
        /// Constructor of a GameController object.
        /// </summary>
        /// <param name="gameBuilder">Defines the GameBuilder the GameController uses.</param> 
        /// <param name="gameHandler">Defines the GameHandler the GameController uses.</param> 
        public GameController(GameBuilder gameBuilder, GameHandler gameHandler)
        {
            this.gameBuilder = gameBuilder;
            this.gameHandler = gameHandler;
            this.gameBuilder.CollisionHandler = this;
            this.gameBuilder.PlayerHandler = this;
        }

       /// <summary>
       /// Creates a new game using its dedicated GameBuilder.
       /// A game consists of a model and its view.
       /// </summary>
        virtual public void CreateGame()
        {            
            gameModel = gameBuilder.BuildModel();
            gameView = gameBuilder.BuildView(gameModel);
        }

        /// <summary>
        /// Draws the GameView and all its subcomponents.
        /// </summary>
        /// <param name="viewPort">Defines the Viewport to usw.</param>
        /// <param name="spriteBatch">Defines the SpriteBatch to use.</param>
        /// <param name="gameTime">The frame's time object.</param>
        public void Draw(Viewport viewPort, SpriteBatch spriteBatch, GameTime gameTime)
        {
            Debug.Assert(gameView != null, "No gameview exists");
            
            gameView.Draw(viewPort, spriteBatch, gameTime);
        }

        /// <summary>
        /// Reacts to a collision that happend in the game depending on 
        /// the type of the two assigned WorldObjects.
        /// This method creates an explosion, reduces the health of the WorldObject, if necessary,
        /// and checks, if one of the involved world objects has to be removed from the world.
        /// </summary>
        /// <param name="collisionObject1">The first WorldObject, which was involved in the collision.</param>
        /// <param name="collisionObject2">The second WorldObject, which was involved in the collision.</param>
        public void OnCollision(WorldObject collisionObject1, WorldObject collisionObject2)
        {
            Debug.Assert(gameModel != null);

            Vector2 posExplosion = new Vector2();
            Vector2 deltaPos = new Vector2(collisionObject2.Position.X - collisionObject1.Position.X, collisionObject2.Position.Y - collisionObject1.Position.Y);

            posExplosion.X = collisionObject1.Position.X + deltaPos.X / 2;
            posExplosion.Y = collisionObject1.Position.Y + deltaPos.Y / 2;

            // creating the Explosion
            Explosion explosion = gameModel.GetFactory().CreateExplosion(gameTime);
            explosion.Position = posExplosion;
            WorldObjectView explosionView = gameModel.GetFactory().CreateExplosionView(explosion);

            // adding the created Explosion to the Game
            gameModel.World.AddWorldObject(explosion);
            gameView.WorldView.AddWorldObjectView(explosionView);

            // reducing the health of the colliding objects
            collisionObject1.Health -= collisionObject2.Attack;
            collisionObject2.Health -= collisionObject1.Attack;
            
            /* checking whether the colliding objects are still "alive". Check the object with
             * less health first to make the player with less health lose the game in case both
             * spaceships died. */
            WorldObjectView[] worldObjectViews = gameView.WorldView.WorldObjectViews;
            
            if (collisionObject1.Health <= collisionObject2.Health)
            {
                checkDeath(collisionObject1, worldObjectViews);
                checkDeath(collisionObject2, worldObjectViews);
            }
            else
            {
                checkDeath(collisionObject2, worldObjectViews);
                checkDeath(collisionObject1, worldObjectViews);
            } 
        }

        
        private void checkDeath(WorldObject collisionObject, WorldObjectView[] worldObjectViews)
        {
            // If the object is dead, remove it and its view from the World and -View.
            if (collisionObject.Health <= 0)    // --> object is dead
            {
                gameModel.World.RemoveWorldObject(collisionObject);

                /* If the object is a spaceship, delete the according player from the players list
                 * and check whether there was only two players left, meaning the other player has won 
                 * the game. */
                if (collisionObject is Spaceship)
                {
                    Player[] players = gameModel.Players;
                    foreach (Player player in players)
                    {
                        if (player.Spaceship == collisionObject)
                        {
                            gameModel.RemovePlayer(player);
                            // checking whether the game has ended and determining the winner 
                            if (players.Length == 2)
                            {
                                if (players[0] == player)
                                {
                                    gameHandler.OnGameEnded(players[1].PlayerId);
                                }
                                else
                                {
                                    gameHandler.OnGameEnded(players[0].PlayerId);
                                }
                            }
                        }
                    }
                }
            }    
        }

        /// <summary>
        /// Creates a projectile and its fitting view. 
        /// </summary>
        /// <param name="shooter">The Spaceship which fired the projectile.</param>
        public void OnFire(Spaceship shooter)
        {
            // create the projectile and its view and add them to the World/WorldView
            Projectile projectile = gameModel.GetFactory().CreateProjectile(shooter.CurrentWeapon);
            WorldObjectView projectileView = gameModel.GetFactory().CreateProjectileView(shooter.CurrentWeapon, projectile);
            gameModel.World.AddWorldObject(projectile);
            gameView.WorldView.AddWorldObjectView(projectileView);

            // set the projectile's rotation
            projectile.Rotation = shooter.Rotation;
            projectile.Shooter = shooter;
            
            // calculate and set the projectile's position. 
            Vector2 projectilePosition;
            projectilePosition.X = shooter.Position.X + (float)Math.Sin(shooter.Rotation) * (shooter.Radius + projectile.Radius + 1);
            projectilePosition.Y = shooter.Position.Y - (float)Math.Cos(shooter.Rotation) * (shooter.Radius + projectile.Radius + 1);
            projectile.Position = projectilePosition;
           
            int velocityFactor = 100;
            switch (shooter.CurrentWeapon) 
            {
                case Weapon.Laser: { velocityFactor = velocityLaser; break; }
                case Weapon.Rocket: { velocityFactor = velocityRocket; break; }
            }
            
            // add the spaceship's velocity to the projectile's velocity
            Vector2 projectileVelocity = shooter.Velocity;
            projectileVelocity.X += (float)Math.Sin(shooter.Rotation) * velocityFactor;
            projectileVelocity.Y -= (float)Math.Cos(shooter.Rotation) * velocityFactor;
            projectile.Velocity = projectileVelocity;

        }

        /// <summary>
        /// Updates the GameModel and its subcomponents.
        /// </summary>
        /// <param name="gameTime">The time, which has passed since the last update.</param>
        public void Update(FrameState frameState)
        {
            if (frameState.KeyboardState.IsKeyDown(Keys.Escape))
            {
                gameHandler.OnGamePaused();
            }

            this.gameTime = frameState.GameTime;
            Debug.Assert(gameModel != null, "No gamemodel exists");      
            
            gameModel.Update(frameState);
        }
    }
}

