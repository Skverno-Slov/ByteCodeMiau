using WebApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var client = new HttpClient()
{
    BaseAddress = new Uri("http://localhost:5158/api/")
};
builder.Services.AddSingleton<EntertainmentService>(new EntertainmentService(client));
builder.Services.AddSingleton<ReviewService>(new ReviewService(client));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
