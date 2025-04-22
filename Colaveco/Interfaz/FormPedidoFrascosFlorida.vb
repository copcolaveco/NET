Public Class FormPedidoFrascosFlorida
    Private _usuario As dUsuario
    Private idpedidoflorida As Long = 0
    Private emailweb As String = ""
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Private _pedidos As dPedidos
    Public Property Pedidos() As dPedidos
        Get
            Return _pedidos
        End Get
        Set(ByVal value As dPedidos)
            _pedidos = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario, ByVal id As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        idpedidoflorida = id
        cargarComboAgencia()
        cargarComboTecnicos()
        limpiar()
        cargarpedido()
    End Sub
    Private Sub cargarpedido()
        Dim pf As New dPedidosFlorida
        pf.ID = idpedidoflorida
        pf = pf.buscar
        If Not pf Is Nothing Then
            emailweb = Trim(pf.EMAIL)
            Dim p As New dCliente
            p.ID = pf.IDPRODUCTOR
            p = p.buscar
            If Not p Is Nothing Then
                TextIdProductor.Text = p.ID
                TextProductor.Text = p.NOMBRE
                If p.CONTRATO = 0 Then
                    MsgBox("El cliente no tiene contrato firmado.")
                End If

                'Controla si debe cajas **************************************
                Dim ec As New dEnvioCajas
                Dim lista As New ArrayList
                Dim idpro As Long = 0
                Dim listacajas As String = ""
                idpro = p.ID
                lista = ec.listarxcliente(idpro)
                If Not lista Is Nothing Then
                    If lista.Count > 0 Then
                        For Each ec In lista
                            listacajas = listacajas & ec.IDCAJA & "  "
                        Next
                    End If
                End If
                If listacajas <> "" Then
                    MsgBox("El cliente debe las siguientes cajas: " & listacajas)
                End If

                'Controla que el cliente no tenga deuda atrasada*************************************
                'If p.MOROSO = 1 Then
                '    MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
                '    'TextIdProductor.Text = ""
                '    'TextProductor.Text = ""
                '    'ComboTecnico.SelectedItem = Nothing
                '    'Exit Sub
                'End If

                'Contola si tiene pedido automático cargado ******************************************
                Dim pa As New dPedidosAuto
                pa.IDPRODUCTOR = p.ID
                pa = pa.buscarxproductor
                If Not pa Is Nothing Then
                    Dim dia As Integer = pa.DIA
                    Dim rccompos As Integer = pa.RC_COMPOS
                    Dim agua As Integer = pa.AGUA
                    Dim sangre As Integer = pa.SANGRE
                    Dim esteriles As Integer = pa.ESTERILES
                    Dim texto As String = ""
                    texto = "El cliente tiene pedido automático para los dias" & " " & dia & ", "
                    If rccompos > 0 Then
                        texto = texto & "Rc Compos." & " " & rccompos & " / "
                    End If
                    If agua > 0 Then
                        texto = texto & "Agua" & " " & agua & " / "
                    End If
                    If sangre > 0 Then
                        texto = texto & "Sangre" & " " & sangre & " / "
                    End If
                    If esteriles > 0 Then
                        texto = texto & "Esteriles" & " " & esteriles
                    End If
                    MsgBox("texto")
                End If

            Else
                TextIdProductor.Text = ""
                TextProductor.Text = ""
                MsgBox("El número de cliente ingresado en la web no existe!")
            End If
            TextDireccion.Text = pf.DIRECCION
            TextTelefono.Text = pf.TELEFONO
            TextEmail.Text = pf.EMAIL
            ComboTecnico.SelectedItem = Nothing

            Dim t As New dCliente
            If Not p Is Nothing Then
                For Each t In ComboTecnico.Items
                    If t.ID = p.TECNICO1 Then
                        ComboTecnico.SelectedItem = t
                        Exit For
                    End If
                Next
            End If
            ComboAgencia.SelectedItem = Nothing
            Dim a As New dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = pf.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            ComboTecnico.Text = ""
            ComboAgencia.Text = ""
            TextRC_compos.Text = pf.CCONSERVANTE
            TextResponsable.Text = Usuario.NOMBRE
            TextAgua.Text = pf.AGUA
            TextSangre.Text = pf.SANGRE
            TextEsteriles.Text = pf.SCONSERVANTE
            TextOtros.Text = ""
            TextObservaciones.Text = pf.OBSERVACIONES
            DateFecha.Focus()
            p = Nothing
            pf = Nothing
            t = Nothing
            a = Nothing
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        DateFechaposEnvio.Value = Now
        TextIdProductor.Text = ""
        TextProductor.Text = ""
        TextDireccion.Text = ""
        TextTelefono.Text = ""
        TextEmail.Text = ""
        ComboTecnico.Text = ""
        ComboAgencia.Text = ""
        TextRC_compos.Text = ""
        TextResponsable.Text = ""
        TextAgua.Text = ""
        TextSangre.Text = ""
        TextEsteriles.Text = ""
        TextOtros.Text = ""
        TextObservaciones.Text = ""
        DateFecha.Focus()
    End Sub

    Public Sub cargarComboAgencia()
        Dim et As New dEmpresaT
        Dim lista As New ArrayList
        lista = et.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each et In lista
                    ComboAgencia.Items.Add(et)
                Next
            End If
        End If
    End Sub
    Public Sub cargarComboTecnicos()
        Dim t As New dCliente
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTecnico.Items.Add(t)
                Next
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fechaposenvio As Date = DateFechaposEnvio.Value.ToString("yyyy-MM-dd")
        If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        Dim productor As Long = TextIdProductor.Text.Trim
        If TextDireccion.Text.Trim.Length = 0 Then MsgBox("No se ha detallado direccìón de envío", MsgBoxStyle.Exclamation, "Atención") : TextDireccion.Focus() : Exit Sub
        Dim direccion As String = TextDireccion.Text.Trim
        Dim telefono As String = TextTelefono.Text.Trim
        Dim tecnico As dCliente = CType(ComboTecnico.SelectedItem, dCliente)
        Dim agencia As dEmpresaT = CType(ComboAgencia.SelectedItem, dEmpresaT)
        Dim responsable As String = ""
        If TextResponsable.Text <> "" Then
            responsable = TextResponsable.Text.Trim
        End If
        Dim rc_compos As Integer
        Dim agua As Integer
        Dim sangre As Integer
        Dim esteriles As Integer
        Dim otros As Integer
        If TextRC_compos.Text <> "" Then
            rc_compos = TextRC_compos.Text.Trim
        End If
        If TextAgua.Text <> "" Then
            agua = TextAgua.Text.Trim
        End If
        If TextSangre.Text <> "" Then
            sangre = TextSangre.Text.Trim
        End If
        If TextEsteriles.Text <> "" Then
            esteriles = TextEsteriles.Text.Trim
        End If
        If TextOtros.Text <> "" Then
            otros = TextOtros.Text.Trim
        End If
        Dim observaciones As String = TextObservaciones.Text.Trim

        Dim id_usuario As Integer = Usuario.ID

        If TextIdProductor.Text.Trim.Length > 0 Then
            Dim ped As New dPedidos()
            'Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            Dim fecposenvio As String
            fec = Format(fecha, "yyyy-MM-dd")
            fecposenvio = Format(fechaposenvio, "yyyy-MM-dd")
            'ped.ID = id
            ped.FECHA = fec
            ped.FECHAPOSENVIO = fecposenvio
            ped.IDPRODUCTOR = productor
            ped.DIRECCION = direccion
            ped.TELEFONO = telefono
            If Not tecnico Is Nothing Then
                ped.IDTECNICO = tecnico.ID
            End If
            ped.RESPONSABLE = responsable
            ped.IDAGENCIA = agencia.ID
            ped.RC_COMPOS = rc_compos
            ped.AGUA = agua
            ped.SANGRE = sangre
            ped.ESTERILES = esteriles
            ped.OTROS = otros
            ped.OBSERVACIONES = observaciones
            ped.IDUSUARIO = id_usuario
            If (ped.guardar(Usuario)) Then
                MsgBox("Pedido guardado", MsgBoxStyle.Information, "Atención")
                Dim pf As New dPedidosFlorida
                pf.ID = idpedidoflorida
                pf.marcar()
                limpiar()
                'enviaremail()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        Dim pf As New dPedidosFlorida
        pf.ID = idpedidoflorida
        pf.marcar()
        limpiar()
    End Sub
    Private Sub enviaremail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        email = emailweb
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
            _Message.[To].Add(email)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Colaveco - Pedido de frascos"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Su pedido de frascos está siendo procesado, le informaremos cuando esté pronto. Gracias!"
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = "\\192.168.1.10\E\NET\Brucelosis en leche\" & archivo & ".xls" 'archivo que se quiere adjuntar ‘
            'Dim _File As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & archivo & ".xls" 'archivo que se quiere adjuntar ‘
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            If cli.CONTRATO = 0 Then
                MsgBox("El cliente no tiene contrato firmado.")
            End If

            'Contola si tiene pedido automático cargado ******************************************
            Dim pa As New dPedidosAuto
            pa.IDPRODUCTOR = cli.ID
            pa = pa.buscarxproductor
            If Not pa Is Nothing Then
                Dim dia As Integer = pa.DIA
                Dim rccompos As Integer = pa.RC_COMPOS
                Dim agua As Integer = pa.AGUA
                Dim sangre As Integer = pa.SANGRE
                Dim esteriles As Integer = pa.ESTERILES
                Dim texto As String = ""
                texto = "El cliente tiene pedido automático para los dias" & " " & dia & ", "
                If rccompos > 0 Then
                    texto = texto & "Rc Compos." & " " & rccompos & " / "
                End If
                If agua > 0 Then
                    texto = texto & "Agua" & " " & agua & " / "
                End If
                If sangre > 0 Then
                    texto = texto & "Sangre" & " " & sangre & " / "
                End If
                If esteriles > 0 Then
                    texto = texto & "Esteriles" & " " & esteriles
                End If
                MsgBox("texto")
            End If
            TextIdProductor.Text = cli.ID
            TextProductor.Text = cli.NOMBRE
            Dim pf As New dPedidosFlorida
            pf.ID = idpedidoflorida
            pf = pf.buscar
            If pf.DIRECCION = "" Then
                TextDireccion.Text = cli.ENVIO
            End If
            If pf.TELEFONO = "" Then
                TextTelefono.Text = cli.TELEFONO1
            End If
            If pf.EMAIL = "" Then
                TextEmail.Text = cli.EMAIL1
            End If
            ComboTecnico.SelectedItem = Nothing
            Dim t As dCliente
            For Each t In ComboTecnico.Items
                If t.ID = cli.TECNICO1 Then
                    ComboTecnico.SelectedItem = t
                    Exit For
                End If
            Next
            ComboAgencia.SelectedItem = Nothing
            Dim a As dEmpresaT
            For Each a In ComboAgencia.Items
                If a.ID = cli.IDAGENCIA Then
                    ComboAgencia.SelectedItem = a
                    Exit For
                End If
            Next
            'Controla si debe cajas **************************************
            Dim ec As New dEnvioCajas
            Dim lista As New ArrayList
            Dim idpro As Long = 0
            Dim listacajas As String = ""
            idpro = cli.ID
            lista = ec.listarxcliente(idpro)
            If Not lista Is Nothing Then
                If lista.Count > 0 Then
                    For Each ec In lista
                        listacajas = listacajas & ec.IDCAJA & "  "
                    Next
                End If
            End If
            If listacajas <> "" Then
                MsgBox("El cliente debe las siguientes cajas: " & listacajas)
            End If
            'Controla que el cliente no tenga deuda atrasada*************************************
            'If pro.MOROSO = 1 Then
            '    MsgBox("El cliente tiene deuda") ', no se puede continuar con la solicitud.")
            '    'Se comenta esta parte a pedido de Administración para poder continuar con el pedido
            '    'TextIdProductor.Text = ""
            '    'TextProductor.Text = ""
            '    'ComboTecnico.SelectedItem = Nothing
            '    'Exit Sub
            'End If

            TextResponsable.Focus()
        End If
    End Sub
End Class