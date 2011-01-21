using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

using EtherDuels.Game.View;
using EtherDuels.Game.Model;

namespace EtherDuels.Game
{
    /// <summary>
    /// Provides methods to build a new game.
    /// </summary>
    public interface GameBuilder
    {
        /// <summary>
        /// Sets the assigned CollisionHandler.
        /// </summary>
        CollisionHandler CollisionHandler { set; }

        /// <summary>
        /// Sets the assigned PlayerHandler.
        /// </summary>
        PlayerHandler PlayerHandler { set; }

        /// <summary>
        /// Creates a new GameModel.
        /// </summary>
        /// <returns>The created GameModel.</returns>
        GameModel BuildModel();

        /// <summary>
        /// Creates a new GameView.
        /// </summary>
        /// <param name="menuModel">The assigned GameModel.</param>
        /// <returns>The created GameView.</returns>
        GameView BuildView(GameModel model);
    }
}
