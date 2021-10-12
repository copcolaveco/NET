Public Class pActasItemFecha
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActasItemFecha = CType(o, dActasItemFecha)
        Dim sql As String = "INSERT INTO actas_item_fecha (id, idacta, fecha, usuario) VALUES (" & obj.ID & ", " & obj.IDACTA & ", '" & obj.FECHA & "', " & obj.USUARIO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas_item_fecha', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActasItemFecha = CType(o, dActasItemFecha)
        Dim sql As String = "UPDATE actas_item_fecha SET idacta =" & obj.IDACTA & ", fecha= '" & obj.FECHA & "',usuario= " & obj.USUARIO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas_item_fecha', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dActasItemFecha = CType(o, dActasItemFecha)
        Dim sql As String = "DELETE FROM actas_item_fecha WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'actas_item_fecha', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dActasItemFecha
        Dim obj As dActasItemFecha = CType(o, dActasItemFecha)
        Dim p As New dActasItemFecha
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idacta, fecha, usuario FROM actas_item_fecha WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.IDACTA = CType(unaFila.Item(1), Long)
                p.FECHA = CType(unaFila.Item(2), String)
                p.USUARIO = CType(unaFila.Item(3), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idacta, fecha, usuario FROM actas_item_fecha ORDER BY plazo ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItemFecha
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.FECHA = CType(unaFila.Item(2), String)
                    p.USUARIO = CType(unaFila.Item(3), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarxidacta(ByVal idacta As Long) As ArrayList
        Dim sql As String = "SELECT id, idacta, fecha, usuario FROM actas_item_fecha WHERE idacta = " & idacta & " ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dActasItemFecha
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDACTA = CType(unaFila.Item(1), Long)
                    p.FECHA = CType(unaFila.Item(2), String)
                    p.USUARIO = CType(unaFila.Item(3), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
