using System.ComponentModel;
using System.Reflection;

namespace Common.Classes
{
  /// <summary>
  /// Implémente INotifyPropertyChanged (permet à toutes les propriétés d'un objet
  /// de lancer l'événement PropertyChanged pour activer le databinding).
  /// Implémente une méthode `Clone()` pour copier toutes les propriétés d'un objet à un autre.
  /// </summary>
  public class Base : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Lance l'événement sur la propriété passée
    /// (uniquement si le data binding est utilisé)
    /// </summary>
    /// <param name="propertyName">Le nom de la propriété modifiée</param>
    protected void RaisePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler handler = this.PropertyChanged;
      // Lancer l'événement seulement si un handler est "connecté"
      if (handler != null)
      {
        PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

        // Lance finalement l'événement PropertyChanged
        handler(this, args);
      }
    }

    public void Clone<T>(T original, T dest)
    {
      if (original != null && dest != null)
      {
        // Utilise la réflexion pour forcer l'appel à RaisePropertyChanged sur chaque propriété
        foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
          var value = prop.GetValue(original, null);
          prop.SetValue(dest, value, null);
        }
      }
    }
  }
}
