using Newtonsoft.Json;

public class S
{
    public static JsonSerializerSettings s = new JsonSerializerSettings()
    {
        TypeNameHandling = TypeNameHandling.All,
    };
}
