Public Class FormCompletoDetalleMuestra
    Private _usuario As dUsuario
    Private _f As Long
    Private _m As String

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal f As Long, ByVal m As String, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _f = f
        _m = m
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        Me.Text = m
        buscardetalle()
    End Sub
#End Region

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        guardar()
    End Sub
    Private Sub buscardetalle()
        Dim na As New dNuevoAnalisis
        na.FICHA = _f
        na.MUESTRA = _m
        na = na.buscarxfichaxmuestra

    End Sub
    Private Sub guardar()
        Dim na As New dNuevoAnalisis
        Dim detallemuestra As String = ""
        detallemuestra = TextDetalleMuestra.Text.Trim
        na.FICHA = _f
        na.MUESTRA = _m
        na.DETALLEMUESTRA = detallemuestra
        na.actualizar_detalle(Usuario)
        Me.Close()
    End Sub

    Private Sub TextDetalleMuestra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextDetalleMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
        End If
    End Sub

    Private Sub TextDetalleMuestra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextDetalleMuestra.TextChanged

    End Sub

    Private Sub ButtonGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
End Class