namespace Inzis_SMM2_Tool
{
  internal class Settings
  {
    public static int AnnoucneIn
    {
      get
      {
        return Settings.GetAnnounceIn();
      }
      set
      {
        Settings.SetAnnounceIn(value);
      }
    }

    private static void SetAnnounceIn(int value)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.AnnounceIn = value;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static int GetAnnounceIn()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.AnnounceIn;
    }

    public static bool OutPut
    {
      get
      {
        return Settings.GetOutputEnabled();
      }
      set
      {
        Settings.SetOutputEnabled(value);
      }
    }

    private static void SetOutputEnabled(bool value)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.outputEnabled = value;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static bool GetOutputEnabled()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.outputEnabled;
    }

    public static string BotName
    {
      get
      {
        return Settings.GetBotName();
      }
      set
      {
        Settings.SetBotName(value);
      }
    }

    public static string Oauth
    {
      get
      {
        return Settings.GetOAuth();
      }
      set
      {
        Settings.SetOAuth(value);
      }
    }

    public static int IDCount
    {
      get
      {
        return Settings.GetIDCount();
      }
      set
      {
        Settings.SetIDCount(value);
      }
    }

    public static string Channel
    {
      get
      {
        return Settings.GetChannel();
      }
      set
      {
        Settings.SetChannel(value);
      }
    }

    public static string Directory
    {
      get
      {
        return Settings.GetDirectory();
      }
      set
      {
        Settings.SetDirectory(value);
      }
    }

    public static string OutputString
    {
      get
      {
        return Settings.GetOutputString();
      }
      set
      {
        Settings.SetOutputString(value);
      }
    }

    private static void SetOutputString(string outputstring)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.outputString = outputstring;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static string GetOutputString()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.outputString;
    }

    private static string GetDirectory()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.directory;
    }

    private static void SetDirectory(string directory)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.directory = directory;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static int GetIDCount()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.numberIDs;
    }

    private static void SetIDCount(int value)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.numberIDs = value;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static string GetChannel()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.channel;
    }

    private static void SetChannel(string value)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.channel = value;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static string GetOAuth()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.bot_auth;
    }

    private static void SetOAuth(string value)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.bot_auth = value;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static void SetBotName(string value)
    {
      Inzis_SMM2_Tool.Properties.Settings.Default.bot_name = value;
      Inzis_SMM2_Tool.Properties.Settings.Default.Save();
    }

    private static string GetBotName()
    {
      return Inzis_SMM2_Tool.Properties.Settings.Default.bot_name;
    }
  }
}
