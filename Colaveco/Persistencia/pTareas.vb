Public Class pTareas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dTareas = CType(o, dTareas)
        Dim sql As String = "INSERT INTO tareas (id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada) VALUES (" & obj.ID & ", '" & obj.FECHA & "', '" & obj.DESCRIPCION & "', '" & obj.FINALIZACION & "', " & obj.USUARIO & ", " & obj.SECTOR & ", " & obj.CREADOR & ", " & obj.REALIZADA & ", " & obj.ELIMINADA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tareas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dTareas = CType(o, dTareas)
        Dim sql As String = "UPDATE tareas SET fecha = '" & obj.FECHA & "', descripcion= '" & obj.DESCRIPCION & "',finalizacion=  '" & obj.FINALIZACION & "',usuario=  " & obj.USUARIO & ",sector=  " & obj.SECTOR & ",creador=  " & obj.CREADOR & ",realizada=  " & obj.REALIZADA & ",eliminada = " & obj.ELIMINADA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tareas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dTareas = CType(o, dTareas)
        Dim sql As String = "UPDATE tareas set eliminada = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'tareas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dTareas
        Dim obj As dTareas = CType(o, dTareas)
        Dim l As New dTareas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.FECHA = CType(unaFila.Item(1), String)
                l.DESCRIPCION = CType(unaFila.Item(2), String)
                l.FINALIZACION = CType(unaFila.Item(3), String)
                l.USUARIO = CType(unaFila.Item(4), Integer)
                l.SECTOR = CType(unaFila.Item(5), Integer)
                l.CREADOR = CType(unaFila.Item(6), Integer)
                l.REALIZADA = CType(unaFila.Item(7), Integer)
                l.ELIMINADA = CType(unaFila.Item(8), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas ORDER BY finalizacion ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTareas
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.FINALIZACION = CType(unaFila.Item(3), String)
                    l.USUARIO = CType(unaFila.Item(4), Integer)
                    l.SECTOR = CType(unaFila.Item(5), Integer)
                    l.CREADOR = CType(unaFila.Item(6), Integer)
                    l.REALIZADA = CType(unaFila.Item(7), Integer)
                    l.ELIMINADA = CType(unaFila.Item(8), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas WHERE usuario = " & idusuario & " AND eliminada = 0 AND realizada = 0 ORDER BY realizada ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTareas
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.FINALIZACION = CType(unaFila.Item(3), String)
                    l.USUARIO = CType(unaFila.Item(4), Integer)
                    l.SECTOR = CType(unaFila.Item(5), Integer)
                    l.CREADOR = CType(unaFila.Item(6), Integer)
                    l.REALIZADA = CType(unaFila.Item(7), Integer)
                    l.ELIMINADA = CType(unaFila.Item(8), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuarior(ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas WHERE usuario = " & idusuario & " AND eliminada = 0 AND realizada = 1 ORDER BY realizada DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTareas
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.FINALIZACION = CType(unaFila.Item(3), String)
                    l.USUARIO = CType(unaFila.Item(4), Integer)
                    l.SECTOR = CType(unaFila.Item(5), Integer)
                    l.CREADOR = CType(unaFila.Item(6), Integer)
                    l.REALIZADA = CType(unaFila.Item(7), Integer)
                    l.ELIMINADA = CType(unaFila.Item(8), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxsector(ByVal idsector As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas WHERE sector = " & idsector & " AND eliminada = 0  AND realizada =0 ORDER BY realizada asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTareas
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.FINALIZACION = CType(unaFila.Item(3), String)
                    l.USUARIO = CType(unaFila.Item(4), Integer)
                    l.SECTOR = CType(unaFila.Item(5), Integer)
                    l.CREADOR = CType(unaFila.Item(6), Integer)
                    l.REALIZADA = CType(unaFila.Item(7), Integer)
                    l.ELIMINADA = CType(unaFila.Item(8), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxsectorr(ByVal idsector As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas WHERE sector = " & idsector & " AND eliminada = 0  AND realizada =1 ORDER BY realizada desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTareas
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.FINALIZACION = CType(unaFila.Item(3), String)
                    l.USUARIO = CType(unaFila.Item(4), Integer)
                    l.SECTOR = CType(unaFila.Item(5), Integer)
                    l.CREADOR = CType(unaFila.Item(6), Integer)
                    l.REALIZADA = CType(unaFila.Item(7), Integer)
                    l.ELIMINADA = CType(unaFila.Item(8), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listargenerales(ByVal hoy As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas WHERE finalizacion >= '" & hoy & "' AND sector = 11 AND eliminada = 0 AND realizada = 0 ORDER BY id DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTareas
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.FINALIZACION = CType(unaFila.Item(3), String)
                    l.USUARIO = CType(unaFila.Item(4), Integer)
                    l.SECTOR = CType(unaFila.Item(5), Integer)
                    l.CREADOR = CType(unaFila.Item(6), Integer)
                    l.REALIZADA = CType(unaFila.Item(7), Integer)
                    l.ELIMINADA = CType(unaFila.Item(8), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuarioxcreador(ByVal idusuario As Integer, ByVal idcreador As Integer, ByVal idsector As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, descripcion, finalizacion, usuario, sector, creador, realizada, eliminada FROM tareas WHERE (usuario = " & idusuario & " OR creador = " & idcreador & " OR sector = " & idsector & ") AND (eliminada = 0 AND realizada = 0) ORDER BY finalizacion ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dTareas
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.FINALIZACION = CType(unaFila.Item(3), String)
                    l.USUARIO = CType(unaFila.Item(4), Integer)
                    l.SECTOR = CType(unaFila.Item(5), Integer)
                    l.CREADOR = CType(unaFila.Item(6), Integer)
                    l.REALIZADA = CType(unaFila.Item(7), Integer)
                    l.ELIMINADA = CType(unaFila.Item(8), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
