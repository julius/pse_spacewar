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
    /// Defines the view of a MenuDialog.
    /// It contains a background and a list of MenuItemViews.
    /// It also holds a reference to its MenuDialog to check it for changes.
    /// </summary>
    class MenuDialogView
    {
        private Texture2D background;
        private MenuDialog menuDialog;
        private MenuItemView[] menuItemViews;

        /// <summary>
        /// Creates a new MenuDialogView object.
        /// </summary>
        /// <param name="menuItemViews">An array of its containing MenuItemViews.</param>
        /// <param name="menuDialog">Its dedicated MenuDialog.</param>
        /// <param name="background">Defines the background of this MenuDialog.</param>
        public MenuDialogView(MenuItemView[] menuItemViews, MenuDialog menuDialog, Texture2D background)
        {
            this.menuItemViews = menuItemViews;
            this.menuDialog = menuDialog;
            this.background = background;
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

            // TODO draw background. edit claudi: hab das jetz einfach mal so von WorldView uebernommen, ohne zu wissen was das zeugs bedeutet
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(this.background, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();
            
            // draw items
            //TODO: schoener machen
            Vector2 position = new Vector2((viewport.Width / 2) - 100, 200);
            int offset = ((viewport.Height - 400) / menuItemViews.Length);
            foreach (MenuItemView menuItemView in this.menuItemViews)
            {
                menuItemView.Draw(position, spriteBatch);
                position.Y += offset;
            }
        }
    }
}
