Public Class dSubproducto
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechasolicitud As String
    Private m_fechaproceso As String
    Private m_estafcoagpositivo As Integer
    Private m_cf As Integer
    Private m_mohosylevaduras As Integer
    Private m_ct As Integer
    Private m_ecoli As Integer
    Private m_ecoli157 As Integer
    Private m_salmonella As Integer
    Private m_listeriaspp As Integer
    Private m_humedad As Integer
    Private m_mgrasa As Integer
    Private m_ph As Integer
    Private m_cloruros As Integer
    Private m_proteinas As Integer
    Private m_enterobacterias As Integer
    Private m_listeriaambiental As Integer
    Private m_esporanaermesofilo As Integer
    Private m_termofilos As Integer
    Private m_psicrotrofos As Integer
    Private m_rb As Integer
    Private m_tablanutricional As Integer
    Private m_listeriamonocitogenes As Integer
    Private m_cenizas As Integer
    Private m_salmonellapool As Integer
    Private m_listeriapool As Integer
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
    Public Property ESTAFCOAGPOSITIVO() As Integer
        Get
            Return m_estafcoagpositivo
        End Get
        Set(ByVal value As Integer)
            m_estafcoagpositivo = value
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
    Public Property MOHOSYLEVADURAS() As Integer
        Get
            Return m_mohosylevaduras
        End Get
        Set(ByVal value As Integer)
            m_mohosylevaduras = value
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
    Public Property ECOLI() As Integer
        Get
            Return m_ecoli
        End Get
        Set(ByVal value As Integer)
            m_ecoli = value
        End Set
    End Property
    Public Property ECOLI157() As Integer
        Get
            Return m_ecoli157
        End Get
        Set(ByVal value As Integer)
            m_ecoli157 = value
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
    Public Property LISTERIASPP() As Integer
        Get
            Return m_listeriaspp
        End Get
        Set(ByVal value As Integer)
            m_listeriaspp = value
        End Set
    End Property
    Public Property HUMEDAD() As Integer
        Get
            Return m_humedad
        End Get
        Set(ByVal value As Integer)
            m_humedad = value
        End Set
    End Property
    Public Property MGRASA() As Integer
        Get
            Return m_mgrasa
        End Get
        Set(ByVal value As Integer)
            m_mgrasa = value
        End Set
    End Property
    Public Property PH() As Integer
        Get
            Return m_ph
        End Get
        Set(ByVal value As Integer)
            m_ph = value
        End Set
    End Property
    Public Property CLORUROS() As Integer
        Get
            Return m_cloruros
        End Get
        Set(ByVal value As Integer)
            m_cloruros = value
        End Set
    End Property
    Public Property PROTEINAS() As Integer
        Get
            Return m_proteinas
        End Get
        Set(ByVal value As Integer)
            m_proteinas = value
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
    Public Property LISTERIAAMBIENTAL() As Integer
        Get
            Return m_listeriaambiental
        End Get
        Set(ByVal value As Integer)
            m_listeriaambiental = value
        End Set
    End Property
    Public Property ESPORANAERMESOFILO() As Integer
        Get
            Return m_esporanaermesofilo
        End Get
        Set(ByVal value As Integer)
            m_esporanaermesofilo = value
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
    Public Property RB() As Integer
        Get
            Return m_rb
        End Get
        Set(ByVal value As Integer)
            m_rb = value
        End Set
    End Property
    Public Property TABLANUTRICIONAL() As Integer
        Get
            Return m_tablanutricional
        End Get
        Set(ByVal value As Integer)
            m_tablanutricional = value
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
    Public Property CENIZAS() As Integer
        Get
            Return m_cenizas
        End Get
        Set(ByVal value As Integer)
            m_cenizas = value
        End Set
    End Property
    Public Property SALMONELLAPOOL() As Integer
        Get
            Return m_salmonellapool
        End Get
        Set(ByVal value As Integer)
            m_salmonellapool = value
        End Set
    End Property
    Public Property LISTERIAPOOL() As Integer
        Get
            Return m_listeriapool
        End Get
        Set(ByVal value As Integer)
            m_listeriapool = value
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
        m_estafcoagpositivo = 0
        m_cf = 0
        m_mohosylevaduras = 0
        m_ct = 0
        m_ecoli = 0
        m_ecoli157 = 0
        m_salmonella = 0
        m_listeriaspp = 0
        m_humedad = 0
        m_mgrasa = 0
        m_ph = 0
        m_cloruros = 0
        m_proteinas = 0
        m_enterobacterias = 0
        m_listeriaambiental = 0
        m_esporanaermesofilo = 0
        m_termofilos = 0
        m_psicrotrofos = 0
        m_rb = 0
        m_tablanutricional = 0
        m_listeriamonocitogenes = 0
        m_cenizas = 0
        m_salmonellapool = 0
        m_listeriapool = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechasolicitud As String, ByVal fechaproceso As String, ByVal estafcoagpositivo As Integer, ByVal cf As Integer, ByVal mohosylevaduras As Integer, ByVal ct As Integer, ByVal ecoli As Integer, ByVal ecoli157 As Integer, ByVal salmonella As Integer, ByVal listeriaspp As Integer, ByVal humedad As Integer, ByVal mgrasa As Integer, ByVal ph As Integer, ByVal cloruros As Integer, ByVal proteinas As Integer, ByVal enterobacterias As Integer, ByVal listeriaambiental As Integer, ByVal esporanaermesofilo As Integer, ByVal termofilos As Integer, ByVal psicrotrofos As Integer, ByVal rb As Integer, ByVal tablanutricional As Integer, ByVal listeriamonocitogenes As Integer, ByVal cenizas As Integer, ByVal salmonellapool As Integer, ByVal listeriapool As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechasolicitud = fechasolicitud
        m_fechaproceso = fechaproceso
        m_estafcoagpositivo = estafcoagpositivo
        m_cf = cf
        m_mohosylevaduras = mohosylevaduras
        m_ct = ct
        m_ecoli = ecoli
        m_ecoli157 = ecoli157
        m_salmonella = salmonella
        m_listeriaspp = listeriaspp
        m_humedad = humedad
        m_mgrasa = mgrasa
        m_ph = ph
        m_cloruros = cloruros
        m_proteinas = proteinas
        m_enterobacterias = enterobacterias
        m_listeriaambiental = listeriaambiental
        m_esporanaermesofilo = esporanaermesofilo
        m_termofilos = termofilos
        m_psicrotrofos = psicrotrofos
        m_rb = rb
        m_tablanutricional = tablanutricional
        m_listeriamonocitogenes = listeriamonocitogenes
        m_cenizas = cenizas
        m_salmonellapool = salmonellapool
        m_listeriapool = listeriapool
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSubproducto
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSubproducto
        Return s.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSubproducto
        Return s.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSubproducto
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSubproducto
        Dim s As New pSubproducto
        Return s.buscar(Me)
    End Function
    Public Function buscarxsolicitud() As dSubproducto
        Dim s As New pSubproducto
        Return s.buscarxsolicitud(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim s As New pSubproducto
        Return s.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim s As New pSubproducto
        Return s.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim s As New pSubproducto
        Return s.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim s As New pSubproducto
        Return s.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim s As New pSubproducto
        Return s.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSubproducto
        Return s.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
