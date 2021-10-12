Public Class FormBuscarEmpresa
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
        Dim p As New dCliente
        Dim lista As New ArrayList
        lista = p.listarempresa
        ListProductores.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListProductores.Items.Add(p)
                Next
            End If
        End If
    End Sub

    Private Sub ListProductores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListProductores.SelectedIndexChanged
        If ListProductores.SelectedItems.Count = 1 Then
            Dim pro As dCliente = CType(ListProductores.SelectedItem, dCliente)
            Cliente = pro
        End If
        Me.Close()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListProductores.Items.Clear()
        If nombre.Length > 0 Then
            Dim unPro As New dCliente
            Dim lista As New ArrayList
            lista = unPro.buscarPorNombreEmpresa(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then

                For Each s As dCliente In lista
                    ListProductores.Items.Add(s)
                Next
                ListProductores.Sorted = True
            End If
        Else : ListProductores.Items.Clear()
        End If
    End Sub
End Class