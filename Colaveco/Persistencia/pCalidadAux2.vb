Public Class pCalidadAux2
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadAux2 = CType(o, dCalidadAux2)
        Dim sql As String = "INSERT INTO calidadaux2 (id, ficha, muestra, crioscopia) VALUES (" & obj.ID & ", " & obj.FICHA & ", '" & obj.MUESTRA & "'," & obj.CRIOSCOPIA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidadaux2', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadAux2 = CType(o, dCalidadAux2)
        Dim sql As String = "UPDATE calidadaux2 SET ficha = " & obj.FICHA & ",  muestra='" & obj.MUESTRA & "', crioscopia=" & obj.CRIOSCOPIA & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidadaux2', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadAux2 = CType(o, dCalidadAux2)
        Dim sql As String = "DELETE FROM calidadaux2 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidadaux2', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminartodo(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCalidadAux2 = CType(o, dCalidadAux2)
        Dim sql As String = "DELETE FROM calidadaux2"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'calidadaux2', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminarxficha(ByVal o As Object) As Boolean
        Dim obj As dCalidadAux2 = CType(o, dCalidadAux2)
        Dim sql As String = "DELETE FROM calidadaux2 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCalidadAux2
        Dim obj As dCalidadAux2 = CType(o, dCalidadAux2)
        Dim c As New dCalidadAux2
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, crioscopia FROM calidadaux2 WHERE ficha = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.CRIOSCOPIA = CType(unaFila.Item(3), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dCalidadAux2
        Dim obj As dCalidadAux2 = CType(o, dCalidadAux2)
        Dim c As New dCalidadAux2
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, crioscopia FROM calidadaux2 WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), Long)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.CRIOSCOPIA = CType(unaFila.Item(3), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, crioscopia FROM calidadaux2 ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadAux2
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.CRIOSCOPIA = CType(unaFila.Item(3), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, crioscopia FROM calidadaux2 where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadAux2
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.CRIOSCOPIA = CType(unaFila.Item(3), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
  

    Public Function listarxficha(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, crioscopia FROM calidadaux2 where ficha = " & texto & " ORDER BY muestra ASC")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCalidadAux2
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), Long)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.CRIOSCOPIA = CType(unaFila.Item(3), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
