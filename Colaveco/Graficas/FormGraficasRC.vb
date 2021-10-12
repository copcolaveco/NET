Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class FormGraficasRC
    Private id_sol As Long = 0
    Public Sub New(ByVal idsol As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        id_sol = idsol
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If idsol <> 0 Then
            graficar()
            MsgBox("Finalizado!!!")
        End If
    End Sub
    Private Sub ButtonGraficar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGraficar.Click
        graficar()
        MsgBox("Finalizado!!!")
    End Sub
    Private Sub graficar()
        Dim sa As New dSolicitudAnalisis
        If TextFicha.Text <> "" Then
            id_sol = TextFicha.Text.Trim
        End If
        Dim ficha As Long = id_sol
        Dim idproductor As Long = 0
        Dim ficha1 As Long = 0
        Dim ficha2 As Long = 0
        Dim ficha3 As Long = 0
        Dim fecha1 As String = ""
        Dim fecha2 As String = ""
        Dim fecha3 As String = ""
        Dim listafichas As New ArrayList
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            idproductor = sa.IDPRODUCTOR
            ficha1 = ficha
            fecha1 = sa.FECHAINGRESO
        End If
        listafichas = sa.listarporproductorultimas3(idproductor, ficha)
        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim i As Integer = 1
                For Each sa In listafichas
                    If i = 1 Then
                        ficha2 = sa.ID
                        fecha2 = sa.FECHAINGRESO
                    ElseIf i = 2 Then
                        ficha3 = sa.ID
                        fecha3 = sa.FECHAINGRESO
                    End If
                    i = i + 1
                Next
            End If
        End If

        Dim c1 As New dControl
        Dim c2 As New dControl
        Dim c3 As New dControl
        Dim lista1 As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista_caravanas As String = ""
        Dim lista_caravanas2 As String = ""
        Dim lista_caravanas3 As String = ""
        Dim lista_caravanas4 As String = ""
        Dim muestras1 As Integer = 0
        Dim muestras2 As Integer = 0
        Dim muestras3 As Integer = 0
        lista1 = c1.listarxficha(ficha1)
        lista2 = c1.listarxficha(ficha2)
        lista3 = c1.listarxficha(ficha3)
        If Not lista1 Is Nothing Then
            muestras1 = lista1.Count
        End If
        If Not lista2 Is Nothing Then
            muestras2 = lista2.Count
        End If
        If Not lista3 Is Nothing Then
            muestras3 = lista3.Count
        End If
        Dim menor200_1 As Integer = 0
        Dim menor700_1 As Integer = 0
        Dim mayor700_1 As Integer = 0
        Dim menor200_2 As Integer = 0
        Dim menor700_2 As Integer = 0
        Dim mayor700_2 As Integer = 0
        Dim menor200_3 As Integer = 0
        Dim menor700_3 As Integer = 0
        Dim mayor700_3 As Integer = 0
        If muestras1 > 0 And muestras2 > 0 And muestras3 > 0 Then
            If Not lista1 Is Nothing Then
                For Each c1 In lista1
                    If c1.RC < 200 And c1.RC > 0 Then
                        menor200_1 = menor200_1 + 1
                    ElseIf c1.RC >= 200 And c1.RC < 700 Then
                        menor700_1 = menor700_1 + 1
                    ElseIf c1.RC >= 700 Then
                        mayor700_1 = mayor700_1 + 1
                        lista_caravanas = lista_caravanas & c1.MUESTRA & " - "
                    End If
                Next
            End If
            If Not lista2 Is Nothing Then
                For Each c2 In lista2
                    If c2.RC < 200 And c2.RC > 0 Then
                        menor200_2 = menor200_2 + 1
                    ElseIf c2.RC >= 200 And c2.RC < 700 Then
                        menor700_2 = menor700_2 + 1
                    ElseIf c2.RC >= 700 Then
                        mayor700_2 = mayor700_2 + 1
                        lista_caravanas2 = lista_caravanas2 & c2.MUESTRA & " - "
                    End If
                Next
            End If
            If Not lista3 Is Nothing Then
                For Each c3 In lista3
                    If c3.RC < 200 And c3.RC > 0 Then
                        menor200_3 = menor200_3 + 1
                    ElseIf c3.RC >= 200 And c3.RC < 700 Then
                        menor700_3 = menor700_3 + 1
                    ElseIf c3.RC >= 700 Then
                        mayor700_3 = mayor700_3 + 1
                        lista_caravanas3 = lista_caravanas3 & c3.MUESTRA & " - "
                    End If
                Next
            End If
            'Buscar nuevas infecciones*************************************************
            Dim nuevas_inf As Integer = 0
            Dim porc_ninf As Integer = 0
            Dim m As String = ""
            If Not lista1 Is Nothing Then
                For Each c1 In lista1
                    If c1.RC > 200 Then
                        m = c1.MUESTRA
                        If Not lista2 Is Nothing Then
                            For Each c2 In lista2
                                If m = c2.MUESTRA Then
                                    If c2.RC < 200 Then
                                        nuevas_inf = nuevas_inf + 1
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
            If nuevas_inf > 0 Then
                porc_ninf = (nuevas_inf * 100) / menor200_2 'lista1.Count
            End If
            'Listar caravanas con mas de 700 mil células que esten en los 3 últimos controles *********************************
            Dim mu As String = ""
            If Not lista1 Is Nothing Then
                For Each c1 In lista1
                    If c1.RC > 700 Then
                        mu = c1.MUESTRA
                        If Not lista2 Is Nothing Then
                            For Each c2 In lista2
                                If mu = c2.MUESTRA Then
                                    If c2.RC > 700 Then
                                        If Not lista3 Is Nothing Then
                                            For Each c3 In lista3
                                                If mu = c3.MUESTRA Then
                                                    If c3.RC > 700 Then
                                                        lista_caravanas4 = lista_caravanas4 & mu & " - "
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
            'porc_ninf = (nuevas_inf * 100) / lista1.Count
            '***************************************************************************
            Dim valmenor200_1 As Integer = 0
            Dim valmenor700_1 As Integer = 0
            Dim valmayor700_1 As Integer = 0
            Dim sumavalores_1 As Integer = 0
            Dim diferenciavalores_1 As Integer = 0
            Dim valmenor200_2 As Integer = 0
            Dim valmenor700_2 As Integer = 0
            Dim valmayor700_2 As Integer = 0
            Dim sumavalores_2 As Integer = 0
            Dim diferenciavalores_2 As Integer = 0
            Dim valmenor200_3 As Integer = 0
            Dim valmenor700_3 As Integer = 0
            Dim valmayor700_3 As Integer = 0
            Dim sumavalores_3 As Integer = 0
            Dim diferenciavalores_3 As Integer = 0

            valmenor200_1 = (menor200_1 / muestras1) * 100
            valmenor700_1 = (menor700_1 / muestras1) * 100
            valmayor700_1 = (mayor700_1 / muestras1) * 100
            sumavalores_1 = valmenor200_1 + valmenor700_1 + valmayor700_1
            diferenciavalores_1 = sumavalores_1 - 100
            If diferenciavalores_1 < 0 Then
                diferenciavalores_1 = diferenciavalores_1 * -1
            End If
            If sumavalores_1 > 100 Then
                valmenor200_1 = valmenor200_1 - diferenciavalores_1
            ElseIf sumavalores_1 < 100 Then
                valmenor200_1 = valmenor200_1 + diferenciavalores_1
            End If

            valmenor200_2 = (menor200_2 / muestras2) * 100
            valmenor700_2 = (menor700_2 / muestras2) * 100
            valmayor700_2 = (mayor700_2 / muestras2) * 100
            sumavalores_2 = valmenor200_2 + valmenor700_2 + valmayor700_2
            diferenciavalores_2 = sumavalores_2 - 100
            If diferenciavalores_2 < 0 Then
                diferenciavalores_2 = diferenciavalores_2 * -1
            End If
            If sumavalores_2 > 100 Then
                valmenor200_2 = valmenor200_2 - diferenciavalores_2
            ElseIf sumavalores_2 < 100 Then
                valmenor200_2 = valmenor200_2 + diferenciavalores_2
            End If

            valmenor200_3 = (menor200_3 / muestras3) * 100
            valmenor700_3 = (menor700_3 / muestras3) * 100
            valmayor700_3 = (mayor700_3 / muestras3) * 100
            sumavalores_3 = valmenor200_3 + valmenor700_3 + valmayor700_3
            diferenciavalores_3 = sumavalores_3 - 100
            If diferenciavalores_3 < 0 Then
                diferenciavalores_3 = diferenciavalores_3 * -1
            End If
            If sumavalores_3 > 100 Then
                valmenor200_3 = valmenor200_3 - diferenciavalores_3
            ElseIf sumavalores_3 < 100 Then
                valmenor200_3 = valmenor200_3 + diferenciavalores_3
            End If

            Dim fecha11 As Date = Convert.ToDateTime(fecha1)
            Dim fecha12 As Date = Convert.ToDateTime(fecha3)
            Dim diasx As Integer = fecha11.DayOfYear - fecha12.DayOfYear
            Dim anio1 As Integer = 0
            Dim anio3 As Integer = 0
            anio1 = fecha11.Year
            anio3 = fecha12.Year
         
            'GRAFICA RECUENTO CELULAS 1                                                                                                                                     '**************************************************************************************************************************************
            Chart1.Titles.Clear()
            Chart1.Titles.Add("Interpretación de recuento celular - Actual")
            Chart1.Series(0).Points.Clear()
            Chart1.Series(0).Points.AddXY("Menor a 200: " & " " & valmenor200_1 & " %", valmenor200_1)
            Chart1.Series(0).Points.AddXY("Mayor a 200: " & " " & valmenor700_1 & " %", valmenor700_1)
            Chart1.Series(0).Points.AddXY("Mayor a 700: " & " " & valmayor700_1 & " %", valmayor700_1)
            Chart1.SaveImage("\\ROBOT\GraficasRC\" & ficha & "_RC1" & ".jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg)
            'GRAFICA RECUENTO CELULAS 2                                                                                                                                     '**************************************************************************************************************************************
            Chart2.Titles.Clear()
            Chart2.Titles.Add("Interpretación de recuento celular - Anterior")
            Chart2.Series(0).Points.Clear()
            Chart2.Series(0).Points.AddXY("Menor a 200: " & " " & valmenor200_2 & " %", valmenor200_2)
            Chart2.Series(0).Points.AddXY("Mayor a 200: " & " " & valmenor700_2 & " %", valmenor700_2)
            Chart2.Series(0).Points.AddXY("Mayor a 700: " & " " & valmayor700_2 & " %", valmayor700_2)
            Chart2.SaveImage(" \\ROBOT\GraficasRC\" & ficha & "_RC2" & ".jpg", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg)

          
            Dim x1app As Microsoft.Office.Interop.Excel.Application
            Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
            Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
            x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
            x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
            x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
            x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
            x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(0.3)
            x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.1)
            x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(1)
            Dim fila As Integer
            Dim columna As Integer
            x1hoja.Cells(1, 1).columnwidth = 15
            x1hoja.Cells(1, 2).columnwidth = 8
            x1hoja.Cells(1, 3).columnwidth = 8
            x1hoja.Cells(1, 4).columnwidth = 8
            x1hoja.Cells(1, 5).columnwidth = 8
            x1hoja.Cells(1, 6).columnwidth = 8
            x1hoja.Cells(1, 7).columnwidth = 8
            x1hoja.Cells(1, 8).columnwidth = 8
            x1hoja.Cells(1, 9).columnwidth = 8
            fila = 1
            columna = 1
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Formula = "ESTADÍSTICA DE RECUENTO CELULAR" & " - Ficha " & ficha
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 12
            fila = fila + 1
            columna = 1
            x1libro.Worksheets(1).cells(fila, columna).select()
            x1libro.ActiveSheet.pictures.Insert("\\ROBOT\GraficasRC\" & ficha1 & "_RC1.jpg").select()
            x1libro.Worksheets(1).cells(2, 1).select()
            fila = fila + 3
            columna = 6
            x1libro.Worksheets(1).cells(fila, columna).select()
            x1libro.ActiveSheet.pictures.Insert("\\ROBOT\GraficasRC\" & ficha1 & "_RC2.jpg").select()
            x1libro.Worksheets(1).cells(2, 1).select()
            fila = fila + 14
            columna = 1
            'LISTA LAS CARAVANAS > 700.000 DEL ULTIMO CONTROL *************************************************************************************
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Formula = "Caravanas con mas de 700.000 células presentes en el control actual."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Range("A" & fila, "J" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            If lista_caravanas <> "" Then
                x1hoja.Cells(fila, columna).Formula = lista_caravanas
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
            Else
                x1hoja.Cells(fila, columna).Formula = "No hay caravanas con mas de 700.000 células presentes en el control actual."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
            End If
            'PORCENTAJE DE NUEVAS INFECCIONES*********************************************************************************************
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Formula = "Porcentaje de nuevas infecciones: " & porc_ninf & " %"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Formula = "% de vacas que pasaron de estar sanas(<200.000 cels/mL) a enfermas(>200.000 cels/mL)"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 2
            '*****************************************************************************************************************************
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Formula = "Caravanas con mas de 700.000 células presentes en los 3 últimos controles (vacas crónicas)"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 24
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Range("A" & fila, "J" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            If lista_caravanas4 <> "" Then
                x1hoja.Cells(fila, columna).Formula = lista_caravanas4
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
            Else
                x1hoja.Cells(fila, columna).Formula = "No hay caravanas con mas de 700.000 células presentes en los 3 últimos controles."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
            End If
            x1hoja.Cells(fila, columna).rowheight = 9
            fila = fila + 1
            columna = 2
            x1hoja.Range("B" & fila, "D" & fila).WrapText = True
            x1hoja.Range("B" & fila, "D" & fila).Merge()
            x1hoja.Range("B" & fila, "D" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("B" & fila, "D" & fila).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "BHB leche Vaca ind. (mmol/L)"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 3
            x1hoja.Range("E" & fila, "F" & fila).WrapText = True
            x1hoja.Range("E" & fila, "F" & fila).Merge()
            x1hoja.Range("E" & fila, "F" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("E" & fila, "F" & fila).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Riesgo de Cetósis"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            columna = 2
            x1hoja.Range("B" & fila, "D" & fila).WrapText = True
            x1hoja.Range("B" & fila, "D" & fila).Merge()
            x1hoja.Range("B" & fila, "D" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "< 0.15"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 3
            x1hoja.Range("E" & fila, "F" & fila).WrapText = True
            x1hoja.Range("E" & fila, "F" & fila).Merge()
            x1hoja.Range("E" & fila, "F" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Negativa"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "D" & fila).WrapText = True
            x1hoja.Range("B" & fila, "D" & fila).Merge()
            x1hoja.Range("B" & fila, "D" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "0.15 y 0.19"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 3
            x1hoja.Range("E" & fila, "F" & fila).WrapText = True
            x1hoja.Range("E" & fila, "F" & fila).Merge()
            x1hoja.Range("E" & fila, "F" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Sospechosa"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "D" & fila).WrapText = True
            x1hoja.Range("B" & fila, "D" & fila).Merge()
            x1hoja.Range("B" & fila, "D" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "> 0.20 mmol/L"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 3
            x1hoja.Range("E" & fila, "F" & fila).WrapText = True
            x1hoja.Range("E" & fila, "F" & fila).Merge()
            x1hoja.Range("E" & fila, "F" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Positiva"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Cells(fila, columna).Formula = "Santschi et. al. (2016)"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 5
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Interior.Color = RGB(0, 0, 0)
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 20
            fila = fila + 1
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Formula = "ESTADÍSTICA GENERAL DE TANQUE"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 12
            fila = fila + 1
            Dim ec As New dEstadisticaCalidad
            ec = ec.buscarultimo
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Formula = "Datos procesados de muestras recibidas en COLAVECO"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Formula = "Media geométrica / Muestras de leche de tanque" & "- Período " & ec.PERIODO
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            columna = 2
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "RBt"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "RCS"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Gr"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Pr"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Lac"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "ST"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Crio"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Ur"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 23.25
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "x 1.000 eq. UFC/mL"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "x 1.000 cel/mL"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "g/100mL"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "g/100mL"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "g/100mL"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "g/100mL"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "ºC"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "mg/dL"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 7
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Media Geom."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.RB
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.RC
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.GR
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.PR
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.LA
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.ST
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.CR
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.UR
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = "Muestras"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.RB_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.RC_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.GR_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.PR_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.LA_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.ST_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.CR_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 1
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).Formula = ec.UR_M
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 20
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Formula = "(Abreviaturas: RBt = Recuento Bacteriano Total / RCS = Recuento de células somáticas / Gr = Grasa / Pr = Proteínas / Lac = Lactosa / ST = Sólidos totales / Crio = Crioscopía / Ur = Urea)"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 6
            fila = fila + 1
            x1hoja.Cells(fila, columna).rowheight = 30
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Formula = "EL EFECTO DEL RECUENTO DE CÉLULAS SOMÁTICAS DEL TANQUE EN LA PRODUCCIÓN DE LECHE EN UN RODEO CON UNA PRODUCCIÓN MEDIA DE 5.000 LTS/VACA/AÑO SERÍA EL SIGUIENTE:"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            fila = fila + 1
            columna = 2
            x1hoja.Range("B" & fila, "C" & fila).WrapText = True
            x1hoja.Range("B" & fila, "C" & fila).Merge()
            x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("B" & fila, "C" & fila).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Recuento celular en el tanque"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Cells(fila, columna).rowheight = 26.25
            x1hoja.Range("D" & fila, "E" & fila).WrapText = True
            x1hoja.Range("D" & fila, "E" & fila).Merge()
            x1hoja.Range("D" & fila, "E" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("D" & fila, "E" & fila).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Reducción Lts/vaca/año"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("F" & fila, "G" & fila).WrapText = True
            x1hoja.Range("F" & fila, "G" & fila).Merge()
            x1hoja.Range("F" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("F" & fila, "G" & fila).Interior.Color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "Reducción Prod. Total (%)"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "C" & fila).WrapText = True
            x1hoja.Range("B" & fila, "C" & fila).Merge()
            x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "<250.000"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("D" & fila, "E" & fila).WrapText = True
            x1hoja.Range("D" & fila, "E" & fila).Merge()
            x1hoja.Range("D" & fila, "E" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "--- ---"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("F" & fila, "G" & fila).WrapText = True
            x1hoja.Range("F" & fila, "G" & fila).Merge()
            x1hoja.Range("F" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "--- ---"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "C" & fila).WrapText = True
            x1hoja.Range("B" & fila, "C" & fila).Merge()
            x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "250.000 - 500.000"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("D" & fila, "E" & fila).WrapText = True
            x1hoja.Range("D" & fila, "E" & fila).Merge()
            x1hoja.Range("D" & fila, "E" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "200"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("F" & fila, "G" & fila).WrapText = True
            x1hoja.Range("F" & fila, "G" & fila).Merge()
            x1hoja.Range("F" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "'4 - 6"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "C" & fila).WrapText = True
            x1hoja.Range("B" & fila, "C" & fila).Merge()
            x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "500.000 - 750.000"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("D" & fila, "E" & fila).WrapText = True
            x1hoja.Range("D" & fila, "E" & fila).Merge()
            x1hoja.Range("D" & fila, "E" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "350"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("F" & fila, "G" & fila).WrapText = True
            x1hoja.Range("F" & fila, "G" & fila).Merge()
            x1hoja.Range("F" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "7"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "C" & fila).WrapText = True
            x1hoja.Range("B" & fila, "C" & fila).Merge()
            x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "750.000 - 1.000.000"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("D" & fila, "E" & fila).WrapText = True
            x1hoja.Range("D" & fila, "E" & fila).Merge()
            x1hoja.Range("D" & fila, "E" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "750"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("F" & fila, "G" & fila).WrapText = True
            x1hoja.Range("F" & fila, "G" & fila).Merge()
            x1hoja.Range("F" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "15"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "C" & fila).WrapText = True
            x1hoja.Range("B" & fila, "C" & fila).Merge()
            x1hoja.Range("B" & fila, "C" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "> 1.000.000"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("D" & fila, "E" & fila).WrapText = True
            x1hoja.Range("D" & fila, "E" & fila).Merge()
            x1hoja.Range("D" & fila, "E" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "900"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = columna + 2
            x1hoja.Range("F" & fila, "G" & fila).WrapText = True
            x1hoja.Range("F" & fila, "G" & fila).Merge()
            x1hoja.Range("F" & fila, "G" & fila).Borders.Color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).WrapText = True
            x1hoja.Cells(fila, columna).Formula = "18"
            x1hoja.Cells(fila, columna).Font.Bold = False
            x1hoja.Cells(fila, columna).Font.Size = 10
            columna = 2
            fila = fila + 1
            x1hoja.Range("B" & fila, "G" & fila).WrapText = True
            x1hoja.Range("B" & fila, "G" & fila).Merge()
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignRight
            x1hoja.Cells(fila, columna).Formula = "L. Kaartinen, 1995"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 2
            columna = 1
            x1hoja.Range("A" & fila, "J" & fila).WrapText = True
            x1hoja.Range("A" & fila, "J" & fila).Merge()
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Formula = "NOTA: LA INFORMACIÓN CONTENIDA EN ESTA HOJA ES GENERADA POR UNA ESTADÍSTICA INTERNA DEL LABORATORIO."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 2

            x1libro.Worksheets(1).cells(fila, columna).select()
            x1libro.ActiveSheet.pictures.Insert("\\ROBOT\GraficasRC\pie.jpg").select()
            x1libro.Worksheets(1).cells(2, 1).select()
            'PROTEGE LA HOJA DE EXCEL
            x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
                Contents:=True, Scenarios:=True)
            'GUARDA EL ARCHIVO DE EXCEL
            x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
            Try
                x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
                x1hoja.SaveAs("\\ROBOT\GraficasRC\x" & ficha1 & ".xls")
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                'MessageBox.Show("Falla al grabar!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            'x1app.Visible = True
            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
            'Else
            '    MsgBox("El cliente no tiene 3 controles realizados.")
        End If

        Dim proceso As System.Diagnostics.Process()
        proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each opro As System.Diagnostics.Process In proceso
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next
        'Me.Close()
    End Sub
End Class