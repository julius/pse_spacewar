using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using Microsoft.Xna.Framework.Graphics;
using EtherDuels.Config;
using Microsoft.Xna.Framework.Input;
using EtherDuels.Game.Model;
using EtherDuels.Game;

namespace EtherDuels.Menu
{   
    /// <summary>
    /// Defines a concrete MenuBuilder.
    /// </summary>
    class SimpleMenuBuilder: MenuBuilder
    {
        private MenuHandler menuHandler;
        private Configuration configuration;

        /// <summary>
        /// Creates a new SimpleMenuBuilder.
        /// </summary>
        /// <param name="menuHandler">The assigned MenuHandler.</param>
        /// <param name="spriteFont">The used font.</param>
        public SimpleMenuBuilder(MenuHandler menuHandler, Configuration configuration)
        {
            this.menuHandler = menuHandler;
            this.configuration = configuration;
        }

        private string FormatKey(Keys key)
        {
            return key == Keys.None ? "Press a key" : key.ToString();
        }

        /// <summary>
        /// Creates an new MenuModel.
        /// </summary>
        /// <returns>The created MenuModel.</returns>
        public MenuModel BuildModel()
        {
            MenuModel menuModel = new MenuModel();
            KeyboardConfiguration kconf1 = this.configuration.GetKeyboardConfiguration(1);
            KeyboardConfiguration kconf2 = this.configuration.GetKeyboardConfiguration(2);

            // Main Menu Actions
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

            // Option Menu Actions
            MenuItem.ActionHandler actionVolume = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(7);
            };

            MenuItem.ActionHandler actionDifficulty = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(8);
            };

            MenuItem.ActionHandler actionKeyboardConfiguration1 = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(9);
            };

            MenuItem.ActionHandler actionKeyboardConfiguration2 = delegate(MenuItem menuItem)
            {
                menuModel.SetActiveDialogByIndex(10);
            };

            MenuItem.ActionHandler actionReturnToMainMenu = delegate(MenuItem menuItem)
            {
                menuModel.SetMainMenu();
            };

            MenuItem.ActionHandler actionReturnToPauseMenu = delegate(MenuItem menuItem)
            {
                menuModel.SetPauseMenu();
            };

            // Volume Menu Actions
            MenuItem.ActionHandler actionVolumeUp = delegate(MenuItem menuItem)
            {
                //TODO: if (configuration.Volume <= 90) { configuration.Volume += 10; }
            };

            MenuItem.ActionHandler actionVolumeDown = delegate(MenuItem menuItem)
            {
                //TODO: if (configuration.Volume >= 10) { configuration.Volume -= 10; }
            };


            // Difficulty Menu Actions
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


            // Keyboard Configuration Actions

            MenuItem.ActionHandler actionForwardKey1 = delegate(MenuItem menuItem)
            {
                kconf1.Forward = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf1.Forward = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionBackwardKey1 = delegate(MenuItem menuItem)
            {
                kconf1.Backward = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf1.Backward = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionLeftKey1 = delegate(MenuItem menuItem)
            {
                kconf1.Left = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf1.Left = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionRightKey1 = delegate(MenuItem menuItem)
            {
                kconf1.Right = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf1.Right = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionFireKey1 = delegate(MenuItem menuItem)
            {
                kconf1.Fire = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf1.Fire = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionNextWeaponKey1 = delegate(MenuItem menuItem)
            {
                kconf1.NextWeapon = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf1.NextWeapon = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionPrevWeaponKey1 = delegate(MenuItem menuItem)
            {
                kconf1.PrevWeapon = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf1.PrevWeapon = key; configuration.Save(); });
            };


            MenuItem.ActionHandler actionForwardKey2 = delegate(MenuItem menuItem)
            {
                kconf2.Forward = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf2.Forward = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionBackwardKey2 = delegate(MenuItem menuItem)
            {
                kconf2.Backward = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf2.Backward = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionLeftKey2 = delegate(MenuItem menuItem)
            {
                kconf2.Left = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf2.Left = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionRightKey2 = delegate(MenuItem menuItem)
            {
                kconf2.Right = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf2.Right = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionFireKey2 = delegate(MenuItem menuItem)
            {
                kconf2.Fire = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf2.Fire = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionNextWeaponKey2 = delegate(MenuItem menuItem)
            {
                kconf2.NextWeapon = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf2.NextWeapon = key; configuration.Save(); });
            };

            MenuItem.ActionHandler actionPrevWeaponKey2 = delegate(MenuItem menuItem)
            {
                kconf2.PrevWeapon = Keys.None;
                menuModel.WaitForKey(delegate(Keys key) { kconf2.PrevWeapon = key; configuration.Save(); });
            };


            // Build Main Menu
            MenuItem mainMenuStartGame = new MenuItem(actionStartGame, delegate() { return "Start Game"; });
            MenuItem mainMenuOptions = new MenuItem(actionMainOptions, delegate() { return "Options"; });
            MenuItem mainMenuHelp = new MenuItem(actionHelp, delegate() { return "Help"; });
            MenuItem mainMenuHighscore = new MenuItem(actionHighscore, delegate() { return "Highscore"; });
            MenuItem mainMenuQuitProgram = new MenuItem(actionQuit, delegate() { return "Quit Program"; });

            MenuItem[] mainMenuItems = { 
                                           mainMenuStartGame, 
                                           mainMenuOptions, 
                                           //mainMenuHelp, 
                                           //mainMenuHighscore, 
                                           mainMenuQuitProgram 
                                       };
            MenuDialog mainMenu = new MenuDialog(mainMenuItems);

            // Build Pause Menu
            MenuItem pauseMenuResumeGame = new MenuItem(actionResumeGame, delegate() { return "Resume Game"; });
            MenuItem pauseMenuStartNewGame = new MenuItem(actionStartGame, delegate() { return "Start new Game"; });
            MenuItem pauseMenuOptions = new MenuItem(actionPauseOptions, delegate() { return "Options"; });
            MenuItem pauseMenuHelp = new MenuItem(actionHelp, delegate() { return "Help"; });
            MenuItem pauseMenuHighscore = new MenuItem(actionHighscore, delegate() { return "Highscore"; });
            MenuItem pauseMenuQuitProgram = new MenuItem(actionQuit, delegate() { return "Quit Program"; });

            MenuItem[] pauseMenuItems = { 
                                            pauseMenuResumeGame, 
                                            pauseMenuStartNewGame, 
                                            pauseMenuOptions, 
                                            //pauseMenuHelp, 
                                            //pauseMenuHighscore, 
                                            pauseMenuQuitProgram 
                                        };
            MenuDialog pauseMenu = new MenuDialog(pauseMenuItems);

            // Build Options Menues
            MenuItem optionsMenuVolume = new MenuItem(actionVolume, delegate() { return "Volume"; });
            MenuItem optionsMenuDifficulty = new MenuItem(actionDifficulty, delegate() { return "Difficulty"; });
            MenuItem optionsMenuKeyboardConfiguration1 = new MenuItem(actionKeyboardConfiguration1, delegate() { return "Player 1 Controls"; });
            MenuItem optionsMenuKeyboardConfiguration2 = new MenuItem(actionKeyboardConfiguration2, delegate() { return "Player 2 Controls"; });
            MenuItem optionsMenuReturnToMainMenu = new MenuItem(actionReturnToMainMenu, delegate() { return "Return to Main Menu"; });
            MenuItem optionsMenuReturnToPauseMenu = new MenuItem(actionReturnToPauseMenu, delegate() { return "Return to Pause Menu"; });

            MenuItem[] optionsMainMenuItems = { 
                                                  optionsMenuKeyboardConfiguration1, 
                                                  optionsMenuKeyboardConfiguration2, 
                                                  //optionsMenuVolume, 
                                                  //optionsMenuDifficulty, 
                                                  optionsMenuReturnToMainMenu 
                                              };
            MenuItem[] optionsPauseMenuItems = { 
                                                   optionsMenuKeyboardConfiguration1, 
                                                   optionsMenuKeyboardConfiguration2, 
                                                   //optionsMenuVolume, 
                                                   optionsMenuReturnToPauseMenu 
                                               };
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
            MenuItem keyConfig1ForwardKey = new MenuItem(actionForwardKey1, delegate() { return "Forward: " + FormatKey(kconf1.Forward); });
            MenuItem keyConfig1BackwardKey = new MenuItem(actionBackwardKey1, delegate() { return "Backward: " + FormatKey(kconf1.Backward); });
            MenuItem keyConfig1LeftKey = new MenuItem(actionLeftKey1, delegate() { return "Left: " + FormatKey(kconf1.Left); });
            MenuItem keyConfig1RightKey = new MenuItem(actionRightKey1, delegate() { return "Right: " + FormatKey(kconf1.Right); });
            MenuItem keyConfig1FireKey = new MenuItem(actionFireKey1, delegate() { return "Fire: " + FormatKey(kconf1.Fire); });
            MenuItem keyConfig1NextWeaponKey = new MenuItem(actionNextWeaponKey1, delegate() { return "Next Weapon: " + FormatKey(kconf1.NextWeapon); });
            MenuItem keyConfig1PrevWeaponKey = new MenuItem(actionPrevWeaponKey1, delegate() { return "Previous Weapon: " + FormatKey(kconf1.PrevWeapon); });
            MenuItem keyConfig1ReturnToOptions = new MenuItem(actionReturn, delegate() { return "Return to Options"; });
            MenuItem[] keyConfigItems1 = { keyConfig1ForwardKey, keyConfig1BackwardKey, keyConfig1LeftKey, keyConfig1RightKey, keyConfig1FireKey,
                                            keyConfig1NextWeaponKey, keyConfig1PrevWeaponKey, keyConfig1ReturnToOptions };
            MenuDialog keyConfig1 = new MenuDialog(keyConfigItems1);

            MenuItem keyConfig2ForwardKey = new MenuItem(actionForwardKey2, delegate() { return "Forward: " + FormatKey(kconf2.Forward); });
            MenuItem keyConfig2BackwardKey = new MenuItem(actionBackwardKey2, delegate() { return "Backward: " + FormatKey(kconf2.Backward); });
            MenuItem keyConfig2LeftKey = new MenuItem(actionLeftKey2, delegate() { return "Left: " + FormatKey(kconf2.Left); });
            MenuItem keyConfig2RightKey = new MenuItem(actionRightKey2, delegate() { return "Right: " + FormatKey(kconf2.Right); });
            MenuItem keyConfig2FireKey = new MenuItem(actionFireKey2, delegate() { return "Fire: " + FormatKey(kconf2.Fire); });
            MenuItem keyConfig2NextWeaponKey = new MenuItem(actionNextWeaponKey2, delegate() { return "Next Weapon: " + FormatKey(kconf2.NextWeapon); });
            MenuItem keyConfig2PrevWeaponKey = new MenuItem(actionPrevWeaponKey2, delegate() { return "Previous Weapon: " + FormatKey(kconf2.PrevWeapon); });
            MenuItem keyConfig2ReturnToOptions = new MenuItem(actionReturn, delegate() { return "Return to Options"; });
            MenuItem[] keyConfigItems2 = { keyConfig2ForwardKey, keyConfig2BackwardKey, keyConfig2LeftKey, keyConfig2RightKey, keyConfig2FireKey,
                                            keyConfig2NextWeaponKey, keyConfig2PrevWeaponKey, keyConfig2ReturnToOptions };
            MenuDialog keyConfig2 = new MenuDialog(keyConfigItems2);


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
                                       volume, difficulty, keyConfig1, keyConfig2};
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
                    MenuItemView menuItemView = new MenuItemView(menuItem);
                    menuItemViewList.Add(menuItemView);
                }

                // TODO: add background texture (3rd argument)
                MenuDialogView menuDialogView = new MenuDialogView(menuItemViewList.ToArray(), menuDialog);
                menuDialogViewList.Add(menuDialogView);
            }

            MenuView menuView = new MenuView(menuDialogViewList.ToArray(), menuModel);
            return menuView;
        }
    }
}
