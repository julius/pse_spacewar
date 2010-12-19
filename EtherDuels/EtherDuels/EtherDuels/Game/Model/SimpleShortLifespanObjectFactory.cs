using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    class SimpleShortLifespanObjectFactory : ShortLifespanObjectFactory
    {

        Configuration configuration;

        public Explosion CreateExplosion(GameTime gameTime)
        {
            Explosion explosion = new Explosion();
            explosion.SetCreationTime(gameTime.TotalGameTime);
            return explosion;
        }

        public Projectile CreateProjectile(Weapon weapon)
        {
            Projectile projectile = new Projectile();
            switch (weapon)
            {
                case Weapon.Laser: projectile.SetAttack(5); break;
                case Weapon.Rocket: projectile.SetAttack(10); break;
            }
            return projectile;
        }

        public WorldObjectView CreateExplosionView(Explosion explosion)
        {
            WorldObjectView explosionView = new WorldObjectView(explosion);
            return explosionView;
        }

        public WorldObjectView CreateProjectileview(Weapon weapon, Projectile projectile)
        {
            WorldObjectView projectileView = new WorldObjectView(projectile);
            return projectileView;
        }
    }
}
