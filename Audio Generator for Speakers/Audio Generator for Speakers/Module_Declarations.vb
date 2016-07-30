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
    Public UsartRxControl As Integer
    Public UsartRxTimeout As Integer

    Public FileDirectory As String
    Public FileName As String
    Public FileSystem As Integer

    Public RecipeIndex As Integer
    Public RecipeControl As Boolean

    Public RecipeList(500) As String


    Public DirLogsError As String = "C:\Users\raset\Desktop\error.txt"

#End Region

End Module
