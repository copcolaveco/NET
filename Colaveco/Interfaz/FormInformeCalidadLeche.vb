Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class FormInformeCalidadLeche
    Private _usuario As dUsuario
    Private contador_rc As Integer = 0
    Private id_sol As Long
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
        id_sol = ficha
        Dim s As New dSolicitudAnalisis
        Dim v As New FormSeleccionarTecnico
        v.ShowDialog()
        Dim v2 As New FormObservaciones(Usuario, ficha)
        v2.ShowDialog()

        creainformeexcel()

        
        s.ID = ficha
        s = s.buscar
        Dim productor As Long = 0
        If Not s Is Nothing Then
            productor = s.IDPRODUCTOR
        End If
        If productor = 143 Then
            If CheckBloqueaEcolat.Checked = True Then
                '''''creainformetxt()
                'creartxt()
                'CargarEcolat()
            Else
                creartxt()
                CargarEcolat()
            End If
        End If
        If productor = 6299 Then
            creartxt()
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
        lista = s.listarfichascalidad
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ListFichas().Items.Add(s)
                Next
            End If
        End If
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


        'Dim c As New dCalidad
        Dim csm As New dCalidadSolicitudMuestra

        Dim textoafla As Integer = 0

        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        contador_rc = 0
        '*****************************
        Dim idsol As Long = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        If Not sa Is Nothing Then
            'sa.marcar(Usuario) 30/08/2018
        Else
            MsgBox("No existe una solicitud con ese número!")
            Exit Sub
        End If


        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        'fila = 17
        'columna = 1
        'ListAntibiogramas.Items.Clear()
        fila = 1
        columna = 2

        'Poner Titulos
        'x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
        ' Microsoft.Office.Core.MsoTriState.msoFalse, _
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)

        x1hoja.Shapes.AddPicture("c:\Debug\encabezado.jpg", _
               Microsoft.Office.Core.MsoTriState.msoFalse, _
               Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)

        'x1hoja.Shapes.AddPicture("c:\Debug\oua.jpg", _
        ' Microsoft.Office.Core.MsoTriState.msoFalse, _
        'Microsoft.Office.Core.MsoTriState.msoCTrue, 660, 0, 80, 35)



        x1hoja.Cells(1, 1).columnwidth = 6 '7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5.5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 7 '8
        x1hoja.Cells(1, 12).columnwidth = 7
        x1hoja.Cells(1, 13).columnwidth = 7 '8
        x1hoja.Cells(1, 14).columnwidth = 7
        x1hoja.Range("A1", "D1").Merge()

        columna = 3
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Formula = "    Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("B4", "C4").Merge()
        fila = fila + 1
        columna = columna + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("D5", "L5").Merge()
        fila = fila + 2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME - ANÁLISIS DE LECHE"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 9
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 2
        x1hoja.Cells(fila, columna).formula = sa.ID
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 5
        x1hoja.Cells(fila, columna).Formula = "Métodos y estándares:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Cliente:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 2
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(fila, columna).formula = pro.NOMBRE
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 5
        x1hoja.Range("H8", "M12").Merge()
        x1hoja.Range("H8", "M12").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("H8", "M12").WrapText = True
        x1hoja.Cells(fila, columna).formula = "R. Celular(ISO13366-2:2006); Grasa, Proteína, Lactosa ISO 9622* - IDF141:2013, Crioscopía*, Urea*, Citrato*, Caseína* (Boletín FIL 393/2003); Sólidos totales (Boletín FIL 208/1987): Método IR; R. Bacteriano: Método Citometría de flujo(PE.LAB.62); Inhibidores: Método Delvo Test (PE.LAB.17) / Rosa Charm*; Psicrótrofos*: Téc. rápida en placa (ISO 8552/FIL 132:2004 mod.); Esporulados Anaerobios*: NMP (INTI Lácteos mod); Afla.M1.*(Fluorometría)"

        
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Dirección:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 2
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(fila, columna).formula = pro.DIRECCION
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
        Else
            x1hoja.Cells(fila, columna).formula = "No aportado"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
        End If
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C10", "D10").Merge()
        x1hoja.Cells(fila, columna).formula = sa.FECHAINGRESO
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        x1hoja.Cells(fila, columna).Formula = "Fecha proceso:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C11", "D11").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        Dim cx As New dCalidad
        Dim listacx As New ArrayList
        listacx = cx.listarfechaproceso(sa.ID)
        If Not listacx Is Nothing Then
            For Each cx In listacx
                x1hoja.Cells(fila, columna).formula = cx.FECHA
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                columna = 1
            Next
        Else
            x1hoja.Cells(fila, columna).formula = fecha2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            columna = 1
        End If
        cx = Nothing
        listacx = Nothing
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C12", "D12").Merge()
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Analista:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        Dim paratecnico As String = ""
        'If idparatecnico1 = 1 Then
        '    paratecnico = paratecnico + "Diego Arenas - "
        'End If
        If idparatecnico2 = 1 Then
            paratecnico = paratecnico + "Lorena Nidegger - "
        End If
        If idparatecnico3 = 1 Then
            paratecnico = paratecnico + "Claudia García - "
        End If
        If idparatecnico4 = 1 Then
            paratecnico = paratecnico + "Erika Silva - "
        End If
        If idparatecnico5 = 1 Then
            paratecnico = paratecnico + "Virginia Ferreira - "
        End If
        If idparatecnico6 = 1 Then
            paratecnico = paratecnico + "Jeniffer Melendrez - "
        End If
        If paratecnico <> "" Then
            x1hoja.Cells(fila, columna).formula = paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            columna = 1
        Else
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            fila = fila + 1
            columna = 1
        End If
        x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 6
        Dim valtemperatura = Val(sa.TEMPERATURA)
        If valtemperatura < 1 Or valtemperatura > 7 Then
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        End If
        x1hoja.Cells(fila, columna).formula = sa.TEMPERATURA & " " & "Cº"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        columna = columna + 3
        fila = fila - 1
        x1hoja.Range("J13", "M13").Merge()
        x1hoja.Range("J13", "M13").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("J13", "M13").WrapText = True
        x1hoja.Cells(fila, columna).formula = "* Ensayos no acreditados ISO 17025 por O.U.A."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 6
        fila = fila + 1
        'x1hoja.Range("H8", "M13").Border.Color = RGB(255, 0, 0)
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)

        'lista = c.listarporsolicitud(idsol)
        lista = csm.listarporsolicitud(idsol)

        fila = fila + 2
        columna = 1


        x1hoja.Cells(fila, columna).Formula = "Ident."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Rc"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "R Bact."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Gr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Pr"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Lc*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "ST"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Cr*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "MUN*"
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
        x1hoja.Cells(fila, columna).Formula = "Esp.Ana.*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Psicro.*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Caseína*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Afla.M1*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = 1
        fila = fila + 1

        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("A17", "A18").Merge()
        x1hoja.Range("A17", "A18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("A17", "A18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("A17", "A18").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("B17", "B18").Merge()
        x1hoja.Range("B17", "B18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("B17", "B18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("B17", "B18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("C17", "C18").Merge()
        x1hoja.Range("C17", "C18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("C17", "C18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("C17", "C18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1.000 eq. UFC/ml"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("D17", "D18").Merge()
        x1hoja.Range("D17", "D18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("D17", "D18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("D17", "D18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("E17", "E18").Merge()
        x1hoja.Range("E17", "E18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("E17", "E18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("E17", "E18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("F17", "F18").Merge()
        x1hoja.Range("F17", "F18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("F17", "F18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("F17", "F18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("G17", "G18").Merge()
        x1hoja.Range("G17", "G18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("G17", "G18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("G17", "G18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "% peso/vol"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("H17", "H18").Merge()
        x1hoja.Range("H17", "H18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("H17", "H18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("H17", "H18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "(ºC)"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("I17", "I18").Merge()
        x1hoja.Range("I17", "I18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("I17", "I18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("I17", "I18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "mg/dl"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("J17", "J18").Merge()
        x1hoja.Range("J17", "J18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("J17", "J18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("J17", "J18").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("K17", "K18").Merge()
        x1hoja.Range("K17", "K18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("K17", "K18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("K17", "K18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "NMP/L"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("L17", "L18").Merge()
        x1hoja.Range("L17", "L18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("L17", "L18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("L17", "L18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "x 1000 UFC/ml UFC/mL "
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("M17", "M18").Merge()
        x1hoja.Range("M17", "M18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("M17", "M18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("M17", "M18").WrapText = True
        x1hoja.Cells(fila, columna).formula = ""
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("N17", "N18").Merge()
        x1hoja.Range("N17", "N18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("N17", "N18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("N17", "N18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "ppb"
        'x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = 1
        fila = fila + 2


        If Not lista Is Nothing Then
            If lista.Count > 0 Then

                'Dim cs As New dCalidadSolicitudMuestra
                'cs.ficha = idsol
                'cs = cs.buscar



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
                                contador_rc = contador_rc + 1
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
                    'x1hoja.Cells(fila, columna).formula = "-"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'columna = columna + 1
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
                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            Dim valgrasa As Double = Val(c.GRASA)
                            If valgrasa < 2 Or valgrasa > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.GRASA, 2)
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
                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            Dim valproteina As Double = Val(c.PROTEINA)
                            If valproteina < 2 Or valproteina > 3.8 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.PROTEINA, 2)
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

                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.LACTOSA, 2)
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
                    If csm.COMPOSICION = 1 Or csm.COMPOSICIONSUERO = 1 Then
                        If Not c Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.ST, 2)
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
                                x1hoja.Cells(fila, columna).formula = valcrioscopia.ToString("##,###0.000")
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
                                If c.EQUIPO = "Bentley600" Then
                                    valorurea = c.UREA
                                Else
                                    valorurea = c.UREA * 0.466
                                End If
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
                    'x1hoja.Cells(fila, columna).formula = "-"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'columna = columna + 1
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

                    'x1hoja.Cells(fila, columna).formula = "-"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'columna = columna + 1
                    'x1hoja.Cells(fila, columna).formula = "-"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'columna = columna + 1

                    If csm.CASEINA = 1 Then
                        If Not c Is Nothing Then
                            If c.CASEINA <> -1 Then
                                Dim valorcaseina As Double
                                valorcaseina = c.CASEINA
                                x1hoja.Cells(fila, columna).formula = FormatNumber(valorcaseina, 2)
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

                '******* CALCULO PRECIO ************************************************************************

                'Dim listamuestras As New ArrayList
                'listamuestras = csm.listarporsolicitud(idsol)
                'Dim total As Double
                'Dim ana As New dAnalisis

                'Dim idtimbre As Integer = 86
                'Dim idrb As Integer = 1
                'Dim idrc As Integer = 2
                'Dim idcomposicion As Integer = 3
                'Dim idinhibidores As Integer = 5
                'Dim idcharm As Integer = 196
                'Dim idurea As Integer = 60
                'Dim idcrioscopia As Integer = 4
                'Dim idesporulados As Integer = 8
                'Dim idpsicrotrofos As Integer = 61
                'Dim idtermofilos As Integer = 62
                'Dim idbact_cel_comp As Integer = 100
                'Dim idbact_cel As Integer = 101
                'Dim idcrioscopia_crioscopo As Integer = 102
                'Dim idcaseina As Integer = 118
                'Dim idaflatoxina As Integer = 162
                'Dim idCalcar_composicion_crioscopia As Integer = 103
                'Dim idCalcar_RC As Integer = 104
                'Dim idCalcar_RB As Integer = 105
                'Dim idEcolat_composicion As Integer = 106
                'Dim idEcolat_RC As Integer = 107
                'Dim idEcolat_RB As Integer = 108
                'Dim idIndulacsaC_composicion As Integer = 109
                'Dim idIndulacsaC_RC As Integer = 110
                'Dim idIndulacsaC_RB As Integer = 111
                'Dim idIndulacsaS_composicion As Integer = 112
                'Dim idIndulacsaS_RC As Integer = 113
                'Dim idIndulacsaS_RB As Integer = 114
                'Dim idIndulacsaS_inhibidores As Integer = 115

                'Dim preciotimbre As Double
                'Dim preciorb As Double
                'Dim preciorc As Double
                'Dim preciocomposicion As Double
                'Dim precioinhibidores As Double
                'Dim preciocharm As Double = 0
                'Dim preciourea As Double
                'Dim preciocrioscopia As Double
                'Dim precioesporulados As Double
                'Dim preciopsicrotrofos As Double
                'Dim preciotermofilos As Double
                'Dim preciobact_cel_comp As Double
                'Dim preciobact_cel As Double
                'Dim preciocrioscopia_crioscopo As Double
                'Dim preciocaseina As Double
                'Dim precioaflatoxina As Double
                'Dim precioCalcar_composicion_crioscopia As Double
                'Dim precioCalcar_RC As Double
                'Dim precioCalcar_RB As Double
                'Dim precioEcolat_composicion As Double
                'Dim precioEcolat_RC As Double
                'Dim precioEcolat_RB As Double
                'Dim precioIndulacsaC_composicion As Double
                'Dim precioIndulacsaC_RC As Double
                'Dim precioIndulacsaC_RB As Double
                'Dim precioIndulacsaS_composicion As Double
                'Dim precioIndulacsaS_RC As Double
                'Dim precioIndulacsaS_RB As Double
                'Dim precioIndulacsaS_inhibidores As Double


                'If sa.IDPRODUCTOR = 219 Then
                '    ana.ID = idCalcar_composicion_crioscopia
                '    ana = ana.buscar
                '    precioCalcar_composicion_crioscopia = ana.COSTO

                '    ana.ID = idCalcar_RC
                '    ana = ana.buscar
                '    precioCalcar_RC = ana.COSTO

                '    ana.ID = idCalcar_RB
                '    ana = ana.buscar
                '    precioCalcar_RB = ana.COSTO
                'End If
                'If sa.IDPRODUCTOR = 143 Then
                '    ana.ID = idEcolat_composicion
                '    ana = ana.buscar
                '    precioEcolat_composicion = ana.COSTO

                '    ana.ID = idEcolat_RC
                '    ana = ana.buscar
                '    precioEcolat_RC = ana.COSTO

                '    ana.ID = idEcolat_RB
                '    ana = ana.buscar
                '    precioEcolat_RB = ana.COSTO
                'End If
                'If sa.IDPRODUCTOR = 150 Then
                '    ana.ID = idIndulacsaC_composicion
                '    ana = ana.buscar
                '    precioIndulacsaC_composicion = ana.COSTO

                '    ana.ID = idIndulacsaC_RC
                '    ana = ana.buscar
                '    precioIndulacsaC_RC = ana.COSTO

                '    ana.ID = idIndulacsaC_RB
                '    ana = ana.buscar
                '    precioIndulacsaC_RB = ana.COSTO
                'End If
                'If sa.IDPRODUCTOR = 2705 Then
                '    ana.ID = idIndulacsaS_composicion
                '    ana = ana.buscar
                '    precioIndulacsaS_composicion = ana.COSTO

                '    ana.ID = idIndulacsaS_RC
                '    ana = ana.buscar
                '    precioIndulacsaS_RC = ana.COSTO

                '    ana.ID = idIndulacsaS_RB
                '    ana = ana.buscar
                '    precioIndulacsaS_RB = ana.COSTO

                '    ana.ID = idIndulacsaS_inhibidores
                '    ana = ana.buscar
                '    precioIndulacsaS_inhibidores = ana.COSTO
                'End If

                'ana.ID = idtimbre
                'ana = ana.buscar
                'preciotimbre = ana.COSTO

                'ana.ID = idrb
                'ana = ana.buscar
                'preciorb = ana.COSTO

                'ana.ID = idrc
                'ana = ana.buscar
                'preciorc = ana.COSTO

                'ana.ID = idcomposicion
                'ana = ana.buscar
                'preciocomposicion = ana.COSTO

                'ana.ID = idinhibidores
                'ana = ana.buscar
                'precioinhibidores = ana.COSTO

                'ana.ID = idcharm
                'ana = ana.buscar
                'preciocharm = ana.COSTO

                'ana.ID = idurea
                'ana = ana.buscar
                'preciourea = ana.COSTO

                'ana.ID = idcrioscopia
                'ana = ana.buscar
                'preciocrioscopia = ana.COSTO

                'ana.ID = idesporulados
                'ana = ana.buscar
                'precioesporulados = ana.COSTO

                'ana.ID = idpsicrotrofos
                'ana = ana.buscar
                'preciopsicrotrofos = ana.COSTO

                'ana.ID = idtermofilos
                'ana = ana.buscar
                'preciotermofilos = ana.COSTO

                'ana.ID = idbact_cel_comp
                'ana = ana.buscar
                'preciobact_cel_comp = ana.COSTO

                'ana.ID = idbact_cel
                'ana = ana.buscar
                'preciobact_cel = ana.COSTO

                'ana.ID = idcrioscopia_crioscopo
                'ana = ana.buscar
                'preciocrioscopia_crioscopo = ana.COSTO

                'ana.ID = idcaseina
                'ana = ana.buscar
                'preciocaseina = ana.COSTO

                'ana.ID = idaflatoxina
                'ana = ana.buscar
                'precioaflatoxina = ana.COSTO

                'Dim muestras As Integer
                'muestras = listamuestras.Count

                'Dim cuentarb As Integer = 0
                'Dim cuentarb2 As Integer = 0
                'Dim cuentarc As Integer = 0
                'Dim cuentarc2 As Integer = 0
                'Dim cuentacomposicion As Integer = 0
                'Dim cuentacrioscopia As Integer = 0
                'Dim cuentainhibidores As Integer = 0
                'Dim cuentacharm As Integer = 0
                'Dim cuentaesporulados As Integer = 0
                'Dim cuentaurea As Integer = 0
                'Dim cuentatermofilos As Integer = 0
                'Dim cuentapsicrotrofos As Integer = 0
                'Dim cuentacrioscopia_crioscopo As Integer = 0
                'Dim cuentacaseina As Integer = 0
                'Dim cuentaaflatoxina As Integer = 0
                'Dim cuentarb_rc As Integer = 0
                'Dim cuentarb_rc2 As Integer = 0
                'Dim cuentarb_rc_composicion = 0

                ''Dim csm As New dCalidadSolicitudMuestra
                'Dim listam As New ArrayList
                'listam = csm.listarrb(idsol)
                'If Not listam Is Nothing Then
                '    cuentarb = listam.Count
                '    cuentarb2 = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarrc(idsol)
                'If Not listam Is Nothing Then
                '    cuentarc = listam.Count
                '    cuentarc2 = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarcomposicion(idsol)
                'If Not listam Is Nothing Then
                '    cuentacomposicion = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarcrioscopia(idsol)
                'If Not listam Is Nothing Then
                '    cuentacrioscopia = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarinhibidores(idsol)
                'If Not listam Is Nothing Then
                '    cuentainhibidores = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarcharm(idsol)
                'If Not listam Is Nothing Then
                '    cuentacharm = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listaresporulados(idsol)
                'If Not listam Is Nothing Then
                '    cuentaesporulados = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarurea(idsol)
                'If Not listam Is Nothing Then
                '    cuentaurea = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listartermofilos(idsol)
                'If Not listam Is Nothing Then
                '    cuentatermofilos = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarpsicrotrofos(idsol)
                'If Not listam Is Nothing Then
                '    cuentapsicrotrofos = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarcrioscopia_crioscopo(idsol)
                'If Not listam Is Nothing Then
                '    cuentacrioscopia_crioscopo = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listar_caseina(idsol)
                'If Not listam Is Nothing Then
                '    cuentacaseina = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listar_aflatoxina(idsol)
                'If Not listam Is Nothing Then
                '    cuentaaflatoxina = listam.Count
                'End If
                'listam = Nothing
                'listam = csm.listarrb_rc(idsol)
                'If sa.IDPRODUCTOR = 219 Or sa.IDPRODUCTOR = 143 Or sa.IDPRODUCTOR = 150 Or sa.IDPRODUCTOR = 2705 Then

                'Else
                '    If Not listam Is Nothing Then
                '        cuentarb_rc = listam.Count
                '        'If cuentarb > cuentarb_rc Then
                '        '    cuentarb = cuentarb - cuentarb_rc
                '        'Else
                '        '    cuentarb = 0
                '        'End If
                '        'If cuentarc > cuentarb_rc Then
                '        '    cuentarc = cuentarc - cuentarb_rc
                '        'Else
                '        '    cuentarc = 0
                '        'End If
                '    End If
                '    listam = Nothing
                '    listam = csm.listarrb_rc_composicion(idsol)
                '    If Not listam Is Nothing Then
                '        'cuentarb = cuentarb2
                '        'cuentarc = cuentarc2
                '        cuentarb_rc_composicion = listam.Count

                '        'If cuentarb > cuentarb_rc_composicion Then
                '        '    cuentarb = cuentarb - cuentarb_rc_composicion
                '        'Else
                '        '    cuentarb = 0
                '        'End If
                '        'If cuentarc > cuentarb_rc_composicion Then
                '        '    cuentarc = cuentarc - cuentarb_rc_composicion
                '        'Else
                '        '    cuentarc = 0
                '        'End If
                '        'If cuentacomposicion > cuentarb_rc_composicion Then
                '        '    cuentacomposicion = cuentacomposicion - cuentarb_rc_composicion
                '        'Else
                '        '    cuentacomposicion = 0
                '        'End If
                '        If cuentarb_rc > cuentarb_rc_composicion Then
                '            'cuentarb_rc = cuentarb_rc - cuentarb_rc_composicion
                '        Else
                '            cuentarb_rc = 0
                '        End If

                '    End If
                '    listam = Nothing
                'End If

                'If sa.IDPRODUCTOR = 219 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioCalcar_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioCalcar_RC)
                '    End If
                '    If cuentacomposicion > 0 And cuentacrioscopia > 0 Then
                '        total = total + (cuentacomposicion * precioCalcar_composicion_crioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If
                '    If cuentaaflatoxina > 0 Then
                '        total = total + (cuentaaflatoxina * precioaflatoxina)
                '    End If
                '    'If cs.RB = 1 Then
                '    'total = total + precioCalcar_RB
                '    'End If
                '    'If cs.RC = 1 Then
                '    'total = total + precioCalcar_RC
                '    'End If
                '    'If cs.COMPOSICION = 1 And cs.CRIOSCOPIA = 1 Then
                '    'total = total + precioCalcar_composicion_crioscopia
                '    'End If
                '    'If cs.INHIBIDORES = 1 Then
                '    'total = total + precioinhibidores
                '    'End If
                '    'If cs.ESPORULADOS = 1 Then
                '    'total = total + precioesporulados
                '    'End If
                '    'If cs.UREA = 1 Then
                '    'total = total + preciourea
                '    'End If
                '    'If cs.TERMOFILOS = 1 Then
                '    'total = total + preciotermofilos
                '    'End If
                '    'If cs.PSICROTROFOS = 1 Then
                '    'total = total + preciopsicrotrofos
                '    'End If
                '    'If cs.CRIOSCOPIA_CRIOSCOPO = 1 Then
                '    'total = total + preciocrioscopia_crioscopo
                '    'End If
                'ElseIf sa.IDPRODUCTOR = 143 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioEcolat_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioEcolat_RC)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        total = total + (cuentacomposicion * precioEcolat_composicion)
                '    End If
                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If
                '    If cuentaaflatoxina > 0 Then
                '        total = total + (cuentaaflatoxina * precioaflatoxina)
                '    End If
                '    'If cs.RB = 1 Then
                '    '    total = total + precioEcolat_RB
                '    'End If
                '    'If cs.RC = 1 Then
                '    '    total = total + precioEcolat_RC
                '    'End If
                '    'If cs.COMPOSICION = 1 Then
                '    '    total = total + precioEcolat_composicion
                '    'End If
                '    'If cs.CRIOSCOPIA = 1 Then
                '    '    total = total + preciocrioscopia
                '    'End If
                '    'If cs.INHIBIDORES = 1 Then
                '    '    total = total + precioinhibidores
                '    'End If
                '    'If cs.ESPORULADOS = 1 Then
                '    '    total = total + precioesporulados
                '    'End If
                '    'If cs.UREA = 1 Then
                '    '    total = total + preciourea
                '    'End If
                '    'If cs.TERMOFILOS = 1 Then
                '    '    total = total + preciotermofilos
                '    'End If
                '    'If cs.PSICROTROFOS = 1 Then
                '    '    total = total + preciopsicrotrofos
                '    'End If
                '    'If cs.CRIOSCOPIA_CRIOSCOPO = 1 Then
                '    '    total = total + preciocrioscopia_crioscopo
                '    'End If
                'ElseIf sa.IDPRODUCTOR = 150 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioIndulacsaC_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioIndulacsaC_RC)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        total = total + (cuentacomposicion * precioIndulacsaC_composicion)
                '    End If
                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If
                '    If cuentaaflatoxina > 0 Then
                '        total = total + (cuentaaflatoxina * precioaflatoxina)
                '    End If
                '    'If cs.RB = 1 Then
                '    '    total = total + precioIndulacsaC_RB
                '    'End If
                '    'If cs.RC = 1 Then
                '    '    total = total + precioIndulacsaC_RC
                '    'End If
                '    'If cs.COMPOSICION = 1 Then
                '    '    total = total + precioIndulacsaC_composicion
                '    'End If
                '    'If cs.CRIOSCOPIA = 1 Then
                '    '    total = total + preciocrioscopia
                '    'End If
                '    'If cs.INHIBIDORES = 1 Then
                '    '    total = total + precioinhibidores
                '    'End If
                '    'If cs.ESPORULADOS = 1 Then
                '    '    total = total + precioesporulados
                '    'End If
                '    'If cs.UREA = 1 Then
                '    '    total = total + preciourea
                '    'End If
                '    'If cs.TERMOFILOS = 1 Then
                '    '    total = total + preciotermofilos
                '    'End If
                '    'If cs.PSICROTROFOS = 1 Then
                '    '    total = total + preciopsicrotrofos
                '    'End If
                '    'If cs.CRIOSCOPIA_CRIOSCOPO = 1 Then
                '    '    total = total + preciocrioscopia_crioscopo
                '    'End If
                'ElseIf sa.IDPRODUCTOR = 2705 Then
                '    If cuentarb > 0 Then
                '        total = total + (cuentarb * precioIndulacsaS_RB)
                '    End If
                '    If cuentarc > 0 Then
                '        total = total + (cuentarc * precioIndulacsaS_RC)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        total = total + (cuentacomposicion * precioIndulacsaS_composicion)
                '    End If
                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioIndulacsaS_inhibidores)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If
                '    If cuentaaflatoxina > 0 Then
                '        total = total + (cuentaaflatoxina * precioaflatoxina)
                '    End If
                '    'If cs.RB = 1 Then
                '    '    total = total + precioIndulacsaS_RB
                '    'End If
                '    'If cs.RC = 1 Then
                '    '    total = total + precioIndulacsaS_RC
                '    'End If
                '    'If cs.COMPOSICION = 1 Then
                '    '    total = total + precioIndulacsaS_composicion
                '    'End If
                '    'If cs.CRIOSCOPIA = 1 Then
                '    '    total = total + preciocrioscopia
                '    'End If
                '    'If cs.INHIBIDORES = 1 Then
                '    '    total = total + precioIndulacsaS_inhibidores
                '    'End If
                '    'If cs.ESPORULADOS = 1 Then
                '    '    total = total + precioesporulados
                '    'End If
                '    'If cs.UREA = 1 Then
                '    '    total = total + preciourea
                '    'End If
                '    'If cs.TERMOFILOS = 1 Then
                '    '    total = total + preciotermofilos
                '    'End If
                '    'If cs.PSICROTROFOS = 1 Then
                '    '    total = total + preciopsicrotrofos
                '    'End If
                '    'If cs.CRIOSCOPIA_CRIOSCOPO = 1 Then
                '    '    total = total + preciocrioscopia_crioscopo
                '    'End If
                'Else
                '    If cuentarb_rc_composicion > 0 Then
                '        total = total + (cuentarb_rc_composicion * preciobact_cel_comp)
                '    End If
                '    If cuentarb_rc > cuentarb_rc_composicion Then
                '        cuentarb_rc = cuentarb_rc - cuentarb_rc_composicion
                '        total = total + (cuentarb_rc * preciobact_cel)
                '    End If
                '    If cuentarb > 0 Then
                '        cuentarb = cuentarb - cuentarb_rc_composicion - cuentarb_rc
                '        total = total + (cuentarb * preciorb)
                '    End If
                '    If cuentarc > 0 Then
                '        cuentarc = cuentarc - cuentarb_rc_composicion - cuentarb_rc
                '        total = total + (cuentarc * preciorc)
                '    End If
                '    If cuentacomposicion > 0 Then
                '        cuentacomposicion = cuentacomposicion - cuentarb_rc_composicion
                '        total = total + (cuentacomposicion * preciocomposicion)
                '    End If

                '    If cuentacrioscopia > 0 Then
                '        total = total + (cuentacrioscopia * preciocrioscopia)
                '    End If
                '    If cuentainhibidores > 0 Then
                '        total = total + (cuentainhibidores * precioinhibidores)
                '    End If
                '    If cuentacharm > 0 Then
                '        total = total + (cuentacharm * preciocharm)
                '    End If
                '    If cuentaesporulados > 0 Then
                '        total = total + (cuentaesporulados * precioesporulados)
                '    End If
                '    If cuentaurea > 0 Then
                '        total = total + (cuentaurea * preciourea)
                '    End If
                '    If cuentatermofilos > 0 Then
                '        total = total + (cuentatermofilos * preciotermofilos)
                '    End If
                '    If cuentapsicrotrofos > 0 Then
                '        total = total + (cuentapsicrotrofos * preciopsicrotrofos)
                '    End If
                '    If cuentacrioscopia_crioscopo > 0 Then
                '        total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
                '    End If
                '    If cuentacaseina > 0 Then
                '        total = total + (cuentacaseina * preciocaseina)
                '    End If
                '    If cuentaaflatoxina > 0 Then
                '        total = total + (cuentaaflatoxina * precioaflatoxina)
                '        textoafla = 1
                '    End If
                '    '    If cs.RB = 1 Then
                '    '        total = total + preciorb
                '    '    End If
                '    '    If cs.RC = 1 Then
                '    '        total = total + preciorc
                '    '    End If
                '    '    If cs.COMPOSICION = 1 Then
                '    '        total = total + preciocomposicion
                '    '    End If
                '    '    If cs.RB = 1 And cs.RC = 1 Then
                '    '        total = 0
                '    '        total = total + preciobact_cel
                '    '    End If
                '    '    If cs.RB = 1 And cs.RC = 1 And cs.COMPOSICION = 1 Then
                '    '        total = 0
                '    '        total = total + preciobact_cel_comp
                '    '    End If


                '    '    If cs.CRIOSCOPIA = 1 Then
                '    '        total = total + preciocrioscopia
                '    '    End If
                '    '    If cs.INHIBIDORES = 1 Then
                '    '        total = total + precioinhibidores
                '    '    End If
                '    '    If cs.ESPORULADOS = 1 Then
                '    '        total = total + precioesporulados
                '    '    End If
                '    '    If cs.UREA = 1 Then
                '    '        total = total + preciourea
                '    '    End If
                '    '    If cs.TERMOFILOS = 1 Then
                '    '        total = total + preciotermofilos
                '    '    End If
                '    '    If cs.PSICROTROFOS = 1 Then
                '    '        total = total + preciopsicrotrofos
                '    '    End If
                '    '    If cs.CRIOSCOPIA_CRIOSCOPO = 1 Then
                '    '        total = total + preciocrioscopia_crioscopo
                '    '    End If
                'End If

                factura_calidad()
                Dim idtimbre As Integer = 86
                Dim lp As New dListaPrecios
                Dim preciotimbre As Double = 0
                lp.ID = idtimbre
                lp = lp.buscar
                preciotimbre = lp.PRECIO1
                lp = Nothing

                totalprecio = Math.Round((totalprecio + preciotimbre), 0, MidpointRounding.AwayFromZero)
                '/* Actualiza el importe en la solicitud 
                Dim saimp As New dSolicitudAnalisis
                Dim importesa As Double = totalprecio
                saimp.ID = idsol
                saimp.actualizarimporte(importesa)


                '***************************************/

                '***********************************************************************************************
                columna = 1

                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).formula = "Observaciones:"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
                    If textoafla = 1 Then
                        sa.OBSERVACIONES = sa.OBSERVACIONES & " - Valores máximos admitidos por la normativa establecida en Mercosur/MGAP (0.5ppb)"
                    End If
                    If sa.OBSERVACIONES <> "" Then
                        x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).formula = "Sin observaciones."
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        fila = fila + 1
                    End If
                    fila = fila + 1
                End If

                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & totalprecio
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = ""
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2 o >3,8 Proteína, >4,5 Grasa % y"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = 1
                fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 7
                x1hoja.Cells(fila, columna).formula = "Crioscopía < -0,512ºC > -0,540ºC, < 1º y > 7º Temp. de arribo)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = 1
                fila = fila + 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                Dim rangeFirma As String = "A" + fila.ToString
                x1libro.ActiveSheet.Range(rangeFirma).select()
                InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
                x1libro.Worksheets(1).cells(2, 1).select()
                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = "La indicación ''Fuera de rango''. está fuera del alcance de la acreditación"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna - 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "-"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Borders.Color = RGB(0, 0, 0)
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Análisis no requerido"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 2
                x1hoja.Cells(fila, columna).formula = "Rc = rec. Celular, R Bact. = Rec. Bacteriano,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Gr = Grasa, Pr = Proteína, Lc = Lactosa, ST = Sólidos Totales,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Cr = Crioscopía, MUN = Nitrogeno ureico en leche,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Inh = Inihibidores, Esp = Esporulados Anaerobios,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Psicro = Psicrótrofos"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = 1
                fila = fila + 2

                x1hoja.Cells(fila, columna).formula = "Laboratorio habilitado RNL 0029 - MGAP" '&" - Certificado vigente al 09/07/2025"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 2

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



            End If
        End If

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
            pi2.TIPO = 10
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing

        fila = fila + 1
        x1hoja.Range("A" & fila, "N" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7

        'PROTEGE LA HOJA DE EXCEL
        If sa.IDPRODUCTOR <> 2427 Then
            x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
       Contents:=True, Scenarios:=True)
        End If

        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\CALIDAD\" & idsol & ".xls")
        Try
            x1hoja.SaveAs("\\ROBOT\PREINFORMES\CALIDAD\" & idsol & ".xls")
        Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            'MessageBox.Show("Falla al grabar!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

        'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("C:\" & idsol & ".xls")
        x1app.Visible = True
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        If contador_rc > 0 Then
            MsgBox("Hay " & contador_rc & " muestra/s con RC por debajo de 100.")
        End If
        totalprecio = 0
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
    Private Sub factura_calidad()
        Dim ficha As Long = 0
        Dim muestras As Integer = 0
        Dim sa As New dSolicitudAnalisis
        ficha = id_sol
        sa.ID = ficha
        sa = sa.buscar
        Dim csm As New dCalidadSolicitudMuestra
        Dim listamuestras As New ArrayList
        listamuestras = csm.listarporsolicitud(ficha)
        muestras = listamuestras.Count
        Dim lp As New dListaPrecios

        Dim idrb As Integer = 1
        Dim idrc As Integer = 2
        Dim idcomposicion As Integer = 3
        Dim idinhibidores As Integer = 5
        Dim idcharm As Integer = 196
        Dim idurea As Integer = 60
        Dim idcrioscopia As Integer = 4
        Dim idesporulados As Integer = 8
        Dim idpsicrotrofos As Integer = 61
        Dim idtermoduricos As Integer = 237
        Dim idbact_cel_comp As Integer = 100
        Dim idbact_cel As Integer = 101
        Dim idcrioscopia_crioscopo As Integer = 102
        Dim idcaseina As Integer = 118
        Dim idaflatoxina As Integer = 162

        Dim preciorb As Double
        Dim preciorc As Double
        Dim preciocomposicion As Double
        Dim precioinhibidores As Double
        Dim preciocharm As Double
        Dim preciourea As Double
        Dim preciocrioscopia As Double
        Dim precioesporulados As Double
        Dim preciopsicrotrofos As Double
        Dim preciotermoduricos As Double
        Dim preciobact_cel_comp As Double
        Dim preciobact_cel As Double
        Dim preciocrioscopia_crioscopo As Double
        Dim preciocaseina As Double
        Dim precioaflatoxina As Double

        Dim c As New dCliente
        Dim precio As Integer = 0
        c.ID = sa.IDPRODUCTOR
        c = c.buscar
        If Not c Is Nothing Then
            precio = c.FAC_LISTA
        End If

        If precio = 1 Then
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO1
            lp.ID = idrc
            lp = lp.buscar
            preciorc = lp.PRECIO1
            lp.ID = idcomposicion
            lp = lp.buscar
            preciocomposicion = lp.PRECIO1
            lp.ID = idinhibidores
            lp = lp.buscar
            precioinhibidores = lp.PRECIO1
            lp.ID = idcharm
            lp = lp.buscar
            preciocharm = lp.PRECIO1
            lp.ID = idurea
            lp = lp.buscar
            preciourea = lp.PRECIO1
            lp.ID = idcrioscopia
            lp = lp.buscar
            preciocrioscopia = lp.PRECIO1
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO1
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO1
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO1
            lp.ID = idbact_cel_comp
            lp = lp.buscar
            preciobact_cel_comp = lp.PRECIO1
            lp.ID = idbact_cel
            lp = lp.buscar
            preciobact_cel = lp.PRECIO1
            lp.ID = idcrioscopia_crioscopo
            lp = lp.buscar
            preciocrioscopia_crioscopo = lp.PRECIO1
            lp.ID = idcaseina
            lp = lp.buscar
            preciocaseina = lp.PRECIO1
            lp.ID = idaflatoxina
            lp = lp.buscar
            precioaflatoxina = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorb = lp.PRECIO1
            End If
            lp.ID = idrc
            lp = lp.buscar
            preciorc = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc = lp.PRECIO1
            End If
            lp.ID = idcomposicion
            lp = lp.buscar
            preciocomposicion = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocomposicion = lp.PRECIO1
            End If
            lp.ID = idinhibidores
            lp = lp.buscar
            precioinhibidores = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioinhibidores = lp.PRECIO1
            End If
            lp.ID = idcharm
            lp = lp.buscar
            preciocharm = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocharm = lp.PRECIO1
            End If
            lp.ID = idurea
            lp = lp.buscar
            preciourea = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciourea = lp.PRECIO1
            End If
            lp.ID = idcrioscopia
            lp = lp.buscar
            preciocrioscopia = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocrioscopia = lp.PRECIO1
            End If
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioesporulados = lp.PRECIO1
            End If
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciopsicrotrofos = lp.PRECIO1
            End If
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciotermoduricos = lp.PRECIO1
            End If
            lp.ID = idbact_cel_comp
            lp = lp.buscar
            preciobact_cel_comp = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciobact_cel_comp = lp.PRECIO1
            End If
            lp.ID = idbact_cel
            lp = lp.buscar
            preciobact_cel = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciobact_cel = lp.PRECIO1
            End If
            lp.ID = idcrioscopia_crioscopo
            lp = lp.buscar
            preciocrioscopia_crioscopo = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocrioscopia_crioscopo = lp.PRECIO1
            End If
            lp.ID = idcaseina
            lp = lp.buscar
            preciocaseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciocaseina = lp.PRECIO1
            End If
            lp.ID = idaflatoxina
            lp = lp.buscar
            precioaflatoxina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                precioaflatoxina = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idrb
            lp = lp.buscar
            preciorb = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorb = lp.PRECIO1
            End If
            lp.ID = idrc
            lp = lp.buscar
            preciorc = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc = lp.PRECIO1
            End If
            lp.ID = idcomposicion
            lp = lp.buscar
            preciocomposicion = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocomposicion = lp.PRECIO1
            End If
            lp.ID = idinhibidores
            lp = lp.buscar
            precioinhibidores = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioinhibidores = lp.PRECIO1
            End If
            lp.ID = idcharm
            lp = lp.buscar
            preciocharm = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocharm = lp.PRECIO1
            End If
            lp.ID = idurea
            lp = lp.buscar
            preciourea = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciourea = lp.PRECIO1
            End If
            lp.ID = idcrioscopia
            lp = lp.buscar
            preciocrioscopia = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocrioscopia = lp.PRECIO1
            End If
            lp.ID = idesporulados
            lp = lp.buscar
            precioesporulados = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioesporulados = lp.PRECIO1
            End If
            lp.ID = idpsicrotrofos
            lp = lp.buscar
            preciopsicrotrofos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciopsicrotrofos = lp.PRECIO1
            End If
            lp.ID = idtermoduricos
            lp = lp.buscar
            preciotermoduricos = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciotermoduricos = lp.PRECIO1
            End If
            lp.ID = idbact_cel_comp
            lp = lp.buscar
            preciobact_cel_comp = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciobact_cel_comp = lp.PRECIO1
            End If
            lp.ID = idbact_cel
            lp = lp.buscar
            preciobact_cel = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciobact_cel = lp.PRECIO1
            End If
            lp.ID = idcrioscopia_crioscopo
            lp = lp.buscar
            preciocrioscopia_crioscopo = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocrioscopia_crioscopo = lp.PRECIO1
            End If
            lp.ID = idcaseina
            lp = lp.buscar
            preciocaseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciocaseina = lp.PRECIO1
            End If
            lp.ID = idaflatoxina
            lp = lp.buscar
            precioaflatoxina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                precioaflatoxina = lp.PRECIO1
            End If
        End If


        Dim cuentarb As Integer = 0
        Dim cuentarc As Integer = 0
        Dim cuentacomposicion As Integer = 0
        Dim cuentainhibidores As Integer = 0
        Dim cuentacharm As Integer = 0
        Dim cuentaurea As Integer = 0
        Dim cuentacrioscopia As Integer = 0
        Dim cuentaesporulados As Integer = 0
        Dim cuentapsicrotrofos As Integer = 0
        Dim cuentatermoduricos As Integer = 0
        Dim cuentabact_cel_comp = 0
        Dim cuentabact_cel As Integer = 0
        Dim cuentacrioscopia_crioscopo As Integer = 0
        Dim cuentacaseina As Integer = 0
        Dim cuentaaflatoxina As Integer = 0


        Dim listam As New ArrayList
        listam = csm.listarrb(ficha)
        If Not listam Is Nothing Then
            cuentarb = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrc(ficha)
        If Not listam Is Nothing Then
            cuentarc = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcomposicion(ficha)
        If Not listam Is Nothing Then
            cuentacomposicion = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcrioscopia(ficha)
        If Not listam Is Nothing Then
            cuentacrioscopia = listam.Count
        End If
        listam = Nothing
        listam = csm.listarinhibidores(ficha)
        If Not listam Is Nothing Then
            cuentainhibidores = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcharm(ficha)
        If Not listam Is Nothing Then
            cuentacharm = listam.Count
        End If
        listam = Nothing
        listam = csm.listaresporulados(ficha)
        If Not listam Is Nothing Then
            cuentaesporulados = listam.Count
        End If
        listam = Nothing
        listam = csm.listarurea(ficha)
        If Not listam Is Nothing Then
            cuentaurea = listam.Count
        End If
        listam = Nothing
        listam = csm.listartermofilos(ficha)
        If Not listam Is Nothing Then
            cuentatermoduricos = listam.Count
        End If
        listam = Nothing
        listam = csm.listarpsicrotrofos(ficha)
        If Not listam Is Nothing Then
            cuentapsicrotrofos = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcrioscopia_crioscopo(ficha)
        If Not listam Is Nothing Then
            cuentacrioscopia_crioscopo = listam.Count
        End If
        listam = Nothing
        listam = csm.listar_caseina(ficha)
        If Not listam Is Nothing Then
            cuentacaseina = listam.Count
        End If
        listam = Nothing
        listam = csm.listar_aflatoxina(ficha)
        If Not listam Is Nothing Then
            cuentaaflatoxina = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrb_rc(ficha)
        If Not listam Is Nothing Then
            cuentabact_cel = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrb_rc_composicion(ficha)
        If Not listam Is Nothing Then
            cuentabact_cel_comp = listam.Count
        End If
        listam = Nothing


        Dim nmuestras As Integer = 0
        Dim precio1 As Double = 0
        Dim subtotal As Double = 0

        If cuentabact_cel_comp > 0 Then
            nmuestras = cuentabact_cel_comp
            precio1 = preciobact_cel_comp
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentabact_cel > cuentabact_cel_comp Then
            cuentabact_cel = cuentabact_cel - cuentabact_cel_comp
            nmuestras = cuentabact_cel
            precio1 = preciobact_cel
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentarb > (cuentabact_cel_comp + cuentabact_cel) Then
            cuentarb = cuentarb - cuentabact_cel_comp - cuentabact_cel
            nmuestras = cuentarb
            precio1 = preciorb
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentarc > (cuentabact_cel_comp + cuentabact_cel) Then
            cuentarc = cuentarc - cuentabact_cel_comp - cuentabact_cel
            nmuestras = cuentarc
            precio1 = preciorc
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentacomposicion > cuentabact_cel_comp Then
            cuentacomposicion = cuentacomposicion - cuentabact_cel_comp
            nmuestras = cuentacomposicion
            precio1 = preciocomposicion
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentacrioscopia > 0 Then
            nmuestras = cuentacrioscopia
            precio1 = preciocrioscopia
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentainhibidores > 0 Then
            nmuestras = cuentainhibidores
            precio1 = precioinhibidores
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentacharm > 0 Then
            nmuestras = cuentacharm
            precio1 = preciocharm
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentaesporulados > 0 Then
            nmuestras = cuentaesporulados
            precio1 = precioesporulados
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentaurea > 0 Then
            nmuestras = cuentaurea
            precio1 = preciourea
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentatermoduricos > 0 Then
            nmuestras = cuentatermoduricos
            precio1 = preciotermoduricos
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentapsicrotrofos > 0 Then
            nmuestras = cuentapsicrotrofos
            precio1 = preciopsicrotrofos
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentacrioscopia_crioscopo > 0 Then
            nmuestras = cuentacrioscopia_crioscopo
            precio1 = preciocrioscopia_crioscopo
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentacaseina > 0 Then
            nmuestras = cuentacaseina
            precio1 = preciocaseina
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
        If cuentaaflatoxina > 0 Then
            nmuestras = cuentaaflatoxina
            precio1 = precioaflatoxina
            subtotal = nmuestras * precio1
            totalprecio = totalprecio + subtotal
            nmuestras = 0
            precio1 = 0
            subtotal = 0
        End If
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        If ListFichas.SelectedItems.Count = 1 Then
            Dim s As dSolicitudAnalisis = CType(ListFichas.SelectedItem, dSolicitudAnalisis)
            TextFicha.Text = s.ID
        End If
    End Sub
    Private Sub creainformetxt()
        Dim idficha As Long = TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt")

        ' ====================================================================================
        Dim oSWAdolfo As New StreamWriter("\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xml")

        Dim cabezal_xml As String = "<?xml version='1.0'?>"

        Dim usuario_xml As String = "<InstalacionID>colaveco</InstalacionID>"
        Dim codigo_xml As String = "<CodigoAcceso>clave</CodigoAcceso>"

        Dim recuentos_xml As String = ""

        Dim modo_xml As String = "<Modo>INS</Modo>"

        ' ====================================================================================
        'NUEVO
        Dim colRecuentos As New ServiceReference1.wsCargoRecuentos
        colRecuentos.CodigoAccesso = "1234"
        colRecuentos.InstalacionID = "1"
        colRecuentos.Modo = "INS"

        Dim lista_recuentos As New ArrayList

        ' ====================================================================================

        Dim csm As New dCalidadSolicitudMuestra
        Dim lista As New ArrayList
        lista = csm.listarporsolicitud(idficha)
        Dim s As New dSolicitudAnalisis
        s.ID = idficha
        s = s.buscar
        Dim fecha As String = ""
        If Not s Is Nothing Then
            fecha = s.FECHAINGRESO
        End If

        '*******************************************************
        Dim diaactual As Integer = Mid(fecha, 1, 2)
        Dim semana As Integer = 1
        If diaactual <= 7 Then
            semana = 1
        ElseIf diaactual > 7 And diaactual <= 14 Then
            semana = 2
        ElseIf diaactual > 14 And diaactual <= 21 Then
            semana = 3
        ElseIf diaactual > 21 And diaactual <= 28 Then
            semana = 4
        ElseIf diaactual > 28 Then
            semana = 5
        End If
        '********************************************************

        If Not lista Is Nothing Then
            If lista.Count > 0 Then


                Dim Linea As String = ""
                'Linea = Linea & fecha & Chr(9)
                'oSW.WriteLine(Linea)
                Linea = ""

                For Each csm In lista
                    Dim c As New dCalidad
                    Dim finmatricula As String = ""
                    Dim matricula As String = ""
                    Dim largocadena As String = ""

                    c.FICHA = idficha
                    c.MUESTRA = Trim(csm.MUESTRA)
                    c = c.buscarxfichaxmuestra

                    If Not c Is Nothing Then
                        largocadena = c.MUESTRA
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(c.MUESTRA, Len(c.MUESTRA) - 1, 2)
                        End If
                    Else
                        largocadena = Trim(csm.MUESTRA)
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(csm.MUESTRA, Len(csm.MUESTRA) - 1, 2)
                        End If
                    End If

                    If finmatricula = "T1" Or finmatricula = "T2" Or finmatricula = "T3" Or finmatricula = "T4" Or finmatricula = "T5" Or finmatricula = "T6" Or finmatricula = "T7" Or finmatricula = "T8" Or finmatricula = "T9" Or finmatricula = "t1" Or finmatricula = "t2" Or finmatricula = "t3" Or finmatricula = "t4" Or finmatricula = "t5" Or finmatricula = "t6" Or finmatricula = "t7" Or finmatricula = "t8" Or finmatricula = "t9" Then
                        matricula = Mid(c.MUESTRA, 1, Len(c.MUESTRA) - 2)
                    Else
                        If Not c Is Nothing Then
                            matricula = c.MUESTRA
                        Else
                            matricula = csm.MUESTRA
                        End If
                    End If


                    If matricula <> "" Then
                        Linea = Linea & matricula & ";"
                    Else
                        Linea = Linea & "-" & ";"
                    End If

                    Linea = Linea & semana & ";"

                    Linea = Linea & fecha & ";"


                    Dim ibc As New dIbc
                    ibc.FICHA = idficha
                    If Not c Is Nothing Then
                        ibc.MUESTRA = Trim(c.MUESTRA)
                    Else
                        ibc.MUESTRA = Trim(csm.MUESTRA)
                    End If

                    ibc = ibc.buscarxfichaxmuestra
                    If csm.RB = 1 Then
                        If Not ibc Is Nothing Then
                            If ibc.RB <> -1 Then
                                Linea = Linea & ibc.RB & "000" & ";"
                            Else
                                Linea = Linea & "-" & ";"
                            End If

                        Else
                            Linea = Linea & "-" & ";"

                        End If
                    Else
                        Linea = Linea & "-" & ";"
                    End If


                    ' ====================================================================================




                    'NUEVO
                    Dim item_bc As New ServiceReference1.SDTRecuento_Item

                    item_bc.TambCod = matricula 'ibc.MUESTRA
                    item_bc.RecuSem = semana
                    item_bc.RecuSemFch = fecha
                    item_bc.PruCod = 4
                    If Not ibc Is Nothing Then
                        item_bc.Recuento = ibc.RB * 1000
                    Else
                        item_bc.Recuento = 0
                    End If

                    lista_recuentos.Add(item_bc)


                    Dim recuento_bc As String
                    If Not ibc Is Nothing Then
                        'Dim recuento_bc As String = "<SDTRecuento_Item>" _
                        recuento_bc = "<SDTRecuento_Item>" _
            & "<TambCod>" & matricula & "</TambCod>" _
            & "<Recusem>" & semana & "</Recusem>" _
            & "<RecuSemFch>" & fecha & "</RecuSemFch>" _
            & "<PruCod>" & 3 & "</PruCod>" _
            & "<Recuento>" & ibc.RB & "000" & "</Recuento>" _
           & "</SDTRecuento_Item>"
                    Else
                        'Dim recuento_bc As String = "<SDTRecuento_Item>" _
                        recuento_bc = "<SDTRecuento_Item>" _
            & "<TambCod>" & matricula & "</TambCod>" _
            & "<Recusem>" & semana & "</Recusem>" _
            & "<RecuSemFch>" & fecha & "</RecuSemFch>" _
            & "<PruCod>" & 3 & "</PruCod>" _
            & "<Recuento>" & "0" & "</Recuento>" _
           & "</SDTRecuento_Item>"
                    End If
                    ' Se agrega a recuentos
                    recuentos_xml = recuentos_xml & recuento_bc

                    ' ====================================================================================
                    ibc = Nothing

                    If csm.RC = 1 Then
                        If Not c Is Nothing Then
                            If c.RC <> -1 Then
                                Linea = Linea & c.RC & "000" '& ";"
                            Else
                                Linea = Linea & "-" '& ";"
                            End If
                        Else
                            Linea = Linea & "-" '& ";"
                        End If
                    Else
                        Linea = Linea & "-" '& ";"
                    End If

                    ' ====================================================================================

                    '             'NUEVO
                    Dim item_rc As New ServiceReference1.SDTRecuento_Item

                    item_rc.TambCod = matricula 'c.MUESTRA
                    item_rc.RecuSem = semana
                    item_rc.RecuSemFch = fecha
                    item_rc.PruCod = 3
                    item_rc.Recuento = c.RC * 1000

                    lista_recuentos.Add(item_rc)


                    Dim recuento_rc As String
                    If Not c Is Nothing Then
                        'Dim recuento_rc As String = "<SDTRecuento_Item>" _
                        recuento_rc = "<SDTRecuento_Item>" _
                                & "<TambCod>" & matricula & "</TambCod>" _
                                & "<Recusem>" & semana & "</Recusem>" _
            & "<RecuSemFch>" & fecha & "</RecuSemFch>" _
            & "<PruCod>" & 4 & "</PruCod>" _
            & "<Recuento>" & c.RC & "000" & "</Recuento>" _
           & "</SDTRecuento_Item>"
                    Else
                        'Dim recuento_rc As String = "<SDTRecuento_Item>" _
                        recuento_rc = "<SDTRecuento_Item>" _
                                & "<TambCod>" & matricula & "</TambCod>" _
                                & "<Recusem>" & semana & "</Recusem>" _
            & "<RecuSemFch>" & fecha & "</RecuSemFch>" _
            & "<PruCod>" & 4 & "</PruCod>" _
            & "<Recuento>" & "0" & "</Recuento>" _
           & "</SDTRecuento_Item>"
                    End If
                    ' Se agrega a recuentos
                    recuentos_xml = recuentos_xml & recuento_rc

                    ' ====================================================================================                       


                    oSW.WriteLine(Linea)
                    Linea = ""

                Next
            End If
        End If

        ' ==================================================================================== 

        ''NUEVO
        Dim matrizunidimensional(lista_recuentos.Count) As ServiceReference1.SDTRecuento_Item
        For i As Integer = 0 To lista_recuentos.Count - 1

            matrizunidimensional(i) = lista_recuentos.Item(i)

        Next

        colRecuentos.Recuentos = matrizunidimensional



        Dim wsSoapClient As New ServiceReference1.WSCargaRecuentosSoapPortClient

        Dim respuesta As ServiceReference1.wsCargoRecuentos_Respuesta = wsSoapClient.Execute(colRecuentos)

        If respuesta IsNot Nothing Then

            For Each item_error In respuesta.Errores
                If item_error.Err_Codigo <> 0 Then
                    MsgBox("Error código " & item_error.Err_Codigo & Chr(13) & Chr(10) & _
                           "Error descripción " & item_error.Err_Descripcion) '& Chr(13) & Chr(10) & _
                    '"Error prucod " & item_error.PruCod & Chr(13) & Chr(10) & _
                    '"Error recusem " & item_error.RecuSem & Chr(13) & Chr(10) & _
                    '"Error tambcod " & item_error.TambCod)
                End If
            Next

        End If




        ' Se arma XML y se imprime

        recuentos_xml = "<Recuentos>" & recuentos_xml & "</Recuentos>"

        Dim informe_xml As String = cabezal_xml & "<contenedor>" & usuario_xml & codigo_xml & recuentos_xml & modo_xml & "</contenedor>"
        oSWAdolfo.WriteLine(informe_xml)
        oSWAdolfo.Flush()


        ' ====================================================================================       		


        oSW.Flush()
    End Sub
    Private Sub creartxt()
        Dim idficha As Long = TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt")
        Dim csm As New dCalidadSolicitudMuestra
        Dim lista As New ArrayList
        lista = csm.listarporsolicitud(idficha)
        Dim s As New dSolicitudAnalisis
        s.ID = idficha
        s = s.buscar
        Dim fecha As String = ""
        If Not s Is Nothing Then
            fecha = s.FECHAINGRESO
        End If
        '*******************************************************
        'Dim diaactual As Integer = Mid(fecha, 1, 2)
        'Dim semana As Integer = 1
        'If diaactual <= 7 Then
        '    semana = 1
        'ElseIf diaactual > 7 And diaactual <= 14 Then
        '    semana = 2
        'ElseIf diaactual > 14 And diaactual <= 21 Then
        '    semana = 3
        'ElseIf diaactual > 21 And diaactual <= 28 Then
        '    semana = 4
        'ElseIf diaactual > 28 Then
        '    semana = 5
        'End If
        '********************************************************
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim Linea As String = ""
                'Linea = Linea & fecha & Chr(9)
                'oSW.WriteLine(Linea)
                Linea = ""
                For Each csm In lista
                    Dim c As New dCalidad
                    Dim finmatricula As String = ""
                    Dim matricula As String = ""
                    Dim largocadena As String = ""
                    c.FICHA = idficha
                    c.MUESTRA = Trim(csm.MUESTRA)
                    c = c.buscarxfichaxmuestra
                    If Not c Is Nothing Then
                        largocadena = c.MUESTRA
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(c.MUESTRA, Len(c.MUESTRA) - 1, 2)
                        End If
                    Else
                        largocadena = Trim(csm.MUESTRA)
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(csm.MUESTRA, Len(csm.MUESTRA) - 1, 2)
                        End If
                    End If
                    If finmatricula = "T1" Or finmatricula = "T2" Or finmatricula = "T3" Or finmatricula = "T4" Or finmatricula = "T5" Or finmatricula = "T6" Or finmatricula = "T7" Or finmatricula = "T8" Or finmatricula = "T9" Or finmatricula = "t1" Or finmatricula = "t2" Or finmatricula = "t3" Or finmatricula = "t4" Or finmatricula = "t5" Or finmatricula = "t6" Or finmatricula = "t7" Or finmatricula = "t8" Or finmatricula = "t9" Then
                        If Not c Is Nothing Then
                            matricula = Mid(c.MUESTRA, 1, Len(c.MUESTRA) - 2)
                        Else
                            matricula = csm.MUESTRA
                        End If
                    Else
                        If Not c Is Nothing Then
                            matricula = c.MUESTRA
                        Else
                            matricula = csm.MUESTRA
                        End If
                    End If
                    If matricula <> "" Then
                        Linea = Linea & matricula & ";"
                    Else
                        Linea = Linea & "-" & ";"
                    End If
                    'Linea = Linea & fecha & ";"
                    Dim ibc As New dIbc
                    ibc.FICHA = idficha
                    If Not c Is Nothing Then
                        ibc.MUESTRA = Trim(c.MUESTRA)
                    Else
                        ibc.MUESTRA = Trim(csm.MUESTRA)
                    End If
                    ibc = ibc.buscarxfichaxmuestra
                    If csm.RB = 1 Then
                        If Not ibc Is Nothing Then
                            If ibc.RB <> -1 Then
                                Linea = Linea & ibc.RB & "; "
                            Else
                                Linea = Linea & " - " & "; "
                            End If
                        Else
                            Linea = Linea & "-" & "; "
                        End If
                    Else
                        Linea = Linea & "-" & "; "
                    End If
                    ibc = Nothing
                    If csm.RC = 1 Then
                        If Not c Is Nothing Then
                            If c.RC <> -1 Then
                                Linea = Linea & c.RC & "; "
                            Else
                                Linea = Linea & "-" & "; "
                            End If
                        Else
                            Linea = Linea & " - " & "; "
                        End If
                    Else
                        Linea = Linea & " - " & "; "
                    End If
                    If csm.COMPOSICION = 1 Then
                        If Not c Is Nothing Then
                            If c.GRASA <> -1 Then
                                Linea = Linea & c.GRASA & "; " & c.PROTEINA & "; " & c.LACTOSA & "; " & c.ST & "; " & "-0." & c.CRIOSCOPIA
                            Else
                                Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                            End If
                        Else
                            Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                        End If
                    Else
                        Linea = Linea & "-" & ";" & "-" & ";" & "-" & ";" & "-" & ";" & "-"
                    End If
                    oSW.WriteLine(Linea)
                    Linea = ""
                Next
            End If
        End If
        oSW.Flush()
    End Sub
    Private Sub CargarEcolat()
        Dim idficha As Long = TextFicha.Text.Trim

        ' ====================================================================================
        'NUEVO
        Dim colRecuentos As New ServiceReference1.wsCargoRecuentos
        colRecuentos.CodigoAccesso = "1234"
        colRecuentos.InstalacionID = "1"
        colRecuentos.Modo = "INS"

        Dim lista_recuentos As New ArrayList

        ' ====================================================================================

        Dim csm As New dCalidadSolicitudMuestra
        Dim lista As New ArrayList
        lista = csm.listarporsolicitud(idficha)
        Dim s As New dSolicitudAnalisis
        s.ID = idficha
        s = s.buscar
        Dim fecha As String = ""
        If Not s Is Nothing Then
            fecha = s.FECHAINGRESO
        End If

        '*******************************************************
        Dim diaactual As Integer = Mid(fecha, 1, 2)
        Dim semana As Integer = 1
        If diaactual <= 7 Then
            semana = 1
        ElseIf diaactual > 7 And diaactual <= 14 Then
            semana = 2
        ElseIf diaactual > 14 And diaactual <= 21 Then
            semana = 3
        ElseIf diaactual > 21 And diaactual <= 28 Then
            semana = 4
        ElseIf diaactual > 28 Then
            semana = 5
        End If
        '********************************************************

        If Not lista Is Nothing Then
            If lista.Count > 0 Then


                Dim Linea As String = ""
                'Linea = Linea & fecha & Chr(9)
                'oSW.WriteLine(Linea)
                Linea = ""

                For Each csm In lista
                    Dim c As New dCalidad
                    Dim finmatricula As String = ""
                    Dim matricula As String = ""
                    Dim largocadena As String = ""

                    c.FICHA = idficha
                    c.MUESTRA = Trim(csm.MUESTRA)
                    c = c.buscarxfichaxmuestra

                    If Not c Is Nothing Then
                        largocadena = c.MUESTRA
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(c.MUESTRA, Len(c.MUESTRA) - 1, 2)
                        End If
                    Else
                        largocadena = Trim(csm.MUESTRA)
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(csm.MUESTRA, Len(csm.MUESTRA) - 1, 2)
                        End If
                    End If

                    If finmatricula = "T1" Or finmatricula = "T2" Or finmatricula = "T3" Or finmatricula = "T4" Or finmatricula = "T5" Or finmatricula = "T6" Or finmatricula = "T7" Or finmatricula = "T8" Or finmatricula = "T9" Or finmatricula = "t1" Or finmatricula = "t2" Or finmatricula = "t3" Or finmatricula = "t4" Or finmatricula = "t5" Or finmatricula = "t6" Or finmatricula = "t7" Or finmatricula = "t8" Or finmatricula = "t9" Then
                        matricula = Mid(c.MUESTRA, 1, Len(c.MUESTRA) - 2)
                    Else
                        If Not c Is Nothing Then
                            matricula = c.MUESTRA
                        Else
                            matricula = csm.MUESTRA
                        End If
                    End If


                    If matricula <> "" Then
                        Linea = Linea & matricula & ";"
                    Else
                        Linea = Linea & "-" & ";"
                    End If

                    Linea = Linea & semana & ";"

                    Linea = Linea & fecha & ";"


                    Dim ibc As New dIbc
                    ibc.FICHA = idficha
                    If Not c Is Nothing Then
                        ibc.MUESTRA = Trim(c.MUESTRA)
                    Else
                        ibc.MUESTRA = Trim(csm.MUESTRA)
                    End If

                    ibc = ibc.buscarxfichaxmuestra
                    If csm.RB = 1 Then
                        If Not ibc Is Nothing Then
                            If ibc.RB <> -1 Then
                                Linea = Linea & ibc.RB & "000" & ";"
                            Else
                                Linea = Linea & "-" & ";"
                            End If

                        Else
                            Linea = Linea & "-" & ";"

                        End If
                    Else
                        Linea = Linea & "-" & ";"
                    End If


                    ' ====================================================================================

                    'NUEVO
                    Dim item_bc As New ServiceReference1.SDTRecuento_Item

                    item_bc.TambCod = matricula 'ibc.MUESTRA
                    item_bc.RecuSem = semana
                    item_bc.RecuSemFch = fecha
                    item_bc.PruCod = 4
                    If Not ibc Is Nothing Then
                        item_bc.Recuento = ibc.RB * 1000
                    Else
                        item_bc.Recuento = 0
                    End If

                    lista_recuentos.Add(item_bc)


                    ' ====================================================================================
                    ibc = Nothing


                    ' ====================================================================================

                    '             'NUEVO
                    Dim item_rc As New ServiceReference1.SDTRecuento_Item

                    item_rc.TambCod = matricula 'c.MUESTRA
                    item_rc.RecuSem = semana
                    item_rc.RecuSemFch = fecha
                    item_rc.PruCod = 3
                    item_rc.Recuento = c.RC * 1000

                    lista_recuentos.Add(item_rc)



                Next
            End If
        End If

        ' ==================================================================================== 

        ''NUEVO
        Dim matrizunidimensional(lista_recuentos.Count) As ServiceReference1.SDTRecuento_Item
        For i As Integer = 0 To lista_recuentos.Count - 1

            matrizunidimensional(i) = lista_recuentos.Item(i)

        Next

        colRecuentos.Recuentos = matrizunidimensional



        Dim wsSoapClient As New ServiceReference1.WSCargaRecuentosSoapPortClient

        Dim respuesta As ServiceReference1.wsCargoRecuentos_Respuesta = wsSoapClient.Execute(colRecuentos)

        If respuesta IsNot Nothing Then

            For Each item_error In respuesta.Errores
                If item_error.Err_Codigo <> 0 Then
                    MsgBox("Error código " & item_error.Err_Codigo & Chr(13) & Chr(10) & _
                           "Error descripción " & item_error.Err_Descripcion) '& Chr(13) & Chr(10) & _
                    '"Error prucod " & item_error.PruCod & Chr(13) & Chr(10) & _
                    '"Error recusem " & item_error.RecuSem & Chr(13) & Chr(10) & _
                    '"Error tambcod " & item_error.TambCod)
                End If
            Next

        End If

    End Sub


    Private Sub creainformetxt2()
        Dim idficha As Long = TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt")
        Dim csm As New dCalidadSolicitudMuestra
        Dim lista As New ArrayList
        lista = csm.listarporsolicitud(idficha)
        Dim s As New dSolicitudAnalisis
        s.ID = idficha
        s = s.buscar
        Dim fecha As String = ""
        If Not s Is Nothing Then
            fecha = s.FECHAINGRESO
        End If
        If Not lista Is Nothing Then
            If lista.Count > 0 Then


                Dim Linea As String = ""
                'Linea = Linea & fecha & Chr(9)
                'oSW.WriteLine(Linea)
                Linea = ""

                For Each csm In lista
                    Dim c As New dCalidad
                    Dim finmatricula As String = ""
                    Dim matricula As String = ""
                    Dim largocadena As String = ""

                    c.FICHA = idficha
                    c.MUESTRA = Trim(csm.MUESTRA)
                    c = c.buscarxfichaxmuestra

                    If Not c Is Nothing Then
                        largocadena = c.MUESTRA
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(c.MUESTRA, Len(c.MUESTRA) - 1, 2)
                        End If
                    Else
                        largocadena = Trim(csm.MUESTRA)
                        If largocadena.Length > 1 Then
                            finmatricula = Mid(csm.MUESTRA, Len(csm.MUESTRA) - 1, 2)
                        End If
                    End If

                    If finmatricula = "T1" Or finmatricula = "T2" Or finmatricula = "T3" Or finmatricula = "T4" Or finmatricula = "T5" Or finmatricula = "T6" Or finmatricula = "T7" Or finmatricula = "T8" Or finmatricula = "T9" Or finmatricula = "t1" Or finmatricula = "t2" Or finmatricula = "t3" Or finmatricula = "t4" Or finmatricula = "t5" Or finmatricula = "t6" Or finmatricula = "t7" Or finmatricula = "t8" Or finmatricula = "t9" Then
                        matricula = Mid(c.MUESTRA, 1, Len(c.MUESTRA) - 2)
                    Else
                        If Not c Is Nothing Then
                            matricula = c.MUESTRA
                        Else
                            matricula = csm.MUESTRA
                        End If
                    End If


                    If matricula <> "" Then
                        Linea = Linea & matricula & ";"
                    Else
                        Linea = Linea & "-" & ";"
                    End If

                    Linea = Linea & "-" & ";"

                    Linea = Linea & fecha & ";"


                    Dim ibc As New dIbc
                    ibc.FICHA = idficha
                    If Not c Is Nothing Then
                        ibc.MUESTRA = Trim(c.MUESTRA)
                    Else
                        ibc.MUESTRA = Trim(csm.MUESTRA)
                    End If

                    ibc = ibc.buscarxfichaxmuestra
                    If csm.RB = 1 Then
                        If Not ibc Is Nothing Then
                            If ibc.RB <> -1 Then
                                Linea = Linea & ibc.RB & "000" & ";"
                            Else
                                Linea = Linea & "-" & ";"
                            End If
                            ibc = Nothing
                        Else
                            Linea = Linea & "-" & ";"

                        End If
                    Else
                        Linea = Linea & "-" & ";"
                    End If


                    If csm.RC = 1 Then
                        If Not c Is Nothing Then
                            If c.RC <> -1 Then
                                Linea = Linea & c.RC & "000" '& ";"
                            Else
                                Linea = Linea & "-" '& ";"
                            End If
                        Else
                            Linea = Linea & "-" '& ";"
                        End If
                    Else
                        Linea = Linea & "-" '& ";"
                    End If



                    'If csm.COMPOSICION = 1 Then
                    '    If c.GRASA = -1 Then
                    '        Linea = Linea & "-" & Chr(9)
                    '    Else
                    '        Dim valgrasa = Val(c.GRASA)
                    '        Linea = Linea & valgrasa & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    'If csm.COMPOSICION = 1 Then
                    '    If c.PROTEINA = -1 Then
                    '        Linea = Linea & "-" & Chr(9)
                    '    Else
                    '        Dim valproteina = Val(c.PROTEINA)
                    '        Linea = Linea & valproteina & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    'If csm.COMPOSICION = 1 Then
                    '    If c.LACTOSA = -1 Then
                    '        Linea = Linea & "-" & Chr(9)
                    '    Else
                    '        Linea = Linea & c.LACTOSA & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    'If csm.COMPOSICION = 1 Then
                    '    If c.ST = -1 Then
                    '        Linea = Linea & "-" & Chr(9)
                    '    Else
                    '        Linea = Linea & c.ST & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    'If csm.CRIOSCOPIA = 1 Then
                    '    If c.CRIOSCOPIA = -1 Then
                    '        Linea = Linea & "-" & Chr(9)
                    '    Else
                    '        Linea = Linea & c.CRIOSCOPIA & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    'If csm.UREA = 1 Then
                    '    If c.UREA = -1 Then
                    '        Linea = Linea & "-" & Chr(9)
                    '    Else
                    '        Linea = Linea & c.UREA & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    'Dim inh As New dInhibidores
                    'inh.FICHA = idficha
                    'inh.MUESTRA = Trim(c.MUESTRA)
                    'inh = inh.buscarxfichaxmuestra
                    'If csm.INHIBIDORES = 1 Then
                    '    If Not inh Is Nothing Then
                    '        Linea = Linea & inh.RESULTADO & Chr(9)
                    '    Else
                    '        Linea = Linea & "-" & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    'Esporulados
                    'Linea = Linea & "-" & Chr(9)

                    'psicrotrofos
                    'Linea = Linea & "-" & Chr(9)

                    'If csm.CASEINA = 1 Then
                    '    If c.CASEINA = -1 Then
                    '        Linea = Linea & "-" & Chr(9)
                    '    Else
                    '        Linea = Linea & c.CASEINA & Chr(9)
                    '    End If
                    'Else
                    '    Linea = Linea & "-" & Chr(9)
                    'End If

                    oSW.WriteLine(Linea)
                    Linea = ""
                    'secuencial = secuencial + 1
                Next
            End If
        End If


        oSW.Flush()
    End Sub

    Private Sub ButtonEcolat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEcolat.Click
        Dim ficha As Long = TextFicha.Text.Trim
        Dim s As New dSolicitudAnalisis

        s.ID = ficha
        s = s.buscar
        Dim productor As Long = 0
        If Not s Is Nothing Then
            productor = s.IDPRODUCTOR
        End If
        If productor = 143 Then
            If CheckBloqueaEcolat.Checked = True Then
                CargarEcolat()
            End If
        End If
        limpiar()
    End Sub
End Class