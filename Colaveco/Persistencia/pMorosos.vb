Public Class pMorosos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMorosos = CType(o, dMorosos)
        Dim sql As String = "INSERT INTO morosos (cliente, debe) VALUES ('" & obj.CLIENTE & "', " & obj.DEBE & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMorosos = CType(o, dMorosos)
        Dim sql As String = "UPDATE morosos SET debe = " & obj.DEBE & " WHERE cliente = '" & obj.CLIENTE & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMorosos = CType(o, dMorosos)
        Dim sql As String = "DELETE FROM morosos WHERE debe = 1"

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMorosos
        Dim obj As dMorosos = CType(o, dMorosos)
        Dim l As New dMorosos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT cliente, debe FROM morosos WHERE cliente = '" & obj.CLIENTE & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.CLIENTE = CType(unaFila.Item(0), String)
                l.DEBE = CType(unaFila.Item(1), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT cliente, debe FROM morosos"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMorosos
                    l.CLIENTE = CType(unaFila.Item(0), String)
                    l.DEBE = CType(unaFila.Item(1), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
