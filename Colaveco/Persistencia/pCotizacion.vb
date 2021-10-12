Public Class pCotizacion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim sql As String = "INSERT INTO cotizacion (id, proveedor, email,proveedor2, email2,proveedor3, email3, fecha, usuariocreador, enviado, observaciones, asociada, anulada) VALUES (" & obj.ID & ", " & obj.PROVEEDOR & ", '" & obj.EMAIL & "'," & obj.PROVEEDOR2 & ", '" & obj.EMAIL2 & "'," & obj.PROVEEDOR3 & ", '" & obj.EMAIL3 & "', '" & obj.FECHA & "', " & obj.USUARIOCREADOR & ", " & obj.ENVIADO & ", '" & obj.OBSERVACIONES & "', " & obj.ASOCIADA & ", " & obj.ANULADA & " )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cotizacion', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim sql As String = "UPDATE cotizacion SET proveedor =" & obj.PROVEEDOR & ", email = '" & obj.EMAIL & "',proveedor2 =" & obj.PROVEEDOR2 & ", email2 = '" & obj.EMAIL2 & "',proveedor3 =" & obj.PROVEEDOR3 & ", email3 = '" & obj.EMAIL3 & "', fecha= '" & obj.FECHA & "',usuariocreador= " & obj.USUARIOCREADOR & ", enviado= " & obj.ENVIADO & ", observaciones= '" & obj.OBSERVACIONES & "', asociada= " & obj.ASOCIADA & ", anulada= " & obj.ANULADA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cotizacion', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function marcaranulada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim sql As String = "UPDATE cotizacion SET anulada= 1  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cotizacion', 'marcaranulada', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function marcarenviado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim sql As String = "UPDATE cotizacion SET  enviado= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cotizacion', 'marcarenviado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarasociada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim sql As String = "UPDATE cotizacion SET  asociada= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cotizacion', 'marcarenviado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim sql As String = "DELETE FROM cotizacion WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cotizacion', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCotizacion
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim p As New dCotizacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, proveedor, ifnull(email,''),proveedor2, ifnull(email2,''),proveedor3, ifnull(email3,''), fecha, usuariocreador, enviado, observaciones, asociada, anulada FROM cotizacion WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.PROVEEDOR2 = CType(unaFila.Item(3), Integer)
                p.EMAIL2 = CType(unaFila.Item(4), String)
                p.PROVEEDOR3 = CType(unaFila.Item(5), Integer)
                p.EMAIL3 = CType(unaFila.Item(6), String)
                p.FECHA = CType(unaFila.Item(7), String)
                p.USUARIOCREADOR = CType(unaFila.Item(8), Integer)
                p.ENVIADO = CType(unaFila.Item(9), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(10), String)
                p.ASOCIADA = CType(unaFila.Item(11), Integer)
                p.ANULADA = CType(unaFila.Item(12), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''),proveedor2, ifnull(email2,''),proveedor3, ifnull(email3,''), fecha, usuariocreador, enviado, observaciones, asociada, anulada FROM cotizacion ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCotizacion
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.PROVEEDOR2 = CType(unaFila.Item(3), Integer)
                    p.EMAIL2 = CType(unaFila.Item(4), String)
                    p.PROVEEDOR3 = CType(unaFila.Item(5), Integer)
                    p.EMAIL3 = CType(unaFila.Item(6), String)
                    p.FECHA = CType(unaFila.Item(7), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(10), String)
                    p.ASOCIADA = CType(unaFila.Item(11), Integer)
                    p.ANULADA = CType(unaFila.Item(12), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinasociar() As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''),proveedor2, ifnull(email2,''),proveedor3, ifnull(email3,''), fecha, usuariocreador, enviado, observaciones, asociada, anulada FROM cotizacion WHERE asociada = 0 ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCotizacion
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.PROVEEDOR2 = CType(unaFila.Item(3), Integer)
                    p.EMAIL2 = CType(unaFila.Item(4), String)
                    p.PROVEEDOR3 = CType(unaFila.Item(5), Integer)
                    p.EMAIL3 = CType(unaFila.Item(6), String)
                    p.FECHA = CType(unaFila.Item(7), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(10), String)
                    p.ASOCIADA = CType(unaFila.Item(11), Integer)
                    p.ANULADA = CType(unaFila.Item(12), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimoid(ByVal o As Object) As dCotizacion
        Dim obj As dCotizacion = CType(o, dCotizacion)
        Dim c As New dCotizacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id FROM cotizacion where id = (SELECT MAX(id) FROM cotizacion)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
