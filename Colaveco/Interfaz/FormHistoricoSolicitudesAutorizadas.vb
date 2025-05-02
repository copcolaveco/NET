Imports Microsoft.Office.Interop

Public Class FormHistoricoSolicitudesAutorizadas

    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        Usuario = u
    End Sub
#End Region
    Private Sub FormHistoricoSolicitudesAutorizadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        listar()
    End Sub

    Private Sub listar()
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim desde2 As Date = desde.Value.Date
        Dim hasta2 As Date = hasta.Value.Date

        Dim fecdesde As String = desde2.ToString("yyyy-MM-dd")
        Dim fechasta As String = hasta2.ToString("yyyy-MM-dd")

        Dim solicitudId As Long = 0
        If Not String.IsNullOrEmpty(ficha.Text) Then
            Long.TryParse(ficha.Text, solicitudId)
        End If

        Dim sa As New dSolicitud_Autorizacion
        lista = sa.listarPorFiltros(fecdesde, fechasta, solicitudId)

        DataGridView1.Rows.Clear()

        If lista IsNot Nothing Then
            DataGridView1.ColumnCount = 4
            DataGridView1.Rows.Add(lista.Count)

            For Each item As dSolicitud_Autorizacion In lista
                ' Columna 1: SolicitudAnalisisId
                DataGridView1(columna, fila).Value = item.SOLICITUDANALISIS_ID
                columna += 1

                ' Columna 2: Nombre del UsuarioAutorizador
                Dim usuario As New dUsuario
                usuario.ID = item.USUARIO_AUTORIZA_ID
                usuario = usuario.buscar()
                If usuario IsNot Nothing Then
                    DataGridView1(columna, fila).Value = usuario.NOMBRE
                Else
                    DataGridView1(columna, fila).Value = "Desconocido"
                End If
                columna += 1

                ' Columna 3: Fecha
                DataGridView1(2, fila).Value = item.FECHA
                columna += 1

                ' Columna 4: Motivo (observaciones)
                DataGridView1(columna, fila).Value = item.OBSERVACIONES
                columna = 0
                fila += 1
            Next
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExportarAExcel()
    End Sub

    Private Sub ExportarAExcel()
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No hay datos para exportar", MsgBoxStyle.Information, "Atención")
            Exit Sub
        End If

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook = xlApp.Workbooks.Add
        Dim xlWS As Excel.Worksheet = xlWB.Sheets(1)

        xlApp.Visible = True
        xlWS.Name = "Historial Autorizaciones"

        ' Escribir encabezados
        For col As Integer = 0 To DataGridView1.Columns.Count - 1
            xlWS.Cells(1, col + 1).Value = DataGridView1.Columns(col).Name
        Next

        ' Escribir datos
        For row As Integer = 0 To DataGridView1.Rows.Count - 1
            For col As Integer = 0 To DataGridView1.Columns.Count - 1
                xlWS.Cells(row + 2, col + 1).Value = DataGridView1.Rows(row).Cells(col).Value
            Next
        Next

        ' Ajustar tamaño de columnas
        xlWS.Columns.AutoFit()

        MsgBox("Exportación a Excel finalizada", MsgBoxStyle.Information, "Excel")
    End Sub

End Class