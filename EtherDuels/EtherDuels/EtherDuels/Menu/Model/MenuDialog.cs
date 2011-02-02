using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// A MenuDialog is a group of MenuItems which have a specific functionality.
    /// </summary>
    public class MenuDialog
    {
        private MenuItem[] menuItems;
        private bool active;

        /// <summary>
        /// Returns an array of all MenuItems the MenuDialog consists of.
        /// </summary>
        public MenuItem[] MenuItems
        {
            get { return this.menuItems; }
        }

        /// <summary>
        /// Gets and sets the active property of a MenuDialog.
        /// </summary>
        public bool Active
        {
            get { return this.active; }
            set { this.active = value; }
        }

        /// <summary>
        /// Creates a new MenuDialog.
        /// </summary>
        /// <param name="menuItems">An array of all MenuItems the MenuDialog consists of.</param>
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
        /// Sets the MenuItem beneath the currently selected one to selected.
        /// The previously selected MenuItem is set to not selected.
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
            if (this.menuItems[menuItemIndex].IsStaticText)
                this.Down();
        }

        /// <summary>
        /// Sets the MenuItem above the currently selected one to selected.
        /// The previously selected Menuitem is set to not selected.
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
            if (this.menuItems[menuItemIndex].IsStaticText)
                this.Up();
        }

        /// <summary>
        /// Returns the index of the menu item which is currently selected.
        /// </summary>
        /// <returns>The index of the currently selected item. Returns -1 if no item is selected.</returns>
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
