using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{
    class SimpleShortLifespanObjectFactory : ShortLifespanObjectFactory
    {
        public Explosion CreateExplosion()
        {
            Explosion explosion = new Explosion();
            explosion.SetCreationTime(TimeSpan.G
        }

        public Projectile CreateProjectile()
        {
            throw new NotImplementedException();
        }

        public ExplosionView CreateExplosionView(Explosion explosion)
        {
            throw new NotImplementedException();
        }

        public ProjectileView CreateProjectileview(Projectile projectile)
        {
            throw new NotImplementedException();
        }
    }
}
