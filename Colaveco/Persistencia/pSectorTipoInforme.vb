Public Class pSectorTipoInforme
    Inherits Conectoras.ConexionMySQL

    Public Function insertar(ByVal sti As dSectorTipoInforme) As Boolean
        Dim sql As String = "INSERT INTO sector_tipoinforme (sector_id, tipo_informe_id, eliminado) VALUES (" & sti.sector_id & ", " & sti.tipo_informe_id & ", " & sti.eliminado & ")"
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificar(ByVal sti As dSectorTipoInforme) As Boolean
        Dim sql As String = "UPDATE sector_tipoinforme SET eliminado = " & sti.eliminado & " WHERE sector_id = " & sti.sector_id & " AND tipo_informe_id = " & sti.tipo_informe_id
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal sti As dSectorTipoInforme) As Boolean
        Dim sql As String = "DELETE FROM sector_tipoinforme WHERE sector_id = " & sti.sector_id & " AND tipo_informe_id = " & sti.tipo_informe_id
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscar(ByVal sectorId As Long) As ArrayList
        Dim sql As String = "SELECT sector_id, tipo_informe_id, eliminado FROM sector_tipoinforme WHERE sector_id = " & sectorId
        Dim lista As New ArrayList
        Try
            Dim ds As DataSet = Me.EjecutarSQL(sql)
            For Each row As DataRow In ds.Tables(0).Rows
                Dim sti As New dSectorTipoInforme
                sti.SECTOR_ID = CType(row("sector_id"), Long)
                sti.TIPO_INFORME_ID = CType(row("tipo_informe_id"), Long)
                sti.ELIMINADO = CType(row("eliminado"), Integer)
                lista.Add(sti)
            Next
        Catch ex As Exception
        End Try
        Return lista
    End Function
End Class

