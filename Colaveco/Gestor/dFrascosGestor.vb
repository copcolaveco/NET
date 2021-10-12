Public Class dFrascosGestor
    Private m_id As Long
    Private m_idnet As Long
    Private m_nombre As String
    Private m_direccion As String
    Private m_agencia As String
    Private m_telefono As String
    Private m_email As String
    Private m_frascos_con_c As Integer
    Private m_frascos_sin_c As Integer
    Private m_frascos_agua As Integer
    Private m_frascos_sangre As Integer
    Private m_observaciones As String

#Region "Getters y Setters"
    Public Property id() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property
    Public Property idnet() As Long
        Get
            Return m_idnet
        End Get
        Set(ByVal value As Long)
            m_idnet = value
        End Set
    End Property
    Public Property nombre() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property direccion() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property agencia() As String
        Get
            Return m_agencia
        End Get
        Set(ByVal value As String)
            m_agencia = value
        End Set
    End Property
    Public Property telefono() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
        End Set
    End Property
    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property frascos_con_c() As Integer
        Get
            Return m_frascos_con_c
        End Get
        Set(ByVal value As Integer)
            m_frascos_con_c = value
        End Set
    End Property
    Public Property frascos_sin_c() As Integer
        Get
            Return m_frascos_sin_c
        End Get
        Set(ByVal value As Integer)
            m_frascos_sin_c = value
        End Set
    End Property
    Public Property frascos_agua() As Integer
        Get
            Return m_frascos_agua
        End Get
        Set(ByVal value As Integer)
            m_frascos_agua = value
        End Set
    End Property
    Public Property frascos_sangre() As Integer
        Get
            Return m_frascos_sangre
        End Get
        Set(ByVal value As Integer)
            m_frascos_sangre = value
        End Set
    End Property
    Public Property observaciones() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
#End Region
End Class
