using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public interface IPlayer {
        Dictionary<string, Item> Inventory { get; set; }
    }
}