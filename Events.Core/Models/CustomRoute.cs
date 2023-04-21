namespace Events.Core.Models
{
    public class CustomRoute
    {
        public string Name { get; set; }
        public string Pattern { get; set; }
        public RouteDefaults Defaults { get; set; }
    }

    public class RouteDefaults
    {
        public string Controller { get; set; }
        public string Action { get; set; }
    }

}
