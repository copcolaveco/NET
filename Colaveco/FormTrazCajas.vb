Public Class FormTrazCajas
    Dim email As String
    Dim ecaja1 As String
    Dim eagencia As String
    Dim eremito As String
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
        listarpedidos()
        'cargarComboLocalidad()
        'limpiar()
    End Sub
#End Region
    Public Sub listarpedidos()
        Dim p As New dPedidos
        Dim lista As New ArrayList
        lista = p.listar
        ListPedidos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ListPedidos().Items.Add(p)
                Next
            End If
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub enviarmail()
        Dim miCorreo As New System.Net.Mail.MailMessage

        miCorreo.IsBodyHtml = False
        miCorreo.From = New System.Net.Mail.MailAddress("computos@colaveco.com")
        'miCorreo.From = "info@solovb.net" 'mail desde donde se envía
        miCorreo.To.Add("usuario@hotmail.com") 'Mail del destinatario
        miCorreo.Subject = "Mensaje de prueba desde aplicación windows [solovb.net]" 'Asunto

        miCorreo.Body = "abc abc abc" 'TextBox1.Text 'Cuerpo del mensaje

        miCorreo.Priority = System.Net.Mail.MailPriority.Normal 'Prioridad

        Dim smtp As New System.Net.Mail.SmtpClient

        smtp.Host = "mail.colaveco.com"
        'para las credenciales debo pasarle la cuenta y la clave desde donde se envía
        smtp.Credentials = New System.Net.NetworkCredential("computos@colaveco.com", "trinidad")
        Try
            smtp.Send(miCorreo)
            MsgBox("Mensaje enviado.", MsgBoxStyle.OkOnly, "colaveco.com")
        Catch ex As Exception
            'MsgBox("ERROR: " &amp; ex.Message, MsgBoxStyle.OkOnly, "Error!")
        End Try
    End Sub
    Private Sub enviomail()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        'CONFIGURACIÓN DEL STMP 
        _SMTP.Credentials = New System.Net.NetworkCredential("pepobaez@gmail.com", "ps281198")
        _SMTP.Host = "smtp.gmail.com"
        _SMTP.Port = 587 '465
        _SMTP.EnableSsl = True
        ' CONFIGURACION DEL MENSAJE 
        '_Message.[To].Add("computos@colaveco.com")
        _Message.[To].Add(email)
        'Cuenta de Correo al que se le quiere enviar el e-mail 
        _Message.From = New System.Net.Mail.MailAddress("pepobaez@gmail.com", "Pepo", System.Text.Encoding.UTF8)
        'Quien lo envía 
        _Message.Subject = "Envío de cajas"
        'Sujeto del e-mail 
        _Message.SubjectEncoding = System.Text.Encoding.UTF8
        'Codificacion 
        _Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
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
        email = ""
        ecaja1 = ""
        eagencia = ""
        eremito = ""
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim estado As String = 0
        Dim fec As String
        Dim fecha As Date
        fecha = DateFecha.Value
        fec = Format(fecha, "yyyy-MM-dd")
        Dim idproductor As Long = TextIdProductor.Text.Trim
        Dim idcaja As Integer = TextCaja.Text.Trim
        ecaja1 = TextCaja.Text.Trim
        Dim armazones As Integer = TextArmazones.Text.Trim
        Dim gradillas As Integer = TextGradillas.Text.Trim
        Dim frascos As Integer = TextFrascos.Text.Trim
        Dim empresa As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        eagencia = ComboAgencia.Text.Trim
        Dim envio As String = TextEnvio.Text.Trim
        eremito = TextEnvio.Text.Trim
        If TextId.Text.Trim.Length > 0 Then
            Dim t As New dTrazCajas()
            Dim id As Long = TextId.Text.Trim
            t.ID = id
            t.ESTADO = estado
            t.FECHA = fec
            t.IDPRODUCTOR = idproductor
            t.IDCAJA = idcaja
            t.ARMAZONES = armazones
            t.GRADILLAS = gradillas
            t.FRASCOS = frascos
            t.IDEMPRESA = empresa.ID
            t.ENVIO = envio
            If (t.modificar(Usuario)) Then
                MsgBox("Envío modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            If TextIdProductor.Text.Trim.Length > 0 Then
                Dim t As New dTrazCajas()
                t.ESTADO = estado
                t.FECHA = fec
                t.IDPRODUCTOR = idproductor
                t.IDCAJA = idcaja
                t.ARMAZONES = armazones
                t.GRADILLAS = gradillas
                t.FRASCOS = frascos
                t.IDEMPRESA = empresa.ID
                t.ENVIO = envio
                If (t.guardar(Usuario)) Then
                    MsgBox("Envío guardado", MsgBoxStyle.Information, "Atención")
                    enviomail()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        TextCaja.Text = ""
        TextArmazones.Text = ""
        TextGradillas.Text = ""
        TextFrascos.Text = ""
        ComboAgencia.Text = ""
        TextEnvio.Text = ""
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
            Dim et As dEmpresaT
            ComboAgencia.SelectedItem = Nothing
            For Each et In ComboAgencia.Items
                If et.ID = ped.IDAGENCIA Then
                    ComboAgencia.SelectedItem = et
                    Exit For
                End If
            Next
            TextRC_compos.Text = ped.RC_COMPOS
            TextAgua.Text = ped.AGUA
            TextSangre.Text = ped.SANGRE
            TextEsteriles.Text = ped.ESTERILES
            TextOtros.Text = ped.OTROS
            TextObservaciones.Text = ped.OBSERVACIONES
        End If
    End Sub
End Class
