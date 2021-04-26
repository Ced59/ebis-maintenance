namespace Common.Classes
{
  /// <summary>
  /// View Model spécialisé dans les vues classiques CRUD.
  /// Gère un ensemble de booléens sur lesquels l'UI va pouvoir venir
  /// se binder pour activer/désactiver certains éléments
  /// </summary>
  public class ViewModelAddEditDeleteBase : ViewModelBase
  {
    private bool listeEstActive = true;
    private bool detailEstActif = false;
    private bool estEnModeAjout = false;

    public bool ListeEstActive
    {
      get { return listeEstActive; }
      set
      {
        listeEstActive = value;
        RaisePropertyChanged("ListeEstActive");
      }
    }

    public bool DetailEstActif
    {
      get { return detailEstActif; }
      set
      {
        detailEstActif = value;
        RaisePropertyChanged("DetailEstActif");
      }
    }

    public bool EstEnModeAjout
    {
      get { return estEnModeAjout; }
      set
      {
        estEnModeAjout = value;
        RaisePropertyChanged("EstEnModeAjout");
      }
    }

    public virtual void CommencerEdition(bool estEnModeAjout = false)
    {
      ListeEstActive = false;
      DetailEstActif = true;
      EstEnModeAjout = estEnModeAjout;
    }

    public virtual void AnnulerEdition()
    {
      base.Clear();

      ListeEstActive = true;
      DetailEstActif = false;
      EstEnModeAjout = false;
    }

    public virtual bool Enregistrer()
    {
      return true;
    }

    public virtual bool Supprimer()
    {
      return true;
    }

  }
}
