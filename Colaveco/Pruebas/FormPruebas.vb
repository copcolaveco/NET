Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.Net
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports Newtonsoft.Json
Imports System.Web.Mail
Imports System.Net.Mail

Public Class FormPruebas
    Private carpeta As Long
    Dim listacontroles As New ArrayList
    Private factura_origen As String

#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub

#End Region
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim c As New dCompras
        Dim lista As New ArrayList
        lista = c.listarsinautorizar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    Dim lc As New dLineaCompra
                    lc.IDCOMPRA = c.ID
                    lc = lc.buscarxidcompra
                    If Not lc Is Nothing Then
                    Else
                        c.eliminar(Usuario)
                    End If
                    lc = Nothing
                Next
            End If
        End If
    End Sub
    Private Sub ButtonActualizarIdNet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonActualizarIdNet.Click
        Dim pw As New dProductorWeb_com
        Dim idproductorweb As Long = 0
        Dim lista As New ArrayList
        lista = pw.listarsinidnet
        If Not lista Is Nothing Then
            For Each pw In lista
                Dim uweb As String = pw.USUARIO
                idproductorweb = pw.ID
                Dim p As New dCliente
                p.USUARIO_WEB = uweb
                p = p.buscarPorUsuarioWeb
                If Not p Is Nothing Then
                    Dim pw2 As New dProductorWeb_com
                    pw2.ID = idproductorweb
                    pw2.IDNET = p.ID
                    pw2.actualizaridnet(Usuario)
                    pw2 = Nothing
                End If
                p = Nothing
            Next
        End If
        pw = Nothing
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim p As New dCliente
        Dim lista As New ArrayList
        lista = p.listar
        For Each p In lista
            Dim pw As New dProductorWeb_com
            pw.USUARIO = p.USUARIO_WEB
            pw.NOMBRE = p.NOMBRE
            pw.modificarnombre(Usuario)
            pw = Nothing
        Next
        p = Nothing
        MsgBox("Unificación finalizada")
    End Sub

    Private Sub prueba_crear()
        Dim usuario As New Dictionary(Of String, dUsuarioGestor)
        Dim ug As New dUsuarioGestor
        ug.email = "pepo2@test.com"
        ug.password = "12345678"
        ug.password_confirmation = "12345678"
        ug.usuario_web = "pepo2"
        ug.nombre = "pepo2"
        ug.dicose = "55555555"
        ug.razon_social = "el pepo srl"
        ug.rut = "12345678910"
        usuario.Add("user", ug)
        Dim parameters As String = JsonConvert.SerializeObject(usuario, Formatting.None)
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/users", "POST", parameters, status)
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
    Private Sub prueba_leer()
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = GetResponse("http://colaveco-gestor.herokuapp.com/users", "GET", status)
        Dim responseString As String
        If response IsNot Nothing Then
            responseString = System.Text.Encoding.UTF8.GetString(response)
        Else
            responseString = "NULL"
        End If
        Console.WriteLine("Response Code: " & status)
        Console.WriteLine("Response String: " & responseString)
        Dim usuarios As New List(Of dUsuarioGestor)
        usuarios = JsonConvert.DeserializeObject(Of List(Of dUsuarioGestor))(responseString)
    End Sub
    Public Function GetResponse(ByVal url As String, ByVal metodo As String, ByRef statusCode As HttpStatusCode) As Byte()
        Dim responseFromServer As Byte() = Nothing
        Dim dataStream As Stream = Nothing
        Try
            Dim request As WebRequest = WebRequest.Create(url)
            request.Timeout = 120000
            request.Method = metodo
            request.ContentType = "application/json"
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

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim f As Long = 123443
        Dim tipoinforme As Integer = 0
        Dim idficha As Long = 0
        Dim cli As Long = 0
        Dim usuweb As String = ""
        Dim idusuweb As Long = 0
        lista = s.listarultimos6meses(f)
        If Not lista Is Nothing Then
            For Each s In lista
                tipoinforme = s.IDTIPOINFORME
                idficha = s.ID
                Dim c As New dCliente
                c.ID = s.IDPRODUCTOR
                c = c.buscar
                cli = c.ID
                usuweb = c.USUARIO_WEB
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = usuweb
                pw_com = pw_com.buscar
                idusuweb = pw_com.ID

                '*** CREA RESULTADO EN GESTOR NUEVO *******************************************************************************************
                Dim resultado As New Dictionary(Of String, dResultado)
                Dim carpeta As String = ""
                If tipoinforme = 1 Then
                    carpeta = "control_lechero"
                ElseIf tipoinforme = 3 Then
                    carpeta = "agua"
                ElseIf tipoinforme = 4 Then
                    carpeta = "antibiograma"
                ElseIf tipoinforme = 6 Then
                    carpeta = "parasitologia"
                ElseIf tipoinforme = 7 Then
                    carpeta = "productos_subproductos"
                ElseIf tipoinforme = 8 Then
                    carpeta = "serologia"
                ElseIf tipoinforme = 9 Then
                    carpeta = "patologia"
                ElseIf tipoinforme = 10 Then
                    carpeta = "calidad_de_leche"
                ElseIf tipoinforme = 11 Then
                    carpeta = "ambiental"
                ElseIf tipoinforme = 13 Then
                    carpeta = "agro_nutricion"
                ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
                    carpeta = "agro_suelos"
                ElseIf tipoinforme = 15 Then
                    carpeta = "brucelosis_leche"
                End If
                Dim rg As New dResultado
                Dim fechaemi2 As String
                Dim fecha_emision2 As Date = s.FECHAENVIO
                fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")
                'fechaemi2 = s.FECHAENVIO
                rg.ficha = idficha
                rg.comentarios = ""
                rg.idnet_usuario = cli
                rg.abonado = True
                rg.fecha_creado = fechaemi2
                rg.fecha_emision = fechaemi2
                rg.path_excel = "/home/colaveco/public_html/gestor/data_file/" & idusuweb & "/" & carpeta & "/" & idficha & ".xls"
                rg.path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idusuweb & "/" & carpeta & "/" & idficha & ".pdf"
                rg.path_csv = "/home/colaveco/public_html/gestor/data_file/" & idusuweb & "/" & carpeta & "/" & idficha & ".txt"
                rg.id_estado = 3
                rg.id_libro = idficha
                rg.idnet_tipo_informe = tipoinforme
                resultado.Add("resultado", rg)
                Dim parameters As String = JsonConvert.SerializeObject(resultado, Formatting.None)
                Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
                Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/resultados", "POST", parameters, status)
            Next
        End If
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        Dim c As New dCliente
        Dim lista As New ArrayList
        lista = c.listarxid
        If Not lista Is Nothing Then
            For Each c In lista
                Dim usuariogestor As New Dictionary(Of String, dUsuarioGestor)
                Dim ug As New dUsuarioGestor
                ug.email = c.EMAIL
                'ug.password = c.USUARIO_WEB
                'ug.password_confirmation = c.USUARIO_WEB
                ug.usuario_web = c.USUARIO_WEB
                ug.nombre = c.NOMBRE
                ug.direccion = c.DIRECCION
                ug.dicose = c.DICOSE
                ug.razon_social = c.FAC_RSOCIAL
                ug.cedula = c.FAC_CEDULA
                ug.rut = c.FAC_RUT
                ug.idnet = c.ID
                ug.direccion_frasco = c.ENVIO
                ug.agencia_frasco = c.IDAGENCIA
                ug.notificacion_frasco_1 = c.NOT_EMAIL_FRASCOS1
                ug.notificacion_frasco_2 = c.NOT_EMAIL_FRASCOS2
                ug.notificacion_solicitud_1 = c.NOT_EMAIL_MUESTRAS1
                ug.notificacion_solicitud_2 = c.NOT_EMAIL_MUESTRAS2
                ug.notificacion_resultado_1 = c.NOT_EMAIL_ANALISIS1
                ug.notificacion_resultado_2 = c.NOT_EMAIL_ANALISIS2
                ug.notificacion_avisos_1 = c.NOT_EMAIL_GENERAL1
                ug.notificacion_avisos_2 = c.NOT_EMAIL_GENERAL2
                ug.tecnico_celular_1 = c.CELULAR
                ug.tecnico_celular_2 = c.CELULAR2
                ug.tecnico_celular_nombre_1 = c.NOMBRE_CELULAR1
                ug.tecnico_celular_nombre_2 = c.NOMBRE_CELULAR2
                ug.tecnico_telefono_1 = c.TELEFONO1
                ug.tecnico_telefono_2 = c.TELEFONO2
                ug.tecnico_telefono_nombre_1 = c.NOMBRE_TELEFONO1
                ug.tecnico_telefono_nombre_2 = c.NOMBRE_TELEFONO2
                ug.tecnico_email_1 = c.EMAIL1
                ug.tecnico_email_2 = c.EMAIL2
                ug.tecnico_email_nombre_1 = c.NOMBRE_EMAIL1
                ug.tecnico_email_nombre_2 = c.NOMBRE_EMAIL2
                ug.fac_direccion = c.FAC_DIRECCION
                ug.fac_localidad = c.FAC_LOCALIDAD
                ug.fac_departamento = c.FAC_DEPARTAMENTO
                ug.fac_email_envio = c.FAC_EMAIL
                ug.cobranza_celular_1 = c.COB_CELULAR1
                ug.cobranza_celular_2 = c.COB_CELULAR2
                ug.cobranza_celular_nombre_1 = c.COB_NOMBRE_CELULAR1
                ug.cobranza_celular_nombre_2 = c.COB_NOMBRE_CELULAR2
                ug.cobranza_telefono_1 = c.FAC_TELEFONOS
                ug.cobranza_telefono_2 = c.COB_TELEFONO2
                ug.cobranza_telefono_nombre_1 = c.COB_NOMBRE_TELEFONO1
                ug.cobranza_telefono_nombre_2 = c.COB_NOMBRE_TELEFONO2
                ug.cobranza_email_1 = c.COB_EMAIL1
                ug.cobranza_email_2 = c.COB_EMAIL2
                ug.cobranza_email_nombre_1 = c.COB_NOMBRE_EMAIL1
                ug.cobranza_email_nombre_2 = c.COB_NOMBRE_EMAIL2
                ug.id_tecnico_1 = c.TECNICO1
                ug.id_tecnico_2 = c.TECNICO2
                usuariogestor.Add("user", ug)
                Dim parameters As String = JsonConvert.SerializeObject(usuariogestor, Formatting.None)
                Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
                Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/users", "POST", parameters, status)
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c As New dCajas
        Dim listacajas As New ArrayList
        listacajas = c.listar
        For Each c In listacajas
            Dim ec As New dEnvioCajas
            Dim listaenvios As New ArrayList
            listaenvios = ec.listarxcaja_asc(c.CODIGO)
            If Not listaenvios Is Nothing Then

            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim v As New FormRCConvenio
        v.Show()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim v As New FormClientesPorEmpresa
        v.Show()
    End Sub
End Class