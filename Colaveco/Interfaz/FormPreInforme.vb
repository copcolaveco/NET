Imports Microsoft.Office.Interop.Excel

Public Class FormPreInforme
    Private _usuario As dUsuario
    Private _dUsuario As dUsuario
    Dim creapreinformecalidad As Integer = 1

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
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try
            If txtFicha.Text <> "" Then
            Dim pi As New pPreinformes
            Dim p As New dPreinformes
            Dim ficha As Long = txtFicha.Text.Trim()
            p = pi.buscarPorId(ficha)
            If Not p Is Nothing Then
                Dim csm As New dCalidadSolicitudMuestra
                Dim listacsm As New ArrayList
                listacsm = csm.listarporsolicitud(ficha)
                If Not listacsm Is Nothing Then
                    creapreinformecalidad = 1
                    For Each csm In listacsm
                        If csm.RB = 1 Then
                            Dim ibc As New dIbc
                            ibc.FICHA = csm.FICHA
                            ibc.MUESTRA = csm.MUESTRA
                            ibc = ibc.buscarxfichaxmuestra
                            If Not ibc Is Nothing Then
                            Else
                                creapreinformecalidad = 0
                                Exit For
                            End If
                            ibc = Nothing
                        End If
                        If csm.PSICROTROFOS = 1 Then
                            Dim psi As New dPsicrotrofos
                            psi.FICHA = csm.FICHA
                            psi.MUESTRA = csm.MUESTRA
                            psi = psi.buscarxfichaxmuestra
                            If Not psi Is Nothing Then
                            Else
                                creapreinformecalidad = 0
                                Exit For
                            End If
                            psi = Nothing
                        End If
                        If csm.ESPORULADOS = 1 Then
                            Dim esp As New dEsporulados
                            esp.FICHA = csm.FICHA
                            esp.MUESTRA = csm.MUESTRA
                            esp = esp.buscarxfichaxmuestra
                            If Not esp Is Nothing Then
                            Else
                                creapreinformecalidad = 0
                                Exit For
                            End If
                            esp = Nothing
                        End If
                        If csm.INHIBIDORES = 1 Then
                            Dim inh As New dInhibidores
                            inh.FICHA = csm.FICHA
                            inh.MUESTRA = csm.MUESTRA
                            inh = inh.buscarxfichaxmuestra
                            If Not inh Is Nothing Then
                                If inh.MARCA = 0 Then
                                    creapreinformecalidad = 0
                                    Exit For
                                End If
                            Else
                                creapreinformecalidad = 0
                                Exit For
                            End If
                            inh = Nothing
                        End If
                        If csm.AFLATOXINA = 1 Then
                            Dim ml As New dMicotoxinasLeche
                            ml.FICHA = csm.FICHA
                            ml.MUESTRA = csm.MUESTRA
                            ml = ml.buscarxfichaxmuestra
                            If Not ml Is Nothing Then
                            Else
                                creapreinformecalidad = 0
                                Exit For
                            End If
                            ml = Nothing
                        End If
                        Next
                    End If


                    If p.TIPO = 1 Then
                        preinforme_control(ficha)
                        MsgBox("La ficha fue guardada correctamente", MsgBoxStyle.Information)
                    ElseIf p.TIPO = 10 Then
                        preinforme_calidad(ficha)
                        MsgBox("La ficha fue guardada correctamente", MsgBoxStyle.Information)
                    Else
                        MsgBox("Solo se crean pre informes de Calidad o de Control, la ficha ingresada no es de ninguno de estos dos tipos.", MsgBoxStyle.Exclamation)
                    End If
                Else
                    MsgBox("No existe o no se agrego correctamente a preinformes la ficha", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Debe ingresar un numero de ficha.", MsgBoxStyle.Exclamation)
            End If
            txtFicha.Clear()
        Catch ex As Exception
            MsgBox("Error al ingresar la ficha.", MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub preinforme_calidad(ByVal id_sol As Long)
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
        Dim csm As New dCalidadSolicitudMuestra
        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        '*****************************
        Dim idsol As Long = id_sol 'TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2
        '*********************** ENCABEZADO ************************************************************************
        '***********************************************************************************************************
        'Poner Titulos
        x1hoja.Cells(1, 1).columnwidth = 6 '7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 6 '8
        x1hoja.Cells(1, 12).columnwidth = 6
        x1hoja.Cells(1, 13).columnwidth = 6 '8
        x1hoja.Cells(1, 14).columnwidth = 5
        lista = csm.listarporsolicitud(idsol)
        fila = 15
        columna = 1
        '*** FIN DEL ENCABEZADO************************************************************************************
        '**********************************************************************************************************
        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Rc*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "R Bact.*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lc"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "ST*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Cr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Inh"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Esp.Ana."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Psicro."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Caseína"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Afla.M1"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = 1
        fila = fila + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("A16", "A17").Merge()
        x1hoja.Range("A16", "A17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("A16", "A17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("A16", "A17").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("B16", "B17").Merge()
        x1hoja.Range("B16", "B17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("B16", "B17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("B16", "B17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("C16", "C17").Merge()
        x1hoja.Range("C16", "C17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("C16", "C17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("C16", "C17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 eq. UFC/ml"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("D16", "D17").Merge()
        x1hoja.Range("D16", "D17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("D16", "D17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("D16", "D17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("E16", "E17").Merge()
        x1hoja.Range("E16", "E17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("E16", "E17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("E16", "E17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("F16", "F17").Merge()
        x1hoja.Range("F16", "F17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("F16", "F17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("F16", "F17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("G16", "G17").Merge()
        x1hoja.Range("G16", "G17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("G16", "G17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("G16", "G17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("H16", "H17").Merge()
        x1hoja.Range("H16", "H17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("H16", "H17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("H16", "H17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "(ºC)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("I16", "I17").Merge()
        x1hoja.Range("I16", "I17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("I16", "I17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("I16", "I17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "mg/dl"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("J16", "J17").Merge()
        x1hoja.Range("J16", "J17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("J16", "J17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("J16", "J17").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("K16", "K17").Merge()
        x1hoja.Range("K16", "K17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("K16", "K17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("K16", "K17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "NMP/L"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("L16", "L17").Merge()
        x1hoja.Range("L16", "L17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("L16", "L17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("L16", "L17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1000 UFC/ml UFC/mL "
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("M16", "M17").Merge()
        x1hoja.Range("M16", "M17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("M16", "M17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("M16", "M17").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("N16", "N17").Merge()
        x1hoja.Range("N16", "N17").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("N16", "N17").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("N16", "N17").WrapText = True
        x1hoja.Cells(fila, columna).formula = "ppb"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each csm In lista
                    Dim c As New dCalidad
                    c.FICHA = idsol
                    c.MUESTRA = Trim(csm.MUESTRA)
                    c = c.buscarxfichaxmuestra
                    If csm.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(csm.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.RC = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = c.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            If c.RC < 100 Then
                                'contador_rc = contador_rc + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.RB = 1 Then
                        Dim ibc As New dIbc
                        ibc.FICHA = idsol
                        ibc.MUESTRA = Trim(csm.MUESTRA)
                        ibc = ibc.buscarxfichaxmuestra
                        If Not ibc Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = ibc.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            Dim valgrasa As Double = Val(c.GRASA)
                            If valgrasa < 2 Or valgrasa > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.GRASA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            Dim valproteina As Double = Val(c.PROTEINA)
                            If valproteina < 2 Or valproteina > 3.8 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.PROTEINA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = c.LACTOSA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = c.ST
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.CRIOSCOPIA = 1 Or csm.CRIOSCOPIA_CRIOSCOPO = 1 Then
                        If Not c Is Nothing Then
                            If c.CRIOSCOPIA <> -1 Then
                                Dim valcrioscopia As Double = Val(c.CRIOSCOPIA) * -1 / 1000
                                If valcrioscopia > -0.512 Or valcrioscopia < -0.54 Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                End If
                                x1hoja.Cells(fila, columna).formula = valcrioscopia.ToString("##,##0.000")
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.UREA = 1 Then
                        If Not c Is Nothing Then
                            If c.UREA <> -1 Then
                                Dim valorurea As Integer
                                valorurea = c.UREA * 0.466
                                If valorurea > 20 Or valorurea < 9 Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                End If
                                x1hoja.Cells(fila, columna).formula = valorurea
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    Dim inh As New dInhibidores
                    inh.FICHA = idsol
                    inh.MUESTRA = Trim(csm.MUESTRA)
                    inh = inh.buscarxfichaxmuestra
                    If Not inh Is Nothing Then
                        If inh.RESULTADO = 0 Then
                            x1hoja.Cells(fila, columna).formula = "Negativo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 6
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Positivo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 6
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'ESPORULADOS*******************************************************************************
                    Dim esp As New dEsporulados
                    esp.FICHA = idsol
                    esp.MUESTRA = Trim(csm.MUESTRA)
                    esp = esp.buscarxfichaxmuestra
                    If Not esp Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = esp.RESULTADO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'PSICROTROFOS*******************************************************************************
                    Dim psi As New dPsicrotrofos
                    psi.FICHA = idsol
                    psi.MUESTRA = Trim(csm.MUESTRA)
                    psi = psi.buscarxfichaxmuestra
                    If Not psi Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = psi.PROMEDIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If csm.CASEINA = 1 Then
                        If Not c Is Nothing Then
                            If c.CASEINA <> -1 Then
                                Dim valorcaseina As Double
                                valorcaseina = c.CASEINA
                                x1hoja.Cells(fila, columna).formula = valorcaseina
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'AFLATOXINA M1*******************************************************************************
                    Dim m As New dMicotoxinasLeche
                    m.FICHA = idsol
                    m.MUESTRA = Trim(csm.MUESTRA)
                    m = m.buscarxfichaxmuestra
                    If Not m Is Nothing Then
                        x1hoja.Cells(fila, columna).formula = m.RESULTADO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                    End If
                    columna = 1
                    fila = fila + 1
                Next
                'Referencias
                fila = fila + 1
                columna = 1
            End If
        End If
        'PROTEGE LA HOJA DE EXCEL
        'x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\PREINFORMES\CALIDAD\" & idsol & ".xls")
        'x1hoja.SaveAs("C:\PREINFORMES\CALIDAD\" & idsol & ".xls")
        'Marcar como creado
        Dim preinf As New dPreinformes
        preinf.FICHA = idsol
        preinf.marcarcreado()
        preinf = Nothing
        x1app.Visible = False
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub preinforme_control(ByVal id_sol As Long)
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
        Dim c As New dControl
        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************
        Dim idsol As Long = id_sol 'ficha
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2

        '*** ENCABEZADO ********************************************************************************
        '***********************************************************************************************
        'Poner Titulos
        x1hoja.Cells(1, 1).columnwidth = 5
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 3
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 5
        x1hoja.Cells(1, 14).columnwidth = 5
        x1hoja.Cells(1, 15).columnwidth = 5
        x1hoja.Range("A1", "D1").Merge()
        fila = 15
        columna = 1
        '*** FIN DEL ENCABEZADO ***********************************************************************************
        '**********************************************************************************************************
        lista = c.listarporsolicitud(idsol)
        lista2 = c.listarporrc(idsol)
        x1hoja.Cells(fila, columna).Formula = "Listado ordenado por identificación"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 7
        x1hoja.Cells(fila, columna).Formula = "Listado ordenado decreciente por Recuento celular"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        Dim filaguia As Integer = fila
        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Rc*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lc"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Caseina"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 6
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = 1
        fila = fila + 1
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    If c.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.RC = -1 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        If c.RC < 4 Then
                            x1hoja.Cells(fila, columna).formula = "4"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.RC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    End If
                    If c.GRASA = -1 Or c.GRASA = 0 Then
                        columna = columna - 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valgrasa = Val(c.GRASA)
                        If valgrasa < 2 Or valgrasa > 5.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.GRASA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        Dim valproteina = Val(c.PROTEINA)
                        If valproteina < 2 Or valproteina > 4.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.PROTEINA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = c.LACTOSA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    Dim cs As New dControlSolicitud
                    cs.FICHA = idsol
                    cs = cs.buscar
                    If Not cs Is Nothing Then
                        If cs.UREA = 1 Then
                            If c.UREA = -1 Or c.UREA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                Dim valorurea As Integer
                                valorurea = c.UREA * 0.466
                                If valorurea > 20 Or valorurea < 9 Then
                                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                End If
                                x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If cs.CASEINA = 1 Then
                            If c.CASEINA = -1 Or c.UREA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.CASEINA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    cs = Nothing
                    columna = 1
                    fila = fila + 1
                Next
                'Referencias
                fila = fila + 1
                columna = 1
            End If
            '****** ORDENADO POR RC ************************************************************************
            Dim libreinfeccion As Integer = 0
            Dim posibleinfeccion As Integer = 0
            Dim probableinfeccion As Integer = 0
            fila = filaguia
            columna = 9
            x1hoja.Cells(fila, columna).Formula = "Ident."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Rc*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Gr*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Pr*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Lc"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "MUN"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Caseina"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 6
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = 9
            fila = fila + 1
            If Not lista2 Is Nothing Then
                If lista2.Count > 0 Then
                    For Each c In lista2
                        If c.MUESTRA <> "" Then
                            x1hoja.Cells(fila, columna).formula = Trim(c.MUESTRA)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.RC = -1 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            If c.RC < 4 Then
                                x1hoja.Cells(fila, columna).formula = "4"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.RC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        End If
                        If c.GRASA = -1 Or c.GRASA = 0 Then
                            columna = columna - 1
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).formula = "MUESTRA NO APTA **"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valgrasa = Val(c.GRASA)
                            If valgrasa < 2 Or valgrasa > 5.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.GRASA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            Dim valproteina = Val(c.PROTEINA)
                            If valproteina < 2 Or valproteina > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.PROTEINA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.LACTOSA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        Dim cs As New dControlSolicitud
                        cs.FICHA = idsol
                        cs = cs.buscar
                        If Not cs Is Nothing Then
                            If cs.UREA = 1 Then
                                If c.UREA = -1 Or c.UREA = 0 Then
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna + 1
                                Else
                                    Dim valorurea As Integer
                                    valorurea = c.UREA * 0.466
                                    If valorurea > 20 Or valorurea < 9 Then
                                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                    End If
                                    x1hoja.Cells(fila, columna).formula = FormatNumber(valorurea, 0)
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna + 1
                                End If
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                            If cs.CASEINA = 1 Then
                                If c.CASEINA = -1 Or c.CASEINA = 0 Then
                                    x1hoja.Cells(fila, columna).formula = "-"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna + 1
                                Else
                                    x1hoja.Cells(fila, columna).formula = c.CASEINA
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna + 1
                                End If
                            Else
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            End If
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        cs = Nothing
                        columna = 9
                        fila = fila + 1
                    Next
                    'Referencias
                    fila = fila + 1
                    columna = 1
                End If
            End If
        End If
        'PROTEGE LA HOJA DE EXCEL
        'x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("C:\PREINFORMES\CONTROL\" & idsol & ".xls")
        Dim preinf As New dPreinformes
        preinf.FICHA = id_sol
        preinf.marcarcreado()
        preinf = Nothing
        x1app.Visible = False
        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class