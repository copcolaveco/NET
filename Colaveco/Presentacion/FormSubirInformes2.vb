Imports System.Net.FtpWebRequest
Imports System.Net
Imports System.IO
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
          

            'Dim pical As New dPreinformeCalidad
            'pical.FICHA = ficha
            'pical.ABONADO = abonado
            'pical.COMENTARIO = comentario
            'pical.COPIA = copia
            'pical.PARASUBIR = 1
            'pical.modificar2()

            '*** MOVER ARCHIVO XLS ***********************************************************************
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CALIDAD\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PRE INFORMES\CALIDAD\" & ficha & ".xls"
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
            'Dim sArchivoOrigen2 As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CALIDAD\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PRE INFORMES\CALIDAD\" & ficha & ".pdf"
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


        

        ElseIf TextTipoAnalisis.Text = "Control Lechero" Then
          

            'Dim picon As New dPreinformeControl
            'picon.FICHA = ficha
            'picon.ABONADO = abonado
            'picon.COMENTARIO = comentario
            'picon.COPIA = copia
            'picon.PARASUBIR = 1
            'picon.modificar2()

            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PRE INFORMES\CONTROL\" & ficha & ".xls"
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
            'Dim sArchivoOrigen2 As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PRE INFORMES\CONTROL\" & ficha & ".pdf"
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
            'Dim sArchivoOrigen3 As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".txt"
            'Dim sRutaDestino3 As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".txt"
            Dim sArchivoOrigen3 As String = "\\ROBOT\PRE INFORMES\CONTROL\" & ficha & ".txt"
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

        ElseIf TextTipoAnalisis.Text = "Agua" Then

            'Dim picon As New dPreinformeControl
            'picon.FICHA = ficha
            'picon.ABONADO = abonado
            'picon.COMENTARIO = comentario
            'picon.COPIA = copia
            'picon.PARASUBIR = 1
            'picon.modificar2()

            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PRE INFORMES\AGUA\" & ficha & ".xls"
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
            'Dim sArchivoOrigen2 As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PRE INFORMES\AGUA\" & ficha & ".pdf"
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

        ElseIf TextTipoAnalisis.Text = "Prodúctos Lácteos" Then

            'Dim picon As New dPreinformeControl
            'picon.FICHA = ficha
            'picon.ABONADO = abonado
            'picon.COMENTARIO = comentario
            'picon.COPIA = copia
            'picon.PARASUBIR = 1
            'picon.modificar2()

            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PRE INFORMES\SUBPRODUCTOS\" & ficha & ".xls"
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
            'Dim sArchivoOrigen2 As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PRE INFORMES\SUBPRODUCTOS\" & ficha & ".pdf"
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

        ElseIf TextTipoAnalisis.Text = "Bacteriología y Antibiograma" Then

            'Dim picon As New dPreinformeControl
            'picon.FICHA = ficha
            'picon.ABONADO = abonado
            'picon.COMENTARIO = comentario
            'picon.COPIA = copia
            'picon.PARASUBIR = 1
            'picon.modificar2()

            '*** MOVER ARCHIVO XLS***********************************************************************
            'Dim sArchivoOrigen As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".xls"
            'Dim sRutaDestino As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".xls"
            Dim sArchivoOrigen As String = "\\ROBOT\PRE INFORMES\ANTIBIOGRAMA\" & ficha & ".xls"
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
            'Dim sArchivoOrigen2 As String = "\\Srvcolaveco2\datos (d)\NET\PRE INFORMES\CONTROL\" & ficha & ".pdf"
            'Dim sRutaDestino2 As String = "\\Srvcolaveco2\datos (d)\NET\INFORMES PARA SUBIR\" & ficha & ".pdf"
            Dim sArchivoOrigen2 As String = "\\ROBOT\PRE INFORMES\ANTIBIOGRAMA\" & ficha & ".pdf"
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

        End If

       

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
        Dim v As New FormBuscarProductor
        v.ShowDialog()
        productorweb_com = ""


        If Not v.Productor Is Nothing Then
            Dim pro As dProductor = v.Productor
            TextIdCliente.Text = pro.ID
            TextNombreCliente.Text = pro.NOMBRE
            If pro.USUARIO_WEB = "" Then
                MsgBox("El cliente no tiene usuario web")
                Exit Sub
                limpiar()
                marcarxdefecto()
            End If
            productorweb_com = pro.USUARIO_WEB
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
            If pro.MOROSO = 1 Then
                MsgBox("El cliente tiene deuda, no se puede continuar con la solicitud.")
                TextIdCliente.Text = ""
                TextNombreCliente.Text = ""
                Exit Sub
            End If
            If pro.CONTADO = 1 Then
                MsgBox("El cliente trabaja solo contado, tener en cuenta a la hora de subir informes.")
                ButtonSeleccionarFicha.Focus()
            End If
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

    Private Sub ButtonEnviarCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnviarCopia.Click
        Dim v As New FormBuscarTecnico
        v.ShowDialog()
        Dim mailproductor As String = ""

        If Not v.Productor Is Nothing Then
            Dim pro As dProductorWeb_com = v.Productor
            TextEnviarCopia.Text = pro.ENVIAR_EMAIL
        End If
    End Sub

End Class