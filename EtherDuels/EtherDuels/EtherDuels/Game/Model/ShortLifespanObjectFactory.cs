using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;

using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface ShortLifespanObjectFactory
    {   
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
        /// Creates a new WorldObjectView for an explosion.
        /// </summary>
        /// <param name="explosion">The Explosion object.</param>
        /// <returns></returns>
        WorldObjectView CreateExplosionView(Explosion explosion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weapon"></param>
        /// <param name="projectile"></param>
        /// <returns></returns>
        WorldObjectView CreateProjectileview(Weapon weapon, Projectile projectile);
    }
}
