Public Class dCredenciales

    Private m_id As Long
    Private m_host As String
    Private m_usuario As String
    Private m_password As String
    Private m_eliminado As Integer
    Private m_descripcion As String

    ' Propiedades
    Public Property CredencialesId() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property

    Public Property CredencialesHost() As String
        Get
            Return m_host
        End Get
        Set(ByVal value As String)
            m_host = value
        End Set
    End Property

    Public Property CredencialesUsuario() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property

    Public Property CredencialesPassword() As String
        Get
            Return m_password
        End Get
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property

    Public Property CredencialesEliminado() As Integer
        Get
            Return m_eliminado
        End Get
        Set(ByVal value As Integer)
            m_eliminado = value
        End Set
    End Property

    Public Property CredencialesDescripcion() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property

    ' Constructor vacío
    Public Sub New()
        m_id = 0
        m_host = ""
        m_usuario = ""
        m_password = ""
        m_eliminado = 0
        m_descripcion = ""
    End Sub

    ' Constructor con parámetros
    Public Sub New(ByVal id As Long, ByVal host As String, ByVal usuario As String, ByVal password As String, ByVal eliminado As Integer, ByVal descripcion As String)
        m_id = id
        m_host = host
        m_usuario = usuario
        m_password = password
        m_eliminado = eliminado
        m_descripcion = descripcion
    End Sub

    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCredenciales
        Return p.guardar(Me, usuario)
    End Function

    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCredenciales
        Return p.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCredenciales
        Return p.eliminar(Me, usuario)
    End Function

    Public Shared Function buscar(ByVal criterio As String) As dCredenciales
        Dim p As New pCredenciales
        Return p.buscar(criterio)
    End Function


End Class
