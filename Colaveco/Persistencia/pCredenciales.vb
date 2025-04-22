Public Class pCredenciales
    Inherits Conectoras.ConexionMySQL

    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCredenciales = CType(o, dCredenciales)
        Dim sql As String = "INSERT INTO credenciales (CredencialesHost, CredencialesUsuario, CredencialesPassword, CredencialesEliminado, CredencialesDescripcion) VALUES (" &
            "'" & obj.CredencialesHost & "'," &
            "'" & obj.CredencialesUsuario & "'," &
            "'" & obj.CredencialesPassword & "'," &
            obj.CredencialesEliminado & "," &
            "'" & obj.CredencialesDescripcion & "')"

        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCredenciales = CType(o, dCredenciales)
        Dim sql As String = "UPDATE credenciales SET " &
            "CredencialesHost = '" & obj.CredencialesHost & "', " &
            "CredencialesUsuario = '" & obj.CredencialesUsuario & "', " &
            "CredencialesPassword = '" & obj.CredencialesPassword & "', " &
            "CredencialesEliminado = " & obj.CredencialesEliminado & ", " &
            "CredencialesDescripcion = '" & obj.CredencialesDescripcion & "' " &
            "WHERE CredencialesId = " & obj.CredencialesId

        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCredenciales = CType(o, dCredenciales)
        Dim sql As String = "DELETE FROM credenciales WHERE CredencialesId = " & obj.CredencialesId

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal criterio As String) As dCredenciales
        Dim sql As String = "SELECT * FROM credenciales WHERE " &
                            "CredencialesId = '" & criterio & "' " &
                            "OR CredencialesDescripcion LIKE '%" & criterio & "%' " &
                            "OR CredencialesHost LIKE '%" & criterio & "%'"

        Dim ds As New DataSet
        ds = EjecutarSQL(sql)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim obj As New dCredenciales()
            obj.CredencialesId = row("CredencialesId")
            obj.CredencialesHost = row("CredencialesHost").ToString()
            obj.CredencialesUsuario = row("CredencialesUsuario").ToString()
            obj.CredencialesPassword = row("CredencialesPassword").ToString()
            obj.CredencialesEliminado = Convert.ToInt32(row("CredencialesEliminado"))
            obj.CredencialesDescripcion = row("CredencialesDescripcion").ToString()
            Return obj
        End If

        Return Nothing
    End Function

End Class
