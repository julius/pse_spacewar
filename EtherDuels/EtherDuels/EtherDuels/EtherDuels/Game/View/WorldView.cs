﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EtherDuels.Game.Model;

namespace EtherDuels.Game.View
{   
    /// <summary>
    /// Defines the view of a World.
    /// </summary>
    public class WorldView
    {
        private Vector3 cameraPosition;
        private World world;
        private List<WorldObjectView> worldObjectViews;

        public WorldObjectView[] WorldObjectViews
        {
            get { return worldObjectViews.ToArray<WorldObjectView>(); }
        }
        private Texture2D background;

        /// <summary>
        /// Creates a new WorldView object.
        /// </summary>
        /// <param name="background">Defines the background of this world.</param>
        /// <param name="world">The dedicated World to check it for changes.</param>
        public WorldView(Texture2D background, World world)
        {
            this.background = background;
            this.world = world;
            this.cameraPosition = new Vector3(0.0f, 5000.0f, 1000.0f);
            this.worldObjectViews = new List<WorldObjectView>();
        }

        /// <summary>
        /// Adds a new WorldObjectView to the WorldView.
        /// </summary>
        /// <param name="worldObjectView">The worldObjectView, which has to be added.</param>
        public void AddWorldObjectView(WorldObjectView worldObjectView)
        {
            this.worldObjectViews.Add(worldObjectView);
        }

        /// <summary>
        /// Removes the given WorldObjectView from the List of WorldObjectViews in the WorldView.
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