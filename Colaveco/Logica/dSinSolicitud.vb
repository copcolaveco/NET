Public Class dSinSolicitud
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
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
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
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
        m_ficha = 0
        m_detalle = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal detalle As String)
        m_id = id
        m_ficha = ficha
        m_detalle = detalle
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSinSolicitud
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSinSolicitud
        Return s.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSinSolicitud
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSinSolicitud
        Dim s As New pSinSolicitud
        Return s.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim s As New pSinSolicitud
        Return s.listar
    End Function
End Class
