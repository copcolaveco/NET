Public Class pCancelaCompra
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCancelaCompra = CType(o, dCancelaCompra)
        Dim sql As String = "INSERT INTO cancela_compra (id, idcompra, fecha, proveedor, usuariocreador, usuariocancela, visto) VALUES (" & obj.ID & ", " & obj.IDCOMPRA & ", '" & obj.FECHA & "', " & obj.PROVEEDOR & ", " & obj.USUARIOCREADOR & ", " & obj.USUARIOCANCELA & ", " & obj.VISTO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cancela_compra', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCancelaCompra = CType(o, dCancelaCompra)
        Dim sql As String = "UPDATE cancela_compra SET idcompra = " & obj.IDCOMPRA & ", fecha = '" & obj.FECHA & "', proveedor = " & obj.PROVEEDOR & ", usuariocreador = " & obj.USUARIOCREADOR & ", usuariocancela = " & obj.USUARIOCANCELA & ", visto = " & obj.VISTO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cancela_compra', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCancelaCompra = CType(o, dCancelaCompra)
        Dim sql As String = "DELETE FROM cancela_compra WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cancela_compra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCancelaCompra
        Dim obj As dCancelaCompra = CType(o, dCancelaCompra)
        Dim l As New dCancelaCompra
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idcompra, fecha, proveedor, usuariocreador, usuariocancela, visto FROM cancela_compra WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.IDCOMPRA = CType(unaFila.Item(1), Long)
                l.FECHA = CType(unaFila.Item(2), String)
                l.PROVEEDOR = CType(unaFila.Item(3), Integer)
                l.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                l.USUARIOCANCELA = CType(unaFila.Item(5), Integer)
                l.VISTO = CType(unaFila.Item(6), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idcompra, fecha, proveedor, usuariocreador, usuariocancela, visto FROM cancela_compra"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCancelaCompra
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDCOMPRA = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.PROVEEDOR = CType(unaFila.Item(3), Integer)
                    l.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    l.USUARIOCANCELA = CType(unaFila.Item(5), Integer)
                    l.VISTO = CType(unaFila.Item(6), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, idcompra, fecha, proveedor, usuariocreador, usuariocancela, visto FROM cancela_compra WHERE usuariocreador = " & idusuario & " AND visto = 0 "
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCancelaCompra
                    l.ID = CType(unaFila.Item(0), Long)
                    l.IDCOMPRA = CType(unaFila.Item(1), Long)
                    l.FECHA = CType(unaFila.Item(2), String)
                    l.PROVEEDOR = CType(unaFila.Item(3), Integer)
                    l.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    l.USUARIOCANCELA = CType(unaFila.Item(5), Integer)
                    l.VISTO = CType(unaFila.Item(6), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarvisto(ByVal o As Object) As Boolean
        Dim obj As dCancelaCompra = CType(o, dCancelaCompra)
        Dim sql As String = "UPDATE cancela_compra SET  visto= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
End Class
