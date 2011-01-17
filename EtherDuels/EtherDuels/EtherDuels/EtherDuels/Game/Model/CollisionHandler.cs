using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels.Game.Model
{   
    /// <summary>
    /// This interface defines a CollisionHandler.
    /// It provides methods to inform a higher layer of the game of
    /// a collision that happend in the running game.
    /// </summary>
    public interface CollisionHandler
    {   
        /// <summary>
        /// Defines the reaction to a collision that happend in a game.
        /// </summary>
        /// <param name="object1">The first involved WorldObject.</param>
        /// <param name="object2">The second involved worldObject.</param>
        void OnCollision(WorldObject object1, WorldObject object2);
    }
}
