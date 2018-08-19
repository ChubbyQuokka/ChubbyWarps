using System;
using Rocket.API.Player;
using Rocket.API.User;

namespace ChubbyWarps.Extensions
{
    public static class UserExtension
    {
        public static bool IsWarpableUser(this IUser user) => user is IPlayerUser<IPlayer<IPlayerEntity<IPlayer>, IPlayerUser<IPlayer>, IPlayer>>;

        public static IPlayerEntity GetPlayerEntity(this IUser user)
        {
            if (!user.IsWarpableUser())
                throw new ArgumentException("Argument must be castable to `IPlayerUser<IPlayer<IPlayerEntity<IPlayer>, IPlayerUser<IPlayer>, IPlayer>>`!", nameof(user));

            return ((IPlayerUser<IPlayer<IPlayerEntity<IPlayer>, IPlayerUser<IPlayer>, IPlayer>>) user).Player.Entity;
        }
    }
}
