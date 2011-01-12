using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{
    class MenuDialog
    {
        private MenuItem[] menuItems;
        public MenuItem[] MenuItems
        {
            get { return this.menuItems; }
        }

        private bool active;
        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }

        public MenuDialog(MenuItem[] menuItems)
        {
            this.menuItems = menuItems;

            // make sure a menuitem is selected
            int menuItemIndex = this.GetSelectedMenuItemIndex();
            if (menuItemIndex == -1) this.Down();
        }

        public void Action()
        {
            int menuItemIndex = this.GetSelectedMenuItemIndex();
            if (menuItemIndex == -1) return;

            this.menuItems[menuItemIndex].Action();
        }

        public void Down()
        {
            int menuItemIndex = this.GetSelectedMenuItemIndex();

            if (menuItemIndex != -1)
            {
                this.menuItems[menuItemIndex].Selected = false;
            }

            menuItemIndex += 1;
            if (menuItemIndex >= this.menuItems.Length) menuItemIndex = 0;

            this.menuItems[menuItemIndex].Selected = true;
        }

        public void Up()
        {
            int menuItemIndex = this.GetSelectedMenuItemIndex();

            if (menuItemIndex != -1)
            {
                this.menuItems[menuItemIndex].Selected = false;
            }

            menuItemIndex -= 1;
            if (menuItemIndex < 0) menuItemIndex = this.menuItems.Length - 1;

            this.menuItems[menuItemIndex].Selected = true;
        }

        /// <summary>
        /// Gets index of the menu item, which is selected.
        /// </summary>
        /// <returns>The index of the item. -1 if no item is selected.</returns>
        private int GetSelectedMenuItemIndex()
        {
            for (int i = 0; i < this.menuItems.Length; i += 1)
            {
                if (this.menuItems[i].Selected)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
