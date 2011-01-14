using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// Defines the complete MenuModel.
    /// It is the biggest component of the menu.
    /// </summary>
    class MenuModel
    {   
        private MenuDialog[] menuDialogs;
        
        /// <summary>
        /// Gets an array of all MenuDialogs, which are used by the menu.
        /// </summary>
        public MenuDialog[] MenuDialogs
        {
            get { return this.menuDialogs; }
        }

        /// <summary>
        /// Creates a new MenuModel.
        /// </summary>
        /// <param name="menuDialogs">All MenuDialogs the MenuModel consists of.</param>
        public MenuModel(MenuDialog[] menuDialogs)
        {
            this.menuDialogs = menuDialogs;
        }

        /// <summary>
        /// Passes the action call to its selected MenuDialog.
        /// </summary>
        public void Action()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            this.menuDialogs[menuDialogIndex].Action();
        }

        /// <summary>
        /// Passes the down call to its selected MenuDialog.
        /// </summary>
        public void Down()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            this.menuDialogs[menuDialogIndex].Down();
        }

        /// <summary>
        /// Passes the up call to its selected MenuDialog.
        /// </summary>
        public void Up()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            this.menuDialogs[menuDialogIndex].Up();
        }

        /// <summary>
        /// Sets MenuDialog at index 0 active.
        /// </summary>
        public void SetMainMenu()
        {
            this.SetActiveDialogByIndex(0);
        }

        /// <summary>
        /// Sets MenuDialog at index 1 active.
        /// </summary>
        public void SetPauseMenu()
        {
            this.SetActiveDialogByIndex(1);
        }

        private void SetActiveDialogByIndex(int index)
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();

            if (menuDialogIndex != -1)
            {
                this.menuDialogs[menuDialogIndex].Active = false;
            }

            this.menuDialogs[index].Active = true;
        }

        /// <summary>
        /// Gets index of the menu dialog, which is active.
        /// </summary>
        /// <returns>The index of the dialog. -1 if no dialog is active.</returns>
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
