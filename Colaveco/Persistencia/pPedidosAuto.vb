Public Class pPedidosAuto
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosAuto = CType(o, dPedidosAuto)
        Dim sql As String = "INSERT INTO pedidosautomaticos (id, dia, idproductor, direccion, telefono, idtecnico, idagencia, rc_compos, agua, sangre, esteriles, otros, observaciones, factura, enviado, convenio, suspendido) VALUES (" & obj.ID & "," & obj.DIA & ", " & obj.IDPRODUCTOR & ",'" & obj.DIRECCION & "', '" & obj.TELEFONO & "'," & obj.IDTECNICO & "," & obj.IDAGENCIA & "," & obj.RC_COMPOS & "," & obj.AGUA & "," & obj.SANGRE & ", " & obj.ESTERILES & "," & obj.OTROS & ",'" & obj.OBSERVACIONES & "'," & obj.FACTURA & "," & obj.ENVIADO & "," & obj.CONVENIO & "," & obj.SUSPENDIDO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidosauto', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosAuto = CType(o, dPedidosAuto)
        Dim sql As String = "UPDATE pedidosautomaticos SET dia =" & obj.DIA & ",idproductor =" & obj.IDPRODUCTOR & ",direccion ='" & obj.DIRECCION & "',telefono ='" & obj.TELEFONO & "',idtecnico =" & obj.IDTECNICO & ",idagencia =" & obj.IDAGENCIA & ", rc_compos =" & obj.RC_COMPOS & ", agua=" & obj.AGUA & ", sangre =" & obj.SANGRE & ", esteriles =  " & obj.ESTERILES & ", otros =" & obj.OTROS & ", observaciones ='" & obj.OBSERVACIONES & "', factura =" & obj.FACTURA & ", enviado=" & obj.ENVIADO & ", convenio=" & obj.CONVENIO & ", suspendido=" & obj.SUSPENDIDO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidosauto', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function activar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosAuto = CType(o, dPedidosAuto)
        Dim sql As String = "UPDATE pedidosautomaticos SET enviado = 0 WHERE dia = " & obj.DIA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidosauto', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosAuto = CType(o, dPedidosAuto)
        Dim sql As String = "DELETE FROM pedidosautomaticos WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidosauto', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPedidosAuto
        Dim obj As dPedidosAuto = CType(o, dPedidosAuto)
        Dim p As New dPedidosAuto
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, dia, idproductor,direccion, telefono, idtecnico, idagencia,rc_compos, agua, sangre, esteriles, otros, observaciones, factura, enviado, convenio, suspendido FROM pedidosautomaticos WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.DIA = CType(unaFila.Item(1), Integer)
                p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                p.DIRECCION = CType(unaFila.Item(3), String)
                p.TELEFONO = CType(unaFila.Item(4), String)
                p.IDTECNICO = CType(unaFila.Item(5), Integer)
                p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                p.RC_COMPOS = CType(unaFila.Item(7), Integer)
                p.AGUA = CType(unaFila.Item(8), Integer)
                p.SANGRE = CType(unaFila.Item(9), Integer)
                p.ESTERILES = CType(unaFila.Item(10), Integer)
                p.OTROS = CType(unaFila.Item(11), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(12), String)
                p.FACTURA = CType(unaFila.Item(13), Long)
                p.ENVIADO = CType(unaFila.Item(14), Integer)
                p.CONVENIO = CType(unaFila.Item(15), Integer)
                p.SUSPENDIDO = CType(unaFila.Item(16), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxproductor(ByVal o As Object) As dPedidosAuto
        Dim obj As dPedidosAuto = CType(o, dPedidosAuto)
        Dim p As New dPedidosAuto
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, dia, idproductor,direccion, telefono, idtecnico, idagencia,rc_compos, agua, sangre, esteriles, otros, observaciones, factura, enviado, convenio, suspendido FROM pedidosautomaticos WHERE idproductor = " & obj.IDPRODUCTOR)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.DIA = CType(unaFila.Item(1), Integer)
                p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                p.DIRECCION = CType(unaFila.Item(3), String)
                p.TELEFONO = CType(unaFila.Item(4), String)
                p.IDTECNICO = CType(unaFila.Item(5), Integer)
                p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                p.RC_COMPOS = CType(unaFila.Item(7), Integer)
                p.AGUA = CType(unaFila.Item(8), Integer)
                p.SANGRE = CType(unaFila.Item(9), Integer)
                p.ESTERILES = CType(unaFila.Item(10), Integer)
                p.OTROS = CType(unaFila.Item(11), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(12), String)
                p.FACTURA = CType(unaFila.Item(13), Long)
                p.ENVIADO = CType(unaFila.Item(14), Integer)
                p.CONVENIO = CType(unaFila.Item(15), Integer)
                p.SUSPENDIDO = CType(unaFila.Item(16), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpordia(ByVal texto As Integer) As ArrayList
        Dim sql As String = "SELECT id, dia, idproductor, direccion, ifnull(telefono,''), ifnull(idtecnico,999),idagencia, ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura,0), enviado, convenio, suspendido FROM pedidosautomaticos WHERE dia = " & texto & " and enviado = 0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidosAuto
                    p.ID = CType(unaFila.Item(0), Long)
                    p.DIA = CType(unaFila.Item(1), Integer)
                    p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    p.DIRECCION = CType(unaFila.Item(3), String)
                    p.TELEFONO = CType(unaFila.Item(4), String)
                    p.IDTECNICO = CType(unaFila.Item(5), Integer)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.RC_COMPOS = CType(unaFila.Item(7), Integer)
                    p.AGUA = CType(unaFila.Item(8), Integer)
                    p.SANGRE = CType(unaFila.Item(9), Integer)
                    p.ESTERILES = CType(unaFila.Item(10), Integer)
                    p.OTROS = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.FACTURA = CType(unaFila.Item(13), Long)
                    p.ENVIADO = CType(unaFila.Item(14), Integer)
                    p.CONVENIO = CType(unaFila.Item(15), Integer)
                    p.SUSPENDIDO = CType(unaFila.Item(16), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, dia, idproductor, direccion, ifnull(telefono,''), ifnull(idtecnico,999),idagencia, ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura,0), enviado, convenio, suspendido FROM pedidosautomaticos order by dia asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidosAuto
                    p.ID = CType(unaFila.Item(0), Long)
                    p.DIA = CType(unaFila.Item(1), Integer)
                    p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    p.DIRECCION = CType(unaFila.Item(3), String)
                    p.TELEFONO = CType(unaFila.Item(4), String)
                    p.IDTECNICO = CType(unaFila.Item(5), Integer)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.RC_COMPOS = CType(unaFila.Item(7), Integer)
                    p.AGUA = CType(unaFila.Item(8), Integer)
                    p.SANGRE = CType(unaFila.Item(9), Integer)
                    p.ESTERILES = CType(unaFila.Item(10), Integer)
                    p.OTROS = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.FACTURA = CType(unaFila.Item(13), Long)
                    p.ENVIADO = CType(unaFila.Item(14), Integer)
                    p.CONVENIO = CType(unaFila.Item(15), Integer)
                    p.SUSPENDIDO = CType(unaFila.Item(16), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim sql As String = "SELECT id, dia, idproductor, direccion, ifnull(telefono,''), ifnull(idtecnico,999),idagencia, ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura,0), enviado, convenio, suspendido FROM pedidosautomaticos WHERE enviado=0 AND suspendido = 0 order by dia asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidosAuto
                    p.ID = CType(unaFila.Item(0), Long)
                    p.DIA = CType(unaFila.Item(1), Integer)
                    p.IDPRODUCTOR = CType(unaFila.Item(2), Long)
                    p.DIRECCION = CType(unaFila.Item(3), String)
                    p.TELEFONO = CType(unaFila.Item(4), String)
                    p.IDTECNICO = CType(unaFila.Item(5), Integer)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.RC_COMPOS = CType(unaFila.Item(7), Integer)
                    p.AGUA = CType(unaFila.Item(8), Integer)
                    p.SANGRE = CType(unaFila.Item(9), Integer)
                    p.ESTERILES = CType(unaFila.Item(10), Integer)
                    p.OTROS = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.FACTURA = CType(unaFila.Item(13), Long)
                    p.ENVIADO = CType(unaFila.Item(14), Integer)
                    p.CONVENIO = CType(unaFila.Item(15), Integer)
                    p.SUSPENDIDO = CType(unaFila.Item(16), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarEnvio(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidosautomaticos SET enviado = 1 WHERE id = " & idPedido

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidosauto', 'marcar envio', " & idPedido & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarEnvio(ByVal iddia As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidosautomaticos SET enviado = 0 WHERE dia = " & iddia

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidosauto', 'desmarcar envio', " & iddia & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcartodos() As Boolean
        Dim sql As String = "UPDATE pedidosautomaticos SET enviado = 0 "

        Dim lista As New ArrayList : lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
End Class
