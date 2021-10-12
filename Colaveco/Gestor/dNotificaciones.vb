Public Class dNotificaciones
    Private m_fecha As String
    Private m_tipo As String
    Private m_mensaje As String
    Private m_idnet_usuario As Integer
    Private m_detalle As String

#Region "Getters y Setters"
    Public Property fecha() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
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
    Public Property mensaje() As String
        Get
            Return m_mensaje
        End Get
        Set(ByVal value As String)
            m_mensaje = value
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
    Public Property detalle() As String
        Get
            Return m_detalle
        End Get
        Set(ByVal value As String)
            m_detalle = value
        End Set
    End Property
#End Region
End Class
