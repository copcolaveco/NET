Public Class FormMuestrasNoAptas
    Private _usuario As dUsuario
    Dim idsol As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal ficha As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarComboMotivo()
        Usuario = u
        idsol = ficha
        TextFicha.Text = idsol
        listarmuestras()
    End Sub
#End Region
    Public Sub listarmuestras()
        Dim mn As New dMuestrasNoAptas
        Dim lista As New ArrayList
        lista = mn.listarporficha(idsol)
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each a In lista
                    ListMuestras().Items.Add(a)
                Next
            End If
        End If
    End Sub
    Private Sub cargarComboMotivo()
        Dim m As New dMuestraNoApta
        Dim lista As New ArrayList
        lista = m.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ComboMotivo.Items.Add(m)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim ficha As Long = TextFicha.Text.Trim
        Dim motivo As dMuestraNoApta = CType(ComboMotivo.SelectedItem, dMuestraNoApta)
        Dim cantidad As Integer = TextCantidad.Text.Trim
        If Not ListMuestras.SelectedItem Is Nothing And TextFicha.Text.Trim.Length > 0 Then
            Dim mna As New dMuestrasNoAptas()
            Dim id As Long = TextId.Text.Trim
            mna.ID = id
            mna.FICHA = ficha
            mna.MOTIVO = motivo.ID
            mna.CANTIDAD = cantidad
            If (mna.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextFicha.Text.Trim.Length > 0 Then
                Dim mna As New dMuestrasNoAptas()
                mna.FICHA = ficha
                mna.MOTIVO = motivo.ID
                mna.CANTIDAD = cantidad
                If (mna.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        listarmuestras()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        ComboMotivo.SelectedItem = Nothing
        TextCantidad.Text = ""
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        limpiar()
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim mna As dMuestrasNoAptas = CType(ListMuestras.SelectedItem, dMuestrasNoAptas)
            TextId.Text = mna.ID
            TextFicha.Text = mna.FICHA
            Dim m As dMuestraNoApta
            ComboMotivo.SelectedItem = Nothing
            For Each m In ComboMotivo.Items
                If m.ID = mna.MOTIVO Then
                    ComboMotivo.SelectedItem = m
                    Exit For
                End If
            Next
            TextCantidad.Text = mna.CANTIDAD
            TextCantidad.Focus()
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListMuestras.SelectedItem Is Nothing Then
            Dim m As New dMuestrasNoAptas
            Dim id As Long = CType(TextId.Text, Long)
            m.ID = id
            If (m.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listarmuestras()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
    End Sub

    Private Sub TextCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCantidad.TextChanged

    End Sub
End Class