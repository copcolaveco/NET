Public Class dSectorTipoInforme
    Public Property sector_id As Long
    Public Property tipo_informe_id As Long
    Public Property eliminado As Integer

    Public Sub New()
    End Sub

    Public Sub New(sector_id As Long, tipo_informe_id As Long, eliminado As Integer)
        Me.sector_id = sector_id
        Me.tipo_informe_id = tipo_informe_id
        Me.eliminado = eliminado
    End Sub

    Public Function insertar() As Boolean
        Dim p As New pSectorTipoInforme
        Return p.insertar(Me)
    End Function

    Public Function modificar() As Boolean
        Dim p As New pSectorTipoInforme
        Return p.modificar(Me)
    End Function

    Public Function eliminar() As Boolean
        Dim p As New pSectorTipoInforme
        Return p.eliminar(Me)
    End Function

    Public Function buscar(ByVal usuarioId As Long) As ArrayList
        Dim p As New pSectorTipoInforme
        Return p.buscar(usuarioId)
    End Function
End Class

