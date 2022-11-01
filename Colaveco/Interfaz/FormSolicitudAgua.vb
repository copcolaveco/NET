Public Class FormSolicitudAgua
    Private _usuario As dUsuario
    Dim idsol As Long
    Dim fechasol As Date

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As Long, ByVal fecha As Date)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarComboAguaTratada()
        cargarComboEstadoConservacion()
        cargarComboMuestraExtraida()
        cargarComboMuestraFueraCondicion()
        cargarComboTipoPozo()
        'listarultimoid()
        TextPrecinto.Enabled = False
        idsol = solicitud
        fechasol = fecha
    End Sub
#End Region
    Public Sub cargarComboTipoPozo()
        Dim tp As New dTipoPozo
        Dim lista As New ArrayList
        lista = tp.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each tp In lista
                    ComboIdTipoPozo.Items.Add(tp)
                Next
            End If
        End If
    End Sub
   
    Public Sub cargarComboEstadoConservacion()
        Dim ec As New dEstadoConservacion
        Dim lista As New ArrayList
        lista = ec.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ec In lista
                    ComboIdEstConsevacion.Items.Add(ec)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMuestraExtraida()
        Dim mue As New dMuestraExtraida
        Dim lista As New ArrayList
        lista = mue.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each mue In lista
                    ComboIdMuestraExtraida.Items.Add(mue)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboMuestraFueraCondicion()
        Dim mfc As New dMuestraFueraCondicion
        Dim lista As New ArrayList
        lista = mfc.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each mfc In lista
                    ComboIdMuestFueraCondicion.Items.Add(mfc)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboAguaTratada()
        Dim at As New dAguaTratada
        Dim lista As New ArrayList
        lista = at.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each at In lista
                    ComboIdAguaTratada.Items.Add(at)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        'Dim ficha As Long = Textficha.Text.Trim
        Dim fecsol As String
        fecsol = Format(fechasol, "yyyy-MM-dd")
        Dim idtipopozo As dTipoPozo = CType(ComboIdTipoPozo.SelectedItem, dTipoPozo)
        Dim antiguedad As Double
        If TextAntiguedad.Text <> "" Then
            antiguedad = TextAntiguedad.Text.Trim
        Else
            antiguedad = -1
        End If
        Dim distanciapozonegro As Double
        If TextDistPozoNegro.Text <> "" Then
            distanciapozonegro = TextDistPozoNegro.Text.Trim
        Else
            distanciapozonegro = -1
        End If
        Dim distanciatambo As Double
        If TextDistTambo.Text <> "" Then
            distanciatambo = TextDistTambo.Text.Trim
        Else
            distanciatambo = -1
        End If
        Dim envasada As Integer = 0
        Dim idmuestraextraida As dMuestraExtraida = CType(ComboIdMuestraExtraida.SelectedItem, dMuestraExtraida)
        Dim idmuestrafueracondicion As dMuestraFueraCondicion = CType(ComboIdMuestFueraCondicion.SelectedItem, dMuestraFueraCondicion)
        Dim profundidad As Integer
        If TextProfundidad.Text <> "" Then
            profundidad = TextProfundidad.Text.Trim
        Else
            profundidad = -1
        End If
        aguaclorada = 0
        Dim idaguatratada As dAguaTratada = CType(ComboIdAguaTratada.SelectedItem, dAguaTratada)
        If Not idaguatratada Is Nothing Then
            If idaguatratada.ID = 1 Then
                aguaclorada = 1
            End If
        End If
        Dim idestadoconservacion As dEstadoConservacion = CType(ComboIdEstConsevacion.SelectedItem, dEstadoConservacion)
        Dim het22 As Integer
        Dim het35 As Integer
        Dim het37 As Integer
        Dim cloro As Integer
        Dim conductividad As Integer
        Dim ph As Integer
        Dim ecoli As Integer
        Dim muestraoficial As Integer
        Dim precinto As String = ""
        Dim sulfitoreductores As Integer
        Dim enterococos As Integer
        Dim estreptococos As Integer
        'EFLUENTES ********************************
        Dim efluentes As Integer = 0
        Dim paqmacro As Integer
        Dim ca As Integer
        Dim mg As Integer
        Dim na As Integer
        Dim fe As Integer
        Dim k As Integer
        Dim al As Integer
        Dim cd As Integer
        Dim cr As Integer
        Dim cu As Integer
        Dim pb As Integer
        Dim mn As Integer
        Dim fem As Integer
        Dim zn As Integer
        Dim se As Integer
        Dim alcalinidad As Integer
        Dim refrendacion_tambo As Integer
        '********************************************
        If CheckMuestraOficial.Checked = True Then
            muestraoficial = 1
        Else
            muestraoficial = 0
        End If
        If TextPrecinto.Text <> "" Then
            precinto = TextPrecinto.Text.Trim
        End If
        If CheckHeterotroficos22.Checked = True Then
            het22 = 1
        Else
            het22 = 0
        End If
        If CheckHeterotroficos35.Checked = True Then
            het35 = 1
        Else
            het35 = 0
        End If
        If CheckHeterotroficos37.Checked = True Then
            het37 = 1
        Else
            het37 = 0
        End If
        If CheckCloro.Checked = True Then
            cloro = 1
        Else
            cloro = 0
        End If
        If CheckConductividad.Checked = True Then
            conductividad = 1
        Else
            conductividad = 0
        End If
        If CheckpH.Checked = True Then
            ph = 1
        Else
            ph = 0
        End If
        If CheckEcoli.Checked = True Then
            ecoli = 1
        Else
            ecoli = 0
        End If
        If CheckSulfitoReductores.Checked = True Then
            sulfitoreductores = 1
        Else
            sulfitoreductores = 0
        End If
        If CheckEnterococos.Checked = True Then
            enterococos = 1
        Else
            enterococos = 0
        End If
        If CheckEstreptococos.Checked = True Then
            estreptococos = 1
        Else
            estreptococos = 0
        End If
        If CheckPaqMacro.Checked = True Then
            paqmacro = 1
            efluentes = 1
        Else
            paqmacro = 0
        End If
        If CheckCa.Checked = True Then
            ca = 1
            efluentes = 1
        Else
            ca = 0
        End If
        If CheckMg.Checked = True Then
            mg = 1
            efluentes = 1
        Else
            mg = 0
        End If
        If CheckNa.Checked = True Then
            na = 1
            efluentes = 1
        Else
            na = 0
        End If
        If CheckFe.Checked = True Then
            fe = 1
            efluentes = 1
        Else
            fe = 0
        End If
        If CheckK.Checked = True Then
            k = 1
            efluentes = 1
        Else
            k = 0
        End If
        If CheckAl.Checked = True Then
            al = 1
            efluentes = 1
        Else
            al = 0
        End If
        If CheckCd.Checked = True Then
            cd = 1
            efluentes = 1
        Else
            cd = 0
        End If
        If CheckCr.Checked = True Then
            cr = 1
            efluentes = 1
        Else
            cr = 0
        End If
        If CheckCu.Checked = True Then
            cu = 1
            efluentes = 1
        Else
            cu = 0
        End If
        If CheckPb.Checked = True Then
            pb = 1
            efluentes = 1
        Else
            pb = 0
        End If
        If CheckMn.Checked = True Then
            mn = 1
            efluentes = 1
        Else
            mn = 0
        End If
        If CheckFem.Checked = True Then
            fem = 1
            efluentes = 1
        Else
            fem = 0
        End If
        If CheckZn.Checked = True Then
            zn = 1
            efluentes = 1
        Else
            zn = 0
        End If
        If CheckSe.Checked = True Then
            se = 1
            efluentes = 1
        Else
            se = 0
        End If
        If CheckAlcalinidad.Checked = True Then
            alcalinidad = 1
            efluentes = 1
        Else
            alcalinidad = 0
        End If
        If cbxRefrendacionTambo.Checked = True Then
            refrendacion_tambo = 1
        Else
            refrendacion_tambo = 0
        End If
        Dim a As New dAgua
        Dim a3 As New dAgua3
        a.FICHA = idsol
        a.FECHAENTRADA = fecsol
        If Not idtipopozo Is Nothing Then
            a.IDTIPOPOZO = idtipopozo.ID
        End If
        If antiguedad > 0 Then
            a.ANTIGUEDAD = antiguedad
        End If
        If distanciapozonegro > 0 Then
            a.DISTANCIAPOZONEGRO = distanciapozonegro
        End If
        If distanciatambo > 0 Then
            a.DISTANCIATAMBO = distanciatambo
        End If
        If CheckEnvasada.Checked = True Then
            envasada = 1
        Else
            envasada = 0
        End If
        a.ENVASADA = envasada
        If Not idmuestraextraida Is Nothing Then
            a.IDMUESTRAEXTRAIDA = idmuestraextraida.ID
        End If
        If Not idmuestrafueracondicion Is Nothing Then
            a.IDMUESTRAFUERACONDICION = idmuestrafueracondicion.ID
        End If
        If profundidad > 0 Then
            a.PROFUNDIDAD = profundidad
        End If
        If Not idaguatratada Is Nothing Then
            a.IDAGUATRATADA = idaguatratada.ID
        End If
        If Not idestadoconservacion Is Nothing Then
            a.IDESTADODECONSERVACION = idestadoconservacion.ID
        End If
        a.HET22 = het22
        a.HET35 = het35
        a.HET37 = het37
        a.CLORO = cloro
        a.CONDUCTIVIDAD = conductividad
        a.PH = ph
        a.ECOLI = ecoli
        a.SULFITOREDUCTORES = sulfitoreductores
        a.ENTEROCOCOS = enterococos
        a.ESTREPTOCOCOS = estreptococos
        a.MUESTRAOFICIAL = muestraoficial
        a.PRECINTO = precinto
        a.PAQMACRO = paqmacro
        a.CA = ca
        a.MG = mg
        a.NA = na
        a.FE = fe
        a.K = k
        a.AL = al
        a.CD = cd
        a.CR = cr
        a.CU = cu
        a.PB = pb
        a.MN = mn
        a.FEM = fem
        a.ZN = zn
        a.SE = se
        a.ALCALINIDAD = alcalinidad
        a.REFRENDACION_TAMBO = refrendacion_tambo
        If (a.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        Me.Close()

    End Sub
    
    Private Sub CheckMuestraOficial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMuestraOficial.CheckedChanged
        If CheckMuestraOficial.Checked = True Then
            TextPrecinto.Enabled = True
        Else
            TextPrecinto.Enabled = False
        End If
    End Sub

    Private Sub CheckPaqMacro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPaqMacro.CheckedChanged
        seleccionamacro()
    End Sub
    Private Sub seleccionamacro()
        If CheckPaqMacro.Checked = True Then
            CheckCa.Checked = True
            CheckMg.Checked = True
            CheckNa.Checked = True
            CheckFe.Checked = True
            CheckK.Checked = True
        Else
            CheckCa.Checked = False
            CheckMg.Checked = False
            CheckNa.Checked = False
            CheckFe.Checked = False
            CheckK.Checked = False
        End If
    End Sub
End Class