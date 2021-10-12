Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformePAL
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
        RadioEmpresa.Checked = True
    End Sub
#End Region
    Private Sub limpiar()
        TextFicha.Text = ""
        listarfichas()
    End Sub
    Private Sub listarfichas()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarfichasPAL
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

    Private Sub ButtonGenerarInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerarInforme.Click
        If RadioEmpresa.Checked = True Then
            Dim ficha As Long = TextFicha.Text.Trim
            Dim v As New FormSeleccionarTecnicoPAL
            v.ShowDialog()
            creainformeexcel()
            abrirventanaenvio()
            limpiar()
        End If
        If RadioProductor.Checked = True Then
            Dim ficha As Long = TextFicha.Text.Trim
            Dim v As New FormSeleccionarTecnicoPAL
            v.ShowDialog()
            creainformeexcelproductor()
            abrirventanaenvio()
            limpiar()
        End If
    End Sub
    Private Sub abrirventanaenvio()
        Dim v As New FormSubirInformes(Usuario)
        v.ShowDialog()
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
        Dim p As New dPal
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList

        '*****************************
        Dim idsol As Long = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        'sa.marcar(Usuario) 30/08/2018

        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2

        'Poner Titulos
        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)


        x1hoja.Cells(1, 1).columnwidth = 16
        x1hoja.Cells(1, 2).columnwidth = 30
        x1hoja.Cells(1, 3).columnwidth = 12
        x1hoja.Cells(1, 4).columnwidth = 12
        x1hoja.Cells(1, 5).columnwidth = 12
        'x1hoja.Cells(1, 6).columnwidth = 7
        'x1hoja.Cells(1, 7).columnwidth = 4
        'x1hoja.Cells(1, 8).columnwidth = 7
        'x1hoja.Cells(1, 9).columnwidth = 5
        'x1hoja.Cells(1, 10).columnwidth = 5
        'x1hoja.Cells(1, 11).columnwidth = 5
        'x1hoja.Cells(1, 12).columnwidth = 5
        'x1hoja.Cells(1, 13).columnwidth = 7
        x1hoja.Range("A1", "D1").Merge()

        columna = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        x1hoja.Range("B4", "C4").Merge()
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Range("A5", "E5").Merge()
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE LA PRUEBA DE ANILLO EN LECHE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Range("A6", "E6").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "PAL"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Range("A7", "E7").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Requisito sanitario del MGAP, Decreto 2/97."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = sa.ID
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Empresa:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(fila, columna).formula = pro.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Range("C10", "D10").Merge()
        x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Range("C11", "D11").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Técnico responsable:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 1

        Dim paratecnico As String = ""
        If idparatecnico1 = 1 Then
            paratecnico = paratecnico + "Dr. Darío Hirigoyen"
        End If
        If idparatecnico2 = 1 Then
            paratecnico = paratecnico + "Dra. Cecilia Abelenda"
        End If

        If paratecnico <> "" Then
            x1hoja.Cells(fila, columna).formula = paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
        Else
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
        End If
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Ant. Serie."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Dilave 17"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 2
        columna = 1

        lista = p.listarporsolicitud(idsol)

        x1hoja.Cells(fila, columna).Formula = "Matrícula"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Propietario"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "DICOSE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Resultado"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = 1
        fila = fila + 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                Dim sp As New dSolicitudPAL
                Dim produc As New dCliente


                For Each p In lista
                    If p.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(p.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    Dim pe As New dProductorEmpresa
                    pe.IDEMPRESA = sa.IDPRODUCTOR
                    pe.MATRICULA = p.MUESTRA
                    pe = pe.buscarproductorempresa2
                    If Not pe Is Nothing Then
                        produc.ID = pe.IDPRODUCTOR
                        produc = produc.buscar
                        If Not produc Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = produc.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).formula = produc.DICOSE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    pe = Nothing
                    If p.RESULTADO = 0 Then
                        x1hoja.Cells(fila, columna).formula = "Negativo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "Positivo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    If p.FECHA <> "" Then
                        x1hoja.Cells(fila, columna).formula = p.FECHA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If

                    columna = 1
                    fila = fila + 1
                Next
            End If


            '******* CALCULO PRECIO ************************************************************************

            Dim listamuestras As New ArrayList
            listamuestras = p.listarporsolicitud(idsol)
            Dim total As Double
            Dim ana As New dAnalisis

            Dim idtimbre As Integer = 86
            Dim idpal1 As Integer = 6
            Dim idpal2 As Integer = 119
            Dim idpal3 As Integer = 120


            Dim preciotimbre As Double
            Dim preciopal1 As Double
            Dim preciopal2 As Double
            Dim preciopal3 As Double

            ana.ID = idtimbre
            ana = ana.buscar
            preciotimbre = ana.COSTO


            ana.ID = idpal1
            ana = ana.buscar
            preciopal1 = ana.COSTO

            ana.ID = idpal2
            ana = ana.buscar
            preciopal2 = ana.COSTO

            ana.ID = idpal3
            ana = ana.buscar
            preciopal3 = ana.COSTO


            Dim muestras As Integer = 0
            muestras = listamuestras.Count

            If muestras = 1 Then
                total = muestras * preciopal1
                total = total + preciotimbre
            ElseIf muestras > 1 And muestras < 22 Then
                total = muestras * preciopal2
                total = total + preciotimbre
            ElseIf muestras > 22 Then
                total = muestras * preciopal3
                total = total + preciotimbre
            End If

            '/* Actualiza el importe en la solicitud 
            Dim saimp As New dSolicitudAnalisis
            Dim importesa As Double = total
            saimp.ID = idsol
            saimp.actualizarimporte(importesa)
            '***************************************/

            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & Math.Round(total, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
            x1hoja.Cells(fila, columna).Font.Bold = True

            columna = 1
            fila = fila + 1

            x1libro.Worksheets(1).cells(fila, columna).select()
            x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
            x1libro.Worksheets(1).cells(2, 1).select()


            fila = fila + 4


            '*******************************************************************
            columna = 1
            fila = fila + 1
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

        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\PAL\" & idsol & ".xls")

        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub creainformeexcelproductor()
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
        Dim p As New dPal
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList

        '*****************************
        Dim idsol As Long = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        'sa.marcar(Usuario) 30/08/2018

        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2

        'Poner Titulos
        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)


        x1hoja.Cells(1, 1).columnwidth = 16
        x1hoja.Cells(1, 2).columnwidth = 30
        x1hoja.Cells(1, 3).columnwidth = 12
        x1hoja.Cells(1, 4).columnwidth = 12
        x1hoja.Cells(1, 5).columnwidth = 12
        'x1hoja.Cells(1, 6).columnwidth = 7
        'x1hoja.Cells(1, 7).columnwidth = 4
        'x1hoja.Cells(1, 8).columnwidth = 7
        'x1hoja.Cells(1, 9).columnwidth = 5
        'x1hoja.Cells(1, 10).columnwidth = 5
        'x1hoja.Cells(1, 11).columnwidth = 5
        'x1hoja.Cells(1, 12).columnwidth = 5
        'x1hoja.Cells(1, 13).columnwidth = 7
        x1hoja.Range("A1", "D1").Merge()

        columna = 2
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        x1hoja.Range("B4", "C4").Merge()
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Range("A5", "E5").Merge()
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DE LA PRUEBA DE ANILLO EN LECHE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Range("A6", "E6").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "PAL"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 1
        x1hoja.Range("A7", "E7").Merge()
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Requisito sanitario del MGAP, Decreto 2/97."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = sa.ID
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Empresa:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(fila, columna).formula = pro.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "DICOSE:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = pro.DICOSE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Dirección:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = pro.DIRECCION
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Range("C10", "D10").Merge()
        x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Range("C11", "D11").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Técnico responsable:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 1

        Dim paratecnico As String = ""
        If idparatecnico1 = 1 Then
            paratecnico = paratecnico + "Dr. Darío Hirigoyen"
        End If
        If idparatecnico2 = 1 Then
            paratecnico = paratecnico + "Dra. Cecilia Abelenda"
        End If

        If paratecnico <> "" Then
            x1hoja.Cells(fila, columna).formula = paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
        Else
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 10
        End If
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Ant. Serie."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Dilave 17"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 2
        columna = 1

        lista = p.listarporsolicitud(idsol)

        x1hoja.Cells(fila, columna).Formula = "Matrícula"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "Propietario"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = "DICOSE"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        'columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Vacas"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Resultado"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Fecha proceso"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = 1
        fila = fila + 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                Dim sp As New dSolicitudPAL
                Dim produc As New dCliente


                For Each p In lista
                    If p.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(p.MUESTRA)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    'Dim pe As New dProductorEmpresa
                    'pe.IDEMPRESA = sa.IDPRODUCTOR
                    'pe.MATRICULA = p.MUESTRA
                    'pe = pe.buscarproductorempresa2
                    'If Not pe Is Nothing Then
                    '    produc.ID = pe.IDPRODUCTOR
                    '    produc = produc.buscar
                    '    If Not produc Is Nothing Then
                    '        x1hoja.Cells(fila, columna).formula = produc.NOMBRE
                    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '        x1hoja.Cells(fila, columna).Font.Size = 10
                    '        columna = columna + 1
                    '        x1hoja.Cells(fila, columna).formula = produc.DICOSE
                    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '        x1hoja.Cells(fila, columna).Font.Size = 10
                    '        columna = columna + 1
                    '    Else
                    '        x1hoja.Cells(fila, columna).formula = ""
                    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '        x1hoja.Cells(fila, columna).Font.Size = 10
                    '        columna = columna + 1
                    '        x1hoja.Cells(fila, columna).formula = ""
                    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '        x1hoja.Cells(fila, columna).Font.Size = 10
                    '        columna = columna + 1
                    '    End If
                    'Else
                    '    x1hoja.Cells(fila, columna).formula = ""
                    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '    x1hoja.Cells(fila, columna).Font.Size = 10
                    '    columna = columna + 1
                    '    x1hoja.Cells(fila, columna).formula = ""
                    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '    x1hoja.Cells(fila, columna).Font.Size = 10
                    '    columna = columna + 1
                    'End If
                    'pe = Nothing
                    sp.FICHA = sa.ID
                    sp = sp.buscar
                    If Not sp Is Nothing Then
                        If sp.VACAS > 0 Then
                            x1hoja.Cells(fila, columna).formula = sp.VACAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                        End If
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If

                    If p.RESULTADO = 0 Then
                        x1hoja.Cells(fila, columna).formula = "Negativo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "Positivo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    If p.FECHA <> "" Then
                        x1hoja.Cells(fila, columna).formula = p.FECHA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "-"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If

                    columna = 1
                    fila = fila + 1
                Next
            End If


            '******* CALCULO PRECIO ************************************************************************

            Dim listamuestras As New ArrayList
            listamuestras = p.listarporsolicitud(idsol)
            Dim total As Double
            Dim ana As New dAnalisis

            Dim idtimbre As Integer = 86
            Dim idpal1 As Integer = 6
            Dim idpal2 As Integer = 119
            Dim idpal3 As Integer = 120


            Dim preciotimbre As Double
            Dim preciopal1 As Double
            Dim preciopal2 As Double
            Dim preciopal3 As Double

            ana.ID = idtimbre
            ana = ana.buscar
            preciotimbre = ana.COSTO


            ana.ID = idpal1
            ana = ana.buscar
            preciopal1 = ana.COSTO

            ana.ID = idpal2
            ana = ana.buscar
            preciopal2 = ana.COSTO

            ana.ID = idpal3
            ana = ana.buscar
            preciopal3 = ana.COSTO


            Dim muestras As Integer = 0
            muestras = listamuestras.Count

            If muestras = 1 Then
                total = muestras * preciopal1
                total = total + preciotimbre
            ElseIf muestras > 1 And muestras < 22 Then
                total = muestras * preciopal2
                total = total + preciotimbre
            ElseIf muestras > 22 Then
                total = muestras * preciopal3
                total = total + preciotimbre
            End If

            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & Math.Round(total, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True

            columna = 1
            fila = fila + 1

            x1libro.Worksheets(1).cells(fila, columna).select()
            x1libro.ActiveSheet.pictures.Insert("c:\Debug\cecilia.jpg").select()
            x1libro.Worksheets(1).cells(2, 1).select()


            fila = fila + 4


            '*******************************************************************
            columna = 1
            fila = fila + 1
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

        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\PAL\" & idsol & ".xls")

        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub RadioProductor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProductor.CheckedChanged

    End Sub
End Class