Public Class FormSinSolicitud
#Region "Atributos"
    Private _usuario As dUsuario
    Private _ficha As Long
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
    Public Sub New(ByVal u As dUsuario, ByVal ficha As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _ficha = ficha
        TextFicha.Text = _ficha
        TextDetalle.Focus()
    End Sub

#End Region
    Private Sub limpiar()
        TextId.Text = ""
        TextFicha.Text = ""
        TextDetalle.Text = ""
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        Dim ficha As Long = TextFicha.Text.Trim
        Dim detalle As String = TextDetalle.Text.Trim
        If TextId.Text.Trim.Length > 0 Then
            Dim s As New dSinSolicitud
            Dim id As Long = TextId.Text.Trim
            s.ID = id
            s.FICHA = ficha
            s.DETALLE = detalle
            If (s.modificar(Usuario)) Then
                MsgBox("Registro modificado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        Else
            Dim s As New dSinSolicitud
            s.FICHA = ficha
            s.DETALLE = detalle
            If (s.guardar(Usuario)) Then
                MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
            Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
            End If
        End If
        Me.Close()
    End Sub
End Class