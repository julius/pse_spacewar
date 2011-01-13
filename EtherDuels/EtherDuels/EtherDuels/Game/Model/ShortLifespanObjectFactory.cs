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
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns></returns>
        Explosion CreateExplosion(GameTime gameTime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns></returns>
        Projectile CreateProjectile(Weapon weapon);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="explosion"></param>
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
