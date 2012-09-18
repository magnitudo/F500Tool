using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F500Tool
{
    public class RomFile
    {
        public RomFileHeader Header;
        public byte[] Content;

        public string FileName
        {
            get { return Header.FileName; }
        }
    }
}
