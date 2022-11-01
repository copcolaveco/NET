Public Class FormCorreoMorosos
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
        TextAsunto.Text = "Informe sin visualización!"
    End Sub
    Private Sub cargardescripcion()
        Dim textocliente As String = ""
        Dim textoprolesa As String = ""

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
        ' & "El monto del análisis es de $ " & importe & " , puede realizar, si lo desea, un depósito en la cta cte en $ del BROU 001522854-00007, a nombre de Colaveco, o abonarlo en nuestro local." & vbCrLf & vbCrLf _
        textocliente = "Estimado cliente" & vbCrLf & vbCrLf _
        & "Le informamos que desde el día de la fecha el informe Nº" & " " & nficha & " - " & tipo_analisis & " " & "(" & nombre_productor & ")," & "se encuentra pendiente de visualización en la web/app de Colaveco, aguardando aviso de pago." & vbCrLf & vbCrLf _
        & "La cooperativa se maneja con un sistema de entrega de informes contra pago, por lo que el mismo permanecerá restringido de visualización hasta recibir el mismo." & vbCrLf & vbCrLf _
        & "Si lo desea, puede realizar un depósito en la cta cte en $ del BROU 001522854-00007, a nombre de Colaveco, o abonarlo en nuestro local." & vbCrLf & vbCrLf _
        & "Solicitamos nos informe si ha realizado el pago por esta vía, de forma de emitir el recibo y darle visualización a la brevedad." & vbCrLf & vbCrLf _
        & "Recuerde que los resultados quedan habilitados si el cliente no tiene facturas vencidas." & vbCrLf & vbCrLf _
        & "Para poder acceder a los resultados debe ir a http://www.colaveco.com.uy/gestor y digitar su usuario y contraseña." & vbCrLf & vbCrLf _
        & "Sino cuenta con usuario y contraseña, favor solicitarla en administración al correo electrónico colaveco@gmail.com o al teléfono 4554 5311." & vbCrLf & vbCrLf _
        & "Sin mas, saluda muy atte." & vbCrLf & vbCrLf _
        & "Administración - COLAVECO"

        textoprolesa = "El informe Nº" & " " & nficha & " - " & tipo_analisis & " " & "(" & nombre_productor & ")," & "se encuentra pendiente de visualización en la web/app de Colaveco, por motivo        de FALTA DE RECEPCIÓN ORDEN DE PROLESA." & vbCrLf & vbCrLf _
        & "Solicitamos gestionar LA ORDEN DE PAGO con la sucursal de PROLESA que ud. trabaja y nos la haga llegar vía mail o fax a los efectos de poder visualizar el resultado." & vbCrLf & vbCrLf _
        & "Recuerde que los resultados quedan habilitados cuando el cliente envía la orden correspondiente." & vbCrLf & vbCrLf _
        & "Para poder acceder a los resultados debe ir a http://www.colaveco.com.uy/gestor y digitar su usuario y contraseña." & vbCrLf & vbCrLf _
        & "Sino cuenta con usuario y contraseña, favor solicitarla en administración al correo electrónico colaveco@gmail.com o al teléfono 4554 5311." & vbCrLf & vbCrLf _
        & "Sin mas, saluda muy atte." & vbCrLf & vbCrLf _
        & "Administración - COLAVECO"

        If RadioCliente.Checked = True Then
            TextDescripcion.Text = textocliente
            ButtonAdjuntar.Enabled = True
            TextAdjunto.Enabled = True
        ElseIf RadioProlesa.Checked = True Then
            TextDescripcion.Text = textoprolesa
            ButtonAdjuntar.Enabled = False
            TextAdjunto.Enabled = False
        Else
            TextDescripcion.Text = ""
            ButtonAdjuntar.Enabled = False
            TextAdjunto.Enabled = False
            TextDescripcion.Focus()
        End If
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
    Private Sub enviar_mail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        If TextAdjunto.Text <> "" Then
            archivo = TextAdjunto.Text.Trim
        End If
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

        texto = TextDescripcion.Text.Trim

        If email <> "" Then
            If TextAdjunto.Text <> "" Then
                'CONFIGURACIÓN DEL STMP 
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Informe sin visualización"
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
                _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "19912021Notificaciones")
                _SMTP.Host = "170.249.199.66"
                _SMTP.Port = 25
                _SMTP.EnableSsl = False

                ' CONFIGURACION DEL MENSAJE 
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
                'Cuenta de Correo al que se le quiere enviar el e-mail 
                _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
                'Quien lo envía 
                _Message.Subject = "Informe sin visualización"
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
End Class