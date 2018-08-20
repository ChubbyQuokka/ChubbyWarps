using System;
using ChubbyWarps.API;
using Rocket.API.Configuration;
using Rocket.API.Plugins;
using Rocket.Core.Configuration;

namespace ChubbyWarps.Services
{
    public abstract class DataProvider<T> : IDataProvider<T> where T : new()
    {
        private IPlugin _plugin;
        private readonly IConfiguration _configuration;
        private bool _isInitialized;

        public abstract string Name { get; }

        public T Data { get; set; }

        protected DataProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Initialize(IPlugin plugin)
        {
            if (_isInitialized)
                throw new NotSupportedException("DataProvider is already initialized!");

            _plugin = plugin;
            Load();

            _isInitialized = true;
        }

        public void Load()
        {
            var context = new ConfigurationContext(_plugin, Name);
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
    }
}
