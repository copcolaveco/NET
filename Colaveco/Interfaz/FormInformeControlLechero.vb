Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeControlLechero
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

        'Dim vg As New FormGraficaCL(ficha)
        'vg.ShowDialog()


        '*** Controla que el productor realiza cambio de caravanas **********************
        Dim sa As New dSolicitudAnalisis
        Dim caravanas As Integer = 0
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            Dim p As New dCliente
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                If p.CARAVANAS = 1 Then
                    caravanas = 1
                End If
            End If
        End If
        If caravanas = 1 Then
            Dim result = MessageBox.Show("El productor realiza cambio de caravanas!, desea continuar?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                limpiar()
                Exit Sub
            ElseIf result = DialogResult.No Then
                limpiar()
                Exit Sub
            ElseIf result = DialogResult.Yes Then

            End If
        End If
        '*********************************************************************************************

        Dim v As New FormSeleccionarTecnico
        v.ShowDialog()
        Dim v2 As New FormMuestrasNoAptas(Usuario, ficha)
        v2.ShowDialog()
        Dim v3 As New FormObservaciones(Usuario, ficha)
        v3.ShowDialog()
        creainformetxt()
        'creainformeexcel()
        creainformeexcel2()
        creainformeexcel3()
        abrirventanaenvio()
        limpiar()
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        listarfichas()
    End Sub
    Private Sub listarfichas()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarfichascontrol
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ListFichas().Items.Add(s)
                Next
            End If
        End If
    End Sub
    Private Sub creainformeexcel3()
        Dim proceso1 As System.Diagnostics.Process()
        proceso1 = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each opro As System.Diagnostics.Process In proceso1
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next

        Dim idsol As Long = TextFicha.Text.Trim
        Dim Arch As String
        Arch = "\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls"
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        Dim c As New dControl

        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************

        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        'sa.marcar(Usuario)

        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Unprotect(Password:="1582782")
        '*****************************
        Dim fila As Integer
        Dim columna As Integer

        'fila = 1
        'columna = 1
        'x1libro.Worksheets(1).cells(fila, columna).select()
        'x1libro.ActiveSheet.pictures.Insert("c:\Debug\encabezado.jpg").select()
        'x1libro.Worksheets(1).cells(2, 1).select()

        fila = 1
        columna = 2


        x1hoja.Shapes.AddPicture("c:\Debug\encabezado.jpg", _
        Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)



        x1hoja.Cells(1, 1).columnwidth = 5
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5.5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 2.5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 5
        x1hoja.Cells(1, 14).columnwidth = 5
        x1hoja.Cells(1, 15).columnwidth = 5
        x1hoja.Range("A1", "D1").Merge()

        columna = 4
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("B4", "C4").Merge()
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("A5", "M5").Merge()
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DEL RECUENTO CELULAR Y COMPOSICIÓN DE VACAS INDIVIDUALES"
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
        x1hoja.Range("H8", "N8").Merge()
        x1hoja.Range("H8", "N8").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "R. Celular x 1000cel/mL (Mét. IR - ISO 13366-2:2006)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
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
        columna = columna + 5
        x1hoja.Range("H9", "N9").Merge()
        x1hoja.Range("H9", "N9").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "Gr, Pr, Lc* % peso/vol.(Mét. IR - ISO 9622 - IDF 141:2013)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
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
        columna = columna + 5
        x1hoja.Range("H10", "N10").Merge()
        x1hoja.Range("H10", "N10").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "MUN* mg/dL (Mét. IR - Boletín FIL 393:2003"
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
        Dim cx As New dControl
        Dim listacx As New ArrayList
        listacx = cx.listarfechaproceso(sa.ID)
        If Not listacx Is Nothing Then
            For Each cx In listacx
                x1hoja.Cells(fila, columna).formula = cx.FECHA
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 5
            Next
        Else
            x1hoja.Cells(fila, columna).formula = fecha2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 5
        End If
        cx = Nothing
        listacx = Nothing
        x1hoja.Cells(fila, columna).formula = "Gr = Grasa, Pr = Proteina, Lc = Lactosa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C12", "D12").Merge()
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8

        columna = columna + 5
        x1hoja.Cells(fila, columna).formula = "MUN = Nitrogeno ureico, Rc = Recuento celular"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        x1hoja.Cells(fila, columna).Formula = "Paratécnico:"
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
        If idparatecnico7 = 1 Then
            paratecnico = paratecnico + "Cristian Cedrani - "
        End If
        If paratecnico <> "" Then
            x1hoja.Cells(fila, columna).formula = paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            'fila = fila + 1
            'columna = 1
        Else
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            'fila = fila + 1
            'columna = 1
        End If

        'columna = columna + 5
        'x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 5
        'Dim valtemperatura = Val(sa.TEMPERATURA)
        'If valtemperatura < 1 Or valtemperatura > 7 Then
        'x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        'End If
        'x1hoja.Cells(fila, columna).formula = sa.TEMPERATURA & " " & "Cº"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "* Ensayos no acreditados ISO 17025 por OUA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 2
        columna = 1


        lista = c.listarporsolicitud(idsol)
        lista2 = c.listarporrc(idsol)


        Dim libreinfeccion As Integer = 0
        Dim posibleinfeccion As Integer = 0
        Dim probableinfeccion As Integer = 0
        For Each c In lista2
            'If c.RC < 150 Then
            '    libreinfeccion = libreinfeccion + 1
            'ElseIf c.RC >= 150 And c.RC < 400 Then
            '    posibleinfeccion = posibleinfeccion + 1
            'ElseIf c.RC >= 400 Then
            '    probableinfeccion = probableinfeccion + 1
            'End If
            If c.RC <= 200 Then
                libreinfeccion = libreinfeccion + 1
                'ElseIf c.RC >= 150 And c.RC < 400 Then
                '    posibleinfeccion = posibleinfeccion + 1
            ElseIf c.RC > 200 Then
                probableinfeccion = probableinfeccion + 1
            End If
        Next
        fila = lista.Count + 18


        '***CALCULO PRECIO NUEVO ***************************************
        Dim ti As Integer = 0
        Dim sti As Integer = 0
        Dim ficha As Long = 0
        Dim muestrastotales As Integer = 0
        ficha = idsol
        sa.ID = idsol
        sa = sa.buscar
        If Not sa Is Nothing Then
            ti = sa.IDTIPOINFORME
            sti = sa.IDSUBINFORME
            'muestras = sa.NMUESTRAS
        End If

        Dim listamuestras As New ArrayList
        listamuestras = c.listarporsolicitud(idsol)
        muestrastotales = listamuestras.Count
        Dim minimomuestras As Integer = 0

        '*** CUENTA MUESTRAS NO APTAS ***************************************
        Dim mna As New dMuestrasNoAptas
        Dim cuenta_mna As Integer = 0
        Dim cuenta_rep As Integer = 0
        Dim faltan As Integer = 0
        lista3 = mna.listarporficha(idsol)
        If Not lista3 Is Nothing Then
            If lista3.Count > 0 Then
                For Each mna In lista3
                    If mna.MOTIVO = 8 Then
                        cuenta_rep = cuenta_rep + mna.CANTIDAD
                    End If
                    If mna.MOTIVO = 4 Or mna.MOTIVO = 6 Or mna.MOTIVO = 10 Then
                        faltan = faltan + mna.CANTIDAD
                    End If
                    If mna.MOTIVO = 1 Or mna.MOTIVO = 2 Or mna.MOTIVO = 3 Or mna.MOTIVO = 5 Or mna.MOTIVO = 7 Or mna.MOTIVO = 9 Then
                        cuenta_mna = cuenta_mna + mna.CANTIDAD
                    End If
                Next
            End If
        End If
        Dim muestrasanalizadas As Integer = 0
        muestrasanalizadas = muestrastotales - cuenta_mna
        muestrasanalizadas = muestrasanalizadas - faltan
        '********************************************************************

        Dim total1 As Double = 0
        Dim total2 As Double = 0
        Dim total3 As Double = 0
        Dim total4 As Double = 0
        Dim total As Double = 0
        Dim lp As New dListaPrecios

        Dim idrc_comp As Integer = 116
        Dim idrc_comp_urea As Integer = 117
        Dim idrc_comp_caseina As Integer = 157
        Dim idrc_comp_urea_caseina As Integer = 158
        Dim id_noprocesadas As Integer = 224
        Dim idtimbre As Integer = 86

        Dim preciorc_comp As Double
        Dim preciorc_comp_urea As Double
        Dim preciorc_comp_caseina As Double
        Dim preciorc_comp_urea_caseina As Double
        Dim precio_noprocesadas As Double
        Dim preciotimbre As Double

        Dim cli As New dCliente
        Dim precio As Integer = 0
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        If Not cli Is Nothing Then
            precio = cli.FAC_LISTA
        End If

        If precio = 1 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO1
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO1
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO1
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO1
        ElseIf precio = 2 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_urea = lp.PRECIO1
            End If
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_caseina = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO2
            If lp.PRECIO2 = 0 Then
                preciorc_comp_urea_caseina = lp.PRECIO1
            End If
        ElseIf precio = 3 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_urea = lp.PRECIO1
            End If
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_caseina = lp.PRECIO1
            End If
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO3
            If lp.PRECIO3 = 0 Then
                preciorc_comp_urea_caseina = lp.PRECIO1
            End If
        ElseIf precio = 4 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO4
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO4
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO4
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO4
        ElseIf precio = 5 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO5
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO5
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO5
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO5
        ElseIf precio = 6 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO6
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO6
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO6
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO6
        ElseIf precio = 7 Then
            lp.ID = idrc_comp
            lp = lp.buscar
            preciorc_comp = lp.PRECIO7
            lp.ID = idrc_comp_urea
            lp = lp.buscar
            preciorc_comp_urea = lp.PRECIO7
            lp.ID = idrc_comp_caseina
            lp = lp.buscar
            preciorc_comp_caseina = lp.PRECIO7
            lp.ID = idrc_comp_urea_caseina
            lp = lp.buscar
            preciorc_comp_urea_caseina = lp.PRECIO7
        End If

        lp.ID = id_noprocesadas
        lp = lp.buscar
        precio_noprocesadas = lp.PRECIO1

        lp.ID = idtimbre
        lp = lp.buscar
        preciotimbre = lp.PRECIO1

        If muestrasanalizadas > 0 And muestrasanalizadas < 20 Then
            muestrasanalizadas = 20
        End If

        Dim subtipo As Integer
        subtipo = sti

        If subtipo = 1 Then
            total1 = muestrasanalizadas * preciorc_comp
        ElseIf subtipo = 32 Then
            total2 = muestrasanalizadas * preciorc_comp_urea
        ElseIf subtipo = 53 Then
            total3 = muestrasanalizadas * preciorc_comp_caseina
        ElseIf subtipo = 54 Then
            total4 = muestrasanalizadas * preciorc_comp_urea_caseina
        End If


        Dim analisis As Integer = 0
        Dim precio1 As Double = 0
        Dim precio2 As Double = 0
        Dim precio3 As Double = 0
        Dim precio4 As Double = 0


        Dim subtotal As Double = 0


        If sti = 1 Then
            analisis = 116
            precio1 = preciorc_comp
            Dim f1 As New dFacturacion
            f1.FICHA = ficha
            f1.CANTIDAD = muestrasanalizadas
            f1.ANALISIS = analisis
            f1.PRECIO = precio1
            f1.SUBTOTAL = total1
            f1.FACTURA = 0
            'f1.guardar(Usuario)
            total = total + total1
            f1 = Nothing
        ElseIf sti = 32 Then
            analisis = 117
            precio2 = preciorc_comp_urea
            Dim f2 As New dFacturacion
            f2.FICHA = ficha
            f2.CANTIDAD = muestrasanalizadas
            f2.ANALISIS = analisis
            f2.PRECIO = precio2
            f2.SUBTOTAL = total2
            f2.FACTURA = 0
            'f2.guardar(Usuario)
            total = total + total2
            f2 = Nothing
        ElseIf sti = 53 Then
            analisis = 157
            precio3 = preciorc_comp_caseina
            Dim f3 As New dFacturacion
            f3.FICHA = ficha
            f3.CANTIDAD = muestrasanalizadas
            f3.ANALISIS = analisis
            f3.PRECIO = precio3
            f3.SUBTOTAL = total3
            f3.FACTURA = 0
            'f3.guardar(Usuario)
            total = total + total3
            f3 = Nothing
        ElseIf sti = 54 Then
            analisis = 158
            precio4 = preciorc_comp_urea_caseina
            Dim f4 As New dFacturacion
            f4.FICHA = ficha
            f4.CANTIDAD = muestrasanalizadas
            f4.ANALISIS = analisis
            f4.PRECIO = precio4
            f4.SUBTOTAL = total4
            f4.FACTURA = 0
            'f4.guardar(Usuario)
            total = total + total4
            f4 = Nothing
        End If
        If cuenta_mna > 0 Then
            MsgBox("Hay muestras no aptas para hacer Nota de Crédito!")
            If sti = 1 Then
                'analisis = 116
                analisis = 224
                'precio1 = preciorc_comp * 0.5
                precio1 = precio_noprocesadas
                Dim f1 As New dFacturacion
                f1.FICHA = ficha
                f1.CANTIDAD = cuenta_mna
                f1.ANALISIS = analisis
                f1.PRECIO = precio1
                f1.SUBTOTAL = cuenta_mna * precio1
                f1.FACTURA = 0
                f1.guardar(Usuario)
                total = total + f1.SUBTOTAL
                f1 = Nothing
            ElseIf sti = 32 Then
                'analisis = 117
                analisis = 224
                'precio2 = preciorc_comp_urea * 0.5
                precio2 = precio_noprocesadas
                Dim f2 As New dFacturacion
                f2.FICHA = ficha
                f2.CANTIDAD = cuenta_mna
                f2.ANALISIS = analisis
                f2.PRECIO = precio2
                f2.SUBTOTAL = cuenta_mna * precio2
                f2.FACTURA = 0
                f2.guardar(Usuario)
                total = total + f2.SUBTOTAL
                f2 = Nothing
            ElseIf sti = 53 Then
                'analisis = 157
                analisis = 224
                'precio3 = preciorc_comp_caseina * 0.5
                precio3 = precio_noprocesadas
                Dim f3 As New dFacturacion
                f3.FICHA = ficha
                f3.CANTIDAD = cuenta_mna
                f3.ANALISIS = analisis
                f3.PRECIO = precio3
                f3.SUBTOTAL = cuenta_mna * precio3
                f3.FACTURA = 0
                f3.guardar(Usuario)
                total = total + f3.SUBTOTAL
                f3 = Nothing
            ElseIf sti = 54 Then
                'analisis = 158
                analisis = 224
                'precio4 = preciorc_comp_urea_caseina * 0.5
                precio4 = precio_noprocesadas
                Dim f4 As New dFacturacion
                f4.FICHA = ficha
                f4.CANTIDAD = cuenta_mna
                f4.ANALISIS = analisis
                f4.PRECIO = precio4
                f4.SUBTOTAL = cuenta_mna * precio4
                f4.FACTURA = 0
                f4.guardar(Usuario)
                total = total + f4.SUBTOTAL
                f4 = Nothing
            End If
        End If
        total = total + preciotimbre
        '***************************************************************

        '/* Actualiza el importe en la solicitud 
        Dim saimp As New dSolicitudAnalisis
        Dim importesa As Double = total
        saimp.ID = idsol
        saimp.actualizarimporte(importesa)
        '***************************************/
        fila = fila + 3
        columna = 1

        If sa.OBSERVACIONES <> "" Then
            x1hoja.Cells(fila, columna).formula = "Observaciones:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            fila = fila + 1
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

        x1hoja.Cells(fila, columna).formula = "Total de muestras procesadas:" & " " & muestrasanalizadas
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2.5 o >40 Proteína <2.5 o >5 Grasa %)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 7
        x1hoja.Cells(fila, columna).Font.Bold = False
        columna = 1
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & Math.Round(total, 0)
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "La indicación ''Fuera de rango''. está fuera del alcance de la acreditación"
        'x1hoja.Cells(fila, columna).formula = ""
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 6
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = 1
        fila = fila + 1
        columna = columna + 6
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
        columna = 1

        x1libro.Worksheets(1).cells(fila, columna).select()
        Dim rangeFirma As String = "A" + fila.ToString
        x1libro.ActiveSheet.Range(rangeFirma).select()
        InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
        x1libro.Worksheets(1).cells(2, 1).select()


        columna = columna + 6
        x1hoja.Cells(fila, columna).formula = "Interpretación de recuento celular"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna - 5
        fila = fila + 1


        Dim vallibreinfeccion As Integer = 0
        Dim valposibleinfeccion As Integer = 0
        Dim valprobableinfeccion As Integer = 0
        Dim sumavalores As Integer = 0
        Dim diferenciavalores As Integer = 0

        'vallibreinfeccion = (libreinfeccion / muestrasreales) * 100
        'valposibleinfeccion = (posibleinfeccion / muestrasreales) * 100
        'valprobableinfeccion = (probableinfeccion / muestrasreales) * 100

        vallibreinfeccion = (libreinfeccion / muestrastotales) * 100
        valposibleinfeccion = (posibleinfeccion / muestrastotales) * 100
        valprobableinfeccion = (probableinfeccion / muestrastotales) * 100

        sumavalores = vallibreinfeccion + valposibleinfeccion + valprobableinfeccion
        diferenciavalores = sumavalores - 100
        If diferenciavalores < 0 Then
            diferenciavalores = diferenciavalores * -1
        End If
        If sumavalores > 100 Then
            vallibreinfeccion = vallibreinfeccion - diferenciavalores
        ElseIf sumavalores < 100 Then
            vallibreinfeccion = vallibreinfeccion + diferenciavalores
        End If

        'x1hoja.Cells(fila, columna).formula = "<150: probablemente libre de infección:" & " " & libreinfeccion & " " & "(" & Math.Round(vallibreinfeccion, 0) & " %" & ")"
        x1hoja.Cells(fila, columna).formula = "<=200: vacas sanas:" & " " & libreinfeccion & " " & "(" & Math.Round(vallibreinfeccion, 0) & " %" & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna - 5
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "150-400: posiblemente infectadas:" & " " & posibleinfeccion & " " & "(" & Math.Round(valposibleinfeccion, 0) & " %" & ")"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Size = 8
        'x1hoja.Cells(fila, columna).Font.Bold = False
        'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        'columna = columna - 5
        'fila = fila + 1
        x1hoja.Cells(fila, columna).formula = ">200: vacas infectadas:" & " " & probableinfeccion & " " & "(" & Math.Round(valprobableinfeccion, 0) & " %" & ")"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna - 5
        fila = fila + 1
        'x1hoja.Cells(fila, columna).formula = "R.Blowey & P. Edmonson, (1995)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        columna = columna + 1
        x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
        fila = fila + 1
        columna = 7
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).formula = "Valores de 30 en RC, corresponden a <=30 (menor o igual)"

        '** SI HAY MUESTRAS NO APTAS ***************************************
        If cuenta_mna > 0 Or cuenta_rep > 0 Then
            columna = 1
            fila = fila + 1
            x1hoja.Cells(fila, columna).formula = "(**) No apta por:"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            columna = columna + 1
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            columna = columna + 1
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            columna = columna + 1
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            columna = 1
            fila = fila + 1
            Dim muestrasna As New dMuestrasNoAptas
            Dim muestrana As New dMuestraNoApta
            Dim motivomna As Integer = 0
            Dim cantidadmna As Integer = 0
            lista3 = muestrasna.listarporficha(idsol)
            If Not lista3 Is Nothing Then
                If lista3.Count > 0 Then
                    For Each muestrasna In lista3
                        motivomna = muestrasna.MOTIVO
                        muestrana.ID = motivomna
                        muestrana = muestrana.buscar()
                        x1hoja.Cells(fila, columna).formula = muestrana.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        columna = columna + 1
                        cantidadmna = muestrasna.CANTIDAD
                        x1hoja.Cells(fila, columna).formula = cantidadmna
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        columna = 1
                        fila = fila + 1
                    Next
                End If
            End If
            x1hoja.Cells(fila, columna).formula = "Muestras no aptas = 50% importe del análisis"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).Font.Bold = True
        End If

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

        fila = fila + 1
        x1hoja.Range("A" & fila, "O" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7

        'GRAFICAS*******************************************************************
        'fila = fila + 2
        'columna = 1
        'x1libro.Worksheets(1).cells(fila, columna).select()
        'x1libro.ActiveSheet.pictures.Insert("\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\" & idsol & "_RC.jpg").select()
        'x1libro.Worksheets(1).cells(2, 1).select()

        '***************************************************************************



        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls")


        x1app.Visible = True
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
        Dim proceso1 As System.Diagnostics.Process()
        proceso1 = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each opro As System.Diagnostics.Process In proceso1
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next

        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        Dim c As New dControl
        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        '*****************************
        Dim idsol As Long = TextFicha.Text 'ficha
        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        fila = 1
        columna = 2
        '*** ENCABEZADO ********************************************************************************
        '***********************************************************************************************
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
        columna = columna + 8
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
        x1hoja.Cells(fila, columna).Formula = "RCS"
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
        x1hoja.Cells(fila, columna).Formula = "Lac*"
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
        x1hoja.Cells(fila, columna).Formula = "Cas*"
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
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("C17", "C18").Merge()
        x1hoja.Range("C17", "C18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("C17", "C18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("C17", "C18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("D17", "D18").Merge()
        x1hoja.Range("D17", "D18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("D17", "D18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("D17", "D18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("E17", "E18").Merge()
        x1hoja.Range("E17", "E18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("E17", "E18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("E17", "E18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("F17", "F18").Merge()
        x1hoja.Range("F17", "F18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("F17", "F18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("F17", "F18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "mg/dL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("G17", "G18").Merge()
        x1hoja.Range("G17", "G18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("G17", "G18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("G17", "G18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = 1
        fila = fila + 2
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
                        If c.RC < 30 Then
                            x1hoja.Cells(fila, columna).formula = "30"
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
                        If valgrasa < 2.0 Or valgrasa > 5.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.GRASA.ToString("##,##0.00")
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
                        If valproteina < 2.0 Or valproteina > 4.5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = c.PROTEINA.ToString("##,##0.00")
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
                        x1hoja.Cells(fila, columna).formula = c.LACTOSA.ToString("##,##0.00")
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If
                    'Dim cs As New dControlSolicitud
                    'cs.FICHA = idsol
                    'cs = cs.buscar
                    Dim na As New dNuevoAnalisis
                    Dim listana As New ArrayList
                    Dim _urea As Integer = 0
                    Dim _caseina As Integer = 0
                    listana = na.listarporficha2(idsol)
                    If Not listana Is Nothing Then
                        For Each na In listana
                            If na.ANALISIS = 117 Then
                                _urea = 1
                            End If
                            If na.ANALISIS = 157 Then
                                _caseina = 1
                            End If
                            If na.ANALISIS = 158 Then
                                _caseina = 1
                                _urea = 1
                            End If
                        Next
                    End If
                    'If Not cs Is Nothing Then
                    If _urea = 1 Then
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
                    If _caseina = 1 Then
                        If c.CASEINA = -1 Or c.UREA = 0 Then
                            x1hoja.Cells(fila, columna).formula = "-"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = c.CASEINA.ToString("##,##0.00")
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
                    'Else
                    '    x1hoja.Cells(fila, columna).formula = "-"
                    '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    '    x1hoja.Cells(fila, columna).Font.Size = 8
                    '    columna = columna + 1
                    'End If
                    na = Nothing
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
            x1hoja.Cells(fila, columna).Formula = "RCS"
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
            x1hoja.Cells(fila, columna).Formula = "Lac*"
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
            x1hoja.Cells(fila, columna).Formula = "Cas*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = 9
            fila = fila + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("I17", "I18").Merge()
            x1hoja.Range("I17", "I18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("I17", "I18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("I17", "I18").WrapText = True
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("J17", "J18").Merge()
            x1hoja.Range("J17", "J18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("J17", "J18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("J17", "J18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("K17", "K18").Merge()
            x1hoja.Range("K17", "K18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("K17", "K18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("K17", "K18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("L17", "L18").Merge()
            x1hoja.Range("L17", "L18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("L17", "L18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("L17", "L18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("M17", "M18").Merge()
            x1hoja.Range("M17", "M18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("M17", "M18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("M17", "M18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("N17", "N18").Merge()
            x1hoja.Range("N17", "N18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("N17", "N18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("N17", "N18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "mg/dL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("O17", "O18").Merge()
            x1hoja.Range("O17", "O18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("O17", "O18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("O17", "O18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = 9
            fila = fila + 2
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
                            If c.RC < 30 Then
                                x1hoja.Cells(fila, columna).formula = "30"
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
                            If valgrasa < 2.0 Or valgrasa > 5.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.GRASA.ToString("##,##0.00")
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
                            If valproteina < 2.0 Or valproteina > 4.5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = c.PROTEINA.ToString("##,##0.00")
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
                            x1hoja.Cells(fila, columna).formula = c.LACTOSA.ToString("##,##0.00")
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
                        'Dim cs As New dControlSolicitud
                        'cs.FICHA = idsol
                        'cs = cs.buscar
                        Dim na2 As New dNuevoAnalisis
                        Dim listana2 As New ArrayList
                        Dim _urea As Integer = 0
                        Dim _caseina As Integer = 0
                        listana2 = na2.listarporficha2(idsol)
                        If Not listana2 Is Nothing Then
                            For Each na2 In listana2
                                If na2.ANALISIS = 117 Then
                                    _urea = 1
                                End If
                                If na2.ANALISIS = 157 Then
                                    _caseina = 1
                                End If
                                If na2.ANALISIS = 158 Then
                                    _caseina = 1
                                    _urea = 1
                                End If

                            Next
                        End If
                        'If Not cs Is Nothing Then
                        If _urea = 1 Then
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
                        If _caseina = 1 Then
                            If c.CASEINA = -1 Or c.CASEINA = 0 Then
                                x1hoja.Cells(fila, columna).formula = "-"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                            Else
                                x1hoja.Cells(fila, columna).formula = c.CASEINA.ToString("##,##0.00")
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
                        'Else
                        '    x1hoja.Cells(fila, columna).formula = "-"
                        '    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        '    x1hoja.Cells(fila, columna).Font.Size = 8
                        '    columna = columna + 1
                        'End If
                        na2 = Nothing
                        columna = 9
                        fila = fila + 1
                    Next
                    'Referencias
                    fila = fila + 1
                    columna = 1
                End If
            End If
        End If
        'GUARDA EL ARCHIVO DE EXCEL
        x1app.DisplayAlerts = False 'NO PREGUNTA SI EL ARCHIVO EXISTE
        x1hoja.PageSetup.CenterFooter = "Página &P"
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls")
        'x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & "p" & idsol & ".xls")
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

        Dim proceso As System.Diagnostics.Process()
        proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        For Each opro As System.Diagnostics.Process In proceso
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()
        Next
        Dim v As New FormGraficasRC(idsol)
        v.Show()


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

        Dim c As New dControl

        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim tec As New dCliente
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
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

        x1hoja.Shapes.AddPicture("c:\Debug\encabezado.jpg", _
              Microsoft.Office.Core.MsoTriState.msoFalse, _
              Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)


        x1hoja.Cells(1, 1).columnwidth = 5
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5.5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 2.5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 5
        x1hoja.Cells(1, 12).columnwidth = 5
        x1hoja.Cells(1, 13).columnwidth = 5
        x1hoja.Cells(1, 14).columnwidth = 5
        x1hoja.Cells(1, 15).columnwidth = 5
        x1hoja.Range("A1", "D1").Merge()

        columna = 4
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("B4", "C4").Merge()
        fila = fila + 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Range("A5", "M5").Merge()
        fila = fila + 2
        columna = 1
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).Formula = "INFORME DEL RECUENTO CELULAR Y COMPOSICIÓN DE VACAS INDIVIDUALES"
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
        x1hoja.Range("H8", "N8").Merge()
        x1hoja.Range("H8", "N8").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "R. Celular x 1000cel/mL (Mét. IR - ISO 13366-2:2006)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
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
        columna = columna + 5
        x1hoja.Range("H9", "N9").Merge()
        x1hoja.Range("H9", "N9").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "Gr, Pr, Lc* % peso/vol.(Mét. IR - ISO 9622 -IDF 141:2013)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
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
        columna = columna + 5
        x1hoja.Range("H10", "N10").Merge()
        x1hoja.Range("H10", "N10").Borders.Color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).formula = "MUN* mg/dL (Mét. IR - Boletín FIL 393:2003"
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
        Dim cx As New dControl
        Dim listacx As New ArrayList
        listacx = cx.listarfechaproceso(sa.ID)
        If Not listacx Is Nothing Then
            For Each cx In listacx
                x1hoja.Cells(fila, columna).formula = cx.FECHA
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 5
            Next
        Else
            x1hoja.Cells(fila, columna).formula = fecha2
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            columna = columna + 5
        End If
        cx = Nothing
        listacx = Nothing
        x1hoja.Cells(fila, columna).formula = "Gr = Grasa, Pr = Proteina, Lc = Lactosa"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C12", "D12").Merge()
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8

        columna = columna + 5
        x1hoja.Cells(fila, columna).formula = "MUN = Nitrogeno ureico, Rc = Recuento celular"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1

        x1hoja.Cells(fila, columna).Formula = "Paratécnico:"
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
        If idparatecnico7 = 1 Then
            paratecnico = paratecnico + "Cristian Cedrani - "
        End If
        If paratecnico <> "" Then
            x1hoja.Cells(fila, columna).formula = paratecnico
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            'fila = fila + 1
            'columna = 1
        Else
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(fila, columna).Font.Size = 8
            'fila = fila + 1
            'columna = 1
        End If

        'columna = columna + 5
        'x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 5
        'Dim valtemperatura = Val(sa.TEMPERATURA)
        'If valtemperatura < 1 Or valtemperatura > 7 Then
        'x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        'End If
        'x1hoja.Cells(fila, columna).formula = sa.TEMPERATURA & " " & "Cº"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        'columna = columna + 2
        x1hoja.Cells(fila, columna).formula = "* Ensayos no acreditados ISO 17025 por OUA"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 2
        columna = 1

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
        x1hoja.Cells(fila, columna).Formula = "Rc"
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
        x1hoja.Cells(fila, columna).Formula = "MUN*"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Cas*"
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
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("C17", "C18").Merge()
        x1hoja.Range("C17", "C18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("C17", "C18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("C17", "C18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("D17", "D18").Merge()
        x1hoja.Range("D17", "D18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("D17", "D18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("D17", "D18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("E17", "E18").Merge()
        x1hoja.Range("E17", "E18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("E17", "E18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("E17", "E18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("F17", "F18").Merge()
        x1hoja.Range("F17", "F18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("F17", "F18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("F17", "F18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "mg/dl"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = columna + 1
        x1hoja.Cells(1, 1).RowHeight = 18
        x1hoja.Range("G17", "G18").Merge()
        x1hoja.Range("G17", "G18").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("G17", "G18").Interior.Color = RGB(192, 192, 192)
        x1hoja.Range("G17", "G18").WrapText = True
        x1hoja.Cells(fila, columna).formula = "g/100mL"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
        x1hoja.Cells(fila, columna).Font.Size = 6
        columna = 1
        fila = fila + 2
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.FICHA = idsol
                cs = cs.buscar

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
                        If c.RC < 30 Then
                            x1hoja.Cells(fila, columna).formula = "30"
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
                        If valgrasa < 2.5 Or valgrasa > 5 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = FormatNumber(c.GRASA, 2)
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
                        If valproteina < 2.5 Or valproteina > 4 Then
                            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                        End If
                        x1hoja.Cells(fila, columna).formula = FormatNumber(c.PROTEINA, 2)
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
                        x1hoja.Cells(fila, columna).formula = FormatNumber(c.LACTOSA, 2)
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                    End If

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
            x1hoja.Cells(fila, columna).Formula = "Rc"
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
            x1hoja.Cells(fila, columna).Formula = "MUN*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = columna + 1
            x1hoja.Cells(fila, columna).Formula = "Cas*"
            x1hoja.Cells(fila, columna).Font.Bold = True
            x1hoja.Cells(fila, columna).Font.Size = 8
            x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            columna = 9
            fila = fila + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("I17", "I18").Merge()
            x1hoja.Range("I17", "I18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("I17", "I18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("I17", "I18").WrapText = True
            x1hoja.Cells(fila, columna).formula = ""
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("J17", "J18").Merge()
            x1hoja.Range("J17", "J18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("J17", "J18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("J17", "J18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "x 1.000 cel/mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("K17", "K18").Merge()
            x1hoja.Range("K17", "K18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("K17", "K18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("K17", "K18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("L17", "L18").Merge()
            x1hoja.Range("L17", "L18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("L17", "L18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("L17", "L18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("M17", "M18").Merge()
            x1hoja.Range("M17", "M18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("M17", "M18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("M17", "M18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("N17", "N18").Merge()
            x1hoja.Range("N17", "N18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("N17", "N18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("N17", "N18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "mg/dl"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = columna + 1
            x1hoja.Cells(1, 1).RowHeight = 18
            x1hoja.Range("O17", "O18").Merge()
            x1hoja.Range("O17", "O18").Borders.Color = RGB(0, 0, 0)
            x1hoja.Range("O17", "O18").Interior.Color = RGB(192, 192, 192)
            x1hoja.Range("O17", "O18").WrapText = True
            x1hoja.Cells(fila, columna).formula = "g/100mL"
            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
            x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
            x1hoja.Cells(fila, columna).Font.Size = 6
            columna = 9
            fila = fila + 2
            If Not lista2 Is Nothing Then
                If lista2.Count > 0 Then
                    Dim cs As New dControlSolicitud
                    cs.FICHA = idsol
                    cs = cs.buscar
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
                            If c.RC < 30 Then
                                x1hoja.Cells(fila, columna).formula = "30"
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
                        'If c.RC < 150 Then
                        '    libreinfeccion = libreinfeccion + 1
                        'ElseIf c.RC >= 150 And c.RC < 400 Then
                        '    posibleinfeccion = posibleinfeccion + 1
                        'ElseIf c.RC >= 400 Then
                        '    probableinfeccion = probableinfeccion + 1
                        'End If
                        If c.RC <= 200 Then
                            libreinfeccion = libreinfeccion + 1
                            'ElseIf c.RC >= 150 And c.RC < 400 Then
                            'posibleinfeccion = posibleinfeccion + 1
                        ElseIf c.RC > 200 Then
                            probableinfeccion = probableinfeccion + 1
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
                            If valgrasa < 2.5 Or valgrasa > 5 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.GRASA, 2)
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
                            If valproteina < 2.5 Or valproteina > 4 Then
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                            End If
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.PROTEINA, 2)
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
                            x1hoja.Cells(fila, columna).formula = FormatNumber(c.LACTOSA, 2)
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                        End If
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
                        columna = 9
                        fila = fila + 1
                    Next
                    'Referencias
                    fila = fila + 1
                    columna = 1
                End If


                '*** CALCULO PRECIO (NUEVO) ***************************************************************************************************************
                'Dim sa As New dSolicitudAnalisis

                Dim ti As Integer = 0
                Dim sti As Integer = 0
                Dim ficha As Long = 0
                Dim muestrastotales As Integer = 0
                ficha = idsol
                sa.ID = idsol
                sa = sa.buscar
                If Not sa Is Nothing Then
                    ti = sa.IDTIPOINFORME
                    sti = sa.IDSUBINFORME
                    'muestras = sa.NMUESTRAS
                End If

                Dim listamuestras As New ArrayList
                listamuestras = c.listarporsolicitud(idsol)
                muestrastotales = listamuestras.Count
                Dim minimomuestras As Integer = 0

                '*** CUENTA MUESTRAS NO APTAS ***************************************
                Dim mna As New dMuestrasNoAptas
                Dim cuenta_mna As Integer = 0
                Dim cuenta_rep As Integer = 0
                Dim faltan As Integer = 0
                lista3 = mna.listarporficha(idsol)
                If Not lista3 Is Nothing Then
                    If lista3.Count > 0 Then
                        For Each mna In lista3
                            If mna.MOTIVO = 8 Then
                                cuenta_rep = cuenta_rep + mna.CANTIDAD
                            End If
                            If mna.MOTIVO = 4 Or mna.MOTIVO = 6 Or mna.MOTIVO = 10 Then
                                faltan = faltan + mna.CANTIDAD
                            End If
                            If mna.MOTIVO = 1 Or mna.MOTIVO = 2 Or mna.MOTIVO = 3 Or mna.MOTIVO = 5 Or mna.MOTIVO = 7 Or mna.MOTIVO = 9 Then
                                cuenta_mna = cuenta_mna + mna.CANTIDAD
                            End If
                        Next
                    End If
                End If
                Dim muestrasanalizadas As Integer = 0
                muestrasanalizadas = muestrastotales - cuenta_mna
                muestrasanalizadas = muestrasanalizadas - faltan
                '********************************************************************

                Dim total1 As Double = 0
                Dim total2 As Double = 0
                Dim total3 As Double = 0
                Dim total4 As Double = 0
                Dim total As Double = 0
                Dim lp As New dListaPrecios

                Dim idrc_comp As Integer = 116
                Dim idrc_comp_urea As Integer = 117
                Dim idrc_comp_caseina As Integer = 157
                Dim idrc_comp_urea_caseina As Integer = 158
                Dim id_noprocesadas As Integer = 224
                Dim idtimbre As Integer = 86

                Dim preciorc_comp As Double
                Dim preciorc_comp_urea As Double
                Dim preciorc_comp_caseina As Double
                Dim preciorc_comp_urea_caseina As Double
                Dim precio_noprocesadas As Double
                Dim preciotimbre As Double

                Dim cli As New dCliente
                Dim precio As Integer = 0
                cli.ID = sa.IDPRODUCTOR
                cli = cli.buscar
                If Not cli Is Nothing Then
                    precio = cli.FAC_LISTA
                End If

                If precio = 1 Then
                    lp.ID = idrc_comp
                    lp = lp.buscar
                    preciorc_comp = lp.PRECIO1
                    lp.ID = idrc_comp_urea
                    lp = lp.buscar
                    preciorc_comp_urea = lp.PRECIO1
                    lp.ID = idrc_comp_caseina
                    lp = lp.buscar
                    preciorc_comp_caseina = lp.PRECIO1
                    lp.ID = idrc_comp_urea_caseina
                    lp = lp.buscar
                    preciorc_comp_urea_caseina = lp.PRECIO1
                ElseIf precio = 2 Then
                    lp.ID = idrc_comp
                    lp = lp.buscar
                    preciorc_comp = lp.PRECIO2
                    If lp.PRECIO2 = 0 Then
                        preciorc_comp = lp.PRECIO1
                    End If
                    lp.ID = idrc_comp_urea
                    lp = lp.buscar
                    preciorc_comp_urea = lp.PRECIO2
                    If lp.PRECIO2 = 0 Then
                        preciorc_comp_urea = lp.PRECIO1
                    End If
                    lp.ID = idrc_comp_caseina
                    lp = lp.buscar
                    preciorc_comp_caseina = lp.PRECIO2
                    If lp.PRECIO2 = 0 Then
                        preciorc_comp_caseina = lp.PRECIO1
                    End If
                    lp.ID = idrc_comp_urea_caseina
                    lp = lp.buscar
                    preciorc_comp_urea_caseina = lp.PRECIO2
                    If lp.PRECIO2 = 0 Then
                        preciorc_comp_urea_caseina = lp.PRECIO1
                    End If
                ElseIf precio = 3 Then
                    lp.ID = idrc_comp
                    lp = lp.buscar
                    preciorc_comp = lp.PRECIO3
                    If lp.PRECIO3 = 0 Then
                        preciorc_comp = lp.PRECIO1
                    End If
                    lp.ID = idrc_comp_urea
                    lp = lp.buscar
                    preciorc_comp_urea = lp.PRECIO3
                    If lp.PRECIO3 = 0 Then
                        preciorc_comp_urea = lp.PRECIO1
                    End If
                    lp.ID = idrc_comp_caseina
                    lp = lp.buscar
                    preciorc_comp_caseina = lp.PRECIO3
                    If lp.PRECIO3 = 0 Then
                        preciorc_comp_caseina = lp.PRECIO1
                    End If
                    lp.ID = idrc_comp_urea_caseina
                    lp = lp.buscar
                    preciorc_comp_urea_caseina = lp.PRECIO3
                    If lp.PRECIO3 = 0 Then
                        preciorc_comp_urea_caseina = lp.PRECIO1
                    End If
                ElseIf precio = 4 Then
                    lp.ID = idrc_comp
                    lp = lp.buscar
                    preciorc_comp = lp.PRECIO4
                    lp.ID = idrc_comp_urea
                    lp = lp.buscar
                    preciorc_comp_urea = lp.PRECIO4
                    lp.ID = idrc_comp_caseina
                    lp = lp.buscar
                    preciorc_comp_caseina = lp.PRECIO4
                    lp.ID = idrc_comp_urea_caseina
                    lp = lp.buscar
                    preciorc_comp_urea_caseina = lp.PRECIO4
                ElseIf precio = 5 Then
                    lp.ID = idrc_comp
                    lp = lp.buscar
                    preciorc_comp = lp.PRECIO5
                    lp.ID = idrc_comp_urea
                    lp = lp.buscar
                    preciorc_comp_urea = lp.PRECIO5
                    lp.ID = idrc_comp_caseina
                    lp = lp.buscar
                    preciorc_comp_caseina = lp.PRECIO5
                    lp.ID = idrc_comp_urea_caseina
                    lp = lp.buscar
                    preciorc_comp_urea_caseina = lp.PRECIO5
                ElseIf precio = 6 Then
                    lp.ID = idrc_comp
                    lp = lp.buscar
                    preciorc_comp = lp.PRECIO6
                    lp.ID = idrc_comp_urea
                    lp = lp.buscar
                    preciorc_comp_urea = lp.PRECIO6
                    lp.ID = idrc_comp_caseina
                    lp = lp.buscar
                    preciorc_comp_caseina = lp.PRECIO6
                    lp.ID = idrc_comp_urea_caseina
                    lp = lp.buscar
                    preciorc_comp_urea_caseina = lp.PRECIO6
                ElseIf precio = 7 Then
                    lp.ID = idrc_comp
                    lp = lp.buscar
                    preciorc_comp = lp.PRECIO7
                    lp.ID = idrc_comp_urea
                    lp = lp.buscar
                    preciorc_comp_urea = lp.PRECIO7
                    lp.ID = idrc_comp_caseina
                    lp = lp.buscar
                    preciorc_comp_caseina = lp.PRECIO7
                    lp.ID = idrc_comp_urea_caseina
                    lp = lp.buscar
                    preciorc_comp_urea_caseina = lp.PRECIO7
                End If

                lp.ID = id_noprocesadas
                lp = lp.buscar
                precio_noprocesadas = lp.PRECIO1

                lp.ID = idtimbre
                lp = lp.buscar
                preciotimbre = lp.PRECIO1

                If muestrasanalizadas > 0 And muestrasanalizadas < 20 Then
                    muestrasanalizadas = 20
                End If

                Dim subtipo As Integer
                subtipo = sti

                If subtipo = 1 Then
                    total1 = muestrasanalizadas * preciorc_comp
                ElseIf subtipo = 32 Then
                    total2 = muestrasanalizadas * preciorc_comp_urea
                ElseIf subtipo = 53 Then
                    total3 = muestrasanalizadas * preciorc_comp_caseina
                ElseIf subtipo = 54 Then
                    total4 = muestrasanalizadas * preciorc_comp_urea_caseina
                End If


                Dim analisis As Integer = 0
                Dim precio1 As Double = 0
                Dim precio2 As Double = 0
                Dim precio3 As Double = 0
                Dim precio4 As Double = 0


                Dim subtotal As Double = 0


                If sti = 1 Then
                    analisis = 116
                    precio1 = preciorc_comp
                    Dim f1 As New dFacturacion
                    f1.FICHA = ficha
                    f1.CANTIDAD = muestrasanalizadas
                    f1.ANALISIS = analisis
                    f1.PRECIO = precio1
                    f1.SUBTOTAL = total1
                    f1.FACTURA = 0
                    'f1.guardar(Usuario)
                    total = total + total1
                    f1 = Nothing
                ElseIf sti = 32 Then
                    analisis = 117
                    precio2 = preciorc_comp_urea
                    Dim f2 As New dFacturacion
                    f2.FICHA = ficha
                    f2.CANTIDAD = muestrasanalizadas
                    f2.ANALISIS = analisis
                    f2.PRECIO = precio2
                    f2.SUBTOTAL = total2
                    f2.FACTURA = 0
                    'f2.guardar(Usuario)
                    total = total + total2
                    f2 = Nothing
                ElseIf sti = 53 Then
                    analisis = 157
                    precio3 = preciorc_comp_caseina
                    Dim f3 As New dFacturacion
                    f3.FICHA = ficha
                    f3.CANTIDAD = muestrasanalizadas
                    f3.ANALISIS = analisis
                    f3.PRECIO = precio3
                    f3.SUBTOTAL = total3
                    f3.FACTURA = 0
                    'f3.guardar(Usuario)
                    total = total + total3
                    f3 = Nothing
                ElseIf sti = 54 Then
                    analisis = 158
                    precio4 = preciorc_comp_urea_caseina
                    Dim f4 As New dFacturacion
                    f4.FICHA = ficha
                    f4.CANTIDAD = muestrasanalizadas
                    f4.ANALISIS = analisis
                    f4.PRECIO = precio4
                    f4.SUBTOTAL = total4
                    f4.FACTURA = 0
                    'f4.guardar(Usuario)
                    total = total + total4
                    f4 = Nothing
                End If
                If cuenta_mna > 0 Then
                    MsgBox("Hay muestras no aptas para hacer Nota de Crédito!")
                    If sti = 1 Then
                        'analisis = 116
                        analisis = 224
                        'precio1 = preciorc_comp * 0.5
                        precio1 = precio_noprocesadas
                        Dim f1 As New dFacturacion
                        f1.FICHA = ficha
                        f1.CANTIDAD = cuenta_mna
                        f1.ANALISIS = analisis
                        f1.PRECIO = precio1
                        f1.SUBTOTAL = cuenta_mna * precio1
                        f1.FACTURA = 0
                        f1.guardar(Usuario)
                        total = total + f1.SUBTOTAL
                        f1 = Nothing
                    ElseIf sti = 32 Then
                        'analisis = 117
                        analisis = 224
                        'precio2 = preciorc_comp_urea * 0.5
                        precio2 = precio_noprocesadas
                        Dim f2 As New dFacturacion
                        f2.FICHA = ficha
                        f2.CANTIDAD = cuenta_mna
                        f2.ANALISIS = analisis
                        f2.PRECIO = precio2
                        f2.SUBTOTAL = cuenta_mna * precio2
                        f2.FACTURA = 0
                        f2.guardar(Usuario)
                        total = total + f2.SUBTOTAL
                        f2 = Nothing
                    ElseIf sti = 53 Then
                        'analisis = 157
                        analisis = 224
                        'precio3 = preciorc_comp_caseina * 0.5
                        precio3 = precio_noprocesadas
                        Dim f3 As New dFacturacion
                        f3.FICHA = ficha
                        f3.CANTIDAD = cuenta_mna
                        f3.ANALISIS = analisis
                        f3.PRECIO = precio3
                        f3.SUBTOTAL = cuenta_mna * precio3
                        f3.FACTURA = 0
                        f3.guardar(Usuario)
                        total = total + f3.SUBTOTAL
                        f3 = Nothing
                    ElseIf sti = 54 Then
                        'analisis = 158
                        analisis = 224
                        'precio4 = preciorc_comp_urea_caseina * 0.5
                        precio4 = precio_noprocesadas
                        Dim f4 As New dFacturacion
                        f4.FICHA = ficha
                        f4.CANTIDAD = cuenta_mna
                        f4.ANALISIS = analisis
                        f4.PRECIO = precio4
                        f4.SUBTOTAL = cuenta_mna * precio4
                        f4.FACTURA = 0
                        f4.guardar(Usuario)
                        total = total + f4.SUBTOTAL
                        f4 = Nothing
                    End If
                End If
                total = total + preciotimbre
                '*** FIN CALCULO PRECIO (NUEVO)***********************************************************************************************************************************

                '/* Actualiza el importe en la solicitud 
                Dim saimp As New dSolicitudAnalisis
                Dim importesa As Double = total
                saimp.ID = idsol
                saimp.actualizarimporte(importesa)
                '***************************************/

                columna = 1
                fila = fila + 3

                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).formula = "Observaciones:"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    fila = fila + 1
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

                x1hoja.Cells(fila, columna).formula = "Total de muestras procesadas:" & " " & muestrastotales
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = ""
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                columna = columna + 1
                x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2.5 o >4 Proteína <2.5 o >5 Grasa)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = 1
                fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & Math.Round(total, 0)
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = "La indicación ''Fuera de rango''. está fuera del alcance de la acreditación"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 6
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
                columna = 1

                'fila = fila - 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                Dim rangeFirma As String = "A" + fila.ToString
                x1libro.ActiveSheet.Range(rangeFirma).select()
                InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
                x1libro.Worksheets(1).cells(2, 1).select()
                'fila = fila + 5

                columna = columna + 6
                x1hoja.Cells(fila, columna).formula = "Interpretación de recuento celular"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna - 5
                fila = fila + 1

                Dim vallibreinfeccion As Integer = 0
                Dim valposibleinfeccion As Integer = 0
                Dim valprobableinfeccion As Integer = 0
                Dim sumavalores As Integer = 0
                Dim diferenciavalores As Integer = 0

                vallibreinfeccion = (libreinfeccion / muestrastotales) * 100
                valposibleinfeccion = (posibleinfeccion / muestrastotales) * 100
                valprobableinfeccion = (probableinfeccion / muestrastotales) * 100

                sumavalores = vallibreinfeccion + valposibleinfeccion + valprobableinfeccion
                diferenciavalores = sumavalores - 100
                If diferenciavalores < 0 Then
                    diferenciavalores = diferenciavalores * -1
                End If
                If sumavalores > 100 Then
                    vallibreinfeccion = vallibreinfeccion - diferenciavalores
                ElseIf sumavalores < 100 Then
                    vallibreinfeccion = vallibreinfeccion + diferenciavalores
                End If



                'x1hoja.Cells(fila, columna).formula = "<150: probablemente libre de infección:" & " " & libreinfeccion & " " & "(" & Math.Round(vallibreinfeccion, 0) & " %" & ")"
                x1hoja.Cells(fila, columna).formula = "<=200: vacas sanas:" & " " & libreinfeccion & " " & "(" & Math.Round(vallibreinfeccion, 0) & " %" & ")"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna - 5
                fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "150-400: posiblemente infectadas:" & " " & posibleinfeccion & " " & "(" & Math.Round(valposibleinfeccion, 0) & " %" & ")"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna + 1
                'x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                'columna = columna - 5
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = ">200: vacas infectadas:" & " " & probableinfeccion & " " & "(" & Math.Round(valprobableinfeccion, 0) & " %" & ")"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna - 5
                fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "R.Blowey & P. Edmonson, (1995)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                columna = columna + 1
                x1hoja.Cells(fila, columna).interior.color = RGB(0, 255, 255)
                fila = fila + 1
                columna = 7
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).formula = "Valores de 30 en RC, corresponden a <=30 (menor o igual)"
                '** SI HAY MUESTRAS NO APTAS ***************************************
                If cuenta_mna > 0 Or cuenta_rep > 0 Then
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).formula = "(**) No apta por:"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                    columna = 1
                    fila = fila + 1
                    Dim muestrasna As New dMuestrasNoAptas
                    Dim muestrana As New dMuestraNoApta
                    Dim motivomna As Integer = 0
                    Dim cantidadmna As Integer = 0
                    lista3 = muestrasna.listarporficha(idsol)
                    If Not lista3 Is Nothing Then
                        If lista3.Count > 0 Then
                            For Each muestrasna In lista3
                                motivomna = muestrasna.MOTIVO
                                muestrana.ID = motivomna
                                muestrana = muestrana.buscar()
                                x1hoja.Cells(fila, columna).formula = muestrana.NOMBRE
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = columna + 1
                                cantidadmna = muestrasna.CANTIDAD
                                x1hoja.Cells(fila, columna).formula = cantidadmna
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).interior.color = RGB(192, 192, 192)
                                columna = 1
                                fila = fila + 1
                            Next
                        End If
                    End If
                    x1hoja.Cells(fila, columna).formula = "Muestras no aptas = 50% importe del análisis"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    x1hoja.Cells(fila, columna).Font.Bold = True
                End If



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
        End If



        'GRAFICAS*******************************************************************
        'fila = fila + 2
        'columna = 1
        'x1libro.Worksheets(1).cells(fila, columna).select()
        'x1libro.ActiveSheet.pictures.Insert("\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\" & idsol & "_RC.jpg").select()
        'x1libro.Worksheets(1).cells(2, 1).select()

        '***************************************************************************
        fila = fila + 1
        x1hoja.Range("A" & fila, "O" & fila).Merge()
        x1hoja.Cells(fila, columna).Interior.Color = RGB(215, 219, 221)
        x1hoja.Cells(fila, columna).rowheight = 8
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignCenter
        x1hoja.Cells(fila, columna).Formula = "Fin del informe."
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7

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
            pi2.TIPO = 1
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing

        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        'x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        ' x1hoja.SaveAs("\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idsol & ".xls")
        Try
            x1hoja.SaveAs("\\ROBOT\PREINFORMES\CONTROL\" & idsol & ".xls")
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
    End Sub

    Private Sub creainformetxt()
        Dim idficha As Long = TextFicha.Text.Trim
        'Dim oSW As New StreamWriter("\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt")
        Dim oSW As New StreamWriter("\\ROBOT\PREINFORMES\CONTROL\" & idficha & ".txt")
        Dim c As New dControl
        Dim lista4 As New ArrayList
        lista4 = c.listarporsolicitud(idficha)
        Dim secuencial As Integer = 1

        If Not lista4 Is Nothing Then
            If lista4.Count > 0 Then
                Dim cs As New dControlSolicitud
                cs.FICHA = idficha
                cs = cs.buscar
                Dim Linea As String = ""

                For Each c In lista4
                    Linea = Linea & secuencial & Chr(9)
                    If c.MUESTRA <> "" Then
                        Linea = Linea & c.MUESTRA + Chr(9)
                    Else
                        Linea = Linea & "-" & Chr(9)
                    End If
                    If c.GRASA = -1 Or c.GRASA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Dim valgrasa = Val(c.GRASA)
                        Linea = Linea & valgrasa & Chr(9)
                    End If
                    If c.PROTEINA = -1 Or c.PROTEINA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Dim valproteina = Val(c.PROTEINA)
                        Linea = Linea & valproteina & Chr(9)
                    End If
                    If c.LACTOSA = -1 Or c.LACTOSA = 0 Then
                        Linea = Linea & "-" & Chr(9)
                    Else
                        Linea = Linea & c.LACTOSA & Chr(9)
                    End If
                    'If cs.UREA = 1 Then
                    'If c.UREA = -1 Or c.UREA = 0 Then
                    'Linea = Linea & vbNewLine
                    'Else
                    'Dim valorurea As Integer
                    'valorurea = c.UREA * 0.466
                    'Linea = Linea & valorurea & vbNewLine
                    'End If
                    'Else
                    'Linea = Linea & vbNewLine
                    'End If
                    Linea = Linea & "0" & Chr(9)
                    If c.RC = -1 Then
                        Linea = Linea & "-" '& vbNewLine
                    Else
                        If c.GRASA = -1 Or c.GRASA = 0 Then
                            Linea = Linea & "-" & Chr(9)
                        Else
                            'If c.RC < 4 Then
                            '    Linea = Linea & "4" ' & vbNewLine
                            If c.RC < 30 Then
                                Linea = Linea & "30"
                            Else
                                Linea = Linea & c.RC ' & vbNewLine
                            End If
                        End If
                    End If
                    oSW.WriteLine(Linea)
                    Linea = ""
                    secuencial = secuencial + 1
                Next
            End If
        End If

        Dim sa2 As New dSolicitudAnalisis
        sa2.ID = idficha
        sa2.NMUESTRAS = secuencial - 1
        sa2.actualizar_cantidad_muestras(Usuario)
        oSW.Flush()
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        If ListFichas.SelectedItems.Count = 1 Then
            Dim s As dSolicitudAnalisis = CType(ListFichas.SelectedItem, dSolicitudAnalisis)
            TextFicha.Text = s.ID
        End If
    End Sub
    Private Sub abrirventanaenvio()
        Dim v As New FormSubirInformes(Usuario)
        v.ShowDialog()
    End Sub
End Class