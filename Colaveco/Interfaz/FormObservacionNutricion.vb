Public Class FormObservacionNutricion
    Private _usuario As dUsuario
    Private _texto As String
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
        RadioSilo.Checked = True
        buscarobservaciones()
        seleccionar_texto()
        juntar_observaciones()
    End Sub
    Private Sub buscarobservaciones()
        Dim idficha As Long = 0
        idficha = TextFicha.Text.Trim
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            If sa.OBSERVACIONES <> "" Then
                TextObservacion.Text = sa.OBSERVACIONES
            Else
                TextObservacion.Text = ""
            End If
        Else
            TextObservacion.Text = ""
        End If
    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        Me.Close()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardarobservacion()
    End Sub
    Private Sub guardarobservacion()
        Dim ficha As Long = 0
        Dim obs As String = ""
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            obs = TextObservacion.Text.Trim
            Dim sa As New dSolicitudAnalisis
            sa.ID = ficha
            sa.OBSERVACIONES = obs
            sa.modificarobservaciones(Usuario)
        End If
        Me.Close()
    End Sub
    Private Sub seleccionar_texto()
        If RadioSilo.Checked = True Then
            _texto = ""
            _texto = "Análisis realizados sobre el material parcialmente seco (60ºC) y posterior expresión del resultado en base a MS total (105ºC)."
        Else
            _texto = ""
            _texto = "Análisis realizados sobre el material original y posterior cálculo para la expresión del resultado en base a MS total (105ºC)."
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSilo.CheckedChanged
        seleccionar_texto()
        juntar_observaciones()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGenerales.CheckedChanged
        seleccionar_texto()
        juntar_observaciones()
    End Sub
    Private Sub juntar_observaciones()
        Dim obs As String = ""
        obs = TextObservacion.Text.Trim
        If obs <> "" Then
            TextObservacion.Text = TextObservacion.Text.Trim & vbCrLf _
            & _texto
        Else
            TextObservacion.Text = _texto
        End If
    End Sub
End Class