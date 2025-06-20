using DatabaseLibrary.Database;
using DatabaseLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string connectionString = "Data Source=mssql;Initial Catalog=ispp3104;Persist Security Info=True;User ID=ispp3104;Password=3104;Trust Server Certificate=True";
string connectionString = "Data Source=zombatka;Integrated Security=True;Trust Server Certificate=True";

builder.Services.AddSingleton<IDatabaseFactory>(new MsSqlFactory(connectionString));
builder.Services.AddScoped<GamesRepository>();

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
