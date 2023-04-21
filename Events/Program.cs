using Events.Core.Data.Context.Concrete;
using Microsoft.EntityFrameworkCore;
using Events.UI.Providers.Concrete;
using Events.Providers.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEventProvider, EventProvider>();

var connectionString = builder.Configuration.GetConnectionString("MyDbConnection");
builder.Services.AddDbContext<EventsDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    var routeProvider = new RoutesProvider();
    var routes = routeProvider.GetEntityFromJsonFile("Routes/routes.json");
    foreach (var route in routes)
    {
        endpoints.MapControllerRoute(route.Name, route.Pattern, route.Defaults);
    }
});


app.Run();
