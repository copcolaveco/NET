Public Class pLecturasIbc
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dLecturasIbc = CType(o, dLecturasIbc)
        Dim sql As String = "INSERT INTO control_ibc_lecturas (id, fecha, b1,  a1 ) VALUES (" & obj.ID & ",'" & obj.FECHA & "', " & obj.B1 & ",  " & obj.A1 & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dLecturasIbc = CType(o, dLecturasIbc)
        'Dim sql As String = "DELETE FROM lecturasibc WHERE id = " & obj.ID
        Dim sql As String = "UPDATE control_ibc_lecturas SET eliminado =1 WHERE id = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dLecturasIbc
        Dim obj As dLecturasIbc = CType(o, dLecturasIbc)
        Dim p As New dLecturasIbc
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, b1,  a1 FROM control_ibc_lecturas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FECHA = CType(unaFila.Item(1), String)
                p.B1 = CType(unaFila.Item(2), Double)
                p.A1 = CType(unaFila.Item(3), Double)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, b1, a1 FROM control_ibc_lecturas order by fecha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLecturasIbc
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.B1 = CType(unaFila.Item(2), Double)
                    p.A1 = CType(unaFila.Item(3), Double)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
   
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, b1,  a1 FROM control_ibc_lecturas WHERE  fecha BETWEEN '" & desde & "' and '" & hasta & "'order by fecha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dLecturasIbc
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.B1 = CType(unaFila.Item(2), Double)
                    p.A1 = CType(unaFila.Item(3), Double)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
End Class
