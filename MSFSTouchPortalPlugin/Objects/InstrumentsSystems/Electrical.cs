﻿/*
This file is part of the MSFS Touch Portal Plugin project.
https://github.com/mpaperno/MSFSTouchPortalPlugin

COPYRIGHT:
(c) 2020 Tim Lewis;
(c) Maxim Paperno; All Rights Reserved.

This file may be used under the terms of the GNU General Public License (GPL)
as published by the Free Software Foundation, either version 3 of the Licenses,
or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

A copy of the GNU GPL is included with this project
and is also available at <http://www.gnu.org/licenses/>.
*/

using MSFSTouchPortalPlugin.Attributes;
using MSFSTouchPortalPlugin.Enums;

namespace MSFSTouchPortalPlugin.Objects.InstrumentsSystems
{
  [TouchPortalCategory(Groups.Electrical)]
  internal static class ElectricalMapping {
    #region Avionics

    [TouchPortalAction("AvionicsMasterSwitch", "Avionics Master", "Toggle Avionics Master", "Toggle Avionics Master")]
    [TouchPortalActionMapping("TOGGLE_AVIONICS_MASTER")]
    public static readonly object TOGGLE_AVIONICS_MASTER;

    #endregion

    #region Alternator & Battery

    [TouchPortalAction("MasterAlternator", "Master Alternator", "Toggle Master Alternator", "Toggle Master Alternator")]
    [TouchPortalActionMapping("TOGGLE_MASTER_ALTERNATOR")]
    public static readonly object MASTER_ALTERNATOR;

    [TouchPortalAction("MasterBattery", "Master Battery", "Toggle Master Battery", "Toggle Master Battery")]
    [TouchPortalActionMapping("TOGGLE_MASTER_BATTERY")]
    public static readonly object MASTER_BATTERY;

    [TouchPortalAction("MasterBatteryAlternator", "Master Battery & Alternator", "Toggle Master Battery & Alternator", "Toggle Master Battery & Alternator")]
    [TouchPortalActionMapping("TOGGLE_MASTER_BATTERY_ALTERNATOR")]
    public static readonly object MASTER_BATTERY_ALTERNATOR;

    [TouchPortalAction("AlternatorIndex", "Alternator - Specific", "Toggle Specific Alternator", "Toggle Alternator - {0}")]
    [TouchPortalActionChoice()]
    [TouchPortalActionMapping("TOGGLE_ALTERNATOR1", "1")]
    [TouchPortalActionMapping("TOGGLE_ALTERNATOR2", "2")]
    [TouchPortalActionMapping("TOGGLE_ALTERNATOR3", "3")]
    [TouchPortalActionMapping("TOGGLE_ALTERNATOR4", "4")]
    public static readonly object ALTERNATOR_INDEX;

    #endregion

    #region Lights

    [TouchPortalAction("StrobeLights", "Toggle/On/Off Strobe Lights", "Strobe Lights - {0}")]
    [TouchPortalActionChoice(new[] { "Toggle", "On", "Off" })]
    [TouchPortalActionMapping("STROBES_TOGGLE", "Toggle")]
    [TouchPortalActionMapping("STROBES_ON", "On")]
    [TouchPortalActionMapping("STROBES_OFF", "Off")]
    public static readonly object STROBE_LIGHTS;

    [TouchPortalAction("PanelLights", "Toggle/On/Off Panel Lights", "Panel Lights - {0}")]
    [TouchPortalActionChoice(new[] { "Toggle", "On", "Off" })]
    [TouchPortalActionMapping("PANEL_LIGHTS_TOGGLE", "Toggle")]
    [TouchPortalActionMapping("PANEL_LIGHTS_ON", "On")]
    [TouchPortalActionMapping("PANEL_LIGHTS_OFF", "Off")]
    public static readonly object PANEL_LIGHTS;

    [TouchPortalAction("LandingLights", "Toggle/On/Off Landing Lights", "Landing Lights - {0}")]
    [TouchPortalActionChoice(new[] { "Toggle", "On", "Off" })]
    [TouchPortalActionMapping("LANDING_LIGHTS_TOGGLE", "Toggle")]
    [TouchPortalActionMapping("LANDING_LIGHTS_ON", "On")]
    [TouchPortalActionMapping("LANDING_LIGHTS_OFF", "Off")]
    public static readonly object LANDING_LIGHTS;

    [TouchPortalAction("ToggleLights", "Toggle All/Specific Lights", "Toggle Lights - {0}")]
    [TouchPortalActionChoice(new[] { "All", "Beacon", "Taxi", "Logo", "Recognition", "Wing", "Nav", "Cabin" })]
    [TouchPortalActionMapping("ALL_LIGHTS_TOGGLE", "All")]
    [TouchPortalActionMapping("TOGGLE_BEACON_LIGHTS", "Beacon")]
    [TouchPortalActionMapping("TOGGLE_TAXI_LIGHTS", "Taxi")]
    [TouchPortalActionMapping("TOGGLE_LOGO_LIGHTS", "Logo")]
    [TouchPortalActionMapping("TOGGLE_RECOGNITION_LIGHTS", "Recognition")]
    [TouchPortalActionMapping("TOGGLE_WING_LIGHTS", "Wing")]
    [TouchPortalActionMapping("TOGGLE_NAV_LIGHTS", "Nav")]
    [TouchPortalActionMapping("TOGGLE_CABIN_LIGHTS", "Cabin")]
    public static readonly object ALL_LIGHTS;

    #endregion

  }
}
