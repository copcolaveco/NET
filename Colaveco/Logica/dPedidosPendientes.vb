Public Class dPedidosPendientes
#Region "Atributos"
    Private m_id As Long
    Private m_pedido As Long
    Private m_observaciones As String
#End Region

#Region "Getters y Setters"
    Public Property ID() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property
    Public Property PEDIDO() As Long
        Get
            Return m_pedido
        End Get
        Set(ByVal value As Long)
            m_pedido = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_pedido = 0
        m_observaciones = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal pedido As Long, ByVal observaciones As String)
        m_id = id
        m_pedido = pedido
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosPendientes
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosPendientes
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosPendientes
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPedidosPendientes
        Dim p As New pPedidosPendientes
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_pedido
    End Function

    Public Function listar() As ArrayList
        Dim p As New dPedidosPendientes
        Return p.listar
    End Function
End Class
