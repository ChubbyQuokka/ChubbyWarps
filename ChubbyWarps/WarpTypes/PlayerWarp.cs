using System.Numerics;
using ChubbyWarps.API;

namespace ChubbyWarps.NewFolder
{
    public sealed class PlayerWarp : IWarpType
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public string Owner { get; set; }
    }
}
