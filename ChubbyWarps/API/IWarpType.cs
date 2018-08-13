using System.Numerics;

namespace ChubbyWarps.API
{
    public interface IWarpType
    {
        string Name { get; set; }
        Vector3 Position { get; set; }
    }
}
