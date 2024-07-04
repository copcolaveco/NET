Public Class dClient
#Region "Atributos"
    Private m_clicod As Long ' código del cliente
    Private m_clisct As Long ' código del cliente a facturar
#End Region

#Region "Getters y Setters"
    Public Property CLICOD() As Long
        Get
            Return m_clicod
        End Get
        Set(ByVal value As Long)
            m_clicod = value
        End Set
    End Property
  
    Public Property CLISCT() As Long
        Get
            Return m_clisct
        End Get
        Set(ByVal value As Long)
            m_clisct = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_clicod = 0
        m_clisct = 0
      
    End Sub
    Public Sub New(ByVal clicod As Long, ByVal clisct As Long)
        m_clicod = clicod
        m_clisct = clisct
    End Sub
#End Region
    Public Function buscarxcli() As dClient
        Dim p As New pClient
        Return p.buscarxcli(Me)
    End Function
 
End Class
