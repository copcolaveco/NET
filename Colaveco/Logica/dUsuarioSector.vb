Public Class dUsuarioSector
    Public Property usuario_id As Long
    Public Property sector_id As Long
    Public Property eliminado As Integer

    Public Sub New()
    End Sub

    Public Sub New(usuario_id As Long, sector_id As Long, eliminado As Integer)
        Me.usuario_id = usuario_id
        Me.sector_id = sector_id
        Me.eliminado = eliminado
    End Sub

    Public Overrides Function ToString() As String
        Return "Usuario: " & usuario_id & " - Sector: " & sector_id
    End Function

    Public Function insertar() As Boolean
        Dim p As New pUsuarioSector
        Return p.insertar(Me)
    End Function

    Public Function modificar() As Boolean
        Dim p As New pUsuarioSector
        Return p.modificar(Me)
    End Function

    Public Function eliminar() As Boolean
        Dim p As New pUsuarioSector
        Return p.eliminar(Me)
    End Function

    Public Function buscar(ByVal usuarioId As Long) As ArrayList
        Dim p As New pUsuarioSector
        Return p.buscar(usuarioId)
    End Function
End Class

