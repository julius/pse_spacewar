using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// Provides a method to define the reaction to an action call.
    /// </summary>
    interface ActionHandler
    {
        /// <summary>
        /// Defines the reaction to an action call.
        /// </summary>
        /// <param name="menuItem">The MenuItem, which called its Handler.</param>
        void OnAction(MenuItem menuItem);
    }
}
