using ChubbyWarps.API;
using Rocket.API.Configuration;
using Rocket.API.Plugins;
using Rocket.Core.Configuration;

namespace ChubbyWarps.Services
{
    public sealed class WarpsDataProvider : IWarpsDataProvider
    {
        private IPlugin plugin;
        private readonly IConfiguration configuration;

        public WarpsDataProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        internal void Initialize(IPlugin plugin)
        {
            this.plugin = plugin;
            Load();
        }

        public void Load()
        {
            ConfigurationContext context = new ConfigurationContext(plugin, "Data");
            configuration.Load(context, Data);
            Data = configuration.Get(Data);
        }

        public void Reload()
        {
            configuration.Reload();
        }

        public void Save()
        {
            configuration.Set(Data);
            configuration.Save();
        }

        public WarpsData Data { get; private set; } = new WarpsData();
    }
}
