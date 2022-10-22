using Crawler.models.formatters;
using Crawler.models.university;

namespace Crawler.models.util;

public static class FileUtil
{
    private const string ErrorLogPath = "log.txt";

    static FileUtil()
    {
        File.Delete(ErrorLogPath);
    }

    public static void WriteError(string message)
    {
        File.AppendAllText(ErrorLogPath,message + "\n");
    }

    public static void Export(string sourcePath, string destinationPath, string format)
    {
        var students = LoadStudentsFromCsv(sourcePath);
        var uczelnia = University.Create("Arkadiusz Zieliński", students);
        var formatter = IFormatter.GetFormatter(format);
        var result = formatter.Format(uczelnia.GetResult());
        File.WriteAllText(destinationPath, result);
    }

    private static HashSet<Student> LoadStudentsFromCsv(string sourcePath)
    {
        var studentCsvReader = new StreamReader(new FileInfo(sourcePath).OpenRead());
        var students = new HashSet<Student>();
        var rowNumber = 1;
        while (studentCsvReader.ReadLine() is { } line)
        {
            var student = Student.CreateStudent(rowNumber, line);
            if (student != null)
            {
                students.Add(student);
            }

            rowNumber++;
        }

        return students;
    }
}