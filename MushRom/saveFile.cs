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
        MessageBox.Show("Error saving ROM file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
