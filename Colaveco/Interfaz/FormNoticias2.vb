Public Class FormNoticias2
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
        cargarComboUsuarios()
        cargarLista()
        limpiar()
    End Sub

#End Region
    Public Sub cargarLista()
        Dim n As New dNoticias2
        Dim lista As New ArrayList
        lista = n.listar
        ListNoticias.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each n In lista
                    ListNoticias.Items.Add(n)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextDescripcion.Text = ""
        ComboUsuarios.SelectedItem = Nothing
        ComboUsuarios.Text = ""
        CheckMostrar.Checked = False
        TextDescripcion.Focus()
    End Sub
    Public Sub cargarComboUsuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboUsuarios.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub ListNoticias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListNoticias.SelectedIndexChanged
        If ListNoticias.SelectedItems.Count = 1 Then
            Dim noti As dNoticias2 = CType(ListNoticias.SelectedItem, dNoticias2)
            TextId.Text = noti.ID
            TextDescripcion.Text = noti.DESCRIPCION
            Dim u As dUsuario
            ComboUsuarios.SelectedItem = Nothing
            For Each u In ComboUsuarios.Items
                If u.ID = noti.USUARIO Then
                    ComboUsuarios.SelectedItem = u
                    Exit For
                End If
            Next
            If noti.MOSTRAR = 1 Then
                CheckMostrar.Checked = True
            Else
                CheckMostrar.Checked = False
            End If
            TextDescripcion.Focus()
        End If
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim descripcion As String = TextDescripcion.Text.Trim
        Dim usuario As dUsuario = CType(ComboUsuarios.SelectedItem, dUsuario)
        Dim idusuario As Integer = 0
        If Not usuario Is Nothing Then
            idusuario = usuario.ID
        End If
        Dim mostrar As Integer = 0
        If CheckMostrar.Checked = True Then
            mostrar = 1
        End If
        If Not ListNoticias.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextDescripcion.Text.Trim.Length > 0 Then
                Dim noti As New dNoticias2()
                Dim id As Long = TextId.Text.Trim
                noti.ID = id
                noti.DESCRIPCION = descripcion
                noti.USUARIO = idusuario
                noti.MOSTRAR = mostrar
                If (noti.modificar(Usuario)) Then
                    MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextDescripcion.Text.Trim.Length > 0 Then
                Dim noti As New dNoticias2()
                noti.DESCRIPCION = descripcion
                noti.USUARIO = idusuario
                noti.MOSTRAR = mostrar
                If (noti.guardar(Usuario)) Then
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        Dim n As New dNoticias2
        n.ID = TextId.Text
        n.eliminar(Usuario)
        limpiar()
        cargarLista()
    End Sub
End Class