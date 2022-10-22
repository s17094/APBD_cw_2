using Crawler.models.university;

namespace Crawler.models;

public class Result
{
    public University University { get; }

    private Result(University university)
    {
        University = university;
    }

    public static Result CreateFrom(University univeristy)
    {
        return new Result(univeristy);
    }
}