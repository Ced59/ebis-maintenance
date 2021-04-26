using System;
using System.Configuration;

namespace Common.Classes
{
  /// <summary>
  /// Utiliser cette classe pour les paramètres globaux à l'application
  /// </summary>
  public class ConfigurationSettings : Base
  {
    public virtual void ChargerParametres()
    {
      // TODO: Charger ici tous les paramètres COMMUNS à toute l'application
    }

    protected T GetSetting<T>(string key, object defaultValue)
    {
      T ret = default(T);
      string value;

      value = ConfigurationManager.AppSettings[key];
      if (string.IsNullOrEmpty(value))
      {
        ret = (T)defaultValue;
      }
      else
      {
        ret = (T)Convert.ChangeType(value, typeof(T));
      }

      return ret;
    }
  }
}
