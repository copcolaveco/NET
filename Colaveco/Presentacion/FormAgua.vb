Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormAgua
    Private _usuario As dUsuario
    Dim idsol As Long
    Public fechaendo As Date
    Public fechamfc As Date
    Public fechacentrimide As Date
    Public fechamhpc As Date
    Public fechaagua As Date
    Public lotnitrato As String
    Public lotnitrito As String
    Public lotdureza As String
    
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
        cargarComboVolSiembra()
        cargarComboAspecto()
        cargarComboOlor()
        cargarComboColor()
        cargarComboMateriaOrganica()
        cargarComboDureza()
        cargarComboNitrato()
        cargarComboNitrito()
        cargarComboTecnica()
        limpiar()

    End Sub
#End Region
    
    Public Sub listarfichas()
        Dim a As New dAgua2
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
    Public Sub listaragua()
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAgua2 = CType(ListFichas.SelectedItem, dAgua2)
            Dim id As Long = a.IDSOLICITUD
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
    Private Sub limpiar()
        TextFicha.Text = ""
        DateFechaSolicitud.Value = Now()
        TextMuestra.Text = ""
        TextObservaciones.Text = ""
        TextTipoInforme.Text = ""
        TextColiformesTotales.Text = ""
        TextColiformesFecales.Text = ""
        ComboAspecto.Text = ""
        ComboAspecto.SelectedItem = Nothing
        ComboOlor.Text = ""
        ComboOlor.SelectedItem = Nothing
        ComboColor.Text = ""
        ComboColor.SelectedItem = Nothing
        TextPH.Text = ""
        ComboMateriaOrganica.Text = ""
        ComboMateriaOrganica.SelectedItem = Nothing
        TextConductividad.Text = ""
        ComboDureza.Text = ""
        ComboDureza.SelectedItem = Nothing
        TextNitrato.Text = ""
        TextNitrito.Text = ""
        TextHeterotroficos22.Text = ""
        TextTurbiedad.Text = ""
        ComboNitrato.Text = ""
        ComboNitrato.SelectedItem = Nothing
        ComboNitrito.Text = ""
        ComboNitrito.SelectedItem = Nothing
        TextDureza.Text = ""
        ComboVolSiembra.Text = ""
        ComboVolSiembra.SelectedItem = Nothing
        ComboVolSiembra2.Text = ""
        ComboVolSiembra2.SelectedItem = Nothing
        ComboTecnica.Text = "FM"
        ComboTecnica.SelectedItem = 1
        TextHeterotroficos37.Text = ""
        TextHeterotroficos35.Text = ""
        TextCloroLibre.Text = ""
        TextCloroResidual.Text = ""
        TextPseudomonasA.Text = ""
        TextPseudomonaSPP.Text = ""
        MaskedEndo.Text = ""
        MaskedMFC.Text = ""
        MaskedCetrimide.Text = ""
        MaskedMHPC.Text = ""
        MaskedAguaDil.Text = ""
        TextEcoli.Text = ""
        TextSulfitoReductores.Text = ""
        TextLoteNitrato.Text = ""
        TextLoteNitrito.Text = ""
        TextLoteDureza.Text = ""
        TextDatos.Text = ""
        deshabilitarcontroles()
    End Sub
    Public Sub cargarComboVolSiembra()
        Dim vs As New dVolumenSiembra
        Dim lista As New ArrayList
        lista = vs.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each vs In lista
                    ComboVolSiembra.Items.Add(vs)
                    ComboVolSiembra2.Items.Add(vs)
                Next
            End If
        End If
    End Sub

    Public Sub cargarComboAspecto()
        Dim a As New dAspecto
        Dim lista As New ArrayList
        lista = a.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ComboAspecto.Items.Add(a)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboOlor()
        Dim o As New dOlor
        Dim lista As New ArrayList
        lista = o.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each o In lista
                    ComboOlor.Items.Add(o)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboColor()
        Dim c As New dColor
        Dim lista As New ArrayList
        lista = c.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboColor.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMateriaOrganica()
        Dim mo As New dMateriaOrganica
        Dim lista As New ArrayList
        lista = mo.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each mo In lista
                    ComboMateriaOrganica.Items.Add(mo)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboDureza()
        Dim d As New dDureza
        Dim lista As New ArrayList
        lista = d.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                    ComboDureza.Items.Add(d)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboNitrato()
        Dim n As New dNitrato
        Dim lista As New ArrayList
        lista = n.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    ComboNitrato.Items.Add(n)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboNitrito()
        Dim ni As New dNitrito
        Dim lista As New ArrayList
        lista = ni.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ni In lista
                    ComboNitrito.Items.Add(ni)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTecnica()
        Dim t As New dTecnica
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTecnica.Items.Add(t)
                Next
            End If
        End If
    End Sub
    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        limpiar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAgua2 = CType(ListFichas.SelectedItem, dAgua2)
            Dim id As Long = a.IDSOLICITUD
            Dim lista As New ArrayList
            lista = a.listarporid(id)
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

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim a As dAgua2 = CType(ListMuestras.SelectedItem, dAgua2)
            Dim m As New dMedios
            Dim lista As New ArrayList
            lista = m.listar
            Dim endo As String
            Dim mfc44 As String
            Dim centrimide As String
            Dim mhpc As String
            Dim aguadil As String
            Dim lotenitrato As String
            Dim lotenitrito As String
            Dim lotedureza As String
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each m In lista
                        endo = m.ENDO35
                        mfc44 = m.MFC44_5
                        centrimide = m.CENTRIMIDE37
                        mhpc = m.MHPC
                        aguadil = m.AGUADEDILUCION
                        lotenitrato = m.NITRATO
                        lotenitrito = m.NITRITO
                        lotedureza = m.DUREZA
                    Next
                End If
            End If
            fechaendo = endo
            fechamfc = mfc44
            fechacentrimide = centrimide
            fechamhpc = mhpc
            fechaagua = aguadil
            lotnitrato = lotenitrato
            lotnitrito = lotenitrito
            lotdureza = lotedureza
            TextId.Text = a.ID
            TextFicha.Text = a.IDSOLICITUD
            DateFechaSolicitud.Value = a.FECHAENTRADA
            ComboOperador.Text = Usuario.NOMBRE
            TextMuestra.Text = a.IDMUESTRA
            If a.FECHAPROCESAMIENTO <> "00:00:00" Then
                DateFechaProceso.Value = a.FECHAPROCESAMIENTO
            Else
                DateFechaProceso.Value = Now()
            End If

            Dim tec As dTecnica
            For Each tec In ComboTecnica.Items
                If tec.ID = a.TECNICA Then
                    ComboTecnica.SelectedItem = tec
                    Exit For
                End If
            Next
            Dim vs As dVolumenSiembra
            For Each vs In ComboVolSiembra.Items
                If vs.ID = a.VOLUMENDESIEMBRA Then
                    ComboVolSiembra.SelectedItem = vs
                    Exit For
                End If
            Next
            For Each vs In ComboVolSiembra2.Items
                If vs.ID = a.VOLUMENDESIEMBRA2 Then
                    ComboVolSiembra2.SelectedItem = vs
                    Exit For
                End If
            Next
            If a.MEDIOS = 0 Then
                If endo <> "00:00:00" Then
                    MaskedEndo.Text = endo
                Else
                    MaskedEndo.Text = "00/00/0000"
                End If
                If mfc44 <> "00:00:00" Then
                    MaskedMFC.Text = mfc44
                Else
                    MaskedMFC.Text = "00/00/0000"
                End If
                If centrimide <> "00:00:00" Then
                    MaskedCetrimide.Text = centrimide
                Else
                    MaskedCetrimide.Text = "00/00/0000"
                End If
                If mhpc <> "00:00:00" Then
                    MaskedMHPC.Text = mhpc
                Else
                    MaskedMHPC.Text = "00/00/0000"
                End If
                If aguadil <> "00:00:00" Then
                    MaskedAguaDil.Text = aguadil
                Else
                    MaskedAguaDil.Text = "00/00/0000"
                End If
                
            Else
                If a.ENDO35 <> "00:00:00" Then
                    MaskedEndo.Text = a.ENDO35
                Else
                    MaskedEndo.Text = "00/00/0000"
                End If
                If a.MFC44_5 <> "00:00:00" Then
                    MaskedMFC.Text = a.MFC44_5
                Else
                    MaskedMFC.Text = "00/00/0000"
                End If
                If a.CENTRIMIDE37 <> "00:00:00" Then
                    MaskedCetrimide.Text = a.CENTRIMIDE37
                Else
                    MaskedCetrimide.Text = "00/00/0000"
                End If
                If a.MHPC <> "00:00:00" Then
                    MaskedMHPC.Text = a.MHPC
                Else
                    MaskedMHPC.Text = "00/00/0000"
                End If
                If a.AGUADEDILUCION <> "00:00:00" Then
                    MaskedAguaDil.Text = a.AGUADEDILUCION
                Else
                    MaskedAguaDil.Text = "00/00/0000"
                End If
                
            End If
            '***********************************************
            'If lotenitrato <> "-1" Then
            '    TextLoteNitrato.Text = lotenitrato
            'Else
            '    TextLoteNitrato.Text = ""
            'End If
            'If lotenitrito <> "-1" Then
            '    TextLoteNitrito.Text = lotenitrito
            'Else
            '    TextLoteNitrito.Text = ""
            'End If
            'If lotedureza <> "-1" Then
            '    TextLoteDureza.Text = lotedureza
            'Else
            '    TextLoteDureza.Text = ""
            'End If
            '**********************************************
            If a.LOTENITRATO <> "-1" Then
                TextLoteNitrato.Text = a.LOTENITRATO
            Else
                TextLoteNitrato.Text = lotenitrato
            End If
            If a.LOTENITRITO <> "-1" Then
                TextLoteNitrito.Text = a.LOTENITRITO
            Else
                TextLoteNitrito.Text = lotenitrito
            End If
            If a.LOTEDUREZA <> "-1" Then
                TextLoteDureza.Text = a.LOTEDUREZA
            Else
                TextLoteDureza.Text = lotedureza
            End If
            '************************************************
            If a.COLIFORMESTOTALES <> -1 Then
                TextColiformesTotales.Text = a.COLIFORMESTOTALES
            End If
            If a.COLIFORMESFECALES <> -1 Then
                TextColiformesFecales.Text = a.COLIFORMESFECALES
            End If
            If a.PSEUDOMONASAERUGINOSA <> -1 Then
                TextPseudomonasA.Text = a.PSEUDOMONASAERUGINOSA
            End If
            If a.PSEUDOMONASPP <> -1 Then
                TextPseudomonaSPP.Text = a.PSEUDOMONASPP
            End If
            If a.ECOLI <> -1 Then
                TextEcoli.Text = a.ECOLI
            End If
            If a.SULFITOREDUCTORES <> -1 Then
                TextSulfitoReductores.Text = a.SULFITOREDUCTORES
            End If
            If a.HETEROTROFICOS35 <> -1 Then
                TextHeterotroficos35.Text = a.HETEROTROFICOS35
            End If
            If a.HETEROTROFICOS <> -1 Then
                TextHeterotroficos22.Text = a.HETEROTROFICOS
            End If
            If a.HETEROTROFICOS37 <> -1 Then
                TextHeterotroficos37.Text = a.HETEROTROFICOS37
            End If

            Dim asp As dAspecto
            For Each asp In ComboAspecto.Items
                If asp.ID = a.IDASPECTO Then
                    ComboAspecto.SelectedItem = asp
                    Exit For
                    'Else
                    '    ComboAspecto.Text = "límpida"
                End If
            Next



            Dim ol As dOlor
            For Each ol In ComboOlor.Items
                If ol.ID = a.IDOLOR Then
                    ComboOlor.SelectedItem = ol
                    Exit For
                    'Else
                    '    ComboOlor.Text = "inodora"
                End If
            Next



            Dim col As dColor
            For Each col In ComboColor.Items
                If col.ID = a.IDCOLOR Then
                    ComboColor.SelectedItem = col
                    Exit For
                    'Else
                    '    ComboColor.Text = "incolora"
                End If
            Next


            If a.PH <> -1 Then
                TextPH.Text = a.PH
            End If
            If a.NITRATO <> "-1" And a.NITRATO <> "-1.00" Then
                TextNitrato.Text = a.NITRATO
            End If
            If a.NITRITO <> "-1" And a.NITRITO <> "-1.00" Then
                TextNitrito.Text = a.NITRITO
            End If
            Dim nitra As dNitrato
            For Each nitra In ComboNitrato.Items
                If nitra.ID = a.NITRATOTIRAS Then
                    ComboNitrato.SelectedItem = nitra
                    Exit For
                End If
            Next
            Dim nitri As dNitrito
            For Each nitri In ComboNitrito.Items
                If nitri.ID = a.NITRITOTIRAS Then
                    ComboNitrito.SelectedItem = nitri
                    Exit For
                End If
            Next

            Dim morg As dMateriaOrganica
            For Each morg In ComboMateriaOrganica.Items
                If morg.ID = a.IDMATERIAORGANICA Then
                    ComboMateriaOrganica.SelectedItem = morg
                    Exit For
                    'Else
                    '    ComboMateriaOrganica.Text = "No detectado"
                End If
            Next

            If a.TURBIEDAD <> -1 Then
                TextTurbiedad.Text = a.TURBIEDAD
            End If
            If a.DUREZA <> "-1" And a.DUREZA <> "-1.00" Then
                TextDureza.Text = a.DUREZA
            End If
            Dim dur As dDureza
            For Each dur In ComboDureza.Items
                If dur.ID = a.IDDUREZA Then
                    ComboDureza.SelectedItem = dur
                    Exit For
                End If
            Next
            If a.CLOROLIBRE <> -1 Then
                TextCloroLibre.Text = a.CLOROLIBRE
            End If
            If a.CLORORESIDUAL <> -1 Then
                TextCloroResidual.Text = a.CLORORESIDUAL
            End If
            If a.CONDUCTIVIDAD <> -1 Then
                TextConductividad.Text = a.CONDUCTIVIDAD
            End If
            '********************************************
            Dim sa As New dSolicitudAnalisis
            Dim id As Long = TextFicha.Text.Trim
            sa.ID = id
            sa = sa.buscar()
            If Not sa.OBSERVACIONES Is Nothing Then
                TextObservaciones.Text = sa.OBSERVACIONES
            End If

            Dim si As New dSubInforme
            si.ID = sa.IDSUBINFORME
            si = si.buscar()
            TextTipoInforme.Text = si.NOMBRE & " "
            '*********************************************
            Dim a1 As New dAgua
            a1.ID = id
            a1 = a1.buscar()

            Dim tp As New dTipoPozo
            tp.ID = a1.IDTIPOPOZO
            If a1.IDTIPOPOZO <> 0 Then
                tp = tp.buscar()
            End If

            Dim mue As New dMuestraExtraida
            mue.ID = a1.IDMUESTRAEXTRAIDA
            mue = mue.buscar()

            Dim mfc As New dMuestraFueraCondicion
            mfc.ID = a1.IDMUESTRAFUERACONDICION
            mfc = mfc.buscar()

            Dim at As New dAguaTratada
            at.ID = a1.IDAGUATRATADA
            at = at.buscar()

            Dim ec As New dEstadoConservacion
            ec.ID = a1.IDESTADODECONSERVACION
            ec = ec.buscar()
            TextTipoInforme.Text = si.NOMBRE & " "
            If a1.HET22 = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Heterotróficos 22" & " "
            End If
            If a1.HET35 = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Heterotróficos 35" & " "
            End If
            If a1.HET37 = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Heterotróficos 37" & " "
            End If
            If a1.CLORO = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Cloro" & " "
            End If
            If a1.CONDYPH = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Conductividad y pH" & " "
            End If
            If a1.ECOLI = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Ecoli" & " "
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                TextTipoInforme.Text = TextTipoInforme.Text & " " & "+ Sulfito reductores" & " "
            End If

            If sa.IDSUBINFORME = 2 Then
                deshabilitarcontroles()
                habilitamicrobiologico()
                habilitafisicoquimico()
            ElseIf sa.IDSUBINFORME = 29 Then
                deshabilitarcontroles()
                habilitafisicoquimico()
            ElseIf sa.IDSUBINFORME = 30 Or sa.IDSUBINFORME = 45 Then
                deshabilitarcontroles()
                habilitamicrobiologico()
            ElseIf sa.IDSUBINFORME = 48 Then
                deshabilitarcontroles()
                habilitamicrobiologico()
                habilitaheterotroficos()
            ElseIf sa.IDSUBINFORME = 46 Then
                deshabilitarcontroles()
                habilitacloro()
            ElseIf sa.IDSUBINFORME = 47 Then
                deshabilitarcontroles()
                habilitacondyph()
            ElseIf sa.IDSUBINFORME = 49 Then
                deshabilitarcontroles()
                habilitaheterotroficos()
            End If

            If a1.HET22 = 1 Or a1.HET35 = 1 Or a1.HET37 = 1 Then
                habilitaheterotroficos()
            End If
            If a1.CLORO = 1 Then
                habilitacloro()
            End If
            If a1.CONDYPH = 1 Then
                habilitacondyph()
            End If
            If a1.ECOLI = 1 Then
                habilitaecoli()
            End If
            If a1.SULFITOREDUCTORES = 1 Then
                habilitasulfitoreductores()
            End If
            Dim textoMO As String
            If a1.MUESTRAOFICIAL = 0 Then
                textoMO = "No"
            Else
                textoMO = "Si"
            End If
            TextDatos.Text = "Tipo pozo:" & " " & tp.NOMBRE & " / " & "Antiguedad:" & " " & a1.ANTIGUEDAD & " / " & "Distancia pozo negro:" & " " & a1.DISTANCIAPOZONEGRO & " / " & "Distancia tambo:" & " " & a1.DISTANCIATAMBO & " / " & "Muestra extraída:" & " " & mue.NOMBRE & " / " & "Muestra fuera condición:" & " " & mfc.NOMBRE & " / " & "Profundidad:" & " " & a1.PROFUNDIDAD & " / " & "Agua tratada:" & " " & at.NOMBRE & " / " & "Estado conservación:" & " " & ec.NOMBRE & " / " & "Muestra oficial M.G.A.P.:" & " " & textoMO
        End If

    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim idsolicitud As Long = TextFicha.Text.Trim
        Dim fechaentrada As Date = DateFechaSolicitud.Value.ToString("yyyy-MM-dd")
        Dim fechaent As String
        fechaent = Format(fechaentrada, "yyyy-MM-dd")
        Dim fechaemision As Date = Now()
        Dim fechaemi As String
        fechaemi = Format(fechaemision, "yyyy-MM-dd")
        If TextMuestra.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la muestra", MsgBoxStyle.Exclamation, "Atención") : TextMuestra.Focus() : Exit Sub
        Dim idmuestra As String = TextMuestra.Text.Trim
        Dim observaciones As String
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim coliformestotales As Integer
        If TextColiformesTotales.Text <> "" Then
            coliformestotales = TextColiformesTotales.Text.Trim
        Else
            coliformestotales = -1
        End If
        Dim coliformesfecales As Integer
        If TextColiformesFecales.Text <> "" Then
            coliformesfecales = TextColiformesFecales.Text.Trim
        Else
            coliformesfecales = -1
        End If
        Dim idaspecto As dAspecto = CType(ComboAspecto.SelectedItem, dAspecto)
        Dim idolor As dOlor = CType(ComboOlor.SelectedItem, dOlor)
        Dim idcolor As dColor = CType(ComboColor.SelectedItem, dColor)
        Dim ph As Double
        If TextPH.Text <> "" Then
            ph = TextPH.Text.Trim
        Else
            ph = -1
        End If
        Dim idmateriaorganica As dMateriaOrganica = CType(ComboMateriaOrganica.SelectedItem, dMateriaOrganica)
        Dim conductividad As Integer
        If TextConductividad.Text <> "" Then
            conductividad = TextConductividad.Text.Trim
        Else
            conductividad = -1
        End If
        Dim iddureza As dDureza = CType(ComboDureza.SelectedItem, dDureza)
        Dim nitrato As String
        If TextNitrato.Text <> "" Then
            nitrato = TextNitrato.Text.Trim
        Else
            nitrato = -1
        End If
        Dim nitrito As String
        If TextNitrito.Text <> "" Then
            nitrito = TextNitrito.Text.Trim
        Else
            nitrito = -1
        End If
        Dim fechaproceso As Date = DateFechaProceso.Value.ToString("yyyy-MM-dd")
        Dim fechapro As String
        fechapro = Format(fechaproceso, "yyyy-MM-dd")
        Dim heterotroficos22 As Double
        If TextHeterotroficos22.Text <> "" Then
            heterotroficos22 = TextHeterotroficos22.Text.Trim
        Else
            heterotroficos22 = -1
        End If
        Dim turbiedad As Double
        If TextTurbiedad.Text <> "" Then
            turbiedad = TextTurbiedad.Text.Trim
        Else
            turbiedad = -1
        End If
        Dim nitratotiras As dNitrato = CType(ComboNitrato.SelectedItem, dNitrato)
        Dim nitritotiras As dNitrito = CType(ComboNitrito.SelectedItem, dNitrito)
        Dim dureza As String
        If TextDureza.Text <> "" Then
            dureza = TextDureza.Text.Trim
        Else
            dureza = -1
        End If
        Dim volumensiembra As dVolumenSiembra = CType(ComboVolSiembra.SelectedItem, dVolumenSiembra)
        Dim volumensiembra2 As dVolumenSiembra = CType(ComboVolSiembra2.SelectedItem, dVolumenSiembra)
        Dim tecnica As dTecnica = CType(ComboTecnica.SelectedItem, dTecnica)
        Dim heterotroficos35 As Double
        If TextHeterotroficos35.Text <> "" Then
            heterotroficos35 = TextHeterotroficos35.Text.Trim
        Else
            heterotroficos35 = -1
        End If
        Dim heterotroficos37 As Double
        If TextHeterotroficos37.Text <> "" Then
            heterotroficos37 = TextHeterotroficos37.Text.Trim
        Else
            heterotroficos37 = -1
        End If
        Dim clorolibre As Double
        If TextCloroLibre.Text <> "" Then
            clorolibre = TextCloroLibre.Text.Trim
        Else
            clorolibre = -1
        End If
        Dim clororesidual As Double
        If TextCloroResidual.Text <> "" Then
            clororesidual = TextCloroResidual.Text.Trim
        Else
            clororesidual = -1
        End If
        Dim pseudomonasa As Double
        If TextPseudomonasA.Text <> "" Then
            pseudomonasa = TextPseudomonasA.Text.Trim
        Else
            pseudomonasa = -1
        End If
        Dim pseudomonaspp As Double
        If TextPseudomonaSPP.Text <> "" Then
            pseudomonaspp = TextPseudomonaSPP.Text.Trim
        Else
            pseudomonaspp = -1
        End If
        Dim endo35 As Date
        Dim endo As String
        If MaskedEndo.Text <> "00/00/0000" Then
            endo35 = MaskedEndo.Text
            endo = Format(endo35, "yyyy-MM-dd")
        End If
        Dim mfc44_5 As Date
        Dim mfc As String
        If MaskedMFC.Text <> "00/00/0000" Then
            mfc44_5 = MaskedMFC.Text
            mfc = Format(mfc44_5, "yyyy-MM-dd")
        End If
        Dim centrimide37 As Date
        Dim centrimide As String
        If MaskedCetrimide.Text <> "00/00/0000" Then
            centrimide37 = MaskedCetrimide.Text
            centrimide = Format(centrimide37, "yyyy-MM-dd")
        End If
        Dim mhpc_37 As Date
        Dim mhpc As String
        If MaskedMHPC.Text <> "00/00/0000" Then
            mhpc_37 = MaskedMHPC.Text
            mhpc = Format(mhpc_37, "yyyy-MM-dd")
        End If
        Dim aguadedilucion As Date
        Dim aguadilucion As String
        If MaskedAguaDil.Text <> "00/00/0000" Then
            aguadedilucion = MaskedAguaDil.Text
            aguadilucion = Format(aguadedilucion, "yyyy-MM-dd")
        End If
        Dim ecoli As Integer
        If TextEcoli.Text <> "" Then
            ecoli = TextEcoli.Text.Trim
        Else
            ecoli = -1
        End If
        Dim sulfitoreductores As Integer
        If TextSulfitoReductores.Text <> "" Then
            sulfitoreductores = TextSulfitoReductores.Text.Trim
        Else
            sulfitoreductores = -1
        End If
        Dim lote_nitrato As String = ""
        If TextLoteNitrato.Text <> "" Then
            lote_nitrato = TextLoteNitrato.Text.Trim
        End If
        Dim lote_nitrito As String = ""
        If TextLoteNitrito.Text <> "" Then
            lote_nitrito = TextLoteNitrito.Text.Trim
        End If
        Dim lote_dureza As String = ""
        If TextLoteDureza.Text <> "" Then
            lote_dureza = TextLoteDureza.Text.Trim
        End If
        Dim operador As Integer = Usuario.ID
        If TextId.Text.Trim.Length > 0 Then
            Dim a As New dAgua2()
            Dim m As New dMedios
            Dim id As Long = CType(TextId.Text.Trim, Long)
            a.ID = id
            a.IDSOLICITUD = idsolicitud
            a.FECHAENTRADA = fechaent
            a.FECHAEMISION = fechaemi
            a.IDMUESTRA = idmuestra
            a.OBSERVACIONES = observaciones
            a.COLIFORMESTOTALES = coliformestotales
            a.COLIFORMESFECALES = coliformesfecales
            If Not idaspecto Is Nothing Then
                a.IDASPECTO = idaspecto.ID
            End If
            If Not idolor Is Nothing Then
                a.IDOLOR = idolor.ID
            End If
            If Not idcolor Is Nothing Then
                a.IDCOLOR = idcolor.ID
            End If
            a.PH = ph
            If Not idmateriaorganica Is Nothing Then
                a.IDMATERIAORGANICA = idmateriaorganica.ID
            End If
            a.CONDUCTIVIDAD = conductividad
            If Not iddureza Is Nothing Then
                a.IDDUREZA = iddureza.ID
            End If
            a.NITRATO = nitrato
            a.NITRITO = nitrito
            a.FECHAPROCESAMIENTO = fechapro
            a.HETEROTROFICOS = heterotroficos22
            a.TURBIEDAD = turbiedad
            If Not nitratotiras Is Nothing Then
                a.NITRATOTIRAS = nitratotiras.ID
            End If
            If Not nitritotiras Is Nothing Then
                a.NITRITOTIRAS = nitritotiras.ID
            End If
            a.DUREZA = dureza
            If Not volumensiembra Is Nothing Then
                a.VOLUMENDESIEMBRA = volumensiembra.ID
            End If
            If Not volumensiembra2 Is Nothing Then
                a.VOLUMENDESIEMBRA2 = volumensiembra2.ID
            End If
            If Not tecnica Is Nothing Then
                a.TECNICA = tecnica.ID
            End If
            a.HETEROTROFICOS37 = heterotroficos37
            a.HETEROTROFICOS35 = heterotroficos35
            a.CLOROLIBRE = clorolibre
            a.CLORORESIDUAL = clororesidual
            a.PSEUDOMONASAERUGINOSA = pseudomonasa
            a.PSEUDOMONASPP = pseudomonaspp
            If MaskedEndo.Text <> "00/00/0000" Then
                a.ENDO35 = endo
                m.ENDO35 = endo
            Else
                a.ENDO35 = "00/00/0000"
                m.ENDO35 = Format(fechaendo, "yyyy-MM-dd")
            End If
            If MaskedMFC.Text <> "00/00/0000" Then
                a.MFC44_5 = mfc
                m.MFC44_5 = mfc
            Else
                a.MFC44_5 = "00/00/0000"
                m.MFC44_5 = Format(fechamfc, "yyyy-MM-dd")
            End If
            If MaskedCetrimide.Text <> "00/00/0000" Then
                a.CENTRIMIDE37 = centrimide
                m.CENTRIMIDE37 = centrimide
            Else
                a.CENTRIMIDE37 = "00/00/0000"
                m.CENTRIMIDE37 = Format(fechacentrimide, "yyyy-MM-dd")
            End If
            If MaskedMHPC.Text <> "00/00/0000" Then
                a.MHPC = mhpc
                m.MHPC = mhpc
            Else
                a.MHPC = "00/00/0000"
                m.MHPC = Format(fechamhpc, "yyyy-MM-dd")
            End If
            If MaskedAguaDil.Text <> "00/00/0000" Then
                a.AGUADEDILUCION = aguadilucion
                m.AGUADEDILUCION = aguadilucion
            Else
                a.AGUADEDILUCION = "00/00/0000"
                m.AGUADEDILUCION = Format(fechaagua, "yyyy-MM-dd")
            End If
            a.ECOLI = ecoli
            a.SULFITOREDUCTORES = sulfitoreductores
            If lote_nitrato <> "" Then
                a.LOTENITRATO = lote_nitrato
                m.NITRATO = lote_nitrato
            End If
            If lote_nitrito <> "" Then
                a.LOTENITRITO = lote_nitrito
                m.NITRITO = lote_nitrito
            End If
            If lote_dureza <> "" Then
                a.LOTEDUREZA = lote_dureza
                m.DUREZA = lote_dureza
            End If
            a.OPERADOR = operador
            a.MEDIOS = 1
            a.MARCA = 0
            If (a.modificar(Usuario)) Then
                m.modificar(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'listaragua()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dAgua2()
            Dim m As New dMedios
            a.IDSOLICITUD = idsolicitud
            a.FECHAENTRADA = fechaent
            a.FECHAEMISION = fechaemi
            a.IDMUESTRA = idmuestra
            a.OBSERVACIONES = observaciones
            a.COLIFORMESTOTALES = coliformestotales
            a.COLIFORMESFECALES = coliformesfecales
            If Not idaspecto Is Nothing Then
                a.IDASPECTO = idaspecto.ID
            End If
            If Not idolor Is Nothing Then
                a.IDOLOR = idolor.ID
            End If
            If Not idcolor Is Nothing Then
                a.IDCOLOR = idcolor.ID
            End If
            a.PH = ph
            If Not idmateriaorganica Is Nothing Then
                a.IDMATERIAORGANICA = idmateriaorganica.ID
            End If
            a.CONDUCTIVIDAD = conductividad
            If Not iddureza Is Nothing Then
                a.IDDUREZA = iddureza.ID
            End If
            a.NITRATO = nitrato
            a.NITRITO = nitrito
            a.FECHAPROCESAMIENTO = fechapro
            a.HETEROTROFICOS = heterotroficos22
            a.TURBIEDAD = turbiedad
            a.NITRATOTIRAS = nitratotiras.ID
            a.NITRITOTIRAS = nitritotiras.ID
            a.DUREZA = dureza
            If Not volumensiembra Is Nothing Then
                a.VOLUMENDESIEMBRA = volumensiembra.ID
            End If
            If Not tecnica Is Nothing Then
                a.TECNICA = tecnica.ID
            End If
            a.HETEROTROFICOS37 = heterotroficos37
            a.HETEROTROFICOS35 = heterotroficos35
            a.CLOROLIBRE = clorolibre
            a.CLORORESIDUAL = clororesidual
            a.PSEUDOMONASAERUGINOSA = pseudomonasa
            a.PSEUDOMONASPP = pseudomonaspp
            a.ENDO35 = endo
            a.MFC44_5 = mfc
            a.CENTRIMIDE37 = centrimide
            a.MHPC = mhpc
            a.AGUADEDILUCION = aguadilucion
            a.ECOLI = ecoli
            a.SULFITOREDUCTORES = sulfitoreductores
            If lote_nitrato <> "" Then
                a.LOTENITRATO = lote_nitrato
                m.NITRATO = lote_nitrato
            End If
            If lote_nitrito <> "" Then
                a.LOTENITRITO = lote_nitrito
                m.NITRITO = lote_nitrito
            End If
            If lote_dureza <> "" Then
                a.LOTEDUREZA = lote_dureza
                m.DUREZA = lote_dureza
            End If


            'a.LOTENITRATO = lote_nitrato
            'a.LOTENITRITO = lote_nitrito
            'a.LOTEDUREZA = lote_dureza
            a.OPERADOR = operador
            a.MEDIOS = 1
            a.MARCA = 0
            If (a.guardar(Usuario)) Then
                m.modificar(Usuario)
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'listaragua()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
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

        Dim a As New dAgua
        Dim a2 As New dAgua2
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        '*****************************
        'idsol = TextBox1.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        '*****************************
        x1hoja.Cells(6, 2).formula = sa.ID
        x1hoja.Cells(6, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(7, 2).formula = pro.NOMBRE
        x1hoja.Cells(7, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 2).Font.Size = 9
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(8, 2).formula = pro.DIRECCION
            x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(8, 2).Font.Size = 9
        Else
            x1hoja.Cells(8, 2).formula = "No aportado"
            x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(8, 2).Font.Size = 9
        End If
        tec.ID = pro.TECNICO
        If tec.ID > 0 Then
            tec = tec.buscar
        End If
        If Not tec.NOMBRE Is Nothing Then
            x1hoja.Cells(9, 2).formula = tec.NOMBRE
        End If
        If tec.NOMBRE = "" Then
            x1hoja.Cells(9, 2).formula = "No aportado"
        End If
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9
        lista = a2.listarporsolicitud2(idsol)
        'x1hoja.Range("H8", "J8").Merge()
        x1hoja.Cells(6, 4).formula = sa.FECHAINGRESO
        x1hoja.Cells(6, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 4).Font.Size = 9
        'x1hoja.Range("H9", "L9").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")

        'x1hoja.Cells(7, 4).formula = a2.FECHAPROCESAMIENTO
        'x1hoja.Cells(7, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(7, 4).Font.Size = 9

        x1hoja.Cells(8, 4).formula = fecha2
        x1hoja.Cells(8, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 4).Font.Size = 9
        x1hoja.Cells(9, 4).formula = pro.DICOSE
        x1hoja.Cells(9, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 4).Font.Size = 9
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

                x1hoja.Shapes.AddPicture("c:\Debug\oua.jpg", _
                 Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 220, 0, 80, 35)




                'x1libro.Worksheets(1).cells(3, 1).select()
                x1hoja.Cells(3, 1).columnwidth = 15
                x1hoja.Cells(3, 2).columnwidth = 27
                x1hoja.Cells(3, 3).columnwidth = 17
                x1hoja.Cells(3, 4).columnwidth = 24
                x1hoja.Range("A1", "D1").Merge()

                'columna = 4
                'x1libro.Worksheets(1).cells(fila, columna).select()
                'x1libro.ActiveSheet.pictures.Insert("c:\Debug\oua.jpg").select()
                'x1libro.Worksheets(1).cells(2, 1).select()
                columna = 2
                'fila = 1
                'columna = 2
                '*****************************************************************************
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                'x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 4
                'x1hoja.Range("B2", "D2").Merge()
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
                x1hoja.Range("B5", "C5").Merge()
                fila = fila + 2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE AGUA"
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
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "DICOSE:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila - 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Técnico:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Datos de la fuente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1

                Dim id As Long = idsol
                Dim a1 As New dAgua
                a1.ID = id
                a1 = a1.buscar()

                Dim tp As New dTipoPozo
                tp.ID = a1.IDTIPOPOZO
                If a1.IDTIPOPOZO <> 0 Then
                    tp = tp.buscar()
                End If

                Dim mue As New dMuestraExtraida
                mue.ID = a1.IDMUESTRAEXTRAIDA
                mue = mue.buscar()

                Dim mfc As New dMuestraFueraCondicion
                mfc.ID = a1.IDMUESTRAFUERACONDICION
                mfc = mfc.buscar()

                Dim at As New dAguaTratada
                at.ID = a1.IDAGUATRATADA
                at = at.buscar()

                Dim ec As New dEstadoConservacion
                ec.ID = a1.IDESTADODECONSERVACION
                ec = ec.buscar()

                Dim textoMO As String
                If a1.MUESTRAOFICIAL = 0 Then
                    textoMO = "No"
                Else
                    textoMO = "Si"
                End If

                x1hoja.Cells(fila, columna).Formula = "Tipo pozo:" & " " & tp.NOMBRE & " / " & "Antiguedad:" & " " & a1.ANTIGUEDAD & " / " & "Distancia pozo negro:" & " " & a1.DISTANCIAPOZONEGRO
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Distancia tambo:" & " " & a1.DISTANCIATAMBO & " / " & "Estado de conservación:" & " " & ec.NOMBRE & " / " & "Muestra extraída de:" & " " & mue.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                If textoMO = "Si" Then
                    x1hoja.Cells(fila, columna).Formula = "Muestra fuera de condición:" & " " & mfc.NOMBRE & " / " & "Profundidad:" & " " & a1.PROFUNDIDAD & " / " & "Agua tratada:" & " " & at.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Muestra oficial M.G.A.P.:" & " " & textoMO
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                Else
                    x1hoja.Cells(fila, columna).Formula = "Muestra fuera de condición:" & " " & mfc.NOMBRE & " / " & "Profundidad:" & " " & a1.PROFUNDIDAD & " / " & "Agua tratada:" & " " & at.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                End If
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).Formula = "Tipo de análisis:"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 9


                fila = fila + 2
                columna = 1

                For Each a2 In lista

                    x1hoja.Cells(7, 4).formula = a2.FECHAPROCESAMIENTO
                    x1hoja.Cells(7, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(7, 4).Font.Size = 9


                    x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 3
                    If sa.TEMPERATURA > 8 Then
                        x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C" & " " & "(Proceso autorizado por cliente)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = "RESULTADO DEL ANÁLISIS"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 3
                    x1hoja.Cells(fila, columna).Formula = a2.IDMUESTRA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "UFC"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Método/Estandar"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "MICROBIOLÓGICO"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Coliformes totales /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.COLIFORMESTOTALES = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESTOTALES = 80 Then
                        x1hoja.Cells(fila, columna).Formula = "> 80"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESTOTALES = 160 Then
                        x1hoja.Cells(fila, columna).Formula = "> 160"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESTOTALES = 800 Then
                        x1hoja.Cells(fila, columna).Formula = "> 800"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.COLIFORMESTOTALES = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.COLIFORMESTOTALES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "* FM/SMWW 9222 B 2005."
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1

                    x1hoja.Cells(fila, columna).Formula = "Coliformes fecales /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.COLIFORMESFECALES = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESFECALES = 60 Then
                        x1hoja.Cells(fila, columna).Formula = "> 60"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESFECALES = 120 Then
                        x1hoja.Cells(fila, columna).Formula = "> 120"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESFECALES = 600 Then
                        x1hoja.Cells(fila, columna).Formula = "> 600"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.COLIFORMESFECALES = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.COLIFORMESFECALES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "* FM/SMWW 9222 D 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    'x1hoja.Cells(fila, columna).Formula = "Pseudomonas spp /100 mL"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    'x1hoja.Cells(fila, columna).Font.Bold = True
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Pseudomona aeruginosa /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.PSEUDOMONASAERUGINOSA = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.PSEUDOMONASAERUGINOSA = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.PSEUDOMONASAERUGINOSA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 943:1994"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    '***********************************************************************
                    x1hoja.Cells(fila, columna).Formula = "Pseudomona spp /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.PSEUDOMONASPP = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.PSEUDOMONASPP = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.PSEUDOMONASPP = 400 Or a2.PSEUDOMONASPP > 400 Then
                        x1hoja.Cells(fila, columna).Formula = "> 400"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.PSEUDOMONASPP
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 943:1994"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    '***********************************************************************
                    x1hoja.Cells(fila, columna).Formula = "Heterotróficos 22ºC /mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.HETEROTROFICOS = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 10"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.HETEROTROFICOS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/SMWW 9215 D 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Heterotróficos 37ºC /mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.HETEROTROFICOS37 = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 10"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS37 = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS37 = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.HETEROTROFICOS37
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 858:1991"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Heterotróficos 35ºC /mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.HETEROTROFICOS35 = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 10"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS35 = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS35 = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.HETEROTROFICOS35
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 858:1991"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "E. coli / 100mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.ECOLI = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.ECOLI = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.ECOLI = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.ECOLI
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/ISO 9308:2000"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Clostridios Sulfito reductores/100ml"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.SULFITOREDUCTORES = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.SULFITOREDUCTORES = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.SULFITOREDUCTORES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "ISO 6461-2"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "ORGANOLÉPTICO"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Aspecto"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim asp As New dAspecto
                    asp.ID = a2.IDASPECTO
                    If asp.ID <> 0 Then
                        asp = asp.buscar
                        If Not asp.NOMBRE Is Nothing Then
                            If asp.ID <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = asp.NOMBRE
                            Else
                                x1hoja.Cells(fila, columna).Formula = "No requerido"
                            End If
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                    End If
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "sensorial"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1

                    x1hoja.Cells(fila, columna).Formula = "Olor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim ol As New dOlor
                    ol.ID = a2.IDOLOR
                    If ol.ID <> 0 Then
                        ol = ol.buscar
                        If Not ol.NOMBRE Is Nothing Then
                            If ol.ID <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                            Else
                                x1hoja.Cells(fila, columna).Formula = "No requerido"
                            End If
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                    End If
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "sensorial"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Color"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim col As New dColor
                    col.ID = a2.IDCOLOR
                    If col.ID <> 0 Then
                        col = col.buscar
                        If Not col.NOMBRE Is Nothing Then
                            If col.ID <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = col.NOMBRE
                            Else
                                x1hoja.Cells(fila, columna).Formula = "No requerido"
                            End If
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                    End If
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "sensorial"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "FÍSICO-QUÍMICO"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "pH"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.PH = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.PH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Potenciométrico/SMWW 4500 H+B 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 7
                    columna = columna - 2
                    fila = fila + 1

                    If a2.NITRATO <> "-1" Then
                        x1hoja.Cells(fila, columna).Formula = "Nitratos como N (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRATO = "-1" Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            x1hoja.Cells(fila, columna).Formula = a2.NITRATO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espectrofoto./Basado en DIN 38405-9"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        columna = columna - 2
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = "Nitratos como N (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRATOTIRAS = 0 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            Dim nt As New dNitrato
                            nt.ID = a2.NITRATOTIRAS
                            nt = nt.buscar
                            Dim valornitrato As Double = nt.VALOR / 4.43
                            x1hoja.Cells(fila, columna).Formula = Math.Round(valornitrato, 2)
                            'x1hoja.Cells(fila, columna).Formula = nt.VALOR
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espectrofoto./Basado en DIN 38405-9"
                        'x1hoja.Cells(fila, columna).Formula = "Colorimétrico"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        columna = columna - 2
                        fila = fila + 1
                    End If
                    If a2.NITRITO <> "-1" Then
                        x1hoja.Cells(fila, columna).Formula = "Nitritos como NO² (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRITO = "-1" Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            x1hoja.Cells(fila, columna).Formula = a2.NITRITO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espect./Basado en SMWW 4500 NO²B 2005"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        columna = columna - 2
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = "Nitritos como NO² (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRITOTIRAS = 0 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            Dim nt2 As New dNitrito
                            nt2.ID = a2.NITRITOTIRAS
                            nt2 = nt2.buscar
                            x1hoja.Cells(fila, columna).Formula = nt2.VALOR
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Tiras"
                        x1hoja.Cells(fila, columna).Formula = "Espect./Basado en SMWW 4500 NO²B 2005"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 6
                        columna = columna - 2
                        fila = fila + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = "Materia orgánica"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.IDMATERIAORGANICA = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        Dim mo As New dMateriaOrganica
                        mo.ID = a2.IDMATERIAORGANICA
                        mo = mo.buscar
                        x1hoja.Cells(fila, columna).Formula = mo.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Colorimétrico"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Conductividad (µS/cm)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.CONDUCTIVIDAD = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.CONDUCTIVIDAD
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Conductímetro/SMWW 2510 B 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Turbiedad (U.N.T.)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.TURBIEDAD = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.TURBIEDAD
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Nefelómetrico/SMWW 2130 B 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    If a2.DUREZA <> "-1" Then
                        x1hoja.Cells(fila, columna).Formula = "Dureza (mg/L CaCO3)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.DUREZA = "-1" Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            x1hoja.Cells(fila, columna).Formula = a2.DUREZA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espectrofotométrico"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = "Dureza (mg/L CaCO3)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.IDDUREZA = 0 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            'columna = columna - 1
                            'fila = fila + 1
                        Else
                            Dim du As New dDureza
                            du.ID = a2.IDDUREZA
                            du = du.buscar
                            x1hoja.Cells(fila, columna).Formula = du.VALOR
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            'columna = columna - 1
                            'fila = fila + 1
                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espectrofotométrico"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = "Cloro libre (ppm)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.CLOROLIBRE = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.CLOROLIBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "DPD/SMWW 4500 Cl F 2b 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Cloro residual(ppm)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.CLORORESIDUAL = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.CLORORESIDUAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "DPD/SMWW 4500 Cl F 2b 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1


                Next
                'Referencias
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "FM: Filtración de Membrana - UFC: Unidades Formadoras de Colonias - (*)Ensayo acreditado ISO 17025 por OUA"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                Dim fila2 As Integer = fila
                Dim columna2 As Integer = columna + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Parámetros Indicadores de calidad para agua potable - Valores Máximos Admitidos - Reglamento Bromatológico Nacional 315/994"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Font.Bold = True
                'fila = fila + 1
                'columna = 1
                'x1hoja.Cells(fila, columna).formula = "Parámetros Microbiológicos: valores máximos admitidos"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).formula = "Parámetros físico-químicos valores máximos admitidos"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "(Reglamento Bromatológico Nacional 315/994)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).formula = "(Reglamento Bromatológico Nacional 315/994)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'fila = fila + 1
                'columna = 1
                x1hoja.Cells(fila, columna).formula = "Coliformes totales: <1/100 mL - Coliformes fecales: <1/100 mL - Nitratos como N: 10 mg/L - Dureza total en CaCo3: 500 mg/L"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Heterotróficos agua potable: ≤ 500 ufc/mL. - Nitritos como NO2: 1,5 mg/L - Heterotróficos agua envasada: ≤ 30 ufc/mL."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Turbiedad: 5 UNT - pH: 6-9 - Pseudomona aeruginosa: < 1/100 mL. - Caracteres sensoriales característicos"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 2
                columna = 1

                '***************************************


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

                Dim ag As New dAgua2
                Dim listamuestras As New ArrayList
                listamuestras = ag.listarporid2(idsol)

                Dim ana As New dAnalisis
                Dim idcompleto As Integer = 87
                Dim idfqcompleto As Integer = 89
                Dim idbacteriologico As Integer = 88
                Dim idfqcondyph As Integer = 90
                Dim idfqcloro As Integer = 91
                Dim idheterotroficos As Integer = 92
                Dim idecoli As Integer = 93
                Dim idsulfitoreductores As Integer = 149
                Dim idtimbre As Integer = 86
                Dim preciocompleto As Double
                Dim preciofqcompleto As Double
                Dim preciobacteriologico As Double
                Dim preciofqcondyph As Double
                Dim preciofqcloro As Double
                Dim precioheterotroficos As Double
                Dim precioecoli As Double
                Dim preciosulfitoreductores As Double
                Dim preciotimbre As Double
                ana.ID = idcompleto
                ana = ana.buscar
                preciocompleto = ana.COSTO
                ana.ID = idfqcompleto
                ana = ana.buscar
                preciofqcompleto = ana.COSTO
                ana.ID = idbacteriologico
                ana = ana.buscar
                preciobacteriologico = ana.COSTO
                ana.ID = idfqcondyph
                ana = ana.buscar
                preciofqcondyph = ana.COSTO
                ana.ID = idfqcloro
                ana = ana.buscar
                preciofqcloro = ana.COSTO
                ana.ID = idheterotroficos
                ana = ana.buscar
                precioheterotroficos = ana.COSTO
                ana.ID = idecoli
                ana = ana.buscar
                precioecoli = ana.COSTO
                ana.ID = idsulfitoreductores
                ana = ana.buscar
                preciosulfitoreductores = ana.COSTO
                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO
                Dim total As Double
                Dim subtipo As Integer
                Dim contadorh As Integer = 0
                Dim contadorcph As Integer = 0
                Dim contadorc As Integer = 0
                Dim muestras As Integer
                muestras = listamuestras.Count
                subtipo = sa.IDSUBINFORME
                If subtipo = 2 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcondyph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    If a1.SULFITOREDUCTORES = 1 Then
                        total = total + preciosulfitoreductores
                    End If
                    total = ((total + preciocompleto) * muestras) + preciotimbre
                End If
                If subtipo = 29 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcondyph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    If a1.SULFITOREDUCTORES = 1 Then
                        total = total + preciosulfitoreductores
                    End If
                    total = ((total + preciofqcompleto) * muestras) + preciotimbre
                End If
                If subtipo = 30 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcondyph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    If a1.SULFITOREDUCTORES = 1 Then
                        total = total + preciosulfitoreductores
                    End If
                    total = ((total + preciobacteriologico) * muestras) + preciotimbre
                End If
                If subtipo = 46 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcondyph
                    End If
                    If a1.CLORO = 1 Then
                        'total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    If a1.SULFITOREDUCTORES = 1 Then
                        total = total + preciosulfitoreductores
                    End If
                    total = ((total + preciofqcloro) * muestras) + preciotimbre
                End If
                If subtipo = 47 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        'total = total + preciofqcondyph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    If a1.SULFITOREDUCTORES = 1 Then
                        total = total + preciosulfitoreductores
                    End If
                    total = ((total + preciofqcondyph) * muestras) + preciotimbre
                End If
                If subtipo = 49 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcondyph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    If a1.SULFITOREDUCTORES = 1 Then
                        total = total + preciosulfitoreductores
                    End If
                    total = ((total) * muestras) + preciotimbre
                End If

                '***********************************************************************************************
                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Técnico:" & " " & ComboOperador.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                x1libro.Worksheets(1).cells(2, 1).select()

                columna = columna + 2
                x1hoja.Cells(fila, columna).formula = "Laboratorio habilitado RNL 0029 - MGAP"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 10
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1

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
        'x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\AGUA\" & idsol & ".xls")
        x1hoja.SaveAs("\\ROBOT\PRE INFORMES\AGUA\" & idsol & ".xls")


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
            pi2.TIPO = 3
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        Dim a As New dAgua
        Dim a2 As New dAgua2
        Dim sa As New dSolicitudAnalisis
        Dim pro As New dProductor
        Dim tec As New dTecnicos
        Dim lista As New ArrayList
        '*****************************
        idsol = TextBox1.Text.Trim
        sa.ID = idsol
        sa = sa.buscar

        '*****************************
        x1hoja.Cells(6, 2).formula = sa.ID
        x1hoja.Cells(6, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 2).Font.Size = 9
        pro.ID = sa.IDPRODUCTOR
        pro = pro.buscar
        x1hoja.Cells(7, 2).formula = pro.NOMBRE
        x1hoja.Cells(7, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(7, 2).Font.Size = 9
        If pro.DIRECCION <> "" Then
            x1hoja.Cells(8, 2).formula = pro.DIRECCION
            x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(8, 2).Font.Size = 9
        Else
            x1hoja.Cells(8, 2).formula = "No aportado"
            x1hoja.Cells(8, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
            x1hoja.Cells(8, 2).Font.Size = 9
        End If
        tec.ID = pro.TECNICO
        If tec.ID > 0 Then
            tec = tec.buscar
        End If
        If Not tec.NOMBRE Is Nothing Then
            x1hoja.Cells(9, 2).formula = tec.NOMBRE
        End If
        If tec.NOMBRE = "" Then
            x1hoja.Cells(9, 2).formula = "No aportado"
        End If
        x1hoja.Cells(9, 2).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 2).Font.Size = 9
        lista = a2.listarporsolicitud2(idsol)
        'x1hoja.Range("H8", "J8").Merge()
        x1hoja.Cells(6, 4).formula = sa.FECHAINGRESO
        x1hoja.Cells(6, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(6, 4).Font.Size = 9
        'x1hoja.Range("H9", "L9").Merge()
        Dim fecha As Date = Now()
        Dim fecha2 As String = fecha.ToString("dd/MM/yyyy")

        'x1hoja.Cells(7, 4).formula = a2.FECHAPROCESAMIENTO
        'x1hoja.Cells(7, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(7, 4).Font.Size = 9

        x1hoja.Cells(8, 4).formula = fecha2
        x1hoja.Cells(8, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(8, 4).Font.Size = 9
        x1hoja.Cells(9, 4).formula = pro.DICOSE
        x1hoja.Cells(9, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(9, 4).Font.Size = 9
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

                x1hoja.Shapes.AddPicture("c:\Debug\oua.jpg", _
                 Microsoft.Office.Core.MsoTriState.msoFalse, _
                Microsoft.Office.Core.MsoTriState.msoCTrue, 220, 0, 80, 35)




                'x1libro.Worksheets(1).cells(3, 1).select()
                x1hoja.Cells(3, 1).columnwidth = 15
                x1hoja.Cells(3, 2).columnwidth = 27
                x1hoja.Cells(3, 3).columnwidth = 17
                x1hoja.Cells(3, 4).columnwidth = 24
                x1hoja.Range("A1", "D1").Merge()

                'columna = 4
                'x1libro.Worksheets(1).cells(fila, columna).select()
                'x1libro.ActiveSheet.pictures.Insert("c:\Debug\oua.jpg").select()
                'x1libro.Worksheets(1).cells(2, 1).select()
                columna = 2
                'fila = 1
                'columna = 2
                '*****************************************************************************
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                'x1hoja.Cells(fila, columna).Formula = "Parque El retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 4
                'x1hoja.Range("B2", "D2").Merge()
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
                x1hoja.Range("B5", "C5").Merge()
                fila = fila + 2
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                x1hoja.Cells(fila, columna).Formula = "INFORME DE AGUA"
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
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "DICOSE:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila - 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Dirección:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Técnico:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                x1hoja.Cells(fila, columna).Formula = "Datos de la fuente:"
                x1hoja.Cells(fila, columna).Font.Bold = True
                x1hoja.Cells(fila, columna).Font.Size = 9
                columna = columna + 1

                Dim id As Long = idsol
                Dim a1 As New dAgua
                a1.ID = id
                a1 = a1.buscar()

                Dim tp As New dTipoPozo
                tp.ID = a1.IDTIPOPOZO
                If a1.IDTIPOPOZO <> 0 Then
                    tp = tp.buscar()
                End If

                Dim mue As New dMuestraExtraida
                mue.ID = a1.IDMUESTRAEXTRAIDA
                mue = mue.buscar()

                Dim mfc As New dMuestraFueraCondicion
                mfc.ID = a1.IDMUESTRAFUERACONDICION
                mfc = mfc.buscar()

                Dim at As New dAguaTratada
                at.ID = a1.IDAGUATRATADA
                at = at.buscar()

                Dim ec As New dEstadoConservacion
                ec.ID = a1.IDESTADODECONSERVACION
                ec = ec.buscar()

                Dim textoMO As String
                If a1.MUESTRAOFICIAL = 0 Then
                    textoMO = "No"
                Else
                    textoMO = "Si"
                End If

                x1hoja.Cells(fila, columna).Formula = "Tipo pozo:" & " " & tp.NOMBRE & " / " & "Antiguedad:" & " " & a1.ANTIGUEDAD & " / " & "Distancia pozo negro:" & " " & a1.DISTANCIAPOZONEGRO
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).Formula = "Distancia tambo:" & " " & a1.DISTANCIATAMBO & " / " & "Estado de conservación:" & " " & ec.NOMBRE & " / " & "Muestra extraída de:" & " " & mue.NOMBRE
                x1hoja.Cells(fila, columna).Font.Bold = False
                x1hoja.Cells(fila, columna).Font.Size = 9
                fila = fila + 1
                If textoMO = "Si" Then
                    x1hoja.Cells(fila, columna).Formula = "Muestra fuera de condición:" & " " & mfc.NOMBRE & " / " & "Profundidad:" & " " & a1.PROFUNDIDAD & " / " & "Agua tratada:" & " " & at.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Muestra oficial M.G.A.P.:" & " " & textoMO
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                Else
                    x1hoja.Cells(fila, columna).Formula = "Muestra fuera de condición:" & " " & mfc.NOMBRE & " / " & "Profundidad:" & " " & a1.PROFUNDIDAD & " / " & "Agua tratada:" & " " & at.NOMBRE
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 9
                End If
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).Formula = "Tipo de análisis:"
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'x1hoja.Cells(fila, columna).Font.Size = 9


                fila = fila + 2
                columna = 1

                For Each a2 In lista

                    x1hoja.Cells(7, 4).formula = a2.FECHAPROCESAMIENTO
                    x1hoja.Cells(7, 4).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(7, 4).Font.Size = 9


                    x1hoja.Cells(fila, columna).Formula = "Temperatura de arribo de la/s muestra/s"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 3
                    If sa.TEMPERATURA > 8 Then
                        x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C" & " " & "(Proceso autorizado por cliente)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = sa.TEMPERATURA & " " & "°C"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = 1
                        fila = fila + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = "RESULTADO DEL ANÁLISIS"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 3
                    x1hoja.Cells(fila, columna).Formula = a2.IDMUESTRA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "UFC"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Método/Estandar"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "MICROBIOLÓGICO"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Coliformes totales /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.COLIFORMESTOTALES = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESTOTALES = 80 Then
                        x1hoja.Cells(fila, columna).Formula = "> 80"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESTOTALES = 160 Then
                        x1hoja.Cells(fila, columna).Formula = "> 160"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESTOTALES = 800 Then
                        x1hoja.Cells(fila, columna).Formula = "> 800"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.COLIFORMESTOTALES = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.COLIFORMESTOTALES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "* FM/SMWW 9222 B 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1

                    x1hoja.Cells(fila, columna).Formula = "Coliformes fecales /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.COLIFORMESFECALES = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESFECALES = 60 Then
                        x1hoja.Cells(fila, columna).Formula = "> 60"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESFECALES = 120 Then
                        x1hoja.Cells(fila, columna).Formula = "> 120"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.COLIFORMESFECALES = 600 Then
                        x1hoja.Cells(fila, columna).Formula = "> 600"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.COLIFORMESFECALES = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.COLIFORMESFECALES
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "* FM/SMWW 9222 D 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    'x1hoja.Cells(fila, columna).Formula = "Pseudomonas spp /100 mL"
                    'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    'x1hoja.Cells(fila, columna).Font.Bold = True
                    'x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    'x1hoja.Cells(fila, columna).Font.Size = 8
                    'fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Pseudomona aeruginosa /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.PSEUDOMONASAERUGINOSA = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.PSEUDOMONASAERUGINOSA = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.PSEUDOMONASAERUGINOSA
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 943:1994"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    '***********************************************************************
                    x1hoja.Cells(fila, columna).Formula = "Pseudomona spp /100 mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.PSEUDOMONASPP = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.PSEUDOMONASPP = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    ElseIf a2.PSEUDOMONASPP = 400 Or a2.PSEUDOMONASPP > 400 Then
                        x1hoja.Cells(fila, columna).Formula = "> 400"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.PSEUDOMONASPP
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 943:1994"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    '***********************************************************************
                    x1hoja.Cells(fila, columna).Formula = "Heterotróficos 22ºC /mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.HETEROTROFICOS = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 10"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.HETEROTROFICOS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/SMWW 9215 D 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Heterotróficos 37ºC /mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.HETEROTROFICOS37 = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 10"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS37 = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS37 = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.HETEROTROFICOS37
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 858:1991"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Heterotróficos 35ºC /mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.HETEROTROFICOS35 = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 10"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS35 = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.HETEROTROFICOS35 = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.HETEROTROFICOS35
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/UNIT 858:1991"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "E. coli / 100mL"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.ECOLI = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "< 1"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.ECOLI = 2000 Then
                        x1hoja.Cells(fila, columna).Formula = "> 2000"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    ElseIf a2.ECOLI = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.ECOLI
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "FM/ISO 9308:2000"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "ORGANOLÉPTICO"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Aspecto"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim asp As New dAspecto
                    asp.ID = a2.IDASPECTO
                    If asp.ID <> 0 Then
                        asp = asp.buscar
                        If Not asp.NOMBRE Is Nothing Then
                            If asp.ID <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = asp.NOMBRE
                            Else
                                x1hoja.Cells(fila, columna).Formula = "No requerido"
                            End If
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                    End If
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "sensorial"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1

                    x1hoja.Cells(fila, columna).Formula = "Olor"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim ol As New dOlor
                    ol.ID = a2.IDOLOR
                    If ol.ID <> 0 Then
                        ol = ol.buscar
                        If Not ol.NOMBRE Is Nothing Then
                            If ol.ID <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = ol.NOMBRE
                            Else
                                x1hoja.Cells(fila, columna).Formula = "No requerido"
                            End If
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                    End If
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "sensorial"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Color"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    Dim col As New dColor
                    col.ID = a2.IDCOLOR
                    If col.ID <> 0 Then
                        col = col.buscar
                        If Not col.NOMBRE Is Nothing Then
                            If col.ID <> -1 Then
                                x1hoja.Cells(fila, columna).Formula = col.NOMBRE
                            Else
                                x1hoja.Cells(fila, columna).Formula = "No requerido"
                            End If
                        End If
                    Else
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                    End If
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "sensorial"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = 1
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "FÍSICO-QUÍMICO"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "pH"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.PH = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.PH
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Potenciométrico/SMWW 4500 H+B 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1

                    If a2.NITRATO <> -1 Then
                        x1hoja.Cells(fila, columna).Formula = "Nitratos como N (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRATO = -1 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            x1hoja.Cells(fila, columna).Formula = a2.NITRATO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espectrofoto./DIN 38405-9"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = "Nitratos como N (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRATOTIRAS = 0 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            Dim nt As New dNitrato
                            nt.ID = a2.NITRATOTIRAS
                            nt = nt.buscar
                            Dim valornitrato As Double = nt.VALOR / 4.43
                            x1hoja.Cells(fila, columna).Formula = Math.Round(valornitrato, 2)
                            'x1hoja.Cells(fila, columna).Formula = nt.VALOR
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Tiras"
                        x1hoja.Cells(fila, columna).Formula = "Espectrofoto./DIN 38405-9"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    End If
                    If a2.NITRITO <> -1 Then
                        x1hoja.Cells(fila, columna).Formula = "Nitritos como NO2 (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRITO = -1 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            x1hoja.Cells(fila, columna).Formula = a2.NITRITO
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espect./SMWW 4500 NO2B 2005"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = "Nitritos como NO2 (mg/L)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.NITRITOTIRAS = 0 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            Dim nt2 As New dNitrito
                            nt2.ID = a2.NITRITOTIRAS
                            nt2 = nt2.buscar
                            x1hoja.Cells(fila, columna).Formula = nt2.VALOR
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        'x1hoja.Cells(fila, columna).Formula = "Tiras"
                        x1hoja.Cells(fila, columna).Formula = "Espect./SMWW 4500 NO2B 2005"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = "Materia orgánica"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.IDMATERIAORGANICA = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        Dim mo As New dMateriaOrganica
                        mo.ID = a2.IDMATERIAORGANICA
                        mo = mo.buscar
                        x1hoja.Cells(fila, columna).Formula = mo.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Colorimétrico"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Conductividad (uS/cm)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.CONDUCTIVIDAD = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.CONDUCTIVIDAD
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Conduct./SMWW 2510 B 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Turbiedad (U.N.T.)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.TURBIEDAD = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.TURBIEDAD
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8

                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "Nefelómet./SMWW 2130 B 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    If a2.DUREZA <> -1 Then
                        x1hoja.Cells(fila, columna).Formula = "Dureza (mg/L CaCO3)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.DUREZA = -1 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        Else
                            x1hoja.Cells(fila, columna).Formula = a2.DUREZA
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8

                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espectrofotométrico"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = "Dureza (mg/L CaCO3)"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = True
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna + 1
                        If a2.IDDUREZA = 0 Then
                            x1hoja.Cells(fila, columna).Formula = "No requerido"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            'columna = columna - 1
                            'fila = fila + 1
                        Else
                            Dim du As New dDureza
                            du.ID = a2.IDDUREZA
                            du = du.buscar
                            x1hoja.Cells(fila, columna).Formula = du.VALOR
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                            x1hoja.Cells(fila, columna).Font.Size = 8
                            'columna = columna - 1
                            'fila = fila + 1
                        End If
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = "Espectrofotométrico"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        columna = columna - 2
                        fila = fila + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = "Cloro libre (ppm)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.CLOROLIBRE = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.CLOROLIBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "DPD/SMWW 4500 Cl F 2b 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1
                    x1hoja.Cells(fila, columna).Formula = "Cloro residual(ppm)"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = True
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna + 1
                    If a2.CLORORESIDUAL = -1 Then
                        x1hoja.Cells(fila, columna).Formula = "No requerido"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = a2.CLORORESIDUAL
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Size = 8
                        'columna = columna - 1
                        'fila = fila + 1
                    End If
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).Formula = "DPD/SMWW 4500 Cl F 2b 2005"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 8
                    columna = columna - 2
                    fila = fila + 1


                Next
                'Referencias
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "FM: Filtración de Membrana - UFC: Unidades Formadoras de Colonias - (*)Ensayo acreditado ISO 17025 por OUA"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1
                Dim fila2 As Integer = fila
                Dim columna2 As Integer = columna + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Parámetros Indicadores de calidad para agua potable - Valores Máximos Admitidos - Reglamento Bromatológico Nacional 315/994"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 7
                x1hoja.Cells(fila, columna).Font.Bold = True
                'fila = fila + 1
                'columna = 1
                'x1hoja.Cells(fila, columna).formula = "Parámetros Microbiológicos: valores máximos admitidos"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).formula = "Parámetros físico-químicos valores máximos admitidos"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                'x1hoja.Cells(fila, columna).formula = "(Reglamento Bromatológico Nacional 315/994)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'columna = columna + 2
                'x1hoja.Cells(fila, columna).formula = "(Reglamento Bromatológico Nacional 315/994)"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = True
                'fila = fila + 1
                'columna = 1
                x1hoja.Cells(fila, columna).formula = "Coliformes totales: <1/100 mL - Coliformes fecales: <1/100 mL"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 2
                x1hoja.Cells(fila, columna).formula = "Nitratos como N: 10 mg/L - Dureza total en CaCo3: 500 mg/L"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Heterotróficos agua potable: ≤ 500 ufc/mL."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 2
                'x1hoja.Cells(fila, columna).formula = "Coliformes fecales: <1/100 mL"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'columna = columna + 2
                x1hoja.Cells(fila, columna).formula = "Nitritos como NO2: 1,5 mg/L"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Heterotróficos agua envasada: ≤ 30 ufc/mL."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 2
                x1hoja.Cells(fila, columna).formula = "Turbiedad: 5 UNT - pH: 6-9"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1
                columna = 1
                'columna = 1
                'x1hoja.Cells(fila, columna).formula = "Materia orgánica: ausencia - Color: incolora"
                'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                'x1hoja.Cells(fila, columna).Font.Size = 6
                'x1hoja.Cells(fila, columna).Font.Bold = False
                'fila = fila + 1
                columna = 1
                x1hoja.Cells(fila, columna).formula = "Pseudomona aeruginosa: < 1/100 mL."
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                columna = columna + 2
                x1hoja.Cells(fila, columna).formula = "Caracteres sensoriales característicos"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 6
                x1hoja.Cells(fila, columna).Font.Bold = False
                fila = fila + 1

                '***************************************



                'fila = fila + 1
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

                Dim ag As New dAgua2
                Dim listamuestras As New ArrayList
                listamuestras = ag.listarporid2(idsol)

                Dim ana As New dAnalisis
                Dim idcompleto As Integer = 87
                Dim idfqcompleto As Integer = 89
                Dim idbacteriologico As Integer = 88
                Dim idfqcond As Integer = 90
                Dim idph As Integer = 150
                Dim idfqcloro As Integer = 91
                Dim idheterotroficos As Integer = 92
                Dim idecoli As Integer = 93
                Dim idtimbre As Integer = 86
                Dim preciocompleto As Double
                Dim preciofqcompleto As Double
                Dim preciobacteriologico As Double
                Dim preciofqcond As Double
                Dim precioph As Double
                Dim preciofqcloro As Double
                Dim precioheterotroficos As Double
                Dim precioecoli As Double
                Dim preciotimbre As Double
                ana.ID = idcompleto
                ana = ana.buscar
                preciocompleto = ana.COSTO
                ana.ID = idfqcompleto
                ana = ana.buscar
                preciofqcompleto = ana.COSTO
                ana.ID = idbacteriologico
                ana = ana.buscar
                preciobacteriologico = ana.COSTO
                ana.ID = idfqcond
                ana = ana.buscar
                preciofqcond = ana.COSTO
                ana.ID = idph
                ana = ana.buscar
                precioph = ana.COSTO
                ana.ID = idfqcloro
                ana = ana.buscar
                preciofqcloro = ana.COSTO
                ana.ID = idheterotroficos
                ana = ana.buscar
                precioheterotroficos = ana.COSTO
                ana.ID = idecoli
                ana = ana.buscar
                precioecoli = ana.COSTO
                ana.ID = idtimbre
                ana = ana.buscar
                preciotimbre = ana.COSTO
                Dim total As Double
                Dim subtipo As Integer
                Dim contadorh As Integer = 0
                Dim contadorcph As Integer = 0
                Dim contadorc As Integer = 0
                Dim muestras As Integer
                muestras = listamuestras.Count
                subtipo = sa.IDSUBINFORME
                If subtipo = 2 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcond
                        total = total + precioph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    total = ((total + preciocompleto) * muestras) + preciotimbre
                End If
                If subtipo = 29 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcond
                        total = total + precioph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    total = ((total + preciofqcompleto) * muestras) + preciotimbre
                End If
                If subtipo = 30 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcond
                        total = total + precioph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    total = ((total + preciobacteriologico) * muestras) + preciotimbre
                End If
                If subtipo = 46 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcond
                        total = total + precioph
                    End If
                    If a1.CLORO = 1 Then
                        'total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    total = ((total + preciofqcloro) * muestras) + preciotimbre
                End If
                If subtipo = 47 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        'total = total + preciofqcondyph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    total = ((total + preciofqcond + precioph) * muestras) + preciotimbre
                End If
                If subtipo = 49 Then
                    If a1.HET22 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET35 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.HET37 = 1 Then
                        total = total + precioheterotroficos
                    End If
                    If a1.CONDYPH = 1 Then
                        total = total + preciofqcond
                        total = total + precioph
                    End If
                    If a1.CLORO = 1 Then
                        total = total + preciofqcloro
                    End If
                    If a1.ECOLI = 1 Then
                        total = total + precioecoli
                    End If
                    total = ((total) * muestras) + preciotimbre
                End If

                '***********************************************************************************************
                'x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total & " (Timbre incluído)"
                x1hoja.Cells(fila, columna).formula = "Por concepto de análisis: $" & " " & total
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = columna + 3
                x1hoja.Cells(fila, columna).formula = "Técnico resp.:" & " " & ComboOperador.Text
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                columna = 1
                fila = fila + 1
                x1hoja.Cells(fila, columna).formula = "Este precio incluye IVA y timbre CJPPU"
                x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                x1hoja.Cells(fila, columna).Font.Size = 8
                x1hoja.Cells(fila, columna).Font.Bold = True
                fila = fila + 1

                x1libro.Worksheets(1).cells(fila, columna).select()
                x1libro.ActiveSheet.pictures.Insert("c:\Debug\dario.jpg").select()
                x1libro.Worksheets(1).cells(fila, columna).select()

              

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
        x1hoja.SaveAs("\\SRVCOLAVECO\D\NET\AGUA\" & idsol & ".xls")

        'x1hoja.Protect(Password:="pepo", DrawingObjects:=True, _
        'Contents:=True, Scenarios:=True)
        'x1hoja.SaveAs("C:\" & idsol & ".xls")

        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub

    Public Sub deshabilitarcontroles()
        TextColiformesTotales.Enabled = False
        TextColiformesFecales.Enabled = False
        TextPseudomonasA.Enabled = False
        TextPseudomonaSPP.Enabled = False
        TextNitrato.Enabled = False
        ComboNitrato.Enabled = False
        TextNitrito.Enabled = False
        ComboNitrito.Enabled = False
        ComboMateriaOrganica.Enabled = False
        TextTurbiedad.Enabled = False
        TextDureza.Enabled = False
        ComboDureza.Enabled = False
        TextEcoli.Enabled = False
        TextSulfitoReductores.Enabled = False
        TextHeterotroficos22.Enabled = False
        TextHeterotroficos35.Enabled = False
        TextHeterotroficos37.Enabled = False
        TextCloroLibre.Enabled = False
        TextCloroResidual.Enabled = False
        TextConductividad.Enabled = False
        TextPH.Enabled = False
        ComboAspecto.Enabled = False
        ComboOlor.Enabled = False
        ComboColor.Enabled = False
    End Sub
    Public Sub habilitamicrobiologico()
        TextColiformesTotales.Enabled = True
        TextColiformesFecales.Enabled = True
        TextPseudomonasA.Enabled = True
        TextPseudomonaSPP.Enabled = True
    End Sub
    Public Sub habilitafisicoquimico()
        TextNitrato.Enabled = True
        ComboNitrato.Enabled = True
        TextNitrito.Enabled = True
        ComboNitrito.Enabled = True
        ComboMateriaOrganica.Enabled = True
        TextTurbiedad.Enabled = True
        TextDureza.Enabled = True
        ComboDureza.Enabled = True
        ComboAspecto.Enabled = True
        ComboOlor.Enabled = True
        ComboColor.Enabled = True
        TextPH.Enabled = True
    End Sub
    Public Sub habilitacloro()
        TextCloroLibre.Enabled = True
        TextCloroResidual.Enabled = True
    End Sub
    Public Sub habilitacondyph()
        TextConductividad.Enabled = True
        TextPH.Enabled = True
    End Sub
    Public Sub habilitaecoli()
        TextEcoli.Enabled = True
    End Sub
    Public Sub habilitasulfitoreductores()
        TextSulfitoReductores.Enabled = True
    End Sub
    Public Sub habilitaheterotroficos()
        TextHeterotroficos22.Enabled = True
        TextHeterotroficos35.Enabled = True
        TextHeterotroficos37.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerarInforme.Click
        guardar()
        If ListFichas.SelectedItems.Count = 1 Then
            Dim a As dAgua2 = CType(ListFichas.SelectedItem, dAgua2)
            Dim id As Long = a.IDSOLICITUD
            Dim lista As New ArrayList
            lista = a.listarporid(id)
            'ListMuestras.Items.Clear()
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each a In lista
                        Dim fechaemision As Date = Now()
                        Dim fechaemi As String
                        fechaemi = Format(fechaemision, "yyyy-MM-dd")
                        a.MARCA = 1
                        a.FECHAEMISION = fechaemi
                        'a.FECHAPROCESAMIENTO = fechaemi
                        If (a.modificar2(Usuario)) Then
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    Next
                End If
            End If
            listaragua()
            If ListMuestras.Items.Count = 0 Then
                creainformeexcel()
                listarfichas()
            End If
        End If
    End Sub
End Class