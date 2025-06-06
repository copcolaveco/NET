﻿Public Class FormReclamos
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Private _reclamos As dReclamos
    Public Property Reclamos() As dReclamos
        Get
            Return _reclamos
        End Get
        Set(ByVal value As dReclamos)
            _reclamos = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarLista()
        limpiar()
        permitiracceso()
    End Sub

    Private Sub permitiracceso()
        ButtonEliminar.Enabled = False
        If Usuario.USUARIO = "CA" Or Usuario.USUARIO = "JMS" Then
            ButtonEliminar.Enabled = True
        Else
            ButtonEliminar.Enabled = False
        End If
    End Sub
    Public Sub cargarLista()
        Dim r As New dReclamos
        Dim lista As New ArrayList
        lista = r.listar
        ListReclamos.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each r In lista
                    ListReclamos().Items.Add(r)
                Next
            End If
        End If
    End Sub
    Public Sub limpiar()
        TextId.Text = ""
        ComboTipo.Text = ""
        CheckAcreditado.Checked = False
        DateFecha.Value = Now
        ComboCategoria.Text = ""
        ComboFuente.Text = ""
        TextDescripcion.Text = ""
        TextAnalisis.Text = ""
        TextAcciones.Text = ""
        TextResponsable.Text = ""
        DateAccion.Value = Now
        ComboSeguimiento.Text = ""
        TextCierreProblema.Text = ""
        TextObservaciones.Text = ""
        ComboTipo.Focus()
    End Sub

    Private Sub ButtonNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNuevo.Click
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not ListReclamos.SelectedItem Is Nothing Then
            If MsgBox("El registro será eliminado, ¿desea continuar?", MsgBoxStyle.OkCancel, "Atención") = MsgBoxResult.Ok Then
                Dim r As New dReclamos
                Dim id As Long = CType(TextId.Text, Long)
                r.ID = id
                If (r.eliminar(Usuario)) Then
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, "Atención")
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        limpiar()
        cargarLista()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim tipo As String = ComboTipo.Text.Trim
        Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim categoria As String = ComboCategoria.Text.Trim
        Dim fuente As String = ComboFuente.Text.Trim
        Dim descripcion As String = TextDescripcion.Text
        Dim analisis As String = TextAnalisis.Text
        Dim acciones As String = TextAcciones.Text
        Dim responsable As String = TextResponsable.Text
        Dim fechaaccion As Date = DateAccion.Value.ToString("yyyy-MM-dd")
        Dim seguimiento As String = ComboSeguimiento.Text.Trim
        Dim cierreproblema As String = TextCierreProblema.Text
        Dim observaciones As String = TextObservaciones.Text
        Dim acreditado As Integer = 0
        If CheckAcreditado.Checked = True Then
            acreditado = 1
        End If
        'If TextIdProductor.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de productor", MsgBoxStyle.Exclamation, "Atención") : TextIdProductor.Focus() : Exit Sub
        
        If Not ListReclamos Is Nothing And TextId.Text.Trim.Length > 0 Then
            If TextId.Text.Trim.Length > 0 Then
                Dim rec As New dReclamos()
                Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                Dim fecaccion As String
                fec = Format(fecha, "yyyy-MM-dd")
                fecaccion = Format(fechaaccion, "yyyy-MM-dd")
                rec.ID = id
                rec.TIPO = tipo
                rec.FECHA = fec
                rec.CATEGORIA = categoria
                rec.FUENTE = fuente
                rec.DESCRIPCION = descripcion
                rec.ANALISIS = analisis
                rec.ACCIONES = acciones
                rec.RESPONSABLE = responsable
                rec.FECHAACCION = fecaccion
                rec.SEGUIMIENTO = seguimiento
                rec.CIERREPROBLEMA = cierreproblema
                rec.OBSERVACIONES = observaciones
                rec.ACREDITADO = acreditado
                If Usuario.USUARIO = "CA" Or Usuario.USUARIO = "JMS" Or Usuario.USUARIO = "MD" Then
                    If (rec.modificar(Usuario)) Then
                        MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
                        enviomail()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    MsgBox("No tiene permisos para modificar el registro.", MsgBoxStyle.Information, "Atención")
                End If
            End If
        Else
            If ComboTipo.Text.Trim.Length > 0 Then
                Dim rec As New dReclamos()
                'Dim id As Long = CType(TextId.Text.Trim, Long)
                Dim fec As String
                Dim fecaccion As String
                fec = Format(fecha, "yyyy-MM-dd")
                fecaccion = Format(fechaaccion, "yyyy-MM-dd")
                'rec.ID = id
                rec.TIPO = tipo
                rec.FECHA = fec
                rec.CATEGORIA = categoria
                rec.FUENTE = fuente
                rec.DESCRIPCION = descripcion
                rec.ANALISIS = analisis
                rec.ACCIONES = acciones
                rec.RESPONSABLE = responsable
                rec.FECHAACCION = fecaccion
                rec.SEGUIMIENTO = seguimiento
                rec.CIERREPROBLEMA = cierreproblema
                rec.OBSERVACIONES = observaciones
                rec.ACREDITADO = acreditado
                If (rec.guardar(Usuario)) Then
                    enviomail()
                    MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
                    limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        End If
        cargarLista()
        limpiar()
    End Sub

    Private Sub ListReclamos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListReclamos.SelectedIndexChanged
        limpiar()
        If ListReclamos.SelectedItems.Count = 1 Then
            Dim rec As dReclamos = CType(ListReclamos.SelectedItem, dReclamos)
            TextId.Text = rec.ID
            ComboTipo.Text = rec.TIPO
            If rec.ACREDITADO = 1 Then
                CheckAcreditado.Checked = True
            Else
                CheckAcreditado.Checked = False
            End If
            DateFecha.Value = rec.FECHA
            ComboCategoria.Text = rec.CATEGORIA
            ComboFuente.Text = rec.FUENTE
            TextDescripcion.Text = rec.DESCRIPCION
            TextAnalisis.Text = rec.ANALISIS
            TextAcciones.Text = rec.ACCIONES
            TextResponsable.Text = rec.RESPONSABLE
            DateAccion.Value = rec.FECHAACCION
            ComboSeguimiento.Text = rec.SEGUIMIENTO
            TextCierreProblema.Text = rec.CIERREPROBLEMA
            TextObservaciones.Text = rec.OBSERVACIONES
            DateFecha.Focus()
        End If
    End Sub

    Private Sub ButtonListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        Dim v As New FormListarReclamos
        v.ShowDialog()
    End Sub

    Private Sub ComboSeguimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSeguimiento.SelectedIndexChanged

    End Sub

    Private Sub ButtonAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAC.Click
        Dim num As Long = 0
        num = TextId.Text.Trim
        If num = 0 Then
            MsgBox("Primero debe guardar el reclamo, sugerencia o no conformidad!")
            Exit Sub
        Else
            Dim v As New FormAccionCorrectiva(Usuario, num)
            v.Show()
        End If
       
    End Sub


    Private Sub enviomail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim nombre_productor As String = ""
        Dim tipo As String = ""
        tipo = ComboTipo.SelectedItem.ToString

        Dim texto As String = ""
        texto = "Se ha ingresado un nuevo RECLAMO del tipo: " & tipo & ""

        'CONFIGURACIÓN DEL STMP 
        ' Llamamos al método buscar para obtener el objeto Credenciales
        Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

        _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
        _SMTP.Host = objetoCredenciales.CredencialesHost
        _SMTP.Port = 25
        _SMTP.EnableSsl = False

        Try
            _Message.[To].Add("qc.colaveco@gmail.com")

        Catch ex As System.Net.Mail.SmtpException

        End Try

        'Cuenta de Correo al que se le quiere enviar el e-mail 
        _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
        'Quien lo envía 
        _Message.Subject = "Reclamo - Colaveco"
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
            MessageBox.Show("Error!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
End Class