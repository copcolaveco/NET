Imports Microsoft.Office.Interop.Excel

Public Class FormNotificacionesReloj
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarNotificaciones()
        cargarUsuarios()
    End Sub
#End Region
    Private Sub cargarNotificaciones()
        DataGridNotificaciones.Rows.Clear()
        Dim n As New dNotificaciones_reloj
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = n.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridNotificaciones.Rows.Clear()
                DataGridNotificaciones.Rows.Add(lista.Count)
                For Each n In lista
                    DataGridNotificaciones(columna, fila).Value = n.ID
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.FECHA
                    columna = columna + 1
                    Dim u As New dUsuario
                    u.ID = n.IDUSUARIO
                    u = u.buscar
                    DataGridNotificaciones(columna, fila).Value = u.NOMBRE
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.FECHAEVENTO
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.DETALLE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If cbxSinFiltros.Checked = True Then
            cargarNotificaciones()
        Else
            Listar()
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If cbxSinFiltros.Checked = True Then
            exportarTodos()
        Else
            exportarConFiltros()
        End If
    End Sub

    Private Sub Listar()
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0

        lista = getNotificacionesConFiltros()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridNotificaciones.Rows.Clear()
                DataGridNotificaciones.Rows.Add(lista.Count)
                For Each n In lista
                    DataGridNotificaciones(columna, fila).Value = n.ID
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.FECHA
                    columna = columna + 1
                    Dim u As New dUsuario
                    u.ID = n.IDUSUARIO
                    u = u.buscar
                    DataGridNotificaciones(columna, fila).Value = u.NOMBRE
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.FECHAEVENTO
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.DETALLE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub

    Public Function getNotificacionesConFiltros() As ArrayList
        Dim fecha_desde As String
        Dim fecha_hasta As String
        Dim des As Date = desde.Value.ToString("yyyy-MM-dd")
        Dim has As Date = hasta.Value.ToString("yyyy-MM-dd")

        If Not desde Is Nothing Then
            fecha_desde = Format(des, "yyyy-MM-dd")
        End If

        If Not hasta Is Nothing Then
            fecha_hasta = Format(has, "yyyy-MM-dd")
        End If

        Dim usuario As dUsuario
        Dim id_usuario As Integer = 0

        If Not cbxUsuario.Text Is Nothing And cbxUsuario.Text <> "" Then
            usuario = cbxUsuario.SelectedItem
            id_usuario = usuario.ID
        End If

        DataGridNotificaciones.Rows.Clear()
        Dim n As New dNotificaciones_reloj
        Dim lista As New ArrayList

        Try
            lista = n.listarPorFiltros(fecha_desde, fecha_hasta, id_usuario)
        Catch ex As Exception
            MsgBox(ex.Data)
        End Try

        Return lista
    End Function

    Private Sub cargarUsuarios()
        Dim m As New dUsuario
        Dim lista As New ArrayList

        cbxUsuario.Items.Clear()
        lista = m.listar()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    cbxUsuario.Items.Add(m)
                Next
                Dim n As New dUsuario
                cbxUsuario.Items.Add(n)
            End If
        End If
    End Sub

    Public Function exportarTodos()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim n As New dNotificaciones_reloj
        Dim lista As New ArrayList
        lista = n.listar

        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Usuario"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha evento"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Detalle"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        columna = 1

        If Not lista Is Nothing Then
            For Each n In lista
                If Not n.FECHA Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = n.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.IDUSUARIO > 0 Then
                    Dim usu As New dUsuario
                    usu.ID = n.IDUSUARIO
                    usu = usu.buscar()
                    x1hoja.Cells(fila, columna).formula = usu.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If Not n.FECHAEVENTO Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = n.FECHAEVENTO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.DETALLE <> "" Then
                    x1hoja.Cells(fila, columna).formula = n.DETALLE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If
            Next
        End If
        
        x1app.Visible = True
        'x1libro.PrintPreview()
        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Function

    Public Function exportarConFiltros()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim lista As New ArrayList
        lista = getNotificacionesConFiltros()

        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Usuario"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha evento"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Detalle"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        columna = 1

        Dim n As dNotificaciones_reloj
        If Not lista Is Nothing Then
            For Each n In lista

                If Not n.FECHA Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = n.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.IDUSUARIO > 0 Then
                    Dim usu As New dUsuario
                    usu.ID = n.IDUSUARIO
                    usu = usu.buscar()
                    x1hoja.Cells(fila, columna).formula = usu.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If Not n.FECHAEVENTO Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = n.FECHAEVENTO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.DETALLE <> "" Then
                    x1hoja.Cells(fila, columna).formula = n.DETALLE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If
            Next
        End If
        
        x1app.Visible = True
        'x1libro.PrintPreview()
        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Function
End Class