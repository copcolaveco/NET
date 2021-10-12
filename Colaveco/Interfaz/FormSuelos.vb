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
        TextZinc.Text = ""
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
        TextZinc.Enabled = False
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
            If s.ZINC <> "-1" Then
                TextZinc.Text = s.ZINC
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
                If ss_.ZINC = 1 Then
                    texto_ = texto_ & "Zinc / "
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
                If ss_.ZINC = 1 Then
                    TextZinc.Enabled = True
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
        Dim zinc As Double = 0


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
        If TextZinc.Text <> "" Then
            zinc = TextZinc.Text.Trim
        Else
            zinc = -1
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
            s.ZINC = zinc
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
            s.ZINC = zinc
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
        Dim zinc As Double = 0

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
        If TextZinc.Text <> "" Then
            zinc = TextZinc.Text.Trim
        Else
            zinc = -1
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
            s.ZINC = zinc
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
            s.ZINC = zinc
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
                            If (s.marcar(Usuario)) Then
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


    Private Sub TextCarbonoOrganico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCarbonoOrganico.TextChanged
        Dim carborg As Double = 0
        Dim matorg As Double = 0
        carborg = Val(TextCarbonoOrganico.Text)
        matorg = carborg * 1.724
        TextMateriaOrganica.Text = matorg
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