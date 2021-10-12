Public Class FormPedidosPendientes
    Private _usuario As dUsuario
    Private idpedi As Long = 0
    Private id As Long = 0

    Public Property Usuario() As dUsuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As dUsuario)
            _usuario = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New(ByVal u As dUsuario, ByVal idped As Long)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Usuario = u
        idpedi = idped
        buscarpedido()
    End Sub
#End Region
    Private Sub buscarpedido()
        Dim pp As New dPedidosPendientes
        pp.PEDIDO = idpedi
        pp = pp.buscar
        If Not pp Is Nothing Then
            id = pp.ID
            TextObservaciones.Text = pp.OBSERVACIONES
        End If
    End Sub
    Private Sub ButtonGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGuardar.Click
        If TextObservaciones.Text <> "" Then
            If id > 0 Then
                Dim pp As New dPedidosPendientes
                pp.ID = id
                pp.PEDIDO = idpedi
                pp.OBSERVACIONES = TextObservaciones.Text.Trim
                If (pp.modificar(Usuario)) Then
                    MsgBox("Pedido modificado", MsgBoxStyle.Information, "Atención")
                    Me.Close()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            Else
                Dim pp As New dPedidosPendientes
                pp.PEDIDO = idpedi
                pp.OBSERVACIONES = TextObservaciones.Text.Trim
                If (pp.guardar(Usuario)) Then
                    MsgBox("Pedido guardado", MsgBoxStyle.Information, "Atención")
                    Me.Close()
                Else : MsgBox("Error", MsgBoxStyle.Critical, "Atención")
                End If
            End If
          
        End If
    End Sub
End Class