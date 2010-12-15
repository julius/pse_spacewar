using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    interface PlayerHandler
    {
        void OnFire(Spaceship shooter);
    }
}
