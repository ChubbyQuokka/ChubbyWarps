using System;
using Rocket.API.Permissions;
using Rocket.API.Player;
using Rocket.Core.Player;

namespace ChubbyWarps.Extensions
{
    public static class IPlayerEntityExtensions
    {
        public static bool CheckHasPermission(this IPlayerEntity entity, string perm)
        {
            if (!(entity is IPlayerEntity<IPlayer> player))
                throw new NotSupportedException();

            return player.Player.CheckHasAnyPermission(perm) == PermissionResult.Grant;
        }
    }
}
