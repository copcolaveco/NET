Public Class pCrioscopia_Control
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Control = CType(o, dCrioscopia_Control)
        Dim sql As String = "INSERT INTO crioscopia_control (id, ficha, muestra, delta, crioscopo, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.DELTA & "," & obj.CRIOSCOPO & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_control', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Control = CType(o, dCrioscopia_Control)
        Dim sql As String = "UPDATE crioscopia_control SET ficha = " & obj.FICHA & ",muestra = '" & obj.MUESTRA & "',delta = " & obj.DELTA & ",crioscopo = " & obj.CRIOSCOPO & ", marca = " & obj.MARCA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_control', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Control = CType(o, dCrioscopia_Control)
        Dim sql As String = "UPDATE crioscopia_control SET ficha = " & obj.FICHA & ",muestra = '" & obj.MUESTRA & "',delta = " & obj.DELTA & ",crioscopo = " & obj.CRIOSCOPO & ", marca = " & obj.MARCA & " WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_control', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCrioscopia_Control = CType(o, dCrioscopia_Control)
        Dim sql As String = "DELETE FROM crioscopia_control WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'crioscopia_control', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal o As Object) As dCrioscopia_Control
        Dim obj As dCrioscopia_Control = CType(o, dCrioscopia_Control)
        Dim c As New dCrioscopia_Control
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, delta, crioscopo, marca FROM crioscopia_control WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.DELTA = CType(unaFila.Item(3), Integer)
                c.CRIOSCOPO = CType(unaFila.Item(4), Integer)
                c.MARCA = CType(unaFila.Item(5), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dCrioscopia_Control
        Dim obj As dCrioscopia_Control = CType(o, dCrioscopia_Control)
        Dim c As New dCrioscopia_Control
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, delta, crioscopo, marca FROM crioscopia_control WHERE ficha = " & obj.FICHA & " AND muestra='" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.DELTA = CType(unaFila.Item(3), Integer)
                c.CRIOSCOPO = CType(unaFila.Item(4), Integer)
                c.MARCA = CType(unaFila.Item(5), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, delta, crioscopo, marca FROM crioscopia_control order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCrioscopia_Control
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.DELTA = CType(unaFila.Item(3), Integer)
                    c.CRIOSCOPO = CType(unaFila.Item(4), Integer)
                    c.MARCA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, delta, crioscopo, marca FROM crioscopia_control WHERE marca = 0 ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCrioscopia_Control
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.DELTA = CType(unaFila.Item(3), Integer)
                    c.CRIOSCOPO = CType(unaFila.Item(4), Integer)
                    c.MARCA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
