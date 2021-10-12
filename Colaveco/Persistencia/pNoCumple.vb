Public Class pNoCumple
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoCumple = CType(o, dNoCumple)
        Dim sql As String = "INSERT INTO incumplimientocompras (id, idlineacompra, fecha, puntualidad, calidad, cantidad, precio, factura, descripcion, usuario) VALUES (" & obj.ID & ", " & obj.IDLINEACOMPRA & ", '" & obj.FECHA & "', " & obj.PUNTUALIDAD & ", " & obj.CALIDAD & ", " & obj.CANTIDAD & ", " & obj.PRECIO & ", " & obj.FACTURA & ", '" & obj.DESCRIPCION & "', " & obj.USUARIO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'incumplimientocompras', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoCumple = CType(o, dNoCumple)
        Dim sql As String = "UPDATE incumplimientocompras SET idlineacompra= " & obj.IDLINEACOMPRA & ", fecha= '" & obj.FECHA & "', puntualidad = " & obj.PUNTUALIDAD & ", calidad = " & obj.CALIDAD & ", cantidad = " & obj.CANTIDAD & ", precio = " & obj.PRECIO & ", factura = " & obj.FACTURA & ", descripcion = '" & obj.DESCRIPCION & "', usuario = " & obj.USUARIO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'incumplimientocompras', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoCumple = CType(o, dNoCumple)
        Dim sql As String = "DELETE FROM incumplimientocompras WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'incumplimientocompras', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNoCumple
        Dim obj As dNoCumple = CType(o, dNoCumple)
        Dim l As New dNoCumple
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idlineacompra, fecha, puntualidad, calidad, cantidad, precio, factura, descripcion, usuario FROM incumplimientocompras WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDLINEACOMPRA = CType(unaFila.Item(1), Long)
                l.FECHA = CType(unaFila.Item(2), String)
                l.PUNTUALIDAD = CType(unaFila.Item(3), Integer)
                l.CALIDAD = CType(unaFila.Item(4), Integer)
                l.CANTIDAD = CType(unaFila.Item(5), Integer)
                l.PRECIO = CType(unaFila.Item(6), Integer)
                l.FACTURA = CType(unaFila.Item(7), Integer)
                l.DESCRIPCION = CType(unaFila.Item(8), String)
                l.USUARIO = CType(unaFila.Item(9), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxlineacompra(ByVal o As Object) As dNoCumple
        Dim obj As dNoCumple = CType(o, dNoCumple)
        Dim l As New dNoCumple
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idlineacompra, fecha, puntualidad, calidad, cantidad, precio, factura, descripcion, usuario FROM incumplimientocompras WHERE idlineacompra = " & obj.IDLINEACOMPRA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDLINEACOMPRA = CType(unaFila.Item(1), Long)
                l.FECHA = CType(unaFila.Item(2), String)
                l.PUNTUALIDAD = CType(unaFila.Item(3), Integer)
                l.CALIDAD = CType(unaFila.Item(4), Integer)
                l.CANTIDAD = CType(unaFila.Item(5), Integer)
                l.PRECIO = CType(unaFila.Item(6), Integer)
                l.FACTURA = CType(unaFila.Item(7), Integer)
                l.DESCRIPCION = CType(unaFila.Item(8), String)
                l.USUARIO = CType(unaFila.Item(9), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idlineacompra, fecha, puntualidad, calidad, cantidad, precio, factura, descripcion, usuario FROM incumplimientocompras"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dNoCumple
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDLINEACOMPRA = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.PUNTUALIDAD = CType(unaFila.Item(3), Integer)
                    l.CALIDAD = CType(unaFila.Item(4), Integer)
                    l.CANTIDAD = CType(unaFila.Item(5), Integer)
                    l.PRECIO = CType(unaFila.Item(6), Integer)
                    l.FACTURA = CType(unaFila.Item(7), Integer)
                    l.DESCRIPCION = CType(unaFila.Item(8), String)
                    l.USUARIO = CType(unaFila.Item(9), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
