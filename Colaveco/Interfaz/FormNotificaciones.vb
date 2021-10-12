Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net

Imports Newtonsoft.Json
Public Class FormNotificaciones
#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        limpiar()
    End Sub
#End Region
    Private Sub ButtonBuscarProductor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProductor.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
        End If
    End Sub
    Private Sub enviar()
        Dim fechaactual As Date = DateFecha.Value
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        Dim notificacion As New Dictionary(Of String, dNotificaciones)
        Dim nt As New dNotificaciones
        Dim _tipo As String = ""
        Dim _mensaje As String = TextMensaje.Text.Trim
        Dim nuevoid As Long = CType(TextIdProductor.Text, Long)
        _tipo = "aviso"
        nt.fecha = _fecha
        nt.tipo = _tipo
        nt.mensaje = _mensaje
        nt.idnet_usuario = nuevoid
        notificacion.Add("notification", nt)
        Dim parameters As String = JsonConvert.SerializeObject(notificacion, Formatting.None)
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/notifications", "POST", parameters, status)
    End Sub
    Public Function PostResponse(ByVal url As String, ByVal metodo As String, ByVal content As String, ByRef statusCode As HttpStatusCode) As Byte()
        Dim responseFromServer As Byte() = Nothing
        Dim dataStream As Stream = Nothing
        Try
            Dim request As WebRequest = WebRequest.Create(url)
            request.Timeout = 120000
            request.Method = metodo
            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(content)
            request.ContentType = "application/json"
            request.ContentLength = byteArray.Length
            dataStream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()
            Dim ms As New MemoryStream()
            Dim thisRead As Integer = 0
            Dim buff As Byte() = New Byte(1023) {}
            Do
                thisRead = dataStream.Read(buff, 0, buff.Length)
                If thisRead = 0 Then
                    Exit Do
                End If
                ms.Write(buff, 0, thisRead)
            Loop While True
            responseFromServer = ms.ToArray()
            dataStream.Close()
            response.Close()
            statusCode = HttpStatusCode.OK
        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                dataStream = ex.Response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim resp As String = reader.ReadToEnd()
                statusCode = DirectCast(ex.Response, HttpWebResponse).StatusCode
            Else
                Dim resp As String = ""
                statusCode = HttpStatusCode.ExpectationFailed
            End If
        Catch ex As Exception
            statusCode = HttpStatusCode.ExpectationFailed
        End Try
        Return responseFromServer
    End Function

    Private Sub ButtonEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviar.Click
        enviar()
        MsgBox("Mensaje enviado!")
        limpiar()
    End Sub
    Private Sub limpiar()
        DateFecha.Value = Now
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        TextMensaje.Text = ""
    End Sub
End Class