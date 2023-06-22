using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OnionProject.Persistence.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((context, cfg) =>
{
    cfg.AddJsonFile($"configuration.{context.HostingEnvironment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();
});

var appSettingsSection = builder.Configuration;
var appSettings = appSettingsSection.Get<AppSettings>();

var key = Encoding.UTF8.GetBytes(appSettings.JWTSecret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddOcelot();

var app = builder.Build();
//var configuration = new OcelotPipelineConfiguration
//{
//    AuthorizationMiddleware = async (ctx, next) =>
//    {
//        if (Authorize(ctx))
//        {
//            await next.Invoke();

//        }
//        else
//        {
//            //ctx.Errors.Add(new UnauthorisedError($"Fail to authorize"));
//        }
//    }
//};

//app.UseOcelot(configuration);
app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();

//static bool Authorize(HttpContext ctx)
//{
//    DownstreamRoute route = (DownstreamRoute)ctx.Items["DownstreamRoute"];
//    string key = route.AuthenticationOptions.AuthenticationProviderKey;

//    if (key == null || key == "") return true;
//    if (route.RouteClaimsRequirement.Count == 0) return true;
//    else
//    {
//        //flag for authorization
//        bool auth = false;

//        //where are stored the claims of the jwt token
//        Claim[] claims = ctx.User.Claims.ToArray<Claim>();

//        //where are stored the required claims for the route
//        Dictionary<string, string> required = route.RouteClaimsRequirement;

//        return auth;
//    }
//}
