using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
//using EtherDuels;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Defines an abstract Physics for the calculation of the movement
    /// of all existing WorldObjects.
    /// </summary>
    public abstract class Physics
    {
        // TODO handle never used warning. (for example, try a constructor.. not sure what the right solution is)
        private CollisionHandler collisionHandler;
        private World world;

        /// <summary>
        /// Updates the position of all WorldObject the World contains
        /// depending on the used Physics.
        /// </summary>
        /// <param name="gameTime">A timeobject, which saved how much time is 
        /// passed since the last update.</param>
        abstract public void Update(GameTime gameTime);
    }
}
