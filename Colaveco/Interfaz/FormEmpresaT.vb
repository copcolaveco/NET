Public Class FormEmpresaT
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
        Dim e As New dEmpresaT
        Dim lista As New ArrayList
        lista = e.listar
        ListEmpresasT.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each e In lista
                    ListEmpresasT.Items.Add(e)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextDireccion.Text = ""
        TextTelefonos.Text = ""
        TextNombre.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        Dim direccion As String = TextDireccion.Text.Trim
        Dim telefono As String = TextTelefonos.Text.Trim
        If Not ListEmpresasT.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim et As New dEmpresaT()
                Dim id As Long = TextId.Text.Trim
                et.ID = id
                et.NOMBRE = nombre
                et.DIRECCION = direccion
                et.TELEFONO = telefono
                If (et.modificar(Usuario)) Then
                    MsgBox("Empresa de transporte modificada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim et As New dEmpresaT()
                'pro.ID = id
                et.NOMBRE = nombre
                et.DIRECCION = direccion
                et.TELEFONO = telefono
                If (et.guardar(Usuario)) Then
                    MsgBox("Empresa de transporte guardada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ListEmpresasT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListEmpresasT.SelectedIndexChanged
        If ListEmpresasT.SelectedItems.Count = 1 Then
            Dim et As dEmpresaT = CType(ListEmpresasT.SelectedItem, dEmpresaT)
            TextId.Text = et.ID
            TextNombre.Text = et.NOMBRE
            TextDireccion.Text = et.DIRECCION
            TextTelefonos.Text = et.TELEFONO
            TextNombre.Focus()
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click

    End Sub
End Class