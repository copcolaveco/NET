Public Class FormEliminarControlLechero
    Private _usuario As dUsuario

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
        RadioControl.Checked = True
    End Sub

#End Region
    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If RadioControl.Checked = True Then
            eliminarcontrol()
        Else
            eliminarcalidad()
        End If
    End Sub
    Private Sub eliminarcontrol()
        Dim c As New dControl
        Dim ficha As Long
        ficha = TextFicha.Text.Trim
        c.FICHA = ficha
        c.eliminar(Usuario)
        TextFicha.Text = ""
        MsgBox("Importación de control lechero, eliminado")
    End Sub
    Private Sub eliminarcalidad()
        Dim cal As New dCalidad
        Dim ficha As Long
        ficha = TextFicha.Text.Trim
        cal.FICHA = ficha
        cal.eliminar(Usuario)
        TextFicha.Text = ""
        MsgBox("Importación de calidad de leche, eliminado")
    End Sub
End Class