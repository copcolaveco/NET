Public Class FormEditarNumeroTambo

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            buscarproductor()
            TextTambo.Focus()
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFicha.LostFocus
        buscarproductor()
        TextTambo.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFicha.TextChanged

    End Sub
    Private Sub buscarproductor()
        If TextFicha.Text <> "" Then
            Dim sa As New dSolicitudAnalisis
            Dim ficha As Long = TextFicha.Text.Trim
            sa.ID = ficha
            sa = sa.buscar
            If Not sa Is Nothing Then
                Dim p As New dCliente
                p.ID = sa.IDPRODUCTOR
                p = p.buscar
                If Not p Is Nothing Then
                    TextProductor.Text = p.NOMBRE
                End If
            End If
        End If
    End Sub
    Private Sub cambiar()
        If TextFicha.Text <> "" Then
            If TextTambo.Text <> "" Then
                Dim ca As New dControlAuxWeb_com
                Dim ficha As Long = 0
                Dim tambo As Integer = 0
                ficha = TextFicha.Text.Trim
                tambo = TextTambo.Text.Trim
                If (ca.modificartambo(ficha, tambo)) Then
                    MsgBox("Actualización finalizada", MsgBoxStyle.Information, "Atención")
                    limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        TextProductor.Text = ""
        TextTambo.Text = ""
        TextFicha.Focus()
    End Sub
  
    Private Sub ButtonCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCambiar.Click
        cambiar()
    End Sub
End Class