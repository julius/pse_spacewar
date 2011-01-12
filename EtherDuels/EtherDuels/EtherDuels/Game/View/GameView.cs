using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Game.View
{
    /// <summary>
    /// Defines the view of a GameModel.
    /// </summary>
    public class GameView
    {
        private GameModel gameModel;
        private WorldView worldView;

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
        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            // TODO draw HUD

            this.worldView.Draw(viewport, spriteBatch);
        }
    }
}
