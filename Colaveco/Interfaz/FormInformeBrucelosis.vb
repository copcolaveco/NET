Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeBrucelosis
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
        RadioEmpresa.Checked = True
        Usuario = u

    End Sub
#End Region
    Private Sub limpiar()
        TextFicha.Text = ""
        listarfichas()
    End Sub
    Private Sub abrirventanaenvio()
        Dim v As New FormSubirInformes(Usuario)
        v.Show()
    End Sub
    Private Sub listarfichas()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarfichasBrucelosis
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
            creainformeexcelempresa()
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

        'creainformeexcel()
        'abrirventanaenvio()
        'limpiar()
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

        Dim l As New dBrucelosis
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim listapos As New ArrayList
        Dim listaneg As New ArrayList
        Dim idsol As Long
        Dim muestras As Integer = 0
        Dim muestraspos As Integer = 0
        Dim muestrasneg As Integer = 0
        Dim listadopos As String = ""
        Dim listadoneg As String = ""
        '*****************************

        idsol = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        '*****************************

        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
        Microsoft.Office.Core.MsoTriState.msoFalse, _
       Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)

        x1libro.Worksheets(1).cells(3, 1).select()
        x1hoja.Cells(3, 1).columnwidth = 10
        x1hoja.Cells(3, 2).columnwidth = 20
        x1hoja.Cells(3, 3).columnwidth = 12
        x1hoja.Cells(3, 4).columnwidth = 4
        x1hoja.Cells(3, 5).columnwidth = 4
        x1hoja.Cells(3, 6).columnwidth = 4
        x1hoja.Cells(3, 7).columnwidth = 4
        x1hoja.Cells(3, 8).columnwidth = 4
        x1hoja.Cells(3, 9).columnwidth = 4
        x1hoja.Cells(3, 10).columnwidth = 4
        x1hoja.Cells(3, 11).columnwidth = 4

        x1hoja.Range("B1", "J1").Merge()
        x1hoja.Cells(1, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(1, 2).Formula = "   Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(1, 2).Font.Bold = True
        x1hoja.Cells(1, 2).Font.Size = 9
        x1hoja.Range("B2", "J2").Merge()
        x1hoja.Cells(2, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(2, 2).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(2, 2).Font.Bold = True
        x1hoja.Cells(2, 2).Font.Size = 9
        x1hoja.Range("B4", "J4").Merge()
        x1hoja.Cells(4, 2).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(4, 2).Formula = "INFORME DE BRUCELOSIS EN LECHE"
        x1hoja.Cells(4, 2).Font.Bold = True
        x1hoja.Cells(4, 2).Font.Size = 12
        x1hoja.Cells(6, 1).Formula = "Nº Ficha:"
        x1hoja.Cells(6, 1).Font.Bold = True
        x1hoja.Cells(6, 1).Font.Size = 9
        x1hoja.Cells(6, 4).Formula = "Fecha entrada:"
        x1hoja.Cells(6, 4).Font.Bold = True
        x1hoja.Cells(6, 4).Font.Size = 9
        x1hoja.Cells(7, 1).Formula = "Cliente:"
        x1hoja.Cells(7, 1).Font.Bold = True
        x1hoja.Cells(7, 1).Font.Size = 9
        x1hoja.Cells(7, 4).Formula = "Fecha proceso:"
        x1hoja.Cells(7, 4).Font.Bold = True
        x1hoja.Cells(7, 4).Font.Size = 9
        x1hoja.Cells(8, 4).Formula = "Material recibido:"
        x1hoja.Cells(8, 4).Font.Bold = True
        x1hoja.Cells(8, 4).Font.Size = 9
        x1hoja.Cells(8, 1).Formula = "Dirección:"
        x1hoja.Cells(8, 1).Font.Bold = True
        x1hoja.Cells(8, 1).Font.Size = 9
        x1hoja.Cells(9, 1).Formula = "Técnico:"
        x1hoja.Cells(9, 1).Font.Bold = True
        x1hoja.Cells(9, 1).Font.Size = 9
        x1hoja.Cells(10, 1).Formula = "DICOSE:"
        x1hoja.Cells(10, 1).Font.Bold = True
        x1hoja.Cells(10, 1).Font.Size = 9
        x1hoja.Cells(9, 4).Formula = "Estudio solicitado:"
        x1hoja.Cells(9, 4).Font.Bold = True
        x1hoja.Cells(9, 4).Font.Size = 9
        x1hoja.Cells(10, 4).Formula = "Muestras:"
        x1hoja.Cells(10, 4).Font.Bold = True
        x1hoja.Cells(10, 4).Font.Size = 9


        x1hoja.Cells(12, 1).Formula = "Observaciones:"
        x1hoja.Cells(12, 1).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(12, 1).Font.Bold = True
        x1hoja.Cells(12, 1).Font.Size = 9

        x1hoja.Cells(13, 1).Formula = sa.OBSERVACIONES
        x1hoja.Cells(13, 1).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(13, 1).Font.Bold = False
        x1hoja.Cells(13, 1).Font.Size = 9

        x1hoja.Cells(15, 1).Formula = "PROCESAMIENTO"
        x1hoja.Cells(15, 1).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(15, 1).Font.Bold = True
        x1hoja.Cells(15, 1).Font.Size = 9

        x1hoja.Range("A16", "B16").Merge()
        x1hoja.Cells(16, 1).Formula = "Análisis: Brucelosis Bovina"
        x1hoja.Cells(16, 1).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(16, 1).Font.Bold = True

        x1hoja.Range("A17", "B17").Merge()
        x1hoja.Cells(17, 1).Formula = "Método: ELISA"
        x1hoja.Cells(17, 1).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(17, 1).Font.Bold = True

        '***************************************

        x1hoja.Cells(6, 2).formula = sa.ID
        x1hoja.Cells(6, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(7, 2).formula = pro.NOMBRE
        x1hoja.Cells(7, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 2).Font.Size = 9
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(8, 2).formula = pro.DIRECCION
            x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(8, 2).Font.Size = 9
        Else
            x1hoja.Cells(8, 2).formula = "No aportado"
            x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(8, 2).Font.Size = 9
        End If
        If pro.DICOSE <> "" Then
            x1hoja.Cells(10, 2).formula = pro.DICOSE
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        Else
            x1hoja.Cells(10, 2).formula = "No aportado"
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        End If
        tec.ID = pro.TECNICO1
        If tec.ID > 0 Then
            tec = tec.buscar
        Else
            x1hoja.Cells(9, 2).formula = "No aportado"
        End If
        If Not tec.NOMBRE Is Nothing Then
            x1hoja.Cells(9, 2).formula = tec.NOMBRE
        Else
            x1hoja.Cells(9, 2).formula = "No aportado"
        End If
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9



        Dim fechaem As Date = Now()
        Dim fechaemi As String = fechaem.ToString("dd/MM/yyyy")

        l.FICHA = idsol
        l = l.buscarxficha

        'lista = l.listarporsolicitud(idsol)
        x1hoja.Range("H6", "J6").Merge()
        x1hoja.Cells(6, 8).formula = sa.FECHAINGRESO
        x1hoja.Cells(6, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 8).Font.Size = 9
        x1hoja.Range("H7", "J7").Merge()
        x1hoja.Cells(7, 8).formula = l.FECHA
        x1hoja.Cells(7, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 8).Font.Size = 9
        x1hoja.Range("H8", "J8").Merge()
        x1hoja.Cells(8, 8).formula = "Leche"
        x1hoja.Cells(8, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 8).Font.Size = 9
        x1hoja.Range("H9", "J9").Merge()
        x1hoja.Cells(9, 8).formula = "Brucelosis"
        x1hoja.Cells(9, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 8).Font.Size = 9


        lista = l.listarporsolicitud(idsol)
        listapos = l.listarporfichapos(idsol)
        listaneg = l.listarporfichaneg(idsol)
        muestras = lista.Count

        'Cantidad de muestras ------------------------------------------
        x1hoja.Cells(10, 8).formula = muestras
        x1hoja.Cells(10, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(10, 8).Font.Size = 9
        '---------------------------------------------------------------
        'Muestras positivas y negativas --------------------------------
        x1hoja.Range("C16", "H16").Merge()
        If Not listapos Is Nothing Then
            If listapos.Count > 0 Then
                x1hoja.Cells(16, 3).Formula = "Muestras positivas: " & listapos.Count
                x1hoja.Cells(16, 3).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(16, 3).Font.Bold = True
            Else
                x1hoja.Cells(16, 3).Formula = "Muestras positivas: 0"
                x1hoja.Cells(16, 3).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(16, 3).Font.Bold = True
            End If
        End If
        x1hoja.Range("C17", "H17").Merge()
        If Not listaneg Is Nothing Then
            If listaneg.Count > 0 Then
                x1hoja.Cells(17, 3).Formula = "Muestras negativas: " & listaneg.Count
                x1hoja.Cells(17, 3).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(17, 3).Font.Bold = True
            Else
                x1hoja.Cells(17, 3).Formula = "Muestras negativas: 0"
                x1hoja.Cells(17, 3).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(17, 3).Font.Bold = True
            End If
        End If
        '---------------------------------------------------------------

        If Not listapos Is Nothing Then
            If listapos.Count > 0 Then
                muestraspos = listapos.Count
            End If
        End If
        If Not listaneg Is Nothing Then
            If listaneg.Count > 0 Then
                muestrasneg = listaneg.Count
            End If
        End If
        Dim fila As Integer
        Dim columna As Integer
        fila = 19
        columna = 1
        If Not listapos Is Nothing Then
            If listapos.Count > 0 Then
                For Each l In listapos
                    listadopos = listadopos & l.MUESTRA & " - "
                Next
            End If
        End If

        If Not listaneg Is Nothing Then
            If listaneg.Count > 0 Then
                For Each l In listaneg
                    listadoneg = listadoneg & l.MUESTRA & " - "
                Next
            End If
        End If

        x1hoja.Cells(19, 1).formula = "RESULTADO:"
        x1hoja.Cells(19, 1).Font.Size = 10
        x1hoja.Cells(19, 1).Font.Bold = True

        x1hoja.Cells(21, 1).formula = "Las siguientes muestras resultaron positivas"
        x1hoja.Cells(21, 1).Font.Size = 9
        x1hoja.Cells(21, 1).Font.Bold = True
        x1hoja.Range("A22", "K25").Merge()

        If listadopos <> "" Then
            x1hoja.Cells(22, 1).formula = listadopos
            x1hoja.Cells(22, 1).Font.Size = 9
            x1hoja.Range("A22", "K25").WrapText = True
            x1hoja.Cells(22, 1).VerticalAlignment = XlHAlign.xlHAlignGeneral
        Else
            x1hoja.Cells(22, 1).formula = "No se encontraron muestras positivas"
            x1hoja.Cells(22, 1).Font.Size = 9
            x1hoja.Range("A22", "K25").WrapText = True
            x1hoja.Cells(22, 1).VerticalAlignment = XlHAlign.xlHAlignGeneral
        End If

        x1hoja.Cells(27, 1).formula = "Las siguientes muestras resultaron negativas"
        x1hoja.Cells(27, 1).Font.Size = 9
        x1hoja.Cells(27, 1).Font.Bold = True
        x1hoja.Range("A28", "K31").Merge()

        If listadoneg <> "" Then
            x1hoja.Cells(28, 1).formula = listadoneg
            x1hoja.Cells(28, 1).Font.Size = 9
            x1hoja.Range("A28", "K31").WrapText = True
            x1hoja.Cells(28, 1).VerticalAlignment = XlHAlign.xlHAlignGeneral
        Else
            x1hoja.Cells(28, 1).formula = "No se encontraron muestras negativas"
            x1hoja.Cells(28, 1).Font.Size = 9
            x1hoja.Range("A28", "K31").WrapText = True
            x1hoja.Cells(28, 1).VerticalAlignment = XlHAlign.xlHAlignGeneral
        End If

        '******* CALCULO PRECIO ************************************************************************
        Dim total As Integer = 0
        Dim ana As New dAnalisis
        Dim idbrucelosis As Integer = 124
        Dim preciobrucelosis As Double = 0
        Dim idtimbre As Integer = 86
        Dim preciotimbre As Double = 0

        ana.ID = idbrucelosis
        ana = ana.buscar
        preciobrucelosis = ana.COSTO
        ana.ID = idtimbre
        ana = ana.buscar
        preciotimbre = ana.COSTO
        total = Math.Round((muestras * preciobrucelosis) + preciotimbre, 2)

        '/* Actualiza el importe en la solicitud 
        Dim saimp As New dSolicitudAnalisis
        Dim importesa As Double = total
        saimp.ID = idsol
        saimp.actualizarimporte(importesa)
        '***************************************/
        '***********************************************************************************************
        fila = 33
        columna = 1

        'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'columna = columna + 3
        x1hoja.Cells(fila, columna).formula = "Técnico responsable: Cecilia Abelenda"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        'columna = 1
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 2

        x1libro.Worksheets(1).cells(fila, columna).select()
        Dim rangeFirma As String = "A" + fila.ToString
        x1libro.ActiveSheet.Range(rangeFirma).select()
        InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
        x1libro.Worksheets(1).cells(fila, columna).select()

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
        x1hoja.Range("A" & fila, "F" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7

        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\Brucelosis en leche\" & idsol & ".xls")


        x1app.Visible = True

        ' x1libro.Close()
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

    Private Sub RadioEmpresa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEmpresa.CheckedChanged

    End Sub

    Private Sub RadioProductor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProductor.CheckedChanged

    End Sub
    Private Sub creainformeexcelempresa()
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
        Dim b As New dBrucelosis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim muestras As Integer = 0
        '*****************************
        Dim idsol As Long = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
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
        x1hoja.Cells(fila, columna).Formula = "INFORME DE BRUCELOSIS EN LECHE"
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
        x1hoja.Cells(fila, columna).Formula = "Análisis:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Brucelosis Bovina"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Método: ELISA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        columna = 1
        lista = b.listarporsolicitud(idsol)
        If lista.Count > 0 Then
            muestras = lista.Count
        End If
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
                'Dim sp As New dSolicitudPAL
                For Each b In lista
                    If b.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(b.MUESTRA)
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
                    pe.MATRICULA = b.MUESTRA
                    pe = pe.buscarproductorempresa2
                    If Not pe Is Nothing Then
                        Dim produc As New dCliente
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
                    If b.RESULTADO = 0 Then
                        x1hoja.Cells(fila, columna).formula = "Negativo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    ElseIf b.RESULTADO = 1 Then
                        x1hoja.Cells(fila, columna).formula = "Positivo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "Dudoso"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    If b.FECHA <> "" Then
                        x1hoja.Cells(fila, columna).formula = b.FECHA
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
            Dim total As Integer = 0
            Dim ana As New dAnalisis
            Dim idbrucelosis As Integer = 124
            Dim preciobrucelosis As Double = 0
            Dim idtimbre As Integer = 86
            Dim preciotimbre As Double = 0

            ana.ID = idbrucelosis
            ana = ana.buscar
            preciobrucelosis = ana.COSTO
            ana.ID = idtimbre
            ana = ana.buscar
            preciotimbre = ana.COSTO
            total = Math.Round((muestras * preciobrucelosis) + preciotimbre, 2)
            '/* Actualiza el importe en la solicitud 
            Dim saimp As New dSolicitudAnalisis
            Dim importesa As Double = total
            saimp.ID = idsol
            saimp.actualizarimporte(importesa)
            '***********************************************************************************************
            fila = fila + 1
            Dim paratecnico As String = ""
            If idparatecnico1 = 1 Then
                paratecnico = paratecnico + "Dr. Darío Hirigoyen"
            End If
            If idparatecnico2 = 1 Then
                paratecnico = paratecnico + "Dra. Cecilia Abelenda"
            End If
            x1hoja.Cells(fila, columna).formula = "Técnico responsable:" & " " & paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 2
            x1libro.Worksheets(1).cells(fila, columna).select()
            Dim rangeFirma As String = "A" + fila.ToString
            x1libro.ActiveSheet.Range(rangeFirma).select()
            InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
            x1libro.Worksheets(1).cells(fila, columna).select()
            fila = fila + 5
            columna = 1
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
            x1hoja.Range("A" & fila, "F" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).rowheight = 8
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Formula = "Fin del informe."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 7
        End If

        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        Try
            x1hoja.SaveAs("\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & idsol & ".xls")
        Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            'MessageBox.Show("Falla al grabar!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        '***********************************
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
            pi2.TIPO = 15
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '************************************
        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        abrirventanaenvio2()
    End Sub
    Private Sub creainformeexcelproductor()
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
        Dim b As New dBrucelosis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim muestras As Integer = 0
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
        'x1hoja.Cells(1, 2).columnwidth = 30
        x1hoja.Cells(1, 2).columnwidth = 12
        x1hoja.Cells(1, 3).columnwidth = 12
        x1hoja.Cells(1, 4).columnwidth = 12
        'x1hoja.Cells(1, 5).columnwidth = 12
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
        x1hoja.Cells(fila, columna).Formula = "INFORME DE BRUCELOSIS EN LECHE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        'fila = fila + 1
        'x1hoja.Range("A6", "E6").Merge()
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        'x1hoja.Cells(fila, columna).Formula = "PAL"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 9
        'fila = fila + 1
        'x1hoja.Range("A7", "E7").Merge()
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        'x1hoja.Cells(fila, columna).Formula = "Requisito sanitario del MGAP, Decreto 2/97."
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
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
        x1hoja.Cells(fila, columna).Formula = "Productor:"
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
        x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 1
        columna = 1
        'x1hoja.Cells(fila, columna).Formula = "Técnico responsable:"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 7
        'columna = columna + 1

        'Dim paratecnico As String = ""
        'If idparatecnico1 = 1 Then
        '    paratecnico = paratecnico + "Dr. Darío Hirigoyen"
        'End If
        'If idparatecnico2 = 1 Then
        '    paratecnico = paratecnico + "Dra. Cecilia Abelenda"
        'End If

        'If paratecnico <> "" Then
        '    x1hoja.Cells(fila, columna).formula = paratecnico
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 10
        'Else
        '    x1hoja.Cells(fila, columna).formula = ""
        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        '    x1hoja.Cells(fila, columna).Font.Size = 10
        'End If
        'fila = fila + 1
        'columna = 1
        x1hoja.Cells(fila, columna).Formula = "Análisis:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Brucelosis Bovina"
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 2
        x1hoja.Cells(fila, columna).Formula = "Método: ELISA"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10

        fila = fila + 2
        columna = 2

        lista = b.listarporsolicitud(idsol)
        If lista.Count > 0 Then
            muestras = lista.Count
        End If

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
        'x1hoja.Cells(fila, columna).Formula = "Vacas"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        'columna = columna + 1
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
        columna = 2
        fila = fila + 1

        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                Dim sp As New dSolicitudPAL
                Dim produc As New dCliente


                For Each b In lista
                    If b.MUESTRA <> "" Then
                        x1hoja.Cells(fila, columna).formula = Trim(b.MUESTRA)
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

                    'sp.ficha = sa.ID
                    'sp = sp.buscar
                    'If Not sp Is Nothing Then
                    '    If sp.VACAS > 0 Then
                    '        x1hoja.Cells(fila, columna).formula = sp.VACAS
                    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '        x1hoja.Cells(fila, columna).Font.Size = 10
                    '        columna = columna + 1
                    '    Else
                    '        x1hoja.Cells(fila, columna).formula = "-"
                    '        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    '        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '        x1hoja.Cells(fila, columna).Font.Size = 10
                    '        columna = columna + 1
                    '    End If
                    'Else
                    '    x1hoja.Cells(fila, columna).formula = "-"
                    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    '    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    '    x1hoja.Cells(fila, columna).Font.Size = 10
                    '    columna = columna + 1
                    'End If

                    If b.RESULTADO = 0 Then
                        x1hoja.Cells(fila, columna).formula = "Negativo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    ElseIf b.RESULTADO = 1 Then
                        x1hoja.Cells(fila, columna).formula = "Positivo"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "Dudoso"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    If b.FECHA <> "" Then
                        x1hoja.Cells(fila, columna).formula = b.FECHA
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

                    columna = 2
                    fila = fila + 1
                Next
            End If
            columna = 1

            '******* CALCULO PRECIO ************************************************************************
            Dim total As Integer = 0
            Dim ana As New dAnalisis
            Dim idbrucelosis As Integer = 124
            Dim preciobrucelosis As Double = 0
            Dim idtimbre As Integer = 86
            Dim preciotimbre As Double = 0

            ana.ID = idbrucelosis
            ana = ana.buscar
            preciobrucelosis = ana.COSTO
            ana.ID = idtimbre
            ana = ana.buscar
            preciotimbre = ana.COSTO
            total = Math.Round((muestras * preciobrucelosis) + preciotimbre, 2)

            '/* Actualiza el importe en la solicitud 
            Dim saimp As New dSolicitudAnalisis
            Dim importesa As Double = total
            saimp.ID = idsol
            saimp.actualizarimporte(importesa)
            '***************************************/
            '***********************************************************************************************
            fila = fila + 1
            'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
            'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            'x1hoja.Cells(fila, columna).Font.Size = 8
            'x1hoja.Cells(fila, columna).Font.Bold = True
            'columna = columna + 3

            Dim paratecnico As String = ""
            If idparatecnico1 = 1 Then
                paratecnico = paratecnico + "Dr. Darío Hirigoyen"
            End If
            If idparatecnico2 = 1 Then
                paratecnico = paratecnico + "Dra. Cecilia Abelenda"
            End If

            x1hoja.Cells(fila, columna).formula = "Técnico responsable:" & " " & paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            'columna = 1
            'fila = fila + 1
            'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
            'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            'x1hoja.Cells(fila, columna).Font.Size = 8
            'x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 2

            x1libro.Worksheets(1).cells(fila, columna).select()
            Dim rangeFirma As String = "A" + fila.ToString
            x1libro.ActiveSheet.Range(rangeFirma).select()
            InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
            x1libro.Worksheets(1).cells(fila, columna).select()

            columna = 1
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
            x1hoja.Range("A" & fila, "F" & fila).Merge()
            x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
            x1hoja.Cells(fila, columna).rowheight = 8
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
            x1hoja.Cells(fila, columna).Formula = "Fin del informe."
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 7

        End If

        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas

        Try
            x1hoja.SaveAs("\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & idsol & ".xls")
        Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            'MessageBox.Show("Falla al grabar!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        'Try
        '    x1hoja.SaveAs("\\SRVDATOS\D\NET\PREINFORMES\BRUCELOSIS_LECHE\" & idsol & ".xls")
        'Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
        '    'MessageBox.Show("Falla al grabar!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try



        '***********************************
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
            pi2.TIPO = 15
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '************************************

        x1app.Visible = True
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

        abrirventanaenvio2()
    End Sub
    Private Sub abrirventanaenvio2()
        Dim v As New FormSubirInformes2(Usuario)
        v.Show()
    End Sub
End Class