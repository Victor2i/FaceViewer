Imports System.Windows.Forms

Public Class Dialog1
    Dim PhotoTypes As String() = {
        "PhotoF", "PhotoP"
    }

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ComboBox1.SelectedIndex = -1 Then
            Exit Sub
        End If
        If TextBox1.Text = "" Then
            Exit Sub
        End If
        My.Computer.FileSystem.WriteAllBytes(FolderBrowserDialog1.SelectedPath + "\" + PhotoTypes(ComboBox1.SelectedIndex) + CStr(Math.Floor((NumericUpDown1.Value - (NumericUpDown1.Value Mod 10)) / 10)) + CStr(NumericUpDown1.Value Mod 10) + ".dat", BitConverter.GetBytes(Form1.Header), False)
        My.Computer.FileSystem.WriteAllBytes(FolderBrowserDialog1.SelectedPath + "\" + PhotoTypes(ComboBox1.SelectedIndex) + CStr(Math.Floor((NumericUpDown1.Value - (NumericUpDown1.Value Mod 10)) / 10)) + CStr(NumericUpDown1.Value Mod 10) + ".dat", Form1.EncodeRawFaceData(Form1.LoadedImage), True)
        My.Computer.FileSystem.WriteAllBytes(FolderBrowserDialog1.SelectedPath + "\" + PhotoTypes(ComboBox1.SelectedIndex) + CStr(Math.Floor((NumericUpDown1.Value - (NumericUpDown1.Value Mod 10)) / 10)) + CStr(NumericUpDown1.Value Mod 10) + ".dat", BitConverter.GetBytes(Form1.FileCRC32), True)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            NumericUpDown1.Maximum = 48
        ElseIf ComboBox1.SelectedIndex = 1 Then
            NumericUpDown1.Maximum = 9
        End If
    End Sub
End Class
