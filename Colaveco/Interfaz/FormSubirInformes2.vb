Imports System.Net.FtpWebRequest
Imports System.Net
Imports System.IO
Imports System.Collections
Imports Newtonsoft.Json
Imports iTextSharp.text 'Para trabajar con los pdf
Imports iTextSharp.text.pdf

Public Class FormSubirInformes2
    Private productorweb_com As String
    Private productorweb_uy As String
    Private copiaproductorweb_com As String
    Private copiaproductorweb_uy As String
    Private idproductorweb_com As Long
    Private idproductorweb_uy As Long
    Private copiaidproductorweb_com As Long
    Private copiaidproductorweb_uy As Long
    Private idficha As String
    Private tipoinforme As Integer
    Private _usuario As dUsuario
    Public email As String
    Public celular As String
    Public nficha As String
    Public mensaje As String = ""
    Public excel As Integer = 0
    Public pdf As Integer = 0
    Public csv As Integer = 0
    Public Informe As Integer = 0
    Public ficha As Long = 0
    Public abonado As Integer = 0
    Public comentario As String = ""
    Public copia As String = ""
    Public cliente As Integer = 0
    Dim sFile1 As String = ""
    Dim sFile2 As String = ""
    Dim sFile3 As String = ""
    Dim sFile4 As String = ""
    Dim Listax As New List(Of String)

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        marcarxdefecto()
    End Sub
#End Region

    Private Sub marcarxdefecto()
        CheckXls.Checked = True
        CheckPdf.Checked = True
        RadioNoAbonadocv.Checked = True
        CheckCom.Checked = True
    End Sub
    Private Sub ButtonSubirInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirInforme.Click


        Dim saMarcar As New dSolicitudAnalisis
        saMarcar.ID = idficha
        Dim pi As New dPreinformes
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        pi.FICHA = idficha
        Informe = idficha

        Try
            If tipoinforme = 1 Then
                subir_control() '_control()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 3 Then
                subir_agua()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 4 Then
                subir_atb()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 6 Then
                subir_parasitologia()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 7 Then
                subir_alimentos()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 8 Then
                subir_serologia()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 9 Then
                subir_patologia()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 10 Then
                subir_calidad()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 11 Then
                subir_ambiental()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 13 Then
                subir_nutricion()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 14 Then
                subir_suelos()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 15 Then
                subir_brucelosis()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 16 Then
                subir_efluentes()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 17 Then
                subir_bacteriologia()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 18 Then
                subir_bacteriologia_clinica()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 19 Then
                subir_foliares()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 20 Then
                subir_toxicologia()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
            ElseIf tipoinforme = 21 Then
                subir_mineralesenleche()
                saMarcar.marcar(Usuario, _fecha)
                pi.marcarsubido(_fecha)
               
            End If

            '---------------GestorGX
            Dim gestorNuevo As New dNuevoGestor
            gestorNuevo.ID = idficha
            gestorNuevo.FECHAENVIO = _fecha
            gestorNuevo.modificarFechaEnvio(Usuario)
        Catch ex As Exception

        End Try

        
    End Sub
    Private Sub subir_control()

        estadoPago()
        mover_archivos(EnumCarpetaInforme.CONTROL_LECHERO, EnumTipoInforme.ControlLechero)
        actualizar_estados(abonado)
        actualizar_preInforme()
        agregar_control_informe(EnumTipoControles.FisicoQuimico)
        limpiar()
        marcarxdefecto()

    End Sub
    Private Sub subir_agua()

        estadoPago()
        mover_archivos(EnumCarpetaInforme.AGUA, EnumTipoInforme.Agua)
        actualizar_estados(abonado)
        actualizar_preInforme()
        agregar_control_informe(EnumTipoControles.Microbiologia)
        limpiar()
        marcarxdefecto()

    End Sub
    Private Sub subir_atb()

        estadoPago()
        mover_archivos(EnumCarpetaInforme.ANTIBIOGRAMA, EnumTipoInforme.AislamientoAntibiograma)
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()

    End Sub
    Private Sub subir_parasitologia()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.PARASITOLOGIA, EnumTipoInforme.Parasitologia)
        actualizar_preInforme()
        actualizar_estados(abonado)
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_alimentos()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.ALIMENTOS, EnumTipoInforme.Alimentos)
        actualizar_estados(abonado)
        actualizar_preInforme()
        agregar_control_informe(EnumTipoControles.Microbiologia)
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_serologia()
        estadoPago()
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_patologia()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.PATOLOGIA, EnumTipoInforme.Patologia)
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_calidad()
       
        estadoPago()
        cliente = TextIdCliente.Text.Trim
        mover_archivos(EnumCarpetaInforme.CALIDAD, EnumTipoInforme.CalidadLeche)

        Dim csm As New dCalidadSolicitudMuestra
        csm.FICHA = Informe
        csm = csm.buscarxsolicitud
        agregar_control_informe(EnumTipoControles.FisicoQuimico)

        If csm.RB = 1 Or csm.INHIBIDORES = 1 Or csm.ESPORULADOS = 1 Or csm.PSICROTROFOS = 1 Then
            agregar_control_informe(EnumTipoControles.Microbiologia)
        End If

        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_mineralesenleche()
        estadoPago()
        cliente = TextIdCliente.Text.Trim
        mover_archivos(EnumCarpetaInforme.CALIDAD, EnumTipoInforme.CalidadLeche)
        agregar_control_informe(EnumTipoControles.FisicoQuimico)

        Dim csm As New dCalidadSolicitudMuestra
        csm.FICHA = ficha
        csm = csm.buscarxsolicitud

        If csm.RB = 1 Or csm.INHIBIDORES = 1 Or csm.ESPORULADOS = 1 Or csm.PSICROTROFOS = 1 Then
            agregar_control_informe(EnumTipoControles.Microbiologia)
        End If

        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_ambiental()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.AMBIENTAL, EnumTipoInforme.Ambiental)
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_nutricion()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.NUTRICION, EnumTipoInforme.Nutricion)
        actualizar_estados(abonado)
        actualizar_preInforme()
        agregar_control_informe(EnumTipoControles.Nutricion)
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_suelos()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.SUELOS, EnumTipoInforme.Suelos)
        actualizar_estados(abonado)
        actualizar_preInforme()
        agregar_control_informe(EnumTipoControles.Suelos)
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_brucelosis()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.BRUCELOSIS_LECHE, EnumTipoInforme.BrucelosisLeche)
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_efluentes()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.EFLUENTES, EnumTipoInforme.Efluentes)
        actualizar_estados(abonado)
        actualizar_preInforme()
        agregar_control_informe(EnumTipoControles.Efluentes)
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_bacteriologia()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.BACTERIOLOGIA, EnumTipoInforme.BacteriologiaTanque)
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_bacteriologia_clinica()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.BACTERIOLOGIA, EnumTipoInforme.BacteriologiaClinica)
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_foliares()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.TOXICOLOGIA, EnumTipoInforme.Foliares)
        actualizar_estados(abonado)
        actualizar_preInforme()
        agregar_control_informe(EnumTipoControles.Suelos)
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_toxicologia()
        estadoPago()
        mover_archivos(EnumCarpetaInforme.TOXICOLOGIA, EnumTipoInforme.Toxicologia)
        actualizar_estados(abonado)
        actualizar_preInforme()
        limpiar()
        marcarxdefecto()
    End Sub
   
    Private Sub limpiar()
        TextIdCliente.Text = ""
        TextNombreCliente.Text = ""
        TextFicha.Text = ""
        TextComentarios.Text = ""
        TextEnviarCopia.Text = ""
    End Sub

    Private Sub ButtonSeleccionarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionarCliente.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()

        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdCliente.Text = cli.ID
            TextNombreCliente.Text = cli.NOMBRE

            If cli.USUARIO_WEB = "" Then
                MsgBox("El cliente no tiene usuario web")
                Exit Sub
                limpiar()
                marcarxdefecto()
            End If
            
            If cli.FAC_CONTADO = 1 Then
                MsgBox("El cliente es CONTADO!")
            End If

            If cli.PROLESA = 1 Then
                MsgBox("El cliente realiza el pago por PROLESA.")
                ButtonSeleccionarFicha.Focus()
            End If

            ButtonSeleccionarFicha.Focus()
        End If
    End Sub

    Private Sub enviar_correo_AFB()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = TextFicha.Text.Trim
        email = "jgarello@lasibila.com.ar, pdemaio@lasibila.com.ar, amrodriguez@afb.com.uy, hvilche@afb.com.uy, lab.fisicoquimico@afb.com.uy, mcornejo@afb.com.uy"
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
            _Message.Subject = "Colaveco - Calidad de leche"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos informe de Calidad de leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\ROBOT\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Attachment = Nothing
                _File = ""
            Catch ex As System.Net.Mail.SmtpException
            End Try
        End If
        email = ""
    End Sub
    Private Sub enviar_correo_AFB2()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = TextFicha.Text.Trim
        email = "jgarello@lasibila.com.ar, pdemaio@lasibila.com.ar, amrodriguez@afb.com.uy, hvilche@afb.com.uy, lab.fisicoquimico@afb.com.uy, mcornejo@afb.com.uy"
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
            _Message.Subject = "Colaveco - Calidad de leche - TXT"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos informe de Calidad de leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".txt" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("TXT enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Attachment = Nothing
                _File = ""
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub
    Private Sub enviar_correo_IS()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = TextFicha.Text.Trim
        email = "iverocay@hotmail.com"
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
            _Message.Subject = "Colaveco - Calidad de leche - TXT"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjuntamos informe de Calidad de leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".txt" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("TXT enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Attachment = Nothing
                _File = ""
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub

    Private Sub enviomailInformeConVisualizacion()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        nficha = idficha
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
        texto = "Nos es grato comunicarle que el informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se encuentra disponible en la web/app de Colaveco." & vbCrLf _
            & "Para poder acceder a los resultados debe ir a www.colaveco.com.uy y digitar su usuario y contraseña." & vbCrLf _
            & "Sino cuenta con usuario y contraseña, favor solicitarla en administración al correo electrónico colaveco@gmail.com o al teléfono 4554 5311." & vbCrLf _
            & "Agradecemos su confianza y quedamos a sus órdenes." & vbCrLf & vbCrLf _
            & "Sin mas, saluda muy atte." & vbCrLf & vbCrLf _
            & "Administración - COLAVECO"

        Dim sol As New dSolicitudAnalisis
        Dim cli As New dCliente
        Dim prod As Long = sol.IDPRODUCTOR
        cli.ID = sa.IDPRODUCTOR
        cli = cli.buscar
        If cli.NOT_EMAIL_ANALISIS1 <> "" Then
            email = RTrim(cli.NOT_EMAIL_ANALISIS1)
        ElseIf cli.NOT_EMAIL_ANALISIS2 <> "" Then
            email = RTrim(cli.NOT_EMAIL_ANALISIS2)
        ElseIf cli.EMAIL <> "" Then
            email = RTrim(cli.EMAIL)
        End If

        If email <> "" Then
         
            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com.uy")
            Try
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Informe" & " Nº " & nficha & " - Colaveco"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = texto
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False

            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException
            End Try
        End If

        If cliente = 6299 Then
            enviar_correo_AFB()
            enviar_correo_AFB2()
        ElseIf cliente = 2705 Then
            enviar_correo_IS()
        End If

        email = ""
        nficha = 0
    End Sub

    Private Sub subir_informe_gestor()

        'Gestor 
        Dim nuevoGestor As New dNuevoGestor
        nuevoGestor.ID = Informe
        nuevoGestor.SOLICITUDESTADOID = 3
        nuevoGestor.modificar(Usuario)

        'Envio de Email
        enviomailInformeConVisualizacion()
    End Sub

    Public Sub agregar_control_informe(ByVal tipoControl As Integer)
        Dim fechadesde As Date = Now
        Dim fechahasta As Date = Now
        Dim fechad As String
        Dim fechah As String
        Dim tipo As Integer = 3
        fechad = Format(fechadesde, "yyyy-MM-dd")
        fechah = Format(fechahasta, "yyyy-MM-dd")
        Informe = TextFicha.Text.Trim

        Dim Control As dControlBase
        Select Case tipoControl
            Case EnumTipoControles.Efluentes
                Control = New dControlInformesEfluentes
            Case EnumTipoControles.FisicoQuimico
                Control = New dControlInformesFQ
            Case EnumTipoControles.Microbiologia
                Control = New dControlInformesMicro
            Case EnumTipoControles.Nutricion
                Control = New dControlInformesNutricion
            Case EnumTipoControles.Suelos
                Control = New dControlInformesSuelos
        End Select

        Dim lista As ArrayList = Control.listarxtipoxfecha(tipoControl, fechad, fechah)
        If Not lista Is Nothing Then
            If lista.Count < 6 Then
                Control.FECHACONTROL = fechad
                Control.FICHA = Informe
                Control.FECHA = fechad
                Control.TIPO = tipoControl
                Control.RESULTADO = 0
                Control.COINCIDE = 0
                Control.OBSERVACIONES = ""
                Control.CONTROLADOR = 100
                Control.CONTROLADO = 0
                Control.guardar()

                Dim controlGestor As New dNGControl
                Try
                    'Registro en Gestor Nuevo
                    controlGestor.InformeId = Informe
                    controlGestor.UsuarioId = _usuario.ID
                    controlGestor.ControlTipoId = tipoControl
                    controlGestor.ControlCoincide = 0
                    controlGestor.ControlControlado = 0
                    controlGestor.ControlFechaIngreso = Today.ToString("yyyy-MM-dd HH:mm:ss")
                    controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                    controlGestor.ControlInformeTipo = tipoinforme
                    controlGestor.ControlNoConformidad = 0
                    controlGestor.ControlObservaciones = "Se creo Control"
                    controlGestor.ControlOpcMejora = 0
                    controlGestor.ControlResultado = 0
                    controlGestor.guardar()
                Catch ex As Exception

                End Try

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = Informe
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
        Else
            Control.FECHACONTROL = fechad
            Control.FICHA = Informe
            Control.FECHA = fechad
            Control.TIPO = tipoControl
            Control.RESULTADO = 0
            Control.COINCIDE = 0
            Control.OBSERVACIONES = ""
            Control.CONTROLADOR = 100
            Control.CONTROLADO = 0
            Control.guardar()
            Control = Nothing

            Dim controlGestor As New dNGControl
            Try
                'Registro en Gestor Nuevo
                controlGestor.InformeId = Informe
                controlGestor.UsuarioId = _usuario.ID
                controlGestor.ControlTipoId = tipoControl
                controlGestor.ControlCoincide = 0
                controlGestor.ControlControlado = 0
                controlGestor.ControlFechaIngreso = Today.ToString("yyyy-MM-dd HH:mm:ss")
                controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                controlGestor.ControlInformeTipo = tipoinforme
                controlGestor.ControlNoConformidad = 0
                controlGestor.ControlObservaciones = "Se creo Control"
                controlGestor.ControlOpcMejora = 0
                controlGestor.ControlResultado = 0
                controlGestor.guardar()
            Catch ex As Exception

            End Try

            ' Grabar estado de la ficha
            Dim est As New dEstados
            est.FICHA = Informe
            est.ESTADO = 6
            est.FECHA = fechad
            est.guardar2()
            est = Nothing
            '****************************
        End If

    End Sub

    Public Sub mover_archivos(ByVal enumCarpeta As EnumCarpetaInforme, ByVal tipoInforme As Long)

        Dim carpetaInforme As String = EnumCarpetaInformeToString(enumCarpeta)

        '****************************************************************************************
        'JUNTAR LOS 2 PDF ***************************************************************************
        ' Creamos una lista de archivos para concatenar
        Dim Listax As New List(Of String)
        ' Identificamos los documentos que queremos unir
        Dim sFile1 As String = "\\192.168.1.10\E\NET\" + carpetaInforme + "\Graficas\" & Informe & ".pdf"
        Dim sFile2 As String = "\\192.168.1.10\E\NET\" + carpetaInforme + "\Graficas\x" & Informe & ".pdf"
        ' Los añadimos a la lista
        Listax.Add(sFile1)
        Listax.Add(sFile2)

        ' Unir PDFs y Mover TXT
        If tipoInforme = EnumTipoInforme.ControlLechero Then

            Dim sFileJoin As String = ""

            If tipoInforme = EnumTipoInforme.ControlLechero Then
                sFileJoin = "\\ROBOT\PREINFORMES\CONTROL\" & Informe & ".pdf"
            Else
                sFileJoin = "\\ROBOT\PREINFORMES\" + carpetaInforme + "\" & Informe & ".pdf"
            End If

            Dim Doc As New Document()
            Try
                Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim copy As New PdfCopy(Doc, fs)
                Doc.Open()
                Dim Rd As PdfReader
                Dim n As Integer
                For Each file In Listax
                    Rd = New PdfReader(file)
                    n = Rd.NumberOfPages
                    Dim page As Integer = 0
                    Do While page < n
                        page += 1
                        copy.AddPage(copy.GetImportedPage(Rd, page))
                    Loop
                    copy.FreeReader(Rd)
                    Rd.Close()
                Next
            Catch ex As Exception

            Finally
                Doc.Close()
            End Try

            '*** MOVER ARCHIVO TXT***********************************************************************

            Dim sArchivoOrigenTxt As String = ""

            If tipoInforme = EnumTipoInforme.ControlLechero Then
                sArchivoOrigenTxt = "\\ROBOT\PREINFORMES\CONTROL\" & Informe & ".txt"
            Else
                sArchivoOrigenTxt = "\\ROBOT\PREINFORMES\" + carpetaInforme + "\" & Informe & ".txt"
            End If

            Dim sRutaDestino3 As String = "\\ROBOT\INFORMES PARA SUBIR\" & Informe & ".txt"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigenTxt, _
                                                sRutaDestino3, _
                                                True)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

        End If

        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = ""
        If tipoInforme = EnumTipoInforme.ControlLechero Then
            sArchivoOrigen = "\\ROBOT\PREINFORMES\CONTROL\" & Informe & ".xls"
        Else
            sArchivoOrigen = "\\ROBOT\PREINFORMES\" + carpetaInforme + "\" & Informe & ".xls"
        End If

        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & Informe & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                           sRutaDestino, _
                                            True)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        '*** MOVER ARCHIVO PDF***********************************************************************
        If tipoInforme = EnumTipoInforme.Suelos Then
            sFile1 = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".pdf"
            sFile2 = "\\ROBOT\PREINFORMES\SUELOS\anexo" & ficha & ".pdf"
            sFile3 = "\\ROBOT\PREINFORMES\SUELOS\anexoPH" & ficha & ".pdf"
            sFile4 = "\\ROBOT\PREINFORMES\SUELOS\anexoCationes" & ficha & ".pdf"
            Listax.Add(sFile1)

            If isAnexo Then 'fertilizantes
                Listax.Add(sFile2)
            End If

            If isAnexoPH Then 'PH
                Listax.Add(sFile3)
            End If

            If isAnexoCationes Then 'PH
                Listax.Add(sFile4)
            End If

            ' Nombre del documento resultante
            Dim sFileJoin As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim Doc As New Document()
            Try
                Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim copy As New PdfCopy(Doc, fs)
                Doc.Open()
                Dim Rd As PdfReader
                Dim n As Integer 'Número de páginas de cada pdf
                For Each file In Listax
                    Rd = New PdfReader(file)
                    n = Rd.NumberOfPages
                    Dim page As Integer = 0
                    Do While page < n
                        page += 1
                        copy.AddPage(copy.GetImportedPage(Rd, page))
                    Loop
                    copy.FreeReader(Rd)
                    Rd.Close()
                Next
            Catch ex As Exception
                MsgBox(ex.Message, vbExclamation, "Error uniendo los pdf, si el informe no lleva ANEXO por conversiòn de fertilizante proceguir.")
            Finally
                ' Cerramos el documento
                Doc.Close()
            End Try
        Else
            Dim sArchivoOrigen2 As String = ""
            If tipoInforme = EnumTipoInforme.ControlLechero Then
                sArchivoOrigen2 = "\\ROBOT\PREINFORMES\CONTROL\" & Informe & ".pdf"
            Else
                sArchivoOrigen2 = "\\ROBOT\PREINFORMES\" + carpetaInforme + "\" & Informe & ".pdf"
            End If

            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & Informe & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If
        

    End Sub

    Public Sub ButtonSeleccionarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionarFicha.Click
        Dim cliente As Long = TextIdCliente.Text.Trim
        Dim v As New FormListarFichas(cliente)
        Dim vencido As Integer = 0
        Dim diferencia As Double = 0
        Dim abonado As Integer = 0
        Dim pagaotro As Long = 0
        Dim pagook As Integer = 0
        Dim ti As New dTipoInforme
        v.ShowDialog()
        If Not v.Ficha Is Nothing Then
            Dim s As dSolicitudAnalisis = v.Ficha
            TextFicha.Text = s.ID
            idficha = s.ID
            If s.PAGO = 1 Then
                pagook = 1
            End If
            If s.IDTIPOINFORME > 0 Then
                ti.ID = s.IDTIPOINFORME
                ti = ti.buscar
                TextTipoAnalisis.Text = ti.NOMBRE
                tipoinforme = s.IDTIPOINFORME
            Else
                TextTipoAnalisis.Text = ""
            End If
            If s.IDTIPOINFORME = 1 Then
                CheckTxt.Checked = True
            Else
                CheckTxt.Checked = False
            End If

            Dim cli As New dCliente
            cli.ID = cliente
            cli = cli.buscar
            Dim client As New dClient
            client.CLICOD = cliente
            client = client.buscarxcli
            If Not client Is Nothing Then
                If client.CLISCT <> 0 Then
                    pagaotro = client.CLISCT
                End If
            End If
            If Not cli Is Nothing Then
                If cli.FAC_CONTADO = 1 Then
                    Dim f As New dFacturacion
                    Dim lista As New ArrayList
                    lista = f.listarxficha(idficha)
                    If Not lista Is Nothing Then
                        For Each f In lista
                            If f.FACTURA <> 0 And f.FACTURA <> 999999 Then
                                Dim mc As New dMovCte
                                mc.MCCCMP = f.FACTURA
                                mc = mc.buscarxcomprobante
                                If Not mc Is Nothing Then
                                    If mc.MCCPAG >= mc.MCCIMP Then
                                        abonado = 2 '1
                                    End If
                                End If
                            End If
                        Next
                    End If
                ElseIf cli.PROLESA = 1 Then
                    Dim f As New dFacturacion
                    Dim lista As New ArrayList
                    lista = f.listarxficha(idficha)
                    For Each f In lista
                        If f.FACTURA <> 0 And f.FACTURA <> 999999 Then
                            Dim mc As New dMovCte
                            mc.MCCCMP = f.FACTURA
                            mc = mc.buscarxcomprobante
                            If Not mc Is Nothing Then
                                abonado = 2 '1
                            End If
                        End If
                    Next
                Else
                    Dim mc As New dMovCte
                    Dim listamc As New ArrayList
                    Dim fechaactual As Date = Now.ToString("yyyy-MM-dd")
                    Dim fechaact As String = Format(fechaactual, "yyyy-MM-dd")
                    vencido = 0
                    If pagaotro <> 0 Then
                        cliente = pagaotro
                    End If
                    listamc = mc.listarxcli(cliente)
                    If Not listamc Is Nothing Then
                        For Each mc In listamc
                            Dim fechavto As Date = mc.MCCVTO
                            Dim fecvto As String = Format(fechavto, "yyyy-MM-dd")
                            If fecvto < fechaact Then
                                If mc.MCCPAG < mc.MCCIMP Then

                                    diferencia = mc.MCCIMP - mc.MCCPAG
                                    If diferencia > 100 Then
                                        vencido = 1
                                    End If
                                End If
                            Else
                                abonado = 1
                            End If
                        Next

                        'Dim f As New dFacturacion
                        'Dim lista As New ArrayList
                        'lista = f.listarxficha(idficha)
                        'For Each f In lista
                        '    If f.FACTURA <> 0 And f.FACTURA <> 999999 Then
                        '        abonado = 1
                        '    End If
                        'Next
                    Else
                        abonado = 2 ' asignaba 1, lo cambie el 16/07/2019
                    End If
                End If
            End If
            If pagook = 1 Then
                RadioAbonado.Checked = True
            Else
                If abonado = 1 Then
                    RadioNoAbonadocv.Checked = True
                Else
                    RadioAbonado.Checked = True
                End If
                If vencido = 0 And abonado <> 2 Then
                    RadioNoAbonadocv.Checked = True
                ElseIf vencido = 1 Then
                    RadioNoAbonadosv.Checked = True
                End If

                If cli.PROLESA = 1 And abonado = 0 Then
                    RadioNoAbonadosv.Checked = True
                End If
                If cli.FAC_CONTADO = 1 And abonado = 0 Then
                    RadioNoAbonadosv.Checked = True
                End If
            End If

            pagook = 0
            TextComentarios.Focus()
        End If
    End Sub

    Public Function EnumCarpetaInformeToString(carpeta As EnumCarpetaInforme) As String
        Return carpeta.ToString()
    End Function

    Public Sub actualizar_estados(ByVal abonado As Long)
        Dim sol As New dSolicitudAnalisis

        ' Grabar si es NO abonado sin visualización
        If abonado = 0 Then
            Dim fechaact As Date = Now()
            Dim fecact As String
            Dim muestras As Integer = 0
            fecact = Format(fechaact, "yyyy-MM-dd")

            Dim sv As New dSinVisualizacion
            sol.ID = Informe
            sol = sol.buscar

            Dim nuevoGestor As New dNuevoGestor
            nuevoGestor.ID = Informe
            nuevoGestor.SOLICITUDESTADOID = 2
            nuevoGestor.modificar(Usuario)

            If Not sol Is Nothing Then
                muestras = sol.NMUESTRAS
            End If

            Dim importe As Double = sol.IMPORTE
            Dim visualizacion As Integer = 0
            Dim observaciones As String = ""

            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If

            sv.FICHA = Informe
            fichasv = Informe
            sv.FECHA = fecact
            sv.MUESTRAS = muestras
            sv.IMPORTE = importe
            sv.VISUALIZACION = visualizacion
            sv.FECHAVISUALIZACION = fecact
            sv.OBSERVACIONES = observaciones
            sv.guardar()

            Dim p As New dCliente
            Dim prod As Long = sol.IDPRODUCTOR
            p.ID = sol.IDPRODUCTOR
            p = p.buscar

            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If

            'Email a informes no abonados sin visualización
            Dim v As New FormCorreoMorosos(Usuario, email, Informe)
            v.Show()

            p = Nothing
            prod = Nothing
            sv = Nothing
            sol = Nothing

            'No abonado con visualización o Abonado
        ElseIf abonado = 2 Or abonado = 1 Then

            sol.ID = Informe
            sol = sol.buscar

            'Gestor, envio mail al cliente, verifico si tiene Control pendiente de aprovación 

            Dim fichaControl As New dControlInformesFQ
            Dim estado As Integer = fichaControl.obtener_estado_control_ficha(Informe)
            Dim control As EnumControles = CType(estado, EnumControles)

            Select Case control
                Case EnumControles.Controlado
                    subir_informe_gestor()
                    MsgBox("Se finalizó el proceso y se notifico al cliente por mail, el informe fué controlado por un técnmico y subido al Gestor modificando a su nuevo estado.")
                Case EnumControles.NoControlado
                    MsgBox("Informe en proceso, debe ser controlado por un técnico para ser Finalizado.")
                Case EnumControles.NoTieneControl
                    subir_informe_gestor()
                    MsgBox("Se finalizó el proceso y se notifico al cliente por mail, Informe no tenía asociado un control para hacerse por lo tanto fué subido al Gestor y modificado su estado.")
            End Select

            sol = Nothing

        End If
    End Sub

    Public Sub estadoPago()
        If RadioAbonado.Checked = True Then
            abonado = 2
        ElseIf RadioNoAbonadocv.Checked = True Then
            abonado = 1
        ElseIf RadioNoAbonadosv.Checked = True Then
            abonado = 0
        End If
        If TextComentarios.Text <> "" Then
            comentario = TextComentarios.Text
        End If
        If TextEnviarCopia.Text <> "" Then
            copia = TextEnviarCopia.Text
        End If
    End Sub

    Public Sub actualizar_preInforme()
        Dim pi As New dPreinformes
        pi.FICHA = Informe
        pi.ABONADO = abonado
        pi.COMENTARIO = comentario
        pi.COPIA = copia
        pi.PARASUBIR = 1
        pi.modificar2()
    End Sub

End Class