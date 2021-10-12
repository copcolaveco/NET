Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormInformeCalidadLeche2
    Private _usuario As dUsuario
    Private contador_rc As Integer = 0
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
        abrirventanaenvio()
        limpiar()
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        listarfichas()
    End Sub
    Private Sub abrirventanaenvio()
        Dim v As New FormSubirInformes2(Usuario)
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

        Dim idsol As Long = TextFicha.Text.Trim
        Dim Arch As String
        'Arch = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CALIDAD\" & idsol & ".xls"
        Arch = "\\ROBOT\PRE INFORMES\CALIDAD\" & idsol & ".xls"

        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet

        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Open(Arch), Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)



        'Dim c As New dCalidad
        Dim csm As New dCalidadSolicitudMuestra

        Dim i As New dIbc
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        contador_rc = 0
        '*****************************

        sa.ID = idsol
        sa = sa.buscar
        '*****************************
        sa.marcar(Usuario)

        '*****************************
        Dim fila As Integer
        Dim columna As Integer
        'fila = 17
        'columna = 1
        'ListAntibiogramas.Items.Clear()
        fila = 1
        columna = 2

        'Poner Titulos
        x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
         Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)

        '******************************************************************
        'x1libro.Worksheets(1).cells(1, 1).select()
        'x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
        'x1libro.Worksheets(1).cells(1, 1).select()
        '******************************************************************

        x1hoja.Shapes.AddPicture("c:\Debug\oua.jpg", _
         Microsoft.Office.Core.MsoTriState.msoFalse, _
        Microsoft.Office.Core.MsoTriState.msoCTrue, 220, 145, 80, 35)


        x1hoja.Cells(1, 1).columnwidth = 7
        x1hoja.Cells(1, 2).columnwidth = 5
        x1hoja.Cells(1, 3).columnwidth = 5
        x1hoja.Cells(1, 4).columnwidth = 5
        x1hoja.Cells(1, 5).columnwidth = 5
        x1hoja.Cells(1, 6).columnwidth = 5
        x1hoja.Cells(1, 7).columnwidth = 5
        x1hoja.Cells(1, 8).columnwidth = 5
        x1hoja.Cells(1, 9).columnwidth = 5
        x1hoja.Cells(1, 10).columnwidth = 5
        x1hoja.Cells(1, 11).columnwidth = 8
        x1hoja.Cells(1, 12).columnwidth = 6
        x1hoja.Cells(1, 13).columnwidth = 8
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
        x1hoja.Range("H8", "M11").Merge()
        x1hoja.Range("H8", "M11").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("H8", "M11").WrapText = True
        x1hoja.Cells(fila, columna).formula = "R. Celular*(ISO13366-2:2006); Grasa*, Proteína*, Lactosa (IDF141C:2000), Crioscopía, Urea, Citrato, Caseína (Boletín FIL 393/2003); Sólidos totales* (Boletín FIL 208/1987): Método IR; R. Bacteriano: Método IBC (citometría de flujo); Inhibidores: Método Delvo Test (PE.LAB.17); Psicrótrofos: Téc. rápida en placa (ISO 8552/FIL 132:2004 mod.); Esporulados Anaerobios: NMP (INTI Lácteos mod)."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
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
        x1hoja.Cells(fila, columna).Formula = "Fecha emisión:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        x1hoja.Range("C11", "D11").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(fila, columna).formula = fecha2
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        fila = fila + 1
        columna = 1
        x1hoja.Cells(fila, columna).Formula = "Paratécnico:"
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 7
        columna = columna + 2
        Dim paratecnico As String = ""
        If idparatecnico1 = 1 Then
            paratecnico = paratecnico + "Diego Arenas - "
        End If
        If idparatecnico2 = 1 Then
            paratecnico = paratecnico + "Lorena Nidegger - "
        End If
        If idparatecnico3 = 1 Then
            paratecnico = paratecnico + "Claudia García - "
        End If
        If idparatecnico4 = 1 Then
            paratecnico = paratecnico + "Erika Silva - "
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
        columna = columna + 4
        x1hoja.Range("K13", "M13").Merge()
        x1hoja.Range("K13", "M13").Borders.Color = RGB(0, 0, 0)
        x1hoja.Range("K13", "M13").WrapText = True
        x1hoja.Cells(fila, columna).formula = "* Ensayos acreditados ISO 17.025 por O.U.A."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 6

        'x1hoja.Range("H8", "M13").Border.Color = RGB(255, 0, 0)
        'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)

        'lista = c.listarporsolicitud(idsol)
        lista = csm.listarporsolicitud(idsol)


        fila = lista.Count + 19


        '******* CALCULO PRECIO ************************************************************************

        Dim listamuestras As New ArrayList
        listamuestras = csm.listarporsolicitud(idsol)
        Dim total As Double
        Dim ana As New dAnalisis

        Dim idtimbre As Integer = 86
        Dim idrb As Integer = 1
        Dim idrc As Integer = 2
        Dim idcomposicion As Integer = 3
        Dim idinhibidores As Integer = 5
        Dim idurea As Integer = 60
        Dim idcrioscopia As Integer = 4
        Dim idesporulados As Integer = 8
        Dim idpsicrotrofos As Integer = 61
        Dim idtermofilos As Integer = 62
        Dim idbact_cel_comp As Integer = 100
        Dim idbact_cel As Integer = 101
        Dim idcrioscopia_crioscopo As Integer = 102
        Dim idcaseina As Integer = 118
        Dim idCalcar_composicion_crioscopia As Integer = 103
        Dim idCalcar_RC As Integer = 104
        Dim idCalcar_RB As Integer = 105
        Dim idEcolat_composicion As Integer = 106
        Dim idEcolat_RC As Integer = 107
        Dim idEcolat_RB As Integer = 108
        Dim idIndulacsaC_composicion As Integer = 109
        Dim idIndulacsaC_RC As Integer = 110
        Dim idIndulacsaC_RB As Integer = 111
        Dim idIndulacsaS_composicion As Integer = 112
        Dim idIndulacsaS_RC As Integer = 113
        Dim idIndulacsaS_RB As Integer = 114
        Dim idIndulacsaS_inhibidores As Integer = 115

        Dim preciotimbre As Double
        Dim preciorb As Double
        Dim preciorc As Double
        Dim preciocomposicion As Double
        Dim precioinhibidores As Double
        Dim preciourea As Double
        Dim preciocrioscopia As Double
        Dim precioesporulados As Double
        Dim preciopsicrotrofos As Double
        Dim preciotermofilos As Double
        Dim preciobact_cel_comp As Double
        Dim preciobact_cel As Double
        Dim preciocrioscopia_crioscopo As Double
        Dim preciocaseina As Double
        Dim precioCalcar_composicion_crioscopia As Double
        Dim precioCalcar_RC As Double
        Dim precioCalcar_RB As Double
        Dim precioEcolat_composicion As Double
        Dim precioEcolat_RC As Double
        Dim precioEcolat_RB As Double
        Dim precioIndulacsaC_composicion As Double
        Dim precioIndulacsaC_RC As Double
        Dim precioIndulacsaC_RB As Double
        Dim precioIndulacsaS_composicion As Double
        Dim precioIndulacsaS_RC As Double
        Dim precioIndulacsaS_RB As Double
        Dim precioIndulacsaS_inhibidores As Double


        If sa.IDPRODUCTOR = 219 Then
            ana.ID = idCalcar_composicion_crioscopia
            ana = ana.buscar
            precioCalcar_composicion_crioscopia = ana.COSTO

            ana.ID = idCalcar_RC
            ana = ana.buscar
            precioCalcar_RC = ana.COSTO

            ana.ID = idCalcar_RB
            ana = ana.buscar
            precioCalcar_RB = ana.COSTO
        End If
        If sa.IDPRODUCTOR = 143 Then
            ana.ID = idEcolat_composicion
            ana = ana.buscar
            precioEcolat_composicion = ana.COSTO

            ana.ID = idEcolat_RC
            ana = ana.buscar
            precioEcolat_RC = ana.COSTO

            ana.ID = idEcolat_RB
            ana = ana.buscar
            precioEcolat_RB = ana.COSTO
        End If
        If sa.IDPRODUCTOR = 150 Then
            ana.ID = idIndulacsaC_composicion
            ana = ana.buscar
            precioIndulacsaC_composicion = ana.COSTO

            ana.ID = idIndulacsaC_RC
            ana = ana.buscar
            precioIndulacsaC_RC = ana.COSTO

            ana.ID = idIndulacsaC_RB
            ana = ana.buscar
            precioIndulacsaC_RB = ana.COSTO
        End If
        If sa.IDPRODUCTOR = 2705 Then
            ana.ID = idIndulacsaS_composicion
            ana = ana.buscar
            precioIndulacsaS_composicion = ana.COSTO

            ana.ID = idIndulacsaS_RC
            ana = ana.buscar
            precioIndulacsaS_RC = ana.COSTO

            ana.ID = idIndulacsaS_RB
            ana = ana.buscar
            precioIndulacsaS_RB = ana.COSTO

            ana.ID = idIndulacsaS_inhibidores
            ana = ana.buscar
            precioIndulacsaS_inhibidores = ana.COSTO
        End If

        ana.ID = idtimbre
        ana = ana.buscar
        preciotimbre = ana.COSTO

        ana.ID = idrb
        ana = ana.buscar
        preciorb = ana.COSTO

        ana.ID = idrc
        ana = ana.buscar
        preciorc = ana.COSTO

        ana.ID = idcomposicion
        ana = ana.buscar
        preciocomposicion = ana.COSTO

        ana.ID = idinhibidores
        ana = ana.buscar
        precioinhibidores = ana.COSTO

        ana.ID = idurea
        ana = ana.buscar
        preciourea = ana.COSTO

        ana.ID = idcrioscopia
        ana = ana.buscar
        preciocrioscopia = ana.COSTO

        ana.ID = idesporulados
        ana = ana.buscar
        precioesporulados = ana.COSTO

        ana.ID = idpsicrotrofos
        ana = ana.buscar
        preciopsicrotrofos = ana.COSTO

        ana.ID = idtermofilos
        ana = ana.buscar
        preciotermofilos = ana.COSTO

        ana.ID = idbact_cel_comp
        ana = ana.buscar
        preciobact_cel_comp = ana.COSTO

        ana.ID = idbact_cel
        ana = ana.buscar
        preciobact_cel = ana.COSTO

        ana.ID = idcrioscopia_crioscopo
        ana = ana.buscar
        preciocrioscopia_crioscopo = ana.COSTO

        ana.ID = idcaseina
        ana = ana.buscar
        preciocaseina = ana.COSTO

        Dim muestras As Integer
        muestras = listamuestras.Count

        Dim cuentarb As Integer = 0
        Dim cuentarb2 As Integer = 0
        Dim cuentarc As Integer = 0
        Dim cuentarc2 As Integer = 0
        Dim cuentacomposicion As Integer = 0
        Dim cuentacrioscopia As Integer = 0
        Dim cuentainhibidores As Integer = 0
        Dim cuentaesporulados As Integer = 0
        Dim cuentaurea As Integer = 0
        Dim cuentatermofilos As Integer = 0
        Dim cuentapsicrotrofos As Integer = 0
        Dim cuentacrioscopia_crioscopo As Integer = 0
        Dim cuentacaseina As Integer = 0
        Dim cuentarb_rc As Integer = 0
        Dim cuentarb_rc2 As Integer = 0
        Dim cuentarb_rc_composicion = 0

        'Dim csm As New dCalidadSolicitudMuestra
        Dim listam As New ArrayList
        listam = csm.listarrb(idsol)
        If Not listam Is Nothing Then
            cuentarb = listam.Count
            cuentarb2 = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrc(idsol)
        If Not listam Is Nothing Then
            cuentarc = listam.Count
            cuentarc2 = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcomposicion(idsol)
        If Not listam Is Nothing Then
            cuentacomposicion = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcrioscopia(idsol)
        If Not listam Is Nothing Then
            cuentacrioscopia = listam.Count
        End If
        listam = Nothing
        listam = csm.listarinhibidores(idsol)
        If Not listam Is Nothing Then
            cuentainhibidores = listam.Count
        End If
        listam = Nothing
        listam = csm.listaresporulados(idsol)
        If Not listam Is Nothing Then
            cuentaesporulados = listam.Count
        End If
        listam = Nothing
        listam = csm.listarurea(idsol)
        If Not listam Is Nothing Then
            cuentaurea = listam.Count
        End If
        listam = Nothing
        listam = csm.listartermofilos(idsol)
        If Not listam Is Nothing Then
            cuentatermofilos = listam.Count
        End If
        listam = Nothing
        listam = csm.listarpsicrotrofos(idsol)
        If Not listam Is Nothing Then
            cuentapsicrotrofos = listam.Count
        End If
        listam = Nothing
        listam = csm.listarcrioscopia_crioscopo(idsol)
        If Not listam Is Nothing Then
            cuentacrioscopia_crioscopo = listam.Count
        End If
        listam = Nothing
        listam = csm.listar_caseina(idsol)
        If Not listam Is Nothing Then
            cuentacaseina = listam.Count
        End If
        listam = Nothing
        listam = csm.listarrb_rc(idsol)
        If sa.IDPRODUCTOR = 219 Or sa.IDPRODUCTOR = 143 Or sa.IDPRODUCTOR = 150 Or sa.IDPRODUCTOR = 2705 Then

        Else
            If Not listam Is Nothing Then
                cuentarb_rc = listam.Count

            End If
            listam = Nothing
            listam = csm.listarrb_rc_composicion(idsol)
            If Not listam Is Nothing Then

                cuentarb_rc_composicion = listam.Count


                If cuentarb_rc > cuentarb_rc_composicion Then

                Else
                    cuentarb_rc = 0
                End If

            End If
            listam = Nothing
        End If

        If sa.IDPRODUCTOR = 219 Then
            If cuentarb > 0 Then
                total = total + (cuentarb * precioCalcar_RB)
            End If
            If cuentarc > 0 Then
                total = total + (cuentarc * precioCalcar_RC)
            End If
            If cuentacomposicion > 0 And cuentacrioscopia > 0 Then
                total = total + (cuentacomposicion * precioCalcar_composicion_crioscopia)
            End If
            If cuentainhibidores > 0 Then
                total = total + (cuentainhibidores * precioinhibidores)
            End If
            If cuentaesporulados > 0 Then
                total = total + (cuentaesporulados * precioesporulados)
            End If
            If cuentaurea > 0 Then
                total = total + (cuentaurea * preciourea)
            End If
            If cuentatermofilos > 0 Then
                total = total + (cuentatermofilos * preciotermofilos)
            End If
            If cuentapsicrotrofos > 0 Then
                total = total + (cuentapsicrotrofos * preciopsicrotrofos)
            End If
            If cuentacrioscopia_crioscopo > 0 Then
                total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
            End If
            If cuentacaseina > 0 Then
                total = total + (cuentacaseina * preciocaseina)
            End If

        ElseIf sa.IDPRODUCTOR = 143 Then
            If cuentarb > 0 Then
                total = total + (cuentarb * precioEcolat_RB)
            End If
            If cuentarc > 0 Then
                total = total + (cuentarc * precioEcolat_RC)
            End If
            If cuentacomposicion > 0 Then
                total = total + (cuentacomposicion * precioEcolat_composicion)
            End If
            If cuentacrioscopia > 0 Then
                total = total + (cuentacrioscopia * preciocrioscopia)
            End If
            If cuentainhibidores > 0 Then
                total = total + (cuentainhibidores * precioinhibidores)
            End If
            If cuentaesporulados > 0 Then
                total = total + (cuentaesporulados * precioesporulados)
            End If
            If cuentaurea > 0 Then
                total = total + (cuentaurea * preciourea)
            End If
            If cuentatermofilos > 0 Then
                total = total + (cuentatermofilos * preciotermofilos)
            End If
            If cuentapsicrotrofos > 0 Then
                total = total + (cuentapsicrotrofos * preciopsicrotrofos)
            End If
            If cuentacrioscopia_crioscopo > 0 Then
                total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
            End If
            If cuentacaseina > 0 Then
                total = total + (cuentacaseina * preciocaseina)
            End If

        ElseIf sa.IDPRODUCTOR = 150 Then
            If cuentarb > 0 Then
                total = total + (cuentarb * precioIndulacsaC_RB)
            End If
            If cuentarc > 0 Then
                total = total + (cuentarc * precioIndulacsaC_RC)
            End If
            If cuentacomposicion > 0 Then
                total = total + (cuentacomposicion * precioIndulacsaC_composicion)
            End If
            If cuentacrioscopia > 0 Then
                total = total + (cuentacrioscopia * preciocrioscopia)
            End If
            If cuentainhibidores > 0 Then
                total = total + (cuentainhibidores * precioinhibidores)
            End If
            If cuentaesporulados > 0 Then
                total = total + (cuentaesporulados * precioesporulados)
            End If
            If cuentaurea > 0 Then
                total = total + (cuentaurea * preciourea)
            End If
            If cuentatermofilos > 0 Then
                total = total + (cuentatermofilos * preciotermofilos)
            End If
            If cuentapsicrotrofos > 0 Then
                total = total + (cuentapsicrotrofos * preciopsicrotrofos)
            End If
            If cuentacrioscopia_crioscopo > 0 Then
                total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
            End If
            If cuentacaseina > 0 Then
                total = total + (cuentacaseina * preciocaseina)
            End If

        ElseIf sa.IDPRODUCTOR = 2705 Then
            If cuentarb > 0 Then
                total = total + (cuentarb * precioIndulacsaS_RB)
            End If
            If cuentarc > 0 Then
                total = total + (cuentarc * precioIndulacsaS_RC)
            End If
            If cuentacomposicion > 0 Then
                total = total + (cuentacomposicion * precioIndulacsaS_composicion)
            End If
            If cuentacrioscopia > 0 Then
                total = total + (cuentacrioscopia * preciocrioscopia)
            End If
            If cuentainhibidores > 0 Then
                total = total + (cuentainhibidores * precioIndulacsaS_inhibidores)
            End If
            If cuentaesporulados > 0 Then
                total = total + (cuentaesporulados * precioesporulados)
            End If
            If cuentaurea > 0 Then
                total = total + (cuentaurea * preciourea)
            End If
            If cuentatermofilos > 0 Then
                total = total + (cuentatermofilos * preciotermofilos)
            End If
            If cuentapsicrotrofos > 0 Then
                total = total + (cuentapsicrotrofos * preciopsicrotrofos)
            End If
            If cuentacrioscopia_crioscopo > 0 Then
                total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
            End If
            If cuentacaseina > 0 Then
                total = total + (cuentacaseina * preciocaseina)
            End If

        Else
            If cuentarb_rc_composicion > 0 Then
                total = total + (cuentarb_rc_composicion * preciobact_cel_comp)
            End If
            If cuentarb_rc > cuentarb_rc_composicion Then
                cuentarb_rc = cuentarb_rc - cuentarb_rc_composicion
                total = total + (cuentarb_rc * preciobact_cel)
            End If
            If cuentarb > 0 Then
                cuentarb = cuentarb - cuentarb_rc_composicion - cuentarb_rc
                total = total + (cuentarb * preciorb)
            End If
            If cuentarc > 0 Then
                cuentarc = cuentarc - cuentarb_rc_composicion - cuentarb_rc
                total = total + (cuentarc * preciorc)
            End If
            If cuentacomposicion > 0 Then
                cuentacomposicion = cuentacomposicion - cuentarb_rc_composicion
                total = total + (cuentacomposicion * preciocomposicion)
            End If

            If cuentacrioscopia > 0 Then
                total = total + (cuentacrioscopia * preciocrioscopia)
            End If
            If cuentainhibidores > 0 Then
                total = total + (cuentainhibidores * precioinhibidores)
            End If
            If cuentaesporulados > 0 Then
                total = total + (cuentaesporulados * precioesporulados)
            End If
            If cuentaurea > 0 Then
                total = total + (cuentaurea * preciourea)
            End If
            If cuentatermofilos > 0 Then
                total = total + (cuentatermofilos * preciotermofilos)
            End If
            If cuentapsicrotrofos > 0 Then
                total = total + (cuentapsicrotrofos * preciopsicrotrofos)
            End If
            If cuentacrioscopia_crioscopo > 0 Then
                total = total + (cuentacrioscopia_crioscopo * preciocrioscopia_crioscopo)
            End If
            If cuentacaseina > 0 Then
                total = total + (cuentacaseina * preciocaseina)
            End If

        End If


        total = Math.Round((total + preciotimbre), 0, MidpointRounding.AwayFromZero)


        '***********************************************************************************************
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

        x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total
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
        x1hoja.Cells(fila, columna).formula = "Valor fuera de rango (<2 o >3,8 Proteína, >4,5 Grasa % y"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = False
        columna = 1
        fila = fila + 1
        x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 7
        x1hoja.Cells(fila, columna).formula = "Crioscopía < -0,510ºC > -0,540ºC, < 1º y > 7º Temp. de arribo)"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 8
        x1hoja.Cells(fila, columna).Font.Bold = False
        columna = 1
        fila = fila + 1
        x1libro.Worksheets(1).cells(fila, columna).select()
        x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
        x1libro.Worksheets(1).cells(2, 1).select()
        columna = columna + 7
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

        x1hoja.Cells(fila, columna).formula = "Laboratorio habilitado RNL 0029 - MGAP"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        fila = fila + 2

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





        'PROTEGE LA HOJA DE EXCEL
        If sa.IDPRODUCTOR <> 2427 Then
            x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
       Contents:=True, Scenarios:=True)
        End If
        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.SaveAs("\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CALIDAD\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PRE INFORMES\CALIDAD\" & idsol & ".xls")

        x1app.Visible = True

        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
        If contador_rc > 0 Then
            MsgBox("Hay " & contador_rc & " muestra/s con RC por debajo de 100.")
        End If
    End Sub

    Private Sub FormInformeCalidadLeche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        If ListFichas.SelectedItems.Count = 1 Then
            Dim s As dSolicitudAnalisis = CType(ListFichas.SelectedItem, dSolicitudAnalisis)
            TextFicha.Text = s.ID
        End If
    End Sub
    Private Sub creainformetxt()
        Dim idficha As Long = TextFicha.Text.Trim
        Dim oSW As New StreamWriter("\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".txt")

        ' ====================================================================================
        Dim oSWAdolfo As New StreamWriter("\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".xml")

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
        Dim oSW As New StreamWriter("\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".txt")

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
        Dim oSW As New StreamWriter("\\SRVCOLAVECO\D\NET\CALIDAD\" & idficha & ".txt")
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