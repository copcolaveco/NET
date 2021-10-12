Public Class FormBuscarProductor
    Private _productor As dProductor
    Public Property Productor() As dProductor
        Get
            Return _productor
        End Get
        Set(ByVal value As dProductor)
            _productor = value
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
        lista = p.listar
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
            Dim pro As dProductor = CType(ListProductores.SelectedItem, dProductor)
            Productor = pro
        End If
        Me.Close()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListProductores.Items.Clear()
        If nombre.Length > 0 Then
            Dim unPro As New dCliente
            Dim lista As New ArrayList
            lista = unPro.buscarPorNombre(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then
                For Each s As dProductor In lista
                    ListProductores.Items.Add(s)
                Next
                ListProductores.Sorted = True
            End If
        Else : ListProductores.Items.Clear()
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        cargarLista()
    End Sub
End Class