Public Class pUsuarioSector
    Inherits Conectoras.ConexionMySQL

    Public Function insertar(ByVal us As dUsuarioSector) As Boolean
        Dim sql As String = "INSERT INTO usuario_sector (usuario_id, sector_id, eliminado) VALUES (" & us.usuario_id & ", " & us.sector_id & ", " & us.eliminado & ")"
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificar(ByVal us As dUsuarioSector) As Boolean
        Dim sql As String = "UPDATE usuario_sector SET eliminado = " & us.eliminado & " WHERE usuario_id = " & us.usuario_id & " AND sector_id = " & us.sector_id
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal us As dUsuarioSector) As Boolean
        Dim sql As String = "DELETE FROM usuario_sector WHERE usuario_id = " & us.usuario_id & " AND sector_id = " & us.sector_id
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function


    Public Function buscar(ByVal usuarioId As Long) As ArrayList
        Dim sql As String = "SELECT usuario_id, sector_id, eliminado FROM usuario_sector WHERE usuario_id = " & usuarioId
        Dim lista As New ArrayList
        Try
            Dim ds As DataSet = Me.EjecutarSQL(sql)
            For Each row As DataRow In ds.Tables(0).Rows
                Dim us As New dUsuarioSector
                us.usuario_id = CType(row("usuario_id"), Long)
                us.sector_id = CType(row("sector_id"), Long)
                us.eliminado = CType(row("eliminado"), Integer)
                lista.Add(us)
            Next
        Catch ex As Exception
        End Try
        Return lista
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT * FROM usuario_sector WHERE eliminado = 0 ORDER BY usuario_id, sector_id"
        Dim Ds As DataSet = Me.EjecutarSQL(sql)
        Dim lista As New ArrayList
        For Each fila As DataRow In Ds.Tables(0).Rows
            Dim us As New dUsuarioSector
            us.usuario_id = CType(fila.Item("usuario_id"), Long)
            us.sector_id = CType(fila.Item("sector_id"), Long)
            us.eliminado = CType(fila.Item("eliminado"), Integer)
            lista.Add(us)
        Next
        Return lista
    End Function
End Class

