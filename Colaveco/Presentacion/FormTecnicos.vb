Public Class FormTecnicos
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
        Dim t As New dTecnicos
        Dim lista As New ArrayList
        lista = t.listar
        ListTecnicos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ListTecnicos.Items.Add(t)
                Next
            End If
        End If
    End Sub

    Private Sub ListTecnicos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListTecnicos.SelectedIndexChanged
        If ListTecnicos.SelectedItems.Count = 1 Then
            Dim tec As dTecnicos = CType(ListTecnicos.SelectedItem, dTecnicos)
            TextId.Text = tec.ID
            TextNombre.Text = tec.NOMBRE
            TextDireccion.Text = tec.DIRECCION
            TextTelefono.Text = tec.TELEFONO
            TextCelular.Text = tec.CELULAR
            TextMail.Text = tec.EMAIL
            TextNombre.Focus()
        End If
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListTecnicos.Items.Clear()
        If nombre.Length > 0 Then
            Dim unTec As New dTecnicos
            Dim lista As New ArrayList
            lista = unTec.buscarPorNombre(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then
                For Each s As dTecnicos In lista
                    ListTecnicos.Items.Add(s)
                Next
                ListTecnicos.Sorted = True
            End If
        Else : ListTecnicos.Items.Clear()
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        TextBuscar.Text = ""
        cargarLista()
        TextBuscar.Focus()
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        TextNombre.Text = ""
        TextDireccion.Text = ""
        TextTelefono.Text = ""
        TextCelular.Text = ""
        TextMail.Text = ""
        TextNombre.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        cargarLista()
        limpiar()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim nombre As String = TextNombre.Text.Trim
        Dim direccion As String = TextDireccion.Text.Trim
        Dim telefono As String = TextTelefono.Text.Trim
        Dim celular As String = TextCelular.Text.Trim
        Dim mail As String = TextMail.Text.Trim
        If Not ListTecnicos.SelectedItem Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextNombre.Text.Trim.Length > 0 Then
                Dim tec As New dTecnicos()
                Dim id As Long = TextId.Text.Trim
                tec.ID = id
                tec.NOMBRE = nombre
                tec.DIRECCION = direccion
                tec.TELEFONO = telefono
                tec.CELULAR = celular
                tec.EMAIL = mail
                If (tec.modificar(Usuario)) Then
                    MsgBox("Técnico modificado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        Else
            If TextNombre.Text.Trim.Length > 0 Then
                Dim tec As New dTecnicos()
                tec.NOMBRE = nombre
                tec.DIRECCION = direccion
                tec.TELEFONO = telefono
                tec.CELULAR = celular
                tec.EMAIL = mail
                If (tec.guardar(Usuario)) Then
                    MsgBox("Técnico guardado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click

    End Sub
End Class