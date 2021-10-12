Imports System
Imports System.IO
Imports System.Collections
Public Class FormContadorAnalisisEmpresas2
#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarempresas()
    End Sub
#End Region
    Private Sub cargarempresas()
        ComboEmpresas.Items.Add("Seleccione una empresa")
        ComboEmpresas.Items.Add("CALCAR CARMELO")
        ComboEmpresas.Items.Add("CALCAR TARARIRAS")
        ComboEmpresas.Items.Add("CALDEM")
        ComboEmpresas.Items.Add("DULEI")
        ComboEmpresas.Items.Add("ECOLAT")
        ComboEmpresas.Items.Add("GRANJA BRASSETTI")
        ComboEmpresas.Items.Add("INDULACSA CARDONA")
        ComboEmpresas.Items.Add("INDULACSA SALTO")
        ComboEmpresas.Items.Add("LA MAGNOLIA")
        ComboEmpresas.Items.Add("NATURALIA")
        ComboEmpresas.Items.Add("PINEROLO")
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        DataGridView1.Rows.Clear()
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
        End If
    End Sub
    Private Sub calcar_carmelo()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 219
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub calcar_tarariras()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 4688
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub caldem()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 149
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub dulei()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 809
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub ecolat()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 143
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub brassetti()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 107
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub indulacsac()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 150
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub indulacsas()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 2705
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        If Not listasa Is Nothing Then
            contador = listasa.Count + 2
        End If
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub magnolia()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 157
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub naturalia()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 144
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub pinerolo()
        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 140
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        DataGridView1.Rows.Clear()
        Dim contador As Integer = 0
        contador = listasa.Count + 2
        DataGridView1.Rows.Add(contador)
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If

    End Sub
    Private Sub imprimir_calcar_carmelo()
        Dim oSW As New StreamWriter("c:\empresa\calcar_carmelo.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 219
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)
        
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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_calcar_tarariras()
        Dim oSW As New StreamWriter("c:\empresa\calcar_tarariras.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 4688
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_caldem()
        Dim oSW As New StreamWriter("c:\empresa\caldem.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 149
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_dulei()
        Dim oSW As New StreamWriter("c:\empresa\dulei.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 809
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_ecolat()
        Dim oSW As New StreamWriter("c:\empresa\ecolat.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 143
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_brassetti()
        Dim oSW As New StreamWriter("c:\empresa\brassetti.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 107
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_indulacsac()
        Dim oSW As New StreamWriter("c:\empresa\indulacsa_cardona.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 150
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_indulacsas()
        Dim oSW As New StreamWriter("c:\empresa\indulacsa_salto.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 2705
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_magnolia()
        Dim oSW As New StreamWriter("c:\empresa\magnolia.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 157
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_naturalia()
        Dim oSW As New StreamWriter("c:\empresa\naturalia.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 144
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
    Private Sub imprimir_pinerolo()
        Dim oSW As New StreamWriter("c:\empresa\calcar_pinerolo.txt")
        Dim Linea As String = ""
        Linea = "Ficha" + Chr(9) + "Fecha" + Chr(9) + Chr(9) + "RC" + Chr(9) + "RB" + Chr(9) + "Gr" + Chr(9) + "Pr" + Chr(9) + "Lc" + Chr(9) + "ST" + Chr(9) + "Cr" + Chr(9) + "Ur" + Chr(9) + "Inh" + Chr(9) + "Esp" + Chr(9) + "Psi"
        oSW.WriteLine(Linea)
        Linea = ""

        Dim sa As New dSolicitudAnalisis
        Dim listasa As New ArrayList

        Dim desde As Date = DateDesde.Value.ToString("yyyy-MM-dd")
        Dim hasta As Date = DateHasta.Value.ToString("yyyy-MM-dd")
        Dim fecdesde As String
        Dim fechasta As String
        fecdesde = Format(desde, "yyyy-MM-dd")
        fechasta = Format(hasta, "yyyy-MM-dd")
        Dim idempresa As Long = 140
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

        listasa = sa.listarxfechaxempresa(fecdesde, fechasta, idempresa)

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
                                    ibc.FICHA = csm.IDSOLICITUD
                                    ibc.MUESTRA = csm.MUESTRA
                                    ibc = ibc.buscarxfichaxmuestra
                                    If Not ibc Is Nothing Then
                                        contrb = contrb + 1
                                    End If
                                    ibc = Nothing
                                End If
                                Dim c As New dCalidad
                                c.FICHA = csm.IDSOLICITUD
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
                                    inh.FICHA = csm.IDSOLICITUD
                                    inh.MUESTRA = csm.MUESTRA
                                    inh = inh.buscarxfichaxmuestra
                                    If Not inh Is Nothing Then
                                        continh = continh + 1
                                    End If
                                    inh = Nothing
                                End If
                                If csm.ESPORULADOS = 1 Then
                                    Dim esp As New dEsporulados
                                    esp.FICHA = csm.IDSOLICITUD
                                    esp.MUESTRA = csm.MUESTRA
                                    esp = esp.buscarxfichaxmuestra
                                    If Not esp Is Nothing Then
                                        contesp = contesp + 1
                                    End If
                                    esp = Nothing
                                End If
                                If csm.PSICROTROFOS = 1 Then
                                    Dim psi As New dPsicrotrofos
                                    psi.FICHA = csm.IDSOLICITUD
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

                Next

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
        End If
        sa = Nothing
        listasa = Nothing
    End Sub
End Class