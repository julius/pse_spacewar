using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherDuels
{
    public enum GameState
    {
        GamePaused,
        InGame,
        NoGame
    }

    public enum MenuState
    {
        InMenu,
        NoMenu
    }

    class ProgramState
    {
        private GameState gameState;
        public GameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        private MenuState menuState;
        public MenuState MenuState
        {
            get { return this.menuState; }
            set { this.menuState = value; }
        }
    }
}
