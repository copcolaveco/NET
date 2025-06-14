
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class FormInformesPendientesUsuario

    Private _sesion As New dSesion
    Private _usuario As dUsuario
    Dim informe As String = ""
    Dim fecdesde As String = ""
    Dim fechasta As String = ""
    Dim sector_id As Integer = 0

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Property Sesion() As dSesion
        Get
            Return _sesion
        End Get
        Set(ByVal value As dSesion)
            _sesion = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        cargarSectores()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub
#End Region

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim lista As New ArrayList
        Dim solicitudAnalisis As New dSolicitudAnalisis
        Dim parmDesde As Date = Desde.Value.ToString("yyyy-MM-dd")
        Dim parmHasta As Date = Hasta.Value.ToString("yyyy-MM-dd")
        fecdesde = Format(parmDesde, "yyyy-MM-dd")
        fechasta = Format(parmHasta, "yyyy-MM-dd")
        Dim sector As dSectores = CType(cbxSectores.SelectedItem, dSectores)

        If sector Is Nothing Then
            sector_id = 0
        Else
            sector_id = sector.ID
        End If

        If tbxInforme.Text <> "" Then
            informe = tbxInforme.Text
        End If

        lista = solicitudAnalisis.listar_informes_usuario_filtro(_usuario.ID, fecdesde, fechasta, informe, sector_id)
        DataGridView1.Rows.Clear()

        With DataGridView1
            .Rows.Clear()
            If .Columns.Count = 0 Then
                .Columns.Add("FICHA", "Ficha")
                .Columns.Add("FECHAINGRESO", "Fecha Ingreso")
                .Columns.Add("TIPO", "Tipo Informe")
                .Columns.Add("NMUESTRAS", "N° Muestras")
            End If
        End With


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                If lista IsNot Nothing Then
                    For Each item As dInformeAnalisis In lista
                        DataGridView1.Rows.Add(item.FICHA, item.FECHAINGRESO, item.NOMBRETIPOINFORME, item.NMUESTRAS)
                    Next
                Else
                    MessageBox.Show("No se encontraron resultados.")
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            ' Obtenemos la ficha de la fila seleccionada
            Dim solicitudIdSeleccionada As Long = CLng(DataGridView1.Rows(e.RowIndex).Cells("FICHA").Value)

            ' Llamamos a la función que carga la segunda grilla
            Dim lista As New ArrayList
            Dim solicitudAnalisis As New dSolicitudAnalisis

            CargarAnalisisConDescripcion(_usuario.ID, solicitudIdSeleccionada)
        End If
    End Sub

    Private Sub CargarAnalisisConDescripcion(usuarioId As Integer, solicitudId As Long)
        Dim datos As New pSolicitudAnalisis
        Dim lista As ArrayList = datos.listar_analisis_con_descripcion(usuarioId, solicitudId)

        DataGridView2.Rows.Clear()

        If DataGridView2.Columns.Count = 0 Then
            DataGridView2.Columns.Add("ANALISIS", "Análisis")
            DataGridView2.Columns.Add("ID_SOLICITUD", "Solicitud ID")
            DataGridView2.Columns.Add("DESCRIPCION", "Descripción")
        End If

        ' Asegurarse de que los datos ya estén cargados si vas a usar AllCells.
        DataGridView2.Columns("DESCRIPCION").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        If lista IsNot Nothing Then
            For Each item As dAnalisisConDescripcion In lista
                DataGridView2.Rows.Add(item.ANALISIS, item.ID_SOLICITUD, item.DESCRIPCION)
            Next
        End If
    End Sub

    Public Sub ExportarReporteExcel(usuarioId As Integer, desde As Date, hasta As Date, idInforme As String)
        Dim excelApp As New Excel.Application
        Dim workbook As Excel.Workbook = excelApp.Workbooks.Add()
        Dim worksheet As Excel.Worksheet = workbook.Sheets(1)
        worksheet.Name = "Informe por Usuario"
        Dim sector As dSectores = CType(cbxSectores.SelectedItem, dSectores)
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        If sector Is Nothing Then
            sector_id = 0
        Else
            sector_id = sector.ID
        End If

        ' Fila 1: Título del reporte
        Dim titulo As String = "Reporte de análisis para ser realizados"
        worksheet.Cells(1, 1) = titulo

        ' Aplicar formato en negrita
        Dim tituloRange As Excel.Range = worksheet.Range("A1", "D1")
        tituloRange.Merge()
        tituloRange.Font.Bold = True
        tituloRange.Font.Size = 12

        ' Fila 2 vacía
        Dim row As Integer = 3

        ' Encabezados de solicitudes
        worksheet.Cells(row, 1) = "FICHA"
        worksheet.Cells(row, 2) = "FECHA INGRESO"
        worksheet.Cells(row, 3) = "TIPO INFORME"
        worksheet.Cells(row, 4) = "CANTIDAD MUESTRAS"
        worksheet.Range("A3:D3").Font.Bold = True
        row += 1

        ' Cargar datos
        Dim solicitudAnalisis As New dSolicitudAnalisis
        Dim listaSolicitudes As ArrayList = solicitudAnalisis.listar_informes_usuario_filtro(usuarioId, fecdesde, fechasta, idInforme, sector_id)

        If listaSolicitudes IsNot Nothing Then
            For Each solicitud As dInformeAnalisis In listaSolicitudes
                worksheet.Cells(row, 1) = solicitud.FICHA
                worksheet.Cells(row, 2) = solicitud.FECHAINGRESO
                worksheet.Cells(row, 3) = solicitud.NOMBRETIPOINFORME
                worksheet.Cells(row, 4) = solicitud.NMUESTRAS
                row += 1

                ' Encabezados de análisis
                worksheet.Cells(row, 2) = "Análisis"
                worksheet.Cells(row, 3) = "ID Solicitud"
                worksheet.Cells(row, 4) = "Descripción"
                worksheet.Range("B" & row & ":D" & row).Font.Bold = True
                row += 1

                ' Buscar los análisis relacionados
                Dim datos As New pSolicitudAnalisis
                Dim listaAnalisis As ArrayList = datos.listar_analisis_con_descripcion(usuarioId, solicitud.FICHA)

                If listaAnalisis IsNot Nothing Then
                    For Each analisis As dAnalisisConDescripcion In listaAnalisis
                        worksheet.Cells(row, 2) = analisis.ANALISIS
                        worksheet.Cells(row, 3) = analisis.ID_SOLICITUD
                        worksheet.Cells(row, 4) = analisis.DESCRIPCION
                        row += 1
                    Next
                End If

                row += 1 ' Línea vacía entre solicitudes
            Next
        End If

        ' Autoajustar columnas
        worksheet.Columns.AutoFit()

        ' Mostrar Excel al usuario
        excelApp.Visible = True

    End Sub

    Private Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        Dim parmDesde As Date = Desde.Value.ToString("yyyy-MM-dd")
        Dim parmHasta As Date = Hasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(parmDesde, "yyyy-MM-dd")
        fechasta = Format(parmHasta, "yyyy-MM-dd")
        ExportarReporteExcel(_usuario.ID, fecdesde, fechasta, tbxInforme.Text)
    End Sub

    Public Sub cargarSectores()
        Dim s As New dSectores
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    cbxSectores.Items.Add(s)
                Next
            End If
        End If
    End Sub

End Class