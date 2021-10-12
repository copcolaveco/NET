Public Class FormCompletoEnvio2
    Private _usuario As dUsuario
    Private _envio As Long
    Private _pedido As Long

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property
#Region "Constructores"
    Public Sub New(ByVal id As Long, ByVal u As dUsuario)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        _envio = id
        Dim ec As New dEnvioCajas
        ec.ID = _envio
        ec = ec.buscar2
        If Not ec Is Nothing Then
            TextCaja.Text = ec.IDCAJA
            _pedido = ec.IDPEDIDO
            cargarultimoenvio()
            TextEnvio.Focus()
        End If
    End Sub
#End Region
    Private Sub cargarultimoenvio()
        Dim ne As New dNumeracionEnvios
        Dim ec As New dEnvioCajas
        Dim id As Long = 0
        Dim agencia As Integer = 0
        id = _envio
        ec.ID = id
        ec = ec.buscarxenvio
        If Not ec Is Nothing Then
            agencia = ec.IDEMPRESA
            ne.IDAGENCIA = agencia
            ne = ne.buscar
            If Not ne Is Nothing Then
                TextEnvio.Text = ne.ENVIO
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        guardar()
    End Sub
    Private Sub guardar()
        Dim ec As New dEnvioCajas
        Dim ec2 As New dEnvioCajas
        Dim ne As New dNumeracionEnvios
        Dim id As Long
        Dim pedido As Long
        Dim agencia As Integer
        Dim envio As String = ""
        id = _envio
        ec2.ID = id
        ec2 = ec2.buscar2
        If Not ec2 Is Nothing Then
            agencia = ec2.IDEMPRESA
        End If
        pedido = _pedido
        If TextEnvio.Text <> "" Then
            envio = TextEnvio.Text.Trim
        End If
        ec.ID = id
        ec.ENVIO = envio
        ec.completarenvio(Usuario)
        ne.IDAGENCIA = agencia
        ne.ENVIO = envio
        ne.modificar(Usuario)
        Me.Close()
    End Sub

    Private Sub TextEnvio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextEnvio.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            guardar()
        End If
    End Sub

End Class