Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Imports Newtonsoft.Json
Public Class FormEnvioCajas
    Dim email As String
    Dim email2 As String
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
        cargarComboCajas()
        cargarComboAgencia()
        cargarComboResponsable()
        cargarComboProlesa()
        listarpedidos()
        contarpedidos()
        Timer1.Enabled = True
        Timer2.Enabled = True
        MsgBox("Recuerde cargar los pedidos automáticos, si es la primera vez en el día que carga esta pantalla!.")
        'CargarPedidosAutomaticos()
        'limpiar()
    End Sub
#End Region

    Public Sub cargarComboCajas()
        Dim c As New dCajas
        Dim lista As New ArrayList
        lista = c.listarenLaboratorio
        ComboCajas.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each c In lista
                    ComboCajas.Items.Add(c)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboProlesa()
        Dim p As New dProlesa
        Dim lista As New ArrayList
        lista = p.listar
        ComboProlesa.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ComboProlesa.Items.Add(p)
                Next
            End If
        End If
    End Sub
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
        Dim urgente As Integer = 0
        Dim p As New dPedidos
        Dim lista As New ArrayList
        lista = p.listar

        ListPedidos.Items.Clear()
        If Not lista Is Nothing Then
            Dim cantnueva As Integer = lista.Count
            If lista.Count > 0 Then
                For Each p In lista
                    ListPedidos().Items.Add(p)
                    If p.IDAGENCIA = 13 Then
                        urgente = 1
                    Else
                        urgente = 0
                    End If
                Next
                If cantnueva > cantactual Then
                    My.Computer.Audio.Play("c:\debug\alarma.wav")
                End If
            End If
        End If
    End Sub
    Public Sub listarpedidos2()
        Dim cantactual As Integer = ListPedidos.Items.Count
        Dim urgente As Integer = 0
        Dim nombre As String = ""
        Dim p As New dPedidos
        Dim lista As New ArrayList
        lista = p.listar
        If Not lista Is Nothing Then
            Dim cantnueva As Integer = lista.Count
            If lista.Count > 0 Then
                For Each p In lista
                    If p.IDAGENCIA = 13 Then
                        urgente = 1
                        Dim pro As New dCliente
                        pro.ID = p.IDPRODUCTOR
                        pro = pro.buscar
                        If Not pro Is Nothing Then
                            nombre = pro.NOMBRE
                        End If
                    End If
                Next
                If urgente = 1 Then
                    Timer2.Enabled = False
                    Dim v As New FormPedidoUrgente(nombre)
                    v.ShowDialog()
                    listarpedidos()
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
        'Dim texto2 As String
        'If horaenvio2 < 11 Then
        '    texto2 = "antes del mediodía"
        'Else
        '    texto2 = "en la tarde"
        'End If
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim c As New dCliente
        Dim pw_com As New dProductorWeb_com
        Dim env As New dEnvioCajas
        Dim ag As New dEmpresaT
        Dim texto As String = ""
        Dim id As Long = CType(TextIdProductor.Text, Long)
        c.ID = Val(TextIdProductor.Text)
        c = c.buscar
        If Not c Is Nothing Then
            email = ""
            email2 = ""
            If c.NOT_EMAIL_FRASCOS1 <> "" Then
                email = RTrim(c.NOT_EMAIL_FRASCOS1)
            End If
            If c.NOT_EMAIL_FRASCOS2 <> "" Then
                email2 = RTrim(c.NOT_EMAIL_FRASCOS2)
            End If
            If email = "" Then
                If email2 = "" Then
                    If c.EMAIL <> "" Then
                        email = RTrim(c.EMAIL)
                    End If
                Else
                    email = email2
                End If
            Else
                If email2 = "" Then
                    email = email
                Else
                    email = email & "," & email2
                End If
            End If
            If Not c.USUARIO_WEB = "" Then
                pw_com.USUARIO = c.USUARIO_WEB
                pw_com = pw_com.buscar
                If Not pw_com Is Nothing Then
                    celular = Replace(pw_com.ENVIAR_SMS, " ", "")
                End If
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
        If email <> "" And email <> "no aportado" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "CLV19912021Colaveco30")
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
            'If eremito <> "" Then
            '    _Message.Body = "Colaveco envia" & " " & texto2 & ", " & "las siguientes cajas Nº " & texto & ", " & "por agencia" & " " & eagencia & ", " & "envío nº" & " " & eremito
            'Else
            _Message.Body = "Colaveco tiene preparadas la/s siguiente/s caja/s Nº " & texto & "listas para retirar. Costo del flete a cargo del Productor."
            'End If
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
        Dim texto As String = ""
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
            celular1 = cel1
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
            celular2 = cel2
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
            celular2 = celular
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
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "CLV19912021Colaveco30")
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
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy/gestor"
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio http://www.colaveco.com.uy/gestor"
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
        cargarComboCajas()
        'comboCajas.Text=""
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
        TextObservacionesE.Text = ""
        CheckPendiente.Checked = False
        ListCajas.Items.Clear()
        listarpedidos()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
            email = cli.EMAIL1
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
            DateFechaPosEnvio.Value = ped.FECHAPOSENVIO
            Dim p As New dCliente
            TextIdProductor.Text = ped.IDPRODUCTOR
            Dim id As Long = CType(TextIdProductor.Text, Long)
            p.ID = Val(TextIdProductor.Text)
            p = p.buscar
            If Not p Is Nothing Then
                TextProductor.Text = p.NOMBRE
            End If
            TextDireccion.Text = ped.DIRECCION
            TextTelefono.Text = ped.TELEFONO
            If ped.CONVENIO <> 0 Then
                MsgBox("El envío es por PROLESA!")
            End If
            Dim pro As dProlesa
            ComboProlesa.SelectedItem = Nothing
            For Each pro In ComboProlesa.Items
                If pro.ID = ped.CONVENIO Then
                    ComboProlesa.SelectedItem = pro
                    Exit For
                End If
            Next

            'Controla si debe cajas **************************************
            Dim ec As New dEnvioCajas
            Dim listacajas As New ArrayList
            Dim idpro As Long = 0
            Dim listadodecajas As String = ""
            idpro = p.ID
            listacajas = ec.listarxcliente(idpro)
            If Not listacajas Is Nothing Then
                If listacajas.Count > 0 Then
                    For Each ec In listacajas
                        listadodecajas = listadodecajas & ec.IDCAJA & "  "
                    Next
                End If
            End If
            If listadodecajas <> "" Then
                MsgBox("El cliente debe las siguientes cajas: " & listadodecajas)
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
            TextUsuarioCreador.Text = ""
            Dim u As New dUsuario
            u.ID = ped.IDUSUARIO
            u = u.buscar
            If Not u Is Nothing Then
                TextUsuarioCreador.Text = u.NOMBRE
            End If

            If ped.PENDIENTE = 1 Then
                CheckPendiente.Checked = True
                ComboCajas.Enabled = False
                ButtonEnvio.Enabled = False
            Else
                CheckPendiente.Checked = False
                ComboCajas.Enabled = True
                ButtonEnvio.Enabled = True
            End If
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
            guardar()
            limpiar()
            listarcajasporid()
        End If
    End Sub
    Private Sub matarcaja()
        Dim ec As New dEnvioCajas
        Dim lista As New ArrayList
        Dim fecharecibo As Date = Now
        Dim fec As String
        fec = Format(fecharecibo, "yyyy-MM-dd")
        Dim idcaja As String = ComboCajas.Text.Trim
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
        Dim v As New FormIngresarUsuario
        v.ShowDialog()
        Dim responsable As Integer = idusuario1
        Dim id As Long
        Dim idpedido As Long = TextId.Text.Trim
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idcaja As String = ComboCajas.Text.Trim
        Dim gradilla1 As String = ""
        If TextGradilla1.Text <> "" Then
            gradilla1 = TextGradilla1.Text.Trim
        End If
        Dim gradilla2 As String = ""
        If TextGradilla2.Text <> "" Then
            gradilla2 = TextGradilla2.Text.Trim
        End If
        Dim gradilla3 As String = ""
        If TextGradilla3.Text <> "" Then
            gradilla3 = TextGradilla3.Text.Trim
        End If
        If TextFrascos.Text = "" Then
            MsgBox("Debe ingresar la cantidad de frascos!")
            Exit Sub
        End If
        Dim frascos As Integer = TextFrascos.Text.Trim
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim envio As String = TextEnvio.Text.Trim
        Dim fechaenvio As Date = DateFechaEnvio.Value.ToString("yyyy-MM-dd")
        Dim observaciones As String = TextObservacionesE.Text.Trim
        Dim prolesa As dProlesa = CType(ComboProlesa.SelectedItem, dProlesa)
        Dim idprolesa As Integer = 0
        If Not prolesa Is Nothing Then
            idprolesa = prolesa.ID
        End If
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
                env.RESPONSABLE = responsable
                env.CONVENIO = idprolesa
            End If
            If (env.modificar(Usuario)) Then
                MsgBox("Caja modificada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If ComboCajas.Text.Trim.Length > 0 Then
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
                env.RECIBIDO = 0
                env.RESPONSABLE = responsable
                env.CONVENIO = idprolesa
                If (env.guardar(Usuario)) Then
                    MsgBox("Caja guardada", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
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
            Dim idcaja As String = TextCaja.Text
            ec.ID = id
            If (ec.eliminar(Usuario)) Then
                Dim c As New dCajas
                c.CODIGO = idcaja
                c.marcarLaboratorio(Usuario)
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
        env.marcarEnvio(env.ID, Usuario)
        p.marcarEnvio(p.ID, Usuario)
        If ComboAgencia.Text = "RETIRA EN COLAVECO" Or ComboAgencia.Text = "Retira ahora" Then
            enviomail()
            enviar_notificacion_envio()
            p.marcar(p.ID, Usuario)
        End If
        limpiar2()
        Timer2.Enabled = True
    End Sub
    Private Sub enviar_notificacion_envio()
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        Dim notificacion As New Dictionary(Of String, dNotificaciones)
        Dim nt As New dNotificaciones
        Dim _tipo As String = ""
        Dim _mensaje As String = ""
        Dim nuevoid As Long = CType(TextIdProductor.Text, Long)
        Dim _detalle As String = ""
        Dim _detalle_envio As String = ""
        Dim eagencia As String = ComboAgencia.Text
        If eagencia = "RETIRA EN COLAVECO" Then
            _mensaje = "Su pedido de frascos está pronto para retirar en Colaveco"
        ElseIf eagencia = "Retira ahora" Then
            _mensaje = "Su pedido de frascos está pronto para retirar en Colaveco"
        Else
            _mensaje = "Su pedido de frascos está pronto para despachar por " & eagencia
        End If
        _tipo = "envio_frasco"
        Dim env As New dEnvioCajas
        Dim idped As Long = CType(TextId.Text, Long)
        Dim lista As New ArrayList
        lista = env.listarporid(idped)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each env In lista
                    _detalle_envio = _detalle_envio & env.IDCAJA & ", "
                Next
            End If
        End If
        _detalle = "<p><b>Fecha de despacho:</b> " + _fecha + " </p><p><b>Agencia:</b> " + eagencia + " </p><p><b>Destino:</b> " + TextDireccion.Text + " </p><p><b>Detalle de Envio:</b> " + _detalle_envio + " </p>"
        nt.fecha = _fecha
        nt.tipo = _tipo
        nt.mensaje = _mensaje
        nt.idnet_usuario = nuevoid
        nt.detalle = _detalle
        notificacion.Add("notification", nt)
        Dim parameters As String = JsonConvert.SerializeObject(notificacion, Formatting.None)
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/notifications", "POST", parameters, status)
    End Sub
    Public Function PostResponse(ByVal url As String, ByVal metodo As String, ByVal content As String, ByRef statusCode As HttpStatusCode) As Byte()
        Dim responseFromServer As Byte() = Nothing
        Dim dataStream As Stream = Nothing
        Try
            Dim request As WebRequest = WebRequest.Create(url)
            request.Timeout = 120000
            request.Method = metodo
            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(content)
            request.ContentType = "application/json"
            request.ContentLength = byteArray.Length
            dataStream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            dataStream = response.GetResponseStream()
            Dim ms As New MemoryStream()
            Dim thisRead As Integer = 0
            Dim buff As Byte() = New Byte(1023) {}
            Do
                thisRead = dataStream.Read(buff, 0, buff.Length)
                If thisRead = 0 Then
                    Exit Do
                End If
                ms.Write(buff, 0, thisRead)
            Loop While True
            responseFromServer = ms.ToArray()
            dataStream.Close()
            response.Close()
            statusCode = HttpStatusCode.OK
        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                dataStream = ex.Response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim resp As String = reader.ReadToEnd()
                statusCode = DirectCast(ex.Response, HttpWebResponse).StatusCode
            Else
                Dim resp As String = ""
                statusCode = HttpStatusCode.ExpectationFailed
            End If
        Catch ex As Exception
            statusCode = HttpStatusCode.ExpectationFailed
        End Try
        Return responseFromServer
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ComboCajas.Text <> "" Then 'And ListCajas.Items.Count = 0 Then
            'If ListCajas.Items.Count > 0 Then
        Else
            listarpedidos()
            contarpedidos()
            cargarComboCajas()
            DateFechaEnvio.Value = Now
        End If
    End Sub
    Private Sub contarpedidos()
        Dim fecha As Date = Now
        Dim fecha2 As Date = DateAdd(DateInterval.Day, 1, fecha)
        Dim fecha3 As Date = DateAdd(DateInterval.Day, 2, fecha)
        Dim fecha4 As Date = DateAdd(DateInterval.Day, 3, fecha)
        Dim fecha5 As Date = DateAdd(DateInterval.Day, 4, fecha)
        Dim fec As String
        Dim fec2 As String
        Dim fec3 As String
        Dim fec4 As String
        Dim fec5 As String
        fec = Format(fecha, "yyyy-MM-dd")
        fec2 = Format(fecha2, "yyyy-MM-dd")
        fec3 = Format(fecha3, "yyyy-MM-dd")
        fec4 = Format(fecha4, "yyyy-MM-dd")
        fec5 = Format(fecha5, "yyyy-MM-dd")
        Dim lista As New ArrayList
        Dim lista2 As New ArrayList
        Dim lista3 As New ArrayList
        Dim lista4 As New ArrayList
        Dim lista5 As New ArrayList
        Dim p As New dPedidos
        Dim p2 As New dPedidos
        Dim p3 As New dPedidos
        Dim p4 As New dPedidos
        Dim p5 As New dPedidos
        lista = p.listarporfecharc(fec, fec)
        lista2 = p2.listarporfecharc(fec2, fec2)
        lista3 = p3.listarporfecharc(fec3, fec3)
        lista4 = p4.listarporfecharc(fec4, fec4)
        lista5 = p5.listarporfecharc(fec5, fec5)
        Dim contador As Integer = 0
        Dim contador2 As Integer = 0
        Dim contador3 As Integer = 0
        Dim contador4 As Integer = 0
        Dim contador5 As Integer = 0
        If Not lista Is Nothing Then
            For Each p In lista
                contador = contador + p.RC_COMPOS
            Next
        End If
        If Not lista2 Is Nothing Then
            For Each p2 In lista2
                contador2 = contador2 + p2.RC_COMPOS
            Next
        End If
        If Not lista3 Is Nothing Then
            For Each p3 In lista3
                contador3 = contador3 + p3.RC_COMPOS
            Next
        End If
        If Not lista4 Is Nothing Then
            For Each p4 In lista4
                contador4 = contador4 + p4.RC_COMPOS
            Next
        End If
        If Not lista5 Is Nothing Then
            For Each p5 In lista5
                contador5 = contador5 + p5.RC_COMPOS
            Next
        End If
        DataGridView1.Rows.Clear()
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        DataGridView1.Rows.Add(5)
        DataGridView1(columna, fila).Value = fecha
        columna = columna + 1
        DataGridView1(columna, fila).Value = contador
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = fecha2
        columna = columna + 1
        DataGridView1(columna, fila).Value = contador2
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = fecha3
        columna = columna + 1
        DataGridView1(columna, fila).Value = contador3
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = fecha4
        columna = columna + 1
        DataGridView1(columna, fila).Value = contador4
        columna = 0
        fila = fila + 1
        DataGridView1(columna, fila).Value = fecha5
        columna = columna + 1
        DataGridView1(columna, fila).Value = contador5
        columna = 0
        fila = fila + 1
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
                            pa.marcarEnvio(pa.ID, Usuario)
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    Next
                End If
            End If
            'listarpedidos()
            diaactual = diaactual + 1
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
        listarpedidos()
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
    Private Sub ComboAgencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAgencia.SelectedIndexChanged
        If ComboAgencia.Text = "RETIRA EN COLAVECO" Then
            TextEnvio.Text = "sin comprobante"
        Else
            TextEnvio.Text = ""
        End If
    End Sub
    Private Sub ButtonCargarPedidosAutomaticos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarPedidosAutomaticos()
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If ComboCajas.Text = "" Then 'And ListCajas.Items.Count = 0 Then
            listarpedidos2()
        End If
    End Sub

    Private Sub TextEnvio_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEnvio.Leave

    End Sub

    Private Sub TextEnvio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextEnvio.TextChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListarPedidos.Click
        listarpedidos()
    End Sub

    Private Sub ActualizarCajasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarCajasToolStripMenuItem.Click

    End Sub
    Private Sub actualizar_cajas()
        Dim c As New dCajas
        Dim fecha As Date
        Dim fec As String = ""
        Dim lista_cajas As New ArrayList
        lista_cajas = c.listar
        For Each c In lista_cajas
            Dim ec As New dEnvioCajas
            ec.IDCAJA = c.CODIGO
            ec = ec.buscarultimoenvioxcaja
            If Not ec Is Nothing Then
                Dim c2 As New dCajas
                c2.CODIGO = ec.IDCAJA
                If ec.RECIBIDO = 1 Then
                    c2.ESTADO = 1
                    c2.IDCLIENTE = -1
                    fecha = ec.FECHARECIBO
                    fec = Format(fecha, "yyyy-MM-dd")
                    c2.FECHA = fec
                Else
                    If ec.IDCAJA = "Cons-Devolución" Or ec.IDCAJA = "Caja-Devolución" Or ec.IDCAJA = "Bolsa" Or ec.IDCAJA = "Gradilla" Or ec.IDCAJA = "Frasco de agua" Then
                        c2.ESTADO = 1
                        c2.IDCLIENTE = -1
                        fecha = ec.FECHAENVIO
                        fec = Format(fecha, "yyyy-MM-dd")
                        c2.FECHA = fec
                    Else
                        c2.ESTADO = 2
                        c2.IDCLIENTE = ec.IDPRODUCTOR
                        fecha = ec.FECHAENVIO
                        fec = Format(fecha, "yyyy-MM-dd")
                        c2.FECHA = fec
                    End If

                End If
                c2.modificar2()
                c2 = Nothing
            End If
            ec = Nothing
        Next
        MsgBox("Cajas actualizadas!")
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        contarpedidos()
    End Sub

    Private Sub CheckPendiente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPendiente.CheckedChanged
      
    End Sub

    Private Sub CheckPendiente_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CheckPendiente.MouseClick
        Dim idpedido As Long = 0
        Dim pendiente As Integer = 0
        If TextId.Text <> "" Then
            idpedido = TextId.Text.Trim
            Dim p As New dPedidos
            p.ID = idpedido
            p = p.buscar
            If Not p Is Nothing Then
                If p.PENDIENTE = 0 Then
                    p.marcarpendiente(idpedido, Usuario)
                    Dim v As New FormPedidosPendientes(Usuario, idpedido)
                    v.ShowDialog()
                    listarpedidos()
                Else
                    p.desmarcarpendiente(idpedido, Usuario)
                    listarpedidos()
                End If
            End If
        End If
    End Sub

    Private Sub ActualizarCajasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizarCajasToolStripMenuItem1.Click
        actualizar_cajas()
    End Sub

    Private Sub CargarPedidosAutomáticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarPedidosAutomáticosToolStripMenuItem.Click
        Dim v As New FormCargarPedidosAutomaticos(Usuario)
        v.ShowDialog()
    End Sub

    Private Sub TextFrascos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFrascos.LostFocus
        Dim f As Integer = 0
        Dim c As String = ""
        Dim texto As String = ""
        f = TextFrascos.Text
        c = ComboCajas.Text
        If f = 210 Then
            texto = Mid(c, 1, 4)
            If texto = "Cons" Then
                MsgBox("Conservadoras no llevan 210 frascos!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TextFrascos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFrascos.TextChanged

    End Sub
End Class
