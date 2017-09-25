using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public interface IGame {
        Room currentRoom { get; set; }
        Player Player { get; set; }

        void InitializeGame();
        void UseMysteriousKey(string itemName);
    }
}