Public Class pSolicitudesIT
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudesIT = CType(o, dSolicitudesIT)
        Dim sql As String = "INSERT INTO solicitudes_it (id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, validado, valida, fechavalidacion, observaciones) VALUES (" & obj.ID & ",'" & obj.FECHA & "', '" & obj.DESCRIPCION & "'," & obj.SOLICITANTE & "," & obj.PRIORIDAD & "," & obj.ESTADO & "," & obj.AUTORIZADO & "," & obj.AUTORIZA & "," & obj.VALIDADO & "," & obj.VALIDA & ",'" & obj.FECHAVALIDACION & "','" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudesit', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudesIT = CType(o, dSolicitudesIT)
        Dim sql As String = "UPDATE solicitudes_it SET fecha ='" & obj.FECHA & "',descripcion ='" & obj.DESCRIPCION & "',solicitante =" & obj.SOLICITANTE & ",prioridad =" & obj.PRIORIDAD & ",estado =" & obj.ESTADO & ",autorizado =" & obj.AUTORIZADO & ",autoriza =" & obj.AUTORIZA & ",validado =" & obj.VALIDADO & " ,valida =" & obj.VALIDA & " ,fechavalidacion ='" & obj.FECHAVALIDACION & "',observaciones ='" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudesit', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarestado(ByVal o As Object) As Boolean
        Dim obj As dSolicitudesIT = CType(o, dSolicitudesIT)
        Dim sql As String = "UPDATE solicitudes_it SET estado =" & obj.ESTADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarobservaciones(ByVal o As Object) As Boolean
        Dim obj As dSolicitudesIT = CType(o, dSolicitudesIT)
        Dim sql As String = "UPDATE solicitudes_it SET observaciones =" & obj.OBSERVACIONES & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudesIT = CType(o, dSolicitudesIT)
        Dim sql As String = "UPDATE solicitudes_it SET estado=3 WHERE estado=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudes_it', 'estado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudesIT = CType(o, dSolicitudesIT)
        Dim sql As String = "DELETE FROM solicitudes_it WHERE id = " & obj.ID & ""
        'Dim sql As String = "UPDATE solicitudes_it SET eliminado =1 WHERE id = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitudesit', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSolicitudesIT
        Dim obj As dSolicitudesIT = CType(o, dSolicitudesIT)
        Dim s As New dSolicitudesIT
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, validado, valida, fechavalidacion, observaciones FROM solicitudes_it WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHA = CType(unaFila.Item(1), String)
                s.DESCRIPCION = CType(unaFila.Item(2), String)
                s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                s.ESTADO = CType(unaFila.Item(5), Integer)
                s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                s.AUTORIZA = CType(unaFila.Item(7), Integer)
                s.VALIDADO = CType(unaFila.Item(8), Integer)
                s.VALIDA = CType(unaFila.Item(9), Integer)
                s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                s.OBSERVACIONES = CType(unaFila.Item(11), String)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = ("select id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, validado, valida, fechavalidacion, observaciones FROM solicitudes_it order by fecha desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudesIT
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.DESCRIPCION = CType(unaFila.Item(2), String)
                    s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                    s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                    s.ESTADO = CType(unaFila.Item(5), Integer)
                    s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                    s.AUTORIZA = CType(unaFila.Item(7), Integer)
                    s.VALIDADO = CType(unaFila.Item(8), Integer)
                    s.VALIDA = CType(unaFila.Item(9), Integer)
                    s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpendientes() As ArrayList
        Dim sql As String = ("select id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, validado, valida, fechavalidacion, observaciones FROM solicitudes_it WHERE estado = 1 order by fecha desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudesIT
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.DESCRIPCION = CType(unaFila.Item(2), String)
                    s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                    s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                    s.ESTADO = CType(unaFila.Item(5), Integer)
                    s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                    s.AUTORIZA = CType(unaFila.Item(7), Integer)
                    s.VALIDADO = CType(unaFila.Item(8), Integer)
                    s.VALIDA = CType(unaFila.Item(9), Integer)
                    s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfinalizadas() As ArrayList
        Dim sql As String = ("select id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, valida, validado, fechavalidacion, observaciones FROM solicitudes_it WHERE estado = 3 order by fecha desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudesIT
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.DESCRIPCION = CType(unaFila.Item(2), String)
                    s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                    s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                    s.ESTADO = CType(unaFila.Item(5), Integer)
                    s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                    s.AUTORIZA = CType(unaFila.Item(7), Integer)
                    s.VALIDADO = CType(unaFila.Item(8), Integer)
                    s.VALIDA = CType(unaFila.Item(9), Integer)
                    s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarenproceso() As ArrayList
        Dim sql As String = ("select id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, valida, validado, fechavalidacion, observaciones FROM solicitudes_it WHERE estado = 2 order by fecha desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudesIT
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.DESCRIPCION = CType(unaFila.Item(2), String)
                    s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                    s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                    s.ESTADO = CType(unaFila.Item(5), Integer)
                    s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                    s.AUTORIZA = CType(unaFila.Item(7), Integer)
                    s.VALIDADO = CType(unaFila.Item(8), Integer)
                    s.VALIDA = CType(unaFila.Item(9), Integer)
                    s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxestado(ByVal estado As Integer) As ArrayList
        Dim sql As String = ("select id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, validado, valida, fechavalidacion, observaciones FROM solicitudes_it WHERE estado= " & estado & " order by fecha desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudesIT
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.DESCRIPCION = CType(unaFila.Item(2), String)
                    s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                    s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                    s.ESTADO = CType(unaFila.Item(5), Integer)
                    s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                    s.AUTORIZA = CType(unaFila.Item(7), Integer)
                    s.VALIDADO = CType(unaFila.Item(8), Integer)
                    s.VALIDA = CType(unaFila.Item(9), Integer)
                    s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal usuario As Integer) As ArrayList
        Dim sql As String = ("select id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, validado, valida, fechavalidacion, observaciones FROM solicitudes_it WHERE solicitante= " & usuario & " order by fecha desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudesIT
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.DESCRIPCION = CType(unaFila.Item(2), String)
                    s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                    s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                    s.ESTADO = CType(unaFila.Item(5), Integer)
                    s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                    s.AUTORIZA = CType(unaFila.Item(7), Integer)
                    s.VALIDADO = CType(unaFila.Item(8), Integer)
                    s.VALIDA = CType(unaFila.Item(9), Integer)
                    s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxestadousuario(ByVal estado As Integer, ByVal usuario As Integer) As ArrayList
        Dim sql As String = ("select id, fecha, descripcion, solicitante, prioridad, estado, autorizado, autoriza, validado, valida, fechavalidacion, observaciones FROM solicitudes_it WHERE estado= " & estado & " AND solicitante = " & usuario & " order by fecha desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dSolicitudesIT
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.DESCRIPCION = CType(unaFila.Item(2), String)
                    s.SOLICITANTE = CType(unaFila.Item(3), Integer)
                    s.PRIORIDAD = CType(unaFila.Item(4), Integer)
                    s.ESTADO = CType(unaFila.Item(5), Integer)
                    s.AUTORIZADO = CType(unaFila.Item(6), Integer)
                    s.AUTORIZA = CType(unaFila.Item(7), Integer)
                    s.VALIDADO = CType(unaFila.Item(8), Integer)
                    s.VALIDA = CType(unaFila.Item(9), Integer)
                    s.FECHAVALIDACION = CType(unaFila.Item(10), String)
                    s.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function modificarobservaciones(dSolicitudesIT As dSolicitudesIT, usuario As dUsuario) As Boolean
        Dim obj As dSolicitudesIT = CType(dSolicitudesIT, dSolicitudesIT)
        Dim sql As String = "UPDATE solicitudes_it SET observaciones = '" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

End Class
