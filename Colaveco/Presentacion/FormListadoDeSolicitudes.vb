Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormListadoDeSolicitudes
    Private _usuario As dUsuario
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
        DateDesde.Value = Now
        DateHasta.Value = Now
    End Sub
    Private Sub cargarlista()
        Dim sa As New dSolicitudAnalisis
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim lista As New ArrayList
        lista = sa.listarporfecha2(fecdesde, fechasta)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each sa In lista
                    DataGridView1(columna, fila).Value = sa.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sa.FECHAINGRESO
                    columna = columna + 1
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    p = Nothing
                    Dim ti As New dTipoInforme
                    ti.ID = sa.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        DataGridView1(columna, fila).Value = ti.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    ti = Nothing
                    Dim si As New dSubInforme
                    si.ID = sa.IDSUBINFORME
                    si = si.buscar
                    If Not si Is Nothing Then
                        DataGridView1(columna, fila).Value = si.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    si = Nothing
                    DataGridView1(columna, fila).Value = sa.NMUESTRAS
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        Dim sa As New dSolicitudAnalisis
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        lista = sa.listarporfecha2(fecdesde, fechasta)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 1
                Dim columna As Integer = 1

                x1hoja.Cells(1, 1).columnwidth = 8
                x1hoja.Cells(1, 2).columnwidth = 10
                x1hoja.Cells(1, 3).columnwidth = 25
                x1hoja.Cells(1, 4).columnwidth = 15
                x1hoja.Cells(1, 5).columnwidth = 15
                x1hoja.Cells(1, 6).columnwidth = 8

                x1hoja.Cells(fila, columna).formula = "Listado de fichas desde " & desde & " hasta " & hasta
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                fila = fila + 2
                x1hoja.Cells(fila, columna).formula = "Ficha"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Fecha ing."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Cliente"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Tipo informe"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Sub informe"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Muestras"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = 1
                fila = fila + 1
                For Each sa In lista
                    x1hoja.Cells(fila, columna).formula = sa.ID
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    Dim p As New dProductor
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                    p = Nothing
                    Dim ti As New dTipoInforme
                    ti.ID = sa.IDTIPOINFORME
                    ti = ti.buscar
                    If Not ti Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = ti.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                    ti = Nothing
                    Dim si As New dSubInforme
                    si.ID = sa.IDSUBINFORME
                    si = si.buscar
                    If Not si Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = si.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        columna = columna + 1
                    End If
                    si = Nothing
                    x1hoja.Cells(fila, columna).formula = sa.NMUESTRAS
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                Next
            End If
        End If

        x1app.Visible = True
        'x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        cargarlista()
    End Sub
End Class