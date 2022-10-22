namespace Crawler.models.university;

public class University
{
    public string CreatedAt { get; }
    public string Author { get; }
    public HashSet<Student> Studenci { get; }
    public HashSet<ActiveStudy> ActiveStudies { get; }

    private University(string createdAt, string author,
        HashSet<Student> studenci, HashSet<ActiveStudy> activeStudies)
    {
        CreatedAt = createdAt;
        Author = author;
        Studenci = studenci;
        ActiveStudies = activeStudies;
    }

    public static University Create(string author, HashSet<Student> studenci)
    {
        var createdAt = DateTime.Now.ToString("yyyy-MM-dd");
        var activeStudies = FetchActiveStudies(studenci);
        return new University(createdAt, author, studenci, activeStudies);
    }

    private static HashSet<ActiveStudy> FetchActiveStudies(IEnumerable<Student> studenci)
    {
         return studenci.Distinct()
            .Select(m => m.Studies)
            .GroupBy(m => m.Name)
            .Select(group => new ActiveStudy(
                group.Key,
                group.Count().ToString()
                )
            )
            .ToHashSet();
    }

    public Result GetResult()
    {
        return Result.CreateFrom(this);
    }

}