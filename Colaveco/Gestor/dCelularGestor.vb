Public Class dCelularGestor
    Private m_idusuario As Long
    Private m_tipo As String
    Private m_nombre As String
    Private m_celular As String

#Region "Getters y Setters"
    Public Property idusuario() As Long
        Get
            Return m_idusuario
        End Get
        Set(ByVal value As Long)
            m_idusuario = value
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
    Public Property nombre() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property celular() As String
        Get
            Return m_celular
        End Get
        Set(ByVal value As String)
            m_celular = value
        End Set
    End Property
#End Region
End Class
