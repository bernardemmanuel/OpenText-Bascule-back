using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenText_Bascule_Core
{
    public class FileDto
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = String.Empty;
        public string LastWriteTime { get; set; } = String.Empty;
        public long Length { get; set; } = 0;


    }
}
