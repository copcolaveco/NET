Public Class FormAntibiograma2
    Private _usuario As dUsuario
    Dim idsol As Long

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal solicitud As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        idsol = solicitud
        CheckAislamiento.Checked = True
        CheckAislamiento.Enabled = False
    End Sub
#End Region
    

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click

        Dim aislamiento As Integer
        Dim antibiograma As Integer
        If CheckAntibiograma.Checked = True Then
            antibiograma = 1
        Else
            antibiograma = 0
        End If
        Dim a2 As New dAntibiograma2
        a2.IDSOLICITUD = idsol
        a2.AISLAMIENTO = 1
        a2.ANTIBIOGRAMA = antibiograma
        If (a2.guardar(Usuario)) Then
            MsgBox("Registro guardado", MsgBoxStyle.Information, "Atención")
        Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
        End If
        Me.Close()

    End Sub
End Class