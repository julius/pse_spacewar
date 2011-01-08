using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Game.View
{
    public class GameView
    {
        private GameModel gameModel;
        private WorldView worldView;

        public WorldView WorldView
        {
            get { return this.worldView; }
            set { this.worldView = value; }
        }

        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            // TODO draw HUD

            this.worldView.Draw(viewport, spriteBatch);
        }
    }
}
