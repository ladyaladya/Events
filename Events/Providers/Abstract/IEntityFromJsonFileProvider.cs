namespace Events.UI.Providers.Abstract
{
    public interface IEntityFromJsonFileProvider<T>
    {
        public IEnumerable<T> GetEntityFromJsonFile(string path);
    }
}
