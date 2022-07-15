Public Class dSolicitudanalisis_TecMuestreo

#Region "Atributos"
    Private m_id_solicitudanalisis_tecmuestreo As Long
    Private m_id_solicitudanalisis As Long
    Private m_id_tecnicomuestreo As Long
#End Region

    Public Property ID_SOLICITUDANALISIS_TECMUESTREO() As Long
        Get
            Return m_id_solicitudanalisis_tecmuestreo
        End Get
        Set(ByVal value As Long)
            m_id_solicitudanalisis_tecmuestreo = value
        End Set
    End Property

    Public Property ID_SOLICITUDANALISIS() As Long
        Get
            Return m_id_solicitudanalisis
        End Get
        Set(ByVal value As Long)
            m_id_solicitudanalisis = value
        End Set
    End Property

    Public Property ID_TECNICOMUESTREO() As Long
        Get
            Return m_id_tecnicomuestreo
        End Get
        Set(ByVal value As Long)
            m_id_tecnicomuestreo = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New()
        m_id_solicitudanalisis_tecmuestreo = 0
        m_id_solicitudanalisis = 0
        m_id_tecnicomuestreo = 0
    End Sub

    Public Sub New(ByVal id_solicitudanalisis_tecmuestreo As Long, ByVal id_solicitudanalisis As Long, ByVal id_tecnicomuestreo As Long)
        m_id_solicitudanalisis_tecmuestreo = id_solicitudanalisis_tecmuestreo
        m_id_solicitudanalisis = id_solicitudanalisis
        m_id_tecnicomuestreo = id_tecnicomuestreo
    End Sub

#End Region

    Public Function guardar() As Boolean
        Dim p As New pSolicitudanalisisTecnicoMuestreo
        Return p.guardar(Me)
    End Function

End Class
