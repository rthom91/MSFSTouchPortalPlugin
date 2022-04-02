﻿using MSFSTouchPortalPlugin.Enums;
using MSFSTouchPortalPlugin.Types;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace MSFSTouchPortalPlugin.Interfaces
{
  internal delegate void DataUpdateEventHandler(Definition def, Definition req, object data);
  internal delegate void ConnectEventHandler();
  internal delegate void DisconnectEventHandler();

  internal interface ISimConnectService {
    event DataUpdateEventHandler OnDataUpdateEvent;
    event ConnectEventHandler OnConnect;
    event DisconnectEventHandler OnDisconnect;

    bool IsConnected();
    bool AddNotification(Groups group, Enum eventId);
    bool Connect(uint configIndex = 0);
    void Disconnect();
    bool MapClientEventToSimEvent(Enum eventId, string eventName);
    void SetNotificationGroupPriorities();
    void ClearAllDataDefinitions();
    bool RegisterToSimConnect(SimVarItem simVar);
    bool RequestDataOnSimObjectType(SimVarItem simVar);
    bool TransmitClientEvent(Groups group, Enum eventId, uint data);
  }
}
