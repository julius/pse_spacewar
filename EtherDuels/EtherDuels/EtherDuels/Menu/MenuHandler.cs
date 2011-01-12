using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Menu
{
    interface MenuHandler
    {
        void OnNewGame();
        void OnQuitProgram();
        void OnResumeGame();
    }
}
