Public Class dReferencias
#Region "Atributos"
    Private m_id As Integer
    Private m_analisis As Integer
    Private m_referencia1 As String
    Private m_referencia2 As String
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
    Public Property REFERENCIA1() As String
        Get
            Return m_referencia1
        End Get
        Set(ByVal value As String)
            m_referencia1 = value
        End Set
    End Property
    Public Property REFERENCIA2() As String
        Get
            Return m_referencia2
        End Get
        Set(ByVal value As String)
            m_referencia2 = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_analisis = 0
        m_referencia1 = ""
        m_referencia2 = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal analisis As Integer, ByVal referencia1 As String, ByVal referencia2 As String)
        m_id = id
        m_analisis = analisis
        m_referencia1 = referencia1
        m_referencia2 = referencia2
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pReferencias
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pReferencias
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pReferencias
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dReferencias
        Dim p As New pReferencias
        Return p.buscar(Me)
    End Function
#End Region
    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pReferencias
        Return p.listar
    End Function
End Class
