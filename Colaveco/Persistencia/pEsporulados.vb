Public Class pEsporulados
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEsporulados = CType(o, dEsporulados)
        Dim sql As String = "INSERT INTO esporulados (id, fecha, ficha, muestra, valor1, valor2, valor3, resultado) VALUES (" & obj.ID & ",'" & obj.FECHA & "'," & obj.FICHA & ", '" & obj.MUESTRA & "','" & obj.VALOR1 & "','" & obj.VALOR2 & "','" & obj.VALOR3 & "','" & obj.RESULTADO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'esporulados', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardar2(ByVal o As Object) As Boolean
        Dim obj As dEsporulados = CType(o, dEsporulados)
        Dim sql As String = "INSERT INTO esporulados (id, fecha, ficha, muestra, valor1, valor2, valor3, resultado) VALUES (" & obj.ID & ",'" & obj.FECHA & "'," & obj.FICHA & ", '" & obj.MUESTRA & "','" & obj.VALOR1 & "','" & obj.VALOR2 & "','" & obj.VALOR3 & "','" & obj.RESULTADO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEsporulados = CType(o, dEsporulados)
        Dim sql As String = "UPDATE esporulados SET fecha='" & obj.FECHA & "', ficha =" & obj.FICHA & ",muestra ='" & obj.MUESTRA & "', valor1 ='" & obj.VALOR1 & "',valor2 ='" & obj.VALOR2 & "',valor3 ='" & obj.VALOR3 & "',resultado ='" & obj.RESULTADO & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'esporulados', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dEsporulados = CType(o, dEsporulados)
        Dim sql As String = "DELETE FROM esporulados WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'esporulados', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dEsporulados
        Dim obj As dEsporulados = CType(o, dEsporulados)
        Dim r As New dEsporulados
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra, valor1, valor2, valor3, resultado FROM esporulados WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                r.ID = CType(unaFila.Item(0), Long)
                r.FECHA = CType(unaFila.Item(1), String)
                r.FICHA = CType(unaFila.Item(2), Long)
                r.MUESTRA = CType(unaFila.Item(3), String)
                r.VALOR1 = CType(unaFila.Item(4), String)
                r.VALOR2 = CType(unaFila.Item(5), String)
                r.VALOR3 = CType(unaFila.Item(6), String)
                r.RESULTADO = CType(unaFila.Item(7), String)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dEsporulados
        Dim obj As dEsporulados = CType(o, dEsporulados)
        Dim r As New dEsporulados
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra, valor1, valor2, valor3, resultado FROM esporulados WHERE ficha = '" & obj.FICHA & "' and muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                r.ID = CType(unaFila.Item(0), Long)
                r.FECHA = CType(unaFila.Item(1), String)
                r.FICHA = CType(unaFila.Item(2), Long)
                r.MUESTRA = CType(unaFila.Item(3), String)
                r.VALOR1 = CType(unaFila.Item(4), String)
                r.VALOR2 = CType(unaFila.Item(5), String)
                r.VALOR3 = CType(unaFila.Item(6), String)
                r.RESULTADO = CType(unaFila.Item(7), String)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar(ByVal paginado As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, ficha, muestra, valor1, valor2, valor3, resultado FROM esporulados order by fecha desc LIMIT " & paginado & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dEsporulados
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.FICHA = CType(unaFila.Item(2), Long)
                    r.MUESTRA = CType(unaFila.Item(3), String)
                    r.VALOR1 = CType(unaFila.Item(4), String)
                    r.VALOR2 = CType(unaFila.Item(5), String)
                    r.VALOR3 = CType(unaFila.Item(6), String)
                    r.RESULTADO = CType(unaFila.Item(7), String)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, ficha, muestra, valor1, valor2, valor3, resultado FROM esporulados WHERE  fecha >='" & desde & "' and fecha <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dEsporulados
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.FICHA = CType(unaFila.Item(2), Long)
                    r.MUESTRA = CType(unaFila.Item(3), String)
                    r.VALOR1 = CType(unaFila.Item(4), String)
                    r.VALOR2 = CType(unaFila.Item(5), String)
                    r.VALOR3 = CType(unaFila.Item(6), String)
                    r.RESULTADO = CType(unaFila.Item(7), String)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    
End Class
