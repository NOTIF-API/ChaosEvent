using System;
using System.Linq;

using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;

using UnityEngine;

namespace ChaosEvent
{
    public class ChaosManager
    {
        public CustomItem[] SpawnableCustom { get; private set; } = new CustomItem[0];

        public bool IsChaos { get; internal set; } = false;

        public ItemType[] Spawnable { get; private set; } = new ItemType[0];

        internal void InitEvents()
        {
            Exiled.Events.Handlers.Player.Dying += OnDied;
            Spawnable = ((ItemType[])Enum.GetValues(typeof(ItemType))).Where(x => !Plugin.Instance.Config.BlackListItems.Contains(x)).ToArray();
            SpawnableCustom = CustomItem.Registered.Where(x => !Plugin.Instance.Config.BlackListCustom.Contains(x.Id)).ToArray();
            Log.Debug($"[InitEvents] New instance with event controller created with supported {Spawnable.Length} game items, {SpawnableCustom.Length} custom items");
        }

        private void OnDied(DyingEventArgs e)
        {
            if (!IsChaos) return;
            if (!e.IsAllowed) return;
            Log.Debug($"[OnDied] Running Died event handling for chaosevent");
            e.ItemsToDrop.Clear();
            Vector3 deadpos = e.Player.Position;
            for (int i = 0; i < UnityEngine.Random.Range(Plugin.Instance.Config.ItemMinFall, Plugin.Instance.Config.ItemMaxFall); i++)
            {
                ItemType random = Spawnable.RandomItem();
                try
                {
                    if (UnityEngine.Random.value * 100f < Plugin.Instance.Config.ChanceForCustom && SpawnableCustom.Length > 0)
                    {
                        Log.Debug("[OnDied] Spawning custom item on speecial position without prev owner");
                        SpawnableCustom.RandomItem().Spawn(deadpos, null);
                        continue;
                    }
                    if (random == ItemType.GrenadeHE || random == ItemType.GrenadeFlash || random == ItemType.SCP2176)
                    {
                        if (UnityEngine.Random.value * 100f < Plugin.Instance.Config.ChanceToExplode)
                        {
                            Log.Debug("[OnDied] Spawning random throwable explosive grenage");
                            SpawnExplodeGrenage(random, Plugin.Instance.Config.TimeDoDetonate, deadpos);
                            continue;
                        }
                    }
                    e.ItemsToDrop.Add(Item.Create(random));
                }
                catch (Exception ex)
                {
                    Log.Debug($"[OnDied] Error when spawn new items {ex.Message}");
                }
            }
        }

        private void SpawnExplodeGrenage(ItemType type, float fuseTime, Vector3 position)
        {
            try
            {
                if (type == ItemType.SCP2176)
                {
                    Scp2176 a = (Scp2176)Item.Create(type);
                    a.SpawnActive(position);
                    a.FuseTime = fuseTime;
                    return;
                }
                if (type == ItemType.GrenadeHE)
                {
                    ExplosiveGrenade exp = (ExplosiveGrenade)Item.Create(type);
                    exp.SpawnActive(position, null);
                    exp.FuseTime = fuseTime;
                    return;
                }
                if (type == ItemType.GrenadeFlash)
                {
                    FlashGrenade exp = (FlashGrenade)Item.Create(type);
                    exp.SpawnActive(position, null);
                    exp.FuseTime = fuseTime;
                    return;
                }
            }
            catch (Exception e)
            {
                Log.Debug($"[SpawnExplodeGrenage] Exception when spawning explosive grenage {e.Message}");
            }
        }

        internal void DisableEvent()
        {
            Exiled.Events.Handlers.Player.Dying -= OnDied;
            Spawnable = null;
            SpawnableCustom = null;
        }
    }
}
