<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Controller
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.TextBoxReceiver = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonSaveFile = New System.Windows.Forms.Button()
        Me.ButtonOpenFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(197, 226)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(75, 23)
        Me.ButtonConnect.TabIndex = 2
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'TextBoxReceiver
        '
        Me.TextBoxReceiver.Location = New System.Drawing.Point(12, 191)
        Me.TextBoxReceiver.Name = "TextBoxReceiver"
        Me.TextBoxReceiver.Size = New System.Drawing.Size(260, 20)
        Me.TextBoxReceiver.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label1"
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
        'Form_Controller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ButtonOpenFile)
        Me.Controls.Add(Me.ButtonSaveFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxReceiver)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Name = "Form_Controller"
        Me.Text = "Audio Generator for Speakers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonConnect As System.Windows.Forms.Button
    Friend WithEvents TextBoxReceiver As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonSaveFile As System.Windows.Forms.Button
    Friend WithEvents ButtonOpenFile As System.Windows.Forms.Button

End Class
