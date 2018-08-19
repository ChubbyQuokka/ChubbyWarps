using System;
using System.Collections.Generic;
using ChubbyWarps.Data;
using ChubbyWarps.Extensions;
using Rocket.API.Commands;
using Rocket.API.Player;
using Rocket.API.Plugins;
using Rocket.Core.Commands;

namespace ChubbyWarps.Commands
{
    public sealed class CommandSetWarp : ICommand
    {
        private readonly ChubbyWarps _plugin;

        public CommandSetWarp(IPlugin plugin)
        {
            _plugin = (ChubbyWarps)plugin;
        }

        public string Name => "SetWarp";
        public string[] Aliases => new string[0];
        public string Summary => "Sets a warp to your current location";
        public string Description => null;
        public string Syntax => "<name>";
        public IChildCommand[] ChildCommands => new IChildCommand[0];
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
        public CommandSetWarpBasic(IPlugin plugin) : base(plugin) { }

        private List<PlayerWarpContainer> _warps => Plugin.DataProvider.Data.PlayerWarps;

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
        public CommandSetWarpPlayer(IPlugin plugin) : base(plugin) { }
        
        private List<PlayerWarpContainer> _warps => Plugin.DataProvider.Data.PlayerWarps;

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
        public CommandSetWarpPay(IPlugin plugin) : base(plugin) { }

        private List<PayWarpContainer> _warps => Plugin.DataProvider.Data.PayWarps;

        public override string Name => "pay";
        public override string[] Aliases => new string[0];
        public override string Summary => "Sets the warp as a pay per warp.";
        public override string Description => null;

        protected override void ExecuteChild(IPlayerEntity entity, IEnumerable<string> parameters)
        {

        }
    }
}
