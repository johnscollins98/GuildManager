using System.Net.Http.Headers;
using AspNet.Security.OAuth.Discord;
using GuildManager;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services
  .AddAuthentication(o =>
  {
    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultAuthenticateScheme = DiscordAuthenticationDefaults.AuthenticationScheme;
  })
  .AddCookie(o =>
  {
    o.Events.OnRedirectToLogin = context =>
    {
      context.Response.StatusCode = 401;
      return Task.CompletedTask;
    };

    o.Events.OnRedirectToAccessDenied = context => 
    {
      context.Response.StatusCode = 403;
      return Task.CompletedTask;
    };
  })
  .AddDiscord(o =>
  {
    o.ClientId = builder.Configuration["Discord:ClientId"];
    o.ClientSecret = builder.Configuration["Discord:ClientSecret"];
    o.SaveTokens = true;
    o.Scope.Add("guilds");
    o.Scope.Add("guilds.members.read");
  });

builder.Services.AddAuthorization(options => 
{
  options.AddPolicy("AdminPolicy", 
    policy => 
    {
      policy.RequireAuthenticatedUser();
      policy.Requirements.Add(new AdminRequirement());
    });
});

builder.Services.AddAutoMapper(o =>
{
  o.CreateMap<DiscordGuild, DiscordGuildDto>();
  o.CreateMap<DiscordGuildMember, DiscordGuildMemberDto>();
  o.CreateMap<DiscordUser, DiscordUserDto>();
});

builder.Services.AddHttpClient<IUserDiscordService, UserDiscordService>();
builder.Services.AddHttpClient<IDiscordService, DiscordService>(o =>
{
  var botToken = builder.Configuration["Discord:BotToken"];
  o.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botToken);
  o.BaseAddress = new Uri("https://discord.com/api/");
});
builder.Services.AddTransient<IAuthorizationHandler, AdminAuthorizationHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
