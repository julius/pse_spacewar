using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    interface CollisionHandler
    {
        void OnCollision(WorldObject object1, WorldObject object2);
    }
}
