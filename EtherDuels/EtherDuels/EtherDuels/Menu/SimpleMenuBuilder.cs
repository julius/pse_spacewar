using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using Microsoft.Xna.Framework.Graphics;
using EtherDuels.Config;

namespace EtherDuels.Menu
{   
    /// <summary>
    /// Defines a concrete MenuBuilder.
    /// </summary>
    class SimpleMenuBuilder: MenuBuilder
    {
        private MenuHandler menuHandler;
        private SpriteFont spriteFont;
        Configuration configuration;
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
            MenuModel menuModel = new MenuModel();

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

            MenuItem.ActionHandler actionMainOptions = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(2);
            };

            MenuItem.ActionHandler actionPauseOptions = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(3);
            };

            MenuItem.ActionHandler actionHelp = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(4);
            };

            MenuItem.ActionHandler actionHighscore = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(5);
            };

            MenuItem.ActionHandler actionQuit = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(6);
            };

            MenuItem.ActionHandler actionVolume = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(7);
            };

            MenuItem.ActionHandler actionDifficulty = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(8);
            };

            MenuItem.ActionHandler actionKeyboardConfiguration = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(9);
            };

            MenuItem.ActionHandler actionReturnToMainMenu = delegate(MenuItem menuItem)
            {
                menuModel.SetMainMenu();
            };

            MenuItem.ActionHandler actionReturnToPauseMenu = delegate(MenuItem menuItem)
            {
                menuModel.SetPauseMenu();
            };

            MenuItem.ActionHandler actionVolumeUp = delegate(MenuItem menuItem)
            {
                //TODO: if (configuration.Volume <= 90) { configuration.Volume += 10; }
            };

            MenuItem.ActionHandler actionVolumeDown = delegate(MenuItem menuItem)
            {
                //TODO: if (configuration.Volume >= 10) { configuration.Volume -= 10; }
            };

            MenuItem.ActionHandler actionDifficultyUp = delegate(MenuItem menuItem)
            {
                if (configuration.Difficulty < 3)
                {
                    configuration.Difficulty += 1;
                }
            };

            MenuItem.ActionHandler actionDifficultyDown = delegate(MenuItem menuItem)
            {
                if (configuration.Difficulty > 0)
                {
                    configuration.Difficulty -= 1;
                }
            };

            MenuItem.ActionHandler actionReturn = delegate(MenuItem menuItem)
            {
                menuModel.SetPreviousDialogActive();
            };

            MenuItem.ActionHandler actionForwardKey = delegate(MenuItem menuItem)
            {
                // TODO: configuration.SetForwardKey();
            };

            MenuItem.ActionHandler actionBackwardKey = delegate(MenuItem menuItem)
            {
                // TODO: configuration.SetBackwardKey();
            };

            MenuItem.ActionHandler actionLeftKey = delegate(MenuItem menuItem)
            {
                // TODO: configuration.SetLeftKey();
            };

            MenuItem.ActionHandler actionRightKey = delegate(MenuItem menuItem)
            {
                // TODO: configuration.SetRightKey();
            };

            MenuItem.ActionHandler actionFireKey = delegate(MenuItem menuItem)
            {
                // TODO: configuration.SetFireKey();
            };

            MenuItem.ActionHandler actionNextWeaponKey = delegate(MenuItem menuItem)
            {
                // TODO: configuration.SetNextWeaponKey();
            };

            MenuItem.ActionHandler actionPrevWeaponKey = delegate(MenuItem menuItem)
            {
                // TODO: configuration.SetPrevWeaponKey();
            };


            // Build Main Menu
            MenuItem mainMenuStartGame = new MenuItem(actionStartGame, delegate() { return "Start Game"; });
            MenuItem mainMenuOptions = new MenuItem(actionMainOptions, delegate() { return "Options"; });
            MenuItem mainMenuHelp = new MenuItem(actionHelp, delegate() { return "Help"; });
            MenuItem mainMenuHighscore = new MenuItem(actionHighscore, delegate() { return "Highscore"; });
            MenuItem mainMenuQuitProgram = new MenuItem(actionQuit, delegate() { return "Quit Program"; });

            MenuItem[] mainMenuItems = { mainMenuStartGame, mainMenuOptions, mainMenuHelp, mainMenuHighscore, mainMenuQuitProgram };
            MenuDialog mainMenu = new MenuDialog(mainMenuItems);

            // Build Pause Menu
            MenuItem pauseMenuResumeGame = new MenuItem(actionResumeGame, delegate() { return "Resume Game"; });
            MenuItem pauseMenuStartNewGame = new MenuItem(actionStartGame, delegate() { return "Start new Game"; });
            MenuItem pauseMenuOptions = new MenuItem(actionPauseOptions, delegate() { return "Options"; });
            MenuItem pauseMenuHelp = new MenuItem(actionHelp, delegate() { return "Help"; });
            MenuItem pauseMenuHighscore = new MenuItem(actionHighscore, delegate() { return "Highscore"; });
            MenuItem pauseMenuQuitProgram = new MenuItem(actionQuitProgram, delegate() { return "Quit Program"; });

            MenuItem[] pauseMenuItems = { pauseMenuResumeGame, pauseMenuStartNewGame, pauseMenuOptions, pauseMenuHelp, pauseMenuHighscore, pauseMenuQuitProgram };
            MenuDialog pauseMenu = new MenuDialog(mainMenuItems);

            // Build Options Menues
            MenuItem optionsMenuVolume = new MenuItem(actionVolume, delegate() { return "Volume"; });
            MenuItem optionsMenuDifficulty = new MenuItem(actionDifficulty, delegate() { return "Difficulty"; });
            MenuItem optionsMenuKeyboardConfiguration = new MenuItem(actionKeyboardConfiguration, delegate() { return "Keyboard Configuration"; });
            MenuItem optionsMenuReturnToMainMenu = new MenuItem(actionReturnToMainMenu, delegate() { return "Return to Main Menu"; });
            MenuItem optionsMenuReturnToPauseMenu = new MenuItem(actionReturnToPauseMenu, delegate() { return "Return to Pause Menu"; });

            MenuItem[] optionsMainMenuItems = { optionsMenuVolume, optionsMenuDifficulty, optionsMenuKeyboardConfiguration, optionsMenuReturnToMainMenu };
            MenuItem[] optionsPauseMenuItems = { optionsMenuVolume, optionsMenuKeyboardConfiguration, optionsMenuReturnToPauseMenu };
            MenuDialog optionsMainMenu = new MenuDialog(optionsMainMenuItems);
            MenuDialog optionsPauseMenu = new MenuDialog(optionsPauseMenuItems);

            // Build Volume Dialog
            MenuItem volumeUp = new MenuItem(actionVolumeUp, delegate() { return "Volume +"; });
            MenuItem volumeDown = new MenuItem(actionVolumeDown, delegate() { return "Volume -"; });
            MenuItem volumeReturnToOptions = new MenuItem(actionReturn, delegate() { return "Return to Options"; });
            MenuItem[] volumeMenuItems = { volumeUp, volumeDown, volumeReturnToOptions };
            MenuDialog volume = new MenuDialog(volumeMenuItems);

            // Build Difficulty Dialog
            MenuItem difficultyUp = new MenuItem(actionDifficultyUp, delegate() { return "Difficulty +"; });
            MenuItem difficultyDown = new MenuItem(actionDifficultyDown, delegate() { return "Difficulty -"; });
            MenuItem difficultyReturnToOptions = new MenuItem(actionReturn, delegate() { return "Return to Options"; });
            MenuItem[] difficultyMenuItems = { difficultyUp, difficultyDown, difficultyReturnToOptions };
            MenuDialog difficulty = new MenuDialog(difficultyMenuItems);

            // Build Keyboard Configuration Dialog
            MenuItem keyConfigForwardKey = new MenuItem(actionForwardKey, delegate() { return "Forward"; });
            MenuItem keyConfigBackwardKey = new MenuItem(actionBackwardKey, delegate() { return "Backward"; });
            MenuItem keyConfigLeftKey = new MenuItem(actionLeftKey, delegate() { return "Left"; });
            MenuItem keyConfigRightKey = new MenuItem(actionRightKey, delegate() { return "Right"; });
            MenuItem keyConfigFireKey = new MenuItem(actionFireKey, delegate() { return "Fire"; });
            MenuItem keyConfigNextWeaponKey = new MenuItem(actionNextWeaponKey, delegate() { return "Next Weapon"; });
            MenuItem keyConfigPrevWeaponKey = new MenuItem(actionPrevWeaponKey, delegate() { return "Previous Weapon"; });
            MenuItem keyConfigReturnToOptions = new MenuItem(actionReturn, delegate() { return "Return to Options"; }); 
            MenuItem[] keyConfigItems = { keyConfigForwardKey, keyConfigBackwardKey, keyConfigLeftKey, keyConfigRightKey, keyConfigFireKey,
                                            keyConfigNextWeaponKey, keyConfigPrevWeaponKey, keyConfigReturnToOptions };
            MenuDialog keyConfig = new MenuDialog(keyConfigItems);


            // Build Help Dialog
            MenuItem helpReturn = new MenuItem(actionReturn, delegate() { return "Return to Main Menu"; });
            MenuItem[] helpItems = { helpReturn };
            MenuDialog help = new MenuDialog(helpItems);

            // Build Highscore Dialog
            MenuItem highscoreReturn = new MenuItem(actionReturn, delegate() { return "Return to Main Menu"; });
            MenuItem[] highscoreItems = { highscoreReturn };
            MenuDialog highscore = new MenuDialog(highscoreItems);

            // Build Quit Program Dialog
            MenuItem quitProgramYes = new MenuItem(actionQuitProgram, delegate() { return "Yes"; });
            MenuItem quitProgramNo = new MenuItem(actionReturn, delegate() { return "No"; });
            MenuItem[] quitProgramItems = { quitProgramYes, quitProgramNo };
            MenuDialog quitProgram = new MenuDialog(quitProgramItems);

            // Build Menu Model
            MenuDialog[] menuDialogs = { mainMenu, pauseMenu, optionsMainMenu, optionsPauseMenu, help, highscore, quitProgram,
                                       volume, difficulty, keyConfig};
            menuModel.MenuDialogs = menuDialogs;
            return menuModel;
        }

        /// <summary>
        /// Creates a new MenuView fitting to the assigned MenuModel.
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
