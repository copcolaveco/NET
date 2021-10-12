Public Class pProductor
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductor = CType(o, dProductor)
        Dim sql As String = "INSERT INTO productor (ID, Nombre, Email1, Email2, Email3, Envio, usuario_web, Razon_social, Telefono_2, Telefono_3, Celular_1, Celular_2, Celular_3, RUC, CodigoFigaro, TipoUsuario, Direccion, Telefono, Fax, DICOSE, IDDepartamento, IDLocalidad, Tecnico, tecnico2, tecnico3, idagencia, contrato, socio, nousar, moroso, contado, caravanas, prolesa, observaciones) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', '" & obj.EMAIL1 & "','" & obj.EMAIL2 & "','" & obj.EMAIL3 & "', '" & obj.ENVIO & "','" & obj.USUARIO_WEB & "','" & obj.RAZON_SOCIAL & "','" & obj.TELEFONO_2 & "','" & obj.TELEFONO_3 & "','" & obj.CELULAR_1 & "', '" & obj.CELULAR_2 & "','" & obj.CELULAR_3 & "','" & obj.RUT & "','" & obj.CODIGOFIGARO & "'," & obj.TIPOUSUARIO & ",'" & obj.DIRECCION & "','" & obj.TELEFONO & "','" & obj.FAX & "','" & obj.DICOSE & "'," & obj.IDDEPARTAMENTO & "," & obj.IDLOCALIDAD & "," & obj.TECNICO & "," & obj.TECNICO2 & "," & obj.TECNICO3 & "," & obj.IDAGENCIA & ", " & obj.CONTRATO & ", " & obj.SOCIO & ", " & obj.NOUSAR & ", " & obj.MOROSO & ", " & obj.CONTADO & ", " & obj.CARAVANAS & ", " & obj.PROLESA & ", '" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productor', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductor = CType(o, dProductor)
        Dim sql As String = "UPDATE productor SET Nombre ='" & obj.NOMBRE & "',Email1 ='" & obj.EMAIL1 & "',Email2 ='" & obj.EMAIL2 & "',Email3 ='" & obj.EMAIL3 & "',Envio ='" & obj.ENVIO & "',usuario_web ='" & obj.USUARIO_WEB & "',Razon_social ='" & obj.RAZON_SOCIAL & "', Telefono_2 ='" & obj.TELEFONO_2 & "', Telefono_3='" & obj.TELEFONO_3 & "', Celular_1 ='" & obj.CELULAR_1 & "', Celular_2 =  '" & obj.CELULAR_2 & "', Celular_3 ='" & obj.CELULAR_3 & "', RUC ='" & obj.RUT & "', CodigoFigaro ='" & obj.CODIGOFIGARO & "', TipoUsuario =" & obj.TIPOUSUARIO & ", Direccion ='" & obj.DIRECCION & "', Telefono ='" & obj.TELEFONO & "', Fax ='" & obj.FAX & "', DICOSE ='" & obj.DICOSE & "', IDDepartamento =" & obj.IDDEPARTAMENTO & ", IDLocalidad =" & obj.IDLOCALIDAD & ", Tecnico =" & obj.TECNICO & ", tecnico2 =" & obj.TECNICO2 & ", tecnico3 =" & obj.TECNICO3 & ", idagencia=" & obj.IDAGENCIA & ", contrato=" & obj.CONTRATO & ", socio=" & obj.SOCIO & ", nousar=" & obj.NOUSAR & ", moroso=" & obj.MOROSO & ", contado=" & obj.CONTADO & ", caravanas=" & obj.CARAVANAS & ", prolesa=" & obj.PROLESA & ", observaciones='" & obj.OBSERVACIONES & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productor', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductor = CType(o, dProductor)
        Dim sql As String = "DELETE FROM productor WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productor', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dProductor
        Dim obj As dProductor = CType(o, dProductor)
        Dim p As New dProductor
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE ID = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.EMAIL1 = CType(unaFila.Item(2), String)
                p.EMAIL2 = CType(unaFila.Item(3), String)
                p.EMAIL3 = CType(unaFila.Item(4), String)
                p.ENVIO = CType(unaFila.Item(5), String)
                p.USUARIO_WEB = CType(unaFila.Item(6), String)
                p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                p.TELEFONO_2 = CType(unaFila.Item(8), String)
                p.TELEFONO_3 = CType(unaFila.Item(9), String)
                p.CELULAR_1 = CType(unaFila.Item(10), String)
                p.CELULAR_2 = CType(unaFila.Item(11), String)
                p.CELULAR_3 = CType(unaFila.Item(12), String)
                p.RUT = CType(unaFila.Item(13), String)
                p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                p.DIRECCION = CType(unaFila.Item(16), String)
                p.TELEFONO = CType(unaFila.Item(17), String)
                p.FAX = CType(unaFila.Item(18), String)
                p.DICOSE = CType(unaFila.Item(19), String)
                p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                p.TECNICO = CType(unaFila.Item(22), String)
                p.TECNICO2 = CType(unaFila.Item(23), String)
                p.TECNICO3 = CType(unaFila.Item(24), String)
                p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                p.CONTRATO = CType(unaFila.Item(26), Integer)
                p.SOCIO = CType(unaFila.Item(27), Integer)
                p.NOUSAR = CType(unaFila.Item(28), Integer)
                p.MOROSO = CType(unaFila.Item(29), Integer)
                p.CONTADO = CType(unaFila.Item(30), Integer)
                p.CARAVANAS = CType(unaFila.Item(31), Integer)
                p.PROLESA = CType(unaFila.Item(32), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(33), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorUsuarioWeb(ByVal o As Object) As dProductor
        Dim obj As dProductor = CType(o, dProductor)
        Dim p As New dProductor
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE usuario_web = '" & obj.USUARIO_WEB & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.EMAIL1 = CType(unaFila.Item(2), String)
                p.EMAIL2 = CType(unaFila.Item(3), String)
                p.EMAIL3 = CType(unaFila.Item(4), String)
                p.ENVIO = CType(unaFila.Item(5), String)
                p.USUARIO_WEB = CType(unaFila.Item(6), String)
                p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                p.TELEFONO_2 = CType(unaFila.Item(8), String)
                p.TELEFONO_3 = CType(unaFila.Item(9), String)
                p.CELULAR_1 = CType(unaFila.Item(10), String)
                p.CELULAR_2 = CType(unaFila.Item(11), String)
                p.CELULAR_3 = CType(unaFila.Item(12), String)
                p.RUT = CType(unaFila.Item(13), String)
                p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                p.DIRECCION = CType(unaFila.Item(16), String)
                p.TELEFONO = CType(unaFila.Item(17), String)
                p.FAX = CType(unaFila.Item(18), String)
                p.DICOSE = CType(unaFila.Item(19), String)
                p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                p.TECNICO = CType(unaFila.Item(22), String)
                p.TECNICO2 = CType(unaFila.Item(23), String)
                p.TECNICO3 = CType(unaFila.Item(24), String)
                p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                p.CONTRATO = CType(unaFila.Item(26), Integer)
                p.SOCIO = CType(unaFila.Item(27), Integer)
                p.NOUSAR = CType(unaFila.Item(28), Integer)
                p.MOROSO = CType(unaFila.Item(29), Integer)
                p.CONTADO = CType(unaFila.Item(30), Integer)
                p.CARAVANAS = CType(unaFila.Item(31), Integer)
                p.PROLESA = CType(unaFila.Item(32), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(33), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE nousar= 0 and id between 6501 and 7000 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductor
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxtecnico(ByVal id As Long) As ArrayList
        Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE tecnico= " & id & " or tecnico2= " & id & " or tecnico3= " & id & " and nousar= 0 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductor
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxdepartamento(ByVal iddepto As Integer) As ArrayList
        Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE iddepartamento= " & iddepto & "  and nousar= 0 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductor
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartodos() As ArrayList
        Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductor
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarempresa() As ArrayList
        Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE tipousuario = 2 AND nousar = 0 order by Nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductor
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
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
            Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE Nombre LIKE '%" & pNombre & "%'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductor()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function buscarPorNombre(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE Nombre LIKE '%" & pNombre & "%' AND nousar =0"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductor()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
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
            Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE Nombre LIKE '%" & pNombre & "%' AND tipousuario = 2 AND nousar= 0"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductor()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
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
            Dim sql As String = "SELECT ID, Nombre, ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,3282),ifnull(tecnico2,3282),ifnull(tecnico3,3282), ifnull(idagencia,8), contrato, socio, nousar, moroso, contado, caravanas, prolesa, ifnull(observaciones,'') FROM productor WHERE id = pId"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductor()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.EMAIL1 = CType(unaFila.Item(2), String)
                    p.EMAIL2 = CType(unaFila.Item(3), String)
                    p.EMAIL3 = CType(unaFila.Item(4), String)
                    p.ENVIO = CType(unaFila.Item(5), String)
                    p.USUARIO_WEB = CType(unaFila.Item(6), String)
                    p.RAZON_SOCIAL = CType(unaFila.Item(7), String)
                    p.TELEFONO_2 = CType(unaFila.Item(8), String)
                    p.TELEFONO_3 = CType(unaFila.Item(9), String)
                    p.CELULAR_1 = CType(unaFila.Item(10), String)
                    p.CELULAR_2 = CType(unaFila.Item(11), String)
                    p.CELULAR_3 = CType(unaFila.Item(12), String)
                    p.RUT = CType(unaFila.Item(13), String)
                    p.CODIGOFIGARO = CType(unaFila.Item(14), String)
                    p.TIPOUSUARIO = CType(unaFila.Item(15), Integer)
                    p.DIRECCION = CType(unaFila.Item(16), String)
                    p.TELEFONO = CType(unaFila.Item(17), String)
                    p.FAX = CType(unaFila.Item(18), String)
                    p.DICOSE = CType(unaFila.Item(19), String)
                    p.IDDEPARTAMENTO = CType(unaFila.Item(20), Integer)
                    p.IDLOCALIDAD = CType(unaFila.Item(21), Integer)
                    p.TECNICO = CType(unaFila.Item(22), String)
                    p.TECNICO2 = CType(unaFila.Item(23), String)
                    p.TECNICO3 = CType(unaFila.Item(24), String)
                    p.IDAGENCIA = CType(unaFila.Item(25), Integer)
                    p.CONTRATO = CType(unaFila.Item(26), Integer)
                    p.SOCIO = CType(unaFila.Item(27), Integer)
                    p.NOUSAR = CType(unaFila.Item(28), Integer)
                    p.MOROSO = CType(unaFila.Item(29), Integer)
                    p.CONTADO = CType(unaFila.Item(30), Integer)
                    p.CARAVANAS = CType(unaFila.Item(31), Integer)
                    p.PROLESA = CType(unaFila.Item(32), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(33), String)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function actualizardireccion(ByVal idProductor As Integer, ByVal direnvio As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET envio = '" & direnvio & "' WHERE id = " & idProductor

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar dirección', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizartelefono(ByVal idProductor As Integer, ByVal tel As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET telefono = '" & tel & "' WHERE id = " & idProductor

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar teléfono', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizartecnico(ByVal idProductor As Integer, ByVal tec As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET Tecnico = '" & tec & "' WHERE id = " & idProductor & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar tecnico', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizartecnico2(ByVal idProductor As Integer, ByVal tec2 As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET tecnico2 = '" & tec2 & "' WHERE id = " & idProductor & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar tecnico 2', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizartecnico3(ByVal idProductor As Integer, ByVal tec3 As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET tecnico3 = '" & tec3 & "' WHERE id = " & idProductor & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar tecnico 3', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizaragencia(ByVal idProductor As Integer, ByVal age As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET idagencia = '" & age & "' WHERE id = " & idProductor

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar teléfono', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizarmail(ByVal idProductor As Integer, ByVal mail As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET Email1 = '" & mail & "' WHERE id = " & idProductor

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar email', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizardicose(ByVal idProductor As Integer, ByVal dicose As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET dicose = '" & dicose & "' WHERE id = " & idProductor

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'actualizar dicose', " & idProductor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarmoroso(ByVal idfigaro As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET moroso = 1 WHERE CodigoFigaro = '" & idfigaro & "'"

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'productores', 'marcar moroso', '" & idfigaro & "', " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarmoroso2(ByVal usuario As dUsuario, ByVal productor As Long) As Boolean
        Dim sql As String = "UPDATE productor SET moroso = 1 WHERE id = " & productor & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'productores', 'marcar moroso', " & productor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(Sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarmoroso2(ByVal usuario As dUsuario, ByVal productor As Long) As Boolean
        Dim sql As String = "UPDATE productor SET moroso = 0 WHERE id = " & productor & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'productores', 'desmarcar moroso', " & productor & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarmoroso(ByVal idfigaro As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET moroso = 0 WHERE CodigoFigaro = '" & idfigaro & "'"

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'productores', 'desmarcar moroso', '" & idfigaro & "', " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarmorosos(ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE productor SET moroso = 0 "


        Dim lista As New ArrayList : lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
End Class
