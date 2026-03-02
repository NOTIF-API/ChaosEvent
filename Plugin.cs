using System;

using Cassie;

using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;

namespace ChaosEvent
{
    public class Plugin: Plugin<Config>
    {
        public override string Author => "notifapi";

        public override bool IgnoreRequiredVersionCheck => false;

        public override Version RequiredExiledVersion => new Version(9, 0, 0);

        public override Version Version => new Version(1, 0, 0);

        public static Plugin Instance { get; private set; } = null;

        public ChaosManager ChaosManager { get; private set; }

        public override void OnEnabled()
        {
            Instance = this;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            ChaosManager = new ChaosManager();
            ChaosManager.InitEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundEnded -= OnRoundEnded;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            ChaosManager.DisableEvent();
            ChaosManager = null;
            Instance = null;
            base.OnDisabled();
        }

        private void OnRoundEnded(RoundEndedEventArgs e)
        {
            ChaosManager.IsChaos = false;
        }

        private void OnRoundStarted()
        {
            if (!Config.IsCassieEnabled) return;
            if (!ChaosManager.IsChaos) return;
            if (string.IsNullOrEmpty(Config.CassieMessage)) return;
            new CassieAnnouncement(new CassieTtsPayload(Plugin.Instance.Config.CassieMessage, Plugin.Instance.Config.CassieTranslation));
        }
    }
}