// Decompiled with JetBrains decompiler
// Type: todobar.App
// Assembly: todobar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 40D7304E-F994-44A4-B6EE-9F0B1D8D4D67
// Assembly location: C:\data\Engineering\Tools\todobar.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace todobar
{
  public class App : Application
  {
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
    }

    [STAThread]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
