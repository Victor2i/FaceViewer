Imports System.Threading

Public Class Form1
    Public Shared Header As UInt32
    Public Shared LoadedImage As Bitmap
    Public Shared ImageLoaded As Boolean = False
    Public Shared FileCRC32 As UInt32

    Public Class Crc32
        Shared table As UInteger()

        Shared Sub New()
            Dim polynomial As UInteger = &HEDB88320UI
            table = New UInteger(255) {}
            Dim temp As UInteger
            For i As UInteger = 0 To table.Length - 1
                temp = i
                For j As Integer = 8 To 1 Step -1
                    If (temp And 1) = 1 Then
                        temp = CUInt((temp >> 1) Xor polynomial)
                    Else
                        temp >>= 1
                    End If
                Next
                table(i) = temp
            Next
        End Sub

        Public Shared Function ComputeCRC32(data As Byte(), datastart As UInt16, dataend As UInt16) As UInteger
            Dim crc32 As UInteger = &HFFFFFFFFUI
            For i As Integer = datastart To dataend
                Dim index As Byte = CByte((crc32 And &HFF) Xor data(i))
                crc32 = CUInt((crc32 >> 8) Xor table(index))
            Next
            Return Not crc32
        End Function
    End Class

    Public Shared ReadOnly ByteOrderLUT = {
        0, 1, 8, 9, 2, 3, 10, 11,
        16, 17, 24, 25, 18, 19, 26, 27,
        4, 5, 12, 13, 6, 7, 14, 15,
        20, 21, 28, 29, 22, 23, 30, 31,
        32, 33, 40, 41, 34, 35, 42, 43,
        48, 49, 56, 57, 50, 51, 58, 59,
        36, 37, 44, 45, 38, 39, 46, 47,
        52, 53, 60, 61, 54, 55, 62, 63
    }

    Public Shared Function DecodeRawFaceData(InData)
        Dim OutImage As New Bitmap(128, 128)

        Dim InOff As UInt16 = 0

        For tY As Int16 = 0 To 15
            For tX As Int16 = 0 To 15
                For pX As Int16 = 0 To 63
                    Dim X = ByteOrderLUT(pX) Mod 8
                    Dim Y = (ByteOrderLUT(pX) - X) / 8

                    Dim PixelData As UInt16 = 0
                    PixelData += InData(InOff)
                    PixelData += InData(InOff + 1) * 256

                    Dim B = (PixelData And &H1F) * 8
                    Dim G = ((PixelData >> 5) And &H3F) * 4
                    Dim R = ((PixelData >> 11) And &H1F) * 8

                    OutImage.SetPixel(tX * 8 + X, tY * 8 + Y, Color.FromArgb(255, R, G, B))

                    InOff += 2
                Next
            Next
        Next

        Return OutImage
    End Function

    Public Shared Function EncodeRawFaceData(InImage As Bitmap)
        Dim Output As Byte()
        ReDim Output(&H7FFF)

        Dim OutOff As UInt16 = 0

        InImage = FixFacePixelData(InImage)

        For tY As Int16 = 0 To 15
            For tX As Int16 = 0 To 15
                For pX As Int16 = 0 To 63
                    Dim X = ByteOrderLUT(pX) Mod 8
                    Dim Y = (ByteOrderLUT(pX) - X) / 8

                    Dim PixelData As UInt16 = 0

                    PixelData += Math.Floor(InImage.GetPixel(tX * 8 + X, tY * 8 + Y).B / 8)
                    PixelData += InImage.GetPixel(tX * 8 + X, tY * 8 + Y).G * 8
                    PixelData += InImage.GetPixel(tX * 8 + X, tY * 8 + Y).R * 256

                    Output(OutOff) = PixelData And &HFF
                    Output(OutOff + 1) = (PixelData And &HFF00) / 256

                    OutOff += 2
                Next
            Next
        Next

        Return Output
    End Function

    Public Shared Function FixFacePixelData(InImage As Bitmap) ' Only works for faces you imported from your computer
        For Y As Int16 = 0 To 127
            For X As Int16 = 0 To 127
                Dim R = InImage.GetPixel(X, Y).R
                Dim G = InImage.GetPixel(X, Y).G
                Dim B = InImage.GetPixel(X, Y).B

                If InImage.GetPixel(X, Y).R Mod 8 > 0 Then
                    R -= R Mod 8
                    InImage.SetPixel(X, Y, Color.FromArgb(255, R, G, B))
                End If

                If InImage.GetPixel(X, Y).G Mod 4 > 0 Then
                    G -= G Mod 4
                    InImage.SetPixel(X, Y, Color.FromArgb(255, R, G, B))
                End If

                If InImage.GetPixel(X, Y).B Mod 8 > 0 Then
                    B -= B Mod 8
                    InImage.SetPixel(X, Y, Color.FromArgb(255, R, G, B))
                End If
            Next
        Next
        Return InImage
    End Function

    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem.Click
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
                Case "DAT"
                    Dim RawFile = My.Computer.FileSystem.ReadAllBytes(OpenFileDialog1.FileName)
                    If RawFile.Length = &H8008 Then
                        Dim RawPixels(&H7FFF) As Byte
                        Array.ConstrainedCopy(RawFile, &H4, RawPixels, &H0, &H8000)
                        PadValueLabel.Text = "0x" & Hex(BitConverter.ToUInt32(RawFile, &H0))
                        CRCValueLabel.Text = "0x" & Hex(BitConverter.ToUInt32(RawFile, &H8004))
                        FileCRC32 = Crc32.ComputeCRC32(RawFile, &H0, &H8003)
                        If FileCRC32 = BitConverter.ToUInt32(RawFile, &H8004) Then
                            CRCValidationLabel.Text = "(valid)"
                            CRCValidationLabel.ForeColor = Color.FromArgb(255, 0, 255, 0)
                        Else
                            CRCValidationLabel.Text = "(invalid)"
                            CRCValidationLabel.ForeColor = Color.FromArgb(255, 255, 0, 0)
                        End If
                        Dim DecodedImage = DecodeRawFaceData(RawPixels)
                        LoadedImage = DecodedImage
                        PictureBox1.Image = DecodedImage
                        ImageLoaded = True
                    Else
                        MsgBox("This file is invalid!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error while opening face file")
                    End If
                Case Else
                    MsgBox("This file format is invalid!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error while opening face file")
            End Select
        End If
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        If Dialog2.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = LoadedImage
            Dim RawImage As Byte() = EncodeRawFaceData(LoadedImage)
            Dim CRCData(&H8003) As Byte
            Array.ConstrainedCopy(RawImage, &H0, CRCData, &H4, &H8000)
            Header = 0
            FileCRC32 = Crc32.ComputeCRC32(CRCData, 0, CRCData.Length - 1)
            CRCValidationLabel.Text = "(valid)"
            CRCValidationLabel.ForeColor = Color.FromArgb(255, 0, 255, 0)
            PadValueLabel.Text = "0x0"
            CRCValueLabel.Text = "0x" & Hex(FileCRC32)
            ImageLoaded = True
        End If
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If ImageLoaded Then
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim PathBytes = System.Text.Encoding.Unicode.GetBytes(SaveFileDialog1.FileName)
                Dim OutFormat As String = ""
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
                        OutFormat += ChrW(PathBytes(DotLoc) - &H20)
                    Else
                        OutFormat += ChrW(PathBytes(DotLoc))
                    End If
                    DotLoc += 2
                End While
                Select Case OutFormat
                    Case "BMP"
                        LoadedImage.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Bmp)
                    Case "JPG", "JPEG"
                        LoadedImage.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Jpeg)
                    Case "PNG"
                        LoadedImage.Save(SaveFileDialog1.FileName, Imaging.ImageFormat.Png)
                    Case Else
                        MsgBox("Sorry... This file format is not supported!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error while saving face as image")
                End Select
            End If
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If ImageLoaded Then
            Dialog1.ShowDialog()
        End If
    End Sub

    Private Sub RecomputeCRCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecomputeCRCToolStripMenuItem.Click
        If ImageLoaded Then
            Dim RawImage As Byte() = EncodeRawFaceData(LoadedImage)
            Dim CRCData(&H8003) As Byte
            Array.ConstrainedCopy(RawImage, &H0, CRCData, &H4, &H8000)
            Header = 0
            FileCRC32 = Crc32.ComputeCRC32(CRCData, 0, CRCData.Length - 1)
            CRCValidationLabel.Text = "(valid)"
            CRCValidationLabel.ForeColor = Color.FromArgb(255, 0, 255, 0)
            PadValueLabel.Text = "0x0"
            CRCValueLabel.Text = "0x" & Hex(FileCRC32)
        End If
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Close()
    End Sub
End Class
