// See https://aka.ms/new-console-template for more information
using OpenText_Bascule_Core;



FileManager fileManager = new();
var files1 = fileManager.GetFiles("c:\\temp");

var files2 = fileManager.GetFilesRecursivelyFromPattern("c:\\temp", "*.cs", ".*net6.0.*");


Console.WriteLine("End!");