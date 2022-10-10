namespace OpenText_Bascule_Core
{
    public class FileDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = String.Empty;
        public string LastWriteTime { get; set; } = String.Empty;
        public long Length { get; set; } = 0;
        public string FullPath { get; set; } = String.Empty;
        public string? PartialPath { get; set; } = String.Empty;

    }
}
