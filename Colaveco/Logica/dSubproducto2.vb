Public Class dSubproducto2
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechasolicitud As String
    Private m_fechaproceso As String
    Private m_idmuestra As String
    Private m_detallemuestra As String
    Private m_observaciones As String
    Private m_estadomuestra As String
    Private m_estafcoagpositivo As String
    Private m_estafcoagpositivo_met As Integer
    Private m_cf As String
    Private m_cf_met As Integer
    Private m_mohos As String
    Private m_mohos_met As Integer
    Private m_levaduras As String
    Private m_levaduras_met As Integer
    Private m_ct As String
    Private m_ct_met As Integer
    Private m_ecoli As String
    Private m_ecoli_met As Integer
    Private m_ecoli157 As String
    Private m_ecoli157_met As Integer
    Private m_salmonella As Integer
    Private m_salmonella_met As Integer
    Private m_listeriaspp As Integer
    Private m_listeriaspp_met As Integer
    Private m_humedad As Double
    Private m_humedad_met As Integer
    Private m_mgrasa As Double
    Private m_mgrasa_met As Integer
    Private m_ph As Double
    Private m_ph_met As Integer
    Private m_cloruros As Double
    Private m_cloruros_met As Integer
    Private m_proteinas As Double
    Private m_proteinas_met As Integer
    Private m_enterobacterias As String
    Private m_enterobacterias_met As Integer
    Private m_listeriaambiental As Integer
    Private m_listeriaambiental2 As Double
    Private m_listeriaambiental_met As Integer
    Private m_esporanaermesofilo As Double
    Private m_esporanaermesofilo_met As Integer
    Private m_termofilos As String
    Private m_termofilos_met As Integer
    Private m_psicrotrofos As String
    Private m_psicrotrofos_met As Integer
    Private m_rb As String
    Private m_rb_met As Integer
    Private m_tablanutricional As Integer
    Private m_tnproteina As Double
    Private m_tncarbohidratos As Double
    Private m_tngrasastotales As Double
    Private m_tngrasassaturadas As Double
    Private m_tngrasastrans As Double
    Private m_listeriamonocitogenes As Integer
    Private m_listeriamonocitogenes_met As Integer
    Private m_cenizas As Double
    Private m_cenizas_met As Integer
    Private m_tnsodio As Double
    Private m_tnfibraalimenticia As Double
    Private m_codigoanalitico As String
    Private m_tipomuestra As Integer
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
    Public Property ESTAFCOAGPOSITIVO() As String
        Get
            Return m_estafcoagpositivo
        End Get
        Set(ByVal value As String)
            m_estafcoagpositivo = value
        End Set
    End Property
    Public Property ESTAFCOAGPOSITIVO_MET() As Integer
        Get
            Return m_estafcoagpositivo_met
        End Get
        Set(ByVal value As Integer)
            m_estafcoagpositivo_met = value
        End Set
    End Property
    Public Property CF() As String
        Get
            Return m_cf
        End Get
        Set(ByVal value As String)
            m_cf = value
        End Set
    End Property
    Public Property CF_MET() As Integer
        Get
            Return m_cf_met
        End Get
        Set(ByVal value As Integer)
            m_cf_met = value
        End Set
    End Property
    Public Property MOHOS() As String
        Get
            Return m_mohos
        End Get
        Set(ByVal value As String)
            m_mohos = value
        End Set
    End Property
    Public Property MOHOS_MET() As Integer
        Get
            Return m_mohos_met
        End Get
        Set(ByVal value As Integer)
            m_mohos_met = value
        End Set
    End Property
    Public Property LEVADURAS() As String
        Get
            Return m_levaduras
        End Get
        Set(ByVal value As String)
            m_levaduras = value
        End Set
    End Property
    Public Property LEVADURAS_MET() As Integer
        Get
            Return m_levaduras_met
        End Get
        Set(ByVal value As Integer)
            m_levaduras_met = value
        End Set
    End Property
    Public Property CT() As String
        Get
            Return m_ct
        End Get
        Set(ByVal value As String)
            m_ct = value
        End Set
    End Property
    Public Property CT_MET() As Integer
        Get
            Return m_ct_met
        End Get
        Set(ByVal value As Integer)
            m_ct_met = value
        End Set
    End Property
    Public Property ECOLI() As String
        Get
            Return m_ecoli
        End Get
        Set(ByVal value As String)
            m_ecoli = value
        End Set
    End Property
    Public Property ECOLI_MET() As Integer
        Get
            Return m_ecoli_met
        End Get
        Set(ByVal value As Integer)
            m_ecoli_met = value
        End Set
    End Property
    Public Property ECOLI157() As String
        Get
            Return m_ecoli157
        End Get
        Set(ByVal value As String)
            m_ecoli157 = value
        End Set
    End Property
    Public Property ECOLI157_MET() As Integer
        Get
            Return m_ecoli157_met
        End Get
        Set(ByVal value As Integer)
            m_ecoli157_met = value
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
    Public Property SALMONELLA_MET() As Integer
        Get
            Return m_salmonella_met
        End Get
        Set(ByVal value As Integer)
            m_salmonella_met = value
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
    Public Property LISTERIASPP_MET() As Integer
        Get
            Return m_listeriaspp_met
        End Get
        Set(ByVal value As Integer)
            m_listeriaspp_met = value
        End Set
    End Property
    Public Property HUMEDAD() As Double
        Get
            Return m_humedad
        End Get
        Set(ByVal value As Double)
            m_humedad = value
        End Set
    End Property
    Public Property HUMEDAD_MET() As Integer
        Get
            Return m_humedad_met
        End Get
        Set(ByVal value As Integer)
            m_humedad_met = value
        End Set
    End Property
    Public Property MGRASA() As Double
        Get
            Return m_mgrasa
        End Get
        Set(ByVal value As Double)
            m_mgrasa = value
        End Set
    End Property
    Public Property MGRASA_MET() As Integer
        Get
            Return m_mgrasa_met
        End Get
        Set(ByVal value As Integer)
            m_mgrasa_met = value
        End Set
    End Property
    Public Property PH() As Double
        Get
            Return m_ph
        End Get
        Set(ByVal value As Double)
            m_ph = value
        End Set
    End Property
    Public Property PH_MET() As Integer
        Get
            Return m_ph_met
        End Get
        Set(ByVal value As Integer)
            m_ph_met = value
        End Set
    End Property
    Public Property CLORUROS() As Double
        Get
            Return m_cloruros
        End Get
        Set(ByVal value As Double)
            m_cloruros = value
        End Set
    End Property
    Public Property CLORUROS_MET() As Integer
        Get
            Return m_cloruros_met
        End Get
        Set(ByVal value As Integer)
            m_cloruros_met = value
        End Set
    End Property
    Public Property PROTEINAS() As Double
        Get
            Return m_proteinas
        End Get
        Set(ByVal value As Double)
            m_proteinas = value
        End Set
    End Property
    Public Property PROTEINAS_MET() As Integer
        Get
            Return m_proteinas_met
        End Get
        Set(ByVal value As Integer)
            m_proteinas_met = value
        End Set
    End Property
    Public Property ENTEROBACTERIAS() As String
        Get
            Return m_enterobacterias
        End Get
        Set(ByVal value As String)
            m_enterobacterias = value
        End Set
    End Property
    Public Property ENTEROBACTERIAS_MET() As Integer
        Get
            Return m_enterobacterias_met
        End Get
        Set(ByVal value As Integer)
            m_enterobacterias_met = value
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
    Public Property LISTERIAAMBIENTAL2() As Double
        Get
            Return m_listeriaambiental2
        End Get
        Set(ByVal value As Double)
            m_listeriaambiental2 = value
        End Set
    End Property
    Public Property LISTERIAAMBIENTAL_MET() As Integer
        Get
            Return m_listeriaambiental_met
        End Get
        Set(ByVal value As Integer)
            m_listeriaambiental_met = value
        End Set
    End Property
    Public Property ESPORANAERMESOFILO() As Double
        Get
            Return m_esporanaermesofilo
        End Get
        Set(ByVal value As Double)
            m_esporanaermesofilo = value
        End Set
    End Property
    Public Property ESPORANAERMESOFILO_MET() As Integer
        Get
            Return m_esporanaermesofilo_met
        End Get
        Set(ByVal value As Integer)
            m_esporanaermesofilo_met = value
        End Set
    End Property
    Public Property TERMOFILOS() As String
        Get
            Return m_termofilos
        End Get
        Set(ByVal value As String)
            m_termofilos = value
        End Set
    End Property
    Public Property TERMOFILOS_MET() As Integer
        Get
            Return m_termofilos_met
        End Get
        Set(ByVal value As Integer)
            m_termofilos_met = value
        End Set
    End Property
    Public Property PSICROTROFOS() As String
        Get
            Return m_psicrotrofos
        End Get
        Set(ByVal value As String)
            m_psicrotrofos = value
        End Set
    End Property
    Public Property PSICROTROFOS_MET() As Integer
        Get
            Return m_psicrotrofos_met
        End Get
        Set(ByVal value As Integer)
            m_psicrotrofos_met = value
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
    Public Property RB_MET() As Integer
        Get
            Return m_rb_met
        End Get
        Set(ByVal value As Integer)
            m_rb_met = value
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
    Public Property TNPROTEINA() As Double
        Get
            Return m_tnproteina
        End Get
        Set(ByVal value As Double)
            m_tnproteina = value
        End Set
    End Property
    Public Property TNCARBOHIDRATOS() As Double
        Get
            Return m_tncarbohidratos
        End Get
        Set(ByVal value As Double)
            m_tncarbohidratos = value
        End Set
    End Property
    Public Property TNGRASASTOTALES() As Double
        Get
            Return m_tngrasastotales
        End Get
        Set(ByVal value As Double)
            m_tngrasastotales = value
        End Set
    End Property
    Public Property TNGRASASSATURADAS() As Double
        Get
            Return m_tngrasassaturadas
        End Get
        Set(ByVal value As Double)
            m_tngrasassaturadas = value
        End Set
    End Property
    Public Property TNGRASASTRANS() As Double
        Get
            Return m_tngrasastrans
        End Get
        Set(ByVal value As Double)
            m_tngrasastrans = value
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
    Public Property LISTERIAMONOCITOGENES_MET() As Integer
        Get
            Return m_listeriamonocitogenes_met
        End Get
        Set(ByVal value As Integer)
            m_listeriamonocitogenes_met = value
        End Set
    End Property
    Public Property CENIZAS() As Double
        Get
            Return m_cenizas
        End Get
        Set(ByVal value As Double)
            m_cenizas = value
        End Set
    End Property
    Public Property CENIZAS_MET() As Integer
        Get
            Return m_cenizas_met
        End Get
        Set(ByVal value As Integer)
            m_cenizas_met = value
        End Set
    End Property
    Public Property TNSODIO() As Double
        Get
            Return m_tnsodio
        End Get
        Set(ByVal value As Double)
            m_tnsodio = value
        End Set
    End Property
    Public Property TNFIBRAALIMENTICIA() As Double
        Get
            Return m_tnfibraalimenticia
        End Get
        Set(ByVal value As Double)
            m_tnfibraalimenticia = value
        End Set
    End Property
    Public Property CODIGOANALITICO() As String
        Get
            Return m_codigoanalitico
        End Get
        Set(ByVal value As String)
            m_codigoanalitico = value
        End Set
    End Property
    Public Property TIPOMUESTRA() As Integer
        Get
            Return m_tipomuestra
        End Get
        Set(ByVal value As Integer)
            m_tipomuestra = value
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
        m_estafcoagpositivo = ""
        m_estafcoagpositivo_met = 0
        m_cf = ""
        m_cf_met = 0
        m_mohos = ""
        m_mohos_met = 0
        m_levaduras = ""
        m_levaduras_met = 0
        m_ct = ""
        m_ct_met = 0
        m_ecoli = ""
        m_ecoli_met = 0
        m_ecoli157 = ""
        m_ecoli157_met = 0
        m_salmonella = 0
        m_salmonella_met = 0
        m_listeriaspp = 0
        m_listeriaspp_met = 0
        m_humedad = 0
        m_humedad_met = 0
        m_mgrasa = 0
        m_mgrasa_met = 0
        m_ph = 0
        m_ph_met = 0
        m_cloruros = 0
        m_cloruros_met = 0
        m_proteinas = 0
        m_proteinas_met = 0
        m_enterobacterias = ""
        m_enterobacterias_met = 0
        m_listeriaambiental = 0
        m_listeriaambiental2 = 0
        m_listeriaambiental_met = 0
        m_esporanaermesofilo = 0
        m_esporanaermesofilo_met = 0
        m_termofilos = ""
        m_termofilos_met = 0
        m_psicrotrofos = ""
        m_psicrotrofos_met = 0
        m_rb = ""
        m_rb_met = 0
        m_tablanutricional = 0
        m_tnproteina = 0
        m_tncarbohidratos = 0
        m_tngrasastotales = 0
        m_tngrasassaturadas = 0
        m_tngrasastrans = 0
        m_listeriamonocitogenes = 0
        m_listeriamonocitogenes_met = 0
        m_cenizas = 0
        m_cenizas_met = 0
        m_tnsodio = 0
        m_tnfibraalimenticia = 0
        m_codigoanalitico = ""
        m_tipomuestra = 0
        m_operador = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechasolicitud As String, ByVal fechaproceso As String, ByVal idmuestra As String, ByVal detallemuestra As String, ByVal observaciones As String, ByVal estadomuestra As String, ByVal estafcoagpositivo As String, ByVal estafcoagpositivo_met As Integer, ByVal cf As String, ByVal cf_met As Integer, ByVal mohos As String, ByVal mohos_met As Integer, ByVal levaduras As String, ByVal levaduras_met As Integer, ByVal ct As String, ByVal ct_met As Integer, ByVal ecoli As String, ByVal ecoli_met As Integer, ByVal ecoli157 As String, ByVal ecoli157_met As Integer, ByVal salmonella As Integer, ByVal salmonella_met As Integer, ByVal listeriaspp As Integer, ByVal listeriaspp_met As Integer, ByVal humedad As Double, ByVal humedad_met As Integer, ByVal mgrasa As Double, ByVal mgrasa_met As Integer, ByVal ph As Double, ByVal ph_met As Integer, ByVal cloruros As Double, ByVal cloruros_met As Integer, ByVal proteinas As Double, ByVal proteinas_met As Integer, ByVal enterobacterias As String, ByVal enterobacterias_met As Integer, ByVal listeriaambiental As Integer, ByVal listeriaambiental2 As Double, ByVal listeriaambiental_met As Integer, ByVal esporanaermesofilo As Double, ByVal ranaermesofilo_met As Integer, ByVal termofilos As String, ByVal termofilos_met As Double, ByVal psicrotrofos As String, ByVal psicrotrofos_met As Integer, ByVal rb As String, ByVal rb_met As Integer, ByVal tablanutricional As Integer, ByVal tnproteina As Double, ByVal tncarbohidratos As Double, ByVal tngrasastotales As Double, ByVal tngrasassaturadas As Double, ByVal tngrasastrans As Double, ByVal listeriamonocitogenes As Integer, ByVal listeriamonocitogenes_met As Integer, ByVal cenizas As Double, ByVal cenizas_met As Integer, ByVal tnsodio As Double, ByVal tnfibraalimenticia As Double, ByVal codigoanalitico As String, ByVal tipomuestra As Integer, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechasolicitud = fechasolicitud
        m_fechaproceso = fechaproceso
        m_idmuestra = idmuestra
        m_detallemuestra = detallemuestra
        m_observaciones = observaciones
        m_estadomuestra = estadomuestra
        m_estafcoagpositivo = estafcoagpositivo
        m_estafcoagpositivo_met = estafcoagpositivo_met
        m_cf = cf
        m_cf_met = cf_met
        m_mohos = mohos
        m_mohos_met = mohos_met
        m_levaduras = levaduras
        m_levaduras_met = levaduras_met
        m_ct = ct
        m_ct_met = ct_met
        m_ecoli = ecoli
        m_ecoli_met = ecoli_met
        m_ecoli157 = ecoli157
        m_ecoli157_met = ecoli157_met
        m_salmonella = salmonella
        m_salmonella_met = salmonella_met
        m_listeriaspp = listeriaspp
        m_listeriaspp_met = listeriaspp_met
        m_humedad = humedad
        m_humedad_met = humedad_met
        m_mgrasa = mgrasa
        m_mgrasa_met = mgrasa_met
        m_ph = ph
        m_ph_met = ph_met
        m_cloruros = cloruros
        m_cloruros_met = cloruros_met
        m_proteinas = proteinas
        m_proteinas_met = proteinas_met
        m_enterobacterias = enterobacterias
        m_enterobacterias_met = enterobacterias_met
        m_listeriaambiental = listeriaambiental
        m_listeriaambiental2 = listeriaambiental2
        m_listeriaambiental_met = listeriaambiental_met
        m_esporanaermesofilo = esporanaermesofilo
        m_esporanaermesofilo_met = ESPORANAERMESOFILO_MET
        m_termofilos = termofilos
        m_termofilos_met = termofilos_met
        m_psicrotrofos = psicrotrofos
        m_psicrotrofos_met = psicrotrofos_met
        m_rb = rb
        m_rb_met = rb_met
        m_tablanutricional = tablanutricional
        m_tnproteina = tnproteina
        m_tncarbohidratos = tncarbohidratos
        m_tngrasastotales = tngrasastotales
        m_tngrasassaturadas = tngrasassaturadas
        m_tngrasastrans = tngrasastrans
        m_listeriamonocitogenes = listeriamonocitogenes
        m_listeriamonocitogenes_met = listeriamonocitogenes_met
        m_cenizas = cenizas
        m_cenizas_met = cenizas_met
        m_tnsodio = tnsodio
        m_tnfibraalimenticia = tnfibraalimenticia
        m_codigoanalitico = codigoanalitico
        m_tipomuestra = tipomuestra
        m_operador = operador
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s2 As New pSubproducto2
        Return s2.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s2 As New pSubproducto2
        Return s2.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim s2 As New pSubproducto2
        Return s2.modificar2(Me, usuario)
    End Function
    Public Function desmarcarficha() As Boolean
        Dim s2 As New pSubproducto2
        Return s2.desmarcarficha(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s2 As New pSubproducto2
        Return s2.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSubproducto2
        Dim s2 As New pSubproducto2
        Return s2.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        'Return m_ficha
        Return m_ficha & Chr(9) & m_idmuestra
    End Function
    Public Function listar() As ArrayList
        Dim s2 As New pSubproducto2
        Return s2.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim s2 As New pSubproducto2
        Return s2.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim s2 As New pSubproducto2
        Return s2.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim s2 As New pSubproducto2
        Return s2.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim s2 As New pSubproducto2
        Return s2.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s2 As New pSubproducto2
        Return s2.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
