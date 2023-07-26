Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormExportar
    Private _anio As Integer
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        calcularano()
    End Sub
#End Region
    Private Sub calcularano()
        Dim hoy As Date = Now
        Dim ano As Integer = 0
        ano = hoy.Year
        _anio = hoy.Year
        NumericAno.Value = ano
    End Sub
    Private Sub exportar()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        Dim a As New dActividades
        Dim lista As New ArrayList
        Dim fecha As Integer
        fecha = NumericAno.Value
        lista = a.listarxano(fecha)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 1
                Dim columna As Integer = 1

                x1hoja.Cells(1, 1).columnwidth = 20
                x1hoja.Cells(1, 2).columnwidth = 29
                x1hoja.Cells(1, 3).columnwidth = 34
                x1hoja.Cells(1, 4).columnwidth = 60
                x1hoja.Cells(1, 5).columnwidth = 40
                x1hoja.Cells(1, 6).columnwidth = 10
                x1hoja.Cells(1, 7).columnwidth = 11
                x1hoja.Cells(1, 8).columnwidth = 16
                x1hoja.Cells(1, 9).columnwidth = 14
                x1hoja.Cells(1, 10).columnwidth = 10



                x1hoja.Cells(fila, columna).formula = "Dimensión"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Objetivo general"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Objetivo específico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Actividad"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Indicador"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Meta"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Aceptable"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Responsable"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Plazo"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Año"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                columna = 1
                fila = fila + 1
               
                For Each a In lista
                    Dim d As New dDimension
                    Dim og As New dObjGral
                    Dim oe As New dObjEspecifico
                    d.ID = a.IDDIMENSION
                    d = d.buscar
                    og.IDDIMENSION = d.ID
                    og = og.buscarxiddimension
                    oe.ID = a.IDOBJESPECIFICO
                    oe = oe.buscar

                    If Not d Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = d.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    If Not og Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = og.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If

                    If Not oe Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = oe.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        columna = columna + 1
                    End If
                    
                    x1hoja.Cells(fila, columna).formula = a.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1
                    
                    x1hoja.Cells(fila, columna).formula = a.INDICADOR
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    Dim i As New dIndicadores
                    i.IDACTIVIDAD = a.ID
                    i = i.buscarxactividad
                    If Not i Is Nothing Then
                        If a.ACEPTABLE = i.INDICADOR Then
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 255, 0)
                        ElseIf a.ACEPTABLE > i.INDICADOR Then
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.color = RGB(255, 255, 255)
                        End If
                        If a.META <= i.INDICADOR Then
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(0, 128, 0)
                            x1hoja.Cells(fila, columna).Font.color = RGB(255, 255, 255)
                        End If
                    End If
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = a.META
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = a.ACEPTABLE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = a.RESPONSABLE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = a.PLAZO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True
                    columna = columna + 1

                    x1hoja.Cells(fila, columna).formula = a.ANO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).WrapText = True

                    columna = 1
                    fila = fila + 1

                    d = Nothing
                    og = Nothing
                    oe = Nothing
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

    Private Sub ButtonExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportar.Click
        exportar()
    End Sub
End Class