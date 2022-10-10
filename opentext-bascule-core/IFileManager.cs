namespace OpenText_Bascule_Core
{
    public interface IFileManager
    {
        List<FileDto> GetFiles(string path);
        void CopyFile(string sourceDirName, string targetDirName, string fileName);
        void CopyFiles(List<string> files, string targetDirName);
    }
}
