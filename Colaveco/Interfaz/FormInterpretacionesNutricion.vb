Public Class FormInterpretacionesNutricion
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
        buscarinterpretaciones()
    End Sub
    Private Sub buscarinterpretaciones()
        Dim idficha As Long = 0
        idficha = TextFicha.Text.Trim
        Dim sa As New dSolicitudAnalisis
        sa.ID = idficha
        sa = sa.buscar
        If Not sa Is Nothing Then
            If sa.INTERPRETACION <> "" Then
                TextInterpretacion.Text = sa.INTERPRETACION
            Else
                TextInterpretacion.Text = ""
            End If
        Else
            TextInterpretacion.Text = ""
        End If
    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        Me.Close()
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardarinterpretacion()
    End Sub
    Private Sub guardarinterpretacion()
        Dim ficha As Long = 0
        Dim interp As String = ""
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            interp = TextInterpretacion.Text.Trim
            Dim sa As New dSolicitudAnalisis
            sa.ID = ficha
            sa.INTERPRETACION = interp
            sa.modificarinterpretacion(Usuario)
        End If
        Me.Close()
    End Sub
End Class