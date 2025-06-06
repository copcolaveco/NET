﻿Public Class FormEnviarMensajes
    Private productorweb_com As String
    Private idproductorweb_com As Long
    Private _usuario As dUsuario
    Private email As String
    Private celular As String

    Private Sub ButtonSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionar.Click
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        productorweb_com = ""

        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            productorweb_com = pro.USUARIO_WEB
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
            TextCliente.Text = pro.NOMBRE
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
                _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
                _SMTP.Host = "smtp.gmail.com"
                _SMTP.Port = 587 '465
                _SMTP.EnableSsl = True
                ' CONFIGURACION DEL MENSAJE 
                '_Message.[To].Add("computos@colaveco.com")
                _Message.[To].Add(LTrim(email))
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
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