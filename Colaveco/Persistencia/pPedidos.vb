Public Class pPedidos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim sql As String = "INSERT INTO pedidos (id, fecha, fechaposenvio, idproductor, direccion, telefono, idagencia, idtecnico, responsable,  rc_compos, agua, sangre, esteriles, otros, observaciones, factura1, cantidad1, factura2, cantidad2, factura3, cantidad3, enviado, facturado, eliminado, usuario, convenio, pendiente, marca) VALUES (" & obj.ID & ",'" & obj.FECHA & "', '" & obj.FECHAPOSENVIO & "'," & obj.IDPRODUCTOR & ",'" & obj.DIRECCION & "', '" & obj.TELEFONO & "'," & obj.IDAGENCIA & "," & obj.IDTECNICO & ", '" & obj.RESPONSABLE & "'," & obj.RC_COMPOS & "," & obj.AGUA & "," & obj.SANGRE & ", " & obj.ESTERILES & "," & obj.OTROS & ",'" & obj.OBSERVACIONES & "'," & obj.FACTURA1 & "," & obj.CANTIDAD1 & "," & obj.FACTURA2 & "," & obj.CANTIDAD2 & "," & obj.FACTURA3 & "," & obj.CANTIDAD3 & ", " & obj.ENVIADO & ", " & obj.FACTURADO & ", " & obj.ELIMINADO & ", " & obj.IDUSUARIO & ", " & obj.CONVENIO & ", " & obj.PENDIENTE & ", " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim sql As String = "UPDATE pedidos SET fecha ='" & obj.FECHA & "',fechaposenvio ='" & obj.FECHAPOSENVIO & "',idproductor =" & obj.IDPRODUCTOR & ",direccion ='" & obj.DIRECCION & "',telefono ='" & obj.TELEFONO & "',idagencia =" & obj.IDAGENCIA & ",idtecnico =" & obj.IDTECNICO & ",responsable ='" & obj.RESPONSABLE & "', rc_compos =" & obj.RC_COMPOS & ", agua=" & obj.AGUA & ", sangre =" & obj.SANGRE & ", esteriles =  " & obj.ESTERILES & ", otros =" & obj.OTROS & ", observaciones ='" & obj.OBSERVACIONES & "', factura1 =" & obj.FACTURA1 & ", cantidad1 =" & obj.CANTIDAD1 & ", factura2 =" & obj.FACTURA2 & ", cantidad2 =" & obj.CANTIDAD2 & ", factura3 =" & obj.FACTURA3 & ", cantidad3 =" & obj.CANTIDAD3 & ", enviado=" & obj.ENVIADO & ", facturado=" & obj.FACTURADO & ", eliminado=" & obj.ELIMINADO & ", usuario=" & obj.IDUSUARIO & ", convenio=" & obj.CONVENIO & ", pendiente=" & obj.PENDIENTE & ", marca=" & obj.MARCA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidos = CType(o, dPedidos)
        'Dim sql As String = "DELETE FROM pedidos WHERE id = " & obj.ID
        Dim sql As String = "UPDATE pedidos SET eliminado =1 WHERE id = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pedidos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPedidos
        Dim obj As dPedidos = CType(o, dPedidos)
        Dim p As New dPedidos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, fechaposenvio, idproductor,direccion, telefono,idagencia, idtecnico,responsable, rc_compos, agua, sangre, esteriles, otros, observaciones, factura1, cantidad1, factura2, cantidad2, factura3, cantidad3, enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FECHA = CType(unaFila.Item(1), String)
                p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                p.DIRECCION = CType(unaFila.Item(4), String)
                p.TELEFONO = CType(unaFila.Item(5), String)
                p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                p.IDTECNICO = CType(unaFila.Item(7), Integer)
                p.RESPONSABLE = CType(unaFila.Item(8), String)
                p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                p.AGUA = CType(unaFila.Item(10), Integer)
                p.SANGRE = CType(unaFila.Item(11), Integer)
                p.ESTERILES = CType(unaFila.Item(12), Integer)
                p.OTROS = CType(unaFila.Item(13), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(14), String)
                p.FACTURA1 = CType(unaFila.Item(15), Long)
                p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                p.FACTURA2 = CType(unaFila.Item(17), Long)
                p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                p.FACTURA3 = CType(unaFila.Item(19), Long)
                p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                p.ENVIADO = CType(unaFila.Item(21), Integer)
                p.FACTURADO = CType(unaFila.Item(22), Integer)
                p.ELIMINADO = CType(unaFila.Item(23), Integer)
                p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                p.CONVENIO = CType(unaFila.Item(25), Integer)
                p.PENDIENTE = CType(unaFila.Item(26), Integer)
                p.MARCA = CType(unaFila.Item(27), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE enviado = 0 and eliminado = 0 order by fechaposenvio asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpendientes() As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE enviado = 0 and eliminado = 0 and pendiente = 1 order by fechaposenvio asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfrascospormes(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT YEAR(fecha) AS AÑO, MONTH(fecha) AS MES, SUM(rc_compos) as totalrc, SUM(agua) AS totalagua, SUM(sangre) AS totalsangre, SUM(esteriles) AS totalesteriles, SUM(otros) AS totalotros FROM pedidos WHERE fecha>= '" & desde & "' and fecha<= '" & hasta & "' and eliminado=0 GROUP BY AÑO DESC, MES DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim inf As New dInformeFrascosxMes
                    inf.AÑO = CType(unaFila.Item(0), String)
                    inf.MES = CType(unaFila.Item(1), String)
                    inf.TOTALRC = CType(unaFila.Item(2), Long)
                    inf.TOTALAGUA = CType(unaFila.Item(3), Long)
                    inf.TOTALSANGRE = CType(unaFila.Item(4), Long)
                    inf.TOTALESTERILES = CType(unaFila.Item(5), Long)
                    inf.TOTALOTROS = CType(unaFila.Item(6), Long)
                    Lista.Add(inf)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorFecha(ByVal pFecha As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0) FROM pedidos WHERE fecha ='" & pFecha & "'"
            'Dim sql As String = "SELECT ID, ifnull(Nombre,''), ifnull(Email1,''), ifnull(Email2,''),ifnull(Email3,''), ifnull(Envio,''), ifnull(usuario_web,''), ifnull(Razon_social,''),ifnull(Telefono_2,''), ifnull(Telefono_3,''), ifnull(Celular_1,''), ifnull(Celular_2,''), ifnull(Celular_3,''), ifnull(RUC,''), ifnull(CodigoFigaro,''), ifnull(TipoUsuario,1), ifnull(Direccion,''), ifnull(Telefono,''), ifnull(Fax,''), ifnull(DICOSE,''), ifnull(IDDepartamento,999), ifnull(IDLocalidad,999), ifnull(Tecnico,''), ifnull(camino_control_lechero,''), ifnull(camino_calidad_leche,''), ifnull(camino_analisis_de_agua,''), ifnull(camino_pal,''),ifnull(camino_rosa_bengala,''), ifnull(camino_antibiograma,'') FROM pedidos WHERE Nombre LIKE '%" & pNombre & "%'"

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dPedidos()
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function marcar(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidos SET marca = 1 WHERE id = " & idPedido

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'marcar', " & idPedido & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarEnvio(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidos SET enviado = 1 WHERE id = " & idPedido

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'marcar envio', " & idPedido & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarPedido(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidos SET enviado = 0 and eliminado=0 WHERE id = " & idPedido

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'marcar envio', " & idPedido & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarpendiente(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidos SET pendiente = 1 WHERE id = " & idPedido & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'marcar envio', " & idPedido & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarpendiente(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidos SET pendiente = 0 WHERE id = " & idPedido & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'marcar envio', " & idPedido & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarFacturado(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pedidos SET facturado = 1 WHERE id = " & idPedido & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pedidos', 'marcar facturado', " & idPedido & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function listarxcliente(ByVal texto As Long) As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE enviado = 1 and eliminado = 0 and idproductor = " & texto
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporcliente(ByVal cliente As Long) As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE eliminado = 0 and idproductor = " & cliente & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE eliminado = 0 and fecha >='" & desde & "' and fecha <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecharc(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE eliminado = 0 and rc_compos >0 and fechaposenvio >='" & desde & "' and fechaposenvio <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfechaxcliente(ByVal desde As String, ByVal hasta As String, ByVal cliente As Long) As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE eliminado = 0 and fecha >='" & desde & "' and fecha <='" & hasta & "' and idproductor = " & cliente & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinfacturarsangre() As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE eliminado = 0 and facturado = 0 and sangre >0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinfacturaragua() As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca FROM pedidos WHERE eliminado = 0 and facturado = 0 and agua >0"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarPedidosFinalizados() As ArrayList
        Dim sql As String = "SELECT id, fecha, fechaposenvio, idproductor, direccion, ifnull(telefono,''), idagencia, ifnull(idtecnico,999),ifnull(responsable,''), ifnull(rc_compos,0),ifnull(agua,0), ifnull(sangre,0), ifnull(esteriles,0), ifnull(otros,0), ifnull(observaciones,''), ifnull(factura1,0), ifnull(cantidad1,0), ifnull(factura2,0), ifnull(cantidad2,0), ifnull(factura3,0), ifnull(cantidad3,0), enviado, facturado, eliminado, usuario, convenio, pendiente, marca, status FROM pedidos WHERE status = 2 order by 1 desc limit 1000"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dPedidos
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.FECHAPOSENVIO = CType(unaFila.Item(2), String)
                    p.IDPRODUCTOR = CType(unaFila.Item(3), Long)
                    p.DIRECCION = CType(unaFila.Item(4), String)
                    p.TELEFONO = CType(unaFila.Item(5), String)
                    p.IDAGENCIA = CType(unaFila.Item(6), Integer)
                    p.IDTECNICO = CType(unaFila.Item(7), Integer)
                    p.RESPONSABLE = CType(unaFila.Item(8), String)
                    p.RC_COMPOS = CType(unaFila.Item(9), Integer)
                    p.AGUA = CType(unaFila.Item(10), Integer)
                    p.SANGRE = CType(unaFila.Item(11), Integer)
                    p.ESTERILES = CType(unaFila.Item(12), Integer)
                    p.OTROS = CType(unaFila.Item(13), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(14), String)
                    p.FACTURA1 = CType(unaFila.Item(15), Long)
                    p.CANTIDAD1 = CType(unaFila.Item(16), Integer)
                    p.FACTURA2 = CType(unaFila.Item(17), Long)
                    p.CANTIDAD2 = CType(unaFila.Item(18), Integer)
                    p.FACTURA3 = CType(unaFila.Item(19), Long)
                    p.CANTIDAD3 = CType(unaFila.Item(20), Integer)
                    p.ENVIADO = CType(unaFila.Item(21), Integer)
                    p.FACTURADO = CType(unaFila.Item(22), Integer)
                    p.ELIMINADO = CType(unaFila.Item(23), Integer)
                    p.IDUSUARIO = CType(unaFila.Item(24), Integer)
                    p.CONVENIO = CType(unaFila.Item(25), Integer)
                    p.PENDIENTE = CType(unaFila.Item(26), Integer)
                    p.MARCA = CType(unaFila.Item(27), Integer)
                    p.STATUS = CType(unaFila.Item(28), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
