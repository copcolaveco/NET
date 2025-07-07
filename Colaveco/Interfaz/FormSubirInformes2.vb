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
    'Private Sub ButtonSubirInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirInforme.Click


    '    Dim saMarcar As New dSolicitudAnalisis
    '    saMarcar.ID = idficha
    '    Dim pi As New dPreinformes
    '    Dim fechaactual As Date = Now()
    '    Dim _fecha As String
    '    _fecha = Format(fechaactual, "yyyy-MM-dd")
    '    pi.FICHA = idficha
    '    Informe = idficha

    '    Try
    '        If tipoinforme = 1 Then
    '            subir_control() '_control()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 3 Then
    '            subir_agua()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 4 Then
    '            subir_atb()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 6 Then
    '            subir_parasitologia()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 7 Then
    '            subir_alimentos()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 8 Then
    '            subir_serologia()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 9 Then
    '            subir_patologia()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 10 Then
    '            subir_calidad()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 11 Then
    '            subir_ambiental()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 13 Then
    '            subir_nutricion()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 14 Then
    '            subir_suelos()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 15 Then
    '            subir_brucelosis()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 16 Then
    '            subir_efluentes()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 17 Then
    '            subir_bacteriologia()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 18 Then
    '            subir_bacteriologia_clinica()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 19 Then
    '            subir_foliares()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 20 Then
    '            subir_toxicologia()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)
    '        ElseIf tipoinforme = 21 Then
    '            subir_mineralesenleche()
    '            saMarcar.marcar(Usuario, _fecha)
    '            pi.marcarsubido(_fecha)

    '        End If

    '        '---------------GestorGX
    '        Dim gestorNuevo As New dNuevoGestor
    '        gestorNuevo.ID = idficha
    '        gestorNuevo.FECHAENVIO = _fecha
    '        gestorNuevo.modificarFechaEnvio(Usuario)
    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Private Sub ButtonSubirInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirInforme.Click
    '    Dim saMarcar As New dSolicitudAnalisis
    '    saMarcar.ID = idficha

    '    Dim pi As New dPreinformes
    '    pi.FICHA = idficha
    '    Informe = idficha

    '    Dim fechaActual As String = Format(Now(), "yyyy-MM-dd")

    '    Try
    '        ' Selecciona y ejecuta el método correspondiente según el tipo de informe
    '        Select Case tipoinforme
    '            Case 1 : subir_control()
    '            Case 3 : subir_agua()
    '            Case 4 : subir_atb()
    '            Case 6 : subir_parasitologia()
    '            Case 7 : subir_alimentos()
    '            Case 8 : subir_serologia()
    '            Case 9 : subir_patologia()
    '            Case 10 : subir_calidad()
    '            Case 11 : subir_ambiental()
    '            Case 13 : subir_nutricion()
    '            Case 14 : subir_suelos()
    '            Case 15 : subir_brucelosis()
    '            Case 16 : subir_efluentes()
    '            Case 17 : subir_bacteriologia()
    '            Case 18 : subir_bacteriologia_clinica()
    '            Case 19 : subir_foliares()
    '            Case 20 : subir_toxicologia()
    '            Case 21 : subir_mineralesenleche()
    '            Case Else
    '                MsgBox("Tipo de informe no reconocido. No se realizó ninguna acción.", MsgBoxStyle.Exclamation, "Atención")
    '                Exit Sub
    '        End Select

    '        ' Marcar informe como subido
    '        saMarcar.marcar(Usuario, fechaActual)
    '        pi.marcarsubido(fechaActual)

    '        ' Registrar fecha de envío en el Gestor
    '        Dim gestorNuevo As New dNuevoGestor
    '        gestorNuevo.ID = idficha
    '        gestorNuevo.FECHAENVIO = fechaActual
    '        gestorNuevo.modificarFechaEnvio(Usuario)

    '        MsgBox("El informe ha sido subido y marcado correctamente.", MsgBoxStyle.Information, "Operación Exitosa")

    '    Catch ex As Exception
    '        MsgBox("Se produjo un error al subir el informe: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    ' Clase para encapsular los parámetros que devuelve la función
    Public Class ParametrosSubirInforme
        Public Property Carpeta As Nullable(Of EnumCarpetaInforme)
        Public Property TipoInforme As Nullable(Of EnumTipoInforme)
        Public Property TipoControl As Nullable(Of Integer)
        Public Property TipoControlAdicional As Nullable(Of Integer)
        Public Property CondicionAdicional As Func(Of Boolean)
    End Class

    ' Función para obtener los parámetros según el tipo de informe
    Private Function ObtenerParametrosParaSubirInforme(tipoinforme As Integer) As ParametrosSubirInforme
        Select Case tipoinforme
            Case 1
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.CONTROL_LECHERO,
                    .TipoInforme = EnumTipoInforme.ControlLechero,
                    .TipoControl = EnumTipoControles.FisicoQuimico
                }
            Case 3
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.AGUA,
                    .TipoInforme = EnumTipoInforme.Agua,
                    .TipoControl = EnumTipoControles.Microbiologia
                }
            Case 4
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.ANTIBIOGRAMA,
                    .TipoInforme = EnumTipoInforme.AislamientoAntibiograma
                }
            Case 6
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.PARASITOLOGIA,
                    .TipoInforme = EnumTipoInforme.Parasitologia
                }
            Case 7
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.ALIMENTOS,
                    .TipoInforme = EnumTipoInforme.Alimentos,
                    .TipoControl = EnumTipoControles.Microbiologia
                }
            Case 8
                Return New ParametrosSubirInforme With {
                    .TipoInforme = EnumTipoInforme.Serologia
                }
            Case 9
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.PATOLOGIA,
                    .TipoInforme = EnumTipoInforme.Patologia
                }
            Case 10
                Dim condicion As Func(Of Boolean) = Function()
                                                        Dim csm As New dCalidadSolicitudMuestra
                                                        csm.FICHA = Informe
                                                        csm = csm.buscarxsolicitud()
                                                        Return csm.RB = 1 Or csm.INHIBIDORES = 1 Or csm.ESPORULADOS = 1 Or csm.PSICROTROFOS = 1
                                                    End Function
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.CALIDAD,
                    .TipoInforme = EnumTipoInforme.CalidadLeche,
                    .TipoControl = EnumTipoControles.FisicoQuimico,
                    .TipoControlAdicional = EnumTipoControles.Microbiologia,
                    .CondicionAdicional = condicion
                }
            Case 11
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.AMBIENTAL,
                    .TipoInforme = EnumTipoInforme.Ambiental
                }
            Case 13
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.NUTRICION,
                    .TipoInforme = EnumTipoInforme.Nutricion,
                    .TipoControl = EnumTipoControles.Nutricion
                }
            Case 14
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.SUELOS,
                    .TipoInforme = EnumTipoInforme.Suelos,
                    .TipoControl = EnumTipoControles.Suelos
                }
            Case 15
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.BRUCELOSIS_LECHE,
                    .TipoInforme = EnumTipoInforme.BrucelosisLeche
                }
            Case 16
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.EFLUENTES,
                    .TipoInforme = EnumTipoInforme.Efluentes,
                    .TipoControl = EnumTipoControles.Efluentes
                }
            Case 17
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.BACTERIOLOGIA,
                    .TipoInforme = EnumTipoInforme.BacteriologiaTanque
                }
            Case 18
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.BACTERIOLOGIA,
                    .TipoInforme = EnumTipoInforme.BacteriologiaClinica
                }
            Case 19
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.TOXICOLOGIA,
                    .TipoInforme = EnumTipoInforme.Foliares
                }
            Case 20
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.TOXICOLOGIA,
                    .TipoInforme = EnumTipoInforme.Toxicologia
                }
            Case 21
                Dim condicion As Func(Of Boolean) = Function()
                                                        Dim csm As New dCalidadSolicitudMuestra
                                                        csm.FICHA = Informe
                                                        csm = csm.buscarxsolicitud()
                                                        Return csm.RB = 1 Or csm.INHIBIDORES = 1 Or csm.ESPORULADOS = 1 Or csm.PSICROTROFOS = 1
                                                    End Function
                Return New ParametrosSubirInforme With {
                    .Carpeta = EnumCarpetaInforme.CALIDAD,
                    .TipoInforme = EnumTipoInforme.CalidadLeche,
                    .TipoControl = EnumTipoControles.FisicoQuimico,
                    .TipoControlAdicional = EnumTipoControles.Microbiologia,
                    .CondicionAdicional = condicion
                }
            Case Else
                Return Nothing
        End Select
    End Function

    ' Evento del botón que usa la función para ejecutar el flujo
    Private Sub ButtonSubirInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirInforme.Click
        Dim saMarcar As New dSolicitudAnalisis
        saMarcar.ID = idficha

        Dim pi As New dPreinformes
        pi.FICHA = idficha
        Informe = idficha

        Dim fechaActual As String = Format(Now(), "yyyy-MM-dd")

        Try
            Dim parametros = ObtenerParametrosParaSubirInforme(tipoinforme)
            If parametros Is Nothing Then
                MsgBox("Tipo de informe no reconocido. No se realizó ninguna acción.", MsgBoxStyle.Exclamation, "Atención")
                Exit Sub
            End If

            ' Si hay carpeta definida, mover archivos
            If parametros.Carpeta.HasValue Then
                mover_archivos(parametros.Carpeta.Value, parametros.TipoInforme.Value)

            End If

            ' Si hay que agregar control de informe
            If parametros.TipoControl.HasValue Then
                agregar_control_informe(parametros.TipoControl.Value)
            End If

            ' Control adicional si la condición está definida y se cumple
            If parametros.TipoControlAdicional.HasValue AndAlso parametros.CondicionAdicional IsNot Nothing Then
                If parametros.CondicionAdicional.Invoke() Then
                    agregar_control_informe(parametros.TipoControlAdicional.Value)
                End If
            End If

            ' Estado pago y demás (si es necesario que se llame antes o después, ajusta)
            estadoPago()

            ' Actualizar estados y preinforme
            actualizar_estados(abonado)
            actualizar_preInforme()

            ' Limpiar controles y marcar por defecto
            limpiar()
            marcarxdefecto()

            ' Marcar informe como subido
            saMarcar.marcar(Usuario, fechaActual)
            pi.marcarsubido(fechaActual)

            ' Registrar fecha de envío en Gestor
            Dim gestorNuevo As New dNuevoGestor
            gestorNuevo.ID = idficha
            gestorNuevo.FECHAENVIO = fechaActual
            gestorNuevo.modificarFechaEnvio(Usuario)

        Catch ex As Exception
            MsgBox("Se produjo un error al subir el informe: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub




    Private Sub subir_informe(
    moverCarpeta As EnumCarpetaInforme?,
    tipoInformeMover As EnumTipoInforme?,
    tipoControlAgregar As Integer?,
    Optional tipoControlAgregarAdicional As Integer? = Nothing,
    Optional condicionAdicional As Func(Of Boolean) = Nothing
)
        Try
            estadoPago()

            ' Mover archivos si los parámetros están indicados
            If moverCarpeta.HasValue AndAlso tipoInformeMover.HasValue Then
                mover_archivos(moverCarpeta.Value, tipoInformeMover.Value)
            End If

            actualizar_estados(abonado)
            actualizar_preInforme()

            ' Agregar control principal si aplica
            If tipoControlAgregar.HasValue Then
                agregar_control_informe(tipoControlAgregar.Value)
            End If

            ' Agregar control adicional si la condición se cumple
            If tipoControlAgregarAdicional.HasValue AndAlso condicionAdicional IsNot Nothing Then
                If condicionAdicional() Then
                    agregar_control_informe(tipoControlAgregarAdicional.Value)
                End If
            End If

            limpiar()
            marcarxdefecto()
        Catch ex As Exception
            ' Agregar log o manejo de error si es necesario
            MsgBox("Error al subir informe: " & ex.Message, MsgBoxStyle.Critical)
        End Try
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

    Private Sub cambiar_estado_gestor(ByVal nuevoEstado As Integer, ByVal control As EnumControles)

        'Gestor 
        Dim nuevoGestor As New dNuevoGestor
        nuevoGestor.ID = Informe
        nuevoGestor.SOLICITUDESTADOID = nuevoEstado
        nuevoGestor.modificar(Usuario)

        'Envio de Email si esta controlado y es con visualizacion 
        If nuevoEstado = EnumEstadoGestor.Finalizado_con_Visualización And control = EnumControles.NoControlado Then
            Return
        ElseIf nuevoEstado = EnumEstadoGestor.Finalizado_sin_Visualización Then
            Return
        ElseIf nuevoEstado = EnumEstadoGestor.Finalizado_con_Visualización And control = EnumControles.NoTieneControl Then
            enviomailInformeConVisualizacion()
        End If

    End Sub

    'Public Sub agregar_control_informe(ByVal tipoControl As Integer)
    '    Dim fechadesde As Date = Now
    '    Dim fechahasta As Date = Now
    '    Dim fechad As String
    '    Dim fechah As String
    '    fechad = Format(fechadesde, "yyyy-MM-dd")
    '    fechah = Format(fechahasta, "yyyy-MM-dd")
    '    Informe = TextFicha.Text.Trim

    '    Dim Control As dControlBase
    '    Select Case tipoControl
    '        Case EnumTipoControles.Efluentes
    '            Control = New dControlInformesEfluentes
    '        Case EnumTipoControles.FisicoQuimico
    '            Control = New dControlInformesFQ
    '        Case EnumTipoControles.Microbiologia
    '            Control = New dControlInformesMicro
    '        Case EnumTipoControles.Nutricion
    '            Control = New dControlInformesNutricion
    '        Case EnumTipoControles.Suelos
    '            Control = New dControlInformesSuelos
    '    End Select

    '    Dim lista As ArrayList = Control.listarxtipoxfecha(tipoControl, fechad, fechah)
    '    If Not lista Is Nothing Then
    '        If lista.Count < 6 Then
    '            Control.FECHACONTROL = fechad
    '            Control.FICHA = Informe
    '            Control.FECHA = fechad
    '            Control.TIPO = tipoinforme
    '            Control.RESULTADO = 0
    '            Control.COINCIDE = 0
    '            Control.OBSERVACIONES = ""
    '            Control.CONTROLADOR = 100
    '            Control.CONTROLADO = 0
    '            Control.guardar()

    '            Dim controlGestor As New dNGControl
    '            Try
    '                'Registro en Gestor Nuevo
    '                controlGestor.InformeId = Informe
    '                controlGestor.UsuarioId = _usuario.ID
    '                controlGestor.ControlTipoId = tipoControl
    '                controlGestor.ControlCoincide = 0
    '                controlGestor.ControlControlado = 0
    '                controlGestor.ControlFechaIngreso = Today.ToString("yyyy-MM-dd HH:mm:ss")
    '                controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
    '                controlGestor.ControlInformeTipo = tipoinforme
    '                controlGestor.ControlNoConformidad = 0
    '                controlGestor.ControlObservaciones = "Se creo Control"
    '                controlGestor.ControlOpcMejora = 0
    '                controlGestor.ControlResultado = 0
    '                controlGestor.guardar()
    '            Catch ex As Exception

    '            End Try

    '            ' Grabar estado de la ficha
    '            Dim est As New dEstados
    '            est.FICHA = Informe
    '            est.ESTADO = 6
    '            est.FECHA = fechad
    '            est.guardar2()
    '            est = Nothing
    '            '****************************
    '        End If
    '    Else
    '        Control.FECHACONTROL = fechad
    '        Control.FICHA = Informe
    '        Control.FECHA = fechad
    '        Control.TIPO = tipoinforme
    '        Control.RESULTADO = 0
    '        Control.COINCIDE = 0
    '        Control.OBSERVACIONES = ""
    '        Control.CONTROLADOR = 100
    '        Control.CONTROLADO = 0
    '        Control.guardar()
    '        Control = Nothing

    '        Dim controlGestor As New dNGControl
    '        Try
    '            'Registro en Gestor Nuevo
    '            controlGestor.InformeId = Informe
    '            controlGestor.UsuarioId = _usuario.ID
    '            controlGestor.ControlTipoId = tipoControl
    '            controlGestor.ControlCoincide = 0
    '            controlGestor.ControlControlado = 0
    '            controlGestor.ControlFechaIngreso = Today.ToString("yyyy-MM-dd HH:mm:ss")
    '            controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
    '            controlGestor.ControlInformeTipo = tipoinforme
    '            controlGestor.ControlNoConformidad = 0
    '            controlGestor.ControlObservaciones = "Se creo Control"
    '            controlGestor.ControlOpcMejora = 0
    '            controlGestor.ControlResultado = 0
    '            controlGestor.guardar()
    '        Catch ex As Exception

    '        End Try

    '        ' Grabar estado de la ficha
    '        Dim est As New dEstados
    '        est.FICHA = Informe
    '        est.ESTADO = 6
    '        est.FECHA = fechad
    '        est.guardar2()
    '        est = Nothing
    '        '****************************
    '    End If

    'End Sub

    Public Sub agregar_control_informe(ByVal tipoControl As Integer)
        Dim fechaActual As String = Format(Now(), "yyyy-MM-dd")
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
            Case Else
                MsgBox("Tipo de control no válido.", MsgBoxStyle.Exclamation, "Atención")
                Exit Sub
        End Select

        Dim lista As ArrayList = Control.listarxtipoxfecha(tipoControl, fechaActual, fechaActual, Informe)
        Dim debeAgregarControl As Boolean = (lista Is Nothing) OrElse (lista.Count < 6)

        If debeAgregarControl Then
            ' Asignar propiedades comunes
            With Control
                .FECHACONTROL = fechaActual
                .FICHA = Informe
                .FECHA = fechaActual
                .TIPO = tipoinforme
                .RESULTADO = 0
                .COINCIDE = 0
                .OBSERVACIONES = ""
                .CONTROLADOR = 100
                .CONTROLADO = 0
                .guardar()
            End With

            ' Guardar en Gestor Nuevo
            Try
                Dim controlGestor As New dNGControl With {
                    .InformeId = Informe,
                    .UsuarioId = _usuario.ID,
                    .ControlTipoId = tipoControl,
                    .ControlCoincide = 0,
                    .ControlControlado = 0,
                    .ControlFechaIngreso = Today.ToString("yyyy-MM-dd HH:mm:ss"),
                    .ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss"),
                    .ControlInformeTipo = tipoinforme,
                    .ControlNoConformidad = 0,
                    .ControlObservaciones = "Se creó control",
                    .ControlOpcMejora = 0,
                    .ControlResultado = 0
                }
                controlGestor.guardar()
            Catch ex As Exception
                ' Podrías agregar log aquí para registrar el error
            End Try

            ' Grabar estado de la ficha
            Dim est As New dEstados With {
                .FICHA = Informe,
                .ESTADO = 6,
                .FECHA = fechaActual
            }
            est.guardar2()
        Else
            MsgBox("Ya existen 6 o más controles para este tipo en la fecha actual.", MsgBoxStyle.Information, "Información")
        End If

        Control = Nothing
    End Sub

    Public Sub mover_archivos(ByVal enumCarpeta As EnumCarpetaInforme, ByVal tipoInforme As Long)
        Dim carpetaInforme As String
        carpetaInforme = EnumCarpetaInformeToString(enumCarpeta)

        Dim nombreInforme As String
        nombreInforme = Informe ' Asumo que Informe es variable de módulo

        Dim rutaDestinoBase As String
        rutaDestinoBase = "\\ROBOT\INFORMES PARA SUBIR\"
        Dim rutaOrigenBase As String
        rutaOrigenBase = "\\ROBOT\PREINFORMES\"

        Dim Listax() As String
        Dim i As Integer

        ' CONTROL LECHERO - unir PDF
        If tipoInforme = EnumTipoInforme.ControlLechero Then
            ReDim Listax(1)
            Listax(0) = "\\192.168.1.10\E\NET\" & carpetaInforme & "\Graficas\" & nombreInforme & ".pdf"
            Listax(1) = "\\192.168.1.10\E\NET\" & carpetaInforme & "\Graficas\x" & nombreInforme & ".pdf"

            Dim sFileJoin As String
            sFileJoin = rutaOrigenBase & "CONTROL\" & nombreInforme & ".pdf"

            On Error GoTo ErrorPDF
            Dim Doc As New Document
            Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim copy As New PdfCopy(Doc, fs)
            Doc.Open()

            Dim Rd As PdfReader
            Dim n As Integer, page As Integer

            For i = LBound(Listax) To UBound(Listax)
                If Dir(Listax(i)) <> "" Then
                    Rd = New PdfReader(Listax(i))
                    n = Rd.NumberOfPages
                    For page = 1 To n
                        copy.AddPage(copy.GetImportedPage(Rd, page))
                    Next page
                    copy.FreeReader(Rd)
                    Rd.Close()
                End If
            Next i

            Doc.Close()
ErrorPDF:

            ' MOVER ARCHIVO TXT
            Call MoverArchivo(rutaOrigenBase & "CONTROL\" & nombreInforme & ".txt", rutaDestinoBase & nombreInforme & ".txt")
        End If

        ' ARCHIVO XLS
        Dim rutaXlsOrigen As String
        If tipoInforme = EnumTipoInforme.ControlLechero Then
            rutaXlsOrigen = rutaOrigenBase & "CONTROL\" & nombreInforme & ".xls"
        Else
            rutaXlsOrigen = rutaOrigenBase & carpetaInforme & "\" & nombreInforme & ".xls"
        End If
        Call MoverArchivo(rutaXlsOrigen, rutaDestinoBase & nombreInforme & ".xls")

        ' INFORME SUELOS - unir PDF
        If tipoInforme = EnumTipoInforme.Suelos Then
            i = 0
            ReDim Listax(0)
            Listax(0) = rutaOrigenBase & "SUELOS\" & nombreInforme & ".pdf"

            If isAnexo Then
                i = i + 1
                ReDim Preserve Listax(i)
                Listax(i) = rutaOrigenBase & "SUELOS\anexo" & nombreInforme & ".pdf"
            End If

            If isAnexoPH Then
                i = i + 1
                ReDim Preserve Listax(i)
                Listax(i) = rutaOrigenBase & "SUELOS\anexoPH" & nombreInforme & ".pdf"
            End If

            If isAnexoCationes Then
                i = i + 1
                ReDim Preserve Listax(i)
                Listax(i) = rutaOrigenBase & "SUELOS\anexoCationes" & nombreInforme & ".pdf"
            End If

            Dim sFileJoin As String
            sFileJoin = rutaDestinoBase & nombreInforme & ".pdf"

            On Error GoTo ErrorPDFSuelos
            Dim Doc2 As New Document
            Dim fs2 As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim copy2 As New PdfCopy(Doc2, fs2)
            Doc2.Open()

            For i = LBound(Listax) To UBound(Listax)
                If Dir(Listax(i)) <> "" Then
                    Dim Rd = New PdfReader(Listax(i))
                    Dim n = Rd.NumberOfPages
                    For page = 1 To n
                        copy2.AddPage(copy2.GetImportedPage(Rd, page))
                    Next page
                    copy2.FreeReader(Rd)
                    Rd.Close()
                End If
            Next i

            Doc2.Close()
ErrorPDFSuelos:
        Else
            ' OTROS INFORMES - mover PDF directamente
            Dim origenPdf As String
            If tipoInforme = EnumTipoInforme.ControlLechero Then
                origenPdf = rutaOrigenBase & "CONTROL\" & nombreInforme & ".pdf"
            Else
                origenPdf = rutaOrigenBase & carpetaInforme & "\" & nombreInforme & ".pdf"
            End If

            Call MoverArchivo(origenPdf, rutaDestinoBase & nombreInforme & ".pdf")
        End If

        CopiarArchivosalGestor(Informe)
    End Sub

    '--------------------------
    ' MoverArchivo auxiliar VB6
    '--------------------------
    Private Sub MoverArchivo(ByVal origen As String, ByVal destino As String)
        If Dir(origen) <> "" Then
            On Error Resume Next
            FileCopy(origen, destino)
            Kill(origen)
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

    'Public Sub actualizar_estados(ByVal abonado As Long)
    '    Dim sol As New dSolicitudAnalisis

    '    ' Grabar si es NO abonado sin visualización
    '    If abonado = 0 Then
    '        Dim fechaact As Date = Now()
    '        Dim fecact As String
    '        Dim muestras As Integer = 0
    '        fecact = Format(fechaact, "yyyy-MM-dd")

    '        Dim sv As New dSinVisualizacion
    '        sol.ID = Informe
    '        sol = sol.buscar

    '        Dim nuevoGestor As New dNuevoGestor
    '        nuevoGestor.ID = Informe
    '        nuevoGestor.SOLICITUDESTADOID = 2
    '        nuevoGestor.modificar(Usuario)

    '        If Not sol Is Nothing Then
    '            muestras = sol.NMUESTRAS
    '        End If

    '        Dim importe As Double = sol.IMPORTE
    '        Dim visualizacion As Integer = 0
    '        Dim observaciones As String = ""

    '        If TextComentarios.Text <> "" Then
    '            observaciones = TextComentarios.Text.Trim
    '        End If

    '        sv.FICHA = Informe
    '        fichasv = Informe
    '        sv.FECHA = fecact
    '        sv.MUESTRAS = muestras
    '        sv.IMPORTE = importe
    '        sv.VISUALIZACION = visualizacion
    '        sv.FECHAVISUALIZACION = fecact
    '        sv.OBSERVACIONES = observaciones
    '        sv.guardar()

    '        Dim p As New dCliente
    '        Dim prod As Long = sol.IDPRODUCTOR
    '        p.ID = sol.IDPRODUCTOR
    '        p = p.buscar

    '        If p.NOT_EMAIL_ANALISIS1 <> "" Then
    '            email = RTrim(p.NOT_EMAIL_ANALISIS1)
    '        ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
    '            email = RTrim(p.NOT_EMAIL_ANALISIS2)
    '        ElseIf p.EMAIL <> "" Then
    '            email = RTrim(p.EMAIL)
    '        End If

    '        'Email a informes no abonados sin visualización
    '        Dim v As New FormCorreoMorosos(Usuario, email, Informe)
    '        v.Show()

    '        p = Nothing
    '        prod = Nothing
    '        sv = Nothing
    '        sol = Nothing

    '        'No abonado con visualización o Abonado
    '    ElseIf abonado = 2 Or abonado = 1 Then

    '        sol.ID = Informe
    '        sol = sol.buscar

    '        'Gestor, envio mail al cliente, verifico si tiene Control pendiente de aprovación 

    '        Dim fichaControl As New dControlInformesFQ
    '        Dim estado As Integer = fichaControl.obtener_estado_control_ficha(Informe)
    '        Dim control As EnumControles = CType(estado, EnumControles)

    '        Select Case control
    '            Case EnumControles.Controlado
    '                subir_informe_gestor()
    '                MsgBox("Se finalizó el proceso y se notifico al cliente por mail, el informe fué controlado por un técnmico y subido al Gestor modificando a su nuevo estado.")
    '            Case EnumControles.NoControlado
    '                MsgBox("Informe en proceso, debe ser controlado por un técnico para ser Finalizado.")
    '            Case EnumControles.NoTieneControl
    '                subir_informe_gestor()
    '                MsgBox("Se finalizó el proceso y se notifico al cliente por mail, Informe no tenía asociado un control para hacerse por lo tanto fué subido al Gestor y modificado su estado.")
    '        End Select

    '        sol = Nothing

    '    End If
    'End Sub

    Public Sub actualizar_estados(ByVal abonado As Long)
        Dim sol As New dSolicitudAnalisis
        Dim fechaActual As Date = Now()
        Dim fechaFormatoSQL As String = Format(fechaActual, "yyyy-MM-dd")
        Dim muestras As Integer = 0
        Dim observaciones As String = ""
        Dim importe As Double = 0
        Dim emailCliente As String = ""

        ' Buscar la solicitud relacionada al informe
        sol.ID = Informe
        sol = sol.buscar

        If sol Is Nothing Then
            MsgBox("No se encontró la solicitud correspondiente al informe indicado.", vbCritical, "Error al buscar solicitud")
            Exit Sub
        End If

        muestras = sol.NMUESTRAS
        importe = sol.IMPORTE

        If abonado = 0 Then
            ' Caso: No abonado sin visualización

            Dim nuevoGestor As New dNuevoGestor With {
                .ID = Informe,
                .SOLICITUDESTADOID = 2
            }
            nuevoGestor.modificar(Usuario)

            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If

            Dim sv As New dSinVisualizacion With {
                .FICHA = Informe,
                .FECHA = fechaFormatoSQL,
                .MUESTRAS = muestras,
                .IMPORTE = importe,
                .VISUALIZACION = 0,
                .FECHAVISUALIZACION = fechaFormatoSQL,
                .OBSERVACIONES = observaciones
            }
            sv.guardar()

            ' Buscar correo del cliente
            Dim cliente As New dCliente With {.ID = sol.IDPRODUCTOR}
            cliente = cliente.buscar

            If cliente IsNot Nothing Then
                If cliente.NOT_EMAIL_ANALISIS1 <> "" Then
                    emailCliente = RTrim(cliente.NOT_EMAIL_ANALISIS1)
                ElseIf cliente.NOT_EMAIL_ANALISIS2 <> "" Then
                    emailCliente = RTrim(cliente.NOT_EMAIL_ANALISIS2)
                ElseIf cliente.EMAIL <> "" Then
                    emailCliente = RTrim(cliente.EMAIL)
                End If
            End If

            ' Mostrar formulario de envío de correo
            Dim correoForm As New FormCorreoMorosos(Usuario, emailCliente, Informe)
            correoForm.Show()
            Dim fichaControl As New dControlInformesFQ
            Dim estadoControl As Integer = fichaControl.obtener_estado_control_ficha(Informe)
            Dim control As EnumControles = CType(estadoControl, EnumControles)

            cambiar_estado_gestor(EnumEstadoGestor.Finalizado_sin_Visualización, control)

            MsgBox("Informe finalizado Sin Visualización.", vbInformation, "Subir Informe")

        ElseIf abonado = 1 Or abonado = 2 Then
            ' Caso: Abonado o No abonado con visualización

            ' Verificar estado de control
            Dim fichaControl As New dControlInformesFQ
            Dim estadoControl As Integer = fichaControl.obtener_estado_control_ficha(Informe)
            Dim control As EnumControles = CType(estadoControl, EnumControles)
            Dim nuevoEstado As Integer = EnumEstadoGestor.Finalizado_con_Visualización

            Select Case control
                Case EnumControles.NoControlado
                    cambiar_estado_gestor(nuevoEstado, control)
                    MsgBox("Informe finalizado con visualización, para controlar por un técnico.", vbExclamation, "Subir Informe")
                Case EnumControles.NoTieneControl
                    cambiar_estado_gestor(nuevoEstado, control)
                    MsgBox("Informe finalizado con visualización, no se le asigna control.", vbInformation, "Subir Informe")
            End Select
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

    Public Sub CopiarArchivosalGestor(ByVal ficha As Long)
        Dim rutaOrigen As String = "\\ROBOT\INFORMES PARA SUBIR\"
        Dim rutaDestino As String = "\\192.168.1.118\Informes"

        ' Asegura que la carpeta destino exista
        If Not Directory.Exists(rutaDestino) Then
            Directory.CreateDirectory(rutaDestino)
        End If

        ' Extensiones a mover
        Dim extensiones() As String = {".pdf", ".xls", ".xlsx", ".txt"}

        For Each ext As String In extensiones
            Dim archivoOrigen As String = Path.Combine(rutaOrigen, ficha & ext)
            Dim archivoDestino As String = Path.Combine(rutaDestino, ficha & ext)

            If File.Exists(archivoOrigen) Then
                If Not File.Exists(archivoDestino) Then
                    Try
                        File.Copy(archivoOrigen, archivoDestino)
                    Catch ex As Exception
                        MessageBox.Show("Error al copiar archivo " & ficha & ext & ": " & ex.Message)
                    End Try
                Else
                    ' Archivo ya existe en destino, podés decidir qué hacer
                    ' Por ejemplo, eliminar y copiar de nuevo, o renombrar, o simplemente ignorar
                    ' Aquí lo dejamos como ignorado
                    'MessageBox.Show("El archivo ya existe: " & archivoDestino)
                End If
            End If
        Next
    End Sub

End Class