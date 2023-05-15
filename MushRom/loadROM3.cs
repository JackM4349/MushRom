private void saveToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (!string.IsNullOrEmpty(_currentFileName))
    {
        File.WriteAllBytes(_currentFileName, hexBox.ByteProvider.Bytes.ToArray());
    }
    else
    {
        saveAsToolStripMenuItem_Click(sender, e);
    }
}

private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
{
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.Filter = "NES ROMs (*.nes)|*.nes|All files (*.*)|*.*";
    saveFileDialog.FilterIndex = 1;
    saveFileDialog.RestoreDirectory = true;

    if (saveFileDialog.ShowDialog() == DialogResult.OK)
    {
        string fileName = saveFileDialog.FileName;
        File.WriteAllBytes(fileName, hexBox.ByteProvider.Bytes.ToArray());
        _currentFileName = fileName;
        lblFilename.Text = Path.GetFileName(fileName);
    }
}
