using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.Model;

namespace EtherDuels.Config
{
    interface ConfigurationRetriever
    {
        int Difficulty { get; }
        int Difficulty_AI { get; }
        KeyboardConfiguration GetKeyboardConfiguration(int playerID);
    }
}
