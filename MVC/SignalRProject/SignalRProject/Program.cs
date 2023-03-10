using Microsoft.EntityFrameworkCore;
using SignalRProject;
using SignalRProject.Data;
using SignalRProject.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("default")));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>(); 
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<SignalRServer>("/signalRServer");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=categories}/{action=index}/{id?}");

app.Run();
