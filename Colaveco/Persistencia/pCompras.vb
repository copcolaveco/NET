Public Class pCompras
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "INSERT INTO compras (id, proveedor, email, fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion) VALUES (" & obj.ID & ", " & obj.PROVEEDOR & ", '" & obj.EMAIL & "', '" & obj.FECHA & "', " & obj.USUARIOCREADOR & ", " & obj.USUARIOAUTORIZA & ", '" & obj.FECHAAUTORIZA & "'," & obj.AUTORIZA & "," & obj.ENVIA & ", " & obj.ENVIADO & ", '" & obj.FECHARECIBO & "', " & obj.ACEPTADO & ", '" & obj.OBSERVACIONES & "', " & obj.USUARIORECIBE & ", " & obj.RECIBIDO & ", " & obj.ANULADA & ", " & obj.COTIZACION & " )"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "UPDATE compras SET proveedor =" & obj.PROVEEDOR & ", email = '" & obj.EMAIL & "', fecha= '" & obj.FECHA & "',usuariocreador= " & obj.USUARIOCREADOR & ", usuarioautoriza=" & obj.USUARIOAUTORIZA & ", fechaautoriza= '" & obj.FECHAAUTORIZA & "', autoriza= " & obj.AUTORIZA & ", autoriza= " & obj.ENVIA & ", enviado= " & obj.ENVIADO & ", fecharecibo= '" & obj.FECHARECIBO & "', aceptado=" & obj.ACEPTADO & ", observaciones= '" & obj.OBSERVACIONES & "',usuariorecibe= " & obj.USUARIORECIBE & ",recibido= " & obj.RECIBIDO & ",anulada= " & obj.ANULADA & ",cotizacion= " & obj.COTIZACION & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarautoriza(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "UPDATE compras SET  usuarioautoriza= " & obj.USUARIOAUTORIZA & ", fechaautoriza= '" & obj.FECHAAUTORIZA & "', autoriza= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'marcarautoriza', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcaranulada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "UPDATE compras SET  fechaautoriza= '" & obj.FECHAAUTORIZA & "', anulada= 1  WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'marcaranulada', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarrecibido(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "UPDATE compras SET  fecharecibo= '" & obj.FECHARECIBO & "', aceptado= " & obj.ACEPTADO & ",observaciones = '" & obj.OBSERVACIONES & "',usuariorecibe = " & obj.USUARIORECIBE & ", recibido= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'marcarrecibido', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarenviado(ByVal o As Object) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "UPDATE compras SET  enviado= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarenvia(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "UPDATE compras SET  envia= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'marcarenvia', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarnoenvia(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "UPDATE compras SET  envia= 0 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'marcarnoenvia', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCompras = CType(o, dCompras)
        Dim sql As String = "DELETE FROM compras WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'compras', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCompras
        Dim obj As dCompras = CType(o, dCompras)
        Dim p As New dCompras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.FECHA = CType(unaFila.Item(3), String)
                p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                p.AUTORIZA = CType(unaFila.Item(7), Integer)
                p.ENVIA = CType(unaFila.Item(8), Integer)
                p.ENVIADO = CType(unaFila.Item(9), Integer)
                p.FECHARECIBO = CType(unaFila.Item(10), String)
                p.ACEPTADO = CType(unaFila.Item(11), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(12), String)
                p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                p.RECIBIDO = CType(unaFila.Item(14), Integer)
                p.ANULADA = CType(unaFila.Item(15), Integer)
                p.COTIZACION = CType(unaFila.Item(16), Long)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarrecibido(ByVal o As Object) As dCompras
        Dim obj As dCompras = CType(o, dCompras)
        Dim p As New dCompras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE id = " & obj.ID & " AND recibido = 1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.FECHA = CType(unaFila.Item(3), String)
                p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                p.AUTORIZA = CType(unaFila.Item(7), Integer)
                p.ENVIA = CType(unaFila.Item(8), Integer)
                p.ENVIADO = CType(unaFila.Item(9), Integer)
                p.FECHARECIBO = CType(unaFila.Item(10), String)
                p.ACEPTADO = CType(unaFila.Item(11), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(12), String)
                p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                p.RECIBIDO = CType(unaFila.Item(14), Integer)
                p.ANULADA = CType(unaFila.Item(15), Integer)
                p.COTIZACION = CType(unaFila.Item(16), Long)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarsinrecibir(ByVal o As Object) As dCompras
        Dim obj As dCompras = CType(o, dCompras)
        Dim p As New dCompras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE id = " & obj.ID & " AND recibido = 0")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                p.EMAIL = CType(unaFila.Item(2), String)
                p.FECHA = CType(unaFila.Item(3), String)
                p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                p.AUTORIZA = CType(unaFila.Item(7), Integer)
                p.ENVIA = CType(unaFila.Item(8), Integer)
                p.ENVIADO = CType(unaFila.Item(9), Integer)
                p.FECHARECIBO = CType(unaFila.Item(10), String)
                p.ACEPTADO = CType(unaFila.Item(11), Integer)
                p.OBSERVACIONES = CType(unaFila.Item(12), String)
                p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                p.RECIBIDO = CType(unaFila.Item(14), Integer)
                p.ANULADA = CType(unaFila.Item(15), Integer)
                p.COTIZACION = CType(unaFila.Item(16), Long)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal id As Long) As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE id = " & id & " AND anulada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxproveedor(ByVal idproveedor As Long) As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE proveedor = " & idproveedor & " AND anulada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxproveedorrecibido(ByVal idproveedor As Long) As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE proveedor = " & idproveedor & " AND RECIBIDO = 1 AND anulada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxproveedorsinrecibir(ByVal idproveedor As Long) As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE proveedor = " & idproveedor & " AND recibido = 0 AND anulada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE fecharecibo BETWEEN '" & desde & "' AND '" & hasta & "' AND  anulada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecharecibido(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE fecharecibo BETWEEN '" & desde & "' AND '" & hasta & "' AND recibido = 1 AND  anulada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechasinrecibir(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE fecharecibo BETWEEN '" & desde & "' AND '" & hasta & "' AND recibido = 0 AND  anulada = 0 ORDER BY fecha DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinautorizar() As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE autoriza = 0 AND anulada =0 ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE envia = 1 AND enviado = 0 ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarautorizadas() As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE autoriza = 1 AND anulada =0 ORDER BY fecha DESC LIMIT 150"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinrecibir() As ArrayList
        Dim sql As String = "SELECT id, proveedor, ifnull(email,''), fecha, usuariocreador, usuarioautoriza, fechaautoriza, autoriza, envia, enviado, fecharecibo, aceptado, observaciones, usuariorecibe, recibido, anulada, cotizacion FROM compras WHERE recibido = 0 AND anulada =0 AND autoriza = 1 ORDER BY fecha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dCompras
                    p.ID = CType(unaFila.Item(0), Long)
                    p.PROVEEDOR = CType(unaFila.Item(1), Integer)
                    p.EMAIL = CType(unaFila.Item(2), String)
                    p.FECHA = CType(unaFila.Item(3), String)
                    p.USUARIOCREADOR = CType(unaFila.Item(4), Integer)
                    p.USUARIOAUTORIZA = CType(unaFila.Item(5), Integer)
                    p.FECHAAUTORIZA = CType(unaFila.Item(6), String)
                    p.AUTORIZA = CType(unaFila.Item(7), Integer)
                    p.ENVIA = CType(unaFila.Item(8), Integer)
                    p.ENVIADO = CType(unaFila.Item(9), Integer)
                    p.FECHARECIBO = CType(unaFila.Item(10), String)
                    p.ACEPTADO = CType(unaFila.Item(11), Integer)
                    p.OBSERVACIONES = CType(unaFila.Item(12), String)
                    p.USUARIORECIBE = CType(unaFila.Item(13), Integer)
                    p.RECIBIDO = CType(unaFila.Item(14), Integer)
                    p.ANULADA = CType(unaFila.Item(15), Integer)
                    p.COTIZACION = CType(unaFila.Item(16), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimoid(ByVal o As Object) As dCompras
        Dim obj As dCompras = CType(o, dCompras)
        Dim c As New dCompras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id FROM compras where id = (SELECT MAX(id) FROM compras)")

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
