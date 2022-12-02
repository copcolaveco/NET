Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System
Imports System.Net
Imports System.IO
Imports System.Collections
Imports System.Net.FtpWebRequest
Imports Newtonsoft.Json
Public Class FormGestor
    Private _abonado As Integer = 0
    Private _comentarios As String = ""
    Private idficha As Long = 0
    Private _fechaenvio As Date
    Private factura_origen As String
    Private idproductorweb_com As Long = 0
    Private productorweb_com As String = ""
    Private tipoinforme As Integer = 0
    Private carpeta As Long = 0
    Private excel As Integer = 0
    Private pdf As Integer = 0
    Private csv As Integer = 0
    Private mensaje As String = ""
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'prueba_crear()
        'prueba_leer()
        'limpiar()
    End Sub
#End Region
    Private Sub prueba_crear()
        Dim usuario As New Dictionary(Of String, dUsuarioGestor)

        Dim ug As New dUsuarioGestor

        Dim telefonos As New List(Of dTelefonoGestor)
        Dim un_telefono As New dTelefonoGestor
        un_telefono.idusuario = 55
        un_telefono.tipo = "consultas_tecnicas"
        un_telefono.nombre = "Pepo"
        un_telefono.telefono = "45545311"
        telefonos.Add(un_telefono)

        Dim celulares As New List(Of dCelularGestor)
        Dim un_celular As New dCelularGestor
        un_celular.idusuario = 55
        un_celular.tipo = "consultas_tecnicas"
        un_celular.nombre = "Pepo"
        un_celular.celular = "099550386"
        celulares.Add(un_celular)

        Dim emails As New List(Of dEmailGestor)
        Dim un_email As New dEmailGestor
        un_email.idusuario = 55
        un_email.tipo = "consultas_tecnicas"
        un_email.nombre = "Pepo"
        un_email.email = "pepobaez@gmail.com"
        emails.Add(un_email)


        ug.idnet = "55"
        ug.email = "colaveco@test.com"
        ug.password = "12345678"
        ug.password_confirmation = "12345678"
        ug.usuario_web = "colaveco"
        ug.nombre = "colaveco"
        ug.dicose = "55555555"
        ug.razon_social = "cooperativa colaveco"
        ug.rut = "12345678910"

        usuario.Add("user", ug)

        Dim parameters As String = JsonConvert.SerializeObject(usuario, Formatting.None)

        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/users/users", "POST", parameters, status)
        'Dim responseString As String
        'If response IsNot Nothing Then
        '    responseString = System.Text.Encoding.UTF8.GetString(response)
        'Else
        '    responseString = "NULL"
        'End If
        'Console.WriteLine("Response Code: " & status)
        'Console.WriteLine("Response String: " & responseString)

        MsgBox("Usuario creado")
        ' Tip: Use *.Dump(me)/*.Dump(this) to dump out objects, and Dump([anonymous]) to dump out Anonymous objects. 
        ' BTW, hit F5 on your keyboard inside the code editor to compile and run your code! 
        ' Define additional methods and/or classes here 

    End Sub

    Private Sub prueba_leer()

        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = GetResponse("http://colaveco-gestor.herokuapp.com/users", "GET", status)
        Dim responseString As String
        If response IsNot Nothing Then
            responseString = System.Text.Encoding.UTF8.GetString(response)
        Else
            responseString = "NULL"
        End If
        Console.WriteLine("Response Code: " & status)
        Console.WriteLine("Response String: " & responseString)

        Dim usuarios As New List(Of dUsuarioGestor)
        usuarios = JsonConvert.DeserializeObject(Of List(Of dUsuarioGestor))(responseString)



    End Sub
    Public Function GetResponse(ByVal url As String, ByVal metodo As String, ByRef statusCode As HttpStatusCode) As Byte()

        Dim responseFromServer As Byte() = Nothing
        Dim dataStream As Stream = Nothing

        Try
            Dim request As WebRequest = WebRequest.Create(url)

            request.Timeout = 120000

            request.Method = metodo



            request.ContentType = "application/json"




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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        prueba_crear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        prueba_leer()
    End Sub
    Private Sub solicitud_frascos()

        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = GetResponse("http://colaveco-gestor.herokuapp.com/solicitudfrascos/nuevos", "GET", status)
        Dim responseString As String
        If response IsNot Nothing Then
            responseString = System.Text.Encoding.UTF8.GetString(response)
        Else
            responseString = "NULL"
        End If
        Console.WriteLine("Response Code: " & status)
        Console.WriteLine("Response String: " & responseString)

        Dim frascos As New List(Of dFrascosGestor)
        frascos = JsonConvert.DeserializeObject(Of List(Of dFrascosGestor))(responseString)

        For Each a In frascos
            Dim pw As New dPedidosWeb
            Dim fecha As Date = Now
            Dim fec As String
            fec = Format(fecha, "yyyy-MM-dd")
            pw.FECHA = fec
            pw.CODIGO = a.idnet
            pw.NOMBRE = a.nombre
            pw.DIRECCION = a.direccion
            If a.agencia = "Agencia Central" Then
                pw.AGENCIA = 1
            ElseIf a.agencia = "Tiempost" Then
                pw.AGENCIA = 2
            ElseIf a.agencia = "Cia. Colonia" Then
                pw.AGENCIA = 3
            ElseIf a.agencia = "Cot" Then
                pw.AGENCIA = 4
            ElseIf a.agencia = "Comsa" Then
                pw.AGENCIA = 5
            ElseIf a.agencia = "Turil" Then
                pw.AGENCIA = 6
            ElseIf a.agencia = "Retiro en Colaveco" Then
                pw.AGENCIA = 7
            ElseIf a.agencia = "No proporcionado" Then
                pw.AGENCIA = 8
            ElseIf a.agencia = "Correo" Then
                pw.AGENCIA = 9
            ElseIf a.agencia = "Retiro en Florida" Then
                pw.AGENCIA = 10
            ElseIf a.agencia = "Retiro en Cardal" Then
                pw.AGENCIA = 11
            ElseIf a.agencia = "Retiro en Canelones" Then
                pw.AGENCIA = 12
            ElseIf a.agencia = "Retiro ahora" Then
                pw.AGENCIA = 13
            End If
            pw.TELEFONO = a.telefono
            pw.EMAIL = a.email
            pw.CCONSERVANTE = a.frascos_con_c
            pw.SCONSERVANTE = a.frascos_sin_c
            pw.AGUA = a.frascos_agua
            pw.SANGRE = a.frascos_sangre
            pw.OBSERVACIONES = a.observaciones
            pw.REALIZADO = 0
            pw.CANCELADO = 0
            pw.guardar()
            pw = Nothing
        Next

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        solicitud_frascos()
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirCtaCte.Click
        Dim fechadesde As Date = DateDesde.Value
        Dim fecdesde As String
        fecdesde = Format(fechadesde, "yyyy-MM-dd")
        Dim fechahasta As Date = DateHasta.Value
        Dim fechasta As String
        fechasta = Format(fechahasta, "yyyy-MM-dd")
        '_fecha = "2018-05-31"
        Dim movimientosDict As New Dictionary(Of String, List(Of dMovimientos2))

        Dim movimientos As New List(Of dMovimientos2)
        Dim m As New dMovCte2
        Dim listamovimientos As New ArrayList
        listamovimientos = m.listarentrefechas(fecdesde, fechasta)
        If Not listamovimientos Is Nothing Then
            For Each m In listamovimientos
                Dim movi As New dMovimientos2
                Dim _path As String = ""
                Dim path As String = "/home/colaveco/www/gestor/facturas/"
                movi.idnet_movimiento = m.MCCNRO
                movi.fecha_emision = m.MCCFCH
                movi.fecha_vencimiento = m.MCCVTO
                Dim tipo As String = ""
                If m.DOCCOD = "NF" Then
                    tipo = "NC"
                ElseIf m.DOCCOD = "NI" Then
                    tipo = "NC"
                ElseIf m.DOCCOD = "01" Then
                    tipo = "R"
                ElseIf m.DOCCOD = "02" Then
                    tipo = "ND"
                ElseIf m.DOCCOD = "AA" Then
                    tipo = "AA"
                ElseIf m.DOCCOD = "AD" Then
                    tipo = "AD"
                ElseIf m.DOCCOD = "CI" Then
                    tipo = "F"
                ElseIf m.DOCCOD = "FA" Then
                    tipo = "F"
                ElseIf m.DOCCOD = "FF" Then
                    tipo = "F"
                ElseIf m.DOCCOD = "NC" Then
                    tipo = "NC"
                End If
                movi.tipo = tipo
                movi.numero = m.MCCDOC
                movi.detalle = m.MCCDES
                movi.importe = m.MCCIMP
                movi.tipo_movimiento = m.MCCCOD
                movi.importe_pago = m.MCCPAG
                movi.idnet_usuario = m.CLICOD
                If m.MCCTIP = "V" Then
                    Dim f As New dFactur
                    f.FACNRO = m.MCCCMP
                    f = f.buscar
                    If Not f Is Nothing Then
                        Dim c As String = "\\SRVCOLAVECO6\apls\soft\"
                        Dim tx As String = f.FACPDF
                        If tx.Contains(c) Then
                            _path = tx.Replace(c, "")
                            factura_origen = _path
                            path = path & _path
                        End If
                    End If
                End If
                movi.path_pdf = path
                movimientos.Add(movi)
                movi = Nothing
                tipo = Nothing
                subirFacturaPdf()
            Next
            movimientosDict.Add("movimientos", movimientos)
            Dim parameters As String = JsonConvert.SerializeObject(movimientosDict, Formatting.None)
            Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
            Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/factura_movimientos/migrar", "POST", parameters, status)
        End If
        MsgBox("Registros subidos al nuevo gestor!")
    End Sub
    Public Function subirFacturaPdf() As String

        Dim fichero As String = ""
        Dim destino As String = ""
        Dim user As String = "colaveco"
        Dim pass As String = "NUEVA**!!COL22$%"

        fichero = "\\SRVCOLAVECO6\apls\soft\" & factura_origen
        destino = "ftp://colaveco.com.uy/www/gestor/facturas/" & factura_origen


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

    Private Sub ButtonBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarCliente.Click
        Dim v As New FormBuscarCliente
        v.ShowDialog()
        If Not v.Cliente Is Nothing Then
            Dim cli As dCliente = v.Cliente
            TextIdCliente.Text = cli.ID
            TextCliente.Text = cli.NOMBRE
        End If
    End Sub

    Private Sub ButtonCtaCtexCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCtaCtexCliente.Click
        'Dim fechaactual As Date = DateCtaCte.Value
        'Dim _fecha As String
        '_fecha = Format(fechaactual, "yyyy-MM-dd")
        Dim idcli As Integer = 0
        idcli = TextIdCliente.Text.Trim
        Dim movimientosDict As New Dictionary(Of String, List(Of dMovimientos2))
        Dim movimientos As New List(Of dMovimientos2)
        Dim m As New dMovCte2
        Dim listamovimientos As New ArrayList
        listamovimientos = m.listarxcliente(idcli)
        If Not listamovimientos Is Nothing Then
            For Each m In listamovimientos
                Dim movi As New dMovimientos2
                Dim _path As String = ""
                Dim path As String = "/home/colaveco/www/gestor/facturas/"
                movi.idnet_movimiento = m.MCCNRO
                movi.fecha_emision = m.MCCFCH
                movi.fecha_vencimiento = m.MCCVTO
                Dim tipo As String = ""
                If m.DOCCOD = "NF" Then
                    tipo = "NC"
                ElseIf m.DOCCOD = "NI" Then
                    tipo = "NC"
                ElseIf m.DOCCOD = "01" Then
                    tipo = "R"
                ElseIf m.DOCCOD = "02" Then
                    tipo = "ND"
                ElseIf m.DOCCOD = "AA" Then
                    tipo = "AA"
                ElseIf m.DOCCOD = "AD" Then
                    tipo = "AD"
                ElseIf m.DOCCOD = "CI" Then
                    tipo = "F"
                ElseIf m.DOCCOD = "FA" Then
                    tipo = "F"
                ElseIf m.DOCCOD = "FF" Then
                    tipo = "F"
                ElseIf m.DOCCOD = "NC" Then
                    tipo = "NC"
                End If
                movi.tipo = tipo
                movi.numero = m.MCCDOC
                movi.detalle = m.MCCDES
                movi.importe = m.MCCIMP
                movi.tipo_movimiento = m.MCCCOD
                movi.importe_pago = m.MCCPAG
                movi.idnet_usuario = m.CLICOD
                If m.MCCTIP = "V" Then
                    Dim f As New dFactur
                    f.FACNRO = m.MCCCMP
                    f = f.buscar
                    If Not f Is Nothing Then
                        Dim c As String = "\\SRVCOLAVECO6\apls\soft\"
                        Dim tx As String = f.FACPDF
                        If tx.Contains(c) Then
                            _path = tx.Replace(c, "")
                            factura_origen = _path
                            path = path & _path
                        End If
                    End If
                End If
                movi.path_pdf = path
                movimientos.Add(movi)
                movi = Nothing
                tipo = Nothing
                subirFacturaPdf()
            Next
            movimientosDict.Add("movimientos", movimientos)
            Dim parameters As String = JsonConvert.SerializeObject(movimientosDict, Formatting.None)
            Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
            Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/factura_movimientos/migrar", "POST", parameters, status)
        End If
        MsgBox("Registros subidos al nuevo gestor!")
    End Sub

    Private Sub ButtonSubirFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubirFicha.Click
        If TextFicha.Text <> "" Then
            If ComboEstado.Text <> "" Then
                If ComboEstado.Text = "Abonado" Then
                    _abonado = 2
                ElseIf ComboEstado.Text = "No abonado (con visualización)" Then
                    _abonado = 1
                ElseIf ComboEstado.Text = "No abonado (sin visualización)" Then
                    _abonado = 0
                End If
                If TextComentarios.Text <> "" Then
                    _comentarios = TextComentarios.Text
                End If
                idficha = TextFicha.Text.Trim
                Dim s As New dSolicitudAnalisis
                s.ID = idficha
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
                    ElseIf s.IDTIPOINFORME = 17 Then
                        tipoinforme = 17
                    ElseIf s.IDTIPOINFORME = 18 Then
                        tipoinforme = 18
                    ElseIf s.IDTIPOINFORME = 19 Then
                        tipoinforme = 19
                    ElseIf s.IDTIPOINFORME = 20 Then
                        tipoinforme = 20
                    End If
                    subir_informes()
                    TextFicha.Text = idficha & " - subida!"
                    TextFicha.SelectAll()
                    TextFicha.Focus()
                End If
            End If
        End If


    End Sub

    Private Sub ButtonEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEstado.Click
        'If TextFicha.Text <> "" Then
        '    If ComboEstado.Text <> "" Then
        '        If ComboEstado.Text = "Abonado" Then
        '            _abonado = 2
        '        ElseIf ComboEstado.Text = "No abonado (con visualización)" Then
        '            _abonado = 1
        '        ElseIf ComboEstado.Text = "No abonado (sin visualización)" Then
        '            _abonado = 0
        '        End If
        '        If TextComentarios.Text <> "" Then
        '            _comentarios = TextComentarios.Text
        '        End If
        '        idficha = TextFicha.Text.Trim
        '        modificarRegistro()
        '    End If
        'End If
    End Sub
    Public Sub modificarRegistro()
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
        ElseIf tipoinforme = 17 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 18 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 19 Then
            carpeta = "agro_suelos"
        ElseIf tipoinforme = 20 Then
            carpeta = "patologia"
        End If

        Dim rg As New dResultado

        Dim fechaemi2 As String
        Dim fecha_emision2 As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        'fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")
        fechaemi2 = _fechaenvio

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
        ElseIf tipoinforme = 17 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 18 Then
            carpeta = "antibiograma"
        ElseIf tipoinforme = 19 Then
            carpeta = "agro_suelos"
        ElseIf tipoinforme = 20 Then
            carpeta = "patologia"
        End If

        Dim rg As New dResultado

        'Dim fechaemi2 As String
        'Dim fecha_emision2 As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        'fechaemi2 = Format(fecha_emision2, "yyyy-MM-dd")

        rg.ficha = idficha
        rg.comentarios = _comentarios
        rg.idnet_usuario = idnet
        rg.abonado = _abonado
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
    Private Sub enviar_notificacion_resultado()
        Dim fechaactual As Date = Now()
        Dim _fecha As String
        _fecha = Format(fechaactual, "yyyy-MM-dd")
        Dim notificacion As New Dictionary(Of String, dNotificaciones)
        Dim nt As New dNotificaciones
        Dim _tipo As String = ""
        Dim _mensaje As String = ""
        Dim nuevoid As Long = 0
        Dim tipoinforme As String = ""

        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            Dim ti As New dTipoInforme
            ti.ID = sa.IDTIPOINFORME
            ti = ti.buscar
            If Not ti Is Nothing Then
                tipoinforme = ti.NOMBRE
            End If
            nuevoid = sa.IDPRODUCTOR
        End If
        _tipo = "resultado"
        _mensaje = "El resultado de su análisis de " & tipoinforme & ", número " & idficha & " está finalizado."
        nt.fecha = _fecha
        nt.tipo = _tipo
        nt.mensaje = _mensaje
        nt.idnet_usuario = nuevoid
        notificacion.Add("notification", nt)

        Dim parameters As String = JsonConvert.SerializeObject(notificacion, Formatting.None)

        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse("http://colaveco-gestor.herokuapp.com/notifications", "POST", parameters, status)
    End Sub
    Private Sub subir_informes()
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
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
                sa = Nothing
            End If
        End If

controlexcel:
        subirFicheroXls()
        existeXls()
        If excel = 1 Then
            GoTo controlexcel
        End If
        subidoxls = 1

controlpdf:

        subirFicheroPdf()
        existePdf()
        If pdf = 1 Then
            GoTo controlpdf
        End If
        subidopdf = 1

        If tipoinforme = 1 Then
controltxt:

            subirFicheroCsv()
            existeCsv()
            If csv = 1 Then
                GoTo controltxt
            End If
        End If



        modificarRegistro()

        Dim s As New dSolicitudAnalisis
        Dim fechaenvio As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecenv As String
        fecenv = Format(fechaenvio, "yyyy-MM-dd")
        s.ID = idficha
        s.actualizarfechaenvio2(fecenv)
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
    End Sub

    Private Sub subir_informes2()
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
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
                sa = Nothing
            End If
        End If

        'controlexcel:
        '        subirFicheroXls()
        '        existeXls()
        '        If excel = 1 Then
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
        's.actualizarfechaenvio2(fecenv)
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
        ElseIf tipoinforme = 17 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 18 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 20 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\TOXICOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
        ElseIf tipoinforme = 99 Then
            crea_otros_servicios_com()
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
        ElseIf tipoinforme = 17 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 18 Then
            crea_antibiograma_com()
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 19 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 20 Then
            crea_agro_suelos_com()
            fichero = "\\192.168.1.10\E\NET\TOXICOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
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
        ElseIf tipoinforme = 17 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 18 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".xls"
        ElseIf tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".xls"
        ElseIf tipoinforme = 20 Then
            fichero = "\\192.168.1.10\E\NET\TOXICOLOGIA\" & idficha & ".xls"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".xls"
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
        ElseIf tipoinforme = 17 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 18 Then
            fichero = "\\192.168.1.10\E\NET\ANTIBIOGRAMA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/antibiograma/" & idficha & ".pdf"
        ElseIf tipoinforme = 19 Then
            fichero = "\\192.168.1.10\E\NET\Suelos\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/agro_suelos/" & idficha & ".pdf"
        ElseIf tipoinforme = 20 Then
            fichero = "\\192.168.1.10\E\NET\TOXICOLOGIA\" & idficha & ".pdf"
            destino = "ftp://colaveco.com.uy/public_html/gestor/data_file/" & idproductorweb_com & "/patologia/" & idficha & ".pdf"
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
    Private Sub cambiar_estado()
        If ComboEstado.Text <> "" Then
            If ComboEstado.Text = "Abonado" Then
                _abonado = 2
            ElseIf ComboEstado.Text = "No abonado (con visualización)" Then
                _abonado = 1
            ElseIf ComboEstado.Text = "No abonado (sin visualización)" Then
                _abonado = 0
            End If
            If TextComentarios.Text <> "" Then
                _comentarios = TextComentarios.Text
            End If
            idficha = TextFicha.Text.Trim
            Dim s As New dSolicitudAnalisis
            s.ID = idficha
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
                subir_informes2()
                TextFicha.Text = idficha & " - subida!"
                TextFicha.SelectAll()
            End If
        End If

    End Sub
    Private Sub ButtonCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCambiarEstado.Click
        If TextFicha.Text <> "" Then
            If ComboEstado.Text <> "" Then
                cambiar_estado()
            Else
                MsgBox("Seleccione un estado!")
            End If
        End If
    End Sub


    Private Sub SubirFichasEnMasaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubirFichasEnMasaToolStripMenuItem.Click
        Dim v As New FormSubirInformesenMasa
        v.Show()
    End Sub
    Private Sub subir_fichas()
        Dim s As New dSolicitudAnalisis
            s.ID = idficha
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
                ElseIf s.IDTIPOINFORME = 17 Then
                    tipoinforme = 17
                ElseIf s.IDTIPOINFORME = 18 Then
                    tipoinforme = 18
                ElseIf s.IDTIPOINFORME = 19 Then
                    tipoinforme = 19
                ElseIf s.IDTIPOINFORME = 20 Then
                    tipoinforme = 20
                End If
                subir_informes()
            End If
    End Sub

    Private Sub SubirInformes_Click(sender As Object, e As EventArgs) Handles SubirInformes.Click
        Dim fichadesde As Long = 0
        Dim fichahasta As Long = 0
        Dim _subinf As Integer = 0
        If ComboEstado2.Text <> "" Then
            If ComboEstado2.Text = "Abonado" Then
                _abonado = 2
            ElseIf ComboEstado2.Text = "No abonado (con visualización)" Then
                _abonado = 1
            ElseIf ComboEstado2.Text = "No abonado (sin visualización)" Then
                _abonado = 0
            End If
        End If
        fichadesde = TextFichaDesde.Text
        fichahasta = TextFichaHasta.Text

        Dim s As New dSolicitudAnalisis
        Dim lista As New ArrayList
        lista = s.listarfichas(fichadesde, fichahasta)
        If Not lista Is Nothing Then
            For Each s In lista
                idficha = s.ID
                tipoinforme = s.IDTIPOINFORME
                _fechaenvio = s.FECHAENVIO
                _subinf = s.IDSUBINFORME
                If _subinf <> 22 Then
                    subir_informes_masivos()
                End If
            Next
        End If
        'idficha = TextFicha.Text.Trim
        MsgBox("Proceso finalizado!")
    End Sub
    Private Sub subir_informes_masivos()
        Dim subidoxls As Integer = 0
        Dim subidopdf As Integer = 0
        Dim subidotxt As Integer = 0
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
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
                sa = Nothing
            End If
        End If

controlexcel:
        subirFicheroXls()
        existeXls()
        If excel = 1 Then
            GoTo controlexcel
        End If
        subidoxls = 1

controlpdf:

        subirFicheroPdf()
        existePdf()
        If pdf = 1 Then
            GoTo controlpdf
        End If
        subidopdf = 1

        If tipoinforme = 1 Then
controltxt:

            subirFicheroCsv()
            existeCsv()
            If csv = 1 Then
                GoTo controltxt
            End If
        End If



        modificarRegistro()

        Dim s As New dSolicitudAnalisis
        Dim fechaenvio As Date = DateFecha.Value.ToString("yyyy-MM-dd")
        Dim fecenv As String
        'fecenv = Format(fechaenvio, "yyyy-MM-dd")
        fecenv = _fechaenvio
        s.ID = idficha
        s.actualizarfechaenvio2(fecenv)
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
    End Sub
End Class