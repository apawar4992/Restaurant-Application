using Restaurant.Manager.Implementation;
using Restaurant.Manager.Interfaces;
using Restaurant.Repository.Implementation;
using Restaurant.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

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

builder.Services.AddSingleton<IRestaurantManager, RestaurantManager>();
builder.Services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddSingleton<IMenuManager, MenuManager>();
builder.Services.AddSingleton<IMenuRepository, MenuRepository>();

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
