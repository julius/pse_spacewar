
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using EtherDuels.Game.Model;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace EtherDuels.Game
{   
    /// <summary>
    /// The GameController is responsible for the communication between the GameModel and its GameView.
    /// It creates new worlds and its views via a GameBuilder and can remove and add objects to them.
    /// It also observes, if a game has ended or was paused, so it has to inform its GameHandler.
    /// </summary>
    public class GameController: CollisionHandler, PlayerHandler
    {
        private GameBuilder gameBuilder;
        private GameHandler gameHandler;
        private GameModel gameModel;
        private GameView gameView;
        private GameTime gameTime;
        private FrameState frameState;
        


        /// <summary>
        /// Constructor of a GameController object.
        /// </summary>
        /// <param name="gameBuilder">Defines the GameBuilder the Controller uses.</param> 
        /// <param name="gameHandler">Defines the GameHandler the Controller uses.</param> 
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
       /// A new game is just created, when there don't exist one yet.
       /// </summary>
        public void CreateGame()
        {
            Debug.Assert(gameModel == null, "A gamemodel already exists");
            
            gameModel = gameBuilder.BuildModel();

            gameView = gameBuilder.BuildView(gameModel);
        }

        /// <summary>
        /// Draws the gameView and all its subcomponents.
        /// </summary>
        /// <param name="viewPort">Defines the Viewport, which is to use.</param>
        /// <param name="spriteBatch">Defines the SpriteBatch, which is to use.</param>
        public void Draw(Viewport viewPort, SpriteBatch spriteBatch)
        {
            Debug.Assert(gameView != null, "No gameview exists");
            
            gameView.Draw(viewPort, spriteBatch);
        }

        /// <summary>
        /// Reacts to a collision that happend in the game depending on 
        /// the type of the two assigned WorldObjects.
        /// This method creates an explosion, reduces the health of the WorldObject, if necessary,
        /// and checks, if one of the involved WorldObjects has to be removed from the world.
        /// </summary>
        /// <param name="collisionObject1">The first WorldObject, which was involved in the collision.</param>
        /// <param name="collisionObject2">The second WorldObject, which was involved in the collision.</param>
        public void OnCollision(WorldObject collisionObject1, WorldObject collisionObject2)
        {
            Debug.Assert(gameModel != null);

            /*
             * TODO 
             * 2 vorschlaege zur verbesserung:
             * - WorldObjectView in jedem Draw() - Aufruf testen lassen, ob die Health vom Model <= 0 ist und wenn
             *   nicht, dann die View aus der WorldView rausnehmen. Dazu bräuchten wir allerdings noch ein Interface
             *   um den Zugriff von WorldObjectView auf WorldView zu lösen.
             * - Liste von Modeln zu Views im Controller speichern, sodass bei OnCollision direkt die zugehörige View
             *   gefunden werden kann. 
             */

            // calculating the position of the explosion
            Vector2 pos1 = collisionObject1.Position;
            Vector2 pos2 = collisionObject2.Position;
            float radius1 = collisionObject1.Radius;
            float radius2 = collisionObject2.Radius;

            Vector2 distance;
            Vector2 radiusPoint1;
            Vector2 radiusPoint2;
            Vector2 explosionPoint;
            distance.X = Math.Abs(pos2.X - pos1.X);
            distance.Y = Math.Abs(pos2.Y - pos1.Y);
            //TODO abfragen ob sich die radien überhaupt überschneiden?
            double hypothenuseDistance = Math.Sqrt((double) (distance.X * distance.X + distance.Y * distance.Y));
            double alpha = Math.Asin(distance.Y / hypothenuseDistance);
            radiusPoint1.Y = (float) Math.Sin(alpha) * radius1;
            radiusPoint1.X = (float) Math.Cos(alpha) * radius1;
            radiusPoint2.Y = (float) Math.Sin(alpha) * radius2;
            radiusPoint2.X = (float) Math.Cos(alpha) * radius2;
            explosionPoint.X = (radiusPoint1.X + radiusPoint2.X) / 2;
            explosionPoint.Y = (radiusPoint1.Y + radiusPoint2.Y) / 2;

            // creating the Explosion
            Explosion explosion = gameModel.GetFactory().CreateExplosion(gameTime);
            explosion.Position = pos1 + explosionPoint; //TODO korrekt?
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
                foreach (WorldObjectView worldObjectView in worldObjectViews)
                {
                    if (worldObjectView.WorldObject == collisionObject)
                    {
                        gameView.WorldView.RemoveWorldObjectView(worldObjectView);
                        break;
                    }
                }

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
                                    gameHandler.OnGameEnded(players[1].PlayerId, players[1].Points);    //TODO was passiert mit dem restlichen auszufuehrenden Code? Bleibt Datenmuell uebrig?
                                }
                                else
                                {
                                    gameHandler.OnGameEnded(players[0].PlayerId, players[0].Points);
                                }
                            }
                        }
                        break;
                    }
                }
            }    
        }

        /// <summary>
        /// Creates a projectile and its fitting view. 
        /// </summary>
        /// <param name="shooter">The Spaceship, which fired a projectile.</param>
        public void OnFire(Spaceship shooter)
        {
            Vector2 position = shooter.Position;
            Vector2 velocity = shooter.Velocity;
            float rotation = shooter.Rotation;
            float radius = shooter.Radius;
            Vector2 projectilePosition;
            Weapon weapon = shooter.CurrentWeapon;

            // create the projectile and its view
            Projectile projectile = gameModel.GetFactory().CreateProjectile(weapon);
            WorldObjectView projectileView = gameModel.GetFactory().CreateProjectileview(weapon, projectile);

            // set the projectile's rotation
            projectile.Rotation = rotation;
            
            // calculate and set the projectile's position
            projectilePosition.Y = (float) Math.Sin(90 - rotation);     //TODO Rotation als double im WorldObject speichern?
            projectilePosition.X = (float) Math.Cos(90 - rotation);
            projectile.Position = projectilePosition;

            // add the spaceship's velocity to the projectile's velocity
            projectile.Velocity += velocity;




        }

        /// <summary>
        /// Updates the GameModel and its subcomponents.
        /// </summary>
        /// <param name="gameTime">The time, which is passed since the last update.</param>
        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            Debug.Assert(gameModel != null, "No gamemodel exists");      //TODO Exception verwenden. Update soll nicht aufgerufen werden, wenn GameModel nicht existiert--- Assertions sind besser, da das kein erwartetes Verhalten ist.
            
            gameModel.Update(frameState);
        }
    }



}

