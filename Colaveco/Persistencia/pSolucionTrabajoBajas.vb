Public Class pSolucionTrabajoBajas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolucionTrabajoBajas = CType(o, dSolucionTrabajoBajas)
        Dim sql As String = "INSERT INTO solucion_trabajo_bajas (id, fecha, idsolucion, cantidad, idunidad) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.IDSOLUCION & ", " & obj.CANTIDAD & ", " & obj.IDUNIDAD & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solucion_trabajo_bajas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolucionTrabajoBajas = CType(o, dSolucionTrabajoBajas)
        Dim sql As String = "UPDATE solucion_trabajo_bajas SET fecha ='" & obj.FECHA & "', idsolucion =" & obj.IDSOLUCION & ", cantidad =" & obj.CANTIDAD & ", idunidad =" & obj.IDUNIDAD & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solucion_trabajo_bajas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolucionTrabajoBajas = CType(o, dSolucionTrabajoBajas)
        Dim sql As String = "DELETE FROM solucion_trabajo_bajas WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solucion_trabajo_bajas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dSolucionTrabajoBajas
        Dim obj As dSolucionTrabajoBajas = CType(o, dSolucionTrabajoBajas)
        Dim c As New dSolucionTrabajoBajas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, idsolucion, cantidad, idunidad FROM solucion_trabajo_bajas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.IDSOLUCION = CType(unaFila.Item(2), Integer)
                c.CANTIDAD = CType(unaFila.Item(3), Double)
                c.IDUNIDAD = CType(unaFila.Item(4), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, idsolucion, cantidad, idunidad FROM solucion_trabajo_bajas"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dSolucionTrabajoBajas
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.IDSOLUCION = CType(unaFila.Item(2), Integer)
                    c.CANTIDAD = CType(unaFila.Item(3), Double)
                    c.IDUNIDAD = CType(unaFila.Item(4), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class
