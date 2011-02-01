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
    /// The GameView is responsible for drawing all the components needed in the game.
    /// </summary>
    public class GameView
    {
        private GameModel gameModel;
        private WorldView worldView;
        private GameAssets gameAssets = GameAssets.Instance;

        /// <summary>
        /// Creates a new GameView object.
        /// </summary>
        /// <param name="gameModel">The assigned GameModel..</param>
        /// <param name="worldView">The view of the World.</param>
        public GameView(GameModel gameModel, WorldView worldView)
        {
            this.gameModel = gameModel;
            this.worldView = worldView;
        }

        /// <summary>
        /// Gets and sets the WorldView.
        /// </summary>
        virtual public WorldView WorldView
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

        // Draws the HUD (HeadUp-Display) of each player and its health.
        private void DrawHUD(Viewport viewport, SpriteBatch spriteBatch)
        {
            string playerName;
            Vector2 posHUD;
            int health;
            Player[] players = gameModel.Players;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            for (int i = 0; i < players.Length; i++)
            {
                playerName = "Player " + players[i].PlayerId;
                posHUD = new Vector2(i * 200 + 100, 20);

                spriteBatch.DrawString(gameAssets.HudFont, playerName, posHUD, players[i].PlayerColor, 0,
                gameAssets.HudFont.MeasureString(playerName) / 2, 0.8f, SpriteEffects.None, 0.5f);

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
                    players[i].PlayerColor, 0,
                    new Vector2(gameAssets.TextureHealthBar.Width / 2, gameAssets.TextureHealthBar.Height / 2), 0.4f,
                    SpriteEffects.None, 0);
            }

            spriteBatch.End();
        }

    }
}
