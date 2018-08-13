using ChubbyWarps.API;
using ChubbyWarps.Services;
using Rocket.API.DependencyInjection;
using Rocket.Core.Plugins;

namespace ChubbyWarps
{
    public sealed class ChubbyWarps : Plugin
    {
        private readonly IWarpsDataProvider dataProvider;

        public ChubbyWarps(IDependencyContainer container) : base("Warps", container)
        {
            dataProvider = container.Resolve<IWarpsDataProvider>("warps");

            (dataProvider as WarpsDataProvider).Initialize(this);
        }
    }
}
