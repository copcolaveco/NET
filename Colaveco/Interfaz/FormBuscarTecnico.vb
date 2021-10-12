Public Class FormBuscarTecnico
    Private _productor As dProductorWeb_com
    Private _tecnico As dTecnicos
    Public Property Tecnico() As dTecnicos
        Get
            Return _tecnico
        End Get
        Set(ByVal value As dTecnicos)
            _tecnico = value
        End Set
    End Property
    Public Property Productor() As dProductorWeb_com
        Get
            Return _productor
        End Get
        Set(ByVal value As dProductorWeb_com)
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
        Dim p As New dProductorWeb_com
        Dim lista As New ArrayList
        lista = p.listartecnicos
        ListTecnicos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListTecnicos.Items.Add(p)
                Next
            End If
        End If
    End Sub

    Private Sub ListTecnicos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListTecnicos.SelectedIndexChanged
        If ListTecnicos.SelectedItems.Count = 1 Then
            Dim pro As dProductorWeb_com = CType(ListTecnicos.SelectedItem, dProductorWeb_com)
            Productor = pro
        End If
        Me.Close()
    End Sub

    Private Sub TextBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBuscar.TextChanged
        Dim nombre As String = TextBuscar.Text.Trim
        ListTecnicos.Items.Clear()
        If nombre.Length > 0 Then
            Dim unPro As New dProductorWeb_com
            Dim lista As New ArrayList
            lista = unPro.buscarPorNombre(nombre)
            If Not lista Is Nothing And lista.Count > 0 Then

                For Each s As dProductorWeb_com In lista
                    ListTecnicos.Items.Add(s)
                Next
                ListTecnicos.Sorted = True
            End If
        Else : ListTecnicos.Items.Clear()
        End If
    End Sub

    Private Sub ButtonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTodos.Click
        cargarLista()
    End Sub
End Class