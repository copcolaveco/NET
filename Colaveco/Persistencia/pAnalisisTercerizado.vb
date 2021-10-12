Public Class pAnalisisTercerizado
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "INSERT INTO analisistercerizado (id, ficha, muestra, tipoinforme, analisis, resultado, metodo, unidad, orden, operador, fechaproceso, laboratorio, finalizado, eliminado) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.TIPOINFORME & "," & obj.ANALISIS & ", '" & obj.RESULTADO & "', '" & obj.METODO & "', '" & obj.UNIDAD & "'," & obj.ORDEN & "," & obj.OPERADOR & ",'" & obj.FECHAPROCESO & "'," & obj.LABORATORIO & "," & obj.FINALIZADO & "," & obj.ELIMINADO & ")"
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET ficha =" & obj.FICHA & ", muestra ='" & obj.MUESTRA & "', tipoinforme=" & obj.TIPOINFORME & ", analisis=" & obj.ANALISIS & ", resultado='" & obj.RESULTADO & "', metodo='" & obj.METODO & "', unidad='" & obj.UNIDAD & "', orden=" & obj.ORDEN & ",operador=" & obj.OPERADOR & ", fechaproceso='" & obj.FECHAPROCESO & "', laboratorio=" & obj.LABORATORIO & ", finalizado=" & obj.FINALIZADO & ", eliminado=" & obj.ELIMINADO & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarlaboratorios(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET laboratorio=" & obj.LABORATORIO & " WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'modificar_laboratorios', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_resultado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET resultado='" & obj.RESULTADO & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'actualizar_resultado', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_metodo(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET metodo='" & obj.METODO & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'actualizar_metodo', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_unidad(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET unidad='" & obj.UNIDAD & "' WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'actualizar_unidad', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_laboratorio(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET laboratorio=" & obj.LABORATORIO & " WHERE ID = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'actualizar_unidad', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function actualizar_fecha(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET fechaproceso='" & obj.FECHAPROCESO & "' WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'actualizar_fecha', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function marcarfinalizado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET finalizado = 1 WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcareliminado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET eliminado = 1 WHERE id = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function asignaroperador(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "UPDATE analisistercerizado SET operador = " & usuario.ID & " WHERE ficha = " & obj.FICHA & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'asiganr_operador', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim sql As String = "DELETE FROM analisistercerizado WHERE id = " & obj.ID & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAnalisisTercerizado
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim n As New dAnalisisTercerizado
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE id = " & obj.ID & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                n.ANALISIS = CType(unaFila.Item(4), Integer)
                n.RESULTADO = CType(unaFila.Item(5), String)
                n.METODO = CType(unaFila.Item(6), String)
                n.UNIDAD = CType(unaFila.Item(7), String)
                n.ORDEN = CType(unaFila.Item(8), Integer)
                n.OPERADOR = CType(unaFila.Item(9), Integer)
                n.FECHAPROCESO = CType(unaFila.Item(10), String)
                n.LABORATORIO = CType(unaFila.Item(11), Integer)
                n.FINALIZADO = CType(unaFila.Item(12), Integer)
                n.ELIMINADO = CType(unaFila.Item(13), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dAnalisisTercerizado
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim n As New dAnalisisTercerizado
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & obj.FICHA & "")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                n.ANALISIS = CType(unaFila.Item(4), Integer)
                n.RESULTADO = CType(unaFila.Item(5), String)
                n.METODO = CType(unaFila.Item(6), String)
                n.UNIDAD = CType(unaFila.Item(7), String)
                n.ORDEN = CType(unaFila.Item(8), Integer)
                n.OPERADOR = CType(unaFila.Item(9), Integer)
                n.FECHAPROCESO = CType(unaFila.Item(10), String)
                n.LABORATORIO = CType(unaFila.Item(11), Integer)
                n.FINALIZADO = CType(unaFila.Item(12), Integer)
                n.ELIMINADO = CType(unaFila.Item(13), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarrepetidas(ByVal o As Object) As dAnalisisTercerizado
        Dim obj As dAnalisisTercerizado = CType(o, dAnalisisTercerizado)
        Dim n As New dAnalisisTercerizado
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Long)
                n.FICHA = CType(unaFila.Item(1), Long)
                n.MUESTRA = CType(unaFila.Item(2), String)
                n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                n.ANALISIS = CType(unaFila.Item(4), Integer)
                n.RESULTADO = CType(unaFila.Item(5), String)
                n.METODO = CType(unaFila.Item(6), String)
                n.UNIDAD = CType(unaFila.Item(7), String)
                n.ORDEN = CType(unaFila.Item(8), Integer)
                n.OPERADOR = CType(unaFila.Item(9), Integer)
                n.FECHAPROCESO = CType(unaFila.Item(10), String)
                n.LABORATORIO = CType(unaFila.Item(11), Integer)
                n.FINALIZADO = CType(unaFila.Item(12), Integer)
                n.ELIMINADO = CType(unaFila.Item(13), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM analisistercerizado order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
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
        Dim sql As String = "SELECT DISTINCT ficha FROM analisistercerizado WHERE tipoinforme = " & tipoinf & " and finalizado = 0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(Sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
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
        Dim sql As String = ("SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct muestra FROM analisistercerizado WHERE ficha = " & texto & " order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
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
        Dim sql As String = ("SELECT distinct muestra FROM analisistercerizado WHERE ficha = " & texto & " order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichamuestra2(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & ficha & " AND muestra = '" & muestra & "' and eliminado =0 order by orden asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT  id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & texto & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha3(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis, metodo, unidad, operador FROM analisistercerizado WHERE ficha = " & texto & " order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    n.METODO = CType(unaFila.Item(1), Integer)
                    n.OPERADOR = CType(unaFila.Item(2), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha4(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT  id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & texto & " order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha5(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis FROM analisistercerizado WHERE ficha = " & texto & " AND resultado <>'' order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ANALISIS = CType(unaFila.Item(0), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporficha6(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT  distinct muestra FROM analisistercerizado WHERE ficha = " & texto & " order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.MUESTRA = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarpormuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & ficha & " AND muestra = '" & muestra & "' AND eliminado =0 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardistintosanalisis(ByVal ficha As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis FROM analisistercerizado WHERE ficha = " & ficha & " order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ANALISIS = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listaranalisisnoeliminados(ByVal ficha As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis FROM analisistercerizado WHERE ficha = " & ficha & " AND eliminado = 0 order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ANALISIS = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarlaboratorios(ByVal ficha As Long) As ArrayList
        Dim sql As String = ("SELECT distinct laboratorio FROM analisistercerizado WHERE ficha = " & ficha & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.LABORATORIO = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarmetodos(ByVal ficha As Long) As ArrayList
        Dim sql As String = ("SELECT distinct metodo FROM analisistercerizado WHERE ficha = " & ficha & "")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.METODO = CType(unaFila.Item(0), String)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardistintosanalisisvacios(ByVal ficha As Long) As ArrayList
        Dim sql As String = ("SELECT distinct analisis FROM analisistercerizado WHERE ficha = " & ficha & " and resultado ='' order by orden asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
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
        Dim sql As String = ("SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE analisis = " & id & " ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfichaxanalisis(ByVal ficha As Long, ByVal id As Integer) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, tipoinforme, analisis, ifnull(resultado,''), ifnull(metodo,''), ifnull(unidad,''), orden, operador, fechaproceso, laboratorio, finalizado, eliminado FROM analisistercerizado WHERE ficha = " & ficha & " AND analisis = " & id & " ")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dAnalisisTercerizado
                    n.ID = CType(unaFila.Item(0), Long)
                    n.FICHA = CType(unaFila.Item(1), Long)
                    n.MUESTRA = CType(unaFila.Item(2), String)
                    n.TIPOINFORME = CType(unaFila.Item(3), Integer)
                    n.ANALISIS = CType(unaFila.Item(4), Integer)
                    n.RESULTADO = CType(unaFila.Item(5), String)
                    n.METODO = CType(unaFila.Item(6), String)
                    n.UNIDAD = CType(unaFila.Item(7), String)
                    n.ORDEN = CType(unaFila.Item(8), Integer)
                    n.OPERADOR = CType(unaFila.Item(9), Integer)
                    n.FECHAPROCESO = CType(unaFila.Item(10), String)
                    n.LABORATORIO = CType(unaFila.Item(11), Integer)
                    n.FINALIZADO = CType(unaFila.Item(12), Integer)
                    n.ELIMINADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
