using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain
{
    public class Image
    {

        public Guid ImageGuid { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] Context { get; set; }
        public string Extension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Size { get; set; }
        public string Resolution { get; set; }
        public string Description { get; set; }
        public int? DisplayPositionX { get; set; }
        public int? DisplayPositionY { get; set; }

    }
}
