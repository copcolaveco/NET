Public Class FormCorreo
    Private _usuario As dUsuario
    Dim email As String
    Dim nficha As Long
    Private _ruta As String
    Private _archivo As String
    Private _extension As String

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal mail As String, ByVal ficha As Long)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        email = mail
        RadioCliente.Checked = True
        nficha = ficha
        cargardatos()
        cargardescripcion()
    End Sub
#End Region
    Private Sub cargardatos()
        TextDestinatario.Text = email
        TextAsunto.Text = "Informe - Colaveco"
    End Sub
    Private Sub cargardescripcion()
        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        Dim importe As Double = 0
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            importe = sa.IMPORTE
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If

        Dim texto As String = ""
        texto = "Nos es grato comunicarle que el informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se encuentra disponible en la web de Colaveco." & vbCrLf _
            & "Para poder acceder a los resultados debe ir a http://www.colaveco.com.uy/gestor y digitar su usuario y contraseña." & vbCrLf _
            & "Sino cuenta con usuario y contraseña, favor solicitarla en administración al correo electrónico colaveco@gmail.com o al teléfono 4554 5311." & vbCrLf _
            & "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas." & vbCrLf & vbCrLf _
            & "Agradecemos su confianza y quedamos a sus órdenes." & vbCrLf & vbCrLf _
            & "Sin mas, saluda muy atte." & vbCrLf & vbCrLf _
            & "Administración - COLAVECO"


        TextDescripcion.Text = texto
        ButtonAdjuntar.Enabled = True
        TextAdjunto.Enabled = True

    End Sub

    Private Sub ButtonEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviar.Click
        'enviar_mail()
        guardar_envio()
        email = ""
        Me.Close()
        Dim v As New FormObservacionesSinVisualizacion
        v.ShowDialog()
    End Sub

    Private Sub ButtonAdjuntar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdjuntar.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.*)|*.*"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de archivo"
        dlAbrir.InitialDirectory = ""
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            TextAdjunto.Text = fichero
            _archivo = System.IO.Path.GetFileNameWithoutExtension(fichero)
            _extension = System.IO.Path.GetExtension(fichero)
            '*** COPIAR ARCHIVO ***********************************************************************
            Dim sArchivoOrigen As String = fichero
            _ruta = "\\" & "\\" & "192.168.1.10" & "\\" & "E" & "\\" & "NET" & "\\" & "ADJUNTOS" & "\\" & _archivo & _extension
            Dim sRutaDestino As String = _ruta
            Try
                ' copiar el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.CopyFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub RadioCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioCliente.CheckedChanged
        cargardescripcion()
    End Sub

    Private Sub RadioProlesa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioProlesa.CheckedChanged
        cargardescripcion()
    End Sub

    Private Sub RadioPersonalizado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioPersonalizado.CheckedChanged
        cargardescripcion()
    End Sub

    Private Sub ButtonNoEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNoEnviar.Click
        no_enviar_mail()
    End Sub
    Private Sub enviar_mail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        email = TextDestinatario.Text.Trim

        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If

        Dim texto As String = ""
        Dim archivo As String = ""
        texto = TextDescripcion.Text.Trim
        If TextAdjunto.Text <> "" Then
            archivo = TextAdjunto.Text.Trim
        End If

        If email <> "" Then
            If TextAdjunto.Text <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "J]e5$5c2(Qnl")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Informe - Colaveco"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = texto
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                Dim _File As String = archivo 'archivo que se quiere adjuntar ‘
                Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
                _Message.Attachments.Add(_Attachment) 'ENVIO 
                Try
                    _SMTP.Send(_Message)
                    MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
                End Try
            Else
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "J]e5$5c2(Qnl")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Informe - Colaveco"
                'Sujeto del e-mail 
                _Message.SubjectEncoding = System.Text.Encoding.UTF8
                'Codificacion 
                _Message.Body = texto
                'contenido del mail 
                _Message.BodyEncoding = System.Text.Encoding.UTF8 '
                _Message.Priority = System.Net.Mail.MailPriority.Normal
                _Message.IsBodyHtml = False
                ' ADICION DE DATOS ADJUNTOS ‘
                'Dim _File As String = archivo 'archivo que se quiere adjuntar ‘
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
        Me.Close()
        Dim v As New FormObservacionesSinVisualizacion
        v.ShowDialog()
    End Sub
    Private Sub no_enviar_mail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        email = TextDestinatario.Text.Trim
        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre_productor = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipo_analisis = ti.NOMBRE
            End If
        End If
        Dim texto As String = ""
        Dim archivo As String = ""
        texto = TextDescripcion.Text.Trim
        If TextAdjunto.Text <> "" Then
            archivo = TextAdjunto.Text.Trim
        End If
        email = ""
        Me.Close()
        Dim v As New FormObservacionesSinVisualizacion
        v.ShowDialog()
    End Sub
    Private Sub guardar_envio()
        Dim _email As String = ""
        Dim _cliente As String = ""
        Dim _informe As String = ""
        If TextDestinatario.Text <> "" Then
            _email = TextDestinatario.Text.Trim
        Else
            _email = ""
        End If

        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        sa.ID = nficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                _cliente = p.NOMBRE
            End If
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                _informe = ti.NOMBRE
            End If
        End If

        Dim _texto As String = ""
        _texto = TextDescripcion.Text.Trim

        Dim c As New dCorreos
        Dim ficha As Long = nficha
        Dim informe As String = _informe
        Dim cliente As String = _cliente
        Dim email As String = _email
        Dim texto As String = _texto
        Dim adjunto As String = _ruta
        c.FICHA = ficha
        c.INFORME = informe
        c.CLIENTE = cliente
        c.EMAIL = email
        c.TEXTO = texto
        c.ADJUNTO = adjunto
        c.ENVIADO = 0
        c.guardar(Usuario)
    End Sub
End Class