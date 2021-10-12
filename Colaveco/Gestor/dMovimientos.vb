Public Class dMovimientos
    Private m_idnet_movimiento As Long
    Private m_fecha_emision As String
    Private m_fecha_vencimiento As Long
    Private m_tipo As Integer
    Private m_numero As String
    Private m_detalle As String
    Private m_importe As String
    Private m_tipo_movimiento As String
    Private m_importe_pago As String
    Private m_idnet_usuario As Integer

#Region "Getters y Setters"
    Public Property idnet_movimiento() As Long
        Get
            Return m_idnet_movimiento
        End Get
        Set(ByVal value As Long)
            m_idnet_movimiento = value
        End Set
    End Property
    Public Property fecha_emision() As String
        Get
            Return m_fecha_emision
        End Get
        Set(ByVal value As String)
            m_fecha_emision = value
        End Set
    End Property
    Public Property fecha_vencimiento() As String
        Get
            Return m_fecha_vencimiento
        End Get
        Set(ByVal value As String)
            m_fecha_vencimiento = value
        End Set
    End Property
    Public Property tipo() As String
        Get
            Return m_tipo

        End Get
        Set(ByVal value As String)
            m_tipo = value
        End Set
    End Property
    Public Property numero() As Long
        Get
            Return m_numero
        End Get
        Set(ByVal value As Long)
            m_numero = value
        End Set
    End Property
    Public Property detalle() As String
        Get
            Return m_detalle
        End Get
        Set(ByVal value As String)
            m_detalle = value
        End Set
    End Property
    Public Property importe() As Double
        Get
            Return m_importe
        End Get
        Set(ByVal value As Double)
            m_importe = value
        End Set
    End Property
    Public Property tipo_movimiento() As Integer
        Get
            Return m_tipo_movimiento
        End Get
        Set(ByVal value As Integer)
            m_tipo_movimiento = value
        End Set
    End Property
    Public Property importe_pago() As Double
        Get
            Return m_importe_pago
        End Get
        Set(ByVal value As Double)
            m_importe_pago = value
        End Set
    End Property
    Public Property idnet_usuario() As Long
        Get
            Return m_idnet_usuario
        End Get
        Set(ByVal value As Long)
            m_idnet_usuario = value
        End Set
    End Property
#End Region
End Class
