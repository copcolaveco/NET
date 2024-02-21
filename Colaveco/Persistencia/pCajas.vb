Public Class pCajas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "INSERT INTO cajas (id, codigo, estado, idcliente, fecha) VALUES (" & obj.ID & ", '" & obj.CODIGO & "'," & obj.ESTADO & ", " & obj.IDCLIENTE & ", '" & obj.FECHA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET codigo='" & obj.CODIGO & "', estado= " & obj.ESTADO & ", idcliente= " & obj.IDCLIENTE & ", fecha='" & obj.FECHA & "'  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET estado= " & obj.ESTADO & ", idcliente= " & obj.IDCLIENTE & ", fecha= '" & obj.FECHA & "'  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarlaboratorio(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET estado= 1, idcliente=-1, fecha = '" & obj.FECHA & "'  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'marcar_laboratorio', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarlaboratorioManual(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET estado= 1, idcliente=-1, fecha = '" & obj.FECHA & "'  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'marcar_laboratorio', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcliente(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET estado= 2, idcliente = " & obj.IDCLIENTE & ", fecha = '" & obj.FECHA & "'  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'marcar_cliente', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarclienteFlorida(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET estado= 3, idcliente = " & obj.IDCLIENTE & ", fecha = '" & obj.FECHA & "'  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'marcar_cliente', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarclienteCardal(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET estado= 4, idcliente = " & obj.IDCLIENTE & ", fecha = '" & obj.FECHA & "'  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'marcar_cliente', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarclienteCanelones(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "UPDATE cajas SET estado= 5, idcliente = " & obj.IDCLIENTE & ", fecha = '" & obj.FECHA & "'  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'marcar_cliente', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajas = CType(o, dCajas)
        Dim sql As String = "DELETE FROM cajas WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCajas
        Dim obj As dCajas = CType(o, dCajas)
        Dim c As New dCajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, codigo, estado, idcliente, fecha FROM cajas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.CODIGO = CType(unaFila.Item(1), String)
                c.ESTADO = CType(unaFila.Item(2), Integer)
                c.IDCLIENTE = CType(unaFila.Item(3), Long)
                c.FECHA = CType(unaFila.Item(4), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorCodigo(ByVal codigo As String) As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, idcliente, fecha FROM cajas WHERE BINARY codigo like '%" & codigo & "%' ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajas
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.IDCLIENTE = CType(unaFila.Item(3), Long)
                    c.FECHA = CType(unaFila.Item(4), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, idcliente, fecha FROM cajas ORDER BY estado, codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajas
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.IDCLIENTE = CType(unaFila.Item(3), Long)
                    c.FECHA = CType(unaFila.Item(4), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar2() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, idcliente, fecha FROM cajas ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajas
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.IDCLIENTE = CType(unaFila.Item(3), Long)
                    c.FECHA = CType(unaFila.Item(4), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarenLaboratorio() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, idcliente, fecha FROM cajas WHERE estado = 1 ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajas
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.IDCLIENTE = CType(unaFila.Item(3), Long)
                    c.FECHA = CType(unaFila.Item(4), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarenClientes() As ArrayList
        Dim sql As String = "SELECT distinct(caj.id), caj.codigo, caj.estado, caj.idcliente, caj.fecha FROM cajas caj INNER JOIN enviocajas ecaj oN ecaj.idcaja = caj.id WHERE estado <> 1 and ecaj.recibido = 1 ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajas
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.IDCLIENTE = CType(unaFila.Item(3), Long)
                    c.FECHA = CType(unaFila.Item(4), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
