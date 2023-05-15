private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
{
    if (romData == null)
    {
        return;
    }

    using (SaveFileDialog dlg = new SaveFileDialog())
    {
        dlg.Filter = "NES ROM Files (*.nes)|*.nes|All Files (*.*)|*.*";
        dlg.Title = "Save ROM As";
        dlg.FileName = Path.GetFileName(filePath);

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            filePath = dlg.FileName;
            SaveRom();
        }
    }
}
