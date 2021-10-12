Public Class FormCompletoATB2
    Private _usuario As dUsuario
    Private _idnuevoanalisis As Long
    Private _idanal As Integer
    Private _id As Long
    Private _ficha As Long
    Private _muestra As String
    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        _idnuevoanalisis = id
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _id = id
        _muestra = muestra
        _ficha = ficha
     
    End Sub
#End Region
    Private Sub ComboResultado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboResistencia.SelectedIndexChanged
        Dim id As Integer = 0
        Dim id_ As Long = 0
        Dim ficha As Long = 0
        Dim muestra As String = ""
        Dim aislamiento As Integer = 0
        Dim atb_ As Integer = 0
        Dim resist As String = ComboResistencia.Text
        Dim modifica As Integer = 0

        ficha = _ficha
        muestra = _muestra
        Dim ma As New dMicroATB
        ma.ID = _id
        ma = ma.buscar
        If Not ma Is Nothing Then
            aislamiento = ma.MICRO
            atb_ = ma.ATB
        End If

        Dim atb As New dATB
        atb.FICHA = ficha
        atb.MUESTRA = muestra
        atb.AISLAMIENTO = aislamiento
        atb.ATB = atb_
        atb = atb.buscarxfichaxmuestra
        If Not atb Is Nothing Then
            modifica = 1
            id_ = atb.ID
        Else
            modifica = 0
        End If
        If modifica = 1 Then
            Dim atb2 As New dATB
            atb2.ID = id_
            atb2.FICHA = ficha
            atb2.MUESTRA = muestra
            atb2.AISLAMIENTO = aislamiento
            atb2.ATB = atb_
            atb2.RESISTENCIA = resist
            atb2.modificar(Usuario)
        Else
            Dim atb2 As New dATB
            atb2.FICHA = ficha
            atb2.MUESTRA = muestra
            atb2.AISLAMIENTO = aislamiento
            atb2.ATB = atb_
            atb2.RESISTENCIA = resist
            atb2.guardar(Usuario)
        End If
        Me.Close()
    End Sub
End Class