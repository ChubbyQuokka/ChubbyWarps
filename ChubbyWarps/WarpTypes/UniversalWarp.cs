using System.Numerics;

namespace ChubbyWarps.API
{
    public sealed class UniversalWarp : IWarpType
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
    }
}
