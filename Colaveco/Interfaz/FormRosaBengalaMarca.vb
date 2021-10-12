Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Imports Newtonsoft.Json
Public Class FormRosaBengalaMarca
    Private _usuario As dUsuario
    Private _idficha As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        limpiar()
        cargarlista()
    End Sub
    Private Sub limpiar()
        DateFecha.Value = Now
    End Sub
    Private Sub cargarlista()
        Dim r As New dRosaBengalaDescarte
        Dim lista As New ArrayList
        lista = r.listarsinmarcar

        DataGridView1.Rows.Clear()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each r In lista
                    DataGridView1(columna, fila).Value = r.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = r.FECHAM
                    columna = 0
                    fila = fila + 1

                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Marcar" Then
            Dim fechamarca As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fecham As String
            fecham = Format(fechamarca, "yyyy-MM-dd")
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim ficha As Long = 0
            Dim r As New dRosaBengalaDescarte
            Dim s As New dSolicitudAnalisis
            id = row.Cells("Id").Value
            ficha = row.Cells("Ficha").Value
            _idficha = ficha
            r.ID = id
            r.FECHAM = fecham
            r.marcar(Usuario)
            s.ID = ficha
            s.FECHAENVIO = fecham
            s.marcar3(Usuario)
            modificarregistro()
            cargarlista()
        End If
    End Sub
    Private Sub modificarregistro()
        Dim resultado As New Dictionary(Of String, dResultado)
        Dim rg As New dResultado
        Dim fechaemi2 As String
        Dim fecha_emision2 As Date = Now
        fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")
        Dim sa As New dSolicitudAnalisis
        Dim idnet As Long = 0
        sa.ID = _idficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            idnet = sa.IDPRODUCTOR
        End If
        rg.ficha = _idficha
        rg.comentarios = "Sitio web de SINAVELE"
        rg.idnet_usuario = idnet
        rg.abonado = 0
        rg.fecha_creado = fechaemi2
        rg.fecha_emision = fechaemi2
        rg.path_excel = ""
        rg.path_pdf = ""
        rg.path_csv = ""
        rg.id_estado = 3
        rg.id_libro = _idficha
        rg.idnet_tipo_informe = 8
        resultado.Add("resultado", rg)
        Dim parameters As String = JsonConvert.SerializeObject(resultado, Formatting.None)
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/resultados", "POST", parameters, status)
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
End Class