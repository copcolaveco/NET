Public Class pProductorWeb_uy
    Inherits Conectoras.ConexionMySQL_uy
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductorWeb_uy = CType(o, dProductorWeb_uy)
        Dim sql As String = "INSERT INTO usuarios (id, usuario, nombre, password, tipo_usuario_id, razon_social, direccion, telefono_1, telefono_2, telefono_3, celular_1, celular_2, celular_3, email_1, email_2, email_3, enviar_email, enviar_sms, ruc, dicose, saldo_pesos, saldo_dolares, ver_control_lechero, ver_agua, ver_pal, ver_serologia, ver_antibiograma, ver_parasitologia, ver_productos_subproductos, ver_patologia, ver_calidad_de_leche, id_tecnico_1, fecha_tecnico, id_usuario_asigno_tecnico, id_tecnico_2, id_tecnico_3, id_tecnico_4, codigofigaro, enviar_informe_por_mail, path_estado_de_cuenta, fecha_modificacion ) VALUES (" & obj.ID & ", '" & obj.USUARIO & "','" & obj.NOMBRE & "','" & obj.PASSWORD & "', " & obj.TIPO_USUARIO_ID & ",'" & obj.RAZON_SOCIAL & "','" & obj.DIRECCION & "','" & obj.TELEFONO_1 & "','" & obj.TELEFONO_2 & "','" & obj.TELEFONO_3 & "','" & obj.CELULAR_1 & "','" & obj.CELULAR_2 & "','" & obj.CELULAR_3 & "','" & obj.EMAIL_1 & "','" & obj.EMAIL_2 & "','" & obj.EMAIL_3 & "', '" & obj.ENVIAR_EMAIL & "','" & obj.ENVIAR_SMS & "','" & obj.RUT & "','" & obj.DICOSE & "', " & obj.SALDO_PESOS & ", " & obj.SALDO_DOLARES & ", " & obj.VER_CONTROL_LECHERO & ", " & obj.VER_AGUA & ", " & obj.VER_PAL & ", " & obj.VER_SEROLOGIA & ", " & obj.VER_ANTIBIOGRAMA & ", " & obj.VER_PARASITOLOGIA & ", " & obj.VER_PRODUCTOS_SUBPRODUCTOS & ", " & obj.VER_PATOLOGIA & ", " & obj.VER_CALIDAD_DE_LECHE & ", " & obj.TECNICO_1 & ", '" & obj.FECHA_TECNICO & "', " & obj.ID_USUARIO_ASIGNA_TECNICO & ", " & obj.TECNICO_2 & ", " & obj.TECNICO_3 & ", " & obj.TECNICO_4 & ", '" & obj.CODIGOFIGARO & "', " & obj.ENVIAR_INFORME_POR_MAIL & ", '" & obj.PATH_ESTADO_DE_CUENTA & "', '" & obj.FECHA_MODIFICACION & "')"

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductorWeb_uy = CType(o, dProductorWeb_uy)
        'Dim sql As String = "UPDATE productor SET Nombre ='" & obj.NOMBRE & "',Email1 ='" & obj.EMAIL1 & "',Email2 ='" & obj.EMAIL2 & "',Email3 ='" & obj.EMAIL3 & "',Envio ='" & obj.ENVIO & "',usuario_web ='" & obj.USUARIO_WEB & "',Razon_social ='" & obj.RAZON_SOCIAL & "', Telefono_2 ='" & obj.TELEFONO_2 & "', Telefono_3='" & obj.TELEFONO_3 & "', Celular_1 ='" & obj.CELULAR_1 & "', Celular_2 =  '" & obj.CELULAR_2 & "', Celular_3 ='" & obj.CELULAR_3 & "', RUC ='" & obj.RUT & "', CodigoFigaro ='" & obj.CODIGOFIGARO & "', TipoUsuario =" & obj.TIPOUSUARIO & ", Direccion ='" & obj.DIRECCION & "', Telefono ='" & obj.TELEFONO & "', Fax ='" & obj.FAX & "', DICOSE ='" & obj.DICOSE & "', IDDepartamento =" & obj.IDDEPARTAMENTO & ", IDLocalidad =" & obj.IDLOCALIDAD & ", Tecnico =" & obj.TECNICO & ", camino_control_lechero ='" & obj.CAMINO_CONTROL_LECHERO & "', camino_calidad_leche ='" & obj.CAMINO_CALIDAD_LECHE & "', camino_analisis_de_agua ='" & obj.CAMINO_ANALISIS_DE_AGUA & "', camino_pal ='" & obj.CAMINO_PAL & "', camino_rosa_bengala ='" & obj.CAMINO_ROSA_BENGALA & "', camino_antibiograma ='" & obj.CAMINO_ANTIBIOGRAMA & "', idagencia=" & obj.IDAGENCIA & " WHERE ID = " & obj.ID
        Dim sql As String = "UPDATE usuarios SET usuario='" & obj.USUARIO & "',nombre='" & obj.NOMBRE & "',password='" & obj.PASSWORD & "',tipo_usuario_id=" & obj.TIPO_USUARIO_ID & ",razon_social='" & obj.RAZON_SOCIAL & "', direccion='" & obj.DIRECCION & "', telefono_1='" & obj.TELEFONO_1 & "', telefono_2=,'" & obj.TELEFONO_2 & "',telefono_3='" & obj.TELEFONO_3 & "',celular_1='" & obj.CELULAR_1 & "',celular_2='" & obj.CELULAR_2 & "',celular_3='" & obj.CELULAR_3 & "',email_1='" & obj.EMAIL_1 & "',email_2='" & obj.EMAIL_2 & "',email_3='" & obj.EMAIL_3 & "',enviar_email= '" & obj.ENVIAR_EMAIL & "',enviar_sms='" & obj.ENVIAR_SMS & "',ruc='" & obj.RUT & "',dicose='" & obj.DICOSE & "',saldo_pesos= " & obj.SALDO_PESOS & ",saldo_dolares= " & obj.SALDO_DOLARES & ",ver_control_lechero= " & obj.VER_CONTROL_LECHERO & ", ver_agua=" & obj.VER_AGUA & ",ver_pal= " & obj.VER_PAL & ",ver_serologia= " & obj.VER_SEROLOGIA & ",ver_antibiograma= " & obj.VER_ANTIBIOGRAMA & ",ver_parasitologia= " & obj.VER_PARASITOLOGIA & ",ver_productos_subproductos= " & obj.VER_PRODUCTOS_SUBPRODUCTOS & ",ver_patologia= " & obj.VER_PATOLOGIA & ",ver_calidad_de_leche= " & obj.VER_CALIDAD_DE_LECHE & ",id_tecnico_1= " & obj.TECNICO_1 & ",fecha_tecnico= '" & obj.FECHA_TECNICO & "',id_usuario_asigno_tecnico= " & obj.ID_USUARIO_ASIGNA_TECNICO & ",id_tecnico_2= " & obj.TECNICO_2 & ", id_tecnico_3=" & obj.TECNICO_3 & ",id_tecnico_4= " & obj.TECNICO_4 & ",codigofigaro= '" & obj.CODIGOFIGARO & "',enviar_informe_por_mail= " & obj.ENVIAR_INFORME_POR_MAIL & ",path_estado_de_cuenta= '" & obj.PATH_ESTADO_DE_CUENTA & "',fecha_modificacion= '" & obj.FECHA_MODIFICACION & "' WHERE ID = " & obj.ID



        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductorWeb_uy = CType(o, dProductorWeb_uy)
        Dim sql As String = "DELETE FROM usuarios WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dProductorWeb_uy
        Dim obj As dProductorWeb_uy = CType(o, dProductorWeb_uy)
        Dim p As New dProductorWeb_uy
        Try
            Dim Ds As New DataSet
            'Ds = Me.EjecutarSQL("SELECT id, usuario, nombre, password, tipo_usuario_id, razon_social, direccion, telefono_1, telefono_2, telefono_3, celular_1, celular_2, celular_3, email_1, email_2, email_3, enviar_email, enviar_sms, ruc, dicose, saldo_pesos, saldo_dolares, ver_control_lechero, ver_agua, ver_pal, ver_serologia, ver_antibiograma, ver_parasitologia, ver_productos_subproductos, ver_patologia, ver_calidad_de_leche, ifnull(id_tecnico_1,0), fecha_tecnico, id_usuario_asigno_tecnico, ifnull(id_tecnico_2,0), ifnull(id_tecnico_3,0), ifnull(id_tecnico_4,0), ifnull(codigofigaro,''), enviar_informe_por_mail, ifnull(path_estado_de_cuenta,''), fecha_modificacion FROM usuarios WHERE usuario = '" & obj.USUARIO & "'")
            Ds = Me.EjecutarSQL("SELECT id, usuario, nombre, password, tipo_usuario_id, ifnull(razon_social,''), ifnull(direccion,''), ifnull(telefono_1,''), ifnull(telefono_2,''), ifnull(telefono_3,''), ifnull(celular_1,''), ifnull(celular_2,''), ifnull(celular_3,''), ifnull(email_1,''), ifnull(email_2,''), ifnull(email_3,''), ifnull(enviar_email,''), ifnull(enviar_sms,''), ifnull(ruc,''), ifnull(dicose,''), ifnull(saldo_pesos,0), ifnull(saldo_dolares,0), ifnull(ver_control_lechero,0), ifnull(ver_agua,0), ifnull(ver_pal,0), ifnull(ver_serologia,0), ifnull(ver_antibiograma,0), ifnull(ver_parasitologia,0), ifnull(ver_productos_subproductos,0), ifnull(ver_patologia,0), ifnull(ver_calidad_de_leche,0), ifnull(id_tecnico_1,0), fecha_tecnico, ifnull(id_usuario_asigno_tecnico,0), ifnull(id_tecnico_2,0), ifnull(id_tecnico_3,0), ifnull(id_tecnico_4,0), ifnull(codigofigaro,''), ifnull(enviar_informe_por_mail,0), ifnull(path_estado_de_cuenta,'null'), fecha_modificacion FROM usuarios WHERE usuario = '" & obj.USUARIO & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.USUARIO = CType(unaFila.Item(1), String)
                p.NOMBRE = CType(unaFila.Item(2), String)
                p.PASSWORD = CType(unaFila.Item(3), String)
                p.TIPO_USUARIO_ID = CType(unaFila.Item(4), Integer)
                p.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                p.DIRECCION = CType(unaFila.Item(6), String)
                p.TELEFONO_1 = CType(unaFila.Item(7), String)
                p.TELEFONO_2 = CType(unaFila.Item(8), String)
                p.TELEFONO_3 = CType(unaFila.Item(9), String)
                p.CELULAR_1 = CType(unaFila.Item(10), String)
                p.CELULAR_2 = CType(unaFila.Item(11), String)
                p.CELULAR_3 = CType(unaFila.Item(12), String)
                p.EMAIL_1 = CType(unaFila.Item(13), String)
                p.EMAIL_2 = CType(unaFila.Item(14), String)
                p.EMAIL_3 = CType(unaFila.Item(15), String)
                p.ENVIAR_EMAIL = CType(unaFila.Item(16), String)
                p.ENVIAR_SMS = CType(unaFila.Item(17), String)
                p.RUT = CType(unaFila.Item(18), String)
                p.DICOSE = CType(unaFila.Item(19), String)
                p.SALDO_PESOS = CType(unaFila.Item(20), Double)
                p.SALDO_DOLARES = CType(unaFila.Item(21), Double)
                p.VER_CONTROL_LECHERO = CType(unaFila.Item(22), Integer)
                p.VER_AGUA = CType(unaFila.Item(23), Integer)
                p.VER_PAL = CType(unaFila.Item(24), Integer)
                p.VER_SEROLOGIA = CType(unaFila.Item(25), Integer)
                p.VER_ANTIBIOGRAMA = CType(unaFila.Item(26), Integer)
                p.VER_PARASITOLOGIA = CType(unaFila.Item(27), Integer)
                p.VER_PRODUCTOS_SUBPRODUCTOS = CType(unaFila.Item(28), Integer)
                p.VER_PATOLOGIA = CType(unaFila.Item(29), Integer)
                p.VER_CALIDAD_DE_LECHE = CType(unaFila.Item(30), Integer)
                p.TECNICO_1 = CType(unaFila.Item(31), Long)
                p.FECHA_TECNICO = CType(unaFila.Item(32), String)
                p.ID_USUARIO_ASIGNA_TECNICO = CType(unaFila.Item(33), Long)
                p.TECNICO_2 = CType(unaFila.Item(34), Long)
                p.TECNICO_3 = CType(unaFila.Item(35), Long)
                p.TECNICO_4 = CType(unaFila.Item(36), Long)
                p.CODIGOFIGARO = CType(unaFila.Item(37), String)
                p.ENVIAR_INFORME_POR_MAIL = CType(unaFila.Item(38), Integer)
                p.PATH_ESTADO_DE_CUENTA = CType(unaFila.Item(39), String)
                p.FECHA_MODIFICACION = CType(unaFila.Item(40), String)

                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorNombre(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, usuario, nombre, password, tipo_usuario_id, razon_social, direccion, telefono_1, telefono_2, telefono_3, celular_1, celular_2, celular_3, email_1, email_2, email_3, enviar_email, enviar_sms, ruc, dicose, saldo_pesos, saldo_dolares, ver_control_lechero, ver_agua, ver_pal, ver_serologia, ver_antibiograma, ver_parasitologia, ver_productos_subproductos, ver_patologia, ver_calidad_de_leche, id_tecnico_1, fecha_tecnico, id_usuario_asigno_tecnico, id_tecnico_2, id_tecnico_3, id_tecnico_4, codigofigaro, enviar_informe_por_mail, path_estado_de_cuenta, fecha_modificacion FROM usuarios WHERE Nombre LIKE '%" & pNombre & "%'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductorWeb_uy()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.USUARIO = CType(unaFila.Item(1), String)
                    p.NOMBRE = CType(unaFila.Item(2), String)
                    p.PASSWORD = CType(unaFila.Item(3), String)
                    p.TIPO_USUARIO_ID = CType(unaFila.Item(4), Integer)
                    p.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                    p.DIRECCION = CType(unaFila.Item(6), String)
                    p.TELEFONO_1 = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.EMAIL_1 = CType(unaFila.Item(13), String)
                    p.EMAIL_2 = CType(unaFila.Item(14), String)
                    p.EMAIL_3 = CType(unaFila.Item(15), String)
                    p.ENVIAR_EMAIL = CType(unaFila.Item(16), String)
                    p.ENVIAR_SMS = CType(unaFila.Item(17), String)
                    p.RUT = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.SALDO_PESOS = CType(unaFila.Item(20), Double)
                    p.SALDO_DOLARES = CType(unaFila.Item(21), Double)
                    p.VER_CONTROL_LECHERO = CType(unaFila.Item(22), Integer)
                    p.VER_AGUA = CType(unaFila.Item(23), Integer)
                    p.VER_PAL = CType(unaFila.Item(24), Integer)
                    p.VER_SEROLOGIA = CType(unaFila.Item(25), Integer)
                    p.VER_ANTIBIOGRAMA = CType(unaFila.Item(26), Integer)
                    p.VER_PARASITOLOGIA = CType(unaFila.Item(27), Integer)
                    p.VER_PRODUCTOS_SUBPRODUCTOS = CType(unaFila.Item(28), Integer)
                    p.VER_PATOLOGIA = CType(unaFila.Item(29), Integer)
                    p.VER_CALIDAD_DE_LECHE = CType(unaFila.Item(30), Integer)
                    p.TECNICO_1 = CType(unaFila.Item(31), Long)
                    p.FECHA_TECNICO = CType(unaFila.Item(32), String)
                    p.ID_USUARIO_ASIGNA_TECNICO = CType(unaFila.Item(33), Long)
                    p.TECNICO_2 = CType(unaFila.Item(34), Long)
                    p.TECNICO_3 = CType(unaFila.Item(35), Long)
                    p.TECNICO_4 = CType(unaFila.Item(36), Long)
                    p.CODIGOFIGARO = CType(unaFila.Item(37), String)
                    p.ENVIAR_INFORME_POR_MAIL = CType(unaFila.Item(38), Integer)
                    p.PATH_ESTADO_DE_CUENTA = CType(unaFila.Item(39), String)
                    p.FECHA_MODIFICACION = CType(unaFila.Item(40), String)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function buscarPorUsuario(ByVal texto As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, usuario, nombre, password, tipo_usuario_id, razon_social, direccion, telefono_1, telefono_2, telefono_3, celular_1, celular_2, celular_3, email_1, email_2, email_3, enviar_email, enviar_sms, ruc, dicose, saldo_pesos, saldo_dolares, ver_control_lechero, ver_agua, ver_pal, ver_serologia, ver_antibiograma, ver_parasitologia, ver_productos_subproductos, ver_patologia, ver_calidad_de_leche, id_tecnico_1, fecha_tecnico, id_usuario_asigno_tecnico, id_tecnico_2, id_tecnico_3, id_tecnico_4, codigofigaro, enviar_informe_por_mail, path_estado_de_cuenta, fecha_modificacion FROM usuarios WHERE usuario = '" & texto & "'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductorWeb_uy()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.USUARIO = CType(unaFila.Item(1), String)
                    p.NOMBRE = CType(unaFila.Item(2), String)
                    p.PASSWORD = CType(unaFila.Item(3), String)
                    p.TIPO_USUARIO_ID = CType(unaFila.Item(4), Integer)
                    p.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                    p.DIRECCION = CType(unaFila.Item(6), String)
                    p.TELEFONO_1 = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.EMAIL_1 = CType(unaFila.Item(13), String)
                    p.EMAIL_2 = CType(unaFila.Item(14), String)
                    p.EMAIL_3 = CType(unaFila.Item(15), String)
                    p.ENVIAR_EMAIL = CType(unaFila.Item(16), String)
                    p.ENVIAR_SMS = CType(unaFila.Item(17), String)
                    p.RUT = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.SALDO_PESOS = CType(unaFila.Item(20), Double)
                    p.SALDO_DOLARES = CType(unaFila.Item(21), Double)
                    p.VER_CONTROL_LECHERO = CType(unaFila.Item(22), Integer)
                    p.VER_AGUA = CType(unaFila.Item(23), Integer)
                    p.VER_PAL = CType(unaFila.Item(24), Integer)
                    p.VER_SEROLOGIA = CType(unaFila.Item(25), Integer)
                    p.VER_ANTIBIOGRAMA = CType(unaFila.Item(26), Integer)
                    p.VER_PARASITOLOGIA = CType(unaFila.Item(27), Integer)
                    p.VER_PRODUCTOS_SUBPRODUCTOS = CType(unaFila.Item(28), Integer)
                    p.VER_PATOLOGIA = CType(unaFila.Item(29), Integer)
                    p.VER_CALIDAD_DE_LECHE = CType(unaFila.Item(30), Integer)
                    p.TECNICO_1 = CType(unaFila.Item(31), Long)
                    p.FECHA_TECNICO = CType(unaFila.Item(32), String)
                    p.ID_USUARIO_ASIGNA_TECNICO = CType(unaFila.Item(33), Long)
                    p.TECNICO_2 = CType(unaFila.Item(34), Long)
                    p.TECNICO_3 = CType(unaFila.Item(35), Long)
                    p.TECNICO_4 = CType(unaFila.Item(36), Long)
                    p.CODIGOFIGARO = CType(unaFila.Item(37), String)
                    p.ENVIAR_INFORME_POR_MAIL = CType(unaFila.Item(38), Integer)
                    p.PATH_ESTADO_DE_CUENTA = CType(unaFila.Item(39), String)
                    p.FECHA_MODIFICACION = CType(unaFila.Item(40), String)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, usuario, nombre, password, tipo_usuario_id, razon_social, direccion, telefono_1, telefono_2, telefono_3, celular_1, celular_2, celular_3, email_1, email_2, email_3, enviar_email, enviar_sms, ruc, dicose, saldo_pesos, saldo_dolares, ver_control_lechero, ver_agua, ver_pal, ver_serologia, ver_antibiograma, ver_parasitologia, ver_productos_subproductos, ver_patologia, ver_calidad_de_leche, id_tecnico_1, fecha_tecnico, id_usuario_asigno_tecnico, id_tecnico_2, id_tecnico_3, id_tecnico_4, codigofigaro, enviar_informe_por_mail, path_estado_de_cuenta, fecha_modificacion FROM usuarios order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductorWeb_uy
                    p.ID = CType(unaFila.Item(0), Long)
                    p.USUARIO = CType(unaFila.Item(1), String)
                    p.NOMBRE = CType(unaFila.Item(2), String)
                    p.PASSWORD = CType(unaFila.Item(3), String)
                    p.TIPO_USUARIO_ID = CType(unaFila.Item(4), Integer)
                    p.RAZON_SOCIAL = CType(unaFila.Item(5), String)
                    p.DIRECCION = CType(unaFila.Item(6), String)
                    p.TELEFONO_1 = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.EMAIL_1 = CType(unaFila.Item(13), String)
                    p.EMAIL_2 = CType(unaFila.Item(14), String)
                    p.EMAIL_3 = CType(unaFila.Item(15), String)
                    p.ENVIAR_EMAIL = CType(unaFila.Item(16), String)
                    p.ENVIAR_SMS = CType(unaFila.Item(17), String)
                    p.RUT = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.SALDO_PESOS = CType(unaFila.Item(20), Double)
                    p.SALDO_DOLARES = CType(unaFila.Item(21), Double)
                    p.VER_CONTROL_LECHERO = CType(unaFila.Item(22), Integer)
                    p.VER_AGUA = CType(unaFila.Item(23), Integer)
                    p.VER_PAL = CType(unaFila.Item(24), Integer)
                    p.VER_SEROLOGIA = CType(unaFila.Item(25), Integer)
                    p.VER_ANTIBIOGRAMA = CType(unaFila.Item(26), Integer)
                    p.VER_PARASITOLOGIA = CType(unaFila.Item(27), Integer)
                    p.VER_PRODUCTOS_SUBPRODUCTOS = CType(unaFila.Item(28), Integer)
                    p.VER_PATOLOGIA = CType(unaFila.Item(29), Integer)
                    p.VER_CALIDAD_DE_LECHE = CType(unaFila.Item(30), Integer)
                    p.TECNICO_1 = CType(unaFila.Item(31), Long)
                    p.FECHA_TECNICO = CType(unaFila.Item(32), String)
                    p.ID_USUARIO_ASIGNA_TECNICO = CType(unaFila.Item(33), Long)
                    p.TECNICO_2 = CType(unaFila.Item(34), Long)
                    p.TECNICO_3 = CType(unaFila.Item(35), Long)
                    p.TECNICO_4 = CType(unaFila.Item(36), Long)
                    p.CODIGOFIGARO = CType(unaFila.Item(37), String)
                    p.ENVIAR_INFORME_POR_MAIL = CType(unaFila.Item(38), Integer)
                    p.PATH_ESTADO_DE_CUENTA = CType(unaFila.Item(39), String)
                    p.FECHA_MODIFICACION = CType(unaFila.Item(40), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
