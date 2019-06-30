// Decompiled with JetBrains decompiler
// Type: Inzis_SMM2_Tool.App
// Assembly: Inzis SMM2 Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3400F75-7E13-41D1-8C16-0812E4AF9035
// Assembly location: C:\Users\Danie\Downloads\Inzis_SMM2_Tool\Inzis SMM2 Tool.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace Inzis_SMM2_Tool
{
  public partial class App : Application
  {
    private bool _contentLoaded;

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
      Application.LoadComponent((object) this, new Uri("/Inzis SMM2 Tool;component/app.xaml", UriKind.Relative));
    }

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
