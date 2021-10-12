Public Class FormCompletoTextBox2
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
        mostrar_resultado()
        cargar_radio()
    End Sub
#End Region
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub cargar_radio()
        If _idanal = 164 Then
            RadioR1.Checked = True
        Else
            RadioR2.Checked = True
        End If
    End Sub
    Private Sub mostrar_resultado()
        Dim na As New dNuevoAnalisis
        na.ID = _idnuevoanalisis
        na = na.buscar
        If Not na Is Nothing Then
            TextResultado.Text = na.RESULTADO
            TextResultado2.Text = na.RESULTADO2
            If na.M = 1 Then
                RadioR1.Checked = True
                RadioR2.Checked = False
            ElseIf na.M = 2 Then
                RadioR1.Checked = False
                RadioR2.Checked = True
            End If
        End If
    End Sub

    Private Sub guardar()
        Dim na As New dNuevoAnalisis
        Dim resultado As String = ""
        Dim resultado2 As String = ""
        Dim mr As Integer = 0
        If RadioR1.Checked = True Then
            mr = 1
        Else
            mr = 2
        End If
        resultado = TextResultado.Text.Trim
        resultado2 = TextResultado2.Text.Trim
        na.ID = _idnuevoanalisis
        na.RESULTADO = resultado
        na.RESULTADO2 = resultado2
        na.M = mr
        na.actualizar_resultado(Usuario)
        Me.Close()
    End Sub

    Private Sub TextResultado2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextResultado2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
        End If
    End Sub

    Private Sub TextResultado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextResultado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextResultado2.Focus()
        End If
    End Sub
End Class