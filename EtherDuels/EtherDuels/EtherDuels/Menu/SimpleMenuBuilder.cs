using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Menu
{   
    /// <summary>
    /// Defines a concrete MenuBuilder.
    /// </summary>
    class SimpleMenuBuilder: MenuBuilder
    {
        private MenuHandler menuHandler;
        private SpriteFont spriteFont;
        // TODO: configuration

        /// <summary>
        /// Creates a new SimpleMenuBuilder.
        /// </summary>
        /// <param name="menuHandler">The assigned MenuHandler.</param>
        /// <param name="spriteFont">The used font.</param>
        public SimpleMenuBuilder(MenuHandler menuHandler, SpriteFont spriteFont)
        {
            this.menuHandler = menuHandler;
            this.spriteFont = spriteFont;
        }

        /// <summary>
        /// Creates an new MenuModel.
        /// </summary>
        /// <returns>The created MenuModel.</returns>
        public MenuModel BuildModel()
        {
            // build menu actions
            MenuItem.ActionHandler actionStartGame = delegate(MenuItem menuItem)
            {
                this.menuHandler.OnNewGame();
            };

            MenuItem.ActionHandler actionResumeGame = delegate(MenuItem menuItem)
            {
                this.menuHandler.OnResumeGame();
            };

            MenuItem.ActionHandler actionQuitProgram = delegate(MenuItem menuItem)
            {
                this.menuHandler.OnQuitProgram();
            };

            // Build Main Menu
            MenuItem mainMenuStartGame = new MenuItem(actionStartGame, delegate() { return "Start Game"; });
            MenuItem mainMenuQuitProgram = new MenuItem(actionQuitProgram, delegate() { return "Quit Program"; });

            MenuItem[] mainMenuItems = { mainMenuStartGame, mainMenuQuitProgram };
            MenuDialog mainMenu = new MenuDialog(mainMenuItems);

            // Build Pause Menu
            MenuItem pauseMenuResumeGame = new MenuItem(actionResumeGame, delegate() { return "Resume Game"; });
            MenuItem pauseMenuStartNewGame = new MenuItem(actionStartGame, delegate() { return "Start new Game"; });
            MenuItem pauseMenuQuitProgram = new MenuItem(actionQuitProgram, delegate() { return "Quit Program"; });

            MenuItem[] pauseMenuItems = { pauseMenuResumeGame, pauseMenuStartNewGame, pauseMenuQuitProgram };
            MenuDialog pauseMenu = new MenuDialog(mainMenuItems);

            // Build Menu Model
            MenuDialog[] menuDialogs = { mainMenu, pauseMenu };
            MenuModel menuModel = new MenuModel(menuDialogs);
            return menuModel;
        }

        /// <summary>
        /// Creates a new MenuView fittin gto the assigned MenuModel.
        /// </summary>
        /// <param name="menuModel">The assigned MenuModel.</param>
        /// <returns>The created MenuView.</returns>
        public MenuView BuildView(MenuModel menuModel)
        {
            List<MenuDialogView> menuDialogViewList = new List<MenuDialogView>();

            foreach (MenuDialog menuDialog in menuModel.MenuDialogs)
            {
                List<MenuItemView> menuItemViewList = new List<MenuItemView>();

                foreach (MenuItem menuItem in menuDialog.MenuItems)
                {
                    MenuItemView menuItemView = new MenuItemView(menuItem, this.spriteFont);
                    menuItemViewList.Add(menuItemView);
                }

                // TODO: add background texture (3rd argument)
                MenuDialogView menuDialogView = new MenuDialogView(menuItemViewList.ToArray(), menuDialog, null);
                menuDialogViewList.Add(menuDialogView);
            }

            MenuView menuView = new MenuView(menuDialogViewList.ToArray(), menuModel);
            return menuView;
        }
    }
}
