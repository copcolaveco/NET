Public Class FormCompletoTercerizado
    Private _usuario As dUsuario
    Private _idnuevoanalisis As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal id As Long, ByVal nanal As String, ByVal u As dUsuario)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _idnuevoanalisis = id
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        Me.Text = nanal
    End Sub
#End Region
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim at As New dAnalisisTercerizado
        Dim resultado As String = ""
        resultado = TextResultado.Text.Trim
        at.ID = _idnuevoanalisis
        at.RESULTADO = resultado
        at.actualizar_resultado(Usuario)
        Me.Close()
    End Sub

    Private Sub TextResultado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextResultado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
        End If
    End Sub

    Private Sub TextResultado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextResultado.TextChanged

    End Sub
End Class