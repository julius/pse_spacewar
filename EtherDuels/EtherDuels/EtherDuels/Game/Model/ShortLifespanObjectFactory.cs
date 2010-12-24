using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EtherDuels.Game.View;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{
    public interface ShortLifespanObjectFactory
    {
        public Explosion CreateExplosion(GameTime gameTime);
        public Projectile CreateProjectile(Weapon weapon);
        public WorldObjectView CreateExplosionView(Explosion explosion);
        public WorldObjectView CreateProjectileview(Weapon weapon, Projectile projectile);
    }
}
