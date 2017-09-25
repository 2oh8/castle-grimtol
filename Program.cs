using System;
using CastleGrimtol.Project;

namespace CastleGrimtol {
    public class Program {
		public static Game game;
        public static void Main(string[] args) {
			game = new Game();
			game.InitializeGame();
        }
    }
}