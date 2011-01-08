using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game
{
    public interface GameHandler
    {
        void OnGamePaused();
        void OnGameEnded(int playerID, int points);
    }
}
