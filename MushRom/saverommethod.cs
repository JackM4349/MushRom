private void SaveRom()
{
    if (romData == null)
    {
        return;
    }

    try
    {
        File.WriteAllBytes(filePath, romData);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Failed to save ROM: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
