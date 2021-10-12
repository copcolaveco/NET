Public Class pPsicrotrofos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPsicrotrofos = CType(o, dPsicrotrofos)
        Dim sql As String = "INSERT INTO psicrotrofos (id, fecha, ficha, muestra, valor1, valor2, promedio) VALUES (" & obj.ID & ",'" & obj.FECHA & "'," & obj.FICHA & ", '" & obj.MUESTRA & "','" & obj.VALOR1 & "','" & obj.VALOR2 & "','" & obj.PROMEDIO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'psicrotrofos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardar2(ByVal o As Object) As Boolean
        Dim obj As dPsicrotrofos = CType(o, dPsicrotrofos)
        Dim sql As String = "INSERT INTO psicrotrofos (id, fecha, ficha, muestra, valor1, valor2, promedio) VALUES (" & obj.ID & ",'" & obj.FECHA & "'," & obj.FICHA & ", '" & obj.MUESTRA & "','" & obj.VALOR1 & "','" & obj.VALOR2 & "','" & obj.PROMEDIO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPsicrotrofos = CType(o, dPsicrotrofos)
        Dim sql As String = "UPDATE psicrotrofos SET fecha='" & obj.FECHA & "', ficha =" & obj.FICHA & ",muestra ='" & obj.MUESTRA & "', valor1 ='" & obj.VALOR1 & "',valor2 ='" & obj.VALOR2 & "',promedio ='" & obj.PROMEDIO & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'psicrotrofos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPsicrotrofos = CType(o, dPsicrotrofos)
        Dim sql As String = "DELETE FROM psicrotrofos WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'psicrotrofos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPsicrotrofos
        Dim obj As dPsicrotrofos = CType(o, dPsicrotrofos)
        Dim r As New dPsicrotrofos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra, valor1, valor2, promedio FROM psicrotrofos WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                r.ID = CType(unaFila.Item(0), Long)
                r.FECHA = CType(unaFila.Item(1), String)
                r.FICHA = CType(unaFila.Item(2), Long)
                r.MUESTRA = CType(unaFila.Item(3), String)
                r.VALOR1 = CType(unaFila.Item(4), String)
                r.VALOR2 = CType(unaFila.Item(5), String)
                r.PROMEDIO = CType(unaFila.Item(6), String)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dPsicrotrofos
        Dim obj As dPsicrotrofos = CType(o, dPsicrotrofos)
        Dim r As New dPsicrotrofos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, ficha, muestra, valor1, valor2, promedio FROM psicrotrofos WHERE ficha = '" & obj.FICHA & "' and muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                r.ID = CType(unaFila.Item(0), Long)
                r.FECHA = CType(unaFila.Item(1), String)
                r.FICHA = CType(unaFila.Item(2), Long)
                r.MUESTRA = CType(unaFila.Item(3), String)
                r.VALOR1 = CType(unaFila.Item(4), String)
                r.VALOR2 = CType(unaFila.Item(5), String)
                r.PROMEDIO = CType(unaFila.Item(6), String)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar(ByVal paginado As Integer) As ArrayList
        Dim sql As String = "SELECT id, fecha, ficha, muestra, valor1, valor2, promedio FROM psicrotrofos order by id desc LIMIT " & paginado & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dPsicrotrofos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.FICHA = CType(unaFila.Item(2), Long)
                    r.MUESTRA = CType(unaFila.Item(3), String)
                    r.VALOR1 = CType(unaFila.Item(4), String)
                    r.VALOR2 = CType(unaFila.Item(5), String)
                    r.PROMEDIO = CType(unaFila.Item(6), String)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, ficha, muestra, valor1, valor2, promedio FROM psicrotrofos WHERE  fecha >='" & desde & "' and fecha <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dPsicrotrofos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.FECHA = CType(unaFila.Item(1), String)
                    r.FICHA = CType(unaFila.Item(2), Long)
                    r.MUESTRA = CType(unaFila.Item(3), String)
                    r.VALOR1 = CType(unaFila.Item(4), String)
                    r.VALOR2 = CType(unaFila.Item(5), String)
                    r.PROMEDIO = CType(unaFila.Item(6), String)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
