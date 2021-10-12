Public Class pRelSolicitudMuestras
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudMuestras = CType(o, dRelSolicitudMuestras)
        Dim sql As String = "INSERT INTO solicitud_muestras (id, ficha, fecha, idtipoinforme, idmuestra, nocolaveco, eliminado) VALUES (" & obj.ID & ", " & obj.ficha & ",'" & obj.FECHA & "'," & obj.IDTIPOINFORME & ",'" & obj.IDMUESTRA & "'," & obj.NOCOLAVECO & ", " & obj.ELIMINADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_muestras', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudMuestras = CType(o, dRelSolicitudMuestras)
        Dim sql As String = "UPDATE solicitud_muestras SET ficha =" & obj.ficha & ", fecha='" & obj.FECHA & "',idtipoinforme=" & obj.IDTIPOINFORME & ", idmuestra ='" & obj.IDMUESTRA & "',nocolaveco=" & obj.NOCOLAVECO & ", eliminado=" & obj.ELIMINADO & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_muestras', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudMuestras = CType(o, dRelSolicitudMuestras)
        Dim sql As String = "DELETE FROM solicitud_muestras WHERE ficha = " & obj.ficha & ""
        'Dim sql As String = "UPDATE solicitud_muestras SET eliminado =1 WHERE ID = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_muestras', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxmuestra(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dRelSolicitudMuestras = CType(o, dRelSolicitudMuestras)
        Dim sql As String = "DELETE FROM solicitud_muestras WHERE ficha = " & obj.FICHA & " AND idmuestra = " & obj.IDMUESTRA & ""
        'Dim sql As String = "UPDATE solicitud_muestras SET eliminado =1 WHERE ID = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_muestras', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dRelSolicitudMuestras
        Dim obj As dRelSolicitudMuestras = CType(o, dRelSolicitudMuestras)
        Dim e As New dRelSolicitudMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, idtipoinforme, idmuestra, nocolaveco, eliminado FROM solicitud_muestras WHERE eliminado = 0 and ficha = " & obj.ficha & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.ficha = CType(unaFila.Item(1), Long)
                e.FECHA = CType(unaFila.Item(2), String)
                e.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                e.IDMUESTRA = CType(unaFila.Item(4), String)
                e.NOCOLAVECO = CType(unaFila.Item(5), Integer)
                e.ELIMINADO = CType(unaFila.Item(6), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarrepetidas(ByVal o As Object) As dRelSolicitudMuestras
        Dim obj As dRelSolicitudMuestras = CType(o, dRelSolicitudMuestras)
        Dim e As New dRelSolicitudMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, fecha, idtipoinforme, idmuestra, nocolaveco, eliminado FROM solicitud_muestras WHERE eliminado = 0 and ficha = " & obj.ficha & " AND idmuestra = '" & obj.IDMUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                e.ID = CType(unaFila.Item(0), Long)
                e.ficha = CType(unaFila.Item(1), Long)
                e.FECHA = CType(unaFila.Item(2), String)
                e.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                e.IDMUESTRA = CType(unaFila.Item(4), String)
                e.NOCOLAVECO = CType(unaFila.Item(5), Integer)
                e.ELIMINADO = CType(unaFila.Item(6), Integer)
                Return e
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, fecha, idtipoinforme, idmuestra  FROM solicitud_muestras WHERE eliminado = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dRelSolicitudMuestras
                    e.ID = CType(unaFila.Item(0), Long)
                    e.ficha = CType(unaFila.Item(1), Long)
                    e.FECHA = CType(unaFila.Item(2), String)
                    e.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    e.IDMUESTRA = CType(unaFila.Item(4), String)
                    e.NOCOLAVECO = CType(unaFila.Item(5), Integer)
                    e.ELIMINADO = CType(unaFila.Item(6), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha, idtipoinforme, idmuestra, nocolaveco, eliminado FROM solicitud_muestras WHERE eliminado = 0 AND ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dRelSolicitudMuestras
                    e.ID = CType(unaFila.Item(0), Long)
                    e.ficha = CType(unaFila.Item(1), Long)
                    e.FECHA = CType(unaFila.Item(2), String)
                    e.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    e.IDMUESTRA = CType(unaFila.Item(4), String)
                    e.NOCOLAVECO = CType(unaFila.Item(5), Integer)
                    e.ELIMINADO = CType(unaFila.Item(6), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, fecha, idtipoinforme, idmuestra, nocolaveco, eliminado FROM solicitud_muestras WHERE eliminado = 0 AND ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim e As New dRelSolicitudMuestras
                    e.ID = CType(unaFila.Item(0), Long)
                    e.ficha = CType(unaFila.Item(1), Long)
                    e.FECHA = CType(unaFila.Item(2), String)
                    e.IDTIPOINFORME = CType(unaFila.Item(3), Integer)
                    e.IDMUESTRA = CType(unaFila.Item(4), String)
                    e.NOCOLAVECO = CType(unaFila.Item(5), Integer)
                    e.ELIMINADO = CType(unaFila.Item(6), Integer)
                    Lista.Add(e)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
