private void saveToolStripMenuItem_Click(object sender, EventArgs e)
{
    SaveRom();
}
private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (romData == null)
    {
        return;
    }

    using (SaveFileDialog dialog = new SaveFileDialog())
    {
        dialog.Filter = "NES ROM Files (*.nes)|*.nes|All files (*.*)|*.*";
        dialog.Title = "Save ROM As";
        dialog.FileName = Path.GetFileName(filePath);

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            filePath = dialog.FileName;
            SaveRom();
        }
    }
}
