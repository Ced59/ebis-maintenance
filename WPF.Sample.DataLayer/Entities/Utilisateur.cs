using Common.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF.MonAppli.CoucheDonnees
{
  [Table("Utilisateur", Schema = "dbo")]
  public class Utilisateur : Base
  {
    private int id;
    private string pseudo = string.Empty;
    private string mdp = string.Empty;
    private string prenom = string.Empty;
    private string nom = string.Empty;
    private string email = string.Empty;
    private bool estConnecte = false;

    [Required]
    [Key]
    public int Id
    {
      get { return id; }
      set
      {
        id = value;
        RaisePropertyChanged("Id");
      }
    }

    [Required]
    public string Pseudo
    {
      get { return pseudo; }
      set
      {
        pseudo = value;
        RaisePropertyChanged("Pseudo");
      }
    }

    [Required]
    public string Mdp
    {
      get { return mdp; }
      set
      {
        mdp = value;
        RaisePropertyChanged("Mdp");
      }
    }

    [Required]
    public string Prenom
    {
      get { return prenom; }
      set
      {
        prenom = value;
        RaisePropertyChanged("Prenom");
      }
    }

    [Required]
    public string Nom
    {
      get { return nom; }
      set
      {
        nom = value;
        RaisePropertyChanged("Nom");
      }
    }

    [Required]
    public string Email
    {
      get { return email; }
      set
      {
        email = value;
        RaisePropertyChanged("Email");
      }
    }

    [NotMapped]
    public bool EstConnecte
    {
      get { return estConnecte; }
      set
      {
        estConnecte = value;
        RaisePropertyChanged("EstConnecte");
      }
    }
  }
}