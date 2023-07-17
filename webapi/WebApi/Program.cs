using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using WebApi.DataAccess;
using System.Text;
using System.Security.Claims;
using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

DotNetEnv.Env.Load();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddHttpClient();
services.AddSingleton<IConfiguration>(configuration);

services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<PostgreSqlContext>()
    .AddDefaultTokenProviders();

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
});

services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddSignInManager()
    .AddEntityFrameworkStores<PostgreSqlContext>()
    .AddDefaultTokenProviders();

var sqlConnectionString = configuration["PostgreSqlConnectionString"];
services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));
services.AddScoped<IDataAccessProvider, DataAccessProvider>();

// Disable DateTime Infinity Conversions for Npgsql
System.AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors(policy => 
    policy.WithOrigins("http://localhost:3000") // replace with your front-end application url
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseCors("corspolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireCors("corspolicy");

app.Run();