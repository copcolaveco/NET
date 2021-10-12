Public Class dAnalisisUnidad
#Region "Atributos"
    Private m_id As Integer
    Private m_analisis As Integer
    Private m_unidad As String
    Private m_pordefecto As Integer
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
    Public Property ANALISIS() As Integer
        Get
            Return m_analisis
        End Get
        Set(ByVal value As Integer)
            m_analisis = value
        End Set
    End Property
    Public Property UNIDAD() As String
        Get
            Return m_unidad
        End Get
        Set(ByVal value As String)
            m_unidad = value
        End Set
    End Property
    Public Property PORDEFECTO() As Integer
        Get
            Return m_pordefecto
        End Get
        Set(ByVal value As Integer)
            m_pordefecto = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_analisis = 0
        m_unidad = ""
        m_pordefecto = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal analisis As Integer, ByVal unidad As String, ByVal pordefecto As Integer)
        m_id = id
        m_analisis = analisis
        m_unidad = unidad
        m_pordefecto = pordefecto
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisUnidad
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisUnidad
        Return p.modificar(Me, usuario)
    End Function
    Public Function desmarcarxdefecto(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisUnidad
        Return p.desmarcarxdefecto(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisUnidad
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAnalisisUnidad
        Dim p As New pAnalisisUnidad
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_unidad & " - " & m_pordefecto
    End Function

    Public Function listar() As ArrayList
        Dim p As New pAnalisisUnidad
        Return p.listar
    End Function
    Public Function listarxanalisis(ByVal idanalisis As Integer) As ArrayList
        Dim p As New pAnalisisUnidad
        Return p.listarxanalisis(idanalisis)
    End Function
End Class
