using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using EtherDuels.Game.View;



namespace EtherDuels.Game.Model
{
    /// <summary>
    /// Provides methods to create WorldObjects with a limited
    /// lifespan and their fitting views.s
    /// </summary>
    public interface ShortLifespanObjectFactory
    {

        Microsoft.Xna.Framework.Graphics.Model ExplosionModel { set; }
        Microsoft.Xna.Framework.Graphics.Model RocketModel { set; }
        Microsoft.Xna.Framework.Graphics.Model LaserModel { set; }

        /// <summary>
        /// Creates a new Explosion object.
        /// </summary>
        /// <param name="gameTime">The GameTime to define the explosion's creationtime.</param>
        /// <returns>The created Explosion object.</returns>
        Explosion CreateExplosion(GameTime gameTime);

        /// <summary>
        /// Creates a new Projectile object.
        /// </summary>
        /// <param name="weapon">The weapon, which shot the projectile.</param>
        /// <returns>The created Projectile object.</returns>
        Projectile CreateProjectile(Weapon weapon);

        /// <summary>
        /// Creates a new WorldObjectView of an explosion.
        /// </summary>
        /// <param name="explosion">The Explosion object to check for position etc. .</param>
        /// <returns>The created WorldObjectView of an explosion.</returns>
        WorldObjectView CreateExplosionView(Explosion explosion);

        /// <summary>
        /// Creates a new WorldObjectView of a projectile.
        /// </summary>
        /// <param name="weapon">The weapon, which shot the projectile to define the right model.</param>
        /// <param name="projectile">The Projectile object to check for position etc. .</param>
        /// <returns>The created WorldObjectView of a projectile.</returns>
        WorldObjectView CreateProjectileView(Weapon weapon, Projectile projectile);
    }
}
