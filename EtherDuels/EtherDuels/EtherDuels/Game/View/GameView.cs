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
        WorldView worldView;
        public void SetWorldView(WorldView worldView)
        {
            this.worldView = worldView;
        }

        public void Draw(Viewport viewPort, SpriteBatch spriteBatch)
        {
            //TODO
        }

        public WorldView GetWorldView()
        {
            return worldView;
        }
        
        //TODO
    }
}
