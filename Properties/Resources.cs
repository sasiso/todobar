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
