Public Class dNotificaciones_reloj
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_idusuario As Integer
    Private m_fechaevento As String
    Private m_detalle As String
#End Region

#Region "Getters y Setters"
    Public Property ID() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
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
    Public Property IDUSUARIO() As Integer
        Get
            Return m_idusuario
        End Get
        Set(ByVal value As Integer)
            m_idusuario = value
        End Set
    End Property
    Public Property FECHAEVENTO() As String
        Get
            Return m_fechaevento
        End Get
        Set(ByVal value As String)
            m_fechaevento = value
        End Set
    End Property
    Public Property DETALLE() As String
        Get
            Return m_detalle
        End Get
        Set(ByVal value As String)
            m_detalle = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_idusuario = 0
        m_fechaevento = ""
        m_detalle = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal idusuario As Integer, ByVal fechaevento As String, ByVal detalle As String)
        m_id = id
        m_fecha = fecha
        m_idusuario = idusuario
        m_fechaevento = fechaevento
        m_detalle = detalle
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNotificaciones_reloj
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNotificaciones_reloj
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNotificaciones_reloj
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNotificaciones_reloj
        Dim p As New pNotificaciones_reloj
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idusuario
    End Function

    Public Function listar() As ArrayList
        Dim p As New pNotificaciones_reloj
        Return p.listar
    End Function
    Public Function listarsemana(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pNotificaciones_reloj
        Return p.listarsemana(desde, hasta)
    End Function
End Class
