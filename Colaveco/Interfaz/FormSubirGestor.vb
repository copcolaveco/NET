Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports System.Net
Imports Newtonsoft.Json
Public Class FormSubirGestor
    Private _usuario As dUsuario
    Private idficha As Long = 0
    Private productorweb_com As String = ""
    Private idproductorweb_com As Long = 0
    Private _comentarios As String = ""
    Private _abonado As Integer = 0
    Private tipoinforme As Integer = 0
    Private excel As Integer = 0
    Private pdf As Integer = 0
    Private csv As Integer = 0
    Private mensaje As String = ""
    Private _ficheroxls As String = ""
    Private _ficheropdf As String = ""
    Private _ficherocsv As String = ""

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
        RadioNoAbonadocv.Checked = True
        DateFecha.Value = Now
    End Sub
#End Region

    Private Sub ButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcel.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.xls)|*.xls"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\192.168.1.10\E\NET"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            _ficheroxls = dlAbrir.FileName
            TextXls.Text = fichero
        End If
        dlAbrir = Nothing
    End Sub

    Private Sub ButtonPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPdf.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.pdf)|*.pdf"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\192.168.1.10\E\NET"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            _ficheropdf = dlAbrir.FileName
            TextPdf.Text = fichero
        End If
        dlAbrir = Nothing
    End Sub

    Private Sub ButtonTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTxt.Click
        Dim fichero As String
        Dim dlAbrir As New System.Windows.Forms.OpenFileDialog
        dlAbrir.Filter = "Todos los archivos (*.txt)|*.txt"
        dlAbrir.Multiselect = False
        dlAbrir.CheckFileExists = False
        dlAbrir.Title = "Selección de fichero"
        dlAbrir.InitialDirectory = "\\192.168.1.10\E\NET"
        dlAbrir.ShowDialog()
        If dlAbrir.FileName <> "" Then
            fichero = dlAbrir.FileName
            _ficherocsv = dlAbrir.FileName
            TextTxt.Text = fichero
        End If
        dlAbrir = Nothing
    End Sub

    Private Sub ButtonSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubir.Click
        modificarRegistro()
        subir_ficheros()

    End Sub

    Public Sub modificarRegistro()
        If TextFicha.Text <> "" Then
            idficha = TextFicha.Text.Trim
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
            End If
            If TextComentarios.Text <> "" Then
                _comentarios = TextComentarios.Text.Trim
            End If
            If RadioAbonado.Checked = True Then
                _abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                _abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                _abonado = 0
            End If
            If tipoinforme = 1 Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
                Dim cw_com As New dControlLecheroWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado
                'If _moroso = 1 Then
                '    abonado = 0
                'End If

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"

                Dim id_estado As Integer = 3

                cw_com.FICHA = idficha
                cw_com = cw_com.buscar
                If Not cw_com Is Nothing Then
                    If comentarios <> "" Then
                        cw_com.COMENTARIO = comentarios
                    End If
                    cw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    cw_com.FECHA_EMISION = fechaemi
                    cw_com.PATH_EXCEL = path_excel
                    cw_com.PATH_PDF = path_pdf
                    cw_com.PATH_CSV = path_csv
                    cw_com.ID_ESTADO = id_estado
                    If (cw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim cweb_com As New dControlLecheroWeb_com
                    cweb_com.ID_USUARIO = idproductorweb_com

                    If comentarios <> "" Then
                        cweb_com.COMENTARIO = comentarios
                    End If
                    cweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    cweb_com.FECHA_CREADO = fechaemi
                    cweb_com.FECHA_EMISION = fechaemi
                    cweb_com.PATH_EXCEL = path_excel
                    cweb_com.PATH_PDF = path_pdf
                    cweb_com.PATH_CSV = path_csv
                    cweb_com.FICHA = idficha
                    cweb_com.ID_ESTADO = id_estado
                    cweb_com.ID_LIBRO = idficha
                    If (cweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            ElseIf tipoinforme = 3 Then 'SI EL TIPO DE INFORME ES DE AGUA
                Dim aw_com As New dAguaWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado
                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
                Dim id_estado As Integer = 3
                aw_com.FICHA = idficha
                aw_com = aw_com.buscar
                If Not aw_com Is Nothing Then
                    If comentarios <> "" Then
                        aw_com.COMENTARIO = comentarios
                    End If
                    aw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aw_com.FECHA_EMISION = fechaemi
                    aw_com.PATH_EXCEL = path_excel
                    aw_com.PATH_PDF = path_pdf
                    aw_com.PATH_CSV = path_csv
                    aw_com.ID_ESTADO = id_estado
                    If (aw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim aweb_com As New dAguaWeb_com
                    aweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        aweb_com.COMENTARIO = comentarios
                    End If
                    aweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aweb_com.FECHA_CREADO = fechaemi
                    aweb_com.FECHA_EMISION = fechaemi
                    aweb_com.PATH_EXCEL = path_excel
                    aweb_com.PATH_PDF = path_pdf
                    aweb_com.PATH_CSV = path_csv
                    aweb_com.FICHA = idficha
                    aweb_com.ID_ESTADO = id_estado
                    aweb_com.ID_LIBRO = idficha
                    If (aweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            ElseIf tipoinforme = 4 Then 'SI EL TIPO DE INFORME ES DE BACTERIOLOGÍA Y ANTIBIOGRAMA
                Dim aw_com As New dAntibiogramaWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                aw_com.FICHA = idficha
                aw_com = aw_com.buscar
                If Not aw_com Is Nothing Then
                    If comentarios <> "" Then
                        aw_com.COMENTARIO = comentarios
                    End If
                    aw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aw_com.FECHA_EMISION = fechaemi
                    aw_com.PATH_EXCEL = path_excel
                    aw_com.PATH_PDF = path_pdf
                    aw_com.PATH_CSV = path_csv
                    aw_com.ID_ESTADO = id_estado
                    If (aw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim aweb_com As New dAntibiogramaWeb_com
                    aweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        aweb_com.COMENTARIO = comentarios
                    End If
                    aweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aweb_com.FECHA_CREADO = fechaemi
                    aweb_com.FECHA_EMISION = fechaemi
                    aweb_com.PATH_EXCEL = path_excel
                    aweb_com.PATH_PDF = path_pdf
                    aweb_com.PATH_CSV = path_csv
                    aweb_com.FICHA = idficha
                    aweb_com.ID_ESTADO = id_estado
                    aweb_com.ID_LIBRO = idficha
                    If (aweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If

            ElseIf tipoinforme = 6 Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
                Dim paw_com As New dParasitologiaWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                paw_com.FICHA = idficha
                paw_com = paw_com.buscar
                If Not paw_com Is Nothing Then
                    If comentarios <> "" Then
                        paw_com.COMENTARIO = comentarios
                    End If
                    paw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    paw_com.FECHA_EMISION = fechaemi
                    paw_com.PATH_EXCEL = path_excel
                    paw_com.PATH_PDF = path_pdf
                    paw_com.PATH_CSV = path_csv
                    paw_com.ID_ESTADO = id_estado
                    If (paw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim pweb_com As New dParasitologiaWeb_com
                    pweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        pweb_com.COMENTARIO = comentarios
                    End If
                    pweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    pweb_com.FECHA_CREADO = fechaemi
                    pweb_com.FECHA_EMISION = fechaemi
                    pweb_com.PATH_EXCEL = path_excel
                    pweb_com.PATH_PDF = path_pdf
                    pweb_com.PATH_CSV = path_csv
                    pweb_com.FICHA = idficha
                    pweb_com.ID_ESTADO = id_estado
                    pweb_com.ID_LIBRO = idficha
                    If (pweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            ElseIf tipoinforme = 7 Then 'SI EL TIPO DE INFORME ES DE ALIMENTOS E INDICADORES
                Dim spw_com As New dSubproductosWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                spw_com.FICHA = idficha
                spw_com = spw_com.buscar
                If Not spw_com Is Nothing Then
                    If comentarios <> "" Then
                        spw_com.COMENTARIO = comentarios
                    End If
                    spw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    spw_com.FECHA_EMISION = fechaemi
                    spw_com.PATH_EXCEL = path_excel
                    spw_com.PATH_PDF = path_pdf
                    spw_com.PATH_CSV = path_csv
                    spw_com.ID_ESTADO = id_estado
                    If (spw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim spweb_com As New dSubproductosWeb_com
                    spweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        spweb_com.COMENTARIO = comentarios
                    End If
                    spweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    spweb_com.FECHA_CREADO = fechaemi
                    spweb_com.FECHA_EMISION = fechaemi
                    spweb_com.PATH_EXCEL = path_excel
                    spweb_com.PATH_PDF = path_pdf
                    spweb_com.PATH_CSV = path_csv
                    spweb_com.FICHA = idficha
                    spweb_com.ID_ESTADO = id_estado
                    spweb_com.ID_LIBRO = idficha
                    If (spweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If

            ElseIf tipoinforme = 8 Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
                Dim sw_com As New dSerologiaWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                sw_com.FICHA = idficha
                sw_com = sw_com.buscar
                If Not sw_com Is Nothing Then
                    If comentarios <> "" Then
                        sw_com.COMENTARIO = comentarios
                    End If
                    sw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    sw_com.FECHA_EMISION = fechaemi
                    sw_com.PATH_EXCEL = path_excel
                    sw_com.PATH_PDF = path_pdf
                    sw_com.PATH_CSV = path_csv
                    sw_com.ID_ESTADO = id_estado
                    If (sw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim sweb_com As New dSerologiaWeb_com
                    sweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        sweb_com.COMENTARIO = comentarios
                    End If
                    sweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    sweb_com.FECHA_CREADO = fechaemi
                    sweb_com.FECHA_EMISION = fechaemi
                    sweb_com.PATH_EXCEL = path_excel
                    sweb_com.PATH_PDF = path_pdf
                    sweb_com.PATH_CSV = path_csv
                    sweb_com.FICHA = idficha
                    sweb_com.ID_ESTADO = id_estado
                    sweb_com.ID_LIBRO = idficha
                    If (sweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If

            ElseIf tipoinforme = 9 Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
                Dim patw_com As New dPatologiaWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                patw_com.FICHA = idficha
                patw_com = patw_com.buscar
                If Not patw_com Is Nothing Then
                    If comentarios <> "" Then
                        patw_com.COMENTARIO = comentarios
                    End If
                    patw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    patw_com.FECHA_EMISION = fechaemi
                    patw_com.PATH_EXCEL = path_excel
                    patw_com.PATH_PDF = path_pdf
                    patw_com.PATH_CSV = path_csv
                    patw_com.ID_ESTADO = id_estado
                    If (patw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim patoweb_com As New dPatologiaWeb_com
                    patoweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        patoweb_com.COMENTARIO = comentarios
                    End If
                    patoweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    patoweb_com.FECHA_CREADO = fechaemi
                    patoweb_com.FECHA_EMISION = fechaemi
                    patoweb_com.PATH_EXCEL = path_excel
                    patoweb_com.PATH_PDF = path_pdf
                    patoweb_com.PATH_CSV = path_csv
                    patoweb_com.FICHA = idficha
                    patoweb_com.ID_ESTADO = id_estado
                    patoweb_com.ID_LIBRO = idficha
                    If (patoweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If

            ElseIf tipoinforme = 10 Then 'SI EL TIPO DE INFORME ES DE CALIDAD
                Dim cw_com As New dCalidadWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado
                'If _moroso = 1 Then
                '    abonado = 0
                'End If

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
                'Dim path_csv As String = ""
                'path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                cw_com.FICHA = idficha
                cw_com = cw_com.buscar
                If Not cw_com Is Nothing Then
                    If comentarios <> "" Then
                        cw_com.COMENTARIO = comentarios
                    End If
                    cw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    cw_com.FECHA_EMISION = fechaemi
                    cw_com.PATH_EXCEL = path_excel
                    cw_com.PATH_PDF = path_pdf
                    'cw_com.PATH_CSV = path_csv
                    cw_com.ID_ESTADO = id_estado
                    If (cw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim calweb_com As New dCalidadWeb_com
                    calweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        calweb_com.COMENTARIO = comentarios
                    End If
                    calweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    calweb_com.FECHA_CREADO = fechaemi
                    calweb_com.FECHA_EMISION = fechaemi
                    calweb_com.PATH_EXCEL = path_excel
                    calweb_com.PATH_PDF = path_pdf
                    'calweb_com.PATH_CSV = path_csv
                    calweb_com.FICHA = idficha
                    calweb_com.ID_ESTADO = id_estado
                    calweb_com.ID_LIBRO = idficha
                    If (calweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            ElseIf tipoinforme = 11 Then 'SI EL TIPO DE INFORME ES AMBIENTAL
                Dim aw_com As New dAmbientalWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                aw_com.FICHA = idficha
                aw_com = aw_com.buscar
                If Not aw_com Is Nothing Then
                    If comentarios <> "" Then
                        aw_com.COMENTARIO = comentarios
                    End If
                    aw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aw_com.FECHA_EMISION = fechaemi
                    aw_com.PATH_EXCEL = path_excel
                    aw_com.PATH_PDF = path_pdf
                    aw_com.PATH_CSV = path_csv
                    aw_com.ID_ESTADO = id_estado
                    If (aw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim aweb_com As New dAmbientalWeb_com
                    aweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        aweb_com.COMENTARIO = comentarios
                    End If
                    aweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aweb_com.FECHA_CREADO = fechaemi
                    aweb_com.FECHA_EMISION = fechaemi
                    aweb_com.PATH_EXCEL = path_excel
                    aweb_com.PATH_PDF = path_pdf
                    aweb_com.PATH_CSV = path_csv
                    aweb_com.FICHA = idficha
                    aweb_com.ID_ESTADO = id_estado
                    aweb_com.ID_LIBRO = idficha
                    If (aweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If

            ElseIf tipoinforme = 13 Then 'SI EL TIPO DE INFORME ES DE NUTRICIÓN
                Dim aw_com As New dAgroNutricionWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                aw_com.FICHA = idficha
                aw_com = aw_com.buscar
                If Not aw_com Is Nothing Then
                    If comentarios <> "" Then
                        aw_com.COMENTARIO = comentarios
                    End If
                    aw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aw_com.FECHA_EMISION = fechaemi
                    aw_com.PATH_EXCEL = path_excel
                    aw_com.PATH_PDF = path_pdf
                    aw_com.PATH_CSV = path_csv
                    aw_com.ID_ESTADO = id_estado
                    If (aw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim aweb_com As New dAgroNutricionWeb_com
                    aweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        aweb_com.COMENTARIO = comentarios
                    End If
                    aweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aweb_com.FECHA_CREADO = fechaemi
                    aweb_com.FECHA_EMISION = fechaemi
                    aweb_com.PATH_EXCEL = path_excel
                    aweb_com.PATH_PDF = path_pdf
                    aweb_com.PATH_CSV = path_csv
                    aweb_com.FICHA = idficha
                    aweb_com.ID_ESTADO = id_estado
                    aweb_com.ID_LIBRO = idficha
                    If (aweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            ElseIf tipoinforme = 14 Or tipoinforme = 19 Then 'SI EL TIPO DE INFORME ES DE SUELOS
                Dim aw_com As New dAgroSuelosWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                aw_com.FICHA = idficha
                aw_com = aw_com.buscar
                If Not aw_com Is Nothing Then
                    If comentarios <> "" Then
                        aw_com.COMENTARIO = comentarios
                    End If
                    aw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aw_com.FECHA_EMISION = fechaemi
                    aw_com.PATH_EXCEL = path_excel
                    aw_com.PATH_PDF = path_pdf
                    aw_com.PATH_CSV = path_csv
                    aw_com.ID_ESTADO = id_estado
                    If (aw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim aweb_com As New dAgroSuelosWeb_com
                    aweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        aweb_com.COMENTARIO = comentarios
                    End If
                    aweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    aweb_com.FECHA_CREADO = fechaemi
                    aweb_com.FECHA_EMISION = fechaemi
                    aweb_com.PATH_EXCEL = path_excel
                    aweb_com.PATH_PDF = path_pdf
                    aweb_com.PATH_CSV = path_csv
                    aweb_com.FICHA = idficha
                    aweb_com.ID_ESTADO = id_estado
                    aweb_com.ID_LIBRO = idficha
                    If (aweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            ElseIf tipoinforme = 15 Then 'SI EL TIPO DE INFORME ES DE BRUCELOSIS EN LECHE
                Dim bw_com As New dBrucelosisLecheWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                bw_com.FICHA = idficha
                bw_com = bw_com.buscar
                If Not bw_com Is Nothing Then
                    If comentarios <> "" Then
                        bw_com.COMENTARIO = comentarios
                    End If
                    bw_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    bw_com.FECHA_EMISION = fechaemi
                    bw_com.PATH_EXCEL = path_excel
                    bw_com.PATH_PDF = path_pdf
                    bw_com.PATH_CSV = path_csv
                    bw_com.ID_ESTADO = id_estado
                    If (bw_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim bweb_com As New dBrucelosisLecheWeb_com
                    bweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        bweb_com.COMENTARIO = comentarios
                    End If
                    bweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    bweb_com.FECHA_CREADO = fechaemi
                    bweb_com.FECHA_EMISION = fechaemi
                    bweb_com.PATH_EXCEL = path_excel
                    bweb_com.PATH_PDF = path_pdf
                    bweb_com.PATH_CSV = path_csv
                    bweb_com.FICHA = idficha
                    bweb_com.ID_ESTADO = id_estado
                    bweb_com.ID_LIBRO = idficha
                    If (bweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            ElseIf tipoinforme = 99 Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
                Dim ow_com As New dOtrosServiciosWeb_com
                Dim pw_com As New dProductorWeb_com
                pw_com.USUARIO = productorweb_com
                pw_com = pw_com.buscar
                idproductorweb_com = pw_com.ID
                Dim comentarios As String = ""
                If _comentarios.Length > 0 Then
                    comentarios = _comentarios
                End If
                Dim abonado As Integer = _abonado

                Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
                Dim path_excel As String = ""
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
                Dim path_pdf As String = ""
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
                Dim path_csv As String = ""
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
                Dim id_estado As Integer = 3

                ow_com.FICHA = idficha
                ow_com = ow_com.buscar
                If Not ow_com Is Nothing Then
                    If comentarios <> "" Then
                        ow_com.COMENTARIO = comentarios
                    End If
                    ow_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    ow_com.FECHA_EMISION = fechaemi
                    ow_com.PATH_EXCEL = path_excel
                    ow_com.PATH_PDF = path_pdf
                    ow_com.PATH_CSV = path_csv
                    ow_com.ID_ESTADO = id_estado
                    If (ow_com.modificar2()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                Else
                    Dim oweb_com As New dOtrosServiciosWeb_com
                    oweb_com.ID_USUARIO = idproductorweb_com
                    If comentarios <> "" Then
                        oweb_com.COMENTARIO = comentarios
                    End If
                    oweb_com.ABONADO = abonado
                    Dim fechaemi As String
                    fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                    oweb_com.FECHA_CREADO = fechaemi
                    oweb_com.FECHA_EMISION = fechaemi
                    oweb_com.PATH_EXCEL = path_excel
                    oweb_com.PATH_PDF = path_pdf
                    oweb_com.PATH_CSV = path_csv
                    oweb_com.FICHA = idficha
                    oweb_com.ID_ESTADO = id_estado
                    oweb_com.ID_LIBRO = idficha
                    If (oweb_com.guardar()) Then
                        'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                        'limpiar()
                    Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                    End If
                End If
            End If

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
            End If

            Dim rg As New dResultado

            Dim fechaemi2 As String
            Dim fecha_emision2 As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")

            rg.ficha = idficha
            rg.comentarios = _comentarios
            rg.idnet_usuario = idnet
            rg.abonado = _abonado
            rg.fecha_creado = fechaemi2
            rg.fecha_emision = fechaemi2
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
            'Dim responseString As String
            'If response IsNot Nothing Then
            '    responseString = System.Text.Encoding.UTF8.GetString(response)
            'Else
            '    responseString = "NULL"
            'End If
            'Console.WriteLine("Response Code: " & status)
            'Console.WriteLine("Response String: " & responseString)
            ''resultado.Add("resultado", rg)
            '****************************************************************************************************************************
        Else
            MsgBox("Debe ingresar un número de ficha")
            Exit Sub
        End If

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
    Private Sub subir_ficheros()
controlexcel:

        subirFicheroXls()
        existeXls()
        If Excel = 1 Then
            GoTo controlexcel
        End If
controlpdf:

        subirFicheroPdf()
        existePdf()
        If pdf = 1 Then
            GoTo controlpdf
        End If
        If tipoinforme = 1 Then
controltxt:
            subirFicheroCsv()
            existeCsv()
            If csv = 1 Then
                GoTo controltxt
            End If
        End If
        MsgBox("Archivos subidos al gestor!")
        limpiar()
    End Sub
    Public Function subirFicheroXls() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "HSy7TS8sfuv"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            'fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            'fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            'fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 16 Then
            crea_efluentes_com()
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            'fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            fichero = _ficheroxls
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
        End If


        Dim infoFichero As New FileInfo(fichero)

        Dim uri As String
        uri = destino

        ' Si no existe el directorio, lo creamos
        'If Not existeObjeto(dir) Then
        'creaDirectorio(dir)
        'End If

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
        Dim pass As String = "HSy7TS8sfuv"
        If tipoinforme = 1 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            'fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            'fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            'fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 16 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            fichero = _ficheropdf
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            'fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            fichero = _ficheropdf
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
        Dim pass As String = "HSy7TS8sfuv"
        If tipoinforme = 1 Then
            'fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".txt"
            fichero = _ficherocsv
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
        Dim pass As String = "HSy7TS8sfuv"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
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
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
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
        Dim pass As String = "HSy7TS8sfuv"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
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
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
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
        Dim pass As String = "HSy7TS8sfuv"
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
        Dim pass As String = "HSy7TS8sfuv"

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
        Dim pass As String = "HSy7TS8sfuv"

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
        Dim pass As String = "HSy7TS8sfuv"

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
        Dim pass As String = "HSy7TS8sfuv"

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
        Dim pass As String = "HSy7TS8sfuv"

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
        Dim pass As String = "HSy7TS8sfuv"

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
        Dim pass As String = "HSy7TS8sfuv"

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
        Dim pass As String = "HSy7TS8sfuv"
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
        Dim pass As String = "HSy7TS8sfuv"
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
        Dim pass As String = "HSy7TS8sfuv"
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
        Dim pass As String = "HSy7TS8sfuv"
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
        Dim pass As String = "HSy7TS8sfuv"
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
        Dim pass As String = "HSy7TS8sfuv"
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
        Dim pass As String = "HSy7TS8sfuv"
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
    Private Sub limpiar()
        DateFecha.Value = Now
        TextFicha.Text = ""
        TextXls.Text = ""
        TextPdf.Text = ""
        TextTxt.Text = ""
        RadioNoAbonadocv.Checked = True
        TextComentarios.Text = ""
        TextFicha.Focus()
    End Sub
End Class