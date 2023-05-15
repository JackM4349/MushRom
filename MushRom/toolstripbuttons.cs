// Add a label to display the ROM filename
Label lblFilename = new Label();
lblFilename.Text = "No file loaded";
lblFilename.Location = new Point(10, 30);
this.Controls.Add(lblFilename);

// Add a button to reload the current ROM
Button btnReload = new Button();
btnReload.Text = "Reload";
btnReload.Location = new Point(10, 60);
btnReload.Click += (sender, e) =>
{
    if (!string.IsNullOrEmpty(_currentFileName))
    {
        LoadRom(_currentFileName);
    }
};
this.Controls.Add(btnReload);

// Add a button to clear the HexBox
Button btnClear = new Button();
btnClear.Text = "Clear";
btnClear.Location = new Point(10, 90);
btnClear.Click += (sender, e) =>
{
    hexBox.ByteProvider = new DynamicByteProvider(new byte[0]);
};
this.Controls.Add(btnClear);
