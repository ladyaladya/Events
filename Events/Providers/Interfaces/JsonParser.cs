using System.Text.Json;

namespace Events.UI.Providers.Interfaces
{
    public interface JsonParser<T>
    {
        public static IEnumerable<T> GetEntitiesFrom(string path)
        {
            try
            {
                return TryGetEntitiesFrom(path);
            }
            catch (Exception)
            {
                throw new Exception($"Failed to get entities from {typeof(JsonParser<T>)} type with provided '{path}' path");
                // to do
                // replace exception throwing with logging the error
            }
        }

        private static IEnumerable<T> TryGetEntitiesFrom(string path)
        {
            var entities = GetJsonFrom(path);
            var deserializedEntities = GetDeserializedEntities<T>(entities);

            if (deserializedEntities == null)
            {
                throw new Exception($"Deserialized Entities was null in {typeof(JsonParser<T>)} type with provided '{path}' path");
            }

            return deserializedEntities;
        }

        private static string GetJsonFrom(string path)
        {
            return File.ReadAllText(path);
        }

        private static IEnumerable<T>? GetDeserializedEntities<T>(string entities)
        {
            return JsonSerializer.Deserialize<IEnumerable<T>>(entities);
        }
    }
}
