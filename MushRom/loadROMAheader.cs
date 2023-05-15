private void LoadRomHeader(byte[] romData)
{
    if (romData.Length < 0x10)
    {
        MessageBox.Show("Invalid ROM file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    string nesString = Encoding.ASCII.GetString(romData, 0, 4);
    if (nesString != "NES\x1A")
    {
        MessageBox.Show("Invalid ROM file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    byte numPRGROMBanks = romData[4];
    byte numCHRROMBanks = romData[5];
    byte flags6 = romData[6];
    byte flags7 = romData[7];
    byte numPRGRAMBanks = romData[8];
    byte flags9 = romData[9];
    byte flags10 = romData[10];

    lblNumPRGROMBanks.Text = numPRGROMBanks.ToString();
    lblNumCHRROMBanks.Text = numCHRROMBanks.ToString();
    lblMapperNumber.Text = ((flags6 >> 4) | (flags7 & 0xF0)).ToString();
    lblMirroring.Text = ((flags6 & 0x08) != 0) ? "Vertical" : "Horizontal";
    lblBatteryBacked.Text = ((flags6 & 0x02) != 0) ? "Yes" : "No";
    lblTrainer.Text = ((flags6 & 0x04) != 0) ? "Yes" : "No";
    lblFourScreenVRAM.Text = ((flags6 & 0x01) != 0) ? "Yes" : "No";
    lblVSUnisystem.Text = ((flags7 & 0x01) != 0) ? "Yes" : "No";
    lblPlayChoice10.Text = ((flags7 & 0x02) != 0) ? "Yes" : "No";
    lblNumPRGRAMBanks.Text = numPRGRAMBanks.ToString();
    lblPALRegion.Text = ((flags9 & 0x01) != 0) ? "Yes" : "No";
    lblReserved.Text = ((flags9 & 0x02) != 0) ? "Yes" : "No";
    lblTVSystem.Text = ((flags10 & 0x01) != 0) ? "PAL" : "NTSC";
}
