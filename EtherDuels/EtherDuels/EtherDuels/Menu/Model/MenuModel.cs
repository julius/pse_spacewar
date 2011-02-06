using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// The MenuModel is the biggest component of the menu and is responsible for updating the menu logic.
    /// </summary>
    public class MenuModel
    {
        public delegate void KeySetter(Keys key);

        private MenuDialog[] menuDialogs;
        private int previousDialog = 0;
        private int winningPlayerID;
        public int WinningPlayerID
        {
            get { return this.winningPlayerID; }
        }

        /// <summary>
        /// Returns an array of all MenuDialogs which are being used by the menu.
        /// </summary>
        public MenuDialog[] MenuDialogs
        {
            get { return this.menuDialogs; }
            set { this.menuDialogs = value; }
        }

        private KeySetter keyWaiter;

        /// <summary>
        /// When true, the menu is waiting for a single key.
        /// Used for changing keyboard controls of players.
        /// </summary>
        public bool IsWaitingForKey
        {
            get { return this.keyWaiter != null; }
        }

        /// <summary>
        /// Makes the menu wait for a single key to be pressed.
        /// </summary>
        /// <param name="keyWaiter">Delegate which is called when a key is finally pressed.</param>
        public void WaitForKey(KeySetter keyWaiter)
        {
            this.keyWaiter = keyWaiter;
        }

        /// <summary>
        /// Is called to give the menu the key, it is waiting for.
        /// See WaitForKey(..)
        /// </summary>
        /// <param name="key">Key which is pressed</param>
        public void SetWaitingKey(Keys key)
        {
            this.keyWaiter(key);
            this.keyWaiter = null;
        }


        /// <summary>
        /// Passes the action call to its selected MenuDialog.
        /// </summary>
        virtual public void Action()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            MenuAssets.Instance.SoundMenuClick.CreateInstance().Play();
            this.menuDialogs[menuDialogIndex].Action();
        }

        /// <summary>
        /// Passes the down call to its selected MenuDialog.
        /// </summary>
        virtual public void Down()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            MenuAssets.Instance.SoundMenuClick.CreateInstance().Play();
            this.menuDialogs[menuDialogIndex].Down();
        }

        /// <summary>
        /// Passes the up call to its selected MenuDialog.
        /// </summary>
        virtual public void Up()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            MenuAssets.Instance.SoundMenuClick.Play();
            this.menuDialogs[menuDialogIndex].Up();
        }

        /// <summary>
        /// Sets the main menu dialog active.
        /// </summary>
        virtual public void SetMainMenu()
        {
            this.SetActiveDialogByIndex(0);
        }

        /// <summary>
        /// Sets the pause menu dialog active.
        /// </summary>
        virtual public void SetPauseMenu()
        {
            this.SetActiveDialogByIndex(1);
        }

        /// <summary>
        /// Sets the game ended menu active.
        /// </summary>
        /// <param name="playerID">Id of the wining player.</param>
        virtual public void SetGameEndedMenu(int playerID)
        {
            this.winningPlayerID = playerID;
            this.SetActiveDialogByIndex(10);
        }

        /// <summary>
        /// Sets the specified dialog active.
        /// </summary>
        /// <param name="index">index of dialog to be set active</param>
        public void SetActiveDialogByIndex(int index)
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();

            if (menuDialogIndex != -1)
            {
                previousDialog = menuDialogIndex;
                this.menuDialogs[menuDialogIndex].Active = false;
            }

            this.menuDialogs[index].Active = true;
        }

        /// <summary>
        /// Sets the previous dialog active.
        /// </summary>
        public void SetPreviousDialogActive()
        {
            SetActiveDialogByIndex(previousDialog);
        }

        /// <summary>
        /// Returns the index of the menu dialog which is currently active.
        /// </summary>
        /// <returns>The index of the dialog. Returns -1 if no dialog is active.</returns>
        private int GetActiveMenuDialogIndex()
        {
            for (int i = 0; i < this.menuDialogs.Length; i += 1)
            {
                if (this.menuDialogs[i].Active)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
