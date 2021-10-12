Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormListadoCajasVerdesSinDevolver
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
        Dim ec As New dEnvioCajas
        Dim lista As New ArrayList
        lista = ec.listarverdessindevolver
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                Dim p As New dProductor
                For Each ec In lista
                    DataGridView1(columna, fila).Value = ec.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = ec.IDCAJA
                    columna = columna + 1
                    p.ID = ec.IDPRODUCTOR
                    p = p.buscar
                    If Not p Is Nothing Then
                        DataGridView1(columna, fila).Value = p.NOMBRE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = ec.FECHAENVIO
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

        Dim ec As New dEnvioCajas
        Dim lista As New ArrayList
        lista = ec.listarverdessindevolver

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 1
                Dim columna As Integer = 1

                x1hoja.Cells(1, 1).columnwidth = 8
                x1hoja.Cells(1, 2).columnwidth = 25
                x1hoja.Cells(1, 3).columnwidth = 25
                x1hoja.Cells(1, 4).columnwidth = 15

                x1hoja.Cells(fila, columna).formula = "Listado de cajas verdes sin devolver"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                fila = fila + 2
                x1hoja.Cells(fila, columna).formula = "Caja"
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
                x1hoja.Cells(fila, columna).formula = "Teléfono"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Envío"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                columna = 1
                fila = fila + 1
                Dim p As New dProductor
                For Each ec In lista

                    x1hoja.Cells(fila, columna).formula = ec.IDCAJA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    p.ID = ec.IDPRODUCTOR
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
                    If Not p Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = p.TELEFONO
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
                    x1hoja.Cells(fila, columna).formula = ec.FECHAENVIO
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
        x1libro.PrintPreview()

        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class