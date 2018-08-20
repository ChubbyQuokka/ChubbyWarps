using System.Collections.Generic;

namespace ChubbyWarps.Data
{
    public sealed class WarpsData
    {
        public List<BasicWarp> BasicWarps { get; set; } = new List<BasicWarp>();
        public List<PlayerWarpContainer> PlayerWarps { get; set; } = new List<PlayerWarpContainer>();
        public List<PayWarpContainer> PayWarps { get; set; } = new List<PayWarpContainer>();
    }
}
