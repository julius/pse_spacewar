using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using EtherDuels.Game.Model;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Menu
{
    class MenuController
    {
        private MenuHandler menuHandler;
        private MenuModel menuModel;
        private MenuView menuView;

        public MenuController(MenuHandler menuHandler, MenuModel menuModel, MenuView menuView)
        {
            this.menuHandler = menuHandler;
            this.menuModel = menuModel;
            this.menuView = menuView;
        }

        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            this.menuView.Draw(viewport, spriteBatch);
        }

        private bool isDownKeyDown = false;
        private bool isUpKeyDown = false;
        private bool isEnterKeyDown = false;
        public void Update(FrameState frameState)
        {
            if (frameState.KeyboardState.IsKeyDown(Keys.Down)) isDownKeyDown = true;
            if (frameState.KeyboardState.IsKeyUp(Keys.Down) && isDownKeyDown)
            {
                isDownKeyDown = false;
                this.menuModel.Down();
            }

            if (frameState.KeyboardState.IsKeyDown(Keys.Up)) isUpKeyDown = true;
            if (frameState.KeyboardState.IsKeyUp(Keys.Up) && isUpKeyDown)
            {
                isUpKeyDown = false;
                this.menuModel.Up();
            }

            if (frameState.KeyboardState.IsKeyDown(Keys.Enter)) isEnterKeyDown = true;
            if (frameState.KeyboardState.IsKeyUp(Keys.Enter) && isEnterKeyDown)
            {
                isEnterKeyDown = false;
                this.menuModel.Action();
            }
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
