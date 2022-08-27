using Microsoft.EntityFrameworkCore;

namespace GuildManager;

public class GuildManagerDbContext : DbContext
{
  public DbSet<GuildConfiguration> GuildConfigurations => Set<GuildConfiguration>();
  public DbSet<AdminRole> AdminRoles => Set<AdminRole>();

  public string DbPath { get; } = String.Empty;

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