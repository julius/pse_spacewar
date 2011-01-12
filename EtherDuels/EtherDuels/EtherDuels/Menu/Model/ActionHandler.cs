using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{
    interface ActionHandler
    {
        void OnAction(MenuItem menuItem);
    }
}
