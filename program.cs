using Newtonsoft.Json;
using System;
using System.IO;


public class Program
{
    internal class Test
    {
        public string A { get; set; }
        public bool B { get; set; }

        public override string ToString()
        {
            return ">" + this.A + ":" + this.B;
        }
    }

    internal class Converter : JsonConverter<Test>
    {
        public override void WriteJson(JsonWriter writer, Test? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override Test? ReadJson(JsonReader reader, Type objectType, Test? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            while (reader.Read()) ;
            return new Test { A = "aha", B = false };
        }
    }

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
        
        string inp = File.ReadAllText("./test.json");

        Console.WriteLine(JsonConvert.DeserializeObject(inp));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.None
        }));

        Console.WriteLine(JsonConvert.DeserializeObject<Test>(inp));
        
        var a = new Converter();
        Console.WriteLine(JsonConvert.DeserializeObject<Test>(inp, a));
        Console.WriteLine(JsonConvert.DeserializeObject<Test>(inp, new Converter()));
        Console.WriteLine(JsonConvert.DeserializeObject<Test>(inp, new Converter(), new Converter()));

        Console.WriteLine(JsonConvert.DeserializeObject(inp, new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.None
        }));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, new JsonSerializerSettings()));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, settings()));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, S.s));

        Console.WriteLine(JsonConvert.DeserializeObject<Test>(inp, new JsonSerializerSettings()));

        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test)));

        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test), new Converter()));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test), new Converter(), new Converter()));

        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test), new JsonSerializerSettings()));
        
        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test), new JsonSerializerSettings { DateFormatString = "yyyy" }));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test), new JsonSerializerSettings
        {
            DateFormatString = "yyyy",
        }));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test), new JsonSerializerSettings
        {
            DateFormatString = "yyyy"
        }));
        Console.WriteLine(JsonConvert.DeserializeObject(inp, typeof(Test), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None }));
    }

    static JsonSerializerSettings settings()
    {
        return new JsonSerializerSettings();
    }
}
