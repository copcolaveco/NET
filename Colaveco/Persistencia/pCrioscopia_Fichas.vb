Public Class pCrioscopia_Fichas
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Fichas = CType(o, dCrioscopia_Fichas)
        Dim sql As String = "INSERT INTO crioscopia_fichas (id, ficha, muestra, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_fichas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Fichas = CType(o, dCrioscopia_Fichas)
        Dim sql As String = "UPDATE crioscopia_fichas SET ficha = " & obj.FICHA & ",muestra = '" & obj.MUESTRA & "', marca = " & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_fichas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Fichas = CType(o, dCrioscopia_Fichas)
        Dim sql As String = "UPDATE crioscopia_fichas SET ficha = " & obj.FICHA & ",muestra = '" & obj.MUESTRA & "', marca = " & obj.MARCA & " WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_fichas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Fichas = CType(o, dCrioscopia_Fichas)
        Dim sql As String = "DELETE FROM crioscopia_fichas WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_fichas', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dCrioscopia_Fichas
        Dim obj As dCrioscopia_Fichas = CType(o, dCrioscopia_Fichas)
        Dim c As New dCrioscopia_Fichas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, marca FROM crioscopia_fichas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.MARCA = CType(unaFila.Item(3), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, marca FROM crioscopia_fichas ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCrioscopia_Fichas
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.MARCA = CType(unaFila.Item(3), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM crioscopia_fichas WHERE marca = 0 ORDER BY ficha ASC"
        'Dim sql As String = "SELECT id, ficha, muestra, marca FROM crioscopia_fichas WHERE marca = 0 ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCrioscopia_Fichas
                    c.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarfichas(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Fichas = CType(o, dCrioscopia_Fichas)
        Dim sql As String = "UPDATE crioscopia_fichas SET marca = 1 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_fichas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
End Class
