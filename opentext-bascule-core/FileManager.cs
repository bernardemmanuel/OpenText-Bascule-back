
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


        public List<FileDto> GetFiles(string path, string date, string filePattern)
        {
            string pathPattern = $"*{date}*";
  
            var result = new List<FileDto>();

            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories(pathPattern, SearchOption.AllDirectories);
            foreach (DirectoryInfo folder in dirs)
            {
                foreach (FileInfo file in folder.GetFiles(filePattern))
                {
                    result.Add(new FileDto()
                    {
                        Id = result.Count,
                        Name = file.Name,
                        LastWriteTime = file.LastWriteTime.ToString("MM/dd/yyyy HH:mm:ss"),
                        Length = file.Length,
                        FullPath = file.FullName,
                        PartialPath = file.DirectoryName?.Replace(path, "")
                    });
                }
            }


            return result;
        }

    } // end class
} // end namespace
