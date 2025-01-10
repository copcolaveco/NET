Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormAmbiental
    Private _usuario As dUsuario
    Private idsol As Long
  

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
        listarfichas()
        limpiar()

    End Sub
#End Region
    Public Sub listarfichas()
        Dim a As New dAmbiental
        Dim lista As New ArrayList
        lista = a.listarfichas
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ListFichas().Items.Add(a)
                Next
            End If
        End If
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As New dAmbiental
            Dim a2 As dAmbiental = CType(ListFichas.SelectedItem, dAmbiental)
            Dim id As Long = a2.FICHA
            Dim lista As New ArrayList
            lista = a2.listarporid(id)
            a.FICHA = a2.FICHA
            a = a.buscar
            If a.FECHAPROCESO <> "00:00:00" Then
                DateFechaProceso.Value = a.FECHAPROCESO
            End If
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a2 In lista
                        ListMuestras().Items.Add(a2)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim a As dAmbiental = CType(ListMuestras.SelectedItem, dAmbiental)
            TextId.Text = a.ID
            TextFicha.Text = a.FICHA
            DateFechaSolicitud.Value = a.FECHASOLICITUD
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = a.IDMUESTRA
            If a.DETALLEMUESTRA <> "" Then
                TextDetalleMuestra.Text = a.DETALLEMUESTRA
            End If
            If a.ESTADOMUESTRA <> "-1" Then
                ComboEstadoMuestra.Text = a.ESTADOMUESTRA
            End If
            If a.LISTERIAAMBIENTAL <> -1 Then
                If a.LISTERIAAMBIENTAL = 1 Then
                    ComboListAmbiental.Text = "Detectado"
                Else
                    ComboListAmbiental.Text = "No detectado"
                End If
            End If
            If a.LISTERIAAMBIENTAL2 <> "-1" Then
                TextListAmbiental.Text = a.LISTERIAAMBIENTAL2
            End If
            If a.LISTERIAMONOCITOGENES <> -1 Then
                If a.LISTERIAMONOCITOGENES = 1 Then
                    ComboListMonocitogenes.Text = "Detectado"
                Else
                    ComboListMonocitogenes.Text = "No detectado"
                End If
            End If
            If a.LISTERIASPP <> -1 Then
                If a.LISTERIASPP = 1 Then
                    ComboListspp.Text = "Detectado"
                Else
                    ComboListspp.Text = "No detectado"
                End If
            End If
            If a.LISTERIASPP2 <> "-1" Then
                TextListspp.Text = a.LISTERIASPP2
            End If
            If a.ESTAFCOAGPOSITIVO <> -1 Then
                If a.ESTAFCOAGPOSITIVO = 1 Then
                    ComboEstaf.Text = "Detectado"
                Else
                    ComboEstaf.Text = "No detectado"
                End If
            End If
            If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                TextEstaf.Text = a.ESTAFCOAGPOSITIVO2
            End If
            If a.SALMONELLA <> -1 Then
                If a.SALMONELLA = 1 Then
                    ComboSalmonella.Text = "Detectado"
                Else
                    ComboSalmonella.Text = "No detectado"
                End If
            End If
            If a.ENTEROBACTERIAS <> -1 Then
                If a.ENTEROBACTERIAS = 1 Then
                    ComboEnterobacterias.Text = "Detectado"
                Else
                    ComboEnterobacterias.Text = "No detectado"
                End If
            End If
            If a.ENTEROBACTERIAS2 <> "-1" Then
                TextEnterobacterias.Text = a.ENTEROBACTERIAS2
            End If
            If a.ECOLI <> -1 Then
                If a.ECOLI = 1 Then
                    ComboEcoli.Text = "Detectado"
                Else
                    ComboEcoli.Text = "No detectado"
                End If
            End If
            If a.ECOLI2 <> "-1" Then
                TextEcoli.Text = a.ECOLI2
            End If
            If a.RB <> "-1" Then
                TextRB.Text = a.RB
            End If
            If a.MOHOS <> -1 Then
                If a.MOHOS = 1 Then
                    ComboMohos.Text = "Detectado"
                Else
                    ComboMohos.Text = "No detectado"
                End If
            End If
            If a.MOHOS2 <> "-1" Then
                TextMohos.Text = a.MOHOS2
            End If
            If a.LEVADURAS <> -1 Then
                If a.LEVADURAS = 1 Then
                    ComboLevaduras.Text = "Detectado"
                Else
                    ComboLevaduras.Text = "No detectado"
                End If
            End If
            If a.LEVADURAS2 <> "-1" Then
                TextLevaduras.Text = a.LEVADURAS2
            End If
            If a.CT <> -1 Then
                If a.CT = 1 Then
                    ComboCT.Text = "Detectado"
                Else
                    ComboCT.Text = "No detectado"
                End If
            End If
            If a.CT2 <> "-1" Then
                TextCT.Text = a.CT2
            End If
            If a.CF <> -1 Then
                If a.CF = 1 Then
                    ComboCF.Text = "Detectado"
                Else
                    ComboCF.Text = "No detectado"
                End If
            End If
            If a.CF2 <> "-1" Then
                TextCF.Text = a.CF2
            End If
            If a.PSEUDOMONASPP <> -1 Then
                If a.PSEUDOMONASPP = 1 Then
                    ComboPseudomonaspp.Text = "Detectado"
                Else
                    ComboPseudomonaspp.Text = "No detectado"
                End If
            End If
            If a.PSEUDOMONASPP2 <> "-1" Then
                TextPseudomonaspp.Text = a.PSEUDOMONASPP2
            End If
            '********************************************
            Dim sa As New dSolicitudAnalisis
            Dim id As Long = TextFicha.Text.Trim
            sa.ID = id
            sa = sa.buscar()
            If a.OBSERVACIONES <> "" Then
                TextObservaciones.Text = a.OBSERVACIONES
            Else
                If Not sa.OBSERVACIONES Is Nothing Then
                    TextObservaciones.Text = sa.OBSERVACIONES
                End If
            End If

            Dim asol As New dAmbientalSolicitud
            asol.FICHA = sa.ID
            asol = asol.buscar
            Dim texto As String = ""
            If Not asol Is Nothing Then
                If asol.ENTEROBACTERIAS = 1 Then
                    texto = texto + "Enterobacterias - "
                End If
                If asol.LISTAMBIENTAL = 1 Then
                    texto = texto + "Listeria ambiental - "
                End If
                If asol.LISTMONO = 1 Then
                    texto = texto + "Listeria monocitógenes - "
                End If
                If asol.LISTSPP = 1 Then
                    texto = texto + "Listeria spp - "
                End If
                If asol.ESTAFCOAGPOS = 1 Then
                    texto = texto + "Estaf. Coag. Positivo - "
                End If
                If asol.SALMONELLA = 1 Then
                    texto = texto + "Salmonella - "
                End If
                If asol.ECOLI = 1 Then
                    texto = texto + "E. Coli - "
                End If
                If asol.MOHOSYLEVADURAS = 1 Then
                    texto = texto + "Mohos y levaduras - "
                End If
                If asol.RB = 1 Then
                    texto = texto + "Mesófilos - "
                End If
                If asol.CT = 1 Then
                    texto = texto + "CT - "
                End If
                If asol.CF = 1 Then
                    texto = texto + "CF - "
                End If
                If asol.PSEUDOMONASPP = 1 Then
                    texto = texto + "Pseudomona spp - "
                End If
            End If
            TextTipoInforme.Text = texto

            '*** HABILITAR CONTROLES *******************************
            If asol.LISTAMBIENTAL = 1 Then
                ComboListAmbiental.Enabled = True
                TextListAmbiental.Enabled = True
            Else
                ComboListAmbiental.Enabled = False
                TextListAmbiental.Enabled = False
            End If
            If asol.LISTMONO = 1 Then
                ComboListMonocitogenes.Enabled = True
            Else
                ComboListMonocitogenes.Enabled = False
            End If
            If asol.LISTSPP = 1 Then
                ComboListspp.Enabled = True
                TextListspp.Enabled = True
            Else
                ComboListspp.Enabled = False
                TextListspp.Enabled = False
            End If
            If asol.ESTAFCOAGPOS = 1 Then
                ComboEstaf.Enabled = True
                TextEstaf.Enabled = True
            Else
                ComboEstaf.Enabled = False
                TextEstaf.Enabled = False
            End If
            If asol.SALMONELLA = 1 Then
                ComboSalmonella.Enabled = True
            Else
                ComboSalmonella.Enabled = False
            End If
            If asol.ENTEROBACTERIAS = 1 Then
                ComboEnterobacterias.Enabled = True
                TextEnterobacterias.Enabled = True
            Else
                ComboEnterobacterias.Enabled = False
                TextEnterobacterias.Enabled = False
            End If
            If asol.ECOLI = 1 Then
                ComboEcoli.Enabled = True
                TextEcoli.Enabled = True
            Else
                ComboEcoli.Enabled = False
                TextEcoli.Enabled = False
            End If
            If asol.RB = 1 Then
                TextRB.Enabled = True
            Else
                TextRB.Enabled = False
            End If
            If asol.MOHOSYLEVADURAS = 1 Then
                ComboMohos.Enabled = True
                ComboLevaduras.Enabled = True
                TextMohos.Enabled = True
                TextLevaduras.Enabled = True
            Else
                ComboMohos.Enabled = False
                ComboLevaduras.Enabled = False
                TextMohos.Enabled = False
                TextLevaduras.Enabled = False
            End If
            If asol.CT = 1 Then
                ComboCT.Enabled = True
                TextCT.Enabled = True
            Else
                ComboCT.Enabled = False
                TextCT.Enabled = False
            End If
            If asol.CF = 1 Then
                ComboCF.Enabled = True
                TextCF.Enabled = True
            Else
                ComboCF.Enabled = False
                TextCF.Enabled = False
            End If
            If asol.PSEUDOMONASPP = 1 Then
                ComboPseudomonaspp.Enabled = True
                TextPseudomonaspp.Enabled = True
            Else
                ComboPseudomonaspp.Enabled = False
                TextPseudomonaspp.Enabled = False
            End If

            '*******************************************************
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        DateFechaSolicitud.Value = Now()
        TextMuestra.Text = ""
        TextDetalleMuestra.Text = ""
        TextObservaciones.Text = ""
        TextTipoInforme.Text = ""
        ComboEstadoMuestra.Text = ""
        ComboEstadoMuestra.SelectedItem = Nothing
        ComboListAmbiental.Text = ""
        ComboListAmbiental.SelectedItem = Nothing
        TextListAmbiental.Text = ""
        ComboListMonocitogenes.Text = ""
        ComboListMonocitogenes.SelectedItem = Nothing
        ComboListspp.Text = ""
        ComboListspp.SelectedItem = Nothing
        TextListspp.Text = ""
        ComboEstaf.Text = ""
        ComboEstaf.SelectedItem = Nothing
        TextEstaf.Text = ""
        ComboSalmonella.Text = ""
        ComboSalmonella.SelectedItem = Nothing
        ComboEnterobacterias.Text = ""
        ComboEnterobacterias.SelectedItem = Nothing
        TextEnterobacterias.Text = ""
        ComboEcoli.Text = ""
        ComboEcoli.SelectedItem = Nothing
        TextEcoli.Text = ""
        TextRB.Text = ""
        ComboMohos.Text = ""
        ComboMohos.SelectedItem = Nothing
        TextMohos.Text = ""
        ComboLevaduras.Text = ""
        ComboLevaduras.SelectedItem = Nothing
        TextLevaduras.Text = ""
        ComboCT.Text = ""
        ComboCT.SelectedItem = Nothing
        TextCT.Text = ""
        ComboCF.Text = ""
        ComboCF.SelectedItem = Nothing
        TextCF.Text = ""
        ComboPseudomonaspp.Text = ""
        ComboPseudomonaspp.SelectedItem = Nothing
        TextPseudomonaspp.Text = ""
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
        listarproductos()
    End Sub
    Private Sub guardar()
        Dim ficha As Long = TextFicha.Text.Trim
        Dim fechaentrada As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fechaent As String
        fechaent = Format(fechaentrada, "yyyy-MM-dd")
        Dim fechaproceso As Date = DateFechaProceso.Value.ToString("yyyy-MM-dd")
        Dim fechapro As String
        fechapro = Format(fechaproceso, "yyyy-MM-dd")
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim idmuestra As String = TextMuestra.Text.Trim
        Dim detallemuestra As String = TextDetalleMuestra.Text.Trim
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim estadomuestra As String = ""
        If ComboEstadoMuestra.Text = "" Then MsgBox("No se ha ingresado el estado de la muestra", MsgBoxStyle.Exclamation, "Atención") : ComboEstadoMuestra.Focus() : Exit Sub
        If ComboEstadoMuestra.Text <> "" Then
            estadomuestra = ComboEstadoMuestra.Text
        End If
        Dim listambiental As Integer = 0
        Dim listambiental2 As String = ""
        If ComboListAmbiental.Text <> "" Then
            If ComboListAmbiental.Text = "Detectado" Then
                listambiental = 1
            Else
                listambiental = 0
            End If
        Else
            listambiental = -1
        End If
        If TextListAmbiental.Text <> "" Then
            listambiental2 = TextListAmbiental.Text.Trim
        Else
            listambiental2 = -1
        End If
        Dim listmono As Integer = 0
        If ComboListMonocitogenes.Text <> "" Then
            If ComboListMonocitogenes.Text = "Detectado" Then
                listmono = 1
            Else
                listmono = 0
            End If
        Else
            listmono = -1
        End If
        Dim listspp As Integer = 0
        Dim listspp2 As String = ""
        If ComboListspp.Text <> "" Then
            If ComboListspp.Text = "Detectado" Then
                listspp = 1
            Else
                listspp = 0
            End If
        Else
            listspp = -1
        End If
        If TextListspp.Text <> "" Then
            listspp2 = TextListspp.Text.Trim
        Else
            listspp2 = -1
        End If
        Dim estaf As Integer = 0
        Dim estaf2 As String = ""
        If ComboEstaf.Text <> "" Then
            If ComboEstaf.Text = "Detectado" Then
                estaf = 1
            Else
                estaf = 0
            End If
        Else
            estaf = -1
        End If
        If TextEstaf.Text <> "" Then
            estaf2 = TextEstaf.Text.Trim
        Else
            estaf2 = -1
        End If
        Dim salmonella As Integer = 0
        If ComboSalmonella.Text <> "" Then
            If ComboSalmonella.Text = "Detectado" Then
                salmonella = 1
            Else
                salmonella = 0
            End If
        Else
            salmonella = -1
        End If
        Dim enterobacterias As Integer = 0
        Dim enterobacterias2 As String = ""
        If ComboEnterobacterias.Text <> "" Then
            If ComboEnterobacterias.Text = "Detectado" Then
                enterobacterias = 1
            Else
                enterobacterias = 0
            End If
        Else
            enterobacterias = -1
        End If
        If TextEnterobacterias.Text <> "" Then
            enterobacterias2 = TextEnterobacterias.Text.Trim
        Else
            enterobacterias2 = -1
        End If
        Dim ecoli As Integer = 0
        Dim ecoli2 As String = ""
        If ComboEcoli.Text <> "" Then
            If ComboEcoli.Text = "Detectado" Then
                ecoli = 1
            Else
                ecoli = 0
            End If
        Else
            ecoli = -1
        End If
        If TextEcoli.Text <> "" Then
            ecoli2 = TextEcoli.Text.Trim
        Else
            ecoli2 = -1
        End If
        Dim rb As String = ""
        If TextRB.Text <> "" Then
            rb = TextRB.Text.Trim
        Else
            rb = -1
        End If
        Dim mohos As Integer = 0
        Dim mohos2 As String = ""
        If ComboMohos.Text <> "" Then
            If ComboMohos.Text = "Detectado" Then
                mohos = 1
            Else
                mohos = 0
            End If
        Else
            mohos = -1
        End If
        If TextMohos.Text <> "" Then
            mohos2 = TextMohos.Text.Trim
        Else
            mohos2 = -1
        End If
        Dim levaduras As Integer = 0
        Dim levaduras2 As String = ""
        If ComboLevaduras.Text <> "" Then
            If ComboLevaduras.Text = "Detectado" Then
                levaduras = 1
            Else
                levaduras = 0
            End If
        Else
            levaduras = -1
        End If
        If TextLevaduras.Text <> "" Then
            levaduras2 = TextLevaduras.Text.Trim
        Else
            levaduras2 = -1
        End If
        Dim ct As Integer = 0
        Dim ct2 As String = ""
        If ComboCT.Text <> "" Then
            If ComboCT.Text = "Detectado" Then
                ct = 1
            Else
                ct = 0
            End If
        Else
            ct = -1
        End If
        If TextCT.Text <> "" Then
            ct2 = TextCT.Text.Trim
        Else
            ct2 = -1
        End If
        Dim cf As Integer = 0
        Dim cf2 As String = ""
        If ComboCF.Text <> "" Then
            If ComboCF.Text = "Detectado" Then
                cf = 1
            Else
                cf = 0
            End If
        Else
            cf = -1
        End If
        If TextCF.Text <> "" Then
            cf2 = TextCF.Text.Trim
        Else
            cf2 = -1
        End If
        Dim pseudomonaspp As Integer = 0
        Dim pseudomonaspp2 As String = ""
        If ComboPseudomonaspp.Text <> "" Then
            If ComboPseudomonaspp.Text = "Detectado" Then
                pseudomonaspp = 1
            Else
                pseudomonaspp = 0
            End If
        Else
            pseudomonaspp = -1
        End If
        If TextPseudomonaspp.Text <> "" Then
            pseudomonaspp2 = TextPseudomonaspp.Text.Trim
        Else
            pseudomonaspp2 = -1
        End If
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim a As New dAmbiental
            Dim id As Long = CType(TextId.Text.Trim, Long)
            a.ID = id
            a.FICHA = ficha
            a.FECHASOLICITUD = fechaent
            a.FECHAPROCESO = fechapro
            a.IDMUESTRA = idmuestra
            a.DETALLEMUESTRA = detallemuestra
            a.OBSERVACIONES = observaciones
            a.ESTADOMUESTRA = estadomuestra
            a.LISTERIAAMBIENTAL = listambiental
            a.LISTERIAAMBIENTAL2 = listambiental2
            a.LISTERIAMONOCITOGENES = listmono
            a.LISTERIASPP = listspp
            a.LISTERIASPP2 = listspp2
            a.ESTAFCOAGPOSITIVO = estaf
            a.ESTAFCOAGPOSITIVO2 = estaf2
            a.SALMONELLA = salmonella
            a.ENTEROBACTERIAS = enterobacterias
            a.ENTEROBACTERIAS2 = enterobacterias2
            a.ECOLI = ecoli
            a.ECOLI2 = ecoli2
            a.RB = rb
            a.MOHOS = mohos
            a.MOHOS2 = mohos2
            a.LEVADURAS = levaduras
            a.LEVADURAS2 = levaduras2
            a.CT = ct
            a.CT2 = ct2
            a.CF = cf
            a.CF2 = cf2
            a.PSEUDOMONASPP = pseudomonaspp
            a.PSEUDOMONASPP2 = pseudomonaspp2
            a.OPERADOR = operador
            a.MARCA = 0
            If (a.modificar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dAmbiental

            a.FICHA = ficha
            a.FECHASOLICITUD = fechaent
            a.FECHAPROCESO = fechapro
            a.IDMUESTRA = idmuestra
            a.DETALLEMUESTRA = detallemuestra
            a.OBSERVACIONES = observaciones
            a.ESTADOMUESTRA = estadomuestra
            a.LISTERIAAMBIENTAL = listambiental
            a.LISTERIAAMBIENTAL2 = listambiental2
            a.LISTERIAMONOCITOGENES = listmono
            a.LISTERIASPP = listspp
            a.LISTERIASPP2 = listspp2
            a.ESTAFCOAGPOSITIVO = estaf
            a.ESTAFCOAGPOSITIVO2 = estaf2
            a.SALMONELLA = salmonella
            a.ENTEROBACTERIAS = enterobacterias
            a.ENTEROBACTERIAS2 = enterobacterias2
            a.ECOLI = ecoli
            a.ECOLI2 = ecoli2
            a.RB = rb
            a.MOHOS = mohos
            a.MOHOS2 = mohos2
            a.LEVADURAS = levaduras
            a.LEVADURAS2 = levaduras2
            a.CT = ct
            a.CT2 = ct2
            a.CF = cf
            a.CF2 = cf2
            a.PSEUDOMONASPP = pseudomonaspp
            a.PSEUDOMONASPP2 = pseudomonaspp2
            a.OPERADOR = operador
            a.MARCA = 0
            If (a.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'listaragua()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Public Sub listarproductos()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAmbiental = CType(ListFichas.SelectedItem, dAmbiental)
            Dim id As Long = a.FICHA
            idsol = id
            Dim lista As New ArrayList
            lista = a.listarporsolicitud(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a In lista
                        ListMuestras().Items.Add(a)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        guardar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAmbiental = CType(ListFichas.SelectedItem, dAmbiental)
            Dim id As Long = a.FICHA
            Dim lista As New ArrayList
            lista = a.listarporid(id)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a In lista
                        Dim fechaemision As Date = Now()
                        Dim fechaemi As String
                        fechaemi = Format(fechaemision, "yyyy-MM-dd")
                        a.MARCA = 1
                        If (a.modificar2(Usuario)) Then
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

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        Dim a As New dAmbiental
        Dim a2 As New dAmbientalSolicitud
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dCliente
        Dim lista As New ArrayList
        '*****************************
        'idsol = TextBox1.Text.Trim
        sa.ID = idsol
        sa = sa.buscar
        a2.FICHA = idsol
        a2 = a2.buscarxsolicitud
        a.FICHA = idsol
        a = a.buscarxsolicitud
        '*****************************
        x1hoja.Cells(6, 2).formula = sa.ID
        x1hoja.Cells(6, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 2).Font.Size = 10
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(7, 2).formula = pro.NOMBRE
        x1hoja.Cells(7, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 2).Font.Size = 10
        x1hoja.Cells(8, 2).formula = pro.DIRECCION
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 10
        lista = a.listarporsolicitud2(idsol)
        'x1hoja.Range("H8", "J8").Merge()
        x1hoja.Cells(6, 4).formula = sa.FECHAINGRESO
        x1hoja.Cells(6, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 4).Font.Size = 10
        'x1hoja.Range("H9", "L9").Merge()

        x1hoja.Cells(7, 4).formula = a.FECHAPROCESO
        x1hoja.Cells(7, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 4).Font.Size = 10

        'x1hoja.Range("H10", "L10").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(8, 4).formula = fecha2
        x1hoja.Cells(8, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 4).Font.Size = 10
        Dim fila As Integer
        Dim columna As Integer
       
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


                'x1hoja.Cells(3, 1).columnwidth = 15
                'x1hoja.Cells(3, 2).columnwidth = 27
                'x1hoja.Cells(3, 3).columnwidth = 17
                'x1hoja.Cells(3, 4).columnwidth = 24

                x1hoja.Cells(3, 1).columnwidth = 21
                x1hoja.Cells(3, 2).columnwidth = 20
                x1hoja.Cells(3, 3).columnwidth = 20
                x1hoja.Cells(3, 4).columnwidth = 20

                x1hoja.Range("A1", "D1").Merge()


                columna = 2
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                x1hoja.Range("B4", "C4").Merge()
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Range("B5", "C5").Merge()
                fila = fila + 2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME AMBIENTAL"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Cliente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Fecha proceso:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Fecha informe:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Muestreo"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Muestras extraídas y transportadas por el cliente."
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Material enviado:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 1
                Dim texto As String = ""
                'For Each sp2 In lista
                '    texto = texto & " - " & sp2.IDMUESTRA
                'Next
                Dim m As New dMuestras
                m.ID = sa.IDMUESTRA
                m = m.buscar
                If Not m Is Nothing Then
                    texto = m.NOMBRE
                Else
                    texto = ""
                End If

                'x1hoja.Range("B12", "D12").Merge()
                'x1hoja.Range("B12", "D12").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = "Temperatura (Cº):"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 1
                x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Estudio solicitado"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 1
                a2.FICHA = idsol
                a2 = a2.buscarxsolicitud
                Dim nota As String = ""
                Dim texto2 As String = ""
                If a2.ENTEROBACTERIAS = 1 Then
                    texto2 = texto2 + "Enterobacterias - "
                End If
                If a2.LISTAMBIENTAL = 1 Then
                    texto2 = texto2 + "Listeria ambiental (¹)- "
                    nota = nota + "(¹)Incluye Listeria monocytogenes, innocua, gray /murrayi y welshimeri."
                End If
                If a2.LISTMONO = 1 Then
                    texto2 = texto2 + "Listeria monocytogenes - "
                End If
                If a2.LISTSPP = 1 Then
                    texto2 = texto2 + "Listeria spp - "
                End If
                If a2.ESTAFCOAGPOS = 1 Then
                    texto2 = texto2 + "estaf. Coag. Positivo - "
                End If
                If a2.SALMONELLA = 1 Then
                    texto2 = texto2 + "Salmonella sppEXTERIOR BOCA ENVASADO - "
                End If
                If a2.ECOLI = 1 Then
                    texto2 = texto2 + "E. Coli - "
                End If
                If a2.MOHOSYLEVADURAS = 1 Then
                    texto2 = texto2 + "Mohos y levaduras - "
                End If
                If a2.RB = 1 Then
                    texto2 = texto2 + "Mesófilos - "
                End If
                If a2.CT = 1 Then
                    texto2 = texto2 + "CT - "
                End If
                If a2.CF = 1 Then
                    texto2 = texto2 + "CF - "
                End If
                If a2.PSEUDOMONASPP = 1 Then
                    texto2 = texto2 + "Pseudomona spp - "
                End If

                x1hoja.Range("B14", "D15").Merge()
                x1hoja.Range("B14", "D15").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "Métodos"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = columna + 1

                '*** METODOS*************************************************************************
                Dim texto3 As String = ""
                If a2.LISTAMBIENTAL = 1 Then
                    texto3 = texto3 & "Listeria ambiental: Petrifilm listeria, MFLP 2006 (Gob. Canadá).-"
                End If
                If a2.LISTMONO = 1 Then
                    texto3 = texto3 & "Listeria monocytogenes: Aislamiento en placa, ISO 11290-1:2017"
                End If
                If a2.LISTSPP = 1 Then
                    texto3 = texto3 & ""
                End If
                If a2.ESTAFCOAGPOS = 1 Then
                    texto3 = texto3 & ""
                End If
                If a2.SALMONELLA = 1 Then
                    texto3 = texto3 & "Salmonella: Aislamiento en placa, ISO 6579-1:2017"
                End If
                If a2.ENTEROBACTERIAS = 1 Then
                    texto3 = texto3 & "Enterobacterias - Placa incluída / "
                End If
                If a2.ECOLI = 1 Then
                    texto3 = texto3 & "Ecoli - Petrifilm / "
                End If
                If a2.RB = 1 Then
                    texto3 = texto3 & "Mesófilos - Placa / "
                End If
                If a2.MOHOSYLEVADURAS = 1 Then
                    texto3 = texto3 & "Mohos y levaduras: ISO 6611:2004 / "
                End If
                If a2.CT = 1 Then
                    texto3 = texto3 & "Coliformes totales - Placa incluída / "
                End If
                If a2.CF = 1 Then
                    texto3 = texto3 & "Coliformes fecales - Petrifilm / "
                End If
                If a2.PSEUDOMONASPP = 1 Then
                    texto3 = texto3 & "Pseudomona spp - Placa / "
                End If

                x1hoja.Range("B16", "D17").Merge()
                x1hoja.Range("B16", "D17").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto3
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                columna = 1


                '*** FIN METODOS *********************************************************************



                x1hoja.Cells(fila, columna).Formula = "Procesamiento:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Se recibieron los siguientes productos:"
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 1
                Dim cuenta As Integer = 1
                For Each a In lista
                    x1hoja.Cells(fila, columna).Formula = cuenta & ")" & " " & a.DETALLEMUESTRA
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    fila = fila + 1
                    cuenta = cuenta + 1
                Next
                cuenta = cuenta - 1
                fila = fila + 1
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "RESULTADO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 10
                fila = fila + 2
                Dim linea As Integer = 0
                Dim i As Integer = 1
                Dim texto_ As String = ""
                For Each a In lista



                    'For i = 1 To lista.Count
                    'PRODUCTO 1 ****************************************************************
                    If i = 1 Then
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 1
                        linea = linea + 1


                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. ambiental ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. monocitógenes"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. spp"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Estaf. Coag. Positivo"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25mL"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Enterobacterias ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "E. Coli"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mesófilos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = a.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mohos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Levaduras"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.CT <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes totales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.CF <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes fecales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Pseudomona spp"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1

                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If
                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If
                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = a.RB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        
                        End If

                        If a.MOHOS2 <> "-1" Then
                            If a.MOHOS = -1 Then
                                fila = fila + 1
                            End If
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            If a.LEVADURAS = -1 Then
                                fila = fila + 1
                            End If
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If
                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If
                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.RB <> -1 Then
                            fila = fila + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            If a.MOHOS = -1 Then
                                fila = fila + 1
                            End If
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            If a.LEVADURAS = -1 Then
                                fila = fila + 1
                            End If
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                    End If
                    'PRODUCTO 4 ****************************************************************
                    If i = 4 Then
                        fila = fila + 2
                        columna = 1
                        linea = 0
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 1
                        linea = linea + 1


                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. ambiental ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. monocytogenes"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If
                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. spp ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Estaf.Coag.Pos. ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25mL"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Enterobacterias ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "E. Coli"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.RB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mesófilos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mohos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            If a.MOHOS = -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Mohos"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                            End If
                            columna = columna + 1
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Levaduras"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            If a.LEVADURAS = -1 Then
                                fila = fila + 1
                                x1hoja.Cells(fila, columna).Formula = "Levaduras"
                                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                                x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                                x1hoja.Cells(fila, columna).Font.Bold = True
                                x1hoja.Cells(fila, columna).Font.Size = 10
                            End If
                            columna = columna + 1
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes totales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CF <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes fecales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Pseudomona spp"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If
                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.RB <> -1 Then
                            fila = fila + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.RB <> -1 Then
                            fila = fila + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
                            linea = linea + 1
                        End If


                    End If

                    'PRODUCTO 7 ****************************************************************
                    If i = 7 Then
                        fila = fila + 2
                        columna = 1
                        linea = 0
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 1
                        linea = linea + 1


                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. ambiental ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. monocytogenes"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. spp ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Estaf.Coag.Pos. ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25mL"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Enterobacterias ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "E. Coli"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.RB <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mesófilos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mohos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Levaduras"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes totales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CF <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes fecales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Pseudomona spp"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.RB <> -1 Then
                            fila = fila + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.RB <> -1 Then
                            fila = fila + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                    End If
                    'PRODUCTO 10 ****************************************************************
                    If i = 10 Then
                        fila = fila + 2
                        columna = 1
                        linea = 0
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna - 1
                        linea = linea + 1


                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. ambiental ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. monocytogenes"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "List. spp ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Estaf.Coag.Pos. ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Salmonella spp/25mL"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Enterobacterias ufc/placa"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "E. Coli"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.RB <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mesófilos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Mohos"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Levaduras"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes totales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CF <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Coliformes fecales"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Pseudomona spp"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            columna = columna + 1
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            columna = columna - 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.RB <> -1 Then
                            fila = fila + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
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
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        linea = linea + 1

                        If a.LISTERIAAMBIENTAL <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAAMBIENTAL = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIAAMBIENTAL2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIAAMBIENTAL2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIAAMBIENTAL <> -1 Or a.LISTERIAAMBIENTAL2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.LISTERIAMONOCITOGENES <> -1 Then
                            fila = fila + 1
                            If a.LISTERIAMONOCITOGENES = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.LISTERIASPP <> -1 Then
                            fila = fila + 1
                            If a.LISTERIASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LISTERIASPP2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.LISTERIASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.LISTERIASPP <> -1 Or a.LISTERIASPP2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO <> -1 Then
                            fila = fila + 1
                            If a.ESTAFCOAGPOSITIVO = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ESTAFCOAGPOSITIVO2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ESTAFCOAGPOSITIVO <> -1 Or a.ESTAFCOAGPOSITIVO2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.SALMONELLA <> -1 Then
                            fila = fila + 1
                            If a.SALMONELLA = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS <> -1 Then
                            fila = fila + 1
                            If a.ENTEROBACTERIAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ENTEROBACTERIAS2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ENTEROBACTERIAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ENTEROBACTERIAS <> -1 Or a.ENTEROBACTERIAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.ECOLI <> -1 Then
                            fila = fila + 1
                            If a.ECOLI = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.ECOLI2 <> "-1" Then
                            'columna = columna + 1
                            texto_ = a.ECOLI2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                        End If
                        If a.ECOLI <> -1 Or a.ECOLI2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.RB <> -1 Then
                            fila = fila + 1
                            texto_ = a.RB
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            linea = linea + 1
                        End If

                        If a.MOHOS <> -1 Then
                            fila = fila + 1
                            If a.MOHOS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.MOHOS2 <> "-1" Then
                            texto_ = a.MOHOS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.MOHOS <> -1 Or a.MOHOS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.LEVADURAS <> -1 Then
                            fila = fila + 1
                            If a.LEVADURAS = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.LEVADURAS2 <> "-1" Then
                            texto_ = a.LEVADURAS2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.LEVADURAS <> -1 Or a.LEVADURAS2 <> "-1" Then
                            linea = linea + 1
                        End If

                        If a.CT <> -1 Then
                            fila = fila + 1
                            If a.CT = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CT2 <> "-1" Then
                            texto_ = a.CT2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CT <> -1 Or a.CT2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.CF <> -1 Then
                            fila = fila + 1
                            If a.CF = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.CF2 <> "-1" Then
                            texto_ = a.CF2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.CF <> -1 Or a.CF2 <> "-1" Then
                            linea = linea + 1
                        End If


                        If a.PSEUDOMONASPP <> -1 Then
                            fila = fila + 1
                            If a.PSEUDOMONASPP = 1 Then
                                texto_ = "Detectado"
                            Else
                                texto_ = "No detectado"
                            End If
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If

                        If a.PSEUDOMONASPP2 <> "-1" Then
                            texto_ = a.PSEUDOMONASPP2
                            x1hoja.Cells(fila, columna).Formula = texto_
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            'columna = columna - 1
                            'linea = linea + 1
                        End If
                        If a.PSEUDOMONASPP <> -1 Or a.PSEUDOMONASPP2 <> "-1" Then
                            linea = linea + 1
                        End If


                    End If
                    'Next i
                    i = i + 1
                Next

                '***************************************

                fila = fila + 1
                columna = 1

                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = nota
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 10
                columna = 1
                fila = fila + 1



                '******* CALCULO PRECIO ************************************************************************

                'Dim amb As New dAmbiental
                'Dim amb2 As New dAmbientalSolicitud
                'amb2.FICHA = idsol
                'amb2 = amb2.buscarxsolicitud
                'Dim listamuestras As New ArrayList
                'listamuestras = amb.listarporid(idsol)
                'Dim muestras As Integer = listamuestras.Count

                'Dim lp As New dListaPrecios
                'Dim idlistambiental As Integer = 26
                'Dim idlistspp As Integer = 81
                'Dim idestaf As Integer = 24
                'Dim idct As Integer = 151
                'Dim idcf As Integer = 152
                'Dim idpseudomonaspp As Integer = 153
                'Dim idmesofilos As Integer = 121
                'Dim identerobacterias As Integer = 122
                'Dim idmohosylevaduras As Integer = 123
                'Dim idsalmonella As Integer = 27

                'Dim idtimbre As Integer = 86

                'Dim preciolistambiental As Double = 0
                'Dim preciolistspp As Double = 0
                'Dim precioestaf As Double = 0
                'Dim precioct As Double = 0
                'Dim preciocf As Double = 0
                'Dim preciopseudomonaspp As Double = 0
                'Dim preciomesofilos As Double = 0
                'Dim precioenterobacterias As Double = 0
                'Dim preciomohosylevaduras As Double = 0
                'Dim preciosalmonella As Double = 0
                'Dim preciotimbre As Double = 0
                'lp.ID = idlistambiental
                'lp = lp.buscar
                'preciolistambiental = lp.PRECIO1
                'lp.ID = idlistspp
                'lp = lp.buscar
                'preciolistspp = lp.PRECIO1
                'lp.ID = idestaf
                'lp = lp.buscar
                'precioestaf = lp.PRECIO1
                'lp.ID = idct
                'lp = lp.buscar
                'precioct = lp.PRECIO1
                'lp.ID = idcf
                'lp = lp.buscar
                'preciocf = lp.PRECIO1
                'lp.ID = idpseudomonaspp
                'lp = lp.buscar
                'preciopseudomonaspp = lp.PRECIO1
                'lp.ID = idmesofilos
                'lp = lp.buscar
                'preciomesofilos = lp.PRECIO1
                'lp.ID = identerobacterias
                'lp = lp.buscar
                'precioenterobacterias = lp.PRECIO1
                'lp.ID = idmohosylevaduras
                'lp = lp.buscar
                'preciomohosylevaduras = lp.PRECIO1
                'lp.ID = idsalmonella
                'lp = lp.buscar
                'preciosalmonella = lp.PRECIO1
                'lp.ID = idtimbre
                'lp = lp.buscar
                'preciotimbre = lp.PRECIO1
                'Dim total As Double = 0

                'If amb2.LISTAMBIENTAL = 1 Then
                '    total = total + (preciolistambiental * muestras)
                'End If
                'If amb2.LISTSPP = 1 Then
                '    total = total + (preciolistspp * muestras)
                'End If
                'If amb2.ESTAFCOAGPOS = 1 Then
                '    total = total + (precioestaf * muestras)
                'End If
                'If amb2.CT = 1 Then
                '    total = total + (precioct * muestras)
                'End If
                'If amb2.CF = 1 Then
                '    total = total + (preciocf * muestras)
                'End If
                'If amb2.PSEUDOMONASPP = 1 Then
                '    total = total + (preciopseudomonaspp * muestras)
                'End If
                'If amb2.RB = 1 Then
                '    total = total + (preciomesofilos * muestras)
                'End If
                'If amb2.ENTEROBACTERIAS = 1 Then
                '    total = total + (precioenterobacterias * muestras)
                'End If
                'If amb2.MOHOSYLEVADURAS = 1 Then
                '    total = total + (preciomohosylevaduras * muestras)
                'End If
                'If amb2.SALMONELLA = 1 Then
                '    total = total + (preciosalmonella * muestras)
                'End If

                'total = total + preciotimbre
                '***********************************************************************************************
                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incl.)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 2
                x1hoja.Cells(fila, columna).formula = "Técnico responsable:" & " " & ComboOperador.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = 1
                'fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 10
                'x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                Dim rangeFirma As String = "A" + fila.ToString
                x1libro.ActiveSheet.Range(rangeFirma).select()
                InsertImageToDeclaredVariable(x1libro, rangeFirma, "c:\Debug\cecilia.jpg")
                x1libro.Worksheets(1).cells(2, 1).select()
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



            End If
        End If

        fila = fila + 1
        x1hoja.Range("A" & fila, "D" & fila).Merge()
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
            pi2.TIPO = 11
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
        'x1hoja.SaveAs("\\192.168.1.10\E\NET\AMBIENTAL\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PREINFORMES\AMBIENTAL\" & idsol & ".xls")
        

        'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("C:\" & idsol & ".xls")

        x1libro.Close()
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

    Private Sub ComboListAmbiental_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboListAmbiental.SelectedIndexChanged
        If ComboListAmbiental.Text = "Detectado" Then
            ComboListMonocitogenes.Enabled = True
        Else
            ComboListMonocitogenes.Enabled = False
        End If
    End Sub

    Private Sub TextListAmbiental_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextListAmbiental.TextChanged
        ComboListAmbiental.Text = "Detectado"
    End Sub

    Private Sub TextEnterobacterias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextEnterobacterias.TextChanged
        ComboEnterobacterias.Text = "Detectado"
    End Sub

    Private Sub TextEcoli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextEcoli.TextChanged
        ComboEcoli.Text = "Detectado"
    End Sub

    Private Sub TextMohos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMohos.TextChanged
        ComboMohos.Text = "Detectado"
    End Sub

    Private Sub TextLevaduras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextLevaduras.TextChanged
        ComboLevaduras.Text = "Detectado"
    End Sub

    Private Sub TextCT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCT.TextChanged
        ComboCT.Text = "Detectado"
    End Sub

    Private Sub TextCF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCF.TextChanged
        ComboCF.Text = "Detectado"
    End Sub

    Private Sub TextPseudomonaspp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextPseudomonaspp.TextChanged
        ComboPseudomonaspp.Text = "Detectado"
    End Sub

    Private Sub ComboListMonocitogenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboListMonocitogenes.SelectedIndexChanged

    End Sub
End Class