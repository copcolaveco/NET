Public Class pComunicacionTecnica
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComunicacionTecnica = CType(o, dComunicacionTecnica)
        Dim sql As String = "INSERT INTO comunicacion_tecnica (id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto) VALUES (" & obj.ID & ",'" & obj.FECHA & "','" & obj.TIPOCLIENTE & "', " & obj.CLIENTE & ", " & obj.TECNICO & ",'" & obj.DESCRIPCION & "'," & obj.TECNICORESP & ",'" & obj.ACCIONES & "'," & obj.RESPACCIONES & ",'" & obj.OBSERVACIONES & "'," & obj.VISTO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'comunicacion_tecnica', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComunicacionTecnica = CType(o, dComunicacionTecnica)
        Dim sql As String = "UPDATE comunicacion_tecnica SET fecha ='" & obj.FECHA & "', tipocliente='" & obj.TIPOCLIENTE & "', cliente =" & obj.CLIENTE & ", tecnico =" & obj.TECNICO & ",descripcion ='" & obj.DESCRIPCION & "',tecnicoresp =" & obj.TECNICORESP & ",acciones ='" & obj.ACCIONES & "',respacciones =" & obj.RESPACCIONES & ",observaciones ='" & obj.OBSERVACIONES & "', visto =" & obj.VISTO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'comunicacion_tecnica', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComunicacionTecnica = CType(o, dComunicacionTecnica)
        Dim sql As String = "DELETE FROM comunicacion_tecnica WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'comunicacion_tecnica', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dComunicacionTecnica
        Dim obj As dComunicacionTecnica = CType(o, dComunicacionTecnica)
        Dim r As New dComunicacionTecnica
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto FROM comunicacion_tecnica WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                r.ID = CType(unaFila.Item(0), Long)
                r.FECHA = CType(unaFila.Item(1), String)
                r.TIPOCLIENTE = CType(unaFila.Item(2), String)
                r.CLIENTE = CType(unaFila.Item(3), Integer)
                r.TECNICO = CType(unaFila.Item(4), Integer)
                r.DESCRIPCION = CType(unaFila.Item(5), String)
                r.TECNICORESP = CType(unaFila.Item(6), Integer)
                r.ACCIONES = CType(unaFila.Item(7), String)
                r.RESPACCIONES = CType(unaFila.Item(8), Integer)
                r.OBSERVACIONES = CType(unaFila.Item(9), String)
                r.VISTO = CType(unaFila.Item(10), Integer)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto FROM comunicacion_tecnica WHERE visto = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dComunicacionTecnica
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.TIPOCLIENTE = CType(unaFila.Item(2), String)
                    r.CLIENTE = CType(unaFila.Item(3), Integer)
                    r.TECNICO = CType(unaFila.Item(4), Integer)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.TECNICORESP = CType(unaFila.Item(6), Integer)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPACCIONES = CType(unaFila.Item(8), Integer)
                    r.OBSERVACIONES = CType(unaFila.Item(9), String)
                    r.VISTO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfinalizados() As ArrayList
        Dim sql As String = "SELECT id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto FROM comunicacion_tecnica WHERE visto = 1 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dComunicacionTecnica
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.TIPOCLIENTE = CType(unaFila.Item(2), String)
                    r.CLIENTE = CType(unaFila.Item(3), Integer)
                    r.TECNICO = CType(unaFila.Item(4), Integer)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.TECNICORESP = CType(unaFila.Item(6), Integer)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPACCIONES = CType(unaFila.Item(8), Integer)
                    r.OBSERVACIONES = CType(unaFila.Item(9), String)
                    r.VISTO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinver(ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto FROM comunicacion_tecnica WHERE tecnicoresp= " & idusuario & " AND visto=0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dComunicacionTecnica
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.TIPOCLIENTE = CType(unaFila.Item(2), String)
                    r.CLIENTE = CType(unaFila.Item(3), Integer)
                    r.TECNICO = CType(unaFila.Item(4), Integer)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.TECNICORESP = CType(unaFila.Item(6), Integer)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPACCIONES = CType(unaFila.Item(8), Integer)
                    r.OBSERVACIONES = CType(unaFila.Item(9), String)
                    r.VISTO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarvisto(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComunicacionTecnica = CType(o, dComunicacionTecnica)
        Dim sql As String = "UPDATE comunicacion_tecnica SET visto = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'comunicacion_tecnica', 'marcar_visto', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto FROM comunicacion_tecnica WHERE  fecha >='" & desde & "' and fecha <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dComunicacionTecnica
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.TIPOCLIENTE = CType(unaFila.Item(2), String)
                    r.CLIENTE = CType(unaFila.Item(3), Integer)
                    r.TECNICO = CType(unaFila.Item(4), Integer)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.TECNICORESP = CType(unaFila.Item(6), Integer)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPACCIONES = CType(unaFila.Item(8), Integer)
                    r.OBSERVACIONES = CType(unaFila.Item(9), String)
                    r.VISTO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartodos(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal categoria As String, ByVal fuente As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto FROM comunicacion_tecnica WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and tipo = '" & tipo & "' and categoria = '" & categoria & "' and fuente = '" & fuente & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dComunicacionTecnica
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.TIPOCLIENTE = CType(unaFila.Item(2), String)
                    r.CLIENTE = CType(unaFila.Item(3), Integer)
                    r.TECNICO = CType(unaFila.Item(4), Integer)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.TECNICORESP = CType(unaFila.Item(6), Integer)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPACCIONES = CType(unaFila.Item(8), Integer)
                    r.OBSERVACIONES = CType(unaFila.Item(9), String)
                    r.VISTO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartipocliente(ByVal desde As String, ByVal hasta As String, ByVal tipocliente As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, tipocliente, cliente, tecnico, descripcion, tecnicoresp, acciones, respacciones, observaciones, visto FROM comunicacion_tecnica WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and tipocliente = '" & tipocliente & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dComunicacionTecnica
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.TIPOCLIENTE = CType(unaFila.Item(2), String)
                    r.CLIENTE = CType(unaFila.Item(3), Integer)
                    r.TECNICO = CType(unaFila.Item(4), Integer)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.TECNICORESP = CType(unaFila.Item(6), Integer)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPACCIONES = CType(unaFila.Item(8), Integer)
                    r.OBSERVACIONES = CType(unaFila.Item(9), String)
                    r.VISTO = CType(unaFila.Item(10), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
