Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class FormSolicitarCotizacion
    Dim cotizacionid As Long = 0
#Region "Atributos"
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarUnidades()
        cargarPresentacion()
        cargarMonedas()
        'limpiar()
    End Sub

#End Region


    Private Sub ButtonBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProveedor.Click
        Dim v As New FormBuscarProveedor
        v.ShowDialog()
        If Not v.Proveedor Is Nothing Then
            Dim pro As dProveedores = v.Proveedor
            TextIdProveedor.Text = pro.ID
            TextProveedor.Text = pro.NOMBRE
            TextIdProducto.Focus()
            guardarcabezal()
            If pro.EMAIL <> "" Then
                ComboEmail.Enabled = True
                ComboEmail.Items.Add(pro.EMAIL)
                ComboEmail.Text = pro.EMAIL
            End If
            If pro.EMAIL2 <> "" Then
                ComboEmail.Items.Add(pro.EMAIL2)
            End If
            If pro.EMAIL3 <> "" Then
                ComboEmail.Items.Add(pro.EMAIL3)
            End If
        End If
    End Sub

    Private Sub ButtonBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProducto.Click
        Dim v As New FormBuscarProducto
        v.ShowDialog()
        If Not v.Producto Is Nothing Then
            Dim pro As dProductos = v.Producto
            TextIdProducto.Text = pro.ID
            TextProducto.Text = pro.NOMBRE
            TextDetalle.Text = pro.DETALLE
            buscarultimacompra()
            Dim vv As New FormUltimasCompras(pro.ID)
            vv.ShowDialog()
            TextCantidad.Focus()
        End If
    End Sub
    Private Sub buscarultimacompra()
        Dim c As New dCompras
        Dim lc As New dLineaCompra
        Dim idproducto As Integer = TextIdProducto.Text.Trim
        lc.PRODUCTO = idproducto
        lc = lc.buscarultimacompra()
        If Not lc Is Nothing Then
            TextPrecio.Text = lc.PRECIO
            If lc.MONEDA = 0 Then
                ComboMoneda.Text = "$"
            ElseIf lc.MONEDA = 1 Then
                ComboMoneda.Text = "U$S"
            End If
            c.ID = lc.IDCOMPRA
            c = c.buscar
            If Not c Is Nothing Then
                DateUltimaCompra.Value = c.FECHARECIBO
            End If
        End If
       
    End Sub
    Public Sub cargarUnidades()
        Dim uni As New dUnidades
        Dim lista As New ArrayList
        lista = uni.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each uni In lista
                    ComboUnidad.Items.Add(uni)
                Next
            End If
        End If
    End Sub
    Public Sub cargarPresentacion()
        Dim p As New dPresentacionUnidades
        Dim lista As New ArrayList
        lista = p.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each p In lista
                    ComboPresentacion.Items.Add(p)
                Next
            End If
        End If
    End Sub
    Public Sub cargarMonedas()
        Dim mon As New dMoneda
        Dim lista As New ArrayList
        lista = mon.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each mon In lista
                    ComboMoneda.Items.Add(mon)
                Next
            End If
        End If
    End Sub
    Private Sub guardarcabezal()
        If TextProveedor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el proveedor", MsgBoxStyle.Exclamation, "Atención") : ButtonBuscarProveedor.Focus() : Exit Sub
        Dim proveedor As Integer = TextIdProveedor.Text.Trim
        Dim proveedor2 As Integer = 0
        Dim proveedor3 As Integer = 0
        If TextIdProveedor2.Text <> "" Then
            proveedor2 = TextIdProveedor2.Text.Trim
        End If
        If TextIdProveedor3.Text <> "" Then
            proveedor3 = TextIdProveedor3.Text.Trim
        End If
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim usuariocreador As Integer = Usuario.ID
        Dim enviado As Integer = -1
        Dim anulada As Integer = 0
        If TextId.Text <> "" Then
            Dim c As New dCotizacion
            Dim id As Long = TextId.Text.Trim
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.ID = id
            c.PROVEEDOR = proveedor
            c.PROVEEDOR2 = proveedor2
            c.PROVEEDOR3 = proveedor3
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.ENVIADO = enviado
            c.ANULADA = anulada
            If (c.modificar(Usuario)) Then
                'MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")

            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim c As New dCotizacion
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.PROVEEDOR = proveedor
            c.PROVEEDOR2 = proveedor2
            c.PROVEEDOR3 = proveedor3
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.ENVIADO = enviado
            c.ANULADA = anulada
            If (c.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                buscarultimoid()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub buscarultimoid()
        Dim c As New dCotizacion
        Dim id As Long = 0
        c = c.buscarultimoid()
        If Not c Is Nothing Then
            id = c.ID
            TextId.Text = id
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
        generarsolicitud()

        '*** Mata los procesos de excel para poder abrir la orden de compra ***
        Dim proceso As System.Diagnostics.Process()
        proceso = System.Diagnostics.Process.GetProcessesByName("EXCEL")

        For Each opro As System.Diagnostics.Process In proceso
            'antes de iniciar el proceso obtengo la fecha en que inicie el 
            'proceso para detener todos los procesos que excel que inicio
            'mi código durante el proceso
            opro.Kill()

        Next
        '**********************************************************************
        Dim Arch1 As String
        Arch1 = "\\192.168.1.10\E\NET\COMPRAS\SOLICITUDES\SC_" & cotizacionid & ".xls"
        System.Diagnostics.Process.Start(Arch1)
        '*** Para enviar correo electrónico ********************************
        Dim result = MessageBox.Show("Desea enviar un correo electrónico con la solicitud de cotización?", "Atención!", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Exit Sub
        ElseIf result = DialogResult.No Then
            limpiar()
            limpiar2()
        ElseIf result = DialogResult.Yes Then
            enviaremail()
            limpiar()
            limpiar2()
        End If
        '*******************************************************************

    End Sub
    Private Sub guardar()
        If TextProveedor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el proveedor", MsgBoxStyle.Exclamation, "Atención") : ButtonBuscarProveedor.Focus() : Exit Sub
        Dim proveedor As Integer = TextIdProveedor.Text.Trim
        Dim proveedor2 As Integer = 0
        Dim proveedor3 As Integer = 0
        If TextIdProveedor2.Text <> "" Then
            proveedor2 = TextIdProveedor2.Text.Trim
        End If
        If TextIdProveedor3.Text <> "" Then
            proveedor3 = TextIdProveedor3.Text.Trim
        End If
        Dim email As String = ""
        If ComboEmail.Text <> "" Then
            email = ComboEmail.Text
        End If
        Dim email2 As String = ""
        If ComboEmail2.Text <> "" Then
            email2 = ComboEmail2.Text
        End If
        Dim email3 As String = ""
        If ComboEmail3.Text <> "" Then
            email3 = ComboEmail3.Text
        End If
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim usuariocreador As Integer = Usuario.ID
        Dim enviado As Integer = 0
        Dim observaciones As String = ""
        If TextObservaciones.Text <> "" Then
            observaciones = TextObservaciones.Text
        End If
        Dim anulada As Integer = 0
        If TextId.Text <> "" Then
            Dim c As New dCotizacion
            Dim id As Long = TextId.Text.Trim
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.ID = id
            c.PROVEEDOR = proveedor
            c.EMAIL = email
            c.PROVEEDOR2 = proveedor2
            c.EMAIL2 = email2
            c.PROVEEDOR3 = proveedor3
            c.EMAIL3 = email3
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.ENVIADO = enviado
            c.OBSERVACIONES = observaciones
            c.ANULADA = anulada
            If (c.modificar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'limpiar2()
                'limpiar()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim c As New dCotizacion
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            c.PROVEEDOR = proveedor
            c.EMAIL = email
            c.PROVEEDOR2 = proveedor2
            c.EMAIL2 = email2
            c.PROVEEDOR3 = proveedor3
            c.EMAIL3 = email3
            c.FECHA = fec
            c.USUARIOCREADOR = usuariocreador
            c.ENVIADO = enviado
            c.OBSERVACIONES = observaciones
            c.ANULADA = anulada
            If (c.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                'buscarultimoid()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub enviaremail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _Message2 As New System.Net.Mail.MailMessage()
        Dim _Message3 As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim email2 As String = ""
        Dim destinatario2 As String = ""
        Dim email3 As String = ""
        Dim destinatario3 As String = ""


        Dim c As New dCotizacion
        cotizacionid = TextId.Text
        c.ID = cotizacionid
        c = c.buscar
        If Not c Is Nothing Then
            If c.EMAIL <> "" Then
                email = Trim(c.EMAIL)
            End If
            If c.EMAIL2 <> "" Then
                email2 = Trim(c.EMAIL2)
            End If
            If c.EMAIL3 <> "" Then
                email3 = Trim(c.EMAIL3)
            End If
            Dim p As New dProveedores
            Dim p2 As New dProveedores
            Dim p3 As New dProveedores
            p.ID = c.PROVEEDOR
            p = p.buscar
            If Not p Is Nothing Then
                destinatario = p.NOMBRE
            End If
            p2.ID = c.PROVEEDOR2
            p2 = p2.buscar
            If Not p2 Is Nothing Then
                destinatario2 = p2.NOMBRE
            End If
            p3.ID = c.PROVEEDOR3
            p3 = p3.buscar
            If Not p3 Is Nothing Then
                destinatario3 = p3.NOMBRE
            End If
            p = Nothing
            p2 = Nothing
            p3 = Nothing
        End If

        If email <> "" Then

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
            _Message.Subject = "Solicitud de cotización"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Sres. de" & " " & destinatario & ", " & "por medio del presente correo adjuntamos solicitud de cotización. Desde ya gracias. COLAVECO"
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\COMPRAS\SOLICITUDES\SC_" & cotizacionid & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Primer correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
            marcarenvio()
            email = ""
            _File = ""

        End If


        '*** EMAIL 2
        If email2 <> "" Then

            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "CLV19912021Colaveco30")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message2.[To].Add(email2)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message2.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message2.Subject = "Solicitud de cotización"
            'Sujeto del e-mail 
            _Message2.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message2.Body = "Sres. de" & " " & destinatario2 & ", " & "por medio del presente correo adjuntamos solicitud de cotización. Desde ya gracias. COLAVECO"
            'contenido del mail 
            _Message2.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message2.Priority = System.Net.Mail.MailPriority.Normal
            _Message2.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File2 As String = "\\192.168.1.10\E\NET\COMPRAS\SOLICITUDES\SC_" & cotizacionid & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _Attachment2 As New System.Net.Mail.Attachment(_File2, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message2.Attachments.Add(_Attachment2) 'ENVIO 
            Try
                _SMTP.Send(_Message2)
                MessageBox.Show("Segundo correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
            'marcarenvio()
            email2 = ""
            _File2 = ""
        End If


        '*** EMAIL 3
        If email3 <> "" Then

            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("colaveco@gmail.com", "CLV19912021Colaveco30")
            _SMTP.Host = "smtp.gmail.com"
            _SMTP.Port = 587 '465
            _SMTP.EnableSsl = True
            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
            _Message3.[To].Add(email3)
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message3.From = New System.Net.Mail.MailAddress("colaveco@gmail.com", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message3.Subject = "Solicitud de cotización"
            'Sujeto del e-mail 
            _Message3.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message3.Body = "Sres. de" & " " & destinatario3 & ", " & "por medio del presente correo adjuntamos solicitud de cotización. Desde ya gracias. COLAVECO"
            'contenido del mail 
            _Message3.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message3.Priority = System.Net.Mail.MailPriority.Normal
            _Message3.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File3 As String = "\\192.168.1.10\E\NET\COMPRAS\SOLICITUDES\SC_" & cotizacionid & ".xls" 'archivo que se quiere adjuntar ‘
            Dim _Attachment3 As New System.Net.Mail.Attachment(_File3, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message3.Attachments.Add(_Attachment3) 'ENVIO 
            Try
                _SMTP.Send(_Message3)
                MessageBox.Show("Tercer correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
            'marcarenvio()
            email3 = ""
            _File3 = ""
        End If


    End Sub
    Private Sub marcarenvio()
        Dim c As New dCotizacion
        c.ID = cotizacionid
        c.marcarenviado(Usuario)
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextIdProveedor.Text = ""
        TextProveedor.Text = ""
        ComboEmail.Text = ""
        ComboEmail.Items.Clear()
        TextIdProveedor2.Text = ""
        TextProveedor2.Text = ""
        ComboEmail2.Text = ""
        ComboEmail2.Items.Clear()
        TextIdProveedor3.Text = ""
        TextProveedor3.Text = ""
        ComboEmail3.Text = ""
        ComboEmail3.Items.Clear()
        DateFecha.Value = Now
        TextObservaciones.Text = ""
        DataGridView1.Rows.Clear()
        ButtonBuscarProveedor.Focus()
    End Sub
    Private Sub limpiar2()
        TextIdProducto.Text = ""
        TextIdLinea.Text = ""
        TextProducto.Text = ""
        TextDetalle.Text = ""
        TextCantidad.Text = ""
        ComboUnidad.Text = ""
        ComboPresentacion.Text = ""
        TextPrecio.Text = ""
        ComboMoneda.Text = ""
        ButtonBuscarProducto.Focus()
    End Sub
    Private Sub generarsolicitud()
        Dim x1app As Microsoft.Office.Interop.Excel.Application
        Dim x1libro As Microsoft.Office.Interop.Excel.Workbook
        Dim x1hoja As Microsoft.Office.Interop.Excel.Worksheet
        x1app = CType(CreateObject("Excel.Application"), Microsoft.Office.Interop.Excel.Application)
        x1libro = CType(x1app.Workbooks.Add, Microsoft.Office.Interop.Excel.Workbook)
        x1hoja = CType(x1libro.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
        x1hoja.PageSetup.Orientation = XlPageOrientation.xlLandscape

        x1hoja.PageSetup.TopMargin = x1app.CentimetersToPoints(2)
        x1hoja.PageSetup.LeftMargin = x1app.CentimetersToPoints(1.9)
        x1hoja.PageSetup.RightMargin = x1app.CentimetersToPoints(0.5)
        x1hoja.PageSetup.BottomMargin = x1app.CentimetersToPoints(2)


        Dim fila As Integer = 1
        Dim columna As Integer = 1
        Dim sol As Long = TextId.Text
        cotizacionid = sol
        Dim fecha As Date = DateFecha.Value
        Dim c As New dCotizacion
        Dim p As New dProveedores
        Dim usu As New dUsuario
        Dim nombre As String = ""
        Dim direccion As String = ""
        Dim telefono As String = ""
        Dim email As String = ""
        Dim contacto As String = ""
        Dim creador As String = ""

        c.ID = sol
        c = c.buscar
        If Not c Is Nothing Then
            p.ID = c.PROVEEDOR
            p = p.buscar
            If Not p Is Nothing Then
                nombre = p.NOMBRE
                direccion = p.DIRECCION
                telefono = p.TELEFONO
                email = p.EMAIL
                contacto = p.CONTACTO
            End If
            usu.ID = c.USUARIOCREADOR
            usu = usu.buscar
            If Not usu Is Nothing Then
                creador = usu.NOMBRE
            End If
        End If


        x1hoja.Shapes.AddPicture("c:\Debug\encab_compras.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 520, 60)
        fila = fila + 3

        x1hoja.Cells(1, 1).columnwidth = 18
        x1hoja.Cells(1, 2).columnwidth = 30
        x1hoja.Cells(1, 3).columnwidth = 8
        x1hoja.Cells(1, 4).columnwidth = 8
        x1hoja.Cells(1, 5).columnwidth = 12
        x1hoja.Cells(1, 6).columnwidth = 9
        x1hoja.Cells(1, 7).columnwidth = 9

        'x1hoja.Cells(fila, columna).Formula = "Parque El Retiro, Nueva Helvecia. Tel/Fax: 45545311 / 45545975 / 45546838"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 1
        'x1hoja.Cells(fila, columna).Formula = "Email: colaveco@gmail.com - Sitio: http://www.colaveco.com.uy"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Solicitud de cotización Nº " & sol
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 12
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Fecha:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = fecha
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = 1
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).Formula = "Proveedor:"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = nombre
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).WrapText = True
        'x1hoja.Cells(fila, columna).Font.Bold = False
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = 1
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).Formula = "Dirección:"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = direccion
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).WrapText = True
        'x1hoja.Cells(fila, columna).Font.Bold = False
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = 1
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).Formula = "Teléfono:"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = telefono
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).WrapText = True
        'x1hoja.Cells(fila, columna).Font.Bold = False
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = 1
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).Formula = "Email:"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = email
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).WrapText = True
        'x1hoja.Cells(fila, columna).Font.Bold = False
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = 1
        'fila = fila + 1
        'x1hoja.Cells(fila, columna).Formula = "Contacto:"
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).Font.Bold = True
        'x1hoja.Cells(fila, columna).Font.Size = 10
        'columna = columna + 1
        'x1hoja.Cells(fila, columna).Formula = contacto
        'x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        'x1hoja.Cells(fila, columna).WrapText = True
        'x1hoja.Cells(fila, columna).Font.Bold = False
        'x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Producto"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Especificacion"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Cantidad"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Unidad"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Presentación"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Precio"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = "Moneda"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = True
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 1

        Dim lc As New dLineaCotizacion
        Dim idcotizacion As Long = sol
        Dim lista As New ArrayList
        lista = lc.listarxidcotizacion(idcotizacion)
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each lc In lista
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = pro.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = pro.DETALLE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).WrapText = True
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    x1hoja.Cells(fila, columna).Formula = lc.CANTIDAD
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = lc.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = uni.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1
                    End If
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        x1hoja.Cells(fila, columna).Formula = pre.NOMBRE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1

                    Else
                        x1hoja.Cells(fila, columna).Formula = ""
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = columna + 1

                    End If
                    x1hoja.Cells(fila, columna).Formula = "" 'lc.PRECIO
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                    x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                    x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    columna = columna + 1
                    If lc.MONEDA = 0 Then
                        x1hoja.Cells(fila, columna).Formula = "" '"$"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = 1
                        fila = fila + 1
                    ElseIf lc.MONEDA = 1 Then
                        x1hoja.Cells(fila, columna).Formula = "" '"U$S"
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignCenter
                        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
                        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        columna = 1
                        fila = fila + 1
                    End If
                Next
            End If
        End If
        fila = fila + 1
        x1hoja.Cells(fila, columna).Formula = "Observaciones:"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = columna + 1
        x1hoja.Cells(fila, columna).Formula = c.OBSERVACIONES
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).VerticalAlignment = XlHAlign.xlHAlignJustify
        x1hoja.Cells(fila, columna).WrapText = True
        x1hoja.Cells(fila, columna).BORDERS.color = RGB(0, 0, 0)
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10
        columna = 1
        fila = fila + 2
        x1hoja.Cells(fila, columna).Formula = "Solicita: " & creador
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Bold = False
        x1hoja.Cells(fila, columna).Font.Size = 10


        'PROTEGE LA HOJA DE EXCEL
        x1hoja.Protect(Password:="1582782", DrawingObjects:=True, _
            Contents:=True, Scenarios:=True)
        'GUARDA EL ARCHIVO DE EXCEL
        'Dim paginas As Integer = x1hoja.PageSetup.pages.count
        x1hoja.PageSetup.CenterFooter = "Página &P" ' de " & paginas
        x1hoja.SaveAs("\\192.168.1.10\E\NET\COMPRAS\SOLICITUDES\SC_" & idcotizacion & ".xls")



        x1libro.Close()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing


    End Sub

    Private Sub ButtonAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgregar.Click
        agregarlinea()
    End Sub
    Private Sub agregarlinea()
        If TextId.Text.Trim.Length = 0 Then MsgBox("Seleccione un proveedor", MsgBoxStyle.Exclamation, "Atención") : ButtonBuscarProveedor.Focus() : Exit Sub
        If TextIdProducto.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado un producto", MsgBoxStyle.Exclamation, "Atención") : TextIdProducto.Focus() : Exit Sub
        If TextCantidad.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado la cantidad", MsgBoxStyle.Exclamation, "Atención") : TextCantidad.Focus() : Exit Sub
        If ComboUnidad.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado una unidad", MsgBoxStyle.Exclamation, "Atención") : ComboUnidad.Focus() : Exit Sub
        If ComboPresentacion.Text.Trim.Length = 0 Then MsgBox("No se ha seleccionado una presentación", MsgBoxStyle.Exclamation, "Atención") : ComboPresentacion.Focus() : Exit Sub
        Dim idcotizacion As Integer = TextId.Text.Trim
        Dim producto As Integer = TextIdProducto.Text
        Dim cantidad As Double = TextCantidad.Text
        Dim unidad As dUnidades = CType(ComboUnidad.SelectedItem, dUnidades)
        Dim presentacion As dPresentacionUnidades = CType(ComboPresentacion.SelectedItem, dPresentacionUnidades)
        Dim precio As Double = 0
        If TextPrecio.Text <> "" Then
            precio = TextPrecio.Text.Trim
        End If
        Dim moneda As Integer = 0
        If ComboMoneda.Text = "$" Then
            moneda = 0
        ElseIf ComboMoneda.Text = "U$S" Then
            moneda = 1
        End If
        Dim fechaprecioant As Date = DateUltimaCompra.Value.ToString("yyyy-MM-dd")
        Dim fecprecioant As String
        fecprecioant = Format(fechaprecioant, "yyyy-MM-dd")
        If TextIdLinea.Text <> "" Then
            Dim lc As New dLineaCotizacion
            Dim id As Long = TextIdLinea.Text.Trim
            lc.ID = id
            lc.IDCOTIZACION = idcotizacion
            lc.PRODUCTO = producto
            lc.CANTIDAD = cantidad
            lc.UNIDAD = unidad.ID
            lc.PRESENTACION = presentacion.ID
            lc.PRECIO = precio
            lc.MONEDA = moneda
            lc.FECHAPRECIO = fecprecioant
            If (lc.modificar(Usuario)) Then
                'MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                listarlineas()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim lc As New dLineaCotizacion
            lc.IDCOTIZACION = idcotizacion
            lc.PRODUCTO = producto
            lc.CANTIDAD = cantidad
            lc.UNIDAD = unidad.ID
            lc.PRESENTACION = presentacion.ID
            lc.PRECIO = precio
            lc.MONEDA = moneda
            lc.FECHAPRECIO = fecprecioant
            If (lc.guardar(Usuario)) Then
                'MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                listarlineas()
                limpiar2()
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub
    Private Sub listarlineas()
        Dim lc As New dLineaCotizacion
        Dim idcotizacion As Long = TextId.Text
        Dim lista As New ArrayList
        lista = lc.listarxidcotizacion(idcotizacion)
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each lc In lista
                    DataGridView1(columna, fila).Value = lc.ID
                    columna = columna + 1
                    Dim pro As New dProductos
                    pro.ID = lc.PRODUCTO
                    pro = pro.buscar
                    If Not pro Is Nothing Then
                        DataGridView1(columna, fila).Value = pro.NOMBRE
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = pro.DETALLE
                        columna = columna + 1
                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = lc.CANTIDAD
                    columna = columna + 1
                    Dim uni As New dUnidades
                    uni.ID = lc.UNIDAD
                    uni = uni.buscar
                    If Not uni Is Nothing Then
                        DataGridView1(columna, fila).Value = uni.NOMBRE
                        columna = columna + 1

                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    Dim pre As New dPresentacionUnidades
                    pre.ID = lc.PRESENTACION
                    pre = pre.buscar
                    If Not pre Is Nothing Then
                        DataGridView1(columna, fila).Value = pre.NOMBRE
                        columna = columna + 1

                    Else
                        DataGridView1(columna, fila).Value = ""
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = lc.PRECIO
                    columna = columna + 1
                    If lc.MONEDA = 0 Then
                        DataGridView1(columna, fila).Value = "$"
                        columna = columna + 1
                    ElseIf lc.MONEDA = 1 Then
                        DataGridView1(columna, fila).Value = "U$S"
                        columna = columna + 1
                    End If
                    DataGridView1(columna, fila).Value = lc.FECHAPRECIO
                    columna = 0
                    fila = fila + 1
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim v As New FormBuscarProveedor
        v.ShowDialog()
        If Not v.Proveedor Is Nothing Then
            Dim pro As dProveedores = v.Proveedor
            TextIdProveedor2.Text = pro.ID
            TextProveedor2.Text = pro.NOMBRE
            guardarcabezal()
            If pro.EMAIL <> "" Then
                ComboEmail2.Enabled = True
                ComboEmail2.Items.Add(pro.EMAIL)
                ComboEmail2.Text = pro.EMAIL
            End If
            If pro.EMAIL2 <> "" Then
                ComboEmail2.Items.Add(pro.EMAIL2)
            End If
            If pro.EMAIL3 <> "" Then
                ComboEmail2.Items.Add(pro.EMAIL3)
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim v As New FormBuscarProveedor
        v.ShowDialog()
        If Not v.Proveedor Is Nothing Then
            Dim pro As dProveedores = v.Proveedor
            TextIdProveedor3.Text = pro.ID
            TextProveedor3.Text = pro.NOMBRE
            guardarcabezal()
            If pro.EMAIL <> "" Then
                ComboEmail3.Enabled = True
                ComboEmail3.Items.Add(pro.EMAIL)
                ComboEmail3.Text = pro.EMAIL
            End If
            If pro.EMAIL3 <> "" Then
                ComboEmail3.Items.Add(pro.EMAIL2)
            End If
            If pro.EMAIL3 <> "" Then
                ComboEmail3.Items.Add(pro.EMAIL3)
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Eliminar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim lc As New dLineaCotizacion
            id = row.Cells("Id").Value
            lc.ID = id
            lc.eliminar(Usuario)
            limpiar2()
            listarlineas()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Editar" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim id As Long = 0
            Dim lc As New dLineaCotizacion
            id = row.Cells("Id").Value
            lc.ID = id
            lc = lc.buscar
            If Not lc Is Nothing Then
                TextIdLinea.Text = lc.ID
                TextIdProducto.Text = lc.PRODUCTO
                Dim p As New dProductos
                p.ID = lc.PRODUCTO
                p = p.buscar
                If Not p Is Nothing Then
                    TextProducto.Text = p.NOMBRE
                    TextDetalle.Text = p.DETALLE
                End If
                TextCantidad.Text = lc.CANTIDAD
                Dim uni As New dUnidades
                uni.ID = lc.UNIDAD
                uni = uni.buscar
                If Not uni Is Nothing Then
                    ComboUnidad.Text = uni.NOMBRE
                End If
                Dim pre As New dPresentacionUnidades
                pre.ID = lc.PRESENTACION
                pre = pre.buscar
                If Not pre Is Nothing Then
                    ComboPresentacion.Text = pre.NOMBRE
                End If
                TextPrecio.Text = lc.PRECIO
                If lc.MONEDA = 0 Then
                    ComboMoneda.Text = "$"
                ElseIf lc.MONEDA = 1 Then
                    ComboMoneda.Text = "U$S"
                End If
                If lc.FECHAPRECIO <> "00:00:00" Then
                    DateUltimaCompra.Value = lc.FECHAPRECIO
                End If
            End If
        End If
    End Sub
End Class