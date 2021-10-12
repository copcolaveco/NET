Public Class pInhibidores_obs
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dInhibidores_obs = CType(o, dInhibidores_obs)
        Dim sql As String = "INSERT INTO inhibidores_obs (id, idinh, observaciones, eliminado) VALUES (" & obj.ID & "," & obj.IDINH & ", '" & obj.OBSERVACIONES & "', " & obj.ELIMINADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'inhibidores_obs', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dInhibidores_obs = CType(o, dInhibidores_obs)
        Dim sql As String = "UPDATE inhibidores_obs SET idinh = " & obj.IDINH & ", observaciones = '" & obj.OBSERVACIONES & "', eliminado = " & obj.ELIMINADO & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'inhibidores_obs', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dInhibidores_obs = CType(o, dInhibidores_obs)
        Dim sql As String = "UPDATE inhibidores_obs SET eliminado =1 WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'inhibidores_obs', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dInhibidores_obs
        Dim obj As dInhibidores_obs = CType(o, dInhibidores_obs)
        Dim c As New dInhibidores_obs
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idinh, observaciones, eliminado FROM inhibidores_obs WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.IDINH = CType(unaFila.Item(1), Long)
                c.OBSERVACIONES = CType(unaFila.Item(2), String)
                c.ELIMINADO = CType(unaFila.Item(3), Integer)

                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idinh, observaciones, eliminado FROM inhibidores_obs order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dInhibidores_obs
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDINH = CType(unaFila.Item(1), Long)
                    c.OBSERVACIONES = CType(unaFila.Item(2), String)
                    c.ELIMINADO = CType(unaFila.Item(3), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idinh, observaciones, eliminado FROM inhibidores_obs where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dInhibidores_obs
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDINH = CType(unaFila.Item(1), Long)
                    c.OBSERVACIONES = CType(unaFila.Item(2), String)
                    c.ELIMINADO = CType(unaFila.Item(3), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
