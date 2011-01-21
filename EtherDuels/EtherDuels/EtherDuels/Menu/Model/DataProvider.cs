using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu.Model
{   
    /// <summary>
    /// Provides a method to get data. 
    /// </summary>
    interface DataProvider
    {   
        /// <summary>
        /// Gets the text a view has to show.
        /// </summary>
        /// <returns>The text.</returns>
        string GetText();
    }
}
