Imports Microsoft.Office.Interop.Excel
Imports Newtonsoft.Json
Imports System.IO
Imports System.Net.FtpWebRequest
Imports System.Net


Public Class FormActualizarGestor
    Public nombre_pc As String = ""
    Private id_ficha_ As Long = 0
    Private email2 As String = ""
    Private enviar_copia As String = ""
    Private _abonado As Integer = 0
    Private _moroso As Integer = 0
    Private _tipoinforme As Long = 0
    Private subido As Integer = 0
    Private carpeta As Long = 0
    Private compraid As Long = 0
    Private tipoinformeweb As String
    Private nmuestrasweb As Integer
    Private muestraweb As String
    Private subtipoinformeweb As String
    Private observacionesweb As String
    Private nombreproductorweb As String
    Private factura_origen As String
    Private userid As Integer
    Private tipo As Integer
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
    Private _comentarios As String = ""
    Dim email As String
    Dim celular As String
    Dim nficha As String
    Dim mensaje As String = ""
    Dim excel As Integer = 0
    Dim pdf As Integer = 0
    Dim csv As Integer = 0
    Private _dUsuario As dUsuario
    Dim abonado As Integer = 0
    Dim creapreinformecalidad As Integer = 1

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
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fecha_desde As String
        fecha_desde = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim fecha_hasta As String
        fecha_hasta = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim lista As New ArrayList
        Dim pi As New pPreinformes
        lista = pi.listarparasubidos(fecha_desde, fecha_hasta)
        modificarRegistro(lista)
        subir_informes_gestor(lista)
    End Sub

    Public Sub modificarRegistro(ByVal lista As ArrayList)
        Dim productorId As Integer = 0
        Dim pi As New dPreinformes
        If Not lista Is Nothing Then
            For Each pi In lista
                Dim idnet As Long = 0
                Dim sa_ As New dSolicitudAnalisis
                sa_.ID = pi.FICHA
                sa_ = sa_.buscar
                If Not sa_ Is Nothing Then
                    idnet = sa_.IDPRODUCTOR
                End If
                idficha = pi.FICHA

                If sa_.IDTIPOINFORME = 1 Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
                    Dim cw_com As New dControlLecheroWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = ""
                    comentarios = pi.COMENTARIO
                    abonado = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA

                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    cw_com.FICHA = pi.FICHA
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
                ElseIf sa_.IDTIPOINFORME = 3 Then 'SI EL TIPO DE INFORME ES DE AGUA
                    Dim aw_com As New dAguaWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = ""
                    comentarios = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    aw_com.FICHA = pi.FICHA
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
                ElseIf sa_.IDTIPOINFORME = 4 Then 'SI EL TIPO DE INFORME ES DE BACTERIOLOGÍA Y ANTIBIOGRAMA
                    Dim aw_com As New dAntibiogramaWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = ""
                    comentarios = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    aw_com.FICHA = pi.FICHA
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
                ElseIf sa_.IDTIPOINFORME = 5 Then 'SI EL TIPO DE INFORME ES DE PAL
                    Dim palw_com As New dPalWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = ""
                    comentarios = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & pi.FICHA & ".txt"

                    Dim id_estado As Integer = 3

                    palw_com.FICHA = pi.FICHA
                    palw_com = palw_com.buscar
                    If Not palw_com Is Nothing Then
                        If comentarios <> "" Then
                            palw_com.COMENTARIO = comentarios
                        End If
                        palw_com.ABONADO = abonado
                        Dim fechaemi As String
                        fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                        palw_com.FECHA_EMISION = fechaemi
                        palw_com.PATH_EXCEL = path_excel
                        palw_com.PATH_PDF = path_pdf
                        palw_com.PATH_CSV = path_csv
                        palw_com.ID_ESTADO = id_estado
                        If (palw_com.modificar2()) Then
                            'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                            'limpiar()
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    Else
                        Dim palweb_com As New dPalWeb_com
                        palweb_com.ID_USUARIO = idproductorweb_com
                        If comentarios <> "" Then
                            palweb_com.COMENTARIO = comentarios
                        End If
                        palweb_com.ABONADO = abonado
                        Dim fechaemi As String
                        fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                        palweb_com.FECHA_CREADO = fechaemi
                        palweb_com.FECHA_EMISION = fechaemi
                        palweb_com.PATH_EXCEL = path_excel
                        palweb_com.PATH_PDF = path_pdf
                        palweb_com.PATH_CSV = path_csv
                        palweb_com.FICHA = idficha
                        palweb_com.ID_ESTADO = id_estado
                        palweb_com.ID_LIBRO = idficha
                        If (palweb_com.guardar()) Then
                            'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                            'limpiar()
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    End If
                ElseIf pi.TIPO = 6 Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
                    Dim paw_com As New dParasitologiaWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    paw_com.FICHA = pi.FICHA
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
                ElseIf sa_.IDTIPOINFORME = 7 Then 'SI EL TIPO DE INFORME ES DE ALIMENTOS E INDICADORES
                    Dim spw_com As New dSubproductosWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    spw_com.FICHA = pi.FICHA
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

                ElseIf sa_.IDTIPOINFORME = 8 Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
                    Dim sw_com As New dSerologiaWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    sw_com.FICHA = pi.FICHA
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

                ElseIf sa_.IDTIPOINFORME = 9 Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
                    Dim patw_com As New dPatologiaWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    patw_com.FICHA = pi.FICHA
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

                ElseIf sa_.IDTIPOINFORME = 10 Then 'SI EL TIPO DE INFORME ES DE CALIDAD
                    Dim cw_com As New dCalidadWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    cw_com.FICHA = pi.FICHA
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
                        calweb_com.PATH_CSV = path_csv
                        calweb_com.FICHA = idficha
                        calweb_com.ID_ESTADO = id_estado
                        calweb_com.ID_LIBRO = idficha
                        If (calweb_com.guardar()) Then
                            'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                            'limpiar()
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    End If
                ElseIf sa_.IDTIPOINFORME = 11 Then 'SI EL TIPO DE INFORME ES AMBIENTAL
                    Dim aw_com As New dAmbientalWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    aw_com.FICHA = pi.FICHA
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

                ElseIf sa_.IDTIPOINFORME = 12 Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
                    Dim lw_com As New dLactometrosWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim id_estado As Integer = 3
                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"

                    lw_com.FICHA = pi.FICHA
                    lw_com = lw_com.buscar
                    If Not lw_com Is Nothing Then
                        If comentarios <> "" Then
                            lw_com.COMENTARIO = comentarios
                        End If
                        lw_com.ABONADO = abonado
                        Dim fechaemi As String
                        fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                        lw_com.FECHA_EMISION = fechaemi
                        lw_com.PATH_EXCEL = path_excel
                        lw_com.PATH_PDF = path_pdf
                        lw_com.PATH_CSV = path_csv
                        lw_com.ID_ESTADO = id_estado
                        If (lw_com.modificar2()) Then
                            'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                            'limpiar()
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    Else
                        Dim lactweb_com As New dLactometrosWeb_com
                        lactweb_com.ID_USUARIO = idproductorweb_com
                        If comentarios <> "" Then
                            lactweb_com.COMENTARIO = comentarios
                        End If
                        lactweb_com.ABONADO = abonado
                        Dim fechaemi As String
                        fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                        lactweb_com.FECHA_CREADO = fechaemi
                        lactweb_com.FECHA_EMISION = fechaemi
                        lactweb_com.PATH_EXCEL = path_excel
                        lactweb_com.PATH_PDF = path_pdf
                        lactweb_com.PATH_CSV = path_csv
                        lactweb_com.FICHA = idficha
                        lactweb_com.ID_ESTADO = id_estado
                        lactweb_com.ID_LIBRO = idficha
                        If (lactweb_com.guardar()) Then
                            'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                            'limpiar()
                        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                        End If
                    End If

                ElseIf sa_.IDTIPOINFORME = 13 Then 'SI EL TIPO DE INFORME ES DE NUTRICIÓN
                    Dim aw_com As New dAgroNutricionWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    aw_com.FICHA = pi.FICHA
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
                ElseIf sa_.IDTIPOINFORME = 14 Then 'SI EL TIPO DE INFORME ES DE SUELOS
                    Dim aw_com As New dAgroSuelosWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    aw_com.FICHA = pi.FICHA
                    aw_com = aw_com.buscar
                    If Not aw_com Is Nothing Then
                        aw_com.COMENTARIO = pi.COMENTARIO
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
                        aweb_com.COMENTARIO = pi.COMENTARIO
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
                ElseIf sa_.IDTIPOINFORME = 15 Then 'SI EL TIPO DE INFORME ES DE SUELOS
                    Dim bw_com As New dBrucelosisLecheWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    productorId = pw_com.ID
                    Dim idproductorweb_com As Long = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    bw_com.FICHA = pi.FICHA
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
                ElseIf sa_.IDTIPOINFORME = 99 Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
                    Dim ow_com As New dOtrosServiciosWeb_com

                    Dim p As New dCliente
                    p = p.buscarPorId2(idnet)
                    Dim productorweb_com As String = ""
                    productorweb_com = p.USUARIO_WEB
                    Dim pw_com As New dProductorWeb_com
                    pw_com.USUARIO = productorweb_com
                    pw_com = pw_com.buscar
                    Dim idproductorweb_com As Long = pw_com.ID
                    productorId = pw_com.ID

                    Dim comentarios As String = pi.COMENTARIO
                    Dim abonado As Integer = pi.ABONADO
                    Dim fecha_emision As Date = pi.FECHA
                    Dim path_excel As String = ""
                    path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & pi.FICHA & ".xls"
                    Dim path_pdf As String = ""
                    path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & pi.FICHA & ".pdf"
                    Dim path_csv As String = ""
                    path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & pi.FICHA & ".txt"
                    Dim id_estado As Integer = 3

                    ow_com.FICHA = pi.FICHA
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
                If sa_.IDTIPOINFORME = 1 Then
                    carpeta = "control_lechero"
                ElseIf sa_.IDTIPOINFORME = 3 Then
                    carpeta = "agua"
                ElseIf sa_.IDTIPOINFORME = 4 Then
                    carpeta = "antibiograma"
                ElseIf sa_.IDTIPOINFORME = 6 Then
                    carpeta = "parasitologia"
                ElseIf sa_.IDTIPOINFORME = 7 Then
                    carpeta = "productos_subproductos"
                ElseIf sa_.IDTIPOINFORME = 8 Then
                    carpeta = "serologia"
                ElseIf sa_.IDTIPOINFORME = 9 Then
                    carpeta = "patologia"
                ElseIf sa_.IDTIPOINFORME = 10 Then
                    carpeta = "calidad_de_leche"
                ElseIf sa_.IDTIPOINFORME = 11 Then
                    carpeta = "ambiental"
                ElseIf sa_.IDTIPOINFORME = 13 Then
                    carpeta = "agro_nutricion"
                ElseIf sa_.IDTIPOINFORME = 14 Then
                    carpeta = "agro_suelos"
                ElseIf sa_.IDTIPOINFORME = 15 Then
                    carpeta = "brucelosis_leche"
                End If

                Dim rg As New dResultado

                Dim fechaemi2 As String
                Dim fecha_emision2 As Date = pi.FECHA
                fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")

                _comentarios = pi.COMENTARIO


                rg.ficha = pi.FICHA
                rg.comentarios = pi.COMENTARIO
                rg.idnet_usuario = idnet
                rg.abonado = pi.ABONADO
                rg.fecha_creado = fechaemi2
                rg.fecha_emision = fechaemi2
                rg.path_excel = "/home/colaveco/public_html/gestor/data_file/" & productorId & "/" & carpeta & "/" & pi.FICHA & ".xls"
                rg.path_pdf = "/home/colaveco/public_html/gestor/data_file/" & productorId & "/" & carpeta & "/" & pi.FICHA & ".pdf"
                rg.path_csv = "/home/colaveco/public_html/gestor/data_file/" & productorId & "/" & carpeta & "/" & pi.FICHA & ".txt"
                rg.id_estado = 3
                rg.id_libro = pi.FICHA
                rg.idnet_tipo_informe = sa_.IDTIPOINFORME
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
            Next
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


#Region "SUBIR-INFORMES"

    
    Private Sub subir_informes_gestor(ByVal lista As ArrayList)

        Dim pi As New dPreinformes
        If Not lista Is Nothing Then
            For Each pi In lista
                Dim subidoxls As Integer = 0
                Dim subidopdf As Integer = 0
                Dim subidotxt As Integer = 0

                Dim sa As New dSolicitudAnalisis
                sa.ID = pi.FICHA
                sa = sa.buscar
                idficha = pi.FICHA
                If Not sa Is Nothing Then
                    Dim p As New dCliente
                    tipoinforme = sa.IDTIPOINFORME
                    p.ID = sa.IDPRODUCTOR
                    p = p.buscar

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
                    End If
                End If
controlexcel:
                subirFicheroXls_G()
                existeXls_G()
                If excel = 1 Then
                    GoTo controlexcel
                End If
                subidoxls = 1
controlpdf:
                subirFicheroPdf_G()
                existePdf_G()
                If pdf = 1 Then
                    GoTo controlpdf
                End If
                subidopdf = 1
                If tipoinforme = 1 Then
controltxt:
                    subirFicheroCsv_G()
                    existeCsv_G()
                    If csv = 1 Then
                        GoTo controltxt
                    End If
                End If
                Dim s As New dSolicitudAnalisis
                Dim fechaenvio As Date = Date.Now.ToString("yyyy-MM-dd")
                Dim fecenv As String
                fecenv = Format(fechaenvio, "yyyy-MM-dd")
               
            Next
        End If
    End Sub

    Public Sub crea_carpeta()
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        Dim peticionFTP As FtpWebRequest
        Dim dir As String = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & carpeta
        ' Creamos una peticion FTP con la dirección del directorio que queremos crear
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)
        ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
        peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
        peticionFTP.KeepAlive = False
        peticionFTP.UseBinary = True
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

    Public Function existeXls() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\e\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\e\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\e\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\e\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\e\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\e\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\e\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\e\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\e\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\e\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 16 Then
            fichero = "\\192.168.1.10\e\NET\Efluentes\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".xls"
        ElseIf tipoinforme = 17 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 18 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 19 Then
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 20 Then
            fichero = "\\192.168.1.10\e\NET\Toxicologia\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"

        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".xls"
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
            'MsgBox("No esta creado el .XLS de la ficha + " & idficha & "", MsgBoxStyle.Critical, "Atención")
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existePdf() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\e\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\e\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\e\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\e\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\e\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\e\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\e\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\e\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\e\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\e\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 16 Then
            fichero = "\\192.168.1.10\e\NET\Efluentes\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".pdf"
        ElseIf tipoinforme = 17 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 18 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 19 Then
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 20 Then
            fichero = "\\192.168.1.10\e\NET\Toxicologia\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".pdf"
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
            ' MsgBox("No esta creado el PDF de la ficha + " & idficha & "", MsgBoxStyle.Critical, "Atención")
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existeCsv() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Or tipoinforme = 10 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"



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
                'MsgBox("No esta creado el txt de la ficha + " & idficha & "", MsgBoxStyle.Critical, "Atención")
                ' Si el objeto no existe, se producirá un error y al entrar por el Catch
                ' se devolverá falso
                Return False
            End Try
        End If
        If tipoinforme = 10 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"



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
                'MsgBox("No esta creado el TXT de la ficha + " & idficha & "", MsgBoxStyle.Critical, "Atención")
                ' Si el objeto no existe, se producirá un error y al entrar por el Catch
                ' se devolverá falso
                Return False
            End Try
        End If
    End Function


    Public Function subirFicheroXls() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            'fichero = "\\192.168.1.10\e\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            'fichero = "\\192.168.1.10\e\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            'fichero = "\\192.168.1.10\e\NET\PARASITOLOGIA\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            'fichero = "\\192.168.1.10\e\NET\INFORMES PARA SUBIR\" & idficha & ".xls"
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 16 Then
            crea_efluentes_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".xls"
        ElseIf tipoinforme = 17 Then
            crea_antibiograma_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 18 Then
            crea_antibiograma_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 20 Then
            crea_patologia_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".xls"
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
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 16 Then
            crea_efluentes_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".pdf"
        ElseIf tipoinforme = 17 Then
            crea_antibiograma_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 18 Then
            crea_antibiograma_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 20 Then
            crea_patologia_com()
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".pdf"
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
        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
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
            'MsgBox("No encuentro el PDF " & idficha & " en Informes para subir")
            Return ex.Message
        End Try
    End Function

    Public Function subirFicheroCsv() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        End If
        If tipoinforme = 10 And userid = 6299 Then
            fichero = "C:\INFORMES PARA SUBIR\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        End If
        If fichero <> "" Then
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
        End If
    End Function

    Public Function existeXls_G() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\e\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\e\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy.uy/www/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\e\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\e\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\e\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\e\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\e\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\e\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\e\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\e\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 16 Then
            fichero = "\\192.168.1.10\e\NET\Efluentes\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".xls"
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
    Public Function existePdf_G() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\e\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\e\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\e\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\e\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\e\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\e\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\e\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\e\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\e\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\e\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 16 Then
            fichero = "\\192.168.1.10\e\NET\Efluentes\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".pdf"
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
    Public Function existeCsv_G() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".txt"
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


    Public Function subirFicheroXls_G() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            fichero = "\\192.168.1.10\e\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            fichero = "\\192.168.1.10\e\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            fichero = "\\192.168.1.10\e\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "\\192.168.1.10\e\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            fichero = "\\192.168.1.10\e\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "\\192.168.1.10\e\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "\\192.168.1.10\e\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "\\192.168.1.10\e\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 16 Then
            crea_efluentes_com()
            fichero = "\\192.168.1.10\e\NET\Efluentes\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".xls"
        ElseIf tipoinforme = 17 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 18 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 20 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".xls"
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
    Public Function subirFicheroPdf_G() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            crea_control_lechero_com()
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            crea_agua_com()
            fichero = "\\192.168.1.10\e\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            crea_parasitologia_com()
            fichero = "\\192.168.1.10\e\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            crea_productos_subproductos_com()
            fichero = "\\192.168.1.10\e\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            crea_serologia_com()
            fichero = "\\192.168.1.10\e\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            crea_calidad_de_leche_com()
            fichero = "\\192.168.1.10\e\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            crea_ambiental_com()
            fichero = "\\192.168.1.10\e\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            crea_agro_nutricion_com()
            fichero = "\\192.168.1.10\e\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "\\192.168.1.10\e\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 16 Then
            crea_efluentes_com()
            fichero = "\\192.168.1.10\e\NET\Efluentes\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/efluentes/" & idficha & ".pdf"
        ElseIf tipoinforme = 17 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 18 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\e\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\e\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 20 Then
            crea_patologia_com()
            fichero = "\\192.168.1.10\e\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
            fichero = "\\192.168.1.10\e\NET\OTROS\" & idficha & ".pdf"
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
        ' Informamos al servidor sobre el tamaño del fichero que vamos a subir
        'peticionFTP.ContentLength = infoFichero.Length
        '**********************************************************************
        Try
            peticionFTP.ContentLength = infoFichero.Length
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
        '*********************************************************************
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
    Public Function subirFicheroCsv_G() As String
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\e\NET\CONTROL_LECHERO\" & idficha & ".txt"
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

#End Region

#Region "CREAR-FTP-COLAVECO.COM"

    Public Sub crea_brucelosis_leche_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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
        Dim pass As String = "NUEVA**!!COL22"
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

#End Region

End Class