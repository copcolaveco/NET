Public Class dSolicitudPAL
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_matricula As String
    Private m_vacas As Integer
    Private m_fechaext As String
    
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
    Public Property MATRICULA() As String
        Get
            Return m_matricula
        End Get
        Set(ByVal value As String)
            m_matricula = value
        End Set
    End Property
    Public Property VACAS() As Integer
        Get
            Return m_vacas
        End Get
        Set(ByVal value As Integer)
            m_vacas = value
        End Set
    End Property
    Public Property FECHAEXT() As String
        Get
            Return m_fechaext
        End Get
        Set(ByVal value As String)
            m_fechaext = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_matricula = ""
        m_vacas = 0
        m_fechaext = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal matricula As String, ByVal vacas As Integer, ByVal fechaext As String)
        m_id = id
        m_ficha = ficha
        m_matricula = matricula
        m_vacas = vacas
        m_fechaext = fechaext

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudPAL
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudPAL
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudPAL
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSolicitudPAL
        Dim p As New pSolicitudPAL
        Return p.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_matricula
    End Function
    Public Function listar() As ArrayList
        Dim p As New pSolicitudPAL
        Return p.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim p As New pSolicitudPAL
        Return p.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim p As New pSolicitudPAL
        Return p.listarporid(texto)
    End Function
    Public Function controlarmuestras(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim p As New pSolicitudPAL
        Return p.controlarmuestras(ficha, muestra)
    End Function
    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim p As New pSolicitudPAL
        Return p.listarporsolicitud(texto)
    End Function

End Class
