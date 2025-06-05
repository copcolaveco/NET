Public Class pNuevoAnalisis
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "INSERT INTO nuevoanalisis (id, ficha, muestra, detallemuestra, tipoinforme, analisis, resultado, resultado2, mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "','" & obj.DETALLEMUESTRA & "'," & obj.TIPOINFORME & "," & obj.ANALISIS & ", '" & obj.RESULTADO & "', '" & obj.RESULTADO2 & "'," & obj.M & "," & obj.METODO & "," & obj.UNIDAD & "," & obj.ORDEN & "," & obj.OPERADOR & ",'" & obj.FECHAPROCESO & "'," & obj.FINALIZADO & ")"
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET ficha =" & obj.FICHA & ", muestra ='" & obj.MUESTRA & "', detallemuestra ='" & obj.DETALLEMUESTRA & "',  tipoinforme=" & obj.TIPOINFORME & ", analisis=" & obj.ANALISIS & ", resultado='" & obj.RESULTADO & "', resultado2='" & obj.RESULTADO2 & "', mostrar_r =" & obj.M & ", metodo=" & obj.METODO & ", unidad=" & obj.UNIDAD & ",orden=" & obj.ORDEN & ",operador=" & obj.OPERADOR & ", fechaproceso='" & obj.FECHAPROCESO & "', finalizado=" & obj.FINALIZADO & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_resultado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET resultado='" & obj.RESULTADO & "',resultado2='" & obj.RESULTADO2 & "', mostrar_r=" & obj.M & ",operador=" & usuario.ID & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'actualizar_resultado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_resultado2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET resultado='" & obj.RESULTADO & "' ,operador=" & usuario.ID & " WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'"
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'actualizar_resultado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_metodo(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET metodo=" & obj.METODO & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'actualizar_metodo', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_detalle(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET detallemuestra='" & obj.DETALLEMUESTRA & "' WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'"
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'actualizar_metodo', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_fecha(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET fechaproceso='" & obj.FECHAPROCESO & "' WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'actualizar_fecha', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_unidad(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET unidad=" & obj.UNIDAD & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'actualizar_unidad', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarfinalizado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET finalizado = 1 WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarfinalizado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET finalizado = 0 WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function asignaroperador(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "UPDATE nuevoanalisis SET operador = " & usuario.ID & " WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'asiganr_operador', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "DELETE FROM nuevoanalisis WHERE id = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxficha(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim sql As String = "DELETE FROM nuevoanalisis WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'nuevoanalisis', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNuevoAnalisis
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim n As New dNuevoAnalisis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE id = " & obj.ID & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                n.ANALISIS = CType(unaFila.Item(5), Integer)
                n.RESULTADO = CType(unaFila.Item(6), String)
                n.RESULTADO2 = CType(unaFila.Item(7), String)
                n.M = CType(unaFila.Item(8), Integer)
                n.METODO = CType(unaFila.Item(9), Integer)
                n.UNIDAD = CType(unaFila.Item(10), Integer)
                n.ORDEN = CType(unaFila.Item(11), Integer)
                n.OPERADOR = CType(unaFila.Item(12), Integer)
                n.FECHAPROCESO = CType(unaFila.Item(13), String)
                n.FINALIZADO = CType(unaFila.Item(14), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dNuevoAnalisis
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim n As New dNuevoAnalisis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & obj.FICHA & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                n.ANALISIS = CType(unaFila.Item(5), Integer)
                n.RESULTADO = CType(unaFila.Item(6), String)
                n.RESULTADO2 = CType(unaFila.Item(7), String)
                n.M = CType(unaFila.Item(8), Integer)
                n.METODO = CType(unaFila.Item(9), Integer)
                n.UNIDAD = CType(unaFila.Item(10), Integer)
                n.ORDEN = CType(unaFila.Item(11), Integer)
                n.OPERADOR = CType(unaFila.Item(12), Integer)
                n.FECHAPROCESO = CType(unaFila.Item(13), String)
                n.FINALIZADO = CType(unaFila.Item(14), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dNuevoAnalisis
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim n As New dNuevoAnalisis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                n.ANALISIS = CType(unaFila.Item(5), Integer)
                n.RESULTADO = CType(unaFila.Item(6), String)
                n.RESULTADO2 = CType(unaFila.Item(7), String)
                n.M = CType(unaFila.Item(8), Integer)
                n.METODO = CType(unaFila.Item(9), Integer)
                n.UNIDAD = CType(unaFila.Item(10), Integer)
                n.ORDEN = CType(unaFila.Item(11), Integer)
                n.OPERADOR = CType(unaFila.Item(12), Integer)
                n.FECHAPROCESO = CType(unaFila.Item(13), String)
                n.FINALIZADO = CType(unaFila.Item(14), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarrepetidas(ByVal o As Object) As dNuevoAnalisis
        Dim obj As dNuevoAnalisis = CType(o, dNuevoAnalisis)
        Dim n As New dNuevoAnalisis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                n.ANALISIS = CType(unaFila.Item(5), Integer)
                n.RESULTADO = CType(unaFila.Item(6), String)
                n.RESULTADO2 = CType(unaFila.Item(7), String)
                n.M = CType(unaFila.Item(8), Integer)
                n.METODO = CType(unaFila.Item(9), Integer)
                n.UNIDAD = CType(unaFila.Item(10), Integer)
                n.ORDEN = CType(unaFila.Item(11), Integer)
                n.OPERADOR = CType(unaFila.Item(12), Integer)
                n.FECHAPROCESO = CType(unaFila.Item(13), String)
                n.FINALIZADO = CType(unaFila.Item(14), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM nuevoanalisis order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichasnuevas(ByVal tipoinf As Integer) As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM nuevoanalisis WHERE tipoinforme = " & tipoinf & " and finalizado = 0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarfichasMineralesLeche(ByVal tipoinf As Integer) As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM nuevoanalisis WHERE tipoinforme = " & tipoinf & " and finalizado = 0 and analisis in(518,570,562,563,571,564,565,572,566,567,573,568) order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra FROM nuevoanalisis WHERE ficha = " & texto & " order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamuestra(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra,ifnull(detallemuestra,'') FROM nuevoanalisis WHERE ficha = " & texto & " order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(1), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamuestramicro(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra,ifnull(detallemuestra,'') FROM nuevoanalisis WHERE ficha = " & texto & " AND  orden <= 100 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(1), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamuestrafq(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra,ifnull(detallemuestra,'') FROM nuevoanalisis WHERE ficha = " & texto & " AND orden >= 101 AND orden <= 300 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(1), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamuestramac(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra,ifnull(detallemuestra,'') FROM nuevoanalisis WHERE ficha = " & texto & " AND orden >= 401 AND orden <= 500 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(1), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamuestramic(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra,ifnull(detallemuestra,'') FROM nuevoanalisis WHERE ficha = " & texto & " AND orden >= 501 AND orden <= 600 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(1), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT  id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpositivo(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT  id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & texto & " AND resultado = 'Positivo'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarnegativo(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT  id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & texto & " AND resultado = 'Negativo'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha3(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis, mostrar_r, metodo, unidad, operador FROM nuevoanalisis WHERE ficha = " & texto & " order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    n.M = CType(unaFila.Item(1), Integer)
                    n.METODO = CType(unaFila.Item(2), Integer)
                    n.UNIDAD = CType(unaFila.Item(3), Integer)
                    n.OPERADOR = CType(unaFila.Item(4), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfichaMinerales(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis, id, ficha, muestra, detallemuestra, tipoinforme, resultado, resultado2, metodo, unidad, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & texto & " order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    n.ID = CType(unaFila.Item(1), Integer)
                    n.FICHA = CType(unaFila.Item(2), Integer)
                    n.MUESTRA = CType(unaFila.Item(3), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(4), String)
                    n.TIPOINFORME = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.METODO = CType(unaFila.Item(8), Integer)
                    n.UNIDAD = CType(unaFila.Item(9), Integer)
                    n.OPERADOR = CType(unaFila.Item(10), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(11), Date)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfichamicro(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis, metodo, unidad, operador FROM nuevoanalisis WHERE ficha = " & texto & " AND orden <= 100 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    n.METODO = CType(unaFila.Item(1), Integer)
                    n.UNIDAD = CType(unaFila.Item(2), Integer)
                    n.OPERADOR = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichafq(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis, metodo, unidad, operador FROM nuevoanalisis WHERE ficha = " & texto & " AND orden >= 101 AND orden <= 300 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    n.METODO = CType(unaFila.Item(1), Integer)
                    n.UNIDAD = CType(unaFila.Item(2), Integer)
                    n.OPERADOR = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamac(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis, metodo, unidad, operador FROM nuevoanalisis WHERE ficha = " & texto & " AND orden >= 401 AND orden <= 500 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    n.METODO = CType(unaFila.Item(1), Integer)
                    n.UNIDAD = CType(unaFila.Item(2), Integer)
                    n.OPERADOR = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamic(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis, metodo, unidad, operador FROM nuevoanalisis WHERE ficha = " & texto & " AND orden >= 501 AND orden <= 600 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    n.METODO = CType(unaFila.Item(1), Integer)
                    n.UNIDAD = CType(unaFila.Item(2), Integer)
                    n.OPERADOR = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & ficha & " AND muestra = '" & muestra & "' order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestramicro(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & ficha & " AND muestra = '" & muestra & "' AND  orden <= 100 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestrafq(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & ficha & " AND muestra = '" & muestra & "' AND orden >= 101 AND orden <= 300 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestramac(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & ficha & " AND muestra = '" & muestra & "' AND orden >= 401 AND orden <= 500 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestramic(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & ficha & " AND muestra = '" & muestra & "' AND orden >= 501 AND orden <= 600 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardistintosanalisis(ByVal ficha As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis FROM nuevoanalisis WHERE ficha = " & ficha & " order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ANALISIS = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxanalisis(ByVal id As Integer) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE analisis = " & id & " ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfichaxanalisis(ByVal ficha As Long, ByVal id As Integer) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, ifnull(detallemuestra,''), tipoinforme, analisis, ifnull(resultado,''), ifnull(resultado2,''), mostrar_r, metodo, unidad, orden, operador, fechaproceso, finalizado FROM nuevoanalisis WHERE ficha = " & ficha & " AND analisis = " & id & " ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String, ByVal idmuestra As Integer) As ArrayList

        Dim sql As String = ("select * from nuevoanalisis na inner join solicitudanalisis sa on sa.id = na.ficha inner join muestra m on m.id = sa.idmuestra where na.tipoinforme = 13 and sa.fechaingreso between '" & desde & "' AND '" & hasta & "' AND sa.idmuestra = " & idmuestra & " order by sa.fechaingreso asc")

        'Dim sql As String = ("select * from nuevoanalisis na inner join solicitudanalisis sa on na.ficha = sa.id where sa.fechaingreso between '" & desde & "' AND '" & hasta & "' AND finalizado=1 order by sa.fechaingreso asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNuevoAnalisis
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.DETALLEMUESTRA = CType(unaFila.Item(3), String)
                    n.TIPOINFORME = CType(unaFila.Item(4), Integer)
                    n.ANALISIS = CType(unaFila.Item(5), Integer)
                    n.RESULTADO = CType(unaFila.Item(6), String)
                    n.RESULTADO2 = CType(unaFila.Item(7), String)
                    n.M = CType(unaFila.Item(8), Integer)
                    n.METODO = CType(unaFila.Item(9), Integer)
                    n.UNIDAD = CType(unaFila.Item(10), Integer)
                    n.ORDEN = CType(unaFila.Item(11), Integer)
                    n.OPERADOR = CType(unaFila.Item(12), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(13), String)
                    n.FINALIZADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
