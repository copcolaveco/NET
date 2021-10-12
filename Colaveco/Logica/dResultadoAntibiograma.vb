Public Class dResultadoAntibiograma
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_sigla As String
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
    Public Property SIGLA() As String
        Get
            Return m_sigla
        End Get
        Set(ByVal value As String)
            m_sigla = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_sigla = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal sigla As String)
        m_id = id
        m_nombre = nombre
        m_sigla = sigla
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pResultadoAntibiograma
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pResultadoAntibiograma
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pResultadoAntibiograma
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dResultadoAntibiograma
        Dim p As New pResultadoAntibiograma
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_sigla
    End Function

    Public Function listar() As ArrayList
        Dim p As New pResultadoAntibiograma
        Return p.listar
    End Function
    Public Function listarDS() As DataSet
        Dim p As New pResultadoAntibiograma
        Return p.listarDS
    End Function
End Class
