Public Class FormEstadoSolicitudIT
    Public Sub New(ByVal id As Long, ByVal estado As Integer)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TextId.Text = id
        If estado = 1 Then
            RadioPendiente.Checked = True
        ElseIf estado = 2 Then
            RadioProceso.Checked = True
        ElseIf estado = 3 Then
            RadioFinalizado.Checked = True
        End If

    End Sub
    Private Sub ButtonGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGrabar.Click
        Dim sit As New dSolicitudesIT
        Dim id As Long = 0
        id = TextId.Text.Trim
        Dim estado As Integer = 0
        If RadioPendiente.Checked = True Then
            estado = 1
        ElseIf RadioProceso.Checked = True Then
            estado = 2
        ElseIf RadioFinalizado.Checked = True Then
            estado = 3
        End If
        sit.ID = id
        sit.ESTADO = estado
        sit.modificarestado()
        Me.Close()
    End Sub
End Class