using System;
using System.Collections.Generic;
using ChubbyWarps.API;
using ChubbyWarps.Data;
using ChubbyWarps.Extensions;
using ChubbyWarps.Services;
using Rocket.API.Commands;
using Rocket.API.Player;
using Rocket.API.Plugins;
using Rocket.Core.Commands;

namespace ChubbyWarps.Commands
{
    public sealed class CommandSetWarp : ICommand
    {
        private readonly IPlugin _plugin;
        private readonly WarpsDataProvider _dataProvider;
        private readonly ConfigDataProvider _configProvider;

        public CommandSetWarp(IPlugin plugin)
        {
            _plugin = plugin;
            _dataProvider = (WarpsDataProvider) plugin.Container.Resolve<IDataProvider>("data");
            _configProvider = (ConfigDataProvider) plugin.Container.Resolve<IDataProvider>("config");
        }

        public string Name => "SetWarp";
        public string[] Aliases => new string[0];
        public string Summary => "Sets a warp to your current location";
        public string Description => null;
        public string Syntax => "<name>";

        public IChildCommand[] ChildCommands =>
            new IChildCommand[]
            {
                new CommandSetWarpBasic(_plugin, _dataProvider, _configProvider),
                new CommandSetWarpPay(_plugin, _dataProvider, _configProvider),
                new CommandSetWarpPlayer(_plugin, _dataProvider, _configProvider),
            };

        public bool SupportsUser(Type user) => typeof(IPlayerUser).IsAssignableFrom(user);

        public void Execute(ICommandContext context) => throw new CommandWrongUsageException();
    }

    public abstract class CommandSetWarpChild : IChildCommand
    {
        protected readonly ChubbyWarps Plugin;

        protected CommandSetWarpChild(IPlugin plugin)
        {
            Plugin = (ChubbyWarps)plugin;
        }
        
        public abstract string Name { get; }
        public abstract string[] Aliases { get; }
        public abstract string Summary { get; }
        public abstract string Description { get; }

        public virtual string Syntax => "<name>";
        public IChildCommand[] ChildCommands => null;
        public bool SupportsUser(Type user) => typeof(IPlayerUser).IsAssignableFrom(user);

        protected abstract void ExecuteChild(IPlayerEntity entity, IEnumerable<string> parameters);

        public void Execute(ICommandContext context)
        {
            var user = context.User;

            if (!user.IsWarpableUser())
                throw new NotSupportedException("The user is not of the correct type; if this was called by an in-game user, please ensure the RocketMod Implementation is finished for your game.");

            if (this is CommandSetWarpPay && context.Parameters.Length != 2)
                throw new CommandWrongUsageException();

            if (!(this is CommandSetWarpPay) && context.Parameters.Length != 1)
                throw new CommandWrongUsageException();

            var entity = user.GetPlayerEntity();

            ExecuteChild(entity, context.Parameters);
        }
    }

    public sealed class CommandSetWarpBasic : CommandSetWarpChild
    {
        private readonly WarpsDataProvider _dataProvider;
        private readonly ConfigDataProvider _configProvider;

        public CommandSetWarpBasic(IPlugin plugin, WarpsDataProvider dataProvider, ConfigDataProvider configProvider) : base(plugin)
        {
            _dataProvider = dataProvider;
            _configProvider = configProvider;
        }

        private List<PlayerWarpContainer> Warps => _dataProvider.Data.PlayerWarps;

        public override string Name => "basic";
        public override string[] Aliases => new string[0];
        public override string Summary => "Sets the warp as a normal warp.";
        public override string Description => null;

        protected override void ExecuteChild(IPlayerEntity entity, IEnumerable<string> parameters)
        {

        }
    }

    public sealed class CommandSetWarpPlayer : CommandSetWarpChild
    {
        private readonly WarpsDataProvider _dataProvider;
        private readonly ConfigDataProvider _configProvider;

        public CommandSetWarpPlayer(IPlugin plugin, WarpsDataProvider dataProvider, ConfigDataProvider configProvider) : base(plugin)
        {
            _dataProvider = dataProvider;
            _configProvider = configProvider;
        }

        private List<PlayerWarpContainer> Warps => _dataProvider.Data.PlayerWarps;

        public override string Name => "player";
        public override string[] Aliases => new string[0];
        public override string Summary => "Sets the warp as a player managed warp.";
        public override string Description => null;

        protected override void ExecuteChild(IPlayerEntity entity, IEnumerable<string> parameters)
        {
            
        }
    }

    public sealed class CommandSetWarpPay : CommandSetWarpChild
    {
        private readonly WarpsDataProvider _dataProvider;
        private readonly ConfigDataProvider _configProvider;

        public CommandSetWarpPay(IPlugin plugin, WarpsDataProvider dataProvider, ConfigDataProvider configProvider) : base(plugin)
        {
            _dataProvider = dataProvider;
            _configProvider = configProvider;
        }

        private List<PayWarpContainer> Warps => _dataProvider.Data.PayWarps;

        public override string Name => "pay";
        public override string[] Aliases => new string[0];
        public override string Summary => "Sets the warp as a pay per warp.";
        public override string Description => null;

        protected override void ExecuteChild(IPlayerEntity entity, IEnumerable<string> parameters)
        {

        }
    }
}
