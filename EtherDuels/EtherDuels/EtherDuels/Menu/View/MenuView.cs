using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Menu.View
{
    class MenuView
    {
        private MenuDialogView[] menuDialogViews;
        private MenuModel menuModel;

        public MenuView(MenuDialogView[] menuDialogViews, MenuModel menuModel)
        {
            this.menuDialogViews = menuDialogViews;
            this.menuModel = menuModel;
        }

        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            // TODO
        }
    }
}
