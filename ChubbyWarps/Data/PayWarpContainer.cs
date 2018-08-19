using System.Collections.Generic;

namespace ChubbyWarps.Data
{
    public sealed class PayWarpContainer
    {
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public List<PayWarp> Warps { get; set; } = new List<PayWarp>();
    }
}
