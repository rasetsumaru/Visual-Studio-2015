#Region "Imports"

Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

#End Region

Module Module_Declarations

#Region "Usart communication"

    Public WithEvents _SerialPort As New SerialPort
    Public WithEvents _SerialList As New ListBox

    Public UsartRx As String
    Public UsartTx As String
    Public UsartConnected As Boolean
    Public UsartPorts As Integer
    Public usartrxcontrol As Integer

    Public filedirectory As String
    Public filename As String
    Public filesystem As Integer

    Public recipeindex As Integer
    Public recipecontroll As Boolean

    Public recipelist(500) As String

#End Region

End Module
