using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;

namespace EtherDuels.Menu
{   
    /// <summary>
    /// Provides methods to build a new menu.
    /// </summary>
    interface MenuBuilder
    {   
        /// <summary>
        /// Creates a new MenuModel.
        /// </summary>
        /// <returns>The created MenuModel.</returns>
        MenuModel BuildModel();

        /// <summary>
        /// Creates a new MenuView.
        /// </summary>
        /// <param name="menuModel">The assigned MenuModel.</param>
        /// <returns>The created MenuView.</returns>
        MenuView BuildView(MenuModel menuModel);
    }
}
