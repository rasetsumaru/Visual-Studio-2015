﻿#Region "Imports"

Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

#End Region

Public Class Form_Controller

#Region "Statements"

    Public WithEvents _SerialPort As New SerialPort
    Public WithEvents _TimerNow As New System.Windows.Forms.Timer
    Public WithEvents _TimerConnected As New System.Windows.Forms.Timer
    Public WithEvents _TimerUsartRx As New System.Windows.Forms.Timer

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Usart communication"

    Public Sub _SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles _SerialPort.DataReceived

        Dim i As Byte
        On Error Resume Next

        UsartRx = _SerialPort.ReadLine

        If UsartRx.Length > 0 Then

            UsartRx = UsartRx.Replace(vbCr, "").Replace(vbLf, "")
            Invoke(New Threading.ThreadStart(AddressOf SerialRead))

        End If

    End Sub

    Public Sub _SerialPort_Connect(SerialData As String)

        _SerialPort.Write(SerialData + vbLf)

    End Sub

    Public Sub _SerialPort_DataSend(SerialData As String)

        For i As Byte = 0 To 68 - SerialData.Length - 1
            SerialData += " "
        Next

        Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(SerialData)

        Dim checksum As Long
        Dim datacalculations As Long
        Dim checksumstring As String = ""

        For i As Byte = 0 To SerialData.Length - 1
            datacalculations = array(i) * (i + 1)
            checksum += datacalculations
        Next

        checksum = checksum Mod 99

        For i As Byte = 0 To 3 - checksum.ToString.Length - 1
            checksumstring += "0"
        Next

        checksumstring += checksum.ToString
        _SerialPort.Write("@" + SerialData + "%" + checksumstring + "#" + vbLf)

    End Sub

    Public Sub _SerialPortSetup()

        Try

            If _SerialPort.IsOpen Then
                _SerialPort.Close()
            End If

            With _SerialPort
                .PortName = _SerialList.SelectedItem
                .BaudRate = 115200
                .DataBits = 8
                .Parity = Parity.None
                .StopBits = StopBits.One
                .Handshake = Handshake.None
            End With

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

#Region "Form event"

    Public Sub FormController_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            UsartConnected = False
            filesystem = 0

            With _TimerNow
                .Enabled = True
                .Interval = 100
            End With

            With _TimerConnected
                .Enabled = True
                .Interval = 1000
                .Stop()
            End With

            With _TimerUsartRx
                .Enabled = True
                .Interval = 1500
                .Stop()
            End With

            Me.ButtonOpenFile.Enabled = False
            Me.ButtonSaveFile.Enabled = False

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try
    End Sub

#End Region

#Region "Functions"

    Public Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click

        Try

            If UsartConnected = False Then
                UsartPorts = -1
                _SerialPortGetNames()
                _TimerConnected.Start()

                Me.ButtonConnect.Enabled = False

            Else

                UsartTx = "WC0000"
                _TimerUsartRx.Start()
                Me.ButtonConnect.Enabled = False

            End If

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

#Region "Threading"

    Public Sub _TimerNow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerNow.Tick

        Try

            Label1.Text = Format(Now, "HH:mm:ss")

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

    Public Sub _TimerConnected_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerConnected.Tick

        Try

            _TimerConnected.Stop()

            If UsartConnected = False Then

                UsartPorts += 1

                If _SerialList.Items.Count > 0 And UsartPorts <= _SerialList.Items.Count - 1 Then

                    Try
                        _SerialList.SelectedIndex = UsartPorts
                        _SerialPortSetup()
                        _SerialPort.Open()
                        _TimerUsartRx.Start()

                    Catch ex As Exception

                        MessageBox.Show(ex.Message)

                    End Try

                    UsartTx = "WC0001"

                Else

                    MsgBox("Equipamento não encontrado")
                    Me.ButtonConnect.Enabled = True

                End If

            End If

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try
    End Sub

    Public Sub _TimerUsartRx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerUsartRx.Tick

        Try

            _TimerUsartRx.Stop()
            If UsartConnected = False Then
                _SerialPort_Connect(UsartTx)
                _TimerConnected.Start()
            Else
                _SerialPort_DataSend(UsartTx)
            End If

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try
    End Sub

#End Region

    Private Sub ButtonSaveFile_Click(sender As Object, e As EventArgs) Handles ButtonSaveFile.Click

        ' Displays a SaveFileDialog so the user can save the Image
        ' assigned to Button2.
        Dim _saveFileDialog As New SaveFileDialog()
        _saveFileDialog.Filter = "SGS 300 recipes|*.sgsr|SGS 300 settings|*.sgss"
        _saveFileDialog.Title = "Save an SGS 300 file"
        _saveFileDialog.FilterIndex = 1
        _saveFileDialog.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If _saveFileDialog.FileName <> "" Then
            ' Saves the Image via a FileStream created by the OpenFile method.
            Dim fs As System.IO.FileStream = CType _
               (_saveFileDialog.OpenFile(), System.IO.FileStream)
            ' Saves the Image in the appropriate ImageFormat based upon the
            ' file type selected in the dialog box.
            ' NOTE that the FilterIndex property is one-based.

            recipesdirectory = _saveFileDialog.FileName
            filesystem = _saveFileDialog.FilterIndex

            fs.Close()
        End If

    End Sub

    Private Sub ButtonOpenFile_Click(sender As Object, e As EventArgs) Handles ButtonOpenFile.Click

        Dim myStream As Stream = Nothing
        Dim _openFileDialog As New OpenFileDialog()

        '_openFileDialog.InitialDirectory = "c:\"
        _openFileDialog.Filter = "SGS 300 recipes|*.sgsr|SGS 300 settings|*.sgss"
        _openFileDialog.Title = "Open an SGS 300 file"
        _openFileDialog.FilterIndex = 1
        _openFileDialog.RestoreDirectory = True

        If _openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = _openFileDialog.OpenFile()
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here.

                    MsgBox("Aberto")
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub
End Class