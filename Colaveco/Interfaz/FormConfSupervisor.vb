Public Class FormConfSupervisor
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Property AutorizadoCorrecto As Boolean = False

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Dim psw As String = txtPassword.Text.Trim

        If psw.Length = 0 Then
            MsgBox("Ingrese su código de confirmación", MsgBoxStyle.Exclamation, "Atención")
            txtPassword.Focus()
            Exit Sub
        End If

        ' Encriptar la contraseña ingresada
        Dim sha As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytestring() As Byte = System.Text.Encoding.ASCII.GetBytes(psw)
        bytestring = sha.ComputeHash(bytestring)

        Dim finalstring As String = Nothing
        For Each bt As Byte In bytestring
            finalstring &= bt.ToString("x2")
        Next

        ' Obtener la lista de passwords de supervisores
        Dim unUsuario As New dUsuario
        Dim lisPassword As New ArrayList
        lisPassword = unUsuario.buscarPassSupervisores()

        If lisPassword IsNot Nothing AndAlso lisPassword.Count > 0 Then
            Dim autorizado As Boolean = False

            ' Recorremos la lista
            For Each u As dUsuario In lisPassword
                If u.PASSWORD = finalstring Then
                    autorizado = True
                    Exit For
                End If
            Next

            If autorizado Then
                MsgBox("Código correcto, puede continuar.", MsgBoxStyle.Information, "Confirmación")
                Me.AutorizadoCorrecto = True ' Indicamos que fue autorizado
                Me.Close()
            Else
                MsgBox("El código digitado no es correcto", MsgBoxStyle.Exclamation, "Atención")
                txtPassword.Focus()
            End If
        Else
            MsgBox("No se encontraron códigos de supervisores para validar.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub
End Class