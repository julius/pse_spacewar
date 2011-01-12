using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;

namespace EtherDuels.Menu
{
    interface MenuBuilder
    {
        MenuModel BuildModel();
        MenuView BuildView(MenuModel menuModel);
    }
}
