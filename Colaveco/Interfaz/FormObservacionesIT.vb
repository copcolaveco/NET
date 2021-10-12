Public Class FormObservacionesIT
    Dim ido As Long
    Private _usuario As dUsuario

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

    Public Sub New(ByVal id As Long)
        InitializeComponent()
        TextBox1.Text = id
        ido = id
        CargarObservaciones(id)
    End Sub

    Private Sub CargarObservaciones(ByVal id As Long)
        Dim s As New dSolicitudesIT
        Dim u As New dUsuario
        s.ID = id
        s = s.buscar
        TextObservaciones.Text = s.OBSERVACIONES
    End Sub

    Private Sub GuardarObsvervaciones(ByVal id As Long)
        Dim s As New dSolicitudesIT

        If TextObservaciones.Text <> "" Then
            s.OBSERVACIONES = TextObservaciones.Text.Trim
            s.ID = id
            If (s.modificarObservaciones(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            GuardarObsvervaciones(ido)
        Else
            MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
    End Sub
End Class