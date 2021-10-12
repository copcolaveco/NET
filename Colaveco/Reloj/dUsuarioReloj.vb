Public Class dUsuarioReloj
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_sexo As String
    Private m_ci As String
    Private m_tipousuario As Integer
    Private m_sector As Integer
    Private m_eliminado As Integer

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
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property SEXO() As String
        Get
            Return m_sexo
        End Get
        Set(ByVal value As String)
            m_sexo = value
        End Set
    End Property
    Public Property CI() As String
        Get
            Return m_ci
        End Get
        Set(ByVal value As String)
            m_ci = value
        End Set
    End Property
    Public Property TIPOUSUARIO() As Integer
        Get
            Return m_tipousuario
        End Get
        Set(ByVal value As Integer)
            m_tipousuario = value
        End Set
    End Property
    Public Property SECTOR() As Integer
        Get
            Return m_sector
        End Get
        Set(ByVal value As Integer)
            m_sector = value
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
        m_nombre = ""
        m_sexo = ""
        m_ci = ""
        m_tipousuario = 0
        m_sector = 0
        m_eliminado = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal sexo As String, ByVal ci As String, ByVal tipousuario As Integer, ByVal sector As Integer, ByVal eliminado As Integer)
        m_id = id
        m_nombre = nombre
        m_sexo = sexo
        m_ci = ci
        m_tipousuario = tipousuario
        m_sector = sector
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuarioreloj As dUsuarioReloj) As Boolean
        Dim p As New pUsuarioReloj
        Return p.guardar(Me)
    End Function
    Public Function modificar(ByVal usuarioreloj As dUsuarioReloj) As Boolean
        Dim p As New pUsuarioReloj
        Return p.modificar(Me)
    End Function
    Public Function eliminar(ByVal usuarioreloj As dUsuarioReloj) As Boolean
        Dim p As New pUsuarioReloj
        Return p.eliminar(Me)
    End Function
    Public Function buscar() As dUsuarioReloj
        Dim p As New pUsuarioReloj
        Return p.buscar(Me)
    End Function
    Public Function buscarPorNombre() As dUsuarioReloj
        Dim p As New pUsuarioReloj
        Return p.buscarPorNombre(Me)
    End Function
    Public Function buscarPorCI() As dUsuarioReloj
        Dim p As New pUsuarioReloj
        Return p.buscarPorCI(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pUsuarioReloj
        Return p.listar
    End Function
End Class
