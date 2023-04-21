using Events.Core.Models;
using Events.UI.Providers.Abstract;
using System.Text.Json;

namespace Events.UI.Providers.Concrete
{
    public class RoutesProvider : IEntityFromJsonFileProvider<CustomRoute>
    {
        public IEnumerable<CustomRoute> GetEntityFromJsonFile(string path)
        {
            var jsonRoutes = File.ReadAllText(path);
            var routes = JsonSerializer.Deserialize<IEnumerable<CustomRoute>>(jsonRoutes);

            if (routes == null)
            {
                throw new Exception($"Routes was't recognized at {GetType()}");
            }

            return routes;
        }
    }
}
