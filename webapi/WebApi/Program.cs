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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<PostgreSqlContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
});

builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddSignInManager()
    .AddEntityFrameworkStores<PostgreSqlContext>()
    .AddDefaultTokenProviders();

//check if .env exists if it does use that, otherwise fall back to what we have now
var sqlConnectionString = configuration["PostgreSqlConnectionString"];
builder.Services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));
builder.Services.AddScoped<IDataAccessProvider, DataAccessProvider>();

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
