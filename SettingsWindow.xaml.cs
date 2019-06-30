// Decompiled with JetBrains decompiler
// Type: Inzis_SMM2_Tool.SettingsWindow
// Assembly: Inzis SMM2 Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3400F75-7E13-41D1-8C16-0812E4AF9035
// Assembly location: C:\Users\Danie\Downloads\Inzis_SMM2_Tool\Inzis SMM2 Tool.exe

using MahApps.Metro.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Inzis_SMM2_Tool
{
  public partial class SettingsWindow : MetroWindow, IComponentConnector
  {
    private readonly FolderBrowserDialog _fbd;
    internal System.Windows.Controls.TextBox tb_Botname;
    internal PasswordBox tb_BotAuth;
    internal System.Windows.Controls.TextBox tb_BotChannel;
    internal System.Windows.Controls.Button btn_Save;
    internal NumericUpDown nud_Ids;
    internal System.Windows.Controls.RadioButton RdbWhisper;
    internal System.Windows.Controls.RadioButton RdbChat;
    internal System.Windows.Controls.TextBox TxtbxOutputdirectory;
    internal ToggleSwitch ChbxUpload;
    internal System.Windows.Controls.Button BtnOutputdirectory;
    internal System.Windows.Controls.Button BtnCopyToClip;
    internal System.Windows.Controls.TextBox TxtbxOutputformat;
    internal System.Windows.Controls.MenuItem MenuBtnUsername;
    internal System.Windows.Controls.MenuItem MenuBtnID;
    private bool _contentLoaded;

    public SettingsWindow()
    {
      base.\u002Ector();
      this.InitializeComponent();
    }

    private void Btn_Save_Click(object sender, RoutedEventArgs e)
    {
      Settings.BotName = this.tb_Botname.Text;
      Settings.Oauth = this.tb_BotAuth.Password;
      Settings.Channel = this.tb_BotChannel.Text;
      Settings.IDCount = (int) this.nud_Ids.get_Value().Value;
      ((Window) this).Close();
    }

    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
      this.SetControls();
    }

    private void ChbxUpload_Checked(object sender, RoutedEventArgs e)
    {
      if (this.ChbxUpload.get_IsChecked().HasValue)
        Settings.OutPut = this.ChbxUpload.get_IsChecked().Value;
      this.SetControls();
    }

    private void BtnOutputdirectoryClick(object sender, RoutedEventArgs e)
    {
      this._fbd.Description = "Path where the text file will be located.";
      this._fbd.SelectedPath = Assembly.GetExecutingAssembly().Location;
      if (this._fbd.ShowDialog() == DialogResult.Cancel)
        return;
      this.TxtbxOutputdirectory.Text = this._fbd.SelectedPath;
      Settings.Directory = this._fbd.SelectedPath;
    }

    private void BtnCopyToClipClick(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(Settings.Directory))
        System.Windows.Clipboard.SetDataObject((object) (Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "\\output.txt"));
      else
        System.Windows.Clipboard.SetDataObject((object) (Settings.Directory + "\\output.txt"));
    }

    private void MenuBtnUsername_Click(object sender, RoutedEventArgs e)
    {
      this.AppendText(this.TxtbxOutputformat, "{USER}");
    }

    private void MenuBtnID_Click(object sender, RoutedEventArgs e)
    {
      this.AppendText(this.TxtbxOutputformat, "{ID}");
    }

    private void TxtbxOutputformat_TextChanged(object sender, TextChangedEventArgs e)
    {
      Settings.OutputString = this.TxtbxOutputformat.Text;
    }

    private void AppendText(System.Windows.Controls.TextBox tb, string text)
    {
      tb.AppendText(text);
      tb.Select(this.TxtbxOutputformat.Text.Length, 0);
      if (tb.ContextMenu == null)
        return;
      tb.ContextMenu.IsOpen = false;
    }

    public void SetControls()
    {
      System.Windows.Controls.TextBox txtbxOutputdirectory = this.TxtbxOutputdirectory;
      string location = Assembly.GetEntryAssembly()?.Location;
      if (location == null)
        throw new InvalidOperationException();
      txtbxOutputdirectory.Text = location;
      if (!string.IsNullOrEmpty(Settings.Directory))
        this.TxtbxOutputdirectory.Text = Settings.Directory;
      this.TxtbxOutputformat.Text = Settings.OutputString;
      this.ChbxUpload.set_IsChecked(new bool?(Settings.OutPut));
      this.TxtbxOutputdirectory.IsEnabled = Settings.OutPut;
      this.TxtbxOutputformat.IsEnabled = Settings.OutPut;
      this.BtnCopyToClip.IsEnabled = Settings.OutPut;
      this.BtnOutputdirectory.IsEnabled = Settings.OutPut;
      this.tb_Botname.Text = Settings.BotName;
      this.tb_BotAuth.Password = Settings.Oauth;
      this.tb_BotChannel.Text = Settings.Channel;
      this.nud_Ids.set_Value(new double?((double) Settings.IDCount));
      this.nud_Ids.set_Minimum(1.0);
      switch (Settings.AnnoucneIn)
      {
        case 0:
          this.RdbChat.IsChecked = new bool?(true);
          break;
        case 1:
          this.RdbWhisper.IsChecked = new bool?(true);
          break;
      }
    }

    private void RdbChat_Checked(object sender, RoutedEventArgs e)
    {
      if (this.RdbChat.IsChecked.Value)
      {
        Settings.AnnoucneIn = 0;
      }
      else
      {
        if (!this.RdbWhisper.IsChecked.Value)
          return;
        Settings.AnnoucneIn = 1;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      System.Windows.Application.LoadComponent((object) this, new Uri("/Inzis SMM2 Tool;component/settingswindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.MetroWindow_Loaded);
          break;
        case 2:
          this.tb_Botname = (System.Windows.Controls.TextBox) target;
          break;
        case 3:
          this.tb_BotAuth = (PasswordBox) target;
          break;
        case 4:
          this.tb_BotChannel = (System.Windows.Controls.TextBox) target;
          break;
        case 5:
          this.btn_Save = (System.Windows.Controls.Button) target;
          this.btn_Save.Click += new RoutedEventHandler(this.Btn_Save_Click);
          break;
        case 6:
          this.nud_Ids = (NumericUpDown) target;
          break;
        case 7:
          this.RdbWhisper = (System.Windows.Controls.RadioButton) target;
          this.RdbWhisper.Checked += new RoutedEventHandler(this.RdbChat_Checked);
          this.RdbWhisper.Unchecked += new RoutedEventHandler(this.RdbChat_Checked);
          break;
        case 8:
          this.RdbChat = (System.Windows.Controls.RadioButton) target;
          this.RdbChat.Checked += new RoutedEventHandler(this.RdbChat_Checked);
          this.RdbChat.Unchecked += new RoutedEventHandler(this.RdbChat_Checked);
          break;
        case 9:
          this.TxtbxOutputdirectory = (System.Windows.Controls.TextBox) target;
          break;
        case 10:
          this.ChbxUpload = (ToggleSwitch) target;
          this.ChbxUpload.add_Checked(new EventHandler<RoutedEventArgs>(this.ChbxUpload_Checked));
          this.ChbxUpload.add_Unchecked(new EventHandler<RoutedEventArgs>(this.ChbxUpload_Checked));
          break;
        case 11:
          this.BtnOutputdirectory = (System.Windows.Controls.Button) target;
          this.BtnOutputdirectory.Click += new RoutedEventHandler(this.BtnOutputdirectoryClick);
          break;
        case 12:
          this.BtnCopyToClip = (System.Windows.Controls.Button) target;
          this.BtnCopyToClip.Click += new RoutedEventHandler(this.BtnCopyToClipClick);
          break;
        case 13:
          this.TxtbxOutputformat = (System.Windows.Controls.TextBox) target;
          this.TxtbxOutputformat.TextChanged += new TextChangedEventHandler(this.TxtbxOutputformat_TextChanged);
          break;
        case 14:
          this.MenuBtnUsername = (System.Windows.Controls.MenuItem) target;
          this.MenuBtnUsername.Click += new RoutedEventHandler(this.MenuBtnUsername_Click);
          break;
        case 15:
          this.MenuBtnID = (System.Windows.Controls.MenuItem) target;
          this.MenuBtnID.Click += new RoutedEventHandler(this.MenuBtnID_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
