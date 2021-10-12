Public Class FormReclamos
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Private _reclamos As dReclamos
    Public Property Reclamos() As dReclamos
        Get
            Return _reclamos
        End Get
        Set(ByVal value As dReclamos)
            _reclamos = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        limpiar()
        permitiracceso()
    End Sub

    Private Sub permitiracceso()
        ButtonEliminar.Enabled = False
        If Usuario.USUARIO = "CA" Then
            ButtonEliminar.Enabled = True
        Else
            ButtonEliminar.Enabled = False
        End If
    End Sub
    Public Sub cargarLista()
        Dim r As New dReclamos
        Dim lista As New ArrayList
        lista = r.listar
        ListReclamos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each r In lista
                    ListReclamos().Items.Add(r)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        ComboTipo.Text = ""
        DateFecha.Value = Now
        ComboCategoria.Text = ""
        ComboFuente.Text = ""
        TextDescripcion.Text = ""
        TextAnalisis.Text = ""
        TextAcciones.Text = ""
        TextResponsable.Text = ""
        DateAccion.Value = Now
        ComboSeguimiento.Text = ""
        TextCierreProblema.Text = ""
        TextObservaciones.Text = ""
        ComboTipo.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListReclamos.SelectedItem Is Nothing Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim r As New dReclamos
                Dim id As Long = CType(TextId.Text, Long)
                r.ID = id
                If (r.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim tipo As String = ComboTipo.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim categoria As String = ComboCategoria.Text.Trim
        Dim fuente As String = ComboFuente.Text.Trim
        Dim descripcion As String = TextDescripcion.Text
        Dim analisis As String = TextAnalisis.Text
        Dim acciones As String = TextAcciones.Text
        Dim responsable As String = TextResponsable.Text
        Dim fechaaccion As Date = DateAccion.Value.ToString("yyyy-MM-dd")
        Dim seguimiento As String = ComboSeguimiento.Text.Trim
        Dim cierreproblema As String = TextCierreProblema.Text
        Dim observaciones As String = TextObservaciones.Text
        'If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        
        If Not ListReclamos Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextId.Text.Trim.Length > 0 Then
                Dim rec As New dReclamos()
                Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                Dim fecaccion As String
                fec = Format(fecha, "yyyy-MM-dd")
                fecaccion = Format(fechaaccion, "yyyy-MM-dd")
                rec.ID = id
                rec.TIPO = tipo
                rec.FECHA = fec
                rec.CATEGORIA = categoria
                rec.FUENTE = fuente
                rec.DESCRIPCION = descripcion
                rec.ANALISIS = analisis
                rec.ACCIONES = acciones
                rec.RESPONSABLE = responsable
                rec.FECHAACCION = fecaccion
                rec.SEGUIMIENTO = seguimiento
                rec.CIERREPROBLEMA = cierreproblema
                rec.OBSERVACIONES = observaciones
                If Usuario.USUARIO = "CA" Then
                    If (rec.modificar(Usuario)) Then
                        MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    MsgBox("No tiene permisos para modificar el registro.", MsgBoxStyle.Information, "Atención")
                End If
            End If
        Else
            If ComboTipo.Text.Trim.Length > 0 Then
                Dim rec As New dReclamos()
                'Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                Dim fecaccion As String
                fec = Format(fecha, "yyyy-MM-dd")
                fecaccion = Format(fechaaccion, "yyyy-MM-dd")
                'rec.ID = id
                rec.TIPO = tipo
                rec.FECHA = fec
                rec.CATEGORIA = categoria
                rec.FUENTE = fuente
                rec.DESCRIPCION = descripcion
                rec.ANALISIS = analisis
                rec.ACCIONES = acciones
                rec.RESPONSABLE = responsable
                rec.FECHAACCION = fecaccion
                rec.SEGUIMIENTO = seguimiento
                rec.CIERREPROBLEMA = cierreproblema
                rec.OBSERVACIONES = observaciones
                If (rec.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        cargarLista()
        limpiar()
    End Sub

    Private Sub ListReclamos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListReclamos.SelectedIndexChanged
        limpiar()
        If ListReclamos.SelectedItems.Count = 1 Then
            Dim rec As dReclamos = CType(ListReclamos.SelectedItem, dReclamos)
            TextId.Text = rec.ID
            ComboTipo.Text = rec.TIPO
            DateFecha.Value = rec.FECHA
            ComboCategoria.Text = rec.CATEGORIA
            ComboFuente.Text = rec.FUENTE
            TextDescripcion.Text = rec.DESCRIPCION
            TextAnalisis.Text = rec.ANALISIS
            TextAcciones.Text = rec.ACCIONES
            TextResponsable.Text = rec.RESPONSABLE
            DateAccion.Value = rec.FECHAACCION
            ComboSeguimiento.Text = rec.SEGUIMIENTO
            TextCierreProblema.Text = rec.CIERREPROBLEMA
            TextObservaciones.Text = rec.OBSERVACIONES
            DateFecha.Focus()
        End If
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        Dim v As New FormListarReclamos
        v.ShowDialog()
    End Sub
End Class