using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EtherDuels.Game.Model;

namespace EtherDuels.Game.View
{
    public class WorldView
    {
        private Vector3 cameraPosition;
        private World world;
        private List<WorldObjectView> worldObjectViews;
        private Texture2D background;

        public WorldView(Texture2D background, World world)
        {
            this.background = background;
            this.world = world;
            this.cameraPosition = new Vector3(0.0f, 5000.0f, 1000.0f);
            this.worldObjectViews = new List<WorldObjectView>();
        }

        public void AddWorldObjectView(WorldObjectView worldObjectView)
        {
            this.worldObjectViews.Add(worldObjectView);
        }

        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(this.background, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();

            foreach (WorldObjectView worldObjectView in this.worldObjectViews)
            {
                worldObjectView.Draw(viewport, this.cameraPosition);
            }
        }
    }
}
