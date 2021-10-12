Public Class dCalidadSolicitud
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_rb As Integer
    Private m_rc As Integer
    Private m_composicion As Integer
    Private m_crioscopia As Integer
    Private m_inhibidores As Integer
    Private m_esporulados As Integer
    Private m_urea As Integer
    Private m_termofilos As Integer
    Private m_psicrotrofos As Integer
    Private m_crioscopia_crioscopo As Integer
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
    Public Property RB() As Integer
        Get
            Return m_rb
        End Get
        Set(ByVal value As Integer)
            m_rb = value
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
    Public Property CRIOSCOPIA() As Integer
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Integer)
            m_crioscopia = value
        End Set
    End Property
    Public Property INHIBIDORES() As Integer
        Get
            Return m_inhibidores
        End Get
        Set(ByVal value As Integer)
            m_inhibidores = value
        End Set
    End Property
    Public Property ESPORULADOS() As Integer
        Get
            Return m_esporulados
        End Get
        Set(ByVal value As Integer)
            m_esporulados = value
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
    Public Property TERMOFILOS() As Integer
        Get
            Return m_termofilos
        End Get
        Set(ByVal value As Integer)
            m_termofilos = value
        End Set
    End Property
    Public Property PSICROTROFOS() As Integer
        Get
            Return m_psicrotrofos
        End Get
        Set(ByVal value As Integer)
            m_psicrotrofos = value
        End Set
    End Property
    Public Property CRIOSCOPIA_CRIOSCOPO() As Integer
        Get
            Return m_crioscopia_crioscopo
        End Get
        Set(ByVal value As Integer)
            m_crioscopia_crioscopo = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_rb = 0
        m_rc = 0
        m_composicion = 0
        m_crioscopia = 0
        m_inhibidores = 0
        m_esporulados = 0
        m_urea = 0
        m_termofilos = 0
        m_psicrotrofos = 0
        m_crioscopia_crioscopo = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal rb As Integer, _
                   ByVal rc As Integer, ByVal composicion As Integer, _
                   ByVal crioscopia As Integer, ByVal inhibidores As Integer, ByVal esporulados As Integer, _
                   ByVal urea As Integer, ByVal termofilos As Integer, ByVal psicrotrofos As Integer, _
                   ByVal crioscopia_crioscopo As Integer)
        m_id = id
        m_ficha = FICHA
        m_rb = rb
        m_rc = rc
        m_composicion = composicion
        m_crioscopia = crioscopia
        m_inhibidores = inhibidores
        m_esporulados = esporulados
        m_urea = urea
        m_termofilos = termofilos
        m_psicrotrofos = psicrotrofos
        m_crioscopia_crioscopo = crioscopia_crioscopo
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitud
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitud
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitud
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCalidadSolicitud
        Dim c As New pCalidadSolicitud
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pCalidadSolicitud
        Return c.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim c As New pCalidadSolicitud
        Return c.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitud
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitud
        Return c.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitud
        Return c.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim c As New pCalidadSolicitud
        Return c.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
