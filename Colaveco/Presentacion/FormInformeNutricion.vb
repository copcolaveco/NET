Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeNutricion
    Private _usuario As dUsuario
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


        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim n As New dNutricion
        Dim sn As New dSolicitudNutricion
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        '*****************************

        Dim idsol As Long = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        lista = n.listarporsolicitud(idsol)
        lista2 = sn.listarporsolicitud(idsol)

        '*****************************
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
                x1hoja.Cells(fila, columna).Formula = "INFORME DE AGRO NUTRICIÓN"
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
                For Each sn In lista2
                    texto = texto & " - " & sn.MUESTRA
                    texto2 = texto2 & "// " & sn.MUESTRA
                    If sn.MGA = 1 Then
                        texto2 = texto2 & "- MS, Cenizas, PB, FND, FAD, Cálculo de energía. "
                    End If
                    If sn.MGB = 1 Then
                        texto2 = texto2 & "- MS, Cenizas, PB, FC."
                    End If
                    If sn.ENSILADOS = 1 Then
                        texto2 = texto2 & " - MS, PB, pH, Cenizas, FAD, FND, Cálculo de energía. "
                    End If
                    If sn.PASTURAS = 1 Then
                        texto2 = texto2 & " - MS, Cenizas, PB, FND, FAD, Cálculo de energía. "
                    End If
                    If sn.EXTETEREO = 1 Then
                        texto2 = texto2 & " - Extracto etéreo "
                    End If
                    If sn.NIDA = 1 Then
                        texto2 = texto2 & " - NIDA "
                    End If
                    If sn.MICOTOXINAS = 1 Then
                        texto2 = texto2 & " - MICOTOXINAS "
                    End If
                Next

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

                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "INFORME"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                Dim linea As Integer = 0
                Dim i As Integer = 1

                For Each n In lista


                    '1 MUESTRA ****************************************************************
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
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.FCH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.FCH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.FCH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.FCH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.FCH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.CENIZASH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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
                            x1hoja.Cells(fila, columna).Formula = n.FCH
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
                            If Not metodo Is Nothing Then
                                x1hoja.Cells(fila, columna).Formula = metodo.ESTANDAR
                                x1hoja.Cells(fila, columna).WrapText = True
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


                    i = i + 1
                Next

                '***************************************

                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "(MS = Materia Seca - FND = Fibra Neutro Detergente - FDA = Fibra Ácido detergente - PB = Proteína Bruta - FC = Fibra Cruda)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6

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
                Dim preciotimbre As Double = 0
                Dim preciopaquete1a As Double = 0
                Dim preciopaquete1b As Double = 0
                Dim preciopaquete2 As Double = 0
                Dim preciopaquete3 As Double = 0
                Dim preciopaquete4 As Double = 0
                Dim preciopaquete5 As Double = 0


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

                Dim total As Double = 0
                Dim sn2 As New dSolicitudNutricion
                Dim lista3 As New ArrayList
                lista3 = sn2.listarporsolicitud(idsol)

                For Each sn2 In lista3

                    If sn.MGA = 1 Then
                        total = total + preciopaquete1a
                    End If
                    If sn.MGB = 1 Then
                        total = total + preciopaquete1b
                    End If
                    If sn.ENSILADOS = 1 Then
                        total = total + preciopaquete2
                    End If
                    If sn.PASTURAS = 1 Then
                        total = total + preciopaquete3
                    End If
                    If sn.EXTETEREO = 1 Then
                        total = total + preciopaquete4
                    End If
                    If sn.NIDA = 1 Then
                        total = total + preciopaquete5
                    End If
                Next

                total = total + preciotimbre
                '***********************************************************************************************
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Técnico resp::" & "Dra. MSc. Analía Pérez Ruchel"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Dpto. de Nutrición Animal Fac. Veterinaria)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
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
        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\AGRO - NUTRICION\" & idsol & "_prueba.xls")
        x1app.Visible = True
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
End Class