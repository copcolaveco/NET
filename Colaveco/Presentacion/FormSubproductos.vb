Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class FormSubproductos
    Private _usuario As dUsuario
    Private idsol As Long
    Private metct As Integer = 0
    Private metcf As Integer = 0
    Private metecoli As Integer = 0
    Private metenterobacterias As Integer = 0
    Private metestafilococo As Integer = 0
    Private metmohos As Integer = 0
    Private metlevaduras As Integer = 0
    Private metsalmonella As Integer = 0
    Private metlistmono As Integer = 0
    Private metlistspp As Integer = 0
    Private metlistambiental As Integer = 0
    Private metesporulados As Integer = 0
    Private mettermofilos As Integer = 0
    Private metpsicrotrofos As Integer = 0
    Private metrb As Integer = 0
    Private metgrasa As Integer = 0
    Private methumedad As Integer = 0
    Private metph As Integer = 0
    Private metcloruros As Integer = 0
    Private metproteinas As Integer = 0
    Private metcenizas As Integer = 0

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

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        'listoantibiogramas()
        'listarantibiogramas()
        listarfichas()
        cargarComboSalmonella()
        cargarComboListeriaAmbiental()
        cargarComboListeriaMono()
        cargarComboListeriaSPP()
        cargarComboEstadoMuestra()

        'cargarMatrizDeColumnas()
        'limpiar()

    End Sub
#End Region
    Public Sub listarfichas()
        Dim s2 As New dSubproducto2
        Dim lista As New ArrayList
        lista = s2.listarfichas
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s2 In lista
                    ListFichas().Items.Add(s2)
                Next
            End If
        End If
    End Sub
    Public Sub listarproductos()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim sp2 As dSubproducto2 = CType(ListFichas.SelectedItem, dSubproducto2)
            Dim id As Long = sp2.IDSOLICITUD
            idsol = id
            Dim lista As New ArrayList
            lista = sp2.listarporsolicitud(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp2 In lista
                        ListMuestras().Items.Add(sp2)
                    Next
                End If
            End If
        End If

    End Sub
    Public Sub cargarComboSalmonella()
        Dim s As New dSalmonella
        Dim lista As New ArrayList
        lista = s.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ComboSalmonella.Items.Add(s)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboListeriaAmbiental()
        Dim la As New dListeriaAmbiental
        Dim lista As New ArrayList
        lista = la.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each la In lista
                    ComboListAmbiental.Items.Add(la)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboListeriaMono()
        Dim lm As New dListeriaMono
        Dim lista As New ArrayList
        lista = lm.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each lm In lista
                    ComboListMonocitogenes.Items.Add(lm)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboListeriaSPP()
        Dim ls As New dListeriaSPP
        Dim lista As New ArrayList
        lista = ls.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ls In lista
                    ComboListSPP.Items.Add(ls)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboEstadoMuestra()
        
        ComboEstadoMuestra.Items.Add("sólido")
        ComboEstadoMuestra.Items.Add("líquido")
        ComboEstadoMuestra.Text = "sólido"
        cambiolabel()
    End Sub
    Public Sub cambiolabel()
        If ComboEstadoMuestra.Text = "sólido" Then
            Label37.Text = "UFC/g"
            Label38.Text = "UFC/g"
            Label39.Text = "UFC/g"
            Label41.Text = "UFC/g"
            Label42.Text = "UFC/g"
            Label43.Text = "UFC/g"
            Label44.Text = "UFC/g"
            Label45.Text = "UFC/g"
            Label46.Text = "UFC/g"
            Label47.Text = "UFC/g"
            Label48.Text = "UFC/g"
            Label49.Text = "UFC/g"
            Label50.Text = "UFC/g"
            Label51.Text = "UFC/g"
            Label66.Text = "UFC/g"
        End If
        If ComboEstadoMuestra.Text = "líquido" Then
            Label37.Text = "UFC/ml"
            Label38.Text = "UFC/ml"
            Label39.Text = "UFC/ml"
            Label41.Text = "UFC/ml"
            Label42.Text = "UFC/ml"
            Label43.Text = "UFC/ml"
            Label44.Text = "UFC/ml"
            Label45.Text = "UFC/ml"
            Label46.Text = "UFC/ml"
            Label47.Text = "UFC/ml"
            Label48.Text = "UFC/ml"
            Label49.Text = "UFC/ml"
            Label50.Text = "UFC/ml"
            Label51.Text = "UFC/ml"
            Label66.Text = "UFC/ml"
        End If
    End Sub
    

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim sp As New dSubproducto
            Dim s2 As dSubproducto2 = CType(ListFichas.SelectedItem, dSubproducto2)
            Dim id As Long = s2.IDSOLICITUD
            Dim lista As New ArrayList
            lista = s2.listarporid(id)
            sp.ID = s2.IDSOLICITUD
            sp = sp.buscar
            If sp.FECHAPROCESO <> "00:00:00" Then
                DateFechaProceso.Value = sp.FECHAPROCESO
            End If
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each s2 In lista
                        ListMuestras().Items.Add(s2)
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        DateFechaSolicitud.Value = Now()
        TextMuestra.Text = ""
        TextDetalleMuestra.Text = ""
        TextObservaciones.Text = ""
        TextTipoInforme.Text = ""
        TextColifTotales.Text = ""
        TextColifFecales.Text = ""
        TextEColi.Text = ""
        TextEnterobacterias.Text = ""
        TextEstafCoag.Text = ""
        TextMohos.Text = ""
        TextLevaduras.Text = ""
        ComboSalmonella.Text = ""
        ComboSalmonella.SelectedItem = Nothing
        ComboListMonocitogenes.Text = ""
        ComboListMonocitogenes.SelectedItem = Nothing
        ComboListSPP.Text = ""
        ComboListSPP.SelectedItem = Nothing
        ComboListAmbiental.Text = ""
        ComboListAmbiental.SelectedItem = Nothing
        TextListAmbiental.Text = ""
        TextEsporulados.Text = ""
        TextTermofilos.Text = ""
        TextPsicrotrofos.Text = ""
        TextRB.Text = ""
        TextGrasa.Text = ""
        TextHumedad.Text = ""
        TextPH.Text = ""
        TextCloruros.Text = ""
        TextProteinas.Text = ""
        TextCenizas.Text = ""
        TextTNSodio.Text = ""
        TextTNFibra.Text = ""
        deshabilitarcontroles()
    End Sub
    Public Sub deshabilitarcontroles()
        TextColifTotales.Enabled = False
        TextColifFecales.Enabled = False
        TextEColi.Enabled = False
        TextEnterobacterias.Enabled = False
        TextEstafCoag.Enabled = False
        TextMohos.Enabled = False
        TextLevaduras.Enabled = False
        ComboSalmonella.Enabled = False
        ComboListMonocitogenes.Enabled = False
        ComboListSPP.Enabled = False
        ComboListAmbiental.Enabled = False
        TextListAmbiental.Enabled = False
        TextEsporulados.Enabled = False
        TextTermofilos.Enabled = False
        TextPsicrotrofos.Enabled = False
        TextRB.Enabled = False
        TextGrasa.Enabled = False
        TextHumedad.Enabled = False
        TextPH.Enabled = False
        TextCloruros.Enabled = False
        TextProteinas.Enabled = False
        TextCenizas.Enabled = False
        TextTNSodio.Enabled = False
        TextTNFibra.Enabled = False
        TextTNProteina.Enabled = False
        TextTNCarbohidratos.Enabled = False
        TextTNGrasasTotales.Enabled = False
        TextTNGrasasSaturadas.Enabled = False
        TextTNGrasasTrans.Enabled = False

    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim sp2 As dSubproducto2 = CType(ListMuestras.SelectedItem, dSubproducto2)
            TextId.Text = sp2.ID
            TextFicha.Text = sp2.IDSOLICITUD
            DateFechaSolicitud.Value = sp2.FECHASOLICITUD
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = sp2.IDMUESTRA
            If sp2.DETALLEMUESTRA <> "" Then
                TextDetalleMuestra.Text = sp2.DETALLEMUESTRA
            End If
            If sp2.ESTADOMUESTRA <> "" Then
                ComboEstadoMuestra.Text = sp2.ESTADOMUESTRA
            End If
            If sp2.CT <> "-1" Then
                TextColifTotales.Text = sp2.CT
            End If
            If sp2.CF <> "-1" Then
                TextColifFecales.Text = sp2.CF
            End If
            If sp2.ECOLI <> "-1" Then
                TextEColi.Text = sp2.ECOLI
            End If
            If sp2.ENTEROBACTERIAS <> "-1" Then
                TextEnterobacterias.Text = sp2.ENTEROBACTERIAS
            End If
            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                TextEstafCoag.Text = sp2.ESTAFCOAGPOSITIVO
            End If
            If sp2.MOHOS <> "-1" Then
                TextMohos.Text = sp2.MOHOS
            End If
            If sp2.LEVADURAS <> "-1" Then
                TextLevaduras.Text = sp2.LEVADURAS
            End If
            If sp2.SALMONELLA <> -1 Then
                Dim sal As dSalmonella
                For Each sal In ComboSalmonella.Items
                    If sal.ID = sp2.SALMONELLA Then
                        ComboSalmonella.SelectedItem = sal
                        Exit For
                    End If
                Next
            End If
            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                Dim lm As dListeriaMono
                For Each lm In ComboListMonocitogenes.Items
                    If lm.ID = sp2.LISTERIAMONOCITOGENES Then
                        ComboListMonocitogenes.SelectedItem = lm
                        Exit For
                    End If
                Next
            End If
            If sp2.LISTERIASPP <> -1 Then
                Dim lspp As dListeriaSPP
                For Each lspp In ComboListSPP.Items
                    If lspp.ID = sp2.LISTERIASPP Then
                        ComboListSPP.SelectedItem = lspp
                        Exit For
                    End If
                Next
            End If
            If sp2.LISTERIAAMBIENTAL <> -1 Then
                Dim la As dListeriaAmbiental
                For Each la In ComboListAmbiental.Items
                    If la.ID = sp2.LISTERIAAMBIENTAL Then
                        ComboListAmbiental.SelectedItem = la
                        Exit For
                    End If
                Next
            End If
            If sp2.LISTERIAAMBIENTAL2 <> -1 Then
                TextListAmbiental.Text = sp2.LISTERIAAMBIENTAL2
            End If
            If sp2.ESPORANAERMESOFILO <> -1 Then
                TextEsporulados.Text = sp2.ESPORANAERMESOFILO
            End If
            If sp2.TERMOFILOS <> "-1" Then
                TextTermofilos.Text = sp2.TERMOFILOS
            End If
            If sp2.PSICROTROFOS <> "-1" Then
                TextPsicrotrofos.Text = sp2.PSICROTROFOS
            End If
            If sp2.RB <> "-1" Then
                TextRB.Text = sp2.RB
            End If
            If sp2.MGRASA <> -1 Then
                TextGrasa.Text = Math.Round(sp2.MGRASA, 2)
            End If
            If sp2.HUMEDAD <> -1 Then
                TextHumedad.Text = Math.Round(sp2.HUMEDAD, 2)
            End If
            If sp2.PH <> -1 Then
                TextPH.Text = sp2.PH
            End If
            If sp2.CLORUROS <> -1 Then
                TextCloruros.Text = sp2.CLORUROS
            End If
            If sp2.PROTEINAS <> -1 Then
                TextProteinas.Text = sp2.PROTEINAS
            End If
            If sp2.CENIZAS <> -1 Then
                TextCenizas.Text = sp2.CENIZAS
            End If
            If sp2.TNSODIO <> -1 Then
                TextTNSodio.Text = sp2.TNSODIO
            End If
            If sp2.TNFIBRAALIMENTICIA <> -1 Then
                TextTNFibra.Text = sp2.TNFIBRAALIMENTICIA
            End If

            '********************************************
            Dim sa As New dSolicitudAnalisis
            Dim id As Long = TextFicha.Text.Trim
            sa.ID = id
            sa = sa.buscar()
            If sp2.OBSERVACIONES <> "" Then
                TextObservaciones.Text = sp2.OBSERVACIONES
            Else
                If Not sa.OBSERVACIONES Is Nothing Then
                    TextObservaciones.Text = sa.OBSERVACIONES
                End If
            End If


            Dim si As New dSubInforme
            si.ID = sa.IDSUBINFORME
            si = si.buscar()
            TextTipoInforme.Text = si.NOMBRE & " "
            '*********************************************
            Dim sp1 As New dSubproducto
            sp1.ID = id
            sp1 = sp1.buscar()

            If sp1.CT = 1 Then
                TextColifTotales.Enabled = True
            End If
            If sp1.CF = 1 Then
                TextColifFecales.Enabled = True
            End If
            If sp1.ECOLI = 1 Then
                TextEColi.Enabled = True
            End If
            If sp1.ENTEROBACTERIAS = 1 Then
                TextEnterobacterias.Enabled = True
            End If
            If sp1.ESTAFCOAGPOSITIVO = 1 Then
                TextEstafCoag.Enabled = True
            End If
            If sp1.MOHOSYLEVADURAS = 1 Then
                TextMohos.Enabled = True
                TextLevaduras.Enabled = True
            End If
            If sp1.SALMONELLA = 1 Then
                ComboSalmonella.Enabled = True
            End If
            If sp1.LISTERIAMONOCITOGENES = 1 Then
                ComboListMonocitogenes.Enabled = True
            End If
            If sp1.LISTERIASPP = 1 Then
                ComboListSPP.Enabled = True
            End If
            If sp1.LISTERIAAMBIENTAL = 1 Then
                ComboListAmbiental.Enabled = True
                TextListAmbiental.Enabled = True
            End If
            If sp1.ESPORANAERMESOFILO = 1 Then
                TextEsporulados.Enabled = True
            End If
            If sp1.TERMOFILOS = 1 Then
                TextTermofilos.Enabled = True
            End If
            If sp1.PSICROTROFOS = 1 Then
                TextPsicrotrofos.Enabled = True
            End If
            If sp1.RB = 1 Then
                TextRB.Enabled = True
            End If
            If sp1.MGRASA = 1 Then
                TextGrasa.Enabled = True
            End If
            If sp1.HUMEDAD = 1 Then
                TextHumedad.Enabled = True
            End If
            If sp1.PH = 1 Then
                TextPH.Enabled = True
            End If
            If sp1.CLORUROS = 1 Then
                TextCloruros.Enabled = True
            End If
            If sp1.PROTEINAS = 1 Then
                TextProteinas.Enabled = True
            End If
            If sp1.CENIZAS = 1 Then
                TextCenizas.Enabled = True
            End If
            If sp1.TABLANUTRICIONAL = 1 Then
                TextTNProteina.Enabled = True
                TextTNCarbohidratos.Enabled = True
                TextTNGrasasTotales.Enabled = True
                TextTNGrasasSaturadas.Enabled = True
                TextTNGrasasTrans.Enabled = True
                TextTNFibra.Enabled = True
                TextTNSodio.Enabled = True
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
        listarproductos()
    End Sub
    Private Sub guardar()
        Dim idsolicitud As Long = TextFicha.Text.Trim
        Dim fechaentrada As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fechaent As String
        fechaent = Format(fechaentrada, "yyyy-MM-dd")
        Dim fechaproceso As Date = DateFechaProceso.Value.ToString("yyyy-MM-dd")
        Dim fechapro As String
        fechapro = Format(fechaproceso, "yyyy-MM-dd")
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim idmuestra As String = TextMuestra.Text.Trim
        Dim detallemuestra As String = TextDetalleMuestra.Text.Trim
        Dim observaciones As String
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim estadomuestra As String
        If ComboEstadoMuestra.Text <> "" Then
            estadomuestra = ComboEstadoMuestra.Text
        End If
        Dim coliformestotales As String
        If TextColifTotales.Text <> "" Then
            coliformestotales = TextColifTotales.Text.Trim
        Else
            coliformestotales = -1
        End If
        Dim coliformesfecales As String
        If TextColifFecales.Text <> "" Then
            coliformesfecales = TextColifFecales.Text.Trim
        Else
            coliformesfecales = -1
        End If
        Dim ecoli As String
        If TextEColi.Text <> "" Then
            ecoli = TextEColi.Text.Trim
        Else
            ecoli = -1
        End If
        Dim enterobacterias As String
        If TextEnterobacterias.Text <> "" Then
            enterobacterias = TextEnterobacterias.Text.Trim
        Else
            enterobacterias = -1
        End If
        Dim estafcoag As String
        If TextEstafCoag.Text <> "" Then
            estafcoag = TextEstafCoag.Text.Trim
        Else
            estafcoag = -1
        End If
        Dim mohos As String
        If TextMohos.Text <> "" Then
            mohos = TextMohos.Text.Trim
        Else
            mohos = -1
        End If
        Dim levaduras As String
        If TextLevaduras.Text <> "" Then
            levaduras = TextLevaduras.Text.Trim
        Else
            levaduras = -1
        End If
        Dim idsalmonella As dSalmonella = CType(ComboSalmonella.SelectedItem, dSalmonella)
        Dim idlistmonocitogenes As dListeriaMono = CType(ComboListMonocitogenes.SelectedItem, dListeriaMono)
        Dim idlistspp As dListeriaSPP = CType(ComboListSPP.SelectedItem, dListeriaSPP)
        Dim idlistambiental As dListeriaAmbiental = CType(ComboListAmbiental.SelectedItem, dListeriaAmbiental)
        Dim listambiental As Double
        If TextListAmbiental.Text <> "" Then
            listambiental = TextListAmbiental.Text.Trim
        Else
            listambiental = -1
        End If
        Dim esporulados As Double
        If TextEsporulados.Text <> "" Then
            esporulados = TextEsporulados.Text.Trim
        Else
            esporulados = -1
        End If
        Dim termofilos As String
        If TextTermofilos.Text <> "" Then
            termofilos = TextTermofilos.Text.Trim
        Else
            termofilos = -1
        End If
        Dim psicrotrofos As String
        If TextPsicrotrofos.Text <> "" Then
            psicrotrofos = TextPsicrotrofos.Text.Trim
        Else
            psicrotrofos = -1
        End If
        Dim rb As String
        If TextRB.Text <> "" Then
            rb = TextRB.Text.Trim
        Else
            rb = -1
        End If
        Dim grasa As Double
        If TextGrasa.Text <> "" Then
            grasa = TextGrasa.Text.Trim
        Else
            grasa = -1
        End If
        Dim humedad As Double
        If TextHumedad.Text <> "" Then
            humedad = TextHumedad.Text.Trim
        Else
            humedad = -1
        End If
        Dim ph As Double
        If TextPH.Text <> "" Then
            ph = TextPH.Text.Trim
        Else
            ph = -1
        End If
        Dim cloruros As Double
        If TextCloruros.Text <> "" Then
            cloruros = TextCloruros.Text.Trim
        Else
            cloruros = -1
        End If
        Dim proteinas As Double
        If TextProteinas.Text <> "" Then
            proteinas = TextProteinas.Text.Trim
        Else
            proteinas = -1
        End If
        Dim cenizas As Double
        If TextCenizas.Text <> "" Then
            cenizas = TextCenizas.Text.Trim
        Else
            cenizas = -1
        End If
        Dim sodio As Double
        If TextTNSodio.Text <> "" Then
            sodio = TextTNSodio.Text.Trim
        Else
            sodio = -1
        End If
        Dim fibraalimenticia As Double
        If TextTNFibra.Text <> "" Then
            fibraalimenticia = TextTNFibra.Text.Trim
        Else
            fibraalimenticia = -1
        End If
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim sp2 As New dSubproducto2()
            Dim sp As New dSubproducto()
            Dim id As Long = CType(TextId.Text.Trim, Long)
            sp2.ID = id
            sp2.IDSOLICITUD = idsolicitud
            sp2.FECHASOLICITUD = fechaent
            sp2.FECHAPROCESO = fechapro
            sp.IDSOLICITUD = idsolicitud
            sp.FECHAPROCESO = fechapro
            sp2.IDMUESTRA = idmuestra
            sp2.DETALLEMUESTRA = detallemuestra
            sp2.OBSERVACIONES = observaciones
            sp2.ESTADOMUESTRA = estadomuestra
            sp2.CT = coliformestotales
            If metct <> 0 Then
                sp2.CT_MET = metct
            Else
                sp2.CT_MET = 7
            End If
            sp2.CF = coliformesfecales
            If metcf <> 0 Then
                sp2.CF_MET = metcf
            Else
                sp2.CF_MET = 10
            End If
            sp2.ECOLI = ecoli
            If metecoli <> 0 Then
                sp2.ECOLI_MET = metecoli
            Else
                sp2.ECOLI_MET = 11
            End If
            sp2.ENTEROBACTERIAS = enterobacterias
            If metenterobacterias <> 0 Then
                sp2.ENTEROBACTERIAS_MET = metenterobacterias
            Else
                sp2.ENTEROBACTERIAS_MET = 12
            End If
            sp2.ESTAFCOAGPOSITIVO = estafcoag
            If metestafilococo <> 0 Then
                sp2.ESTAFCOAGPOSITIVO_MET = metestafilococo
            Else
                sp2.ESTAFCOAGPOSITIVO_MET = 5
            End If
            sp2.MOHOS = mohos
            If metmohos <> 0 Then
                sp2.MOHOS_MET = metmohos
            Else
                sp2.MOHOS_MET = 1
            End If
            sp2.LEVADURAS = levaduras
            If metlevaduras <> 0 Then
                sp2.LEVADURAS_MET = metlevaduras
            Else
                sp2.LEVADURAS_MET = 1
            End If
            If Not idsalmonella Is Nothing Then
                sp2.SALMONELLA = idsalmonella.ID
            Else
                sp2.SALMONELLA = -1
            End If
            If metsalmonella <> 0 Then
                sp2.SALMONELLA_MET = metsalmonella
            Else
                sp2.SALMONELLA_MET = 18
            End If
            If Not idlistmonocitogenes Is Nothing Then
                sp2.LISTERIAMONOCITOGENES = idlistmonocitogenes.ID
            Else
                sp2.LISTERIAMONOCITOGENES = -1
            End If
            If metlistmono <> 0 Then
                sp2.LISTERIAMONOCITOGENES_MET = metlistmono
            Else
                sp2.LISTERIAMONOCITOGENES_MET = 22
            End If
            If Not idlistspp Is Nothing Then
                sp2.LISTERIASPP = idlistspp.ID
            Else
                sp2.LISTERIASPP = -1
            End If
            If metlistspp <> 0 Then
                sp2.LISTERIASPP_MET = metlistspp
            Else
                sp2.LISTERIASPP_MET = 22
            End If
            If Not idlistambiental Is Nothing Then
                sp2.LISTERIAAMBIENTAL = idlistambiental.ID
            Else
                sp2.LISTERIAAMBIENTAL = -1
            End If
            sp2.LISTERIAAMBIENTAL2 = listambiental
            If metlistambiental <> 0 Then
                sp2.LISTERIAAMBIENTAL_MET = metlistambiental
            Else
                sp2.LISTERIAAMBIENTAL_MET = 24
            End If
            sp2.ESPORANAERMESOFILO = esporulados
            If metesporulados <> 0 Then
                sp2.ESPORANAERMESOFILO_MET = metesporulados
            Else
                sp2.ESPORANAERMESOFILO_MET = 25
            End If
            sp2.TERMOFILOS = termofilos
            If mettermofilos <> 0 Then
                sp2.TERMOFILOS_MET = mettermofilos
            Else
                sp2.TERMOFILOS_MET = 49
            End If
            sp2.PSICROTROFOS = psicrotrofos
            If metpsicrotrofos <> 0 Then
                sp2.PSICROTROFOS_MET = metpsicrotrofos
            Else
                sp2.PSICROTROFOS_MET = 17
            End If
            sp2.RB = rb
            If metrb <> 0 Then
                sp2.RB_MET = metpsicrotrofos
            Else
                sp2.RB_MET = 14
            End If
            sp2.MGRASA = grasa
            If metgrasa <> 0 Then
                sp2.MGRASA_MET = metgrasa
            Else
                sp2.MGRASA_MET = 37
            End If
            sp2.HUMEDAD = humedad
            If methumedad <> 0 Then
                sp2.HUMEDAD_MET = methumedad
            Else
                sp2.HUMEDAD_MET = 35
            End If
            sp2.PH = ph
            If metph <> 0 Then
                sp2.PH_MET = metph
            Else
                sp2.PH_MET = 45
            End If
            sp2.CLORUROS = cloruros
            If metcloruros <> 0 Then
                sp2.CLORUROS_MET = metcloruros
            Else
                sp2.CLORUROS_MET = 46
            End If
            sp2.PROTEINAS = proteinas
            If metproteinas <> 0 Then
                sp2.PROTEINAS_MET = metproteinas
            Else
                sp2.PROTEINAS_MET = 41
            End If
            sp2.CENIZAS = cenizas
            If metcenizas <> 0 Then
                sp2.CENIZAS_MET = metcenizas
            Else
                sp2.CENIZAS_MET = 47
            End If
            sp2.TNSODIO = sodio
            sp2.TNFIBRAALIMENTICIA = fibraalimenticia
            sp2.OPERADOR = operador
            sp2.MARCA = 0
            If (sp2.modificar(Usuario)) Then
                sp.modificar2(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'listaragua()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim sp2 As New dSubproducto2()
            Dim sp As New dSubproducto()
            sp2.IDSOLICITUD = idsolicitud
            sp.ID = idsolicitud
            sp2.FECHASOLICITUD = fechaent
            sp2.FECHAPROCESO = fechapro
            sp.FECHAPROCESO = fechapro
            sp2.IDMUESTRA = idmuestra
            sp2.DETALLEMUESTRA = detallemuestra
            sp2.OBSERVACIONES = observaciones
            sp2.ESTADOMUESTRA = estadomuestra
            sp2.CT = coliformestotales
            If metct <> 0 Then
                sp2.CT_MET = metct
            Else
                sp2.CT_MET = 7
            End If
            sp2.CF = coliformesfecales
            If metcf <> 0 Then
                sp2.CF_MET = metcf
            Else
                sp2.CF_MET = 10
            End If
            sp2.ECOLI = ecoli
            If metecoli <> 0 Then
                sp2.ECOLI_MET = metecoli
            Else
                sp2.ECOLI_MET = 11
            End If
            sp2.ENTEROBACTERIAS = enterobacterias
            If metenterobacterias <> 0 Then
                sp2.ENTEROBACTERIAS_MET = metenterobacterias
            Else
                sp2.ENTEROBACTERIAS_MET = 12
            End If
            sp2.ESTAFCOAGPOSITIVO = estafcoag
            If metestafilococo <> 0 Then
                sp2.ESTAFCOAGPOSITIVO_MET = metestafilococo
            Else
                sp2.ESTAFCOAGPOSITIVO_MET = 5
            End If
            sp2.MOHOS = mohos
            If metmohos <> 0 Then
                sp2.MOHOS_MET = metmohos
            Else
                sp2.MOHOS_MET = 1
            End If
            sp2.LEVADURAS = levaduras
            If metlevaduras <> 0 Then
                sp2.LEVADURAS_MET = metlevaduras
            Else
                sp2.LEVADURAS_MET = 1
            End If
            If Not idsalmonella Is Nothing Then
                sp2.SALMONELLA = idsalmonella.ID
            End If
            If metsalmonella <> 0 Then
                sp2.SALMONELLA_MET = metsalmonella
            Else
                sp2.SALMONELLA_MET = 18
            End If
            If Not idlistmonocitogenes Is Nothing Then
                sp2.LISTERIAMONOCITOGENES = idlistmonocitogenes.ID
            End If
            If metlistmono <> 0 Then
                sp2.LISTERIAMONOCITOGENES_MET = metlistmono
            Else
                sp2.LISTERIAMONOCITOGENES_MET = 22
            End If
            If Not idlistspp Is Nothing Then
                sp2.LISTERIASPP = idlistspp.ID
            End If
            If metlistspp <> 0 Then
                sp2.LISTERIASPP_MET = metlistspp
            Else
                sp2.LISTERIASPP_MET = 22
            End If
            If Not idlistambiental Is Nothing Then
                sp2.LISTERIAAMBIENTAL = idlistambiental.ID
            End If
            sp2.LISTERIAAMBIENTAL2 = listambiental
            If metlistambiental <> 0 Then
                sp2.LISTERIAAMBIENTAL_MET = metlistambiental
            Else
                sp2.LISTERIAAMBIENTAL_MET = 24
            End If
            sp2.ESPORANAERMESOFILO = esporulados
            If metesporulados <> 0 Then
                sp2.ESPORANAERMESOFILO_MET = metesporulados
            Else
                sp2.ESPORANAERMESOFILO_MET = 25
            End If
            sp2.TERMOFILOS = termofilos
            If mettermofilos <> 0 Then
                sp2.TERMOFILOS_MET = mettermofilos
            Else
                sp2.TERMOFILOS_MET = 49
            End If
            sp2.PSICROTROFOS = psicrotrofos
            If metpsicrotrofos <> 0 Then
                sp2.PSICROTROFOS_MET = metpsicrotrofos
            Else
                sp2.PSICROTROFOS_MET = 17
            End If
            sp2.RB = rb
            If metrb <> 0 Then
                sp2.RB_MET = metpsicrotrofos
            Else
                sp2.RB_MET = 14
            End If
            sp2.MGRASA = grasa
            If metgrasa <> 0 Then
                sp2.MGRASA_MET = metgrasa
            Else
                sp2.MGRASA_MET = 37
            End If
            sp2.HUMEDAD = humedad
            If methumedad <> 0 Then
                sp2.HUMEDAD_MET = methumedad
            Else
                sp2.HUMEDAD_MET = 34
            End If
            sp2.PH = ph
            If metph <> 0 Then
                sp2.PH_MET = metph
            Else
                sp2.PH_MET = 45
            End If
            sp2.CLORUROS = cloruros
            If metcloruros <> 0 Then
                sp2.CLORUROS_MET = metcloruros
            Else
                sp2.CLORUROS_MET = 46
            End If
            sp2.PROTEINAS = proteinas
            If metproteinas <> 0 Then
                sp2.PROTEINAS_MET = metproteinas
            Else
                sp2.PROTEINAS_MET = 41
            End If
            sp2.CENIZAS = cenizas
            If metcenizas <> 0 Then
                sp2.CENIZAS_MET = metcenizas
            Else
                sp2.CENIZAS_MET = 47
            End If
            sp2.TNSODIO = sodio
            sp2.TNFIBRAALIMENTICIA = fibraalimenticia
            sp2.OPERADOR = operador
            sp2.MARCA = 0
            If (sp2.guardar(Usuario)) Then
                sp.modificar2(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'listaragua()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    

    Private Sub ComboEstadoMuestra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEstadoMuestra.SelectedIndexChanged
        cambiolabel()
    End Sub

    Private Sub ButtonCT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCT.Click
        textometodo = "Coliformes totales"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metct = met.ID
        End If
    End Sub

    Private Sub ButtonCF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCF.Click
        textometodo = "Coliformes termotolerantes"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metcf = met.ID
        End If
    End Sub

    Private Sub ButtonEColi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEColi.Click
        textometodo = "E.coli"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metecoli = met.ID
        End If
    End Sub

    Private Sub ButtonEntBact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEntBact.Click
        textometodo = "Enterobacterias"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metenterobacterias = met.ID
        End If
    End Sub

    Private Sub ButtonEstafCoag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEstafCoag.Click
        textometodo = "Estafilococo coagulasa positivo"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metestafilococo = met.ID
        End If
    End Sub

    Private Sub ButtonMohos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMohos.Click
        textometodo = "Mohos y levaduras"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metmohos = met.ID
        End If
    End Sub

    Private Sub ButtonLevaduras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLevaduras.Click
        textometodo = "Mohos y levaduras"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metlevaduras = met.ID
        End If
    End Sub

    Private Sub ButtonSalmonella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalmonella.Click
        textometodo = "Salmonella spp"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metsalmonella = met.ID
        End If
    End Sub

    Private Sub ButtonListMono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListMono.Click
        textometodo = "Listeria monocitogenes"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metlistmono = met.ID
        End If
    End Sub

    Private Sub ButtonListSPP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListSPP.Click
        textometodo = "Listeria monocitogenes"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metlistmono = met.ID
        End If
    End Sub

    Private Sub ButtonListAmb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListAmb.Click
        textometodo = "Listeria ambiental"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metlistambiental = met.ID
        End If
    End Sub

    Private Sub ButtonEsporulados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEsporulados.Click
        textometodo = "Esporulados anaerobios"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metesporulados = met.ID
        End If
    End Sub

    Private Sub ButtonTermofilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTermofilos.Click
        textometodo = "Termodúricos"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            mettermofilos = met.ID
        End If
    End Sub

    Private Sub ButtonPsicrotrofos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPsicrotrofos.Click
        textometodo = "Recuento bact. Psicotrofo"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metpsicrotrofos = met.ID
        End If
    End Sub

    Private Sub ButtonGrasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGrasa.Click
        textometodo = "Materia Grasa"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metgrasa = met.ID
        End If
    End Sub

    Private Sub ButtonHumedad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHumedad.Click
        textometodo = "Sólidos totales"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            methumedad = met.ID
        End If
    End Sub

    Private Sub ButtonPH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPH.Click
        textometodo = "pH"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metph = met.ID
        End If
    End Sub

    Private Sub ButtonCloruros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCloruros.Click
        textometodo = "Cloruros Totales"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metcloruros = met.ID
        End If
    End Sub

    Private Sub ButtonProteinas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonProteinas.Click
        textometodo = "Proteína"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metproteinas = met.ID
        End If
    End Sub

    Private Sub ButtonCenizas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCenizas.Click
        textometodo = "Cenizas"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metcenizas = met.ID
        End If
    End Sub

    Private Sub ButtonRB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRB.Click
        textometodo = "Recuento Bacteriano Mesofilo"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metrb = met.ID
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        guardar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim sp2 As dSubproducto2 = CType(ListFichas.SelectedItem, dSubproducto2)
            Dim id As Long = sp2.IDSOLICITUD
            Dim lista As New ArrayList
            lista = sp2.listarporid(id)
            'ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each sp2 In lista
                        Dim fechaemision As Date = Now()
                        Dim fechaemi As String
                        fechaemi = Format(fechaemision, "yyyy-MM-dd")
                        sp2.MARCA = 1
                        If (sp2.modificar2(Usuario)) Then
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    Next
                End If
            End If
            listarproductos()
            If ListMuestras.Items.Count = 0 Then
                creainformeexcel()
                listarfichas()
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

        Dim sp As New dSubproducto
        Dim sp2 As New dSubproducto2
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim met As New dMetodos
        Dim lista As New ArrayList
        '*****************************
        'idsol = TextBox1.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        sp.IDSOLICITUD = idsol
        sp = sp.buscarxsolicitud
        '*****************************
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
        lista = sp2.listarporsolicitud2(idsol)
        'x1hoja.Range("H8", "J8").Merge()
        x1hoja.Cells(6, 4).formula = sa.FECHAINGRESO
        x1hoja.Cells(6, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 4).Font.Size = 9
        'x1hoja.Range("H9", "L9").Merge()
        x1hoja.Cells(7, 4).formula = sp.FECHAPROCESO
        x1hoja.Cells(7, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 4).Font.Size = 9
        'x1hoja.Range("H10", "L10").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(8, 4).formula = fecha2
        x1hoja.Cells(8, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 4).Font.Size = 9
        Dim fila As Integer
        Dim columna As Integer
        'fila = 17
        'columna = 1
        'ListAntibiogramas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 2


                'Poner Titulos
                x1hoja.Shapes.AddPicture("c:\Debug\logo.jpg", _
                Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 80, 35)

                

                'x1hoja.Shapes.AddPicture("c:\Debug\oua.jpg", _
                'Microsoft.Office.Core.MsoTriState.msoFalse, _
                'Microsoft.Office.Core.MsoTriState.msoCTrue, 220, 0, 80, 35)


                x1hoja.Cells(3, 1).columnwidth = 15
                x1hoja.Cells(3, 2).columnwidth = 27
                x1hoja.Cells(3, 3).columnwidth = 17
                x1hoja.Cells(3, 4).columnwidth = 24
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
                x1hoja.Range("B5", "C5").Merge()
                fila = fila + 2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE LECHE Y DERIVADOS"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Cliente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Fecha informe:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Muestras extraídas y transportadas por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Material enviado:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                Dim texto As String = ""
                For Each sp2 In lista
                    texto = texto & " - " & sp2.IDMUESTRA
                Next
                
                x1hoja.Range("B12", "D13").Merge()
                x1hoja.Range("B12", "D13").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Estudio solicitado"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                sp.IDSOLICITUD = idsol
                sp = sp.buscarxsolicitud
                Dim texto2 As String = ""
                If sp.ESTAFCOAGPOSITIVO = 1 Then
                    texto2 = texto2 & " - " & "Estafilococo coag. positivo"
                End If
                If sp.CF = 1 Then
                    texto2 = texto2 & " - " & "Coliformes 44ºC"
                End If
                If sp.MOHOSYLEVADURAS = 1 Then
                    texto2 = texto2 & " - " & "Mohos y levaduras"
                End If
                If sp.CT = 1 Then
                    texto2 = texto2 & " - " & "Coliformes totales"
                End If
                If sp.ECOLI = 1 Then
                    texto2 = texto2 & " - " & "E.Coli"
                End If
                If sp.SALMONELLA = 1 Then
                    texto2 = texto2 & " - " & "Salmonella spp"
                End If
                If sp.LISTERIASPP = 1 Then
                    texto2 = texto2 & " - " & "Listeria monocytógenes"
                End If
                If sp.HUMEDAD = 1 Then
                    texto2 = texto2 & " - " & "Sólidos totales"
                End If
                If sp.MGRASA = 1 Then
                    texto2 = texto2 & " - " & "Grasa"
                End If
                If sp.PH = 1 Then
                    texto2 = texto2 & " - " & "pH"
                End If
                If sp.CLORUROS = 1 Then
                    texto2 = texto2 & " - " & "Cloruros"
                End If
                If sp.PROTEINAS = 1 Then
                    texto2 = texto2 & " - " & "Proteínas"
                End If
                If sp.ENTEROBACTERIAS = 1 Then
                    texto2 = texto2 & " - " & "Enterobacterias"
                End If
                If sp.LISTERIAAMBIENTAL = 1 Then
                    texto2 = texto2 & " - " & "Listeria ambiental"
                End If
                If sp.ESPORANAERMESOFILO = 1 Then
                    texto2 = texto2 & " - " & "Esporulados"
                End If
                If sp.TERMOFILOS = 1 Then
                    texto2 = texto2 & " - " & "Termofilos"
                End If
                If sp.PSICROTROFOS = 1 Then
                    texto2 = texto2 & " - " & "Psicrotrofos"
                End If
                If sp.RB = 1 Then
                    texto2 = texto2 & " - " & "Recuento bacteriano"
                End If
                If sp.LISTERIAMONOCITOGENES = 1 Then
                    texto2 = texto2 & " - " & "Listeria monocytógenes"
                End If
                If sp.TABLANUTRICIONAL = 1 Then
                    texto2 = texto2 & " - " & "Tabla nutricional"
                End If
                If sp.CENIZAS = 1 Then
                    texto2 = texto2 & " - " & "Cenizas"
                End If
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
                x1hoja.Cells(fila, columna).Formula = "Se recibieron los siguientes productos:"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                Dim cuenta As Integer = 1
                For Each sp2 In lista
                    x1hoja.Cells(fila, columna).Formula = cuenta & ")" & " " & sp2.DETALLEMUESTRA
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    cuenta = cuenta + 1
                Next
                cuenta = cuenta - 1
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1

                '*** METODOS*************************************************************************
                Dim texto3 As String = "Preparación de muestras, suspenciones y diluciones ISO 8261/IDF 122:2001"
                Dim cuentametodos As Integer = 1
                For Each sp2 In lista
                    If cuentametodos < 2 Then
                        If sp2.ESTAFCOAGPOSITIVO <> "-1" And sp2.ESTAFCOAGPOSITIVO_MET <> 0 Then
                            met.ID = sp2.ESTAFCOAGPOSITIVO_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Estaf. coagulasa positivo:" & " " & met.ESTANDAR
                        End If
                        If sp2.CF <> "-1" And sp2.CF_MET <> 0 Then
                            met.ID = sp2.CF_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Coliformes 44ºC:" & " " & met.ESTANDAR
                        End If
                        If sp2.MOHOS <> "-1" And sp2.MOHOS_MET <> 0 Then
                            met.ID = sp2.MOHOS_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Mohos y levaduras:" & " " & met.ESTANDAR
                        End If
                        If sp2.CT <> "-1" And sp2.CT_MET <> 0 Then
                            met.ID = sp2.CT_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Coliformes totales:" & " " & met.ESTANDAR
                        End If
                        If sp2.ECOLI <> "-1" And sp2.ECOLI_MET <> 0 Then
                            met.ID = sp2.ECOLI_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "E. Coli:" & " " & met.ESTANDAR
                        End If
                        If sp2.SALMONELLA <> -1 And sp2.SALMONELLA_MET <> 0 Then
                            met.ID = sp2.SALMONELLA_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "* Salmonella spp:" & " " & met.ESTANDAR
                        End If
                        If sp2.LISTERIASPP <> -1 And sp2.LISTERIASPP_MET <> 0 Then
                            met.ID = sp2.LISTERIASPP_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "* Listeria Monocytógenes:" & " " & met.ESTANDAR
                        End If
                        If sp2.HUMEDAD <> -1 And sp2.HUMEDAD_MET <> 0 Then
                            met.ID = sp2.HUMEDAD_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "* Sólidos totales:" & " " & met.ESTANDAR
                        End If
                        If sp2.MGRASA <> -1 And sp2.MGRASA_MET <> 0 Then
                            met.ID = sp2.MGRASA_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Grasa:" & " " & met.ESTANDAR
                        End If
                        If sp2.PH <> -1 And sp2.PH_MET <> 0 Then
                            met.ID = sp2.PH_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "pH:" & " " & met.ESTANDAR
                        End If
                        If sp2.CLORUROS <> -1 And sp2.CLORUROS_MET <> 0 Then
                            met.ID = sp2.CLORUROS_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Cloruros:" & " " & met.ESTANDAR
                        End If
                        If sp2.PROTEINAS <> -1 And sp2.PROTEINAS_MET <> 0 Then
                            met.ID = sp2.PROTEINAS_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Proteínas:" & " " & met.ESTANDAR
                        End If
                        If sp2.ENTEROBACTERIAS <> "-1" And sp2.ENTEROBACTERIAS_MET <> 0 Then
                            met.ID = sp2.ENTEROBACTERIAS_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Enterobacterias:" & " " & met.ESTANDAR
                        End If
                        If sp2.LISTERIAAMBIENTAL <> -1 And sp2.LISTERIAAMBIENTAL_MET <> 0 Then
                            met.ID = sp2.LISTERIAAMBIENTAL_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Listeria ambiental:" & " " & met.ESTANDAR
                        End If
                        If sp2.ESPORANAERMESOFILO <> -1 And sp2.ESPORANAERMESOFILO_MET <> 0 Then
                            met.ID = sp2.ESPORANAERMESOFILO_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Esporulados:" & " " & met.ESTANDAR
                        End If
                        If sp2.TERMOFILOS <> "-1" And sp2.TERMOFILOS_MET <> 0 Then
                            met.ID = sp2.TERMOFILOS_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Termofilos:" & " " & met.ESTANDAR
                        End If
                        If sp2.PSICROTROFOS <> "-1" And sp2.PSICROTROFOS_MET <> 0 Then
                            met.ID = sp2.PSICROTROFOS_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Psicrotrofos:" & " " & met.ESTANDAR
                        End If
                        If sp2.RB <> "-1" And sp2.RB_MET <> 0 Then
                            met.ID = sp2.RB_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Recuento bacteriano:" & " " & met.ESTANDAR
                        End If
                        If sp2.LISTERIAMONOCITOGENES <> -1 And sp2.LISTERIAMONOCITOGENES_MET <> 0 Then
                            met.ID = sp2.LISTERIAMONOCITOGENES_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Listeria monocytógenes:" & " " & met.ESTANDAR
                        End If
                        If sp2.CENIZAS <> -1 And sp2.CENIZAS_MET <> 0 Then
                            met.ID = sp2.CENIZAS_MET
                            met = met.buscar
                            texto3 = texto3 & " - " & "Cenizas:" & " " & met.ESTANDAR
                        End If
                        cuentametodos = cuentametodos + 1
                    End If
                Next
                If cuenta = 1 Then
                    x1hoja.Range("A21", "D24").Merge()
                    x1hoja.Range("A21", "D24").WrapText = True
                ElseIf cuenta = 2 Then
                    x1hoja.Range("A22", "D25").Merge()
                    x1hoja.Range("A22", "D25").WrapText = True
                ElseIf cuenta = 3 Then
                    x1hoja.Range("A23", "D26").Merge()
                    x1hoja.Range("A23", "D26").WrapText = True
                ElseIf cuenta = 4 Then
                    x1hoja.Range("A24", "D27").Merge()
                    x1hoja.Range("A24", "D27").WrapText = True
                ElseIf cuenta = 5 Then
                    x1hoja.Range("A25", "D28").Merge()
                    x1hoja.Range("A25", "D28").WrapText = True
                ElseIf cuenta = 6 Then
                    x1hoja.Range("A26", "D29").Merge()
                    x1hoja.Range("A26", "D29").WrapText = True
                ElseIf cuenta = 7 Then
                    x1hoja.Range("A27", "D30").Merge()
                    x1hoja.Range("A27", "D30").WrapText = True
                ElseIf cuenta = 8 Then
                    x1hoja.Range("A28", "D31").Merge()
                    x1hoja.Range("A28", "D31").WrapText = True
                ElseIf cuenta = 9 Then
                    x1hoja.Range("A29", "D32").Merge()
                    x1hoja.Range("A29", "D32").WrapText = True
                ElseIf cuenta = 10 Then
                    x1hoja.Range("A30", "D33").Merge()
                    x1hoja.Range("A30", "D33").WrapText = True
                ElseIf cuenta = 11 Then
                    x1hoja.Range("A31", "D34").Merge()
                    x1hoja.Range("A31", "D34").WrapText = True
                ElseIf cuenta = 12 Then
                    x1hoja.Range("A32", "D35").Merge()
                    x1hoja.Range("A32", "D35").WrapText = True
                End If
                x1hoja.Cells(fila, columna).Formula = texto3
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = 1
                fila = fila + 4
                '*** FIN METODOS *********************************************************************
                x1hoja.Cells(fila, columna).Formula = "INFORME"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 2
                Dim linea As Integer = 0
                Dim i As Integer = 1
                For Each sp2 In lista



                    'For i = 1 To lista.Count
                    'PRODUCTO 1 ****************************************************************
                    If i = 1 Then
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 1
                        linea = linea + 1


                        If sp2.CT <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.CF <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ECOLI <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.MOHOS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LEVADURAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.SALMONELLA <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAMONOCITOGENES <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocytógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocytógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIASPP <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAAMBIENTAL <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESPORANAERMESOFILO <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.TERMOFILOS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.PSICROTROFOS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                        End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Grasa % m/m"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sólidos totales % m/m"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "pH"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cloruros % m/m"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Proteínas % m/m"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cenizas % m/m"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 2 ****************************************************************
                        If i = 2 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 3 ****************************************************************
                        If i = 3 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 4 ****************************************************************
                        If i = 4 Then
                            columna = 1
                            linea = 0
                            fila = fila + 2
                            x1hoja.Cells(fila, columna).Formula = "Análisis"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1


                        If sp2.CT <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.CF <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ECOLI <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.MOHOS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LEVADURAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.SALMONELLA <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAMONOCITOGENES <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocitógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocitógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIASPP <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAAMBIENTAL <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESPORANAERMESOFILO <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.TERMOFILOS <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.PSICROTROFOS <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                        End If
                        If sp2.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.MGRASA <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Grasa % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.HUMEDAD <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sólidos totales % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.PH <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.PH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.CLORUROS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cloruros % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.PROTEINAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Proteínas % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.CENIZAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cenizas % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                    End If
                        'PRODUCTO 5 ****************************************************************
                        If i = 5 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 6 ****************************************************************
                        If i = 6 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 7 ****************************************************************
                        If i = 7 Then
                            columna = 1
                            linea = 0
                            fila = fila + 2
                            x1hoja.Cells(fila, columna).Formula = "Análisis"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1


                        If sp2.CT <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.CF <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ECOLI <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.MOHOS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LEVADURAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.SALMONELLA <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAMONOCITOGENES <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocitógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocitógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIASPP <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAAMBIENTAL <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESPORANAERMESOFILO <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.TERMOFILOS <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.PSICROTROFOS <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                        End If
                        If sp2.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.MGRASA <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Grasa % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.HUMEDAD <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sólidos totales % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.PH <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.PH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.CLORUROS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cloruros % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.PROTEINAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Proteínas % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.CENIZAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cenizas % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                    End If
                        'PRODUCTO 8 ****************************************************************
                        If i = 8 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 9 ****************************************************************
                        If i = 9 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 10 ****************************************************************
                        If i = 10 Then
                            columna = 1
                            linea = 0
                            fila = fila + 2
                            x1hoja.Cells(fila, columna).Formula = "Análisis"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1


                        If sp2.CT <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes totales /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.CF <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Coliformes 44ºC /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ECOLI <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "E.Coli /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Enterobacterias /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Estaf. coag. positivo /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.MOHOS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LEVADURAS <> "-1" Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.SALMONELLA <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAMONOCITOGENES <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocitógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria monocitógenes /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIASPP <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria SPP /25g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.LISTERIAAMBIENTAL <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Listeria ambiental"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                    columna = columna - 1
                                End If
                                linea = linea + 1
                            End If
                        End If
                        If sp2.ESPORANAERMESOFILO <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Esporulados /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.TERMOFILOS <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Termodúricos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If
                        End If
                        If sp2.PSICROTROFOS <> -1 Then
                            If sp2.ESTADOMUESTRA = "líquido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /ml"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            ElseIf sp2.ESTADOMUESTRA = "sólido" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Psicrotrofos /g"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                columna = columna - 1
                                linea = linea + 1
                            End If

                        End If
                        If sp2.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Recuento bacteriano"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.MGRASA <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Grasa % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.HUMEDAD <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sólidos totales % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.PH <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.PH
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.CLORUROS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cloruros % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.PROTEINAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Proteínas % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If sp2.CENIZAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Cenizas % m/m"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If
                    End If
                        'PRODUCTO 11 ****************************************************************
                        If i = 11 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 2
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MGRASA
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.HUMEDAD
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'PRODUCTO 12 ****************************************************************
                        If i = 12 Then
                            fila = fila - linea
                            fila = fila + 1
                            linea = 0
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1


                            If sp2.CT <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CT
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CF <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CF
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.ECOLI <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ECOLI
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        If sp2.ENTEROBACTERIAS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = sp2.ENTEROBACTERIAS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                            If sp2.ESTAFCOAGPOSITIVO <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.ESTAFCOAGPOSITIVO
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MOHOS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.MOHOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.LEVADURAS <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.LEVADURAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.SALMONELLA <> -1 Then
                                fila = fila + 1
                                If sp2.SALMONELLA = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAMONOCITOGENES <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAMONOCITOGENES = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIASPP <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIASPP = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.LISTERIAAMBIENTAL <> -1 Then
                                fila = fila + 1
                                If sp2.LISTERIAAMBIENTAL = 1 Then
                                    x1hoja.Cells(fila, columna).Formula = "Presencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                Else
                                    x1hoja.Cells(fila, columna).Formula = "Ausencia"
                                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                    x1hoja.Cells(fila, columna).Font.Bold = False
                                    x1hoja.Cells(fila, columna).Font.Size = 8
                                End If
                                linea = linea + 1
                            End If
                            If sp2.ESPORANAERMESOFILO <> -1 Then
                                fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = FormatNumber(sp2.ESPORANAERMESOFILO, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.TERMOFILOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.TERMOFILOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PSICROTROFOS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PSICROTROFOS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.RB <> "-1" Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.RB
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.MGRASA <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = Math.Round(sp2.MGRASA, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.HUMEDAD <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = Math.Round(sp2.HUMEDAD, 2)
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PH <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PH
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CLORUROS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CLORUROS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.PROTEINAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.PROTEINAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                            If sp2.CENIZAS <> -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = sp2.CENIZAS
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = False
                                x1hoja.Cells(fila, columna).Font.Size = 8
                                linea = linea + 1
                            End If
                        End If
                        'Next i
                        i = i + 1
                Next

                '***************************************

                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "(%Humedad = 100 - %Sólidos totales)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                columna = 1

                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                If sa.OBSERVACIONES <> "" Then
                    columna = columna + 1
                    'x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                End If
                fila = fila + 1



                '******* CALCULO PRECIO ************************************************************************

                Dim subp2 As New dSubproducto2
                Dim subp As New dSubproducto
                subp.IDSOLICITUD = idsol
                subp = subp.buscarxsolicitud
                Dim listamuestras As New ArrayList
                listamuestras = subp2.listarporid(idsol)

                Dim ana As New dAnalisis
                Dim idpaquete1 As Integer = 94
                Dim idpaquete2 As Integer = 95
                Dim idpaquete3 As Integer = 96
                Dim idhumedad As Integer = 29
                Dim idgrasa As Integer = 30
                Dim idph As Integer = 31
                Dim idcloruros As Integer = 10
                Dim idproteinas As Integer = 32
                Dim idcenizas As Integer = 64
                Dim idestaf As Integer = 24
                Dim idcf As Integer = 22
                Dim idct As Integer = 21
                Dim idmohos As Integer = 28
                Dim idecoli As Integer = 23
                Dim idsalmonella As Integer = 27
                Dim idlistspp As Integer = 25
                Dim idlistmono As Integer = 141
                Dim idesporulados As Integer = 8
                Dim idtermoduricos As Integer = 62
                Dim idpsicrotrofos As Integer = 61
                Dim identerobacterias As Integer = 9
                Dim idrb As Integer = 1
                Dim idtimbre As Integer = 86
                Dim preciopaquete1 As Double = 0
                Dim preciopaquete2 As Double = 0
                Dim preciopaquete3 As Double = 0
                Dim preciohumedad As Double = 0
                Dim preciograsa As Double = 0
                Dim precioph As Double = 0
                Dim preciocloruros As Double = 0
                Dim precioproteinas As Double = 0
                Dim preciocenizas As Double = 0
                Dim precioestaf As Double = 0
                Dim preciocf As Double = 0
                Dim precioct As Double = 0
                Dim preciomohos As Double = 0
                Dim precioecoli As Double = 0
                Dim preciosalmonella As Double = 0
                Dim preciolistspp As Double = 0
                Dim preciolistmono As Double = 0
                Dim precioesporulados As Double = 0
                Dim preciotermoduricos As Double = 0
                Dim preciopsicrotrofos As Double = 0
                Dim precioenterobacterias As Double = 0
                Dim preciorb As Double = 0
                Dim preciotimbre As Double = 0
                ana.ID = idpaquete1
                ana = ana.buscar
                preciopaquete1 = ana.COSTO
                ana.ID = idpaquete2
                ana = ana.buscar
                preciopaquete2 = ana.COSTO
                ana.ID = idpaquete3
                ana = ana.buscar
                preciopaquete3 = ana.COSTO
                ana.ID = idhumedad
                ana = ana.buscar
                preciohumedad = ana.COSTO
                ana.ID = idgrasa
                ana = ana.buscar
                preciograsa = ana.COSTO
                ana.ID = idph
                ana = ana.buscar
                precioph = ana.COSTO
                ana.ID = idcloruros
                ana = ana.buscar
                preciocloruros = ana.COSTO
                ana.ID = idproteinas
                ana = ana.buscar
                precioproteinas = ana.COSTO
                ana.ID = idcenizas
                ana = ana.buscar
                preciocenizas = ana.COSTO
                ana.ID = idestaf
                ana = ana.buscar
                precioestaf = ana.COSTO
                ana.ID = idcf
                ana = ana.buscar
                preciocf = ana.COSTO
                ana.ID = idct
                ana = ana.buscar
                precioct = ana.COSTO
                ana.ID = idmohos
                ana = ana.buscar
                preciomohos = ana.COSTO
                ana.ID = idecoli
                ana = ana.buscar
                precioecoli = ana.COSTO
                ana.ID = idsalmonella
                ana = ana.buscar
                preciosalmonella = ana.COSTO
                ana.ID = idlistspp
                ana = ana.buscar
                preciolistspp = ana.COSTO
                ana.ID = idlistmono
                ana = ana.buscar
                preciolistmono = ana.COSTO
                ana.ID = idesporulados
                ana = ana.buscar
                precioesporulados = ana.COSTO
                ana.ID = idtermoduricos
                ana = ana.buscar
                preciotermoduricos = ana.COSTO
                ana.ID = idpsicrotrofos
                ana = ana.buscar
                preciopsicrotrofos = ana.COSTO
                ana.ID = identerobacterias
                ana = ana.buscar
                precioenterobacterias = ana.COSTO
                ana.ID = idrb
                ana = ana.buscar
                preciorb = ana.COSTO
                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO
                Dim total As Double
                Dim subtipo As Integer
                Dim muestras As Integer
                muestras = listamuestras.Count
                subtipo = sa.IDSUBINFORME
                If subtipo = 14 Then
                    total = ((total + preciopaquete1) * muestras)

                    If subp.HUMEDAD = 1 Then
                        total = total + (preciohumedad * muestras)
                    End If
                    If subp.MGRASA = 1 Then
                        total = total + (preciograsa * muestras)
                    End If
                    If subp.PH = 1 Then
                        total = total + (precioph * muestras)
                    End If
                    If subp.CLORUROS = 1 Then
                        total = total + (preciocloruros * muestras)
                    End If
                    If subp.PROTEINAS = 1 Then
                        total = total + (precioproteinas * muestras)
                    End If
                    If subp.CENIZAS = 1 Then
                        total = total + (preciocenizas * muestras)
                    End If
                    If subp.ESPORANAERMESOFILO = 1 Then
                        total = total + (precioesporulados * muestras)
                    End If
                    If subp.TERMOFILOS = 1 Then
                        total = total + (preciotermoduricos * muestras)
                    End If
                    If subp.PSICROTROFOS = 1 Then
                        total = total + (preciopsicrotrofos * muestras)
                    End If
                    If subp.ENTEROBACTERIAS = 1 Then
                        total = total + (precioenterobacterias * muestras)
                    End If
                End If
                If subtipo = 15 Then
                    total = ((total + preciopaquete2) * muestras)

                    If subp.HUMEDAD = 1 Then
                        total = total + (preciohumedad * muestras)
                    End If
                    If subp.MGRASA = 1 Then
                        total = total + (preciograsa * muestras)
                    End If
                    If subp.PH = 1 Then
                        total = total + (precioph * muestras)
                    End If
                    If subp.CLORUROS = 1 Then
                        total = total + (preciocloruros * muestras)
                    End If
                    If subp.PROTEINAS = 1 Then
                        total = total + (precioproteinas * muestras)
                    End If
                    If subp.CENIZAS = 1 Then
                        total = total + (preciocenizas * muestras)
                    End If
                    If subp.ESPORANAERMESOFILO = 1 Then
                        total = total + (precioesporulados * muestras)
                    End If
                    If subp.TERMOFILOS = 1 Then
                        total = total + (preciotermoduricos * muestras)
                    End If
                    If subp.PSICROTROFOS = 1 Then
                        total = total + (preciopsicrotrofos * muestras)
                    End If
                    If subp.ENTEROBACTERIAS = 1 Then
                        total = total + (precioenterobacterias * muestras)
                    End If
                End If
                If subtipo = 17 Then
                    total = ((total + preciopaquete3) * muestras)

                    If subp.HUMEDAD = 1 Then
                        total = total + (preciohumedad * muestras)
                    End If
                    If subp.MGRASA = 1 Then
                        total = total + (preciograsa * muestras)
                    End If
                    If subp.PH = 1 Then
                        total = total + (precioph * muestras)
                    End If
                    If subp.CLORUROS = 1 Then
                        total = total + (preciocloruros * muestras)
                    End If
                    If subp.PROTEINAS = 1 Then
                        total = total + (precioproteinas * muestras)
                    End If
                    If subp.CENIZAS = 1 Then
                        total = total + (preciocenizas * muestras)
                    End If
                    If subp.ESPORANAERMESOFILO = 1 Then
                        total = total + (precioesporulados * muestras)
                    End If
                    If subp.TERMOFILOS = 1 Then
                        total = total + (preciotermoduricos * muestras)
                    End If
                    If subp.PSICROTROFOS = 1 Then
                        total = total + (preciopsicrotrofos * muestras)
                    End If
                    If subp.ENTEROBACTERIAS = 1 Then
                        total = total + (precioenterobacterias * muestras)
                    End If

                End If
                If subtipo = 20 Then
                    If subp.HUMEDAD = 1 Then
                        total = total + (preciohumedad * muestras)
                    End If
                    If subp.MGRASA = 1 Then
                        total = total + (preciograsa * muestras)
                    End If
                    If subp.PH = 1 Then
                        total = total + (precioph * muestras)
                    End If
                    If subp.CLORUROS = 1 Then
                        total = total + (preciocloruros * muestras)
                    End If
                    If subp.PROTEINAS = 1 Then
                        total = total + (precioproteinas * muestras)
                    End If
                    If subp.CENIZAS = 1 Then
                        total = total + (preciocenizas * muestras)
                    End If
                    If subp.ESTAFCOAGPOSITIVO = 1 Then
                        total = total + (precioestaf * muestras)
                    End If
                    If subp.CF = 1 Then
                        total = total + (preciocf * muestras)
                    End If
                    If subp.CT = 1 Then
                        total = total + (precioct * muestras)
                    End If
                    If subp.MOHOSYLEVADURAS = 1 Then
                        total = total + (preciomohos * muestras)
                    End If
                    If subp.ECOLI = 1 Then
                        total = total + (precioecoli * muestras)
                    End If
                    If subp.SALMONELLA = 1 Then
                        total = total + (preciosalmonella * muestras)
                    End If
                    If subp.LISTERIASPP = 1 Then
                        total = total + (preciolistspp * muestras)
                    End If
                    If subp.LISTERIAMONOCITOGENES = 1 Then
                        total = total + (preciolistmono * muestras)
                    End If
                    If subp.ESPORANAERMESOFILO = 1 Then
                        total = total + (precioesporulados * muestras)
                    End If
                    If subp.TERMOFILOS = 1 Then
                        total = total + (preciotermoduricos * muestras)
                    End If
                    If subp.PSICROTROFOS = 1 Then
                        total = total + (preciopsicrotrofos * muestras)
                    End If
                    If subp.ENTEROBACTERIAS = 1 Then
                        total = total + (precioenterobacterias * muestras)
                    End If
                End If
                If subtipo = 35 Then
                    If subp.HUMEDAD = 1 Then
                        total = total + (preciohumedad * muestras)
                    End If
                    If subp.MGRASA = 1 Then
                        total = total + (preciograsa * muestras)
                    End If
                    If subp.PH = 1 Then
                        total = total + (precioph * muestras)
                    End If
                    If subp.CLORUROS = 1 Then
                        total = total + (preciocloruros * muestras)
                    End If
                    If subp.PROTEINAS = 1 Then
                        total = total + (precioproteinas * muestras)
                    End If
                    If subp.CENIZAS = 1 Then
                        total = total + (preciocenizas * muestras)
                    End If
                    If subp.ESTAFCOAGPOSITIVO = 1 Then
                        total = total + (precioestaf * muestras)
                    End If
                    If subp.CF = 1 Then
                        total = total + (preciocf * muestras)
                    End If
                    If subp.CT = 1 Then
                        total = total + (precioct * muestras)
                    End If
                    If subp.MOHOSYLEVADURAS = 1 Then
                        total = total + (preciomohos * muestras)
                    End If
                    If subp.ECOLI = 1 Then
                        'total = total + (precioecoli * muestras)
                    End If
                    If subp.SALMONELLA = 1 Then
                        total = total + (preciosalmonella * muestras)
                    End If
                    If subp.LISTERIASPP = 1 Then
                        total = total + (preciolistspp * muestras)
                    End If
                    If subp.LISTERIAMONOCITOGENES = 1 Then
                        total = total + (preciolistmono * muestras)
                    End If
                    If subp.ESPORANAERMESOFILO = 1 Then
                        total = total + (precioesporulados * muestras)
                    End If
                    If subp.TERMOFILOS = 1 Then
                        total = total + (preciotermoduricos * muestras)
                    End If
                    If subp.PSICROTROFOS = 1 Then
                        total = total + (preciopsicrotrofos * muestras)
                    End If
                    If subp.ENTEROBACTERIAS = 1 Then
                        total = total + (precioenterobacterias * muestras)
                    End If
                    If subp.RB = 1 Then
                        total = total + (preciorb * muestras)
                    End If
                End If
                If subtipo = 43 Then
                    If subp.HUMEDAD = 1 Then
                        total = total + (preciohumedad * muestras)
                    End If
                    If subp.MGRASA = 1 Then
                        total = total + (preciograsa * muestras)
                    End If
                    If subp.PH = 1 Then
                        total = total + (precioph * muestras)
                    End If
                    If subp.CLORUROS = 1 Then
                        total = total + (preciocloruros * muestras)
                    End If
                    If subp.PROTEINAS = 1 Then
                        total = total + (precioproteinas * muestras)
                    End If
                    If subp.CENIZAS = 1 Then
                        total = total + (preciocenizas * muestras)
                    End If
                    If subp.ESTAFCOAGPOSITIVO = 1 Then
                        total = total + (precioestaf * muestras)
                    End If
                    If subp.CF = 1 Then
                        total = total + (preciocf * muestras)
                    End If
                    If subp.CT = 1 Then
                        total = total + (precioct * muestras)
                    End If
                    If subp.MOHOSYLEVADURAS = 1 Then
                        total = total + (preciomohos * muestras)
                    End If
                    If subp.ECOLI = 1 Then
                        total = total + (precioecoli * muestras)
                    End If
                    If subp.SALMONELLA = 1 Then
                        total = total + (preciosalmonella * muestras)
                    End If
                    If subp.LISTERIASPP = 1 Then
                        total = total + (preciolistspp * muestras)
                    End If
                    If subp.LISTERIAMONOCITOGENES = 1 Then
                        total = total + (preciolistmono * muestras)
                    End If
                    If subp.ESPORANAERMESOFILO = 1 Then
                        total = total + (precioesporulados * muestras)
                    End If
                    If subp.TERMOFILOS = 1 Then
                        total = total + (preciotermoduricos * muestras)
                    End If
                    If subp.PSICROTROFOS = 1 Then
                        total = total + (preciopsicrotrofos * muestras)
                    End If
                    If subp.ENTEROBACTERIAS = 1 Then
                        total = total + (precioenterobacterias * muestras)
                    End If
                End If
                total = total + preciotimbre
                '***********************************************************************************************
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 2
                x1hoja.Cells(fila, columna).formula = "Técnico responsable:" & " " & ComboOperador.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                '**********************************************************
                'prueba
                ' x1hoja.Shapes.AddPicture("c:\Debug\dario.jpg", _
                'Microsoft.Office.Core.MsoTriState.msoTrue, _
                'Microsoft.Office.Core.MsoTriState.msoCTrue, 200, 200, 80, 35)

                'myDocument = Worksheets(1)
                'myDocument.Shapes.AddPicture( _
                '    "c:\microsoft office\clipart\music.bmp", _
                '    True, True, 100, 100, 70, 70)
                '**********************************************************

                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 5
                x1hoja.Cells(fila, columna).formula = "Este informe no podrá ser reproducido total o parcialmente sin la autorización escrita de COLAVECO."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Los resultados consignados se refieren exclusivamente a la muestra recibida."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "COLAVECO declina toda responsabilidad por el uso indebido o incorrecto que se hiciere a este informe,"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "asi como el plan y procedimientos de muestreo aplicados por el cliente. Dr. Darío Hirigoyen (Director)."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8



            End If
        End If




        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\SUBPRODUCTOS\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PRE INFORMES\SUBPRODUCTOS\" & idsol & ".xls")

        'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("C:\" & idsol & ".xls")

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
            pi2.TIPO = 7
            pi2.CREADO = 1
            pi2.FECHA = _fecha
            pi2.guardar()
            pi2 = Nothing
        End If
        pi = Nothing
        '************************************


        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Private Sub ComboListSPP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboListSPP.SelectedIndexChanged
        If ComboListSPP.Text = "Presencia" Then
            ComboListMonocitogenes.Enabled = True
        Else
            ComboListMonocitogenes.Enabled = False
        End If
    End Sub
End Class