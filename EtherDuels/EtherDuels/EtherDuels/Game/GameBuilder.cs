using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

using EtherDuels.Game.View;
using EtherDuels.Game.Model;

namespace EtherDuels.Game
{
    public interface GameBuilder
    {
        Texture2D Background { set; }
        Texture2D Smoke { set; }
        Texture2D HealthBar { set; }
        Microsoft.Xna.Framework.Graphics.Model SpaceshipModel { set; }
        Microsoft.Xna.Framework.Graphics.Model PlanetModel { set; }
        Microsoft.Xna.Framework.Graphics.Model RocketModel { set; }
        Microsoft.Xna.Framework.Graphics.Model LaserModel { set; }
        Microsoft.Xna.Framework.Graphics.Model ExplosionModel { set; }
        CollisionHandler CollisionHandler { set; }
        PlayerHandler PlayerHandler { set; }
        GameModel BuildModel();
        GameView BuildView(GameModel model);
    }
}
