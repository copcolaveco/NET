Public Class pFacturacion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFacturacion = CType(o, dFacturacion)
        Dim sql As String = "INSERT INTO facturacion (id, ficha, cantidad, analisis, precio, subtotal, factura) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.CANTIDAD & ", " & obj.ANALISIS & ", " & obj.PRECIO & ", " & obj.SUBTOTAL & ", " & obj.FACTURA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'facturacion', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFacturacion = CType(o, dFacturacion)
        Dim sql As String = "UPDATE facturacion SET ficha = " & obj.FICHA & ", cantidad=" & obj.CANTIDAD & ", analisis=" & obj.ANALISIS & ", precio=" & obj.PRECIO & ", subtotal=" & obj.SUBTOTAL & ", factura=" & obj.FACTURA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'facturacion', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dFacturacion = CType(o, dFacturacion)
        Dim sql As String = "DELETE FROM facturacion WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'facturacion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dFacturacion
        Dim obj As dFacturacion = CType(o, dFacturacion)
        Dim l As New dFacturacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, cantidad, analisis, precio, subtotal, factura FROM facturacion WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FICHA = CType(unaFila.Item(1), Long)
                l.CANTIDAD = CType(unaFila.Item(2), Double)
                l.ANALISIS = CType(unaFila.Item(3), Integer)
                l.PRECIO = CType(unaFila.Item(4), Double)
                l.SUBTOTAL = CType(unaFila.Item(5), Double)
                l.FACTURA = CType(unaFila.Item(6), Long)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, cantidad, analisis, precio, subtotal, factura FROM facturacion order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dFacturacion
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.CANTIDAD = CType(unaFila.Item(2), Double)
                    l.ANALISIS = CType(unaFila.Item(3), Integer)
                    l.PRECIO = CType(unaFila.Item(4), Double)
                    l.SUBTOTAL = CType(unaFila.Item(5), Double)
                    l.FACTURA = CType(unaFila.Item(6), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxficha(ByVal ficha As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, cantidad, analisis, precio, subtotal, factura FROM facturacion WHERE ficha = " & ficha & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dFacturacion
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FICHA = CType(unaFila.Item(1), Long)
                    l.CANTIDAD = CType(unaFila.Item(2), Double)
                    l.ANALISIS = CType(unaFila.Item(3), Integer)
                    l.PRECIO = CType(unaFila.Item(4), Double)
                    l.SUBTOTAL = CType(unaFila.Item(5), Double)
                    l.FACTURA = CType(unaFila.Item(6), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
