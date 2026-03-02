# ChaosEvent
[![Sponsor on DonatAlerts](https://img.shields.io/badge/sponsor-alerts-orange.svg)](https://www.donationalerts.com/r/asmrmilo21)
[![Download letest version](https://img.shields.io/badge/download-latest-red.svg)](https://github.com/NOTIF-API/ChaosEvent/releases)

Allows you to change the rule to a special one when entering the `chaosevent` command, where the player's death does not throw away their inventory but creates a list of random items, including **custom items**!

# Find bug or have idea
**If you suddenly find an error or a flaw that needs to be corrected. If you see that the plugin is missing something, you can submit a suggestion about what could be added**.
1. You can contact me via [Issues](https://github.com/NOTIF-API/ChaosEvent/issues).
2. You can contact me via Discord under the name `notifapi` or `NOTIF` if you are looking for connections through servers with SCP or Exiled.

# How to allow players to start an event
Any player with a group will be able to run the command **from the admin console**, but it is necessary to additionally add a permission named "ch.init" to the group required to run the event in the `permissions.yaml` file.

# Default configs
```yaml
# Determines whether the plugin itself will be enabled.
is_enabled: true
# Determines whether debug messages will be visible.
debug: false
# Minimum number of items given out
item_min_fall: 0
# Maximum number of items given out
item_max_fall: 8
# What is the chance of custom items appearing (if 8 items spawn, then the chance is determined by each 1 given out)
chance_for_custom: 15
# The probability that the emerging grenade may explode
chance_to_explode: 25
# Time before the grenade explosion
time_do_detonate: 3
# Speaking message of cassie
cassie_message: 'pitch_0.77 warning . . Facility is unstable'
# Displayed text message of cassie
cassie_translation: 'warning Facility is unstable'
# Regardless of the meaning of cassie, will it be played
is_cassie_enabled: true
# A list of custom item IDs that cannot be obtained by players due to the plugin's operation.
black_list_custom: []
# A list of item that cannot be obtained by players due to the plugin's operation.
black_list_items:
- Coal
- SpecialCoal
- DebugRagdollMover
- MarshmallowItem
- Lantern
- Snowball
- Scp021J
```
