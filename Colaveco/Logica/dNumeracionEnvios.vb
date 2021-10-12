Public Class dNumeracionEnvios
#Region "Atributos"
    Private m_id As Integer
    Private m_idagencia As Integer
    Private m_envio As String
#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Public Property IDAGENCIA() As Integer
        Get
            Return m_idagencia
        End Get
        Set(ByVal value As Integer)
            m_idagencia = value
        End Set
    End Property
    Public Property ENVIO() As String
        Get
            Return m_envio
        End Get
        Set(ByVal value As String)
            m_envio = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idagencia = 0
        m_envio = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal idagencia As Integer, ByVal envio As String)
        m_id = id
        m_idagencia = idagencia
        m_envio = envio
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNumeracionEnvios
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNumeracionEnvios
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNumeracionEnvios
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNumeracionEnvios
        Dim p As New pNumeracionEnvios
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pNumeracionEnvios
        Return p.listar
    End Function
End Class
