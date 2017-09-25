using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Room : IRoom {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }
        public void UseMysteriousKey(Item item) {

        }

		public Room(string name, string description) {
			Name = name;
			Description = description;
			Items = new Dictionary<string, Item>();
            Exits = new Dictionary<string, Room>();
		}
    }
}