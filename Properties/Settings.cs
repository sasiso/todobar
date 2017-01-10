// Decompiled with JetBrains decompiler
// Type: todobar.Properties.Settings
// Assembly: todobar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40D7304E-F994-44A4-B6EE-9F0B1D8D4D67
// Assembly location: C:\data\Engineering\Tools\todobar.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace todobar.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
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
  }
}
