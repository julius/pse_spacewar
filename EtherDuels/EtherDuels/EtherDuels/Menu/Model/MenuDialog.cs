using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// Defines a MenuDialog.
    /// </summary>
    class MenuDialog
    {
        private MenuItem[] menuItems;

        /// <summary>
        /// Gets an array of all MenuItems, the MenuDialog consists of.
        /// </summary>
        public MenuItem[] MenuItems
        {
            get { return this.menuItems; }
        }

        private bool active;

        /// <summary>
        /// Gets and sets if the MenuDialog is active.
        /// </summary>
        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }

        /// <summary>
        /// Creates a new MenuDialog.
        /// </summary>
        /// <param name="menuItems">An array of all MenuItems, 
        /// the MenuDialog consists of. </param>
        public MenuDialog(MenuItem[] menuItems)
        {
            this.menuItems = menuItems;

            // make sure a menu item is selected
            int menuItemIndex = this.GetSelectedMenuItemIndex();
            if (menuItemIndex == -1) this.Down();
        }

        /// <summary>
        /// Passes the action call to its selected MenuItem.
        /// </summary>
        public void Action()
        {
            int menuItemIndex = this.GetSelectedMenuItemIndex();
            if (menuItemIndex == -1) return;

            this.menuItems[menuItemIndex].Action();
        }

        /// <summary>
        /// Moves the selectionof an item one MenuItem down. 
        /// The previous selected MenuItem is unselected now. 
        /// </summary>
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

        /// <summary>
        /// Moves the selection of an item one MenuItem up.
        /// The previous selected MenuItem is unselected now.
        /// </summary>
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
