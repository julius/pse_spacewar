using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{
    class MenuModel
    {
        private MenuDialog[] menuDialogs;
        public MenuDialog[] MenuDialogs
        {
            get { return this.menuDialogs; }
        }

        public MenuModel(MenuDialog[] menuDialogs)
        {
            this.menuDialogs = menuDialogs;
        }

        public void Action()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            this.menuDialogs[menuDialogIndex].Action();
        }

        public void Down()
        {
            int menuDialogIndex = this.GetActiveMenuDialogIndex();
            if (menuDialogIndex == -1) return;

            this.menuDialogs[menuDialogIndex].Down();
        }

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
