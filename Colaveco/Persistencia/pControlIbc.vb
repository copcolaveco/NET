Public Class pControlIbc
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dControlIbc = CType(o, dControlIbc)
        Dim sql As String = "INSERT INTO control_ibc_promedios (id, fecha, bajo, alto) VALUES (" & obj.ID & ",'" & obj.FECHA & "', " & obj.BAJO & "," & obj.ALTO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlIbc = CType(o, dControlIbc)
        'Dim sql As String = "DELETE FROM controlibc WHERE id = " & obj.ID
        Dim sql As String = "UPDATE control_ibc_promedios SET eliminado =1 WHERE id = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dControlIbc
        Dim obj As dControlIbc = CType(o, dControlIbc)
        Dim p As New dControlIbc
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, bajo, alto FROM control_ibc_promedios WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FECHA = CType(unaFila.Item(1), String)
                p.BAJO = CType(unaFila.Item(2), Double)
                p.ALTO = CType(unaFila.Item(3), Double)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimo(ByVal o As Object) As dControlIbc
        Dim obj As dControlIbc = CType(o, dControlIbc)
        Dim p As New dControlIbc
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, bajo, alto FROM control_ibc_promedios where fecha = (SELECT MAX(fecha) FROM control_ibc_promedios)")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FECHA = CType(unaFila.Item(1), String)
                p.BAJO = CType(unaFila.Item(2), Double)
                p.ALTO = CType(unaFila.Item(3), Double)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, bajo, alto FROM control_ibc_promedios order by fecha desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dControlIbc
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.BAJO = CType(unaFila.Item(2), Double)
                    p.ALTO = CType(unaFila.Item(3), Double)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarultimosdiez() As ArrayList
        Dim sql As String = "SELECT id, fecha, bajo, alto FROM control_ibc_promedios ORDER BY fecha DESC LIMIT 10"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dControlIbc
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.BAJO = CType(unaFila.Item(2), Double)
                    p.ALTO = CType(unaFila.Item(3), Double)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, fecha, bajo, alto FROM control_ibc_promedios WHERE fecha >='" & desde & "' and fecha <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dControlIbc
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FECHA = CType(unaFila.Item(1), String)
                    p.BAJO = CType(unaFila.Item(2), Double)
                    p.ALTO = CType(unaFila.Item(3), Double)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
End Class
