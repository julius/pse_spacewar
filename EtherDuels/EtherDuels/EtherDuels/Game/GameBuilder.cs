using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

using EtherDuels.Game.View;
using EtherDuels.Game.Model;

namespace EtherDuels.Game
{
    //TODO: kommentieren
    public interface GameBuilder
    {
        CollisionHandler CollisionHandler { set; }
        PlayerHandler PlayerHandler { set; }
        GameModel BuildModel();
        GameView BuildView(GameModel model);
    }
}
