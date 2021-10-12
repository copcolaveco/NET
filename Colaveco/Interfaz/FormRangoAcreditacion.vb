Public Class FormRangoAcreditacion
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
        cargarDatos()

        Dim lp As New dListaPrecios
        lp.ID = _idanalisis
        lp = lp.buscar
        If Not lp Is Nothing Then
            Me.Text = lp.DESCRIPCION
        End If
    End Sub
#End Region
    Private Sub cargarDatos()
        Dim a As New dAcreditacion
        a.ANALISIS = _idanalisis
        a = a.buscar
        If Not a Is Nothing Then
            TextDescripcion.Text = a.DESCRIPCION
            TextDesde.Text = a.DESDE
            TextHasta.Text = a.HASTA
        End If
    End Sub

    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub
    Private Sub guardar()
        If _idanalisis <> 0 Then
            Dim nuevo As Integer = 1
            Dim ac As New dAcreditacion
            ac.ANALISIS = _idanalisis
            ac = ac.buscar
            If Not ac Is Nothing Then
                nuevo = 0
            Else
                nuevo = 1
            End If

            Dim descripcion As String = ""
            Dim desde As String = ""
            Dim hasta As String = ""
            If TextDescripcion.Text <> "" Then
                descripcion = TextDescripcion.Text.Trim
            End If
            If TextDesde.Text <> "" Then
                desde = TextDesde.Text.Trim
            End If
            If TextHasta.Text <> "" Then
                hasta = TextHasta.Text.Trim
            End If
            Dim a As New dAcreditacion
            If nuevo = 0 Then
                a.ANALISIS = _idanalisis
                a.DESCRIPCION = descripcion
                a.DESDE = desde
                a.HASTA = hasta
                a.modificar(Usuario)
                MsgBox("Registro modificado")

            Else
                a.ANALISIS = _idanalisis
                a.DESCRIPCION = descripcion
                a.DESDE = desde
                a.HASTA = hasta
                a.guardar(Usuario)
                MsgBox("Registro guardado")
            End If
        End If
    End Sub
End Class