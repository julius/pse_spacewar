using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// This interface defines a CollisionHandler.
    /// It provides a method to inform a higher layer of the game about
    /// a collision that happend in the running game.
    /// </summary>
    public interface CollisionHandler
    {   
        /// <summary>
        /// Defines the reaction to a collision that happend in a game.
        /// </summary>
        /// <param name="object1">The first colliding WorldObject.</param>
        /// <param name="object2">The second colliding worldObject.</param>
        void OnCollision(WorldObject object1, WorldObject object2);
    }
}
