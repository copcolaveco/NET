Public Class FormObservacionesSinVisualizacion
#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        
    End Sub
#End Region

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim observaciones As String = ""
        observaciones = TextObservaciones.Text.Trim
        If observaciones <> "" Then
            Dim sv As New dSinVisualizacion
            sv.FICHA = fichasv
            sv.OBSERVACIONES = observaciones
            sv.actualizarobservaciones()
            fichasv = 0
        End If
        Me.Close()
    End Sub
End Class