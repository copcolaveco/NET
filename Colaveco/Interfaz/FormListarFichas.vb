Public Class FormListarFichas
    Dim idcliente As Long = 0
    Private _ficha As dSolicitudAnalisis
    Public Property Ficha() As dSolicitudAnalisis
        Get
            Return _ficha
        End Get
        Set(ByVal value As dSolicitudAnalisis)
            _ficha = value
        End Set
    End Property
#Region "Atributos"

#End Region
#Region "Constructores"
    Public Sub New(ByVal cliente As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        idcliente = cliente
        cargarLista()

    End Sub

#End Region
    Public Sub cargarLista()
        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarxproductorsinenviar(idcliente)
        ListFichas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each s In lista
                    ListFichas.Items.Add(s)
                Next
            End If
        End If
    End Sub

    

    Private Sub ListFichas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFichas.SelectedIndexChanged
        If ListFichas.SelectedItems.Count = 1 Then
            Dim s As dSolicitudAnalisis = CType(ListFichas.SelectedItem, dSolicitudAnalisis)
            Ficha = s
        End If
        Me.Close()
    End Sub
End Class