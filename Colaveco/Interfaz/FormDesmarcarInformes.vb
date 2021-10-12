Public Class FormDesmarcarInformes
    Private _usuario As dUsuario
    Private ficha_descarte As Long = 0
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        limpiar()

    End Sub
#End Region
    Private Sub ButtonAgua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgua.Click
        Dim a As New dAgua2
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            a.FICHA = ficha
            a.desmarcarficha()
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub

    Private Sub ButtonAntibiograma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAntibiograma.Click
        Dim a As New dAntibiograma
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            a.FICHA = ficha
            a.desmarcarficha()
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub

    Private Sub ButtonBrucelosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBrucelosis.Click
        Dim b As New dBrucelosis
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            b.FICHA = ficha
            b.desmarcarficha()
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub

    Private Sub ButtonSubproductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubproductos.Click
        Dim s As New dSubproducto2
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            s.FICHA = ficha
            s.desmarcarficha()
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub
    Private Sub limpiar()
        TextFicha.Text = ""
        TextFicha.Focus()
    End Sub

    Private Sub ButtonSuelos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSuelos.Click
        Dim s As New dSuelos
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            s.FICHA = ficha
            s.desmarcarficha()
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub

    Private Sub ButtonNutricion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNutricion.Click
        Dim n As New dNutricion
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            n.FICHA = ficha
            n.desmarcarficha()
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub

    Private Sub ButtonCalidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCalidad.Click
        Dim sa As New dSolicitudAnalisis
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            sa.ID = ficha
            sa.desmarcar(Usuario)
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub

    Private Sub ButtonControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonControl.Click
        Dim sa As New dSolicitudAnalisis
        Dim ficha As Long = 0
        If TextFicha.Text <> "" Then
            ficha = TextFicha.Text.Trim
            sa.ID = ficha
            sa.desmarcar(Usuario)
            desmarcar_preinformes(ficha)
            MsgBox("Listo!")
            limpiar()
        End If
    End Sub
    Private Sub desmarcar_preinformes(ByVal ficha As Long)
        Dim pi As New dPreinformes
        pi.FICHA = ficha
        pi.PARASUBIR = 1
        pi.SUBIDO = 0
        pi.modificar3()
    End Sub
End Class