// Decompiled with JetBrains decompiler
// Type: Inzis_SMM2_Tool.Properties.Settings
// Assembly: Inzis SMM2 Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3400F75-7E13-41D1-8C16-0812E4AF9035
// Assembly location: C:\Users\Danie\Downloads\Inzis_SMM2_Tool\Inzis SMM2 Tool.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Inzis_SMM2_Tool.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Red")]
    public string color
    {
      get
      {
        return (string) this[nameof (color)];
      }
      set
      {
        this[nameof (color)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("BaseLight")]
    public string theme
    {
      get
      {
        return (string) this[nameof (theme)];
      }
      set
      {
        this[nameof (theme)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string bot_name
    {
      get
      {
        return (string) this[nameof (bot_name)];
      }
      set
      {
        this[nameof (bot_name)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string bot_auth
    {
      get
      {
        return (string) this[nameof (bot_auth)];
      }
      set
      {
        this[nameof (bot_auth)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string channel
    {
      get
      {
        return (string) this[nameof (channel)];
      }
      set
      {
        this[nameof (channel)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool mmEnabled
    {
      get
      {
        return (bool) this[nameof (mmEnabled)];
      }
      set
      {
        this[nameof (mmEnabled)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public int numberIDs
    {
      get
      {
        return (int) this[nameof (numberIDs)];
      }
      set
      {
        this[nameof (numberIDs)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string directory
    {
      get
      {
        return (string) this[nameof (directory)];
      }
      set
      {
        this[nameof (directory)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string outputString
    {
      get
      {
        return (string) this[nameof (outputString)];
      }
      set
      {
        this[nameof (outputString)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool outputEnabled
    {
      get
      {
        return (bool) this[nameof (outputEnabled)];
      }
      set
      {
        this[nameof (outputEnabled)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int AnnounceIn
    {
      get
      {
        return (int) this[nameof (AnnounceIn)];
      }
      set
      {
        this[nameof (AnnounceIn)] = (object) value;
      }
    }
  }
}
