Public Class FormPedidosAutomaticos_it
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        Usuario = u
        calculardia()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
#End Region
    Private Sub ButtonActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonActivar.Click

        Dim dia As Integer = 0
        dia = NumericDia.Value
        Dim p As New dPedidosAuto
        p.DIA = dia
        p.activar(Usuario)
    End Sub
    Private Sub calculardia()
        Dim fecha As Date = Now()
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim diaactual As Integer = Mid(fec, 9, 2)
        NumericDia.Value = diaactual
    End Sub
End Class