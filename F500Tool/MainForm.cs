using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NLog;

namespace F500Tool
{
    public partial class MainForm : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private FileHeader _fileHeader;
        private SectionHeader _sectionHeader;
        private RomHeader _romHeader;
        private List<RomFile> _files;
        private List<EntireBitmap> _bitmaps;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {            
        }

        private void OpenFirmwareClick(object sender, EventArgs e)
        {
            LogTextBox.Clear();

            var oDlg = new OpenFileDialog
                           {
                               RestoreDirectory = true
                           };
            
            if (oDlg.ShowDialog() == DialogResult.OK)
            {
                LoadFile(oDlg.FileName);
            }
        }

        private void LoadFile(string fileName)
        {
            Logger.Trace("Opening file {0}", fileName);

            using (var stream = File.OpenRead(fileName))
            {
                try
                {
                    _fileHeader = CheckFileHeader(stream);
                    LogHeaderInfo(_fileHeader);
                    if (RomExists(_fileHeader))
                    {
                        Logger.Trace("Parsing ROM");
                         _sectionHeader = CheckRomSectionHeader(stream, _fileHeader);
                         LogSectionHeader(_sectionHeader);
                        Logger.Trace("Check CRC32");
                        CheckSectionCRC(stream, _fileHeader.RomStart, _sectionHeader);
                        Logger.Trace("CRC32 Ok");
                        _romHeader = CheckRomHeader(stream, _fileHeader.RomStart);
                        LogRomHeader(_romHeader);
                        _files = LoadRomFiles(stream, _fileHeader.RomStart, _romHeader);
                        ShowFiles(_files);
                        tabControl1.SelectTab(RomTabPage);
                    }
                }
                catch(Exception ex)
                {
                    Logger.ErrorException(ex.Message, ex);
                }
            }
        }

        private void ShowFiles(IEnumerable<RomFile> files)
        {
            filesListBox.Items.Clear();

            foreach(var file in files)
            {
                filesListBox.Items.Add(file.FileName);
            }
        }

        private unsafe List<RomFile> LoadRomFiles(FileStream stream, int sectionStart, RomHeader romHeader)
        {
            var result = new List<RomFile>();

            stream.Seek(sectionStart + sizeof(SectionHeader) + sizeof(RomHeader), SeekOrigin.Begin);

            for(var i=0; i < romHeader.FilesCount;i++)
            {
                var fileHeaderData = new byte[sizeof(RomFileHeader)];
                var count = stream.Read(fileHeaderData, 0, fileHeaderData.Length);

                if (count != fileHeaderData.Length)
                    throw new Exception(String.Format("Readed only {0} bytes from {1}", count, fileHeaderData.Length));

                var romFile = new RomFile {Header = fromBytes<RomFileHeader>(fileHeaderData)};
                if (romFile.Header.Magik == Const.RomFileHeaderMagik)
                {
                    result.Add(romFile);
                }
                else throw new Exception("Wrong Magik. File isn't valid firmware file");                 
            }

            foreach(var file in result)
            {
                stream.Seek(sectionStart + sizeof(SectionHeader) + file.Header.FileOffset, SeekOrigin.Begin);
                var data = new byte[file.Header.FileLength];
                var count = stream.Read(data, 0, data.Length);
                if (count != data.Length)
                    throw new Exception(String.Format("Readed only {0} bytes from {1}", count, data.Length));
                
                file.Content = data;
            }

            return result;
        }

        private void LogRomHeader(RomHeader romHeader)
        {
            Logger.Trace("ROM header:");
            Logger.Trace("FilesCount={0}", romHeader.FilesCount);
            Logger.Trace("Magik=0x{0:X}", romHeader.Magik);            
        }

        private unsafe RomHeader CheckRomHeader(FileStream stream, int sectionStart)
        {
            stream.Seek(sectionStart + sizeof(SectionHeader), SeekOrigin.Begin);
            var romHeaderData = new byte[sizeof(RomHeader)];
            var count = stream.Read(romHeaderData, 0, romHeaderData.Length);

            if (count != romHeaderData.Length)
                throw new Exception(String.Format("Readed only {0} bytes from {1}", count, romHeaderData.Length));

            var romHeader = fromBytes<RomHeader>(romHeaderData);

            if (romHeader.Magik == Const.RomHeaderMagik)
            {
                return romHeader;
            }
            throw new Exception("Wrong Magik. File isn't valid firmware file");  
        }

        private unsafe void CheckSectionCRC(FileStream stream, int sectionStart, SectionHeader sectionHeader)
        {
            stream.Seek(sectionStart + sizeof(SectionHeader), SeekOrigin.Begin);

            var sectionData = new byte[sectionHeader.ImgLen];
            var count = stream.Read(sectionData, 0, sectionData.Length);

            if (count != sectionData.Length)
                throw new Exception(String.Format("Readed only {0} bytes from {1}", count, sectionData.Length));

            var crc32 = Crc32(sectionData);

            if (sectionHeader.CRC32 != crc32)
                throw new Exception("Bad CRC32");
        }

        private void LogSectionHeader(SectionHeader sectionHeader)
        {
            Logger.Trace("Section header:");
            Logger.Trace("CRC32=0x{0:X}", sectionHeader.CRC32);
            Logger.Trace("Version=0x{0:X}", sectionHeader.Version);
            Logger.Trace("Date=0x{0:X}", sectionHeader.Date);
            Logger.Trace("ImgLen=0x{0:X}", sectionHeader.ImgLen);
            Logger.Trace("Mem=0x{0:X}", sectionHeader.Mem);
            Logger.Trace("Flags=0x{0:X}", sectionHeader.Flags);
            Logger.Trace("Magik=0x{0:X}", sectionHeader.Magik);
        }

        private unsafe SectionHeader CheckRomSectionHeader(FileStream stream, FileHeader fileHeader)
        {
            stream.Seek(fileHeader.RomStart, SeekOrigin.Begin);
            var sectionHeaderData = new byte[sizeof(SectionHeader)];
            var count = stream.Read(sectionHeaderData, 0, sectionHeaderData.Length);

            if (count != sectionHeaderData.Length)
                throw new Exception(String.Format("Readed only {0} bytes from {1}", count, sectionHeaderData.Length));

            var sectionHeader = fromBytes<SectionHeader>(sectionHeaderData);

            if (sectionHeader.Magik == Const.SectionHeaderMagik)
            {
                return sectionHeader;
            }
            throw new Exception("Wrong Magik. File isn't valid firmware file");                 
        }

        private static void LogHeaderInfo(FileHeader fileHeader)
        {
            if (fileHeader.BstStart != fileHeader.BstEnd)
                Logger.Trace("BST found");

            if (fileHeader.BldStart != fileHeader.BldEnd)
                Logger.Trace("BLD found");

            if (fileHeader.PriStart != fileHeader.PriEnd)
                Logger.Trace("PRI found");

            if (RomExists(fileHeader))
                Logger.Trace("ROM found");

            if (fileHeader.DspStart != fileHeader.DspEnd)
                Logger.Trace("DPS found");
        }

        private static bool RomExists(FileHeader fileHeader)
        {
            return fileHeader.RomStart != fileHeader.RomEnd;
        }

        unsafe private FileHeader CheckFileHeader(FileStream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var data = new byte[sizeof (FileHeader)];
            var count = stream.Read(data, 0, data.Length);

            if (count != data.Length)
                throw new Exception(String.Format("Readed only {0} bytes from {1}", count, data.Length));
            
            var fileHeader = fromBytes<FileHeader>(data);

            if (fileHeader.Magik == Const.FileHeaderMagik)
            {
                return fileHeader;
            }
            throw new Exception("Wrong Magik. File isn't valid firmware file");                      
        }

        byte[] getBytes<TStruct>(TStruct str) where TStruct : struct
        {
            int size = Marshal.SizeOf(str);
            var arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(str, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        TStruct fromBytes<TStruct>(byte[] arr) where TStruct : struct
        {
            var str = new TStruct();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (TStruct)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        UInt32 Crc32(byte[] buf)
        {
            var crcTable = new UInt32[256];


            for (UInt32 i = 0; i < 256; i++)
            {
                var crc = i;
                for (var j = 0; j < 8; j++)
                    crc = ((crc & 1) != 0)? (crc >> 1) ^ 0xEDB88320U : crc >> 1;

                crcTable[i] = crc;
            };
 
            var crc32 = 0xFFFFFFFFU;
            var counter = 0;

            while (counter < buf.Length)
            {
                crc32 = crcTable[(crc32 ^ buf[counter]) & 0xFF] ^ (crc32 >> 8);
                counter++;
            }

            return crc32 ^ 0xFFFFFFFFU;
        }

        private void ExtractButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (filesListBox.SelectedIndex < 0 || _files == null) return;

                var file = _files[filesListBox.SelectedIndex];
                var saveDlg = new SaveFileDialog
                                    {
                                        FileName = file.FileName,
                                        RestoreDirectory = true
                                    };
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveDlg.FileName, file.Content);
                }                
            }
            catch(Exception ex)
            {
                Logger.ErrorException(ex.Message, ex);
            }
        }

        private void PackButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (filesListBox.SelectedIndex < 0 || _files == null) return;

                var file = _files[filesListBox.SelectedIndex];
                var openDlg = new OpenFileDialog()
                {                    
                    RestoreDirectory = true
                };
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    file.Content = File.ReadAllBytes(openDlg.FileName);
                    var newName = "[*]" + filesListBox.Items[filesListBox.SelectedIndex];
                    filesListBox.Items[filesListBox.SelectedIndex] = newName;

                }
            }
            catch (Exception ex)
            {
                Logger.ErrorException(ex.Message, ex);
            }
        }

        private unsafe void SaveRomButtonClick(object sender, EventArgs e)
        {
            try
            {
                var filesData = new List<byte>();

                var filesDataBaseRawOffset = sizeof (RomHeader) + _files.Count*sizeof (RomFileHeader);
                var filesDataBaseOffset = (filesDataBaseRawOffset / 0x800 + 1) * 0x800;
                var filesHeaderPaddingCount = filesDataBaseOffset - filesDataBaseRawOffset;

                foreach (var file in _files)
                {
                    file.Header.FileOffset = filesDataBaseOffset;
                    file.Header.FileLength = file.Content.Length;

                    Logger.Trace("{0} {1:X} {2:X}", 
                        file.FileName, file.Header.FileOffset, file.Header.FileLength);

                    filesData.AddRange(file.Content);

                    var lastByteOffset = filesDataBaseOffset + file.Content.Length - 1;
                    var nextOffset = (lastByteOffset/0x800 + 1)*0x800;
                    var align = nextOffset - lastByteOffset - 1;

                    if (align != 0)
                    {
                        filesData.AddRange(Enumerable.Repeat((byte) 0xFF, align));
                    }

                    filesDataBaseOffset = nextOffset;
                }

                Logger.Trace("NextOffset={0:X}", filesDataBaseOffset);

                var rom = new List<byte>();

                _romHeader.FilesCount = _files.Count;
                rom.AddRange(getBytes(_romHeader));

                foreach (var file in _files)
                {
                    rom.AddRange(getBytes(file.Header));
                }

                rom.AddRange(Enumerable.Repeat((byte)0xFF, filesHeaderPaddingCount));

                rom.AddRange(filesData);

                var crc32 = Crc32(rom.ToArray());

                _sectionHeader.CRC32 = crc32;
                _sectionHeader.ImgLen = rom.Count;

                //if (_sectionHeader.ImgLen > _fileHeader.MaxRomLength)
                //    throw new Exception("ROM section exceeds max length");

                _fileHeader.BstStart = 0;
                _fileHeader.BstEnd = 0;

                _fileHeader.BldStart = 0;
                _fileHeader.BldEnd = 0;

                _fileHeader.PriStart = 0;
                _fileHeader.PriEnd = 0;

                _fileHeader.RomStart = sizeof (FileHeader);
                _fileHeader.RomEnd = sizeof (FileHeader) + sizeof (SectionHeader) + rom.Count;

                _fileHeader.DspStart = 0;
                _fileHeader.DspEnd = 0;

                var romFile = new List<byte>();

                romFile.AddRange(getBytes(_fileHeader));
                romFile.AddRange(getBytes(_sectionHeader));
                romFile.AddRange(rom);

                romFile.AddRange(Enumerable.Repeat((byte)0,0x700));

                var saveDlg = new SaveFileDialog
                                  {
                                      FileName = "yamaha.bin",
                                      RestoreDirectory = true
                                  };
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveDlg.FileName, romFile.ToArray());
                }
            }
            catch(Exception ex)
            {
                Logger.ErrorException(ex.Message,ex);

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FilesListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var index = filesListBox.SelectedIndex;
                if (index >= 0 && _files != null)
                {
                    var file = _files[index];
                    picturePreview.Image = file.FileName.ToLower().Contains(".jpg") 
                        ? Image.FromStream(new MemoryStream(file.Content)) 
                        : null;

                    if (file.FileName == "bitmaps.bin")
                        ParseBitmaps(file);
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorException(ex.Message, ex);
            }
        }

        private unsafe void ParseBitmaps(RomFile file)
        {
            _bitmaps = new List<EntireBitmap>();

            var headerData = file.Content.Take(sizeof (BitmapsBinFileHeader)).ToArray();

            var header = fromBytes<BitmapsBinFileHeader>(headerData);

            var firstBitmapHeaderOffset = sizeof (BitmapsBinFileHeader);

            for (var i = 0; i < header.BitmapCount; i++)
            {               
                var bitmapHeaderData = new byte[sizeof(BitmapHeader)];

                Array.Copy(
                    file.Content, 
                    firstBitmapHeaderOffset + i * sizeof(BitmapHeader), 
                    bitmapHeaderData, 
                    0, 
                    sizeof(BitmapHeader)); 
           
                var bitmapHeader = fromBytes<BitmapHeader>(bitmapHeaderData);

                var bitmapData = new byte[bitmapHeader.Length];

                Array.Copy(
                    file.Content,
                    bitmapHeader.Start,
                    bitmapData,
                    0,
                    bitmapHeader.Length);

                var entireBitmap = new EntireBitmap();

                entireBitmap.Header = bitmapHeader;
                entireBitmap.BitmapData = new BitmapData();
                entireBitmap.BitmapData.FillFromByteArray(bitmapData);

                _bitmaps.Add(entireBitmap);
                BitmapsList.Items.Add(entireBitmap);
            }
        }

        private void BitmapsListSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hexTextBox.Text = "";
                var index = BitmapsList.SelectedIndex;
                if (index >= 0 && _bitmaps != null)
                {
                    var bitmap = _bitmaps[index];
                    for (int i=0; i < bitmap.BitmapData.Data.Length; i++)
                    {
                        if ((i % 16 == 0) && (i !=0)) hexTextBox.Text += Environment.NewLine;

                        hexTextBox.Text += String.Format("{0:X2} ", bitmap.BitmapData.Data[i]);
                    }                    
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorException(ex.Message, ex);
            }
        }
    }
}
