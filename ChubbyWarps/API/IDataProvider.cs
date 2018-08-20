using Rocket.API.DependencyInjection;
using Rocket.API.Plugins;

namespace ChubbyWarps.API
{
    public interface IDataProvider<T> : IService, IDataProvider where T : new()
    {
        T Data { get; set; }
    }

    public interface IDataProvider
    {
        string Name { get; }

        void Load();

        void Reload();

        void Save();

        void Initialize(IPlugin plugin);
    }
}
