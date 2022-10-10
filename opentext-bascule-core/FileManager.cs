using System.IO;
using System.Text.RegularExpressions;

namespace OpenText_Bascule_Core
{
    public class FileManager : IFileManager
    {
        static void CheckDirectoryPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new Exception($"Path '{path}' is not valid.");

            if (!Directory.Exists(path))
                throw new Exception($"Path '{path}' does not exist.");
        }

        public void CopyFile(string sourceDirName, string targetDirName, string fileName)
        {
            CheckDirectoryPath(sourceDirName);
            CheckDirectoryPath(targetDirName);

            if (string.IsNullOrEmpty(fileName))
                throw new Exception($"FileName is not valid.");

            var sourceFileName = Path.Combine(sourceDirName, fileName);

            if (!File.Exists(sourceFileName))
                throw new Exception($"File '{sourceFileName}' does not exist.");

            var targetFileName = Path.Combine(targetDirName, fileName);

            File.Copy(sourceFileName, targetFileName, true);
        }

        public void CopyFiles(List<string> files, string targetDirName)
        {
            if (files == null)
                return;

            CheckDirectoryPath(targetDirName);

            files.ForEach(f =>
            {
                var fileName = Path.GetFileName(f);
                var targetFileName = Path.Combine(targetDirName, fileName);

                File.Copy(f, targetFileName, true);
            });

        }



        public List<FileDto> GetFiles(string path)
        {
            return GetFilesRecursivelyFromPattern(path, "*.cs", ".*net6.0.*");
            /*
            CheckDirectoryPath(path);

            var result = new List<FileDto>();

            DirectoryInfo di = new(path);
            var files = di.GetFiles().ToList();

            files.ForEach(f =>
            {
                result.Add(new FileDto()
                {
                    Id = result.Count,
                    Name = f.Name,
                    LastWriteTime = f.LastWriteTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    Length = f.Length
                });
            });

            return result;
            */
        }


        private List<FileDto> GetFilesRecursivelyFromPattern(string path, string filePattern, string pathPattern)
        {
            CheckDirectoryPath(path);

            var result = new List<FileDto>();

            //Regex reg = new(@".*net6.0.*");
            Regex reg = new(pathPattern);

            var files = Directory.GetFiles(path, filePattern, SearchOption.AllDirectories)
                                 .Where(path => reg.IsMatch(path))
                                 .ToList();

            files.ForEach(f =>
            {
                FileInfo fi = new(f);
            
                result.Add(new FileDto()
                {
                    Id = result.Count,
                    Name = fi.Name,
                    LastWriteTime = fi.LastWriteTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    Length = fi.Length,
                    FullPath = fi.FullName,
                    PartialPath = fi.DirectoryName?.Replace(path, "")
                });

            });

            return result;
        }
    }
}
