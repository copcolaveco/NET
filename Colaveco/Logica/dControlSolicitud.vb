Public Class dControlSolicitud
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_rc As Integer
    Private m_composicion As Integer
    Private m_urea As Integer
    Private m_caseina As Integer
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
    Public Property RC() As Integer
        Get
            Return m_rc
        End Get
        Set(ByVal value As Integer)
            m_rc = value
        End Set
    End Property
    Public Property COMPOSICION() As Integer
        Get
            Return m_composicion
        End Get
        Set(ByVal value As Integer)
            m_composicion = value
        End Set
    End Property
  
    Public Property UREA() As Integer
        Get
            Return m_urea
        End Get
        Set(ByVal value As Integer)
            m_urea = value
        End Set
    End Property
    Public Property CASEINA() As Integer
        Get
            Return m_caseina
        End Get
        Set(ByVal value As Integer)
            m_caseina = value
        End Set
    End Property
   

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_rc = 0
        m_composicion = 0
        m_urea = 0
        m_caseina = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal rc As Integer, ByVal composicion As Integer, ByVal urea As Integer, ByVal caseina As Integer)
        m_id = id
        m_ficha = ficha
        m_rc = rc
        m_composicion = composicion
        m_urea = urea
        m_caseina = caseina
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlSolicitud
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlSolicitud
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlSolicitud
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dControlSolicitud
        Dim c As New pControlSolicitud
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pControlSolicitud
        Return c.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim c As New pControlSolicitud
        Return c.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pControlSolicitud
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pControlSolicitud
        Return c.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim c As New pControlSolicitud
        Return c.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim c As New pControlSolicitud
        Return c.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
