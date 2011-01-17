using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Menu.View
{   
    /// <summary>
    /// Defines the view of one MenuItem.
    /// </summary>
    class MenuItemView
    {
        private MenuItem menuItem;
        private SpriteFont font;

        /// <summary>
        /// Creates a MenuItemView object for its dedicated MenuItem.
        /// </summary>
        /// <param name="menuItem">Defines the dedicated MenuItem, to check it for changes.</param>
        /// <param name="font">Defines the used font. </param>
        public MenuItemView(MenuItem menuItem, SpriteFont font)
        {
            this.menuItem = menuItem;
            this.font = font;
        }

        /// <summary>
        /// Draws the MenuItemView.
        /// </summary>
        /// <param name="position">The position of the dedicated MenuItem.</param>
        /// <param name="spriteBatch">The used SpriteBatch.</param>
        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (this.menuItem.Selected)
            {
                color = Color.Orange;
            }

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(this.font, this.menuItem.Text, position, color);
            spriteBatch.End();
        }
    }
}
