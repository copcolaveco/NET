Public Class pBrucelosis
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim sql As String = "INSERT INTO brucelosis (id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca) VALUES (" & obj.ID & "," & obj.IDGRUPAL & ", " & obj.COLUMNA & ", '" & obj.FILA & "', '" & obj.FECHA & "','" & obj.FICHA & "','" & obj.MUESTRA & "'," & obj.RESULTADO & ", " & obj.OPERADOR & ", " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'brucelosis', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim sql As String = "UPDATE brucelosis SET idgrupal = " & obj.IDGRUPAL & ", columna = " & obj.COLUMNA & ", fila = '" & obj.FILA & "', fecha = '" & obj.FECHA & "',ficha = '" & obj.FICHA & "', muestra='" & obj.MUESTRA & "', resultado=" & obj.RESULTADO & ", operador = " & obj.OPERADOR & ", marca = " & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'brucelosis', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim sql As String = "UPDATE brucelosis SET ficha = '" & obj.FICHA & "', muestra='" & obj.MUESTRA & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'brucelosis', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarficha(ByVal o As Object) As Boolean
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim sql As String = "UPDATE brucelosis SET marca = 0 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim sql As String = "DELETE FROM brucelosis WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'brucelosis', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dBrucelosis
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim c As New dBrucelosis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis WHERE ficha = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.IDGRUPAL = CType(unaFila.Item(1), Long)
                c.COLUMNA = CType(unaFila.Item(2), Integer)
                c.FILA = CType(unaFila.Item(3), String)
                c.FECHA = CType(unaFila.Item(4), String)
                c.FICHA = CType(unaFila.Item(5), String)
                c.MUESTRA = CType(unaFila.Item(6), String)
                c.RESULTADO = CType(unaFila.Item(7), Integer)
                c.OPERADOR = CType(unaFila.Item(8), Integer)
                c.MARCA = CType(unaFila.Item(9), Integer)

                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dBrucelosis
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim c As New dBrucelosis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis WHERE ficha = '" & obj.FICHA & "' and muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.IDGRUPAL = CType(unaFila.Item(1), Long)
                c.COLUMNA = CType(unaFila.Item(2), Integer)
                c.FILA = CType(unaFila.Item(3), String)
                c.FECHA = CType(unaFila.Item(4), String)
                c.FICHA = CType(unaFila.Item(5), String)
                c.MUESTRA = CType(unaFila.Item(6), String)
                c.RESULTADO = CType(unaFila.Item(7), Integer)
                c.OPERADOR = CType(unaFila.Item(8), Integer)
                c.MARCA = CType(unaFila.Item(9), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dBrucelosis
        Dim obj As dBrucelosis = CType(o, dBrucelosis)
        Dim c As New dBrucelosis
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis WHERE ficha = " & obj.FICHA & "  ORDER BY id DESC LIMIT 1")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.IDGRUPAL = CType(unaFila.Item(1), Long)
                c.COLUMNA = CType(unaFila.Item(2), Integer)
                c.FILA = CType(unaFila.Item(3), String)
                c.FECHA = CType(unaFila.Item(4), String)
                c.FICHA = CType(unaFila.Item(5), String)
                c.MUESTRA = CType(unaFila.Item(6), String)
                c.RESULTADO = CType(unaFila.Item(7), Integer)
                c.OPERADOR = CType(unaFila.Item(8), Integer)
                c.MARCA = CType(unaFila.Item(9), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where ficha = " & texto & " and marca=1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function existeResultadoPositivoPorCliente(ByVal productorId As Long) As Boolean
        Dim sql As String = "SELECT COUNT(*) " &
                            "FROM brucelosis b " &
                            "INNER JOIN solicitudanalisis s ON b.ficha = s.id " &
                            "INNER JOIN cliente c ON s.idproductor = c.id " &
                            "WHERE c.id = " & productorId & " AND b.resultado = 1 AND b.marca = 1"
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count > 0 Then
                Dim cantidad As Integer = CType(Ds.Tables(0).Rows(0).Item(0), Integer)
                Return cantidad > 0
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function listarporfichapos(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where ficha = " & texto & " and resultado =1 ORDER BY muestra ASC")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfichaneg(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where ficha = " & texto & " and resultado =0 ORDER BY muestra ASC")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar1_2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where idgrupal = " & texto & " and columna =1 or idgrupal = " & texto & " and columna =2 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar3_4(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where idgrupal = " & texto & " and columna =3 or idgrupal = " & texto & " and columna =4 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar5_6(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where idgrupal = " & texto & " and columna =5 or idgrupal = " & texto & " and columna =6 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar7_8(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where idgrupal = " & texto & " and columna =7 or idgrupal = " & texto & " and columna =8 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar9_10(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where idgrupal = " & texto & " and columna =9 or idgrupal = " & texto & " and columna =10 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar11_12(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, muestra, resultado, operador, marca FROM brucelosis where idgrupal = " & texto & " and columna =11 or idgrupal = " & texto & " and columna =12 order by id asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.MUESTRA = CType(unaFila.Item(6), String)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.OPERADOR = CType(unaFila.Item(8), Integer)
                    c.MARCA = CType(unaFila.Item(9), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listargrupos() As ArrayList
        Dim sql As String = "SELECT DISTINCT idgrupal FROM brucelosis where marca=0 order by idgrupal asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.IDGRUPAL = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM brucelosis where marca=0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dBrucelosis
                    c.FICHA = CType(unaFila.Item(0), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcar(ByVal texto As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE brucelosis SET marca = 1 WHERE idgrupal = " & texto & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'brucelosis', 'marcar', " & texto & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarxficha(ByVal texto As Long, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE brucelosis SET marca = 1 WHERE ficha = " & texto & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'brucelosis', 'marcar', " & texto & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
End Class
