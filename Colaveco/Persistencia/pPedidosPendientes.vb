Public Class pPedidosPendientes
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosPendientes = CType(o, dPedidosPendientes)
        Dim sql As String = "INSERT INTO pedidos_pendientes (id, pedido, observaciones) VALUES (" & obj.ID & ", " & obj.PEDIDO & ", '" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidos_pendientes', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosPendientes = CType(o, dPedidosPendientes)
        Dim sql As String = "UPDATE pedidos_pendientes SET pedido = " & obj.PEDIDO & ", observaciones = '" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidos_pendientes', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosPendientes = CType(o, dPedidosPendientes)
        Dim sql As String = "DELETE FROM pedidos_pendientes WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidos_pendientes', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPedidosPendientes
        Dim obj As dPedidosPendientes = CType(o, dPedidosPendientes)
        Dim l As New dPedidosPendientes
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, pedido, observaciones FROM pedidos_pendientes WHERE pedido = " & obj.PEDIDO & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.PEDIDO = CType(unaFila.Item(1), Long)
                l.OBSERVACIONES = CType(unaFila.Item(2), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, pedido, observaciones FROM pedidos_pendientes"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dPedidosPendientes
                    l.ID = CType(unaFila.Item(0), Long)
                    l.PEDIDO = CType(unaFila.Item(1), Long)
                    l.OBSERVACIONES = CType(unaFila.Item(2), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
