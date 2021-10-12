Public Class FormSolicitudSubproductos
    Private _usuario As dUsuario
    Dim idsol As Long
    Dim fechasol As Date
    Dim subinf As Integer
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As Long, ByVal fecha As Date, ByVal idsubinf As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        'listarultimoid()
        idsol = solicitud
        fechasol = fecha
        subinf = idsubinf
        cargarcheckbox()
    End Sub
#End Region
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cargarcheckbox()
        Dim sp As New dSubproducto
        sp.IDSOLICITUD = idsol
        sp = sp.buscarxsolicitud

        If subinf = 14 Then
            desmarcarcheckbox()
            CheckEstafilococo.Checked = True
            CheckCF.Checked = True
            CheckMohos.Checked = True
            CheckCT.Checked = True
            CheckEColi.Checked = True
        ElseIf subinf = 15 Then
            desmarcarcheckbox()
            CheckEstafilococo.Checked = True
            CheckCF.Checked = True
            CheckMohos.Checked = True
            CheckCT.Checked = True
            CheckEColi.Checked = True
            CheckSalmonella.Checked = True
        ElseIf subinf = 17 Then
            desmarcarcheckbox()
            CheckEstafilococo.Checked = True
            CheckCF.Checked = True
            CheckMohos.Checked = True
            CheckCT.Checked = True
            CheckEColi.Checked = True
            CheckSalmonella.Checked = True
            CheckListSPP.Checked = False ' deshabilitada
            CheckListMono.Checked = True
        ElseIf subinf = 20 Then
            desmarcarcheckbox()
            If Not sp Is Nothing Then
                If sp.ESTAFCOAGPOSITIVO = 1 Then
                    CheckEstafilococo.Checked = True
                End If
                If sp.CF = 1 Then
                    CheckCF.Checked = True
                End If
                If sp.MOHOSYLEVADURAS = 1 Then
                    CheckMohos.Checked = True
                End If
                If sp.CT = 1 Then
                    CheckCT.Checked = True
                End If
                If sp.ECOLI = 1 Then
                    CheckEColi.Checked = True
                End If
                If sp.SALMONELLA = 1 Then
                    CheckSalmonella.Checked = True
                End If
                If sp.LISTERIASPP = 1 Then
                    CheckListSPP.Checked = False 'deshabilitada
                End If
                If sp.HUMEDAD = 1 Then
                    CheckHumedad.Checked = True
                End If
                If sp.MGRASA = 1 Then
                    CheckMGrasa.Checked = True
                End If
                If sp.PH = 1 Then
                    CheckPH.Checked = True
                End If
                If sp.CLORUROS = 1 Then
                    CheckCloruros.Checked = True
                End If
                If sp.PROTEINAS = 1 Then
                    CheckProteinas.Checked = True
                End If
                If sp.ENTEROBACTERIAS = 1 Then
                    CheckEnterobacterias.Checked = True
                End If
                If sp.LISTERIAAMBIENTAL = 1 Then
                    CheckListAmb.Checked = True
                End If
                If sp.ESPORANAERMESOFILO = 1 Then
                    CheckEsporulados.Checked = True
                End If
                If sp.TERMOFILOS = 1 Then
                    CheckTermofilos.Checked = True
                End If
                If sp.PSICROTROFOS = 1 Then
                    CheckPsicrotrofos.Checked = True
                End If
                If sp.TABLANUTRICIONAL = 1 Then
                    CheckTNutricional.Checked = True
                End If
                If sp.LISTERIAMONOCITOGENES = 1 Then
                    CheckListMono.Checked = True
                End If
                If sp.CENIZAS = 1 Then
                    CheckCenizas.Checked = True
                End If
            End If
            ElseIf subinf = 35 Then
                desmarcarcheckbox()
            If Not sp Is Nothing Then
                If sp.ESTAFCOAGPOSITIVO = 1 Then
                    CheckEstafilococo.Checked = True
                End If
                If sp.CF = 1 Then
                    CheckCF.Checked = True
                End If
                If sp.MOHOSYLEVADURAS = 1 Then
                    CheckMohos.Checked = True
                End If
                If sp.CT = 1 Then
                    CheckCT.Checked = True
                End If
                If sp.ECOLI = 1 Then
                    CheckEColi.Checked = True
                End If
                If sp.SALMONELLA = 1 Then
                    CheckSalmonella.Checked = True
                End If
                If sp.LISTERIASPP = 1 Then
                    CheckListSPP.Checked = False 'deshabilitada
                End If
                If sp.HUMEDAD = 1 Then
                    CheckHumedad.Checked = True
                End If
                If sp.MGRASA = 1 Then
                    CheckMGrasa.Checked = True
                End If
                If sp.PH = 1 Then
                    CheckPH.Checked = True
                End If
                If sp.CLORUROS = 1 Then
                    CheckCloruros.Checked = True
                End If
                If sp.PROTEINAS = 1 Then
                    CheckProteinas.Checked = True
                End If
                If sp.ENTEROBACTERIAS = 1 Then
                    CheckEnterobacterias.Checked = True
                End If
                If sp.LISTERIAAMBIENTAL = 1 Then
                    CheckListAmb.Checked = True
                End If
                If sp.ESPORANAERMESOFILO = 1 Then
                    CheckEsporulados.Checked = True
                End If
                If sp.TERMOFILOS = 1 Then
                    CheckTermofilos.Checked = True
                End If
                If sp.PSICROTROFOS = 1 Then
                    CheckPsicrotrofos.Checked = True
                End If
                If sp.TABLANUTRICIONAL = 1 Then
                    CheckTNutricional.Checked = True
                End If
                If sp.LISTERIAMONOCITOGENES = 1 Then
                    CheckListMono.Checked = True
                End If
                If sp.CENIZAS = 1 Then
                    CheckCenizas.Checked = True
                End If
            End If
            ElseIf subinf = 37 Then
            desmarcarcheckbox()
            If Not sp Is Nothing Then
                If sp.ESTAFCOAGPOSITIVO = 1 Then
                    CheckEstafilococo.Checked = True
                End If
                If sp.CF = 1 Then
                    CheckCF.Checked = True
                End If
                If sp.MOHOSYLEVADURAS = 1 Then
                    CheckMohos.Checked = True
                End If
                If sp.CT = 1 Then
                    CheckCT.Checked = True
                End If
                If sp.ECOLI = 1 Then
                    CheckEColi.Checked = True
                End If
                If sp.SALMONELLA = 1 Then
                    CheckSalmonella.Checked = True
                End If
                If sp.LISTERIASPP = 1 Then
                    CheckListSPP.Checked = False 'deshabilitada
                End If
                If sp.HUMEDAD = 1 Then
                    CheckHumedad.Checked = True
                End If
                If sp.MGRASA = 1 Then
                    CheckMGrasa.Checked = True
                End If
                If sp.PH = 1 Then
                    CheckPH.Checked = True
                End If
                If sp.CLORUROS = 1 Then
                    CheckCloruros.Checked = True
                End If
                If sp.PROTEINAS = 1 Then
                    CheckProteinas.Checked = True
                End If
                If sp.ENTEROBACTERIAS = 1 Then
                    CheckEnterobacterias.Checked = True
                End If
                If sp.LISTERIAAMBIENTAL = 1 Then
                    CheckListAmb.Checked = True
                End If
                If sp.ESPORANAERMESOFILO = 1 Then
                    CheckEsporulados.Checked = True
                End If
                If sp.TERMOFILOS = 1 Then
                    CheckTermofilos.Checked = True
                End If
                If sp.PSICROTROFOS = 1 Then
                    CheckPsicrotrofos.Checked = True
                End If
                If sp.TABLANUTRICIONAL = 1 Then
                    CheckTNutricional.Checked = True
                End If
                If sp.LISTERIAMONOCITOGENES = 1 Then
                    CheckListMono.Checked = True
                End If
                If sp.CENIZAS = 1 Then
                    CheckCenizas.Checked = True
                End If
            End If
            ElseIf subinf = 43 Then
            desmarcarcheckbox()
            If Not sp Is Nothing Then
                If sp.ESTAFCOAGPOSITIVO = 1 Then
                    CheckEstafilococo.Checked = True
                End If
                If sp.CF = 1 Then
                    CheckCF.Checked = True
                End If
                If sp.MOHOSYLEVADURAS = 1 Then
                    CheckMohos.Checked = True
                End If
                If sp.CT = 1 Then
                    CheckCT.Checked = True
                End If
                If sp.ECOLI = 1 Then
                    CheckEColi.Checked = True
                End If
                If sp.SALMONELLA = 1 Then
                    CheckSalmonella.Checked = True
                End If
                If sp.LISTERIASPP = 1 Then
                    CheckListSPP.Checked = False 'deshabilitada
                End If
                If sp.HUMEDAD = 1 Then
                    CheckHumedad.Checked = True
                End If
                If sp.MGRASA = 1 Then
                    CheckMGrasa.Checked = True
                End If
                If sp.PH = 1 Then
                    CheckPH.Checked = True
                End If
                If sp.CLORUROS = 1 Then
                    CheckCloruros.Checked = True
                End If
                If sp.PROTEINAS = 1 Then
                    CheckProteinas.Checked = True
                End If
                If sp.ENTEROBACTERIAS = 1 Then
                    CheckEnterobacterias.Checked = True
                End If
                If sp.LISTERIAAMBIENTAL = 1 Then
                    CheckListAmb.Checked = True
                End If
                If sp.ESPORANAERMESOFILO = 1 Then
                    CheckEsporulados.Checked = True
                End If
                If sp.TERMOFILOS = 1 Then
                    CheckTermofilos.Checked = True
                End If
                If sp.PSICROTROFOS = 1 Then
                    CheckPsicrotrofos.Checked = True
                End If
                If sp.TABLANUTRICIONAL = 1 Then
                    CheckTNutricional.Checked = True
                End If
                If sp.LISTERIAMONOCITOGENES = 1 Then
                    CheckListMono.Checked = True
                End If
                If sp.CENIZAS = 1 Then
                    CheckCenizas.Checked = True
                End If
            End If
            End If

    End Sub
    Private Sub desmarcarcheckbox()
        CheckEstafilococo.Checked = False
        CheckCF.Checked = False
        CheckMohos.Checked = False
        CheckCT.Checked = False
        CheckEColi.Checked = False
        CheckSalmonella.Checked = False
        CheckListSPP.Checked = False
        CheckHumedad.Checked = False
        CheckMGrasa.Checked = False
        CheckPH.Checked = False
        CheckCloruros.Checked = False
        CheckProteinas.Checked = False
        CheckEnterobacterias.Checked = False
        CheckListAmb.Checked = False
        CheckEsporulados.Checked = False
        CheckTermofilos.Checked = False
        CheckPsicrotrofos.Checked = False
        CheckTNutricional.Checked = False
        CheckListMono.Checked = False
        CheckCenizas.Checked = False


    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEstafilococo.CheckedChanged

    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        'Dim idsolicitud As Long = TextIdSolicitud.Text.Trim
        Dim fecsol As String
        fecsol = Format(fechasol, "yyyy-MM-dd")
        Dim fechaproceso As Date
        Dim fecpro As String
        fechaproceso = Now
        fecpro = Format(fechaproceso, "yyyy-MM-dd")
        Dim estafcoagpositivo As Integer
        Dim cf As Integer
        Dim mohosylevaduras As Integer
        Dim ct As Integer
        Dim ecoli As Integer
        Dim salmonella As Integer
        Dim listeriaspp As Integer
        Dim humedad As Integer
        Dim mgrasa As Integer
        Dim ph As Integer
        Dim cloruros As Integer
        Dim proteinas As Integer
        Dim enterobacterias As Integer
        Dim listeriaambiental As Integer
        Dim esporanaermesofilo As Integer
        Dim termofilos As Integer
        Dim psicrotrofos As Integer
        Dim rb As Integer
        Dim tablanutricional As Integer
        Dim listeriamonocitogenes As Integer
        Dim cenizas As Integer
        If CheckEstafilococo.Checked = True Then
            estafcoagpositivo = 1
        Else
            estafcoagpositivo = 0
        End If
        If CheckCF.Checked = True Then
            cf = 1
        Else
            cf = 0
        End If
        If CheckMohos.Checked = True Then
            mohosylevaduras = 1
        Else
            mohosylevaduras = 0
        End If
        If CheckCT.Checked = True Then
            ct = 1
        Else
            ct = 0
        End If
        If CheckEColi.Checked = True Then
            ecoli = 1
        Else
            ecoli = 0
        End If
        If CheckSalmonella.Checked = True Then
            salmonella = 1
        Else
            salmonella = 0
        End If
        If CheckListSPP.Checked = True Then
            listeriaspp = 1
        Else
            listeriaspp = 0
        End If
        If CheckHumedad.Checked = True Then
            humedad = 1
        Else
            humedad = 0
        End If
        If CheckMGrasa.Checked = True Then
            mgrasa = 1
        Else
            mgrasa = 0
        End If
        If CheckPH.Checked = True Then
            ph = 1
        Else
            ph = 0
        End If
        If CheckCloruros.Checked = True Then
            cloruros = 1
        Else
            cloruros = 0
        End If
        If CheckProteinas.Checked = True Then
            proteinas = 1
        Else
            proteinas = 0
        End If
        If CheckEnterobacterias.Checked = True Then
            enterobacterias = 1
        Else
            enterobacterias = 0
        End If
        If CheckListAmb.Checked = True Then
            listeriaambiental = 1
        Else
            listeriaambiental = 0
        End If
        If CheckEsporulados.Checked = True Then
            esporanaermesofilo = 1
        Else
            esporanaermesofilo = 0
        End If
        If CheckTermofilos.Checked = True Then
            termofilos = 1
        Else
            termofilos = 0
        End If
        If CheckPsicrotrofos.Checked = True Then
            psicrotrofos = 1
        Else
            psicrotrofos = 0
        End If
        If CheckRB.Checked = True Then
            rb = 1
        Else
            rb = 0
        End If
        If CheckTNutricional.Checked = True Then
            tablanutricional = 1
        Else
            tablanutricional = 0
        End If
        If CheckListMono.Checked = True Then
            listeriamonocitogenes = 1
        Else
            listeriamonocitogenes = 0
        End If
        If CheckCenizas.Checked = True Then
            cenizas = 1
        Else
            cenizas = 0
        End If
        Dim s As New dSubproducto
        s.IDSOLICITUD = idsol
        s.FECHASOLICITUD = fecsol
        s.FECHAPROCESO = fecpro
        s.ESTAFCOAGPOSITIVO = estafcoagpositivo
        s.CF = cf
        s.MOHOSYLEVADURAS = mohosylevaduras
        s.CT = ct
        s.ECOLI = ecoli
        s.SALMONELLA = salmonella
        s.LISTERIASPP = listeriaspp
        s.HUMEDAD = humedad
        s.MGRASA = mgrasa
        s.PH = ph
        s.CLORUROS = cloruros
        s.PROTEINAS = proteinas
        s.ENTEROBACTERIAS = enterobacterias
        s.LISTERIAAMBIENTAL = listeriaambiental
        s.ESPORANAERMESOFILO = esporanaermesofilo
        s.TERMOFILOS = termofilos
        s.PSICROTROFOS = psicrotrofos
        s.RB = rb
        s.TABLANUTRICIONAL = tablanutricional
        s.LISTERIAMONOCITOGENES = listeriamonocitogenes
        s.CENIZAS = cenizas
        s.MARCA = 0
        If (s.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        Me.Close()
    End Sub
End Class