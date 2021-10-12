Public Class FormIngresarUsuario
   
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextId.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If TextId.Text <> "" Then
                idusuario1 = TextId.Text.Trim
            End If
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextId.TextChanged

    End Sub
End Class