Public Class dCalidadSolicitudMuestra
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_rb As Integer
    Private m_rc As Integer
    Private m_composicion As Integer
    Private m_composicionsuero As Integer
    Private m_crioscopia As Integer
    Private m_inhibidores As Integer
    Private m_charm As Integer
    Private m_esporulados As Integer
    Private m_urea As Integer
    Private m_termofilos As Integer
    Private m_psicrotrofos As Integer
    Private m_crioscopia_crioscopo As Integer
    Private m_caseina As Integer
    Private m_aflatoxina As Integer
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
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
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
    Public Property COMPOSICIONSUERO() As Integer
        Get
            Return m_composicionsuero
        End Get
        Set(ByVal value As Integer)
            m_composicionsuero = value
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
    Public Property CHARM() As Integer
        Get
            Return m_charm
        End Get
        Set(ByVal value As Integer)
            m_charm = value
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
    Public Property CASEINA() As Integer
        Get
            Return m_caseina
        End Get
        Set(ByVal value As Integer)
            m_caseina = value
        End Set
    End Property
    Public Property AFLATOXINA() As Integer
        Get
            Return m_aflatoxina
        End Get
        Set(ByVal value As Integer)
            m_aflatoxina = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_muestra = ""
        m_rb = 0
        m_rc = 0
        m_composicion = 0
        m_composicionsuero = 0
        m_crioscopia = 0
        m_inhibidores = 0
        m_charm = 0
        m_esporulados = 0
        m_urea = 0
        m_termofilos = 0
        m_psicrotrofos = 0
        m_crioscopia_crioscopo = 0
        m_caseina = 0
        m_aflatoxina = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal rb As Integer, ByVal muestra As String, ByVal rc As Integer, ByVal composicion As Integer, ByVal composicionsuero As Integer, ByVal crioscopia As Integer, ByVal inhibidores As Integer, ByVal charm As Integer, ByVal esporulados As Integer, ByVal urea As Integer, ByVal termofilos As Integer, ByVal psicrotrofos As Integer, ByVal crioscopia_crioscopo As Integer, ByVal caseina As Integer, ByVal aflatoxina As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_rb = rb
        m_rc = rc
        m_composicion = composicion
        m_composicionsuero = composicionsuero
        m_crioscopia = crioscopia
        m_inhibidores = inhibidores
        m_charm = charm
        m_esporulados = esporulados
        m_urea = urea
        m_termofilos = termofilos
        m_psicrotrofos = psicrotrofos
        m_crioscopia_crioscopo = crioscopia_crioscopo
        m_caseina = caseina
        m_aflatoxina = aflatoxina
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitudMuestra
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitudMuestra
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitudMuestra
        Return c.eliminar(Me, usuario)
    End Function
    Public Function eliminar2(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitudMuestra
        Return c.eliminar2(Me, usuario)
    End Function
    Public Function eliminarxmuestra(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadSolicitudMuestra
        Return c.eliminarxmuestra(Me, usuario)
    End Function
 
    Public Function buscar() As dCalidadSolicitudMuestra
        Dim c As New pCalidadSolicitudMuestra
        Return c.buscar(Me)
    End Function
    Public Function buscarxsolicitud() As dCalidadSolicitudMuestra
        Dim c As New pCalidadSolicitudMuestra
        Return c.buscarxsolicitud(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarporid(texto)
    End Function
    Public Function controlarmuestras(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.controlarmuestras(ficha, muestra)
    End Function
    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarporsolicitud2(texto)
    End Function
    Public Function listarporsolicitud3(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarporsolicitud3(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarporfecha(fechadesde, fechahasta)
    End Function
    Public Function listarrb(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarrb(texto)
    End Function
    Public Function listarrc(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarrc(texto)
    End Function
    Public Function listarcomposicion(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarcomposicion(texto)
    End Function
    Public Function listarcrioscopia(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarcrioscopia(texto)
    End Function
    Public Function listarinhibidores(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarinhibidores(texto)
    End Function
    Public Function listarcharm(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarcharm(texto)
    End Function
    Public Function listaresporulados(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listaresporulados(texto)
    End Function
    Public Function listarurea(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarurea(texto)
    End Function
    Public Function listartermofilos(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listartermofilos(texto)
    End Function
    Public Function listarpsicrotrofos(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarpsicrotrofos(texto)
    End Function
    Public Function listarcrioscopia_crioscopo(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarcrioscopia_crioscopo(texto)
    End Function
    Public Function listarrb_rc(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarrb_rc(texto)
    End Function
    Public Function listarrb_rc_composicion(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listarrb_rc_composicion(texto)
    End Function
    Public Function listar_caseina(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listar_caseina(texto)
    End Function
    Public Function listar_aflatoxina(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listar_aflatoxina(texto)
    End Function
    Public Function listar_composicionsuero(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadSolicitudMuestra
        Return c.listar_composicionsuero(texto)
    End Function
End Class
