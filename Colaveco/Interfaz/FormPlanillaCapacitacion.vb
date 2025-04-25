Public Class FormPlanillaCapacitacion
    Dim tc As Integer
    Dim fun As Integer
    Dim des As Date
    Dim has As Date
    Dim hor As String
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal tipocap As Integer, ByVal func As Integer, ByVal fechad As Date, ByVal fechah As Date, ByVal hora As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarfuncionarios()
        cargarevaluacion()
        listartipo()
        TextIdLin.Text = idlincapacitacion
        tc = tipocap
        fun = func
        des = fechad
        has = fechah
        hor = hora
        versiexiste()
    End Sub

#End Region
    Private Sub cargarfuncionarios()
        Dim p As New dUsuario
        Dim lista As New ArrayList
        lista = p.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ComboParticipante.Items.Add(p)
                Next
            End If
        End If
    End Sub
    Private Sub listartipo()
        Dim t As New dCapacitacionTipo
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTipoActividad.Items.Add(t)
                Next
            End If
        End If
    End Sub
    Public Sub cargarevaluacion()
        Dim e As New dCapacitacionEv
        Dim lista As New ArrayList
        lista = e.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each e In lista
                    ComboEvaluacionDir.Items.Add(e)
                Next
            End If
        End If
    End Sub
    Private Sub versiexiste()
        If idlincapacitacion > 0 Then
            Dim p As New dPlanillaCapacitacion
            Dim f As New dUsuario
            Dim t As New dCapacitacionTipo
            Dim ev As New dCapacitacionEv
            p.IDLIN = idlincapacitacion
            p = p.buscarxcapacitacion
            If Not p Is Nothing Then
                TextId.Text = p.ID
                TextIdLin.Text = p.IDLIN
                ComboParticipante.SelectedItem = Nothing
                For Each f In ComboParticipante.Items
                    If f.ID = p.PARTICIPANTE Then
                        ComboParticipante.SelectedItem = f
                        Exit For
                    End If
                Next
                ComboTipoActividad.SelectedItem = Nothing
                For Each t In ComboTipoActividad.Items
                    If t.ID = p.TIPOACTIVIDAD Then
                        ComboTipoActividad.SelectedItem = t
                        Exit For
                    End If
                Next
                TextInstructor.Text = p.INSTRUCTOR
                DateInicio.Value = p.FECHAINICIO
                DateFin.Value = p.FECHAFIN
                TextLocal.Text = p.LOCAL
                TextHoras.Text = p.HORAS
                TextCosto.Text = p.COSTO
                If p.AUTORIZACION = 1 Then
                    ComboAutorizacion.Text = "Si"
                Else
                    ComboAutorizacion.Text = "No"
                End If
                DateAutorizacion.Value = p.FECHAAUTORIZACION
                ComboB1.Text = p.B1
                ComboB2.Text = p.B2
                If p.B3 = 1 Then
                    ComboB3.Text = "Si"
                Else
                    ComboB3.Text = "No"
                End If
                TextRecomendar.Text = p.RECOMENDAR
                TextComentarios.Text = p.COMENTARIOS
                ComboEvaluacionDir.SelectedItem = Nothing
                For Each ev In ComboEvaluacionDir.Items
                    If ev.ID = p.EVALUACIONDIR Then
                        ComboEvaluacionDir.SelectedItem = ev
                        Exit For
                    End If
                Next
                CbxEvaluacion.Text = p.EVALUACION
                '    TextDevolucion.Text = p.DEVOLUCION
                '    TextMejora.Text = p.MEJORA
                '    TextRepercusion.Text = p.REPERCUSION
                '    TextComentariosDir.Text = p.COMENTARIOSDIR
            Else
                'Dim f As New dUsuario
                'Dim t As New dCapacitacionTipo
                t.ID = tc
                t = t.buscar
                If Not t Is Nothing Then
                    ComboTipoActividad.Text = t.NOMBRE
                End If
                f.ID = fun
                f = f.buscar
                If Not f Is Nothing Then
                    ComboParticipante.Text = f.NOMBRE
                End If
                DateInicio.Value = des
                DateFin.Value = has
                TextHoras.Text = hor
            End If

            
        End If
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextIdLin.Text = ""
        ComboParticipante.Text = ""
        ComboTipoActividad.Text = ""
        TextInstructor.Text = ""
        DateInicio.Value = Now
        DateFin.Value = Now
        TextLocal.Text = ""
        TextHoras.Text = ""
        TextCosto.Text = ""
        ComboAutorizacion.Text = ""
        DateAutorizacion.Value = Now
        ComboB1.Text = ""
        ComboB2.Text = ""
        ComboB3.Text = ""
        TextRecomendar.Text = ""
        TextComentarios.Text = ""
        ComboEvaluacionDir.Text = ""
        'TextComentariosDir.Text = ""
        ComboParticipante.Focus()
    End Sub
    Private Sub guardar()
        Dim idlin As Long = TextIdLin.Text.Trim
        If ComboParticipante.Text.Trim.Length = 0 Then MsgBox("Debe ingresar un participante", MsgBoxStyle.Exclamation, "Atención") : ComboParticipante.Focus() : Exit Sub
        Dim participante As dUsuario = CType(ComboParticipante.SelectedItem, dUsuario)
        If ComboTipoActividad.Text.Trim.Length = 0 Then MsgBox("Debe ingresar una actividad", MsgBoxStyle.Exclamation, "Atención") : ComboTipoActividad.Focus() : Exit Sub
        Dim tipoactividad As dCapacitacionTipo = CType(ComboTipoActividad.SelectedItem, dCapacitacionTipo)
        Dim instructor As String = ""
        If TextInstructor.Text <> "" Then
            instructor = TextInstructor.Text.Trim
        End If
        Dim fechainicio As Date = DateInicio.Value.ToString("yyyy-MM-dd")
        Dim fechafin As Date = DateFin.Value.ToString("yyyy-MM-dd")
        Dim local As String = ""
        If TextLocal.Text <> "" Then
            local = TextLocal.Text.Trim
        End If
        Dim horas As String = ""
        If TextHoras.Text <> "" Then
            horas = TextHoras.Text.Trim
        End If
        Dim costo As String = ""
        If TextCosto.Text <> "" Then
            costo = TextCosto.Text.Trim
        End If
        Dim autorizacion As Integer = 0
        If ComboAutorizacion.Text = "Si" Then
            autorizacion = 1
        Else
            autorizacion = 0
        End If
        Dim fechaautorizacion As Date = DateAutorizacion.Value.ToString("yyyy-MM-dd")
        Dim b1 As Integer = 0
        If ComboB1.Text.Trim.Length = 0 Then MsgBox("Debe completar la pregunta 1 de la sección B", MsgBoxStyle.Exclamation, "Atención") : ComboB1.Focus() : Exit Sub
        b1 = Val(ComboB1.Text)
        Dim b2 As Integer = 0
        If ComboB2.Text.Trim.Length = 0 Then MsgBox("Debe completar la pregunta 2 de la sección B", MsgBoxStyle.Exclamation, "Atención") : ComboB2.Focus() : Exit Sub
        b2 = Val(ComboB2.Text)
        Dim b3 As Integer = 0
        If ComboB3.Text.Trim.Length = 0 Then MsgBox("Debe completar la pregunta 3 de la sección B", MsgBoxStyle.Exclamation, "Atención") : ComboB3.Focus() : Exit Sub
        If ComboB3.Text = "Si" Then
            b3 = 1
        Else
            b3 = 0
        End If
        Dim recomendar As String = ""
        If TextRecomendar.Text <> "" Then
            recomendar = TextRecomendar.Text.Trim
        End If
        Dim comentarios As String = ""
        If TextComentarios.Text <> "" Then
            comentarios = TextComentarios.Text.Trim
        End If
        Dim evaluaciondir As dCapacitacionEv = CType(ComboEvaluacionDir.SelectedItem, dCapacitacionEv)
        Dim comentariosdir As String = ""
        'If TextComentariosDir.Text <> "" Then
        '    comentariosdir = TextComentariosDir.Text.Trim
        'End If
        Dim evaluacion As String = ""
        If CbxEvaluacion.Text <> "" Then
            evaluacion = CbxEvaluacion.Text.Trim
        End If
        Dim devolucion As String = ""
        'If TextDevolucion.Text <> "" Then
        '    devolucion = TextDevolucion.Text.Trim
        'End If
        Dim mejora As String = ""
        'If TextMejora.Text <> "" Then
        '    mejora = TextMejora.Text.Trim
        'End If
        Dim repercusion As String = ""
        'If TextRepercusion.Text <> "" Then
        '    repercusion = TextRepercusion.Text.Trim
        'End If
        If TextId.Text.Trim.Length > 0 Then
            Dim p As New dPlanillaCapacitacion
            Dim id As Long = TextId.Text.Trim
            Dim fecinicio As String
            Dim fecfin As String
            Dim fecauto As String
            fecinicio = Format(fechainicio, "yyyy-MM-dd")
            fecfin = Format(fechafin, "yyyy-MM-dd")
            fecauto = Format(fechaautorizacion, "yyyy-MM-dd")
            p.ID = id
            p.IDLIN = idlin
            p.PARTICIPANTE = participante.ID
            p.TIPOACTIVIDAD = tipoactividad.ID
            If instructor <> "" Then
                p.INSTRUCTOR = instructor
            End If
            p.FECHAINICIO = fecinicio
            p.FECHAFIN = fecfin
            If local <> "" Then
                p.LOCAL = local
            End If
            If horas <> "" Then
                p.HORAS = horas
            Else
                p.HORAS = 0
            End If
            If costo <> "" Then
                p.COSTO = costo
            Else
                p.COSTO = 0
            End If
            p.AUTORIZACION = autorizacion
            p.FECHAAUTORIZACION = fecauto
            If b1 > 0 Then
                p.B1 = b1
            Else
                p.B1 = 0
            End If
            If b2 > 0 Then
                p.B2 = b2
            Else
                p.B2 = 0
            End If
            If b3 > 0 Then
                p.B3 = b3
            Else
                p.B3 = 0
            End If
            If recomendar <> "" Then
                p.RECOMENDAR = recomendar
            End If
            If comentarios <> "" Then
                p.COMENTARIOS = comentarios
            End If
            If Not evaluaciondir Is Nothing Then
                p.EVALUACIONDIR = evaluaciondir.ID
            Else
                p.EVALUACIONDIR = 0
            End If
            If comentariosdir <> "" Then
                p.COMENTARIOSDIR = comentariosdir
            End If
            If evaluacion <> "" Then
                p.EVALUACION = evaluacion
            End If
            If devolucion <> "" Then
                p.DEVOLUCION = devolucion
            End If
            If mejora <> "" Then
                p.MEJORA = mejora
            End If
            If repercusion <> "" Then
                p.REPERCUSION = repercusion
            End If
            If (p.modificar(Usuario)) Then
                MsgBox("Planilla modificada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim p As New dPlanillaCapacitacion()
            Dim fecinicio As String
            Dim fecfin As String
            Dim fecauto As String
            fecinicio = Format(fechainicio, "yyyy-MM-dd")
            fecfin = Format(fechafin, "yyyy-MM-dd")
            fecauto = Format(fechaautorizacion, "yyyy-MM-dd")
            p.IDLIN = idlin
            p.PARTICIPANTE = participante.ID
            p.TIPOACTIVIDAD = tipoactividad.ID
            If instructor <> "" Then
                p.INSTRUCTOR = instructor
            End If
            p.FECHAINICIO = fecinicio
            p.FECHAFIN = fecfin
            If local <> "" Then
                p.LOCAL = local
            End If
            If horas <> "" Then
                p.HORAS = horas
            Else
                p.HORAS = 0
            End If
            If costo <> "" Then
                p.COSTO = costo
            Else
                p.COSTO = 0
            End If
            p.AUTORIZACION = autorizacion
            p.FECHAAUTORIZACION = fecauto
            If b1 <> 0 Then
                p.B1 = b1
            Else
                p.B1 = 0
            End If
            If b2 <> 0 Then
                p.B2 = b2
            Else
                p.B2 = 0
            End If
            If b3 <> 0 Then
                p.B3 = b3
            Else
                p.B3 = 0
            End If
            If recomendar <> "" Then
                p.RECOMENDAR = recomendar
            End If
            If comentarios <> "" Then
                p.COMENTARIOS = comentarios
            End If
            If Not evaluaciondir Is Nothing Then
                p.EVALUACIONDIR = evaluaciondir.ID
            Else
                p.EVALUACIONDIR = 0
            End If
            If comentariosdir <> "" Then
                p.COMENTARIOSDIR = comentariosdir
            End If
            If evaluacion <> "" Then
                p.EVALUACION = evaluacion
            End If
            If devolucion <> "" Then
                p.DEVOLUCION = devolucion
            End If
            If mejora <> "" Then
                p.MEJORA = mejora
            End If
            If repercusion <> "" Then
                p.REPERCUSION = repercusion
            End If
            If (p.guardar(Usuario)) Then
                MsgBox("Planilla guardada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If

        'limpiar()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        guardar()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
    End Sub
End Class