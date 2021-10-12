Public Class pProductos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductos = CType(o, dProductos)
        Dim sql As String = "INSERT INTO productos (id, codigo, nombre, detalle, unidad, categoria, iva, stock, eliminado) VALUES (" & obj.ID & ", '" & obj.CODIGO & "','" & obj.NOMBRE & "', '" & obj.DETALLE & "', " & obj.UNIDAD & "," & obj.CATEGORIA & ", " & obj.IVA & ", " & obj.STOCK & ", " & obj.ELIMINADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductos = CType(o, dProductos)
        Dim sql As String = "UPDATE productos SET codigo ='" & obj.CODIGO & "', nombre ='" & obj.NOMBRE & "',detalle ='" & obj.DETALLE & "', unidad = " & obj.UNIDAD & ", categoria = " & obj.CATEGORIA & ", iva = " & obj.IVA & ", stock = " & obj.STOCK & ", eliminado = " & obj.ELIMINADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dProductos = CType(o, dProductos)
        'Dim sql As String = "DELETE FROM productos WHERE id = " & obj.ID & ""
        Dim sql As String = "UPDATE productos SET eliminado = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'productos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dProductos
        Dim obj As dProductos = CType(o, dProductos)
        Dim p As New dProductos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, codigo, nombre, detalle, unidad, categoria, iva, stock, eliminado FROM productos WHERE id = " & obj.ID & " AND eliminado = 0 ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Integer)
                p.CODIGO = CType(unaFila.Item(1), String)
                p.NOMBRE = CType(unaFila.Item(2), String)
                p.DETALLE = CType(unaFila.Item(3), String)
                p.UNIDAD = CType(unaFila.Item(4), Integer)
                p.CATEGORIA = CType(unaFila.Item(5), Integer)
                p.IVA = CType(unaFila.Item(6), Integer)
                p.STOCK = CType(unaFila.Item(7), Double)
                p.ELIMINADO = CType(unaFila.Item(8), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscar2(ByVal o As Object) As dProductos
        Dim obj As dProductos = CType(o, dProductos)
        Dim p As New dProductos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, codigo, nombre, detalle, unidad, categoria, iva, stock, eliminado FROM productos WHERE id = " & obj.ID & " ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Integer)
                p.CODIGO = CType(unaFila.Item(1), String)
                p.NOMBRE = CType(unaFila.Item(2), String)
                p.DETALLE = CType(unaFila.Item(3), String)
                p.UNIDAD = CType(unaFila.Item(4), Integer)
                p.CATEGORIA = CType(unaFila.Item(5), Integer)
                p.IVA = CType(unaFila.Item(6), Integer)
                p.STOCK = CType(unaFila.Item(7), Double)
                p.ELIMINADO = CType(unaFila.Item(8), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, codigo, nombre, detalle, unidad, categoria, iva, stock, eliminado FROM productos WHERE eliminado=0 ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductos
                    p.ID = CType(unaFila.Item(0), Integer)
                    p.CODIGO = CType(unaFila.Item(1), String)
                    p.NOMBRE = CType(unaFila.Item(2), String)
                    p.DETALLE = CType(unaFila.Item(3), String)
                    p.UNIDAD = CType(unaFila.Item(4), Integer)
                    p.CATEGORIA = CType(unaFila.Item(5), Integer)
                    p.IVA = CType(unaFila.Item(6), Integer)
                    p.STOCK = CType(unaFila.Item(7), Double)
                    p.ELIMINADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarmedios() As ArrayList
        Dim sql As String = "SELECT id, codigo, nombre, detalle, unidad, categoria, iva, stock, eliminado FROM productos WHERE categoria = 4 and eliminado =0 ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dProductos
                    p.ID = CType(unaFila.Item(0), Integer)
                    p.CODIGO = CType(unaFila.Item(1), String)
                    p.NOMBRE = CType(unaFila.Item(2), String)
                    p.DETALLE = CType(unaFila.Item(3), String)
                    p.UNIDAD = CType(unaFila.Item(4), Integer)
                    p.CATEGORIA = CType(unaFila.Item(5), Integer)
                    p.IVA = CType(unaFila.Item(6), Integer)
                    p.STOCK = CType(unaFila.Item(7), Double)
                    p.ELIMINADO = CType(unaFila.Item(8), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function buscarPorNombre(ByVal pNombre As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, codigo, nombre, detalle, unidad, categoria, iva, stock, eliminado FROM productos WHERE Nombre LIKE '%" & pNombre & "%' and eliminado=0 "

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductos()
                    p.ID = CType(unaFila.Item(0), Integer)
                    p.CODIGO = CType(unaFila.Item(1), String)
                    p.NOMBRE = CType(unaFila.Item(2), String)
                    p.DETALLE = CType(unaFila.Item(3), String)
                    p.UNIDAD = CType(unaFila.Item(4), Integer)
                    p.CATEGORIA = CType(unaFila.Item(5), Integer)
                    p.IVA = CType(unaFila.Item(6), Integer)
                    p.STOCK = CType(unaFila.Item(7), Double)
                    p.ELIMINADO = CType(unaFila.Item(8), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
    Public Function buscarPorCodigo(ByVal pcodigo As String) As ArrayList
        Dim listaResultado As New ArrayList

        Try
            Dim Ds As New DataSet
            Dim sql As String = "SELECT id, codigo, nombre, detalle, unidad, categoria, iva, stock, eliminado FROM productos WHERE codigo LIKE '%" & pcodigo & "%' and eliminado=0 "

            Ds = Me.EjecutarSQL(sql)

            If Ds.Tables(0).Rows.Count > 0 Then
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim p As New dProductos()
                    p.ID = CType(unaFila.Item(0), Integer)
                    p.CODIGO = CType(unaFila.Item(1), String)
                    p.NOMBRE = CType(unaFila.Item(2), String)
                    p.DETALLE = CType(unaFila.Item(3), String)
                    p.UNIDAD = CType(unaFila.Item(4), Integer)
                    p.CATEGORIA = CType(unaFila.Item(5), Integer)
                    p.IVA = CType(unaFila.Item(6), Integer)
                    p.STOCK = CType(unaFila.Item(7), Double)
                    p.ELIMINADO = CType(unaFila.Item(8), Integer)
                    listaResultado.Add(p)
                Next
                Return listaResultado
            End If
            Return listaResultado
        Catch ex As Exception
            Return listaResultado
        End Try
    End Function
End Class
