Public Class dInhibidores_obs
#Region "Atributos"
    Private m_id As Long
    Private m_idinh As Long
    Private m_observaciones As String
    Private m_eliminado As Integer
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
    Public Property IDINH() As Long
        Get
            Return m_idinh
        End Get
        Set(ByVal value As Long)
            m_idinh = value
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
    Public Property ELIMINADO() As Integer
        Get
            Return m_eliminado
        End Get
        Set(ByVal value As Integer)
            m_eliminado = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idinh = 0
        m_observaciones = ""
        m_eliminado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idinh As Long, ByVal observaciones As String, ByVal eliminado As Integer)
        m_id = id
        m_idinh = idinh
        m_observaciones = observaciones
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pInhibidores_obs
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pInhibidores_obs
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pInhibidores_obs
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dInhibidores_obs
        Dim c As New pInhibidores_obs
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pInhibidores_obs
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pInhibidores_obs
        Return c.listarporid(texto)
    End Function

    
End Class
