Public Class dMeta
#Region "Atributos"
    Private m_id As Integer
    Private m_analisis As Integer
    Private m_meta As String
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
    Public Property META() As String
        Get
            Return m_meta
        End Get
        Set(ByVal value As String)
            m_meta = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_analisis = 0
        m_meta = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal analisis As Integer, ByVal meta As String)
        m_id = id
        m_analisis = analisis
        m_meta = meta
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMeta
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMeta
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMeta
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMeta
        Dim p As New pMeta
        Return p.buscar(Me)
    End Function
#End Region
    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pMeta
        Return p.listar
    End Function
End Class
