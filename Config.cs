using System.Collections.Generic;
using System.ComponentModel;

using Exiled.API.Interfaces;

namespace ChaosEvent
{
    public class Config: IConfig
    {
        [Description("Determines whether the plugin itself will be enabled.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Determines whether debug messages will be visible.")]
        public bool Debug { get; set; } = false;
        [Description("Minimum number of items given out")]
        public ushort ItemMinFall { get; set; } = 0;
        [Description("Maximum number of items given out")]
        public ushort ItemMaxFall { get; set; } = 8;
        [Description("What is the chance of custom items appearing (if 8 items spawn, then the chance is determined by each 1 given out)")]
        public int ChanceForCustom { get; set; } = 15;
        [Description("The probability that the emerging grenade may explode")]
        public int ChanceToExplode { get; set; } = 25;
        [Description("Time before the grenade explosion")]
        public float TimeDoDetonate { get; set; } = 3.0f;
        [Description("Speaking message of cassie")]
        public string CassieMessage { get; set; } = "pitch_0.77 warning . . Facility is unstable";
        [Description("Displayed text message of cassie")]
        public string CassieTranslation { get; set; } = "warning Facility is unstable";
        [Description("Regardless of the meaning of cassie, will it be played")]
        public bool IsCassieEnabled { get; set; } = true;
        [Description("A list of custom item IDs that cannot be obtained by players due to the plugin's operation.")]
        public List<uint> BlackListCustom { get; set; } = new List<uint>();
        [Description("A list of item that cannot be obtained by players due to the plugin's operation.")]
        public List<ItemType> BlackListItems { get; set; } = new List<ItemType>()
        {
            ItemType.Coal,
            ItemType.SpecialCoal,
            ItemType.DebugRagdollMover,
            ItemType.MarshmallowItem,
            ItemType.Lantern,
            ItemType.Snowball,
            ItemType.Scp021J
        };
    }
}
