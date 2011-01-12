using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using EtherDuels.Menu.Model;

namespace EtherDuels.Menu.View
{
    class MenuDialogView
    {
        private Texture2D background;
        private MenuDialog menuDialog;
        private MenuItemView[] menuItemViews;

        public MenuDialogView(MenuItemView[] menuItemViews, MenuDialog menuDialog, Texture2D background)
        {
            this.menuItemViews = menuItemViews;
            this.menuDialog = menuDialog;
            this.background = background;
        }

        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            // TODO
        }
    }
}
