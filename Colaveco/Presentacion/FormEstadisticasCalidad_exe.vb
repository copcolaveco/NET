Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormEstadisticasCalidad_exe
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region
    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        ListarTodos()
    End Sub
    
    Private Sub ListarTodos()
        Dim c As New dCalidad_exe
        Dim lista As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        lista = c.listarporfecha(fecdesde, fechasta)

        Dim muestras As Integer = 0
        Dim descartadas As Integer = 0

        Dim valor As Double = 0
        Dim valor1 As Double = 0

        Dim idficha As Long = 0

        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 6
        x1hoja.Cells(1, 3).columnwidth = 6
        x1hoja.Cells(1, 4).columnwidth = 6
        x1hoja.Cells(1, 5).columnwidth = 7
        x1hoja.Cells(1, 6).columnwidth = 7
        x1hoja.Cells(1, 7).columnwidth = 6
        x1hoja.Cells(1, 8).columnwidth = 9
        x1hoja.Cells(1, 9).columnwidth = 6
        x1hoja.Cells(1, 10).columnwidth = 9
        x1hoja.Cells(1, 11).columnwidth = 7

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Estadísticas calidad de leche " & fecdesde & " - " & fechasta
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 2
        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "RB"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "RC"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Grasa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteina"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Lactosa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "ST"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista


                    If c.RC >= 100 And c.RC <= 10000 Or c.RC = 0 Then
                        If c.GRASA >= 2 And c.GRASA <= 5.5 Or c.GRASA = 0 Then
                            If c.PROTEINA >= 2 And c.PROTEINA <= 4 Or c.PROTEINA = 0 Then
                                If c.LACTOSA >= 2 And c.LACTOSA <= 6 Or c.LACTOSA = 0 Then
                                    If c.ST >= 10 And c.ST <= 14 Or c.ST = 0 Then

                                        muestras = muestras + 1

                                        x1hoja.Cells(fila, columna).formula = c.FECHA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1

                                        x1hoja.Cells(fila, columna).formula = c.RB
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1

                                        x1hoja.Cells(fila, columna).formula = c.RC
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1

                                        x1hoja.Cells(fila, columna).formula = c.GRASA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1

                                        x1hoja.Cells(fila, columna).formula = c.PROTEINA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1

                                        x1hoja.Cells(fila, columna).formula = c.LACTOSA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1

                                        x1hoja.Cells(fila, columna).formula = c.ST
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = 1
                                        fila = fila + 1

                                    End If
                                End If
                            End If
                        End If
                    End If
                    valor = 100 / lista.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next
                descartadas = lista.Count - muestras
            End If

           

            'Muestra cantidad de muestras
            x1hoja.Cells(fila, columna).formula = "Muestras"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            columna = columna + 1
            x1hoja.Cells(fila, columna).formula = muestras
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            fila = fila + 1
            columna = 1
            'Muestra cantidad de muestras descartadas
            x1hoja.Cells(fila, columna).formula = "Muestras descartadas"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            columna = columna + 1
            x1hoja.Cells(fila, columna).formula = descartadas
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            fila = fila + 1
            columna = 1

            x1app.Visible = True
            'x1libro.PrintPreview()

            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If
    End Sub

End Class