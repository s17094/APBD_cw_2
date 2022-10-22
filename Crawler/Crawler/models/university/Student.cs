using Crawler.models.util;

namespace Crawler.models.university;

public class Student
{
    public string IndexNumber { get; }
    public string Fname { get; }
    public string Lname { get; }
    public string Birthdate { get; }
    public string Email { get; }
    public string MothersName { get; }
    public string FathersName { get; }
    public Studies Studies { get; }

    private Student(string indexNumber, string fname, string lname, string birthdate,
        string email, string mothersName, string fathersName, Studies studies)
    {
        IndexNumber = indexNumber;
        Fname = fname;
        Lname = lname;
        Birthdate = birthdate;
        Email = email;
        MothersName = mothersName;
        FathersName = fathersName;
        Studies = studies;
    }

    public static Student? CreateStudent(int rowNumber, string studentInfo)
    {
        var studentParams = studentInfo.Split(",");
        if (studentParams.Length != 9)
        {
            FileUtil.WriteError("Error loading student from row "
                                + rowNumber + ": Invalid number of columns.");
            return null;
        }

        var student = FetchStudent(studentParams);

        if (NonValid(student))
        {
            FileUtil.WriteError("Error loading student from row "
                                + rowNumber + ": Empty field detected in columns.");
            return null;
        }

        return student;
    }

    private static Student FetchStudent(string[] studentParams)
    {
        var fname = studentParams[0].Trim();
        var lname = studentParams[1].Trim();
        var studies = new Studies(studentParams[2].Trim(), studentParams[3].Trim());
        var indexNumber = "s" + studentParams[4].Trim();
        var birthdate = studentParams[5].Trim();
        var email = studentParams[6].Trim();
        var mothersName = studentParams[7].Trim();
        var fathersName = studentParams[8].Trim();

        return new Student(indexNumber, fname, lname, birthdate,
            email, mothersName, fathersName, studies);
    }

    private static bool NonValid(Student student)
    {
        return string.IsNullOrEmpty(student.IndexNumber) ||
               string.IsNullOrEmpty(student.Fname) ||
               string.IsNullOrEmpty(student.Lname) ||
               string.IsNullOrEmpty(student.Birthdate) ||
               string.IsNullOrEmpty(student.Email) ||
               string.IsNullOrEmpty(student.MothersName) ||
               string.IsNullOrEmpty(student.FathersName) ||
               string.IsNullOrEmpty(student.Studies.Name) ||
               string.IsNullOrEmpty(student.Studies.Mode);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IndexNumber, Fname, Lname);
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Student)obj);
    }

    private bool Equals(Student other)
    {
        return IndexNumber == other.IndexNumber && Fname == other.Fname && Lname == other.Lname;
    }
}