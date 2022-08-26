using Microsoft.EntityFrameworkCore;

namespace GuildManager;

public class GuildManagerDbContext : DbContext
{
  public DbSet<GuildConfiguration> GuildConfigurations { get; set; }
  public DbSet<AdminRole> AdminRoles { get; set; }

  public string DbPath { get; }

  public GuildManagerDbContext(DbContextOptions<GuildManagerDbContext> options) : base(options)
  {
    Database.Migrate();
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    var dbPath = System.IO.Path.Join(path, "guild-manager.db");

    options.UseSqlite($"Data Source={dbPath}");
  }
}