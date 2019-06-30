// Decompiled with JetBrains decompiler
// Type: Inzis_SMM2_Tool.MainWindow
// Assembly: Inzis SMM2 Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B3400F75-7E13-41D1-8C16-0812E4AF9035
// Assembly location: C:\Users\Danie\Downloads\Inzis_SMM2_Tool\Inzis SMM2 Tool.exe

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Extensions.Logging;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Interfaces;

namespace Inzis_SMM2_Tool
{
  public partial class MainWindow : MetroWindow, IComponentConnector
  {
    public static RoutedCommand MyCommand = new RoutedCommand();
    private SQLiteCommand _command;
    private readonly SQLiteConnection _dbConnection;
    private string _sqlQuery;
    private TwitchClient _client;
    private ConnectionCredentials _credentials;
    private bool connected;
    private DispatcherTimer timer;
    private bool IsOnCD;
    internal Button btn_ConnectDisconnect;
    internal Button btnSettings;
    internal TextBlock tb_Ausgabe;
    internal Label lbl_Status;
    internal DataGrid dgvIDS;
    private bool _contentLoaded;

    public void Connect()
    {
      try
      {
        this._credentials = new ConnectionCredentials(Inzis_SMM2_Tool.Properties.Settings.Default.bot_name, Inzis_SMM2_Tool.Properties.Settings.Default.bot_auth, "wss://irc-ws.chat.twitch.tv:443", false);
        this._client = new TwitchClient((IClient) null, (ClientProtocol) 1, (ILogger<TwitchClient>) null);
        this._client.Initialize(this._credentials, Inzis_SMM2_Tool.Properties.Settings.Default.channel, '!', '!', true);
        this._client.add_OnConnected(new EventHandler<OnConnectedArgs>(this.OnConnect));
        this._client.add_OnDisconnected(new EventHandler<OnDisconnectedEventArgs>(this.OnDisconnect));
        this._client.add_OnConnectionError(new EventHandler<OnConnectionErrorArgs>(this.OnConnectionError));
        this._client.add_OnMessageReceived(new EventHandler<OnMessageReceivedArgs>(this.OnMessageReceived));
        this._client.Connect();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
      if (!((ChatMessage) e.ChatMessage).get_Message().ToLower().StartsWith("!id") || this.IsOnCD)
        return;
      this.IsOnCD = true;
      string id = ((ChatMessage) e.ChatMessage).get_Message().Split(' ')[1];
      switch (this.InsertDB(((TwitchLibMessage) e.ChatMessage).get_Username(), id))
      {
        case 1:
          this.UpdateStatus(((TwitchLibMessage) e.ChatMessage).get_Username() + " | ID: " + id + " added");
          switch (Settings.AnnoucneIn)
          {
            case 0:
              this._client.SendMessage(((ChatMessage) e.ChatMessage).get_Channel(), "@" + ((TwitchLibMessage) e.ChatMessage).get_Username() + " your ID has been added to the database!", false);
              break;
            case 1:
              this._client.SendWhisper(((TwitchLibMessage) e.ChatMessage).get_Username(), "Your ID has been added to the database!", false);
              break;
          }
          this.ReadDb();
          break;
        case 2:
          this.UpdateStatus(((TwitchLibMessage) e.ChatMessage).get_Username() + " already has an ID in the DB");
          switch (Settings.AnnoucneIn)
          {
            case 0:
              this._client.SendMessage(((ChatMessage) e.ChatMessage).get_Channel(), "@" + ((TwitchLibMessage) e.ChatMessage).get_Username() + " you already have " + (object) Settings.IDCount + " ID(s) in the database!", false);
              break;
            case 1:
              this._client.SendWhisper(((TwitchLibMessage) e.ChatMessage).get_Username(), "You already have " + (object) Settings.IDCount + " ID (s) in the database!", false);
              break;
          }
        case 3:
          this.UpdateStatus(id + " bereits der DB");
          switch (Settings.AnnoucneIn)
          {
            case 0:
              this._client.SendMessage(((ChatMessage) e.ChatMessage).get_Channel(), "@" + ((TwitchLibMessage) e.ChatMessage).get_Username() + " this ID is already in the database", false);
              break;
            case 1:
              this._client.SendWhisper(((TwitchLibMessage) e.ChatMessage).get_Username(), "This ID is already in the database", false);
              break;
          }
      }
      this.timer.Start();
    }

    private void OnConnectionError(object sender, OnConnectionErrorArgs e)
    {
      this.connected = false;
      this.UpdateButtonText("Connect");
    }

    private void OnDisconnect(object sender, OnDisconnectedEventArgs e)
    {
      this.connected = false;
      this.UpdateButtonText("Connect");
    }

    private void OnConnect(object sender, OnConnectedArgs e)
    {
      this.connected = true;
      this.UpdateButtonText("Disconnect");
    }

    private void UpdateButtonText(string text)
    {
      if (this.btn_ConnectDisconnect.Dispatcher.CheckAccess())
        this.btn_ConnectDisconnect.Content = (object) text;
      else
        this.btn_ConnectDisconnect.Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) new MainWindow.ButtonTextChanger(this.UpdateButtonText), (object) text);
    }

    private void UpdateTB(string text)
    {
      if (this.tb_Ausgabe.Dispatcher.CheckAccess())
        this.tb_Ausgabe.Text = text;
      else
        this.tb_Ausgabe.Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) new MainWindow.ButtonTextChanger(this.UpdateTB), (object) text);
    }

    private void UpdateStatus(string text)
    {
      if (this.lbl_Status.Dispatcher.CheckAccess())
        this.lbl_Status.Content = (object) text;
      else
        this.lbl_Status.Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) new MainWindow.ButtonTextChanger(this.UpdateStatus), (object) text);
    }

    public MainWindow()
    {
      base.\u002Ector();
      this.InitializeComponent();
    }

    public void ReadDb()
    {
      // ISSUE: method pointer
      ((DispatcherObject) this.dgvIDS).Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) new Action((object) this, __methodptr(\u003CReadDb\u003Eb__19_0)));
      this._sqlQuery = "SELECT count(*) FROM mmids";
      ((DbConnection) this._dbConnection).Open();
      this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
      int int32 = Convert.ToInt32(((DbCommand) this._command).ExecuteScalar());
      ((DbConnection) this._dbConnection).Close();
      if ((uint) int32 > 0U)
      {
        ((DbConnection) this._dbConnection).Open();
        this._sqlQuery = "select * from mmids";
        this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
        SQLiteDataReader sqLiteDataReader1 = this._command.ExecuteReader();
        while (((DbDataReader) sqLiteDataReader1).Read())
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: method pointer
          ((DispatcherObject) this.dgvIDS).Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) new Action((object) new MainWindow.\u003C\u003Ec__DisplayClass19_0()
          {
            \u003C\u003E4__this = this,
            data = new MainWindow.ID()
            {
              User = ((DbDataReader) sqLiteDataReader1).GetValue(1).ToString(),
              LevelID = ((DbDataReader) sqLiteDataReader1).GetValue(2).ToString()
            }
          }, __methodptr(\u003CReadDb\u003Eb__1)));
        }
        this._sqlQuery = "select * from mmids LIMIT 1";
        this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
        SQLiteDataReader sqLiteDataReader2 = this._command.ExecuteReader();
        while (((DbDataReader) sqLiteDataReader2).Read())
        {
          this.UpdateTB(((DbDataReader) sqLiteDataReader2).GetValue(1).ToString() + "\n" + ((DbDataReader) sqLiteDataReader2).GetValue(2));
          if (Settings.OutPut)
          {
            string path = !string.IsNullOrEmpty(Settings.Directory) ? Settings.Directory + "/ouput.txt" : Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) + "/output.txt";
            string contents = Settings.OutputString.Replace("{USER}", ((DbDataReader) sqLiteDataReader2).GetValue(1).ToString()).Replace("{ID}", ((DbDataReader) sqLiteDataReader2).GetValue(2).ToString());
            if (!File.Exists(path))
            {
              File.Create(path).Close();
              File.WriteAllText(path, contents);
            }
            File.WriteAllText(path, contents);
          }
        }
        ((DbConnection) this._dbConnection).Close();
      }
      else
        this.UpdateTB("");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      this.ReadDb();
    }

    private int InsertDB(string user, string id)
    {
      this._sqlQuery = "SELECT count(*) FROM mmids WHERE username='" + user + "'";
      ((DbConnection) this._dbConnection).Open();
      this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
      int int32 = Convert.ToInt32(((DbCommand) this._command).ExecuteScalar());
      ((DbConnection) this._dbConnection).Close();
      if (int32 < Settings.IDCount)
      {
        try
        {
          this._sqlQuery = "INSERT INTO `mmids` (username, levelid) values ('" + user + "', '" + id + "');";
          ((DbConnection) this._dbConnection).Open();
          this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
          ((DbCommand) this._command).ExecuteNonQuery();
          ((DbConnection) this._dbConnection).Close();
          this.ReadDb();
          return 1;
        }
        catch (Exception ex)
        {
          ((DbConnection) this._dbConnection).Close();
          this.ReadDb();
          return 3;
        }
      }
      else
      {
        this.ReadDb();
        return 2;
      }
    }

    private void Btn_ConnectDisconnect_Click(object sender, RoutedEventArgs e)
    {
      if (!this.connected)
        this.Connect();
      else if (this._client != null)
        this._client.Disconnect();
    }

    private void Btn_laden_Click(object sender, RoutedEventArgs e)
    {
      this.ReadDb();
    }

    private async void Button_Click_2(object sender, RoutedEventArgs e)
    {
      MetroDialogSettings metroDialogSettings = new MetroDialogSettings();
      metroDialogSettings.set_AffirmativeButtonText("Yes");
      metroDialogSettings.set_NegativeButtonText("No");
      metroDialogSettings.set_DefaultButtonFocus((MessageDialogResult) 1);
      MessageDialogResult result = await DialogManager.ShowMessageAsync((MetroWindow) this, "Warning", "This will delete the current shown Entry.\n\nAre you sure?", (MessageDialogStyle) 1, metroDialogSettings);
      if (result != 1)
        return;
      int id = 0;
      ((DbConnection) this._dbConnection).Open();
      this._sqlQuery = "select * from mmids LIMIT 1";
      this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
      SQLiteDataReader reader = this._command.ExecuteReader();
      while (((DbDataReader) reader).Read())
        id = int.Parse(((DbDataReader) reader).GetValue(0).ToString());
      this._sqlQuery = "DELETE FROM mmids WHERE id=" + (object) id + ";";
      this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
      ((DbCommand) this._command).ExecuteNonQuery();
      ((DbConnection) this._dbConnection).Close();
      this.ReadDb();
      reader = (SQLiteDataReader) null;
    }

    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
      MainWindow.MyCommand.InputGestures.Add((InputGesture) new KeyGesture(Key.F5));
      if (!File.Exists("db.sqlite"))
      {
        SQLiteConnection.CreateFile("db.sqlite");
        this._sqlQuery = "CREATE TABLE `mmids` (`id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `username` TEXT NOT NULL, `levelid` TEXT NOT NULL UNIQUE);";
        ((DbConnection) this._dbConnection).Open();
        this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
        ((DbCommand) this._command).ExecuteNonQuery();
        ((DbConnection) this._dbConnection).Close();
      }
      else
        this.ReadDb();
      this.timer.Interval = TimeSpan.FromSeconds(5.0);
      this.timer.Tick += new EventHandler(this.timer_Tick);
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      this.IsOnCD = false;
      this.timer.Stop();
    }

    private void BtnSettings_Click(object sender, RoutedEventArgs e)
    {
      ((Window) new SettingsWindow()).ShowDialog();
    }

    private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      this.ReadDb();
    }

    private void DgvItemDelete_Click(object sender, RoutedEventArgs e)
    {
      ((DbConnection) this._dbConnection).Open();
      this._sqlQuery = "DELETE FROM mmids WHERE levelid='" + ((MainWindow.ID) ((Selector) this.dgvIDS).SelectedItem).LevelID + "';";
      this._command = new SQLiteCommand(this._sqlQuery, this._dbConnection);
      ((DbCommand) this._command).ExecuteNonQuery();
      ((DbConnection) this._dbConnection).Close();
      this.ReadDb();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/Inzis SMM2 Tool;component/mainwindow.xaml", UriKind.Relative));
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
          this.btn_ConnectDisconnect = (Button) target;
          this.btn_ConnectDisconnect.Click += new RoutedEventHandler(this.Btn_ConnectDisconnect_Click);
          break;
        case 3:
          this.btnSettings = (Button) target;
          this.btnSettings.Click += new RoutedEventHandler(this.BtnSettings_Click);
          break;
        case 4:
          ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.CommandBinding_OnExecuted);
          break;
        case 5:
          this.tb_Ausgabe = (TextBlock) target;
          break;
        case 6:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.Button_Click_2);
          break;
        case 7:
          this.lbl_Status = (Label) target;
          break;
        case 8:
          this.dgvIDS = (DataGrid) target;
          break;
        case 9:
          ((MenuItem) target).Click += new RoutedEventHandler(this.DgvItemDelete_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }

    private delegate void ButtonTextChanger(string text);

    public class ID
    {
      public string User { get; set; }

      public string LevelID { get; set; }
    }
  }
}
