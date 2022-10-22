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

    public static Student? CreateStudent(string studentInfo)
    {
        var studentParams = studentInfo.Split(",");
        if (studentParams.Length != 9) return null;

        // more or less then 9 columns
        // empty value in column
        // duplicated value

        var fname = studentParams[0];
        var lname = studentParams[1];
        var studies = new Studies(studentParams[2], studentParams[3]);
        var indexNumber = studentParams[4];
        var birthdate = studentParams[5];
        var email = studentParams[6];
        var mothersName = studentParams[7];
        var fathersName = studentParams[8];

        return new Student(indexNumber, fname, lname, birthdate,
            email, mothersName, fathersName, studies);
    }
}