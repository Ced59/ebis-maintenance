using System.Data.Entity;

namespace WPF.MonAppli.CoucheDonnees
{
  public partial class SampleDbContext : DbContext
  {
    public SampleDbContext() : base("name=MonAppli")
    {
    }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
  }
}
