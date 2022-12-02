Public Class FormEnviarMensajes
    Private productorweb_com As String
    Private idproductorweb_com As Long
    Private _usuario As dUsuario
    Private email As String
    Private celular As String

    Private Sub ButtonSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionar.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        productorweb_com = ""

        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            productorweb_com = cli.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            If Not pw_com Is Nothing Then
                idproductorweb_com = pw_com.ID
                email = RTrim(pw_com.ENVIAR_EMAIL)
                celular = Replace(pw_com.ENVIAR_SMS, " ", "")
            Else
                MsgBox("No coincide el usuario web (.com)")
                Exit Sub
            End If
            TextCliente.Text = cli.NOMBRE
            TextEmail.Text = email
        End If
    End Sub
    Private Sub enviomail()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim texto As String = ""
        If TextTexto.Text <> "" Then
            texto = TextTexto.Text.Trim
        End If
        If email <> "" Then
            If texto <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "J]e5$5c2(Qnl")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                _Message.[To].Add(LTrim(email))
                _Message.[To].Add("envios@colaveco.com.uy")
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Aviso!"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""

                _Message.Body = texto
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                'Dim _File As String = My.Application.Info.DirectoryPath & "archivo" 'archivo que se quiere adjuntar ‘
                'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
                '_Message.Attachments.Add(_Attachment) 'ENVIO 
                Try
                    _SMTP.Send(_Message)
                    MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            End If
        End If
        email = ""
        texto = ""
        limpiar()
    End Sub

    Private Sub ButtonEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviar.Click
        enviomail()
    End Sub
    Private Sub limpiar()
        TextCliente.Text = ""
        TextEmail.Text = ""
        TextTexto.Text = ""
    End Sub
End Class