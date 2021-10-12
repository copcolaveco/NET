Public Class FormCompletoLaboratorio
    Private _usuario As dUsuario
    Private _idnuevoanalisis As Long
    Private _idanal As Integer

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal id As Long, ByVal nanal As String, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _idnuevoanalisis = id
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        cargarcombo()

    End Sub
#End Region

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim at As New dAnalisisTercerizado
        Dim laboratorio As dOtrosLaboratorios = CType(ComboLaboratorio.SelectedItem, dOtrosLaboratorios)
        at.ID = _idnuevoanalisis
        at.LABORATORIO = laboratorio.ID
        at.actualizar_laboratorio(Usuario)
        Me.Close()
    End Sub
    Private Sub cargarcombo()
        Dim ol As New dOtrosLaboratorios
        Dim lista As New ArrayList
        lista = ol.listar
        If Not lista Is Nothing Then
            For Each ol In lista
                ComboLaboratorio.Items.Add(ol)
            Next
        End If
    End Sub

    Private Sub ComboResultado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboLaboratorio.SelectedIndexChanged
        guardar()
    End Sub
End Class