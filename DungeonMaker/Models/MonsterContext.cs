using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DungeonMaker.Models
{
  public class MonsterContext : DbContext
  {
    public DbSet<Monster> Monsters { get; set; }
    public DbSet<Abilities> Abilities { get; set; }

    public MonsterContext() : base("name=DungeonDBConnectionString")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }


}