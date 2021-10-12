Public Class dAmbiental
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechasolicitud As String
    Private m_fechaproceso As String
    Private m_idmuestra As String
    Private m_detallemuestra As String
    Private m_observaciones As String
    Private m_estadomuestra As String
    Private m_listeriaambiental As Integer
    Private m_listeriaambiental2 As String
    Private m_listeriamonocitogenes As Integer
    Private m_listeriaspp As Integer
    Private m_listeriaspp2 As String
    Private m_estafcoagpositivo As Integer
    Private m_estafcoagpositivo2 As String
    Private m_salmonella As Integer
    Private m_enterobacterias As Integer
    Private m_enterobacterias2 As String
    Private m_ecoli As Integer
    Private m_ecoli2 As String
    Private m_rb As String
    Private m_mohos As Integer
    Private m_mohos2 As String
    Private m_levaduras As Integer
    Private m_levaduras2 As String
    Private m_ct As Integer
    Private m_ct2 As String
    Private m_cf As Integer
    Private m_cf2 As String
    Private m_pseudomonaspp As Integer
    Private m_pseudomonaspp2 As String
    Private m_operador As Integer
    Private m_marca As Integer

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
    Public Property FECHASOLICITUD() As String
        Get
            Return m_fechasolicitud
        End Get
        Set(ByVal value As String)
            m_fechasolicitud = value
        End Set
    End Property
    Public Property FECHAPROCESO() As String
        Get
            Return m_fechaproceso
        End Get
        Set(ByVal value As String)
            m_fechaproceso = value
        End Set
    End Property
    Public Property IDMUESTRA() As String
        Get
            Return m_idmuestra
        End Get
        Set(ByVal value As String)
            m_idmuestra = value
        End Set
    End Property
    Public Property DETALLEMUESTRA() As String
        Get
            Return m_detallemuestra
        End Get
        Set(ByVal value As String)
            m_detallemuestra = value
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
    Public Property ESTADOMUESTRA() As String
        Get
            Return m_estadomuestra
        End Get
        Set(ByVal value As String)
            m_estadomuestra = value
        End Set
    End Property
    Public Property LISTERIAAMBIENTAL() As Integer
        Get
            Return m_listeriaambiental
        End Get
        Set(ByVal value As Integer)
            m_listeriaambiental = value
        End Set
    End Property
    Public Property LISTERIAAMBIENTAL2() As String
        Get
            Return m_listeriaambiental2
        End Get
        Set(ByVal value As String)
            m_listeriaambiental2 = value
        End Set
    End Property
    Public Property LISTERIAMONOCITOGENES() As Integer
        Get
            Return m_listeriamonocitogenes
        End Get
        Set(ByVal value As Integer)
            m_listeriamonocitogenes = value
        End Set
    End Property
    Public Property LISTERIASPP() As Integer
        Get
            Return m_listeriaspp
        End Get
        Set(ByVal value As Integer)
            m_listeriaspp = value
        End Set
    End Property
    Public Property LISTERIASPP2() As String
        Get
            Return m_listeriaspp2
        End Get
        Set(ByVal value As String)
            m_listeriaspp2 = value
        End Set
    End Property
    Public Property ESTAFCOAGPOSITIVO() As Integer
        Get
            Return m_estafcoagpositivo
        End Get
        Set(ByVal value As Integer)
            m_estafcoagpositivo = value
        End Set
    End Property
    Public Property ESTAFCOAGPOSITIVO2() As String
        Get
            Return m_estafcoagpositivo2
        End Get
        Set(ByVal value As String)
            m_estafcoagpositivo2 = value
        End Set
    End Property
    Public Property SALMONELLA() As Integer
        Get
            Return m_salmonella
        End Get
        Set(ByVal value As Integer)
            m_salmonella = value
        End Set
    End Property
    Public Property ENTEROBACTERIAS() As Integer
        Get
            Return m_enterobacterias
        End Get
        Set(ByVal value As Integer)
            m_enterobacterias = value
        End Set
    End Property
    Public Property ENTEROBACTERIAS2() As String
        Get
            Return m_enterobacterias2
        End Get
        Set(ByVal value As String)
            m_enterobacterias2 = value
        End Set
    End Property
    Public Property ECOLI() As Integer
        Get
            Return m_ecoli
        End Get
        Set(ByVal value As Integer)
            m_ecoli = value
        End Set
    End Property
    Public Property ECOLI2() As String
        Get
            Return m_ecoli2
        End Get
        Set(ByVal value As String)
            m_ecoli2 = value
        End Set
    End Property
    Public Property RB() As String
        Get
            Return m_rb
        End Get
        Set(ByVal value As String)
            m_rb = value
        End Set
    End Property

    Public Property MOHOS() As Integer
        Get
            Return m_mohos
        End Get
        Set(ByVal value As Integer)
            m_mohos = value
        End Set
    End Property
    Public Property MOHOS2() As String
        Get
            Return m_mohos2
        End Get
        Set(ByVal value As String)
            m_mohos2 = value
        End Set
    End Property
    Public Property LEVADURAS() As Integer
        Get
            Return m_levaduras
        End Get
        Set(ByVal value As Integer)
            m_levaduras = value
        End Set
    End Property
    Public Property LEVADURAS2() As String
        Get
            Return m_levaduras2
        End Get
        Set(ByVal value As String)
            m_levaduras2 = value
        End Set
    End Property
    Public Property CT() As Integer
        Get
            Return m_ct
        End Get
        Set(ByVal value As Integer)
            m_ct = value
        End Set
    End Property
    Public Property CT2() As String
        Get
            Return m_ct2
        End Get
        Set(ByVal value As String)
            m_ct2 = value
        End Set
    End Property
    Public Property CF() As Integer
        Get
            Return m_cf
        End Get
        Set(ByVal value As Integer)
            m_cf = value
        End Set
    End Property
    Public Property CF2() As String
        Get
            Return m_cf2
        End Get
        Set(ByVal value As String)
            m_cf2 = value
        End Set
    End Property
    Public Property PSEUDOMONASPP() As Integer
        Get
            Return m_pseudomonaspp
        End Get
        Set(ByVal value As Integer)
            m_pseudomonaspp = value
        End Set
    End Property
    Public Property PSEUDOMONASPP2() As String
        Get
            Return m_pseudomonaspp2
        End Get
        Set(ByVal value As String)
            m_pseudomonaspp2 = value
        End Set
    End Property
    Public Property OPERADOR() As Integer
        Get
            Return m_operador
        End Get
        Set(ByVal value As Integer)
            m_operador = value
        End Set
    End Property
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_fechasolicitud = ""
        m_fechaproceso = ""
        m_idmuestra = ""
        m_detallemuestra = ""
        m_observaciones = ""
        m_estadomuestra = ""
        m_listeriaambiental = 0
        m_listeriaambiental2 = ""
        m_listeriamonocitogenes = 0
        m_listeriaspp = 0
        m_listeriaspp2 = ""
        m_estafcoagpositivo = 0
        m_estafcoagpositivo2 = ""
        m_salmonella = 0
        m_enterobacterias = 0
        m_enterobacterias2 = ""
        m_ecoli = 0
        m_ecoli2 = ""
        m_rb = 0
        m_mohos = 0
        m_mohos2 = ""
        m_levaduras = 0
        m_levaduras2 = ""
        m_ct = 0
        m_ct2 = ""
        m_cf = 0
        m_cf2 = ""
        m_pseudomonaspp = 0
        m_pseudomonaspp2 = ""
        m_operador = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechasolicitud As String, ByVal fechaproceso As String, ByVal idmuestra As String, ByVal detallemuestra As String, ByVal observaciones As String, ByVal estadomuestra As String, ByVal listambiental As Integer, ByVal listambiental2 As String, ByVal listmono As Integer, ByVal listeriaspp As Integer, ByVal listeriaspp2 As String, ByVal estafcoagpositivo As Integer, ByVal estafcoagpositivo2 As String, ByVal salmonella As Integer, ByVal enterobacterias As Integer, ByVal enterobacterias2 As String, ByVal ecoli As Integer, ByVal ecoli2 As String, ByVal rb As String, ByVal mohos As Integer, ByVal mohos2 As String, ByVal levaduras As Integer, ByVal levaduras2 As String, ByVal ct As Integer, ByVal ct2 As String, ByVal cf As Integer, ByVal cf2 As String, ByVal pseudomonaspp As Integer, ByVal pseudomonaspp2 As String, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechasolicitud = fechasolicitud
        m_fechaproceso = fechaproceso
        m_idmuestra = idmuestra
        m_detallemuestra = detallemuestra
        m_observaciones = observaciones
        m_estadomuestra = estadomuestra
        m_listeriaambiental = listambiental
        m_listeriaambiental2 = listambiental2
        m_listeriamonocitogenes = listmono
        m_listeriaspp = listeriaspp
        m_listeriaspp2 = listeriaspp2
        m_estafcoagpositivo = estafcoagpositivo
        m_estafcoagpositivo2 = estafcoagpositivo2
        m_salmonella = salmonella
        m_enterobacterias = enterobacterias
        m_enterobacterias2 = enterobacterias2
        m_ecoli = ecoli
        m_ecoli2 = ecoli2
        m_rb = rb
        m_mohos = mohos
        m_mohos2 = mohos2
        m_levaduras = levaduras
        m_levaduras2 = levaduras2
        m_ct = ct
        m_ct2 = ct2
        m_cf = cf
        m_cf2 = cf2
        m_pseudomonaspp = pseudomonaspp
        m_pseudomonaspp2 = pseudomonaspp2
        m_operador = operador
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbiental
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbiental
        Return a.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbiental
        Return a.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbiental
        Return a.eliminar(Me, usuario)
    End Function
    Public Function eliminar2(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbiental
        Return a.eliminar2(Me, usuario)
    End Function
    Public Function buscar() As dAmbiental
        Dim a As New pAmbiental
        Return a.buscar(Me)
    End Function
    Public Function buscarxsolicitud() As dAmbiental
        Dim a As New pAmbiental
        Return a.buscarxsolicitud(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        'Return m_ficha
        Return m_ficha & Chr(9) & m_idmuestra
    End Function
    Public Function listar() As ArrayList
        Dim a As New pAmbiental
        Return a.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim a As New pAmbiental
        Return a.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a As New pAmbiental
        Return a.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a As New pAmbiental
        Return a.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a As New pAmbiental
        Return a.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a As New pAmbiental
        Return a.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
