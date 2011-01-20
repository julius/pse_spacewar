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
    /// Defines a concrete ShortLifespanFactory.
    /// It provides methods to create WorldObject with a limited lifespan 
    /// and its fitting views.
    /// </summary>
    public class SimpleShortLifespanObjectFactory : ShortLifespanObjectFactory
    {
        private GameAssets gameAssets = GameAssets.Instance;

        /* TODO: hatte das irgendjemand aus besonderem grund eingefügt oder kann das weg?
        private Microsoft.Xna.Framework.Graphics.Model explosionModel;
        public Microsoft.Xna.Framework.Graphics.Model ExplosionModel
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.explosionModel = value;
            }
        }

        private Microsoft.Xna.Framework.Graphics.Model rocketModel;
        public Microsoft.Xna.Framework.Graphics.Model RocketModel
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.rocketModel = value;
            }
        }

        private Microsoft.Xna.Framework.Graphics.Model laserModel;
        public Microsoft.Xna.Framework.Graphics.Model LaserModel
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.laserModel = value;
            }
        }*/

        
        /// <summary>
        /// Creates a new explosion.
        /// </summary>
        /// <param name="gameTime">The time the explosion was created.</param>
        /// <returns>The created Explosion object.</returns>
        public Explosion CreateExplosion(GameTime gameTime)
        {
            Explosion explosion = new Explosion();
            explosion.CreationTime = gameTime.TotalGameTime;
            gameAssets.SoundExplosion.CreateInstance().Play();
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
        /// Creates a new view for an explosion.
        /// </summary>
        /// <param name="explosion">An Explosion object.</param>
        /// <returns>The created view fitting to the assigned Explosion object.</returns>
        public WorldObjectView CreateExplosionView(Explosion explosion)
        {
            WorldObjectView explosionView = new WorldObjectView(gameAssets.ModelExplosion, explosion);
            return explosionView;
        }

        /// <summary>
        /// Creates a new view for a projectile.
        /// </summary>
        /// <param name="weapon">The type of the weapon to define the projectiles look.</param>
        /// <param name="projectile">A Projectile object.</param>
        /// <returns>The created view fitting the assigned Projectile object.</returns>
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
