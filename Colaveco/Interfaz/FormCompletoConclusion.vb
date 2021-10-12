Public Class FormCompletoConclusion
    Private _usuario As dUsuario
    Private _ficha As Long = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal ficha As Long, ByVal u As dUsuario)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _ficha = ficha
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        mostrar_resultado()
    End Sub
#End Region
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub mostrar_resultado()
        Dim c As New dConclusiones
        c.FICHA = _ficha
        c = c.buscar
        If Not c Is Nothing Then
            TextConclusiones.Text = c.CONCLUSION
        Else
        End If
    End Sub
    Private Sub guardar()
        Dim c As New dConclusiones
        Dim conclusion As String = ""
        conclusion = TextConclusiones.Text.Trim
        c.FICHA = _ficha
        c.CONCLUSION = conclusion
        c.guardar(Usuario)
        Me.Close()
    End Sub
End Class