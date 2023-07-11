using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Manager.Implementation;
using Restaurant.Manager.Interfaces;
using Restaurant.Model;
using Restaurant.Repository.Implementation;
using Restaurant.Repository.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var configuration = builder.Configuration;
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var _jwtsetting = configuration.GetSection("JWTSetting");
builder.Services.Configure<JWTSettings>(_jwtsetting);

builder.Services.AddSingleton<IRestaurantManager, RestaurantManager>();
builder.Services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddSingleton<IMenuManager, MenuManager>();
builder.Services.AddSingleton<IMenuRepository, MenuRepository>();
builder.Services.AddSingleton<IUserManager, UserManager>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IRegisterManager, RegisterManager>();
builder.Services.AddSingleton<IRegisterRepository, RegisterRepository>();
builder.Services.AddSingleton<ITokenManager, TokenManager>();

#region Authentication

var authkey = configuration.GetValue<string>("JWTSetting:securitykey");

builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authkey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
