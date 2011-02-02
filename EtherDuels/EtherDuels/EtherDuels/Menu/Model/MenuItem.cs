using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// A MenuItem is the smallest component of the menu. It has a specific functionality which can be executed via the action() function.
    /// </summary>
    public class MenuItem
    {
        public delegate string TextProvider();
        public delegate void ActionHandler(MenuItem menuItem);
        private ActionHandler actionHandler;
        private TextProvider textProvider;
        private bool selected;

        /// <summary>
        /// Creates a new MenuItem.
        /// </summary>
        /// <param name="actionHandler">The assigned ActionHandler.</param>
        /// <param name="textProvider">The assigned DataProvider.</param>
        public MenuItem(ActionHandler actionHandler, TextProvider textProvider)
        {
            this.actionHandler = actionHandler;
            this.textProvider = textProvider;
        }

        /// <summary>
        /// Returns whether the MenuItem is static text or not.
        /// A MenuItem is defined static text when it does not have an ActionHandler.
        /// </summary>
        public bool IsStaticText
        {
            get { return this.actionHandler == null; }
        }

        /// <summary>
        /// Gets and sets whether the MenuItem is currently selected.
        /// </summary>
        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        /// <summary>
        /// Returns the text the MenuItem shows.
        /// </summary>
        public string Text
        {
            get { return this.textProvider(); }
        }

        /// <summary>
        /// Defines the action performed if the action input was hit.
        /// </summary>
        public void Action()
        {
            this.actionHandler(this);
        }
    }
}
