using System.Text.Json;

namespace SportsStore.Infrastructure
{
    //session state nie przechowuje obiektów, jeżeli chce przechowywać Cart object
    //extension method dla ISession, dzięki niej serializujemy obiekt Cart do json
    //łatwo się je zapisuje i odczytuje
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
            ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
