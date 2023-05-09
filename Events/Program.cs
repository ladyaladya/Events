using Events.Core.Data.Context.Concrete;
using Microsoft.EntityFrameworkCore;
using Events.Providers.Interfaces;
using Events.UI.Providers.Interfaces;
using Events.UI.Providers;
using Events.Core.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEventProvider, EventProvider>();

var connectionString = builder.Configuration.GetConnectionString("MyDbConnection");
builder.Services.AddDbContext<EventsDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    var routes = JsonParser<CustomRoute>.GetEntitiesFrom("Routes/routes.json");
    foreach (var route in routes)
    {
        endpoints.MapControllerRoute(route.Name, route.Pattern, route.Defaults);
    }
});

app.Run();
