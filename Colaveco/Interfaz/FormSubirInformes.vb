﻿Imports System.Net.FtpWebRequest
Imports System.Net
Imports System.IO

Imports Newtonsoft.Json

Public Class FormSubirInformes
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
        CheckComUy.Checked = False
    End Sub
    Private Sub ButtonSubirInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirInforme.Click
        'subirinforme()
        subirinforme2()
      
    End Sub
    Private Sub subirinforme()
        If CheckCom.Checked = True Then
            If CheckXls.Checked = True Then
controlexcel:
                subirFicheroXls()
                existeXls()
                If excel = 1 Then
                    GoTo controlexcel
                End If
            End If
            If CheckPdf.Checked = True Then
controlpdf:
                subirFicheroPdf()
                existePdf()
                If pdf = 1 Then
                    GoTo controlpdf
                End If
            End If
            If CheckTxt.Checked = True Then
controlcsv:
                subirFicheroCsv()
                existeCsv()
                If csv = 1 Then
                    GoTo controlcsv
                End If
            End If
            modificarRegistro()
            Dim picalidad As New dPreinformeCalidad
            Dim picontrol As New dPreinformeControl
            Dim fechaactual2 As Date = Now()
            Dim _fecha2 As String
            _fecha2 = Format(fechaactual2, "yyyy-MM-dd")
            If tipoinforme = 1 Then
                picontrol.FICHA = idficha
                picontrol.marcarsubido(_fecha2)
            End If
            If tipoinforme = 10 Then
                picalidad.FICHA = idficha
                picalidad.marcarsubido(_fecha2)
            End If


        End If

        If tipoinforme = 15 Then
            enviar_correo_brucelosisenleche()
        End If

        Dim cliente As Integer = 0
        cliente = TextIdCliente.Text.Trim
        If cliente = 6299 Then
            If tipoinforme = 10 Then
                If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
                    enviar_correo_AFB()
                    enviar_correo_AFB2()
                End If
            End If
        End If


        If TextEnviarCopia.Text <> "" Then
            enviocopia()
        End If

        If TextIdCliente.Text.Trim = 143 Then
            enviartxtxcorreo()
        End If

        Dim s As New dSolicitudAnalisis
        Dim fechaenvio As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecenv As String
        fecenv = Format(fechaenvio, "yyyy-MM-dd")
        s.ID = TextFicha.Text.Trim
        Dim _fecha As String
        Dim fechaactual As Date = Now()
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        s.marcar(Usuario, _fecha)
        s.actualizarfechaenvio(fecenv)
        'enviomail()
        enviosms()
        'If mensaje = "" Then
        MsgBox("Archivos subidos correctamente!")
        'Else
        'MsgBox("Archivos con error: " & mensaje)
        'End If


        ' Grabar estado de la ficha
        Dim est As New dEstados
        est.FICHA = s.ID
        est.ESTADO = 8
        est.FECHA = fecenv
        est.guardar2()
        est = Nothing
        '****************************
        ' Grabar si es sin visualización
        If RadioNoAbonadosv.Checked = True Then
            Dim ficha As Long = s.ID
            Dim fecha As String = fecenv
            Dim muestras As Integer = s.NMUESTRAS
            Dim importe As Double = s.IMPORTE
            Dim visualizacion As Integer = 0
            Dim observaciones As String = ""
            Dim sv As New dSinVisualizacion
            sv.FICHA = ficha
            sv.FECHA = fecha
            sv.MUESTRAS = muestras
            sv.IMPORTE = importe
            sv.VISUALIZACION = visualizacion
            sv.FECHAVISUALIZACION = fecha
            sv.OBSERVACIONES = observaciones
            sv.guardar()
            sv = Nothing

            Dim p As New dCliente
            Dim prod As Long = s.IDPRODUCTOR

            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            If Not pw_com Is Nothing Then
                email = RTrim(pw_com.ENVIAR_EMAIL)
            Else
                MsgBox("No coincide el usuario web (.com)")
            End If

            Dim v As New FormCorreoMorosos(Usuario, email, ficha)
            v.Show()

            p = Nothing
            prod = Nothing
            productorweb_com = Nothing
            pw_com = Nothing
        Else
            Dim ficha As Long = 0
            ficha = TextFicha.Text.Trim
            Dim sol As New dSolicitudAnalisis
            sol.ID = ficha
            sol = sol.buscar

            Dim p As New dCliente
            p.ID = sol.IDPRODUCTOR
            p = p.buscar
            Dim prod As Long = sol.IDPRODUCTOR

            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            If Not pw_com Is Nothing Then
                email = RTrim(pw_com.ENVIAR_EMAIL)
            Else
                MsgBox("No coincide el usuario web (.com)")
            End If

            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()

            productorweb_com = Nothing
            pw_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If

        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subirinforme2()
        Dim ficha As Long = 0
        Dim abonado As Integer = 0
        Dim comentario As String = ""
        Dim copia As String = ""
        ficha = TextFicha.Text.Trim
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


        If TextTipoAnalisis.Text = "Calidad de leche" Then

            Dim cliente As Integer = 0
            cliente = TextIdCliente.Text.Trim
            'If cliente = 6299 Then
            '    'If tipoinforme = 10 Then
            '    If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
            '        enviar_correo_AFB()
            '    End If
            '    'End If
            'End If

            


            '*** MOVER ARCHIVO XLS ***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\CALIDAD\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF ***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\CALIDAD\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            Dim fechaactual As Date = Now()
            Dim fecactual As String
            fecactual = Format(fechaactual, "yyyy-MM-dd")

            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.FECHA = fecactual
            pi.modificar2()

            'AGREGRA A LISTA PARA CONTROLAR FQ***************************
            Dim fechadesde As Date = Now
            Dim fechahasta As Date = Now
            Dim fechad As String
            Dim fechah As String
            Dim tipo As Integer = 10
            fechad = Format(fechadesde, "yyyy-MM-dd")
            fechah = Format(fechahasta, "yyyy-MM-dd")
            Dim ci As New dControlInformesFQ
            Dim lista As New ArrayList
            lista = ci.listarxtipoxfecha(tipo.ToString, fechad, fechah, ficha)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
                    Dim cifq As New dControlInformesFQ
                    Dim controlGestor As New dNGControl
                    cifq.FECHACONTROL = fechad
                    cifq.FICHA = ficha
                    cifq.FECHA = fechad
                    cifq.TIPO = 10
                    cifq.RESULTADO = 0
                    cifq.COINCIDE = 0
                    cifq.OBSERVACIONES = ""
                    cifq.CONTROLADOR = 100
                    cifq.CONTROLADO = 0
                    cifq.guardar()
                    cifq = Nothing

                    'Registro en Gestor Nuevo
                    controlGestor.InformeId = pi.FICHA
                    controlGestor.UsuarioId = _usuario.ID
                    controlGestor.ControlTipoId = 1 'FQ
                    controlGestor.ControlCoincide = 0
                    controlGestor.ControlControlado = 0
                    controlGestor.ControlFechaIngreso = Today.ToString("yyyy-MM-dd HH:mm:ss")
                    controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                    controlGestor.ControlInformeTipo = pi.TIPO
                    controlGestor.ControlNoConformidad = 0
                    controlGestor.ControlObservaciones = "Se creo Control"
                    controlGestor.ControlOpcMejora = 0
                    controlGestor.ControlResultado = 0
                    controlGestor.guardar()

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            Else
                Dim cifq As New dControlInformesFQ
                cifq.FECHACONTROL = fechad
                cifq.FICHA = ficha
                cifq.FECHA = fechad
                cifq.TIPO = 10
                cifq.RESULTADO = 0
                cifq.COINCIDE = 0
                cifq.OBSERVACIONES = ""
                cifq.CONTROLADOR = 100
                cifq.CONTROLADO = 0
                cifq.guardar()
                cifq = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
            'AGREGRA A LISTA PARA CONTROLAR MICRO***************************
            Dim csm As New dCalidadSolicitudMuestra
            csm.FICHA = ficha
            csm = csm.buscarxsolicitud
            If csm.RB = 1 Or csm.INHIBIDORES = 1 Or csm.ESPORULADOS = 1 Or csm.PSICROTROFOS = 1 Then
                Dim cim As New dControlInformesMicro
                Dim listam As New ArrayList
                listam = cim.listarxtipoxfecha(tipo, fechad, fechah)
                If Not listam Is Nothing Then
                    If listam.Count < 6 Then
                        Dim cimicro As New dControlInformesMicro
                        cimicro.FECHACONTROL = fechad
                        cimicro.FICHA = ficha
                        cimicro.FECHA = fechad
                        cimicro.TIPO = 10
                        cimicro.RESULTADO = 0
                        cimicro.COINCIDE = 0
                        cimicro.OBSERVACIONES = ""
                        cimicro.CONTROLADOR = 100
                        cimicro.CONTROLADO = 0
                        cimicro.guardar()
                        cimicro = Nothing

                        ' Grabar estado de la ficha
                        Dim est As New dEstados
                        est.FICHA = ficha
                        est.ESTADO = 6
                        est.FECHA = fechad
                        est.guardar2()
                        est = Nothing
                        '****************************
                    End If
                Else
                    Dim cimicro As New dControlInformesMicro
                    cimicro.FECHACONTROL = fechad
                    cimicro.FICHA = ficha
                    cimicro.FECHA = fechad
                    cimicro.TIPO = 10
                    cimicro.RESULTADO = 0
                    cimicro.COINCIDE = 0
                    cimicro.OBSERVACIONES = ""
                    cimicro.CONTROLADOR = 100
                    cimicro.CONTROLADO = 0
                    cimicro.guardar()
                    cimicro = Nothing

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            End If

            If cliente = 6299 Then
                'If tipoinforme = 10 Then
                If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
                    enviar_correo_AFB()
                    enviar_correo_AFB2()
                End If
                'End If
            End If
            '*****************************************************************************

        ElseIf TextTipoAnalisis.Text = "Control Lechero" Then



            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\CONTROL\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\CONTROL\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO TXT***********************************************************************
            'Dim sArchivoOrigen3 As String = "\\192.168.1.10\E\NET\PREINFORMES\CONTROL\" & ficha & ".txt"
            Dim sArchivoOrigen3 As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".txt"
            'Dim sRutaDestino3 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".txt"
            Dim sRutaDestino3 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".txt"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen3, _
                                                sRutaDestino3, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

            'AGREGRA A LISTA PARA CONTROLAR ***************************
            Dim fechadesde As Date = Now
            Dim fechahasta As Date = Now
            Dim fechad As String
            Dim fechah As String
            Dim tipo As Integer = 1
            fechad = Format(fechadesde, "yyyy-MM-dd")
            fechah = Format(fechahasta, "yyyy-MM-dd")
            Dim ci As New dControlInformesFQ
            Dim lista As New ArrayList
            lista = ci.listarxtipoxfecha(tipo.ToString, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
                    Dim cifq As New dControlInformesFQ
                    Dim controlGestor As New dNGControl
                    cifq.FECHACONTROL = fechad
                    cifq.FICHA = ficha
                    cifq.FECHA = fechad
                    cifq.TIPO = 1
                    cifq.RESULTADO = 0
                    cifq.COINCIDE = 0
                    cifq.OBSERVACIONES = ""
                    cifq.CONTROLADOR = 100
                    cifq.CONTROLADO = 0
                    cifq.guardar()
                    cifq = Nothing

                    Try
                        'Registro en Gestor Nuevo
                        controlGestor.InformeId = pi.FICHA
                        controlGestor.UsuarioId = _usuario.ID
                        controlGestor.ControlTipoId = 3 'Micro
                        controlGestor.ControlCoincide = 0
                        controlGestor.ControlControlado = 0
                        controlGestor.ControlFechaIngreso = Today.ToString("yyyy-MM-dd HH:mm:ss")
                        controlGestor.ControlFechaRealizado = Today.ToString("yyyy-MM-dd HH:mm:ss")
                        controlGestor.ControlInformeTipo = pi.TIPO
                        controlGestor.ControlNoConformidad = 0
                        controlGestor.ControlObservaciones = "Se creo Control"
                        controlGestor.ControlOpcMejora = 0
                        controlGestor.ControlResultado = 0
                        controlGestor.guardar()
                    Catch ex As Exception

                    End Try


                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            Else
                Dim cifq As New dControlInformesFQ
                cifq.FECHACONTROL = fechad
                cifq.FICHA = ficha
                cifq.FECHA = fechad
                cifq.TIPO = 1
                cifq.RESULTADO = 0
                cifq.COINCIDE = 0
                cifq.OBSERVACIONES = ""
                cifq.CONTROLADOR = 100
                cifq.CONTROLADO = 0
                cifq.guardar()
                cifq = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
            '*****************************************************************************

        ElseIf TextTipoAnalisis.Text = "Agua" Then


            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\AGUA\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\AGUA\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

            'AGREGRA A LISTA PARA CONTROLAR ***************************
            Dim fechadesde As Date = Now
            Dim fechahasta As Date = Now
            Dim fechad As String
            Dim fechah As String
            Dim tipo As Integer = 3
            fechad = Format(fechadesde, "yyyy-MM-dd")
            fechah = Format(fechahasta, "yyyy-MM-dd")
            Dim ci As New dControlInformesMicro
            Dim lista As New ArrayList
            lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
                    Dim cimicro As New dControlInformesMicro
                    cimicro.FECHACONTROL = fechad
                    cimicro.FICHA = ficha
                    cimicro.FECHA = fechad
                    cimicro.TIPO = 3
                    cimicro.RESULTADO = 0
                    cimicro.COINCIDE = 0
                    cimicro.OBSERVACIONES = ""
                    cimicro.CONTROLADOR = 100
                    cimicro.CONTROLADO = 0
                    cimicro.guardar()
                    cimicro = Nothing

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            Else
                Dim cimicro As New dControlInformesMicro
                cimicro.FECHACONTROL = fechad
                cimicro.FICHA = ficha
                cimicro.FECHA = fechad
                cimicro.TIPO = 3
                cimicro.RESULTADO = 0
                cimicro.COINCIDE = 0
                cimicro.OBSERVACIONES = ""
                cimicro.CONTROLADOR = 100
                cimicro.CONTROLADO = 0
                cimicro.guardar()
                cimicro = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
            '*****************************************************************************

        ElseIf TextTipoAnalisis.Text = "Alimentos" Then


            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\ALIMENTOS\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\ALIMENTOS\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\ALIMENTOS\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\ALIMENTOS\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

            'AGREGRA A LISTA PARA CONTROLAR ***************************
            Dim fechadesde As Date = Now
            Dim fechahasta As Date = Now
            Dim fechad As String
            Dim fechah As String
            Dim tipo As Integer = 7
            fechad = Format(fechadesde, "yyyy-MM-dd")
            fechah = Format(fechahasta, "yyyy-MM-dd")
            Dim ci As New dControlInformesMicro
            Dim lista As New ArrayList
            lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
                    Dim cimicro As New dControlInformesMicro
                    cimicro.FECHACONTROL = fechad
                    cimicro.FICHA = ficha
                    cimicro.FECHA = fechad
                    cimicro.TIPO = 7
                    cimicro.RESULTADO = 0
                    cimicro.COINCIDE = 0
                    cimicro.OBSERVACIONES = ""
                    cimicro.CONTROLADOR = 100
                    cimicro.CONTROLADO = 0
                    cimicro.guardar()
                    cimicro = Nothing

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            Else
                Dim cimicro As New dControlInformesMicro
                cimicro.FECHACONTROL = fechad
                cimicro.FICHA = ficha
                cimicro.FECHA = fechad
                cimicro.TIPO = 7
                cimicro.RESULTADO = 0
                cimicro.COINCIDE = 0
                cimicro.OBSERVACIONES = ""
                cimicro.CONTROLADOR = 100
                cimicro.CONTROLADO = 0
                cimicro.guardar()
                cimicro = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
            '*****************************************************************************

        ElseIf TextTipoAnalisis.Text = "Bacteriología y Antibiograma" Then

            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

        ElseIf TextTipoAnalisis.Text = "Brucelosis en leche" Then

            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

        ElseIf TextTipoAnalisis.Text = "Nutrición" Then


            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\NUTRICION\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\NUTRICION\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

            'AGREGRA A LISTA PARA CONTROLAR ***************************
            Dim fechadesde As Date = Now
            Dim fechahasta As Date = Now
            Dim fechad As String
            Dim fechah As String
            Dim tipo As Integer = 13
            fechad = Format(fechadesde, "yyyy-MM-dd")
            fechah = Format(fechahasta, "yyyy-MM-dd")
            Dim ci As New dControlInformesNutricion
            Dim lista As New ArrayList
            lista = ci.listarxtipoxfecha(tipo.ToString, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
                    Dim cinutricion As New dControlInformesNutricion
                    cinutricion.FECHACONTROL = fechad
                    cinutricion.FICHA = ficha
                    cinutricion.FECHA = fechad
                    cinutricion.TIPO = 13
                    cinutricion.RESULTADO = 0
                    cinutricion.COINCIDE = 0
                    cinutricion.OBSERVACIONES = ""
                    cinutricion.CONTROLADOR = 100
                    cinutricion.CONTROLADO = 0
                    cinutricion.guardar()
                    cinutricion = Nothing

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            Else
                Dim cinutricion As New dControlInformesNutricion
                cinutricion.FECHACONTROL = fechad
                cinutricion.FICHA = ficha
                cinutricion.FECHA = fechad
                cinutricion.TIPO = 13
                cinutricion.RESULTADO = 0
                cinutricion.COINCIDE = 0
                cinutricion.OBSERVACIONES = ""
                cinutricion.CONTROLADOR = 100
                cinutricion.CONTROLADO = 0
                cinutricion.guardar()
                cinutricion = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
            '*****************************************************************************

        ElseIf TextTipoAnalisis.Text = "Suelos" Then


            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

            'AGREGRA A LISTA PARA CONTROLAR ***************************
            Dim fechadesde As Date = Now
            Dim fechahasta As Date = Now
            Dim fechad As String
            Dim fechah As String
            Dim tipo As Integer = 14
            fechad = Format(fechadesde, "yyyy-MM-dd")
            fechah = Format(fechahasta, "yyyy-MM-dd")
            Dim ci As New dControlInformesSuelos
            Dim lista As New ArrayList
            lista = ci.listarxtipoxfecha(tipo.ToString, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
                    Dim cisuelos As New dControlInformesSuelos
                    cisuelos.FECHACONTROL = fechad
                    cisuelos.FICHA = ficha
                    cisuelos.FECHA = fechad
                    cisuelos.TIPO = 14
                    cisuelos.RESULTADO = 0
                    cisuelos.COINCIDE = 0
                    cisuelos.OBSERVACIONES = ""
                    cisuelos.CONTROLADOR = 100
                    cisuelos.CONTROLADO = 0
                    cisuelos.guardar()
                    cisuelos = Nothing

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            Else
                Dim cisuelos As New dControlInformesSuelos
                cisuelos.FECHACONTROL = fechad
                cisuelos.FICHA = ficha
                cisuelos.FECHA = fechad
                cisuelos.TIPO = 14
                cisuelos.RESULTADO = 0
                cisuelos.COINCIDE = 0
                cisuelos.OBSERVACIONES = ""
                cisuelos.CONTROLADOR = 100
                cisuelos.CONTROLADO = 0
                cisuelos.guardar()
                cisuelos = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
            '*****************************************************************************
        ElseIf TextTipoAnalisis.Text = "Efluentes" Then


            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\EFLUENTES\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, _
                                                sRutaDestino, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            'Dim sArchivoOrigen2 As String = "\\192.168.1.10\E\NET\PREINFORMES\AGUA\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\EFLUENTES\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\192.168.1.10\E\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"

            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, _
                                                sRutaDestino2, _
                                                True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try

            '***********************************
            Dim pi As New dPreinformes
            pi.FICHA = ficha
            pi.ABONADO = abonado
            pi.COMENTARIO = comentario
            pi.COPIA = copia
            pi.PARASUBIR = 1
            pi.modificar2()

            'AGREGRA A LISTA PARA CONTROLAR ***************************
            Dim fechadesde As Date = Now
            Dim fechahasta As Date = Now
            Dim fechad As String
            Dim fechah As String
            Dim tipo As Integer = 14
            fechad = Format(fechadesde, "yyyy-MM-dd")
            fechah = Format(fechahasta, "yyyy-MM-dd")
            Dim ci As New dControlInformesEfluentes
            Dim lista As New ArrayList
            lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
                    Dim ciefluentes As New dControlInformesEfluentes
                    ciefluentes.FECHACONTROL = fechad
                    ciefluentes.FICHA = ficha
                    ciefluentes.FECHA = fechad
                    ciefluentes.TIPO = 16
                    ciefluentes.RESULTADO = 0
                    ciefluentes.COINCIDE = 0
                    ciefluentes.OBSERVACIONES = ""
                    ciefluentes.CONTROLADOR = 100
                    ciefluentes.CONTROLADO = 0
                    ciefluentes.guardar()
                    ciefluentes = Nothing

                    ' Grabar estado de la ficha
                    Dim est As New dEstados
                    est.FICHA = ficha
                    est.ESTADO = 6
                    est.FECHA = fechad
                    est.guardar2()
                    est = Nothing
                    '****************************
                End If
            Else
                Dim ciefluentes As New dControlInformesEfluentes
                ciefluentes.FECHACONTROL = fechad
                ciefluentes.FICHA = ficha
                ciefluentes.FECHA = fechad
                ciefluentes.TIPO = 16
                ciefluentes.RESULTADO = 0
                ciefluentes.COINCIDE = 0
                ciefluentes.OBSERVACIONES = ""
                ciefluentes.CONTROLADOR = 100
                ciefluentes.CONTROLADO = 0
                ciefluentes.guardar()
                ciefluentes = Nothing

                ' Grabar estado de la ficha
                Dim est As New dEstados
                est.FICHA = ficha
                est.ESTADO = 6
                est.FECHA = fechad
                est.guardar2()
                est = Nothing
                '****************************
            End If
            '*****************************************************************************
        End If

        ' Grabar si es sin visualización
        If RadioNoAbonadosv.Checked = True Then
            Dim fechaact As Date = Now()
            Dim fecact As String
            fecact = Format(fechaact, "yyyy-MM-dd")
            Dim sol As New dSolicitudAnalisis
            sol.ID = ficha
            sol = sol.buscar
            Dim muestras As Integer = 0
            If Not sol Is Nothing Then
                muestras = sol.NMUESTRAS
            End If
            Dim importe As Double = sol.IMPORTE
            Dim visualizacion As Integer = 0
            Dim observaciones As String = ""
            Dim sv As New dSinVisualizacion
            sv.FICHA = ficha
            fichasv = ficha
            sv.FECHA = fecact
            sv.MUESTRAS = muestras
            sv.IMPORTE = importe
            sv.VISUALIZACION = visualizacion
            sv.FECHAVISUALIZACION = fecact
            sv.OBSERVACIONES = observaciones
            sv.guardar()


            Dim p As New dCliente
            Dim prod As Long = sol.IDPRODUCTOR

            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            If Not pw_com Is Nothing Then
                email = RTrim(pw_com.ENVIAR_EMAIL)
            Else
                MsgBox("No coincide el usuario web (.com)")
            End If

            Dim v As New FormCorreoMorosos(Usuario, email, ficha)
            v.Show()

            productorweb_com = Nothing
            pw_com = Nothing
            p = Nothing
            prod = Nothing
            sv = Nothing
            sol = Nothing
        Else

            Dim sol As New dSolicitudAnalisis
            sol.ID = ficha
            sol = sol.buscar

            Dim p As New dCliente
            Dim prod As Long = sol.IDPRODUCTOR
            p.ID = sol.IDPRODUCTOR
            p = p.buscar
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            If Not pw_com Is Nothing Then
                email = RTrim(pw_com.ENVIAR_EMAIL)
            Else
                MsgBox("No coincide el usuario web (.com)")
            End If

            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()

            productorweb_com = Nothing
            pw_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************

        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub enviocopia()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim enviarcopia As String = ""
        Dim fichero As String = ""
        Dim tipo As String = ""
        enviarcopia = TextEnviarCopia.Text.Trim
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            tipo = "Control lechero"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            tipo = "Agua"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            tipo = "Antibiograma"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            tipo = "PAL"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            tipo = "Parasitología"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            tipo = "Alimentos"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            tipo = "Serología"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            tipo = "Patología"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            tipo = "Calidad de leche"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            tipo = "Prueba ambiental"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            tipo = "Lactómetros"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            tipo = "Nutrición"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            tipo = "Suelos"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            tipo = "Brucelosis en leche"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            tipo = "Otros"
        End If

        If enviarcopia <> "" Then

            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(enviarcopia)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "Informe" & " " & idficha & " - " & tipo
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            _Message.Body = "Adjunto informe:" & " " & tipo
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False


            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = fichero 'My.Application.Info.DirectoryPath & fichero 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                '_SMTP.Send(_Message)
                'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try


            _SMTP.Send(_Message)
            'MessageBox.Show("Pedidos enviados!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If




    End Sub
    Public Function eliminarFichero(ByVal fichero As String) As String
        Dim destino As String = "ftp://colaveco.com.uy/www/gestor/data_file/1002/prueba.xls"
        Dim user As String = "colaveco"
        Dim pass As String = "Fmbh23052305"
        Dim peticionFTP As FtpWebRequest

        ' Creamos una petición FTP con la dirección del fichero a eliminar
        peticionFTP = CType(WebRequest.Create(New Uri(fichero)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
        peticionFTP.UsePassive = False

        Try
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            respuestaFTP.Close()
            ' Si todo ha ido bien, devolvemos String.Empty
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
        Dim pass As String = "Fmbh23052305"
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
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
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
        Dim pass As String = "Fmbh23052305"
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
        Dim pass As String = "Fmbh23052305"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
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
    Public Function existeXls2() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".xls"
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
            Return True
        Catch ex As Exception
            mensaje = mensaje & " excel(uy) - "
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existePdf2() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & "pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".pdf"
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
            Return True
        Catch ex As Exception
            mensaje = mensaje & " pdf(uy) - "
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existeCsv2() As Boolean
        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".txt"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".txt"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".txt"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".txt"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".txt"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".txt"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".txt"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".txt"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".txt"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".txt"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".txt"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".txt"
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
            Return True
        Catch ex As Exception
            mensaje = mensaje & " csv(uy)"
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function
    Public Function existeObjeto() As Boolean
        'Dim destino As String = "ftp://colaveco.com.uy/www/gestor/data_file/1002/prueba.xls"
        Dim user As String = "colaveco"
        Dim pass As String = "Fmbh23052305"
        Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/pepito/"
        Dim peticionFTP As FtpWebRequest

        ' Creamos una peticion FTP con la dirección del objeto que queremos saber si existe
        peticionFTP = CType(WebRequest.Create(New Uri(dir)), FtpWebRequest)

        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(user, pass)

        ' Para saber si el objeto existe, solicitamos la fecha de creación del mismo
        peticionFTP.Method = WebRequestMethods.Ftp.GetDateTimestamp

        peticionFTP.UsePassive = False

        Try
            ' Si el objeto existe, se devolverá True
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
            Return True
        Catch ex As Exception
            ' Si el objeto no existe, se producirá un error y al entrar por el Catch
            ' se devolverá falso
            Return False
        End Try
    End Function

    Public Function creaDirectorio() As String
        Dim user As String = "colaveco"
        Dim pass As String = "Fmbh23052305"
        Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/pepito2/"
        Dim peticionFTP As FtpWebRequest

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
            Return String.Empty
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            Return ex.Message
        End Try
    End Function

    Public Function subirFicheroXls() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "Fmbh23052305"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
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
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
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
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            crea_brucelosis_leche_com()
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
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
        Dim pass As String = "Fmbh23052305"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
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
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
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
    Public Function subirFicheroCsv() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "Fmbh23052305"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".txt"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
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
    Public Function subirFicheroXls2() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".xls"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".xls"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".xls"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".xls"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".xls"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".xls"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".xls"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".xls"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".xls"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".xls"
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

    Public Function subirFicheroPdf2() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"
        'Dim dir As String = "ftp://colaveco.com.uy/www/gestor/data_file/1"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".pdf"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".pdf"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".pdf"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".pdf"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".pdf"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".pdf"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".pdf"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".pdf"
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
    Public Function subirFicheroCsv2() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colav0"
        Dim pass As String = "colaveco5311"
        If tipoinforme = 1 Then
            fichero = "\\192.168.1.10\E\NET\CONTROL_LECHERO\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".txt"
        ElseIf tipoinforme = 3 Then
            fichero = "\\192.168.1.10\E\NET\AGUA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".txt"
        ElseIf tipoinforme = 4 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".txt"
        ElseIf tipoinforme = 5 Then
            fichero = "\\192.168.1.10\E\NET\PAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".txt"
        ElseIf tipoinforme = 6 Then
            fichero = "\\192.168.1.10\E\NET\PARASITOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".txt"
        ElseIf tipoinforme = 7 Then
            fichero = "\\192.168.1.10\E\NET\ALIMENTOS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".txt"
        ElseIf tipoinforme = 8 Then
            fichero = "\\192.168.1.10\E\NET\SEROLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".txt"
        ElseIf tipoinforme = 9 Then
            fichero = "\\192.168.1.10\E\NET\PATOLOGIA\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".txt"
        ElseIf tipoinforme = 10 Then
            fichero = "\\192.168.1.10\E\NET\CALIDAD\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 11 Then
            fichero = "\\192.168.1.10\E\NET\AMBIENTAL\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".txt"
        ElseIf tipoinforme = 12 Then
            fichero = "\\192.168.1.10\E\NET\LACTOMETROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".txt"
        ElseIf tipoinforme = 13 Then
            fichero = "\\192.168.1.10\E\NET\NUTRICION\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".txt"
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".txt"
        ElseIf tipoinforme = 15 Then
            fichero = "\\192.168.1.10\E\NET\Brucelosis en leche\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".txt"
        ElseIf tipoinforme = 99 Then
            fichero = "\\192.168.1.10\E\NET\OTROS\" & idficha & ".txt"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".txt"
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
        productorweb_com = ""
        'productorweb_uy = ""

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
            productorweb_com = cli.USUARIO_WEB
            'productorweb_uy = pro.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            'Dim pw_uy As New dProductorWeb_uy
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            If Not pw_com Is Nothing Then
                idproductorweb_com = pw_com.ID
                email = RTrim(pw_com.ENVIAR_EMAIL)
                celular = Replace(pw_com.ENVIAR_SMS, " ", "")
            Else
                MsgBox("No coincide el usuario web (.com)")
                Exit Sub
            End If
            'If cli.MOROSO = 1 Then
            '    MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
            '    '/*comentado a pedido de Noelia, para no salir y desmarcar moroso
            '    'TextIdCliente.Text = ""
            '    'TextNombreCliente.Text = ""
            '    'Exit Sub
            'End If
            'If cli.CONTADO = 1 Then
            '    MsgBox("El cliente trabaja solo contado, tener en cuenta a la hora de subir informes.")
            '    ButtonSeleccionarFicha.Focus()
            'End If
            '*** VERIFICA SI EL CLIENTE TIENE DEUDA ***************************************
            Dim mc As New dMovCte
            Dim listamc As New ArrayList
            Dim idcli As Long = cli.ID
            Dim fechaactual As Date = Now.ToString("yyyy-MM-dd")
            Dim fechaact As String = Format(fechaactual, "yyyy-MM-dd")
            Dim vencido As Integer = 0

            listamc = mc.listarxcli(idcli)
            If Not listamc Is Nothing Then
                For Each mc In listamc
                    If mc.MCCVTO < fechaact Then
                        vencido = 1
                    End If
                Next
            End If
            'If vencido = 1 Then
            '    MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
            'End If
            '*******************************************************************************

            If cli.PROLESA = 1 Then
                MsgBox("El cliente realiza el pago por PROLESA.")
                ButtonSeleccionarFicha.Focus()
            End If
            'pw_uy.USUARIO = productorweb_uy
            'pw_uy = pw_uy.buscar
            'If Not pw_uy Is Nothing Then
            'idproductorweb_uy = pw_uy.ID
            'Else
            'MsgBox("No coincide el usuario web del (.uy)")
            'Exit Sub
            'End If
            ButtonSeleccionarFicha.Focus()
        End If
    End Sub

    Private Sub ButtonSeleccionarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionarFicha.Click
        Dim cliente As Long = TextIdCliente.Text.Trim
        Dim v As New FormListarFichas(cliente)
        Dim ti As New dTipoInforme
        v.ShowDialog()
        If Not v.Ficha Is Nothing Then
            Dim s As dSolicitudAnalisis = v.Ficha
            TextFicha.Text = s.ID
            idficha = s.ID
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
            TextComentarios.Focus()
        End If
    End Sub
    Public Sub modificarRegistro()
        Dim idnet As Long = 0
        Dim sa_ As New dSolicitudAnalisis
        sa_.ID = idficha
        sa_ = sa_.buscar
        If Not sa_ Is Nothing Then
            idnet = sa_.IDPRODUCTOR
        End If

        If tipoinforme = 1 Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
            Dim cw_com As New dControlLecheroWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/control_lechero/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            cw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agua/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_com.FICHA = TextFicha.Text.Trim
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
        ElseIf tipoinforme = 5 Then 'SI EL TIPO DE INFORME ES DE PAL
            Dim palw_com As New dPalWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/pal/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            palw_com.FICHA = TextFicha.Text.Trim
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
        ElseIf tipoinforme = 6 Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
            Dim paw_com As New dParasitologiaWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/parasitologia/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            paw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/productos_subproductos/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            spw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/serologia/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            sw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            patw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/calidad_de_leche/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            cw_com.FICHA = TextFicha.Text.Trim
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
        ElseIf tipoinforme = 11 Then 'SI EL TIPO DE INFORME ES AMBIENTAL
            Dim aw_com As New dAmbientalWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/ambiental/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_com.FICHA = TextFicha.Text.Trim
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

        ElseIf tipoinforme = 12 Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
            Dim lw_com As New dLactometrosWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/lactometros_chequeos_maquina/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            lw_com.FICHA = TextFicha.Text.Trim
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

        ElseIf tipoinforme = 13 Then 'SI EL TIPO DE INFORME ES DE NUTRICIÓN
            Dim aw_com As New dAgroNutricionWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_nutricion/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_com.FICHA = TextFicha.Text.Trim
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
        ElseIf tipoinforme = 15 Then 'SI EL TIPO DE INFORME ES DE SUELOS
            Dim bw_com As New dBrucelosisLecheWeb_com
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/brucelosis_leche/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            bw_com.FICHA = TextFicha.Text.Trim
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
            Dim idproductorweb_com As Long = pw_com.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_com & "/otros_servicios/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            ow_com.FICHA = TextFicha.Text.Trim
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
        ElseIf tipoinforme = 21 Then
            carpeta = "calidad_de_leche"
            tipoinforme = 10
        End If

        Dim rg As New dResultado

        Dim fechaemi2 As String
        Dim fecha_emision2 As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")

        If TextComentarios.Text <> "" Then
            _comentarios = TextComentarios.Text
        End If

        rg.ficha = idficha
        rg.comentarios = _comentarios
        rg.idnet_usuario = idnet
        rg.abonado = True
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
    End Sub

    Public Sub modificarRegistro2()
        Dim idnet As Long = 0
        Dim sa_ As New dSolicitudAnalisis
        sa_.ID = idficha
        sa_ = sa_.buscar
        If Not sa_ Is Nothing Then
            idnet = sa_.IDPRODUCTOR
        End If

        If tipoinforme = 1 Then 'SI EL TIPO DE INFORME ES DE CONTROL LECHERO
            Dim cw_uy As New dControlLecheroWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/control_lechero/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            cw_uy.FICHA = TextFicha.Text.Trim
            cw_uy = cw_uy.buscar
            If Not cw_uy Is Nothing Then
                If comentarios <> "" Then
                    cw_uy.COMENTARIO = comentarios
                End If
                cw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                cw_uy.FECHA_EMISION = fechaemi
                cw_uy.PATH_EXCEL = path_excel
                cw_uy.PATH_PDF = path_pdf
                cw_uy.PATH_CSV = path_csv
                cw_uy.ID_ESTADO = id_estado
                If (cw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim cweb_uy As New dControlLecheroWeb_uy
                cweb_uy.ID_USUARIO = idproductorweb_uy

                If comentarios <> "" Then
                    cw_uy.COMENTARIO = comentarios
                End If
                cweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                cweb_uy.FECHA_CREADO = fechaemi
                cweb_uy.FECHA_EMISION = fechaemi
                cweb_uy.PATH_EXCEL = path_excel
                cweb_uy.PATH_PDF = path_pdf
                cweb_uy.PATH_CSV = path_csv
                cweb_uy.FICHA = idficha
                cweb_uy.ID_ESTADO = id_estado
                cweb_uy.ID_LIBRO = idficha
                If (cweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 3 Then 'SI EL TIPO DE INFORME ES DE AGUA
            Dim aw_uy As New dAguaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/agua/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_uy.FICHA = TextFicha.Text.Trim
            aw_uy = aw_uy.buscar
            If Not aw_uy Is Nothing Then
                If comentarios <> "" Then
                    aw_uy.COMENTARIO = comentarios
                End If
                aw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_uy.FECHA_EMISION = fechaemi
                aw_uy.PATH_EXCEL = path_excel
                aw_uy.PATH_PDF = path_pdf
                aw_uy.PATH_CSV = path_csv
                aw_uy.ID_ESTADO = id_estado
                If (aw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_uy As New dAguaWeb_uy
                aweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    aweb_uy.COMENTARIO = comentarios
                End If
                aweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_uy.FECHA_CREADO = fechaemi
                aweb_uy.FECHA_EMISION = fechaemi
                aweb_uy.PATH_EXCEL = path_excel
                aweb_uy.PATH_PDF = path_pdf
                aweb_uy.PATH_CSV = path_csv
                aweb_uy.FICHA = idficha
                aweb_uy.ID_ESTADO = id_estado
                aweb_uy.ID_LIBRO = idficha
                If (aweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 4 Then 'SI EL TIPO DE INFORME ES DE BACTERIOLOGÍA Y ANTIBIOGRAMA
            Dim aw_uy As New dAntibiogramaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/antibiograma/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_uy.FICHA = TextFicha.Text.Trim
            aw_uy = aw_uy.buscar
            If Not aw_uy Is Nothing Then
                If comentarios <> "" Then
                    aw_uy.COMENTARIO = comentarios
                End If
                aw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_uy.FECHA_EMISION = fechaemi
                aw_uy.PATH_EXCEL = path_excel
                aw_uy.PATH_PDF = path_pdf
                aw_uy.PATH_CSV = path_csv
                aw_uy.ID_ESTADO = id_estado
                If (aw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_uy As New dAntibiogramaWeb_uy
                aweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    aweb_uy.COMENTARIO = comentarios
                End If
                aweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_uy.FECHA_CREADO = fechaemi
                aweb_uy.FECHA_EMISION = fechaemi
                aweb_uy.PATH_EXCEL = path_excel
                aweb_uy.PATH_PDF = path_pdf
                aweb_uy.PATH_CSV = path_csv
                aweb_uy.FICHA = idficha
                aweb_uy.ID_ESTADO = id_estado
                aweb_uy.ID_LIBRO = idficha
                If (aweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 5 Then 'SI EL TIPO DE INFORME ES DE PAL
            Dim palw_uy As New dPalWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/pal/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            palw_uy.FICHA = TextFicha.Text.Trim
            palw_uy = palw_uy.buscar
            If Not palw_uy Is Nothing Then
                If comentarios <> "" Then
                    palw_uy.COMENTARIO = comentarios
                End If
                palw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                palw_uy.FECHA_EMISION = fechaemi
                palw_uy.PATH_EXCEL = path_excel
                palw_uy.PATH_PDF = path_pdf
                palw_uy.PATH_CSV = path_csv
                palw_uy.ID_ESTADO = id_estado
                If (palw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim palweb_uy As New dPalWeb_uy
                palweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    palweb_uy.COMENTARIO = comentarios
                End If
                palweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                palweb_uy.FECHA_CREADO = fechaemi
                palweb_uy.FECHA_EMISION = fechaemi
                palweb_uy.PATH_EXCEL = path_excel
                palweb_uy.PATH_PDF = path_pdf
                palweb_uy.PATH_CSV = path_csv
                palweb_uy.FICHA = idficha
                palweb_uy.ID_ESTADO = id_estado
                palweb_uy.ID_LIBRO = idficha
                If (palweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 6 Then 'SI EL TIPO DE INFORME ES DE PARASITOLOGÍA
            Dim paw_uy As New dParasitologiaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/parasitologia/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            paw_uy.FICHA = TextFicha.Text.Trim
            paw_uy = paw_uy.buscar
            If Not paw_uy Is Nothing Then
                If comentarios <> "" Then
                    paw_uy.COMENTARIO = comentarios
                End If
                paw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                paw_uy.FECHA_EMISION = fechaemi
                paw_uy.PATH_EXCEL = path_excel
                paw_uy.PATH_PDF = path_pdf
                paw_uy.PATH_CSV = path_csv
                paw_uy.ID_ESTADO = id_estado
                If (paw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim pweb_uy As New dParasitologiaWeb_uy
                pweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    pweb_uy.COMENTARIO = comentarios
                End If
                pweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                pweb_uy.FECHA_CREADO = fechaemi
                pweb_uy.FECHA_EMISION = fechaemi
                pweb_uy.PATH_EXCEL = path_excel
                pweb_uy.PATH_PDF = path_pdf
                pweb_uy.PATH_CSV = path_csv
                pweb_uy.FICHA = idficha
                pweb_uy.ID_ESTADO = id_estado
                pweb_uy.ID_LIBRO = idficha
                If (pweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 7 Then 'SI EL TIPO DE INFORME ES DE ALIMENTOS E INDICADORES
            Dim spw_uy As New dSubproductosWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/productos_subproductos/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            spw_uy.FICHA = TextFicha.Text.Trim
            spw_uy = spw_uy.buscar
            If Not spw_uy Is Nothing Then
                If comentarios <> "" Then
                    spw_uy.COMENTARIO = comentarios
                End If
                spw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                spw_uy.FECHA_EMISION = fechaemi
                spw_uy.PATH_EXCEL = path_excel
                spw_uy.PATH_PDF = path_pdf
                spw_uy.PATH_CSV = path_csv
                spw_uy.ID_ESTADO = id_estado
                If (spw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim spweb_uy As New dSubproductosWeb_uy
                spweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    spweb_uy.COMENTARIO = comentarios
                End If
                spweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                spweb_uy.FECHA_CREADO = fechaemi
                spweb_uy.FECHA_EMISION = fechaemi
                spweb_uy.PATH_EXCEL = path_excel
                spweb_uy.PATH_PDF = path_pdf
                spweb_uy.PATH_CSV = path_csv
                spweb_uy.FICHA = idficha
                spweb_uy.ID_ESTADO = id_estado
                spweb_uy.ID_LIBRO = idficha
                If (spweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 8 Then 'SI EL TIPO DE INFORME ES DE SEROLOGÍA
            Dim sw_uy As New dSerologiaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/serologia/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            sw_uy.FICHA = TextFicha.Text.Trim
            sw_uy = sw_uy.buscar
            If Not sw_uy Is Nothing Then
                If comentarios <> "" Then
                    sw_uy.COMENTARIO = comentarios
                End If
                sw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                sw_uy.FECHA_EMISION = fechaemi
                sw_uy.PATH_EXCEL = path_excel
                sw_uy.PATH_PDF = path_pdf
                sw_uy.PATH_CSV = path_csv
                sw_uy.ID_ESTADO = id_estado
                If (sw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim sweb_uy As New dSerologiaWeb_uy
                sweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    sweb_uy.COMENTARIO = comentarios
                End If
                sweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                sweb_uy.FECHA_CREADO = fechaemi
                sweb_uy.FECHA_EMISION = fechaemi
                sweb_uy.PATH_EXCEL = path_excel
                sweb_uy.PATH_PDF = path_pdf
                sweb_uy.PATH_CSV = path_csv
                sweb_uy.FICHA = idficha
                sweb_uy.ID_ESTADO = id_estado
                sweb_uy.ID_LIBRO = idficha
                If (sweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 9 Then 'SI EL TIPO DE INFORME ES DE PATOLOGÍA - TOXICOLOGÍA
            Dim patw_uy As New dPatologiaWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/patologia/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            patw_uy.FICHA = TextFicha.Text.Trim
            patw_uy = patw_uy.buscar
            If Not patw_uy Is Nothing Then
                If comentarios <> "" Then
                    patw_uy.COMENTARIO = comentarios
                End If
                patw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                patw_uy.FECHA_EMISION = fechaemi
                patw_uy.PATH_EXCEL = path_excel
                patw_uy.PATH_PDF = path_pdf
                patw_uy.PATH_CSV = path_csv
                patw_uy.ID_ESTADO = id_estado
                If (patw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim patoweb_uy As New dPatologiaWeb_uy
                patoweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    patoweb_uy.COMENTARIO = comentarios
                End If
                patoweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                patoweb_uy.FECHA_CREADO = fechaemi
                patoweb_uy.FECHA_EMISION = fechaemi
                patoweb_uy.PATH_EXCEL = path_excel
                patoweb_uy.PATH_PDF = path_pdf
                patoweb_uy.PATH_CSV = path_csv
                patoweb_uy.FICHA = idficha
                patoweb_uy.ID_ESTADO = id_estado
                patoweb_uy.ID_LIBRO = idficha
                If (patoweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 10 Then 'SI EL TIPO DE INFORME ES DE CALIDAD
            Dim cw_uy As New dCalidadWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/calidad_de_leche/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            cw_uy.FICHA = TextFicha.Text.Trim
            cw_uy = cw_uy.buscar
            If Not cw_uy Is Nothing Then
                If comentarios <> "" Then
                    cw_uy.COMENTARIO = comentarios
                End If
                cw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                cw_uy.FECHA_EMISION = fechaemi
                cw_uy.PATH_EXCEL = path_excel
                cw_uy.PATH_PDF = path_pdf
                cw_uy.PATH_CSV = path_csv
                cw_uy.ID_ESTADO = id_estado
                If (cw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim calweb_uy As New dCalidadWeb_uy
                calweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    calweb_uy.COMENTARIO = comentarios
                End If
                calweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                calweb_uy.FECHA_CREADO = fechaemi
                calweb_uy.FECHA_EMISION = fechaemi
                calweb_uy.PATH_EXCEL = path_excel
                calweb_uy.PATH_PDF = path_pdf
                calweb_uy.PATH_CSV = path_csv
                calweb_uy.FICHA = idficha
                calweb_uy.ID_ESTADO = id_estado
                calweb_uy.ID_LIBRO = idficha
                If (calweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
        ElseIf tipoinforme = 11 Then 'SI EL TIPO DE INFORME ES AMBIENTAL
            Dim aw_uy As New dAmbientalWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/ambiental/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_uy.FICHA = TextFicha.Text.Trim
            aw_uy = aw_uy.buscar
            If Not aw_uy Is Nothing Then
                If comentarios <> "" Then
                    aw_uy.COMENTARIO = comentarios
                End If
                aw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_uy.FECHA_EMISION = fechaemi
                aw_uy.PATH_EXCEL = path_excel
                aw_uy.PATH_PDF = path_pdf
                aw_uy.PATH_CSV = path_csv
                aw_uy.ID_ESTADO = id_estado
                If (aw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_uy As New dAmbientalWeb_uy
                aweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    aweb_uy.COMENTARIO = comentarios
                End If
                aweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_uy.FECHA_CREADO = fechaemi
                aweb_uy.FECHA_EMISION = fechaemi
                aweb_uy.PATH_EXCEL = path_excel
                aweb_uy.PATH_PDF = path_pdf
                aweb_uy.PATH_CSV = path_csv
                aweb_uy.FICHA = idficha
                aweb_uy.ID_ESTADO = id_estado
                aweb_uy.ID_LIBRO = idficha
                If (aweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 12 Then 'SI EL TIPO DE INFORME ES DE LACTÓMETROS
            Dim lw_uy As New dLactometrosWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/lactometros_chequeos_maquina/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            lw_uy.FICHA = TextFicha.Text.Trim
            lw_uy = lw_uy.buscar
            If Not lw_uy Is Nothing Then
                If comentarios <> "" Then
                    lw_uy.COMENTARIO = comentarios
                End If
                lw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                lw_uy.FECHA_EMISION = fechaemi
                lw_uy.PATH_EXCEL = path_excel
                lw_uy.PATH_PDF = path_pdf
                lw_uy.PATH_CSV = path_csv
                lw_uy.ID_ESTADO = id_estado
                If (lw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim lactweb_uy As New dLactometrosWeb_uy
                lactweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    lactweb_uy.COMENTARIO = comentarios
                End If
                lactweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                lactweb_uy.FECHA_CREADO = fechaemi
                lactweb_uy.FECHA_EMISION = fechaemi
                lactweb_uy.PATH_EXCEL = path_excel
                lactweb_uy.PATH_PDF = path_pdf
                lactweb_uy.PATH_CSV = path_csv
                lactweb_uy.FICHA = idficha
                lactweb_uy.ID_ESTADO = id_estado
                lactweb_uy.ID_LIBRO = idficha
                If (lactweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 13 Then 'SI EL TIPO DE INFORME ES DE NUTRICIÓN
            Dim aw_uy As New dAgroNutricionWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/agro_nutricion/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            aw_uy.FICHA = TextFicha.Text.Trim
            aw_uy = aw_uy.buscar
            If Not aw_uy Is Nothing Then
                If comentarios <> "" Then
                    aw_uy.COMENTARIO = comentarios
                End If
                aw_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aw_uy.FECHA_EMISION = fechaemi
                aw_uy.PATH_EXCEL = path_excel
                aw_uy.PATH_PDF = path_pdf
                aw_uy.PATH_CSV = path_csv
                aw_uy.ID_ESTADO = id_estado
                If (aw_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim aweb_uy As New dAgroNutricionWeb_uy
                aweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    aweb_uy.COMENTARIO = comentarios
                End If
                aweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                aweb_uy.FECHA_CREADO = fechaemi
                aweb_uy.FECHA_EMISION = fechaemi
                aweb_uy.PATH_EXCEL = path_excel
                aweb_uy.PATH_PDF = path_pdf
                aweb_uy.PATH_CSV = path_csv
                aweb_uy.FICHA = idficha
                aweb_uy.ID_ESTADO = id_estado
                aweb_uy.ID_LIBRO = idficha
                If (aweb_uy.guardar(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If

        ElseIf tipoinforme = 99 Then 'SI EL TIPO DE INFORME ES DE OTROS SERVICIOS
            Dim ow_uy As New dOtrosServiciosWeb_uy
            Dim pw_uy As New dProductorWeb_uy
            pw_uy.USUARIO = productorweb_uy
            pw_uy = pw_uy.buscar
            Dim idproductorweb_uy As Long = pw_uy.ID
            Dim comentarios As String = ""
            If TextComentarios.Text.Length > 0 Then
                comentarios = TextComentarios.Text.Trim
            End If
            Dim abonado As Integer = 0
            If RadioAbonado.Checked = True Then
                abonado = 2
            ElseIf RadioNoAbonadocv.Checked = True Then
                abonado = 1
            ElseIf RadioNoAbonadosv.Checked = True Then
                abonado = 0
            End If
            Dim fecha_emision As Date = DateFecha.Value.ToString("yyyy-MM-dd")
            Dim path_excel As String = ""
            If CheckXls.Checked = True Then
                path_excel = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".xls"
            End If
            Dim path_pdf As String = ""
            If CheckPdf.Checked = True Then
                path_pdf = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".pdf"
            End If
            Dim path_csv As String = ""
            If CheckTxt.Checked = True Then
                path_csv = "/home/colaveco/public_html/gestor/data_file/" & idproductorweb_uy & "/otros_servicios/" & idficha & ".txt"
            End If
            Dim id_estado As Integer = 3

            ow_uy.FICHA = TextFicha.Text.Trim
            ow_uy = ow_uy.buscar
            If Not ow_uy Is Nothing Then
                If comentarios <> "" Then
                    ow_uy.COMENTARIO = comentarios
                End If
                ow_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                ow_uy.FECHA_EMISION = fechaemi
                ow_uy.PATH_EXCEL = path_excel
                ow_uy.PATH_PDF = path_pdf
                ow_uy.PATH_CSV = path_csv
                ow_uy.ID_ESTADO = id_estado
                If (ow_uy.modificar2(Usuario)) Then
                    'MsgBox("Solicitud guardada", MsgBoxStyle.Information, "Atención")
                    'limpiar()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim oweb_uy As New dOtrosServiciosWeb_uy
                oweb_uy.ID_USUARIO = idproductorweb_uy
                If comentarios <> "" Then
                    oweb_uy.COMENTARIO = comentarios
                End If
                oweb_uy.ABONADO = abonado
                Dim fechaemi As String
                fechaemi = Format(fecha_emision, "yyyy-MM-dd")
                oweb_uy.FECHA_CREADO = fechaemi
                oweb_uy.FECHA_EMISION = fechaemi
                oweb_uy.PATH_EXCEL = path_excel
                oweb_uy.PATH_PDF = path_pdf
                oweb_uy.PATH_CSV = path_csv
                oweb_uy.FICHA = idficha
                oweb_uy.ID_ESTADO = id_estado
                oweb_uy.ID_LIBRO = idficha
                If (oweb_uy.guardar(Usuario)) Then
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
        ElseIf tipoinforme = 21 Then
            carpeta = "calidad_de_leche"
            tipoinforme = 10
        End If

        Dim rg As New dResultado

        Dim fechaemi2 As String
        Dim fecha_emision2 As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")

        If TextComentarios.Text <> "" Then
            _comentarios = TextComentarios.Text
        End If

        rg.ficha = idficha
        rg.comentarios = _comentarios
        rg.idnet_usuario = idnet
        rg.abonado = True
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
    Private Sub ButtonEnviarCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviarCopia.Click
        Dim v As New FormBuscarTecnico
        v.ShowDialog()
        Dim mailproductor As String = ""
        'copiaproductorweb_uy = ""

        If Not v.Productor Is Nothing Then
            Dim pro As dProductorWeb_com = v.Productor
            'TextIdCliente.Text = pro.ID
            'TextEnviarCopia.Text = pro.NOMBRE
            'mailproductor = pro.ENVIAR_EMAIL
            TextEnviarCopia.Text = pro.ENVIAR_EMAIL
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        creaDirectorio()
    End Sub
    Private Sub enviomail()

        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        nficha = TextFicha.Text.Trim
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
        texto = "Nos es grato comunicarle que el informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se encuentra disponible en la web de Colaveco." & vbCrLf _
            & "Para poder acceder a los resultados debe ir a https://colavecoresults.ddns.net:8080/LabColJavaEnvironment/com.labcol.colavecologin y digitar su usuario y contraseña." & vbCrLf _
            & "Sino cuenta con usuario y contraseña, favor solicitarla en administración al correo electrónico colaveco@gmail.com o al teléfono 4554 5311." & vbCrLf _
            & "Agradecemos su confianza y quedamos a sus órdenes." & vbCrLf & vbCrLf _
            & "Sin mas, saluda muy atte." & vbCrLf & vbCrLf _
            & "Administración - COLAVECO"
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
            _Message.Subject = "Informe" & " Nº " & nficha & " - Colaveco"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""

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
        nficha = ""

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
        Dim texto As String = celular
        Dim cantcaracteres As Integer = Len(texto)
        If celular <> "" Then
            largotexto = celular.Length
        End If
        nficha = TextFicha.Text.Trim

        Dim posicion As Integer
        Dim posicion1 As Integer
        Dim posicion2 As Integer
        posicion = InStr(celular, ",")
        If posicion > 0 Then
            posicion1 = posicion - 1
            posicion2 = posicion + 1
            cel1 = Mid(celular, 1, posicion1)
            cel2 = Mid(celular, posicion2, largotexto)

            If Mid(cel1, 1, 2) = "09" Then
                celular1 = cel1.Remove(0, 2)
            Else
                celular1 = cel1
            End If

            email = celular1
            num1 = Mid(celular1, 1, 1)

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
            If Mid(cel2, 1, 2) = "09" Then
                celular2 = cel2.Remove(0, 2)
            Else
                celular2 = cel2
            End If

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

            'Dim celular As String = ""

            'celular = TextCelular1.Text.Trim
            nficha = TextFicha.Text.Trim
            If Mid(celular, 1, 2) = "09" Then
                celular2 = celular.Remove(0, 2)
            Else
                celular2 = celular
            End If

            email = celular2
            num1 = Mid(celular2, 1, 1)

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

        Dim sa As New dSolicitudAnalisis
        Dim p As New dCliente
        Dim ti As New dTipoInforme
        Dim nombre_productor As String = ""
        Dim tipo_analisis As String = ""
        nficha = TextFicha.Text.Trim
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

        If sms <> "" Then

            'CONFIGURACIÓN DEL STMP 
            ' Llamamos al método buscar para obtener el objeto Credenciales
            Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

            _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
            _SMTP.Host = objetoCredenciales.CredencialesHost
            _SMTP.Port = 25
            _SMTP.EnableSsl = False

            ' CONFIGURACION DEL MENSAJE 
            _Message.[To].Add(sms)
            _Message.[To].Add("envios@colaveco.com.uy")
            'Cuenta de Correo al que se le quiere enviar el e-mail 
            _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
            'Quien lo envía 
            _Message.Subject = "El informe Nº " & " " & nficha & " - " & tipo_analisis & " (" & nombre_productor & ")," & "se ha subido a la web. Gracias."
            '_Message.Subject = "El informe número " & " " & nficha & ", " & "se ha subido a la web. Gracias."
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio https://colavecoresults.ddns.net:8080/LabColJavaEnvironment/com.labcol.colavecologin"
            '_Message.Body = "Colaveco ha publicado un informe. Ingrese al sitio https://colavecoresults.ddns.net:8080/LabColJavaEnvironment/com.labcol.colavecologin"
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
                'MessageBox.Show("Mensaje enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
        texto = ""

    End Sub
    Private Sub enviartxtxcorreo()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        Dim archivo As String = ""
        Dim fichero As String = ""
        archivo = TextFicha.Text.Trim
        fichero = "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".txt" 'archivo que se quiere adjuntar ‘
        Dim contador As Integer = 0

        'CONFIGURACIÓN DEL STMP 
        ' Llamamos al método buscar para obtener el objeto Credenciales
        Dim objetoCredenciales As dCredenciales = dCredenciales.buscar("notificaciones")

        _SMTP.Credentials = New System.Net.NetworkCredential(objetoCredenciales.CredencialesUsuario, objetoCredenciales.CredencialesPassword)
        _SMTP.Host = objetoCredenciales.CredencialesHost
        _SMTP.Port = 25
        _SMTP.EnableSsl = False

        ' CONFIGURACION DEL MENSAJE 
        _Message.[To].Add("martin.bentancor@ecolat.com,rafael.bidegain@ecolat.com")
        _Message.[To].Add("envios@colaveco.com.uy")
        'Cuenta de Correo al que se le quiere enviar el e-mail 
        _Message.From = New System.Net.Mail.MailAddress("notificaciones@colaveco.com.uy", "COLAVECO", System.Text.Encoding.UTF8)
        'Quien lo envía 
        _Message.Subject = "Informe TXT"
        'Sujeto del e-mail 
        _Message.SubjectEncoding = System.Text.Encoding.UTF8
        'Codificacion 
        _Message.Body = ""
        'contenido del mail 
        _Message.BodyEncoding = System.Text.Encoding.UTF8 '
        _Message.Priority = System.Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False


        ' ADICION DE DATOS ADJUNTOS ‘
        Dim _File As String = fichero ' My.Application.Info.DirectoryPath & "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".txt" 'archivo que se quiere adjuntar ‘
        Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
        _Message.Attachments.Add(_Attachment) 'ENVIO 
        Try
            '_SMTP.Send(_Message)
            'MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
        End Try

        _SMTP.Send(_Message)
        'MessageBox.Show("Pedidos enviados!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Public Sub crea_brucelosis_leche_com()
        Dim carpeta As Long = idproductorweb_com
        Dim pweb_com As New dProductorWeb_com
        Dim user As String = "colaveco"
        Dim pass As String = "Fmbh23052305"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
        Dim pass As String = "Fmbh23052305"

        Dim peticionFTP As FtpWebRequest
        'Dim lista As New ArrayList
        'lista = pweb_com.listarxid
        'If Not lista Is Nothing Then
        'If lista.Count > 0 Then
        'carpeta = pweb_com.ID
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
    Private Sub enviar_correo_brucelosisenleche()
        Dim result = MessageBox.Show("Desea enviar un correo electrónico MGAP?", "Atención!", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Exit Sub
        ElseIf result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            enviaremail()
            enviaremail2()
        End If
    End Sub
    Private Sub enviaremail()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = TextFicha.Text.Trim
        email = "unepi@mgap.gub.uy"

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
            _Message.Subject = "Colaveco - Brucelosis en leche"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Adjuntamos informe de Brucelsois en leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\Brucelosis en leche\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""

    End Sub
    Private Sub enviaremail2()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = TextFicha.Text.Trim
        email = "decano@fvet.edu.uy"

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
            _Message.Subject = "Colaveco - Brucelosis en leche"
            'Sujeto del e-mail 
            _Message.SubjectEncoding = System.Text.Encoding.UTF8
            'Codificacion 
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Adjuntamos informe de Brucelsois en leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\Brucelosis en leche\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""

    End Sub
    Private Sub enviar_correo_AFB()
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient

        Dim email As String = ""
        Dim destinatario As String = ""
        Dim archivo As String = ""
        archivo = TextFicha.Text.Trim
        email = "jgarello@lasibila.com.ar, pdemaio@lasibila.com.ar, amrodriguez@afb.com.uy, hvilche@afb.com.uy, lab.fisicoquimico@afb.com.uy, rchatel@afb.com.uy"

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
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Adjuntamos informe de Calidad de leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            'Dim _File As String = "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _File As String = "\\ROBOT\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
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
        email = "jgarello@lasibila.com.ar, pdemaio@lasibila.com.ar, amrodriguez@afb.com.uy, hvilche@afb.com.uy, lab.fisicoquimico@afb.com.uy, rchatel@afb.com.uy"

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
            '_Message.Body = "Se han enviado las siguientes cajas:" & " " & ecaja1 & ", " & "por" & " " & eagencia & " " & "envío nº" & " " & eremito & ""
            _Message.Body = "Adjuntamos informe de Calidad de leche."
            'contenido del mail 
            _Message.BodyEncoding = System.Text.Encoding.UTF8 '
            _Message.Priority = System.Net.Mail.MailPriority.Normal
            _Message.IsBodyHtml = False
            ' ADICION DE DATOS ADJUNTOS ‘
            Dim _File As String = "\\192.168.1.10\E\NET\CALIDAD\" & archivo & ".txt" 'archivo que se quiere adjuntar ‘
            'Dim _File As String = "\\ROBOT\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("TXT enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Net.Mail.SmtpException ' MessageBox.Show(ex.ToString) 
            End Try
        End If
        email = ""
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class