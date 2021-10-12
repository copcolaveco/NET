Public Class FormSolicitudRodeo
#Region "Atributos"
    Private nroficha As Long = 0
    Private _usuario As dUsuario
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
        nroficha = ficha
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
    End Sub
#End Region
   
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If ComboMastitis.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado un tipo de mastitis", MsgBoxStyle.Exclamation, "Atención") : ComboMastitis.Focus() : Exit Sub
        If TextRodeo.Text.Trim.Length = 0 Then MsgBox("No se ha ingresado un número de rodeo", MsgBoxStyle.Exclamation, "Atención") : TextRodeo.Focus() : Exit Sub
        Dim rodeo As Integer = TextRodeo.Text
        Dim sr As New dSolicitudRodeo
        sr.MASTITIS = ComboMastitis.Text
        sr.FICHA = nroficha
        sr.RODEO = rodeo
        If (sr.guardar(Usuario)) Then
            MsgBox("Rodeo guardado", MsgBoxStyle.Information, "Atención")
            Me.Close()
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If

    End Sub
End Class