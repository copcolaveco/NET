Imports MySql.Data.MySqlClient

Public Class pCliente
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCliente = CType(o, dCliente)
        Dim sql As String = "INSERT INTO cliente (id, nombre, email, nombre_email1, email1, nombre_email2, email2, envio, usuario_web, nombre_celular1, celular, nombre_celular2, celular2, codigofigaro, tipousuario, direccion, nombre_telefono1, telefono1, nombre_telefono2, telefono2, fax, dicose, iddepartamento, idlocalidad, tecnico1, tecnico2, idagencia, contrato, socio, nousar, codbar, caravanas, prolesa, prolesasuc, prolesamat, observaciones, fac_rsocial, fac_cedula, fac_rut, fac_direccion, fac_localidad, fac_departamento, fac_cpostal, fac_giro, cob_nombre_telefono1, fac_telefonos, cob_nombre_telefono2, cob_telefono2, cob_nombre_celular1, cob_celular1, cob_nombre_celular2, cob_celular2, cob_nombre_email1, cob_email1, cob_nombre_email2, cob_email2, fac_fax, fac_email, fac_contacto, fac_observaciones, fac_lista, fac_contado, not_email_frascos1, not_email_frascos2, not_email_muestras1, not_email_muestras2, not_email_analisis1, not_email_analisis2, not_email_general1,  not_email_general2, incobrable, tecnico_suelo_nutri) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', '" & obj.EMAIL & "','" & obj.NOMBRE_EMAIL1 & "','" & obj.EMAIL1 & "', '" & obj.NOMBRE_EMAIL2 & "','" & obj.EMAIL2 & "', '" & obj.ENVIO & "','" & obj.USUARIO_WEB & "','" & obj.NOMBRE_CELULAR1 & "', '" & obj.CELULAR & "', '" & obj.NOMBRE_CELULAR2 & "', '" & obj.CELULAR2 & "', '" & obj.CODIGOFIGARO & "'," & obj.TIPOUSUARIO & ",'" & obj.DIRECCION & "','" & obj.NOMBRE_TELEFONO1 & "','" & obj.TELEFONO1 & "','" & obj.NOMBRE_TELEFONO2 & "','" & obj.TELEFONO2 & "','" & obj.FAX & "','" & obj.DICOSE & "'," & obj.IDDEPARTAMENTO & "," & obj.IDLOCALIDAD & "," & obj.TECNICO1 & "," & obj.TECNICO2 & "," & obj.IDAGENCIA & ", " & obj.CONTRATO & ", " & obj.SOCIO & ", " & obj.NOUSAR & ", " & obj.CODBAR & ", " & obj.CARAVANAS & ", " & obj.PROLESA & "," & obj.PROLESASUC & "," & obj.PROLESAMAT & ", '" & obj.OBSERVACIONES & "', '" & obj.FAC_RSOCIAL & "', '" & obj.FAC_CEDULA & "','" & obj.FAC_RUT & "', '" & obj.FAC_DIRECCION & "', '" & obj.FAC_LOCALIDAD & "', " & obj.FAC_DEPARTAMENTO & ", '" & obj.FAC_CPOSTAL & "', " & obj.FAC_GIRO & ", '" & obj.COB_NOMBRE_TELEFONO1 & "', '" & obj.FAC_TELEFONOS & "','" & obj.COB_NOMBRE_TELEFONO2 & "', '" & obj.COB_TELEFONO2 & "', '" & obj.COB_NOMBRE_CELULAR1 & "', '" & obj.COB_CELULAR1 & "', '" & obj.COB_NOMBRE_CELULAR2 & "', '" & obj.COB_CELULAR2 & "', '" & obj.COB_NOMBRE_EMAIL1 & "', '" & obj.COB_EMAIL1 & "','" & obj.COB_NOMBRE_EMAIL2 & "', '" & obj.COB_EMAIL2 & "','" & obj.FAC_FAX & "', '" & obj.FAC_EMAIL & "', '" & obj.FAC_CONTACTO & "', '" & obj.FAC_OBSERVACIONES & "', " & obj.FAC_LISTA & ", " & obj.FAC_CONTADO & ", '" & obj.NOT_EMAIL_FRASCOS1 & "', '" & obj.NOT_EMAIL_FRASCOS2 & "', '" & obj.NOT_EMAIL_MUESTRAS1 & "', '" & obj.NOT_EMAIL_MUESTRAS2 & "', '" & obj.NOT_EMAIL_ANALISIS1 & "', '" & obj.NOT_EMAIL_ANALISIS2 & "', '" & obj.NOT_EMAIL_GENERAL1 & "', '" & obj.NOT_EMAIL_GENERAL2 & "', " & obj.INCOBRABLE & ", " & obj.TECNICO_SUELO_NUTRI & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cliente', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCliente = CType(o, dCliente)
        Dim sql As String = "UPDATE cliente SET nombre= '" & obj.NOMBRE & "', email= '" & obj.EMAIL & "', nombre_email1='" & obj.NOMBRE_EMAIL1 & "',email1='" & obj.EMAIL1 & "', nombre_email2='" & obj.NOMBRE_EMAIL2 & "',email2='" & obj.EMAIL2 & "', envio='" & obj.ENVIO & "',usuario_web='" & obj.USUARIO_WEB & "',nombre_celular1='" & obj.NOMBRE_CELULAR1 & "', celular= '" & obj.CELULAR & "', nombre_celular2= '" & obj.NOMBRE_CELULAR2 & "', celular2= '" & obj.CELULAR2 & "', codigofigaro= '" & obj.CODIGOFIGARO & "',tipousuario= " & obj.TIPOUSUARIO & ",direccion='" & obj.DIRECCION & "',nombre_telefono1='" & obj.NOMBRE_TELEFONO1 & "',telefono1='" & obj.TELEFONO1 & "',nombre_telefono2='" & obj.NOMBRE_TELEFONO2 & "',telefono2='" & obj.TELEFONO2 & "',fax='" & obj.FAX & "',dicose='" & obj.DICOSE & "',iddepartamento=" & obj.IDDEPARTAMENTO & ",idlocalidad=" & obj.IDLOCALIDAD & ",tecnico1=" & obj.TECNICO1 & ",tecnico2=" & obj.TECNICO2 & ",idagencia=" & obj.IDAGENCIA & ", contrato=" & obj.CONTRATO & ", socio=" & obj.SOCIO & ", nousar=" & obj.NOUSAR & ", codbar=" & obj.CODBAR & ",caravanas=" & obj.CARAVANAS & ", prolesa=" & obj.PROLESA & ",prolesasuc=" & obj.PROLESASUC & ", prolesamat=" & obj.PROLESAMAT & ",observaciones='" & obj.OBSERVACIONES & "', fac_rsocial='" & obj.FAC_RSOCIAL & "', fac_cedula='" & obj.FAC_CEDULA & "',fac_rut='" & obj.FAC_RUT & "', fac_direccion='" & obj.FAC_DIRECCION & "', fac_localidad='" & obj.FAC_LOCALIDAD & "', fac_departamento=" & obj.FAC_DEPARTAMENTO & ", fac_cpostal='" & obj.FAC_CPOSTAL & "', fac_giro=" & obj.FAC_GIRO & ", cob_nombre_telefono1='" & obj.COB_NOMBRE_TELEFONO1 & "', fac_telefonos='" & obj.FAC_TELEFONOS & "',cob_nombre_telefono2='" & obj.COB_NOMBRE_TELEFONO2 & "', cob_telefono2='" & obj.COB_TELEFONO2 & "', cob_nombre_celular1='" & obj.COB_NOMBRE_CELULAR1 & "', cob_celular1='" & obj.COB_CELULAR1 & "', cob_nombre_celular2='" & obj.COB_NOMBRE_CELULAR2 & "', cob_celular2= '" & obj.COB_CELULAR2 & "', cob_nombre_email1='" & obj.COB_NOMBRE_EMAIL1 & "', cob_email1='" & obj.COB_EMAIL1 & "',cob_nombre_email2='" & obj.COB_NOMBRE_EMAIL2 & "', cob_email2='" & obj.COB_EMAIL2 & "',fac_fax='" & obj.FAC_FAX & "', fac_email='" & obj.FAC_EMAIL & "', fac_contacto='" & obj.FAC_CONTACTO & "', fac_observaciones='" & obj.FAC_OBSERVACIONES & "', fac_lista=" & obj.FAC_LISTA & ", fac_contado=" & obj.FAC_CONTADO & ", not_email_frascos1='" & obj.NOT_EMAIL_FRASCOS1 & "', not_email_frascos2= '" & obj.NOT_EMAIL_FRASCOS2 & "', not_email_muestras1='" & obj.NOT_EMAIL_MUESTRAS1 & "', not_email_muestras2='" & obj.NOT_EMAIL_MUESTRAS2 & "', not_email_analisis1='" & obj.NOT_EMAIL_ANALISIS1 & "', not_email_analisis2='" & obj.NOT_EMAIL_ANALISIS2 & "', not_email_general1='" & obj.NOT_EMAIL_GENERAL1 & "', not_email_general2='" & obj.NOT_EMAIL_GENERAL2 & "', incobrable = " & obj.INCOBRABLE & ", tecnico_suelo_nutri = " & obj.TECNICO_SUELO_NUTRI & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cliente', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcaravana(ByVal usuario As dUsuario, ByVal cli As Integer) As Boolean
        Dim lista As New ArrayList
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cliente', 'marcar_caravana', " & cli & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarcaravana(ByVal usuario As dUsuario, ByVal cli As Integer) As Boolean
        Dim lista As New ArrayList
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cliente', 'desmarcar_caravana', " & cli & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCliente = CType(o, dCliente)
        Dim sql As String = "DELETE FROM cliente WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cliente', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCliente
        Dim obj As dCliente = CType(o, dCliente)
        Dim p As New dCliente
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                p.EMAIL1 = CType(unaFila.Item(4), String)
                p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                p.EMAIL2 = CType(unaFila.Item(6), String)
                p.ENVIO = CType(unaFila.Item(7), String)
                p.USUARIO_WEB = CType(unaFila.Item(8), String)
                p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                p.CELULAR = CType(unaFila.Item(10), String)
                p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                p.CELULAR2 = CType(unaFila.Item(12), String)
                p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                p.DIRECCION = CType(unaFila.Item(15), String)
                p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                p.TELEFONO1 = CType(unaFila.Item(17), String)
                p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                p.TELEFONO2 = CType(unaFila.Item(19), String)
                p.FAX = CType(unaFila.Item(20), String)
                p.DICOSE = CType(unaFila.Item(21), String)
                p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                p.TECNICO1 = CType(unaFila.Item(24), Long)
                p.TECNICO2 = CType(unaFila.Item(25), Long)
                p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                p.CONTRATO = CType(unaFila.Item(27), Integer)
                p.SOCIO = CType(unaFila.Item(28), Integer)
                p.NOUSAR = CType(unaFila.Item(29), Integer)
                p.CODBAR = CType(unaFila.Item(30), Integer)
                p.CARAVANAS = CType(unaFila.Item(31), Integer)
                p.PROLESA = CType(unaFila.Item(32), Integer)
                p.PROLESASUC = CType(unaFila.Item(33), Integer)
                p.PROLESAMAT = CType(unaFila.Item(34), Long)
                p.OBSERVACIONES = CType(unaFila.Item(35), String)
                p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                p.FAC_CEDULA = CType(unaFila.Item(37), String)
                p.FAC_RUT = CType(unaFila.Item(38), String)
                p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                p.FAC_FAX = CType(unaFila.Item(56), String)
                p.FAC_EMAIL = CType(unaFila.Item(57), String)
                p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dCliente
        Dim obj As dCliente = CType(o, dCliente)
        Dim p As New dCliente
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE id = (SELECT MAX(id) FROM cliente)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                p.EMAIL1 = CType(unaFila.Item(4), String)
                p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                p.EMAIL2 = CType(unaFila.Item(6), String)
                p.ENVIO = CType(unaFila.Item(7), String)
                p.USUARIO_WEB = CType(unaFila.Item(8), String)
                p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                p.CELULAR = CType(unaFila.Item(10), String)
                p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                p.CELULAR2 = CType(unaFila.Item(12), String)
                p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                p.DIRECCION = CType(unaFila.Item(15), String)
                p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                p.TELEFONO1 = CType(unaFila.Item(17), String)
                p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                p.TELEFONO2 = CType(unaFila.Item(19), String)
                p.FAX = CType(unaFila.Item(20), String)
                p.DICOSE = CType(unaFila.Item(21), String)
                p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                p.TECNICO1 = CType(unaFila.Item(24), Long)
                p.TECNICO2 = CType(unaFila.Item(25), Long)
                p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                p.CONTRATO = CType(unaFila.Item(27), Integer)
                p.SOCIO = CType(unaFila.Item(28), Integer)
                p.NOUSAR = CType(unaFila.Item(29), Integer)
                p.CODBAR = CType(unaFila.Item(30), Integer)
                p.CARAVANAS = CType(unaFila.Item(31), Integer)
                p.PROLESA = CType(unaFila.Item(32), Integer)
                p.PROLESASUC = CType(unaFila.Item(33), Integer)
                p.PROLESAMAT = CType(unaFila.Item(34), Long)
                p.OBSERVACIONES = CType(unaFila.Item(35), String)
                p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                p.FAC_CEDULA = CType(unaFila.Item(37), String)
                p.FAC_RUT = CType(unaFila.Item(38), String)
                p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                p.FAC_FAX = CType(unaFila.Item(56), String)
                p.FAC_EMAIL = CType(unaFila.Item(57), String)
                p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxCodigoFigaro(ByVal o As Object) As dCliente
        Dim obj As dCliente = CType(o, dCliente)
        Dim p As New dCliente
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE codigofigaro = '" & obj.CODIGOFIGARO & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                p.EMAIL1 = CType(unaFila.Item(4), String)
                p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                p.EMAIL2 = CType(unaFila.Item(6), String)
                p.ENVIO = CType(unaFila.Item(7), String)
                p.USUARIO_WEB = CType(unaFila.Item(8), String)
                p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                p.CELULAR = CType(unaFila.Item(10), String)
                p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                p.CELULAR2 = CType(unaFila.Item(12), String)
                p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                p.DIRECCION = CType(unaFila.Item(15), String)
                p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                p.TELEFONO1 = CType(unaFila.Item(17), String)
                p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                p.TELEFONO2 = CType(unaFila.Item(19), String)
                p.FAX = CType(unaFila.Item(20), String)
                p.DICOSE = CType(unaFila.Item(21), String)
                p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                p.TECNICO1 = CType(unaFila.Item(24), Long)
                p.TECNICO2 = CType(unaFila.Item(25), Long)
                p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                p.CONTRATO = CType(unaFila.Item(27), Integer)
                p.SOCIO = CType(unaFila.Item(28), Integer)
                p.NOUSAR = CType(unaFila.Item(29), Integer)
                p.CODBAR = CType(unaFila.Item(30), Integer)
                p.CARAVANAS = CType(unaFila.Item(31), Integer)
                p.PROLESA = CType(unaFila.Item(32), Integer)
                p.PROLESASUC = CType(unaFila.Item(33), Integer)
                p.PROLESAMAT = CType(unaFila.Item(34), Long)
                p.OBSERVACIONES = CType(unaFila.Item(35), String)
                p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                p.FAC_CEDULA = CType(unaFila.Item(37), String)
                p.FAC_RUT = CType(unaFila.Item(38), String)
                p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                p.FAC_FAX = CType(unaFila.Item(56), String)
                p.FAC_EMAIL = CType(unaFila.Item(57), String)
                p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorUsuarioWeb(ByVal o As Object) As dCliente
        Dim obj As dCliente = CType(o, dCliente)
        Dim p As New dCliente
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE usuario_web = '" & obj.USUARIO_WEB & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                p.EMAIL1 = CType(unaFila.Item(4), String)
                p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                p.EMAIL2 = CType(unaFila.Item(6), String)
                p.ENVIO = CType(unaFila.Item(7), String)
                p.USUARIO_WEB = CType(unaFila.Item(8), String)
                p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                p.CELULAR = CType(unaFila.Item(10), String)
                p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                p.CELULAR2 = CType(unaFila.Item(12), String)
                p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                p.DIRECCION = CType(unaFila.Item(15), String)
                p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                p.TELEFONO1 = CType(unaFila.Item(17), String)
                p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                p.TELEFONO2 = CType(unaFila.Item(19), String)
                p.FAX = CType(unaFila.Item(20), String)
                p.DICOSE = CType(unaFila.Item(21), String)
                p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                p.TECNICO1 = CType(unaFila.Item(24), Long)
                p.TECNICO2 = CType(unaFila.Item(25), Long)
                p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                p.CONTRATO = CType(unaFila.Item(27), Integer)
                p.SOCIO = CType(unaFila.Item(28), Integer)
                p.NOUSAR = CType(unaFila.Item(29), Integer)
                p.CODBAR = CType(unaFila.Item(30), Integer)
                p.CARAVANAS = CType(unaFila.Item(31), Integer)
                p.PROLESA = CType(unaFila.Item(32), Integer)
                p.PROLESASUC = CType(unaFila.Item(33), Integer)
                p.PROLESAMAT = CType(unaFila.Item(34), Long)
                p.OBSERVACIONES = CType(unaFila.Item(35), String)
                p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                p.FAC_CEDULA = CType(unaFila.Item(37), String)
                p.FAC_RUT = CType(unaFila.Item(38), String)
                p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                p.FAC_FAX = CType(unaFila.Item(56), String)
                p.FAC_EMAIL = CType(unaFila.Item(57), String)
                p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE nousar= 0 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxid() As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE nousar= 0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxtecnico(ByVal id As Long) As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE tecnico1= " & id & " or tecnico2= " & id & " and nousar= 0 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxdepartamento(ByVal iddepto As Integer) As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE iddepartamento= " & iddepto & "  and nousar= 0 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartodos() As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsocios() As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente where socio = 1 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarempresa() As ArrayList
        Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE tipousuario = 2 AND nousar = 0 order by Nombre asc"

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorNombreTodos(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE Nombre LIKE '%" & pNombre & "%'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dCliente()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function

    Public Function buscarPorNombreBasico(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim nombreEscapado As String = pNombre.Replace("'", "''")
            Dim sql As String = "SELECT id, nombre FROM cliente WHERE nombre LIKE '%" & nombreEscapado & "%' AND nousar = 0 LIMIT 50"
            Ds = Me.EjecutarSQL(sql)

            If Ds IsNot Nothing AndAlso Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dCliente
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    listaResultado.Add(p)
                Next
            End If

        Catch ex As Exception
            ' Manejo básico de errores
        End Try

        Return listaResultado
    End Function



    Public Function buscarPorNombre(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE Nombre LIKE '%" & pNombre & "%' AND nousar =0"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dCliente()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function

    Public Function buscarPorDicose(ByVal pDicose As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE Dicose LIKE '%" & pDicose & "%' AND nousar =0"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dCliente()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function

    Public Function buscarPorNombreEmpresa(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE Nombre LIKE '%" & pNombre & "%' AND tipousuario = 2 AND nousar= 0"
            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dCliente()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function buscarPorId(ByVal pId As Long) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE id = pId"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dCliente()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    p.EMAIL1 = CType(unaFila.Item(4), String)
                    p.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    p.EMAIL2 = CType(unaFila.Item(6), String)
                    p.ENVIO = CType(unaFila.Item(7), String)
                    p.USUARIO_WEB = CType(unaFila.Item(8), String)
                    p.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    p.CELULAR = CType(unaFila.Item(10), String)
                    p.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    p.CELULAR2 = CType(unaFila.Item(12), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    p.DIRECCION = CType(unaFila.Item(15), String)
                    p.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    p.TELEFONO1 = CType(unaFila.Item(17), String)
                    p.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    p.TELEFONO2 = CType(unaFila.Item(19), String)
                    p.FAX = CType(unaFila.Item(20), String)
                    p.DICOSE = CType(unaFila.Item(21), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    p.TECNICO1 = CType(unaFila.Item(24), Long)
                    p.TECNICO2 = CType(unaFila.Item(25), Long)
                    p.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    p.CONTRATO = CType(unaFila.Item(27), Integer)
                    p.SOCIO = CType(unaFila.Item(28), Integer)
                    p.NOUSAR = CType(unaFila.Item(29), Integer)
                    p.CODBAR = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.PROLESASUC = CType(unaFila.Item(33), Integer)
                    p.PROLESAMAT = CType(unaFila.Item(34), Long)
                    p.OBSERVACIONES = CType(unaFila.Item(35), String)
                    p.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    p.FAC_CEDULA = CType(unaFila.Item(37), String)
                    p.FAC_RUT = CType(unaFila.Item(38), String)
                    p.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    p.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    p.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    p.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    p.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    p.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    p.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    p.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    p.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    p.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    p.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    p.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    p.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    p.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    p.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    p.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    p.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    p.FAC_FAX = CType(unaFila.Item(56), String)
                    p.FAC_EMAIL = CType(unaFila.Item(57), String)
                    p.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    p.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    p.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    p.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    p.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    p.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    p.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    p.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    p.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    p.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    p.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    p.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    p.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    p.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function

    Public Function buscarPorId2(ByVal pId As Long) As dCliente
        Dim cliente As New dCliente

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, nombre, ifnull(email,''), ifnull(nombre_email1,''), ifnull(email1,''), ifnull(nombre_email2,''), ifnull(email2,''), ifnull(envio,''), ifnull(usuario_web,''), ifnull(nombre_celular1,''), ifnull(celular,''), ifnull(nombre_celular2,''), ifnull(celular2,''), ifnull(codigofigaro,''), ifnull(tipousuario,1), ifnull(direccion,''), ifnull(nombre_telefono1,''), ifnull(telefono1,''), ifnull(nombre_telefono2,''), ifnull(telefono2,''), ifnull(fax,''), ifnull(dicose,''), ifnull(iddepartamento,999), ifnull(idlocalidad,999), ifnull(tecnico1,3197), ifnull(tecnico2,3197), ifnull(idagencia,8), contrato, socio, nousar, codbar, caravanas, prolesa, ifnull(prolesasuc,0), prolesamat, ifnull(observaciones,''), ifnull(fac_rsocial,''), ifnull(fac_cedula,''), ifnull(fac_rut,''), ifnull(fac_direccion,''), ifnull(fac_localidad,''), ifnull(fac_departamento,0), ifnull(fac_cpostal,''), ifnull(fac_giro,0), ifnull(cob_nombre_telefono1,''), ifnull(fac_telefonos,''), ifnull(cob_nombre_telefono2,''), ifnull(cob_telefono2,''), ifnull(cob_nombre_celular1,''), ifnull(cob_celular1,''), ifnull(cob_nombre_celular2,''), ifnull(cob_celular2,''), ifnull(cob_nombre_email1,''), ifnull(cob_email1,''), ifnull(cob_nombre_email2,''), ifnull(cob_email2,''), ifnull(fac_fax,''), ifnull(fac_email,''), ifnull(fac_contacto,''), ifnull(fac_observaciones,''), fac_lista, fac_contado, ifnull(not_email_frascos1,''), ifnull(not_email_frascos2,''), ifnull(not_email_muestras1,''), ifnull(not_email_muestras2,''), ifnull(not_email_analisis1,''), ifnull(not_email_analisis2,''), ifnull(not_email_general1,''), ifnull(not_email_general2,''), incobrable, tecnico_suelo_nutri FROM cliente WHERE id = " & pId & ""

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows

                    cliente.ID = CType(unaFila.Item(0), Long)
                    cliente.NOMBRE = CType(unaFila.Item(1), String)
                    cliente.EMAIL = CType(unaFila.Item(2), String)
                    cliente.NOMBRE_EMAIL1 = CType(unaFila.Item(3), String)
                    cliente.EMAIL1 = CType(unaFila.Item(4), String)
                    cliente.NOMBRE_EMAIL2 = CType(unaFila.Item(5), String)
                    cliente.EMAIL2 = CType(unaFila.Item(6), String)
                    cliente.ENVIO = CType(unaFila.Item(7), String)
                    cliente.USUARIO_WEB = CType(unaFila.Item(8), String)
                    cliente.NOMBRE_CELULAR1 = CType(unaFila.Item(9), String)
                    cliente.CELULAR = CType(unaFila.Item(10), String)
                    cliente.NOMBRE_CELULAR2 = CType(unaFila.Item(11), String)
                    cliente.CELULAR2 = CType(unaFila.Item(12), String)
                    cliente.CODIGOFIGARO = CType(unaFila.Item(13), String)
                    cliente.TIPOUSUARIO = CType(unaFila.Item(14), Integer)
                    cliente.DIRECCION = CType(unaFila.Item(15), String)
                    cliente.NOMBRE_TELEFONO1 = CType(unaFila.Item(16), String)
                    cliente.TELEFONO1 = CType(unaFila.Item(17), String)
                    cliente.NOMBRE_TELEFONO2 = CType(unaFila.Item(18), String)
                    cliente.TELEFONO2 = CType(unaFila.Item(19), String)
                    cliente.FAX = CType(unaFila.Item(20), String)
                    cliente.DICOSE = CType(unaFila.Item(21), String)
                    cliente.IDDEPARTAMENTO = CType(unaFila.Item(22), Integer)
                    cliente.IDLOCALIDAD = CType(unaFila.Item(23), Integer)
                    cliente.TECNICO1 = CType(unaFila.Item(24), Long)
                    cliente.TECNICO2 = CType(unaFila.Item(25), Long)
                    cliente.IDAGENCIA = CType(unaFila.Item(26), Integer)
                    cliente.CONTRATO = CType(unaFila.Item(27), Integer)
                    cliente.SOCIO = CType(unaFila.Item(28), Integer)
                    cliente.NOUSAR = CType(unaFila.Item(29), Integer)
                    cliente.CODBAR = CType(unaFila.Item(30), Integer)
                    cliente.CARAVANAS = CType(unaFila.Item(31), Integer)
                    cliente.PROLESA = CType(unaFila.Item(32), Integer)
                    cliente.PROLESASUC = CType(unaFila.Item(33), Integer)
                    cliente.PROLESAMAT = CType(unaFila.Item(34), Long)
                    cliente.OBSERVACIONES = CType(unaFila.Item(35), String)
                    cliente.FAC_RSOCIAL = CType(unaFila.Item(36), String)
                    cliente.FAC_CEDULA = CType(unaFila.Item(37), String)
                    cliente.FAC_RUT = CType(unaFila.Item(38), String)
                    cliente.FAC_DIRECCION = CType(unaFila.Item(39), String)
                    cliente.FAC_LOCALIDAD = CType(unaFila.Item(40), String)
                    cliente.FAC_DEPARTAMENTO = CType(unaFila.Item(41), Integer)
                    cliente.FAC_CPOSTAL = CType(unaFila.Item(42), String)
                    cliente.FAC_GIRO = CType(unaFila.Item(43), Integer)
                    cliente.COB_NOMBRE_TELEFONO1 = CType(unaFila.Item(44), String)
                    cliente.FAC_TELEFONOS = CType(unaFila.Item(45), String)
                    cliente.COB_NOMBRE_TELEFONO2 = CType(unaFila.Item(46), String)
                    cliente.COB_TELEFONO2 = CType(unaFila.Item(47), String)
                    cliente.COB_NOMBRE_CELULAR1 = CType(unaFila.Item(48), String)
                    cliente.COB_CELULAR1 = CType(unaFila.Item(49), String)
                    cliente.COB_NOMBRE_CELULAR2 = CType(unaFila.Item(50), String)
                    cliente.COB_CELULAR2 = CType(unaFila.Item(51), String)
                    cliente.COB_NOMBRE_EMAIL1 = CType(unaFila.Item(52), String)
                    cliente.COB_EMAIL1 = CType(unaFila.Item(53), String)
                    cliente.COB_NOMBRE_EMAIL2 = CType(unaFila.Item(54), String)
                    cliente.COB_EMAIL2 = CType(unaFila.Item(55), String)
                    cliente.FAC_FAX = CType(unaFila.Item(56), String)
                    cliente.FAC_EMAIL = CType(unaFila.Item(57), String)
                    cliente.FAC_CONTACTO = CType(unaFila.Item(58), String)
                    cliente.FAC_OBSERVACIONES = CType(unaFila.Item(59), String)
                    cliente.FAC_LISTA = CType(unaFila.Item(60), Integer)
                    cliente.FAC_CONTADO = CType(unaFila.Item(61), Integer)
                    cliente.NOT_EMAIL_FRASCOS1 = CType(unaFila.Item(62), String)
                    cliente.NOT_EMAIL_FRASCOS2 = CType(unaFila.Item(63), String)
                    cliente.NOT_EMAIL_MUESTRAS1 = CType(unaFila.Item(64), String)
                    cliente.NOT_EMAIL_MUESTRAS2 = CType(unaFila.Item(65), String)
                    cliente.NOT_EMAIL_ANALISIS1 = CType(unaFila.Item(66), String)
                    cliente.NOT_EMAIL_ANALISIS2 = CType(unaFila.Item(67), String)
                    cliente.NOT_EMAIL_GENERAL1 = CType(unaFila.Item(68), String)
                    cliente.NOT_EMAIL_GENERAL2 = CType(unaFila.Item(69), String)
                    cliente.INCOBRABLE = CType(unaFila.Item(70), Integer)
                    cliente.TECNICO_SUELO_NUTRI = CType(unaFila.Item(71), Integer)

                Next
                Return cliente
            End If
            Return cliente
        Catch ex As Exception
            Return cliente
        End Try
    End Function


    Public Function actualizardireccion(ByVal idcliente As Integer, ByVal direnvio As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE cliente SET envio = '" & direnvio & "' WHERE id = " & idcliente

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar dirección', " & idcliente & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function actualizartecnico1(ByVal idcliente As Integer, ByVal tec As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE cliente SET tecnico1 = '" & tec & "' WHERE id = " & idcliente & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar tecnico 1', " & idcliente & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizartecnico2(ByVal idcliente As Integer, ByVal tec2 As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE cliente SET tecnico2 = '" & tec2 & "' WHERE id = " & idcliente & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar tecnico 2', " & idcliente & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizaragencia(ByVal idcliente As Integer, ByVal age As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE cliente SET idagencia = '" & age & "' WHERE id = " & idcliente

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar teléfono', " & idcliente & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function actualizardicose(ByVal idcliente As Integer, ByVal dicose As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE cliente SET dicose = '" & dicose & "' WHERE id = " & idcliente

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar dicose', " & idcliente & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function actualizarTecnicoSueloNutri(ByVal idcliente As Integer, ByVal tecnicoSueloNutri As Integer) As Boolean
        Dim sql As String = "UPDATE cliente SET tecnico_suelo_nutri = '" & tecnicoSueloNutri & "' WHERE id = " & idcliente

        Dim lista As New ArrayList : lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function


End Class
