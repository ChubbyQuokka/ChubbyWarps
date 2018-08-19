using System.Numerics;
using ChubbyWarps.API;

namespace ChubbyWarps.Data
{
    public class BasicWarp : IWarpType
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }
    }
}
