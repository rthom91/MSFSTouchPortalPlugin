﻿using MSFSTouchPortalPlugin.Constants;
using MSFSTouchPortalPlugin.Enums;
using Stopwatch = System.Diagnostics.Stopwatch;
using SIMCONNECT_DATATYPE = Microsoft.FlightSimulator.SimConnect.SIMCONNECT_DATATYPE;

namespace MSFSTouchPortalPlugin.Types
{
  /// <summary> Dynamically generated SimConnect definition IDs are "parented" to this enum type,
  /// meaning they become of this Type when they need to be cast to en Enum type (eg. for SimConnect C# API). </summary>
  public enum Definition
  {
    None = 0
  }

  /// <summary>
  /// The SimVarItem which defines all data variables for SimConnect
  /// </summary>
  public class SimVarItem
  {
    /// <summary> Unique ID string, used to generate TouchPortal state ID (and possibly other uses). </summary>
    public string Id { get; set; }
    /// <summary> Category for sorting/organizing, also used in TouchPortal state ID. </summary>
    public Groups CategoryId { get; set; } = default;
    /// <summary> Descriptive name for this data (for TouchPortal or other UI). </summary>
    public string Name { get; set; }
    /// <summary> Corresponding SimConnect SimVar name (blank if used for internal purposes). </summary>
    public string SimVarName { get; set; }
    /// <summary> Default value string when no data from SimConnect. </summary>
    public string DefaultValue { get; set; }
    /// <summary> SimConnect settable value (future use) </summary>
    public bool CanSet { get; set; } = false;
    /// <summary> How often updates are sent by SimConnect if value changes (SIMCONNECT_PERIOD). Default is equivalent to SIMCONNECT_PERIOD_SIM_FRAME. </summary>
    public UpdatePeriod UpdatePeriod { get; set; } = UpdatePeriod.Default;
    /// <summary> The number of UpdatePeriod events that should elapse between data updates. Default is 0, which means the data is transmitted every Period.
    /// Note that when UpdatePeriod = Millisecond, there is an effective minimum of ~25ms. </summary>
    public uint UpdateInterval { get; set; } = 0;
    /// <summary> Only report change if it is greater than the value of this parameter (not greater than or equal to).
    /// Default is 0.0099999f limits changes to 2 decimal places which is suitable for most unit types (except perhaps MHz and "percent over 100"). </summary>
    public float DeltaEpsilon { get; set; } = 0.0099999f;
    /// <summary> Could also be "choice" but we don't use that (yet?) </summary>
    public string TouchPortalValueType { get; set; } = "text";
    /// <summary> This could/should be populated by whatever is creating the SimVarItem instance </summary>
    public string TouchPortalStateId { get; set; }

    /// <summary>
    /// SimConnect unit name. Changing this property will clear any current value!
    /// Setting this property also sets the SimConnectDataType, StorageDataType, and all the Is*Type properties.
    /// </summary>
    public string Unit
    {
      get => _unit;
      set {
        if (_unit == value)
          return;
        _unit = value;
        // set up type information based on the new Unit.
        IsStringType = Units.IsStringType(_unit);
        IsBooleanType = !IsStringType && Units.IsBooleantype(_unit);
        IsIntegralType = !IsStringType && !IsBooleanType && Units.IsIntegraltype(_unit);
        IsRealType = !IsStringType && !IsBooleanType && !IsIntegralType;
        SimConnectDataType = IsStringType ? SIMCONNECT_DATATYPE.STRING256 : IsIntegralType ? SIMCONNECT_DATATYPE.INT64 : IsBooleanType ? SIMCONNECT_DATATYPE.INT32 : SIMCONNECT_DATATYPE.FLOAT64;
        StorageDataType = IsStringType ? typeof(StringVal) : IsIntegralType ? typeof(long) : IsBooleanType ? typeof(uint) : typeof(double);
      }
    }

    /// <summary>
    /// This returns a full formatting string, as in "{0}" or "{0:FormattingString}" as needed.
    /// It can be set with either a full string (with "{}" brackets and/or "0:" part(s)) or just as the actual formatting part (what goes after the "0:" part).
    /// To get the "raw" formatting string, w/out any "{}" or "0:" parts, use the FormattingString property (which may be blank/null). </summary>
    public string StringFormat
    {
      get => string.IsNullOrWhiteSpace(_formatString) ? "{0}" : "{0:" + _formatString + "}";
      set {
        if (value.StartsWith('{'))
          value = value.Trim('{', '}');
        if (value.StartsWith("0:"))
          value = value.Remove(0, 2);
        _formatString = value;
      }
    }

    /// <summary> The current value as an object. May be null; </summary>
    public object Value
    {
      get => _value;
      set {
        _value = value;
        _lastUpdate = Stopwatch.GetTimestamp();
        SetPending(false);
        _valueExpires = UpdatePeriod switch {
          UpdatePeriod.Millisecond => _lastUpdate + UpdateInterval * (Stopwatch.Frequency / 1000L),
          //UpdatePeriod.Second      => _lastUpdate + UpdateInterval * Stopwatch.Frequency,
          _ => 0,  // never?  or always?
        };
      }
    }

    /// <summary>
    /// Returns the current value as a formatted string according to the value type and StringFormat property.
    /// If no value has been explicitly set, returns the DefaultValue.
    /// </summary>
    public string FormattedValue
    {
      get {
        if (!ValInit)
          return DefaultValue;
        return Value switch {
          double v => string.Format(StringFormat, v),
          uint v => string.Format(StringFormat, v),
          long v => string.Format(StringFormat, v),
          StringVal v => string.Format(StringFormat, v.ToString()),
          _ => string.Empty,
        };
      }
    }

    /// <summary>
    /// The actual system Type used for Value property. This is determined automatically when setting the Unit type.
    /// The return type could be null if Value type is null. Changing this property will clear any current value!
    /// </summary>
    public System.Type StorageDataType
    {
      get => Value?.GetType();
      private set {
        if (Value == null || Value.GetType() != value) {
          _value = value == typeof(StringVal) ? new StringVal() : System.Activator.CreateInstance(value);
          _lastUpdate = 0;
        }
      }
    }

    /// <summary> Returns true if this value is of a real (double) type, false otherwise </summary>
    public bool IsRealType { get; private set; }
    /// <summary> Returns true if this value is of a string type, false if numeric or bool. </summary>
    public bool IsStringType { get; private set; }
    /// <summary> Returns true if this value is of a integer type, false if string, real or bool. </summary>
    public bool IsIntegralType { get; private set; }
    /// <summary> Returns true if this value is of a boolean type, false otherwise </summary>
    public bool IsBooleanType { get; private set; }

    /// <summary> Unique Definition ID for SimConnect </summary>
    public Definition Def { get; private set; }
    /// <summary> The SimConnect data type for registering this var. </summary>
    public SIMCONNECT_DATATYPE SimConnectDataType { get; private set; }
    /// <summary> Indicates that this state needs a scheduled update request (UpdatePeriod == Millisecond). </summary>
    public bool NeedsScheduledRequest => UpdatePeriod == UpdatePeriod.Millisecond;
    /// <summary> For serializing the "raw" formatting string w/out "{0}" parts </summary>
    public string FormattingString => _formatString;

    /// <summary>
    /// Indicates that the value has "expired" based on the UpdatePeriod and UpdateInterval since the last time the value was set.
    /// This always returns false if UpdatePeriod != UpdatePeriod.Millisecond. Also returns false if a request for this value is pending and hasn't yet timed out.
    /// </summary>
    public bool UpdateRequired => _valueExpires > 0 && !CheckPending() && Stopwatch.GetTimestamp() > _valueExpires;

    private object _value;         // the actual Value storage
    private string _unit;          // unit type storage
    private string _formatString;  // the "raw" formatting string w/out "{0}" part
    private long _lastUpdate = 0;  // value update timestamp in Stopwatch ticks
    private long _valueExpires;    // value expiry timestamp in Stopwatch ticks, if a timed UpdatePeriod type, zero otherwise
    private long _requestTimeout;  // for tracking last data request time to avoid race conditions, next pending timeout ticks count or zero if not pending
    private const short REQ_TIMEOUT_SEC = 30;  // pending value timeout period in seconds

    private bool ValInit => _lastUpdate > 0;  // has value been set at least once

    // this is how we generate unique Def IDs for every instance of SimVarItem. Assigned in c'tor.
    private static Definition _nextDefinionId = Definition.None;
    private static Definition NextId() => ++_nextDefinionId;      // got a warning when trying to increment this directly from c'tor, but not via static member... ?

    public SimVarItem() {
      Def = NextId();
    }

    public bool ValueEquals(string value) => ValInit && IsStringType && value == Value.ToString();
    public bool ValueEquals(double value) => ValInit && IsRealType && System.Math.Abs((double)Value - ConvertValueIfNeeded(value)) <= DeltaEpsilon;
    public bool ValueEquals(long value)   => ValInit && IsIntegralType && System.Math.Abs((long)Value - value) <= (long)DeltaEpsilon;
    public bool ValueEquals(uint value)   => ValInit && IsBooleanType && System.Math.Abs((uint)Value - value) <= (uint)DeltaEpsilon;

    /// <summary>
    /// Compare this instance's value to the given object's value. For numeric types, it takes the DeltaEpsilon property into account.
    /// Uses strict type matching for double, long, uint, and falls back to string compare for all other types.
    /// </summary>
    public bool ValueEquals(object value) {
      if (!ValInit)
        return false;
      try {
        return value switch {
          double v => ValueEquals(v),
          uint v => ValueEquals(v),
          long v => ValueEquals(v),
          _ => ValueEquals(value.ToString()),
        };
      }
      catch {
        return false;
      }
    }

    internal bool SetValue(StringVal value) {
      if (IsStringType)
        Value = value;
      return IsStringType;
    }

    internal bool SetValue(double value) {
      if (!IsStringType)
        Value = ConvertValueIfNeeded(value);
      return !IsStringType;
    }

    internal bool SetValue(long value) {
      if (IsIntegralType)
        Value = value;
      return IsIntegralType;
    }

    internal bool SetValue(uint value) {
      if (IsBooleanType)
        Value = value;
      return IsBooleanType;
    }

    /// <summary>
    /// Prefer using this method, or one of the type-specific SetValue() overloads to
    /// to set the Value property, vs. direct access. Returns false if the given object's
    /// value type doesn't match this type.
    /// </summary>
    internal bool SetValue(object value) {
      try {
        return value switch {
          double v => SetValue(v),
          uint v => SetValue(v),
          long v => SetValue(v),
          StringVal v => SetValue(v),
          _ => false
        };
      }
      catch {
        return false;
      }
    }

    /// <summary>
    /// Updates the object to either set pending update or no longer pending
    /// </summary>
    /// <param name="val">True/False</param>
    public void SetPending(bool val) {
      _requestTimeout = val ? Stopwatch.GetTimestamp() + REQ_TIMEOUT_SEC * Stopwatch.Frequency : 0;
    }

    private double ConvertValueIfNeeded(double value) {
      // Convert to Degrees
      if (Unit == Units.radians)
        return value * (180.0 / System.Math.PI);
      // Convert to actual percentage (percentover100 range is 0 to 1)
      if (Unit == Units.percentover100)
        return value * 100.0;
      // no conversion
      return value;
    }

    private bool CheckPending() {
      if (_requestTimeout == 0)
        return false;
      if (Stopwatch.GetTimestamp() > _requestTimeout) {
        SetPending(false);
        return false;
      }
      return true;
    }

    public string ToDebugString() {
      return $"{GetType().Name}: {{Def: {Def}; SimVarName: {SimVarName}; Unit: {Unit}; Cat: {CategoryId}; Name: {Name}}}";
    }

  }
}
