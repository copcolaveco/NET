Public Class FormBuscarCliente
    Private _cliente As dCliente
    Public Property Cliente() As dCliente
        Get
            Return _cliente
        End Get
        Set(ByVal value As dCliente)
            _cliente = value
        End Set
    End Property
#Region "Atributos"

#End Region
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarLista()
    End Sub

#End Region
    Public Sub cargarLista()
        Dim c As New dCliente
        Dim lista As New ArrayList
        lista = c.listar
        ListClientes.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ListClientes.Items.Add(c)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        cargarLista()
    End Sub

    Private Sub ListClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListClientes.SelectedIndexChanged
        If ListClientes.SelectedItems.Count = 1 Then
            Dim cli As dCliente = CType(ListClientes.SelectedItem, dCliente)
            Cliente = cli
        End If
        Me.Close()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListClientes.Items.Clear()
        If nombre.Length > 0 Then
            Dim unCli As New dCliente
            Dim lista As New ArrayList
            lista = unCli.buscarPorNombre(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then
                For Each c As dCliente In lista
                    ListClientes.Items.Add(c)
                Next
                ListClientes.Sorted = True
            End If
        Else : ListClientes.Items.Clear()
        End If
    End Sub
End Class