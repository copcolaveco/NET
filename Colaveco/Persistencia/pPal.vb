Public Class pPal
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPal = CType(o, dPal)
        Dim sql As String = "INSERT INTO pal (id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca) VALUES (" & obj.ID & "," & obj.IDGRUPAL & ", " & obj.COLUMNA & ", '" & obj.FILA & "', '" & obj.FECHA & "','" & obj.FICHA & "','" & obj.SERIE & "','" & obj.MUESTRA & "'," & obj.RESULTADO & ", " & obj.OPERADOR & ", " & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pal', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPal = CType(o, dPal)
        Dim sql As String = "UPDATE pal SET idgrupal = " & obj.IDGRUPAL & ", columna = " & obj.COLUMNA & ", fila = '" & obj.FILA & "', fecha = '" & obj.FECHA & "',ficha = '" & obj.FICHA & "',serie = '" & obj.SERIE & "', muestra='" & obj.MUESTRA & "', resultado=" & obj.RESULTADO & ", operador = " & obj.OPERADOR & ", marca = " & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pal', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarmuestra(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPal = CType(o, dPal)
        Dim sql As String = "UPDATE pal SET muestra='" & obj.MUESTRA & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pal', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPal = CType(o, dPal)
        Dim sql As String = "DELETE FROM pal WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'pal', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPal
        Dim obj As dPal = CType(o, dPal)
        Dim c As New dPal
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal WHERE ficha = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.IDGRUPAL = CType(unaFila.Item(1), Long)
                c.COLUMNA = CType(unaFila.Item(2), Integer)
                c.FILA = CType(unaFila.Item(3), String)
                c.FECHA = CType(unaFila.Item(4), String)
                c.FICHA = CType(unaFila.Item(5), String)
                c.SERIE = CType(unaFila.Item(6), String)
                c.MUESTRA = CType(unaFila.Item(7), String)
                c.RESULTADO = CType(unaFila.Item(8), Integer)
                c.OPERADOR = CType(unaFila.Item(9), Integer)
                c.MARCA = CType(unaFila.Item(10), Integer)

                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dPal
        Dim obj As dPal = CType(o, dPal)
        Dim c As New dPal
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal WHERE ficha = '" & obj.FICHA & "' and muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.IDGRUPAL = CType(unaFila.Item(1), Long)
                c.COLUMNA = CType(unaFila.Item(2), Integer)
                c.FILA = CType(unaFila.Item(3), String)
                c.FECHA = CType(unaFila.Item(4), String)
                c.FICHA = CType(unaFila.Item(5), String)
                c.SERIE = CType(unaFila.Item(6), String)
                c.MUESTRA = CType(unaFila.Item(7), String)
                c.RESULTADO = CType(unaFila.Item(8), Integer)
                c.OPERADOR = CType(unaFila.Item(9), Integer)
                c.MARCA = CType(unaFila.Item(10), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where ficha = " & texto & " and marca = 1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar1(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =1")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =2")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar3(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =3")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar4(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =4")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar5(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =5")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar6(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =6")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar7(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =7")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar8(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =8")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar9(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =9")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar10(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =10")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar11(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =11")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar12(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =12")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar13(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =13")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar14(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =14")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar15(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, idgrupal, columna, fila, fecha, ficha, serie, muestra, resultado, operador, marca FROM pal where idgrupal = " & texto & " and columna =15")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.ID = CType(unaFila.Item(0), Long)
                    c.IDGRUPAL = CType(unaFila.Item(1), Long)
                    c.COLUMNA = CType(unaFila.Item(2), Integer)
                    c.FILA = CType(unaFila.Item(3), String)
                    c.FECHA = CType(unaFila.Item(4), String)
                    c.FICHA = CType(unaFila.Item(5), String)
                    c.SERIE = CType(unaFila.Item(6), String)
                    c.MUESTRA = CType(unaFila.Item(7), String)
                    c.RESULTADO = CType(unaFila.Item(8), Integer)
                    c.OPERADOR = CType(unaFila.Item(9), Integer)
                    c.MARCA = CType(unaFila.Item(10), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listargrupos() As ArrayList
        Dim sql As String = "SELECT DISTINCT idgrupal FROM pal where marca=0 order by idgrupal asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPal
                    c.IDGRUPAL = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcar(ByVal id As Long, ByVal fecact As String, ByVal usuario As dUsuario) As Boolean
        Dim sql As String = "UPDATE pal SET marca = 1, fecha = '" & fecact & "' WHERE idgrupal = " & id & ""

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                    & "VALUES (now(), 'pal', 'marcar', " & id & ", " & usuario.ID & ")"

        Dim lista As New ArrayList : lista.Add(sql) : lista.Add(sqlAccion)
        Return EjecutarTransaccion(lista)
    End Function
End Class
