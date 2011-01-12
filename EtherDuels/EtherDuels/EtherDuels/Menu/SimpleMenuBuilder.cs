using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;

namespace EtherDuels.Menu
{
    class SimpleMenuBuilder: MenuBuilder
    {
        public MenuModel BuildModel()
        {
            // Build Main Menu
            MenuItem mainMenuStartGame = new MenuItem(null, null);
            MenuItem mainMenuQuitProgram = new MenuItem(null, null);

            MenuItem[] mainMenuItems = { mainMenuStartGame, mainMenuQuitProgram };
            MenuDialog mainMenu = new MenuDialog(mainMenuItems);

            // Build Pause Menu
            MenuItem pauseMenuResumeGame = new MenuItem(null, null);
            MenuItem pauseMenuStartNewGame = new MenuItem(null, null);
            MenuItem pauseMenuQuitProgram = new MenuItem(null, null);

            MenuItem[] pauseMenuItems = { pauseMenuResumeGame, pauseMenuStartNewGame, pauseMenuQuitProgram };
            MenuDialog pauseMenu = new MenuDialog(mainMenuItems);

            // Build Menu Model
            MenuDialog[] menuDialogs = { mainMenu, pauseMenu };
            MenuModel menuModel = new MenuModel(menuDialogs);
            return menuModel;
        }

        public MenuView BuildView(MenuModel menuModel)
        {
            List<MenuDialogView> menuDialogViewList = new List<MenuDialogView>();

            foreach (MenuDialog menuDialog in menuModel.MenuDialogs)
            {
                List<MenuItemView> menuItemViewList = new List<MenuItemView>();

                foreach (MenuItem menuItem in menuDialog.MenuItems)
                {
                    MenuItemView menuItemView = new MenuItemView(menuItem);
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
