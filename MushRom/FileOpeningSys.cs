private void openToolStripMenuItem_Click(object sender, EventArgs e)
{
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "NES ROM Files (*.nes)|*.nes|All Files (*.*)|*.*";
    openFileDialog.FilterIndex = 1;
    openFileDialog.Multiselect = false;

    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
        string fileName = openFileDialog.FileName;
        byte[] romData = File.ReadAllBytes(fileName);
        hexBox.ByteProvider = new DynamicByteProvider(romData);
        LoadRomHeader(romData);
        this.Text = "NES ROM Editor - " + Path.GetFileName(fileName);
    }
}

private void saveToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (romData == null)
    {
        MessageBox.Show("No ROM is currently loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    if (currentRomFileName == null)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "NES ROM Files (*.nes)|*.nes|All Files (*.*)|*.*";
        saveFileDialog.FilterIndex = 1;

        if (saveFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        currentRomFileName = saveFileDialog.FileName;
    }

    File.WriteAllBytes(currentRomFileName, romData);
}

private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (romData == null)
    {
        MessageBox.Show("No ROM is currently loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.Filter = "NES ROM Files (*.nes)|*.nes|All Files (*.*)|*.*";
    saveFileDialog.FilterIndex = 1;

    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        currentRomFileName = saveFileDialog.FileName;
        File.WriteAllBytes(currentRomFileName, romData);
    }
}
