using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using EtherDuels.Game.View;
using EtherDuels.Config;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Defines a simple ShortLifespanObjectFactory.
    /// It provides methods to create world objects with a limited lifespan 
    /// and its fitting views.
    /// </summary>
    public class SimpleShortLifespanObjectFactory : ShortLifespanObjectFactory
    {
        private GameAssets gameAssets = GameAssets.Instance;

        /// <summary>
        /// Creates a new Explosion object.
        /// </summary>
        /// <param name="gameTime">The GameTime which defines the explosion's creation time.</param>
        /// <returns>The created Explosion object.</returns>
        public Explosion CreateExplosion(GameTime gameTime)
        {
            Explosion explosion = new Explosion();
            explosion.CreationTime = gameTime.TotalGameTime;
            gameAssets.SoundExplosion.CreateInstance().Play();
            return explosion;
        }

        /// <summary>
        /// Creates a new Projectile object.
        /// </summary>
        /// <param name="weapon">The weapon which shot the projectile.</param>
        /// <returns>The created Projectile object.</returns>
        public Projectile CreateProjectile(Weapon weapon)
        {
            Projectile projectile = new Projectile();
            switch (weapon)
            {
                case Weapon.Laser:
                    {
                        projectile.Attack = 5;
                        projectile.Health = 5;
                        projectile.Weapon = Weapon.Laser;
                        gameAssets.SoundLaser.CreateInstance().Play();
                        break;
                    }
                    
                case Weapon.Rocket:
                    {
                        projectile.Attack = 10;
                        projectile.Health = 10;
                        projectile.Weapon = Weapon.Rocket;
                        gameAssets.SoundRocket.CreateInstance().Play();
                        break;
                    }
            }
            return projectile;
        }

        /// <summary>
        /// Creates a new WorldObjectView of an explosion.
        /// </summary>
        /// <param name="explosion">The Explosion object needed to create the accordant view.</param>
        /// <returns>The created WorldObjectView of an explosion.</returns>
        public WorldObjectView CreateExplosionView(Explosion explosion)
        {
            WorldObjectView explosionView = new WorldObjectView(gameAssets.ModelExplosion, explosion);
            return explosionView;
        }

        /// <summary>
        /// Creates a new WorldObjectView of a projectile.
        /// </summary>
        /// <param name="weapon">The weapon which shot the projectile.</param>
        /// <param name="projectile">The Projectile object needed to create the accordant view.</param>
        /// <returns>The created WorldObjectView of a projectile.</returns>
        public WorldObjectView CreateProjectileView(Weapon weapon, Projectile projectile)
        {
            WorldObjectView projectileView = null;
            switch (weapon)
            {
                case Weapon.Laser:
                    {
                        projectileView = new WorldObjectView(gameAssets.ModelLaser, projectile);
                        break;
                    }
                case Weapon.Rocket:
                    {
                        projectileView = new WorldObjectView(gameAssets.ModelRocket, projectile);
                        break;
                    }
            }
            return projectileView;
        }
    }
}
