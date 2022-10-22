using System.Text.Json;

namespace Crawler.models.formatters;

public class JsonFormatter : IFormatter
{
    public string Format<TValue>(TValue value)
    {
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        return JsonSerializer.Serialize(value, serializeOptions);
    }
}