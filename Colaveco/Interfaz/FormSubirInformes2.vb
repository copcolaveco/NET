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
    End Sub
    Private Sub ButtonSubirInforme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirInforme.Click
        'subirinforme()
        If tipoinforme = 1 Then
            subir_control()
        ElseIf tipoinforme = 3 Then
            subir_agua()
        ElseIf tipoinforme = 4 Then
            subir_atb()
        ElseIf tipoinforme = 6 Then
            subir_parasitologia()
        ElseIf tipoinforme = 7 Then
            subir_alimentos()
        ElseIf tipoinforme = 8 Then
            subir_serologia()
        ElseIf tipoinforme = 9 Then
            subir_patologia()
        ElseIf tipoinforme = 10 Then
            subir_calidad()
        ElseIf tipoinforme = 11 Then
            subir_ambiental()
        ElseIf tipoinforme = 13 Then
            subir_nutricion()
        ElseIf tipoinforme = 14 Or tipoinforme = 19 Then
            subir_suelos()
        ElseIf tipoinforme = 15 Then
            subir_brucelosis()
        ElseIf tipoinforme = 16 Then
            subir_efluentes()
        ElseIf tipoinforme = 17 Then
            subir_bacteriologia()
        ElseIf tipoinforme = 18 Then
            subir_bacteriologia_clinica()
        ElseIf tipoinforme = 19 Then
            subir_foliares()
        ElseIf tipoinforme = 20 Then
            subir_toxicologia()
        ElseIf tipoinforme = 21 Then
            subir_mineralesenleche()
        End If
    End Sub
    Private Sub subir_control()
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
        '****************************************************************************************
        'JUNTAR LOS 2 PDF ***************************************************************************
        ' Creamos una lista de archivos para concatenar
        Dim Listax As New List(Of String)
        ' Identificamos los documentos que queremos unir
        Dim sFile1 As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\" & ficha & ".pdf"
        Dim sFile2 As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\x" & ficha & ".pdf"
        ' Los añadimos a la lista
        Listax.Add(sFile1)
        Listax.Add(sFile2)
        ' Nombre del documento resultante
        Dim sFileJoin As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".pdf"
        Dim Doc As New Document()
        Try
            Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim copy As New PdfCopy(Doc, fs)
            Doc.Open()
            Dim Rd As PdfReader
            Dim n As Integer 'Número de páginas de cada pdf
            For Each file In Listax
                Rd = New PdfReader(file)
                n = Rd.NumberOfPages
                Dim page As Integer = 0
                Do While page < n
                    page += 1
                    copy.AddPage(copy.GetImportedPage(Rd, page))
                Loop
                copy.FreeReader(Rd)
                Rd.Close()
            Next
        Catch ex As Exception
            'MsgBox(ex.Message, vbExclamation, "Error uniendo los pdf")
        Finally
            ' Cerramos el documento
            Doc.Close()
        End Try
        '********************************************************************************************

        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".xls"
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
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".pdf"
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
        Dim sArchivoOrigen3 As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".txt"
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
        lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
        If Not lista Is Nothing Then
            If lista.Count < 6 Then
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            'Dim prod As Long = sol.IDPRODUCTOR
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim pw_com As New dProductorWeb_com
            pw_com.USUARIO = productorweb_com
            pw_com = pw_com.buscar

            Dim prod As Long = sol.IDPRODUCTOR
            p.ID = sol.IDPRODUCTOR
            p = p.buscar

            If Not pw_com Is Nothing Then
                email = RTrim(pw_com.ENVIAR_EMAIL)
            ElseIf Not p.NOT_EMAIL_ANALISIS1 Is Nothing Then
                If p.NOT_EMAIL_ANALISIS1 <> "" Then
                    email = RTrim(p.NOT_EMAIL_ANALISIS1)
                ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                    email = RTrim(p.NOT_EMAIL_ANALISIS2)
                ElseIf p.EMAIL <> "" Then
                    email = RTrim(p.EMAIL)
                End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()

    End Sub
    Private Sub subir_agua()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\AGUA\" & ficha & ".xls"
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
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\AGUA\" & ficha & ".pdf"
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_atb()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_parasitologia()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\PARASITOLOGIA\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\PARASITOLOGIA\" & ficha & ".pdf"
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

        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_alimentos()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\ALIMENTOS\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\ALIMENTOS\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_serologia()
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
        '****************************************************************************************

        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_patologia()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\PATOLOGIA\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\PATOLOGIA\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_calidad()
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
        Dim marcarPago As Integer = 0
        marcarPago = abonado
        If TextComentarios.Text <> "" Then
            comentario = TextComentarios.Text
        End If
        If TextEnviarCopia.Text <> "" Then
            copia = TextEnviarCopia.Text
        End If
        Dim cliente As Integer = 0
        cliente = TextIdCliente.Text.Trim

        'ABRE TXT PARA CONTROL ****************************************************************************************************************
        If cliente = 6299 Then 'Or cliente = 2705 Then
            'If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
            Dim arch As String = ""
            arch = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & ".txt"
            If File.Exists(arch) Then
                System.Diagnostics.Process.Start(arch)
            End If
            'End If
            Dim result = MessageBox.Show("Desea enviar un correo electrónico con el archivo txt?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                '*** MOVER ARCHIVO XLS ***********************************************************************
                Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".xls"
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
                Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".pdf"
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
                '*****************************************************************************************
                If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
                    If cliente = 6299 Then
                        enviar_correo_AFB()
                        enviar_correo_AFB2()
                    ElseIf cliente = 2705 Then
                        enviar_correo_IS()
                    End If
                End If
            End If
            'enviar_correo_AFB()
            'enviar_correo_AFB2()
        Else
            '*** MOVER ARCHIVO XLS ***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".xls"
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
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".pdf"
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
            '*****************************************************************************************
        End If

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
        lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
        If Not lista Is Nothing Then
            If lista.Count < 6 Then
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        '**Marcar pago en SA***
        Dim solicitud As New dSolicitudAnalisis
        solicitud.ID = ficha
        solicitud = solicitud.buscar
        If marcarPago = 0 Then
            solicitud.PAGO = 0
            solicitud.marcarpago2(Usuario)
        End If
        If marcarPago = 1 Then
            solicitud.PAGO = 1
            solicitud.marcarpago2(Usuario)
        End If
        If marcarPago = 2 Then
            solicitud.PAGO = 2
            solicitud.marcarpago2(Usuario)
        End If
        limpiar()
        marcarxdefecto()
    End Sub

    Private Sub subir_mineralesenleche()
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
        Dim cliente As Integer = 0
        cliente = TextIdCliente.Text.Trim

        'ABRE TXT PARA CONTROL ****************************************************************************************************************
        If cliente = 6299 Then 'Or cliente = 2705 Then
            'If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
            Dim arch As String = ""
            arch = "\\192.168.1.10\E\NET\CALIDAD\" & ficha & ".txt"
            If File.Exists(arch) Then
                System.Diagnostics.Process.Start(arch)
            End If
            'End If
            Dim result = MessageBox.Show("Desea enviar un correo electrónico con el archivo txt?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                '*** MOVER ARCHIVO XLS ***********************************************************************
                Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".xls"
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
                Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".pdf"
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
                '*****************************************************************************************
                If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
                    If cliente = 6299 Then
                        enviar_correo_AFB()
                        enviar_correo_AFB2()
                    ElseIf cliente = 2705 Then
                        enviar_correo_IS()
                    End If
                End If
            End If
            'enviar_correo_AFB()
            'enviar_correo_AFB2()
        Else
            '*** MOVER ARCHIVO XLS ***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".xls"
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
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".pdf"
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
            '*****************************************************************************************
        End If

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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_ambiental()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\AMBIENTAL\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\AMBIENTAL\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_nutricion()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\NUTRICION\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\NUTRICION\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_suelos()
        Dim ficha As Long = 0
        Dim abonado As Integer = 0
        Dim comentario As String = ""
        Dim copia As String = ""
        Dim AnexosPHCreados = False
        Dim AnexosFerCreados = False

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

        If isAnexo Then
            '****************************************************************************************
            'JUNTAR LOS 2 PDF ***************************************************************************
            ' Creamos una lista de archivos para concatenar
            Dim Listax As New List(Of String)
            ' Identificamos los documentos que queremos unir
            Dim sFile1 As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".pdf"
            Dim sFile2 As String = "\\ROBOT\PREINFORMES\SUELOS\anexo" & ficha & ".pdf"
            Dim sFile3 As String = "\\ROBOT\PREINFORMES\SUELOS\anexoPH" & ficha & ".pdf"
            ' Los añadimos a la lista
            Listax.Add(sFile1)
            Listax.Add(sFile2)
            AnexosFerCreados = True
            'Si es con anexo de PH
            If isAnexoPH Then
                Listax.Add(sFile3)
                AnexosPHCreados = True
            End If

            ' Nombre del documento resultante
            Dim sFileJoin As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim Doc As New Document()
            Try
                Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim copy As New PdfCopy(Doc, fs)
                Doc.Open()
                Dim Rd As PdfReader
                Dim n As Integer 'Número de páginas de cada pdf
                For Each file In Listax
                    Rd = New PdfReader(file)
                    n = Rd.NumberOfPages
                    Dim page As Integer = 0
                    Do While page < n
                        page += 1
                        copy.AddPage(copy.GetImportedPage(Rd, page))
                    Loop
                    copy.FreeReader(Rd)
                    Rd.Close()
                Next
            Catch ex As Exception
                MsgBox(ex.Message, vbExclamation, "Error uniendo los pdf, si el informe no lleva ANEXO por conversiòn de fertilizante proceguir.")
            Finally
                ' Cerramos el documento
                Doc.Close()
            End Try
            '********************************************************************************************
        End If

        If isAnexoPH And AnexosPHCreados = False Then

            '****************************************************************************************
            'JUNTAR LOS 2 PDF ***************************************************************************
            ' Creamos una lista de archivos para concatenar
            Dim Listax As New List(Of String)
            ' Identificamos los documentos que queremos unir
            Dim sFile1 As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".pdf"
            Dim sFile3 As String = "\\ROBOT\PREINFORMES\SUELOS\anexoPH" & ficha & ".pdf"
            ' Los añadimos a la lista
            Listax.Add(sFile1)
            'Si es con anexo de PH
            Listax.Add(sFile3)

            ' Nombre del documento resultante
            Dim sFileJoin As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim Doc As New Document()
            Try
                Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim copy As New PdfCopy(Doc, fs)
                Doc.Open()
                Dim Rd As PdfReader
                Dim n As Integer 'Número de páginas de cada pdf
                For Each file In Listax
                    Doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate())
                    Rd = New PdfReader(file)
                    n = Rd.NumberOfPages
                    Dim page As Integer = 0
                    Do While page < n
                        page += 1
                        copy.AddPage(copy.GetImportedPage(Rd, page))
                    Loop
                    copy.FreeReader(Rd)
                    Rd.Close()
                Next
            Catch ex As Exception
                MsgBox(ex.Message, vbExclamation, "Error uniendo los pdf, si el informe no lleva ANEXO por conversiòn de fertilizante proceguir.")
            Finally
                ' Cerramos el documento
                Doc.Close()
            End Try
            '********************************************************************************************
        End If

        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        'If isAnexo = False Then
        '    '*** MOVER ARCHIVO PDF***********************************************************************
        '    Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".pdf"
        '    Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        '    Try
        '        ' Mover el fichero.si existe lo sobreescribe  
        '        My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
        '        'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
        '        ' errores  
        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        '    End Try
        '    '***********************************
        'End If
        
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
        lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_brucelosis()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_efluentes()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\EFLUENTES\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\EFLUENTES\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        Dim tipo As Integer = 16
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_bacteriologia()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_bacteriologia_clinica()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_foliares()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        Dim tipo As Integer = 19
        fechad = Format(fechadesde, "yyyy-MM-dd")
        fechah = Format(fechahasta, "yyyy-MM-dd")
        Dim ci As New dControlInformesSuelos
        Dim lista As New ArrayList
        lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
        If Not lista Is Nothing Then
            If lista.Count < 6 Then
                Dim cisuelos As New dControlInformesSuelos
                cisuelos.FECHACONTROL = fechad
                cisuelos.FICHA = ficha
                cisuelos.FECHA = fechad
                cisuelos.TIPO = 19
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
            cisuelos.TIPO = 19
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subir_toxicologia()
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
        '****************************************************************************************
        '*** MOVER ARCHIVO XLS***********************************************************************
        Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\TOXICOLOGIA\" & ficha & ".xls"
        Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
            'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
            ' errores  
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
        '*** MOVER ARCHIVO PDF***********************************************************************
        Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\TOXICOLOGIA\" & ficha & ".pdf"
        Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
        Try
            ' Mover el fichero.si existe lo sobreescribe  
            My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        '****************************************************************************************
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
    End Sub
    Private Sub subirinforme()
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
            '*** MOVER ARCHIVO XLS ***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".xls"
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
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CALIDAD\" & ficha & ".pdf"
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
            lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
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
                If RadioAbonado.Checked = True Or RadioNoAbonadocv.Checked = True Then
                    enviar_correo_AFB()
                    enviar_correo_AFB2()

                End If
            End If
            '*****************************************************************************
        ElseIf TextTipoAnalisis.Text = "Control Lechero" Then
            'JUNTAR LOS 2 PDF ***************************************************************************
            ' Creamos una lista de archivos para concatenar
            Dim Listax As New List(Of String)
            ' Identificamos los documentos que queremos unir
            Dim sFile1 As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\" & ficha & ".pdf"
            Dim sFile2 As String = "\\192.168.1.10\E\NET\CONTROL_LECHERO\Graficas\x" & ficha & ".pdf"
            ' Los añadimos a la lista
            Listax.Add(sFile1)
            Listax.Add(sFile2)
            ' Nombre del documento resultante
            Dim sFileJoin As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".pdf"
            Dim Doc As New Document()
            Try
                Dim fs As New FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None)
                Dim copy As New PdfCopy(Doc, fs)
                Doc.Open()
                Dim Rd As PdfReader
                Dim n As Integer 'Número de páginas de cada pdf
                For Each file In Listax
                    Rd = New PdfReader(file)
                    n = Rd.NumberOfPages
                    Dim page As Integer = 0
                    Do While page < n
                        page += 1
                        copy.AddPage(copy.GetImportedPage(Rd, page))
                    Loop
                    copy.FreeReader(Rd)
                    Rd.Close()
                Next
            Catch ex As Exception
                'MsgBox(ex.Message, vbExclamation, "Error uniendo los pdf")
            Finally
                ' Cerramos el documento
                Doc.Close()
            End Try
            '********************************************************************************************

            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".xls"
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
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".pdf"
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
            Dim sArchivoOrigen3 As String = "\\ROBOT\PREINFORMES\CONTROL\" & ficha & ".txt"
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
            lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
            If Not lista Is Nothing Then
                If lista.Count < 6 Then
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
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\AGUA\" & ficha & ".xls"
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
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\AGUA\" & ficha & ".pdf"
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
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\ALIMENTOS\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\ALIMENTOS\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        ElseIf TextTipoAnalisis.Text = "Aislamiento y Antibiograma" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\ANTIBIOGRAMA\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        ElseIf TextTipoAnalisis.Text = "Bacteriología de tanque" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        ElseIf TextTipoAnalisis.Text = "Bacteriología clínica aeróbica" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\BACTERIOLOGIA\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
        ElseIf TextTipoAnalisis.Text = "Ambiental" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\AMBIENTAL\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\AMBIENTAL\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\BRUCELOSIS_LECHE\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\NUTRICION\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\NUTRICION\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
            lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
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
        ElseIf TextTipoAnalisis.Text = "Parasitología" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\PARASITOLOGIA\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\PARASITOLOGIA\" & ficha & ".pdf"
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


            '*****************************************************************************
        ElseIf TextTipoAnalisis.Text = "Toxicología" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\TOXICOLOGIA\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\TOXICOLOGIA\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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

            '*****************************************************************************
        ElseIf TextTipoAnalisis.Text = "Efluentes" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\EFLUENTES\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\EFLUENTES\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
            Dim tipo As Integer = 16
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
                    cimicro.TIPO = 16
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
                cimicro.TIPO = 16
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

        ElseIf TextTipoAnalisis.Text = "Suelos" Or TextTipoAnalisis.Text = "Foliares" Then
            '*** MOVER ARCHIVO XLS***********************************************************************
            Dim sArchivoOrigen As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".xls"
            Dim sRutaDestino As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".xls"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen, sRutaDestino, True)
                'MsgBox("Ok.", MsgBoxStyle.Information, "Mover archivo")
                ' errores  
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
            '*** MOVER ARCHIVO PDF***********************************************************************
            Dim sArchivoOrigen2 As String = "\\ROBOT\PREINFORMES\SUELOS\" & ficha & ".pdf"
            Dim sRutaDestino2 As String = "\\ROBOT\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Try
                ' Mover el fichero.si existe lo sobreescribe  
                My.Computer.FileSystem.MoveFile(sArchivoOrigen2, sRutaDestino2, True)
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
            lista = ci.listarxtipoxfecha(tipo, fechad, fechah)
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
            If TextComentarios.Text <> "" Then
                observaciones = TextComentarios.Text.Trim
            End If
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
            If p.NOT_EMAIL_ANALISIS1 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS1)
            ElseIf p.NOT_EMAIL_ANALISIS2 <> "" Then
                email = RTrim(p.NOT_EMAIL_ANALISIS2)
            ElseIf p.EMAIL <> "" Then
                email = RTrim(p.EMAIL)
            End If
            Dim productorweb_com As String = ""
            productorweb_com = p.USUARIO_WEB
            'Dim pw_com As New dProductorWeb_com
            'pw_com.USUARIO = productorweb_com
            'pw_com = pw_com.buscar
            'If Not pw_com Is Nothing Then
            '    'email = RTrim(pw_com.ENVIAR_EMAIL)
            'Else
            '    MsgBox("No coincide el usuario web (.com)")
            'End If
            Dim v As New FormCorreo(Usuario, email, ficha)
            v.Show()
            productorweb_com = Nothing
            'pw_com = Nothing
            p = Nothing
            prod = Nothing
            sol = Nothing
        End If
        '****************************
        limpiar()
        marcarxdefecto()
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
        productorweb_com = ""
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
            Dim pw_com As New dProductorWeb_com
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
    Private Sub ButtonSeleccionarFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSeleccionarFicha.Click
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

    Private Sub ButtonEnviarCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviarCopia.Click
        Dim v As New FormBuscarTecnico
        v.ShowDialog()
        Dim mailproductor As String = ""
        If Not v.Productor Is Nothing Then
            Dim pro As dProductorWeb_com = v.Productor
            TextEnviarCopia.Text = pro.ENVIAR_EMAIL
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
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "170.249.199.66"
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
            'Dim _File As String = "\\ROBOT\PREINFORMES\CALIDAD\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _File As String = "\\ROBOT\INFORMES PARA SUBIR\" & archivo & ".pdf" 'archivo que se quiere adjuntar ‘
            Dim _Attachment As New System.Net.Mail.Attachment(_File, System.Net.Mime.MediaTypeNames.Application.Octet) '
            _Message.Attachments.Add(_Attachment) 'ENVIO 
            Try
                _SMTP.Send(_Message)
                MessageBox.Show("Correo enviado!", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _Attachment = Nothing
                _File = ""
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
        email = "jgarello@lasibila.com.ar, pdemaio@lasibila.com.ar, amrodriguez@afb.com.uy, hvilche@afb.com.uy, lab.fisicoquimico@afb.com.uy, mcornejo@afb.com.uy"
        If email <> "" Then
            'CONFIGURACIÓN DEL STMP 
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "170.249.199.66"
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
            _SMTP.Credentials = New System.Net.NetworkCredential("notificaciones@colaveco.com.uy", "-]$]Mo8z1kr3")
            _SMTP.Host = "170.249.199.66"
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
    Private Sub DataRepeater1_CurrentItemIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class