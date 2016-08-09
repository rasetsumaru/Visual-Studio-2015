<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Controller
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.TextBoxReceiver = New System.Windows.Forms.TextBox()
        Me.ButtonSaveFile = New System.Windows.Forms.Button()
        Me.ButtonOpenFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonRead = New System.Windows.Forms.Button()
        Me.TextBoxRead = New System.Windows.Forms.TextBox()
        Me.ButtonReadAll = New System.Windows.Forms.Button()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.ButtonVersion = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(224, 399)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(75, 23)
        Me.ButtonConnect.TabIndex = 2
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'TextBoxReceiver
        '
        Me.TextBoxReceiver.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxReceiver.Location = New System.Drawing.Point(12, 373)
        Me.TextBoxReceiver.Name = "TextBoxReceiver"
        Me.TextBoxReceiver.Size = New System.Drawing.Size(287, 20)
        Me.TextBoxReceiver.TabIndex = 4
        Me.TextBoxReceiver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonSaveFile
        '
        Me.ButtonSaveFile.Location = New System.Drawing.Point(197, 93)
        Me.ButtonSaveFile.Name = "ButtonSaveFile"
        Me.ButtonSaveFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSaveFile.TabIndex = 6
        Me.ButtonSaveFile.Text = "Save"
        Me.ButtonSaveFile.UseVisualStyleBackColor = True
        '
        'ButtonOpenFile
        '
        Me.ButtonOpenFile.Location = New System.Drawing.Point(197, 122)
        Me.ButtonOpenFile.Name = "ButtonOpenFile"
        Me.ButtonOpenFile.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpenFile.TabIndex = 7
        Me.ButtonOpenFile.Text = "Open"
        Me.ButtonOpenFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 409)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "00:00:00"
        '
        'ButtonRead
        '
        Me.ButtonRead.Location = New System.Drawing.Point(72, 230)
        Me.ButtonRead.Name = "ButtonRead"
        Me.ButtonRead.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRead.TabIndex = 10
        Me.ButtonRead.Text = "Read"
        Me.ButtonRead.UseVisualStyleBackColor = True
        '
        'TextBoxRead
        '
        Me.TextBoxRead.Location = New System.Drawing.Point(15, 232)
        Me.TextBoxRead.Name = "TextBoxRead"
        Me.TextBoxRead.Size = New System.Drawing.Size(51, 20)
        Me.TextBoxRead.TabIndex = 11
        Me.TextBoxRead.Text = "1"
        '
        'ButtonReadAll
        '
        Me.ButtonReadAll.Location = New System.Drawing.Point(72, 259)
        Me.ButtonReadAll.Name = "ButtonReadAll"
        Me.ButtonReadAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonReadAll.TabIndex = 12
        Me.ButtonReadAll.Text = "Read all"
        Me.ButtonReadAll.UseVisualStyleBackColor = True
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Location = New System.Drawing.Point(207, 300)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpen.TabIndex = 13
        Me.ButtonOpen.Text = "Open"
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'ButtonVersion
        '
        Me.ButtonVersion.Location = New System.Drawing.Point(24, 315)
        Me.ButtonVersion.Name = "ButtonVersion"
        Me.ButtonVersion.Size = New System.Drawing.Size(75, 23)
        Me.ButtonVersion.TabIndex = 14
        Me.ButtonVersion.Text = "Version"
        Me.ButtonVersion.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form_Controller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 434)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonVersion)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Controls.Add(Me.ButtonReadAll)
        Me.Controls.Add(Me.TextBoxRead)
        Me.Controls.Add(Me.ButtonRead)
        Me.Controls.Add(Me.ButtonOpenFile)
        Me.Controls.Add(Me.ButtonSaveFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxReceiver)
        Me.Controls.Add(Me.ButtonConnect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Controller"
        Me.Text = "Audio Generator for Speakers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonConnect As System.Windows.Forms.Button
    Friend WithEvents TextBoxReceiver As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSaveFile As System.Windows.Forms.Button
    Friend WithEvents ButtonOpenFile As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonRead As System.Windows.Forms.Button
    Friend WithEvents TextBoxRead As System.Windows.Forms.TextBox
    Friend WithEvents ButtonReadAll As System.Windows.Forms.Button
    Friend WithEvents ButtonOpen As Button
    Friend WithEvents ButtonVersion As Button
    Friend WithEvents Button1 As Button
End Class
