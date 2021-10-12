Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeSuelos
    Private _usuario As dUsuario
    Private idsol As Long = 0
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

        'Dim v2 As New FormObservaciones(Usuario, ficha)
        'v2.ShowDialog()

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
        Dim v As New FormSubirInformes(Usuario)
        v.ShowDialog()
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
    Private Sub creainformeexcel()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)


        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
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
                Dim s1 As New dSuelos
                s1.FICHA = idsol
                s1 = s1.buscar
                If Not s1 Is Nothing Then
                    If s1.FINAL = 0 Then
                        informefinal = 0
                    Else
                        informefinal = 1
                    End If
                End If
                If informefinal = 0 Then
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Formula = "INFORME PARCIAL DE SUELOS"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 2
                    columna = 1
                Else
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Formula = "INFORME DE SUELOS"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 2
                    columna = 1
                End If
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


                'x1hoja.Range("B14", "D15").Merge()
                'x1hoja.Range("B14", "D15").WrapText = True
                x1hoja.Range("B13", "E14").Merge()
                x1hoja.Range("B13", "E14").WrapText = True

                x1hoja.Cells(fila, columna).Formula = texto2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
                'x1hoja.Cells(fila, columna).Formula = "Procesamiento:"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 9
                'fila = fila + 1
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
                    'x1hoja.Cells(fila, columna).Formula = cuenta & ")" & " " & s.DETALLEMUESTRA
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 9
                    'fila = fila + 1
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


                x1hoja.Cells(fila, columna).Formula = "INFORME"
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
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1


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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
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
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
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
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "% SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            columna = columna - 1
                            linea = linea + 1

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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "pH Agua"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "pH KCI"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                            If s.SULFATOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                            If s.MATERIAORGANICA <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Calcio"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Magnesio"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Sodio"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "% SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                            columna = columna - 1
                            linea = linea + 1

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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "pH Agua"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "pH KCI"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                            If s.SULFATOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                            If s.MATERIAORGANICA <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Calcio"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Magnesio"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Sodio"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "CIC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
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
                                linea = linea + 1
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "% SB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
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
                            Else
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "N/R"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
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
                x1hoja.Cells(fila, columna).formula = "Nitrógeno vegetal: Dumas AOAC 968.06 modif.LECO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Carbono orgánico: Combustión a 900ºC y detección de CO2 por infrarrojo"
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
                    x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                End If
                fila = fila + 1



                '******* CALCULO PRECIO ************************************************************************

                Dim listamuestras As New ArrayList
                listamuestras = s.listarporid(idsol)

                Dim ana As New dAnalisis

                Dim idtimbre As Integer = 86
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
                Dim preciotimbre As Double = 0
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


                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO
                ana.ID = idfosforobray
                ana = ana.buscar
                preciofosforobray = ana.COSTO
                ana.ID = idfosforocitrico
                ana = ana.buscar
                preciofosforcitrico = ana.COSTO
                ana.ID = idnitratos
                ana = ana.buscar
                precionitratos = ana.COSTO
                ana.ID = idphagua
                ana = ana.buscar
                preciophagua = ana.COSTO
                ana.ID = idphkci
                ana = ana.buscar
                preciophkci = ana.COSTO
                ana.ID = idpotasio
                ana = ana.buscar
                preciopotasio = ana.COSTO
                ana.ID = idsulfatos
                ana = ana.buscar
                preciosulfatos = ana.COSTO
                ana.ID = idnitrogenovegetal
                ana = ana.buscar
                precionitrogenovegetal = ana.COSTO
                ana.ID = idmateriaorganica
                ana = ana.buscar
                preciomateriaorganica = ana.COSTO
                ana.ID = idpmn
                ana = ana.buscar
                preciopmn = ana.COSTO
                ana.ID = idpaq1
                ana = ana.buscar
                preciopaq1 = ana.COSTO
                ana.ID = idpaq2
                ana = ana.buscar
                preciopaq1 = ana.COSTO
                ana.ID = idpaq3
                ana = ana.buscar
                preciopaq3 = ana.COSTO
                ana.ID = idpaq4
                ana = ana.buscar
                preciopaq4 = ana.COSTO


                Dim total As Double = 0
                Dim ss2 As New dSolicitudSuelos
                Dim lista3 As New ArrayList
                lista3 = ss2.listarporsolicitud(idsol)

                For Each ss2 In lista3
                    If ss2.PAQUETE = 0 Then
                        If ss2.FOSFOROBRAY = 1 Then
                            total = total + preciofosforobray
                        End If
                        If ss2.FOSFOROCITRICO = 1 Then
                            total = total + preciofosforcitrico
                        End If
                        If ss2.NITRATOS = 1 Then
                            total = total + precionitratos
                        End If
                        If ss2.PHAGUA = 1 Then
                            total = total + preciophagua
                        End If
                        If ss2.PHKCI = 1 Then
                            total = total + preciophkci
                        End If
                        If ss2.POTASIOINT = 1 Then
                            total = total + preciopotasio
                        End If
                        If ss2.SULFATOS = 1 Then
                            total = total + preciosulfatos
                        End If
                        If ss2.NITROGENOVEGETAL = 1 Then
                            total = total + precionitrogenovegetal
                        End If
                        If ss2.MATERIAORG = 1 Then
                            total = total + preciomateriaorganica
                        End If
                        If ss2.MINERALIZACION = 1 Then
                            total = total + preciopmn
                        End If
                    End If
                    If ss2.PAQUETE = 1 Then
                        total = total + preciopaq1
                        If ss2.FOSFOROCITRICO = 1 Then
                            total = total + preciofosforcitrico
                        End If
                        If ss2.PHKCI = 1 Then
                            total = total + preciophkci
                        End If
                        If ss2.SULFATOS = 1 Then
                            total = total + preciosulfatos
                        End If
                        If ss2.NITROGENOVEGETAL = 1 Then
                            total = total + precionitrogenovegetal
                        End If
                        If ss2.MINERALIZACION = 1 Then
                            total = total + preciopmn
                        End If
                    End If
                    If ss2.PAQUETE = 2 Then
                        total = total + preciopaq2
                        If ss2.FOSFOROCITRICO = 1 Then
                            total = total + preciofosforcitrico
                        End If
                        If ss2.NITRATOS = 1 Then
                            total = total + precionitratos
                        End If
                        If ss2.PHKCI = 1 Then
                            total = total + preciophkci
                        End If
                        If ss2.NITROGENOVEGETAL = 1 Then
                            total = total + precionitrogenovegetal
                        End If
                        If ss2.MATERIAORG = 1 Then
                            total = total + preciomateriaorganica
                        End If
                        If ss2.MINERALIZACION = 1 Then
                            total = total + preciopmn
                        End If
                    End If
                    If ss2.PAQUETE = 3 Then
                        total = total + preciopaq3
                        If ss2.FOSFOROCITRICO = 1 Then
                            total = total + preciofosforcitrico
                        End If
                        If ss2.PHKCI = 1 Then
                            total = total + preciophkci
                        End If
                        If ss2.SULFATOS = 1 Then
                            total = total + preciosulfatos
                        End If
                        If ss2.NITROGENOVEGETAL = 1 Then
                            total = total + precionitrogenovegetal
                        End If
                        If ss2.MATERIAORG = 1 Then
                            total = total + preciomateriaorganica
                        End If
                        If ss2.MINERALIZACION = 1 Then
                            total = total + preciopmn
                        End If
                    End If
                    If ss2.PAQUETE = 4 Then
                        total = total + preciopaq4
                        If ss2.FOSFOROBRAY = 1 Then
                            total = total + preciofosforobray
                        End If
                        If ss2.FOSFOROCITRICO = 1 Then
                            total = total + preciofosforcitrico
                        End If
                        If ss2.NITRATOS = 1 Then
                            total = total + precionitratos
                        End If
                        If ss2.PHAGUA = 1 Then
                            total = total + preciophagua
                        End If
                        If ss2.PHKCI = 1 Then
                            total = total + preciophkci
                        End If
                       
                        If ss2.SULFATOS = 1 Then
                            total = total + preciosulfatos
                        End If
                        If ss2.NITROGENOVEGETAL = 1 Then
                            total = total + precionitrogenovegetal
                        End If
                        If ss2.MATERIAORG = 1 Then
                            total = total + preciomateriaorganica
                        End If
                        If ss2.MINERALIZACION = 1 Then
                            total = total + preciopmn
                        End If
                    End If

                   
                Next

                total = Math.Round(total + preciotimbre, 2)
                '***********************************************************************************************
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Técnico resp::" & "Ing. Ag. Victor González"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y Timbre de la CJPU"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Colaborador: Alejandro Morón"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Convenio FCA UDE - Colaveco"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True

                columna = 1
                'fila = fila + 1
                '**********************************************************

                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
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
                x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dr. Darío Hirigoyen (Director)."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6



            End If
        End If




        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\Agro - suelos\" & idsol & "_NET.xls")
        x1app.Visible = True
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub crearPDF()
        'Dim stream As StreamReader stream = New StreamReader("\\SRVCOLAVECO\D\NET\Agro - suelos\" & idsol & ".xls") 
        'Dim printer As New PrintDocument()
        'printer.PrinterSettings.PrinterName = "doPDF v7"

        '' Convert Word file (DOCX or DOC) to PDF.
        'DocumentModel.Load("Document.doc").Save("Document.pdf")
    End Sub
End Class