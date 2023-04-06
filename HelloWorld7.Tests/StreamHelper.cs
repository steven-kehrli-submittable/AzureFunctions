using System.Text;
using Newtonsoft.Json;

namespace AzureFunctions.HelloWorld7;

public static class StreamHelper
{
    public static T Deserialize<T>(Stream stream)
    {
        using var reader = new StreamReader(stream);
        using var jsonReader = new JsonTextReader(reader);
        var serializer = new JsonSerializer();
        return serializer.Deserialize<T>(jsonReader) ?? throw new NullReferenceException("json reader is null");
    }

    public static Stream ConvertToStream(object value)
    {
        // serialize the object to a string
        var jsonString = JsonConvert.SerializeObject(value);

        // get the bytes
        var jsonBytes = Encoding.UTF8.GetBytes(jsonString);

        return new MemoryStream(jsonBytes);
    }
}
