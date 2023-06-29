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
ConfigurationManager configuration = builder.Configuration;

DotNetEnv.Env.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<PostgreSqlContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
});
// Adding Jwt Bearer to Identity
// .AddJwtBearer(options =>
// {
//   options.SaveToken = true;
//   options.RequireHttpsMetadata = false;
//   options.TokenValidationParameters = new TokenValidationParameters()
//   {
//     ValidateIssuer = true,
//     ValidateAudience = true,
//     ValidAudience = configuration["JWT:ValidAudience"],
//     ValidIssuer = configuration["JWT:ValidIssuer"],
//     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
//   };
// });

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddSignInManager()
    .AddEntityFrameworkStores<PostgreSqlContext>()
    .AddDefaultTokenProviders();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

