using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Menu.View
{
    class MenuItemView
    {
        private MenuItem menuItem;
        private SpriteFont font;

        public MenuItemView(MenuItem menuItem, SpriteFont font)
        {
            this.menuItem = menuItem;
            this.font = font;
        }

        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (this.menuItem.Selected)
            {
                color = Color.Red;
            }

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(this.font, this.menuItem.Text, position, color);
            spriteBatch.End();
        }
    }
}
