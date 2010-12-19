using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;

namespace EtherDuels.Game.Model
{
    public interface ShortLifespanObjectFactory
    {
        Explosion CreateExplosion();
        Projectile CreateProjectile();
        ExplosionView CreateExplosionView(Explosion explosion);
        ProjectileView CreateProjectileview(Projectile projectile);
    }
}
