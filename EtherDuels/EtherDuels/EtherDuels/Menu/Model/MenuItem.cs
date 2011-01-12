using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{
    class MenuItem
    {
        private ActionHandler actionHandler;
        private DataProvider dataProvider;
        
        private bool selected;
        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        public string Text
        {
            get { return this.dataProvider.GetText(); }
        }

        public MenuItem(ActionHandler actionHandler, DataProvider dataProvider)
        {
            this.actionHandler = actionHandler;
            this.dataProvider = dataProvider;
        }

        public void Action()
        {
            this.actionHandler.OnAction(this);
        }
    }
}
