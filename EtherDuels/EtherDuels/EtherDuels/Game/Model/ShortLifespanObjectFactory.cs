using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public interface ShortLifespanObjectFactory
    {
        Explosion CreateExplosion(GameTime gameTime);
        Projectile CreateProjectile(Weapon weapon);
        WorldObjectView CreateExplosionView(Explosion explosion);
        WorldObjectView CreateProjectileview(Weapon weapon, Projectile projectile);
    }
}
