Public Class pUsuario
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim sql As String = "INSERT INTO usuario (nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, entra, sale, entra2, sale2, entra3, sale3, entra4, sale4, entra5, sale5, entra6, sale6, entrac, salec, entrac2, salec2, entrac3, salec3, entrac4, salec4, entrac5, salec5, entrac6, salec6, entrar, saler, entrar2, saler2, entrar3, saler3, entrar4, saler4, entrar5, saler5, entrar6, saler6, email, csalud) VALUES ('" & obj.NOMBRE & "', '" & obj.SEXO & "','" & obj.CI & "'," & obj.TIPOUSUARIO & ", " & obj.SECTOR & ",'" & obj.USUARIO & "', sha1('" & obj.PASSWORD & "'), " & obj.ELIMINADO & ", '" & obj.FOTO & "', " & obj.TIPOMARCA & ", '" & obj.ENTRA & "', '" & obj.SALE & "' , '" & obj.ENTRA2 & "', '" & obj.SALE2 & "' , '" & obj.ENTRA3 & "', '" & obj.SALE3 & "' , '" & obj.ENTRA4 & "', '" & obj.SALE4 & "' , '" & obj.ENTRA5 & "', '" & obj.SALE5 & "' , '" & obj.ENTRA6 & "', '" & obj.SALE6 & "' , '" & obj.ENTRAC & "', '" & obj.SALEC & "' , '" & obj.ENTRAC2 & "', '" & obj.SALEC2 & "' , '" & obj.ENTRAC3 & "', '" & obj.SALEC3 & "' , '" & obj.ENTRAC4 & "', '" & obj.SALEC4 & "' , '" & obj.ENTRAC5 & "', '" & obj.SALEC5 & "' , '" & obj.ENTRAC6 & "', '" & obj.SALEC6 & "' , '" & obj.ENTRAR & "', '" & obj.SALER & "' , '" & obj.ENTRAR2 & "', '" & obj.SALER2 & "' , '" & obj.ENTRAR3 & "', '" & obj.SALER3 & "' , '" & obj.ENTRAR4 & "', '" & obj.SALER4 & "' , '" & obj.ENTRAR5 & "', '" & obj.SALER5 & "' , '" & obj.ENTRAR6 & "', '" & obj.SALER6 & "' , '" & obj.EMAIL & "', '" & obj.CSALUD & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'usuario', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        'Dim sql As String = "UPDATE usuario SET nombre, tipousuario, usuario, password = '" & obj.NOMBRE & "', '" & obj.TIPOUSUARIO & "', '" & obj.USUARIO & "', '" & obj.PASSWORD & "' WHERE id = " & obj.ID
        Dim sql As String = "UPDATE usuario SET nombre ='" & obj.NOMBRE & "',sexo ='" & obj.SEXO & "', ci ='" & obj.CI & "',tipousuario=" & obj.TIPOUSUARIO & ", sector=" & obj.SECTOR & ",usuario ='" & obj.USUARIO & "' , password =  sha1('" & obj.PASSWORD & "'), eliminado =  " & obj.ELIMINADO & ", foto =  '" & obj.FOTO & "', tipomarca =  " & obj.TIPOMARCA & ", entra =  '" & obj.ENTRA & "', sale =  '" & obj.SALE & "', entra2 =  '" & obj.ENTRA2 & "', sale2 =  '" & obj.SALE2 & "', entra3 =  '" & obj.ENTRA3 & "', sale3 =  '" & obj.SALE3 & "', entra4 =  '" & obj.ENTRA4 & "', sale4 =  '" & obj.SALE4 & "', entra5 =  '" & obj.ENTRA5 & "', sale5 =  '" & obj.SALE5 & "', entra6 =  '" & obj.ENTRA6 & "', sale6 =  '" & obj.SALE6 & "', entrac =  '" & obj.ENTRAC & "', salec =  '" & obj.SALEC & "', entrac2 =  '" & obj.ENTRAC2 & "', salec2 =  '" & obj.SALEC2 & "', entrac3 =  '" & obj.ENTRAC3 & "', salec3 =  '" & obj.SALEC3 & "', entrac4 =  '" & obj.ENTRAC4 & "', salec4 =  '" & obj.SALEC4 & "', entrac5 =  '" & obj.ENTRAC5 & "', salec5 =  '" & obj.SALEC5 & "', entrac6 =  '" & obj.ENTRAC6 & "', salec6 =  '" & obj.SALEC6 & "', entrar =  '" & obj.ENTRAR & "', saler =  '" & obj.SALER & "', entrar2 =  '" & obj.ENTRAR2 & "', saler2 =  '" & obj.SALER2 & "', entrar3 =  '" & obj.ENTRAR3 & "', saler3 =  '" & obj.SALER3 & "', entrar4 =  '" & obj.ENTRAR4 & "', saler4 =  '" & obj.SALER4 & "', entrar5 =  '" & obj.ENTRAR5 & "', saler5 =  '" & obj.SALER5 & "', entrar6 =  '" & obj.ENTRAR6 & "', saler6 =  '" & obj.SALER6 & "', email =  '" & obj.EMAIL & "', csalud =  '" & obj.CSALUD & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'usuario', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim sql As String = "INSERT INTO usuario (nombre, sexo, ci, tipousuario, sector, usuario,  eliminado, foto, tipomarca, entra, sale, entra2, sale2, entra3, sale3, entra4, sale4, entra5, sale5, entra6, sale6, entrac, salec, entrac2, salec2, entrac3, salec3, entrac4, salec4, entrac5, salec5, entrac6, salec6, entrar, saler, entrar2, saler2, entrar3, saler3, entrar4, saler4, entrar5, saler5, entrar6, saler6, email, csalud) VALUES ('" & obj.NOMBRE & "', '" & obj.SEXO & "','" & obj.CI & "'," & obj.TIPOUSUARIO & ", " & obj.SECTOR & ",'" & obj.USUARIO & "',  " & obj.ELIMINADO & ", '" & obj.FOTO & "', " & obj.TIPOMARCA & ", '" & obj.ENTRA & "', '" & obj.SALE & "' , '" & obj.ENTRA2 & "', '" & obj.SALE2 & "' , '" & obj.ENTRA3 & "', '" & obj.SALE3 & "' , '" & obj.ENTRA4 & "', '" & obj.SALE4 & "' , '" & obj.ENTRA5 & "', '" & obj.SALE5 & "' , '" & obj.ENTRA6 & "', '" & obj.SALE6 & "' , '" & obj.ENTRAC & "', '" & obj.SALEC & "' , '" & obj.ENTRAC2 & "', '" & obj.SALEC2 & "' , '" & obj.ENTRAC3 & "', '" & obj.SALEC3 & "' , '" & obj.ENTRAC4 & "', '" & obj.SALEC4 & "' , '" & obj.ENTRAC5 & "', '" & obj.SALEC5 & "' , '" & obj.ENTRAC6 & "', '" & obj.SALEC6 & "' , '" & obj.ENTRAR & "', '" & obj.SALER & "' , '" & obj.ENTRAR2 & "', '" & obj.SALER2 & "' , '" & obj.ENTRAR3 & "', '" & obj.SALER3 & "' , '" & obj.ENTRAR4 & "', '" & obj.SALER4 & "' , '" & obj.ENTRAR5 & "', '" & obj.SALER5 & "' , '" & obj.ENTRAR6 & "', '" & obj.SALER6 & "' , '" & obj.EMAIL & "', '" & obj.CSALUD & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'usuario', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        'Dim sql As String = "UPDATE usuario SET nombre, tipousuario, usuario, password = '" & obj.NOMBRE & "', '" & obj.TIPOUSUARIO & "', '" & obj.USUARIO & "', '" & obj.PASSWORD & "' WHERE id = " & obj.ID
        Dim sql As String = "UPDATE usuario SET nombre ='" & obj.NOMBRE & "',sexo ='" & obj.SEXO & "', ci ='" & obj.CI & "',tipousuario=" & obj.TIPOUSUARIO & ", sector=" & obj.SECTOR & ",usuario ='" & obj.USUARIO & "' ,  eliminado =  " & obj.ELIMINADO & ", foto =  '" & obj.FOTO & "', tipomarca =  " & obj.TIPOMARCA & ", entra =  '" & obj.ENTRA & "', sale =  '" & obj.SALE & "', entra2 =  '" & obj.ENTRA2 & "', sale2 =  '" & obj.SALE2 & "', entra3 =  '" & obj.ENTRA3 & "', sale3 =  '" & obj.SALE3 & "', entra4 =  '" & obj.ENTRA4 & "', sale4 =  '" & obj.SALE4 & "', entra5 =  '" & obj.ENTRA5 & "', sale5 =  '" & obj.SALE5 & "', entra6 =  '" & obj.ENTRA6 & "', sale6 =  '" & obj.SALE6 & "', entrac =  '" & obj.ENTRAC & "', salec =  '" & obj.SALEC & "', entrac2 =  '" & obj.ENTRAC2 & "', salec2 =  '" & obj.SALEC2 & "', entrac3 =  '" & obj.ENTRAC3 & "', salec3 =  '" & obj.SALEC3 & "', entrac4 =  '" & obj.ENTRAC4 & "', salec4 =  '" & obj.SALEC4 & "', entrac5 =  '" & obj.ENTRAC5 & "', salec5 =  '" & obj.SALEC5 & "', entrac6 =  '" & obj.ENTRAC6 & "', salec6 =  '" & obj.SALEC6 & "', entrar =  '" & obj.ENTRAR & "', saler =  '" & obj.SALER & "', entrar2 =  '" & obj.ENTRAR2 & "', saler2 =  '" & obj.SALER2 & "', entrar3 =  '" & obj.ENTRAR3 & "', saler3 =  '" & obj.SALER3 & "', entrar4 =  '" & obj.ENTRAR4 & "', saler4 =  '" & obj.SALER4 & "', entrar5 =  '" & obj.ENTRAR5 & "', saler5 =  '" & obj.SALER5 & "', entrar6 =  '" & obj.ENTRAR6 & "', saler6 =  '" & obj.SALER6 & "', email =  '" & obj.EMAIL & "', csalud =  '" & obj.CSALUD & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'usuario', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim sql As String = "DELETE FROM usuario WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'usuario', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dUsuario
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim u As New dUsuario
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                u.ID = CType(unaFila.Item(0), Integer)
                u.NOMBRE = CType(unaFila.Item(1), String)
                u.SEXO = CType(unaFila.Item(2), String)
                u.CI = CType(unaFila.Item(3), String)
                u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                u.SECTOR = CType(unaFila.Item(5), String)
                u.USUARIO = CType(unaFila.Item(6), String)
                u.PASSWORD = CType(unaFila.Item(7), String)
                u.ELIMINADO = CType(unaFila.Item(8), Integer)
                u.FOTO = CType(unaFila.Item(9), String)
                u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                u.ENTRA = CType(unaFila.Item(11), String)
                u.SALE = CType(unaFila.Item(12), String)
                u.ENTRA2 = CType(unaFila.Item(13), String)
                u.SALE2 = CType(unaFila.Item(14), String)
                u.ENTRA3 = CType(unaFila.Item(15), String)
                u.SALE3 = CType(unaFila.Item(16), String)
                u.ENTRA4 = CType(unaFila.Item(17), String)
                u.SALE4 = CType(unaFila.Item(18), String)
                u.ENTRA5 = CType(unaFila.Item(19), String)
                u.SALE5 = CType(unaFila.Item(20), String)
                u.ENTRA6 = CType(unaFila.Item(21), String)
                u.SALE6 = CType(unaFila.Item(22), String)
                u.ENTRAC = CType(unaFila.Item(23), String)
                u.SALEC = CType(unaFila.Item(24), String)
                u.ENTRAC2 = CType(unaFila.Item(25), String)
                u.SALEC2 = CType(unaFila.Item(26), String)
                u.ENTRAC3 = CType(unaFila.Item(27), String)
                u.SALEC3 = CType(unaFila.Item(28), String)
                u.ENTRAC4 = CType(unaFila.Item(29), String)
                u.SALEC4 = CType(unaFila.Item(30), String)
                u.ENTRAC5 = CType(unaFila.Item(31), String)
                u.SALEC5 = CType(unaFila.Item(32), String)
                u.ENTRAC6 = CType(unaFila.Item(33), String)
                u.SALEC6 = CType(unaFila.Item(34), String)
                u.ENTRAR = CType(unaFila.Item(35), String)
                u.SALER = CType(unaFila.Item(36), String)
                u.ENTRAR2 = CType(unaFila.Item(37), String)
                u.SALER2 = CType(unaFila.Item(38), String)
                u.ENTRAR3 = CType(unaFila.Item(39), String)
                u.SALER3 = CType(unaFila.Item(40), String)
                u.ENTRAR4 = CType(unaFila.Item(41), String)
                u.SALER4 = CType(unaFila.Item(42), String)
                u.ENTRAR5 = CType(unaFila.Item(43), String)
                u.SALER5 = CType(unaFila.Item(44), String)
                u.ENTRAR6 = CType(unaFila.Item(45), String)
                u.SALER6 = CType(unaFila.Item(46), String)
                u.EMAIL = CType(unaFila.Item(47), String)
                u.CSALUD = CType(unaFila.Item(48), String)
                Return u
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorNombre(ByVal o As Object) As dUsuario
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim u As New dUsuario
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario WHERE usuario = '" & obj.USUARIO & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                u.ID = CType(unaFila.Item(0), Integer)
                u.NOMBRE = CType(unaFila.Item(1), String)
                u.SEXO = CType(unaFila.Item(2), String)
                u.CI = CType(unaFila.Item(3), String)
                u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                u.SECTOR = CType(unaFila.Item(5), String)
                u.USUARIO = CType(unaFila.Item(6), String)
                u.PASSWORD = CType(unaFila.Item(7), String)
                u.ELIMINADO = CType(unaFila.Item(8), Integer)
                u.FOTO = CType(unaFila.Item(9), String)
                u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                u.ENTRA = CType(unaFila.Item(11), String)
                u.SALE = CType(unaFila.Item(12), String)
                u.ENTRA2 = CType(unaFila.Item(13), String)
                u.SALE2 = CType(unaFila.Item(14), String)
                u.ENTRA3 = CType(unaFila.Item(15), String)
                u.SALE3 = CType(unaFila.Item(16), String)
                u.ENTRA4 = CType(unaFila.Item(17), String)
                u.SALE4 = CType(unaFila.Item(18), String)
                u.ENTRA5 = CType(unaFila.Item(19), String)
                u.SALE5 = CType(unaFila.Item(20), String)
                u.ENTRA6 = CType(unaFila.Item(21), String)
                u.SALE6 = CType(unaFila.Item(22), String)
                u.ENTRAC = CType(unaFila.Item(23), String)
                u.SALEC = CType(unaFila.Item(24), String)
                u.ENTRAC2 = CType(unaFila.Item(25), String)
                u.SALEC2 = CType(unaFila.Item(26), String)
                u.ENTRAC3 = CType(unaFila.Item(27), String)
                u.SALEC3 = CType(unaFila.Item(28), String)
                u.ENTRAC4 = CType(unaFila.Item(29), String)
                u.SALEC4 = CType(unaFila.Item(30), String)
                u.ENTRAC5 = CType(unaFila.Item(31), String)
                u.SALEC5 = CType(unaFila.Item(32), String)
                u.ENTRAC6 = CType(unaFila.Item(33), String)
                u.SALEC6 = CType(unaFila.Item(34), String)
                u.ENTRAR = CType(unaFila.Item(35), String)
                u.SALER = CType(unaFila.Item(36), String)
                u.ENTRAR2 = CType(unaFila.Item(37), String)
                u.SALER2 = CType(unaFila.Item(38), String)
                u.ENTRAR3 = CType(unaFila.Item(39), String)
                u.SALER3 = CType(unaFila.Item(40), String)
                u.ENTRAR4 = CType(unaFila.Item(41), String)
                u.SALER4 = CType(unaFila.Item(42), String)
                u.ENTRAR5 = CType(unaFila.Item(43), String)
                u.SALER5 = CType(unaFila.Item(44), String)
                u.ENTRAR6 = CType(unaFila.Item(45), String)
                u.SALER6 = CType(unaFila.Item(46), String)
                u.EMAIL = CType(unaFila.Item(47), String)
                u.CSALUD = CType(unaFila.Item(48), String)
                Return u
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorPassword(ByVal o As Object) As dUsuario
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim u As New dUsuario
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario WHERE Password = '" & obj.PASSWORD & "' AND eliminado = 0 ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                u.ID = CType(unaFila.Item(0), Integer)
                u.NOMBRE = CType(unaFila.Item(1), String)
                u.SEXO = CType(unaFila.Item(2), String)
                u.CI = CType(unaFila.Item(3), String)
                u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                u.SECTOR = CType(unaFila.Item(5), String)
                u.USUARIO = CType(unaFila.Item(6), String)
                u.PASSWORD = CType(unaFila.Item(7), String)
                u.ELIMINADO = CType(unaFila.Item(8), Integer)
                u.FOTO = CType(unaFila.Item(9), String)
                u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                u.ENTRA = CType(unaFila.Item(11), String)
                u.SALE = CType(unaFila.Item(12), String)
                u.ENTRA2 = CType(unaFila.Item(13), String)
                u.SALE2 = CType(unaFila.Item(14), String)
                u.ENTRA3 = CType(unaFila.Item(15), String)
                u.SALE3 = CType(unaFila.Item(16), String)
                u.ENTRA4 = CType(unaFila.Item(17), String)
                u.SALE4 = CType(unaFila.Item(18), String)
                u.ENTRA5 = CType(unaFila.Item(19), String)
                u.SALE5 = CType(unaFila.Item(20), String)
                u.ENTRA6 = CType(unaFila.Item(21), String)
                u.SALE6 = CType(unaFila.Item(22), String)
                u.ENTRAC = CType(unaFila.Item(23), String)
                u.SALEC = CType(unaFila.Item(24), String)
                u.ENTRAC2 = CType(unaFila.Item(25), String)
                u.SALEC2 = CType(unaFila.Item(26), String)
                u.ENTRAC3 = CType(unaFila.Item(27), String)
                u.SALEC3 = CType(unaFila.Item(28), String)
                u.ENTRAC4 = CType(unaFila.Item(29), String)
                u.SALEC4 = CType(unaFila.Item(30), String)
                u.ENTRAC5 = CType(unaFila.Item(31), String)
                u.SALEC5 = CType(unaFila.Item(32), String)
                u.ENTRAC6 = CType(unaFila.Item(33), String)
                u.SALEC6 = CType(unaFila.Item(34), String)
                u.ENTRAR = CType(unaFila.Item(35), String)
                u.SALER = CType(unaFila.Item(36), String)
                u.ENTRAR2 = CType(unaFila.Item(37), String)
                u.SALER2 = CType(unaFila.Item(38), String)
                u.ENTRAR3 = CType(unaFila.Item(39), String)
                u.SALER3 = CType(unaFila.Item(40), String)
                u.ENTRAR4 = CType(unaFila.Item(41), String)
                u.SALER4 = CType(unaFila.Item(42), String)
                u.ENTRAR5 = CType(unaFila.Item(43), String)
                u.SALER5 = CType(unaFila.Item(44), String)
                u.ENTRAR6 = CType(unaFila.Item(45), String)
                u.SALER6 = CType(unaFila.Item(46), String)
                u.EMAIL = CType(unaFila.Item(47), String)
                u.CSALUD = CType(unaFila.Item(48), String)
                Return u
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPassSupervisores(ByVal o As Object) As ArrayList
        Dim sql As String = "SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario where usuario in ('MCF','DF') order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim u As New dUsuario
                    u.ID = CType(unaFila.Item(0), Integer)
                    u.NOMBRE = CType(unaFila.Item(1), String)
                    u.SEXO = CType(unaFila.Item(2), String)
                    u.CI = CType(unaFila.Item(3), String)
                    u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                    u.SECTOR = CType(unaFila.Item(5), String)
                    u.USUARIO = CType(unaFila.Item(6), String)
                    u.PASSWORD = CType(unaFila.Item(7), String)
                    u.ELIMINADO = CType(unaFila.Item(8), Integer)
                    u.FOTO = CType(unaFila.Item(9), String)
                    u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                    u.ENTRA = CType(unaFila.Item(11), String)
                    u.SALE = CType(unaFila.Item(12), String)
                    u.ENTRA2 = CType(unaFila.Item(13), String)
                    u.SALE2 = CType(unaFila.Item(14), String)
                    u.ENTRA3 = CType(unaFila.Item(15), String)
                    u.SALE3 = CType(unaFila.Item(16), String)
                    u.ENTRA4 = CType(unaFila.Item(17), String)
                    u.SALE4 = CType(unaFila.Item(18), String)
                    u.ENTRA5 = CType(unaFila.Item(19), String)
                    u.SALE5 = CType(unaFila.Item(20), String)
                    u.ENTRA6 = CType(unaFila.Item(21), String)
                    u.SALE6 = CType(unaFila.Item(22), String)
                    u.ENTRAC = CType(unaFila.Item(23), String)
                    u.SALEC = CType(unaFila.Item(24), String)
                    u.ENTRAC2 = CType(unaFila.Item(25), String)
                    u.SALEC2 = CType(unaFila.Item(26), String)
                    u.ENTRAC3 = CType(unaFila.Item(27), String)
                    u.SALEC3 = CType(unaFila.Item(28), String)
                    u.ENTRAC4 = CType(unaFila.Item(29), String)
                    u.SALEC4 = CType(unaFila.Item(30), String)
                    u.ENTRAC5 = CType(unaFila.Item(31), String)
                    u.SALEC5 = CType(unaFila.Item(32), String)
                    u.ENTRAC6 = CType(unaFila.Item(33), String)
                    u.SALEC6 = CType(unaFila.Item(34), String)
                    u.ENTRAR = CType(unaFila.Item(35), String)
                    u.SALER = CType(unaFila.Item(36), String)
                    u.ENTRAR2 = CType(unaFila.Item(37), String)
                    u.SALER2 = CType(unaFila.Item(38), String)
                    u.ENTRAR3 = CType(unaFila.Item(39), String)
                    u.SALER3 = CType(unaFila.Item(40), String)
                    u.ENTRAR4 = CType(unaFila.Item(41), String)
                    u.SALER4 = CType(unaFila.Item(42), String)
                    u.ENTRAR5 = CType(unaFila.Item(43), String)
                    u.SALER5 = CType(unaFila.Item(44), String)
                    u.ENTRAR6 = CType(unaFila.Item(45), String)
                    u.SALER6 = CType(unaFila.Item(46), String)
                    u.EMAIL = CType(unaFila.Item(47), String)
                    u.CSALUD = CType(unaFila.Item(48), String)
                    Lista.Add(u)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario where eliminado=0 order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim u As New dUsuario
                    u.ID = CType(unaFila.Item(0), Integer)
                    u.NOMBRE = CType(unaFila.Item(1), String)
                    u.SEXO = CType(unaFila.Item(2), String)
                    u.CI = CType(unaFila.Item(3), String)
                    u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                    u.SECTOR = CType(unaFila.Item(5), String)
                    u.USUARIO = CType(unaFila.Item(6), String)
                    u.PASSWORD = CType(unaFila.Item(7), String)
                    u.ELIMINADO = CType(unaFila.Item(8), Integer)
                    u.FOTO = CType(unaFila.Item(9), String)
                    u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                    u.ENTRA = CType(unaFila.Item(11), String)
                    u.SALE = CType(unaFila.Item(12), String)
                    u.ENTRA2 = CType(unaFila.Item(13), String)
                    u.SALE2 = CType(unaFila.Item(14), String)
                    u.ENTRA3 = CType(unaFila.Item(15), String)
                    u.SALE3 = CType(unaFila.Item(16), String)
                    u.ENTRA4 = CType(unaFila.Item(17), String)
                    u.SALE4 = CType(unaFila.Item(18), String)
                    u.ENTRA5 = CType(unaFila.Item(19), String)
                    u.SALE5 = CType(unaFila.Item(20), String)
                    u.ENTRA6 = CType(unaFila.Item(21), String)
                    u.SALE6 = CType(unaFila.Item(22), String)
                    u.ENTRAC = CType(unaFila.Item(23), String)
                    u.SALEC = CType(unaFila.Item(24), String)
                    u.ENTRAC2 = CType(unaFila.Item(25), String)
                    u.SALEC2 = CType(unaFila.Item(26), String)
                    u.ENTRAC3 = CType(unaFila.Item(27), String)
                    u.SALEC3 = CType(unaFila.Item(28), String)
                    u.ENTRAC4 = CType(unaFila.Item(29), String)
                    u.SALEC4 = CType(unaFila.Item(30), String)
                    u.ENTRAC5 = CType(unaFila.Item(31), String)
                    u.SALEC5 = CType(unaFila.Item(32), String)
                    u.ENTRAC6 = CType(unaFila.Item(33), String)
                    u.SALEC6 = CType(unaFila.Item(34), String)
                    u.ENTRAR = CType(unaFila.Item(35), String)
                    u.SALER = CType(unaFila.Item(36), String)
                    u.ENTRAR2 = CType(unaFila.Item(37), String)
                    u.SALER2 = CType(unaFila.Item(38), String)
                    u.ENTRAR3 = CType(unaFila.Item(39), String)
                    u.SALER3 = CType(unaFila.Item(40), String)
                    u.ENTRAR4 = CType(unaFila.Item(41), String)
                    u.SALER4 = CType(unaFila.Item(42), String)
                    u.ENTRAR5 = CType(unaFila.Item(43), String)
                    u.SALER5 = CType(unaFila.Item(44), String)
                    u.ENTRAR6 = CType(unaFila.Item(45), String)
                    u.SALER6 = CType(unaFila.Item(46), String)
                    u.EMAIL = CType(unaFila.Item(47), String)
                    u.CSALUD = CType(unaFila.Item(48), String)
                    Lista.Add(u)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar2(ByVal idusu As Integer) As ArrayList
        Dim sql As String = "SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario where id = " & idusu & " and eliminado=0 order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim u As New dUsuario
                    u.ID = CType(unaFila.Item(0), Integer)
                    u.NOMBRE = CType(unaFila.Item(1), String)
                    u.SEXO = CType(unaFila.Item(2), String)
                    u.CI = CType(unaFila.Item(3), String)
                    u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                    u.SECTOR = CType(unaFila.Item(5), String)
                    u.USUARIO = CType(unaFila.Item(6), String)
                    u.PASSWORD = CType(unaFila.Item(7), String)
                    u.ELIMINADO = CType(unaFila.Item(8), Integer)
                    u.FOTO = CType(unaFila.Item(9), String)
                    u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                    u.ENTRA = CType(unaFila.Item(11), String)
                    u.SALE = CType(unaFila.Item(12), String)
                    u.ENTRA2 = CType(unaFila.Item(13), String)
                    u.SALE2 = CType(unaFila.Item(14), String)
                    u.ENTRA3 = CType(unaFila.Item(15), String)
                    u.SALE3 = CType(unaFila.Item(16), String)
                    u.ENTRA4 = CType(unaFila.Item(17), String)
                    u.SALE4 = CType(unaFila.Item(18), String)
                    u.ENTRA5 = CType(unaFila.Item(19), String)
                    u.SALE5 = CType(unaFila.Item(20), String)
                    u.ENTRA6 = CType(unaFila.Item(21), String)
                    u.SALE6 = CType(unaFila.Item(22), String)
                    u.ENTRAC = CType(unaFila.Item(23), String)
                    u.SALEC = CType(unaFila.Item(24), String)
                    u.ENTRAC2 = CType(unaFila.Item(25), String)
                    u.SALEC2 = CType(unaFila.Item(26), String)
                    u.ENTRAC3 = CType(unaFila.Item(27), String)
                    u.SALEC3 = CType(unaFila.Item(28), String)
                    u.ENTRAC4 = CType(unaFila.Item(29), String)
                    u.SALEC4 = CType(unaFila.Item(30), String)
                    u.ENTRAC5 = CType(unaFila.Item(31), String)
                    u.SALEC5 = CType(unaFila.Item(32), String)
                    u.ENTRAC6 = CType(unaFila.Item(33), String)
                    u.SALEC6 = CType(unaFila.Item(34), String)
                    u.ENTRAR = CType(unaFila.Item(35), String)
                    u.SALER = CType(unaFila.Item(36), String)
                    u.ENTRAR2 = CType(unaFila.Item(37), String)
                    u.SALER2 = CType(unaFila.Item(38), String)
                    u.ENTRAR3 = CType(unaFila.Item(39), String)
                    u.SALER3 = CType(unaFila.Item(40), String)
                    u.ENTRAR4 = CType(unaFila.Item(41), String)
                    u.SALER4 = CType(unaFila.Item(42), String)
                    u.ENTRAR5 = CType(unaFila.Item(43), String)
                    u.SALER5 = CType(unaFila.Item(44), String)
                    u.ENTRAR6 = CType(unaFila.Item(45), String)
                    u.SALER6 = CType(unaFila.Item(46), String)
                    u.EMAIL = CType(unaFila.Item(47), String)
                    u.CSALUD = CType(unaFila.Item(48), String)
                    Lista.Add(u)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartodos() As ArrayList
        Dim sql As String = "SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim u As New dUsuario
                    u.ID = CType(unaFila.Item(0), Integer)
                    u.NOMBRE = CType(unaFila.Item(1), String)
                    u.SEXO = CType(unaFila.Item(2), String)
                    u.CI = CType(unaFila.Item(3), String)
                    u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                    u.SECTOR = CType(unaFila.Item(5), String)
                    u.USUARIO = CType(unaFila.Item(6), String)
                    u.PASSWORD = CType(unaFila.Item(7), String)
                    u.ELIMINADO = CType(unaFila.Item(8), Integer)
                    u.FOTO = CType(unaFila.Item(9), String)
                    u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                    u.ENTRA = CType(unaFila.Item(11), String)
                    u.SALE = CType(unaFila.Item(12), String)
                    u.ENTRA2 = CType(unaFila.Item(13), String)
                    u.SALE2 = CType(unaFila.Item(14), String)
                    u.ENTRA3 = CType(unaFila.Item(15), String)
                    u.SALE3 = CType(unaFila.Item(16), String)
                    u.ENTRA4 = CType(unaFila.Item(17), String)
                    u.SALE4 = CType(unaFila.Item(18), String)
                    u.ENTRA5 = CType(unaFila.Item(19), String)
                    u.SALE5 = CType(unaFila.Item(20), String)
                    u.ENTRA6 = CType(unaFila.Item(21), String)
                    u.SALE6 = CType(unaFila.Item(22), String)
                    u.ENTRAC = CType(unaFila.Item(23), String)
                    u.SALEC = CType(unaFila.Item(24), String)
                    u.ENTRAC2 = CType(unaFila.Item(25), String)
                    u.SALEC2 = CType(unaFila.Item(26), String)
                    u.ENTRAC3 = CType(unaFila.Item(27), String)
                    u.SALEC3 = CType(unaFila.Item(28), String)
                    u.ENTRAC4 = CType(unaFila.Item(29), String)
                    u.SALEC4 = CType(unaFila.Item(30), String)
                    u.ENTRAC5 = CType(unaFila.Item(31), String)
                    u.SALEC5 = CType(unaFila.Item(32), String)
                    u.ENTRAC6 = CType(unaFila.Item(33), String)
                    u.SALEC6 = CType(unaFila.Item(34), String)
                    u.ENTRAR = CType(unaFila.Item(35), String)
                    u.SALER = CType(unaFila.Item(36), String)
                    u.ENTRAR2 = CType(unaFila.Item(37), String)
                    u.SALER2 = CType(unaFila.Item(38), String)
                    u.ENTRAR3 = CType(unaFila.Item(39), String)
                    u.SALER3 = CType(unaFila.Item(40), String)
                    u.ENTRAR4 = CType(unaFila.Item(41), String)
                    u.SALER4 = CType(unaFila.Item(42), String)
                    u.ENTRAR5 = CType(unaFila.Item(43), String)
                    u.SALER5 = CType(unaFila.Item(44), String)
                    u.ENTRAR6 = CType(unaFila.Item(45), String)
                    u.SALER6 = CType(unaFila.Item(46), String)
                    u.EMAIL = CType(unaFila.Item(47), String)
                    u.CSALUD = CType(unaFila.Item(48), String)
                    Lista.Add(u)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal usu As Integer) As ArrayList
        Dim sql As String = "SELECT id, nombre, sexo, ci, tipousuario, sector, usuario, password, eliminado, foto, tipomarca, ifnull(entra,''), ifnull(sale,''), ifnull(entra2,''), ifnull(sale2,''), ifnull(entra3,''), ifnull(sale3,''), ifnull(entra4,''), ifnull(sale4,''), ifnull(entra5,''), ifnull(sale5,''), ifnull(entra6,''), ifnull(sale6,''), ifnull(entrac,''), ifnull(salec,''), ifnull(entrac2,''), ifnull(salec2,''), ifnull(entrac3,''), ifnull(salec3,''), ifnull(entrac4,''), ifnull(salec4,''), ifnull(entrac5,''), ifnull(salec5,''), ifnull(entrac6,''), ifnull(salec6,''), ifnull(entrar,''), ifnull(saler,''), ifnull(entrar2,''), ifnull(saler2,''), ifnull(entrar3,''), ifnull(saler3,''), ifnull(entrar4,''), ifnull(saler4,''), ifnull(entrar5,''), ifnull(saler5,''), ifnull(entrar6,''), ifnull(saler6,''), ifnull(email,''), csalud FROM usuario where id= " & usu & " AND eliminado=0 order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim u As New dUsuario
                    u.ID = CType(unaFila.Item(0), Integer)
                    u.NOMBRE = CType(unaFila.Item(1), String)
                    u.SEXO = CType(unaFila.Item(2), String)
                    u.CI = CType(unaFila.Item(3), String)
                    u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                    u.SECTOR = CType(unaFila.Item(5), String)
                    u.USUARIO = CType(unaFila.Item(6), String)
                    u.PASSWORD = CType(unaFila.Item(7), String)
                    u.ELIMINADO = CType(unaFila.Item(8), Integer)
                    u.FOTO = CType(unaFila.Item(9), String)
                    u.TIPOMARCA = CType(unaFila.Item(10), Integer)
                    u.ENTRA = CType(unaFila.Item(11), String)
                    u.SALE = CType(unaFila.Item(12), String)
                    u.ENTRA2 = CType(unaFila.Item(13), String)
                    u.SALE2 = CType(unaFila.Item(14), String)
                    u.ENTRA3 = CType(unaFila.Item(15), String)
                    u.SALE3 = CType(unaFila.Item(16), String)
                    u.ENTRA4 = CType(unaFila.Item(17), String)
                    u.SALE4 = CType(unaFila.Item(18), String)
                    u.ENTRA5 = CType(unaFila.Item(19), String)
                    u.SALE5 = CType(unaFila.Item(20), String)
                    u.ENTRA6 = CType(unaFila.Item(21), String)
                    u.SALE6 = CType(unaFila.Item(22), String)
                    u.ENTRAC = CType(unaFila.Item(23), String)
                    u.SALEC = CType(unaFila.Item(24), String)
                    u.ENTRAC2 = CType(unaFila.Item(25), String)
                    u.SALEC2 = CType(unaFila.Item(26), String)
                    u.ENTRAC3 = CType(unaFila.Item(27), String)
                    u.SALEC3 = CType(unaFila.Item(28), String)
                    u.ENTRAC4 = CType(unaFila.Item(29), String)
                    u.SALEC4 = CType(unaFila.Item(30), String)
                    u.ENTRAC5 = CType(unaFila.Item(31), String)
                    u.SALEC5 = CType(unaFila.Item(32), String)
                    u.ENTRAC6 = CType(unaFila.Item(33), String)
                    u.SALEC6 = CType(unaFila.Item(34), String)
                    u.ENTRAR = CType(unaFila.Item(35), String)
                    u.SALER = CType(unaFila.Item(36), String)
                    u.ENTRAR2 = CType(unaFila.Item(37), String)
                    u.SALER2 = CType(unaFila.Item(38), String)
                    u.ENTRAR3 = CType(unaFila.Item(39), String)
                    u.SALER3 = CType(unaFila.Item(40), String)
                    u.ENTRAR4 = CType(unaFila.Item(41), String)
                    u.SALER4 = CType(unaFila.Item(42), String)
                    u.ENTRAR5 = CType(unaFila.Item(43), String)
                    u.SALER5 = CType(unaFila.Item(44), String)
                    u.ENTRAR6 = CType(unaFila.Item(45), String)
                    u.SALER6 = CType(unaFila.Item(46), String)
                    u.EMAIL = CType(unaFila.Item(47), String)
                    u.CSALUD = CType(unaFila.Item(48), String)
                    Lista.Add(u)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
