using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// Defines a MenuItem. 
    /// It is the smallest component in the menu.
    /// </summary>
    class MenuItem
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
        /// Gets if the MenuItem is static text.
        /// A MenuItem is static text, when it has no ActionHandler
        /// </summary>
        public bool IsStaticText
        {
            get { return this.actionHandler == null; }
        }

        /// <summary>
        /// Gets and sets if the MenuItem is selected.
        /// </summary>
        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        /// <summary>
        /// Gets the text the MenuItem shows.
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
