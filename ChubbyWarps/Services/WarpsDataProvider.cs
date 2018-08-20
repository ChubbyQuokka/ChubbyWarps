using ChubbyWarps.Data;
using Rocket.API.Configuration;

namespace ChubbyWarps.Services
{
    public sealed class WarpsDataProvider : DataProvider<WarpsData>
    {
        public WarpsDataProvider(IConfiguration configuration) : base(configuration) { }
        public override string Name => "Data";
    }
}
