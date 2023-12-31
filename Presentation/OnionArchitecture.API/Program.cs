using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnionProject.Persistence;
using OnionProject.Persistence.Configurations;
using OnionProject.Application;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// JWT authentication Aayarlaması
//AppSettings

///////////////////////////////////////////
var appSettingsSection = builder.Configuration;
var appSettings = appSettingsSection.Get<AppSettings>();
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

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
        ClockSkew=TimeSpan.Zero
    };
});
builder.Services.AddSingleton(appSettings);


///////////////////////////////////////////
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();//-->Eklendi.

app.UseAuthorization();

app.MapControllers();

app.Run();
