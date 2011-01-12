using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{
    class MenuItem
    {
        public delegate string TextProvider();
        public delegate void ActionHandler(MenuItem menuItem);

        private ActionHandler actionHandler;
        private TextProvider textProvider;
        
        private bool selected;
        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        public string Text
        {
            get { return this.textProvider(); }
        }

        public MenuItem(ActionHandler actionHandler, TextProvider textProvider)
        {
            this.actionHandler = actionHandler;
            this.textProvider = textProvider;
        }

        public void Action()
        {
            this.actionHandler(this);
        }
    }
}
