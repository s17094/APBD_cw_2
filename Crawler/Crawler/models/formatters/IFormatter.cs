namespace Crawler.models.formatters;

public interface IFormatter
{
    string Format <TValue>(TValue value);

    public static IFormatter GetFormatter(string format)
    {
        return format switch
        {
            _ => new JsonFormatter()
        };
    }

}