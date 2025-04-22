Imports Microsoft.Office.Interop.Excel

Public Class FormAutorizaciones
    Private mailautoriza As Integer
    Private mailtipo As Integer
    Private maildetalle As String
    Private mailemail As String
    Private mailobservaciones As String
#Region "Atributos"
    Private _usuario As dUsuario
#End Region
#Region "Constructores"
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarUsuarios()
        cargarAutorizadores()
        cargarTipos()
        cargarLista()
    End Sub
#End Region
    Private Sub cargarUsuarios()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboNombre.Items.Add(u)
                    cbxUsuario.Items.Add(u)
                Next
                Dim n As New dUsuario
                cbxUsuario.Items.Add(n)
            End If
        End If
    End Sub
    Private Sub cargarTipos()
        Dim t As New dTipoAutorizacion
        Dim lista As New ArrayList
        lista = t.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each t In lista
                    ComboTipo.Items.Add(t)
                Next
            End If
        End If
    End Sub
    Private Sub cargarAutorizadores()
        Dim u As New dUsuario
        Dim lista As New ArrayList
        lista = u.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each u In lista
                    ComboAutoriza.Items.Add(u)
                Next
            End If
        End If
    End Sub
    Private Sub guardar()
        Dim usuario As dUsuario = CType(ComboNombre.SelectedItem, dUsuario)
        Dim idusuario As Integer = 0
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If Not usuario Is Nothing Then
            idusuario = usuario.ID
        Else
            MsgBox("No se ha seleccionado usuario", MsgBoxStyle.Exclamation, "Atención") : ComboNombre.Focus() : Exit Sub
        End If
        Dim tipo As dTipoAutorizacion = CType(ComboTipo.SelectedItem, dTipoAutorizacion)
        Dim idtipo As Integer = 0
        If Not tipo Is Nothing Then
            idtipo = tipo.ID
        Else
            MsgBox("No se ha seleccionado un tipo de autorización", MsgBoxStyle.Exclamation, "Atención") : ComboTipo.Focus() : Exit Sub
        End If
        Dim fechaevento As Date = DateFechaEvento.Value.ToString("yyyy-MM-dd")
        Dim detalle As String = ""
        If TextDetalle.Text <> "" Then
            detalle = TextDetalle.Text.Trim
        End If
        Dim autoriza As dUsuario = CType(ComboAutoriza.SelectedItem, dUsuario)
        Dim idautoriza = 0
        If Not autoriza Is Nothing Then
            idautoriza = autoriza.ID
        End If
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text.Trim
        End If
        Dim email As String = ""
        If TextEmail.Text <> "" Then
            email = TextEmail.Text.Trim
        End If
        If TextId.Text.Length > 0 Then
            Dim a As New dAutorizaciones
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            Dim fecevento As String
            fecevento = Format(fechaevento, "yyyy-MM-dd")
            a.ID = id
            a.FECHA = fec
            a.IDUSUARIO = idusuario
            a.TIPO = idtipo
            a.FECHAEVENTO = fecevento
            a.DETALLE = detalle
            a.AUTORIZA = idautoriza
            a.OBSERVACIONES = observaciones
            a.AUTORIZADA = 1
            a.EMAIL = email
            If (a.modificar(usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                mailautoriza = idautoriza
                mailtipo = idtipo
                maildetalle = detalle
                mailemail = a.EMAIL
                mailobservaciones = observaciones
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dAutorizaciones
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            Dim fecevento As String
            fecevento = Format(fechaevento, "yyyy-MM-dd")
            a.FECHA = fec
            a.IDUSUARIO = idusuario
            a.TIPO = idtipo
            a.FECHAEVENTO = fecevento
            a.DETALLE = detalle
            a.AUTORIZA = idautoriza
            a.OBSERVACIONES = observaciones
            a.AUTORIZADA = 1
            If (a.guardar(usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
    End Sub
    Private Sub guardar2()
        Dim usuario As dUsuario = CType(ComboNombre.SelectedItem, dUsuario)
        Dim idusuario As Integer = 0
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        If Not usuario Is Nothing Then
            idusuario = usuario.ID
        Else
            MsgBox("No se ha seleccionado usuario", MsgBoxStyle.Exclamation, "Atención") : ComboNombre.Focus() : Exit Sub
        End If
        Dim tipo As dTipoAutorizacion = CType(ComboTipo.SelectedItem, dTipoAutorizacion)
        Dim idtipo As Integer = 0
        If Not tipo Is Nothing Then
            idtipo = tipo.ID
        Else
            MsgBox("No se ha seleccionado un tipo de autorización", MsgBoxStyle.Exclamation, "Atención") : ComboTipo.Focus() : Exit Sub
        End If
        Dim detalle As String = ""
        If TextDetalle.Text <> "" Then
            detalle = TextDetalle.Text.Trim
        End If
        Dim autoriza As dUsuario = CType(ComboAutoriza.SelectedItem, dUsuario)
        Dim idautoriza = 0
        If Not autoriza Is Nothing Then
            idautoriza = autoriza.ID
        End If
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text.Trim
        End If
        Dim email As String = ""
        If TextEmail.Text <> "" Then
            email = TextEmail.Text.Trim
        End If
        If TextId.Text.Length > 0 Then
            Dim a As New dAutorizaciones
            Dim id As Long = CType(TextId.Text.Trim, Long)
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            a.ID = id
            a.FECHA = fec
            a.IDUSUARIO = idusuario
            a.TIPO = idtipo
            a.DETALLE = detalle
            a.AUTORIZA = idautoriza
            a.OBSERVACIONES = observaciones
            a.AUTORIZADA = -1
            a.EMAIL = email
            If (a.modificar(usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                mailautoriza = idautoriza
                mailtipo = idtipo
                maildetalle = detalle
                mailemail = a.EMAIL
                mailobservaciones = observaciones
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim a As New dAutorizaciones
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            a.FECHA = fec
            a.IDUSUARIO = idusuario
            a.TIPO = idtipo
            a.DETALLE = detalle
            a.AUTORIZA = idautoriza
            a.OBSERVACIONES = observaciones
            a.AUTORIZADA = -1
            If (a.guardar(usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        cargarLista()
    End Sub

    Private Sub limpiar()
        TextId.Text = ""
        DateFecha.Value = Now
        ComboNombre.SelectedItem = False
        ComboNombre.Text = ""
        ComboTipo.SelectedItem = False
        ComboTipo.Text = ""
        TextDetalle.Text = ""
        ComboAutoriza.SelectedItem = False
        ComboAutoriza.Text = ""
        TextObservaciones.Text = ""
        TextEmail.Text = ""
        ComboNombre.Focus()
    End Sub
    Private Sub cargarLista()
        DataGridView1.Rows.Clear()
        Dim a As New dAutorizaciones
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = a.listarultimos50
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(lista.Count)
                For Each a In lista
                    If a.AUTORIZADA = 0 Then
                        DataGridView1(columna, fila).Value = a.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.FECHAEVENTO
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = a.IDUSUARIO
                        u = u.buscar
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim t As New dTipoAutorizacion
                        t.ID = a.TIPO
                        t = t.buscar
                        DataGridView1(columna, fila).Value = t.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.DETALLE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = a.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.FECHAEVENTO
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = a.IDUSUARIO
                        u = u.buscar
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim t As New dTipoAutorizacion
                        t.ID = a.TIPO
                        t = t.buscar
                        DataGridView1(columna, fila).Value = t.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.DETALLE
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        limpiar()
        If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAutorizaciones
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                DateFecha.Value = a.FECHA
                DateFecha.Enabled = False
                Dim u As dUsuario
                ComboNombre.SelectedItem = Nothing
                For Each u In ComboNombre.Items
                    If u.ID = a.IDUSUARIO Then
                        ComboNombre.SelectedItem = u
                        Exit For
                    End If
                Next
                ComboNombre.Enabled = False
                Dim t As dTipoAutorizacion
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                ComboTipo.Enabled = False
                DateFechaEvento.Value = a.FECHAEVENTO
                DateFechaEvento.Enabled = False
                TextDetalle.Text = a.DETALLE
                TextDetalle.Enabled = False
                Dim uu As dUsuario
                ComboAutoriza.SelectedItem = Nothing
                For Each uu In ComboAutoriza.Items
                    If uu.ID = Usuario.ID Then
                        ComboAutoriza.SelectedItem = uu
                        Exit For
                    End If
                Next
                ComboAutoriza.Enabled = False
                If a.OBSERVACIONES <> "" Then
                    TextObservaciones.Text = a.OBSERVACIONES
                End If
                TextEmail.Enabled = False
                If a.EMAIL <> "" Then
                    TextEmail.Text = a.EMAIL
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Nombre" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAutorizaciones
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                DateFecha.Value = a.FECHA
                DateFecha.Enabled = False
                Dim u As dUsuario
                ComboNombre.SelectedItem = Nothing
                For Each u In ComboNombre.Items
                    If u.ID = a.IDUSUARIO Then
                        ComboNombre.SelectedItem = u
                        Exit For
                    End If
                Next
                ComboNombre.Enabled = False
                Dim t As dTipoAutorizacion
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                ComboTipo.Enabled = False
                DateFechaEvento.Value = a.FECHAEVENTO
                DateFechaEvento.Enabled = False
                TextDetalle.Text = a.DETALLE
                TextDetalle.Enabled = False
                Dim uu As dUsuario
                ComboAutoriza.SelectedItem = Nothing
                For Each uu In ComboAutoriza.Items
                    If uu.ID = Usuario.ID Then
                        ComboAutoriza.SelectedItem = uu
                        Exit For
                    End If
                Next
                ComboAutoriza.Enabled = False
                If a.OBSERVACIONES <> "" Then
                    TextObservaciones.Text = a.OBSERVACIONES
                End If
                TextEmail.Enabled = False
                If a.EMAIL <> "" Then
                    TextEmail.Text = a.EMAIL
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Tipo" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAutorizaciones
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                DateFecha.Value = a.FECHA
                DateFecha.Enabled = False
                Dim u As dUsuario
                ComboNombre.SelectedItem = Nothing
                For Each u In ComboNombre.Items
                    If u.ID = a.IDUSUARIO Then
                        ComboNombre.SelectedItem = u
                        Exit For
                    End If
                Next
                ComboNombre.Enabled = False
                Dim t As dTipoAutorizacion
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                ComboTipo.Enabled = False
                DateFechaEvento.Value = a.FECHAEVENTO
                DateFechaEvento.Enabled = False
                TextDetalle.Text = a.DETALLE
                TextDetalle.Enabled = False
                Dim uu As dUsuario
                ComboAutoriza.SelectedItem = Nothing
                For Each uu In ComboAutoriza.Items
                    If uu.ID = Usuario.ID Then
                        ComboAutoriza.SelectedItem = uu
                        Exit For
                    End If
                Next
                ComboAutoriza.Enabled = False
                If a.OBSERVACIONES <> "" Then
                    TextObservaciones.Text = a.OBSERVACIONES
                End If
                TextEmail.Enabled = False
                If a.EMAIL <> "" Then
                    TextEmail.Text = a.EMAIL
                End If
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Detalle" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim a As New dAutorizaciones
            id = row.Cells("Id").Value
            a.ID = id
            a = a.buscar
            If Not a Is Nothing Then
                TextId.Text = a.ID
                DateFecha.Value = a.FECHA
                DateFecha.Enabled = False
                Dim u As dUsuario
                ComboNombre.SelectedItem = Nothing
                For Each u In ComboNombre.Items
                    If u.ID = a.IDUSUARIO Then
                        ComboNombre.SelectedItem = u
                        Exit For
                    End If
                Next
                ComboNombre.Enabled = False
                Dim t As dTipoAutorizacion
                ComboTipo.SelectedItem = Nothing
                For Each t In ComboTipo.Items
                    If t.ID = a.TIPO Then
                        ComboTipo.SelectedItem = t
                        Exit For
                    End If
                Next
                ComboTipo.Enabled = False
                DateFechaEvento.Value = a.FECHAEVENTO
                DateFechaEvento.Enabled = False
                TextDetalle.Text = a.DETALLE
                TextDetalle.Enabled = False
                Dim uu As dUsuario
                ComboAutoriza.SelectedItem = Nothing
                For Each uu In ComboAutoriza.Items
                    If uu.ID = Usuario.ID Then
                        ComboAutoriza.SelectedItem = uu
                        Exit For
                    End If
                Next
                ComboAutoriza.Enabled = False
                If a.OBSERVACIONES <> "" Then
                    TextObservaciones.Text = a.OBSERVACIONES
                End If
                TextEmail.Enabled = False
                If a.EMAIL <> "" Then
                    TextEmail.Text = a.EMAIL
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
        enviomail()
    End Sub

    Private Sub ButtonNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
    End Sub
    Private Sub enviomail()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim u As New dUsuario
        Dim t As New dTipoAutorizacion
        Dim nombre As String = ""
        Dim tipo As String = ""
        Dim detalle As String = ""
        u.ID = mailautoriza
        u = u.buscar
        nombre = u.NOMBRE
        t.ID = mailtipo
        t = t.buscar
        tipo = t.NOMBRE
        detalle = maildetalle
        Dim email As String = mailemail
        If email <> "" Then
            Dim texto As String = ""

            texto = nombre & " ha autorizado su solicitud: " & tipo & " - " & detalle & vbCrLf _
            & "Observaciones: " & mailobservaciones
           
            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            Try
                _Message.[To].Add(email)
                _Message.[To].Add("gerencia@colaveco.com.uy")
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try

            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Autorización aceptada"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
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
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub
    Private Sub enviomail2()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim u As New dUsuario
        Dim t As New dTipoAutorizacion
        Dim nombre As String = ""
        Dim tipo As String = ""
        Dim detalle As String = ""
        u.ID = mailautoriza
        u = u.buscar
        nombre = u.NOMBRE
        t.ID = mailtipo
        t = t.buscar
        tipo = t.NOMBRE
        detalle = maildetalle
        Dim email As String = mailemail
        If email <> "" Then
            Dim texto As String = ""

            texto = nombre & " no ha autorizado su solicitud: " & tipo & " - " & detalle & vbCrLf _
            & "Observaciones: " & mailobservaciones
            
            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            Try
                _Message.[To].Add(email)
                _Message.[To].Add("envios@colaveco.com.uy")
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try

            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Solicitud no autorizada"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
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
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub
    Private Sub ButtonNoAutorizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNoAutorizar.Click
        guardar2()
        enviomail2()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If TextId.Text <> "" Then
            Dim a As New dAutorizaciones
            Dim id As Long = TextId.Text
            a.ID = id
            If (a.eliminar(Usuario)) Then
                MsgBox("Solicitud eliminada", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If cbxSinFiltros.Checked = True Then
            cargarLista()
        Else
            Listar()
        End If
    End Sub

    Private Sub Listar()
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0

        lista = getAutorizacionesConFiltros()

        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add(lista.Count)
                For Each a In lista
                    If a.AUTORIZADA = 0 Then
                        DataGridView1(columna, fila).Value = a.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.FECHAEVENTO
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = a.IDUSUARIO
                        u = u.buscar
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim t As New dTipoAutorizacion
                        t.ID = a.TIPO
                        t = t.buscar
                        DataGridView1(columna, fila).Value = t.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.DETALLE
                        DataGridView1(columna, fila).Style.BackColor = Color.Red
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = 0
                        fila = fila + 1
                    Else
                        DataGridView1(columna, fila).Value = a.ID
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.FECHAEVENTO
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim u As New dUsuario
                        u.ID = a.IDUSUARIO
                        u = u.buscar
                        DataGridView1(columna, fila).Value = u.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        Dim t As New dTipoAutorizacion
                        t.ID = a.TIPO
                        t = t.buscar
                        DataGridView1(columna, fila).Value = t.NOMBRE
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = a.DETALLE
                        DataGridView1(columna, fila).Style.BackColor = Color.Green
                        DataGridView1(columna, fila).Style.ForeColor = Color.White
                        columna = 0
                        fila = fila + 1
                    End If
                Next
            End If
        End If
    End Sub

    Public Function getAutorizacionesConFiltros() As ArrayList
        Dim fecha_desde As String
        Dim fecha_hasta As String
        Dim des As Date = desde.Value.ToString("yyyy-MM-dd")
        Dim has As Date = hasta.Value.ToString("yyyy-MM-dd")

        If Not desde Is Nothing Then
            fecha_desde = Format(des, "yyyy-MM-dd")
        End If

        If Not hasta Is Nothing Then
            fecha_hasta = Format(has, "yyyy-MM-dd")
        End If

        Dim usuario As dUsuario
        Dim id_usuario As Integer = 0

        If Not cbxUsuario.Text Is Nothing And cbxUsuario.Text <> "" Then
            usuario = cbxUsuario.SelectedItem
            id_usuario = usuario.ID
        End If

        DataGridView1.Rows.Clear()
        Dim n As New dAutorizaciones
        Dim lista As New ArrayList

        Try
            lista = n.listarPorFiltros(fecha_desde, fecha_hasta, id_usuario)
        Catch ex As Exception
            MsgBox(ex.Data)
        End Try

        Return lista
    End Function

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If cbxSinFiltros.Checked = True Then
            exportarTodos()
        Else
            exportarConFiltros()
        End If
    End Sub

    Public Function exportarTodos()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim n As New dAutorizaciones
        Dim lista As New ArrayList
        lista = n.listarultimos50

        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Nombre"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Tipo"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Detalle"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        columna = 1

        If Not lista Is Nothing Then
            For Each n In lista
                If Not n.FECHA Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = n.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.IDUSUARIO > 0 Then
                    Dim usu As New dUsuario
                    usu.ID = n.IDUSUARIO
                    usu = usu.buscar()
                    x1hoja.Cells(fila, columna).formula = usu.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.TIPO > 0 Then
                    Dim t As New dTipoAutorizacion
                    t.ID = n.TIPO
                    t = t.buscar
                    x1hoja.Cells(fila, columna).formula = t.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.DETALLE <> "" Then
                    x1hoja.Cells(fila, columna).formula = n.DETALLE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If
            Next
        End If

        x1app.Visible = True
        'x1libro.PrintPreview()
        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing

    End Function

    Public Function exportarConFiltros()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

        'x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(1)
        'x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        'x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        'x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)

        x1hoja.Cells(1, 1).columnwidth = 10
        x1hoja.Cells(1, 2).columnwidth = 10
        x1hoja.Cells(1, 3).columnwidth = 10
        x1hoja.Cells(1, 4).columnwidth = 10

        Dim fila As Integer = 1
        Dim columna As Integer = 1

        Dim lista As New ArrayList
        lista = getAutorizacionesConFiltros()

        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Nombre"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Tipo"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Detalle"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
        fila = fila + 2
        columna = 1

        Dim n As dAutorizaciones
        If Not lista Is Nothing Then
            For Each n In lista

                If Not n.FECHA Is Nothing Then
                    x1hoja.Cells(fila, columna).formula = n.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.IDUSUARIO > 0 Then
                    Dim usu As New dUsuario
                    usu.ID = n.IDUSUARIO
                    usu = usu.buscar()
                    x1hoja.Cells(fila, columna).formula = usu.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.TIPO > 0 Then
                    Dim t As New dTipoAutorizacion
                    t.ID = n.TIPO
                    t = t.buscar
                    x1hoja.Cells(fila, columna).formula = t.NOMBRE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = columna + 1
                End If

                If n.DETALLE <> "" Then
                    x1hoja.Cells(fila, columna).formula = n.DETALLE
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                Else
                    x1hoja.Cells(fila, columna).formula = "-"
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(255, 0, 0)
                    columna = 1
                    fila = fila + 1
                End If
            Next
        End If

        x1app.Visible = True
        'x1libro.PrintPreview()
        'x1hoja.PrintOut()
        'x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Function
End Class