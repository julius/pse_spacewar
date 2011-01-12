using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;
using EtherDuels.Game.Model;

namespace EtherDuels.Game
{
    public interface GameBuilder
    {
        CollisionHandler CollisionHandler { set; }
        PlayerHandler PlayerHandler { set; }
        GameModel BuildModel();
        GameView BuildView(GameModel model);
    }
}
