using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Menu.Model;
using EtherDuels.Menu.View;
using Microsoft.Xna.Framework.Graphics;

namespace EtherDuels.Menu
{   
    /// <summary>
    /// Provides methods to build a new menu.
    /// </summary>
    interface MenuBuilder
    {
        Texture2D Background { set; }

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
