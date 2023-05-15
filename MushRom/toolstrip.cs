using System;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace NES_ROM_Editor
{
    public partial class MainForm : Form
    {
        private byte[] romData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "NES ROM files (*.nes)|*.nes";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadRom(openFileDialog.FileName);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveRom();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "NES ROM files (*.nes)|*.nes";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveRom(saveFileDialog.FileName);
            }
        }

        private void LoadRom(string fileName)
        {
            // Read the ROM data into memory
            romData = File.ReadAllBytes(fileName);

            // Display the ROM header information in the DataGridView
            dgvHeader.Rows.Clear();
            dgvHeader.Rows.Add("File Name", Path.GetFileName(fileName));
            dgvHeader.Rows.Add("File Size", new FileInfo(fileName).Length.ToString() + " bytes");
            dgvHeader.Rows.Add("Game Title", GetGameTitle());
            dgvHeader.Rows.Add("PRG ROM Banks", romData[4].ToString());
            dgvHeader.Rows.Add("CHR ROM Banks", romData[5].ToString());
            dgvHeader.Rows.Add("Mirroring Mode", GetMirroringMode());
            dgvHeader.Rows.Add("Battery-Backed RAM", GetBatteryBackedRAM());
            dgvHeader.Rows.Add("Trainer", GetTrainer());
            dgvHeader.Rows.Add("TV System", GetTVSystem());
            dgvHeader.Rows.Add("Format", GetFormat());

            // Display the ROM data in the HexBox
            hexBox.ByteProvider = new DynamicByteProvider(romData);
        }

        private void SaveRom(string fileName = null)
        {
            // Save the modified ROM data back to the original file or to a new file
            if (fileName == null)
            {
                File.WriteAllBytes(openFileDialog.FileName, romData);
            }
            else
            {
                File.WriteAllBytes(fileName, romData);
            }
        }

        private string GetGameTitle()
        {
            // The game title is stored in bytes 0-3 of the header
            return System.Text.Encoding.ASCII.GetString(romData, 0, 4);
        }

                private string GetMirroringMode()
        {
            // The mirroring mode is determined by bit 0 of byte 6
            byte flags6 = romData[6];
            if ((flags6 & 0x01) == 0x00)
            {
                return "Horizontal";
            }
            else
            {
                return "Vertical";
            }
        }

        private string GetBatteryBackedRAM()
        {
            // The presence of battery-backed RAM is determined by bit 1 of byte 6
            byte flags6 = romData[6];
            if ((flags6 & 0x02) == 0x02)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        private string GetTrainer()
        {
            // The presence of a trainer is determined by bit 2 of byte 6
            byte flags6 = romData[6];
            if ((flags6 & 0x04) == 0x04)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        private string GetTVSystem()
        {
            // The TV system is determined by bit 0 of byte 9
            byte flags9 = romData[9];
            if ((flags9 & 0x01) == 0x00)
            {
                return "NTSC";
            }
            else
            {
                return "PAL";
            }
        }

        private string GetFormat()
        {
            // The format is determined by bytes 7-8 of the header
            byte formatByte1 = romData[7];
            byte formatByte2 = romData[8];
            if (formatByte1 == 0x41 && formatByte2 == 0x49)
            {
                return "iNES";
            }
            else if (formatByte1 == 0x42 && formatByte2 == 0x49)
            {
                return "NES 2.0";
            }
            else
            {
                return "Unknown";
            }
        }
    }
}
