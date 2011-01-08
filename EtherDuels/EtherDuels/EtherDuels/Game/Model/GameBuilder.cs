using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;

namespace EtherDuels.Game.Model
{
    public interface GameBuilder
    {
        GameModel BuildModel();
        GameView BuildView(GameModel model);
        World BuildWorld();
        WorldView BuildWorldView(World world);
    }
}
