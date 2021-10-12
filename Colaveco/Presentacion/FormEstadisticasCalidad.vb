Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormEstadisticasCalidad
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region
    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        If TextEmpresa.Text <> "" Then
            ListarEmpresa()
        ElseIf TextProductor.Text <> "" Then
            ListarProductor()
        Else
            ListarTodos()
        End If
    End Sub
    Private Sub ListarEmpresa()
        If TextIdEmpresa.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar una empresa", MsgBoxStyle.Exclamation, "Atención") : TextIdEmpresa.Focus() : Exit Sub
        Dim s As New dSolicitudAnalisis
        Dim listafichas As New ArrayList
        Dim idempresa As Long = TextIdEmpresa.Text.Trim
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        listafichas = s.listarporfechacalidadempresa(fecdesde, fechasta, idempresa)

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
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Crioscopìa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Urea"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteina V"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Caseina"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1


        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                For Each s In listafichas
                    idficha = s.ID
                    listacsm = csm.listarporsolicitud(idficha)
                    If Not listacsm Is Nothing Then
                        If listacsm.Count > 0 Then
                            For Each csm In listacsm
                                Dim c As New dCalidad
                                Dim ibc As New dIbc
                                ibc.FICHA = idficha
                                ibc.MUESTRA = Trim(csm.MUESTRA)
                                ibc = ibc.buscarxfichaxmuestra
                                c.FICHA = idficha
                                c.MUESTRA = Trim(csm.MUESTRA)
                                c = c.buscarxfichaxmuestra

                                If Not c Is Nothing Then




                                    If c.RC >= 100 And c.RC <= 10000 And c.GRASA >= 2 And c.GRASA <= 5.5 And c.PROTEINA >= 2 And c.PROTEINA <= 4 And c.LACTOSA >= 2 And c.LACTOSA <= 6 And c.ST >= 10 And c.ST <= 14 And c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 And c.UREA >= 2 And c.UREA <= 40 And c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 And c.CASEINA >= 2 And c.CASEINA <= 3.2 Then

                                        x1hoja.Cells(fila, columna).formula = c.FECHA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1


                                        muestras = muestras + 1
                                        If Not ibc Is Nothing Then

                                            If ibc.RB <> -1 Or ibc.RB <> 0 Then
                                                x1hoja.Cells(fila, columna).formula = ibc.RB
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If

                                        If c.RC <> -1 And c.RC <> 0 Then
                                            x1hoja.Cells(fila, columna).formula = c.RC
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.GRASA <> -1 And c.GRASA <> 0 Then
                                            If c.GRASA >= 2 And c.GRASA <= 5.5 Then
                                                x1hoja.Cells(fila, columna).formula = c.GRASA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.PROTEINA <> -1 And c.PROTEINA <> 0 Then
                                            If c.PROTEINA >= 2 And c.PROTEINA <= 4 Then
                                                x1hoja.Cells(fila, columna).formula = c.PROTEINA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.LACTOSA <> -1 And c.LACTOSA <> 0 Then
                                            If c.LACTOSA >= 2 And c.LACTOSA <= 6 Then
                                                x1hoja.Cells(fila, columna).formula = c.LACTOSA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.ST <> -1 And c.ST <> 0 Then
                                            If c.ST >= 10 And c.ST <= 13.5 Then
                                                x1hoja.Cells(fila, columna).formula = c.ST
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.CRIOSCOPIA <> -1 And c.CRIOSCOPIA <> 0 Then
                                            If c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 Then
                                                x1hoja.Cells(fila, columna).formula = c.CRIOSCOPIA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.UREA <> -1 And c.UREA <> 0 Then
                                            If c.UREA >= 3 And c.UREA <= 30 Then
                                                x1hoja.Cells(fila, columna).formula = c.UREA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.PROTEINAV <> -1 And c.PROTEINAV <> 0 Then
                                            If c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 Then
                                                x1hoja.Cells(fila, columna).formula = c.PROTEINAV
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.CASEINA <> -1 And c.CASEINA <> 0 Then
                                            If c.CASEINA >= 2 And c.CASEINA <= 3.2 Then
                                                x1hoja.Cells(fila, columna).formula = c.CASEINA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = 1
                                                fila = fila + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = 1
                                                fila = fila + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1
                                        End If
                                    Else
                                        descartadas = descartadas + 1
                                    End If
                                End If
                            Next

                        End If

                    End If
                    valor = 100 / listafichas.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next


                fila = fila + 1
                columna = 1

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
            End If
            x1app.Visible = True
            'x1libro.PrintPreview()

            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If

    End Sub
    Private Function Es_Bisiesto(ByVal Año As Integer) As Boolean
        On Error GoTo ErrorEs_Bisiesto
        If Año Mod 4 = 0 Then
            If (Año Mod 100 = 0) And Not (Año Mod 400 = 0) Then
                Es_Bisiesto = False
            Else
                Es_Bisiesto = True
            End If
        Else
            Es_Bisiesto = False
        End If
        Exit Function
ErrorEs_Bisiesto:
        Es_Bisiesto = False
    End Function
    Private Sub ListarTodos()
        Dim s As New dSolicitudAnalisis
        Dim listafichas As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        listafichas = s.listarporfechacalidad(fecdesde, fechasta)

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
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Crioscopìa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Urea"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteina V"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Caseina"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1


        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                For Each s In listafichas
                    idficha = s.ID
                    listacsm = csm.listarporsolicitud(idficha)
                    If Not listacsm Is Nothing Then
                        If listacsm.Count > 0 Then
                            For Each csm In listacsm
                                Dim c As New dCalidad
                                Dim ibc As New dIbc
                                ibc.FICHA = idficha
                                ibc.MUESTRA = Trim(csm.MUESTRA)
                                ibc = ibc.buscarxfichaxmuestra
                                c.FICHA = idficha
                                c.MUESTRA = Trim(csm.MUESTRA)
                                c = c.buscarxfichaxmuestra
                                
                                If Not c Is Nothing Then
                                    



                                    If c.RC >= 100 And c.RC <= 10000 And c.GRASA >= 2 And c.GRASA <= 5.5 And c.PROTEINA >= 2 And c.PROTEINA <= 4 And c.LACTOSA >= 2 And c.LACTOSA <= 6 And c.ST >= 10 And c.ST <= 14 And c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 And c.UREA >= 2 And c.UREA <= 40 And c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 And c.CASEINA >= 2 And c.CASEINA <= 3.2 Then

                                        x1hoja.Cells(fila, columna).formula = c.FECHA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1


                                        muestras = muestras + 1
                                        If Not ibc Is Nothing Then

                                            If ibc.RB <> -1 Or ibc.RB <> 0 Then
                                                x1hoja.Cells(fila, columna).formula = ibc.RB
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If

                                        If c.RC <> -1 And c.RC <> 0 Then
                                            x1hoja.Cells(fila, columna).formula = c.RC
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.GRASA <> -1 And c.GRASA <> 0 Then
                                            If c.GRASA >= 2 And c.GRASA <= 5.5 Then
                                                x1hoja.Cells(fila, columna).formula = c.GRASA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.PROTEINA <> -1 And c.PROTEINA <> 0 Then
                                            If c.PROTEINA >= 2 And c.PROTEINA <= 4 Then
                                                x1hoja.Cells(fila, columna).formula = c.PROTEINA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.LACTOSA <> -1 And c.LACTOSA <> 0 Then
                                            If c.LACTOSA >= 2 And c.LACTOSA <= 6 Then
                                                x1hoja.Cells(fila, columna).formula = c.LACTOSA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.ST <> -1 And c.ST <> 0 Then
                                            If c.ST >= 10 And c.ST <= 13.5 Then
                                                x1hoja.Cells(fila, columna).formula = c.ST
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.CRIOSCOPIA <> -1 And c.CRIOSCOPIA <> 0 Then
                                            If c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 Then
                                                x1hoja.Cells(fila, columna).formula = c.CRIOSCOPIA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.UREA <> -1 And c.UREA <> 0 Then
                                            If c.UREA >= 3 And c.UREA <= 30 Then
                                                x1hoja.Cells(fila, columna).formula = c.UREA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.PROTEINAV <> -1 And c.PROTEINAV <> 0 Then
                                            If c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 Then
                                                x1hoja.Cells(fila, columna).formula = c.PROTEINAV
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.CASEINA <> -1 And c.CASEINA <> 0 Then
                                            If c.CASEINA >= 2 And c.CASEINA <= 3.2 Then
                                                x1hoja.Cells(fila, columna).formula = c.CASEINA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = 1
                                                fila = fila + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = 1
                                                fila = fila + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1
                                        End If
                                    Else
                                        descartadas = descartadas + 1
                                    End If
                                    End If
                            Next

                        End If

                    End If
                    valor = 100 / listafichas.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next


                fila = fila + 1
                columna = 1
               
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
            End If
            x1app.Visible = True
            'x1libro.PrintPreview()

            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If
    End Sub

    Private Sub ButtonBuscarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarEmpresa.Click
        Dim v As New FormBuscarEmpresa
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdEmpresa.Text = pro.ID
            TextEmpresa.Text = pro.NOMBRE
        End If
    End Sub

    Private Sub ButtonLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLimpiar.Click
        TextIdEmpresa.Text = ""
        TextEmpresa.Text = ""
    End Sub

    Private Sub ListarTodos_old()
        Dim s As New dSolicitudAnalisis
        Dim listafichas As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        'Dim fechaactual As Date = Now
        'Dim mesactual As Integer = 0
        'Dim anioactual As Integer = 0
        'Dim mes As Integer = NumericMes.Value
        'Dim anio As Integer = NumericAnio.Value
        'Dim fec As String
        'Dim diadesde As Integer = 0
        'Dim diahasta As Integer = 0
        'Dim mesdesde As Integer = 0
        'Dim meshasta As Integer = 0
        'Dim aniodesde As Integer = 0
        'Dim aniohasta As Integer = 0
        'fec = Format(fechaactual, "yyyy-MM-dd")
        'mesactual = Mid(fec, 6, 2)
        'anioactual = Mid(fec, 1, 4)

        'If anioactual = anio Then
        '    If mesactual = mes Then
        '        If mes = 1 Then
        '            mes = 12
        '            anio = anio - 1
        '            meshasta = mes
        '            aniohasta = anio
        '        Else
        '            mes = mes - 1
        '            meshasta = mes
        '            aniohasta = anio
        '        End If
        '    ElseIf mesactual < mes Then
        '        MsgBox("El mes ingresado no es correcto")
        '        Exit Sub
        '    ElseIf mesactual > mes Then
        '        meshasta = mes
        '        aniohasta = anio
        '    End If
        'ElseIf anioactual < anio Then
        '    MsgBox("El año ingresado no es correcto")
        '    Exit Sub
        'ElseIf anioactual > anio Then
        '    meshasta = mes
        '    aniohasta = anio
        'End If
        'Dim bisiesto As Boolean
        'bisiesto = Es_Bisiesto(aniohasta)

        'If meshasta = 2 Then
        '    mesdesde = 12
        '    aniodesde = anio - 1
        'ElseIf meshasta = 1 Then
        '    mesdesde = 11
        '    aniodesde = anio - 1
        'Else
        '    mesdesde = meshasta - 2
        '    aniodesde = aniohasta
        'End If

        'If meshasta = 1 Or meshasta = 3 Or meshasta = 5 Or meshasta = 7 Or meshasta = 8 Or meshasta = 10 Or meshasta = 12 Then
        '    diahasta = 31
        'ElseIf meshasta = 2 Then
        '    If bisiesto = True Then
        '        diahasta = 29
        '    Else
        '        diahasta = 28
        '    End If
        'End If
        'Dim mesdesde2 As String = ""
        'Dim meshasta2 As String = ""
        'If mesdesde = 1 Or mesdesde = 2 Or mesdesde = 3 Or mesdesde = 4 Or mesdesde = 5 Or mesdesde = 6 Or mesdesde = 7 Or mesdesde = 8 Or mesdesde = 9 Then
        '    mesdesde2 = "0" & mesdesde
        'Else
        '    mesdesde2 = mesdesde
        'End If
        'If meshasta = 1 Or meshasta = 2 Or meshasta = 3 Or meshasta = 4 Or meshasta = 5 Or meshasta = 6 Or meshasta = 7 Or meshasta = 8 Or meshasta = 9 Then
        '    meshasta2 = "0" & meshasta
        'Else
        '    meshasta2 = meshasta
        'End If

        'fecdesde = aniodesde & "-" & mesdesde2 & "-" & "01"
        'fechasta = aniohasta & "-" & meshasta2 & "-" & diahasta

        listafichas = s.listarporfechacalidad(fecdesde, fechasta)

        Dim rb As Integer = 0
        Dim rb_min As Integer = 5000
        Dim rb_max As Integer = 0
        Dim rb_prom As Integer = 0
        Dim rb_cuenta As Integer = 0
        Dim rb_numeros As Integer = 0
        Dim rb_resultado As Double = 0
        Dim rc As Integer = 0
        Dim rc_min As Integer = 5000
        Dim rc_max As Integer = 0
        Dim rc_prom As Integer = 0
        Dim rc_cuenta As Integer = 0
        Dim rc_numeros As Integer = 0
        Dim rc_resultado As Double = 0
        Dim grasa As Double = 0
        Dim grasa_min As Double = 5000
        Dim grasa_max As Double = 0
        Dim grasa_prom As Double = 0
        Dim grasa_cuenta As Double = 0
        Dim grasa_numeros As Integer = 0
        Dim grasa_resultado As Double = 0
        Dim proteina As Double = 0
        Dim proteina_min As Double = 5000
        Dim proteina_max As Double = 0
        Dim proteina_prom As Double = 0
        Dim proteina_cuenta As Double = 0
        Dim proteina_numeros As Integer = 0
        Dim proteina_resultado As Double = 0
        Dim lactosa As Double = 0
        Dim lactosa_min As Double = 5000
        Dim lactosa_max As Double = 0
        Dim lactosa_prom As Double = 0
        Dim lactosa_cuenta As Double = 0
        Dim lactosa_numeros As Integer = 0
        Dim lactosa_resultado As Double = 0
        Dim st As Double = 0
        Dim st_min As Double = 5000
        Dim st_max As Double = 0
        Dim st_prom As Double = 0
        Dim st_cuenta As Double = 0
        Dim st_numeros As Integer = 0
        Dim st_resultado As Double = 0
        Dim crioscopia As Double = 0
        Dim crioscopia_min As Double = 5000
        Dim crioscopia_max As Double = 0
        Dim crioscopia_prom As Double = 0
        Dim crioscopia_cuenta As Double = 0
        Dim crioscopia_numeros As Integer = 0
        Dim crioscopia_resultado As Double = 0
        Dim urea As Double = 0
        Dim urea_min As Double = 5000
        Dim urea_max As Double = 0
        Dim urea_prom As Double = 0
        Dim urea_cuenta As Double = 0
        Dim urea_numeros As Integer = 0
        Dim urea_resultado As Double = 0
        Dim proteinav As Double = 0
        Dim proteinav_min As Double = 5000
        Dim proteinav_max As Double = 0
        Dim proteinav_prom As Double = 0
        Dim proteinav_cuenta As Double = 0
        Dim proteinav_numeros As Integer = 0
        Dim proteinav_resultado As Double = 0
        Dim caseina As Double = 0
        Dim caseina_min As Double = 5000
        Dim caseina_max As Double = 0
        Dim caseina_prom As Double = 0
        Dim caseina_cuenta As Double = 0
        Dim caseina_numeros As Integer = 0
        Dim caseina_resultado As Double = 0

        Dim densidad As Double = 0
        Dim densidad_min As Double = 5000
        Dim densidad_max As Double = 0
        Dim densidad_prom As Double = 0
        Dim densidad_cuenta As Double = 0
        Dim ph As Double = 0
        Dim ph_min As Double = 5000
        Dim ph_max As Double = 0
        Dim ph_prom As Double = 0
        Dim ph_cuenta As Double = 0

        Dim idficha As Long = 0

        Dim valor As Double = 0
        Dim valor1 As Double = 0

        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 15
        x1hoja.Cells(1, 3).columnwidth = 20
        x1hoja.Cells(1, 4).columnwidth = 8
        x1hoja.Cells(1, 5).columnwidth = 8
        x1hoja.Cells(1, 6).columnwidth = 25
        x1hoja.Cells(1, 7).columnwidth = 15

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        x1hoja.Cells(fila, columna).formula = "Estadísticas calodad de leche " & fecdesde & " - " & fechasta
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
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Crioscopìa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Urea"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteina V"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Caseina"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1


        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                For Each s In listafichas
                    idficha = s.ID
                    listacsm = csm.listarporsolicitud(idficha)
                    If Not listacsm Is Nothing Then
                        If listacsm.Count > 0 Then
                            For Each csm In listacsm
                                Dim c As New dCalidad
                                Dim ibc As New dIbc
                                ibc.FICHA = idficha
                                ibc.MUESTRA = Trim(csm.MUESTRA)
                                ibc = ibc.buscarxfichaxmuestra
                                c.FICHA = idficha
                                c.MUESTRA = Trim(csm.MUESTRA)
                                c = c.buscarxfichaxmuestra

                                If Not c Is Nothing Then
                                    x1hoja.Cells(fila, columna).formula = c.FECHA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    columna = columna + 1

                                    If Not ibc Is Nothing Then
                                        If ibc.RB <> -1 Or ibc.RB <> 0 Then
                                            rb = rb + ibc.RB
                                            rb_cuenta = rb_cuenta + 1
                                            x1hoja.Cells(fila, columna).formula = ibc.RB
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            rb_numeros = rb_numeros + 1
                                            If rb_min > ibc.RB Then
                                                rb_min = ibc.RB
                                            End If
                                            If rb_max < ibc.RB Then
                                                rb_max = ibc.RB
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If

                                    If c.RC <> -1 And c.RC <> 0 Then
                                        rc = rc + c.RC
                                        rc_cuenta = rc_cuenta + 1
                                        x1hoja.Cells(fila, columna).formula = c.RC
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                        rc_numeros = rc_numeros + 1
                                        If rc_min > c.RC Then
                                            rc_min = c.RC
                                        End If
                                        If rc_max < c.RC Then
                                            rc_max = c.RC
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.GRASA <> -1 And c.GRASA <> 0 Then
                                        grasa_cuenta = grasa_cuenta + 1
                                        If c.GRASA >= 2 And c.GRASA <= 5.5 Then
                                            grasa = grasa + c.GRASA
                                            grasa_numeros = grasa_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.GRASA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            If grasa_min > c.GRASA Then
                                                grasa_min = c.GRASA
                                            End If
                                            If grasa_max < c.GRASA Then
                                                grasa_max = c.GRASA
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.PROTEINA <> -1 And c.PROTEINA <> 0 Then
                                        proteina_cuenta = proteina_cuenta + 1
                                        If c.PROTEINA >= 2 And c.PROTEINA <= 4 Then
                                            proteina = proteina + c.PROTEINA
                                            proteina_numeros = proteina_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.PROTEINA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            If proteina_min > c.PROTEINA Then
                                                proteina_min = c.PROTEINA
                                            End If
                                            If proteina_max < c.PROTEINA Then
                                                proteina_max = c.PROTEINA
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.LACTOSA <> -1 And c.LACTOSA <> 0 Then
                                        lactosa_cuenta = lactosa_cuenta + 1
                                        If c.LACTOSA >= 2 And c.LACTOSA <= 6 Then
                                            lactosa = lactosa + c.LACTOSA
                                            lactosa_numeros = lactosa_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.LACTOSA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            If lactosa_min > c.LACTOSA Then
                                                lactosa_min = c.LACTOSA
                                            End If
                                            If lactosa_max < c.LACTOSA Then
                                                lactosa_max = c.LACTOSA
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.ST <> -1 And c.ST <> 0 Then
                                        st_cuenta = st_cuenta + 1
                                        If c.ST >= 10 And c.ST <= 13.5 Then
                                            st = st + c.ST
                                            st_numeros = st_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.ST
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            If st_min > c.ST Then
                                                st_min = c.ST
                                            End If
                                            If st_max < c.ST Then
                                                st_max = c.ST
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.CRIOSCOPIA <> -1 And c.CRIOSCOPIA <> 0 Then
                                        crioscopia_cuenta = crioscopia_cuenta + 1
                                        If c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 Then
                                            crioscopia = crioscopia + c.CRIOSCOPIA
                                            crioscopia_numeros = crioscopia_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.CRIOSCOPIA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            If crioscopia_min > c.CRIOSCOPIA Then
                                                crioscopia_min = c.CRIOSCOPIA
                                            End If
                                            If crioscopia_max < c.CRIOSCOPIA Then
                                                crioscopia_max = c.CRIOSCOPIA
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.UREA <> -1 And c.UREA <> 0 Then
                                        urea_cuenta = urea_cuenta + 1
                                        If c.UREA >= 3 And c.UREA <= 30 Then
                                            urea = urea + c.UREA
                                            urea_numeros = urea_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.UREA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            If urea_min > c.UREA Then
                                                urea_min = c.UREA
                                            End If
                                            If urea_max < c.UREA Then
                                                urea_max = c.UREA
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.PROTEINAV <> -1 And c.PROTEINAV <> 0 Then
                                        proteinav_cuenta = proteinav_cuenta + 1
                                        If c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 Then
                                            proteinav = proteinav + c.PROTEINAV
                                            proteinav_numeros = proteinav_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.PROTEINAV
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                            If proteinav_min > c.PROTEINAV Then
                                                proteinav_min = c.PROTEINAV
                                            End If
                                            If proteinav_max < c.PROTEINAV Then
                                                proteinav_max = c.PROTEINAV
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.CASEINA <> -1 And c.CASEINA <> 0 Then
                                        caseina_cuenta = caseina_cuenta + 1
                                        If c.CASEINA >= 2 And c.CASEINA <= 3.2 Then
                                            caseina = caseina + c.CASEINA
                                            caseina_numeros = caseina_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.CASEINA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1
                                            If caseina_min > c.CASEINA Then
                                                caseina_min = c.CASEINA
                                            End If
                                            If caseina_max < c.CASEINA Then
                                                caseina_max = c.CASEINA
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = 1
                                        fila = fila + 1
                                    End If
                                    'If c.DENSIDAD <> -1 Then
                                    '    densidad = densidad + c.DENSIDAD
                                    '    densidad_cuenta = densidad_cuenta + 1
                                    '    If densidad_min > c.DENSIDAD Then
                                    '        densidad_min = c.DENSIDAD
                                    '    End If
                                    '    If densidad_max < c.DENSIDAD Then
                                    '        densidad_max = c.DENSIDAD
                                    '    End If
                                    'End If
                                    'If c.PH <> -1 Then
                                    '    ph = ph + c.PH
                                    '    ph_cuenta = ph_cuenta + 1
                                    '    If ph_min > c.PH Then
                                    '        ph_min = c.PH
                                    '    End If
                                    '    If ph_max < c.PH Then
                                    '        ph_max = c.PH
                                    '    End If
                                    'End If
                                End If
                            Next

                        End If

                    End If
                    valor = 100 / listafichas.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next
                If grasa_cuenta > 0 Then
                    rb_prom = rb / rb_cuenta
                    rc_prom = rc / rc_cuenta
                    grasa_prom = grasa / grasa_cuenta
                    proteina_prom = proteina / proteina_cuenta
                    lactosa_prom = lactosa / lactosa_cuenta
                    st_prom = st / st_cuenta
                    crioscopia_prom = crioscopia / crioscopia_cuenta
                    urea_prom = urea / urea_cuenta
                    proteinav_prom = proteinav / proteinav_cuenta
                    caseina_prom = caseina / caseina_cuenta
                    densidad_prom = densidad / densidad_cuenta
                    ph_prom = ph / ph_cuenta

                    'CALCULA LA MEDIA GEOMETRICA
                    'rc_resultado = rc_producto ^ (1 / rc_numeros)
                    'grasa_resultado = grasa_producto ^ (1 / grasa_numeros)
                    'proteina_resultado = proteina_producto ^ (1 / proteina_numeros)
                    'lactosa_resultado = lactosa_producto ^ (1 / lactosa_numeros)
                    'st_resultado = st_producto ^ (1 / st_numeros)
                    'crioscopia_resultado = crioscopia_producto ^ (1 / crioscopia_numeros)
                    'urea_resultado = urea_producto ^ (1 / urea_numeros)
                    'proteinav_resultado = proteinav_producto ^ (1 / proteinav_numeros)
                    'caseina_resultado = caseina_producto ^ (1 / caseina_numeros)

                    fila = fila + 1
                    columna = 1
                    'Muestra minimos
                    x1hoja.Cells(fila, columna).formula = "Mínimo"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rb_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rc_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = grasa_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteina_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = lactosa_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = st_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = crioscopia_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = urea_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteinav_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = caseina_min
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra maximos
                    x1hoja.Cells(fila, columna).formula = "Máximo"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rc_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = grasa_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteina_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = lactosa_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = st_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = crioscopia_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = urea_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteinav_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = caseina_max
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra promedios
                    x1hoja.Cells(fila, columna).formula = "promedio"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rb_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rc_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = grasa_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteina_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = lactosa_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = st_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = crioscopia_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = urea_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteinav_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = caseina_prom
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra media
                    x1hoja.Cells(fila, columna).formula = "Media"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra cantidad de muestras
                    x1hoja.Cells(fila, columna).formula = "Muestras"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rb_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rc_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = grasa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = lactosa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = st_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = crioscopia_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = urea_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteinav_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = caseina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra fura de rango
                    x1hoja.Cells(fila, columna).formula = "Fuera rango"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rb_cuenta - rb_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rc_cuenta - rc_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = grasa_cuenta - grasa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteina_cuenta - proteina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = lactosa_cuenta - lactosa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = st_cuenta - st_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = crioscopia_cuenta - crioscopia_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = urea_cuenta - urea_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteinav_cuenta - proteinav_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = caseina_cuenta - caseina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1


                    'Dim fila As Integer = 0
                    'Dim columna As Integer = 0
                    'DataGridView1.Rows.Clear()
                    'DataGridView1.Rows.Add(6)
                    'DataGridView1(columna, fila).Value = "Mínimo"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = rc_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = grasa_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteina_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = lactosa_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = st_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = crioscopia_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = urea_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteinav_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = caseina_min
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = densidad_min
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = ph_min
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Máximo"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = rc_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = grasa_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteina_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = lactosa_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = st_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = crioscopia_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = urea_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteinav_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = caseina_max
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = densidad_max
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = ph_max
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Promedio"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Media Geom."
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_resultado, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Muestras"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_numeros, 0)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Fuera rango"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_cuenta - rc_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_cuenta - grasa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_cuenta - proteina_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_cuenta - lactosa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_cuenta - st_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_cuenta - crioscopia_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_cuenta - urea_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_cuenta - proteinav_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_cuenta - caseina_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                End If
            End If
            x1app.Visible = True
            'x1libro.PrintPreview()

            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If
    End Sub
    Private Sub ListarTodos_sin_filtro_grupal()
        Dim s As New dSolicitudAnalisis
        Dim listafichas As New ArrayList
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        listafichas = s.listarporfechacalidad(fecdesde, fechasta)

        Dim rb_cuenta As Integer = 0
        Dim rb_numeros As Integer = 0
        Dim rc_cuenta As Integer = 0
        Dim rc_numeros As Integer = 0
        Dim grasa_cuenta As Double = 0
        Dim grasa_numeros As Integer = 0
        Dim proteina_cuenta As Double = 0
        Dim proteina_numeros As Integer = 0
        Dim lactosa_cuenta As Double = 0
        Dim lactosa_numeros As Integer = 0
        Dim st_cuenta As Double = 0
        Dim st_numeros As Integer = 0
        Dim crioscopia_cuenta As Double = 0
        Dim crioscopia_numeros As Integer = 0
        Dim urea_cuenta As Double = 0
        Dim urea_numeros As Integer = 0
        Dim proteinav_cuenta As Double = 0
        Dim proteinav_numeros As Integer = 0
        Dim caseina_cuenta As Double = 0
        Dim caseina_numeros As Integer = 0

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
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Crioscopìa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Urea"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteina V"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Caseina"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1


        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                For Each s In listafichas
                    idficha = s.ID
                    listacsm = csm.listarporsolicitud(idficha)
                    If Not listacsm Is Nothing Then
                        If listacsm.Count > 0 Then
                            For Each csm In listacsm
                                Dim c As New dCalidad
                                Dim ibc As New dIbc
                                ibc.FICHA = idficha
                                ibc.MUESTRA = Trim(csm.MUESTRA)
                                ibc = ibc.buscarxfichaxmuestra
                                c.FICHA = idficha
                                c.MUESTRA = Trim(csm.MUESTRA)
                                c = c.buscarxfichaxmuestra

                                If Not c Is Nothing Then
                                    x1hoja.Cells(fila, columna).formula = c.FECHA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 10
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    columna = columna + 1

                                    If Not ibc Is Nothing Then
                                        If ibc.RB <> -1 Or ibc.RB <> 0 Then
                                            rb_cuenta = rb_cuenta + 1
                                            rb_numeros = rb_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = ibc.RB
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If

                                    If c.RC <> -1 And c.RC <> 0 Then
                                        rc_cuenta = rc_cuenta + 1
                                        x1hoja.Cells(fila, columna).formula = c.RC
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                        rc_numeros = rc_numeros + 1
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.GRASA <> -1 And c.GRASA <> 0 Then
                                        grasa_cuenta = grasa_cuenta + 1
                                        If c.GRASA >= 2 And c.GRASA <= 5.5 Then
                                            grasa_numeros = grasa_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.GRASA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.PROTEINA <> -1 And c.PROTEINA <> 0 Then
                                        proteina_cuenta = proteina_cuenta + 1
                                        If c.PROTEINA >= 2 And c.PROTEINA <= 4 Then
                                            proteina_numeros = proteina_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.PROTEINA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.LACTOSA <> -1 And c.LACTOSA <> 0 Then
                                        lactosa_cuenta = lactosa_cuenta + 1
                                        If c.LACTOSA >= 2 And c.LACTOSA <= 6 Then
                                            lactosa_numeros = lactosa_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.LACTOSA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.ST <> -1 And c.ST <> 0 Then
                                        st_cuenta = st_cuenta + 1
                                        If c.ST >= 10 And c.ST <= 13.5 Then
                                            st_numeros = st_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.ST
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.CRIOSCOPIA <> -1 And c.CRIOSCOPIA <> 0 Then
                                        crioscopia_cuenta = crioscopia_cuenta + 1
                                        If c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 Then
                                            crioscopia_numeros = crioscopia_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.CRIOSCOPIA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.UREA <> -1 And c.UREA <> 0 Then
                                        urea_cuenta = urea_cuenta + 1
                                        If c.UREA >= 3 And c.UREA <= 30 Then
                                            urea_numeros = urea_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.UREA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.PROTEINAV <> -1 And c.PROTEINAV <> 0 Then
                                        proteinav_cuenta = proteinav_cuenta + 1
                                        If c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 Then
                                            proteinav_numeros = proteinav_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.PROTEINAV
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1
                                    End If
                                    If c.CASEINA <> -1 And c.CASEINA <> 0 Then
                                        caseina_cuenta = caseina_cuenta + 1
                                        If c.CASEINA >= 2 And c.CASEINA <= 3.2 Then
                                            caseina_numeros = caseina_numeros + 1
                                            x1hoja.Cells(fila, columna).formula = c.CASEINA
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1
                                        End If
                                    Else
                                        x1hoja.Cells(fila, columna).formula = ""
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = 1
                                        fila = fila + 1
                                    End If
                                    'If c.DENSIDAD <> -1 Then
                                    '    densidad = densidad + c.DENSIDAD
                                    '    densidad_cuenta = densidad_cuenta + 1
                                    '    If densidad_min > c.DENSIDAD Then
                                    '        densidad_min = c.DENSIDAD
                                    '    End If
                                    '    If densidad_max < c.DENSIDAD Then
                                    '        densidad_max = c.DENSIDAD
                                    '    End If
                                    'End If
                                    'If c.PH <> -1 Then
                                    '    ph = ph + c.PH
                                    '    ph_cuenta = ph_cuenta + 1
                                    '    If ph_min > c.PH Then
                                    '        ph_min = c.PH
                                    '    End If
                                    '    If ph_max < c.PH Then
                                    '        ph_max = c.PH
                                    '    End If
                                    'End If
                                End If
                            Next

                        End If

                    End If
                    valor = 100 / listafichas.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next
                If grasa_cuenta > 0 Then
                    'rb_prom = rb / rb_cuenta
                    'rc_prom = rc / rc_cuenta
                    'grasa_prom = grasa / grasa_cuenta
                    'proteina_prom = proteina / proteina_cuenta
                    'lactosa_prom = lactosa / lactosa_cuenta
                    'st_prom = st / st_cuenta
                    'crioscopia_prom = crioscopia / crioscopia_cuenta
                    'urea_prom = urea / urea_cuenta
                    'proteinav_prom = proteinav / proteinav_cuenta
                    'caseina_prom = caseina / caseina_cuenta
                    'densidad_prom = densidad / densidad_cuenta
                    'ph_prom = ph / ph_cuenta

                    'CALCULA LA MEDIA GEOMETRICA
                    'rc_resultado = rc_producto ^ (1 / rc_numeros)
                    'grasa_resultado = grasa_producto ^ (1 / grasa_numeros)
                    'proteina_resultado = proteina_producto ^ (1 / proteina_numeros)
                    'lactosa_resultado = lactosa_producto ^ (1 / lactosa_numeros)
                    'st_resultado = st_producto ^ (1 / st_numeros)
                    'crioscopia_resultado = crioscopia_producto ^ (1 / crioscopia_numeros)
                    'urea_resultado = urea_producto ^ (1 / urea_numeros)
                    'proteinav_resultado = proteinav_producto ^ (1 / proteinav_numeros)
                    'caseina_resultado = caseina_producto ^ (1 / caseina_numeros)

                    fila = fila + 1
                    columna = 1
                    'Muestra minimos
                    x1hoja.Cells(fila, columna).formula = "Mínimo"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra maximos
                    x1hoja.Cells(fila, columna).formula = "Máximo"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra promedios
                    x1hoja.Cells(fila, columna).formula = "promedio"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra media
                    x1hoja.Cells(fila, columna).formula = "Media"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra cantidad de muestras
                    x1hoja.Cells(fila, columna).formula = "Muestras"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rb_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rc_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = grasa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = lactosa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = st_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = crioscopia_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = urea_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteinav_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = caseina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1
                    'Muestra fura de rango
                    x1hoja.Cells(fila, columna).formula = "Fuera rango"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rb_cuenta - rb_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = rc_cuenta - rc_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = grasa_cuenta - grasa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteina_cuenta - proteina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = lactosa_cuenta - lactosa_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = st_cuenta - st_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = crioscopia_cuenta - crioscopia_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = urea_cuenta - urea_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = proteinav_cuenta - proteinav_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = caseina_cuenta - caseina_numeros
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    columna = 1
                    fila = fila + 1


                    'Dim fila As Integer = 0
                    'Dim columna As Integer = 0
                    'DataGridView1.Rows.Clear()
                    'DataGridView1.Rows.Add(6)
                    'DataGridView1(columna, fila).Value = "Mínimo"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = rc_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = grasa_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteina_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = lactosa_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = st_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = crioscopia_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = urea_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteinav_min
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = caseina_min
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = densidad_min
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = ph_min
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Máximo"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = rc_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = grasa_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteina_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = lactosa_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = st_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = crioscopia_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = urea_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = proteinav_max
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = caseina_max
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = densidad_max
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = ph_max
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Promedio"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Media Geom."
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_resultado, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_resultado, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Muestras"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_numeros, 0)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    ''columna = columna + 1
                    ''DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                    'columna = 0
                    'fila = fila + 1
                    'DataGridView1(columna, fila).Value = "Fuera rango"
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(rc_cuenta - rc_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(grasa_cuenta - grasa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteina_cuenta - proteina_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(lactosa_cuenta - lactosa_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(st_cuenta - st_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(crioscopia_cuenta - crioscopia_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(urea_cuenta - urea_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(proteinav_cuenta - proteinav_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(caseina_cuenta - caseina_numeros, 0)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(densidad_prom, 2)
                    'columna = columna + 1
                    'DataGridView1(columna, fila).Value = Math.Round(ph_prom, 2)
                End If
            End If
            x1app.Visible = True
            'x1libro.PrintPreview()

            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If
    End Sub
   
   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdProductor.Text = pro.ID
            TextProductor.Text = pro.NOMBRE
        End If
    End Sub
    Private Sub ListarProductor()
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("Debe seleccionar un productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim s As New dSolicitudAnalisis
        Dim listafichas As New ArrayList
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")

        listafichas = s.listarporfechacalidadempresa(fecdesde, fechasta, idproductor)

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
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Crioscopìa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Urea"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Proteina V"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Caseina"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        columna = 1


        If Not listafichas Is Nothing Then
            If listafichas.Count > 0 Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                For Each s In listafichas
                    idficha = s.ID
                    listacsm = csm.listarporsolicitud(idficha)
                    If Not listacsm Is Nothing Then
                        If listacsm.Count > 0 Then
                            For Each csm In listacsm
                                Dim c As New dCalidad
                                Dim ibc As New dIbc
                                ibc.FICHA = idficha
                                ibc.MUESTRA = Trim(csm.MUESTRA)
                                ibc = ibc.buscarxfichaxmuestra
                                c.FICHA = idficha
                                c.MUESTRA = Trim(csm.MUESTRA)
                                c = c.buscarxfichaxmuestra

                                If Not c Is Nothing Then




                                    If c.RC >= 100 And c.RC <= 10000 And c.GRASA >= 2 And c.GRASA <= 5.5 And c.PROTEINA >= 2 And c.PROTEINA <= 4 And c.LACTOSA >= 2 And c.LACTOSA <= 6 And c.ST >= 10 And c.ST <= 14 And c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 And c.UREA >= 2 And c.UREA <= 40 And c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 And c.CASEINA >= 2 And c.CASEINA <= 3.2 Then

                                        x1hoja.Cells(fila, columna).formula = c.FECHA
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 10
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        columna = columna + 1


                                        muestras = muestras + 1
                                        If Not ibc Is Nothing Then

                                            If ibc.RB <> -1 Or ibc.RB <> 0 Then
                                                x1hoja.Cells(fila, columna).formula = ibc.RB
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If

                                        If c.RC <> -1 And c.RC <> 0 Then
                                            x1hoja.Cells(fila, columna).formula = c.RC
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.GRASA <> -1 And c.GRASA <> 0 Then
                                            If c.GRASA >= 2 And c.GRASA <= 5.5 Then
                                                x1hoja.Cells(fila, columna).formula = c.GRASA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.PROTEINA <> -1 And c.PROTEINA <> 0 Then
                                            If c.PROTEINA >= 2 And c.PROTEINA <= 4 Then
                                                x1hoja.Cells(fila, columna).formula = c.PROTEINA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.LACTOSA <> -1 And c.LACTOSA <> 0 Then
                                            If c.LACTOSA >= 2 And c.LACTOSA <= 6 Then
                                                x1hoja.Cells(fila, columna).formula = c.LACTOSA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.ST <> -1 And c.ST <> 0 Then
                                            If c.ST >= 10 And c.ST <= 13.5 Then
                                                x1hoja.Cells(fila, columna).formula = c.ST
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.CRIOSCOPIA <> -1 And c.CRIOSCOPIA <> 0 Then
                                            If c.CRIOSCOPIA >= 510 And c.CRIOSCOPIA <= 540 Then
                                                x1hoja.Cells(fila, columna).formula = c.CRIOSCOPIA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.UREA <> -1 And c.UREA <> 0 Then
                                            If c.UREA >= 3 And c.UREA <= 30 Then
                                                x1hoja.Cells(fila, columna).formula = c.UREA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.PROTEINAV <> -1 And c.PROTEINAV <> 0 Then
                                            If c.PROTEINAV >= 2.5 And c.PROTEINAV <= 4 Then
                                                x1hoja.Cells(fila, columna).formula = c.PROTEINAV
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = columna + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = columna + 1
                                        End If
                                        If c.CASEINA <> -1 And c.CASEINA <> 0 Then
                                            If c.CASEINA >= 2 And c.CASEINA <= 3.2 Then
                                                x1hoja.Cells(fila, columna).formula = c.CASEINA
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = 1
                                                fila = fila + 1
                                            Else
                                                x1hoja.Cells(fila, columna).formula = ""
                                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                                x1hoja.Cells(fila, columna).Font.Bold = False
                                                x1hoja.Cells(fila, columna).Font.Size = 10
                                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                                columna = 1
                                                fila = fila + 1
                                            End If
                                        Else
                                            x1hoja.Cells(fila, columna).formula = ""
                                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                            x1hoja.Cells(fila, columna).Font.Bold = False
                                            x1hoja.Cells(fila, columna).Font.Size = 10
                                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                            columna = 1
                                            fila = fila + 1
                                        End If
                                    Else
                                        descartadas = descartadas + 1
                                    End If
                                End If
                            Next

                        End If

                    End If
                    valor = 100 / listafichas.Count
                    valor1 = valor1 + valor
                    If valor1 < 100 Then
                        ProgressBar1.Value = valor1
                    End If
                Next


                fila = fila + 1
                columna = 1

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
            End If
            x1app.Visible = True
            'x1libro.PrintPreview()

            x1app = Nothing
            x1libro = Nothing
            x1hoja = Nothing
        End If

    End Sub
End Class