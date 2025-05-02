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
    Private _solicitudAnalisisId As Long
    Public Property SolicitudAnalisisId() As Long
        Get
            Return _solicitudAnalisisId
        End Get
        Set(ByVal value As Long)
            _solicitudAnalisisId = value
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
        Dim lisPassword As ArrayList = unUsuario.buscarPassSupervisores()

        If lisPassword IsNot Nothing AndAlso lisPassword.Count > 0 Then
            Dim autorizado As Boolean = False
            Dim usuarioAutorizador As dUsuario = Nothing

            For Each u As dUsuario In lisPassword
                If u.PASSWORD = finalstring Then
                    autorizado = True
                    usuarioAutorizador = u
                    Exit For
                End If
            Next

            If autorizado Then
                ' Pedir observación
                Dim observacion As String = InputBox("Ingrese una observación para la autorización:", "Observación")
                If observacion.Trim.Length = 0 Then
                    MsgBox("Debe ingresar una observación.", MsgBoxStyle.Exclamation, "Atención")
                    Exit Sub
                End If

                ' Crear y guardar la autorización
                Dim aut As New dSolicitud_Autorizacion
                Dim fechaActual As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                aut.SOLICITUDANALISIS_ID = Me.SolicitudAnalisisId ' <- Esta propiedad debe existir en el formulario
                aut.USUARIO_AUTORIZA_ID = usuarioAutorizador.ID
                aut.OBSERVACIONES = observacion
                aut.FECHA = fechaActual

                If aut.Insertar() Then
                    MsgBox("Autorización registrada correctamente.", MsgBoxStyle.Information, "Éxito")
                    Me.AutorizadoCorrecto = True
                    Me.Close()
                Else
                    MsgBox("Error al registrar la autorización.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("El código digitado no es correcto", MsgBoxStyle.Exclamation, "Atención")
                txtPassword.Focus()
            End If
        Else
            MsgBox("No se encontraron códigos de supervisores para validar.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

End Class