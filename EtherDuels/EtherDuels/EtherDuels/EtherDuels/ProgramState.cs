using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels
{   
    /// <summary>
    /// Defines all states the game can have.
    /// </summary>
    public enum GameState
    {
        GamePaused,
        InGame,
        NoGame
    }

    /// <summary>
    /// Defines all states the menu can have.
    /// </summary>
    public enum MenuState
    {
        InMenu,
        NoMenu
    }

    /// <summary>
    /// Defines the state of the program.
    /// A programstate cointains the state of its menu and
    /// its game. It changes dynamically while using the program.
    /// </summary>
    class ProgramState
    {
        private GameState gameState;

        /// <summary>
        /// Gets and sets the current GameState.
        /// </summary>
        public GameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        private MenuState menuState;

        /// <summary>
        /// Gets and sets the current MenuState.
        /// </summary>
        public MenuState MenuState
        {
            get { return this.menuState; }
            set { this.menuState = value; }
        }
    }
}
