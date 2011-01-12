using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;
using EtherDuels.Config;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines a concrete ShortLifespanFactory.
    /// It provides methods to create WorldObject with a limited lifespan 
    /// and its fitting views.
    /// </summary>
    public class SimpleShortLifespanObjectFactory : ShortLifespanObjectFactory
    {
        Configuration configuration;

       /* public SimpleShortLifespanObjectFactory(Configuration configuration)
        {
            this.configuration = configuration;
        } */

        /// <summary>
        /// Creates a new explosion.
        /// </summary>
        /// <param name="gameTime">The time the explosion was created.</param>
        /// <returns>The created Explosion object.</returns>
        public Explosion CreateExplosion(GameTime gameTime)
        {
            Explosion explosion = new Explosion();
            explosion.CreationTime = gameTime.TotalGameTime;
            return explosion;
        }
        /// <summary>
        /// Creates a new projectile.
        /// </summary>
        /// <param name="weapon">The type of the weapon to define a projectiles attackpower.</param>
        /// <returns>The created Projectile object.</returns>
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

        /// <summary>
        /// Creates a new view for an explosion.
        /// </summary>
        /// <param name="explosion">An Explosion object.</param>
        /// <returns>The created view fitting to the assigned Explosion object.</returns>
        public WorldObjectView CreateExplosionView(Explosion explosion)
        {
            // TODO set correct 3D-Model for Explosion
            WorldObjectView explosionView = new WorldObjectView(null, explosion);
            return explosionView;
        }

        /// <summary>
        /// Creates a new view for a projectile.
        /// </summary>
        /// <param name="weapon">The type of the weapon to define the projectiles look.</param>
        /// <param name="projectile">A Projectile object.</param>
        /// <returns>The created view fitting the assigned Projectile object.</returns>
        public WorldObjectView CreateProjectileview(Weapon weapon, Projectile projectile)
        {
            // TODO set correct 3D-Model for Explosion
            WorldObjectView projectileView = new WorldObjectView(null, projectile);
            return projectileView;
        }
    }
}
