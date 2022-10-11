// See https://aka.ms/new-console-template for more information
using OpenText_Bascule_Core;



FileManager fileManager = new();
var files1 = fileManager.GetFiles("c:\\temp","20221011","*.CS");




Console.WriteLine("End!");