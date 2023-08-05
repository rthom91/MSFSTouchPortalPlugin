# MSFS/SimConnect Touch Portal Plugin

[![Made for Touch POrtal](https://img.shields.io/static/v1?style=flat&labelColor=5884b3&color=black&label=made%20for&message=Touch%20Portal&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAYAAAAfSC3RAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAetJREFUeNp0UruqWlEQXUePb1HERi18gShYWVqJYGeXgF+Qzh9IGh8QiOmECIYkpRY21pZWFnZaqWBhUG4KjWih4msys8FLbrhZMOfsx6w1e9beWjAYBOMtx0eOGBEZzuczrtcreAyTyQSz2QxN04j3f3J84vim8+cNR4s3rKfTSUQQi8UQjUYlGYvFAtPpVIQ0u90eZrGvnHLXuOKcB1GpkkqlUCqVEA6HsVqt4HA4EAgEMJvNUC6XMRwOwWTRfhIi3e93WK1W1Go1dbTBYIDj8YhOp4NIJIJGo4FEIoF8Po/JZAKLxQIIUSIUChGrEy9Sr9cjQTKZJJvNRtlsVs3r9Tq53W6Vb+Cy0rQyQtd1OJ1O9b/dbpCTyHoul1O9z+dzGI1Gla7jFUiyGBWPx9FsNpHJZNBqtdDtdlXfAv3vZLmCB6SiJIlJhUIB/X7/cS0viXI8n8+nrBcRIblcLlSrVez3e4jrD6LsK3O8Xi8Vi0ViJ4nVid2kB3a7HY3HY2q325ROp8nv94s5d0XkSsR90OFwoOVySaPRiF6DiHs8nmdXn+QInIxKpaJclWe4Xq9fxGazAQvDYBAKfssDeMeD7zITc1gR/4M8isvlIn2+F3N+cIjMB76j4Ha7fb7bf8H7v5j0hYef/wgwAKl+FUPYXaLjAAAAAElFTkSuQmCC)](https://www.touch-portal.com/)
[![GitHub release (latest by date including pre-releases)](https://img.shields.io/github/v/release/mpaperno/MSFSTouchPortalPlugin?include_prereleases)](https://github.com/mpaperno/MSFSTouchPortalPlugin/releases)
[![Downloads](https://img.shields.io/github/downloads/mpaperno/MSFSTouchPortalPlugin/total.svg)](https://github.com/mpaperno/MSFSTouchPortalPlugin/releases)
[![Downloads of latest release](https://img.shields.io/github/downloads/mpaperno/MSFSTouchPortalPlugin/latest/total)](https://github.com/mpaperno/MSFSTouchPortalPlugin/releases/latest)
[![License](https://img.shields.io/badge/license-GPL3-blue.svg)](LICENSE)
[![Discord](https://img.shields.io/static/v1?style=flat&color=7289DA&&labelColor=7289DA&message=Discord%20Chat&label=&logo=discord&logoColor=white)](https://discord.gg/6nHKnsWkB7)

<div align="center">
<img src="https://github.com/mpaperno/MSFSTouchPortalPlugin/wiki/images/logo/banner_top-768x204.png" />
</div>

## Overview

This plugin provided tools to build two-way interactive interfaces between
[Touch Portal](https://www.touch-portal.com/) macro launcher software and Flight Simulators which use SimConnect,
such as Microsoft Flight Simulator 2020 (MSFS) and FS-X. The plugin makes available new Touch Portal
Actions, Connectors, States, and Events for creating buttons and pages suitable for virtually any
simulated aircraft, component, or system.

This project is a continuation of the original [MSFSTouchPortalPlugin by Tim Lewis](https://github.com/tlewis17/MSFSTouchPortalPlugin).


## Features

* Connects to local or remote simulators with SimConnect.
* Allows getting data variables from simulator at regular intervals, such as flight instrument readings, control surface positions, or switch states.
* Allows triggering any interactive aircraft event via Touch Portal Actions, such as setting switches, adjusting control surfaces, radio frequencies, and so on.
* Use Touch Portal "Sliders" to control a value within any range, and/or provide visual feedback to simulator variable changes
  (eg. a throttle slider can both control the sim throttle and show the actual position when the throttle is moved with mouse/joystick/keyboard).
* Completely configurable to request any variable or trigger any event supported by the connected simulator, including with custom extensions like MobiFlight.
* Supports simulator system events (such as "flight loaded" or "sim started") as Touch Portal Events.
* Allows simultaneous usage from multiple networked Touch Portal devices.
* Optional WASM (Web ASsembly Module) integration allows even greater expansion, with access to many variable types (including "Local" variables) and events/actions not normally
  accessible via SimConnect alone.
* Categorized lists of all SimConnect Event IDs and Simulator Variables to choose from, custom imported from MSFS online documentation (exclusive feature!).
* Integrates live HubHop data for activating thousands of available Input Events provided by the community (requires WASM integration).


## Documentation

See the [Wiki](https://github.com/mpaperno/MSFSTouchPortalPlugin/wiki/) for guides, tips, and example
[pages and buttons](https://github.com/mpaperno/MSFSTouchPortalPlugin/wiki/Pages-Buttons-and-Graphics) to get started with

Auto-generated documentation on all actions, connectors, events, settings, and default included states can be found in [DOCUMENTATION.md](DOCUMENTATION.md).


## Installation

Note: As with all plugins, this requires the Touch Portal Pro (paid) version to function. Use the latest available Touch Portal version for best results.

1. Get the latest release of this plugin from the  [Releases](https://github.com/mpaperno/MSFSTouchPortalPlugin/releases) page.
2. The plugin is distributed and installed as a standard Touch Portal `.tpp` plugin file. If you know how to import a plugin, just do that and skip to step 4.
3. Import the plugin:
    1. Start/open _Touch Portal_.
    2. Click the Settings "gear" icon at the top-right and select "Import plugin..." from the menu.
    3. Browse to where you downloaded this plugin's `.tpp` file and select it.
    4. When prompted by _Touch Portal_ to trust the plugin startup script, select "Trust Always" or "Yes" (the source code is public!).
       * "Trust Always" will automatically start the plugin each time Touch Portal starts.
       * "Yes" will start the plugin this time and then prompt again each time Touch Portal starts.
       * If you select "No" then you can still start the plugin manually from Touch Portal's _Settings -> Plug-ins_ dialog.
4. **By default the plugin will not attempt to connect to a flight simulator on startup.** You have two options:
    1. Recommended: Create/import a [Touch Portal button](https://github.com/mpaperno/MSFSTouchPortalPlugin/wiki/Pages-Buttons-and-Graphics#the-connect-button)
     which triggers the "_MSFS - Plugin - Connect & Update -> Toggle Simulator Connection_" action. (Also a good place to show the current connection status.)
    2. Change the plugin's settings: Click the Touch Portal "gear" icon at top right of the main screen,
    then navigate to _Settings -> Plugins -> "MSFS Touch Portal Plugin"_. Set the
    "Connect To Flight Sim on Startup" setting to a value of `1` (one) and save the settings.
    The plugin will keep attempting to connect to the simulator every 30 seconds.
5. **For use with FS-X** (and compatible sims): Change the "SimConnect.cfg Index" plugin setting to `1` (one).

### Optional WASM Module (only for MSFS 2020 on PC)

6. The optional `WASimModule` MSFS component is **highly recommended** as a companion to this plugin. It it not required to use most
of the basic plugin features, but it will provide a more advanced feature set (such as access to local "L" variables and HubHop Input Events)
and further optimizations.
    1. Download the `WASimModule` .zip file from the same published Release as the plugin.
    2. Extract the contents into your MSFS _Community_ folder (so that the folder _wasimcommander-module_ is directly inside the _Community_ folder).
    3. If already running, MSFS would need to be restarted after adding the module.

### Updates

The plugin can be updated to a new version by following the same installation procedure described above. It is _not_ necessary to remove any previous version first.
The only thing to be aware of is that any old plugin log files will be removed during the update process.

### Installation Guides

Keep in mind that while guides can be helpful as an overview and to get started, they do get outdated and also may not cover all that is possible to do or configure.

* A video tutorial about the whole setup process was published by _OverKill Simulations_ on YouTube: [Microsoft Flight Simulator | MSFS Touch Portal | YOU NEED THIS!](https://www.youtube.com/watch?v=S4Pms-7oHf0)
* An older installation and usage guide was published on the _Simvol_ Web site: [How to use Touch Portal [with MSFS]](https://www.simvol.org/en/articles/tutorials/use-touch-portal).

---
## Pages and Examples

Check out the [Pages, Buttons, & Graphics](https://github.com/mpaperno/MSFSTouchPortalPlugin/wiki/Pages-Buttons-and-Graphics) for examples to get started with.

The list of known pages has also moved to the Wiki: [List of Published Touch Portal Pages for MSFS Plugin](https://github.com/mpaperno/MSFSTouchPortalPlugin/wiki/List-of-Published-Touch-Portal-Pages-for-MSFS-Plugin)

---
## Troubleshooting

The plugin logs errors and warnings to a plain-text file. 7 days worth of logs are kept by default (a new file is started for each day).
The log files are located within the plugin's installation folder, which is in Touch Portal's configuration directory:<br />
`C:\Users\<User_Name>\AppData\Roaming\TouchPortal\plugins\MSFS-TouchPortal-Plugin\logs` folder, where `<User_Name>` is your Windows user name.

**If something isn't working as expected, check the log.**

Another way to quickly see latest log entries is by using the provided TP States and displaying them in a button area.

- _MSFS - Plugin -> Most recent plugin log messages_ (`MSFSTouchPortalPlugin.Plugin.State.LogMessages`) - Shows the last dozen logged messages. Give this
  one a good size "button" (eg. cell size 4x3 or so).
- _MSFS - System -> Data from most recent Simulator System Event_ (`MSFSTouchPortalPlugin.SimSystem.State.SimSystemEventData`) - Shows one line of text from the last
  significant "simulator event." In case an error or warning is logged, the log entry with the error should show here.

You could also monitor the _MSFS - System -> Simulator System Event_ for the `Plugin Error` and/or `SimConnect Error` events.
For example you could have a button light up red when this event happens, so you can know to go check the log.

Here's a **Windows PowerShell** command to show the last 20 entries from the current day's log file:
```powershell
Get-Content -Tail 20 $Env:APPDATA\TouchPortal\plugins\MSFS-TouchPortal-Plugin\logs\MSFSTouchPortalPlugin$(Get-Date -format 'yyyyMMdd').log
```


---
## Support and Discussion

Please use the GitHub [Issues](https://github.com/mpaperno/MSFSTouchPortalPlugin/issues) pages for bug reports and concise feature requests.
Use the [Discussions](https://github.com/mpaperno/MSFSTouchPortalPlugin/discussions) pages for general conversation on any related topic like suggestions or support questions.

There is also a [Discord support forum](https://discord.gg/ypEY9Rk2TS) on my server, an [announcements channel](https://discord.gg/gUh5DwXjSj), and discussion rooms
on my server channel [#msfs-general](https://discord.gg/6nHKnsWkB7) and at Touch Portal's Discord server channel [#msfs2020](https://discord.gg/B2frqDVtbA)


---
## Update Notifications

The latest version of this software is always published on the GitHub [Releases](https://github.com/mpaperno/MSFSTouchPortalPlugin/releases) page.

You have several options for getting **automatically notified** about new releases:
* **If you have a GitHub account**, just open the _Watch_ menu of this repo in the top right of this page, then go to  _Custom_ and select the
_Releases_ option, then hit _Apply_ button.
* The plugin and updates are [published on Flightsim.to](https://flightsim.to/file/36546/msfs-touch-portal-plugin) where one could "subscribe" to release notifications (account required).
* If you use **Discord**, subscribe to notifications on my server channel [#msfs-plugin](https://discord.gg/gUh5DwXjSj).
* **If you already use an RSS/Atom feed reader**, just subscribe to the [feed URL](https://github.com/mpaperno/MSFSTouchPortalPlugin/releases.atom).
* **Use an RSS/Atom feed notification service**, either one specific for GitHub or a generic one, such as
(a list of services I found, I haven't necessarily tried nor do I endorse any of these):
  * https://blogtrottr.com/  (generic RSS feed notifications, no account required, use the [feed URL](https://github.com/mpaperno/MSFSTouchPortalPlugin/releases.atom))
  * https://coderelease.io/  (no account required)
  * https://newreleases.io/
  * https://gitpunch.com/


---
## Related Plugin(s)

My [TJoy Touch Portal Plugin](https://github.com/mpaperno/TJoy) is an interface between Touch Portal and several virtual joystick/game pad emulation drivers like _vJoy_, _vXBox_, and _ViGEm Bus_.

My [Dynamic Script Engine Plugin](https://dse.tpp.max.paperno.us/) is a great companion for anything from custom data formatting and math operations to a full-blown scripting using JavaScript.

[TouchPortal-Dynamic-Icons](https://github.com/spdermn02/TouchPortal-Dynamic-Icons) can be used to create a wide variety of dynamic images and animations, from basic shapes and styled text to
beautiful multi-layered gauges animated in real-time based on Simulator data.

---
## References

* [SDK Event IDs](https://docs.flightsimulator.com/html/Programming_Tools/Event_IDs/Event_IDs.htm)
* [SDK Simulator Variables](https://docs.flightsimulator.com/html/Programming_Tools/SimVars/Simulation_Variables.htm)
* [FlightSimulator.com SDK Reference](https://docs.flightsimulator.com/html/Programming_Tools/SimConnect/SimConnect_SDK.htm)
* [HubHop Community Database](https://hubhop.mobiflight.com)


---
## Credits
Currently maintained by Maxim Paperno at https://github.com/mpaperno/MSFSTouchPortalPlugin ; see copyright and licensing details below.

Originally created by Tim Lewis at https://github.com/tlewis17/MSFSTouchPortalPlugin and published under the MIT License.

Uses components of the [WASimCommander project](https://github.com/mpaperno/WASimCommander) under terms of the GNU Public License v3 (GPLv3).

Uses tools and data from [MSFS Tools project](https://github.com/mpaperno/MSFS-Tools) under terms of the GNU Public License v3 (GPLv3).

Uses the [Touch Portal C# and .NET API](https://github.com/mpaperno/TouchPortal-CS-API) library, under terms of the MIT License.

Uses a modified version of [SharpConfig](https://github.com/cemdervis/SharpConfig) library, under terms of the MIT License.
Change log is included in this repo alongside the library files.

Uses the _Microsoft SimConnect SDK_ under the terms of the _MS Flight Simulator SDK EULA (11/2019)_ document.

Uses several publicly available Microsoft .NET component libraries under the MIT License.

Uses the [Newtonsoft Json.NET](https://www.newtonsoft.com/json) library under terms of the MIT License.

Uses [Serilog Logging Extensions](https://github.com/serilog/serilog-extensions-logging) components under terms of the Apache-2.0 License.

Uses the [SQLite-net](https://github.com/praeclarum/sqlite-net) library from Krueger Systems, Inc. under terms of the MIT License.


---
## Copyright, License, and Disclaimer

MSFSTouchPortalPlugin Project<br/>
Copyright (c) 2020 Tim Lewis;<br />
Copyright Maxim Paperno, all rights reserved;<br />
Copyright MSFSTouchPortalPlugin Project Contributors

This program and associated files may be used under the terms of the GNU
General Public License as published by the Free Software Foundation,
either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

A copy of the GNU General Public License is included in this repository
and is also available at <http://www.gnu.org/licenses/>.

This project may also use 3rd-party Open Source software under the terms
of their respective licenses. The copyright notice above does not apply
to any 3rd-party components used within.
