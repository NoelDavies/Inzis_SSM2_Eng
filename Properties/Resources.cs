// Decompiled with JetBrains decompiler
// Type: Inzis_SMM2_Tool.Properties.Resources
// Assembly: Inzis SMM2 Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3400F75-7E13-41D1-8C16-0812E4AF9035
// Assembly location: C:\Users\Danie\Downloads\Inzis_SMM2_Tool\Inzis SMM2 Tool.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Inzis_SMM2_Tool.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  public class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static ResourceManager ResourceManager
    {
      get
      {
        if (Inzis_SMM2_Tool.Properties.Resources.resourceMan == null)
          Inzis_SMM2_Tool.Properties.Resources.resourceMan = new ResourceManager("Inzis_SMM2_Tool.Properties.Resources", typeof (Inzis_SMM2_Tool.Properties.Resources).Assembly);
        return Inzis_SMM2_Tool.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
      get
      {
        return Inzis_SMM2_Tool.Properties.Resources.resourceCulture;
      }
      set
      {
        Inzis_SMM2_Tool.Properties.Resources.resourceCulture = value;
      }
    }

    public static Icon icon
    {
      get
      {
        return (Icon) Inzis_SMM2_Tool.Properties.Resources.ResourceManager.GetObject(nameof (icon), Inzis_SMM2_Tool.Properties.Resources.resourceCulture);
      }
    }
  }
}
