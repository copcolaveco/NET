Public Class FormBuscarProveedor
    Private _proveedor As dProveedores
    Public Property Proveedor() As dProveedores
        Get
            Return _proveedor
        End Get
        Set(ByVal value As dProveedores)
            _proveedor = value
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
        Dim p As New dProveedores
        Dim lista As New ArrayList
        lista = p.listar
        ListProveedores.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListProveedores.Items.Add(p)
                Next
            End If
        End If
    End Sub

    Private Sub ListProveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListProveedores.SelectedIndexChanged
        If ListProveedores.SelectedItems.Count = 1 Then
            Dim pro As dProveedores = CType(ListProveedores.SelectedItem, dProveedores)
            Proveedor = pro
        End If
        Me.Close()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListProveedores.Items.Clear()
        If nombre.Length > 0 Then
            Dim unPro As New dProveedores
            Dim lista As New ArrayList
            lista = unPro.buscarPorNombre(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then

                For Each s As dProveedores In lista
                    ListProveedores.Items.Add(s)
                Next
                ListProveedores.Sorted = True
            End If
        Else : ListProveedores.Items.Clear()
        End If
    End Sub
End Class