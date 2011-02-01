using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

using EtherDuels.Game.Model;

namespace EtherDuels.Game.View
{   
    /// <summary>
    /// The WorldView is responsible for drawing the background and all the world objects that the assigned world contains.
    /// </summary>
    public class WorldView
    {
        private Vector3 cameraPosition;
        private World world;
        private List<WorldObjectView> worldObjectViews;
        private GameAssets gameAssets = GameAssets.Instance;

        public WorldObjectView[] WorldObjectViews
        {
            get { return worldObjectViews.ToArray<WorldObjectView>(); }
        }

        /// <summary>
        /// Creates a new WorldView object.
        /// </summary>
        /// <param name="world">The assigned World.</param>
        public WorldView(World world)
        {
            this.world = world;
            this.cameraPosition = new Vector3(0.0f, 7000.0f, 1000.0f);
            this.worldObjectViews = new List<WorldObjectView>();
        }

        /// <summary>
        /// Adds a new WorldObjectView to the WorldView.
        /// </summary>
        /// <param name="worldObjectView">The worldObjectView which has to be added.</param>
        virtual public void AddWorldObjectView(WorldObjectView worldObjectView)
        {
            this.worldObjectViews.Add(worldObjectView);
        }

        /// <summary>
        /// Removes the given WorldObjectView from the list of WorldObjectViews.
        /// </summary>
        /// <param name="worldObjectView">The worldObjectView which needs to be removed.</param>
        public void RemoveWorldObjectView(WorldObjectView worldObjectView)
        {
            this.worldObjectViews.Remove(worldObjectView);
        }

        /// <summary>
        /// Draws the WorldView and all its subcomponents.
        /// </summary>
        /// <param name="viewport">The used Viewport.</param>
        /// <param name="spriteBatch">The used SpriteBatch.</param>
        /// <param name="gameTime">The frame's time object.</param>
        public void Draw(Viewport viewport, SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(gameAssets.TextureBackground, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();
            
            foreach (WorldObjectView worldObjectView in this.worldObjectViews.ToArray())
            {
                if (worldObjectView.WorldObject.Health <= 0)
                {
                    RemoveWorldObjectView(worldObjectView);
                }
                else
                {
                    worldObjectView.Draw(viewport, this.cameraPosition, gameTime);
                }
            }
        }
    }
}
