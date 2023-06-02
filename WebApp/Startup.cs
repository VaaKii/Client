using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApp.Helpers;

namespace WebApp;

public class Startup
{
  private IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    var baseUrl = Configuration["BaseURL"] ?? "https://localhost/";

    services.AddScoped<IAppServiceStore, AppServiceStore>();
    services.AddHttpClient("BaseApi", c => c.BaseAddress = new Uri(baseUrl));
    services.AddHttpClient();

    // CORS
    services.AddCors(options => options
      .AddPolicy("CorsAllowAll", b =>
      {
        b.AllowAnyHeader();
        b.AllowAnyMethod();
        b.AllowAnyOrigin();
      }));

    // JWT Authentication
    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
    services.AddAuthentication(options =>
      {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "oidc";
      })
      .AddCookie(options =>
      {
        options.Cookie.Name = "mvc";

        options.Events.OnSigningOut = async e => { await e.HttpContext.RevokeUserRefreshTokenAsync(); };
      })
      .AddOpenIdConnect("oidc", options =>
      {
        options.Authority = Configuration.GetValue<string>("IdentityServer");

        // no static client secret
        // the secret id created dynamically
        options.ClientId = Configuration.GetValue<string>("ClientId");

        // needed to add JWR / private_key_jwt support
        options.EventsType = typeof(OidcEvents);

        // code flow + PKCE (PKCE is turned on by default)
        options.ResponseType = "code";
        options.UsePkce = true;

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("scope1");
        options.Scope.Add("offline_access");

        // not mapped by default
        options.ClaimActions.MapJsonKey("website", "website");

        // keeps id_token smaller
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
          NameClaimType = "name",
          RoleClaimType = "role"
        };
      });

    // Add services to the container.
    services.AddControllersWithViews()
      .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; });
    services.AddSession();
  }

  public void Configure(
    IApplicationBuilder app,
    IWebHostEnvironment env
  )
  {
// Configure the HTTP request pipeline.
    if (env.IsDevelopment())
    {
      app.UseMigrationsEndPoint();
    }
    else
    {
      app.UseExceptionHandler("/Home/Error");
      app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseSession();
    app.UseStaticFiles();
    app.UseCors("CorsAllowAll");

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllerRoute(
        "areas",
        "{area:exists}/{controller=Home}/{action=Index}/{id?}");
      endpoints.MapControllerRoute(
        "default",
        "{controller=Home}/{action=Index}/{id?}");
    });
  }
}