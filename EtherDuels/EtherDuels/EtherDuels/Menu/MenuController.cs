using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using EtherDuels.Game.Model;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;

namespace EtherDuels.Menu
{
    /// <summary>
    /// The MenuController is responsible for the communication between the MenuModel and its MenuView.
    /// </summary>
    class MenuController
    {
        private MenuHandler menuHandler;
        private MenuModel menuModel;
        private MenuView menuView;
        private bool isDownKeyUp = false;
        private bool isUpKeyUp = false;
        private bool isEnterKeyUp = false;

        /// <summary>
        /// Creates a new MenuController.
        /// </summary>
        /// <param name="menuHandler">The assigned MenuHandler.</param>
        /// <param name="menuModel">The assigned MenuModel.</param>
        /// <param name="menuView">The assigned MenuView.</param>
        public MenuController(MenuHandler menuHandler, MenuModel menuModel, MenuView menuView)
        {
            this.menuHandler = menuHandler;
            this.menuModel = menuModel;
            this.menuView = menuView;
        }

        /// <summary>
        /// Draws the MenuView and all its subcomponents.
        /// </summary>
        /// <param name="viewport">The used Viewport.</param>
        /// <param name="spriteBatch">The used SpriteBatch.</param>
        public void Draw(Viewport viewport, SpriteBatch spriteBatch)
        {
            this.menuView.Draw(viewport, spriteBatch);
        }
        

        /// <summary>
        /// Updates the menu.
        /// </summary>
        /// <param name="frameState">A state object.</param>
        public void Update(FrameState frameState)
        {
            if (this.menuModel.IsWaitingForKey)
            {
                isDownKeyUp = false;
                isUpKeyUp = false;

                Keys[] keys = frameState.KeyboardState.GetPressedKeys();
                if (keys.Length == 0 || keys[0] == Keys.Enter) return;
                this.menuModel.SetWaitingKey(keys[0]);
                return;
            }

            if (frameState.KeyboardState.IsKeyUp(Keys.Down)) isDownKeyUp = true;
            if (frameState.KeyboardState.IsKeyDown(Keys.Down) && isDownKeyUp)
            {
                isDownKeyUp = false;
                this.menuModel.Down();
            }

            if (frameState.KeyboardState.IsKeyUp(Keys.Up)) isUpKeyUp = true;
            if (frameState.KeyboardState.IsKeyDown(Keys.Up) && isUpKeyUp)
            {
                isUpKeyUp = false;
                this.menuModel.Up();
            }

            if (frameState.KeyboardState.IsKeyUp(Keys.Enter)) isEnterKeyUp = true;
            if (frameState.KeyboardState.IsKeyDown(Keys.Enter) && isEnterKeyUp)
            {
                isEnterKeyUp = false;
                this.menuModel.Action();
            }
        }

        /// <summary>
        /// Sets the mainmenu active.
        /// </summary>
        public void SetMainMenu()
        {
            this.menuModel.SetMainMenu();
        }

        /// <summary>
        /// Sets the paused menu active.
        /// </summary>
        public void SetPauseMenu()
        {
            this.menuModel.SetPauseMenu();
        }

        /// <summary>
        /// Sets the end game menu active.
        /// </summary>
        /// <param name="playerID">Id of the wining player.</param>
        public void SetGameEndedMenu(int playerID)
        {
            this.menuModel.SetGameEndedMenu(playerID);
        }
    }
}
