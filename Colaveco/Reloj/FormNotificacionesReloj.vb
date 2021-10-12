Public Class FormNotificacionesReloj
#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        cargarNotificaciones()
    End Sub
#End Region
    Private Sub cargarNotificaciones()
        DataGridNotificaciones.Rows.Clear()
        Dim n As New dNotificaciones_reloj
        Dim lista As New ArrayList
        Dim fila As Integer = 0
        Dim columna As Integer = 0
        lista = n.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                DataGridNotificaciones.Rows.Clear()
                DataGridNotificaciones.Rows.Add(lista.Count)
                For Each n In lista
                    DataGridNotificaciones(columna, fila).Value = n.ID
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.FECHA
                    columna = columna + 1
                    Dim u As New dUsuario
                    u.ID = n.IDUSUARIO
                    u = u.buscar
                    DataGridNotificaciones(columna, fila).Value = u.NOMBRE
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.FECHAEVENTO
                    columna = columna + 1
                    DataGridNotificaciones(columna, fila).Value = n.DETALLE
                    columna = 0
                    fila = fila + 1
                Next
            End If
        End If
    End Sub
End Class