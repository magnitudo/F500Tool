using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F500Tool
{
    public class EntireBitmap
    {
        public BitmapHeader Header;
        public BitmapData BitmapData;

        public override string ToString()
        {
            return String.Format(
                "{0:X5} {1:0000}({1:X4}) {2:0000}({2:X4}) {3:0000}({3:X4}) {4:0000}",
                Header.Start,
                Header.Length,
                BitmapData.Width,
                BitmapData.Height,
                BitmapData.Data.Length);
        }
    }
}
