using Crawler.models.util;

VerifyArguments(args);

var sourcePath = args[0];
var destinationPath = args[1];
var format = args[2];

VerifyPath(sourcePath);
VerifyFile(sourcePath);

VerifyPath(destinationPath);

FileUtil.Export(sourcePath, destinationPath, format);

void VerifyArguments(string[] args)
{
    if (args.Length < 3)
    {
        FileUtil.WriteError("Wrong number of application arguments.");
    }
}

void VerifyPath(string path)
{
    if (WrongPath(path))
    {
        throw new ArgumentException("Podana ścieżka jest niepoprawna.");
    }
}

bool WrongPath(string path)
{
    var fileName = Path.GetFileName(path);
    var startIndexOfFile = path.Length - fileName.Length;
    var directoryPath = path.Remove(startIndexOfFile, fileName.Length);
    var directoryInfo = new DirectoryInfo(directoryPath);
    return !directoryInfo.Exists;
}

void VerifyFile(string filePath)
{
    FileInfo fileInfo = new FileInfo(filePath);
    if (!fileInfo.Exists)
    {
        throw new FileNotFoundException("Plik " + fileInfo.Name + " nie istnieje.");
    }
}