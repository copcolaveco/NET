Public Class pUsuarioReloj
    Inherits Conectoras.ConexionMySQL_reloj
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim sql As String = "INSERT INTO usuario (nombre, sexo, ci, tipousuario, sector,  eliminado) VALUES ('" & obj.NOMBRE & "', '" & obj.SEXO & "','" & obj.CI & "'," & obj.TIPOUSUARIO & ", " & obj.SECTOR & ", " & obj.ELIMINADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)



        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim sql As String = "UPDATE usuario SET nombre ='" & obj.NOMBRE & "',sexo ='" & obj.SEXO & "', ci ='" & obj.CI & "',tipousuario=" & obj.TIPOUSUARIO & ", sector=" & obj.SECTOR & ", eliminado =  " & obj.ELIMINADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dUsuario = CType(o, dUsuario)
        Dim sql As String = "DELETE FROM usuario WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dUsuarioReloj
        Dim obj As dUsuarioReloj = CType(o, dUsuarioReloj)
        Dim u As New dUsuarioReloj
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, sexo, ci, tipousuario, sector, eliminado FROM usuario WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                u.ID = CType(unaFila.Item(0), Integer)
                u.NOMBRE = CType(unaFila.Item(1), String)
                u.SEXO = CType(unaFila.Item(2), String)
                u.CI = CType(unaFila.Item(3), String)
                u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                u.SECTOR = CType(unaFila.Item(5), String)
                u.ELIMINADO = CType(unaFila.Item(6), Integer)
                Return u
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorNombre(ByVal o As Object) As dUsuarioReloj
        Dim obj As dUsuarioReloj = CType(o, dUsuarioReloj)
        Dim u As New dUsuarioReloj
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, sexo,  ci, tipousuario, sector, eliminado FROM usuario WHERE nombre = '" & obj.NOMBRE & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                u.ID = CType(unaFila.Item(0), Integer)
                u.NOMBRE = CType(unaFila.Item(1), String)
                u.SEXO = CType(unaFila.Item(2), String)
                u.CI = CType(unaFila.Item(3), String)
                u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                u.SECTOR = CType(unaFila.Item(5), String)
                u.ELIMINADO = CType(unaFila.Item(6), Integer)
                Return u
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorCI(ByVal o As Object) As dUsuarioReloj
        Dim obj As dUsuarioReloj = CType(o, dUsuarioReloj)
        Dim u As New dUsuarioReloj
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, sexo, ci, tipousuario, sector, eliminado FROM usuario WHERE ci = '" & obj.CI & "' AND eliminado = 0 ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                u.ID = CType(unaFila.Item(0), Integer)
                u.NOMBRE = CType(unaFila.Item(1), String)
                u.SEXO = CType(unaFila.Item(2), String)
                u.CI = CType(unaFila.Item(3), String)
                u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                u.SECTOR = CType(unaFila.Item(5), String)
                u.ELIMINADO = CType(unaFila.Item(6), Integer)
                Return u
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, sexo, ci, tipousuario, sector, eliminado FROM usuario where eliminado=0 order by nombre asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim u As New dUsuarioReloj
                    u.ID = CType(unaFila.Item(0), Integer)
                    u.NOMBRE = CType(unaFila.Item(1), String)
                    u.SEXO = CType(unaFila.Item(2), String)
                    u.CI = CType(unaFila.Item(3), String)
                    u.TIPOUSUARIO = CType(unaFila.Item(4), String)
                    u.SECTOR = CType(unaFila.Item(5), String)
                    u.ELIMINADO = CType(unaFila.Item(6), Integer)
                    Lista.Add(u)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
