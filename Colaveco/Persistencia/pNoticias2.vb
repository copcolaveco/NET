Public Class pNoticias2
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoticias2 = CType(o, dNoticias2)
        Dim sql As String = "INSERT INTO noticias2 (id, descripcion, usuario, mostrar) VALUES (" & obj.ID & ", '" & obj.DESCRIPCION & "', " & obj.USUARIO & ", " & obj.MOSTRAR & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoticias2 = CType(o, dNoticias2)
        Dim sql As String = "UPDATE noticias2 SET descripcion = '" & obj.DESCRIPCION & "',usuario = " & obj.USUARIO & ", mostrar=" & obj.MOSTRAR & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dNoticias2 = CType(o, dNoticias2)
        Dim sql As String = "DELETE FROM noticias2 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

      

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dNoticias2
        Dim obj As dNoticias2 = CType(o, dNoticias2)
        Dim n As New dNoticias2
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, descripcion, usuario, mostrar FROM noticias2 WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                n.ID = CType(unaFila.Item(0), Integer)
                n.DESCRIPCION = CType(unaFila.Item(1), String)
                n.USUARIO = CType(unaFila.Item(2), Integer)
                n.MOSTRAR = CType(unaFila.Item(3), Integer)
                Return n
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, descripcion, usuario, mostrar FROM noticias2"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNoticias2
                    n.ID = CType(unaFila.Item(0), Integer)
                    n.DESCRIPCION = CType(unaFila.Item(1), String)
                    n.USUARIO = CType(unaFila.Item(2), Integer)
                    n.MOSTRAR = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listargeneral() As ArrayList
        Dim sql As String = "SELECT id, descripcion, usuario, mostrar FROM noticias2 WHERE usuario = 0 AND mostrar = 1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNoticias2
                    n.ID = CType(unaFila.Item(0), Integer)
                    n.DESCRIPCION = CType(unaFila.Item(1), String)
                    n.USUARIO = CType(unaFila.Item(2), Integer)
                    n.MOSTRAR = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal usu As Integer) As ArrayList
        Dim sql As String = "SELECT id, descripcion, usuario, mostrar FROM noticias2 WHERE usuario = " & usu & " AND mostrar = 1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim n As New dNoticias2
                    n.ID = CType(unaFila.Item(0), Integer)
                    n.DESCRIPCION = CType(unaFila.Item(1), String)
                    n.USUARIO = CType(unaFila.Item(2), Integer)
                    n.MOSTRAR = CType(unaFila.Item(3), Integer)
                    Lista.Add(n)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
