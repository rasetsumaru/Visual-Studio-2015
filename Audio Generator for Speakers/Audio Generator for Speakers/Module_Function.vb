#Region "Imports"

Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

#End Region

Module Module_Function


#Region "Declarações"

    'Arquivo *.ini
    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

    'Processos
    Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long

#End Region


#Region "Funções e procedimentos"

    'Ler Arquino *.ini
    Public Function LeArquivoINI(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String

        Const MAX_LENGTH As Integer = 500
        Dim string_builder As New StringBuilder(MAX_LENGTH)

        GetPrivateProfileString(section_name, key_name, default_value, string_builder, MAX_LENGTH, file_name)

        Return string_builder.ToString()

    End Function

    'Nome do Arquivo *.ini
    Public Function nomeArquivoINI(ByVal Diretorio As String) As String

        Return Diretorio

    End Function

#End Region

#Region "Usart communication"

    Public Sub _SerialPortGetNames()

        Try
            _SerialList.Items.Clear()

            For Each sp As String In My.Computer.Ports.SerialPortNames
                _SerialList.Items.Add(sp)
            Next

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

    Public Sub SerialRead()

        Dim SerialData As String
        Dim SerialChecksum As Integer

        Try

            Form_Controller._TimerUsartRx.Stop()
            Form_Controller.TextBoxReceiver.Text = UsartRx
            UsartRxTimeout = 0

            If Strings.Left(UsartRx, 1) = "@" And Strings.Right(UsartRx, 1) = "#" Then

                UsartRx = UsartRx.Substring(1, UsartRx.Length - 2)

                SerialData = UsartRx.Substring(0, UsartRx.IndexOf("%"))
                SerialChecksum = Strings.Right(UsartRx, 3)

                Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(SerialData)

                Dim checksum As Long
                Dim datacalculations As Long

                For i As Byte = 0 To SerialData.Length - 1
                    datacalculations = array(i) * (i + 1)
                    checksum += datacalculations
                Next

                checksum = checksum Mod 99

                If checksum = Convert.ToInt16(SerialChecksum) Then
                    UsartRxControl = 0
                    SerialDecoder(SerialData)
                Else
                    If UsartRxControl < 3 Then
                        Form_Controller._TimerUsartTx.Start()
                        UsartRxControl = UsartRxControl + 1
                    Else
                        Form_Controller._TimerDisconnected.Start()
                        Connected()
                    End If

                End If


            End If

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

    Public Sub SerialDecoder(Decoder As String)

        Dim Header As String = Decoder.Substring(0, 2)
        Dim Control As String = Decoder.Substring(2, 3)
        Dim Data As String = Decoder.Substring(5, 64)

        Try

            If Header.Equals("RC") Then

                If Control.Equals("000") Then
                    If Data.Substring(0, 2) = "01" Then
                        UsartConnected = True
                        UsartRx = ""
                        With Form_Controller.ButtonConnect
                            .Text = "Disconnect"
                            .Enabled = True
                        End With
                        Form_Controller.ButtonOpenFile.Enabled = True
                        Form_Controller.ButtonSaveFile.Enabled = True
                        MsgBox("USB connected")
                        GoTo Fim
                    End If

                    If Data.Substring(0, 2) = "00" Then
                        UsartConnected = False
                        RecipeControl = False

                        UsartRx = ""

                        _SerialPort.Close()
                        _SerialPort.Dispose()

                        With Form_Controller.ButtonConnect
                            .Text = "Connect"
                            .Enabled = True
                        End With

                        Form_Controller.ButtonOpenFile.Enabled = False
                        Form_Controller.ButtonSaveFile.Enabled = False
                        Form_Controller._TimerDisconnected.Stop()
                        Form_Controller._TimerConnected.Stop()
                        Form_Controller._TimerUsartTx.Stop()
                        Form_Controller._TimerUsartRx.Stop()
                        MsgBox("USB disconnected")
                        GoTo Fim
                    End If
                End If

            End If

            If Header.Equals("RR") Then

                RecordRecipe()

                If RecipeControl = True And RecipeIndex < 500 Then
                    RecipeIndex = RecipeIndex + 1
                    ReadAllRecipes()
                Else
                    RecipeControl = False
                End If

            End If

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

Fim:

    End Sub

    Public Sub Connected()

        Try

            UsartRxControl = 0
            UsartRxTimeout = 0

            If UsartConnected = False Then
                UsartPorts = 0
                _SerialPortGetNames()
                Form_Controller._TimerConnected.Start()
                Form_Controller.ButtonConnect.Enabled = False

            Else

                UsartTx = "WC00000"
                Form_Controller._TimerUsartTx.Start()
                Form_Controller.ButtonConnect.Enabled = False

            End If

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

    Public Sub Disconnected()

        Try

            Form_Controller._TimerConnected.Stop()
            Form_Controller._TimerUsartTx.Stop()
            Form_Controller._TimerUsartRx.Stop()

            UsartConnected = False
            RecipeControl = False

            UsartRx = ""

            Form_Controller.ButtonOpenFile.Enabled = False
            Form_Controller.ButtonSaveFile.Enabled = False

            With Form_Controller.ButtonConnect
                .Text = "Connect"
                .Enabled = True
            End With

            If _SerialPort.IsOpen Then
                _SerialPort.Close()
                _SerialPort.Dispose()
            End If

            _SerialList.Items.Clear()

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

    Public Sub ReadAllRecipes()

        Dim pointer As String

        pointer = RecipeIndex.ToString

        For i As Integer = 0 To 2 - pointer.Length
            pointer = "0" + pointer
        Next

        UsartTx = "RR" + pointer

        Form_Controller._SerialPort_DataSend(UsartTx)

    End Sub

#Region "Arquivos *.txt"

    ' Gravar
    Public Sub RecordRecipe()

        Try

            Dim DirRecipes As String = "D:\Projetos\Projeto Solitec, Audio Generator for Speakers\Versão 3\H 1.13 F 1.59\"

            Dim nome_arquivo_ini As String = nomeArquivoINI(DirRecipes) & "Recipes" & ".ini"

            WritePrivateProfileString("Recipes", Strings.Left(UsartRx, 5), Strings.Right(UsartRx, UsartRx.Length - 5), nome_arquivo_ini)

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region


End Module
