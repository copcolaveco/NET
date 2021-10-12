Public Class dLocalidad
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_iddepartamento As Integer
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
    Public Property IDDEPARTAMENTO() As Integer
        Get
            Return m_iddepartamento
        End Get
        Set(ByVal value As Integer)
            m_iddepartamento = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_iddepartamento = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal iddepartamento As Integer)
        m_id = id
        m_nombre = nombre
        m_iddepartamento = iddepartamento
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLocalidad
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLocalidad
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLocalidad
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dLocalidad
        Dim p As New pLocalidad
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pLocalidad
        Return p.listar
    End Function
    Public Function listarpordepartamento(ByVal texto As Integer) As ArrayList
        Dim s As New pLocalidad
        Return s.listarpordepartamento(texto)
    End Function
End Class
