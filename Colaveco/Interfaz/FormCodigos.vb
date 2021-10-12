Public Class FormCodigos
    Public _codigo As String = ""
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCodigo.SelectedIndexChanged
        _codigo = ComboCodigo.Text
    End Sub
End Class