Public Class pListaPrecios
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaPrecios = CType(o, dListaPrecios)
        Dim sql As String = "INSERT INTO listadeprecios (id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, abreviatura, acreditado, orden, ocultar, paquete, mostrar_r) VALUES (" & obj.ID & ", '" & obj.CODIGO & "', '" & obj.DESCRIPCION & "', " & obj.PRECIO1 & ", " & obj.PRECIO2 & ", " & obj.PRECIO3 & ", " & obj.PRECIO4 & ", " & obj.PRECIO5 & ", " & obj.PRECIO6 & ", " & obj.PRECIO7 & ", " & obj.TI & ", '" & obj.DESCTECNICA & "', " & obj.TIPOCONTROL & ", '" & obj.ABREVIATURA & "', " & obj.ACREDITADO & ", " & obj.ORDEN & ", " & obj.OCULTAR & ", " & obj.PAQUETE & ", " & obj.MOSTRAR_R & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listadeprecios', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaPrecios = CType(o, dListaPrecios)
        Dim sql As String = "UPDATE listadeprecios SET codigo = '" & obj.CODIGO & "', descripcion='" & obj.DESCRIPCION & "', precio1=" & obj.PRECIO1 & ", precio2=" & obj.PRECIO2 & ", precio3=" & obj.PRECIO3 & ", precio4=" & obj.PRECIO4 & ", precio5=" & obj.PRECIO5 & ", precio6=" & obj.PRECIO6 & ", precio7=" & obj.PRECIO7 & ", ti = " & obj.TI & " , desctecnica = '" & obj.DESCTECNICA & "' , tipocontrol = " & obj.TIPOCONTROL & ", abreviatura = '" & obj.ABREVIATURA & "', acreditado = " & obj.ACREDITADO & " , orden = " & obj.ORDEN & ", ocultar = " & obj.OCULTAR & ", paquete = " & obj.PAQUETE & ", mostrar_r = " & obj.MOSTRAR_R & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listadeprecios', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcar_acreditado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaPrecios = CType(o, dListaPrecios)
        Dim sql As String = "UPDATE listadeprecios SET acreditado = 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listadeprecios', 'marcar_acreditado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcar_acreditado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaPrecios = CType(o, dListaPrecios)
        Dim sql As String = "UPDATE listadeprecios SET acreditado = 0 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listadeprecios', 'marcar_acreditado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaPrecios = CType(o, dListaPrecios)
        Dim sql As String = "DELETE FROM listadeprecios WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listadeprecios', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dListaPrecios
        Dim obj As dListaPrecios = CType(o, dListaPrecios)
        Dim l As New dListaPrecios
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.CODIGO = CType(unaFila.Item(1), String)
                l.DESCRIPCION = CType(unaFila.Item(2), String)
                l.PRECIO1 = CType(unaFila.Item(3), Double)
                l.PRECIO2 = CType(unaFila.Item(4), Double)
                l.PRECIO3 = CType(unaFila.Item(5), Double)
                l.PRECIO4 = CType(unaFila.Item(6), Double)
                l.PRECIO5 = CType(unaFila.Item(7), Double)
                l.PRECIO6 = CType(unaFila.Item(8), Double)
                l.PRECIO7 = CType(unaFila.Item(9), Double)
                l.TI = CType(unaFila.Item(10), Integer)
                l.DESCTECNICA = CType(unaFila.Item(11), String)
                l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                l.ABREVIATURA = CType(unaFila.Item(13), String)
                l.ACREDITADO = CType(unaFila.Item(14), Integer)
                l.ORDEN = CType(unaFila.Item(15), Integer)
                l.OCULTAR = CType(unaFila.Item(16), Integer)
                l.PAQUETE = CType(unaFila.Item(17), Integer)
                l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dListaPrecios
        Dim obj As dListaPrecios = CType(o, dListaPrecios)
        Dim l As New dListaPrecios
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios ORDER BY id DESC LIMIT 1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.CODIGO = CType(unaFila.Item(1), String)
                l.DESCRIPCION = CType(unaFila.Item(2), String)
                l.PRECIO1 = CType(unaFila.Item(3), Double)
                l.PRECIO2 = CType(unaFila.Item(4), Double)
                l.PRECIO3 = CType(unaFila.Item(5), Double)
                l.PRECIO4 = CType(unaFila.Item(6), Double)
                l.PRECIO5 = CType(unaFila.Item(7), Double)
                l.PRECIO6 = CType(unaFila.Item(8), Double)
                l.PRECIO7 = CType(unaFila.Item(9), Double)
                l.TI = CType(unaFila.Item(10), Integer)
                l.DESCTECNICA = CType(unaFila.Item(11), String)
                l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                l.ABREVIATURA = CType(unaFila.Item(13), String)
                l.ACREDITADO = CType(unaFila.Item(14), Integer)
                l.ORDEN = CType(unaFila.Item(15), Integer)
                l.OCULTAR = CType(unaFila.Item(16), Integer)
                l.PAQUETE = CType(unaFila.Item(17), Integer)
                l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios order by descripcion asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaPrecios
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CODIGO = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.PRECIO1 = CType(unaFila.Item(3), Double)
                    l.PRECIO2 = CType(unaFila.Item(4), Double)
                    l.PRECIO3 = CType(unaFila.Item(5), Double)
                    l.PRECIO4 = CType(unaFila.Item(6), Double)
                    l.PRECIO5 = CType(unaFila.Item(7), Double)
                    l.PRECIO6 = CType(unaFila.Item(8), Double)
                    l.PRECIO7 = CType(unaFila.Item(9), Double)
                    l.TI = CType(unaFila.Item(10), Integer)
                    l.DESCTECNICA = CType(unaFila.Item(11), String)
                    l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                    l.ABREVIATURA = CType(unaFila.Item(13), String)
                    l.ACREDITADO = CType(unaFila.Item(14), Integer)
                    l.ORDEN = CType(unaFila.Item(15), Integer)
                    l.OCULTAR = CType(unaFila.Item(16), Integer)
                    l.PAQUETE = CType(unaFila.Item(17), Integer)
                    l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxti(ByVal idti As Integer) As ArrayList
        Dim sql As String = "SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios WHERE ti = " & idti & "  order by descripcion asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaPrecios
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CODIGO = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.PRECIO1 = CType(unaFila.Item(3), Double)
                    l.PRECIO2 = CType(unaFila.Item(4), Double)
                    l.PRECIO3 = CType(unaFila.Item(5), Double)
                    l.PRECIO4 = CType(unaFila.Item(6), Double)
                    l.PRECIO5 = CType(unaFila.Item(7), Double)
                    l.PRECIO6 = CType(unaFila.Item(8), Double)
                    l.PRECIO7 = CType(unaFila.Item(9), Double)
                    l.TI = CType(unaFila.Item(10), Integer)
                    l.DESCTECNICA = CType(unaFila.Item(11), String)
                    l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                    l.ABREVIATURA = CType(unaFila.Item(13), String)
                    l.ACREDITADO = CType(unaFila.Item(14), Integer)
                    l.ORDEN = CType(unaFila.Item(15), Integer)
                    l.OCULTAR = CType(unaFila.Item(16), Integer)
                    l.PAQUETE = CType(unaFila.Item(17), Integer)
                    l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar_solo_analisis(ByVal idti As Integer) As ArrayList
        Dim sql As String = "SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios WHERE ti = " & idti & "  AND paquete = 0 order by descripcion asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaPrecios
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CODIGO = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.PRECIO1 = CType(unaFila.Item(3), Double)
                    l.PRECIO2 = CType(unaFila.Item(4), Double)
                    l.PRECIO3 = CType(unaFila.Item(5), Double)
                    l.PRECIO4 = CType(unaFila.Item(6), Double)
                    l.PRECIO5 = CType(unaFila.Item(7), Double)
                    l.PRECIO6 = CType(unaFila.Item(8), Double)
                    l.PRECIO7 = CType(unaFila.Item(9), Double)
                    l.TI = CType(unaFila.Item(10), Integer)
                    l.DESCTECNICA = CType(unaFila.Item(11), String)
                    l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                    l.ABREVIATURA = CType(unaFila.Item(13), String)
                    l.ACREDITADO = CType(unaFila.Item(14), Integer)
                    l.ORDEN = CType(unaFila.Item(15), Integer)
                    l.OCULTAR = CType(unaFila.Item(16), Integer)
                    l.PAQUETE = CType(unaFila.Item(17), Integer)
                    l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpaquetes(ByVal idti As Integer) As ArrayList
        Dim sql As String = "SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios WHERE ti = " & idti & " AND paquete = 1 order by descripcion asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaPrecios
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CODIGO = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.PRECIO1 = CType(unaFila.Item(3), Double)
                    l.PRECIO2 = CType(unaFila.Item(4), Double)
                    l.PRECIO3 = CType(unaFila.Item(5), Double)
                    l.PRECIO4 = CType(unaFila.Item(6), Double)
                    l.PRECIO5 = CType(unaFila.Item(7), Double)
                    l.PRECIO6 = CType(unaFila.Item(8), Double)
                    l.PRECIO7 = CType(unaFila.Item(9), Double)
                    l.TI = CType(unaFila.Item(10), Integer)
                    l.DESCTECNICA = CType(unaFila.Item(11), String)
                    l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                    l.ABREVIATURA = CType(unaFila.Item(13), String)
                    l.ACREDITADO = CType(unaFila.Item(14), Integer)
                    l.ORDEN = CType(unaFila.Item(15), Integer)
                    l.OCULTAR = CType(unaFila.Item(16), Integer)
                    l.PAQUETE = CType(unaFila.Item(17), Integer)
                    l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarparasolicitud(ByVal idti As Integer) As ArrayList
        Dim sql As String = "SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios WHERE ti = " & idti & " AND ocultar = 0 order by descripcion asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaPrecios
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CODIGO = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.PRECIO1 = CType(unaFila.Item(3), Double)
                    l.PRECIO2 = CType(unaFila.Item(4), Double)
                    l.PRECIO3 = CType(unaFila.Item(5), Double)
                    l.PRECIO4 = CType(unaFila.Item(6), Double)
                    l.PRECIO5 = CType(unaFila.Item(7), Double)
                    l.PRECIO6 = CType(unaFila.Item(8), Double)
                    l.PRECIO7 = CType(unaFila.Item(9), Double)
                    l.TI = CType(unaFila.Item(10), Integer)
                    l.DESCTECNICA = CType(unaFila.Item(11), String)
                    l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                    l.ABREVIATURA = CType(unaFila.Item(13), String)
                    l.ACREDITADO = CType(unaFila.Item(14), Integer)
                    l.ORDEN = CType(unaFila.Item(15), Integer)
                    l.OCULTAR = CType(unaFila.Item(16), Integer)
                    l.PAQUETE = CType(unaFila.Item(17), Integer)
                    l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxdescripcion(ByVal nombre As String) As ArrayList
        Dim sql As String = "SELECT id, codigo, descripcion, precio1, precio2, precio3, precio4, precio5, precio6, precio7, ti, desctecnica, tipocontrol, ifnull(abreviatura,''), acreditado, orden, ocultar, paquete, mostrar_r FROM listadeprecios WHERE descripcion LIKE '%" & nombre & "%' order by descripcion asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaPrecios
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.CODIGO = CType(unaFila.Item(1), String)
                    l.DESCRIPCION = CType(unaFila.Item(2), String)
                    l.PRECIO1 = CType(unaFila.Item(3), Double)
                    l.PRECIO2 = CType(unaFila.Item(4), Double)
                    l.PRECIO3 = CType(unaFila.Item(5), Double)
                    l.PRECIO4 = CType(unaFila.Item(6), Double)
                    l.PRECIO5 = CType(unaFila.Item(7), Double)
                    l.PRECIO6 = CType(unaFila.Item(8), Double)
                    l.PRECIO7 = CType(unaFila.Item(9), Double)
                    l.TI = CType(unaFila.Item(10), Integer)
                    l.DESCTECNICA = CType(unaFila.Item(11), String)
                    l.TIPOCONTROL = CType(unaFila.Item(12), Integer)
                    l.ABREVIATURA = CType(unaFila.Item(13), String)
                    l.ACREDITADO = CType(unaFila.Item(14), Integer)
                    l.ORDEN = CType(unaFila.Item(15), Integer)
                    l.OCULTAR = CType(unaFila.Item(16), Integer)
                    l.PAQUETE = CType(unaFila.Item(17), Integer)
                    l.MOSTRAR_R = CType(unaFila.Item(18), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
