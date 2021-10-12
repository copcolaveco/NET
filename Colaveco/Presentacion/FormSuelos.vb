Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class FormSuelos
    Private _usuario As dUsuario
    Private idsol As Long
    '*** METODOS **********************************
    Private metfosforobray As Integer = 0
    Private metfosforocitrico As Integer = 0
    Private metnitratos As Integer = 0
    Private metphagua As Integer = 0
    Private metphkci As Integer = 0
    Private metpotasioint As Integer = 0
    Private metsulfatos As Integer = 0
    Private metnitrogenovegeteal As Integer = 0
    Private metmateriaorganica As Integer = 0
    Private metpmn As Integer = 0
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
        RadioParcial.Checked = True
        listarfichas()
        DateFechaProceso.Value = Now
    End Sub
#End Region

    Public Sub listarfichas()
        Dim s As New dSuelos
        Dim lista As New ArrayList
        lista = s.listarfichas
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ListFichas().Items.Add(s)
                Next
            End If
        End If
    End Sub
    Public Sub listarmuestras()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim s As dSuelos = CType(ListFichas.SelectedItem, dSuelos)
            Dim id As Long = s.FICHA
            idsol = id
            Dim lista As New ArrayList
            lista = s.listarporsolicitud(id)
            ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each s In lista
                        ListMuestras().Items.Add(s)
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
        TextTipoInforme.Text = ""
        TextObservaciones.Text = ""
        TextFosforoBray.Text = ""
        TextFosforoCitrico.Text = ""
        TextNitratos.Text = ""
        TextPHAgua.Text = ""
        TextPHKCI.Text = ""
        TextPotasio.Text = ""
        TextSulfatos.Text = ""
        TextNitrogenoVegetal.Text = ""
        TextCarbonoOrganico.Text = ""
        TextMateriaOrganica.Text = ""
        TextMineralizacion.Text = ""
        TextCalcio.Text = ""
        TextMagnesio.Text = ""
        TextSodio.Text = ""
        TextAcidezT.Text = ""
        TextCIC.Text = ""
        TextSB.Text = ""
        deshabilitarcontroles()
    End Sub
    Private Sub deshabilitarcontroles()
        TextFosforoBray.Enabled = False
        TextFosforoCitrico.Enabled = False
        TextNitratos.Enabled = False
        TextPHAgua.Enabled = False
        TextPHKCI.Enabled = False
        TextPotasio.Enabled = False
        TextSulfatos.Enabled = False
        TextNitrogenoVegetal.Enabled = False
        TextCarbonoOrganico.Enabled = False
        TextMateriaOrganica.Enabled = False
        TextMineralizacion.Enabled = False
        TextCalcio.Enabled = False
        TextMagnesio.Enabled = False
        TextSodio.Enabled = False
        TextAcidezT.Enabled = False
        TextCIC.Enabled = False
        TextSB.Enabled = False
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim s As dSuelos = CType(ListMuestras.SelectedItem, dSuelos)
            TextId.Text = s.ID
            TextFicha.Text = s.FICHA
            DateFechaSolicitud.Value = s.FECHAINGRESO
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = s.MUESTRA

            If s.DETALLEMUESTRA <> "" Then
                TextDetalleMuestra.Text = s.DETALLEMUESTRA
            Else
                TextDetalleMuestra.Text = s.MUESTRA
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

            If s.FOSFOROBRAY <> "-1" Then
                TextFosforoBray.Text = s.FOSFOROBRAY
            End If
            If s.FOSFOROCITRICO <> "-1" Then
                TextFosforoCitrico.Text = s.FOSFOROCITRICO
            End If
            If s.NITRATOS <> "-1" Then
                TextNitratos.Text = s.NITRATOS
            End If
            If s.PHAGUA <> "-1" Then
                TextPHAgua.Text = s.PHAGUA
            End If
            If s.PHKCI <> "-1" Then
                TextPHKCI.Text = s.PHKCI
            End If
            If s.POTASIOINT <> "-1" Then
                TextPotasio.Text = s.POTASIOINT
            End If
            If s.SULFATOS <> "-1" Then
                TextSulfatos.Text = s.SULFATOS
            End If
            If s.NITROGENOVEGETAL <> "-1" Then
                TextNitrogenoVegetal.Text = s.NITROGENOVEGETAL
            End If
            If s.CARBONOORGANICO <> "-1" Then
                TextCarbonoOrganico.Text = s.CARBONOORGANICO
            End If
            If s.MATERIAORGANICA <> "-1" Then
                TextMateriaOrganica.Text = s.MATERIAORGANICA
            End If
            If s.PMN <> "-1" Then
                TextMineralizacion.Text = s.PMN
            End If
            If s.CALCIO <> "-1" Then
                TextCalcio.Text = s.CALCIO
            End If
            If s.MAGNESIO <> "-1" Then
                TextMagnesio.Text = s.MAGNESIO
            End If
            If s.SODIO <> "-1" Then
                TextSodio.Text = s.SODIO
            End If
            If s.ACIDEZTITULABLE <> "-1" Then
                TextAcidezT.Text = s.ACIDEZTITULABLE
            End If
            If s.CIC <> "-1" Then
                TextCIC.Text = s.CIC
            End If
            If s.SB <> "-1" Then
                TextSB.Text = s.SB
            End If
            '****************************************************************************
            'Dim si As New dSubInforme
            'si.ID = sa.IDSUBINFORME
            'si = si.buscar()
            'TextTipoInforme.Text = si.NOMBRE & " "
            Dim ss_ As New dSolicitudSuelos
            Dim ficha_ As Long = s.FICHA
            Dim muestra_ As String = s.MUESTRA
            Dim texto_ As String = ""
            ss_.FICHA = ficha_
            ss_.MUESTRA = muestra_
            ss_ = ss_.buscarxfichaxmuestra

            If Not ss_ Is Nothing Then
                If ss_.NITRATOS = 1 Then
                    texto_ = texto_ & "Nitratos / "
                End If
                If ss_.MINERALIZACION = 1 Then
                    texto_ = texto_ & "PMN / "
                End If
                If ss_.FOSFOROBRAY = 1 Then
                    texto_ = texto_ & "Fósforo Bray / "
                End If
                If ss_.FOSFOROCITRICO = 1 Then
                    texto_ = texto_ & "Fósforo cítrico / "
                End If
                If ss_.PHAGUA = 1 Then
                    texto_ = texto_ & "pH Agua / "
                End If
                If ss_.PHKCI = 1 Then
                    texto_ = texto_ & "pH KCI / "
                End If
                If ss_.MATERIAORG = 1 Then
                    texto_ = texto_ & "Materia orgánica / "
                End If
                If ss_.POTASIOINT = 1 Then
                    texto_ = texto_ & "potasio intercambiable / "
                End If
                If ss_.SULFATOS = 1 Then
                    texto_ = texto_ & "Sulfatos / "
                End If
                If ss_.NITROGENOVEGETAL = 1 Then
                    texto_ = texto_ & "Nitrógeno vegetal / "
                End If
                If ss_.CALCIO = 1 Then
                    texto_ = texto_ & "Calcio / "
                End If
                If ss_.MAGNESIO = 1 Then
                    texto_ = texto_ & "Magnesio / "
                End If
                If ss_.SODIO = 1 Then
                    texto_ = texto_ & "Sodio / "
                End If
                If ss_.ACIDEZTITULABLE = 1 Then
                    texto_ = texto_ & "Acidez titulable / "
                End If
                If ss_.CIC = 1 Then
                    texto_ = texto_ & "CIC / "
                End If
                If ss_.SB = 1 Then
                    texto_ = texto_ & "%SB / "
                End If
                TextTipoInforme.Text = texto_
            End If
            '*********************************************
            Dim ss As New dSolicitudSuelos
            Dim ss_ficha As String = TextFicha.Text.Trim
            Dim ss_muestra As String = TextMuestra.Text.Trim
            ss.FICHA = ss_ficha
            ss.MUESTRA = ss_muestra
            ss = ss.buscarxfichaxmuestra
            If Not ss Is Nothing Then
                If ss.NITRATOS = 1 Then
                    TextNitratos.Enabled = True
                End If
                If ss.MINERALIZACION = 1 Then
                    TextMineralizacion.Enabled = True
                End If
                If ss.FOSFOROBRAY = 1 Then
                    TextFosforoBray.Enabled = True
                End If
                If ss.FOSFOROCITRICO = 1 Then
                    TextFosforoCitrico.Enabled = True
                End If
                If ss.PHAGUA = 1 Then
                    TextPHAgua.Enabled = True
                End If
                If ss.PHKCI = 1 Then
                    TextPHKCI.Enabled = True
                End If
                If ss.MATERIAORG = 1 Then
                    TextCarbonoOrganico.Enabled = True
                    TextMateriaOrganica.Enabled = True
                End If
                If ss.POTASIOINT = 1 Then
                    TextPotasio.Enabled = True
                End If
                If ss.SULFATOS = 1 Then
                    TextSulfatos.Enabled = True
                End If
                If ss.NITROGENOVEGETAL = 1 Then
                    TextNitrogenoVegetal.Enabled = True
                End If
                If ss.CALCIO = 1 Then
                    TextCalcio.Enabled = True
                End If
                If ss.MAGNESIO = 1 Then
                    TextMagnesio.Enabled = True
                End If
                If ss.SODIO = 1 Then
                    TextSodio.Enabled = True
                End If
                If ss_.ACIDEZTITULABLE = 1 Then
                    TextAcidezT.Enabled = True
                End If
                If ss_.CIC = 1 Then
                    TextCIC.Enabled = True
                End If
                If ss_.SB = 1 Then
                    TextSB.Enabled = True
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
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim fosforobray As Double = 0
        Dim fosforocitrico As Double = 0
        Dim nitratos As Double = 0
        Dim phagua As Double = 0
        Dim phkci As Double = 0
        Dim potasioint As Double = 0
        Dim sulfatos As Double = 0
        Dim nitrogenovegetal As Double = 0
        Dim carbonoorganico As Double = 0
        Dim materiaorganica As Double = 0
        Dim pmn As Double = 0
        Dim calcio As Double = 0
        Dim magnesio As Double = 0
        Dim sodio As Double = 0
        Dim acidezt As Double = 0
        Dim cic As Double = 0
        Dim sb As Double = 0


        If TextFosforoBray.Text <> "" Then
            fosforobray = TextFosforoBray.Text.Trim
        Else
            fosforobray = -1
        End If
        If TextFosforoCitrico.Text <> "" Then
            fosforocitrico = TextFosforoCitrico.Text.Trim
        Else
            fosforocitrico = -1
        End If
        If TextNitratos.Text <> "" Then
            nitratos = TextNitratos.Text.Trim
        Else
            nitratos = -1
        End If
        If TextPHAgua.Text <> "" Then
            phagua = TextPHAgua.Text.Trim
        Else
            phagua = -1
        End If
        If TextPHKCI.Text <> "" Then
            phkci = TextPHKCI.Text.Trim
        Else
            phkci = -1
        End If
        If TextPotasio.Text <> "" Then
            potasioint = TextPotasio.Text.Trim
        Else
            potasioint = -1
        End If
        If TextSulfatos.Text <> "" Then
            sulfatos = TextSulfatos.Text.Trim
        Else
            sulfatos = -1
        End If
        If TextNitrogenoVegetal.Text <> "" Then
            nitrogenovegetal = TextNitrogenoVegetal.Text.Trim
        Else
            nitrogenovegetal = -1
        End If
        If TextCarbonoOrganico.Text <> "" Then
            carbonoorganico = TextCarbonoOrganico.Text.Trim
        Else
            carbonoorganico = -1
        End If
        If TextMateriaOrganica.Text <> "" Then
            materiaorganica = TextMateriaOrganica.Text.Trim
        Else
            materiaorganica = -1
        End If
        If TextMineralizacion.Text <> "" Then
            pmn = TextMineralizacion.Text.Trim
        Else
            pmn = -1
        End If
        If TextCalcio.Text <> "" Then
            calcio = TextCalcio.Text.Trim
        Else
            calcio = -1
        End If
        If TextMagnesio.Text <> "" Then
            magnesio = TextMagnesio.Text.Trim
        Else
            magnesio = -1
        End If
        If TextSodio.Text <> "" Then
            sodio = TextSodio.Text.Trim
        Else
            sodio = -1
        End If
        If TextAcidezT.Text <> "" Then
            acidezt = TextAcidezT.Text.Trim
        Else
            acidezt = -1
        End If
        If TextCIC.Text <> "" Then
            cic = TextCIC.Text.Trim
        Else
            cic = -1
        End If
        If TextSB.Text <> "" Then
            sb = TextSB.Text.Trim
        Else
            sb = -1
        End If

        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim s As New dSuelos
            Dim sa As New dSolicitudAnalisis
            Dim id As Long = CType(TextId.Text.Trim, Long)
            s.ID = id
            s.FICHA = ficha
            s.FECHAINGRESO = fechaent
            s.FECHAPROCESO = fechapro
            s.MUESTRA = muestra
            s.DETALLEMUESTRA = detallemuestra
            s.FOSFOROBRAY = fosforobray
            s.FOSFOROCITRICO = fosforocitrico
            s.NITRATOS = nitratos
            s.PHAGUA = phagua
            s.PHKCI = phkci
            s.POTASIOINT = potasioint
            s.SULFATOS = sulfatos
            s.NITROGENOVEGETAL = nitrogenovegetal
            s.CARBONOORGANICO = carbonoorganico
            s.MATERIAORGANICA = materiaorganica
            s.PMN = pmn
            s.CALCIO = calcio
            s.MAGNESIO = magnesio
            s.SODIO = sodio
            s.ACIDEZTITULABLE = acidezt
            s.CIC = cic
            s.SB = sb
            s.OPERADOR = operador
            s.MARCA = 0
            sa.ID = ficha
            sa.OBSERVACIONES = observaciones
            If (s.modificar(Usuario)) Then
                sa.modificarobservaciones(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim s As New dSuelos
            Dim sa As New dSolicitudAnalisis
            s.FICHA = ficha
            s.FECHAINGRESO = fechaent
            s.FECHAPROCESO = fechapro
            s.MUESTRA = muestra
            s.DETALLEMUESTRA = detallemuestra
            s.FOSFOROBRAY = fosforobray
            s.FOSFOROCITRICO = fosforocitrico
            s.NITRATOS = nitratos
            s.PHAGUA = phagua
            s.PHKCI = phkci
            s.POTASIOINT = potasioint
            s.SULFATOS = sulfatos
            s.NITROGENOVEGETAL = nitrogenovegetal
            s.CARBONOORGANICO = carbonoorganico
            s.MATERIAORGANICA = materiaorganica
            s.PMN = pmn
            s.CALCIO = calcio
            s.MAGNESIO = magnesio
            s.SODIO = sodio
            s.ACIDEZTITULABLE = acidezt
            s.CIC = cic
            s.SB = sb
            s.OPERADOR = operador
            s.MARCA = 0
            sa.ID = ficha
            sa.OBSERVACIONES = observaciones
            If (s.guardar(Usuario)) Then
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
        Dim final As Integer = 0
        If RadioParcial.Checked = True Then
            final = 0
        Else
            final = 1
        End If
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim muestra As String = TextMuestra.Text.Trim
        Dim detallemuestra As String = TextDetalleMuestra.Text.Trim
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If

        Dim fosforobray As Double = 0
        Dim fosforocitrico As Double = 0
        Dim nitratos As Double = 0
        Dim phagua As Double = 0
        Dim phkci As Double = 0
        Dim potasioint As Double = 0
        Dim sulfatos As Double = 0
        Dim nitrogenovegetal As Double = 0
        Dim carbonoorganico As Double = 0
        Dim materiaorganica As Double = 0
        Dim pmn As Double = 0
        Dim calcio As Double = 0
        Dim magnesio As Double = 0
        Dim sodio As Double = 0
        Dim acidezt As Double = 0
        Dim cic As Double = 0
        Dim sb As Double = 0

        If TextFosforoBray.Text <> "" Then
            fosforobray = TextFosforoBray.Text.Trim
        Else
            fosforobray = -1
        End If
        If TextFosforoCitrico.Text <> "" Then
            fosforocitrico = TextFosforoCitrico.Text.Trim
        Else
            fosforocitrico = -1
        End If
        If TextNitratos.Text <> "" Then
            nitratos = TextNitratos.Text.Trim
        Else
            nitratos = -1
        End If
        If TextPHAgua.Text <> "" Then
            phagua = TextPHAgua.Text.Trim
        Else
            phagua = -1
        End If
        If TextPHKCI.Text <> "" Then
            phkci = TextPHKCI.Text.Trim
        Else
            phkci = -1
        End If
        If TextPotasio.Text <> "" Then
            potasioint = TextPotasio.Text.Trim
        Else
            potasioint = -1
        End If
        If TextSulfatos.Text <> "" Then
            sulfatos = TextSulfatos.Text.Trim
        Else
            sulfatos = -1
        End If
        If TextNitrogenoVegetal.Text <> "" Then
            nitrogenovegetal = TextNitrogenoVegetal.Text.Trim
        Else
            nitrogenovegetal = -1
        End If
        If TextCarbonoOrganico.Text <> "" Then
            carbonoorganico = TextCarbonoOrganico.Text.Trim
        Else
            carbonoorganico = -1
        End If
        If TextMateriaOrganica.Text <> "" Then
            materiaorganica = TextMateriaOrganica.Text.Trim
        Else
            materiaorganica = -1
        End If
        If TextMineralizacion.Text <> "" Then
            pmn = TextMineralizacion.Text.Trim
        Else
            pmn = -1
        End If
        If TextCalcio.Text <> "" Then
            calcio = TextCalcio.Text.Trim
        Else
            calcio = -1
        End If
        If TextMagnesio.Text <> "" Then
            magnesio = TextMagnesio.Text.Trim
        Else
            magnesio = -1
        End If
        If TextSodio.Text <> "" Then
            sodio = TextSodio.Text.Trim
        Else
            sodio = -1
        End If
        If TextAcidezT.Text <> "" Then
            acidezt = TextAcidezT.Text.Trim
        Else
            acidezt = -1
        End If
        If TextCIC.Text <> "" Then
            cic = TextCIC.Text.Trim
        Else
            cic = -1
        End If
        If TextSB.Text <> "" Then
            sb = TextSB.Text.Trim
        Else
            sb = -1
        End If


        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim s As New dSuelos
            Dim sa As New dSolicitudAnalisis
            Dim id As Long = CType(TextId.Text.Trim, Long)

            s.ID = id
            s.FICHA = ficha
            s.FECHAINGRESO = fechaent
            s.FECHAPROCESO = fechapro
            s.FINAL = final
            s.MUESTRA = muestra
            s.DETALLEMUESTRA = detallemuestra
            s.FOSFOROBRAY = fosforobray
            s.FOSFOROCITRICO = fosforocitrico
            s.NITRATOS = nitratos
            s.PHAGUA = phagua
            s.PHKCI = phkci
            s.POTASIOINT = potasioint
            s.SULFATOS = sulfatos
            s.NITROGENOVEGETAL = nitrogenovegetal
            s.CARBONOORGANICO = carbonoorganico
            s.MATERIAORGANICA = materiaorganica
            s.PMN = pmn
            s.CALCIO = calcio
            s.MAGNESIO = magnesio
            s.SODIO = sodio
            s.ACIDEZTITULABLE = acidezt
            s.CIC = cic
            s.SB = sb
            s.OPERADOR = operador
            s.MARCA = 0
            sa.ID = ficha
            sa.OBSERVACIONES = observaciones
            If (s.modificar(Usuario)) Then
                sa.modificarobservaciones(Usuario)
                'n.modificar2(Usuario)
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim s As New dSuelos
            Dim sa As New dSolicitudAnalisis
            s.FICHA = ficha
            s.FECHAINGRESO = fechaent
            s.FECHAPROCESO = fechapro
            s.FINAL = final
            s.MUESTRA = muestra
            s.DETALLEMUESTRA = detallemuestra
            s.FOSFOROBRAY = fosforobray
            s.FOSFOROCITRICO = fosforocitrico
            s.NITRATOS = nitratos
            s.PHAGUA = phagua
            s.PHKCI = phkci
            s.POTASIOINT = potasioint
            s.SULFATOS = sulfatos
            s.NITROGENOVEGETAL = nitrogenovegetal
            s.CARBONOORGANICO = carbonoorganico
            s.MATERIAORGANICA = materiaorganica
            s.PMN = pmn
            s.CALCIO = calcio
            s.MAGNESIO = magnesio
            s.SODIO = sodio
            s.ACIDEZTITULABLE = acidezt
            s.CIC = cic
            s.SB = sb
            s.OPERADOR = operador
            s.MARCA = 0
            sa.ID = ficha
            sa.OBSERVACIONES = observaciones
            If (s.guardar(Usuario)) Then
                sa.modificarobservaciones(Usuario)
                'n.modificar2(Usuario)
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFinalizar.Click
        If TextFicha.Text <> "" Then
            If RadioParcial.Checked = True Then
                guardar2()
                listarmuestras()
                If ListMuestras.Items.Count = 0 Then
                    listarfichas()
                End If
            Else
                guardar2()
                If ListFichas.SelectedItems.Count = 1 Then
                    Dim s As dSuelos = CType(ListFichas.SelectedItem, dSuelos)
                    Dim ficha As Long = s.FICHA
                    Dim lista As New ArrayList
                    lista = s.listarporsolicitud(ficha)
                    'ListMuestras.Items.Clear()
                    If Not lista Is Nothing Then
                        If lista.Count > 0 Then
                            For Each s In lista
                                s.FICHA = ficha
                                s.MARCA = 1
                                s.FINAL = 1
                                If (s.marcar(Usuario)) Then
                                    s.marcarfinal(Usuario)
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
        End If
    End Sub


    Private Sub TextCarbonoOrganico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCarbonoOrganico.TextChanged
        Dim carborg As Double = 0
        Dim matorg As Double = 0
        carborg = Val(TextCarbonoOrganico.Text)
        matorg = carborg * 1.724
        TextMateriaOrganica.Text = matorg
    End Sub
    Private Sub creainformeexcel()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)


        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim s As New dSuelos
        Dim ss As New dSolicitudSuelos
        Dim met As New dMetodos
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList

        Dim informefinal As Integer = 0
        '*****************************

        Dim idsol As Long = TextFicha.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        lista = s.listarporsolicitud2(idsol)
        lista2 = ss.listarporsolicitud(idsol)

        '*****************************
        x1hoja.Cells(8, 2).formula = sa.ID
        x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(9, 2).formula = pro.NOMBRE
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(10, 2).formula = pro.DIRECCION
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        Else
            x1hoja.Cells(10, 2).formula = "No aportado"
            x1hoja.Cells(10, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(10, 2).Font.Size = 9
        End If

        x1hoja.Cells(8, 5).formula = sa.FECHAINGRESO
        x1hoja.Cells(8, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 5).Font.Size = 9

        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")
        x1hoja.Cells(9, 5).formula = fecha2
        x1hoja.Cells(9, 5).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 5).Font.Size = 9

        Dim fila As Integer
        Dim columna As Integer

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                fila = 1
                columna = 2


                'Poner Titulos
                x1hoja.Shapes.AddPicture("c:\Debug\encabezado_suelos.jpg", _
                Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 418, 55)



                x1hoja.Cells(3, 1).columnwidth = 25
                x1hoja.Cells(3, 2).columnwidth = 13
                x1hoja.Cells(3, 3).columnwidth = 13
                x1hoja.Cells(3, 4).columnwidth = 13 '32
                x1hoja.Cells(3, 5).columnwidth = 13
                x1hoja.Range("A1", "E1").Merge()


                columna = 2
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Range("B4", "C4").Merge()
                fila = fila + 1
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                'x1hoja.Range("A6", "D6").Merge()
                x1hoja.Range("A6", "E6").Merge()
                fila = fila + 3
                columna = 1
                Dim s1 As New dSuelos
                s1.FICHA = idsol
                s1 = s1.buscar
                If Not s1 Is Nothing Then
                    If s1.FINAL = 0 Then
                        informefinal = 0
                    Else
                        informefinal = 1
                    End If
                End If
                If informefinal = 0 Then
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Formula = "INFORME PARCIAL DE SUELOS"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 2
                    columna = 1
                Else
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Formula = "INFORME DE SUELOS"
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 2
                    columna = 1
                End If
                x1hoja.Cells(fila, columna).Formula = "Nº Ficha:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha entrada:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Cliente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 3
                x1hoja.Cells(fila, columna).Formula = "Fecha informe:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).Formula = "Material recibido:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1
                Dim texto As String = ""
                Dim texto2 As String = ""
                texto = texto & "Muestra de suelo"
                Dim m_nitratos As Integer = 0
                Dim m_mineralizacion As Integer = 0
                Dim m_fosforobray As Integer = 0
                Dim m_fosforocitrico As Integer = 0
                Dim m_phagua As Integer = 0
                Dim m_phkci As Integer = 0
                Dim m_materiaorg As Integer = 0
                Dim m_potasioint As Integer = 0
                Dim m_sulfatos As Integer = 0
                Dim m_nitrogenoveg As Integer = 0
                For Each ss In lista2

                    'texto2 = texto2 & "// " & ss.MUESTRA
                    'If ss.FOSFOROBRAY = 1 Then
                    '    texto2 = texto2 & "- Fósforo Bray "
                    'End If
                    'If ss.FOSFOROCITRICO = 1 Then
                    '    texto2 = texto2 & "- Fósoforo cítrico "
                    'End If
                    'If ss.NITRATOS = 1 Then
                    '    texto2 = texto2 & " - Nitratos "
                    'End If
                    'If ss.PHAGUA = 1 Then
                    '    texto2 = texto2 & " - pH Agua "
                    'End If
                    'If ss.PHKCI = 1 Then
                    '    texto2 = texto2 & " - pH KCI "
                    'End If
                    'If ss.POTASIOINT = 1 Then
                    '    texto2 = texto2 & " - Potasio intercambiable "
                    'End If
                    'If ss.SULFATOS = 1 Then
                    '    texto2 = texto2 & " - Sulfatos "
                    'End If
                    'If ss.NITROGENOVEGETAL = 1 Then
                    '    texto2 = texto2 & " - Nitrógeno vegetal "
                    'End If
                    'If ss.MATERIAORG = 1 Then
                    '    texto2 = texto2 & " - Materia orgánica "
                    'End If
                    'If ss.MINERALIZACION = 1 Then
                    '    texto2 = texto2 & " - PMN (Potencial Mineralización de Nitrógeno) "
                    'End If

                    If ss.FOSFOROBRAY = 1 Then
                        m_fosforobray = 1
                    End If
                    If ss.FOSFOROCITRICO = 1 Then
                        m_fosforocitrico = 1
                    End If
                    If ss.NITRATOS = 1 Then
                        m_nitratos = 1
                    End If
                    If ss.PHAGUA = 1 Then
                        m_phagua = 1
                    End If
                    If ss.PHKCI = 1 Then
                        m_phkci = 1
                    End If
                    If ss.POTASIOINT = 1 Then
                        m_potasioint = 1
                    End If
                    If ss.SULFATOS = 1 Then
                        m_sulfatos = 1
                    End If
                    If ss.NITROGENOVEGETAL = 1 Then
                        m_nitrogenoveg = 1
                    End If
                    If ss.MATERIAORG = 1 Then
                        m_materiaorg = 1
                    End If
                    If ss.MINERALIZACION = 1 Then
                        m_mineralizacion = 1
                    End If

                Next

                If m_fosforobray = 1 Then
                    texto2 = texto2 & "Fósforo Bray - "
                End If
                If m_fosforocitrico = 1 Then
                    texto2 = texto2 & "Fósoforo cítrico - "
                End If
                If m_nitratos = 1 Then
                    texto2 = texto2 & "Nitratos - "
                End If
                If m_phagua = 1 Then
                    texto2 = texto2 & "pH Agua - "
                End If
                If m_phkci = 1 Then
                    texto2 = texto2 & "pH KCI - "
                End If
                If m_potasioint = 1 Then
                    texto2 = texto2 & "Potasio intercambiable - "
                End If
                If m_sulfatos = 1 Then
                    texto2 = texto2 & "Sulfatos - "
                End If
                If m_nitrogenoveg = 1 Then
                    texto2 = texto2 & "Nitrógeno vegetal - "
                End If
                If m_materiaorg = 1 Then
                    texto2 = texto2 & "Materia orgánica - "
                End If
                If m_mineralizacion = 1 Then
                    texto2 = texto2 & "PMN (Potencial Mineralización de Nitrógeno)"
                End If



                'x1hoja.Range("B12", "C13").Merge()
                'x1hoja.Range("B12", "C13").WrapText = True
                x1hoja.Cells(fila, columna).Formula = texto
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Estudio solicitado"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1


                'x1hoja.Range("B14", "D15").Merge()
                'x1hoja.Range("B14", "D15").WrapText = True
                x1hoja.Range("B13", "E14").Merge()
                x1hoja.Range("B13", "E14").WrapText = True

                x1hoja.Cells(fila, columna).Formula = texto2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).VerticalAlignment = XlVAlign.xlVAlignTop
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 2
                columna = 1
                'x1hoja.Cells(fila, columna).Formula = "Procesamiento:"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 9
                'fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Se recibieron las siguientes muestras:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 2
                x1hoja.Cells(fila, columna).Formula = "Total de muestras: " & lista2.Count
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = 1
                fila = fila + 1
                Dim cuenta As Integer = 1
                Dim detallemuestras As String = ""
                Dim idoperador As Integer = 0
                Dim operador As String = ""
                For Each s In lista
                    detallemuestras = detallemuestras & "(" & cuenta & ")" & " " & s.DETALLEMUESTRA & " / "
                    'x1hoja.Cells(fila, columna).Formula = cuenta & ")" & " " & s.DETALLEMUESTRA
                    'x1hoja.Cells(fila, columna).Font.Bold = False
                    'x1hoja.Cells(fila, columna).Font.Size = 9
                    'fila = fila + 1
                    cuenta = cuenta + 1
                    idoperador = s.OPERADOR
                Next
                Dim iu As New dUsuario
                iu.ID = idoperador
                iu = iu.buscar
                If Not iu Is Nothing Then
                    operador = iu.NOMBRE
                End If
                cuenta = cuenta - 1
                x1hoja.Range("A16", "E17").Merge()
                x1hoja.Range("A16", "E17").WrapText = True

                x1hoja.Cells(fila, columna).Formula = detallemuestras
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 3


                x1hoja.Cells(fila, columna).Formula = "INFORME"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 8
                fila = fila + 1
                Dim linea As Integer = 0
                Dim i As Integer = 1

                For Each s In lista


                    'MUESTRA 1 ****************************************************************
                    If i = 1 Then
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If

                    'MUESTRA 2 ****************************************************************
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
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 3 ********************************************************************************
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
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    ' MUESTRA 4 ******************************************************************************

                    If i = 4 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    ' MUESTRA 5 ******************************************************************************

                    If i = 5 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If


                    End If

                    'MUESTRA 6 *******************************************************************************
                    If i = 6 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 7 *******************************************************************************

                    If i = 7 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If



                    End If
                    'MUESTRA 8 *******************************************************************************

                    If i = 8 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    'MUESTRA 9 *******************************************************************************

                    If i = 9 Then
                        columna = 1
                        linea = 0
                        fila = fila + 2
                        x1hoja.Cells(fila, columna).Formula = "Análisis"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        columna = columna - 1
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Bray I (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Fósforo Cítrico (mg P/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitratos (mg N-NO3/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH Agua"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "pH KCI"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Potasio intercambiable (meq/100g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sulfatos (mgs/Kg)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Nitrógeno Vegetal (Valor Dumas %)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Materia orgánica (%)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "PMN (µg N-NH4/g)"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Calcio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Magnesio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Sodio"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "Acidez titulable"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "CIC"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "% SB"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = True
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            columna = columna - 1
                            linea = linea + 1
                        End If

                    End If
                    'MUESTRA 10 ******************************************************************************

                    If i = 10 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 2
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1


                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If


                    End If
                    'MUESTRA 11 ******************************************************************************

                    If i = 11 Then
                        fila = fila - linea
                        fila = fila + 1
                        linea = 0
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Resultado" & " " & i
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If
                    End If
                    'MUESTRA 12 ******************************************************************************

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
                        x1hoja.Cells(fila, columna).Interior.Color = RGB(192, 192, 192)
                        linea = linea + 1

                        If s.FOSFOROBRAY <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROBRAY
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.FOSFOROCITRICO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.FOSFOROCITRICO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITRATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITRATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHAGUA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHAGUA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PHKCI <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PHKCI
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.POTASIOINT <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.POTASIOINT
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SULFATOS <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SULFATOS
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.NITROGENOVEGETAL <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.NITROGENOVEGETAL
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MATERIAORGANICA <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MATERIAORGANICA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.PMN <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.PMN
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CALCIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CALCIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.MAGNESIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.MAGNESIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SODIO <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SODIO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.ACIDEZTITULABLE <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.ACIDEZTITULABLE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.CIC <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.CIC
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                        If s.SB <> "-1" Then
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = s.SB
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        Else
                            fila = fila + 1
                            x1hoja.Cells(fila, columna).Formula = "N/R"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            linea = linea + 1
                        End If

                    End If

                    '*****************************************************************************************
                    i = i + 1

                Next

                '***************************************
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "N/R = No requerido"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True

                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Métodos utilizados:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Fósforo Bray I: Bray, Kurtz - Espectrofotométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Fósforo Cítrico: INIA La Estanzuela. Lab. de Suelos - Espectrofotométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nitratos: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "pH Agua: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "pH KCI: INIA La Estanzuela. Lab. de Suelos - Potenciométrico"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Potasio intercambiable: INIA La Estanzuela. Lab. de Suelos - Espectrometría atómica"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Sulfatos: IAC Brasil - Turbidimetría"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Nitrógeno vegetal: Dumas AOAC 968.06 modif.LECO"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Carbono orgánico: Combustión a 900ºC y detección de CO2 por infrarrojo"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "PMN(Potencial mineralización de Nitrógeno): INIA La Estanzuela. Lab. de Suelos - Incubación anaeróbica"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Calcio"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Magnesio"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Sodio"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Acidez titulable"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "CIC"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "% SB"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False

                fila = fila + 2
                columna = 1

                x1hoja.Cells(fila, columna).formula = "Nota:"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Operador: " & operador
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1


                fila = fila + 1
                If sa.OBSERVACIONES <> "" Then
                    x1hoja.Cells(fila, columna).formula = sa.OBSERVACIONES
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                End If
                fila = fila + 1



                '******* CALCULO PRECIO ************************************************************************

                Dim listamuestras As New ArrayList
                listamuestras = s.listarporid(idsol)

                Dim ana As New dAnalisis

                Dim idtimbre As Integer = 86
                Dim idfosforobray As Integer = 131
                Dim idfosforocitrico As Integer = 132
                Dim idnitratos As Integer = 133
                Dim idphagua As Integer = 134
                Dim idphkci As Integer = 135
                Dim idpotasio As Integer = 136
                Dim idsulfatos As Integer = 137
                Dim idnitrogenovegetal As Integer = 138
                Dim idmateriaorganica As Integer = 139
                Dim idpmn As Integer = 140
                Dim idcalcio As Integer = 146
                Dim idmagnesio As Integer = 147
                Dim idsodio As Integer = 148
                Dim idpaquete1 As Integer = 142
                Dim idpaquete2 As Integer = 143
                Dim idpaquete3 As Integer = 144
                Dim idpaquete4 As Integer = 145
                Dim preciotimbre As Double = 0
                Dim preciofosforobray As Double = 0
                Dim preciofosforcitrico As Double = 0
                Dim precionitratos As Double = 0
                Dim preciophagua As Double = 0
                Dim preciophkci As Double = 0
                Dim preciopotasio As Double = 0
                Dim preciosulfatos As Double = 0
                Dim precionitrogenovegetal As Double = 0
                Dim preciomateriaorganica As Double = 0
                Dim preciopmn As Double = 0
                Dim preciocalcio As Double = 0
                Dim preciomagnesio As Double = 0
                Dim preciosodio As Double = 0
                Dim preciopaquete1 As Double = 0
                Dim preciopaquete2 As Double = 0
                Dim preciopaquete3 As Double = 0
                Dim preciopaquete4 As Double = 0

                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO
                ana.ID = idfosforobray
                ana = ana.buscar
                preciofosforobray = ana.COSTO
                ana.ID = idfosforocitrico
                ana = ana.buscar
                preciofosforcitrico = ana.COSTO
                ana.ID = idnitratos
                ana = ana.buscar
                precionitratos = ana.COSTO
                ana.ID = idphagua
                ana = ana.buscar
                preciophagua = ana.COSTO
                ana.ID = idphkci
                ana = ana.buscar
                preciophkci = ana.COSTO
                ana.ID = idpotasio
                ana = ana.buscar
                preciopotasio = ana.COSTO
                ana.ID = idsulfatos
                ana = ana.buscar
                preciosulfatos = ana.COSTO
                ana.ID = idnitrogenovegetal
                ana = ana.buscar
                precionitrogenovegetal = ana.COSTO
                ana.ID = idmateriaorganica
                ana = ana.buscar
                preciomateriaorganica = ana.COSTO
                ana.ID = idpmn
                ana = ana.buscar
                preciopmn = ana.COSTO
                ana.ID = idcalcio
                ana = ana.buscar
                preciocalcio = ana.COSTO
                ana.ID = idmagnesio
                ana = ana.buscar
                preciomagnesio = ana.COSTO
                ana.ID = idsodio
                ana = ana.buscar
                preciosodio = ana.COSTO
                ana.ID = idpaquete1
                ana = ana.buscar
                preciopaquete1 = ana.COSTO
                ana.ID = idpaquete2
                ana = ana.buscar
                preciopaquete2 = ana.COSTO
                ana.ID = idpaquete3
                ana = ana.buscar
                preciopaquete3 = ana.COSTO
                ana.ID = idpaquete4
                ana = ana.buscar
                preciopaquete4 = ana.COSTO

                Dim total As Double = 0
                Dim ss2 As New dSolicitudSuelos
                Dim lista3 As New ArrayList
                lista3 = ss2.listarporsolicitud(idsol)

                For Each ss2 In lista3

                    If ss2.FOSFOROBRAY = 1 Then
                        total = total + preciofosforobray
                    End If
                    If ss2.FOSFOROCITRICO = 1 Then
                        total = total + preciofosforcitrico
                    End If
                    If ss2.NITRATOS = 1 Then
                        total = total + precionitratos
                    End If
                    If ss2.PHAGUA = 1 Then
                        total = total + preciophagua
                    End If
                    If ss2.PHKCI = 1 Then
                        total = total + preciophkci
                    End If
                    If ss2.POTASIOINT = 1 Then
                        total = total + preciopotasio
                    End If
                    If ss2.SULFATOS = 1 Then
                        total = total + preciosulfatos
                    End If
                    If ss2.NITROGENOVEGETAL = 1 Then
                        total = total + precionitrogenovegetal
                    End If
                    If ss2.MATERIAORG = 1 Then
                        total = total + preciomateriaorganica
                    End If
                    If ss2.MINERALIZACION = 1 Then
                        total = total + preciopmn
                    End If
                    If ss.PAQUETE = 1 Then
                        total = (total + preciopaquete1) - precionitratos - preciofosforobray - preciopotasio - preciophagua - preciomateriaorganica
                    End If
                    If ss.PAQUETE = 2 Then
                        total = (total + preciopaquete2) - preciofosforobray - preciopotasio - preciophagua - preciosulfatos
                    End If
                    If ss.PAQUETE = 3 Then
                        total = (total + preciopaquete3) - precionitratos - preciofosforobray - preciopotasio - preciophagua
                    End If
                    If ss.PAQUETE = 4 Then
                        total = (total + preciopaquete4) - preciopotasio
                    End If
                Next

                total = Math.Round(total + preciotimbre, 2)
                '***********************************************************************************************
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Técnico resp::" & "Dr. Alejandro Morón"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y Timbre de la CJPU"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Convenio FCA UDE - Colaveco"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                '**********************************************************

                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()
                fila = fila + 5
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



            End If
        End If




        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
        Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\Agro - suelos\" & idsol & "_prueba.xls")
        x1app.Visible = True
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub calcularcic()
        Dim ca As Double = 0
        Dim mg As Double = 0
        Dim na As Double = 0
        Dim k As Double = 0
        Dim at As Double = 0
        Dim cic As Double = 0
        If TextCalcio.Text.Length > 0 Then
            ca = TextCalcio.Text.Trim
        End If
        If TextMagnesio.Text.Length > 0 Then
            mg = TextMagnesio.Text.Trim
        End If
        If TextSodio.Text.Length > 0 Then
            na = TextSodio.Text.Trim
        End If
        If TextPotasio.Text.Length > 0 Then
            k = TextPotasio.Text.Trim
        End If
        If TextAcidezT.Text.Length > 0 Then
            at = TextAcidezT.Text.Trim
        End If
        cic = ca + mg + na + k + at
        If cic <> 0 Then
            TextCIC.Text = cic
        End If
    End Sub
    Private Sub calcularsb()
        Dim ca As Double = 0
        Dim mg As Double = 0
        Dim na As Double = 0
        Dim k As Double = 0
        Dim at As Double = 0
        Dim cic As Double = 0
        Dim valor As Double = 0
        Dim resultado As Double = 0
        If TextCalcio.Text.Length > 0 Then
            ca = TextCalcio.Text.Trim
        End If
        If TextMagnesio.Text.Length > 0 Then
            mg = TextMagnesio.Text.Trim
        End If
        If TextSodio.Text.Length > 0 Then
            na = TextSodio.Text.Trim
        End If
        If TextPotasio.Text.Length > 0 Then
            k = TextPotasio.Text.Trim
        End If
        If TextAcidezT.Text.Length > 0 Then
            at = TextAcidezT.Text.Trim
        End If
        cic = ca + mg + na + k + at
        valor = ca + mg + na + k
        resultado = (valor / cic) * 100
        If resultado <> 0 Then
            TextSB.Text = Math.Round(resultado, 2)
        End If
    End Sub

    Private Sub TextCalcio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCalcio.TextChanged
        calcularcic()
        calcularsb()
    End Sub

    Private Sub TextMagnesio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMagnesio.TextChanged
        calcularcic()
        calcularsb()
    End Sub

    Private Sub TextSodio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextSodio.TextChanged
        calcularcic()
        calcularsb()
    End Sub

    Private Sub TextAcidezT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAcidezT.TextChanged
        calcularcic()
        calcularsb()
    End Sub

    Private Sub TextPotasio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextPotasio.TextChanged
        calcularcic()
        calcularsb()
    End Sub
End Class