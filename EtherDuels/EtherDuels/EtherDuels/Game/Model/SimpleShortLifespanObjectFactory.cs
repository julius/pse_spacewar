using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;

namespace EtherDuels.Game.Model
{
    public class SimpleShortLifespanObjectFactory : ShortLifespanObjectFactory
    {
        public Explosion CreateExplosion()
        {
            Explosion explosion = new Explosion();
            // TODO continue editing here
            // explosion.SetCreationTime(TimeSpan.G
            return null;
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
