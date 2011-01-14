using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game
{
    interface ConfigurationRetriever
    {
        //int GetDifficulty();
        //int GetDifficultyAI();
        KeyboardConfiguration GetKeyboardConfiguration(int playerID);

        int Difficulty_AI
        {
            get; set; 
        }

        int Difficulty
        {
            get; set;
        }
    }
}
