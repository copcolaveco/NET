Public Class FormNutricion
    Private _usuario As dUsuario
    Private idsol As Long
    '*** METODOS **********************************
    Private metms As Integer = 0
    Private metcenizas As Integer = 0
    Private metpb As Integer = 0
    Private metfnd As Integer = 0
    Private metfad As Integer = 0
    Private metenl As Integer = 0
    Private metem As Integer = 0
    Private metfc As Integer = 0
    Private metph As Integer = 0
    Private metee As Integer = 0
    Private metnida As Integer = 0

    '***********************************************

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
        cargarComboClase()
        'cargarComboAlimento()
        DateFechaProceso.Value = Now
    End Sub
#End Region
    Public Sub cargarComboClase()
        Dim c As New dNutricionClase
        Dim lista As New ArrayList
        lista = c.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboClase.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAlimento()
        ComboAlimento.Items.Clear()
        Dim clasealimento As dNutricionClase = CType(ComboClase.SelectedItem, dNutricionClase)
        Dim idclasealimento As Integer = clasealimento.ID
        Dim a As New dNutricionAlimento
        Dim lista As New ArrayList
        lista = a.listarporclase(idclasealimento)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboAlimento.Items.Add(a)
                Next
            End If
        End If
    End Sub

    Public Sub listarfichas()
        Dim n As New dNutricion
        Dim lista As New ArrayList
        lista = n.listarfichas
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    ListFichas().Items.Add(n)
                Next
            End If
        End If
    End Sub
    Public Sub listarmuestras()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim n As dNutricion = CType(ListFichas.SelectedItem, dNutricion)
            Dim id As Long = n.FICHA
            idsol = id
            Dim lista As New ArrayList
            lista = n.listarporsolicitud(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each n In lista
                        ListMuestras().Items.Add(n)
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
        ComboClase.Text = ""
        ComboAlimento.Text = ""
        TextTipoInforme.Text = ""
        TextObservaciones.Text = ""
        TextMSH.Text = ""
        TextCenizasH.Text = ""
        TextCenizasS.Text = ""
        TextPBH.Text = ""
        TextPBS.Text = ""
        TextFNDH.Text = ""
        TextFNDS.Text = ""
        TextFADH.Text = ""
        TextFADS.Text = ""
        TextENLS.Text = ""
        TextEMS.Text = ""
        TextFCH.Text = ""
        TextFCS.Text = ""
        TextPHH.Text = ""
        TextEEH.Text = ""
        TextEES.Text = ""
        TextNIDAH.Text = ""
        deshabilitarcontroles()
    End Sub
    Private Sub deshabilitarcontroles()
        TextMSH.Enabled = False
        TextCenizasH.Enabled = False
        TextCenizasS.Enabled = False
        TextPBH.Enabled = False
        TextPBS.Enabled = False
        TextFNDH.Enabled = False
        TextFNDS.Enabled = False
        TextFADH.Enabled = False
        TextFADS.Enabled = False
        TextENLS.Enabled = False
        TextEMS.Enabled = False
        TextFCH.Enabled = False
        TextFCS.Enabled = False
        TextPHH.Enabled = False
        TextEEH.Enabled = False
        TextEES.Enabled = False
        TextNIDAH.Enabled = False
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim n As dNutricion = CType(ListMuestras.SelectedItem, dNutricion)
            TextId.Text = n.ID
            TextFicha.Text = n.FICHA
            DateFechaSolicitud.Value = n.FECHAINGRESO
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = n.MUESTRA
            If n.DETALLEMUESTRA <> "" Then
                TextDetalleMuestra.Text = n.DETALLEMUESTRA
            End If

            '********************************************
            Dim sa As New dSolicitudAnalisis
            Dim id As Long = TextFicha.Text.Trim
            sa.ID = id
            sa = sa.buscar()
            If Not sa.OBSERVACIONES Is Nothing Then
                TextObservaciones.Text = sa.OBSERVACIONES
            End If
            '*********************************************
            
            If n.MSH <> "-1" Then
                TextMSH.Text = n.MSH
            End If
            If n.CENIZASH <> "-1" Then
                TextCenizasH.Text = n.CENIZASH
            End If
            If n.CENIZASS <> "-1" Then
                TextCenizasS.Text = n.CENIZASS
            End If
            If n.PBH <> "-1" Then
                TextPBH.Text = n.PBH
            End If
            If n.PBS <> "-1" Then
                TextPBS.Text = n.PBS
            End If
            If n.FNDH <> "-1" Then
                TextFNDH.Text = n.FNDH
            End If
            If n.FNDS <> "-1" Then
                TextFNDS.Text = n.FNDS
            End If
            If n.FADH <> "-1" Then
                TextFADH.Text = n.FADH
            End If
            If n.FADS <> "-1" Then
                TextFADS.Text = n.FADS
            End If
            If n.ENLS <> "-1" Then
                TextENLS.Text = n.ENLS
            End If
            If n.EMS <> "-1" Then
                TextEMS.Text = n.EMS
            End If
            If n.FCH <> -1 Then
                TextFCH.Text = n.FCH
            End If
            If n.FCS <> -1 Then
                TextFCS.Text = n.FCS
            End If
            If n.PHH <> -1 Then
                TextPHH.Text = n.PHH
            End If
            If n.EEH <> -1 Then
                TextEEH.Text = n.EEH
            End If
            If n.EES <> -1 Then
                TextEES.Text = n.EES
            End If
            If n.NIDAH <> "-1" Then
                TextNIDAH.Text = n.NIDAH
            End If

            '****************************************************************************
            'Dim si As New dSubInforme
            'si.ID = sa.IDSUBINFORME
            'si = si.buscar()
            'TextTipoInforme.Text = si.NOMBRE & " "
            Dim sn_ As New dSolicitudNutricion
            Dim ficha_ As Long = n.FICHA
            Dim muestra_ As String = n.MUESTRA
            Dim texto_ As String = ""
            sn_.FICHA = ficha_
            sn_.MUESTRA = muestra_
            sn_ = sn_.buscarxfichaxmuestra
            If Not sn_ Is Nothing Then
                If sn_.MGA = 1 Then
                    texto_ = texto_ & "MG-a / "
                End If
                If sn_.MGB = 1 Then
                    texto_ = texto_ & "MG-b / "
                End If
                If sn_.ENSILADOS = 1 Then
                    texto_ = texto_ & "Ensilados / "
                End If
                If sn_.PASTURAS = 1 Then
                    texto_ = texto_ & "Pasturas / "
                End If
                If sn_.EXTETEREO = 1 Then
                    texto_ = texto_ & "Extracto etéreo / "
                End If
                If sn_.NIDA = 1 Then
                    texto_ = texto_ & "NIDA / "
                End If
                TextTipoInforme.Text = texto_
            End If
            '*********************************************
            Dim sn As New dSolicitudNutricion
            Dim sn_ficha As String = TextFicha.Text.Trim
            Dim sn_muestra As String = TextMuestra.Text.Trim
            sn.FICHA = sn_ficha
            sn.MUESTRA = sn_muestra
            sn = sn.buscarxfichaxmuestra
            If Not sn Is Nothing Then
                If sn.MGA = 1 Then
                    TextMSH.Enabled = True
                    TextCenizasH.Enabled = True
                    TextCenizasS.Enabled = True
                    TextPBH.Enabled = True
                    TextPBS.Enabled = True
                    TextFNDH.Enabled = True
                    TextFNDS.Enabled = True
                    TextFADH.Enabled = True
                    TextFADS.Enabled = True
                    TextENLS.Enabled = True
                    TextEMS.Enabled = True
                End If
                If sn.MGB = 1 Then
                    TextMSH.Enabled = True
                    TextCenizasH.Enabled = True
                    TextCenizasS.Enabled = True
                    TextPBH.Enabled = True
                    TextPBS.Enabled = True
                    TextFCH.Enabled = True
                    TextFCS.Enabled = True
                End If
                If sn.ENSILADOS = 1 Then
                    TextMSH.Enabled = True
                    TextCenizasH.Enabled = True
                    TextCenizasS.Enabled = True
                    TextPBH.Enabled = True
                    TextPBS.Enabled = True
                    TextFNDH.Enabled = True
                    TextFNDS.Enabled = True
                    TextFADH.Enabled = True
                    TextFADS.Enabled = True
                    TextENLS.Enabled = True
                    TextEMS.Enabled = True
                    TextPHH.Enabled = True
                End If
                If sn.PASTURAS = 1 Then
                    TextMSH.Enabled = True
                    TextCenizasH.Enabled = True
                    TextCenizasS.Enabled = True
                    TextPBH.Enabled = True
                    TextPBS.Enabled = True
                    TextFNDH.Enabled = True
                    TextFNDS.Enabled = True
                    TextFADH.Enabled = True
                    TextFADS.Enabled = True
                    TextENLS.Enabled = True
                    TextEMS.Enabled = True
                End If
                If sn.EXTETEREO = 1 Then
                    TextEEH.Enabled = True
                    TextEES.Enabled = True
                End If
                If sn.NIDA = 1 Then
                    TextNIDAH.Enabled = True
                End If
                If sn.MGB = 1 And sn.EXTETEREO = 1 Then
                    TextEMS.Enabled = True
                End If
            End If
            '****************************************************



        End If

      
    End Sub

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        listarmuestras()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextFicha.Text <> "" Then
            guardar()
            listarmuestras()
        End If
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
        Dim muestra As String = TextMuestra.Text.Trim
        Dim detallemuestra As String = TextDetalleMuestra.Text.Trim
        If ComboClase.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado la clase de alimento", MsgBoxStyle.Exclamation, "Atención") : ComboClase.Focus() : Exit Sub
        Dim clase As dNutricionClase = CType(ComboClase.SelectedItem, dNutricionClase)
        If ComboAlimento.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado el alimento", MsgBoxStyle.Exclamation, "Atención") : ComboAlimento.Focus() : Exit Sub
        Dim alimento As dNutricionAlimento = CType(ComboAlimento.SelectedItem, dNutricionAlimento)
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim msh As Double = 0
        Dim cenizash As Double = 0
        Dim cenizass As Double = 0
        Dim pbh As Double = 0
        Dim pbs As Double = 0
        Dim fndh As Double = 0
        Dim fnds As Double = 0
        Dim fadh As Double = 0
        Dim fads As Double = 0
        Dim enls As Double = 0
        Dim ems As Double = 0
        Dim fch As Double = 0
        Dim fcs As Double = 0
        Dim phh As Double = 0
        Dim eeh As Double = 0
        Dim ees As Double = 0
        Dim nidah As Double = 0


        If TextMSH.Text <> "" Then
            msh = TextMSH.Text.Trim
        Else
            msh = -1
        End If
        If TextCenizasH.Text <> "" Then
            cenizash = TextCenizasH.Text.Trim
        Else
            cenizash = -1
        End If
        If TextCenizasS.Text <> "" Then
            cenizass = TextCenizasS.Text.Trim
        Else
            cenizass = -1
        End If
        If TextPBH.Text <> "" Then
            pbh = TextPBH.Text.Trim
        Else
            pbh = -1
        End If
        If TextPBS.Text <> "" Then
            pbs = TextPBS.Text.Trim
        Else
            pbs = -1
        End If
        If TextFNDH.Text <> "" Then
            fndh = TextFNDH.Text.Trim
        Else
            fndh = -1
        End If
        If TextFNDS.Text <> "" Then
            fnds = TextFNDS.Text.Trim
        Else
            fnds = -1
        End If
        If TextFADH.Text <> "" Then
            fadh = TextFADH.Text.Trim
        Else
            fadh = -1
        End If
        If TextFADS.Text <> "" Then
            fads = TextFADS.Text.Trim
        Else
            fads = -1
        End If
        If TextENLS.Text <> "" Then
            enls = TextENLS.Text.Trim
        Else
            enls = -1
        End If
        If TextEMS.Text <> "" Then
            ems = TextEMS.Text.Trim
        Else
            ems = -1
        End If
        If TextFCH.Text <> "" Then
            fch = TextFCH.Text.Trim
        Else
            fch = -1
        End If
        If TextFCS.Text <> "" Then
            fcs = TextFCS.Text.Trim
        Else
            fcs = -1
        End If
        If TextPHH.Text <> "" Then
            phh = TextPHH.Text.Trim
        Else
            phh = -1
        End If
        If TextEEH.Text <> "" Then
            eeh = TextEEH.Text.Trim
        Else
            eeh = -1
        End If
        If TextEES.Text <> "" Then
            ees = TextEES.Text.Trim
        Else
            ees = -1
        End If
        If TextNIDAH.Text <> "" Then
            nidah = TextNIDAH.Text.Trim
        Else
            nidah = -1
        End If

        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim n As New dNutricion
            Dim id As Long = CType(TextId.Text.Trim, Long)
            n.ID = id
            n.FICHA = ficha
            n.FECHAINGRESO = fechaent
            n.FECHAPROCESO = fechapro
            n.MUESTRA = muestra
            n.DETALLEMUESTRA = detallemuestra
            n.CLASE = clase.ID
            n.ALIMENTO = alimento.ID
            n.MSH = msh
            If metms <> 0 Then
                n.MSM = metms
            Else
                n.MSM = 51
            End If
            n.CENIZASH = cenizash
            n.CENIZASS = cenizass
            If metcenizas <> 0 Then
                n.CENIZASM = metcenizas
            Else
                n.CENIZASM = 52
            End If
            n.PBH = pbh
            n.PBS = pbs
            If metpb <> 0 Then
                n.PBM = metpb
            Else
                n.PBM = 55
            End If
            n.FNDH = fndh
            n.FNDS = fnds
            If metfnd <> 0 Then
                n.FNDM = metfnd
            Else
                n.FNDM = 53
            End If
            n.FADH = fadh
            n.FADS = fads
            If metfad <> 0 Then
                n.FADM = metfad
            Else
                n.FADM = 54
            End If
            n.ENLS = enls
            If metenl <> 0 Then
                n.ENLM = metenl
            Else
                'n.ENLM = 0
            End If
            n.EMS = ems
            If metem <> 0 Then
                n.EMM = metem
            Else
                'n.EMM = 0
            End If
            n.FCH = fch
            n.FCS = fcs
            If metfc <> 0 Then
                n.FCM = metfc
            Else
                n.FCM = 60
            End If
            n.PHH = phh
            If metph <> 0 Then
                n.PHM = metph
            Else
                n.PHM = 80
            End If
            n.EEH = eeh
            n.EES = ees
            If metee <> 0 Then
                n.EEM = metee
            Else
                n.EEM = 56
            End If
            n.NIDAH = nidah
            If metnida <> 0 Then
                n.NIDAM = metnida
            Else
                n.NIDAM = 57
            End If
            n.OPERADOR = operador
            n.MARCA = 0
            Dim sa As New dSolicitudAnalisis
            sa.ID = ficha
            sa.OBSERVACIONES = observaciones
            If (n.modificar(Usuario)) Then
                sa.modificarobservaciones(Usuario)
                'n.modificar2(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim n As New dNutricion
            n.FICHA = ficha
            n.FECHAINGRESO = fechaent
            n.FECHAPROCESO = fechapro
            n.MUESTRA = muestra
            n.DETALLEMUESTRA = detallemuestra
            n.CLASE = clase.ID
            n.ALIMENTO = alimento.ID
            n.MSH = msh
            If metms <> 0 Then
                n.MSM = metms
            Else
                n.MSM = 51
            End If
            n.CENIZASH = cenizash
            n.CENIZASS = cenizass
            If metcenizas <> 0 Then
                n.CENIZASM = metcenizas
            Else
                n.CENIZASM = 52
            End If
            n.PBH = pbh
            n.PBS = pbs
            If metpb <> 0 Then
                n.PBM = metpb
            Else
                n.PBM = 55
            End If
            n.FNDH = fndh
            n.FNDS = fnds
            If metfnd <> 0 Then
                n.FNDM = metfnd
            Else
                n.FNDM = 53
            End If
            n.FADH = fadh
            n.FADS = fads
            If metfad <> 0 Then
                n.FADM = metfad
            Else
                n.FADM = 54
            End If
            n.ENLS = enls
            If metenl <> 0 Then
                n.ENLM = metenl
            Else
                'n.ENLM = 0
            End If
            n.EMS = ems
            If metem <> 0 Then
                n.EMM = metem
            Else
                'n.EMM = 0
            End If
            n.FCH = fch
            n.FCS = fcs
            If metfc <> 0 Then
                n.FCM = metfc
            Else
                'n.FCM = 0
            End If
            n.PHH = phh
            If metph <> 0 Then
                n.PHM = metph
            Else
                n.PHM = 80
            End If
            n.EEH = eeh
            n.EES = ees
            If metee <> 0 Then
                n.EEM = metee
            Else
                n.EEM = 56
            End If
            n.NIDAH = nidah
            If metnida <> 0 Then
                n.NIDAM = metnida
            Else
                n.NIDAM = 57
            End If
            n.OPERADOR = operador
            n.MARCA = 0
            Dim sa As New dSolicitudAnalisis
            sa.ID = ficha
            sa.OBSERVACIONES = observaciones
            If (n.guardar(Usuario)) Then
                sa.modificarobservaciones(Usuario)
                'n.modificar2(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub guardar2()
        Dim ficha As Long = TextFicha.Text.Trim
        Dim fechaentrada As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fechaent As String
        fechaent = Format(fechaentrada, "yyyy-MM-dd")
        Dim fechaproceso As Date = DateFechaProceso.Value.ToString("yyyy-MM-dd")
        Dim fechapro As String
        fechapro = Format(fechaproceso, "yyyy-MM-dd")
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim muestra As String = TextMuestra.Text.Trim
        Dim detallemuestra As String = TextDetalleMuestra.Text.Trim
        If ComboClase.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado la clase de alimento", MsgBoxStyle.Exclamation, "Atención") : ComboClase.Focus() : Exit Sub
        Dim clase As dNutricionClase = CType(ComboClase.SelectedItem, dNutricionClase)
        If ComboAlimento.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado el alimento", MsgBoxStyle.Exclamation, "Atención") : ComboAlimento.Focus() : Exit Sub
        Dim alimento As dNutricionAlimento = CType(ComboAlimento.SelectedItem, dNutricionAlimento)
        Dim observaciones As String
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim msh As Double = 0
        Dim cenizash As Double = 0
        Dim cenizass As Double = 0
        Dim pbh As Double = 0
        Dim pbs As Double = 0
        Dim fndh As Double = 0
        Dim fnds As Double = 0
        Dim fadh As Double = 0
        Dim fads As Double = 0
        Dim enls As Double = 0
        Dim ems As Double = 0
        Dim fch As Double = 0
        Dim fcs As Double = 0
        Dim phh As Double = 0
        Dim eeh As Double = 0
        Dim ees As Double = 0
        Dim nidah As Double = 0


        If TextMSH.Text <> "" Then
            msh = TextMSH.Text.Trim
        Else
            msh = -1
        End If
        If TextCenizasH.Text <> "" Then
            cenizash = TextCenizasH.Text.Trim
        Else
            cenizash = -1
        End If
        If TextCenizasS.Text <> "" Then
            cenizass = TextCenizasS.Text.Trim
        Else
            cenizass = -1
        End If
        If TextPBH.Text <> "" Then
            pbh = TextPBH.Text.Trim
        Else
            pbh = -1
        End If
        If TextPBS.Text <> "" Then
            pbs = TextPBS.Text.Trim
        Else
            pbs = -1
        End If
        If TextFNDH.Text <> "" Then
            fndh = TextFNDH.Text.Trim
        Else
            fndh = -1
        End If
        If TextFNDS.Text <> "" Then
            fnds = TextFNDS.Text.Trim
        Else
            fnds = -1
        End If
        If TextFADH.Text <> "" Then
            fadh = TextFADH.Text.Trim
        Else
            fadh = -1
        End If
        If TextFADS.Text <> "" Then
            fads = TextFADS.Text.Trim
        Else
            fads = -1
        End If
        If TextENLS.Text <> "" Then
            enls = TextENLS.Text.Trim
        Else
            enls = -1
        End If
        If TextEMS.Text <> "" Then
            ems = TextEMS.Text.Trim
        Else
            ems = -1
        End If
        If TextFCH.Text <> "" Then
            fch = TextFCH.Text.Trim
        Else
            fch = -1
        End If
        If TextFCS.Text <> "" Then
            fcs = TextFCS.Text.Trim
        Else
            fcs = -1
        End If
        If TextPHH.Text <> "" Then
            phh = TextPHH.Text.Trim
        Else
            phh = -1
        End If
        If TextEEH.Text <> "" Then
            eeh = TextEEH.Text.Trim
        Else
            eeh = -1
        End If
        If TextEES.Text <> "" Then
            ees = TextEES.Text.Trim
        Else
            ees = -1
        End If
        If TextNIDAH.Text <> "" Then
            nidah = TextNIDAH.Text.Trim
        Else
            nidah = -1
        End If

        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim n As New dNutricion
            Dim id As Long = CType(TextId.Text.Trim, Long)
            n.ID = id
            n.FICHA = ficha
            n.FECHAINGRESO = fechaent
            n.FECHAPROCESO = fechapro
            n.MUESTRA = muestra
            n.DETALLEMUESTRA = detallemuestra
            n.CLASE = clase.ID
            n.ALIMENTO = alimento.ID
            n.MSH = msh
            If metms <> 0 Then
                n.MSM = metms
            Else
                n.MSM = 51
            End If
            n.CENIZASH = cenizash
            n.CENIZASS = cenizass
            If metcenizas <> 0 Then
                n.CENIZASM = metcenizas
            Else
                n.CENIZASM = 52
            End If
            n.PBH = pbh
            n.PBS = pbs
            If metpb <> 0 Then
                n.PBM = metpb
            Else
                n.PBM = 55
            End If
            n.FNDH = fndh
            n.FNDS = fnds
            If metfnd <> 0 Then
                n.FNDM = metfnd
            Else
                n.FNDM = 53
            End If
            n.FADH = fadh
            n.FADS = fads
            If metfad <> 0 Then
                n.FADM = metfad
            Else
                n.FADM = 54
            End If
            n.ENLS = enls
            If metenl <> 0 Then
                n.ENLM = metenl
            Else
                'n.ENLM = 0
            End If
            n.EMS = ems
            If metem <> 0 Then
                n.EMM = metem
            Else
                'n.EmM = 0
            End If
            n.FCH = fch
            n.FCS = fcs
            If metfc <> 0 Then
                n.FCM = metfc
            Else
                'n.FCM = 0
            End If
            n.PHH = phh
            If metph <> 0 Then
                n.PHM = metph
            Else
                n.PHM = 80
            End If
            n.EEH = eeh
            n.EES = ees
            If metee <> 0 Then
                n.EEM = metee
            Else
                n.EEM = 56
            End If
            n.NIDAH = nidah
            If metnida <> 0 Then
                n.NIDAM = metnida
            Else
                n.NIDAM = 57
            End If
            n.OPERADOR = operador
            n.MARCA = 0
            If (n.modificar(Usuario)) Then
                'n.modificar2(Usuario)
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim n As New dNutricion
            n.FICHA = ficha
            n.FECHAINGRESO = fechaent
            n.FECHAPROCESO = fechapro
            n.MUESTRA = muestra
            n.DETALLEMUESTRA = detallemuestra
            n.CLASE = clase.ID
            n.ALIMENTO = alimento.ID
            n.MSH = msh
            If metms <> 0 Then
                n.MSM = metms
            Else
                n.MSM = 51
            End If
            n.CENIZASH = cenizash
            n.CENIZASS = cenizass
            If metcenizas <> 0 Then
                n.CENIZASM = metcenizas
            Else
                n.CENIZASM = 52
            End If
            n.PBH = pbh
            n.PBS = pbs
            If metpb <> 0 Then
                n.PBM = metpb
            Else
                n.PBM = 55
            End If
            n.FNDH = fndh
            n.FNDS = fnds
            If metfnd <> 0 Then
                n.FNDM = metfnd
            Else
                n.FNDM = 53
            End If
            n.FADH = fadh
            n.FADS = fads
            If metfad <> 0 Then
                n.FADM = metfad
            Else
                n.FADM = 54
            End If
            n.ENLS = enls
            If metenl <> 0 Then
                n.ENLM = metenl
            Else
                'n.ENLM = 0
            End If
            n.EMS = ems
            If metem <> 0 Then
                n.EMM = metem
            Else
                'n.EmM = 0
            End If
            n.FCH = fch
            n.FCS = fcs
            If metfc <> 0 Then
                n.FCM = metfc
            Else
                'n.FCM = 0
            End If
            n.PHH = phh
            If metph <> 0 Then
                n.PHM = metph
            Else
                n.PHM = 80
            End If
            n.EEH = eeh
            n.EES = ees
            If metee <> 0 Then
                n.EEM = metee
            Else
                n.EEM = 56
            End If
            n.NIDAH = nidah
            If metnida <> 0 Then
                n.NIDAM = metnida
            Else
                n.NIDAM = 57
            End If
            n.OPERADOR = operador
            n.MARCA = 0
            If (n.guardar(Usuario)) Then
                'n.modificar2(Usuario)
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub ButtonCT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMS.Click
        textometodo = "Materia seca"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metms = met.ID
        End If
    End Sub

    Private Sub ButtonCF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCenizas.Click
        textometodo = "Cenizas (nutrición)"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metcenizas = met.ID
        End If
    End Sub

    Private Sub ButtonEColi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPB.Click
        'textometodo = "Cenizas (nutrición)"
        'Dim v As New FormBuscarMetodos
        'v.ShowDialog()
        'If Not v.Metodos Is Nothing Then
        '    Dim met As dMetodos = v.Metodos
        '    metms = met.ID
        'End If
    End Sub

    Private Sub ButtonFND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFND.Click
        textometodo = "Fibra neutro detergente"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metfnd = met.ID
        End If
    End Sub

    Private Sub ButtonFAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFAD.Click
        textometodo = "Fibra ácido detergente"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metfad = met.ID
        End If
    End Sub

    Private Sub ButtonENL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonENL.Click
        textometodo = "ENL"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metenl = met.ID
        End If
    End Sub

    Private Sub ButtonFC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFC.Click
        textometodo = "FC"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metfc = met.ID
        End If
    End Sub

    Private Sub ButtonEE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEE.Click
        textometodo = "Extracto etéreo"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metee = met.ID
        End If
    End Sub

    Private Sub ButtonNIDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNIDA.Click
        textometodo = "NIDA"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metnida = met.ID
        End If
    End Sub

    Private Sub ButtonFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinalizar.Click
        If TextFicha.Text <> "" Then
            guardar2()
            If ListFichas.SelectedItems.Count = 1 Then
                Dim n As dNutricion = CType(ListFichas.SelectedItem, dNutricion)
                Dim ficha As Long = n.FICHA
                Dim lista As New ArrayList
                lista = n.listarporsolicitud(ficha)
                'ListMuestras.Items.Clear()
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each n In lista
                            n.FICHA = ficha
                            n.MARCA = 1
                            If (n.marcar(Usuario)) Then
                            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                            End If
                        Next
                    End If
                End If
                listarmuestras()
                If ListMuestras.Items.Count = 0 Then
                    listarfichas()
                End If
            End If
        End If
    End Sub

    Private Sub ButtonEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEM.Click
        textometodo = "EM"
        Dim v As New FormBuscarMetodos
        v.ShowDialog()
        If Not v.Metodos Is Nothing Then
            Dim met As dMetodos = v.Metodos
            metenl = met.ID
        End If
    End Sub

    Private Sub ComboClase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboClase.SelectedIndexChanged
        cargarComboAlimento()
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
End Class