using System.Collections.Generic;
using ChubbyWarps.Data;

namespace ChubbyWarps.API
{
    public sealed class WarpsData
    {
        public List<BasicWarp> UniversalWarps { get; set; } = new List<BasicWarp>();
        public List<PlayerWarpContainer> PlayerWarps { get; set; } = new List<PlayerWarpContainer>();
        public List<PayWarpContainer> PayWarps { get; set; } = new List<PayWarpContainer>();
    }
}
