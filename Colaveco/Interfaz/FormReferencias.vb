Public Class FormReferencias
#Region "Atributos"
    Private _usuario As dUsuario
    Private _idanalisis As Integer
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
    Public Sub New(ByVal idana As Integer, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _idanalisis = idana
        buscar()
        Dim lp As New dListaPrecios
        lp.ID = _idanalisis
        lp = lp.buscar
        If Not lp Is Nothing Then
            Me.Text = lp.DESCRIPCION
        End If
    End Sub
#End Region
    Private Sub buscar()
        Dim m As New dReferencias
        m.ANALISIS = _idanalisis
        m = m.buscar
        If Not m Is Nothing Then
            TextId.Text = m.ID
            TextReferencia1.Text = m.REFERENCIA1
            TextReferencia2.Text = m.REFERENCIA2
        End If
    End Sub
    Private Sub guardar()
        If _idanalisis <> 0 Then
            If TextId.Text <> "" Then
                Dim id As Integer = TextId.Text
                Dim referencia1 As String = ""
                Dim referencia2 As String = ""
                If TextReferencia1.Text <> "" Then
                    referencia1 = TextReferencia1.Text
                End If
                If TextReferencia2.Text <> "" Then
                    referencia2 = TextReferencia2.Text
                End If
                Dim m As New dReferencias
                m.ID = id
                m.ANALISIS = _idanalisis
                m.REFERENCIA1 = referencia1
                m.REFERENCIA2=referencia2
                m.modificar(Usuario)
            Else
                Dim referencia1 As String = ""
                Dim referencia2 As String = ""
                If TextReferencia1.Text <> "" Then
                    referencia1 = TextReferencia1.Text
                End If
                If TextReferencia2.Text <> "" Then
                    referencia2 = TextReferencia2.Text
                End If
                Dim m As New dReferencias
                m.ANALISIS = _idanalisis
                m.REFERENCIA1 = referencia1
                m.REFERENCIA2 = referencia2
                m.guardar(Usuario)
            End If
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
        Me.Close()
    End Sub
End Class