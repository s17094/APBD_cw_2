using Crawler.models.util;

var sourcePath = args[0];
var destinationPath = args[1];
var format = args[2];

Console.WriteLine("Source path: " + sourcePath);
Console.WriteLine("Destination path: " + destinationPath);
Console.WriteLine("Format: " + format);

FileUtil.Export(sourcePath, destinationPath, format);


