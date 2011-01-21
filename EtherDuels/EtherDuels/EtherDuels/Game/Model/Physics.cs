using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// Defines an abstract physics for the calculation of the movement
    /// of all existing world objects.
    /// </summary>
    public abstract class Physics
    {
        // TODO handle never used warning. (for example, try a constructor.. not sure what the right solution is)
        private CollisionHandler collisionHandler;
        private World world;

        /// <summary>
        /// Updates the position of all world objects the world contains
        /// depending on the used physics algorithm.
        /// </summary>
        /// <param name="gameTime">A timeobject, which contains the time that has 
        /// passed since the last call of Update.</param>
        abstract public void Update(GameTime gameTime);
    }
}
