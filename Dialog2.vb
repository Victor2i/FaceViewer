Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class Dialog2
    Dim BackBuffer As New Bitmap(128, 128)
    Dim SelectedImage As Image
    Dim ImageInterpolationMode As Integer
    Dim ImageMatrix As New Matrix()
    Dim IsMouseDown As Boolean = False
    Dim MousePoint As Point

    Private Sub Finish_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinishButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Form1.LoadedImage = BackBuffer
        Me.Close()
    End Sub

    Private Sub UserControlUpdate(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim g As Graphics
        g = Graphics.FromImage(BackBuffer)
        g.InterpolationMode = ImageInterpolationMode
        g.Clear(Color.Black)
        g.Transform = ImageMatrix

        ' Draw image

        Dim ImgOffX As Single = 64 - SelectedImage.Width / 2
        Dim ImgOffY As Single = 64 - SelectedImage.Height / 2
        g.DrawImage(SelectedImage, New Point(ImgOffX, ImgOffY))

        ' End draw

        PictureBox1.BackgroundImage = BackBuffer
        PictureBox1.Invalidate()
    End Sub

    Private Sub PictureBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseWheel
        If e.Delta > 0 Then
            ImageMatrix.Scale(1 + 0.05 * ZoomPwr.Value, 1 + 0.05 * ZoomPwr.Value)
        Else
            ImageMatrix.Scale(1 - 0.05 * ZoomPwr.Value, 1 - 0.05 * ZoomPwr.Value)
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        IsMouseDown = True
        MousePoint = e.Location
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If IsMouseDown = True Then
            ImageMatrix.Translate((e.X - MousePoint.X) * TrPwr.Value, (e.Y - MousePoint.Y) * TrPwr.Value)
            MousePoint = e.Location
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        IsMouseDown = False
    End Sub

    Private Sub SelectImageButton_Click(sender As Object, e As EventArgs) Handles SelectImageButton.Click
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            Dim PathBytes = System.Text.Encoding.Unicode.GetBytes(OpenFileDialog1.FileName)
            Dim InFormat As String = ""
            Dim DotLoc As Integer = PathBytes.Length - 2
            While ChrW(PathBytes(DotLoc)) <> "."
                If DotLoc > 0 Then
                    DotLoc -= 2
                Else
                    Exit While
                End If
            End While
            DotLoc += 2
            While DotLoc < PathBytes.Length
                If PathBytes(DotLoc) >= &H61 And PathBytes(DotLoc) <= &H7A And PathBytes(DotLoc + 1) = &H0 Then
                    InFormat += ChrW(PathBytes(DotLoc) - &H20)
                Else
                    InFormat += ChrW(PathBytes(DotLoc))
                End If
                DotLoc += 2
            End While
            Select Case InFormat
                Case "BMP", "JPG", "JPEG", "PNG"
                    SelectedImage = Image.FromFile(OpenFileDialog1.FileName)
                    Timer1.Enabled = True
                    FinishButton.Enabled = True
                    ImageMatrix.Reset()
                Case Else
                    MsgBox("Sorry... This file format is not supported!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error while saving face as image")
            End Select
        End If
    End Sub

    Private Sub ResetImageTransformButton_Click(sender As Object, e As EventArgs) Handles ResetImageTransformButton.Click
        ImageMatrix.Reset()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            PictureBox1.Image = My.Resources.face_calibrate_guide
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ImageInterpolationMode = ComboBox1.SelectedIndex
    End Sub
End Class
