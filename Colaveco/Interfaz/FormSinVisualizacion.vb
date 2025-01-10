Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.Net
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports Newtonsoft.Json
Public Class FormSinVisualizacion
    Private tipoinforme As Integer = 0
    Private _usuario As dUsuario
    Private idproductorweb_com As Long = 0
    Private productorweb_com As String = ""
    Private carpeta As Long = 0
    Private excel As Integer = 0
    Private pdf As Integer = 0
    Private csv As Integer = 0
    Private mensaje As String = ""
    Private idficha As Long = 0
    Private abonado_ As Integer = 0
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
        DateFecha.Value = Now
        Usuario = u
        listarSV()
        listarCV()
    End Sub
#End Region
   
    Private Sub listarSV()
        Dim sv As New dSinVisualizacion
        Dim lista As New ArrayList
        lista = sv.listarsv
        DataGridView1.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView1.Rows.Add(lista.Count)
                For Each sv In lista
                    DataGridView1(columna, fila).Value = sv.ID
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sv.FICHA
                    columna = columna + 1
                    DataGridView1(columna, fila).Value = sv.FECHA
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sv.FICHA
                    sa = sa.buscar
                    Dim pro As New dCliente
                    pro.ID = sa.IDPRODUCTOR
                    pro = pro.buscar
                    Dim ti As New dTipoInforme
                    ti.ID = sa.IDTIPOINFORME
                    ti = ti.buscar
                    If Not sa Is Nothing Then
                        If Not pro Is Nothing Then
                            DataGridView1(columna, fila).Value = pro.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        If Not ti Is Nothing Then
                            DataGridView1(columna, fila).Value = ti.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = sv.MUESTRAS
                        columna = columna + 1
                        DataGridView1(columna, fila).Value = sv.IMPORTE
                        columna = columna + 1
                        If sv.ABONADO = 0 Then
                            DataGridView1(columna, fila).Value = False
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = True
                            columna = columna + 1
                        End If
                        If sv.VISUALIZACION = 0 Then
                            DataGridView1(columna, fila).Value = False
                            columna = columna + 1
                        Else
                            DataGridView1(columna, fila).Value = True
                            columna = columna + 1
                        End If
                        DataGridView1(columna, fila).Value = sv.FECHAVISUALIZACION
                        columna = columna + 1
                        If sv.OBSERVACIONES <> "" Then
                            DataGridView1(columna, fila).Value = sv.OBSERVACIONES
                            columna = 0
                            fila = fila + 1
                        Else
                            DataGridView1(columna, fila).Value = ""
                            columna = 0
                            fila = fila + 1
                        End If
                    End If
                Next
                'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    Private Sub listarCV()
        Dim sv As New dSinVisualizacion
        Dim lista As New ArrayList
        lista = sv.listarcv
        DataGridView2.Rows.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                Dim fila As Integer = 0
                Dim columna As Integer = 0
                DataGridView2.Rows.Add(lista.Count)
                For Each sv In lista
                    DataGridView2(columna, fila).Value = sv.ID
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = sv.FICHA
                    columna = columna + 1
                    DataGridView2(columna, fila).Value = sv.FECHA
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sv.FICHA
                    sa = sa.buscar
                    Dim pro As New dCliente
                    pro.ID = sa.IDPRODUCTOR
                    pro = pro.buscar
                    Dim ti As New dTipoInforme
                    ti.ID = sa.IDTIPOINFORME
                    ti = ti.buscar
                    If Not sa Is Nothing Then
                        If Not pro Is Nothing Then
                            DataGridView2(columna, fila).Value = pro.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        If Not ti Is Nothing Then
                            DataGridView2(columna, fila).Value = ti.NOMBRE
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = ""
                            columna = columna + 1
                        End If
                        DataGridView2(columna, fila).Value = sv.MUESTRAS
                        columna = columna + 1
                        DataGridView2(columna, fila).Value = sv.IMPORTE
                        columna = columna + 1
                        If sv.ABONADO = 0 Then
                            DataGridView2(columna, fila).Value = False
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = True
                            columna = columna + 1
                        End If
                        If sv.VISUALIZACION = 0 Then
                            DataGridView2(columna, fila).Value = False
                            columna = columna + 1
                        Else
                            DataGridView2(columna, fila).Value = True
                            columna = columna + 1
                        End If
                        DataGridView2(columna, fila).Value = sv.FECHAVISUALIZACION
                        columna = columna + 1
                        If sv.OBSERVACIONES <> "" Then
                            DataGridView2(columna, fila).Value = sv.OBSERVACIONES
                            columna = 0
                            fila = fila + 1
                        Else
                            DataGridView2(columna, fila).Value = ""
                            columna = 0
                            fila = fila + 1
                        End If
                    End If
                Next
                'DataGridView2.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            End If
        End If
    End Sub
    'Private Sub listartodos()
    '    Dim sv As New dSinVisualizacion
    '    Dim lista As New ArrayList
    '    lista = sv.listar
    '    DataGridView1.Rows.Clear()
    '    If Not lista Is Nothing Then
    '        If lista.Count > 0 Then
    '            Dim fila As Integer = 0
    '            Dim columna As Integer = 0
    '            DataGridView1.Rows.Add(lista.Count)
    '            For Each sv In lista
    '                DataGridView1(columna, fila).Value = sv.ID
    '                columna = columna + 1
    '                DataGridView1(columna, fila).Value = sv.FICHA
    '                columna = columna + 1
    '                DataGridView1(columna, fila).Value = sv.FECHA
    '                columna = columna + 1
    '                Dim sa As New dSolicitudAnalisis
    '                sa.ID = sv.FICHA
    '                sa = sa.buscar
    '                Dim pro As New dCliente
    '                pro.ID = sa.IDPRODUCTOR
    '                pro = pro.buscar
    '                Dim ti As New dTipoInforme
    '                ti.ID = sa.IDTIPOINFORME
    '                ti = ti.buscar
    '                If Not sa Is Nothing Then
    '                    If Not pro Is Nothing Then
    '                        DataGridView1(columna, fila).Value = pro.NOMBRE
    '                        columna = columna + 1
    '                    Else
    '                        DataGridView1(columna, fila).Value = ""
    '                        columna = columna + 1
    '                    End If
    '                    If Not ti Is Nothing Then
    '                        DataGridView1(columna, fila).Value = ti.NOMBRE
    '                        columna = columna + 1
    '                    Else
    '                        DataGridView1(columna, fila).Value = ""
    '                        columna = columna + 1
    '                    End If
    '                    DataGridView1(columna, fila).Value = sv.MUESTRAS
    '                    columna = columna + 1
    '                    DataGridView1(columna, fila).Value = sv.IMPORTE
    '                    columna = columna + 1
    '                    If sv.ABONADO = 0 Then
    '                        DataGridView1(columna, fila).Value = False
    '                        columna = columna + 1
    '                    Else
    '                        DataGridView1(columna, fila).Value = True
    '                        columna = columna + 1
    '                    End If
    '                    If sv.VISUALIZACION = 0 Then
    '                        DataGridView1(columna, fila).Value = False
    '                        columna = columna + 1
    '                    Else
    '                        DataGridView1(columna, fila).Value = True
    '                        columna = columna + 1
    '                    End If
    '                    DataGridView1(columna, fila).Value = sv.FECHAVISUALIZACION
    '                    columna = columna + 1
    '                    If sv.OBSERVACIONES <> "" Then
    '                        DataGridView1(columna, fila).Value = sv.OBSERVACIONES
    '                        columna = 0
    '                        fila = fila + 1
    '                    Else
    '                        DataGridView1(columna, fila).Value = ""
    '                        columna = 0
    '                        fila = fila + 1
    '                    End If
    '                End If
    '            Next
    '            'DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
    '        End If
    '    End If
    'End Sub
    Private Sub listar()
        listarSV()
        listarCV()
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
       
        If DataGridView1.Columns(e.ColumnIndex).Name = "Abonado2" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            Dim id As Long = 0
            Dim c As New dSinVisualizacion
            c.ID = row.Cells("Id").Value
            c = c.buscar
            Dim ficha As Long = 0
            ficha = c.FICHA
            idficha = ficha
            c.marcarabonado(Usuario, fec)
            c.marcarvisualizacion(Usuario, fec)
            abonado_ = 2
            'marcarweb(ficha, abonado_)
            'subir_ficha(ficha, abonado_)
            'gestorColaveco

            Dim nuevoGestor As New dNuevoGestor
            nuevoGestor.ID = ficha
            nuevoGestor.SOLICITUDESTADOID = 3        'con visualizacion
            nuevoGestor.modificar(Usuario)
            listar()
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Visualizacion2" Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            Dim id As Long = 0
            Dim c As New dSinVisualizacion
            c.ID = row.Cells("Id").Value
            c = c.buscar
            Dim ficha As Long = 0
            ficha = c.FICHA
            idficha = ficha
            c.marcarvisualizacion(Usuario, fec)

            Dim nuevoGestor As New dNuevoGestor
            nuevoGestor.ID = ficha
            nuevoGestor.SOLICITUDESTADOID = 2        'sin visualizacion
            nuevoGestor.modificar(Usuario)
            abonado_ = 1

            'marcarweb(ficha, abonado_)
            'subir_ficha(ficha, abonado_)
            listar()
        End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If DataGridView1.Columns(e.ColumnIndex).Name = "Observaciones" Then
            Dim obs As String = ""
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            obs = row.Cells("Observaciones").Value
            If obs <> "" Then
                Dim c As New dSinVisualizacion
                c.ID = id
                c.guardarobservaciones(Usuario, obs)
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Muestras" Then
            Dim muestras As Integer = 0
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            muestras = row.Cells("Muestras").Value
            If muestras <> 0 Then
                Dim c As New dSinVisualizacion
                c.ID = id
                c.guardarmuestras(Usuario, muestras)
            End If
        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "Importe" Then
            Dim importe As Double = 0
            Dim id As Long = 0
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            id = row.Cells("Id").Value
            importe = row.Cells("Importe").Value
            If importe <> 0 Then
                Dim c As New dSinVisualizacion
                c.ID = id
                c.guardarimporte(Usuario, importe)
            End If
        End If
    End Sub
    Private Sub marcarweb(ByVal ficha As Long, ByVal abonado As Integer)
        Dim _ficha As Long = ficha
        Dim _abonado As Integer = abonado
        Dim sa As New dSolicitudAnalisis
        sa.ID = _ficha
        sa = sa.buscar
        Dim tipoinforme As Integer = 0
        If Not sa Is Nothing Then
            tipoinforme = sa.IDTIPOINFORME
        End If
        If tipoinforme = 1 Then
            Dim clw As New dControlLecheroWeb_com
            clw.modificarabonado(ficha, abonado)
            clw = Nothing
        ElseIf tipoinforme = 3 Then
            Dim aw As New dAguaWeb_com
            aw.modificarabonado(ficha, abonado)
            aw = Nothing
        ElseIf tipoinforme = 4 Then
            Dim atbw As New dAntibiogramaWeb_com
            atbw.modificarabonado(ficha, abonado)
            atbw = Nothing
        ElseIf tipoinforme = 5 Then
            Dim palw As New dPalWeb_com
            palw.modificarabonado(ficha, abonado)
            palw = Nothing
        ElseIf tipoinforme = 6 Then
            Dim pstlgw As New dParasitologiaWeb_com
            pstlgw.modificarabonado(ficha, abonado)
            pstlgw = Nothing
        ElseIf tipoinforme = 7 Then
            Dim spw As New dSubproductosWeb_com
            spw.modificarabonado(ficha, abonado)
            spw = Nothing
        ElseIf tipoinforme = 8 Then
            Dim sw As New dSerologiaWeb_com
            sw.modificarabonado(ficha, abonado)
            sw = Nothing
        ElseIf tipoinforme = 9 Then
            Dim ptlgw As New dPatologiaWeb_com
            ptlgw.modificarabonado(ficha, abonado)
            ptlgw = Nothing
        ElseIf tipoinforme = 10 Then
            Dim calw As New dCalidadWeb_com
            calw.modificarabonado(ficha, abonado)
            calw = Nothing
        ElseIf tipoinforme = 11 Then
            Dim ambw As New dAmbientalWeb_com
            ambw.modificarabonado(ficha, abonado)
            ambw = Nothing
        ElseIf tipoinforme = 12 Then
            Dim lw As New dLactometrosWeb_com
            lw.modificarabonado(ficha, abonado)
            lw = Nothing
        ElseIf tipoinforme = 13 Then
            Dim anw As New dAgroNutricionWeb_com
            anw.modificarabonado(ficha, abonado)
            anw = Nothing
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            Dim asw As New dAgroSuelosWeb_com
            asw.modificarabonado(ficha, abonado)
            asw = Nothing
        ElseIf tipoinforme = 15 Then
            Dim blw As New dBrucelosisLecheWeb_com
            blw.modificarabonado(ficha, abonado)
            blw = Nothing
        ElseIf tipoinforme = 99 Then
            Dim ow As New dOtrosServiciosWeb_com
            ow.modificarabonado(ficha, abonado)
            ow = Nothing
        End If

    End Sub
    Private Sub subir_ficha(ByVal ficha As Long, ByVal abonado As Integer)
        Dim s As New dSolicitudAnalisis
        s.ID = ficha
        s = s.buscar
        If Not s Is Nothing Then
            If s.IDTIPOINFORME = 1 Then
                tipoinforme = 1
            ElseIf s.IDTIPOINFORME = 3 Then
                tipoinforme = 3
            ElseIf s.IDTIPOINFORME = 4 Then
                tipoinforme = 4
            ElseIf s.IDTIPOINFORME = 6 Then
                tipoinforme = 6
            ElseIf s.IDTIPOINFORME = 7 Then
                tipoinforme = 7
            ElseIf s.IDTIPOINFORME = 8 Then
                tipoinforme = 8
            ElseIf s.IDTIPOINFORME = 9 Then
                tipoinforme = 9
            ElseIf s.IDTIPOINFORME = 10 Then
                tipoinforme = 10
            ElseIf s.IDTIPOINFORME = 11 Then
                tipoinforme = 11
            ElseIf s.IDTIPOINFORME = 13 Then
                tipoinforme = 13
            ElseIf s.IDTIPOINFORME = 14 Then
                tipoinforme = 14
            ElseIf s.IDTIPOINFORME = 15 Then
                tipoinforme = 15
            ElseIf s.IDTIPOINFORME = 16 Then
                tipoinforme = 16
            End If
            subir_informes2(ficha, abonado)
        End If
    End Sub
    Private Sub subir_informes2(ByVal ficha As Long, ByVal abonado As Integer)
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        Dim idprod As Long = 0
        Dim sa As New dSolicitudAnalisis
        sa.ID = ficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            Dim p As New dCliente
            tipoinforme = sa.IDTIPOINFORME
            p.ID = sa.IDPRODUCTOR
            p = p.buscar
            idprod = sa.IDPRODUCTOR
            If Not p Is Nothing Then
                productorweb_com = p.USUARIO_WEB
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                If Not pw_com Is Nothing Then
                    idproductorweb_com = pw_com.ID
                    carpeta = idproductorweb_com
                    crea_carpeta()
                End If
                sa = Nothing
            End If
        End If
        'controlexcel:
        '        subirFicheroXls()
        '        existeXls()
        '        If Excel = 1 Then
        '            GoTo controlexcel
        '        End If
        '        subidoxls = 1
        'controlpdf:
        '        subirFicheroPdf()
        '        existePdf()
        '        If pdf = 1 Then
        '            GoTo controlpdf
        '        End If
        '        subidopdf = 1
        '        If tipoinforme = 1 Then
        'controltxt:
        '            subirFicheroCsv()
        '            existeCsv()
        '            If csv = 1 Then
        '                GoTo controltxt
        '            End If
        '        End If
        modificarRegistro2()
        Dim s As New dSolicitudAnalisis
        Dim fechaenvio As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecenv As String
        fecenv = Format(fechaenvio, "yyyy-MM-dd")
        s.ID = idficha
        s.marcar2()
        s = Nothing
        If subidoxls = 1 And subidopdf = 1 Then
            ' Grabar estado de la ficha
            Dim est As New dEstados
            est.FICHA = idficha
            est.ESTADO = 8
            est.FECHA = fecenv
            est.guardar2()
            est = Nothing
            '****************************
        End If

        If tipoinforme = 10 Then
            If idprod = 6299 Or idprod = 2705 Then
                Dim arch As String = ""
                arch = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & ".txt"
                If File.Exists(arch) Then
                    System.Diagnostics.Process.Start(arch)
                End If
            End If
            Dim result = MessageBox.Show("Desea enviar un correo electrónico con el archivo txt?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                If idprod = 6299 Then
                    enviar_correo_AFB2(idficha)
                ElseIf idprod = 2705 Then
                    enviar_correo_IS(idficha)
                End If
            End If
        End If
    End Sub
    Private Sub enviar_correo_AFB2(ByVal fi As Long)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = fi
        email = "jgarello@lasibila.com.ar, pdemaio@lasibila.com.ar, amrodriguez@afb.com.uy, hvilche@afb.com.uy, lab.fisicoquimico@afb.com.uy, mcornejo@afb.com.uy"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "23.111.185.242"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
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
    Private Sub enviar_correo_IS(ByVal fi As Long)
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = fi
        email = "iverocay@hotmail.com"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "23.111.185.242"
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            '_Message.[To].Add("computos@colaveco.com")
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
    Public Sub crea_carpeta()
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Private Sub ButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        imprimir_sv()
    End Sub

    Private Sub imprimir_cv()
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
        Dim fila = 1
        Dim columna = 1
        x1hoja.Cells(fila, columna).formula = "Ficha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Productor"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Informe"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Importe"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Abonado"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Visualizacón"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha Vis."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = 1
        fila = fila + 1
        Dim sv As New dSinVisualizacion
        Dim lista As New ArrayList
        lista = sv.listarcv
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sv In lista
                    x1hoja.Cells(fila, columna).formula = sv.FICHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = sv.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sv.FICHA
                    sa = sa.buscar
                    Dim pro As New dCliente
                    pro.ID = sa.IDPRODUCTOR
                    pro = pro.buscar
                    Dim ti As New dTipoInforme
                    ti.ID = sa.IDTIPOINFORME
                    ti = ti.buscar
                    If Not sa Is Nothing Then
                        If Not pro Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        If Not ti Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = ti.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        x1hoja.Cells(fila, columna).formula = sv.MUESTRAS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = sv.IMPORTE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = columna + 1
                        If sv.ABONADO = 0 Then
                            x1hoja.Cells(fila, columna).formula = "No"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Si"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        If sv.VISUALIZACION = 0 Then
                            x1hoja.Cells(fila, columna).formula = "No"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Si"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        x1hoja.Cells(fila, columna).formula = sv.FECHAVISUALIZACION
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = columna + 1
                        If sv.OBSERVACIONES <> "" Then
                            x1hoja.Cells(fila, columna).formula = sv.OBSERVACIONES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = 1
                            fila = fila + 1
                        End If
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Private Sub imprimir_sv()
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
        Dim fila = 1
        Dim columna = 1
        x1hoja.Cells(fila, columna).formula = "Ficha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Productor"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Informe"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Muestras"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Importe"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Abonado"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Visualizacón"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Fecha Vis."
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = columna + 1
        x1hoja.Cells(fila, columna).formula = "Observaciones"
        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
        x1hoja.Cells(fila, columna).Font.Size = 10
        x1hoja.Cells(fila, columna).Font.Bold = True
        columna = 1
        fila = fila + 1
        Dim sv As New dSinVisualizacion
        Dim lista As New ArrayList
        lista = sv.listarsv
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each sv In lista
                    x1hoja.Cells(fila, columna).formula = sv.FICHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    x1hoja.Cells(fila, columna).formula = sv.FECHA
                    x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                    x1hoja.Cells(fila, columna).Font.Size = 10
                    x1hoja.Cells(fila, columna).Font.Bold = False
                    columna = columna + 1
                    Dim sa As New dSolicitudAnalisis
                    sa.ID = sv.FICHA
                    sa = sa.buscar
                    Dim pro As New dCliente
                    pro.ID = sa.IDPRODUCTOR
                    pro = pro.buscar
                    Dim ti As New dTipoInforme
                    ti.ID = sa.IDTIPOINFORME
                    ti = ti.buscar
                    If Not sa Is Nothing Then
                        If Not pro Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = pro.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        If Not ti Is Nothing Then
                            x1hoja.Cells(fila, columna).formula = ti.NOMBRE
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        x1hoja.Cells(fila, columna).formula = sv.MUESTRAS
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = columna + 1
                        x1hoja.Cells(fila, columna).formula = sv.IMPORTE
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = columna + 1
                        If sv.ABONADO = 0 Then
                            x1hoja.Cells(fila, columna).formula = "No"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Si"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        If sv.VISUALIZACION = 0 Then
                            x1hoja.Cells(fila, columna).formula = "No"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = "Si"
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = columna + 1
                        End If
                        x1hoja.Cells(fila, columna).formula = sv.FECHAVISUALIZACION
                        x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                        x1hoja.Cells(fila, columna).Font.Size = 10
                        x1hoja.Cells(fila, columna).Font.Bold = False
                        columna = columna + 1
                        If sv.OBSERVACIONES <> "" Then
                            x1hoja.Cells(fila, columna).formula = sv.OBSERVACIONES
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = 1
                            fila = fila + 1
                        Else
                            x1hoja.Cells(fila, columna).formula = ""
                            x1hoja.Cells(fila, columna).HorizontalAlignment = XlHAlign.xlHAlignLeft
                            x1hoja.Cells(fila, columna).Font.Size = 10
                            x1hoja.Cells(fila, columna).Font.Bold = False
                            columna = 1
                            fila = fila + 1
                        End If
                    End If
                Next
            End If
        End If
        x1app.Visible = True
        x1libro.PrintPreview()
        x1app = Nothing
        x1libro = Nothing
        x1hoja = Nothing
    End Sub
    Public Function subirFicheroXls() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 16 Then
            crea_efluentes_com()
            fichero = "\\192.168.1.10\E\NET\Efluentes\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
        End If
        Dim infoFichero As New FileInfo(fichero)

        Dim uri As String
        uri = destino
        Dim peticionFTP As FtpWebRequest
        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destino)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False
        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile
        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True
        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        peticionFTP.ContentLength = infoFichero.Length
        ' Fijamos un buffer de 150KB
        Dim longitudBuffer As Integer
        longitudBuffer = 153600
        Dim lector As Byte() = New Byte(153600) {}
        Dim num As Integer
        ' Abrimos el fichero para subirlo
        Dim fs As FileStream
        fs = infoFichero.OpenRead()
        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()
            ' Leemos 150 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)
            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el
                ' flujo de escritura del comando FTP
                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)
            End While
            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function
    Public Function subirFicheroPdf() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 16 Then
            crea_efluentes_com()
            fichero = "\\192.168.1.10\E\NET\Efluentes\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
        Dim peticionFTP As FtpWebRequest
        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destino)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False
        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile
        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True
        '' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        'peticionFTP.ContentLength = infoFichero.Length

        '**********************************************************************
        Try
            peticionFTP.ContentLength = infoFichero.Length
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
        '**********************************************************************
        ' Fijamos un buffer de 150KB
        Dim longitudBuffer As Integer
        longitudBuffer = 153600
        Dim lector As Byte() = New Byte(153600) {}
        Dim num As Integer
        ' Abrimos el fichero para subirlo
        Dim fs As FileStream
        fs = infoFichero.OpenRead()
        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()
            ' Leemos 150 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)
            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el
                ' flujo de escritura del comando FTP
                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)
            End While
            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function
    Public Function subirFicheroCsv() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        End If
        Dim infoFichero As New FileInfo(fichero)
        Dim uri As String
        uri = destino
        Dim peticionFTP As FtpWebRequest
        ' Creamos una peticion FTP con la dirección del fichero que vamos a subir
        peticionFTP = CType(FtpWebRequest.Create(New Uri(destino)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        peticionFTP.KeepAlive = False
        peticionFTP.UsePassive = False
        ' Seleccionamos el comando que vamos a utilizar: Subir un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.UploadFile
        ' Especificamos el tipo de transferencia de datos
        peticionFTP.UseBinary = True
        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        peticionFTP.ContentLength = infoFichero.Length
        ' Fijamos un buffer de 150KB
        Dim longitudBuffer As Integer
        longitudBuffer = 153600
        Dim lector As Byte() = New Byte(153600) {}
        Dim num As Integer
        ' Abrimos el fichero para subirlo
        Dim fs As FileStream
        fs = infoFichero.OpenRead()
        Try
            Dim escritor As Stream
            escritor = peticionFTP.GetRequestStream()
            ' Leemos 150 KB del fichero en cada iteración
            num = fs.Read(lector, 0, longitudBuffer)
            While (num <> 0)
                ' Escribimos el contenido del flujo de lectura en el
                ' flujo de escritura del comando FTP
                escritor.Write(lector, 0, num)
                num = fs.Read(lector, 0, longitudBuffer)
            End While
            escritor.Close()
            fs.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function
    Public Function existeXls() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 16 Then
            fichero = "\\192.168.1.10\E\NET\Efluentes\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
        End If
        Dim peticionFTP As FtpWebRequest
        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(destino)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp
        peticionFTP.UsePassive = False
        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            excel = 0
            Return True
        Catch ex As Exception
            mensaje = mensaje & " excel(com) - "
            excel = 1
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existePdf() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 16 Then
            fichero = "\\192.168.1.10\E\NET\Efluentes\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
        End If
        Dim peticionFTP As FtpWebRequest
        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(destino)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp
        peticionFTP.UsePassive = False
        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            pdf = 0
            Return True
        Catch ex As Exception
            mensaje = mensaje & " pdf(com) - "
            pdf = 1
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existeCsv() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        End If
        Dim peticionFTP As FtpWebRequest
        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(destino)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp
        peticionFTP.UsePassive = False
        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            csv = 0
            Return True
        Catch ex As Exception
            mensaje = mensaje & " csv(com) - "
            csv = 1
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Sub crea_brucelosis_leche_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/brucelosis_leche/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_agro_suelos_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agro_suelos/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_control_lechero_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/control_lechero/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_agua_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agua/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_antibiograma_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/antibiograma/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_parasitologia_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/parasitologia/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_productos_subproductos_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/productos_subproductos/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_serologia_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/serologia/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_patologia_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/patologia/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_calidad_de_leche_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/calidad_de_leche/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_ambiental_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/ambiental/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_agro_nutricion_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/agro_nutricion/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_otros_servicios_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/otros_servicios/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub crea_efluentes_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta & "/efluentes/"
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        Try
            Dim respuesta As FtpWebResponse
            respuesta = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuesta.Close()
            ' Si todo ha ido bien, se devolverá String.Empty
            'Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            'Return ex.Message
        End Try
    End Sub
    Public Sub modificarRegistro2()
        Dim fechacreado As String = ""
        Dim fechaenviado As String = ""
        Dim idnet As Long = 0
        Dim sa_ As New dSolicitudAnalisis
        sa_.ID = idficha
        sa_ = sa_.buscar
        If Not sa_ Is Nothing Then
            idnet = sa_.IDPRODUCTOR
            tipoinforme = sa_.IDTIPOINFORME
            Dim c As New dCliente
            c.ID = sa_.IDPRODUCTOR
            c = c.buscar
            If Not c Is Nothing Then
                productorweb_com = c.USUARIO_WEB
            End If
            fechacreado = sa_.FECHAINGRESO
            fechaenviado = sa_.FECHAENVIO
        End If
        'enviar_notificacion_resultado()

        '*** CREA RESULTADO EN GESTOR NUEVO *******************************************************************************************
        Dim resultado As New Dictionary(Of String, dResultado)
        Dim carpeta As String = ""
        If tipoinforme = 1 Then
            carpeta = "control_lechero"
        ElseIf tipoinforme = 3 Then
            carpeta = "agua"
        ElseIf tipoinforme = 4 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 6 Then
            carpeta = "parasitologia"
        ElseIf tipoinforme = 7 Then
            carpeta = "productos_subproductos"
        ElseIf tipoinforme = 8 Then
            carpeta = "serologia"
        ElseIf tipoinforme = 9 Then
            carpeta = "patologia"
        ElseIf tipoinforme = 10 Then
            carpeta = "calidad_de_leche"
        ElseIf tipoinforme = 11 Then
            carpeta = "ambiental"
        ElseIf tipoinforme = 13 Then
            carpeta = "agro_nutricion"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            carpeta = "agro_suelos"
        ElseIf tipoinforme = 15 Then
            carpeta = "brucelosis_leche"
        ElseIf tipoinforme = 16 Then
            carpeta = "efluentes"
        ElseIf tipoinforme = 21 Then
            carpeta = "calidad_de_leche"
            tipoinforme = 10
        End If
        Dim rg As New dResultado

        'Dim fechaemi2 As String
        'Dim fecha_emision2 As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        'fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")
        rg.ficha = idficha
        rg.comentarios = ""
        rg.idnet_usuario = idnet
        rg.abonado = abonado_
        rg.fecha_creado = fechacreado
        rg.fecha_emision = fechaenviado
        rg.path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/" & carpeta & "/" & idficha & ".xls"
        rg.path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/" & carpeta & "/" & idficha & ".pdf"
        rg.path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/" & carpeta & "/" & idficha & ".txt"
        rg.id_estado = 3
        rg.id_libro = idficha
        rg.idnet_tipo_informe = tipoinforme
        resultado.Add("resultado", rg)
        Dim parameters As String = JsonConvert.SerializeObject(resultado, Formatting.None)
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/resultados", "POST", parameters, status)
        'MsgBox("Actualizado!!!")
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

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView1.Columns(e.ColumnIndex).Name = "Abonado2" Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            Dim fecha As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            Dim id2 As Long = 0
            Dim c As New dSinVisualizacion
            c.ID = row.Cells("Id2").Value
            c = c.buscar
            Dim ficha As Long = 0
            ficha = c.FICHA
            idficha = ficha
            c.desmarcarvisualizacion(Usuario, fec)
            abonado_ = 0

            Dim nuevoGestor As New dNuevoGestor
            nuevoGestor.ID = ficha
            nuevoGestor.SOLICITUDESTADOID = 2        'sin visualizacion
            nuevoGestor.modificar(Usuario)
            abonado_ = 1

            'marcarweb(ficha, abonado_)
            'subir_ficha(ficha, abonado_)
            listar()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class