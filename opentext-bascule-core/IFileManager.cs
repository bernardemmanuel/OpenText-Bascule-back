namespace OpenText_Bascule_Core
{
    public interface IFileManager
    {
        List<FileDto> GetFiles(string path);
        List<FileDto> GetFilesRecursivelyFromPattern(string path, string filePattern, string pathPattern);
        void CopyFile(string sourceDirName, string targetDirName, string fileName);
        void CopyFiles(List<string> files, string targetDirName);
    }
}
