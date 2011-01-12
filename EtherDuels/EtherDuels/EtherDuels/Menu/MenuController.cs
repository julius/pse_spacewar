using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EtherDuels.Menu
{
    class MenuController
    {
        private MenuBuilder menuBuilder;
        private MenuHandler menuHandler;
        private MenuModel menuModel;
        private MenuView menuView;

        public MenuController(MenuBuilder menuBuilder, MenuHandler menuHandler, MenuModel menuModel, MenuView menuView)
        {
            this.menuBuilder = menuBuilder;
            this.menuHandler = menuHandler;
            this.menuModel = menuModel;
            this.menuView = menuView;
        }

        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            // TODO
        }

        public void Update(GameTime gameTime)
        {
            // TODO
        }

        public void SetMainMenu()
        {
            this.menuModel.SetMainMenu();
        }

        public void SetPauseMenu()
        {
            this.menuModel.SetPauseMenu();
        }
    }
}
