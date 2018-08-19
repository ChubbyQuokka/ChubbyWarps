using Rocket.API.DependencyInjection;
using Rocket.API.Plugins;

namespace ChubbyWarps.API
{
    public interface IWarpsDataProvider : IService
    {
        WarpsData Data { get; }

        void Load();

        void Reload();

        void Save();

        void Initialize(IPlugin plugin);
    }
}
