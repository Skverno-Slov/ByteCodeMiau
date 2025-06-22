using DatabaseLibrary.Database;
using DatabaseLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string dbPath = Path.Combine(Environment.CurrentDirectory,"database.db");
string connectionString = $"Data Source={dbPath}";

builder.Services.AddSingleton<IDatabaseFactory>(new SqliteFactory(connectionString));
builder.Services.AddScoped<EntertainmentRepository>();
builder.Services.AddScoped<ReviewRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
