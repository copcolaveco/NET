Public Class dAnalisis
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_simbolomoneda As String
    Private m_costo As Double
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
    Public Property SIMBOLOMONEDA() As String
        Get
            Return m_simbolomoneda
        End Get
        Set(ByVal value As String)
            m_simbolomoneda = value
        End Set
    End Property
    Public Property COSTO() As Double
        Get
            Return m_costo
        End Get
        Set(ByVal value As Double)
            m_costo = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_simbolomoneda = ""
        m_costo = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal simbolomoneda As String, ByVal costo As Double)
        m_id = id
        m_nombre = nombre
        m_simbolomoneda = simbolomoneda
        m_costo = costo
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisis
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisis
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisis
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAnalisis
        Dim p As New pAnalisis
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pAnalisis
        Return p.listar
    End Function
End Class
