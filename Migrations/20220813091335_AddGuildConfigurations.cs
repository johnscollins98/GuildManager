using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class AddGuildConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuildConfigurations",
                columns: table => new
                {
                    DiscordGuildId = table.Column<string>(type: "TEXT", nullable: false),
                    GuildWarsGuildId = table.Column<string>(type: "TEXT", nullable: false),
                    GuildWarsApiKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildConfigurations", x => x.DiscordGuildId);
                });

            migrationBuilder.CreateTable(
                name: "AdminRoles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    GuildConfigurationDiscordGuildId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRoles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_AdminRoles_GuildConfigurations_GuildConfigurationDiscordGuildId",
                        column: x => x.GuildConfigurationDiscordGuildId,
                        principalTable: "GuildConfigurations",
                        principalColumn: "DiscordGuildId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRoles_GuildConfigurationDiscordGuildId",
                table: "AdminRoles",
                column: "GuildConfigurationDiscordGuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRoles");

            migrationBuilder.DropTable(
                name: "GuildConfigurations");
        }
    }
}
