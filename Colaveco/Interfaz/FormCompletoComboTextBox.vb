Public Class FormCompletoComboTextBox
    Private _usuario As dUsuario
    Private _idnuevoanalisis As Long
    Private _idanal As Integer
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal id As Long, ByVal idanal As Integer, ByVal nanal As String, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _idnuevoanalisis = id
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        Me.Text = nanal
        _idanal = idanal
        cargarcombo()

    End Sub
#End Region
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
       Dim na As New dNuevoAnalisis
        Dim resultado As String = ""
        Dim resultado2 As String = ""
        resultado = ComboResultado.Text.Trim
        resultado2 = TextResultado.Text.Trim
        na.ID = _idnuevoanalisis
        na.RESULTADO = resultado
        na.RESULTADO2 = resultado2
        na.actualizar_resultado(Usuario)

        Me.Close()
    End Sub
    Private Sub cargarcombo()
        Dim cr As New dComboResultados
        Dim lista As New ArrayList
        lista = cr.listarxanalisis(_idanal)
        If Not lista Is Nothing Then
            For Each cr In lista
                ComboResultado.Items.Add(cr)
            Next
        End If
    End Sub

    Private Sub ComboResultado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboResultado.SelectedIndexChanged
        TextResultado.Focus()
    End Sub
End Class