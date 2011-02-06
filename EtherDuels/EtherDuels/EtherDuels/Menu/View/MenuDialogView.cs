using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EtherDuels.Menu.Model;
using Microsoft.Xna.Framework;

namespace EtherDuels.Menu.View
{   
    /// <summary>
    /// Defines the view of a MenuDialog. It contains a list of MenuItemViews.
    /// It draws the associated MenuDialog only if that is currently active.
    /// </summary>
    public class MenuDialogView
    {
        private MenuDialog menuDialog;
        private MenuItemView[] menuItemViews;
        private MenuAssets menuAssets = MenuAssets.Instance;

        /// <summary>
        /// Creates a new MenuDialogView object.
        /// </summary>
        /// <param name="menuItemViews">An array of MenuItemViews.</param>
        /// <param name="menuDialog">The dedicated MenuDialog.</param>
        public MenuDialogView(MenuItemView[] menuItemViews, MenuDialog menuDialog)
        {
            this.menuItemViews = menuItemViews;
            this.menuDialog = menuDialog;
        }

        /// <summary>
        /// Draws the MenuDialogView and all its subcomponents. 
        /// </summary>
        /// <param name="viewport">The used ViewPort.</param>
        /// <param name="spriteBatch">The used SpriteBatch.</param>
        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            // do not draw if not active
            if (!this.menuDialog.Active) return;

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(menuAssets.TextureBackground, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();
            
            // draw items
            int offset = 40;
            Vector2 position = new Vector2((viewport.Width / 2) - 300, (viewport.Height / 2) - ((this.menuItemViews.Length * offset) / 2));
            foreach (MenuItemView menuItemView in this.menuItemViews)
            {
                menuItemView.Draw(position, spriteBatch);
                position.Y += offset;
            }
        }
    }
}
