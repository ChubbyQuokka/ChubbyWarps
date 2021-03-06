﻿using ChubbyWarps.API;
using ChubbyWarps.Services;
using Rocket.API.DependencyInjection;

namespace ChubbyWarps.Properties
{
    public sealed class DependencyRegistrator : IDependencyRegistrator
    {
        public void Register(IDependencyContainer container, IDependencyResolver resolver)
        {
            container.RegisterSingletonType<IDataProvider, WarpsDataProvider>("data");
            container.RegisterSingletonType<IDataProvider, ConfigDataProvider>("config");
        }
    }
}
