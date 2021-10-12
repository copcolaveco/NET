Public Class FormPedidoUrgente
    Private nombrep As String
    Public Sub New(ByVal nombre As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Timer1.Enabled = False
        nombrep = nombre
        Me.Text = "Pedido urgente - " & nombre
        sonido()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = False
        My.Computer.Audio.Stop()
        Me.Close()

    End Sub
    Private Sub sonido()

        My.Computer.Audio.Play("c:\debug\alarma2.wav")
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        My.Computer.Audio.Play("c:\debug\alarma2.wav")
    End Sub
End Class