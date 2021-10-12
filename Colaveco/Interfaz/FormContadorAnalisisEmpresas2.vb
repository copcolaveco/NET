Imports System
Imports System.IO
Imports System.Collections
Public Class FormContadorAnalisisEmpresas2
#Region "Constructores"

    Dim barracontadora2 As Object

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarempresas()
        cargarTipoInforme()
        ButtonFacturar.Visible = False
    End Sub

#End Region

    Private Sub cargarempresas()
        ComboEmpresas.Items.Add("Seleccione una empresa")
        ComboEmpresas.Items.Add("CALCAR CARMELO")
        ComboEmpresas.Items.Add("CALCAR TARARIRAS")
        ComboEmpresas.Items.Add("GRANJA POCHA")
        'ComboEmpresas.Items.Add("DULEI")
        'ComboEmpresas.Items.Add("ECOLAT")
        ComboEmpresas.Items.Add("GRANJA BRASSETTI")
        ComboEmpresas.Items.Add("INDULACSA CARDONA")
        ComboEmpresas.Items.Add("INDULACSA SALTO")
        ComboEmpresas.Items.Add("LA MAGNOLIA")
        ComboEmpresas.Items.Add("NATURALIA")
        'ComboEmpresas.Items.Add("PINEROLO")
    End Sub

    Private Sub cargarTipoInforme()
        cbxTipoInforme.Items.Add("Calidad de Leche")
        cbxTipoInforme.Items.Add("Alimentos")
        cbxTipoInforme.Items.Add("Ambiental")
    End Sub

    Private Function tipoInforme(ByVal tipoInf As String) As Integer
        Dim res As Integer = 0
        If tipoInf = "Calidad de Leche" Then
            res = 10
            Return res
        End If
        If tipoInf = "Alimentos" Then
            res = 7
            Return res
        End If
        If tipoInf = "Ambiental" Then
            res = 11
            Return res
        End If
    End Function

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        DataGridView1.Rows.Clear()
        DataGridViewAmbiental.Rows.Clear()
        DataGridViewAlimentos.Rows.Clear()

        If ComboEmpresas.Text = "CALCAR CARMELO" Then
            calcar_carmelo()
        ElseIf ComboEmpresas.Text = "CALCAR TARARIRAS" Then
            calcar_tarariras()
        ElseIf ComboEmpresas.Text = "CALDEM" Then
            caldem()
        ElseIf ComboEmpresas.Text = "DULEI" Then
            dulei()
        ElseIf ComboEmpresas.Text = "ECOLAT" Then
            ecolat()
        ElseIf ComboEmpresas.Text = "GRANJA BRASSETTI" Then
            brassetti()
        ElseIf ComboEmpresas.Text = "INDULACSA CARDONA" Then
            indulacsac()
        ElseIf ComboEmpresas.Text = "INDULACSA SALTO" Then
            indulacsas()
        ElseIf ComboEmpresas.Text = "LA MAGNOLIA" Then
            magnolia()
        ElseIf ComboEmpresas.Text = "NATURALIA" Then
            naturalia()
        ElseIf ComboEmpresas.Text = "PINEROLO" Then
            pinerolo()
        ElseIf ComboEmpresas.Text = "GRANJA POCHA" Then
            granja_pocha()
        End If
    End Sub

    Private Sub ButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        If ComboEmpresas.Text = "CALCAR CARMELO" Then
            imprimir_calcar_carmelo()
        ElseIf ComboEmpresas.Text = "CALCAR TARARIRAS" Then
            imprimir_calcar_tarariras()
        ElseIf ComboEmpresas.Text = "CALDEM" Then
            imprimir_caldem()
        ElseIf ComboEmpresas.Text = "DULEI" Then
            imprimir_dulei()
        ElseIf ComboEmpresas.Text = "ECOLAT" Then
            imprimir_ecolat()
        ElseIf ComboEmpresas.Text = "GRANJA BRASSETTI" Then
            imprimir_brassetti()
        ElseIf ComboEmpresas.Text = "INDULACSA CARDONA" Then
            imprimir_indulacsac()
        ElseIf ComboEmpresas.Text = "INDULACSA SALTO" Then
            imprimir_indulacsas()
        ElseIf ComboEmpresas.Text = "LA MAGNOLIA" Then
            imprimir_magnolia()
        ElseIf ComboEmpresas.Text = "NATURALIA" Then
            imprimir_naturalia()
        ElseIf ComboEmpresas.Text = "PINEROLO" Then
            imprimir_pinerolo()
        ElseIf ComboEmpresas.Text = "GRANJA POCHA" Then
            imprimir_granja_pocha()
        End If
    End Sub

    Private Sub ButtonFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFacturar.Click
        If ComboEmpresas.Text = "CALCAR CARMELO" Then
            facturar_calcar_carmelo()
        ElseIf ComboEmpresas.Text = "CALCAR TARARIRAS" Then
            facturar_calcar_tarariras()
        ElseIf ComboEmpresas.Text = "INDULACSA CARDONA" Then
            facturar_indulacsac()
        ElseIf ComboEmpresas.Text = "INDULACSA SALTO" Then
            facturar_indulacsas()
        End If
    End Sub

#Region "Listados"
    Private Sub calcar_carmelo()
        Dim idempresa As Long = 219
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub calcar_tarariras()
        Dim idempresa As Long = 4688
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub caldem()
        Dim idempresa As Long = 149
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub dulei()
        Dim idempresa As Long = 809
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub ecolat()
        Dim idempresa As Long = 143
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub brassetti()
        Dim idempresa As Long = 107
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub indulacsac()
        Dim idempresa As Long = 150
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub indulacsas()
        Dim idempresa As Long = 2705
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub magnolia()
        Dim idempresa As Long = 157
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub naturalia()
        Dim idempresa As Long = 144
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub pinerolo()
        Dim idempresa As Long = 140
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub granja_pocha()
        Dim idempresa As Long = 600
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Listar(idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            ListarAmbiental(idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            ListarAlimentos(idempresa)
        End If
    End Sub
    Private Sub Listar(ByVal idEmp As Long)
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim cuentaanalisis As Integer = 0
        Dim barracontadora As Integer = 0
        Dim barracontadora2 As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = idEmp
        Dim ficha As Long = 0

        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0

        Dim totalrc As Integer = 0
        Dim totalrb As Integer = 0
        Dim totalgr As Integer = 0
        Dim totalpr As Integer = 0
        Dim totallc As Integer = 0
        Dim totalst As Integer = 0
        Dim totalcr As Integer = 0
        Dim totalur As Integer = 0
        Dim totalinh As Integer = 0
        Dim totalesp As Integer = 0
        Dim totalpsi As Integer = 0

        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim tipoInf As Integer = 0
        Dim cbxInforme As String
        Dim listo As Boolean = False
        cbxInforme = cbxTipoInforme.Text
        tipoInf = tipoInforme(cbxInforme)

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa, tipoInf)
        If listasa IsNot Nothing Then
            cuentaanalisis = listasa.Count
            barracontadora = 100 / cuentaanalisis
            barracontadora2 = 100 / cuentaanalisis
            DataGridView1.Rows.Clear()
            Dim contador As Integer = 0
            contador = listasa.Count + 2
            DataGridView1.Rows.Add(contador)
            If Not listasa Is Nothing Then
                If listasa.Count > 0 Then
                    For Each sa In listasa
                        If barracontadora <= 100 Then
                            ProgressBar1.Value = barracontadora
                        End If
                        Dim csm As New dCalidadSolicitudMuestra
                        Dim listacsm As New ArrayList
                        ficha = sa.ID
                        listacsm = csm.listarporsolicitud(ficha)
                        If Not listacsm Is Nothing Then
                            If listacsm.Count > 0 Then
                                For Each csm In listacsm
                                    If csm.RB = 1 Then
                                        Dim ibc As New dIbc
                                        ibc.FICHA = csm.FICHA
                                        ibc.MUESTRA = csm.MUESTRA
                                        ibc = ibc.buscarxfichaxmuestra
                                        If Not ibc Is Nothing Then
                                            contrb = contrb + 1
                                        End If
                                        ibc = Nothing
                                    End If
                                    Dim c As New dCalidad
                                    c.FICHA = csm.FICHA
                                    c.MUESTRA = csm.MUESTRA
                                    c = c.buscarxfichaxmuestra
                                    If Not c Is Nothing Then
                                        If csm.RC = 1 Then
                                            If c.RC <> -1 Then
                                                contrc = contrc + 1
                                            End If
                                        End If
                                        If csm.COMPOSICION = 1 Then
                                            If c.GRASA <> -1 Then
                                                contgr = contgr + 1
                                            End If
                                            If c.PROTEINA <> -1 Then
                                                contpr = contpr + 1
                                            End If
                                            If c.LACTOSA <> -1 Then
                                                contlc = contlc + 1
                                            End If
                                            If c.ST <> -1 Then
                                                contst = contst + 1
                                            End If
                                        End If
                                        If csm.CRIOSCOPIA = 1 Then
                                            If c.CRIOSCOPIA <> -1 Then
                                                contcr = contcr + 1
                                            End If
                                        End If
                                        If csm.CRIOSCOPIA_CRIOSCOPO Then
                                            contcr = contcr + 1
                                        End If
                                        If csm.UREA = 1 Then
                                            If c.UREA <> -1 Then
                                                contur = contur + 1
                                            End If
                                        End If
                                        c = Nothing
                                    End If
                                    If csm.INHIBIDORES = 1 Then
                                        Dim inh As New dInhibidores
                                        inh.FICHA = csm.FICHA
                                        inh.MUESTRA = csm.MUESTRA
                                        inh = inh.buscarxfichaxmuestra
                                        If Not inh Is Nothing Then
                                            continh = continh + 1
                                        End If
                                        inh = Nothing
                                    End If
                                    If csm.ESPORULADOS = 1 Then
                                        Dim esp As New dEsporulados
                                        esp.FICHA = csm.FICHA
                                        esp.MUESTRA = csm.MUESTRA
                                        esp = esp.buscarxfichaxmuestra
                                        If Not esp Is Nothing Then
                                            contesp = contesp + 1
                                        End If
                                        esp = Nothing
                                    End If
                                    If csm.PSICROTROFOS = 1 Then
                                        Dim psi As New dPsicrotrofos
                                        psi.FICHA = csm.FICHA
                                        psi.MUESTRA = csm.MUESTRA
                                        psi = psi.buscarxfichaxmuestra
                                        If Not psi Is Nothing Then
                                            contpsi = contpsi + 1
                                        End If
                                        psi = Nothing
                                    End If
                                Next
                            End If
                            listacsm = Nothing
                            csm = Nothing
                        End If
                        totalrc = totalrc + contrc
                        totalrb = totalrb + contrb
                        totalgr = totalgr + contgr
                        totalpr = totalpr + contpr
                        totallc = totallc + contlc
                        totalst = totalst + contst
                        totalcr = totalcr + contcr
                        totalur = totalur + contur
                        totalinh = totalinh + continh
                        totalesp = totalesp + contesp
                        totalpsi = totalpsi + contpsi
                        DataGridView1(columna, fila).Value = sa.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = sa.FECHAENVIO
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contrc
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contrb
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contgr
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contpr
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contlc
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contst
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contcr
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contur
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = continh
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contesp
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = contpsi
                        columna = 0
                        fila = fila + 1

                        contrc = 0
                        contrb = 0
                        contgr = 0
                        contpr = 0
                        contlc = 0
                        contst = 0
                        contcr = 0
                        contur = 0
                        continh = 0
                        contesp = 0
                        contpsi = 0
                        barracontadora = barracontadora + barracontadora2
                    Next
                    ProgressBar1.Value = 100

                    DataGridView1(columna, fila).Value = ""
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = "Total"
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalrc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalrb
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalgr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalpr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totallc
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalst
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalcr
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalur
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalinh
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalesp
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = totalpsi
                    columna = 0
                    fila = fila + 1
                    DataGridView1(columna, fila).Value = "Timbres"
                    columna = columna + 1
                    Dim timbres As Integer = 0
                    timbres = contador - 2
                    DataGridView1(columna, fila).Value = timbres
                    columna = columna + 1
                End If
                listasa = Nothing
                sa = Nothing
                listo = True
            End If
        End If
        If listo = False Then
            MsgBox("No se encontraron resultados", 0, "Listado")
        End If
        barracontadora = 1
    End Sub
    Private Sub ListarAmbiental(ByVal idEmp As Long)
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim cuentaanalisis As Integer = 0
        Dim barracontadora As Integer = 0
        Dim barracontadora2 As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = idEmp
        Dim ficha As Long = 0

        Dim LISTERIAAMBIENTAL As Integer = 0
        Dim PSEUDOMONASPPPSEUDOMONAAUREGINOSA As Integer = 0
        Dim ENTEROBACTERIASAMBIENTALES As Integer = 0
        Dim MOHOSYLEVADURASAmbiental As Integer = 0
        Dim COLIFORMESTOTALESAMBIENTALES As Integer = 0
        Dim CFECALESAMBIENTALES As Integer = 0
        Dim PSEUDOMONAAMBIENTAL As Integer = 0
        Dim ANALISISTERCERIZADOSAMB As Integer = 0
        Dim MESOFILOSAMBIENTAL As Integer = 0
        Dim ECOLIMONAMBIENTAL As Integer = 0
        Dim VOUCHERAREAAMBIENTAL As Integer = 0
        Dim MOHOS As Integer = 0
        Dim SALMONELLASPPAislamiento As Integer = 0
        Dim LEVADURAS As Integer = 0
        Dim LISTERIASPPPalcamAislamiento As Integer = 0
        Dim LISTERIAMONOCYTOGENES As Integer = 0
        Dim ESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim EColiO157RevealSP As Integer = 0
        Dim HISOPOPARAAMBIENTAL As Integer = 0
        Dim FRASCOCONMEDIOPARAAMBIENTAL As Integer = 0
        Dim LISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim SALMONELLAConfirmacionenambientales As Integer = 0
        Dim LISTERIASPPPalcamConfirmacion As Integer = 0

        Dim TOTALLISTERIAAMBIENTAL As Integer = 0
        Dim TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA As Integer = 0
        Dim TOTALENTEROBACTERIASAMBIENTALES As Integer = 0
        Dim TOTALMOHOSYLEVADURASAmbiental As Integer = 0
        Dim TOTALCOLIFORMESTOTALESAMBIENTALES As Integer = 0
        Dim TOTALCFECALESAMBIENTALES As Integer = 0
        Dim TOTALPSEUDOMONAAMBIENTAL As Integer = 0
        Dim TOTALANALISISTERCERIZADOSAMB As Integer = 0
        Dim TOTALMESOFILOSAMBIENTAL As Integer = 0
        Dim TOTALECOLIMONAMBIENTAL As Integer = 0
        Dim TOTALVOUCHERAREAAMBIENTAL As Integer = 0
        Dim TOTALMOHOS As Integer = 0
        Dim TOTALSALMONELLASPPAislamiento As Integer = 0
        Dim TOTALLEVADURAS As Integer = 0
        Dim TOTALLISTERIASPPPalcamAislamiento As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENES As Integer = 0
        Dim TOTALESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim TOTALEColiO157RevealSP As Integer = 0
        Dim TOTALHISOPOPARAAMBIENTAL As Integer = 0
        Dim TOTALFRASCOCONMEDIOPARAAMBIENTAL As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim TOTALSALMONELLAConfirmacionenambientales As Integer = 0
        Dim TOTALLISTERIASPPPalcamConfirmacion As Integer = 0


        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim tipoInf As Integer = 0
        Dim cbxInforme As String
        Dim listo As Boolean = False
        cbxInforme = cbxTipoInforme.Text
        tipoInf = tipoInforme(cbxInforme)

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa, tipoInf)
        If listasa IsNot Nothing Then
            cuentaanalisis = listasa.Count
            barracontadora = 100 / cuentaanalisis
            barracontadora2 = 100 / cuentaanalisis
            DataGridViewAmbiental.Rows.Clear()
            Dim contador As Integer = 0
            contador = listasa.Count + 2
            DataGridViewAmbiental.Rows.Add(contador)
            If Not listasa Is Nothing Then
                If listasa.Count > 0 Then
                    For Each sa In listasa
                        If barracontadora <= 100 Then
                            ProgressBar1.Value = barracontadora
                        End If
                        Dim analisis As New dNuevoAnalisis
                        Dim listaRes As New ArrayList
                        ficha = sa.ID
                        listaRes = analisis.listarporid(ficha)
                        If Not listaRes Is Nothing Then
                            If listaRes.Count > 0 Then
                                For Each analisis In listaRes
                                    Select Case analisis.ANALISIS
                                        Case 26
                                            LISTERIAAMBIENTAL = LISTERIAAMBIENTAL + 1
                                        Case 81
                                            PSEUDOMONASPPPSEUDOMONAAUREGINOSA = PSEUDOMONASPPPSEUDOMONAAUREGINOSA + 1
                                        Case 122
                                            ENTEROBACTERIASAMBIENTALES = ENTEROBACTERIASAMBIENTALES + 1
                                        Case 123
                                            MOHOSYLEVADURASAmbiental = MOHOSYLEVADURASAmbiental + 1
                                        Case 151
                                            COLIFORMESTOTALESAMBIENTALES = COLIFORMESTOTALESAMBIENTALES + 1
                                        Case 152
                                            CFECALESAMBIENTALES = CFECALESAMBIENTALES + 1
                                        Case 153
                                            PSEUDOMONAAMBIENTAL = PSEUDOMONAAMBIENTAL + 1
                                        Case 216
                                            ANALISISTERCERIZADOSAMB = ANALISISTERCERIZADOSAMB + 1
                                        Case 228
                                            MESOFILOSAMBIENTAL = MESOFILOSAMBIENTAL + 1
                                        Case 251
                                            ECOLIMONAMBIENTAL = ECOLIMONAMBIENTAL + 1
                                        Case 339
                                            VOUCHERAREAAMBIENTAL = VOUCHERAREAAMBIENTAL + 1
                                        Case 364
                                            MOHOS = MOHOS + 1
                                        Case 357
                                            SALMONELLASPPAislamiento = SALMONELLASPPAislamiento + 1
                                        Case 365
                                            LEVADURAS = LEVADURAS + 1
                                        Case 361
                                            LISTERIASPPPalcamAislamiento = LISTERIASPPPalcamAislamiento + 1
                                        Case 362
                                            LISTERIAMONOCYTOGENES = LISTERIAMONOCYTOGENES + 1
                                        Case 363
                                            ESTAFILOCOCOCOAGULASAPOSITIVO = ESTAFILOCOCOCOAGULASAPOSITIVO + 1
                                        Case 383
                                            EColiO157RevealSP = EColiO157RevealSP + 1
                                        Case 415
                                            HISOPOPARAAMBIENTAL = HISOPOPARAAMBIENTAL + 1
                                        Case 416
                                            FRASCOCONMEDIOPARAAMBIENTAL = FRASCOCONMEDIOPARAAMBIENTAL + 1
                                        Case 418
                                            LISTERIAMONOCYTOGENESPCR = LISTERIAMONOCYTOGENESPCR + 1
                                        Case 419
                                            TOTALLISTERIAMONOCYTOGENESPOOLPCR = TOTALLISTERIAMONOCYTOGENESPOOLPCR + 1
                                        Case 421
                                            SALMONELLAConfirmacionenambientales = SALMONELLAConfirmacionenambientales + 1
                                        Case 430
                                            LISTERIASPPPalcamConfirmacion = LISTERIASPPPalcamConfirmacion + 1
                                    End Select
                                Next
                            End If
                            listaRes = Nothing
                            analisis = Nothing
                        End If

                        TOTALLISTERIAAMBIENTAL = TOTALLISTERIAAMBIENTAL + LISTERIAAMBIENTAL
                        TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA = TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA + PSEUDOMONASPPPSEUDOMONAAUREGINOSA
                        TOTALENTEROBACTERIASAMBIENTALES = TOTALENTEROBACTERIASAMBIENTALES + ENTEROBACTERIASAMBIENTALES
                        TOTALMOHOSYLEVADURASAmbiental = TOTALMOHOSYLEVADURASAmbiental + MOHOSYLEVADURASAmbiental
                        TOTALCOLIFORMESTOTALESAMBIENTALES = TOTALCOLIFORMESTOTALESAMBIENTALES + COLIFORMESTOTALESAMBIENTALES
                        TOTALCFECALESAMBIENTALES = TOTALCFECALESAMBIENTALES + CFECALESAMBIENTALES
                        TOTALPSEUDOMONAAMBIENTAL = TOTALPSEUDOMONAAMBIENTAL + PSEUDOMONAAMBIENTAL
                        TOTALANALISISTERCERIZADOSAMB = TOTALANALISISTERCERIZADOSAMB + ANALISISTERCERIZADOSAMB
                        TOTALMESOFILOSAMBIENTAL = TOTALMESOFILOSAMBIENTAL + MESOFILOSAMBIENTAL
                        TOTALECOLIMONAMBIENTAL = TOTALECOLIMONAMBIENTAL + ECOLIMONAMBIENTAL
                        TOTALVOUCHERAREAAMBIENTAL = TOTALVOUCHERAREAAMBIENTAL + VOUCHERAREAAMBIENTAL
                        TOTALMOHOS = TOTALMOHOS + MOHOS
                        TOTALSALMONELLASPPAislamiento = TOTALSALMONELLASPPAislamiento + SALMONELLASPPAislamiento
                        TOTALLEVADURAS = TOTALLEVADURAS + LEVADURAS
                        TOTALLISTERIASPPPalcamAislamiento = TOTALLISTERIASPPPalcamAislamiento + LISTERIASPPPalcamAislamiento
                        TOTALLISTERIAMONOCYTOGENES = TOTALLISTERIAMONOCYTOGENES + LISTERIAMONOCYTOGENES
                        TOTALESTAFILOCOCOCOAGULASAPOSITIVO = TOTALESTAFILOCOCOCOAGULASAPOSITIVO + ESTAFILOCOCOCOAGULASAPOSITIVO
                        TOTALEColiO157RevealSP = TOTALEColiO157RevealSP + EColiO157RevealSP
                        TOTALHISOPOPARAAMBIENTAL = TOTALHISOPOPARAAMBIENTAL + HISOPOPARAAMBIENTAL
                        TOTALFRASCOCONMEDIOPARAAMBIENTAL = TOTALFRASCOCONMEDIOPARAAMBIENTAL + FRASCOCONMEDIOPARAAMBIENTAL
                        TOTALLISTERIAMONOCYTOGENESPCR = TOTALLISTERIAMONOCYTOGENESPCR + LISTERIAMONOCYTOGENESPCR
                        TOTALLISTERIAMONOCYTOGENESPOOLPCR = TOTALLISTERIAMONOCYTOGENESPOOLPCR + LISTERIAMONOCYTOGENESPOOLPCR
                        TOTALSALMONELLAConfirmacionenambientales = TOTALSALMONELLAConfirmacionenambientales + SALMONELLAConfirmacionenambientales
                        TOTALLISTERIASPPPalcamConfirmacion = TOTALLISTERIASPPPalcamConfirmacion + LISTERIASPPPalcamConfirmacion

                        DataGridViewAmbiental(columna, fila).Value = sa.ID
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = sa.FECHAENVIO
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = LISTERIAAMBIENTAL
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = PSEUDOMONASPPPSEUDOMONAAUREGINOSA
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = ENTEROBACTERIASAMBIENTALES
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = MOHOSYLEVADURASAmbiental
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = COLIFORMESTOTALESAMBIENTALES
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = CFECALESAMBIENTALES
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = PSEUDOMONAAMBIENTAL
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = ANALISISTERCERIZADOSAMB
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = MESOFILOSAMBIENTAL
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = ECOLIMONAMBIENTAL
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = VOUCHERAREAAMBIENTAL
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = MOHOS
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = SALMONELLASPPAislamiento
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = LEVADURAS
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = LISTERIASPPPalcamAislamiento
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = LISTERIAMONOCYTOGENES
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = ESTAFILOCOCOCOAGULASAPOSITIVO
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = EColiO157RevealSP
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = HISOPOPARAAMBIENTAL
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = FRASCOCONMEDIOPARAAMBIENTAL
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = LISTERIAMONOCYTOGENESPCR
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = LISTERIAMONOCYTOGENESPOOLPCR
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = SALMONELLAConfirmacionenambientales
                        columna = columna + 1
                        DataGridViewAmbiental(columna, fila).Value = LISTERIASPPPalcamConfirmacion

                        columna = 0
                        fila = fila + 1

                        LISTERIAAMBIENTAL = 0
                        PSEUDOMONASPPPSEUDOMONAAUREGINOSA = 0
                        ENTEROBACTERIASAMBIENTALES = 0
                        MOHOSYLEVADURASAmbiental = 0
                        COLIFORMESTOTALESAMBIENTALES = 0
                        CFECALESAMBIENTALES = 0
                        PSEUDOMONAAMBIENTAL = 0
                        ANALISISTERCERIZADOSAMB = 0
                        MESOFILOSAMBIENTAL = 0
                        ECOLIMONAMBIENTAL = 0
                        VOUCHERAREAAMBIENTAL = 0
                        MOHOS = 0
                        SALMONELLASPPAislamiento = 0
                        LEVADURAS = 0
                        LISTERIASPPPalcamAislamiento = 0
                        LISTERIAMONOCYTOGENES = 0
                        ESTAFILOCOCOCOAGULASAPOSITIVO = 0
                        EColiO157RevealSP = 0
                        HISOPOPARAAMBIENTAL = 0
                        FRASCOCONMEDIOPARAAMBIENTAL = 0
                        LISTERIAMONOCYTOGENESPCR = 0
                        LISTERIAMONOCYTOGENESPOOLPCR = 0
                        SALMONELLAConfirmacionenambientales = 0
                        LISTERIASPPPalcamConfirmacion = 0

                        barracontadora = barracontadora + barracontadora2
                    Next
                    ProgressBar1.Value = 100

                    DataGridViewAmbiental(columna, fila).Value = ""
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = "Total"
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALLISTERIAAMBIENTAL
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALENTEROBACTERIASAMBIENTALES
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALMOHOSYLEVADURASAmbiental
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALCOLIFORMESTOTALESAMBIENTALES
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALCFECALESAMBIENTALES
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALPSEUDOMONAAMBIENTAL
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALANALISISTERCERIZADOSAMB
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALMESOFILOSAMBIENTAL
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALECOLIMONAMBIENTAL
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALVOUCHERAREAAMBIENTAL
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALMOHOS
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALSALMONELLASPPAislamiento
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALLEVADURAS
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALLISTERIASPPPalcamAislamiento
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALLISTERIAMONOCYTOGENES
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALESTAFILOCOCOCOAGULASAPOSITIVO
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALEColiO157RevealSP
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALHISOPOPARAAMBIENTAL
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALFRASCOCONMEDIOPARAAMBIENTAL
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPCR
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPOOLPCR
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALSALMONELLAConfirmacionenambientales
                    columna = columna + 1
                    DataGridViewAmbiental(columna, fila).Value = TOTALLISTERIASPPPalcamConfirmacion
                    columna = 0

                    fila = fila + 1
                    DataGridViewAmbiental(columna, fila).Value = "Timbres"
                    columna = columna + 1
                    Dim timbres As Integer = 0
                    timbres = contador - 2
                    DataGridViewAmbiental(columna, fila).Value = timbres
                    columna = columna + 1
                End If
                listasa = Nothing
                sa = Nothing
                listo = True
            End If
        End If
        If listo = False Then
            MsgBox("No se encontraron resultados", 0, "Listado")
        End If
        barracontadora = 1
    End Sub
    Private Sub ListarAlimentos(ByVal idEmp As Long)
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim cuentaanalisis As Integer = 0
        Dim barracontadora As Integer = 0
        Dim barracontadora2 As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = idEmp
        Dim ficha As Long = 0

        Dim ENTEROBACTERIAS As Integer = 0
        Dim CLORURODESODIO As Integer = 0
        Dim ECOLICOLIFORMESTOTALES35 As Integer = 0
        Dim ESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim SALMONELLASPPAislamiento As Integer = 0
        Dim MOHOSLEVADURAS As Integer = 0
        Dim SOLIDOSTOTALESHUMEDAD As Integer = 0
        Dim MATERIAGRASAVanGulik As Integer = 0
        Dim pH As Integer = 0
        Dim PROTEINATOTALxDUMAS As Integer = 0
        Dim TermofilosSP As Integer = 0
        Dim CENIZASTOTALES As Integer = 0
        Dim Nitrato As Integer = 0
        Dim COLIFORMESTOTALES As Integer = 0
        Dim COLIFORMESFECALES As Integer = 0
        Dim Paq1 As Integer = 0
        Dim Paq2 As Integer = 0
        Dim Paq3 As Integer = 0
        Dim LISTERIAMONOCYTOGENESAislamiento As Integer = 0
        Dim COMPOSICIONENSUERO As Integer = 0
        Dim EColiO157RevealSP As Integer = 0
        Dim MATERIAGRASAporROSEGOTTLIEB As Integer = 0
        Dim PROTEINATOTALNITROGENOxKJELDAHL As Integer = 0
        Dim ProteinaTotalporDUMAS5muestrasomás As Integer = 0
        Dim ANALISISTERCERIZADOSBROMAT As Integer = 0
        Dim Paq4 As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento As Integer = 0
        Dim SALMONELLASPPPOOL5MUESTRASAislamiento As Integer = 0
        Dim BACTERIASACIDOLACTICAS As Integer = 0
        Dim BACILLUSCEREUS As Integer = 0
        Dim MESÓFILOSRB As Integer = 0
        Dim ECOLIconpaq As Integer = 0
        Dim LEVADURAS As Integer = 0
        Dim LISTERIASPP As Integer = 0
        Dim MOHOS As Integer = 0
        Dim LISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim SALMONELLASPPPCR As Integer = 0
        Dim SALMONELLASPPPOOLPCR As Integer = 0
        Dim ACIDEZ As Integer = 0
        Dim CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO As Integer = 0
        Dim SALMONELLAConfirmacionenAlimentos As Integer = 0
        Dim SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos As Integer = 0
        Dim LISTERIAMONOCYTOGENESConfirmacionenalimentos As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion As Integer = 0
        Dim Paq5 As Integer = 0
        Dim Carbohidratos As Integer = 0
        Dim Energía As Integer = 0
        Dim LACTOSA As Integer = 0
        Dim CONDUCTIVIDADAlimentos As Integer = 0
        Dim EnvioaotrosLaboratoriosBromatologia As Integer = 0

        Dim TOTALENTEROBACTERIAS As Integer = 0
        Dim TOTALCLORURODESODIO As Integer = 0
        Dim TOTALECOLICOLIFORMESTOTALES35 As Integer = 0
        Dim TOTALESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim TOTALSALMONELLASPPAislamiento As Integer = 0
        Dim TOTALMOHOSLEVADURAS As Integer = 0
        Dim TOTALSOLIDOSTOTALESHUMEDAD As Integer = 0
        Dim TOTALMATERIAGRASAVanGulik As Integer = 0
        Dim TOTALpH As Integer = 0
        Dim TOTALPROTEINATOTALxDUMAS As Integer = 0
        Dim TOTALTermofilosSP As Integer = 0
        Dim TOTALCENIZASTOTALES As Integer = 0
        Dim TOTALNitrato As Integer = 0
        Dim TOTALCOLIFORMESTOTALES As Integer = 0
        Dim TOTALCOLIFORMESFECALES As Integer = 0
        Dim TOTALPaq1 As Integer = 0
        Dim TOTALPaq2 As Integer = 0
        Dim TOTALPaq3 As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESAislamiento As Integer = 0
        Dim TOTALCOMPOSICIONENSUERO As Integer = 0
        Dim TOTALEColiO157RevealSP As Integer = 0
        Dim TOTALMATERIAGRASAporROSEGOTTLIEB As Integer = 0
        Dim TOTALPROTEINATOTALNITROGENOxKJELDAHL As Integer = 0
        Dim TOTALProteinaTotalporDUMAS5muestrasomás As Integer = 0
        Dim TOTALANALISISTERCERIZADOSBROMAT As Integer = 0
        Dim TOTALPaq4 As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento As Integer = 0
        Dim TOTALSALMONELLASPPPOOL5MUESTRASAislamiento As Integer = 0
        Dim TOTALBACTERIASACIDOLACTICAS As Integer = 0
        Dim TOTALBACILLUSCEREUS As Integer = 0
        Dim TOTALMESÓFILOSRB As Integer = 0
        Dim TOTALECOLIconpaq As Integer = 0
        Dim TOTALLEVADURAS As Integer = 0
        Dim TOTALLISTERIASPP As Integer = 0
        Dim TOTALMOHOS As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim TOTALSALMONELLASPPPCR As Integer = 0
        Dim TOTALSALMONELLASPPPOOLPCR As Integer = 0
        Dim TOTALACIDEZ As Integer = 0
        Dim TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO As Integer = 0
        Dim TOTALSALMONELLAConfirmacionenAlimentos As Integer = 0
        Dim TOTALSALMONELLAPOOL5MUESTRASConfirmacionenAlimentos As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion As Integer = 0
        Dim TOTALPaq5 As Integer = 0
        Dim TOTALCarbohidratos As Integer = 0
        Dim TOTALEnergía As Integer = 0
        Dim TOTALLACTOSA As Integer = 0
        Dim TOTALCONDUCTIVIDADAlimentos As Integer = 0
        Dim TOTALEnvioaotrosLaboratoriosBromatologia As Integer = 0


        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim tipoInf As Integer = 0
        Dim cbxInforme As String
        Dim listo As Boolean = False
        cbxInforme = cbxTipoInforme.Text
        tipoInf = tipoInforme(cbxInforme)

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa, tipoInf)
        If listasa IsNot Nothing Then
            cuentaanalisis = listasa.Count
            barracontadora = 100 / cuentaanalisis
            barracontadora2 = 100 / cuentaanalisis
            DataGridViewAlimentos.Rows.Clear()
            Dim contador As Integer = 0
            contador = listasa.Count + 2
            DataGridViewAlimentos.Rows.Add(contador)
            If Not listasa Is Nothing Then
                If listasa.Count > 0 Then
                    For Each sa In listasa
                        If barracontadora <= 100 Then
                            ProgressBar1.Value = barracontadora
                        End If
                        Dim analisis As New dNuevoAnalisis
                        Dim listaRes As New ArrayList
                        ficha = sa.ID
                        listaRes = analisis.listarporid(ficha)
                        If Not listaRes Is Nothing Then
                            If listaRes.Count > 0 Then
                                For Each analisis In listaRes
                                    Select Case analisis.ANALISIS
                                        Case 9
                                            ENTEROBACTERIAS = ENTEROBACTERIAS + 1
                                        Case 10
                                            CLORURODESODIO = CLORURODESODIO + 1
                                        Case 23
                                            ECOLICOLIFORMESTOTALES35 = ECOLICOLIFORMESTOTALES35 + 1
                                        Case 24
                                            ESTAFILOCOCOCOAGULASAPOSITIVO = ESTAFILOCOCOCOAGULASAPOSITIVO + 1
                                        Case 27
                                            SALMONELLASPPAislamiento = SALMONELLASPPAislamiento + 1
                                        Case 28
                                            MOHOSLEVADURAS = MOHOSLEVADURAS + 1
                                        Case 29
                                            SOLIDOSTOTALESHUMEDAD = SOLIDOSTOTALESHUMEDAD + 1
                                        Case 30
                                            MATERIAGRASAVanGulik = MATERIAGRASAVanGulik + 1
                                        Case 31
                                            pH = pH + 1
                                        Case 32
                                            PROTEINATOTALxDUMAS = PROTEINATOTALxDUMAS + 1
                                        Case 62
                                            TermofilosSP = TermofilosSP + 1
                                        Case 64
                                            CENIZASTOTALES = CENIZASTOTALES + 1
                                        Case 76
                                            Nitrato = Nitrato + 1
                                        Case 83
                                            COLIFORMESTOTALES = COLIFORMESTOTALES + 1
                                        Case 84
                                            COLIFORMESFECALES = COLIFORMESFECALES + 1
                                        Case 94
                                            Paq1 = Paq1 + 1
                                        Case 95
                                            Paq2 = Paq2 + 1
                                        Case 96
                                            Paq3 = Paq3 + 1
                                        Case 141
                                            LISTERIAMONOCYTOGENESAislamiento = LISTERIAMONOCYTOGENESAislamiento + 1
                                        Case 154
                                            COMPOSICIONENSUERO = COMPOSICIONENSUERO + 1
                                        Case 185
                                            EColiO157RevealSP = EColiO157RevealSP + 1
                                        Case 186
                                            MATERIAGRASAporROSEGOTTLIEB = MATERIAGRASAporROSEGOTTLIEB + 1
                                        Case 187
                                            PROTEINATOTALNITROGENOxKJELDAHL = PROTEINATOTALNITROGENOxKJELDAHL + 1
                                        Case 188
                                            ProteinaTotalporDUMAS5muestrasomás = ProteinaTotalporDUMAS5muestrasomás + 1
                                        Case 217
                                            ANALISISTERCERIZADOSBROMAT = ANALISISTERCERIZADOSBROMAT + 1
                                        Case 230
                                            Paq4 = Paq4 + 1
                                        Case 231
                                            LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento = LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento + 1
                                        Case 232
                                            SALMONELLASPPPOOL5MUESTRASAislamiento = SALMONELLASPPPOOL5MUESTRASAislamiento + 1
                                        Case 248
                                            BACTERIASACIDOLACTICAS = BACTERIASACIDOLACTICAS + 1
                                        Case 249
                                            BACILLUSCEREUS = BACILLUSCEREUS + 1
                                        Case 336
                                            MESÓFILOSRB = MESÓFILOSRB + 1
                                        Case 337
                                            ECOLIconpaq = ECOLIconpaq + 1
                                        Case 346
                                            LEVADURAS = LEVADURAS + 1
                                        Case 347
                                            LISTERIASPP = LISTERIASPP + 1
                                        Case 349
                                            MOHOS = MOHOS + 1
                                        Case 402
                                            LISTERIAMONOCYTOGENESPCR = LISTERIAMONOCYTOGENESPCR + 1
                                        Case 403
                                            LISTERIAMONOCYTOGENESPOOLPCR = LISTERIAMONOCYTOGENESPOOLPCR + 1
                                        Case 404
                                            SALMONELLASPPPCR = SALMONELLASPPPCR + 1
                                        Case 405
                                            SALMONELLASPPPOOLPCR = SALMONELLASPPPOOLPCR + 1
                                        Case 413
                                            ACIDEZ = ACIDEZ + 1
                                        Case 414
                                            CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO = CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO + 1
                                        Case 422
                                            SALMONELLAConfirmacionenAlimentos = SALMONELLAConfirmacionenAlimentos + 1
                                        Case 423
                                            SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos = SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos + 1
                                        Case 424
                                            LISTERIAMONOCYTOGENESConfirmacionenalimentos = LISTERIAMONOCYTOGENESConfirmacionenalimentos + 1
                                        Case 425
                                            LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion = LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion + 1
                                        Case 426
                                            Paq5 = Paq5 + 1
                                        Case 433
                                            Carbohidratos = Carbohidratos + 1
                                        Case 434
                                            Energía = Energía + 1
                                        Case 435
                                            LACTOSA = LACTOSA + 1
                                        Case 436
                                            CONDUCTIVIDADAlimentos = CONDUCTIVIDADAlimentos + 1
                                        Case 437
                                            EnvioaotrosLaboratoriosBromatologia = EnvioaotrosLaboratoriosBromatologia + 1
                                    End Select
                                Next
                            End If
                            listaRes = Nothing
                            analisis = Nothing
                        End If

                        TOTALENTEROBACTERIAS = TOTALENTEROBACTERIAS + ENTEROBACTERIAS
                        TOTALCLORURODESODIO = TOTALCLORURODESODIO + CLORURODESODIO
                        TOTALECOLICOLIFORMESTOTALES35 = TOTALECOLICOLIFORMESTOTALES35 + ECOLICOLIFORMESTOTALES35
                        TOTALESTAFILOCOCOCOAGULASAPOSITIVO = TOTALESTAFILOCOCOCOAGULASAPOSITIVO + ESTAFILOCOCOCOAGULASAPOSITIVO
                        TOTALSALMONELLASPPAislamiento = TOTALSALMONELLASPPAislamiento + SALMONELLASPPAislamiento
                        TOTALMOHOSLEVADURAS = TOTALMOHOSLEVADURAS + MOHOSLEVADURAS
                        TOTALSOLIDOSTOTALESHUMEDAD = TOTALSOLIDOSTOTALESHUMEDAD + SOLIDOSTOTALESHUMEDAD
                        TOTALMATERIAGRASAVanGulik = TOTALMATERIAGRASAVanGulik + MATERIAGRASAVanGulik
                        TOTALpH = TOTALpH + pH
                        TOTALPROTEINATOTALxDUMAS = TOTALPROTEINATOTALxDUMAS + PROTEINATOTALxDUMAS
                        TOTALTermofilosSP = TOTALTermofilosSP + TermofilosSP
                        TOTALCENIZASTOTALES = TOTALCENIZASTOTALES + CENIZASTOTALES
                        TOTALNitrato = TOTALNitrato + Nitrato
                        TOTALCOLIFORMESTOTALES = TOTALCOLIFORMESTOTALES + COLIFORMESTOTALES
                        TOTALCOLIFORMESFECALES = TOTALCOLIFORMESFECALES + COLIFORMESFECALES
                        TOTALPaq1 = TOTALPaq1 + Paq1
                        TOTALPaq2 = TOTALPaq2 + Paq2
                        TOTALPaq3 = TOTALPaq3 + Paq3
                        TOTALLISTERIAMONOCYTOGENESAislamiento = TOTALLISTERIAMONOCYTOGENESAislamiento + LISTERIAMONOCYTOGENESAislamiento
                        TOTALCOMPOSICIONENSUERO = TOTALCOMPOSICIONENSUERO + COMPOSICIONENSUERO
                        TOTALEColiO157RevealSP = TOTALEColiO157RevealSP + EColiO157RevealSP
                        TOTALMATERIAGRASAporROSEGOTTLIEB = TOTALMATERIAGRASAporROSEGOTTLIEB + MATERIAGRASAporROSEGOTTLIEB
                        TOTALPROTEINATOTALNITROGENOxKJELDAHL = TOTALPROTEINATOTALNITROGENOxKJELDAHL + PROTEINATOTALNITROGENOxKJELDAHL
                        TOTALProteinaTotalporDUMAS5muestrasomás = TOTALProteinaTotalporDUMAS5muestrasomás + ProteinaTotalporDUMAS5muestrasomás
                        TOTALANALISISTERCERIZADOSBROMAT = TOTALANALISISTERCERIZADOSBROMAT + ANALISISTERCERIZADOSBROMAT
                        TOTALPaq4 = TOTALPaq4 + Paq4
                        TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento = TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento + LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento
                        TOTALSALMONELLASPPPOOL5MUESTRASAislamiento = TOTALSALMONELLASPPPOOL5MUESTRASAislamiento + SALMONELLASPPPOOL5MUESTRASAislamiento
                        TOTALBACTERIASACIDOLACTICAS = TOTALBACTERIASACIDOLACTICAS + BACTERIASACIDOLACTICAS
                        TOTALBACILLUSCEREUS = TOTALBACILLUSCEREUS + BACILLUSCEREUS
                        TOTALMESÓFILOSRB = TOTALMESÓFILOSRB + MESÓFILOSRB
                        TOTALECOLIconpaq = TOTALECOLIconpaq + ECOLIconpaq
                        TOTALLEVADURAS = TOTALLEVADURAS + LEVADURAS
                        TOTALLISTERIASPP = TOTALLISTERIASPP + LISTERIASPP
                        TOTALMOHOS = TOTALMOHOS + MOHOS
                        TOTALLISTERIAMONOCYTOGENESPCR = TOTALLISTERIAMONOCYTOGENESPCR + LISTERIAMONOCYTOGENESPCR
                        TOTALLISTERIAMONOCYTOGENESPOOLPCR = TOTALLISTERIAMONOCYTOGENESPOOLPCR + LISTERIAMONOCYTOGENESPOOLPCR
                        TOTALSALMONELLASPPPCR = TOTALSALMONELLASPPPCR + SALMONELLASPPPCR
                        TOTALSALMONELLASPPPOOLPCR = TOTALSALMONELLASPPPOOLPCR + SALMONELLASPPPOOLPCR
                        TOTALACIDEZ = TOTALACIDEZ + ACIDEZ
                        TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO = TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO + CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO
                        TOTALSALMONELLAConfirmacionenAlimentos = TOTALSALMONELLAConfirmacionenAlimentos + SALMONELLAConfirmacionenAlimentos
                        TOTALSALMONELLAPOOL5MUESTRASConfirmacionenAlimentos = TOTALSALMONELLAPOOL5MUESTRASConfirmacionenAlimentos + SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos
                        TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos = TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos + LISTERIAMONOCYTOGENESConfirmacionenalimentos
                        TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion = TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion + LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion
                        TOTALPaq5 = TOTALPaq5 + Paq5
                        TOTALCarbohidratos = TOTALCarbohidratos + Carbohidratos
                        TOTALEnergía = TOTALEnergía + Energía
                        TOTALLACTOSA = TOTALLACTOSA + LACTOSA
                        TOTALCONDUCTIVIDADAlimentos = TOTALCONDUCTIVIDADAlimentos + CONDUCTIVIDADAlimentos
                        TOTALEnvioaotrosLaboratoriosBromatologia = TOTALEnvioaotrosLaboratoriosBromatologia + EnvioaotrosLaboratoriosBromatologia

                        DataGridViewAlimentos(columna, fila).Value = sa.ID
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = sa.FECHAENVIO
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = ENTEROBACTERIAS
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = CLORURODESODIO
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = ECOLICOLIFORMESTOTALES35
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = ESTAFILOCOCOCOAGULASAPOSITIVO
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = SALMONELLASPPAislamiento
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = MOHOSLEVADURAS
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = SOLIDOSTOTALESHUMEDAD
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = MATERIAGRASAVanGulik
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = pH
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = PROTEINATOTALxDUMAS
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = TermofilosSP
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = CENIZASTOTALES
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Nitrato
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = COLIFORMESTOTALES
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = COLIFORMESFECALES
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Paq1
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Paq2
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Paq3
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIAMONOCYTOGENESAislamiento
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = COMPOSICIONENSUERO
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = EColiO157RevealSP
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIAMONOCYTOGENESPOOLPCR
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = MATERIAGRASAporROSEGOTTLIEB
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = PROTEINATOTALNITROGENOxKJELDAHL
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = ProteinaTotalporDUMAS5muestrasomás
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = ANALISISTERCERIZADOSBROMAT
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Paq4
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = SALMONELLASPPPOOL5MUESTRASAislamiento
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = BACTERIASACIDOLACTICAS
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = BACILLUSCEREUS
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = MESÓFILOSRB
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = ECOLIconpaq
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LEVADURAS
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIASPP
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = MOHOS
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIAMONOCYTOGENESPCR
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIAMONOCYTOGENESPOOLPCR
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = SALMONELLASPPPCR
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = SALMONELLASPPPOOLPCR
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = ACIDEZ
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = SALMONELLAConfirmacionenAlimentos
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIAMONOCYTOGENESConfirmacionenalimentos
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Paq5
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Carbohidratos
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = Energía
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = CONDUCTIVIDADAlimentos
                        columna = columna + 1
                        DataGridViewAlimentos(columna, fila).Value = EnvioaotrosLaboratoriosBromatologia

                        ENTEROBACTERIAS = 0

                        CLORURODESODIO = 0

                        ECOLICOLIFORMESTOTALES35 = 0

                        ESTAFILOCOCOCOAGULASAPOSITIVO = 0

                        SALMONELLASPPAislamiento = 0

                        MOHOSLEVADURAS = 0

                        SOLIDOSTOTALESHUMEDAD = 0

                        MATERIAGRASAVanGulik = 0

                        pH = 0

                        PROTEINATOTALxDUMAS = 0

                        TermofilosSP = 0

                        CENIZASTOTALES = 0

                        Nitrato = 0

                        COLIFORMESTOTALES = 0

                        COLIFORMESFECALES = 0

                        Paq1 = 0

                        Paq2 = 0

                        Paq3 = 0

                        LISTERIAMONOCYTOGENESAislamiento = 0

                        COMPOSICIONENSUERO = 0

                        EColiO157RevealSP = 0

                        LISTERIAMONOCYTOGENESPOOLPCR = 0

                        MATERIAGRASAporROSEGOTTLIEB = 0

                        PROTEINATOTALNITROGENOxKJELDAHL = 0

                        ProteinaTotalporDUMAS5muestrasomás = 0

                        ANALISISTERCERIZADOSBROMAT = 0

                        Paq4 = 0

                        LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento = 0

                        SALMONELLASPPPOOL5MUESTRASAislamiento = 0

                        BACTERIASACIDOLACTICAS = 0

                        BACILLUSCEREUS = 0

                        MESÓFILOSRB = 0

                        ECOLIconpaq = 0

                        LEVADURAS = 0

                        LISTERIASPP = 0

                        MOHOS = 0

                        LISTERIAMONOCYTOGENESPCR = 0

                        LISTERIAMONOCYTOGENESPOOLPCR = 0

                        SALMONELLASPPPCR = 0

                        SALMONELLASPPPOOLPCR = 0

                        ACIDEZ = 0

                        CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO = 0

                        SALMONELLAConfirmacionenAlimentos = 0

                        SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos = 0

                        LISTERIAMONOCYTOGENESConfirmacionenalimentos = 0

                        LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion = 0

                        Paq5 = 0

                        Carbohidratos = 0

                        Energía = 0

                        CONDUCTIVIDADAlimentos = 0

                        EnvioaotrosLaboratoriosBromatologia = 0

                        columna = 0
                        fila = fila + 1



                        barracontadora = barracontadora + barracontadora2
                    Next
                    ProgressBar1.Value = 100

                    DataGridViewAlimentos(columna, fila).Value = ""
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = "Total"
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALENTEROBACTERIAS
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCLORURODESODIO
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALECOLICOLIFORMESTOTALES35
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALESTAFILOCOCOCOAGULASAPOSITIVO
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALSALMONELLASPPAislamiento
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALMOHOSLEVADURAS
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALSOLIDOSTOTALESHUMEDAD
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALMATERIAGRASAVanGulik
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALpH
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALPROTEINATOTALxDUMAS
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALTermofilosSP
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCENIZASTOTALES
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALNitrato
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCOLIFORMESTOTALES
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCOLIFORMESFECALES
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALPaq1
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALPaq2
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALPaq3
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESAislamiento
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCOMPOSICIONENSUERO
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPCR
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALEColiO157RevealSP
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPOOLPCR
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALMATERIAGRASAporROSEGOTTLIEB
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALPROTEINATOTALNITROGENOxKJELDAHL
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALProteinaTotalporDUMAS5muestrasomás
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPCR
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPOOLPCR
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALANALISISTERCERIZADOSBROMAT
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALPaq4
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALBACTERIASACIDOLACTICAS
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALBACILLUSCEREUS
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALMESÓFILOSRB
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALECOLIconpaq
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLEVADURAS
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIASPP
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALMOHOS
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPCR
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPOOLPCR
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALSALMONELLASPPPCR
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALACIDEZ
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALSALMONELLAConfirmacionenAlimentos
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALPaq5
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCarbohidratos
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALEnergía
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALCONDUCTIVIDADAlimentos
                    columna = columna + 1
                    DataGridViewAlimentos(columna, fila).Value = TOTALEnvioaotrosLaboratoriosBromatologia
                    columna = 0

                    fila = fila + 1
                    DataGridViewAlimentos(columna, fila).Value = "Timbres"
                    columna = columna + 1
                    Dim timbres As Integer = 0
                    timbres = contador - 2
                    DataGridViewAlimentos(columna, fila).Value = timbres
                    columna = columna + 1
                End If
                listasa = Nothing
                sa = Nothing
                listo = True
            End If
        End If
        If listo = False Then
            MsgBox("No se encontraron resultados", 0, "Listado")
        End If
        barracontadora = 1
    End Sub
#End Region

#Region "Impresiones"
    Private Sub imprimir_calcar_carmelo()
        Dim idempresa As Long = 219
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\calcar_carmelo.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\calcar_carmelo_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\calcar_carmelo_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_calcar_tarariras()
        Dim idempresa As Long = 4688
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\calcar_tarariras.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\calcar_tarariras_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\calcar_tarariras_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_caldem()
        Dim idempresa As Long = 149
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\caldem.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\caldem_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\caldem_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_dulei()
        Dim idempresa As Long = 809
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\dulei.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\dulei_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\dulei_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_ecolat()
        Dim idempresa As Long = 143
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\ecolat.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\ecolat_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\ecolat_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_brassetti()
        Dim idempresa As Long = 107
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\brassetti.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\brassetti_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\brassetti_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_indulacsac()
        Dim idempresa As Long = 150
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\indulacsa_cardona.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\indulacsa_cardona_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\indulacsa_cardona_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_indulacsas()
        Dim idempresa As Long = 2705
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\indulacsa_salto.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\indulacsa_salto_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\indulacsa_salto_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_magnolia()
        Dim idempresa As Long = 157
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\magnolia.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\magnolia_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\magnolia_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_naturalia()
        Dim idempresa As Long = 144
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\naturalia.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\naturalia_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\naturalia_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_pinerolo()
        Dim idempresa As Long = 140
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\calcar_pinerolo.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\calcar_pinerolo_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\calcar_pinerolo_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Sub imprimir_granja_pocha()
        Dim idempresa As Long = 600
        If cbxTipoInforme.Text = "Calidad de Leche" Then
            Dim oSW As String = "c:\empresa\granja_pocha.txt"
            Imprimir(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Ambiental" Then
            Dim oSW As String = "c:\empresa\granja_pocha_ambiental.txt"
            ImprimirAmbiental(oSW, idempresa)
        End If
        If cbxTipoInforme.Text = "Alimentos" Then
            Dim oSW As String = "c:\empresa\granja_pocha_alimentos.txt"
            ImprimirAlimentos(oSW, idempresa)
        End If
    End Sub
    Private Function Imprimir(ByVal archivo As String, ByVal idemp As Long)
        Dim oSW As New System.IO.StreamWriter(archivo)
        Dim Linea As String = ""
        Dim imprimio As Boolean = False
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim cuentaanalisis As Integer = 0
        Dim barracontadora As Integer = 0
        Dim barracontadora2 As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = idemp
        Dim ficha As Long = 0

        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0

        Dim totalrc As Integer = 0
        Dim totalrb As Integer = 0
        Dim totalgr As Integer = 0
        Dim totalpr As Integer = 0
        Dim totallc As Integer = 0
        Dim totalst As Integer = 0
        Dim totalcr As Integer = 0
        Dim totalur As Integer = 0
        Dim totalinh As Integer = 0
        Dim totalesp As Integer = 0
        Dim totalpsi As Integer = 0

        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim tipoInf As Integer = 0
        Dim cbxInforme As String
        cbxInforme = cbxTipoInforme.Text
        tipoInf = tipoInforme(cbxInforme)

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa, tipoInf)
        If Not listasa Is Nothing Then
            cuentaanalisis = listasa.Count

            barracontadora = 100 / cuentaanalisis
            barracontadora2 = 100 / cuentaanalisis

            If Not listasa Is Nothing Then
                If listasa.Count > 0 Then
                    For Each sa In listasa
                        If barracontadora <= 100 Then
                            ProgressBar1.Value = barracontadora
                        End If
                        Dim csm As New dCalidadSolicitudMuestra
                        Dim listacsm As New ArrayList
                        ficha = sa.ID
                        listacsm = csm.listarporsolicitud(ficha)
                        If Not listacsm Is Nothing Then
                            If listacsm.Count > 0 Then
                                For Each csm In listacsm
                                    If csm.RB = 1 Then
                                        Dim ibc As New dIbc
                                        ibc.FICHA = csm.FICHA
                                        ibc.MUESTRA = csm.MUESTRA
                                        ibc = ibc.buscarxfichaxmuestra
                                        If Not ibc Is Nothing Then
                                            contrb = contrb + 1
                                        End If
                                        ibc = Nothing
                                    End If
                                    Dim c As New dCalidad
                                    c.FICHA = csm.FICHA
                                    c.MUESTRA = csm.MUESTRA
                                    c = c.buscarxfichaxmuestra
                                    If Not c Is Nothing Then
                                        If csm.RC = 1 Then
                                            If c.RC <> -1 Then
                                                contrc = contrc + 1
                                            End If
                                        End If
                                        If csm.COMPOSICION = 1 Then
                                            If c.GRASA <> -1 Then
                                                contgr = contgr + 1
                                            End If
                                            If c.PROTEINA <> -1 Then
                                                contpr = contpr + 1
                                            End If
                                            If c.LACTOSA <> -1 Then
                                                contlc = contlc + 1
                                            End If
                                            If c.ST <> -1 Then
                                                contst = contst + 1
                                            End If
                                        End If
                                        If csm.CRIOSCOPIA = 1 Then
                                            If c.CRIOSCOPIA <> -1 Then
                                                contcr = contcr + 1
                                            End If
                                        End If
                                        If csm.CRIOSCOPIA_CRIOSCOPO Then
                                            contcr = contcr + 1
                                        End If
                                        If csm.UREA = 1 Then
                                            If c.UREA <> -1 Then
                                                contur = contur + 1
                                            End If
                                        End If
                                        c = Nothing
                                    End If
                                    If csm.INHIBIDORES = 1 Then
                                        Dim inh As New dInhibidores
                                        inh.FICHA = csm.FICHA
                                        inh.MUESTRA = csm.MUESTRA
                                        inh = inh.buscarxfichaxmuestra
                                        If Not inh Is Nothing Then
                                            continh = continh + 1
                                        End If
                                        inh = Nothing
                                    End If
                                    If csm.ESPORULADOS = 1 Then
                                        Dim esp As New dEsporulados
                                        esp.FICHA = csm.FICHA
                                        esp.MUESTRA = csm.MUESTRA
                                        esp = esp.buscarxfichaxmuestra
                                        If Not esp Is Nothing Then
                                            contesp = contesp + 1
                                        End If
                                        esp = Nothing
                                    End If
                                    If csm.PSICROTROFOS = 1 Then
                                        Dim psi As New dPsicrotrofos
                                        psi.FICHA = csm.FICHA
                                        psi.MUESTRA = csm.MUESTRA
                                        psi = psi.buscarxfichaxmuestra
                                        If Not psi Is Nothing Then
                                            contpsi = contpsi + 1
                                        End If
                                        psi = Nothing
                                    End If
                                Next
                            End If
                            listacsm = Nothing
                            csm = Nothing
                        End If
                        totalrc = totalrc + contrc
                        totalrb = totalrb + contrb
                        totalgr = totalgr + contgr
                        totalpr = totalpr + contpr
                        totallc = totallc + contlc
                        totalst = totalst + contst
                        totalcr = totalcr + contcr
                        totalur = totalur + contur
                        totalinh = totalinh + continh
                        totalesp = totalesp + contesp
                        totalpsi = totalpsi + contpsi


                        Linea = Linea & sa.ID & Chr(9)
                        Linea = Linea & sa.FECHAENVIO & Chr(9)
                        Linea = Linea & contrc & Chr(9)
                        Linea = Linea & contrb & Chr(9)
                        Linea = Linea & contgr & Chr(9)
                        Linea = Linea & contpr & Chr(9)
                        Linea = Linea & contlc & Chr(9)
                        Linea = Linea & contst & Chr(9)
                        Linea = Linea & contcr & Chr(9)
                        Linea = Linea & contur & Chr(9)
                        Linea = Linea & continh & Chr(9)
                        Linea = Linea & contesp & Chr(9)
                        Linea = Linea & contpsi & Chr(9)
                        oSW.WriteLine(Linea)
                        Linea = ""

                        contrc = 0
                        contrb = 0
                        contgr = 0
                        contpr = 0
                        contlc = 0
                        contst = 0
                        contcr = 0
                        contur = 0
                        continh = 0
                        contesp = 0
                        contpsi = 0
                        barracontadora = barracontadora + barracontadora2
                    Next
                    ProgressBar1.Value = 100

                    Linea = Linea & "Total" + Chr(9) + Chr(9)
                    Linea = Linea & Chr(9)
                    Linea = Linea & totalrc & Chr(9)
                    Linea = Linea & totalrb & Chr(9)
                    Linea = Linea & totalgr & Chr(9)
                    Linea = Linea & totalpr & Chr(9)
                    Linea = Linea & totallc & Chr(9)
                    Linea = Linea & totalst & Chr(9)
                    Linea = Linea & totalcr & Chr(9)
                    Linea = Linea & totalur & Chr(9)
                    Linea = Linea & totalinh & Chr(9)
                    Linea = Linea & totalesp & Chr(9)
                    Linea = Linea & totalpsi & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    Linea = Linea & "Timbres:" + " " & listasa.Count
                    oSW.WriteLine(Linea)
                    oSW.Flush()
                End If
                imprimio = True
            End If
            sa = Nothing
            listasa = Nothing
            barracontadora = 1
        End If
        If imprimio = False Then
            MsgBox("No se imprimieron los resultados", 0, "Archivo TXT")
        End If
        If imprimio = True Then
            MsgBox("Se imprimieron los resultados", 0, "Archivo TXT")
        End If
    End Function
    Private Function ImprimirAmbiental(ByVal archivo As String, ByVal idemp As Long)
        Dim oSW As New System.IO.StreamWriter(archivo)
        Dim Linea As String = ""
        Dim imprimio As Boolean = False
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "LA" + Chr(9) + "PSE" + Chr(9) + "ENT" + Chr(9) + "MO" + Chr(9) + "CO" + Chr(9) + "CF" + Chr(9) + "PS" + Chr(9) + "AN" + Chr(9) + "ME" + Chr(9) + "EC" + Chr(9) + "VO" + Chr(9) + "MO" + Chr(9) + "SA" + Chr(9) + "LE" + Chr(9) + "LI" + Chr(9) + "LI" + Chr(9) + "ES" + Chr(9) + "EC" + Chr(9) + "HI" + Chr(9) + "FR" + Chr(9) + "LI" + Chr(9) + "LI" + Chr(9) + "SA" + Chr(9) + "LI"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim cuentaanalisis As Integer = 0
        Dim barracontadora As Integer = 0
        Dim barracontadora2 As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = idemp
        Dim ficha As Long = 0

        Dim LISTERIAAMBIENTAL As Integer = 0
        Dim PSEUDOMONASPPPSEUDOMONAAUREGINOSA As Integer = 0
        Dim ENTEROBACTERIASAMBIENTALES As Integer = 0
        Dim MOHOSYLEVADURASAmbiental As Integer = 0
        Dim COLIFORMESTOTALESAMBIENTALES As Integer = 0
        Dim CFECALESAMBIENTALES As Integer = 0
        Dim PSEUDOMONAAMBIENTAL As Integer = 0
        Dim ANALISISTERCERIZADOSAMB As Integer = 0
        Dim MESOFILOSAMBIENTAL As Integer = 0
        Dim ECOLIMONAMBIENTAL As Integer = 0
        Dim VOUCHERAREAAMBIENTAL As Integer = 0
        Dim MOHOS As Integer = 0
        Dim SALMONELLASPPAislamiento As Integer = 0
        Dim LEVADURAS As Integer = 0
        Dim LISTERIASPPPalcamAislamiento As Integer = 0
        Dim LISTERIAMONOCYTOGENES As Integer = 0
        Dim ESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim EColiO157RevealSP As Integer = 0
        Dim HISOPOPARAAMBIENTAL As Integer = 0
        Dim FRASCOCONMEDIOPARAAMBIENTAL As Integer = 0
        Dim LISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim SALMONELLAConfirmacionenambientales As Integer = 0
        Dim LISTERIASPPPalcamConfirmacion As Integer = 0

        Dim TOTALLISTERIAAMBIENTAL As Integer = 0
        Dim TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA As Integer = 0
        Dim TOTALENTEROBACTERIASAMBIENTALES As Integer = 0
        Dim TOTALMOHOSYLEVADURASAmbiental As Integer = 0
        Dim TOTALCOLIFORMESTOTALESAMBIENTALES As Integer = 0
        Dim TOTALCFECALESAMBIENTALES As Integer = 0
        Dim TOTALPSEUDOMONAAMBIENTAL As Integer = 0
        Dim TOTALANALISISTERCERIZADOSAMB As Integer = 0
        Dim TOTALMESOFILOSAMBIENTAL As Integer = 0
        Dim TOTALECOLIMONAMBIENTAL As Integer = 0
        Dim TOTALVOUCHERAREAAMBIENTAL As Integer = 0
        Dim TOTALMOHOS As Integer = 0
        Dim TOTALSALMONELLASPPAislamiento As Integer = 0
        Dim TOTALLEVADURAS As Integer = 0
        Dim TOTALLISTERIASPPPalcamAislamiento As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENES As Integer = 0
        Dim TOTALESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim TOTALEColiO157RevealSP As Integer = 0
        Dim TOTALHISOPOPARAAMBIENTAL As Integer = 0
        Dim TOTALFRASCOCONMEDIOPARAAMBIENTAL As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim TOTALSALMONELLAConfirmacionenambientales As Integer = 0
        Dim TOTALLISTERIASPPPalcamConfirmacion As Integer = 0

        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim tipoInf As Integer = 0
        Dim cbxInforme As String
        Dim listo As Boolean = False
        cbxInforme = cbxTipoInforme.Text
        tipoInf = tipoInforme(cbxInforme)

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa, tipoInf)
        If listasa IsNot Nothing Then
            cuentaanalisis = listasa.Count
            barracontadora = 100 / cuentaanalisis
            barracontadora2 = 100 / cuentaanalisis
            DataGridViewAmbiental.Rows.Clear()
            Dim contador As Integer = 0
            contador = listasa.Count + 2
            DataGridViewAmbiental.Rows.Add(contador)
            If Not listasa Is Nothing Then
                If listasa.Count > 0 Then
                    For Each sa In listasa
                        If barracontadora <= 100 Then
                            ProgressBar1.Value = barracontadora
                        End If
                        Dim analisis As New dNuevoAnalisis
                        Dim listaRes As New ArrayList
                        ficha = sa.ID
                        listaRes = analisis.listarporid(ficha)
                        If Not listaRes Is Nothing Then
                            If listaRes.Count > 0 Then
                                For Each analisis In listaRes
                                    Select Case analisis.ANALISIS
                                        Case 26
                                            LISTERIAAMBIENTAL = LISTERIAAMBIENTAL + 1
                                        Case 81
                                            PSEUDOMONASPPPSEUDOMONAAUREGINOSA = PSEUDOMONASPPPSEUDOMONAAUREGINOSA + 1
                                        Case 122
                                            ENTEROBACTERIASAMBIENTALES = ENTEROBACTERIASAMBIENTALES + 1
                                        Case 123
                                            MOHOSYLEVADURASAmbiental = MOHOSYLEVADURASAmbiental + 1
                                        Case 151
                                            COLIFORMESTOTALESAMBIENTALES = COLIFORMESTOTALESAMBIENTALES + 1
                                        Case 152
                                            CFECALESAMBIENTALES = CFECALESAMBIENTALES + 1
                                        Case 153
                                            PSEUDOMONAAMBIENTAL = PSEUDOMONAAMBIENTAL + 1
                                        Case 216
                                            ANALISISTERCERIZADOSAMB = ANALISISTERCERIZADOSAMB + 1
                                        Case 228
                                            MESOFILOSAMBIENTAL = MESOFILOSAMBIENTAL + 1
                                        Case 251
                                            ECOLIMONAMBIENTAL = ECOLIMONAMBIENTAL + 1
                                        Case 339
                                            VOUCHERAREAAMBIENTAL = VOUCHERAREAAMBIENTAL + 1
                                        Case 364
                                            MOHOS = MOHOS + 1
                                        Case 357
                                            SALMONELLASPPAislamiento = SALMONELLASPPAislamiento + 1
                                        Case 365
                                            LEVADURAS = LEVADURAS + 1
                                        Case 361
                                            LISTERIASPPPalcamAislamiento = LISTERIASPPPalcamAislamiento + 1
                                        Case 362
                                            LISTERIAMONOCYTOGENES = LISTERIAMONOCYTOGENES + 1
                                        Case 363
                                            ESTAFILOCOCOCOAGULASAPOSITIVO = ESTAFILOCOCOCOAGULASAPOSITIVO + 1
                                        Case 383
                                            EColiO157RevealSP = EColiO157RevealSP + 1
                                        Case 415
                                            HISOPOPARAAMBIENTAL = HISOPOPARAAMBIENTAL + 1
                                        Case 416
                                            FRASCOCONMEDIOPARAAMBIENTAL = FRASCOCONMEDIOPARAAMBIENTAL + 1
                                        Case 418
                                            LISTERIAMONOCYTOGENESPCR = LISTERIAMONOCYTOGENESPCR + 1
                                        Case 419
                                            TOTALLISTERIAMONOCYTOGENESPOOLPCR = TOTALLISTERIAMONOCYTOGENESPOOLPCR + 1
                                        Case 421
                                            SALMONELLAConfirmacionenambientales = SALMONELLAConfirmacionenambientales + 1
                                        Case 430
                                            LISTERIASPPPalcamConfirmacion = LISTERIASPPPalcamConfirmacion + 1
                                    End Select
                                Next
                            End If
                            listaRes = Nothing
                            analisis = Nothing
                        End If

                        TOTALLISTERIAAMBIENTAL = TOTALLISTERIAAMBIENTAL + LISTERIAAMBIENTAL
                        TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA = TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA + PSEUDOMONASPPPSEUDOMONAAUREGINOSA
                        TOTALENTEROBACTERIASAMBIENTALES = TOTALENTEROBACTERIASAMBIENTALES + ENTEROBACTERIASAMBIENTALES
                        TOTALMOHOSYLEVADURASAmbiental = TOTALMOHOSYLEVADURASAmbiental + MOHOSYLEVADURASAmbiental
                        TOTALCOLIFORMESTOTALESAMBIENTALES = TOTALCOLIFORMESTOTALESAMBIENTALES + COLIFORMESTOTALESAMBIENTALES
                        TOTALCFECALESAMBIENTALES = TOTALCFECALESAMBIENTALES + CFECALESAMBIENTALES
                        TOTALPSEUDOMONAAMBIENTAL = TOTALPSEUDOMONAAMBIENTAL + PSEUDOMONAAMBIENTAL
                        TOTALANALISISTERCERIZADOSAMB = TOTALANALISISTERCERIZADOSAMB + ANALISISTERCERIZADOSAMB
                        TOTALMESOFILOSAMBIENTAL = TOTALMESOFILOSAMBIENTAL + MESOFILOSAMBIENTAL
                        TOTALECOLIMONAMBIENTAL = TOTALECOLIMONAMBIENTAL + ECOLIMONAMBIENTAL
                        TOTALVOUCHERAREAAMBIENTAL = TOTALVOUCHERAREAAMBIENTAL + VOUCHERAREAAMBIENTAL
                        TOTALMOHOS = TOTALMOHOS + MOHOS
                        TOTALSALMONELLASPPAislamiento = TOTALSALMONELLASPPAislamiento + SALMONELLASPPAislamiento
                        TOTALLEVADURAS = TOTALLEVADURAS + LEVADURAS
                        TOTALLISTERIASPPPalcamAislamiento = TOTALLISTERIASPPPalcamAislamiento + LISTERIASPPPalcamAislamiento
                        TOTALLISTERIAMONOCYTOGENES = TOTALLISTERIAMONOCYTOGENES + LISTERIAMONOCYTOGENES
                        TOTALESTAFILOCOCOCOAGULASAPOSITIVO = TOTALESTAFILOCOCOCOAGULASAPOSITIVO + ESTAFILOCOCOCOAGULASAPOSITIVO
                        TOTALEColiO157RevealSP = TOTALEColiO157RevealSP + EColiO157RevealSP
                        TOTALHISOPOPARAAMBIENTAL = TOTALHISOPOPARAAMBIENTAL + HISOPOPARAAMBIENTAL
                        TOTALFRASCOCONMEDIOPARAAMBIENTAL = TOTALFRASCOCONMEDIOPARAAMBIENTAL + FRASCOCONMEDIOPARAAMBIENTAL
                        TOTALLISTERIAMONOCYTOGENESPCR = TOTALLISTERIAMONOCYTOGENESPCR + LISTERIAMONOCYTOGENESPCR
                        TOTALLISTERIAMONOCYTOGENESPOOLPCR = TOTALLISTERIAMONOCYTOGENESPOOLPCR + LISTERIAMONOCYTOGENESPOOLPCR
                        TOTALSALMONELLAConfirmacionenambientales = TOTALSALMONELLAConfirmacionenambientales + SALMONELLAConfirmacionenambientales
                        TOTALLISTERIASPPPalcamConfirmacion = TOTALLISTERIASPPPalcamConfirmacion + LISTERIASPPPalcamConfirmacion


                        Linea = Linea & sa.ID & Chr(9)
                        Linea = Linea & sa.FECHAENVIO & Chr(9)
                        Linea = Linea & LISTERIAAMBIENTAL & Chr(9)
                        Linea = Linea & PSEUDOMONASPPPSEUDOMONAAUREGINOSA & Chr(9)
                        Linea = Linea & ENTEROBACTERIASAMBIENTALES & Chr(9)
                        Linea = Linea & MOHOSYLEVADURASAmbiental & Chr(9)
                        Linea = Linea & COLIFORMESTOTALESAMBIENTALES & Chr(9)
                        Linea = Linea & CFECALESAMBIENTALES & Chr(9)
                        Linea = Linea & PSEUDOMONAAMBIENTAL & Chr(9)
                        Linea = Linea & ANALISISTERCERIZADOSAMB & Chr(9)
                        Linea = Linea & MESOFILOSAMBIENTAL & Chr(9)
                        Linea = Linea & ECOLIMONAMBIENTAL & Chr(9)
                        Linea = Linea & VOUCHERAREAAMBIENTAL & Chr(9)
                        Linea = Linea & MOHOS & Chr(9)
                        Linea = Linea & SALMONELLASPPAislamiento & Chr(9)
                        Linea = Linea & LEVADURAS & Chr(9)
                        Linea = Linea & LISTERIASPPPalcamAislamiento & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENES & Chr(9)
                        Linea = Linea & ESTAFILOCOCOCOAGULASAPOSITIVO & Chr(9)
                        Linea = Linea & EColiO157RevealSP & Chr(9)
                        Linea = Linea & HISOPOPARAAMBIENTAL & Chr(9)
                        Linea = Linea & FRASCOCONMEDIOPARAAMBIENTAL & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESPCR & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESPOOLPCR & Chr(9)
                        Linea = Linea & SALMONELLAConfirmacionenambientales & Chr(9)
                        Linea = Linea & LISTERIASPPPalcamConfirmacion & Chr(9)
                        oSW.WriteLine(Linea)
                        Linea = ""

                        LISTERIAAMBIENTAL = 0
                        PSEUDOMONASPPPSEUDOMONAAUREGINOSA = 0
                        ENTEROBACTERIASAMBIENTALES = 0
                        MOHOSYLEVADURASAmbiental = 0
                        COLIFORMESTOTALESAMBIENTALES = 0
                        CFECALESAMBIENTALES = 0
                        PSEUDOMONAAMBIENTAL = 0
                        ANALISISTERCERIZADOSAMB = 0
                        MESOFILOSAMBIENTAL = 0
                        ECOLIMONAMBIENTAL = 0
                        VOUCHERAREAAMBIENTAL = 0
                        MOHOS = 0
                        SALMONELLASPPAislamiento = 0
                        LEVADURAS = 0
                        LISTERIASPPPalcamAislamiento = 0
                        LISTERIAMONOCYTOGENES = 0
                        ESTAFILOCOCOCOAGULASAPOSITIVO = 0
                        EColiO157RevealSP = 0
                        HISOPOPARAAMBIENTAL = 0
                        FRASCOCONMEDIOPARAAMBIENTAL = 0
                        LISTERIAMONOCYTOGENESPCR = 0
                        LISTERIAMONOCYTOGENESPOOLPCR = 0
                        SALMONELLAConfirmacionenambientales = 0
                        LISTERIASPPPalcamConfirmacion = 0

                        barracontadora = barracontadora + barracontadora2
                    Next
                    ProgressBar1.Value = 100

                    Linea = Linea & "Total" + Chr(9) + Chr(9)
                    Linea = Linea & Chr(9)
                    Linea = Linea & TOTALLISTERIAAMBIENTAL & Chr(9)
                    Linea = Linea & TOTALPSEUDOMONASPPPSEUDOMONAAUREGINOSA & Chr(9)
                    Linea = Linea & TOTALENTEROBACTERIASAMBIENTALES & Chr(9)
                    Linea = Linea & TOTALMOHOSYLEVADURASAmbiental & Chr(9)
                    Linea = Linea & TOTALCOLIFORMESTOTALESAMBIENTALES & Chr(9)
                    Linea = Linea & TOTALCFECALESAMBIENTALES & Chr(9)
                    Linea = Linea & TOTALPSEUDOMONAAMBIENTAL & Chr(9)
                    Linea = Linea & TOTALANALISISTERCERIZADOSAMB & Chr(9)
                    Linea = Linea & TOTALMESOFILOSAMBIENTAL & Chr(9)
                    Linea = Linea & TOTALECOLIMONAMBIENTAL & Chr(9)
                    Linea = Linea & TOTALVOUCHERAREAAMBIENTAL & Chr(9)
                    Linea = Linea & TOTALMOHOS & Chr(9)
                    Linea = Linea & TOTALSALMONELLASPPAislamiento & Chr(9)
                    Linea = Linea & TOTALLEVADURAS & Chr(9)
                    Linea = Linea & TOTALLISTERIASPPPalcamAislamiento & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENES & Chr(9)
                    Linea = Linea & TOTALESTAFILOCOCOCOAGULASAPOSITIVO & Chr(9)
                    Linea = Linea & TOTALEColiO157RevealSP & Chr(9)
                    Linea = Linea & TOTALHISOPOPARAAMBIENTAL & Chr(9)
                    Linea = Linea & TOTALFRASCOCONMEDIOPARAAMBIENTAL & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESPCR & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESPOOLPCR & Chr(9)
                    Linea = Linea & TOTALSALMONELLAConfirmacionenambientales & Chr(9)
                    Linea = Linea & TOTALLISTERIASPPPalcamConfirmacion & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    Linea = Linea & "Timbres:" + " " & listasa.Count
                    oSW.WriteLine(Linea)
                    oSW.Flush()
                End If
                imprimio = True
            End If
            sa = Nothing
            listasa = Nothing
            barracontadora = 1
        End If
        If imprimio = False Then
            MsgBox("No se imprimieron los resultados", 0, "Archivo TXT")
        End If
        If imprimio = True Then
            MsgBox("Se imprimieron los resultados", 0, "Archivo TXT")
        End If
    End Function
    Private Function ImprimirAlimentos(ByVal archivo As String, ByVal idemp As Long)
        Dim oSW As New System.IO.StreamWriter(archivo)
        Dim Linea As String = ""
        Dim imprimio As Boolean = False
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "EN" + Chr(9) + "CL" + Chr(9) + "EC" + Chr(9) + "ES" + Chr(9) + "SA" + Chr(9) + "MO" + Chr(9) + "SO" + Chr(9) + "MA" + Chr(9) + "pH" + Chr(9) + "PR" + Chr(9) + "Te" + Chr(9) + "CE" + Chr(9) + "Ni" + Chr(9) + "CO" + Chr(9) + "CO" + Chr(9) + "P1" + Chr(9) + "P2" + Chr(9) + "P3" + Chr(9) + "LI" + Chr(9) + "CO" + Chr(9) + "EC" + Chr(9) + "MA" + Chr(9) + "PR" + Chr(9) + "Pr" + Chr(9) + "AN" + Chr(9) + "P4" + Chr(9) + "LI" + Chr(9) + "SA" + Chr(9) + "BA" + Chr(9) + "BA" + Chr(9) + "ME" + Chr(9) + "EC" + Chr(9) + "LE" + Chr(9) + "LI" + Chr(9) + "SA" + Chr(9) + "SA" + Chr(9) + "AC" + Chr(9) + "CL" + Chr(9) + "SA" + Chr(9) + "SA" + Chr(9) + "LI" + Chr(9) + "LI" + Chr(9) + "P5" + Chr(9) + "Ca" + Chr(9) + "En" + Chr(9) + "LA" + Chr(9) + "CO" + Chr(9) + "En" + Chr(9) + "EL" + Chr(9) + "SA" + Chr(9) + "En"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim cuentaanalisis As Integer = 0
        Dim barracontadora As Integer = 0
        Dim barracontadora2 As Integer = 0

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = idemp
        Dim ficha As Long = 0

        Dim ENTEROBACTERIAS As Integer = 0
        Dim CLORURODESODIO As Integer = 0
        Dim ECOLICOLIFORMESTOTALES35 As Integer = 0
        Dim ESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim SALMONELLASPPAislamiento As Integer = 0
        Dim MOHOSLEVADURAS As Integer = 0
        Dim SOLIDOSTOTALESHUMEDAD As Integer = 0
        Dim MATERIAGRASAVanGulik As Integer = 0
        Dim pH As Integer = 0
        Dim PROTEINATOTALxDUMAS As Integer = 0
        Dim TermofilosSP As Integer = 0
        Dim CENIZASTOTALES As Integer = 0
        Dim Nitrato As Integer = 0
        Dim COLIFORMESTOTALES As Integer = 0
        Dim COLIFORMESFECALES As Integer = 0
        Dim Paq1 As Integer = 0
        Dim Paq2 As Integer = 0
        Dim Paq3 As Integer = 0
        Dim LISTERIAMONOCYTOGENESAislamiento As Integer = 0
        Dim COMPOSICIONENSUERO As Integer = 0
        Dim EColiO157RevealSP As Integer = 0
        Dim MATERIAGRASAporROSEGOTTLIEB As Integer = 0
        Dim PROTEINATOTALNITROGENOxKJELDAHL As Integer = 0
        Dim ProteinaTotalporDUMAS5muestrasomás As Integer = 0
        Dim ANALISISTERCERIZADOSBROMAT As Integer = 0
        Dim Paq4 As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento As Integer = 0
        Dim SALMONELLASPPPOOL5MUESTRASAislamiento As Integer = 0
        Dim BACTERIASACIDOLACTICAS As Integer = 0
        Dim BACILLUSCEREUS As Integer = 0
        Dim MESÓFILOSRB As Integer = 0
        Dim ECOLIconpaq As Integer = 0
        Dim LEVADURAS As Integer = 0
        Dim LISTERIASPP As Integer = 0
        Dim MOHOS As Integer = 0
        Dim LISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim SALMONELLASPPPCR As Integer = 0
        Dim SALMONELLASPPPOOLPCR As Integer = 0
        Dim ACIDEZ As Integer = 0
        Dim CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO As Integer = 0
        Dim SALMONELLAConfirmacionenAlimentos As Integer = 0
        Dim SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos As Integer = 0
        Dim LISTERIAMONOCYTOGENESConfirmacionenalimentos As Integer = 0
        Dim LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion As Integer = 0
        Dim Paq5 As Integer = 0
        Dim Carbohidratos As Integer = 0
        Dim Energía As Integer = 0
        Dim LACTOSA As Integer = 0
        Dim CONDUCTIVIDADAlimentos As Integer = 0
        Dim EnvioaotrosLaboratoriosBromatologia As Integer = 0

        Dim TOTALENTEROBACTERIAS As Integer = 0
        Dim TOTALCLORURODESODIO As Integer = 0
        Dim TOTALECOLICOLIFORMESTOTALES35 As Integer = 0
        Dim TOTALESTAFILOCOCOCOAGULASAPOSITIVO As Integer = 0
        Dim TOTALSALMONELLASPPAislamiento As Integer = 0
        Dim TOTALMOHOSLEVADURAS As Integer = 0
        Dim TOTALSOLIDOSTOTALESHUMEDAD As Integer = 0
        Dim TOTALMATERIAGRASAVanGulik As Integer = 0
        Dim TOTALpH As Integer = 0
        Dim TOTALPROTEINATOTALxDUMAS As Integer = 0
        Dim TOTALTermofilosSP As Integer = 0
        Dim TOTALCENIZASTOTALES As Integer = 0
        Dim TOTALNitrato As Integer = 0
        Dim TOTALCOLIFORMESTOTALES As Integer = 0
        Dim TOTALCOLIFORMESFECALES As Integer = 0
        Dim TOTALPaq1 As Integer = 0
        Dim TOTALPaq2 As Integer = 0
        Dim TOTALPaq3 As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESAislamiento As Integer = 0
        Dim TOTALCOMPOSICIONENSUERO As Integer = 0
        Dim TOTALEColiO157RevealSP As Integer = 0
        Dim TOTALMATERIAGRASAporROSEGOTTLIEB As Integer = 0
        Dim TOTALPROTEINATOTALNITROGENOxKJELDAHL As Integer = 0
        Dim TOTALProteinaTotalporDUMAS5muestrasomás As Integer = 0
        Dim TOTALANALISISTERCERIZADOSBROMAT As Integer = 0
        Dim TOTALPaq4 As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento As Integer = 0
        Dim TOTALSALMONELLASPPPOOL5MUESTRASAislamiento As Integer = 0
        Dim TOTALBACTERIASACIDOLACTICAS As Integer = 0
        Dim TOTALBACILLUSCEREUS As Integer = 0
        Dim TOTALMESÓFILOSRB As Integer = 0
        Dim TOTALECOLIconpaq As Integer = 0
        Dim TOTALLEVADURAS As Integer = 0
        Dim TOTALLISTERIASPP As Integer = 0
        Dim TOTALMOHOS As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPCR As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOLPCR As Integer = 0
        Dim TOTALSALMONELLASPPPCR As Integer = 0
        Dim TOTALSALMONELLASPPPOOLPCR As Integer = 0
        Dim TOTALACIDEZ As Integer = 0
        Dim TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO As Integer = 0
        Dim TOTALSALMONELLAConfirmacionenAlimentos As Integer = 0
        Dim TOTALSALMONELLAPOOL5MUESTRASConfirmacionenAlimentos As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos As Integer = 0
        Dim TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion As Integer = 0
        Dim TOTALPaq5 As Integer = 0
        Dim TOTALCarbohidratos As Integer = 0
        Dim TOTALEnergía As Integer = 0
        Dim TOTALLACTOSA As Integer = 0
        Dim TOTALCONDUCTIVIDADAlimentos As Integer = 0
        Dim TOTALEnvioaotrosLaboratoriosBromatologia As Integer = 0


        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim tipoInf As Integer = 0
        Dim cbxInforme As String
        Dim listo As Boolean = False
        cbxInforme = cbxTipoInforme.Text
        tipoInf = tipoInforme(cbxInforme)

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa, tipoInf)
        If listasa IsNot Nothing Then
            cuentaanalisis = listasa.Count
            barracontadora = 100 / cuentaanalisis
            barracontadora2 = 100 / cuentaanalisis
            DataGridViewAlimentos.Rows.Clear()
            Dim contador As Integer = 0
            contador = listasa.Count + 2
            DataGridViewAlimentos.Rows.Add(contador)
            If Not listasa Is Nothing Then
                If listasa.Count > 0 Then
                    For Each sa In listasa
                        If barracontadora <= 100 Then
                            ProgressBar1.Value = barracontadora
                        End If
                        Dim analisis As New dNuevoAnalisis
                        Dim listaRes As New ArrayList
                        ficha = sa.ID
                        listaRes = analisis.listarporid(ficha)
                        If Not listaRes Is Nothing Then
                            If listaRes.Count > 0 Then
                                For Each analisis In listaRes
                                    Select Case analisis.ANALISIS
                                        Case 9
                                            ENTEROBACTERIAS = ENTEROBACTERIAS + 1
                                        Case 10
                                            CLORURODESODIO = CLORURODESODIO + 1
                                        Case 23
                                            ECOLICOLIFORMESTOTALES35 = ECOLICOLIFORMESTOTALES35 + 1
                                        Case 24
                                            ESTAFILOCOCOCOAGULASAPOSITIVO = ESTAFILOCOCOCOAGULASAPOSITIVO + 1
                                        Case 27
                                            SALMONELLASPPAislamiento = SALMONELLASPPAislamiento + 1
                                        Case 28
                                            MOHOSLEVADURAS = MOHOSLEVADURAS + 1
                                        Case 29
                                            SOLIDOSTOTALESHUMEDAD = SOLIDOSTOTALESHUMEDAD + 1
                                        Case 30
                                            MATERIAGRASAVanGulik = MATERIAGRASAVanGulik + 1
                                        Case 31
                                            pH = pH + 1
                                        Case 32
                                            PROTEINATOTALxDUMAS = PROTEINATOTALxDUMAS + 1
                                        Case 62
                                            TermofilosSP = TermofilosSP + 1
                                        Case 64
                                            CENIZASTOTALES = CENIZASTOTALES + 1
                                        Case 76
                                            Nitrato = Nitrato + 1
                                        Case 83
                                            COLIFORMESTOTALES = COLIFORMESTOTALES + 1
                                        Case 84
                                            COLIFORMESFECALES = COLIFORMESFECALES + 1
                                        Case 94
                                            Paq1 = Paq1 + 1
                                        Case 95
                                            Paq2 = Paq2 + 1
                                        Case 96
                                            Paq3 = Paq3 + 1
                                        Case 141
                                            LISTERIAMONOCYTOGENESAislamiento = LISTERIAMONOCYTOGENESAislamiento + 1
                                        Case 154
                                            COMPOSICIONENSUERO = COMPOSICIONENSUERO + 1
                                        Case 185
                                            EColiO157RevealSP = EColiO157RevealSP + 1
                                        Case 186
                                            MATERIAGRASAporROSEGOTTLIEB = MATERIAGRASAporROSEGOTTLIEB + 1
                                        Case 187
                                            PROTEINATOTALNITROGENOxKJELDAHL = PROTEINATOTALNITROGENOxKJELDAHL + 1
                                        Case 188
                                            ProteinaTotalporDUMAS5muestrasomás = ProteinaTotalporDUMAS5muestrasomás + 1
                                        Case 217
                                            ANALISISTERCERIZADOSBROMAT = ANALISISTERCERIZADOSBROMAT + 1
                                        Case 230
                                            Paq4 = Paq4 + 1
                                        Case 231
                                            LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento = LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento + 1
                                        Case 232
                                            SALMONELLASPPPOOL5MUESTRASAislamiento = SALMONELLASPPPOOL5MUESTRASAislamiento + 1
                                        Case 248
                                            BACTERIASACIDOLACTICAS = BACTERIASACIDOLACTICAS + 1
                                        Case 249
                                            BACILLUSCEREUS = BACILLUSCEREUS + 1
                                        Case 336
                                            MESÓFILOSRB = MESÓFILOSRB + 1
                                        Case 337
                                            ECOLIconpaq = ECOLIconpaq + 1
                                        Case 346
                                            LEVADURAS = LEVADURAS + 1
                                        Case 347
                                            LISTERIASPP = LISTERIASPP + 1
                                        Case 349
                                            MOHOS = MOHOS + 1
                                        Case 402
                                            LISTERIAMONOCYTOGENESPCR = LISTERIAMONOCYTOGENESPCR + 1
                                        Case 403
                                            LISTERIAMONOCYTOGENESPOOLPCR = LISTERIAMONOCYTOGENESPOOLPCR + 1
                                        Case 404
                                            SALMONELLASPPPCR = SALMONELLASPPPCR + 1
                                        Case 405
                                            SALMONELLASPPPOOLPCR = SALMONELLASPPPOOLPCR + 1
                                        Case 413
                                            ACIDEZ = ACIDEZ + 1
                                        Case 414
                                            CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO = CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO + 1
                                        Case 422
                                            SALMONELLAConfirmacionenAlimentos = SALMONELLAConfirmacionenAlimentos + 1
                                        Case 423
                                            SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos = SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos + 1
                                        Case 424
                                            LISTERIAMONOCYTOGENESConfirmacionenalimentos = LISTERIAMONOCYTOGENESConfirmacionenalimentos + 1
                                        Case 425
                                            LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion = LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion + 1
                                        Case 426
                                            Paq5 = Paq5 + 1
                                        Case 433
                                            Carbohidratos = Carbohidratos + 1
                                        Case 434
                                            Energía = Energía + 1
                                        Case 435
                                            LACTOSA = LACTOSA + 1
                                        Case 436
                                            CONDUCTIVIDADAlimentos = CONDUCTIVIDADAlimentos + 1
                                        Case 437
                                            EnvioaotrosLaboratoriosBromatologia = EnvioaotrosLaboratoriosBromatologia + 1
                                    End Select
                                Next
                            End If
                            listaRes = Nothing
                            analisis = Nothing
                        End If

                        TOTALENTEROBACTERIAS = TOTALENTEROBACTERIAS + ENTEROBACTERIAS
                        TOTALCLORURODESODIO = TOTALCLORURODESODIO + CLORURODESODIO
                        TOTALECOLICOLIFORMESTOTALES35 = TOTALECOLICOLIFORMESTOTALES35 + ECOLICOLIFORMESTOTALES35
                        TOTALESTAFILOCOCOCOAGULASAPOSITIVO = TOTALESTAFILOCOCOCOAGULASAPOSITIVO + ESTAFILOCOCOCOAGULASAPOSITIVO
                        TOTALSALMONELLASPPAislamiento = TOTALSALMONELLASPPAislamiento + SALMONELLASPPAislamiento
                        TOTALMOHOSLEVADURAS = TOTALMOHOSLEVADURAS + MOHOSLEVADURAS
                        TOTALSOLIDOSTOTALESHUMEDAD = TOTALSOLIDOSTOTALESHUMEDAD + SOLIDOSTOTALESHUMEDAD
                        TOTALMATERIAGRASAVanGulik = TOTALMATERIAGRASAVanGulik + MATERIAGRASAVanGulik
                        TOTALpH = TOTALpH + pH
                        TOTALPROTEINATOTALxDUMAS = TOTALPROTEINATOTALxDUMAS + PROTEINATOTALxDUMAS
                        TOTALTermofilosSP = TOTALTermofilosSP + TermofilosSP
                        TOTALCENIZASTOTALES = TOTALCENIZASTOTALES + CENIZASTOTALES
                        TOTALNitrato = TOTALNitrato + Nitrato
                        TOTALCOLIFORMESTOTALES = TOTALCOLIFORMESTOTALES + COLIFORMESTOTALES
                        TOTALCOLIFORMESFECALES = TOTALCOLIFORMESFECALES + COLIFORMESFECALES
                        TOTALPaq1 = TOTALPaq1 + Paq1
                        TOTALPaq2 = TOTALPaq2 + Paq2
                        TOTALPaq3 = TOTALPaq3 + Paq3
                        TOTALLISTERIAMONOCYTOGENESAislamiento = TOTALLISTERIAMONOCYTOGENESAislamiento + LISTERIAMONOCYTOGENESAislamiento
                        TOTALCOMPOSICIONENSUERO = TOTALCOMPOSICIONENSUERO + COMPOSICIONENSUERO
                        TOTALEColiO157RevealSP = TOTALEColiO157RevealSP + EColiO157RevealSP
                        TOTALMATERIAGRASAporROSEGOTTLIEB = TOTALMATERIAGRASAporROSEGOTTLIEB + MATERIAGRASAporROSEGOTTLIEB
                        TOTALPROTEINATOTALNITROGENOxKJELDAHL = TOTALPROTEINATOTALNITROGENOxKJELDAHL + PROTEINATOTALNITROGENOxKJELDAHL
                        TOTALProteinaTotalporDUMAS5muestrasomás = TOTALProteinaTotalporDUMAS5muestrasomás + ProteinaTotalporDUMAS5muestrasomás
                        TOTALANALISISTERCERIZADOSBROMAT = TOTALANALISISTERCERIZADOSBROMAT + ANALISISTERCERIZADOSBROMAT
                        TOTALPaq4 = TOTALPaq4 + Paq4
                        TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento = TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento + LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento
                        TOTALSALMONELLASPPPOOL5MUESTRASAislamiento = TOTALSALMONELLASPPPOOL5MUESTRASAislamiento + SALMONELLASPPPOOL5MUESTRASAislamiento
                        TOTALBACTERIASACIDOLACTICAS = TOTALBACTERIASACIDOLACTICAS + BACTERIASACIDOLACTICAS
                        TOTALBACILLUSCEREUS = TOTALBACILLUSCEREUS + BACILLUSCEREUS
                        TOTALMESÓFILOSRB = TOTALMESÓFILOSRB + MESÓFILOSRB
                        TOTALECOLIconpaq = TOTALECOLIconpaq + ECOLIconpaq
                        TOTALLEVADURAS = TOTALLEVADURAS + LEVADURAS
                        TOTALLISTERIASPP = TOTALLISTERIASPP + LISTERIASPP
                        TOTALMOHOS = TOTALMOHOS + MOHOS
                        TOTALLISTERIAMONOCYTOGENESPCR = TOTALLISTERIAMONOCYTOGENESPCR + LISTERIAMONOCYTOGENESPCR
                        TOTALLISTERIAMONOCYTOGENESPOOLPCR = TOTALLISTERIAMONOCYTOGENESPOOLPCR + LISTERIAMONOCYTOGENESPOOLPCR
                        TOTALSALMONELLASPPPCR = TOTALSALMONELLASPPPCR + SALMONELLASPPPCR
                        TOTALSALMONELLASPPPOOLPCR = TOTALSALMONELLASPPPOOLPCR + SALMONELLASPPPOOLPCR
                        TOTALACIDEZ = TOTALACIDEZ + ACIDEZ
                        TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO = TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO + CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO
                        TOTALSALMONELLAConfirmacionenAlimentos = TOTALSALMONELLAConfirmacionenAlimentos + SALMONELLAConfirmacionenAlimentos
                        TOTALSALMONELLAPOOL5MUESTRASConfirmacionenAlimentos = TOTALSALMONELLAPOOL5MUESTRASConfirmacionenAlimentos + SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos
                        TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos = TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos + LISTERIAMONOCYTOGENESConfirmacionenalimentos
                        TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion = TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion + LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion
                        TOTALPaq5 = TOTALPaq5 + Paq5
                        TOTALCarbohidratos = TOTALCarbohidratos + Carbohidratos
                        TOTALEnergía = TOTALEnergía + Energía
                        TOTALLACTOSA = TOTALLACTOSA + LACTOSA
                        TOTALCONDUCTIVIDADAlimentos = TOTALCONDUCTIVIDADAlimentos + CONDUCTIVIDADAlimentos
                        TOTALEnvioaotrosLaboratoriosBromatologia = TOTALEnvioaotrosLaboratoriosBromatologia + EnvioaotrosLaboratoriosBromatologia


                        Linea = Linea & sa.ID & Chr(9)
                        Linea = Linea & sa.FECHAENVIO & Chr(9)
                        Linea = Linea & ENTEROBACTERIAS & Chr(9)
                        Linea = Linea & CLORURODESODIO & Chr(9)
                        Linea = Linea & ECOLICOLIFORMESTOTALES35 & Chr(9)
                        Linea = Linea & ESTAFILOCOCOCOAGULASAPOSITIVO & Chr(9)
                        Linea = Linea & SALMONELLASPPAislamiento & Chr(9)
                        Linea = Linea & MOHOSLEVADURAS & Chr(9)
                        Linea = Linea & SOLIDOSTOTALESHUMEDAD & Chr(9)
                        Linea = Linea & MATERIAGRASAVanGulik & Chr(9)
                        Linea = Linea & pH & Chr(9)
                        Linea = Linea & PROTEINATOTALxDUMAS & Chr(9)
                        Linea = Linea & TermofilosSP & Chr(9)
                        Linea = Linea & CENIZASTOTALES & Chr(9)
                        Linea = Linea & Nitrato & Chr(9)
                        Linea = Linea & COLIFORMESTOTALES & Chr(9)
                        Linea = Linea & COLIFORMESFECALES & Chr(9)
                        Linea = Linea & Paq1 & Chr(9)
                        Linea = Linea & Paq2 & Chr(9)
                        Linea = Linea & Paq3 & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESAislamiento & Chr(9)
                        Linea = Linea & COMPOSICIONENSUERO & Chr(9)
                        Linea = Linea & EColiO157RevealSP & Chr(9)
                        Linea = Linea & MATERIAGRASAporROSEGOTTLIEB & Chr(9)
                        Linea = Linea & PROTEINATOTALNITROGENOxKJELDAHL & Chr(9)
                        Linea = Linea & ProteinaTotalporDUMAS5muestrasomás & Chr(9)
                        Linea = Linea & ANALISISTERCERIZADOSBROMAT & Chr(9)
                        Linea = Linea & Paq4 & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento & Chr(9)
                        Linea = Linea & SALMONELLASPPPOOL5MUESTRASAislamiento & Chr(9)
                        Linea = Linea & BACTERIASACIDOLACTICAS & Chr(9)
                        Linea = Linea & BACILLUSCEREUS & Chr(9)
                        Linea = Linea & MESÓFILOSRB & Chr(9)
                        Linea = Linea & ECOLIconpaq & Chr(9)
                        Linea = Linea & LEVADURAS & Chr(9)
                        Linea = Linea & LISTERIASPP & Chr(9)
                        Linea = Linea & MOHOS & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESPCR & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESPOOLPCR & Chr(9)
                        Linea = Linea & SALMONELLASPPPCR & Chr(9)
                        Linea = Linea & SALMONELLASPPPOOLPCR & Chr(9)
                        Linea = Linea & ACIDEZ & Chr(9)
                        Linea = Linea & CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO & Chr(9)
                        Linea = Linea & SALMONELLAConfirmacionenAlimentos & Chr(9)
                        Linea = Linea & SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESConfirmacionenalimentos & Chr(9)
                        Linea = Linea & LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion & Chr(9)
                        Linea = Linea & Paq5 & Chr(9)
                        Linea = Linea & Carbohidratos & Chr(9)
                        Linea = Linea & Energía & Chr(9)
                        Linea = Linea & LACTOSA & Chr(9)
                        Linea = Linea & CONDUCTIVIDADAlimentos & Chr(9)
                        Linea = Linea & EnvioaotrosLaboratoriosBromatologia & Chr(9)
                        oSW.WriteLine(Linea)
                        Linea = ""

                        ENTEROBACTERIAS = 0

                        CLORURODESODIO = 0

                        ECOLICOLIFORMESTOTALES35 = 0

                        ESTAFILOCOCOCOAGULASAPOSITIVO = 0

                        SALMONELLASPPAislamiento = 0

                        MOHOSLEVADURAS = 0

                        SOLIDOSTOTALESHUMEDAD = 0

                        MATERIAGRASAVanGulik = 0

                        pH = 0

                        PROTEINATOTALxDUMAS = 0

                        TermofilosSP = 0

                        CENIZASTOTALES = 0

                        Nitrato = 0

                        COLIFORMESTOTALES = 0

                        COLIFORMESFECALES = 0

                        Paq1 = 0

                        Paq2 = 0

                        Paq3 = 0

                        LISTERIAMONOCYTOGENESAislamiento = 0

                        COMPOSICIONENSUERO = 0

                        EColiO157RevealSP = 0

                        LISTERIAMONOCYTOGENESPOOLPCR = 0

                        MATERIAGRASAporROSEGOTTLIEB = 0

                        PROTEINATOTALNITROGENOxKJELDAHL = 0

                        ProteinaTotalporDUMAS5muestrasomás = 0

                        ANALISISTERCERIZADOSBROMAT = 0

                        Paq4 = 0

                        LISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento = 0

                        SALMONELLASPPPOOL5MUESTRASAislamiento = 0

                        BACTERIASACIDOLACTICAS = 0

                        BACILLUSCEREUS = 0

                        MESÓFILOSRB = 0

                        ECOLIconpaq = 0

                        LEVADURAS = 0

                        LISTERIASPP = 0

                        MOHOS = 0

                        LISTERIAMONOCYTOGENESPCR = 0

                        LISTERIAMONOCYTOGENESPOOLPCR = 0

                        SALMONELLASPPPCR = 0

                        SALMONELLASPPPOOLPCR = 0

                        ACIDEZ = 0

                        CLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO = 0

                        SALMONELLAConfirmacionenAlimentos = 0

                        SALMONELLAPOOL5MUESTRASConfirmacionenAlimentos = 0

                        LISTERIAMONOCYTOGENESConfirmacionenalimentos = 0

                        LISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion = 0

                        Paq5 = 0

                        Carbohidratos = 0

                        Energía = 0

                        CONDUCTIVIDADAlimentos = 0

                        EnvioaotrosLaboratoriosBromatologia = 0

                        barracontadora = barracontadora + barracontadora2
                    Next
                    ProgressBar1.Value = 100

                    Linea = Linea & "Total" + Chr(9) + Chr(9)
                    Linea = Linea & Chr(9)
                    Linea = Linea & TOTALENTEROBACTERIAS & Chr(9)
                    Linea = Linea & TOTALCLORURODESODIO & Chr(9)
                    Linea = Linea & TOTALECOLICOLIFORMESTOTALES35 & Chr(9)
                    Linea = Linea & TOTALESTAFILOCOCOCOAGULASAPOSITIVO & Chr(9)
                    Linea = Linea & TOTALSALMONELLASPPAislamiento & Chr(9)
                    Linea = Linea & TOTALMOHOSLEVADURAS & Chr(9)
                    Linea = Linea & TOTALSOLIDOSTOTALESHUMEDAD & Chr(9)
                    Linea = Linea & TOTALMATERIAGRASAVanGulik & Chr(9)
                    Linea = Linea & TOTALpH & Chr(9)
                    Linea = Linea & TOTALPROTEINATOTALxDUMAS & Chr(9)
                    Linea = Linea & TOTALTermofilosSP & Chr(9)
                    Linea = Linea & TOTALCENIZASTOTALES & Chr(9)
                    Linea = Linea & TOTALNitrato & Chr(9)
                    Linea = Linea & TOTALCOLIFORMESTOTALES & Chr(9)
                    Linea = Linea & TOTALCOLIFORMESFECALES & Chr(9)
                    Linea = Linea & TOTALPaq1 & Chr(9)
                    Linea = Linea & TOTALPaq2 & Chr(9)
                    Linea = Linea & TOTALPaq3 & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESAislamiento & Chr(9)
                    Linea = Linea & TOTALCOMPOSICIONENSUERO & Chr(9)
                    Linea = Linea & TOTALEColiO157RevealSP & Chr(9)
                    Linea = Linea & TOTALMATERIAGRASAporROSEGOTTLIEB & Chr(9)
                    Linea = Linea & TOTALPROTEINATOTALNITROGENOxKJELDAHL & Chr(9)
                    Linea = Linea & TOTALProteinaTotalporDUMAS5muestrasomás & Chr(9)
                    Linea = Linea & TOTALANALISISTERCERIZADOSBROMAT & Chr(9)
                    Linea = Linea & TOTALPaq4 & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASAislamiento & Chr(9)
                    Linea = Linea & TOTALSALMONELLASPPPOOL5MUESTRASAislamiento & Chr(9)
                    Linea = Linea & TOTALBACTERIASACIDOLACTICAS & Chr(9)
                    Linea = Linea & TOTALBACILLUSCEREUS & Chr(9)
                    Linea = Linea & TOTALMESÓFILOSRB & Chr(9)
                    Linea = Linea & TOTALECOLIconpaq & Chr(9)
                    Linea = Linea & TOTALLEVADURAS & Chr(9)
                    Linea = Linea & TOTALLISTERIASPP & Chr(9)
                    Linea = Linea & TOTALMOHOS & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESPCR & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESPOOLPCR & Chr(9)
                    Linea = Linea & TOTALSALMONELLASPPPCR & Chr(9)
                    Linea = Linea & TOTALSALMONELLASPPPOOLPCR & Chr(9)
                    Linea = Linea & TOTALACIDEZ & Chr(9)
                    Linea = Linea & TOTALCLOSTRIDIOSESPORULADOSANAEROBIOSMESÓFILOSENQUESO & Chr(9)
                    Linea = Linea & TOTALSALMONELLAConfirmacionenAlimentos & Chr(9)
                    Linea = Linea & TOTALSALMONELLAPOOL5MUESTRASConfirmacionenAlimentos & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESConfirmacionenalimentos & Chr(9)
                    Linea = Linea & TOTALLISTERIAMONOCYTOGENESPOOL5MUESTRASConfirmacion & Chr(9)
                    Linea = Linea & TOTALPaq5 & Chr(9)
                    Linea = Linea & TOTALCarbohidratos & Chr(9)
                    Linea = Linea & TOTALEnergía & Chr(9)
                    Linea = Linea & TOTALLACTOSA & Chr(9)
                    Linea = Linea & TOTALCONDUCTIVIDADAlimentos & Chr(9)
                    Linea = Linea & TOTALEnvioaotrosLaboratoriosBromatologia & Chr(9)
                    oSW.WriteLine(Linea)
                    Linea = ""
                    Linea = Linea & "Timbres:" + " " & listasa.Count
                    oSW.WriteLine(Linea)
                    oSW.Flush()
                End If
                imprimio = True
            End If
            sa = Nothing
            listasa = Nothing
            barracontadora = 1
        End If
        If imprimio = False Then
            MsgBox("No se imprimieron los resultados", 0, "Archivo TXT")
        End If
        If imprimio = True Then
            MsgBox("Se imprimieron los resultados", 0, "Archivo TXT")
        End If
    End Function
    
#End Region

#Region "Facturar"
    Private Sub facturar_calcar_carmelo()
        Dim idempresa As Long = 219
        Facturar(idempresa)
    End Sub
    Private Sub facturar_calcar_tarariras()
        Dim idempresa As Long = 4688
        Facturar(idempresa)
    End Sub
    Private Sub facturar_indulacsac()
        Dim idempresa As Long = 150
        Facturar(idempresa)
    End Sub
    Private Sub facturar_indulacsas()
        Dim idempresa As Long = 2705
        Facturar(idempresa)
    End Sub
    Private Sub Facturar(ByVal idemp As Long)
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList
        Dim cuentaanalisis As Integer = 0
        Dim Facturo As Boolean = False
        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = idemp
        Dim ficha As Long = 0

        Dim contrc As Integer = 0
        Dim contrb As Integer = 0
        Dim contgr As Integer = 0
        Dim contpr As Integer = 0
        Dim contlc As Integer = 0
        Dim contst As Integer = 0
        Dim contcr As Integer = 0
        Dim contur As Integer = 0
        Dim continh As Integer = 0
        Dim contesp As Integer = 0
        Dim contpsi As Integer = 0

        Dim totalrc As Integer = 0
        Dim totalrb As Integer = 0
        Dim totalgr As Integer = 0
        Dim totalpr As Integer = 0
        Dim totallc As Integer = 0
        Dim totalst As Integer = 0
        Dim totalcr As Integer = 0
        Dim totalur As Integer = 0
        Dim totalinh As Integer = 0
        Dim totalesp As Integer = 0
        Dim totalpsi As Integer = 0
        Dim timbres As Integer = 0

        Dim fila As Integer = 0
        Dim columna As Integer = 0

        Dim tipoInf As Integer = 0
        Dim cbxInforme As String
        cbxInforme = cbxTipoInforme.Text
        tipoInf = tipoInforme(cbxInforme)

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa, tipoInf)
        If Not listasa Is Nothing Then
            cuentaanalisis = listasa.Count

            timbres = cuentaanalisis

            If Not listasa Is Nothing Then
                If listasa.Count > 0 Then
                    For Each sa In listasa
                        Dim csm As New dCalidadSolicitudMuestra
                        Dim listacsm As New ArrayList
                        ficha = sa.ID
                        listacsm = csm.listarporsolicitud(ficha)
                        If Not listacsm Is Nothing Then
                            If listacsm.Count > 0 Then
                                For Each csm In listacsm

                                    If csm.RB = 1 Then
                                        Dim ibc As New dIbc
                                        ibc.FICHA = csm.FICHA
                                        ibc.MUESTRA = csm.MUESTRA
                                        ibc = ibc.buscarxfichaxmuestra
                                        If Not ibc Is Nothing Then
                                            contrb = contrb + 1
                                        End If
                                        ibc = Nothing
                                    End If
                                    Dim c As New dCalidad
                                    c.FICHA = csm.FICHA
                                    c.MUESTRA = csm.MUESTRA
                                    c = c.buscarxfichaxmuestra
                                    If Not c Is Nothing Then
                                        If csm.RC = 1 Then
                                            If c.RC <> -1 Then
                                                contrc = contrc + 1
                                            End If
                                        End If
                                        If csm.COMPOSICION = 1 Then
                                            If c.GRASA <> -1 Then
                                                contgr = contgr + 1
                                            End If
                                            If c.PROTEINA <> -1 Then
                                                contpr = contpr + 1
                                            End If
                                            If c.LACTOSA <> -1 Then
                                                contlc = contlc + 1
                                            End If
                                            If c.ST <> -1 Then
                                                contst = contst + 1
                                            End If
                                        End If
                                        If csm.CRIOSCOPIA = 1 Then
                                            If c.CRIOSCOPIA <> -1 Then
                                                contcr = contcr + 1
                                            End If
                                        End If
                                        If csm.CRIOSCOPIA_CRIOSCOPO Then
                                            contcr = contcr + 1
                                        End If
                                        If csm.UREA = 1 Then
                                            If c.UREA <> -1 Then
                                                contur = contur + 1
                                            End If
                                        End If
                                        c = Nothing
                                    End If
                                    If csm.INHIBIDORES = 1 Then
                                        Dim inh As New dInhibidores
                                        inh.FICHA = csm.FICHA
                                        inh.MUESTRA = csm.MUESTRA
                                        inh = inh.buscarxfichaxmuestra
                                        If Not inh Is Nothing Then
                                            continh = continh + 1
                                        End If
                                        inh = Nothing
                                    End If
                                    If csm.ESPORULADOS = 1 Then
                                        Dim esp As New dEsporulados
                                        esp.FICHA = csm.FICHA
                                        esp.MUESTRA = csm.MUESTRA
                                        esp = esp.buscarxfichaxmuestra
                                        If Not esp Is Nothing Then
                                            contesp = contesp + 1
                                        End If
                                        esp = Nothing
                                    End If
                                    If csm.PSICROTROFOS = 1 Then
                                        Dim psi As New dPsicrotrofos
                                        psi.FICHA = csm.FICHA
                                        psi.MUESTRA = csm.MUESTRA
                                        psi = psi.buscarxfichaxmuestra
                                        If Not psi Is Nothing Then
                                            contpsi = contpsi + 1
                                        End If
                                        psi = Nothing
                                    End If
                                    Dim f As New dFacturacion
                                Next
                            End If
                            listacsm = Nothing
                            csm = Nothing
                        End If
                        totalrc = totalrc + contrc
                        totalrb = totalrb + contrb
                        totalgr = totalgr + contgr
                        totalpr = totalpr + contpr
                        totallc = totallc + contlc
                        totalst = totalst + contst
                        totalcr = totalcr + contcr
                        totalur = totalur + contur
                        totalinh = totalinh + continh
                        totalesp = totalesp + contesp
                        totalpsi = totalpsi + contpsi

                        contrc = 0
                        contrb = 0
                        contgr = 0
                        contpr = 0
                        contlc = 0
                        contst = 0
                        contcr = 0
                        contur = 0
                        continh = 0
                        contesp = 0
                        contpsi = 0
                    Next

                End If
            End If
            sa = Nothing
            listasa = Nothing
            Facturo = True
        End If
        If Facturo = False Then
            MsgBox("No se facturo los resultados", 0, "Facturar")
        End If
        If Facturo = True Then
            MsgBox("Se facturo los resultados", 0, "Facturar")
        End If
    End Sub
#End Region

End Class