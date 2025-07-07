
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
        Usuario = u
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        cargarSectores()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


    End Sub
#End Region

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim lista As New ArrayList
        Dim solicitudAnalisis As New dSolicitudAnalisis
        Dim sector As dSectores = CType(cbxSectores.SelectedItem, dSectores)

        If sector Is Nothing Then
            sector_id = 0
        Else
            sector_id = sector.ID
        End If

        If tbxInforme.Text <> "" Then
            informe = tbxInforme.Text
        End If

        lista = solicitudAnalisis.listar_informes_usuario_pendientes(_usuario.ID, informe, sector_id)
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
            DataGridView2.Columns.Add("DESCRIPCION", "Descripción")
            DataGridView2.Columns.Add("SECTOR", "Sector")
        End If

        ' Opcional: ajusta solo la columna de descripción para que se vea bien
        DataGridView2.Columns("DESCRIPCION").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        If lista IsNot Nothing Then
            For Each item As dAnalisisConDescripcion In lista
                DataGridView2.Rows.Add(item.ANALISIS, item.DESCRIPCION, item.NOMBRE_SECTOR)
            Next
        End If
    End Sub

    Public Sub ExportarReporteExcel(usuarioId As Integer, idInforme As String)
        Dim excelApp As New Excel.Application
        Dim workbook As Excel.Workbook = excelApp.Workbooks.Add()
        Dim worksheet As Excel.Worksheet = workbook.Sheets(1)
        worksheet.Name = "Informe por Usuario"

        ' Obtener sector seleccionado
        Dim sector As dSectores = CType(cbxSectores.SelectedItem, dSectores)
        Dim sector_id As Integer = If(sector Is Nothing, 0, sector.ID)

        ' Obtener nombre del usuario
        Dim nombreUsuario As String = ""
        Dim usuario As New dUsuario
        usuario.ID = usuarioId
        usuario = usuario.buscar() ' Método que busca y devuelve el usuario completo
        If usuario IsNot Nothing Then
            nombreUsuario = usuario.NOMBRE
        End If

        ' Título con nombre del usuario
        worksheet.Cells(1, 1) = "Reporte de análisis pendientes - Usuario: " & nombreUsuario
        Dim tituloRange As Excel.Range = worksheet.Range("A1", "D1")
        tituloRange.Merge()
        tituloRange.Font.Bold = True
        tituloRange.Font.Size = 12

        Dim row As Integer = 3

        ' Encabezados
        worksheet.Cells(row, 1) = "FICHA"
        worksheet.Cells(row, 2) = "FECHA INGRESO"
        worksheet.Cells(row, 3) = "TIPO INFORME"
        worksheet.Cells(row, 4) = "CANTIDAD MUESTRAS"
        worksheet.Range("A3:D3").Font.Bold = True
        row += 1

        ' Obtener solicitudes pendientes
        Dim solicitudAnalisis As New dSolicitudAnalisis
        Dim listaSolicitudes As ArrayList = solicitudAnalisis.listar_informes_usuario_pendientes(usuarioId, idInforme, sector_id)

        If listaSolicitudes IsNot Nothing Then
            For Each solicitud As dInformeAnalisis In listaSolicitudes
                worksheet.Cells(row, 1) = solicitud.FICHA
                worksheet.Cells(row, 2) = solicitud.FECHAINGRESO
                worksheet.Cells(row, 3) = solicitud.NOMBRETIPOINFORME
                worksheet.Cells(row, 4) = solicitud.NMUESTRAS
                row += 1

                ' Encabezado de análisis
                worksheet.Cells(row, 2) = "Análisis"
                worksheet.Cells(row, 3) = "Descripción"
                worksheet.Cells(row, 4) = "Sector"
                worksheet.Range("B" & row & ":D" & row).Font.Bold = True
                row += 1

                ' Análisis asociados
                Dim datos As New pSolicitudAnalisis
                Dim listaAnalisis As ArrayList = datos.listar_analisis_con_descripcion(usuarioId, solicitud.FICHA)

                If listaAnalisis IsNot Nothing Then
                    For Each analisis As dAnalisisConDescripcion In listaAnalisis
                        worksheet.Cells(row, 2) = analisis.ANALISIS
                        worksheet.Cells(row, 3) = analisis.DESCRIPCION
                        worksheet.Cells(row, 4) = analisis.NOMBRE_SECTOR
                        row += 1
                    Next
                End If

                row += 1 ' Línea vacía
            Next
        End If

        ' Autoajustar columnas
        worksheet.Columns.AutoFit()

        ' Mostrar Excel
        excelApp.Visible = True
    End Sub


    Private Sub btn_excel_Click(sender As Object, e As EventArgs) Handles btn_excel.Click
        ExportarReporteExcel(Usuario.ID, tbxInforme.Text)
    End Sub


    Public Sub cargarSectores()
        Dim s As New dSectores
        Dim lista As New ArrayList
        lista = s.listar_por_usuario(Usuario.ID)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    cbxSectores.Items.Add(s)
                Next
            End If
        End If
    End Sub

    Private Sub cbxSectores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSectores.SelectedIndexChanged

    End Sub
End Class