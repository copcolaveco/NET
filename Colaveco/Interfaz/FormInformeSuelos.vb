Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeSuelos
    Private _usuario As dUsuario
    Private idsol As Long = 0
    Private totalprecio As Double = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        listarfichas()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u

    End Sub
#End Region
    Private Sub ButtonGenerarInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerarInforme.Click
        Dim ficha As Long = TextFicha.Text.Trim
        Dim s As New dSolicitudAnalisis

        creainformeexcel()

        s.ID = ficha
        s = s.buscar
        Dim productor As Long = 0
        If Not s Is Nothing Then
            productor = s.IDPRODUCTOR
        End If
        abrirventanaenvio()
        limpiar()
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        listarfichas()
    End Sub
    Private Sub abrirventanaenvio()
        Dim v As New FormSubirInformes2(Usuario)
        v.Show()
    End Sub
    Private Sub listarfichas()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarfichassuelos
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ListFichas().Items.Add(s)
                Next
            End If
        End If
    End Sub
    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        If ListFichas.SelectedItems.Count = 1 Then
            Dim s As dSolicitudAnalisis = CType(ListFichas.SelectedItem, dSolicitudAnalisis)
            TextFicha.Text = s.ID
        End If
    End Sub
   
    Private Sub crearPDF()
        'Dim stream As StreamReader stream = New StreamReader("\\192.168.1.10\E\NET\Suelos\" & idsol & ".xls") 
        'Dim printer As New PrintDocument()
        'printer.PrinterSettings.PrinterName = "doPDF v7"

        '' Convert Word file (DOCX or DOC) to PDF.
        'DocumentModel.Load("Document.doc").Save("Document.pdf")
    End Sub
    Private Sub creainformeexcel()
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

        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim s As New dSuelos
        Dim ss As New dSolicitudSuelos
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList

        Dim informefinal As Integer = 0
        '*****************************

        'Dim idsol As Long = TextFicha.Text.Trim
        idsol = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        lista = s.listarporsolicitud2(idsol)
        lista2 = ss.listarporsolicitud(idsol)

        '*****************************
        x1hoja.Cells(8, 2).formula = sa.ID
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(9, 2).formula = pro.NOMBRE
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(10, 2).formula = pro.DIRECCION
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        Else
            x1hoja.Cells(10, 2).formula = "No aportado"
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        End If

        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")

        x1hoja.Cells(8, 5).formula = sa.FECHAINGRESO
        x1hoja.Cells(8, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 5).Font.Size = 9

        Dim sx As New dSuelos
        Dim listasx As New ArrayList
        listasx = sx.listarfechaproceso(sa.ID)
        If Not listasx Is Nothing Then
            For Each sx In listasx
                x1hoja.Cells(9, 5).formula = sx.FECHAPROCESO
                x1hoja.Cells(9, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(9, 5).Font.Size = 9
            Next
        Else
            x1hoja.Cells(9, 5).formula = fecha2
            x1hoja.Cells(9, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(9, 5).Font.Size = 9
        End If
        sx = Nothing
        x1hoja.Cells(10, 5).formula = fecha2
        x1hoja.Cells(10, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(10, 5).Font.Size = 9

        Dim fila As Integer
        Dim columna As Integer

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 2


                'Poner Titulos
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_suelos.jpg", _
                Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)



                x1hoja.Cells(3, 1).columnwidth = 25
                x1hoja.Cells(3, 2).columnwidth = 13
                x1hoja.Cells(3, 3).columnwidth = 13
                x1hoja.Cells(3, 4).columnwidth = 13
                x1hoja.Cells(3, 5).columnwidth = 13
                x1hoja.Range("A1", "E1").Merge()


                columna = 2
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Range("B4", "C4").Merge()
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Range("A6", "D6").Merge()
                x1hoja.Range("A6", "E6").Merge()
                fila = fila + 3
                columna = 1
               
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE SUELOS"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Cliente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha informe:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "Material recibido:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                Dim texto As String = ""
                Dim texto2 As String = ""
                texto = texto & "Muestra de suelo"
                Dim m_nitratos As Integer = 0
                Dim m_mineralizacion As Integer = 0
                Dim m_fosforobray As Integer = 0
                Dim m_fosforocitrico As Integer = 0
                Dim m_phagua As Integer = 0
                Dim m_phkci As Integer = 0
                Dim m_materiaorg As Integer = 0
                Dim m_potasioint As Integer = 0
                Dim m_sulfatos As Integer = 0
                Dim m_nitrogenoveg As Integer = 0
                Dim m_calcio As Integer = 0
                Dim m_magnesio As Integer = 0
                Dim m_zinc As Integer = 0
                For Each ss In lista2

                    'texto2 = texto2 & "// " & ss.MUESTRA
                    'If ss.FOSFOROBRAY = 1 Then
                    '    texto2 = texto2 & "- Fósforo Bray "
                    'End If
                    'If ss.FOSFOROCITRICO = 1 Then
                    '    texto2 = texto2 & "- Fósoforo cítrico "
                    'End If
                    'If ss.NITRATOS = 1 Then
                    '    texto2 = texto2 & " - Nitratos "
                    'End If
                    'If ss.PHAGUA = 1 Then
                    '    texto2 = texto2 & " - pH Agua "
                    'End If
                    'If ss.PHKCI = 1 Then
                    '    texto2 = texto2 & " - pH KCI "
                    'End If
                    'If ss.POTASIOINT = 1 Then
                    '    texto2 = texto2 & " - Potasio intercambiable "
                    'End If
                    'If ss.SULFATOS = 1 Then
                    '    texto2 = texto2 & " - Sulfatos "
                    'End If
                    'If ss.NITROGENOVEGETAL = 1 Then
                    '    texto2 = texto2 & " - Nitrógeno vegetal "
                    'End If
                    'If ss.MATERIAORG = 1 Then
                    '    texto2 = texto2 & " - Materia orgánica "
                    'End If
                    'If ss.MINERALIZACION = 1 Then
                    '    texto2 = texto2 & " - PMN (Potencial Mineralización de Nitrógeno) "
                    'End If

                    If ss.FOSFOROBRAY = 1 Then
                        m_fosforobray = 1
                    End If
                    If ss.FOSFOROCITRICO = 1 Then
                        m_fosforocitrico = 1
                    End If
                    If ss.NITRATOS = 1 Then
                        m_nitratos = 1
                    End If
                    If ss.PHAGUA = 1 Then
                        m_phagua = 1
                    End If
                    If ss.PHKCI = 1 Then
                        m_phkci = 1
                    End If
                    If ss.POTASIOINT = 1 Then
                        m_potasioint = 1
                    End If
                    If ss.SULFATOS = 1 Then
                        m_sulfatos = 1
                    End If
                    If ss.NITROGENOVEGETAL = 1 Then
                        m_nitrogenoveg = 1
                    End If
                    If ss.MATERIAORG = 1 Then
                        m_materiaorg = 1
                    End If
                    If ss.MINERALIZACION = 1 Then
                        m_mineralizacion = 1
                    End If
                    If ss.CALCIO = 1 Then
                        m_calcio = 1
                    End If
                    If ss.MAGNESIO = 1 Then
                        m_magnesio = 1
                    End If
                    If ss.ZINC = 1 Then
                        m_zinc = 1
                    End If


                Next

                If m_fosforobray = 1 Then
                    texto2 = texto2 & "* Fósforo Bray - "
                End If
                If m_fosforocitrico = 1 Then
                    texto2 = texto2 & "* Fósoforo cítrico - "
                End If
                If m_nitratos = 1 Then
                    texto2 = texto2 & "* Nitratos - "
                End If
                If m_phagua = 1 Then
                    texto2 = texto2 & "* pH Agua - "
                End If
                If m_phkci = 1 Then
                    texto2 = texto2 & "* pH KCI - "
                End If
                If m_potasioint = 1 Then
                    texto2 = texto2 & "* Potasio intercambiable - "
                End If
                If m_sulfatos = 1 Then
                    texto2 = texto2 & "* Sulfatos - "
                End If
                If m_nitrogenoveg = 1 Then
                    texto2 = texto2 & "* Nitrógeno vegetal - "
                End If
                If m_materiaorg = 1 Then
                    texto2 = texto2 & "Materia orgánica - "
                End If
                If m_mineralizacion = 1 Then
                    texto2 = texto2 & "* PMN (Potencial Mineralización de Nitrógeno)"
                End If
                If m_calcio = 1 Then
                    texto2 = texto2 & "* Calcio"
                End If
                If m_magnesio = 1 Then
                    texto2 = texto2 & "* Magnesio"
                End If
                If m_zinc = 1 Then
                    texto2 = texto2 & "* Zinc"
                End If



                'x1hoja.Range("B12", "C13").Merge()
                'x1hoja.Range("B12", "C13").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Estudio solicitado"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1

                x1hoja.Range("B13", "E14").Merge()
                x1hoja.Range("B13", "E14").WrapText = True

                x1hoja.Cells(fila, columna).Formula = texto2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
             
                x1hoja.Cells(fila, columna).Formula = "Se recibieron las siguientes muestras:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & lista2.Count
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                For Each s In lista
                    detallemuestras = detallemuestras & "(" & cuenta & ")" & " " & s.DETALLEMUESTRA & " / "
                    cuenta = cuenta + 1
                    idoperador = s.OPERADOR
                Next
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                cuenta = cuenta - 1
                x1hoja.Range("A16", "E17").Merge()
                x1hoja.Range("A16", "E17").WrapText = True

                x1hoja.Cells(fila, columna).Formula = detallemuestras
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 3


                x1hoja.Cells(fila, columna).Formula = "RESULTADO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                Dim linea As Integer = 0
                Dim i As Integer = 1

                For Each s In lista


                    'MUESTRA 1 ****************************************************************
                    If i = 1 Then
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                           
                            End If
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                       
                            End If
                     
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1

                        End If

                    End If

                    'MUESTRA 2 ****************************************************************
                    If i = 2 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                 
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                 
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                    End If
                    ' MUESTRA 3 ********************************************************************************
                    If i = 3 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                    
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                    
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                    End If
                    ' MUESTRA 4 ******************************************************************************

                    If i = 4 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                     
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 5 ******************************************************************************

                    If i = 5 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                         
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                          
                            End If
                    
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1

                        End If

                    End If

                    'MUESTRA 6 *******************************************************************************
                    If i = 6 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                       
                            End If
                     
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 7 *******************************************************************************

                    If i = 7 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                    
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 8 *******************************************************************************

                    If i = 8 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 9 *******************************************************************************

                    If i = 9 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 10 ******************************************************************************

                    If i = 10 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    'MUESTRA 11 ******************************************************************************

                    If i = 11 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                           
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                    End If
                    'MUESTRA 12 ******************************************************************************

                    If i = 12 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        linea = 0
                    End If
                    'DE LA MUESTRA 13 AL 24 *********/*/*/*/*/*/*/*/*/*/*//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/

                    'MUESTRA 13 ****************************************************************
                    If i = 13 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If

                    'MUESTRA 14 ****************************************************************
                    If i = 14 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                    End If
                    ' MUESTRA 15 ********************************************************************************
                    If i = 15 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    ' MUESTRA 16 ******************************************************************************

                    If i = 16 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    ' MUESTRA 17 ******************************************************************************

                    If i = 17 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                  
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                         
                            End If
                   
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If


                    End If

                    'MUESTRA 18 *******************************************************************************
                    If i = 18 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                           
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 19 *******************************************************************************

                    If i = 19 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If



                    End If
                    'MUESTRA 20 *******************************************************************************

                    If i = 20 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    'MUESTRA 21 *******************************************************************************

                    If i = 21 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 22 ******************************************************************************

                    If i = 22 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 23 ******************************************************************************

                    If i = 23 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                    End If
                    'MUESTRA 24 ******************************************************************************

                    If i = 24 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                    
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        linea = 0
                    End If
                    'DE LA MUESTRA 25 AL 36 *********/*/*/*/*/*/*/*/*/*/*//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


                    'MUESTRA 25 ****************************************************************
                    If i = 25 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                 
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
              
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                           
                            End If
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If

                    'MUESTRA 26 ****************************************************************
                    If i = 26 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                       
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 27 ********************************************************************************
                    If i = 27 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 28 ******************************************************************************

                    If i = 28 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 29 ******************************************************************************

                    If i = 29 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                  
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                           
                            End If
                    
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If


                    End If

                    'MUESTRA 30 *******************************************************************************
                    If i = 30 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 31 *******************************************************************************

                    If i = 31 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If



                    End If
                    'MUESTRA 32 *******************************************************************************

                    If i = 32 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    'MUESTRA 33 *******************************************************************************

                    If i = 33 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                          
                            End If
                    
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 34 ******************************************************************************

                    If i = 34 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                     
                            End If
                   
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    'MUESTRA 35 ******************************************************************************

                    If i = 35 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 36 ******************************************************************************

                    If i = 36 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        linea = 0
                    End If
                    'DE LA MUESTRA 37 AL 48 *********/*/*/*/*/*/*/*/*/*/*//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


                    'MUESTRA 37 ****************************************************************
                    If i = 37 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If

                    'MUESTRA 38 ****************************************************************
                    If i = 38 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 39 ********************************************************************************
                    If i = 39 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                 
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
              
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                       
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 40 ******************************************************************************

                    If i = 40 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                           
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 41 ******************************************************************************

                    If i = 41 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                   
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                  
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If


                    End If

                    'MUESTRA 42 *******************************************************************************
                    If i = 42 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 43 *******************************************************************************

                    If i = 43 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 44 *******************************************************************************

                    If i = 44 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 45 *******************************************************************************

                    If i = 45 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                 
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 46 ******************************************************************************

                    If i = 46 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    'MUESTRA 47 ******************************************************************************

                    If i = 47 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 48 ******************************************************************************

                    If i = 48 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                           
                            End If
                       
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        linea = 0
                    End If
                    'DE LA MUESTRA 49 AL 60 *********/*/*/*/*/*/*/*/*/*/*//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


                    'MUESTRA 49 ****************************************************************
                    If i = 49 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                    
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                         
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If

                    'MUESTRA 50 ****************************************************************
                    If i = 50 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                      
                            End If
                   
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 51 ********************************************************************************
                    If i = 51 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                 
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 52 ******************************************************************************

                    If i = 52 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
               
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                  
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 53 ******************************************************************************

                    If i = 53 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
              
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                          
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If

                    'MUESTRA 54 *******************************************************************************
                    If i = 54 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 55 *******************************************************************************

                    If i = 55 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                          
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 56 *******************************************************************************

                    If i = 56 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                   
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                        
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 57 *******************************************************************************

                    If i = 57 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
               
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Azufre en suelos (mg S/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                     
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                       
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                    
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "* % SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "* Zinc"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 58 ******************************************************************************

                    If i = 58 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                    
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                         
                            End If
                      
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 59 ******************************************************************************

                    If i = 59 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                     
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                       
                            End If
                     
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 60 ******************************************************************************

                    If i = 60 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                 
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                      
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                       
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.CIC <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.CIC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            
                            End If
                        
                        End If
                        If s.ACIDEZTITULABLE <> "-1" Then
                            If s.SB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = s.SB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If

                        If s.ZINC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ZINC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If

                    '*****************************************************************************************
                    i = i + 1


                Next

                '***************************************
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "N/R = No requerido"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True

                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Métodos utilizados:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* Fósforo Bray I: Bray, Kurtz - Espectrofotométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* Fósforo Cítrico: INIA La Estanzuela. Lab. de Suelos - Espectrofotométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* Nitratos: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* pH Agua: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* pH KCI: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* Potasio intercambiable: INIA La Estanzuela. Lab. de Suelos - Espectrometría atómica"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* Sulfatos: IAC Brasil - Turbidimetría"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "M. O.: % Materia Orgánica - ISO 10694"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* Nitrógeno vegetal: Dumas AOAC 968.06 modif.LECO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Carbono y materia orgánica: Combustión a 950ºC y detección de CO2 por infrarrojo - Método interno PE.LAB.86 v03"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "* PMN(Potencial mineralización de Nitrógeno): INIA La Estanzuela. Lab. de Suelos - Incubación anaeróbica"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "(*)Ensayo no acreditado ISO 17.025 O.U.A."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True




                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Operador: " & operador
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1


                fila = fila + 1
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES & " - " & "(Todos los resultados son expresados en suelo seco)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                End If
                fila = fila + 1



                '******* CALCULO PRECIO ************************************************************************

                'Dim listamuestras As New ArrayList
                'listamuestras = s.listarporid(idsol)

                'Dim ana As New dAnalisis

                'Dim idtimbre As Integer = 86
                'Dim idfosforobray As Integer = 131
                'Dim idfosforocitrico As Integer = 132
                'Dim idnitratos As Integer = 133
                'Dim idphagua As Integer = 134
                'Dim idphkci As Integer = 135
                'Dim idpotasio As Integer = 136
                'Dim idsulfatos As Integer = 137
                'Dim idnitrogenovegetal As Integer = 138
                'Dim idmateriaorganica As Integer = 139
                'Dim idpmn As Integer = 140
                'Dim idpaq1 As Integer = 142
                'Dim idpaq2 As Integer = 143
                'Dim idpaq3 As Integer = 144
                'Dim idpaq4 As Integer = 145
                'Dim idpaq5 As Integer = 189
                'Dim idmuestreo As Integer = 236
                'Dim idzinc As Integer = 192
                'Dim idisusaestandar As Integer = 194
                'Dim idisusazinc As Integer = 195
                'Dim preciotimbre As Double = 0
                'Dim preciofosforobray As Double = 0
                'Dim preciofosforcitrico As Double = 0
                'Dim precionitratos As Double = 0
                'Dim preciophagua As Double = 0
                'Dim preciophkci As Double = 0
                'Dim preciopotasio As Double = 0
                'Dim preciosulfatos As Double = 0
                'Dim precionitrogenovegetal As Double = 0
                'Dim preciomateriaorganica As Double = 0
                'Dim preciopmn As Double = 0
                'Dim preciopaq1 As Double = 0
                'Dim preciopaq2 As Double = 0
                'Dim preciopaq3 As Double = 0
                'Dim preciopaq4 As Double = 0
                'Dim preciopaq5 As Double = 0
                'Dim preciomuestreo As Double = 0
                'Dim preciozinc As Double = 0
                'Dim precioisusaestandar As Double = 0
                'Dim precioisusazinc As Double = 0

                'ana.ID = idtimbre
                'ana = ana.buscar
                'preciotimbre = ana.COSTO
                'ana.ID = idfosforobray
                'ana = ana.buscar
                'preciofosforobray = ana.COSTO
                'ana.ID = idfosforocitrico
                'ana = ana.buscar
                'preciofosforcitrico = ana.COSTO
                'ana.ID = idnitratos
                'ana = ana.buscar
                'precionitratos = ana.COSTO
                'ana.ID = idphagua
                'ana = ana.buscar
                'preciophagua = ana.COSTO
                'ana.ID = idphkci
                'ana = ana.buscar
                'preciophkci = ana.COSTO
                'ana.ID = idpotasio
                'ana = ana.buscar
                'preciopotasio = ana.COSTO
                'ana.ID = idsulfatos
                'ana = ana.buscar
                'preciosulfatos = ana.COSTO
                'ana.ID = idnitrogenovegetal
                'ana = ana.buscar
                'precionitrogenovegetal = ana.COSTO
                'ana.ID = idmateriaorganica
                'ana = ana.buscar
                'preciomateriaorganica = ana.COSTO
                'ana.ID = idpmn
                'ana = ana.buscar
                'preciopmn = ana.COSTO
                'ana.ID = idpaq1
                'ana = ana.buscar
                'preciopaq1 = ana.COSTO
                'ana.ID = idpaq2
                'ana = ana.buscar
                'preciopaq2 = ana.COSTO
                'ana.ID = idpaq3
                'ana = ana.buscar
                'preciopaq3 = ana.COSTO
                'ana.ID = idpaq4
                'ana = ana.buscar
                'preciopaq4 = ana.COSTO
                'ana.ID = idpaq5
                'ana = ana.buscar
                'preciopaq5 = ana.COSTO
                'ana.ID = idmuestreo
                'ana = ana.buscar
                'preciomuestreo = ana.COSTO
                'ana.ID = idzinc
                'ana = ana.buscar
                'preciozinc = ana.COSTO
                'ana.ID = idisusaestandar
                'ana = ana.buscar
                'precioisusaestandar = ana.COSTO
                'ana.ID = idisusazinc
                'ana = ana.buscar
                'precioisusazinc = ana.COSTO

                'Dim total As Double = 0
                Dim ss2 As New dSolicitudSuelos
                Dim lista3 As New ArrayList
                lista3 = ss2.listarporsolicitud(idsol)

                'For Each ss2 In lista3
                '    If ss2.PAQUETE = 0 Then
                '        If ss2.FOSFOROBRAY = 1 Then
                '            total = total + preciofosforobray
                '        End If
                '        If ss2.FOSFOROCITRICO = 1 Then
                '            total = total + preciofosforcitrico
                '        End If
                '        If ss2.NITRATOS = 1 Then
                '            total = total + precionitratos
                '        End If
                '        If ss2.PHAGUA = 1 Then
                '            total = total + preciophagua
                '        End If
                '        If ss2.PHKCI = 1 Then
                '            total = total + preciophkci
                '        End If
                '        If ss2.POTASIOINT = 1 Then
                '            total = total + preciopotasio
                '        End If
                '        If ss2.SULFATOS = 1 Then
                '            total = total + preciosulfatos
                '        End If
                '        If ss2.NITROGENOVEGETAL = 1 Then
                '            total = total + precionitrogenovegetal
                '        End If
                '        If ss2.MATERIAORG = 1 Then
                '            total = total + preciomateriaorganica
                '        End If
                '        If ss2.MINERALIZACION = 1 Then
                '            total = total + preciopmn
                '        End If
                '        If ss2.ZINC = 1 Then
                '            total = total + preciozinc
                '        End If
                '    End If
                '    If ss2.PAQUETE = 1 Then
                '        total = total + preciopaq1
                '        If ss2.FOSFOROCITRICO = 1 Then
                '            total = total + preciofosforcitrico
                '        End If
                '        If ss2.PHKCI = 1 Then
                '            total = total + preciophkci
                '        End If
                '        If ss2.SULFATOS = 1 Then
                '            total = total + preciosulfatos
                '        End If
                '        If ss2.NITROGENOVEGETAL = 1 Then
                '            total = total + precionitrogenovegetal
                '        End If
                '        If ss2.MINERALIZACION = 1 Then
                '            total = total + preciopmn
                '        End If
                '        If ss2.ZINC = 1 Then
                '            total = total + preciozinc
                '        End If
                '    End If
                '    If ss2.PAQUETE = 2 Then
                '        total = total + preciopaq2
                '        If ss2.FOSFOROCITRICO = 1 Then
                '            total = total + preciofosforcitrico
                '        End If
                '        If ss2.NITRATOS = 1 Then
                '            total = total + precionitratos
                '        End If
                '        If ss2.PHKCI = 1 Then
                '            total = total + preciophkci
                '        End If
                '        If ss2.NITROGENOVEGETAL = 1 Then
                '            total = total + precionitrogenovegetal
                '        End If
                '        If ss2.MATERIAORG = 1 Then
                '            total = total + preciomateriaorganica
                '        End If
                '        If ss2.MINERALIZACION = 1 Then
                '            total = total + preciopmn
                '        End If
                '        If ss2.ZINC = 1 Then
                '            total = total + preciozinc
                '        End If
                '    End If
                '    If ss2.PAQUETE = 3 Then
                '        total = total + preciopaq3
                '        If ss2.FOSFOROCITRICO = 1 Then
                '            total = total + preciofosforcitrico
                '        End If
                '        If ss2.PHKCI = 1 Then
                '            total = total + preciophkci
                '        End If
                '        If ss2.SULFATOS = 1 Then
                '            total = total + preciosulfatos
                '        End If
                '        If ss2.NITROGENOVEGETAL = 1 Then
                '            total = total + precionitrogenovegetal
                '        End If
                '        If ss2.MATERIAORG = 1 Then
                '            total = total + preciomateriaorganica
                '        End If
                '        If ss2.MINERALIZACION = 1 Then
                '            total = total + preciopmn
                '        End If
                '        If ss2.ZINC = 1 Then
                '            total = total + preciozinc
                '        End If
                '    End If
                '    If ss2.PAQUETE = 4 Then
                '        total = total + preciopaq4
                '        If ss2.FOSFOROBRAY = 1 Then
                '            total = total + preciofosforobray
                '        End If
                '        If ss2.FOSFOROCITRICO = 1 Then
                '            total = total + preciofosforcitrico
                '        End If
                '        If ss2.NITRATOS = 1 Then
                '            total = total + precionitratos
                '        End If
                '        If ss2.PHAGUA = 1 Then
                '            total = total + preciophagua
                '        End If
                '        If ss2.PHKCI = 1 Then
                '            total = total + preciophkci
                '        End If

                '        If ss2.SULFATOS = 1 Then
                '            total = total + preciosulfatos
                '        End If
                '        If ss2.NITROGENOVEGETAL = 1 Then
                '            total = total + precionitrogenovegetal
                '        End If
                '        If ss2.MATERIAORG = 1 Then
                '            total = total + preciomateriaorganica
                '        End If
                '        If ss2.MINERALIZACION = 1 Then
                '            total = total + preciopmn
                '        End If
                '        If ss2.ZINC = 1 Then
                '            total = total + preciozinc
                '        End If
                '    End If
                '    If ss2.PAQUETE = 5 Then
                '        total = total + preciopaq5
                '        If ss2.FOSFOROCITRICO = 1 Then
                '            total = total + preciofosforcitrico
                '        End If
                '        If ss2.NITRATOS = 1 Then
                '            total = total + precionitratos
                '        End If
                '        If ss2.PHKCI = 1 Then
                '            total = total + preciophkci
                '        End If
                '        If ss2.SULFATOS = 1 Then
                '            total = total + preciosulfatos
                '        End If
                '        If ss2.NITROGENOVEGETAL = 1 Then
                '            total = total + precionitrogenovegetal
                '        End If
                '        If ss2.MINERALIZACION = 1 Then
                '            total = total + preciopmn
                '        End If
                '        If ss2.ZINC = 1 Then
                '            total = total + preciozinc
                '        End If
                '    End If
                '    If ss2.PAQUETE = 6 Then
                '        If ss2.ISUSAESTANDAR = 1 Then
                '            total = total + precioisusaestandar
                '        End If
                '        If ss2.ISUSAZINC = 1 Then
                '            total = total + precioisusazinc
                '        End If
                '    End If
                '    If ss2.MUESTREO = 1 Then
                '        'total = total + preciomuestreo
                '        Dim sakm As New dSolicitudAnalisis
                '        sakm.ID = idsol
                '        sakm = sakm.buscar
                '        If Not sakm Is Nothing Then
                '            If sakm.KMTS > 0 Then
                '                Dim viatico As Double = 0
                '                viatico = preciomuestreo * sakm.KMTS
                '                total = total + viatico
                '            End If
                '        End If
                '    End If


                'Next

                'total = Math.Round(total + preciotimbre, 2)
                factura_suelos()


                '/* Actualiza el importe en la solicitud 
                Dim saimp As New dSolicitudAnalisis
                Dim importesa As Double = totalprecio
                saimp.ID = idsol
                saimp.actualizarimporte(importesa)
                '***************************************/

                '***********************************************************************************************
                'If ss2.MUESTREO = 1 Then
                '    x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & totalprecio & " (Timbre y muestreo incluído)"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Font.Bold = True
                '    columna = columna + 3
                'Else
                '    x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & totalprecio & " (Timbre incluído)"
                '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                '    x1hoja.Cells(fila, columna).Font.Size = 8
                '    x1hoja.Cells(fila, columna).Font.Bold = True
                '    columna = columna + 3
                'End If
               
                x1hoja.Cells(fila, columna).formula = "Técnico resp:" & "Ing. Ag. Victor González"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = 1
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y Timbre de la CJPPU"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 3
                'x1hoja.Cells(fila, columna).formula = "Colaborador: Alejandro Morón"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Convenio FCA UDE - Colaveco"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True

                columna = 1
                fila = fila + 2
                '**********************************************************

                x1libro.Worksheets(1).cells(fila, columna).select()
                Dim rangeFirma As String = "A" + fila.ToString
                x1libro.ActiveSheet.Range(rangeFirma).select()
                InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 5
                x1hoja.Cells(fila, columna).formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6

                fila = fila + 1
                x1hoja.Range("A" & fila, "E" & fila).Merge()
                x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
                x1hoja.Cells(fila, columna).rowheight = 8
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
                x1hoja.Cells(fila, columna).Formula = "Fin del informe."
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 7


            End If
        End If

        'Insert tabla preinformes
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = idsol
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = idsol
            pi2.TIPO = 14
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '************************************


        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\Suelos\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\Suelos\" & idsol & ".xls")

        x1app.Visible = True
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub


    Sub InsertImageToDeclaredVariable(ByVal x1libro As Microsoft.Office.Interop.Excel.Workbook, ByVal rangeFirma As String, ByVal imagePath As String)

        Dim myImage As Shape
        Dim ws As Microsoft.Office.Interop.Excel.Worksheet

        ws = x1libro.ActiveSheet
        myImage = ws.Shapes.AddPicture( _
            Filename:=imagePath, _
            LinkToFile:=Microsoft.Office.Core.MsoTriState.msoFalse, _
            SaveWithDocument:=Microsoft.Office.Core.MsoTriState.msoCTrue, _
            Left:=0, _
            Top:=0, _
            Width:=-1, _
            Height:=-1)
        myImage.Left = x1libro.ActiveSheet.Range(rangeFirma).Left
        myImage.Top = x1libro.ActiveSheet.Range(rangeFirma).Top
    End Sub

    Private Sub creainformeexcel2()
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

        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim s As New dSuelos
        Dim ss As New dSolicitudSuelos
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList

        Dim informefinal As Integer = 0
        '*****************************

        'Dim idsol As Long = TextFicha.Text.Trim
        idsol = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        lista = s.listarporsolicitud2(idsol)
        lista2 = ss.listarporsolicitud(idsol)

        '*****************************
        x1hoja.Cells(8, 2).formula = sa.ID
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(9, 2).formula = pro.NOMBRE
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(10, 2).formula = pro.DIRECCION
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        Else
            x1hoja.Cells(10, 2).formula = "No aportado"
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        End If

        x1hoja.Cells(8, 5).formula = sa.FECHAINGRESO
        x1hoja.Cells(8, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 5).Font.Size = 9

        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(9, 5).formula = fecha2
        x1hoja.Cells(9, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 5).Font.Size = 9

        Dim fila As Integer
        Dim columna As Integer

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 2


                'Poner Titulos
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_suelos.jpg", _
                Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)



                x1hoja.Cells(3, 1).columnwidth = 25
                x1hoja.Cells(3, 2).columnwidth = 13
                x1hoja.Cells(3, 3).columnwidth = 13
                x1hoja.Cells(3, 4).columnwidth = 13 '32
                x1hoja.Cells(3, 5).columnwidth = 13
                x1hoja.Range("A1", "E1").Merge()


                columna = 2
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Range("B4", "C4").Merge()
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Range("A6", "D6").Merge()
                x1hoja.Range("A6", "E6").Merge()
                fila = fila + 3
                columna = 1

                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE SUELOS"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Cliente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha informe:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "Material recibido:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                Dim texto As String = ""
                Dim texto2 As String = ""
                texto = texto & "Muestra de suelo"
                Dim m_nitratos As Integer = 0
                Dim m_mineralizacion As Integer = 0
                Dim m_fosforobray As Integer = 0
                Dim m_fosforocitrico As Integer = 0
                Dim m_phagua As Integer = 0
                Dim m_phkci As Integer = 0
                Dim m_materiaorg As Integer = 0
                Dim m_potasioint As Integer = 0
                Dim m_sulfatos As Integer = 0
                Dim m_nitrogenoveg As Integer = 0
                Dim m_calcio As Integer = 0
                Dim m_magnesio As Integer = 0
                Dim m_zinc As Integer = 0
                For Each ss In lista2

                    If ss.FOSFOROBRAY = 1 Then
                        m_fosforobray = 1
                    End If
                    If ss.FOSFOROCITRICO = 1 Then
                        m_fosforocitrico = 1
                    End If
                    If ss.NITRATOS = 1 Then
                        m_nitratos = 1
                    End If
                    If ss.PHAGUA = 1 Then
                        m_phagua = 1
                    End If
                    If ss.PHKCI = 1 Then
                        m_phkci = 1
                    End If
                    If ss.POTASIOINT = 1 Then
                        m_potasioint = 1
                    End If
                    If ss.SULFATOS = 1 Then
                        m_sulfatos = 1
                    End If
                    If ss.NITROGENOVEGETAL = 1 Then
                        m_nitrogenoveg = 1
                    End If
                    If ss.MATERIAORG = 1 Then
                        m_materiaorg = 1
                    End If
                    If ss.MINERALIZACION = 1 Then
                        m_mineralizacion = 1
                    End If
                    If ss.CALCIO = 1 Then
                        m_calcio = 1
                    End If
                    If ss.MAGNESIO = 1 Then
                        m_magnesio = 1
                    End If
                    If ss.ZINC = 1 Then
                        m_zinc = 1
                    End If
                Next

                If m_fosforobray = 1 Then
                    texto2 = texto2 & "Fósforo Bray - "
                End If
                If m_fosforocitrico = 1 Then
                    texto2 = texto2 & "Fósoforo cítrico - "
                End If
                If m_nitratos = 1 Then
                    texto2 = texto2 & "Nitratos - "
                End If
                If m_phagua = 1 Then
                    texto2 = texto2 & "pH Agua - "
                End If
                If m_phkci = 1 Then
                    texto2 = texto2 & "pH KCI - "
                End If
                If m_potasioint = 1 Then
                    texto2 = texto2 & "Potasio intercambiable - "
                End If
                If m_sulfatos = 1 Then
                    texto2 = texto2 & "Sulfatos - "
                End If
                If m_nitrogenoveg = 1 Then
                    texto2 = texto2 & "Nitrógeno vegetal - "
                End If
                If m_materiaorg = 1 Then
                    texto2 = texto2 & "Materia orgánica - "
                End If
                If m_mineralizacion = 1 Then
                    texto2 = texto2 & "PMN (Potencial Mineralización de Nitrógeno)"
                End If
                If m_calcio = 1 Then
                    texto2 = texto2 & "Calcio"
                End If
                If m_magnesio = 1 Then
                    texto2 = texto2 & "Magnesio"
                End If
                If m_zinc = 1 Then
                    texto2 = texto2 & "Zinc"
                End If



                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Estudio solicitado"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1

                x1hoja.Range("B13", "E14").Merge()
                x1hoja.Range("B13", "E14").WrapText = True

                x1hoja.Cells(fila, columna).Formula = texto2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "Se recibieron las siguientes muestras:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & lista2.Count
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                For Each s In lista
                    detallemuestras = detallemuestras & "(" & cuenta & ")" & " " & s.DETALLEMUESTRA & " / "
                    cuenta = cuenta + 1
                    idoperador = s.OPERADOR
                Next
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                cuenta = cuenta - 1
                x1hoja.Range("A16", "E17").Merge()
                x1hoja.Range("A16", "E17").WrapText = True

                x1hoja.Cells(fila, columna).Formula = detallemuestras
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 3


                x1hoja.Cells(fila, columna).Formula = "RESULTADO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                For Each s In lista
                    x1hoja.Cells(fila, columna).Formula = "Análisis"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    columna = columna + 1
                    'x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                    x1hoja.Cells(fila, columna).Formula = s.MUESTRA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                    columna = columna - 1
                    If s.FOSFOROBRAY <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.FOSFOROCITRICO <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.NITRATOS <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.PHAGUA <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "pH Agua"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.PHKCI <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "pH KCI"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.PHKCI
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.POTASIOINT <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.SULFATOS <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Azufre en suelos (mg S/Kg)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.NITROGENOVEGETAL <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.MATERIAORGANICA <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "M. O. (g/100g suelo seco)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.PMN <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.PMN
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.CALCIO <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Calcio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.CALCIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.MAGNESIO <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Magnesio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.SODIO <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Sodio"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.SODIO
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.ACIDEZTITULABLE <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                    If s.ACIDEZTITULABLE <> "-1" Then
                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                        End If
                    End If
                    If s.ACIDEZTITULABLE <> "-1" Then
                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                        End If
                    End If
                    If s.ZINC <> "-1" Then
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Zinc"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = s.ZINC
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                    End If
                Next

                '***************************************
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "N/R = No requerido"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True

                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Métodos utilizados:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Fósforo Bray I: Bray, Kurtz - Espectrofotométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Fósforo Cítrico: INIA La Estanzuela. Lab. de Suelos - Espectrofotométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nitratos: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "pH Agua: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "pH KCI: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Potasio intercambiable: INIA La Estanzuela. Lab. de Suelos - Espectrometría atómica"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Sulfatos: IAC Brasil - Turbidimetría"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "M. O.: % Materia Orgánica - ISO 10694"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nitrógeno vegetal: Dumas AOAC 968.06 modif.LECO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Carbono y materia orgánica: Combustión a 950ºC y detección de CO2 por infrarrojo - Método interno PE.LAB.86 v03"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "PMN(Potencial mineralización de Nitrógeno): INIA La Estanzuela. Lab. de Suelos - Incubación anaeróbica"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False



                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Operador: " & operador
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1


                fila = fila + 1
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES & " - " & "(Todos los resultados son expresados en suelo seco)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                End If
                fila = fila + 1



                '******* CALCULO PRECIO ************************************************************************

                Dim listamuestras As New ArrayList
                listamuestras = s.listarporid(idsol)
                Dim total As Double = 0
                Dim ss2 As New dSolicitudSuelos












                '/* Actualiza el importe en la solicitud 
                Dim saimp As New dSolicitudAnalisis
                Dim importesa As Double = total
                saimp.ID = idsol
                saimp.actualizarimporte(importesa)
                '***************************************/

                '***********************************************************************************************
                If ss2.MUESTREO = 1 Then
                    x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre y muestreo incluído)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = columna + 3
                Else
                    x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = columna + 3
                End If

                x1hoja.Cells(fila, columna).formula = "Técnico resp:" & "Ing. Ag. Victor González"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y Timbre de la CJPPU"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 3
                'x1hoja.Cells(fila, columna).formula = "Colaborador: Alejandro Morón"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Convenio FCA UDE - Colaveco"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True

                columna = 1
                fila = fila + 2
                '**********************************************************

                x1libro.Worksheets(1).cells(fila, columna).select()
                Dim rangeFirma As String = "A" + fila.ToString
                x1libro.ActiveSheet.Range(rangeFirma).select()
                InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 5
                x1hoja.Cells(fila, columna).formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dra. Cecilia Abelenda (Directora Técnica)."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6



            End If
        End If

        'Insert tabla preinformes
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = idsol
        pi = pi.buscar
        If Not pi Is Nothing Then
        Else
            Dim pi2 As New dPreinformes
            pi2.FICHA = idsol
            pi2.TIPO = 14
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '************************************


        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\Suelos\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\Suelos\" & idsol & ".xls")

        x1app.Visible = True
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub factura_suelos()
        Dim ficha As Long = 0
        ficha = idsol


        Dim lp As New dListaPrecios

        Dim idfosforobray As Integer = 131
        Dim idfosforocitrico As Integer = 132
        Dim idnitratos As Integer = 133
        Dim idphagua As Integer = 134
        Dim idphkci As Integer = 135
        Dim idpotasio As Integer = 136
        Dim idsulfatos As Integer = 137
        Dim idnitrogenovegetal As Integer = 138
        Dim idmateriaorganica As Integer = 139
        Dim idpmn As Integer = 140
        Dim idpaq1 As Integer = 142
        Dim idpaq2 As Integer = 143
        Dim idpaq3 As Integer = 144
        Dim idpaq4 As Integer = 145
        Dim idpaq5 As Integer = 189
        Dim idmuestreo As Integer = 236
        Dim idzinc As Integer = 192
        Dim idtimbre As Integer = 86

        Dim preciofosforobray As Double = 0
        Dim preciofosforcitrico As Double = 0
        Dim precionitratos As Double = 0
        Dim preciophagua As Double = 0
        Dim preciophkci As Double = 0
        Dim preciopotasio As Double = 0
        Dim preciosulfatos As Double = 0
        Dim precionitrogenovegetal As Double = 0
        Dim preciomateriaorganica As Double = 0
        Dim preciopmn As Double = 0
        Dim preciopaq1 As Double = 0
        Dim preciopaq2 As Double = 0
        Dim preciopaq3 As Double = 0
        Dim preciopaq4 As Double = 0
        Dim preciopaq5 As Double = 0
        Dim preciomuestreo As Double = 0
        Dim preciozinc As Double = 0
        Dim preciotimbre As Double = 0

        Dim sa As New dSolicitudAnalisis
        sa.ID = idsol
        sa = sa.buscar

        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = sa.IDPRODUCTOR
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If

        If precio = 1 Then
            lp.ID = idfosforobray
            lp = lp.buscar
            preciofosforobray = lp.PRECIO1
            lp.ID = idfosforocitrico
            lp = lp.buscar
            preciofosforcitrico = lp.PRECIO1
            lp.ID = idnitratos
            lp = lp.buscar
            precionitratos = lp.PRECIO1
            lp.ID = idphagua
            lp = lp.buscar
            preciophagua = lp.PRECIO1
            lp.ID = idphkci
            lp = lp.buscar
            preciophkci = lp.PRECIO1
            lp.ID = idpotasio
            lp = lp.buscar
            preciopotasio = lp.PRECIO1
            lp.ID = idsulfatos
            lp = lp.buscar
            preciosulfatos = lp.PRECIO1
            lp.ID = idnitrogenovegetal
            lp = lp.buscar
            precionitrogenovegetal = lp.PRECIO1
            lp.ID = idmateriaorganica
            lp = lp.buscar
            preciomateriaorganica = lp.PRECIO1
            lp.ID = idpmn
            lp = lp.buscar
            preciopmn = lp.PRECIO1
            lp.ID = idpaq1
            lp = lp.buscar
            preciopaq1 = lp.PRECIO1
            lp.ID = idpaq2
            lp = lp.buscar
            preciopaq2 = lp.PRECIO1
            lp.ID = idpaq3
            lp = lp.buscar
            preciopaq3 = lp.PRECIO1
            lp.ID = idpaq4
            lp = lp.buscar
            preciopaq4 = lp.PRECIO1
            lp.ID = idpaq5
            lp = lp.buscar
            preciopaq5 = lp.PRECIO1
            lp.ID = idmuestreo
            lp = lp.buscar
            preciomuestreo = lp.PRECIO1
            lp.ID = idzinc
            lp = lp.buscar
            preciozinc = lp.PRECIO1
            lp.ID = idtimbre
            lp = lp.buscar
            preciotimbre = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idfosforobray
            lp = lp.buscar
            preciofosforobray = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofosforobray = lp.PRECIO1
            End If
            lp.ID = idfosforocitrico
            lp = lp.buscar
            preciofosforcitrico = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofosforcitrico = lp.PRECIO1
            End If
            lp.ID = idnitratos
            lp = lp.buscar
            precionitratos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precionitratos = lp.PRECIO1
            End If
            lp.ID = idphagua
            lp = lp.buscar
            preciophagua = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciophagua = lp.PRECIO1
            End If
            lp.ID = idphkci
            lp = lp.buscar
            preciophkci = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciophkci = lp.PRECIO1
            End If
            lp.ID = idpotasio
            lp = lp.buscar
            preciopotasio = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopotasio = lp.PRECIO1
            End If
            lp.ID = idsulfatos
            lp = lp.buscar
            preciosulfatos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciosulfatos = lp.PRECIO1
            End If
            lp.ID = idnitrogenovegetal
            lp = lp.buscar
            precionitrogenovegetal = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precionitrogenovegetal = lp.PRECIO1
            End If
            lp.ID = idmateriaorganica
            lp = lp.buscar
            preciomateriaorganica = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomateriaorganica = lp.PRECIO1
            End If
            lp.ID = idpmn
            lp = lp.buscar
            preciopmn = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopmn = lp.PRECIO1
            End If
            lp.ID = idpaq1
            lp = lp.buscar
            preciopaq1 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq1 = lp.PRECIO1
            End If
            lp.ID = idpaq2
            lp = lp.buscar
            preciopaq2 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq2 = lp.PRECIO1
            End If
            lp.ID = idpaq3
            lp = lp.buscar
            preciopaq3 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq3 = lp.PRECIO1
            End If
            lp.ID = idpaq4
            lp = lp.buscar
            preciopaq4 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq4 = lp.PRECIO1
            End If
            lp.ID = idpaq5
            lp = lp.buscar
            preciopaq5 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaq5 = lp.PRECIO1
            End If
            lp.ID = idmuestreo
            lp = lp.buscar
            preciomuestreo = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomuestreo = lp.PRECIO1
            End If
            lp.ID = idzinc
            lp = lp.buscar
            preciozinc = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciozinc = lp.PRECIO1
            End If
            lp.ID = idtimbre
            lp = lp.buscar
            preciotimbre = lp.PRECIO1
        ElseIf precio = 3 Then
            lp.ID = idfosforobray
            lp = lp.buscar
            preciofosforobray = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofosforobray = lp.PRECIO1
            End If
            lp.ID = idfosforocitrico
            lp = lp.buscar
            preciofosforcitrico = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofosforcitrico = lp.PRECIO1
            End If
            lp.ID = idnitratos
            lp = lp.buscar
            precionitratos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precionitratos = lp.PRECIO1
            End If
            lp.ID = idphagua
            lp = lp.buscar
            preciophagua = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciophagua = lp.PRECIO1
            End If
            lp.ID = idphkci
            lp = lp.buscar
            preciophkci = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciophkci = lp.PRECIO1
            End If
            lp.ID = idpotasio
            lp = lp.buscar
            preciopotasio = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopotasio = lp.PRECIO1
            End If
            lp.ID = idsulfatos
            lp = lp.buscar
            preciosulfatos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciosulfatos = lp.PRECIO1
            End If
            lp.ID = idnitrogenovegetal
            lp = lp.buscar
            precionitrogenovegetal = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precionitrogenovegetal = lp.PRECIO1
            End If
            lp.ID = idmateriaorganica
            lp = lp.buscar
            preciomateriaorganica = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomateriaorganica = lp.PRECIO1
            End If
            lp.ID = idpmn
            lp = lp.buscar
            preciopmn = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopmn = lp.PRECIO1
            End If
            lp.ID = idpaq1
            lp = lp.buscar
            preciopaq1 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq1 = lp.PRECIO1
            End If
            lp.ID = idpaq2
            lp = lp.buscar
            preciopaq2 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq2 = lp.PRECIO1
            End If
            lp.ID = idpaq3
            lp = lp.buscar
            preciopaq3 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq3 = lp.PRECIO1
            End If
            lp.ID = idpaq4
            lp = lp.buscar
            preciopaq4 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq4 = lp.PRECIO1
            End If
            lp.ID = idpaq5
            lp = lp.buscar
            preciopaq5 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaq5 = lp.PRECIO1
            End If
            lp.ID = idmuestreo
            lp = lp.buscar
            preciomuestreo = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomuestreo = lp.PRECIO1
            End If
            lp.ID = idzinc
            lp = lp.buscar
            preciozinc = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciozinc = lp.PRECIO1
            End If
            lp.ID = idtimbre
            lp = lp.buscar
            preciotimbre = lp.PRECIO1
        End If

        Dim listamuestras As New ArrayList
        Dim ss As New dSolicitudSuelos
        listamuestras = ss.listarporsolicitud(ficha)
        Dim cuentafosforobray As Double = 0
        Dim cuentafosforcitrico As Double = 0
        Dim cuentanitratos As Double = 0
        Dim cuentaphagua As Double = 0
        Dim cuentaphkci As Double = 0
        Dim cuentapotasio As Double = 0
        Dim cuentasulfatos As Double = 0
        Dim cuentanitrogenovegetal As Double = 0
        Dim cuentamateriaorganica As Double = 0
        Dim cuentapmn As Double = 0
        Dim cuentapaq1 As Double = 0
        Dim cuentapaq2 As Double = 0
        Dim cuentapaq3 As Double = 0
        Dim cuentapaq4 As Double = 0
        Dim cuentapaq5 As Double = 0
        Dim cuentamuestreo As Double = 0
        Dim cuentazinc As Double = 0

        If Not listamuestras Is Nothing Then
            For Each ss In listamuestras
                If ss.FOSFOROBRAY = 1 Then
                    cuentafosforobray = cuentafosforobray + 1
                End If
                If ss.FOSFOROCITRICO = 1 Then
                    cuentafosforcitrico = cuentafosforcitrico + 1
                End If
                If ss.NITRATOS = 1 Then
                    cuentanitratos = cuentanitratos + 1
                End If
                If ss.PHAGUA = 1 Then
                    cuentaphagua = cuentaphagua + 1
                End If
                If ss.PHKCI = 1 Then
                    cuentaphkci = cuentaphkci + 1
                End If
                If ss.POTASIOINT = 1 Then
                    cuentapotasio = cuentapotasio + 1
                End If
                If ss.SULFATOS = 1 Then
                    cuentasulfatos = cuentasulfatos + 1
                End If
                If ss.NITROGENOVEGETAL = 1 Then
                    cuentanitrogenovegetal = cuentanitrogenovegetal + 1
                End If
                If ss.MATERIAORG = 1 Then
                    cuentamateriaorganica = cuentamateriaorganica + 1
                End If
                If ss.MINERALIZACION = 1 Then
                    cuentapmn = cuentapmn + 1
                End If
                If ss.ZINC = 1 Then
                    cuentazinc = cuentazinc + 1
                End If
                If ss.PAQUETE = 1 Then
                    cuentapaq1 = cuentapaq1 + 1
                End If
                If ss.PAQUETE = 2 Then
                    cuentapaq2 = cuentapaq2 + 1
                End If
                If ss.PAQUETE = 3 Then
                    cuentapaq3 = cuentapaq3 + 1
                End If
                If ss.PAQUETE = 4 Then
                    cuentapaq4 = cuentapaq4 + 1
                End If
                If ss.PAQUETE = 5 Then
                    cuentapaq5 = cuentapaq5 + 1
                End If
            Next
        End If

        Dim analisis As Integer = 0
        Dim precio1 As Double = 0


        If cuentapaq1 > 0 Then
            analisis = 142
            precio1 = preciopaq1
            precio1 = precio1 * cuentapaq1
            totalprecio = totalprecio + precio1
        End If
        If cuentapaq2 > 0 Then
            analisis = 143
            precio1 = preciopaq2
            precio1 = precio1 * cuentapaq2
            totalprecio = totalprecio + precio1
        End If
        If cuentapaq3 > 0 Then
            analisis = 144
            precio1 = preciopaq3
            precio1 = precio1 * cuentapaq3
            totalprecio = totalprecio + precio1
        End If
        If cuentapaq4 > 0 Then
            analisis = 145
            precio1 = preciopaq4
            precio1 = precio1 * cuentapaq4
            totalprecio = totalprecio + precio1
        End If
        If cuentapaq5 > 0 Then
            analisis = 189
            precio1 = preciopaq5
            precio1 = precio1 * cuentapaq5
            totalprecio = totalprecio + precio1
        End If
        If cuentafosforobray > 0 Then
            analisis = 131
            precio1 = preciofosforobray
            precio1 = precio1 * cuentafosforobray
            totalprecio = totalprecio + precio1
        End If
        If cuentafosforcitrico > 0 Then
            analisis = 132
            precio1 = preciofosforcitrico
            precio1 = precio1 * cuentafosforcitrico
            totalprecio = totalprecio + precio1
        End If
        If cuentanitratos > 0 Then
            analisis = 133
            precio1 = precionitratos
            precio1 = precio1 * cuentanitratos
            totalprecio = totalprecio + precio1
        End If
        If cuentaphagua > 0 Then
            analisis = 134
            precio1 = preciophagua
            precio1 = precio1 * cuentaphagua
            totalprecio = totalprecio + precio1
        End If
        If cuentaphkci > 0 Then
            analisis = 135
            precio1 = preciophkci
            precio1 = precio1 * cuentaphkci
            totalprecio = totalprecio + precio1
        End If
        If cuentapotasio > 0 Then
            analisis = 136
            precio1 = preciopotasio
            precio1 = precio1 * cuentapotasio
            totalprecio = totalprecio + precio1
        End If
        If cuentasulfatos > 0 Then
            analisis = 137
            precio1 = preciosulfatos
            precio1 = precio1 * cuentasulfatos
            totalprecio = totalprecio + precio1
        End If
        If cuentanitrogenovegetal > 0 Then
            analisis = 138
            precio1 = precionitrogenovegetal
            precio1 = precio1 * cuentanitrogenovegetal
            totalprecio = totalprecio + precio1
        End If
        If cuentamateriaorganica > 0 Then
            analisis = 139
            precio1 = preciomateriaorganica
            precio1 = precio1 * cuentamateriaorganica
            totalprecio = totalprecio + precio1
        End If
        If cuentapmn > 0 Then
            analisis = 140
            precio1 = preciopmn
            precio1 = precio1 * cuentapmn
            totalprecio = totalprecio + precio1
        End If
        If cuentazinc > 0 Then
            analisis = 192
            precio1 = preciozinc
            precio1 = precio1 * cuentazinc
            totalprecio = totalprecio + precio1
        End If
        totalprecio = totalprecio + preciotimbre

    End Sub
End Class