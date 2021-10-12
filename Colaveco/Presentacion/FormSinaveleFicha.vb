Public Class FormSinaveleFicha
#Region "Atributos"
    Private _usuario As dUsuario
    Private idficha As Long
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        idficha = solicitud
        If idficha <> 0 Then
            TextFicha.Text = idficha
        Else
            TextFicha.Text = ""
        End If
    End Sub

#End Region

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim ficha As Long = TextFicha.Text.Trim
        Dim sinavele As Long = TextSinavele.Text.Trim
        Dim nmuestras As Integer = 0
        If TextNMuestras.Text <> "" Then
            nmuestras = TextNMuestras.Text.Trim
        End If
        If TextId.Text.Trim.Length > 0 Then
            Dim s As New dSinaveleFicha()
            Dim id As Long = TextId.Text.Trim
            s.ID = id
            s.FICHA = ficha
            s.SINAVELE = sinavele
            If (s.modificar(Usuario)) Then
                Dim sol As New dSolicitudAnalisis
                sol.ID = ficha
                sol.NMUESTRAS = nmuestras
                sol.actualizar_cantidad_muestras(Usuario)
                sol = Nothing
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim s As New dSinaveleFicha()
            s.FICHA = ficha
            s.SINAVELE = sinavele
            If (s.guardar(Usuario)) Then
                Dim sol As New dSolicitudAnalisis
                sol.ID = ficha
                sol.NMUESTRAS = nmuestras
                sol.actualizar_cantidad_muestras(Usuario)
                sol = Nothing
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        limpiar()
    End Sub
    Private Sub limpiar()
        TextId.Text = ""
        TextFicha.Text = ""
        TextSinavele.Text = ""
        TextFicha.Focus()
    End Sub
    Private Sub buscar()
        Dim s As New dSinaveleFicha
        If TextFicha.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado el número de ficha", MsgBoxStyle.Exclamation, "Atención") : TextId.Focus() : Exit Sub
        Dim ficha As Long = TextFicha.Text.Trim
        s.FICHA = ficha
        s = s.buscar
        If Not s Is Nothing Then
            TextId.Text = s.ID
            TextSinavele.Text = s.SINAVELE

        End If
    End Sub

    Private Sub TextFicha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFicha.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            buscar()
            TextSinavele.Focus()
        End If
    End Sub

    Private Sub TextSinavele_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextSinavele.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            ButtonGuardar.Focus()
        End If
    End Sub

   
    Private Sub TextFicha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextFicha.TextChanged

    End Sub
End Class