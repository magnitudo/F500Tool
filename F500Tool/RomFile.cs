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

    public class EntireBitmap
    {
        public BitmapHeader Header;
        public BitmapData   BitmapData;

        public override string ToString()
        {
            return String.Format(
                "{0:X} {1}({1:X}) {2}({2:X}) {3}({3:X}) {4}",
                Header.Start,
                Header.Length,
                BitmapData.Width,
                BitmapData.Height,
                BitmapData.Data.Length);
        }
    }
}
