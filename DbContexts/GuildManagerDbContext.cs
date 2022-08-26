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
    var path = Path.Join(Directory.GetCurrentDirectory(), "App_Data");
    Directory.CreateDirectory(path);
    options.UseSqlite($"Data Source={Path.Join(path, "guild-manager.db")}");
  }
}