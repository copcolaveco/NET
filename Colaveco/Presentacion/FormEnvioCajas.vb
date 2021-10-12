Public Class FormEnvioCajas
    Dim email As String
    Dim celular As String
    Dim ecaja1 As String
    Dim eagencia As String
    Dim eremito As String
    Dim productorweb As String
    Private _usuario As dUsuario

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
        cargarComboAgencia()
        cargarComboResponsable()
        listarpedidos()
        Timer1.Enabled = True
        MsgBox("Recuerde cargar los pedidos automáticos, si es la primera vez en el día que carga esta pantalla!.")
        'CargarPedidosAutomaticos()
        'limpiar()
    End Sub
#End Region
    Public Sub cargarComboResponsable()
        Dim usu As New dUsuario
        Dim lista As New ArrayList
        lista = usu.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each usu In lista
                    ComboResponsable.Items.Add(usu)
                Next
            End If
        End If
        Dim us As dUsuario
        ComboResponsable.SelectedItem = Nothing
        For Each us In ComboResponsable.Items
            If us.ID = Usuario.ID Then
                ComboResponsable.SelectedItem = us
                Exit For
            End If
        Next
    End Sub
    Public Sub listarpedidos()
        Dim cantactual As Integer = ListPedidos.Items.Count
        Dim p As New dPedidos
        Dim lista As New ArrayList
        lista = p.listar

        ListPedidos.Items.Clear()
        If Not lista Is Nothing Then
            Dim cantnueva As Integer = lista.Count
            If lista.Count > 0 Then
                For Each p In lista
                    ListPedidos().Items.Add(p)
                Next
                If cantnueva > cantactual Then
                    My.Computer.Audio.Play("c:\debug\alarma.wav")
                End If
            End If
        End If
    End Sub
    
    Private Sub enviomail()
        Dim hora As Date = Now()
        Dim horaenvio As String
        Dim horaenvio2 As Integer
        horaenvio = Format(hora, "yyyy-MM-dd HH:mm:ss")
        horaenvio2 = Mid(horaenvio, 12, 2)
        Dim texto2 As String
        If horaenvio2 < 11 Then
            texto2 = "antes del mediodía"
        Else
            texto2 = "en la tarde"
        End If
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim p As New dProductor
        Dim pw_com As New dProductorWeb_com
        Dim env As New dEnvioCajas
        Dim ag As New dEmpresaT
        Dim texto As String

        Dim id As Long = CType(TextIdProductor.Text, Long)
        p.ID = Val(TextIdProductor.Text)
        p = p.buscar
        If Not p Is Nothing Then
            If Not p.USUARIO_WEB = "" Then
                pw_com.USUARIO = p.USUARIO_WEB
                pw_com = pw_com.buscar
                If Not pw_com Is Nothing Then
                    'TextProductor.Text = p.NOMBRE
                    email = RTrim(pw_com.ENVIAR_EMAIL)
                    celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                End If
                'If email = "" Or email = "no aportado" Then
                'idprod = TextIdProductor.Text.Trim
                'Dim v As New FormCompletarMail(Usuario)
                'v.ShowDialog()
                'If Not v.TextMail Is Nothing Then
                ' email = v.TextMail.Text.Trim
                'End If
                'End If
            End If
        End If
        eagencia = ComboAgencia.Text

        Dim idped As Long = CType(TextId.Text, Long)
        Dim lista As New ArrayList
        lista = env.listarporid(idped)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each env In lista
                    texto = texto & env.IDCAJA & ", "
                    eremito = env.ENVIO
                Next
            End If
        End If





        If email <> "" Then

            'CONFIGURACIÓN DEL STMP 
            '_SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(email)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Envío de cajas"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            If eremito <> "" Then
                _Message.Body = "Colaveco ha enviado" & " " & texto2 & ", " & "las siguientes cajas Nº " & texto & ", " & "por agencia" & " " & eagencia & ", " & "envío nº" & " " & eremito
            Else
                _Message.Body = "Colaveco ha enviado" & " " & texto2 & ", " & "las siguientes cajas Nº " & texto & ", " & "por agencia" & " " & eagencia
            End If
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
        Else
            MsgBox("Este cliente no tiene correo electrónico ingresado, por lo tanto no se le envía aviso.")
        End If
        email = ""
        ecaja1 = ""
        eagencia = ""
        eremito = ""
        texto = ""

    End Sub
    Private Sub enviosms()
        Dim num1 As String = ""
        Dim num2 As String = ""
        Dim email1 As String = ""
        Dim email2 As String = ""
        Dim sms As String = ""
        Dim sms1 As String = ""
        Dim sms2 As String = ""
        Dim cel1 As String = ""
        Dim cel2 As String = ""
        Dim largotexto As Integer = 0
        Dim celular1 As String = ""
        Dim celular2 As String = ""
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        'Dim texto As String = celular
        'Dim cantcaracteres As Integer = Len(texto)
        If celular <> "" Then
            largotexto = celular.Length
        End If

        Dim posicion As Integer
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        posicion = InStr(celular, ",")

        Dim env As New dEnvioCajas
        Dim ag As New dEmpresaT
        Dim hora As Date = Now()
        Dim horaenvio As String
        Dim horaenvio2 As Integer
        horaenvio = Format(hora, "yyyy-MM-dd HH:mm:ss")
        horaenvio2 = Mid(horaenvio, 12, 2)
        Dim texto As String
        Dim texto2 As String
        If horaenvio2 < 11 Then
            texto2 = "antes del mediodía"
        Else
            texto2 = "en la tarde"
        End If
        eagencia = ComboAgencia.Text
        Dim idped As Long = CType(TextId.Text, Long)
        Dim lista As New ArrayList
        lista = env.listarporid(idped)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each env In lista
                    texto = texto & env.IDCAJA & ", "
                    eremito = env.ENVIO
                Next
            End If
        End If

        If posicion > 0 Then
            posicion1 = posicion - 1
            posicion2 = posicion + 1
            cel1 = Mid(celular, 1, posicion1)
            cel2 = Mid(celular, posicion2, largotexto)

            'If Mid(cel1, 1, 2) = "09" Then
            '    celular1 = cel1.Remove(0, 2)
            'Else
            celular1 = cel1
            'End If

            email = celular1
            num1 = Mid(celular1, 3, 1)

            If num1 = "9" Or num1 = "8" Or num1 = "1" Then
                'ancel es numero (sin 09 inicial + pin)
                sms1 = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular1 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular1
                sms1 = email & "@sms.ctimovil.com.uy"
            End If
            '*****************************************
            'If Mid(cel2, 1, 2) = "09" Then
            '    celular2 = cel2.Remove(0, 2)
            'Else
            celular2 = cel2
            'End If

            email2 = celular2
            num2 = Mid(celular2, 1, 1)

            If num2 = "9" Or num2 = "8" Or num2 = "1" Then
                'ancel es numero (sin 09 inicial + pin)
                sms2 = email2 & "@antelinfo.com.uy"
            ElseIf num2 = "3" Or num2 = "4" Or num2 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.movistar.com.uy"
            ElseIf num2 = "6" Or num2 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular2, 1, 1) = "0" Then
                    celular2 = celular2.Remove(0, 1)
                End If
                email2 = celular2
                sms2 = email2 & "@sms.ctimovil.com.uy"
            End If
            sms = sms1 & "," & sms2
        Else


            'If Mid(celular, 1, 2) = "09" Then
            '    celular2 = celular.Remove(0, 2)
            'Else
            celular2 = celular
            'End If

            email = celular2
            num1 = Mid(celular2, 3, 1)

            If num1 = "9" Or num1 = "8" Or num1 = "1" Then
                'ancel es numero (sin 09 inicial + pin)
                sms = email & "@antelinfo.com.uy"
            ElseIf num1 = "3" Or num1 = "4" Or num1 = "5" Then
                'movistar es numero (sin 0 inicial + pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.movistar.com.uy"
            ElseIf num1 = "6" Or num1 = "7" Then
                'claro es numero (sin 0 inicial sin pin)
                If Mid(celular, 1, 1) = "0" Then
                    celular2 = celular.Remove(0, 1)
                End If
                email = celular2
                sms = email & "@sms.ctimovil.com.uy"
            End If

        End If


        Dim cantcaracteres As Integer = Len(texto)

        If sms <> "" Then

            'CONFIGURACIÓN DEL STMP 
            '_SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "colaveco1582782")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message.[To].Add(sms)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            If eremito <> "" Then
                _Message.Subject = "Colaveco ha enviado" & " " & texto2 & ", " & "las siguientes cajas número " & texto & ", " & "por agencia" & " " & eagencia & ", " & "envío nº" & " " & eremito & " (999 = conservadora)"
            Else
                _Message.Subject = "Colaveco ha enviado" & " " & texto2 & ", " & "las siguientes cajas número " & texto & ", " & "por agencia" & " " & eagencia & " (999 = conservadora)"
            End If
            '_Message.Subject = "Aviso! - Colaveco ha enviado su pedido de frascos."
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy"
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy"
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
                MessageBox.Show("Mensaje enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        Else
            MsgBox("Este cliente no tiene asignado un celular, por lo tanto no se le envía aviso de envío.")
        End If
        email = ""
        texto = ""

    End Sub
    
    Private Sub limpiar()
        'TextId.Text = ""
        'DateFecha.Value = Now
        'TextIdProductor.Text = ""
        'TextProductor.Text = ""
        TextCaja.Text = ""
        TextGradilla1.Text = ""
        TextGradilla2.Text = ""
        TextGradilla3.Text = ""
        TextFrascos.Text = ""
        'ComboAgencia.Text = ""
        TextEnvio.Text = ""
    End Sub
    Private Sub limpiar2()
        TextId.Text = ""
        DateFecha.Value = Now
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        TextCaja.Text = ""
        TextGradilla1.Text = ""
        TextGradilla2.Text = ""
        TextFrascos.Text = ""
        ComboAgencia.Text = ""
        TextEnvio.Text = ""
        ListCajas.Items.Clear()
        listarpedidos()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormBuscarProductor
        v.ShowDialog()

        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdProductor.Text = pro.ID
            TextProductor.Text = pro.NOMBRE
            email = pro.EMAIL1
            TextCaja.Focus()
        End If
    End Sub
    Public Sub cargarComboAgencia()
        Dim et As New dEmpresaT
        Dim lista As New ArrayList
        lista = et.listar
        ComboAgencia.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each et In lista
                    ComboAgencia.Items.Add(et)
                Next
            End If
        End If
    End Sub


    Private Sub ListPedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPedidos.SelectedIndexChanged
        limpiar()
        If ListPedidos.SelectedItems.Count = 1 Then
            Dim ped As dPedidos = CType(ListPedidos.SelectedItem, dPedidos)
            TextId.Text = ped.ID
            DateFecha.Value = ped.FECHA
            DateFechaposEnvio.Value = ped.FECHAPOSENVIO
            Dim p As New dProductor
            TextIdProductor.Text = ped.IDPRODUCTOR
            Dim id As Long = CType(TextIdProductor.Text, Long)
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE
            End If
            TextDireccion.Text = ped.DIRECCION
            TextTelefono.Text = ped.TELEFONO
            '**********************************************************************************
            If p.MOROSO = 1 Then
                MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
                TextIdProductor.Text = ""
                TextProductor.Text = ""
                TextDireccion.Text = ""
                TextTelefono.Text = ""
                Exit Sub
            End If
            '**********************************************************************************
            Dim et As dEmpresaT
            ComboAgencia.SelectedItem = Nothing
            For Each et In ComboAgencia.Items
                If et.ID = ped.IDAGENCIA Then
                    ComboAgencia.SelectedItem = et
                    Exit For
                End If
            Next
            If ped.IDAGENCIA = 7 Then
                TextEnvio.Text = "sin comprobante"
            End If
            TextRC_compos.Text = ped.RC_COMPOS
            TextAgua.Text = ped.AGUA
            TextSangre.Text = ped.SANGRE
            TextEsteriles.Text = ped.ESTERILES
            TextOtros.Text = ped.OTROS
            TextObservaciones.Text = ped.OBSERVACIONES
        End If
        listarcajasporid()
    End Sub

    Private Sub TextCaja_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCaja.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGradilla1.Focus()
        End If
    End Sub

    Private Sub TextGradilla1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGradilla2.Focus()
        End If
    End Sub

    Private Sub TextGradilla2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla2.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextGradilla3.Focus()
        End If
    End Sub
    Private Sub TextGradilla3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextGradilla3.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextFrascos.Focus()
        End If
    End Sub

    Private Sub TextFrascos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFrascos.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            TextEnvio.Focus()
        End If
    End Sub

    Private Sub TextEnvio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextEnvio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If TextCaja.Text <> 0 Then
                matarcaja()
            End If
            guardar()
        End If
    End Sub
    Private Sub matarcaja()
        Dim ec As New dEnvioCajas
        Dim lista As New ArrayList
        Dim fecharecibo As Date = Now
        Dim fec As String
        fec = Format(fecharecibo, "yyyy-MM-dd")
        Dim idcaja As Integer = TextCaja.Text.Trim

        lista = ec.listarxcajasindevolver(idcaja)

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim ec2 As New dEnvioCajas
                For Each ec In lista
                    ec2.ID = ec.ID
                    ec2.IDAGENCIA = 8
                    ec2.RECIBO = "s/n"
                    ec2.FECHARECIBO = fec
                    ec2.OBSRECIBO = "Caja matada en envío"
                    ec2.RECIBIDO = 1

                    If (ec2.marcarrecibido(Usuario)) Then
                        'MsgBox("Caja recibida", MsgBoxStyle.Information, "Atención")
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Next
            End If
        End If


        
       
        
        




    End Sub
    Sub guardar()
        Dim id As Long
        Dim idpedido As Long = TextId.Text.Trim
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idcaja As Integer = TextCaja.Text.Trim
        Dim gradilla1 As Integer
        If TextGradilla1.Text <> "" Then
            gradilla1 = TextGradilla1.Text.Trim
        End If
        Dim gradilla2 As Integer
        If TextGradilla2.Text <> "" Then
            gradilla2 = TextGradilla2.Text.Trim
        End If
        Dim gradilla3 As Integer
        If TextGradilla3.Text <> "" Then
            gradilla3 = TextGradilla3.Text.Trim
        End If
        Dim frascos As Integer = TextFrascos.Text.Trim
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim envio As String = TextEnvio.Text.Trim
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        Dim observaciones As String = TextObservacionesE.Text.Trim
        Dim responsable As dUsuario = CType(ComboResponsable.SelectedItem, dUsuario)
        If Not ListCajas.SelectedItem Is Nothing Then
            Dim env As New dEnvioCajas()
            If TextCaja.Text.Trim.Length > 0 Then
                Dim fec As String
                fec = Format(fechaenvio, "yyyy-MM-dd")
                id = TextIdEnvio.Text.Trim
                env.ID = id
                env.IDPEDIDO = idpedido
                env.IDPRODUCTOR = idproductor
                env.IDCAJA = idcaja
                env.GRADILLA1 = gradilla1
                env.GRADILLA2 = gradilla2
                env.GRADILLA3 = gradilla3
                env.FRASCOS = frascos
                env.IDEMPRESA = agencia.ID
                env.ENVIO = envio
                env.FECHAENVIO = fec
                env.OBSERVACIONES = observaciones
                env.ENVIADO = 0
                env.RESPONSABLE = responsable.ID
            End If
            If (env.modificar(Usuario)) Then
                MsgBox("Caja modificada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextCaja.Text.Trim.Length > 0 Then
                Dim env As New dEnvioCajas()
                Dim fec As String
                fec = Format(fechaenvio, "yyyy-MM-dd")
                env.IDPEDIDO = idpedido
                env.IDPRODUCTOR = idproductor
                env.IDCAJA = idcaja
                env.GRADILLA1 = gradilla1
                env.GRADILLA2 = gradilla2
                env.GRADILLA3 = gradilla3
                env.FRASCOS = frascos
                env.IDEMPRESA = agencia.ID
                env.ENVIO = envio
                env.FECHAENVIO = fec
                env.OBSERVACIONES = observaciones
                env.ENVIADO = 0
                env.IDAGENCIA = 0
                'env.FECHARECIBO = fec
                env.RECIBIDO = 0
                env.RESPONSABLE = responsable.ID
                If (env.guardar(Usuario)) Then
                    MsgBox("Caja guardada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        listarcajasporid()
    End Sub
    Public Sub listarcajas()
        Dim e As New dEnvioCajas
        Dim lista As New ArrayList
        lista = e.listar
        ListCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each e In lista
                    ListCajas().Items.Add(e)
                Next
            End If
        End If
    End Sub
    Public Sub listarcajasporid()
        Dim e As New dEnvioCajas
        Dim lista As New ArrayList
        Dim texto As Long = TextId.Text.Trim
        lista = e.listarporid(texto)
        ListCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each e In lista
                    ListCajas().Items.Add(e)
                Next
            End If
        End If
    End Sub
    Private Sub ListCajas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListCajas.SelectedIndexChanged
        limpiar()
        If ListCajas.SelectedItems.Count = 1 Then
            Dim env As dEnvioCajas = CType(ListCajas.SelectedItem, dEnvioCajas)
            TextIdEnvio.Text = env.ID
            TextCaja.Text = env.IDCAJA
            TextGradilla1.Text = env.GRADILLA1
            TextGradilla2.Text = env.GRADILLA2
            TextGradilla3.Text = env.GRADILLA3
            TextFrascos.Text = env.FRASCOS
            Dim et As dEmpresaT
            ComboAgencia.SelectedItem = Nothing
            For Each et In ComboAgencia.Items
                If et.ID = env.IDEMPRESA Then
                    ComboAgencia.SelectedItem = et
                    Exit For
                End If
            Next
            TextEnvio.Text = env.ENVIO
            DateFechaEnvio.Value = env.FECHAENVIO
            TextObservacionesE.Text = env.OBSERVACIONES
            TextCaja.Focus()
        End If
    End Sub

    

    Private Sub ButtonBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBorrar.Click
        If Not ListCajas.SelectedItem Is Nothing Then
            Dim ec As New dEnvioCajas
            Dim id As Long = CType(TextIdEnvio.Text, Long)
            ec.ID = id
            If (ec.eliminar(Usuario)) Then
                MsgBox("Caja eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        listarcajasporid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnvio.Click
        Dim p As New dPedidos
        Dim env As New dEnvioCajas
        Dim id As Integer = TextId.Text.Trim
        p.ID = id
        env.ID = id
        p.marcarEnvio(p.ID, Usuario)
        env.marcarEnvio(env.ID, Usuario)
        enviomail()
        enviosms()
        limpiar2()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        listarpedidos()
    End Sub

    
    Private Sub CargarPedidosAutomaticos()
        Dim pa As New dPedidosAuto
        Dim p As New dPedidos
        Dim contador As Integer
        Dim lista As New ArrayList
        Dim fecha As Date = Now()
        Dim fec As String
        fec = Format(fecha, "yyyy-MM-dd")
        Dim diaactual As Integer = Mid(fec, 9, 2)

        For i = 1 To 5
            lista = pa.listarpordia(diaactual)

            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each pa In lista
                        'ListPedidos().Items.Add(p)
                        p.FECHA = fec
                        p.FECHAPOSENVIO = fec
                        p.IDPRODUCTOR = pa.IDPRODUCTOR
                        p.DIRECCION = pa.DIRECCION
                        p.TELEFONO = pa.TELEFONO
                        p.IDAGENCIA = pa.IDAGENCIA
                        p.IDTECNICO = pa.IDTECNICO
                        p.RC_COMPOS = pa.RC_COMPOS
                        p.AGUA = pa.AGUA
                        p.SANGRE = pa.SANGRE
                        p.ESTERILES = pa.ESTERILES
                        p.OTROS = pa.OTROS
                        p.OBSERVACIONES = pa.OBSERVACIONES
                        p.FACTURA1 = pa.FACTURA
                        If (p.guardar(Usuario)) Then
                            'MsgBox("Pedido guardado", MsgBoxStyle.Information, "Atención")
                            'limpiar()
                            pa.marcarEnvio(pa.ID, Usuario)
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    Next
                End If
            End If
            listarpedidos()
            diaactual = diaactual - 1
        Next i

        diaactual = Mid(fec, 9, 2)
        If diaactual >= 10 Then
            contador = 1
            For i = 1 To 5
                pa.desmarcarEnvio(contador, Usuario)
                contador = contador + 1
            Next
        End If
        If diaactual >= 15 Then
            contador = 5
            For i = 1 To 5
                pa.desmarcarEnvio(contador, Usuario)
                contador = contador + 1
            Next
        End If
        If diaactual >= 20 Then
            contador = 10
            For i = 1 To 5
                pa.desmarcarEnvio(contador, Usuario)
                contador = contador + 1
            Next
        End If
        If diaactual >= 25 Then
            contador = 15
            For i = 1 To 5
                pa.desmarcarEnvio(contador, Usuario)
                contador = contador + 1
            Next
        End If
        If diaactual >= 30 Then
            contador = 20
            For i = 1 To 5
                pa.desmarcarEnvio(contador, Usuario)
                contador = contador + 1
            Next
        End If
        If diaactual >= 5 Then
            contador = 24
            For i = 1 To 7
                pa.desmarcarEnvio(contador, Usuario)
                contador = contador + 1
            Next
        End If
    End Sub

    
    Private Sub TextEnvio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextEnvio.TextChanged

    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListPedidos.SelectedItem Is Nothing Then
            If MsgBox("El pedido será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim p As New dPedidos
                Dim id As Long = CType(TextId.Text, Long)
                p.ID = id
                If (p.eliminar(Usuario)) Then
                    MsgBox("Pedido eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar2()
        listarpedidos()
    End Sub

    Private Sub TextGradilla1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextGradilla1.TextChanged

    End Sub

    Private Sub ComboAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAgencia.SelectedIndexChanged
        If ComboAgencia.Text = "RETIRA EN COLAVECO" Then
            TextEnvio.Text = "sin comprobante"
        Else
            TextEnvio.Text = ""
        End If
    End Sub

    Private Sub ButtonCargarPedidosAutomaticos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCargarPedidosAutomaticos.Click
        CargarPedidosAutomaticos()
    End Sub

    Private Sub TextCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCaja.TextChanged

    End Sub
End Class
