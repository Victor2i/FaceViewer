<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog2
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog2))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FinishButton = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrPwr = New System.Windows.Forms.NumericUpDown()
        Me.ZoomPwr = New System.Windows.Forms.NumericUpDown()
        Me.ResetImageTransformButton = New System.Windows.Forms.Button()
        Me.SelectImageButton = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrPwr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZoomPwr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(258, 258)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Default", "Low", "High", "Bilinear", "Bicubic", "Nearest Neighbor", "High Quality Bilinear", "High Quality Bicubic"})
        Me.ComboBox1.Location = New System.Drawing.Point(150, 408)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(120, 23)
        Me.ComboBox1.TabIndex = 33
        Me.ComboBox1.Text = "Default"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label3.Location = New System.Drawing.Point(12, 408)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 23)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Interpolation"
        '
        'FinishButton
        '
        Me.FinishButton.Enabled = False
        Me.FinishButton.Location = New System.Drawing.Point(195, 437)
        Me.FinishButton.Name = "FinishButton"
        Me.FinishButton.Size = New System.Drawing.Size(75, 23)
        Me.FinishButton.TabIndex = 31
        Me.FinishButton.Text = "Finish"
        Me.FinishButton.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 440)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(161, 19)
        Me.CheckBox1.TabIndex = 30
        Me.CheckBox1.Text = "Show face calibrate guide"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label2.Location = New System.Drawing.Point(12, 379)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 23)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Translate Power"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(12, 350)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 23)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Zoom Power"
        '
        'TrPwr
        '
        Me.TrPwr.DecimalPlaces = 2
        Me.TrPwr.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.TrPwr.Location = New System.Drawing.Point(150, 379)
        Me.TrPwr.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.TrPwr.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.TrPwr.Name = "TrPwr"
        Me.TrPwr.Size = New System.Drawing.Size(120, 23)
        Me.TrPwr.TabIndex = 27
        Me.TrPwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TrPwr.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ZoomPwr
        '
        Me.ZoomPwr.DecimalPlaces = 2
        Me.ZoomPwr.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.ZoomPwr.Location = New System.Drawing.Point(150, 350)
        Me.ZoomPwr.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.ZoomPwr.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.ZoomPwr.Name = "ZoomPwr"
        Me.ZoomPwr.Size = New System.Drawing.Size(120, 23)
        Me.ZoomPwr.TabIndex = 26
        Me.ZoomPwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ZoomPwr.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ResetImageTransformButton
        '
        Me.ResetImageTransformButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ResetImageTransformButton.Location = New System.Drawing.Point(12, 313)
        Me.ResetImageTransformButton.Name = "ResetImageTransformButton"
        Me.ResetImageTransformButton.Size = New System.Drawing.Size(258, 31)
        Me.ResetImageTransformButton.TabIndex = 25
        Me.ResetImageTransformButton.Text = "Reset image transform"
        Me.ResetImageTransformButton.UseVisualStyleBackColor = True
        '
        'SelectImageButton
        '
        Me.SelectImageButton.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SelectImageButton.Location = New System.Drawing.Point(12, 276)
        Me.SelectImageButton.Name = "SelectImageButton"
        Me.SelectImageButton.Size = New System.Drawing.Size(258, 31)
        Me.SelectImageButton.TabIndex = 24
        Me.SelectImageButton.Text = "Select image..."
        Me.SelectImageButton.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Bitmap image|*.bmp|JPEG image|*.jpg;*.jpeg|PNG image|*.png"
        '
        'Dialog2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 472)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FinishButton)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TrPwr)
        Me.Controls.Add(Me.ZoomPwr)
        Me.Controls.Add(Me.ResetImageTransformButton)
        Me.Controls.Add(Me.SelectImageButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import image"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrPwr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZoomPwr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents FinishButton As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TrPwr As NumericUpDown
    Friend WithEvents ZoomPwr As NumericUpDown
    Friend WithEvents ResetImageTransformButton As Button
    Friend WithEvents SelectImageButton As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
