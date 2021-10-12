Public Class FormCompletarMail
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

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
    End Sub
#End Region
    Private Sub actualizarmail()
        Dim p As New dProductor
        Dim id As Integer = idprod
        Dim mail As String = TextMail.Text.Trim
        p.ID = id
        p.actualizarmail(p.ID, mail, Usuario)
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextMail.Text <> "" Then
            actualizarmail()
        End If
        Me.Close()
    End Sub

    Private Sub TextMail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextMail.TextChanged

    End Sub
End Class