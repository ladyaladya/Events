using System.Web;

namespace Events.UI.Helpers
{
    public static class UrlEncoder
    {
        public static string EncodeQueryKeys(string? url)
        {
            if (url == null)
            {
                return "";
            }

            var queryString = new Uri(url).Query;
            var nameValueCollection = HttpUtility.ParseQueryString(queryString);
            var queryList = new List<KeyValuePair<string, string>>();

            foreach (string key in nameValueCollection.Keys)
            {
                //string encodedKey = HttpUtility.UrlEncode(key);
                string encodedKey = Uri.EscapeDataString(key);
                string value = nameValueCollection[key] ?? "";
                //string encodedValue = HttpUtility.UrlEncode(value);
                string encodedValue = Uri.EscapeDataString(value);
                queryList.Add(new KeyValuePair<string, string>(encodedKey, encodedValue));
            }

            string encodedQuery = string.Join("&", queryList.Select(pair => $"{pair.Key}={pair.Value}"));
            string encodedUrl = $"{url.Split('?')[0]}?{encodedQuery}";

            return encodedUrl;
        }
    }
}
