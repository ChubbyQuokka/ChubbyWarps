﻿using ChubbyWarps.Data;
using Rocket.API.Configuration;

namespace ChubbyWarps.Services
{
    public sealed class ConfigDataProvider : DataProvider<ConfigData>
    {
        public ConfigDataProvider(IConfiguration configuration) : base(configuration) { }

        public override string Name => "Configuration";
    }
}
