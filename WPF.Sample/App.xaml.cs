using System;
using System.Windows;
using WPF.MonAppli.CoucheMetier;

namespace WPF.MonAppli
{
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      // DataDirectory (pour Entity Framework)
      string path = Environment.CurrentDirectory;
      path = path.Replace(@"\bin\Debug", "");
      path += @"\App_Data\";

      AppDomain.CurrentDomain.SetData("DataDirectory", path);

      // Charge les paramètres de l'application
      // (la propriété Instance représente le singleton, voir AppSettings.cs)
      AppSettings.Instance.ChargerParametres();
    }
  }
}
