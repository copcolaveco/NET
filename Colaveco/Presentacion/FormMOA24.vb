Public Class FormMOA24
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
        Dim m As New dMOA24
        Dim lista As New ArrayList
        lista = m.listar
        ListMOA24.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ListMOA24.Items.Add(m)
                Next
            End If
        End If
    End Sub


    Private Sub ListMOA24_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMOA24.SelectedIndexChanged
        If ListMOA24.SelectedItems.Count = 1 Then
            Dim moa As dMOA24 = CType(ListMOA24.SelectedItem, dMOA24)
            TextId.Text = moa.ID
            TextNombre.Text = moa.NOMBRE
            TextOrden.Text = moa.ORDEN
            TextNombre.Focus()
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextOrden.Text = ""
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        Dim orden As Integer = TextOrden.Text.Trim
        If Not ListMOA24.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim moa As New dMOA24()
                Dim id As Long = TextId.Text.Trim
                moa.ID = id
                moa.NOMBRE = nombre
                moa.ORDEN = orden
                If (moa.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim moa As New dMOA24()
                moa.NOMBRE = nombre
                moa.ORDEN = orden
                If (moa.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListMOA24.SelectedItem Is Nothing Then
            Dim m As New dMOA24
            Dim id As Long = CType(TextId.Text, Long)
            m.ID = id
            If (m.eliminar(Usuario)) Then
                MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub
End Class