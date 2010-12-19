using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    public class Spaceship : WorldObject
    {

        Weapon currentWeapon;

        public Weapon GetCurrentWeapon()
        {
            return currentWeapon;
        }

        public void SetCurrentWeapon(Weapon weapon)
        {
            this.currentWeapon = weapon;
        }

    }
}
