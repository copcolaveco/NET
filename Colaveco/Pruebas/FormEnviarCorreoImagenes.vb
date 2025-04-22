Imports System.Net.Mail

Public Class FormEnviarCorreoImagenes

    Private Sub enviaremail2()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = "c:\debug\colaveco_afiche.jpg" 'idficha
        email = "pepobaez@gmail.com"

        If email <> "" Then

            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Prueba"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Probando probando"
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = True

            '**** fondo ************************************************************************************************************
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("Cuerpo del correo", Nothing, "text/html")
            'Path de la imagen
            Dim logo As New LinkedResource("c:\debug\colaveco_afiche.jpg")
            logo.ContentId = "companylogo"
            'Adicionando logo
            htmlView.LinkedResources.Add(logo)

            '***********************************************************************************************************************

            ' ADICION DE DATOS ADJUNTOS 
            'Dim _File As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & archivo & ".xls" 'archivo que se quiere adjuntar 
            'Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            '_Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""

    End Sub
    Private Sub enviarmail()
        Dim SMTP As New System.Net.Mail.SmtpClient 'Variable con la que se envia el correo
        Dim CORREO As New System.Net.Mail.MailMessage
        CORREO.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "Colaveco", System.Text.Encoding.UTF8)


        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("Cuerpo del correo", Nothing, "text/html")
        'Path de la imagen
        Dim logo As New LinkedResource("c:\debug\aprobada.png")
        logo.ContentId = "companylogo"
        'Adicionando logo
        htmlView.LinkedResources.Add(logo)

        CORREO.To.Add("pepobaez@gmail.com")
        'Adicionando copia oculta
        'CORREO.Bcc.Add("pedro.baez@adinet.com.uy")

        CORREO.IsBodyHtml = True
        CORREO.AlternateViews.Add(htmlView)

        CORREO.Subject = "Confirmación de recarga - AutoMailer -"
        SMTP.Host = "smtp.gmail.com"
        SMTP.Port = "587"
        SMTP.EnableSsl = True

        Try
            SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "CLV19912021Colaveco30")
            SMTP.Send(CORREO)

        Catch ex As System.Net.Mail.SmtpException
            MessageBox.Show("Fallo el envio: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        enviarmail()
    End Sub
End Class