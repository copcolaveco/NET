Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeLeucosis
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
    Private Sub limpiar()
        TextFicha.Text = ""
        listarfichas()
    End Sub
    Private Sub abrirventanaenvio()
        'Dim v As New FormSubirInformes(Usuario)
        'v.ShowDialog()
    End Sub
    Private Sub listarfichas()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarfichasleucosis
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
        
        creainformeexcel()
        abririnformeexcel()
        abrirventanaenvio()
        limpiar()
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

        Dim l As New dLeucosis
        'Dim moa24 As New dMOA24
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
        x1hoja.Cells(4, 2).Formula = "INFORME DE LEUCOSIS"
        x1hoja.Cells(4, 2).Font.Bold = True
        x1hoja.Cells(4, 2).Font.Size = 9
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
        x1hoja.Cells(10, 1).Formula = "Muestras:"
        x1hoja.Cells(10, 1).Font.Bold = True
        x1hoja.Cells(10, 1).Font.Size = 9
        x1hoja.Cells(9, 4).Formula = "Estudio solicitado:"
        x1hoja.Cells(9, 4).Font.Bold = True
        x1hoja.Cells(9, 4).Font.Size = 9

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
        x1hoja.Cells(16, 1).Formula = "Análisis: Leucosis Bovina"
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
        x1hoja.Cells(8, 2).formula = pro.DIRECCION
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 9
        tec.ID = pro.TECNICO1
        If tec.ID > 0 Then
            tec = tec.buscar
        End If
        If Not tec.NOMBRE Is Nothing Then
            x1hoja.Cells(9, 2).formula = tec.NOMBRE
        End If
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9


        Dim fechaem As Date = Now()
        Dim fechaemi As String = fechaem.ToString("dd/MM/yyyy")


        l.FICHA = idsol
        l = l.buscarxficha
        If Not l Is Nothing Then
        Else
            MsgBox("No existe registro con ese número de ficha")
            Exit Sub
        End If


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
        x1hoja.Cells(8, 8).formula = "Sangre"
        x1hoja.Cells(8, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 8).Font.Size = 9
        x1hoja.Range("H9", "J9").Merge()
        x1hoja.Cells(9, 8).formula = "Leucosis"
        x1hoja.Cells(9, 8).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 8).Font.Size = 9


        lista = l.listarporsolicitud(idsol)
        listapos = l.listarporfichapos(idsol)
        listaneg = l.listarporfichaneg(idsol)
        muestras = lista.Count

        'Cantidad de muestras ------------------------------------------
        x1hoja.Cells(10, 2).formula = muestras
        x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(10, 2).Font.Size = 9
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
        Else
            x1hoja.Cells(16, 3).Formula = "Muestras positivas: 0"
            x1hoja.Cells(16, 3).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(16, 3).Font.Bold = True
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
        Else
            x1hoja.Cells(17, 3).Formula = "Muestras negativas: 0"
            x1hoja.Cells(17, 3).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(17, 3).Font.Bold = True
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
        'ListAntibiogramas.Items.Clear()
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

        x1hoja.Cells(19, 1).formula = "Resultado"
        x1hoja.Cells(19, 1).Font.Size = 9
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
            x1hoja.Cells(22, 1).formula = "No se encontraron muestras positivas."
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
            x1hoja.Cells(28, 1).formula = "No se encontraron muestras negativas."
            x1hoja.Cells(28, 1).Font.Size = 9
            x1hoja.Range("A28", "K31").WrapText = True
            x1hoja.Cells(28, 1).VerticalAlignment = XlHAlign.xlHAlignGeneral
        End If
        

        '******* CALCULO PRECIO ************************************************************************


        Dim total As Integer = 0

        Dim ana As New dAnalisis
        Dim idleucosis As Integer = 15
        Dim precioleucosis As Double = 0
        Dim idtimbre As Integer = 86
        Dim preciotimbre As Double = 0


        ana.ID = idleucosis
        ana = ana.buscar
        precioleucosis = ana.COSTO
        ana.ID = idtimbre
        ana = ana.buscar
        preciotimbre = ana.COSTO

        total = Math.Round((muestras * precioleucosis) + preciotimbre, 2)

        '/* Actualiza el importe en la solicitud 
        Dim saimp As New dSolicitudAnalisis
        Dim importesa As Double = total
        saimp.ID = idsol
        saimp.actualizarimporte(importesa)
        '***************************************/

        '***********************************************************************************************
        fila = 33
        columna = 1

        x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 3
        x1hoja.Cells(fila, columna).formula = "Técnico responsable: Cecilia Abelenda"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
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

        x1hoja.Cells(fila, columna).formula = "Este informe no podra ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
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
        x1hoja.Cells(fila, columna).formula = "asi como el plan, procedimientos de muestreo e información brindada por el cliente. Dra. Cecilia Abelenda (DT)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 6








        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\LEUCOSIS\" & idsol & ".xls")
       

        'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("C:\" & idsol & ".xls")

        x1app.Visible = True

        ' x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub abririnformeexcel()

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
End Class