Public Class dInformeFrascosRotos
#Region "Atributos"
    Private m_año As String
    Private m_mes As String
    Private m_total As Long
    

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
    Public Property TOTAL() As Long
        Get
            Return m_total
        End Get
        Set(ByVal value As Long)
            m_total = value
        End Set
    End Property
    
#End Region

#Region "Constructores"
    Public Sub New()
        m_año = ""
        m_mes = ""
        m_total = 0
    End Sub
    Public Sub New(ByVal año As String, ByVal mes As String, ByVal total As Long)
        m_año = año
        m_mes = mes
        m_total = total
    End Sub

#End Region
End Class
