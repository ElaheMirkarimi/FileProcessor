using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public short Month { get; set; }
        public string Guid { get; set; }
        public short Version { get; set; }
    }
}
