using System.Collections.Generic;
using ChubbyWarps.API;
using MoreLinq;
using Rocket.API.DependencyInjection;
using Rocket.API.User;
using Rocket.Core.I18N;
using Rocket.Core.Plugins;

namespace ChubbyWarps
{
    public sealed class ChubbyWarps : Plugin
    {
        public ChubbyWarps(IDependencyContainer container) : base("ChubbyWarps", container)
        {
            var providers = container.ResolveAll<IDataProvider>();
            providers.ForEach(x => x.Initialize(this));
        }

        public override Dictionary<string, string> DefaultTranslations =>
            new Dictionary<string, string>
            {
                {TranslationKeys.BasicWarpSucceed, "You have successfully warped to {0}."},
                {TranslationKeys.PlayerWarpSucceed, "You have successfully warped to {0}'s {1}."},
                {TranslationKeys.PayWarpSucceed, "You have successfully warped to {0}'s {1} for ${2}." },
                {TranslationKeys.WarpDeleteSucceed, "You have successfully deleted {0}." },
                {TranslationKeys.WarpNotExist, "The requested warp doesn't exist."},
                {TranslationKeys.WarpAlreadyExist, "A warp with that name already exists, please choose another name or delete the original."},
                {TranslationKeys.PlayerNotExist, "The requested player doesn't exist."},
                {TranslationKeys.NotEnoughMoney, "You do not have enough money in your account to pay for that."},
            };

        public void SendLocalizedMessage(IUser user, string key, object[] args) =>
            user.SendLocalizedMessage(Translations, key, args);

        public static class TranslationKeys
        {
            public const string BasicWarpSucceed = "basic_warp_succeed";
            public const string PlayerWarpSucceed = "player_warp_succeed";
            public const string PayWarpSucceed = "pay_warp_succeed";

            public const string WarpDeleteSucceed = "warp_delete_succeed";

            public const string WarpNotExist = "warp_not_exist";
            public const string WarpAlreadyExist = "warp_already_exist";

            public const string PlayerNotExist = "player_not_exist";
            public const string NotEnoughMoney = "not_enough_money";
        }
    }
}
