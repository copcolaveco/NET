
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Imports Newtonsoft.Json

Public Class FormReporteEstadoInforme

    Private _sesion As New dSesion

    Private Sub FormReporteEstadoInforme_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Property Sesion() As dSesion
        Get
            Return _sesion
        End Get
        Set(ByVal value As dSesion)
            _sesion = value
        End Set
    End Property

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

    End Sub

    Private Sub Button1_Click_5(sender As Object, e As EventArgs) Handles Button1.Click
        CargarInformesGestor()
    End Sub

    Private Sub CargarInformesGestor()
        Dim gestor As New dPreinformes
        Dim desde As String = dtpDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As String = dtpHasta.Value.ToString("yyyy-MM-dd")
        Dim ficha As String = -1

        If dtpDesde.Value.Date > dtpHasta.Value.Date Then
            MsgBox("La fecha 'desde' no puede ser mayor que la fecha 'hasta'", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim estadoSeleccionado As String = ""

        If cbEstadoGestor.SelectedItem IsNot Nothing Then
            estadoSeleccionado = cbEstadoGestor.SelectedItem.ToString()
        Else
            Exit Sub
        End If

        ficha = tbxFicha.Text

        Dim lista As ArrayList = gestor.listar_informes_gestor(desde, hasta, estadoSeleccionado, ficha)
        DataGridViewGestor.Rows.Clear()

        DataGridViewGestor.Columns.Clear()
        DataGridViewGestor.Rows.Clear()

        ' Definir columnas
        DataGridViewGestor.Columns.Add("FICHA", "Ficha")
        DataGridViewGestor.Columns.Add("FECHAINGRESO", "Fecha Ingreso")
        DataGridViewGestor.Columns.Add("FECHAENVIO", "Fecha Envio")
        DataGridViewGestor.Columns.Add("CLIENTE", "Cliente")
        DataGridViewGestor.Columns.Add("TIPOINFORME", "Tipo de Informe")
        DataGridViewGestor.Columns.Add("ESTADO", "Estado")

        If lista IsNot Nothing AndAlso lista.Count > 0 Then
            For Each i As dInformeGestor In lista
                DataGridViewGestor.Rows.Add(i.FICHA, i.FECHAINGRESO, i.FECHAENVIO, i.CLIENTE, i.TIPOINFORME, i.ESTADO)
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridViewGestor.Rows.Clear()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarDataGridViewAExcel(DataGridViewGestor)
    End Sub

    Public Sub ExportarDataGridViewAExcel(ByVal dgv As DataGridView)
        Try
            Dim xlApp As New Excel.Application
            Dim xlLibro As Excel.Workbook = xlApp.Workbooks.Add()
            Dim xlHoja As Excel.Worksheet = CType(xlLibro.Sheets(1), Excel.Worksheet)

            ' Exportar encabezados
            For col As Integer = 0 To dgv.Columns.Count - 1
                xlHoja.Cells(1, col + 1).Value = dgv.Columns(col).HeaderText
                xlHoja.Cells(1, col + 1).Font.Bold = True
            Next

            ' Exportar contenido
            For fila As Integer = 0 To dgv.Rows.Count - 1
                For col As Integer = 0 To dgv.Columns.Count - 1
                    xlHoja.Cells(fila + 2, col + 1).Value = dgv.Rows(fila).Cells(col).Value
                Next
            Next

            xlApp.Visible = True ' Mostrar Excel al usuario
        Catch ex As Exception
            MessageBox.Show("Error al exportar a Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridViewGestor_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewGestor.CellContentClick

    End Sub
End Class