Public Class pMOA24
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMOA24 = CType(o, dMOA24)
        Dim sql As String = "INSERT INTO moa24 (id, nombre, orden, eliminado) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', " & obj.ORDEN & ", " & obj.ELIMINADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'moa24', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMOA24 = CType(o, dMOA24)
        Dim sql As String = "UPDATE moa24 SET nombre = '" & obj.NOMBRE & "' WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'moa24', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMOA24 = CType(o, dMOA24)
        Dim sql As String = "UPDATE moa24 SET eliminado = 1 WHERE id = " & obj.ID
        'Dim sql As String = "DELETE FROM moa24 WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'moa24', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMOA24
        Dim obj As dMOA24 = CType(o, dMOA24)
        Dim m As New dMOA24
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, orden, eliminado FROM moa24 WHERE eliminado = 0 AND id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Integer)
                m.NOMBRE = CType(unaFila.Item(1), String)
                m.ORDEN = CType(unaFila.Item(2), Integer)
                m.ELIMINADO = CType(unaFila.Item(3), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, orden, eliminado FROM moa24 WHERE eliminado = 0 ORDER BY orden ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMOA24
                    m.ID = CType(unaFila.Item(0), Integer)
                    m.NOMBRE = CType(unaFila.Item(1), String)
                    m.ORDEN = CType(unaFila.Item(2), Integer)
                    m.ELIMINADO = CType(unaFila.Item(3), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
