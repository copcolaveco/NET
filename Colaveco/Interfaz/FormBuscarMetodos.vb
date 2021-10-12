Imports Colaveco.FormSubproductos

Public Class FormBuscarMetodos
    Private _metodos As dMetodos
    Public Property Metodos() As dMetodos
        Get
            Return _metodos
        End Get
        Set(ByVal value As dMetodos)
            _metodos = value
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
        Dim texto As String = textometodo
        Dim m As New dMetodos
        Dim lista As New ArrayList
        lista = m.listarporid(texto)
        ListMetodos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each m In lista
                    ListMetodos.Items.Add(m)
                Next
            End If
        End If
    End Sub



    Private Sub ListMetodos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMetodos.SelectedIndexChanged
        If ListMetodos.SelectedItems.Count = 1 Then
            Dim met As dMetodos = CType(ListMetodos.SelectedItem, dMetodos)
            Metodos = met
        End If
        Me.Close()
    End Sub
End Class