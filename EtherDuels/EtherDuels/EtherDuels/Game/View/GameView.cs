using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using EtherDuels.Game.Model;

namespace EtherDuels.Game.View
{
    /// <summary>
    /// Defines the view of a GameModel.
    /// </summary>
    public class GameView
    {
        private GameModel gameModel;
        private WorldView worldView;
        private GameAssets gameAssets = GameAssets.Instance;

        /// <summary>
        /// Creates a new GameView object.
        /// </summary>
        /// <param name="gameModel">The dedicated GameModel to check it for changes.</param>
        /// <param name="worldView">The view of the World.</param>
        public GameView(GameModel gameModel, WorldView worldView)
        {
            this.gameModel = gameModel;
            this.worldView = worldView;
        }

        public WorldView WorldView
        {
            get { return this.worldView; }
            set { this.worldView = value; }
        }

        /// <summary>
        /// Draws the GameView, all its subcomponents and the HUD (Head-Up-Display).
        /// </summary>
        /// <param name="viewport">The used Viewport.</param>
        /// <param name="spriteBatch">The used SpriteBatch.</param>
        /// <param name="gameTime">The frame's time object.</param>
        public void Draw(Viewport viewport, SpriteBatch spriteBatch, GameTime gameTime)
        {
            
           
            this.worldView.Draw(viewport, spriteBatch, gameTime);
            DrawHUD(viewport, spriteBatch);
           
        }

        //Draws the HUD (HeadUp-Display) of each player, with its points and its health.
        private void DrawHUD(Viewport viewport, SpriteBatch spriteBatch)
        {
            string points;
            Vector2 posHUD;
            int health;
            Player[] players = gameModel.Players;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

         
           for (int i = 0; i < players.Length; i++)
            {
                points = "points : " + players[i].Points;
                posHUD = new Vector2(i * 200 + 100, 20);
                
                // Vllt den Playern eine Farbe zuordnen, dann ginge das HUD malen in der Farbe leichter.
                // first player is green.
                if (players[i].PlayerId == 1)
                {
                  
                   spriteBatch.DrawString(gameAssets.HudFont, points, posHUD, Color.Green, 0,
                   gameAssets.HudFont.MeasureString(points) / 2, 0.8f, SpriteEffects.None, 0.5f);

                    posHUD.Y = 60;
                    
                    health = (gameAssets.TextureHealthBar.Width * players[i].Spaceship.Health) / 100 ;

                    spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD,
                        new Rectangle((int)posHUD.X, (int)posHUD.Y, gameAssets.TextureHealthBar.Width,
                            gameAssets.TextureHealthBar.Height),
                        Color.Black, 0,
                        new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.42f,
                        SpriteEffects.None, 0);

                    spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD, 
                        new Rectangle((int) posHUD.X, (int) posHUD.Y, health, 
                            gameAssets.TextureHealthBar.Height),
                        Color.Green, 0,
                        new Vector2(gameAssets.TextureHealthBar.Width/2, gameAssets.TextureHealthBar.Height/2), 0.4f, 
                        SpriteEffects.None, 0);

                   
                }

               // second player is orange.
                if (players[i].PlayerId == 2)
                {
                   spriteBatch.DrawString(gameAssets.HudFont, points, posHUD, Color.OrangeRed, 0,
                        gameAssets.HudFont.MeasureString(points) / 2, 0.8f, SpriteEffects.None, 0.5f);

                   posHUD.Y = 60;

                   health = (gameAssets.TextureHealthBar.Width * players[i].Spaceship.Health) / 100;

                   spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD,
                       new Rectangle((int)posHUD.X, (int)posHUD.Y, gameAssets.TextureHealthBar.Width,
                           gameAssets.TextureHealthBar.Height),
                       Color.Black, 0,
                       new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.42f,
                       SpriteEffects.None, 0);
                  
                   spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD,
                       new Rectangle((int)posHUD.X, (int)posHUD.Y, health,
                       gameAssets.TextureHealthBar.Height),
                       Color.OrangeRed, 0,
                       new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.4f,
                       SpriteEffects.None, 0);
                }

               // third player is red.
                if (players[i].PlayerId == 3)
                {
                    spriteBatch.DrawString(gameAssets.HudFont, points, posHUD, Color.Red, 0,
                       gameAssets.HudFont.MeasureString(points) / 2, 0.8f, SpriteEffects.None, 0.5f);

                    posHUD.Y = 60;

                    health = (gameAssets.TextureHealthBar.Width * players[i].Spaceship.Health) / 100;

                    spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD,
                        new Rectangle((int)posHUD.X, (int)posHUD.Y, gameAssets.TextureHealthBar.Width,
                            gameAssets.TextureHealthBar.Height),
                        Color.Black, 0,
                        new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.42f,
                        SpriteEffects.None, 0);

                    spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD,
                        new Rectangle((int)posHUD.X, (int)posHUD.Y, health,
                        gameAssets.TextureHealthBar.Height),
                        Color.Red, 0,
                        new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.4f,
                        SpriteEffects.None, 0);
                }

                // fourth player is blue.
                if (players[i].PlayerId == 4)
                {
                    spriteBatch.DrawString(gameAssets.HudFont, points, posHUD, Color.Blue, 0,
                       gameAssets.HudFont.MeasureString(points) / 2, 0.8f, SpriteEffects.None, 0.5f);

                    posHUD.Y = 60;

                    health = (gameAssets.TextureHealthBar.Width * players[i].Spaceship.Health) / 100;

                    spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD,
                        new Rectangle((int)posHUD.X, (int)posHUD.Y, gameAssets.TextureHealthBar.Width,
                            gameAssets.TextureHealthBar.Height),
                        Color.Black, 0,
                        new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.42f,
                        SpriteEffects.None, 0);

                    spriteBatch.Draw(gameAssets.TextureHealthBar, posHUD,
                        new Rectangle((int)posHUD.X, (int)posHUD.Y, health,
                        gameAssets.TextureHealthBar.Height),
                        Color.Blue, 0,
                        new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.4f,
                        SpriteEffects.None, 0);
                }
                                  
               
            }
            
           spriteBatch.End();
        }

    }
}
