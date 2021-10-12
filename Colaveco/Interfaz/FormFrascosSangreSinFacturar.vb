Public Class FormFrascosSangreSinFacturar
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
        cargarlista()
    End Sub
    Private Sub cargarlista()
        Dim ped As New dPedidos
        Dim lista As New ArrayList
        lista = ped.listarsinfacturarsangre
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)

                For Each ped In lista
                    DataGridView1(columna, fila).Value = ped.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ped.FECHA
                    columna = columna + 1
                    Dim p As New dCliente
                    p.ID = ped.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    p = Nothing
                    DataGridView1(columna, fila).Value = ped.SANGRE
                    columna = columna + 1
                    Dim pr As New dCliente
                    pr.ID = ped.FACTURA1
                    pr = pr.buscar
                    If Not pr Is Nothing Then
                        DataGridView1(columna, fila).Value = pr.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    pr = Nothing
                    If ped.FACTURADO = 0 Then
                        DataGridView1(columna, fila).Value = "Sin facturar"
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Marcar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim estado As Integer = 0
            id = row.Cells("Id").Value
            Dim p As New dPedidos
            p.marcarFacturado(id, Usuario)
            cargarlista()
        End If
    End Sub
    Private Sub exportar()
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

        '*****************************
        Dim ped As New dPedidos
        Dim lista As New ArrayList
        lista = ped.listarsinfacturarsangre
        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 30
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 30

        x1hoja.Cells(fila, columna).Formula = "LISTADO DE FRASCOS DE SANGRE SIN FACTURAR"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "FECHA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "CLIENTE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FRASCOS"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "FACTURA A:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ped In lista

                    x1hoja.Cells(fila, columna).Formula = ped.FECHA
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    Dim p As New dCliente
                    p.ID = ped.IDPRODUCTOR
                    p = p.buscar
                    x1hoja.Cells(fila, columna).Formula = p.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = ped.SANGRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                    columna = columna + 1
                    Dim pr As New dCliente
                    pr.ID = ped.FACTURA1
                    pr = pr.buscar
                    If Not pr Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = pr.NOMBRE
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                        columna = 1
                        fila = fila + 1
                    End If
                Next
            End If
        End If


        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportar.Click
        exportar()

    End Sub
End Class