using System;
using ChubbyWarps.API;
using Rocket.API.Configuration;
using Rocket.API.Plugins;
using Rocket.Core.Configuration;

namespace ChubbyWarps.Services
{
    public sealed class WarpsDataProvider : IWarpsDataProvider
    {
        private IPlugin _plugin;
        private readonly IConfiguration _configuration;

        private bool _isInitialized;

        public WarpsDataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Initialize(IPlugin plugin)
        {
            if (_isInitialized)
                throw new NotSupportedException("WarpsDataProvider is already initialized!");

            _plugin = plugin;
            Load();

            _isInitialized = true;
        }

        public void Load()
        {
            var context = new ConfigurationContext(_plugin, "Data");
            _configuration.Load(context, Data);
            Data = _configuration.Get(Data);
        }

        public void Reload()
        {
            _configuration.Reload();
        }

        public void Save()
        {
            _configuration.Set(Data);
            _configuration.Save();
        }

        public WarpsData Data { get; private set; } = new WarpsData();
    }
}
