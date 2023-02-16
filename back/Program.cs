using back.DbContexts.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions =>
{
    dbContextOptions.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)))
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
},ServiceLifetime.Transient);


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
