Public Class FormMuestras
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
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        limpiar()
    End Sub

#End Region
    Public Sub cargarLista()
        Dim m As New dMuestras
        Dim lista As New ArrayList
        lista = m.listar
        ListMuestras.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ListMuestras.Items.Add(m)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextNombre.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        If Not ListMuestras.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim mue As New dMuestras()
                Dim id As Long = TextId.Text.Trim
                mue.ID = id
                mue.NOMBRE = nombre
                If (mue.modificar(Usuario)) Then
                    MsgBox("Muestra modificada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim mue As New dMuestras()
                mue.NOMBRE = nombre
                If (mue.guardar(Usuario)) Then
                    MsgBox("Muestra guardada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ListMuestras_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMuestras.SelectedIndexChanged
        If ListMuestras.SelectedItems.Count = 1 Then
            Dim mue As dMuestras = CType(ListMuestras.SelectedItem, dMuestras)
            TextId.Text = mue.ID
            TextNombre.Text = mue.NOMBRE
            TextNombre.Focus()
        End If
    End Sub

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        If Not ListMuestras.SelectedItem Is Nothing Then
            Dim m As New dMuestras
            Dim id As Long = CType(TextId.Text, Long)
            m.ID = id
            If (m.eliminar(Usuario)) Then
                MsgBox("Muestra eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub
End Class