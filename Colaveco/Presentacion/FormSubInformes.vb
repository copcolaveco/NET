Public Class FormSubInformes
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
    Private _subinforme As dSubInforme
    Public Property Subinforme() As dSubInforme
        Get
            Return _subinforme
        End Get
        Set(ByVal value As dSubInforme)
            _subinforme = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        cargarComboTipoInforme()

        limpiar()
    End Sub

#End Region
    Public Sub cargarLista()
        Dim s As New dSubInforme
        Dim lista As New ArrayList
        lista = s.listar
        ListSubInformes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ListSubInformes.Items.Add(s)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        ComboTipoInforme.Text = ""
        CheckGeneraPlanilla.Checked = False
        TextTitulo.Text = ""
        TextNombre.Focus()
    End Sub
    Public Sub cargarComboTipoInforme()
        Dim ti As New dTipoInforme
        Dim lista As New ArrayList
        lista = ti.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each ti In lista
                    ComboTipoInforme.Items.Add(ti)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        Dim tipoinforme As dTipoInforme = CType(ComboTipoInforme.SelectedItem, dTipoInforme)
        Dim generaplanilla As Integer
        If CheckGeneraPlanilla.Checked = True Then
            generaplanilla = 1
        Else
            generaplanilla = 0
        End If
        Dim titulo As String = TextTitulo.Text.Trim
        If Not ListSubInformes.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim subinf As New dSubInforme()
                Dim id As Long = TextId.Text.Trim
                subinf.ID = id
                subinf.NOMBRE = nombre
                If Not tipoinforme Is Nothing Then
                    subinf.IDTIPOINFORME = tipoinforme.ID
                End If
                subinf.GENERARPLANILLA = generaplanilla
                subinf.TITULO = titulo
                If (subinf.modificar(Usuario)) Then
                    MsgBox("Subtipo de informe modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim subinf As New dSubInforme()
                subinf.NOMBRE = nombre
                If Not tipoinforme Is Nothing Then
                    subinf.IDTIPOINFORME = tipoinforme.ID
                End If
                subinf.GENERARPLANILLA = generaplanilla
                subinf.TITULO = titulo
                If (subinf.guardar(Usuario)) Then
                    MsgBox("Subtipo de informe guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ListSubInformes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListSubInformes.SelectedIndexChanged
        limpiar()
        If ListSubInformes.SelectedItems.Count = 1 Then
            Dim subinf As dSubInforme = CType(ListSubInformes.SelectedItem, dSubInforme)
            TextId.Text = subinf.ID
            TextNombre.Text = subinf.NOMBRE
            Dim t As dTipoInforme
            ComboTipoInforme.SelectedItem = Nothing
            For Each t In ComboTipoInforme.Items
                If t.ID = subinf.IDTIPOINFORME Then
                    ComboTipoInforme.SelectedItem = t
                    Exit For
                End If
            Next
            If subinf.GENERARPLANILLA = 1 Then
                CheckGeneraPlanilla.Checked = True
            Else
                CheckGeneraPlanilla.Checked = False
            End If
            TextTitulo.Text = subinf.TITULO
            TextNombre.Focus()
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListSubInformes.SelectedItem Is Nothing Then
            Dim s As New dSubInforme
            Dim id As Long = CType(TextId.Text, Long)
            s.ID = id
            If (s.eliminar(Usuario)) Then
                MsgBox("Sub informe eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub
End Class