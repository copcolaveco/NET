Public Class FormObservaciones
    Private _usuario As dUsuario
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
    Public Sub New(ByVal u As dUsuario, ByVal ficha As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        TextFicha.Text = ficha
        buscarobservaciones()
    End Sub
    Private Sub buscarobservaciones()
        Dim idficha As Long = 0
        idficha = TextFicha.Text.Trim
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            If sa.OBSERVACIONES <> "" Then
                TextObservaciones.Text = sa.OBSERVACIONES
            Else
                TextObservaciones.Text = ""
            End If
        Else
            TextObservaciones.Text = ""
        End If
    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        Me.Close()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        modificarobservaciones()
    End Sub
    Private Sub modificarobservaciones()
        Dim ficha As Long = 0
        Dim obs As String = ""
        If TextFicha.Text <> "" Then

            ficha = TextFicha.Text.Trim
            obs = TextObservaciones.Text.Trim
            Dim sa As New dSolicitudAnalisis
            sa.ID = ficha
            sa.OBSERVACIONES = obs
            sa.modificarobservaciones(Usuario)

        End If
        Me.Close()
    End Sub
End Class