Public Class pImpIbc
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dImpIbc = CType(o, dImpIbc)
        Dim sql As String = "INSERT INTO ibc (id, ficha, muestra, idibc, ibc, rb, fecha) VALUES (" & obj.ID & ", '" & obj.FICHA & "','" & obj.MUESTRA & "'," & obj.IDIBC & ", " & obj.IBC & ", " & obj.RB & ", '" & obj.FECHA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dImpIbc = CType(o, dImpIbc)
        Dim sql As String = "UPDATE ibc SET ficha = '" & obj.FICHA & "', muestra='" & obj.MUESTRA & "', idibc=" & obj.IDIBC & ", ibc = " & obj.IBC & ", rb = " & obj.RB & ", fecha ='" & obj.FECHA & "' WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dImpIbc = CType(o, dImpIbc)
        Dim sql As String = "DELETE FROM ibc WHERE ID = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dImpIbc
        Dim obj As dImpIbc = CType(o, dImpIbc)
        Dim c As New dImpIbc
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, idibc, ibc, rb, fecha FROM ibc WHERE ficha = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FICHA = CType(unaFila.Item(1), String)
                c.MUESTRA = CType(unaFila.Item(2), String)
                c.IDIBC = CType(unaFila.Item(3), Integer)
                c.IBC = CType(unaFila.Item(4), Long)
                c.RB = CType(unaFila.Item(5), Integer)
                c.FECHA = CType(unaFila.Item(6), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, idibc, ibc, rb, fecha FROM ibc order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dImpIbc
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.IDIBC = CType(unaFila.Item(3), Integer)
                    c.IBC = CType(unaFila.Item(4), Long)
                    c.RB = CType(unaFila.Item(5), Integer)
                    c.FECHA = CType(unaFila.Item(6), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, idibc, ibc, rb, fecha FROM ibc where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dImpIbc
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.IDIBC = CType(unaFila.Item(3), Integer)
                    c.IBC = CType(unaFila.Item(4), Long)
                    c.RB = CType(unaFila.Item(5), Integer)
                    c.FECHA = CType(unaFila.Item(6), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, idibc, ibc, rb, fecha FROM ibc where ficha = " & texto)
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dImpIbc
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FICHA = CType(unaFila.Item(1), String)
                    c.MUESTRA = CType(unaFila.Item(2), String)
                    c.IDIBC = CType(unaFila.Item(3), Integer)
                    c.IBC = CType(unaFila.Item(4), Long)
                    c.RB = CType(unaFila.Item(5), Integer)
                    c.FECHA = CType(unaFila.Item(6), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
