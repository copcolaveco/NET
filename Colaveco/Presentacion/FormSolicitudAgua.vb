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
        'Dim idsolicitud As Long = TextIdSolicitud.Text.Trim
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
        Dim condyph As Integer
        Dim ecoli As Integer
        Dim muestraoficial As Integer
        Dim sulfitoreductores As Integer
        If CheckMuestraOficial.Checked = True Then
            muestraoficial = 1
        Else
            muestraoficial = 0
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
        If CheckCondyPH.Checked = True Then
            condyph = 1
        Else
            condyph = 0
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

        Dim a As New dAgua
        a.IDSOLICITUD = idsol
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
        a.CONDYPH = condyph
        a.ECOLI = ecoli
        a.SULFITOREDUCTORES = sulfitoreductores
        If (a.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        Me.Close()

    End Sub
    
End Class