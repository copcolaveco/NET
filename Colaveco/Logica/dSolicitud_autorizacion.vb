Public Class dSolicitud_Autorizacion
    Private m_solicitud_autorizacion_id As Long
    Private m_solicitudanalisis_id As Long
    Private m_usuario_autoriza_id As Long
    Private m_observaciones As String
    Private m_fecha As String


    ' Constructor por defecto
    Public Sub New()
    End Sub

    ' Constructor completo
    Public Sub New(ByVal id As Long, ByVal solicitudid As Long, ByVal usuarioid As Long, ByVal observaciones As String, ByVal fecha As String)
        m_solicitud_autorizacion_id = id
        m_solicitudanalisis_id = solicitudid
        m_usuario_autoriza_id = usuarioid
        m_observaciones = observaciones
        m_fecha = fecha
    End Sub

    ' Getters y Setters
    Public Property SOLICITUD_AUTORIZACION_ID() As Long
        Get
            Return m_solicitud_autorizacion_id
        End Get
        Set(ByVal value As Long)
            m_solicitud_autorizacion_id = value
        End Set
    End Property

    Public Property SOLICITUDANALISIS_ID() As Long
        Get
            Return m_solicitudanalisis_id
        End Get
        Set(ByVal value As Long)
            m_solicitudanalisis_id = value
        End Set
    End Property

    Public Property USUARIO_AUTORIZA_ID() As Long
        Get
            Return m_usuario_autoriza_id
        End Get
        Set(ByVal value As Long)
            m_usuario_autoriza_id = value
        End Set
    End Property

    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property

    ' ToString opcional (para mostrar en grids o debug)
    Public Overrides Function ToString() As String
        Return "Autorización #" & m_solicitud_autorizacion_id.ToString()
    End Function

    ' Equals opcional (para comparar objetos)
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not obj Is Nothing AndAlso TypeOf obj Is dSolicitud_Autorizacion Then
            Dim a As dSolicitud_Autorizacion = CType(obj, dSolicitud_Autorizacion)
            If Me.SOLICITUD_AUTORIZACION_ID = a.SOLICITUD_AUTORIZACION_ID Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function Insertar() As Boolean
        Dim solicitud_autorizacion As New pSolicitud_autorizacion
        Return solicitud_autorizacion.guardar(Me)
    End Function

    Public Function listarPorFiltros(fechaDesde As String, fechaHasta As String, Optional solicitudId As Long = 0) As ArrayList
        Dim p As New pSolicitud_Autorizacion
        Return p.listarPorFiltros(fechaDesde, fechaHasta, solicitudId)
    End Function

    Public Function listarPorSolicitud(solicitudId As Long) As dSolicitud_Autorizacion
        Dim p As New pSolicitud_autorizacion
        Return p.listarPorId(solicitudId)
    End Function

End Class

