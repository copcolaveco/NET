Public Class FormBuscarProducto
    Private _producto As dProductos
    Public Property Producto() As dProductos
        Get
            Return _producto
        End Get
        Set(ByVal value As dProductos)
            _producto = value
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
        Dim p As New dProductos
        Dim lista As New ArrayList
        lista = p.listar
        ListProducto.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListProducto.Items.Add(p)
                Next
            End If
        End If
    End Sub

    Private Sub ListProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListProducto.SelectedIndexChanged
        If ListProducto.SelectedItems.Count = 1 Then
            Dim pro As dProductos = CType(ListProducto.SelectedItem, dProductos)
            Producto = pro
        End If
        Me.Close()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListProducto.Items.Clear()
        If nombre.Length > 0 Then
            Dim unPro As New dProductos
            Dim lista As New ArrayList
            lista = unPro.buscarPorNombre(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then

                For Each s As dProductos In lista
                    ListProducto.Items.Add(s)
                Next
                ListProducto.Sorted = True
            End If
        Else : ListProducto.Items.Clear()
        End If
    End Sub
End Class