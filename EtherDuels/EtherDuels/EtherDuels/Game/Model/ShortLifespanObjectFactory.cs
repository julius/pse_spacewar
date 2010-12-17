using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    interface ShortLifespanObjectFactory
    {
        public Explosion CreateExplosion();
        public Projectile CreateProjectile();
        public ExplosionView CreateExplosionView(Explosion explosion);
        public ProjectileView CreateProjectileview(Projectile projectile);
    }
}
