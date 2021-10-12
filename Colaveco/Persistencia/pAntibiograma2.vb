Public Class pAntibiograma2
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAntibiograma2 = CType(o, dAntibiograma2)
        Dim sql As String = "INSERT INTO antibiograma2 (id, ficha, aislamiento, antibiograma, marca) VALUES (" & obj.ID & ", " & obj.FICHA & ", " & obj.AISLAMIENTO & "," & obj.ANTIBIOGRAMA & "," & obj.MARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'antibiograma2', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAntibiograma2 = CType(o, dAntibiograma2)
        Dim sql As String = "UPDATE antibiograma2 SET ficha = " & obj.FICHA & ", aislamiento=" & obj.AISLAMIENTO & ",antibiograma=" & obj.ANTIBIOGRAMA & ", marca=" & obj.MARCA & " WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'antibiograma2', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAntibiograma2 = CType(o, dAntibiograma2)
        Dim sql As String = "DELETE FROM antibiograma2 WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'antibiograma2', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAntibiograma2
        Dim obj As dAntibiograma2 = CType(o, dAntibiograma2)
        Dim a2 As New dAntibiograma2
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, aislamiento, antibiograma, marca FROM antibiograma2 WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                a2.ID = CType(unaFila.Item(0), Long)
                a2.FICHA = CType(unaFila.Item(1), Long)
                a2.AISLAMIENTO = CType(unaFila.Item(2), Integer)
                a2.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                a2.MARCA = CType(unaFila.Item(4), Integer)
                Return a2
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, aislamiento, antibiograma, marca FROM antibiograma2 WHERE marca = 0 order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a2 As New dAntibiograma2
                    a2.ID = CType(unaFila.Item(0), Long)
                    a2.FICHA = CType(unaFila.Item(1), Long)
                    a2.AISLAMIENTO = CType(unaFila.Item(2), Integer)
                    a2.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                    a2.MARCA = CType(unaFila.Item(4), Integer)
                    Lista.Add(a2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM antibiograma2 WHERE marca = 0 order by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a2 As New dAntibiograma2
                    a2.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(a2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, aislamiento, antibiograma, marca FROM antibiograma2 where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a2 As New dAntibiograma2
                    a2.ID = CType(unaFila.Item(0), Long)
                    a2.FICHA = CType(unaFila.Item(1), Long)
                    a2.AISLAMIENTO = CType(unaFila.Item(2), Integer)
                    a2.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                    a2.MARCA = CType(unaFila.Item(4), Integer)
                    Lista.Add(a2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, aislamiento, antibiograma, marca FROM antibiograma2 where marca = 0 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a2 As New dAntibiograma2
                    a2.ID = CType(unaFila.Item(0), Long)
                    a2.FICHA = CType(unaFila.Item(1), Long)
                    a2.AISLAMIENTO = CType(unaFila.Item(2), Integer)
                    a2.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                    a2.MARCA = CType(unaFila.Item(4), Integer)
                    Lista.Add(a2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, aislamiento, antibiograma, marca FROM antibiograma2 where marca = 1 and ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a2 As New dAntibiograma2
                    a2.ID = CType(unaFila.Item(0), Long)
                    a2.FICHA = CType(unaFila.Item(1), Long)
                    a2.AISLAMIENTO = CType(unaFila.Item(2), Integer)
                    a2.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                    a2.MARCA = CType(unaFila.Item(4), Integer)
                    Lista.Add(a2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = ("SELECT id, ficha, aislamiento, antibiograma, marca FROM antibiograma2 where fechaingreso BETWEEN '" & fechadesde & "' And '" & fechahasta & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim a2 As New dAntibiograma2
                    a2.ID = CType(unaFila.Item(0), Long)
                    a2.FICHA = CType(unaFila.Item(1), Long)
                    a2.AISLAMIENTO = CType(unaFila.Item(2), Integer)
                    a2.ANTIBIOGRAMA = CType(unaFila.Item(3), Integer)
                    a2.MARCA = CType(unaFila.Item(4), Integer)
                    Lista.Add(a2)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
