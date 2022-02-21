
Public Class MsgForm

    Public Sub New(ByVal text As String)
        InitializeComponent()
        CargarTexto(text)
    End Sub

    Public Sub CargarTexto(ByVal text As String)
        MsgFormText.Text = text
        MsgFormText.ForeColor = Color.Red
    End Sub

    Private Sub BtnMSgForm_Click(sender As Object, e As EventArgs)
        Return
    End Sub
End Class