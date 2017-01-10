// Decompiled with JetBrains decompiler
// Type: todobar.Properties.Resources
// Assembly: todobar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40D7304E-F994-44A4-B6EE-9F0B1D8D4D67
// Assembly location: C:\data\Engineering\Tools\todobar.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace todobar.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (todobar.Properties.Resources.resourceMan == null)
          todobar.Properties.Resources.resourceMan = new ResourceManager("todobar.Properties.Resources", typeof (todobar.Properties.Resources).Assembly);
        return todobar.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return todobar.Properties.Resources.resourceCulture;
      }
      set
      {
        todobar.Properties.Resources.resourceCulture = value;
      }
    }

    internal Resources()
    {
    }
  }
}
