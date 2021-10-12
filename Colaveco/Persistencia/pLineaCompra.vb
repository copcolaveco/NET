Public Class pLineaCompra
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "INSERT INTO lineacompra (id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, factura, lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, observaciones) VALUES (" & obj.ID & ", " & obj.IDCOMPRA & ", " & obj.PRODUCTO & ", " & obj.UNIDAD & ", " & obj.CANTIDAD & ", " & obj.PRESENTACION & ", " & obj.PRECIOANT & "," & obj.MONEDAANT & ",'" & obj.FECHAPRECIOANT & "','" & obj.RECIBIDO & "','" & obj.FACTURA & "', '" & obj.LOTE & "', '" & obj.VENCIMIENTO & "', " & obj.LOCACION & ", " & obj.PRECIO & ", " & obj.MONEDA & ", " & obj.NOCUMPLE & ", " & obj.APERTURA & ", '" & obj.FECHAAPERTURA & "', " & obj.CONSUMIDO & ",'" & obj.FECHACONSUMIDO & "', " & obj.DESCARTADO & ", '" & obj.FECHADESCARTADO & "', '" & obj.OBSERVACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "UPDATE lineacompra SET idcompra =" & obj.IDCOMPRA & ",producto =" & obj.PRODUCTO & ", unidad =" & obj.UNIDAD & ", cantidad =" & obj.CANTIDAD & ",presentacion =" & obj.PRESENTACION & ", precioant= " & obj.PRECIOANT & ", monedaant= " & obj.MONEDAANT & ", fechaprecioant= '" & obj.FECHAPRECIOANT & "', recibido= '" & obj.RECIBIDO & "', factura= '" & obj.FACTURA & "', lote ='" & obj.LOTE & "',vencimiento ='" & obj.VENCIMIENTO & "',locacion =" & obj.LOCACION & ",precio =" & obj.PRECIO & ",moneda =" & obj.MONEDA & ",nocumple =" & obj.NOCUMPLE & ",apertura =" & obj.APERTURA & ",fechaapertura ='" & obj.FECHAAPERTURA & "',consumido =" & obj.CONSUMIDO & ", fechaconsumido ='" & obj.FECHACONSUMIDO & "',descartado =" & obj.DESCARTADO & ",fechadescartado ='" & obj.FECHADESCARTADO & "',observaciones ='" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "UPDATE lineacompra SET cantidad =" & obj.CANTIDAD & ", recibido= '" & obj.RECIBIDO & "',factura= '" & obj.FACTURA & "', lote ='" & obj.LOTE & "',vencimiento ='" & obj.VENCIMIENTO & "',locacion =" & obj.LOCACION & ",precio =" & obj.PRECIO & ",moneda =" & obj.MONEDA & ", fechaapertura = '" & obj.FECHAAPERTURA & "',fechaconsumido = '" & obj.FECHACONSUMIDO & "',fechadescartado = '" & obj.FECHADESCARTADO & "'  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar3(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "UPDATE lineacompra SET vencimiento = '" & obj.VENCIMIENTO & "', apertura =" & obj.APERTURA & ",fechaapertura ='" & obj.FECHAAPERTURA & "',consumido =" & obj.CONSUMIDO & ",fechaconsumido ='" & obj.FECHACONSUMIDO & "',descartado =" & obj.DESCARTADO & ",fechadescartado ='" & obj.FECHADESCARTADO & "',observaciones ='" & obj.OBSERVACIONES & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function cambiarcantidad(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "UPDATE lineacompra SET cantidad =" & obj.CANTIDAD & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'cambiar_cantidad', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "DELETE FROM lineacompra WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxcompra(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "DELETE FROM lineacompra WHERE idcompra = " & obj.IDCOMPRA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dLineaCompra
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim p As New dLineaCompra
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.IDCOMPRA = CType(unaFila.Item(1), Long)
                p.PRODUCTO = CType(unaFila.Item(2), Integer)
                p.UNIDAD = CType(unaFila.Item(3), Integer)
                p.CANTIDAD = CType(unaFila.Item(4), Double)
                p.PRESENTACION = CType(unaFila.Item(5), Integer)
                p.PRECIOANT = CType(unaFila.Item(6), Double)
                p.MONEDAANT = CType(unaFila.Item(7), Integer)
                p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                p.RECIBIDO = CType(unaFila.Item(9), String)
                p.FACTURA = CType(unaFila.Item(10), String)
                p.LOTE = CType(unaFila.Item(11), String)
                p.VENCIMIENTO = CType(unaFila.Item(12), String)
                p.LOCACION = CType(unaFila.Item(13), Integer)
                p.PRECIO = CType(unaFila.Item(14), Double)
                p.MONEDA = CType(unaFila.Item(15), Integer)
                p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                p.APERTURA = CType(unaFila.Item(17), Integer)
                p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                p.DESCARTADO = CType(unaFila.Item(21), Integer)
                p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                p.OBSERVACIONES = CType(unaFila.Item(23), String)

                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxidcompra(ByVal o As Object) As dLineaCompra
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim p As New dLineaCompra
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE idcompra = " & obj.IDCOMPRA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.IDCOMPRA = CType(unaFila.Item(1), Long)
                p.PRODUCTO = CType(unaFila.Item(2), Integer)
                p.UNIDAD = CType(unaFila.Item(3), Integer)
                p.CANTIDAD = CType(unaFila.Item(4), Double)
                p.PRESENTACION = CType(unaFila.Item(5), Integer)
                p.PRECIOANT = CType(unaFila.Item(6), Double)
                p.MONEDAANT = CType(unaFila.Item(7), Integer)
                p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                p.RECIBIDO = CType(unaFila.Item(9), String)
                p.FACTURA = CType(unaFila.Item(10), String)
                p.LOTE = CType(unaFila.Item(11), String)
                p.VENCIMIENTO = CType(unaFila.Item(12), String)
                p.LOCACION = CType(unaFila.Item(13), Integer)
                p.PRECIO = CType(unaFila.Item(14), Double)
                p.MONEDA = CType(unaFila.Item(15), Integer)
                p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                p.APERTURA = CType(unaFila.Item(17), Integer)
                p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                p.DESCARTADO = CType(unaFila.Item(21), Integer)
                p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                p.OBSERVACIONES = CType(unaFila.Item(23), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimacompra(ByVal o As Object) As dLineaCompra
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim p As New dLineaCompra
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE producto = " & obj.PRODUCTO & " ORDER BY id DESC LIMIT 1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.IDCOMPRA = CType(unaFila.Item(1), Long)
                p.PRODUCTO = CType(unaFila.Item(2), Integer)
                p.UNIDAD = CType(unaFila.Item(3), Integer)
                p.CANTIDAD = CType(unaFila.Item(4), Double)
                p.PRESENTACION = CType(unaFila.Item(5), Integer)
                p.PRECIOANT = CType(unaFila.Item(6), Double)
                p.MONEDAANT = CType(unaFila.Item(7), Integer)
                p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                p.RECIBIDO = CType(unaFila.Item(9), String)
                p.FACTURA = CType(unaFila.Item(10), String)
                p.LOTE = CType(unaFila.Item(11), String)
                p.VENCIMIENTO = CType(unaFila.Item(12), String)
                p.LOCACION = CType(unaFila.Item(13), Integer)
                p.PRECIO = CType(unaFila.Item(14), Double)
                p.MONEDA = CType(unaFila.Item(15), Integer)
                p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                p.APERTURA = CType(unaFila.Item(17), Integer)
                p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                p.DESCARTADO = CType(unaFila.Item(21), Integer)
                p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                p.OBSERVACIONES = CType(unaFila.Item(23), String)

                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimos10(ByVal idproducto As Integer) As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE producto = " & idproducto & " ORDER BY idcompra DESC LIMIT 10"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxidcompra(ByVal idcompra As Long) As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE idcompra= " & idcompra & " ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxidproducto(ByVal idproducto As Long) As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE producto= " & idproducto & " ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxidproducto2(ByVal idproducto As Long) As ArrayList
        Dim sql As String = "SELECT DISTINCT idcompra FROM lineacompra WHERE producto= " & idproducto & " ORDER BY idcompra ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.IDCOMPRA = CType(unaFila.Item(0), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarenuso(ByVal producto As Long) As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE producto = " & producto & " AND apertura= 1 AND consumido = 0 ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinabrir(ByVal producto As Long) As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE producto = " & producto & " AND apertura= 0  AND consumido =0 AND descartado= 0 ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarconsumidos(ByVal producto As Long) As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE producto = " & producto & " AND  consumido = 1 ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardescartados(ByVal producto As Long) As ArrayList
        Dim sql As String = "SELECT id, idcompra, producto, unidad, cantidad, presentacion, precioant, monedaant, fechaprecioant, recibido, ifnull(factura,''), lote, vencimiento, locacion, precio, moneda, nocumple, apertura, fechaapertura, consumido, fechaconsumido, descartado, fechadescartado, ifnull(observaciones,'') FROM lineacompra WHERE producto = " & producto & " AND  descartado = 1 ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLineaCompra
                    p.ID = CType(unaFila.Item(0), Long)
                    p.IDCOMPRA = CType(unaFila.Item(1), Long)
                    p.PRODUCTO = CType(unaFila.Item(2), Integer)
                    p.UNIDAD = CType(unaFila.Item(3), Integer)
                    p.CANTIDAD = CType(unaFila.Item(4), Double)
                    p.PRESENTACION = CType(unaFila.Item(5), Integer)
                    p.PRECIOANT = CType(unaFila.Item(6), Double)
                    p.MONEDAANT = CType(unaFila.Item(7), Integer)
                    p.FECHAPRECIOANT = CType(unaFila.Item(8), String)
                    p.RECIBIDO = CType(unaFila.Item(9), String)
                    p.FACTURA = CType(unaFila.Item(10), String)
                    p.LOTE = CType(unaFila.Item(11), String)
                    p.VENCIMIENTO = CType(unaFila.Item(12), String)
                    p.LOCACION = CType(unaFila.Item(13), Integer)
                    p.PRECIO = CType(unaFila.Item(14), Double)
                    p.MONEDA = CType(unaFila.Item(15), Integer)
                    p.NOCUMPLE = CType(unaFila.Item(16), Integer)
                    p.APERTURA = CType(unaFila.Item(17), Integer)
                    p.FECHAAPERTURA = CType(unaFila.Item(18), String)
                    p.CONSUMIDO = CType(unaFila.Item(19), Integer)
                    p.FECHACONSUMIDO = CType(unaFila.Item(20), String)
                    p.DESCARTADO = CType(unaFila.Item(21), Integer)
                    p.FECHADESCARTADO = CType(unaFila.Item(22), String)
                    p.OBSERVACIONES = CType(unaFila.Item(23), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarnocumple(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "UPDATE lineacompra SET  nocumple= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'marcarnocumple', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcardescartado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLineaCompra = CType(o, dLineaCompra)
        Dim sql As String = "UPDATE lineacompra SET  descartado= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'lineacompra', 'marcardescartado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
End Class
