using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;
using EtherDuels.Config;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public class SimpleShortLifespanObjectFactory : ShortLifespanObjectFactory
    {
        Configuration configuration;

       /* public SimpleShortLifespanObjectFactory(Configuration configuration)
        {
            this.configuration = configuration;
        } */

        public Explosion CreateExplosion(GameTime gameTime)
        {
            Explosion explosion = new Explosion();
            explosion.CreationTime = gameTime.TotalGameTime;
            return explosion;
        }

        public Projectile CreateProjectile(Weapon weapon)
        {
            Projectile projectile = new Projectile();
            switch (weapon)
            {
                case Weapon.Laser: projectile.Attack = 5; break;
                case Weapon.Rocket: projectile.Attack = 10; break;
            }
            return projectile;
        }

        public WorldObjectView CreateExplosionView(Explosion explosion)
        {
            // TODO set correct 3D-Model for Explosion
            WorldObjectView explosionView = new WorldObjectView(null, explosion);
            return explosionView;
        }

        public WorldObjectView CreateProjectileview(Weapon weapon, Projectile projectile)
        {
            // TODO set correct 3D-Model for Explosion
            WorldObjectView projectileView = new WorldObjectView(null, projectile);
            return projectileView;
        }
    }
}
