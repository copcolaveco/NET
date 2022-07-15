Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeNutricion
    Private _usuario As dUsuario
    Private idsol As Long
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
       
        Dim v2 As New FormObservaciones(Usuario, ficha)
        v2.ShowDialog()

        creainformeexcel()


        s.ID = ficha
        s = s.buscar
        idsol = ficha
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
        lista = s.listarfichasnutricion
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

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim n As New dNutricion
        Dim sn As New dSolicitudNutricion
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
       
        '*****************************

        idsol = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        lista = n.listarporsolicitud(idsol)
        lista2 = sn.listarporsolicitud(idsol)

     
        x1hoja.Cells(8, 2).formula = sa.ID
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(9, 2).formula = pro.NOMBRE
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9
        x1hoja.Cells(10, 2).formula = pro.DIRECCION
        x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(10, 2).Font.Size = 9

        x1hoja.Cells(8, 4).formula = "Fecha entrada: " & sa.FECHAINGRESO
        x1hoja.Cells(8, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 4).Font.Size = 9
        x1hoja.Cells(8, 4).Font.Bold = True

        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(9, 4).formula = "Fecha informe: " & fecha2
        x1hoja.Cells(9, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 4).Font.Size = 9
        x1hoja.Cells(9, 4).Font.Bold = True

        Dim fila As Integer
        Dim columna As Integer

     


        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 2


                'Poner Titulos
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_nutricion.jpg", _
                Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)

                '  x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
                'Microsoft.Office.Core.MsoTriState.msoFalse, _
                'Microsoft.Office.Core.MsoTriState.msoCTrue, 239, 0, 79, 35)




                x1hoja.Cells(3, 1).columnwidth = 15
                x1hoja.Cells(3, 2).columnwidth = 15
                x1hoja.Cells(3, 3).columnwidth = 15
                x1hoja.Cells(3, 4).columnwidth = 32
                x1hoja.Range("A1", "D1").Merge()


                columna = 2
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Range("B4", "C4").Merge()
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Range("A6", "D6").Merge()
                fila = fila + 3
                columna = 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE NUTRICIÓN"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Cliente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).Formula = "Fecha informe:"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 9
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

                Dim txtmga As Integer = 0
                Dim txtmgb As Integer = 0
                Dim txtensilados As Integer = 0
                Dim txtpasturas As Integer = 0
                Dim txtextetereo As Integer = 0
                Dim txtnida As Integer = 0
                Dim txtmicotoxinas As Integer = 0
                Dim txtproteinas As Integer = 0
                Dim txtfibraefectiva As Integer = 0
                Dim txttimac As Integer = 0
                Dim txttimacpro As Integer = 0
                Dim txtfibraneutra As Integer = 0
                Dim txtfibraacida As Integer = 0

                For Each sn In lista2
                    texto = texto & " - " & sn.MUESTRA
                    'texto2 = texto2 & "// " & sn.MUESTRA
                    If sn.MGA = 1 Then
                        txtmga = 1
                        'texto2 = texto2 & "- MS, Cenizas, PB, FND, FAD, Cálculo de energía. "
                    End If
                    If sn.MGB = 1 Then
                        txtmgb = 1
                        'texto2 = texto2 & "- MS, Cenizas, PB, FC."
                    End If
                    If sn.ENSILADOS = 1 Then
                        txtensilados = 1
                        'texto2 = texto2 & " - MS, PB, pH, Cenizas, FAD, FND, Cálculo de energía. "
                    End If
                    If sn.PASTURAS = 1 Then
                        txtpasturas = 1
                        'texto2 = texto2 & " - MS, Cenizas, PB, FND, FAD, Cálculo de energía. "
                    End If
                    If sn.EXTETEREO = 1 Then
                        txtextetereo = 1
                        'texto2 = texto2 & " - Extracto etéreo "
                    End If
                    If sn.NIDA = 1 Then
                        txtnida = 1
                        'texto2 = texto2 & " - NIDA "
                    End If
                    If sn.MICOTOXINAS = 1 Then
                        txtmicotoxinas = 1
                        'texto2 = texto2 & " - MICOTOXINAS "
                    End If
                    If sn.PROTEINAS = 1 Then
                        txtproteinas = 1
                        'texto2 = texto2 & " - PROTEÍNAS "
                    End If
                    If sn.MGA = 0 And sn.MGB = 0 And sn.ENSILADOS = 0 And sn.PASTURAS = 0 Then
                        If sn.MATERIASECA = 1 Then
                            'texto2 = texto2 & " - MS "
                        End If
                    End If
                    If sn.ENSILADOS = 0 Then
                        If sn.PH = 1 Then
                            'texto2 = texto2 & " - pH "
                        End If
                    End If
                    If sn.FIBRAEFECTIVA = 1 Then
                        txtfibraefectiva = 1
                        'texto2 = texto2 & " - FIBRA EFECTIVA "
                    End If
                    If sn.FIBRANEUTRA = 1 Then
                        txtfibraneutra = 1
                        'texto2 = texto2 & " - FIBRA EFECTIVA "
                    End If
                    If sn.FIBRANEUTRA = 1 Then
                        txtfibraacida = 1
                        'texto2 = texto2 & " - FIBRA EFECTIVA "
                    End If
                    If sn.TIMAC = 1 Then
                        txttimac = 1
                        'texto2 = texto2 & " - FIBRA EFECTIVA "
                    End If
                    If sn.TIMACPROTEINA = 1 Then
                        txttimacpro = 1
                        'texto2 = texto2 & " - FIBRA EFECTIVA "
                    End If
                Next

                If txtmga = 1 Then
                    texto2 = "- MS, Cenizas, PB, FND, FAD, Cálculo de energía. "
                End If
                If txtmgb = 1 Then
                    texto2 = "- MS, Cenizas, PB, FC."
                End If
                If txtensilados = 1 Then
                    texto2 = " - MS, PB, pH, Cenizas, FAD, FND, Cálculo de energía. "
                End If
                If txtpasturas = 1 Then
                    texto2 = " - MS, Cenizas, PB, FND, FAD, Cálculo de energía. "
                End If
                If txtextetereo = 1 Then
                    texto2 = " - Extracto etéreo "
                End If
                If txtnida = 1 Then
                    texto2 = " - NIDA "
                End If
                If txtmicotoxinas = 1 Then
                    texto2 = " - MICOTOXINAS "
                End If
                If txtproteinas = 1 Then
                    texto2 = " - PROTEÍNAS "
                End If
                If txtfibraefectiva = 1 Then
                    texto2 = " - FIBRA EFECTIVA "
                End If
                If txtfibraneutra = 1 Then
                    texto2 = " - FIBRA NEUTRA "
                End If
                If txtfibraacida = 1 Then
                    texto2 = " - FIBRA ÁCIDA "
                End If
                If txttimac = 1 Then
                    texto2 = " - TIMAC s/PROTEÍNA "
                End If
                If txttimacpro = 1 Then
                    texto2 = " - TIMAC c/PROTEÍNA "
                End If

                x1hoja.Range("B12", "D13").Merge()
                x1hoja.Range("B12", "D13").WrapText = True
                'x1hoja.Cells(fila, columna).Formula = texto
                Dim m As New dMuestras
                m.ID = sa.IDMUESTRA
                m = m.buscar
                If Not m Is Nothing Then
                    x1hoja.Cells(fila, columna).Formula = m.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                Else
                    x1hoja.Cells(fila, columna).Formula = ""
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                End If
                
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Estudio solicitado"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1


                x1hoja.Range("B14", "D15").Merge()
                x1hoja.Range("B14", "D15").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1

                Dim filasolomicotoxinas As Integer = 0
                filasolomicotoxinas = fila
                Dim linea As Integer = 0
                Dim i As Integer = 1

                '*** COMPROBAR SI SOLICITAN MICOTOXINAS *********************************************************************************************************************
                Dim listanut As New ArrayList
                Dim listasolnut As New ArrayList
                listanut = n.listarporsolicitud(idsol)
                listasolnut = sn.listarporsolicitud(idsol)
                Dim j As Integer = 1
                Dim micotoxinas As Integer = 0
                Dim solomicotoxinas As Integer = 0


                For Each sn In listasolnut
                    If sn.MICOTOXINAS = 1 Then
                        micotoxinas = 1
                        solomicotoxinas = 1
                    End If
                Next
                If micotoxinas = 1 Then
                    'If sn.MGA = 0 And sn.MGB = 0 And sn.ENSILADOS = 0 And sn.PASTURAS = 0 And sn.EXTETEREO = 0 And sn.AFLA = 0 And sn.DON = 0 And sn.FIBRAEFECTIVA = 0 And sn.MATERIASECA = 0 And sn.NIDA = 0 And sn.PH = 0 And sn.PROTEINAS = 0 And sn.ZEARA = 0 Then
                    If sn.MGA = 0 And sn.MGB = 0 And sn.ENSILADOS = 0 And sn.PASTURAS = 0 And sn.EXTETEREO = 0 And sn.FIBRAEFECTIVA = 0 And sn.MATERIASECA = 0 And sn.NIDA = 0 And sn.PH = 0 And sn.PROTEINAS = 0 Then
                        fila = filasolomicotoxinas
                    Else
                        solomicotoxinas = 0
                    End If
                End If

                '*****************************
                If solomicotoxinas = 0 Then
                    x1hoja.Cells(fila, columna).Formula = "Procesamiento:"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Se recibieron las siguientes muestras:"
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    Dim cuenta As Integer = 1
                    For Each n In lista
                        x1hoja.Cells(fila, columna).Formula = cuenta & ")" & " " & n.DETALLEMUESTRA
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 9
                        fila = fila + 1
                        cuenta = cuenta + 1
                    Next
                    cuenta = cuenta - 1
                End If

                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "RESULTADO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1

              

                For Each n In lista


                    '1 MUESTRA ****************************************************************
                    If solomicotoxinas = 0 Then
                        If i = 1 Then
                            x1hoja.Cells(fila, columna).Formula = "Resultado 1"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                If n.EMM = 0 Then
                                    metodo.ID = 59
                                Else
                                    metodo.ID = n.EMM
                                End If
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                If n.FCM = 0 Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                Else
                                    metodo.ID = n.FCM
                                    metodo = metodo.buscar
                                End If

                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                If n.NIDAM > 0 Then
                                    metodo = metodo.buscar
                                Else
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                'If metodo Is Nothing Then
                                '    metodo.ID = 57
                                '    metodo = metodo.buscar
                                'End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra Efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If
                    '2 MUESTRAS ****************************************************************
                    If i = 2 Then
                        fila = fila + 1
                        columna = 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado 2"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Base Seca"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1

                        If n.MSH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.MSH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.MSM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.CENIZASH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.CENIZASM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.PBH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% PB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PBH
                            'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PBS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.PBM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FNDH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FND"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FNDS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FNDM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FADH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FAD"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                            'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FADS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FADM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.ENLS <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.ENLS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.ENLM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.EMS <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EMS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.EMM
                            metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo = New dMetodos
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FCH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = n.FCH
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FCS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FCM
                            metodo = metodo.buscar
                            If metodo Is Nothing Then
                                metodo.ID = 60
                                metodo = metodo.buscar
                            End If
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.PHH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "pH"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PHH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.PHM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.EEH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% EE"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EEH
                            'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.EEM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.NIDAH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% NIDA"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.NIDAH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                If metodo.ID <> 0 Then
                                    metodo = metodo.buscar
                                Else
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If

                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FIBRAEFECTIVA <> "-1" Then
                            x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FIBRAEFECTIVAM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                    End If
                    '3 MUESTRAS ****************************************************************
                    If i = 3 Then
                        fila = fila + 1
                        columna = 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado 3"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Base Seca"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1

                        If n.MSH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.MSH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.MSM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.CENIZASH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.CENIZASM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.PBH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% PB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PBH
                            'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PBS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.PBM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FNDH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FND"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FNDS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FNDM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FADH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FAD"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FADS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FADM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.ENLS <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.ENLS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.ENLM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.EMS <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EMS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                If n.EMM = 0 Then
                                    metodo.ID = 59
                                End If
                            metodo = metodo.buscar
                            If metodo Is Nothing Then
                                metodo.ID = 59
                                metodo = metodo.buscar
                            End If
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FCH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = n.FCH
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FCS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                                Dim metodo As New dMetodos
                                If n.FCM = 0 Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                Else
                                    metodo.ID = n.FCM
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.PHH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "pH"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PHH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.PHM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.EEH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% EE"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EEH
                            'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.EEM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.NIDAH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% NIDA"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.NIDAH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.NIDAM
                            metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    Dim metodo2 As New dMetodos
                                    metodo2.ID = 57
                                    metodo2 = metodo2.buscar
                                    If Not metodo2 Is Nothing Then
                                        x1hoja.Cells(fila, columna).Formula = metodo2.ESTANDAR
                                        x1hoja.Cells(fila, columna).WrapText = True
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 8
                                    End If
                                End If
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FIBRAEFECTIVA <> "-1" Then
                            x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FIBRAEFECTIVAM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                    End If

                    '4 MUESTRAS ****************************************************************
                    If i = 4 Then
                        fila = fila + 1
                        columna = 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado 4"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        fila = fila + 1
                        x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Base Seca"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1

                        If n.MSH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.MSH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.MSM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.CENIZASH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.CENIZASM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.PBH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% PB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PBH
                            'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PBS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.PBM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FNDH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FND"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FNDS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FNDM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FADH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FAD"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FADS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FADM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.ENLS <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.ENLS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.ENLM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.EMS <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EMS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.EMM
                            metodo = metodo.buscar
                            If metodo Is Nothing Then
                                metodo.ID = 59
                                metodo = metodo.buscar
                            End If
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.FCH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% FC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = n.FCH
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.FCS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.FCM
                            metodo = metodo.buscar
                         
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.PHH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "pH"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.PHH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.PHM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.EEH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% EE"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EEH
                            'x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.EES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.EEM
                            metodo = metodo.buscar
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                            End If
                            fila = fila + 1
                            metodo = Nothing
                            columna = 1
                        End If

                        If n.NIDAH <> -1 Then
                            x1hoja.Cells(fila, columna).Formula = "% NIDA"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.NIDAH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "---"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            Dim metodo As New dMetodos
                            metodo.ID = n.NIDAM
                            metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    Dim metodo2 As New dMetodos
                                    metodo2.ID = 57
                                    metodo2 = metodo2.buscar
                                    If Not metodo2 Is Nothing Then
                                        x1hoja.Cells(fila, columna).Formula = metodo2.ESTANDAR
                                        x1hoja.Cells(fila, columna).WrapText = True
                                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                        x1hoja.Cells(fila, columna).Font.Bold = False
                                        x1hoja.Cells(fila, columna).Font.Size = 8
                                    End If
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                        End If
                        '5 MUESTRAS ****************************************************************
                        If i = 5 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 5"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                        End If

                        '6 MUESTRAS ****************************************************************
                        If i = 6 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 6"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                        End If

                        '7 MUESTRAS ****************************************************************
                        If i = 7 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 7"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                        End If

                        '8 MUESTRAS ****************************************************************
                        If i = 8 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 8"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '9 MUESTRAS ****************************************************************
                        If i = 9 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 9"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '10 MUESTRAS ****************************************************************
                        If i = 10 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 10"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '11 MUESTRAS ****************************************************************
                        If i = 11 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 11"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '12 MUESTRAS ****************************************************************
                        If i = 12 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 12"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '13 MUESTRAS ****************************************************************
                        If i = 13 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 13"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '14 MUESTRAS ****************************************************************
                        If i = 14 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 14"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '15 MUESTRAS ****************************************************************
                        If i = 15 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 15"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '16 MUESTRAS ****************************************************************
                        If i = 16 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 16"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '17 MUESTRAS ****************************************************************
                        If i = 17 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 17"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '18 MUESTRAS ****************************************************************
                        If i = 18 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 18"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '19 MUESTRAS ****************************************************************
                        If i = 19 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 19"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                        '20 MUESTRAS ****************************************************************
                        If i = 20 Then
                            fila = fila + 1
                            columna = 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado 20"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Parámetro/Unidad"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Base Seca"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = 1
                            fila = fila + 1

                            If n.MSH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% MS 105ºC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.MSH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.MSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.CENIZASH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% Cenizas"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.CENIZASH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CENIZASS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CENIZASM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PBH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% PB"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PBS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PBM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FNDH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FND"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FNDS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FNDM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FADH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FAD"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FADS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FADM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.ENLS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "ENL(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ENLS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ENLM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EMS <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "EM(Mcal/Kg MS)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EMS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EMM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 59
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FCH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% FC"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                'x1hoja.Cells(fila, columna).Formula = n.FCH
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FCS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FCM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 60
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.PHH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.PHH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.PHM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.EEH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% EE"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EEH
                                'x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.EES
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.EEM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.NIDAH <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = "% NIDA"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.NIDAH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.NIDAM
                                metodo = metodo.buscar
                                If metodo Is Nothing Then
                                    metodo.ID = 57
                                    metodo = metodo.buscar
                                End If
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If

                            If n.FIBRAEFECTIVA <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fibra efectiva"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FIBRAEFECTIVA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FIBRAEFECTIVAM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CLOSTRIDIOS <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Clostridios"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CLOSTRIDIOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CLOSTRIDIOSM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.ZINC <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Zinc mg/Kg"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.ZINC
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.ZINCM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.CALCIO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Calcio % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.CALCIO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.CALCIOM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                            If n.FOSFORO <> "-1" Then
                                x1hoja.Cells(fila, columna).Formula = "Fósforo % (g/100g)"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = n.FOSFORO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = "---"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                Dim metodo As New dMetodos
                                metodo.ID = n.FOSFOROM
                                metodo = metodo.buscar
                                If Not metodo Is Nothing Then
                                    x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                    x1hoja.Cells(fila, columna).WrapText = True
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                fila = fila + 1
                                metodo = Nothing
                                columna = 1
                            End If
                        End If

                    End If
                    i = i + 1

                Next

                '***************************************
                If solomicotoxinas = 0 Then
                    fila = fila + 1
                    columna = 1
                    x1hoja.Cells(fila, columna).formula = "(MS = Materia Seca - FND = Fibra Neutro Detergente - FDA = Fibra Ácido detergente - PB = Proteína Bruta - FC = Fibra Cruda)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 6
                End If

                '*** MICOTOXINAS **********************************************************************************
                'Dim listanut As New ArrayList
                'Dim listasolnut As New ArrayList
                'listanut = n.listarporsolicitud(idsol)
                'listasolnut = sn.listarporsolicitud(idsol)
                'Dim j As Integer = 1
                'Dim micotoxinas As Integer = 0


                'For Each sn In listasolnut
                '    If sn.MICOTOXINAS = 1 Then
                '        micotoxinas = 1
                '    End If
                'Next
                'If micotoxinas = 1 Then
                '    If sn.MGA = 0 And sn.MGB = 0 And sn.ENSILADOS = 0 And sn.PASTURAS = 0 And sn.EXTETEREO = 0 And sn.AFLA = 0 And sn.DON = 0 And sn.FIBRAEFECTIVA = 0 And sn.MATERIASECA = 0 And sn.NIDA = 0 And sn.PH = 0 And sn.PROTEINAS = 0 And sn.ZEARA = 0 Then
                '        fila = filasolomicotoxinas
                '    End If
                'End If

                If micotoxinas = 1 Then
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Micotoxinas"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1

                    x1hoja.Cells(fila, columna).Formula = "ID Muestra"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Parámetro/unidad"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Base Húmeda"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Referencia/Método"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1

                    For Each n In listanut
                        If n.DON <> "-1" And n.DON <> "" Then
                            x1hoja.Cells(fila, columna).Formula = n.MUESTRA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "DON(Deoxinilvalenol)(ppb)"
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.DON
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = "Anticuerpos monoclonales -V Vicam  (Límite de det. 0.25 ppm)"
                            x1hoja.Cells(fila, columna).Formula = "Prueba CHARM ROSA (Límite de det. 100 ppb)"
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            columna = 1
                        End If
                        If n.AFLA <> "-1" And n.AFLA <> "" Then
                            x1hoja.Cells(fila, columna).Formula = n.MUESTRA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "AFLATOXINA(ppb)"
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.AFLA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = "Anticuerpos monoclonales -V Vicam  (Límite de det. 2 ppb)"
                            x1hoja.Cells(fila, columna).Formula = "Prueba CHARM ROSA (Límite de det. 2 ppb)"
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            columna = 1
                        End If
                        If n.ZEARA <> "-1" And n.ZEARA <> "" Then
                            x1hoja.Cells(fila, columna).Formula = n.MUESTRA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "ZEARALENONA(ppb)"
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = n.ZEARA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            'x1hoja.Cells(fila, columna).Formula = "Flurometría (Límite de det 0.1 ppm)"
                            x1hoja.Cells(fila, columna).Formula = "Prueba CHARM ROSA (Límite de det. 15 ppb)"
                            x1hoja.Cells(fila, columna).WrapText = True
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            fila = fila + 1
                            columna = 1
                        End If
                    Next
                End If





                '***************************************************************************************************

                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                If sa.OBSERVACIONES <> "" Then
                    Dim fila2 = fila + 2
                    x1hoja.Range("A" & fila, "D" & fila2).Merge()
                    x1hoja.Range("A" & fila, "D" & fila2).WrapText = True
                    columna = 1
                    x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 2
                End If
                fila = fila + 2



                '******* CALCULO PRECIO ************************************************************************

                Dim listamuestras As New ArrayList
                listamuestras = n.listarporid(idsol)

                Dim ana As New dAnalisis

                Dim idtimbre As Integer = 86
                Dim paquete1a As Integer = 125
                Dim paquete1b As Integer = 126
                Dim paquete2 As Integer = 127
                Dim paquete3 As Integer = 128
                Dim paquete4 As Integer = 129
                Dim paquete5 As Integer = 130
                Dim paquetemicotoxinas As Integer = 160
                Dim idmicotoxinas As Integer = 161
                Dim idproteinas As Integer = 159
                Dim idmateriaseca As Integer = 164
                Dim idph As Integer = 165
                Dim idfibraefectiva As Integer = 191
                Dim idpaquetetimac As Integer = 212
                Dim idpaquetetimacproteina As Integer = 213
                Dim idpaquetetimacproteina5 As Integer = 214
                Dim preciotimbre As Double = 0
                Dim preciopaquete1a As Double = 0
                Dim preciopaquete1b As Double = 0
                Dim preciopaquete2 As Double = 0
                Dim preciopaquete3 As Double = 0
                Dim preciopaquete4 As Double = 0
                Dim preciopaquete5 As Double = 0
                Dim preciopaquetemicotoxinas As Double = 0
                Dim preciomicotoxinas As Double = 0
                Dim precioproteinas As Double = 0
                Dim preciomateriaseca As Double = 0
                Dim precioph As Double = 0
                Dim preciofibraefectiva As Double = 0
                Dim preciotimac As Double = 0
                Dim preciotimacproteina As Double = 0
                Dim preciotimacproteina5 As Double = 0


                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO
                ana.ID = paquete1a
                ana = ana.buscar
                preciopaquete1a = ana.COSTO
                ana.ID = paquete1b
                ana = ana.buscar
                preciopaquete1b = ana.COSTO
                ana.ID = paquete2
                ana = ana.buscar
                preciopaquete2 = ana.COSTO
                ana.ID = paquete3
                ana = ana.buscar
                preciopaquete3 = ana.COSTO
                ana.ID = paquete4
                ana = ana.buscar
                preciopaquete4 = ana.COSTO
                ana.ID = paquete5
                ana = ana.buscar
                preciopaquete5 = ana.COSTO
                ana.ID = paquetemicotoxinas
                ana = ana.buscar
                preciopaquetemicotoxinas = ana.COSTO
                ana.ID = idmicotoxinas
                ana = ana.buscar
                preciomicotoxinas = ana.COSTO
                ana.ID = idproteinas
                ana = ana.buscar
                precioproteinas = ana.COSTO
                ana.ID = idmateriaseca
                ana = ana.buscar
                preciomateriaseca = ana.COSTO
                ana.ID = idph
                ana = ana.buscar
                precioph = ana.COSTO
                ana.ID = idfibraefectiva
                ana = ana.buscar
                preciofibraefectiva = ana.COSTO
                ana.ID = idpaquetetimac
                ana = ana.buscar
                preciotimac = ana.COSTO
                ana.ID = idpaquetetimacproteina
                ana = ana.buscar
                preciotimacproteina = ana.COSTO
                ana.ID = idpaquetetimacproteina5
                ana = ana.buscar
                preciotimacproteina5 = ana.COSTO

                Dim total As Double = 0
                Dim sn2 As New dSolicitudNutricion
                Dim lista3 As New ArrayList
                lista3 = sn2.listarporsolicitud(idsol)

                For Each sn2 In lista3

                    If sn2.MGA = 1 Then
                        total = total + preciopaquete1a
                    End If
                    If sn2.MGB = 1 Then
                        total = total + preciopaquete1b
                    End If
                    If sn2.ENSILADOS = 1 Then
                        total = total + preciopaquete2
                    End If
                    If sn2.PASTURAS = 1 Then
                        total = total + preciopaquete3
                    End If
                    If sn2.EXTETEREO = 1 Then
                        total = total + preciopaquete4
                    End If
                    If sn2.NIDA = 1 Then
                        total = total + preciopaquete5
                    End If
                    If sn2.DON = 1 And sn2.AFLA = 1 And sn2.ZEARA = 1 Then
                        total = total + preciopaquetemicotoxinas
                    Else
                        If sn2.DON = 1 Then
                            total = total + preciomicotoxinas
                        End If
                        If sn2.AFLA = 1 Then
                            total = total + preciomicotoxinas
                        End If
                        If sn2.ZEARA = 1 Then
                            total = total + preciomicotoxinas
                        End If
                    End If
                    If sn2.PROTEINAS = 1 Then
                        total = total + precioproteinas
                    End If
                    If sn2.MATERIASECA = 1 Then
                        total = total + preciomateriaseca
                    End If
                    If sn2.PH = 1 Then
                        total = total + precioph
                    End If
                    If sn2.FIBRAEFECTIVA = 1 Then
                        total = total + preciofibraefectiva
                    End If
                    If sn2.TIMAC = 1 Then
                        total = total + preciotimac
                    End If
                    If sn2.TIMACPROTEINA = 1 Then
                        If lista3.Count > 4 Then
                            total = total + preciotimacproteina5
                        Else
                            total = total + preciotimacproteina
                        End If

                    End If
                Next

                factura_nutricion()

                total = total + preciotimbre
                totalprecio = totalprecio + preciotimbre

                '/* Actualiza el importe en la solicitud 
                Dim saimp As New dSolicitudAnalisis
                Dim importesa As Double = totalprecio
                saimp.ID = idsol
                saimp.actualizarimporte(importesa)
                '***************************************/

                '***********************************************************************************************
                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & totalprecio & " (Timbre incluído)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 3
                If sn2.MICOTOXINAS = 1 Then
                    x1hoja.Cells(fila, columna).formula = "Técnico resp:" & "Ing. Agr. Víctor González"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = 1
                    fila = fila + 1
                Else
                    'x1hoja.Cells(fila, columna).formula = "Técnico resp:" & "Dra. MSc. Analía Pérez Ruchel"
                    x1hoja.Cells(fila, columna).formula = "Técnico resp:" & "Ing. Agr. Víctor González"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = 1
                    fila = fila + 1
                End If

                'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 3
                If sn2.MICOTOXINAS = 1 Then
                    'x1hoja.Cells(fila, columna).formula = "Convenio FCA UDE - Colaveco"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "Dpto. de Nutrición Animal Fac. Veterinaria)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    columna = 1
                    fila = fila + 1
                End If

                '**********************************************************

                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
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
                x1hoja.Range("A" & fila, "D" & fila).Merge()
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
            pi2.TIPO = 13
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
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1app.Visible = True
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\NUTRICION\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\NUTRICION\" & idsol & ".xls")
        'x1hoja.PageSetup.CenterFooter = "Página &P de &N"



        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub factura_nutricion()
        Dim sa As New dSolicitudAnalisis
        Dim n As New dNutricion

        Dim listamuestras As New ArrayList
        listamuestras = n.listarporid(idsol)
        Dim muestras As Integer = listamuestras.Count

        Dim lp As New dListaPrecios

        Dim paquete1a As Integer = 125
        Dim paquete1b As Integer = 126
        Dim paquete2 As Integer = 127
        Dim paquete3 As Integer = 128
        Dim paquete4 As Integer = 129
        Dim paquete5 As Integer = 130
        Dim paquetemicotoxinas As Integer = 160
        Dim idmicotoxinas As Integer = 161
        Dim idproteinas As Integer = 159
        Dim idmateriaseca As Integer = 164
        Dim idph As Integer = 165
        Dim idfibraefectiva As Integer = 191
        Dim idtimbre As Integer = 86

        Dim preciopaquete1a As Double = 0
        Dim preciopaquete1b As Double = 0
        Dim preciopaquete2 As Double = 0
        Dim preciopaquete3 As Double = 0
        Dim preciopaquete4 As Double = 0
        Dim preciopaquete5 As Double = 0
        Dim preciopaquetemicotoxinas As Double = 0
        Dim preciomicotoxinas As Double = 0
        Dim precioproteinas As Double = 0
        Dim preciomateriaseca As Double = 0
        Dim precioph As Double = 0
        Dim preciofibraefectiva As Double = 0
        Dim preciotimbre As Double = 0

        listamuestras = n.listarporsolicitud(idsol)
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
            lp.ID = paquete1a
            lp = lp.buscar
            preciopaquete1a = lp.PRECIO1
            lp.ID = paquete1b
            lp = lp.buscar
            preciopaquete1b = lp.PRECIO1
            lp.ID = paquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO1
            lp.ID = paquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO1
            lp.ID = paquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO1
            lp.ID = paquete5
            lp = lp.buscar
            preciopaquete5 = lp.PRECIO1
            lp.ID = paquetemicotoxinas
            lp = lp.buscar
            preciopaquetemicotoxinas = lp.PRECIO1
            lp.ID = idmicotoxinas
            lp = lp.buscar
            preciomicotoxinas = lp.PRECIO1
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO1
            lp = lp.buscar
            preciomateriaseca = lp.PRECIO1
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO1
            lp.ID = idfibraefectiva
            lp = lp.buscar
            preciofibraefectiva = lp.PRECIO1
            lp.ID = idtimbre
            lp = lp.buscar
            preciotimbre = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = paquete1a
            lp = lp.buscar
            preciopaquete1a = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete1a = lp.PRECIO1
            End If
            lp.ID = paquete1b
            lp = lp.buscar
            preciopaquete1b = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete1b = lp.PRECIO1
            End If
            lp.ID = paquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete2 = lp.PRECIO1
            End If
            lp.ID = paquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete3 = lp.PRECIO1
            End If
            lp.ID = paquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete4 = lp.PRECIO1
            End If
            lp.ID = paquete5
            lp = lp.buscar
            preciopaquete5 = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquete5 = lp.PRECIO1
            End If
            lp.ID = paquetemicotoxinas
            lp = lp.buscar
            preciopaquetemicotoxinas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopaquetemicotoxinas = lp.PRECIO1
            End If
            lp.ID = idmicotoxinas
            lp = lp.buscar
            preciomicotoxinas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomicotoxinas = lp.PRECIO1
            End If
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioproteinas = lp.PRECIO1
            End If
            lp.ID = idmateriaseca
            lp = lp.buscar
            preciomateriaseca = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciomateriaseca = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idfibraefectiva
            lp = lp.buscar
            preciofibraefectiva = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciofibraefectiva = lp.PRECIO1
            End If
            lp.ID = idtimbre
            lp = lp.buscar
            preciotimbre = lp.PRECIO1
        ElseIf precio = 3 Then
            lp.ID = paquete1a
            lp = lp.buscar
            preciopaquete1a = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete1a = lp.PRECIO1
            End If
            lp.ID = paquete1b
            lp = lp.buscar
            preciopaquete1b = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete1b = lp.PRECIO1
            End If
            lp.ID = paquete2
            lp = lp.buscar
            preciopaquete2 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete2 = lp.PRECIO1
            End If
            lp.ID = paquete3
            lp = lp.buscar
            preciopaquete3 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete3 = lp.PRECIO1
            End If
            lp.ID = paquete4
            lp = lp.buscar
            preciopaquete4 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete4 = lp.PRECIO1
            End If
            lp.ID = paquete5
            lp = lp.buscar
            preciopaquete5 = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquete5 = lp.PRECIO1
            End If
            lp.ID = paquetemicotoxinas
            lp = lp.buscar
            preciopaquetemicotoxinas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopaquetemicotoxinas = lp.PRECIO1
            End If
            lp.ID = idmicotoxinas
            lp = lp.buscar
            preciomicotoxinas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomicotoxinas = lp.PRECIO1
            End If
            lp.ID = idproteinas
            lp = lp.buscar
            precioproteinas = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioproteinas = lp.PRECIO1
            End If
            lp.ID = idmateriaseca
            lp = lp.buscar
            preciomateriaseca = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciomateriaseca = lp.PRECIO1
            End If
            lp.ID = idph
            lp = lp.buscar
            precioph = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioph = lp.PRECIO1
            End If
            lp.ID = idfibraefectiva
            lp = lp.buscar
            preciofibraefectiva = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciofibraefectiva = lp.PRECIO1
            End If
            lp.ID = idtimbre
            lp = lp.buscar
            preciotimbre = lp.PRECIO1
        End If

        Dim cuentapaquete1a As Integer = 0
        Dim cuentapaquete1b As Integer = 0
        Dim cuentapaquete2 As Integer = 0
        Dim cuentapaquete3 As Integer = 0
        Dim cuentapaquete4 As Integer = 0
        Dim cuentapaquete5 As Integer = 0
        Dim cuentapaquetemicotoxinas As Integer = 0
        Dim cuentamicotoxinas As Integer = 0
        Dim cuentaproteinas As Integer = 0
        Dim cuentamateriaseca As Integer = 0
        Dim cuentaph As Integer = 0
        Dim cuentafibraefectiva As Integer = 0


        Dim sn2 As New dSolicitudNutricion
        Dim listaanalisis As New ArrayList
        listaanalisis = sn2.listarporsolicitud(idsol)
        If Not listaanalisis Is Nothing Then
            For Each sn2 In listaanalisis

                If sn2.MGA = 1 Then
                    cuentapaquete1a = cuentapaquete1a + 1
                End If
                If sn2.MGB = 1 Then
                    cuentapaquete1b = cuentapaquete1b + 1
                End If
                If sn2.ENSILADOS = 1 Then
                    cuentapaquete2 = cuentapaquete2 + 1
                End If
                If sn2.PASTURAS = 1 Then
                    cuentapaquete3 = cuentapaquete3 + 1
                End If
                If sn2.EXTETEREO = 1 Then
                    cuentapaquete4 = cuentapaquete4 + 1
                End If
                If sn2.NIDA = 1 Then
                    cuentapaquete5 = cuentapaquete5 + 1
                End If
                If sn2.DON = 1 And sn2.AFLA = 1 And sn2.ZEARA = 1 Then
                    cuentapaquetemicotoxinas = cuentapaquetemicotoxinas + 1
                Else
                    If sn2.DON = 1 Then
                        cuentamicotoxinas = cuentamicotoxinas + 1
                    End If
                    If sn2.AFLA = 1 Then
                        cuentamicotoxinas = cuentamicotoxinas + 1
                    End If
                    If sn2.ZEARA = 1 Then
                        cuentamicotoxinas = cuentamicotoxinas + 1
                    End If
                End If
                If sn2.PROTEINAS = 1 Then
                    cuentaproteinas = cuentaproteinas + 1
                End If
                If sn2.MATERIASECA = 1 Then
                    cuentamateriaseca = cuentamateriaseca + 1
                End If
                If sn2.PH = 1 Then
                    cuentaph = cuentaph + 1
                End If
                If sn2.FIBRAEFECTIVA = 1 Then
                    cuentafibraefectiva = cuentafibraefectiva + 1
                End If
            Next
        End If

        Dim analisis As Integer = 0
        Dim precio1 As Double = 0


        If cuentapaquete1a > 0 Then
            analisis = 125
            precio1 = preciopaquete1a
            totalprecio = totalprecio + precio1
        End If
        If cuentapaquete1b > 0 Then
            analisis = 126
            precio1 = preciopaquete1b
            totalprecio = totalprecio + precio1
        End If
        If cuentapaquete2 > 0 Then
            analisis = 127
            precio1 = preciopaquete2
            totalprecio = totalprecio + precio1
        End If
        If cuentapaquete3 > 0 Then
            analisis = 128
            precio1 = preciopaquete3
            totalprecio = totalprecio + precio1
        End If
        If cuentapaquete4 > 0 Then
            analisis = 129
            precio1 = preciopaquete4
            totalprecio = totalprecio + precio1
        End If
        If cuentapaquete5 > 0 Then
            analisis = 130
            precio1 = preciopaquete5
            totalprecio = totalprecio + precio1
        End If
        If cuentapaquetemicotoxinas > 0 Then
            analisis = 160
            precio1 = preciopaquetemicotoxinas
            totalprecio = totalprecio + precio1
        End If
        If cuentamicotoxinas > 0 Then
            analisis = 161
            precio1 = preciomicotoxinas
            totalprecio = totalprecio + precio1
        End If
        If cuentaproteinas > 0 Then
            analisis = 159
            precio1 = precioproteinas
            totalprecio = totalprecio + precio1
        End If
        If cuentamateriaseca > 0 Then
            analisis = 164
            precio1 = preciomateriaseca
            totalprecio = totalprecio + precio1
        End If
        If cuentaph > 0 Then
            analisis = 165
            precio1 = precioph
            totalprecio = totalprecio + precio1
        End If
        If cuentafibraefectiva > 0 Then
            analisis = 191
            precio1 = preciofibraefectiva
            totalprecio = totalprecio + precio1
        End If
        totalprecio = totalprecio + preciotimbre

    End Sub
End Class