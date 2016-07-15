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

#Region "Usart communication"

    Public Sub _SerialPortGetNames()

        Try
            _SerialList.Items.Clear()

            'For Each sp As String In My.Computer.Ports.SerialPortNames
            '_SerialList.Items.Add(sp)
            'Next

            _SerialList.Items.Add("COM6")

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

    Public Sub SerialRead()

        Dim SerialData As String
        Dim SerialChecksum As Integer

        Try

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
                    SerialDecoder(SerialData)
                End If


            End If

            'Form_Controller.TextBoxReceiver.Text = UsartRx

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

    End Sub

    Public Sub SerialDecoder(Decoder As String)

        Dim Header As String = Decoder.Substring(0, 2)
        Dim Control As String = Decoder.Substring(2, 2)
        Dim Data As String = Decoder.Substring(4, 64)

        'Dim ControllerSytring As String
        'Dim DataWrite As String
        'Dim DataEqualizer As String

        Try

            If Header.Equals("RC") Then

                If Control.Equals("00") Then
                    If Data.Substring(0, 2) = "01" Then
                        UsartConnected = True
                        UsartRx = ""
                        With Form_Controller.ButtonConnect
                            .Text = "Disconnect"
                            .Enabled = True
                        End With
                        Form_Controller.ButtonOpenFile.Enabled = True
                        Form_Controller.ButtonSaveFile.Enabled = True
                        MsgBox("Conectado")
                        GoTo Fim
                    End If

                    If Data.Substring(0, 2) = "00" Then
                        UsartConnected = False
                        UsartRx = ""

                        If _SerialPort.IsOpen Then
                            _SerialPort.Close()
                        End If

                        With Form_Controller.ButtonConnect
                            .Text = "Connect"
                            .Enabled = True
                        End With
                        Form_Controller.ButtonOpenFile.Enabled = False
                        Form_Controller.ButtonSaveFile.Enabled = False
                        MsgBox("Desconectado")
                        GoTo Fim
                    End If
                End If


            End If

        Catch ex As Exception

            'WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, nomeArquivoINI(DirLogsError))

        End Try

Fim:

    End Sub

#End Region

End Module
