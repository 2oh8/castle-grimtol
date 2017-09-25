using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Player : IPlayer {

        public int Points { get; set; }
        public Dictionary<string, Item> Inventory { get; set; }

        public Player() {

            Inventory = new Dictionary<string, Item>();
        }
    }

}