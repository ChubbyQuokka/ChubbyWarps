using System.Collections.Generic;

namespace ChubbyWarps.Data
{
    public sealed class PlayerWarpContainer
    {
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public List<BasicWarp> Warps { get; set; } = new List<BasicWarp>();
    }
}
