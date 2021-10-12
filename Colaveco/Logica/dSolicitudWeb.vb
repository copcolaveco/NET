Public Class dSolicitudWeb
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_gestor As Integer
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
    Public Property GESTOR() As Integer
        Get
            Return m_gestor
        End Get
        Set(ByVal value As Integer)
            m_gestor = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_gestor = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal gestor As Integer)
        m_id = id
        m_ficha = ficha
        m_gestor = gestor
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudWeb
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudWeb
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudWeb
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSolicitudWeb
        Dim p As New pSolicitudWeb
        Return p.buscar(Me)
    End Function
    Public Function marcarcargado() As Boolean
        Dim p As New pSolicitudWeb
        Return p.marcarcargado(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pSolicitudWeb
        Return p.listar
    End Function
    Public Function listarsincargar() As ArrayList
        Dim p As New pSolicitudWeb
        Return p.listarsincargar
    End Function
End Class
