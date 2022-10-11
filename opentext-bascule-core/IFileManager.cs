namespace OpenText_Bascule_Core
{
    public interface IFileManager
    {
        List<FileDto> GetFiles(string path, string date, string filePattern);
        void CopyFiles(List<string> files, string targetDirName);
    }
}
