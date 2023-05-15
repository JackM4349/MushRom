private void openToolStripMenuItem_Click(object sender, EventArgs e)
{
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "NES ROMs (*.nes)|*.nes|All files (*.*)|*.*";
    openFileDialog.FilterIndex = 1;
    openFileDialog.RestoreDirectory = true;

    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
        string fileName = openFileDialog.FileName;
        LoadRom(fileName);
    }
}

private void LoadRom(string fileName)
{
    byte[] romData = File.ReadAllBytes(fileName);
    hexBox.ByteProvider = new DynamicByteProvider(romData);
    _currentFileName = fileName;
    lblFilename.Text = Path.GetFileName(fileName);
}
