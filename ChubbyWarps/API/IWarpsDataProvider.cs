using Rocket.API.DependencyInjection;

namespace ChubbyWarps.API
{
    public interface IWarpsDataProvider : IService
    {
        WarpsData Data { get; }

        void Load();

        void Reload();

        void Save();
    }
}
