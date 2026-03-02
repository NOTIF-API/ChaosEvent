using System;

using Cassie;

using CommandSystem;

using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace ChaosEvent.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class chaos : ICommand
    {
        public string Command => "chaosevent";

        public string[] Aliases => new string[] { "cievent", "itemdrops" };

        public string Description => "Triggers a chaos event for 1 round!";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ch.init"))
            {
                response = $"<color=red>You don't have permissions for use this command!</color> <color=orange>Required have <b>[ch.init]</b> in permissions.yaml</color>";
                return true;
            }
            if (Plugin.Instance.ChaosManager.IsChaos)
            {
                response = "<color=red>Event is running now!</color>";
                return true;
            }
            Plugin.Instance.ChaosManager.IsChaos = true;
            response = "<color=green>Event launched successfully</color>";
            if (!Round.IsLobby) new CassieAnnouncement(new CassieTtsPayload(Plugin.Instance.Config.CassieMessage, Plugin.Instance.Config.CassieTranslation));
            return true;
        }
    }
}
