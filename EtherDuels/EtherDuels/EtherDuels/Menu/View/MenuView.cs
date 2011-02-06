using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Menu.View
{   
    /// <summary>
    /// The MenuView is responsible for drawing the menu and all its subcomponents.
    /// It contains a list of menuDialogViews of which only one at a time can be active.
    /// </summary>
    public class MenuView
    {
        private MenuDialogView[] menuDialogViews;
        private MenuModel menuModel;

        /// <summary>
        /// Creates a new MenuView object.
        /// </summary>
        /// <param name="menuDialogViews">An array of MenuDialogView objects.</param>
        /// <param name="menuModel">The dedicated MenuModel.</param>
        public MenuView(MenuDialogView[] menuDialogViews, MenuModel menuModel)
        {
            this.menuDialogViews = menuDialogViews;
            this.menuModel = menuModel;
        }

        /// <summary>
        /// Draws the MenuView and all its subcomponents.
        /// </summary>
        /// <param name="viewport">The used Viewport.</param>
        /// <param name="spriteBatch">The used SpriteBatch.</param>
        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            foreach (MenuDialogView menuDialogView in this.menuDialogViews)
            {
                menuDialogView.Draw(viewport, spriteBatch);
            }
        }
    }
}
