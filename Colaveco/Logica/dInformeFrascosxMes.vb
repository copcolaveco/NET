Public Class dInformeFrascosxMes
#Region "Atributos"
    Private m_año As String
    Private m_mes As String
    Private m_totalrc As Long
    Private m_totalagua As Long
    Private m_totalsangre As Long
    Private m_totalesteriles As Long
    Private m_totalotros As Long
    
#End Region

#Region "Getters y Setters"
    Public Property AÑO() As String
        Get
            Return m_año
        End Get
        Set(ByVal value As String)
            m_año = value
        End Set
    End Property
    Public Property MES() As String
        Get
            Return m_mes
        End Get
        Set(ByVal value As String)
            m_mes = value
        End Set
    End Property
    Public Property TOTALRC() As Long
        Get
            Return m_totalrc
        End Get
        Set(ByVal value As Long)
            m_totalrc = value
        End Set
    End Property
    Public Property TOTALAGUA() As Long
        Get
            Return m_totalagua
        End Get
        Set(ByVal value As Long)
            m_totalagua = value
        End Set
    End Property
    Public Property TOTALSANGRE() As Long
        Get
            Return m_totalsangre
        End Get
        Set(ByVal value As Long)
            m_totalsangre = value
        End Set
    End Property
    Public Property TOTALESTERILES() As Long
        Get
            Return m_totalesteriles
        End Get
        Set(ByVal value As Long)
            m_totalesteriles = value
        End Set
    End Property
    Public Property TOTALOTROS() As Long
        Get
            Return m_totalotros
        End Get
        Set(ByVal value As Long)
            m_totalotros = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_año = ""
        m_mes = ""
        m_totalrc = 0
        m_totalagua = 0
        m_totalsangre = 0
        m_totalesteriles = 0
        m_totalotros = 0
    End Sub
    Public Sub New(ByVal año As String, ByVal mes As String, ByVal totalrc As Long, ByVal totalagua As Long, ByVal totalsangre As Long, ByVal totalesteriles As Long, ByVal totalotros As Long)
        m_año = año
        m_mes = mes
        m_totalrc = totalrc
        m_totalagua = totalagua
        m_totalsangre = totalsangre
        m_totalesteriles = totalesteriles
        m_totalotros = totalotros
    End Sub
    
#End Region
End Class
