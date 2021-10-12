Public Class pLineaCotizacion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCotizacion = CType(o, dLineaCotizacion)
        Dim sql As String = "INSERT INTO lineacotizacion (id, idcotizacion, producto, cantidad, unidad, presentacion, precio, moneda, fechaprecio) VALUES (" & obj.ID & ", " & obj.IDCOTIZACION & ", " & obj.PRODUCTO & ", " & obj.CANTIDAD & ", " & obj.UNIDAD & ", " & obj.PRESENTACION & "," & obj.PRECIO & ", " & obj.MONEDA & ", '" & obj.FECHAPRECIO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacotizacion', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCotizacion = CType(o, dLineaCotizacion)
        Dim sql As String = "UPDATE lineacotizacion SET idcotizacion =" & obj.IDCOTIZACION & ",producto =" & obj.PRODUCTO & ",cantidad =" & obj.CANTIDAD & ",unidad =" & obj.UNIDAD & ", presentacion =" & obj.PRESENTACION & ",precio =" & obj.PRECIO & ", moneda =" & obj.MONEDA & ", fechaprecio ='" & obj.FECHAPRECIO & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacotizacion', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
   
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCotizacion = CType(o, dLineaCotizacion)
        Dim sql As String = "DELETE FROM lineacotizacion WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacotizacion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dLineaCotizacion
        Dim obj As dLineaCotizacion = CType(o, dLineaCotizacion)
        Dim p As New dLineaCotizacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idcotizacion, producto, cantidad, unidad, presentacion, precio, moneda, fechaprecio FROM lineacotizacion WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.IDCOTIZACION = CType(unaFila.Item(1), Long)
                p.PRODUCTO = CType(unaFila.Item(2), Integer)
                p.CANTIDAD = CType(unaFila.Item(3), Double)
                p.UNIDAD = CType(unaFila.Item(4), Integer)
                p.PRESENTACION = CType(unaFila.Item(5), Integer)
                p.PRECIO = CType(unaFila.Item(6), Double)
                p.MONEDA = CType(unaFila.Item(7), Integer)
                p.FECHAPRECIO = CType(unaFila.Item(8), String)

                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idcotizacion, producto, cantidad, unidad, presentacion, precio, moneda, fechaprecio FROM lineacotizacion ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCotizacion
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOTIZACION = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.CANTIDAD = CType(unaFila.Item(3), Double)
                    p.UNIDAD = CType(unaFila.Item(4), Integer)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIO = CType(unaFila.Item(6), Double)
                    p.MONEDA = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIO = CType(unaFila.Item(8), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxidcotizacion(ByVal idcotizacion As Long) As ArrayList
        Dim sql As String = "SELECT id, idcotizacion, producto, cantidad, unidad, presentacion, precio, moneda, fechaprecio FROM lineacotizacion WHERE idcotizacion= " & idcotizacion & " ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCotizacion
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOTIZACION = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.CANTIDAD = CType(unaFila.Item(3), Double)
                    p.UNIDAD = CType(unaFila.Item(4), Integer)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIO = CType(unaFila.Item(6), Double)
                    p.MONEDA = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIO = CType(unaFila.Item(8), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
End Class
