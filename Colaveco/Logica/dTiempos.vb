Public Class dTiempos
#Region "Atributos"
    Private m_control As Integer
    Private m_calidad As Integer
    Private m_agua As Integer
    Private m_antibiograma As Integer
    Private m_pal As Integer
    Private m_parasitologia As Integer
    Private m_productos As Integer
    Private m_serologia_leucosis As Integer
    Private m_patologia As Integer
    Private m_ambiental As Integer
    Private m_lactometros As Integer
    Private m_nutricion As Integer
    Private m_otros As Integer
    Private m_suelos As Integer
    Private m_serologia_brucelosis As Integer
    Private m_serologia_otros As Integer
    Private m_sp_salmonella_listeria As Integer
    Private m_sp_mohos_levaduras As Integer
    Private m_esporulados As Integer
    Private m_brucelosis_leche As Integer
    Private m_efluentes As Integer

#End Region

#Region "Getters y Setters"
    Public Property CONTROL() As Integer
        Get
            Return m_control
        End Get
        Set(ByVal value As Integer)
            m_control = value
        End Set
    End Property
    Public Property CALIDAD() As Integer
        Get
            Return m_calidad
        End Get
        Set(ByVal value As Integer)
            m_calidad = value
        End Set
    End Property
    Public Property AGUA() As Integer
        Get
            Return m_agua
        End Get
        Set(ByVal value As Integer)
            m_agua = value
        End Set
    End Property
    Public Property ANTIBIOGRAMA() As Integer
        Get
            Return m_antibiograma
        End Get
        Set(ByVal value As Integer)
            m_antibiograma = value
        End Set
    End Property
    Public Property PAL() As Integer
        Get
            Return m_pal
        End Get
        Set(ByVal value As Integer)
            m_pal = value
        End Set
    End Property
    Public Property PARASITOLOGIA() As Integer
        Get
            Return m_parasitologia
        End Get
        Set(ByVal value As Integer)
            m_parasitologia = value
        End Set
    End Property
    Public Property PRODUCTOS() As Integer
        Get
            Return m_productos
        End Get
        Set(ByVal value As Integer)
            m_productos = value
        End Set
    End Property
    Public Property SEROLOGIA_LEUCOSIS() As Integer
        Get
            Return m_serologia_leucosis
        End Get
        Set(ByVal value As Integer)
            m_serologia_leucosis = value
        End Set
    End Property
    Public Property PATOLOGIA() As Integer
        Get
            Return m_patologia
        End Get
        Set(ByVal value As Integer)
            m_patologia = value
        End Set
    End Property
    Public Property AMBIENTAL() As Integer
        Get
            Return m_ambiental
        End Get
        Set(ByVal value As Integer)
            m_ambiental = value
        End Set
    End Property
    Public Property LACTOMETROS() As Integer
        Get
            Return m_lactometros
        End Get
        Set(ByVal value As Integer)
            m_lactometros = value
        End Set
    End Property
    Public Property NUTRICION() As Integer
        Get
            Return m_nutricion
        End Get
        Set(ByVal value As Integer)
            m_nutricion = value
        End Set
    End Property
    Public Property OTROS() As Integer
        Get
            Return m_otros
        End Get
        Set(ByVal value As Integer)
            m_otros = value
        End Set
    End Property
    Public Property SUELOS() As Integer
        Get
            Return m_suelos
        End Get
        Set(ByVal value As Integer)
            m_suelos = value
        End Set
    End Property
    Public Property SEROLOGIA_BRUCELOSIS() As Integer
        Get
            Return m_serologia_brucelosis
        End Get
        Set(ByVal value As Integer)
            m_serologia_brucelosis = value
        End Set
    End Property
    Public Property SEROLOGIA_OTROS() As Integer
        Get
            Return m_serologia_otros
        End Get
        Set(ByVal value As Integer)
            m_serologia_otros = value
        End Set
    End Property
    Public Property SP_SALMONELLA_LISTERIA() As Integer
        Get
            Return m_sp_salmonella_listeria
        End Get
        Set(ByVal value As Integer)
            m_sp_salmonella_listeria = value
        End Set
    End Property
    Public Property SP_MOHOS_LEVADURAS() As Integer
        Get
            Return m_sp_mohos_levaduras
        End Get
        Set(ByVal value As Integer)
            m_sp_mohos_levaduras = value
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

    Public Property BRUCELOSIS_LECHE() As Integer
        Get
            Return m_brucelosis_leche
        End Get
        Set(ByVal value As Integer)
            m_brucelosis_leche = value
        End Set
    End Property
    Public Property EFLUENTES() As Integer
        Get
            Return m_efluentes
        End Get
        Set(ByVal value As Integer)
            m_efluentes = value
        End Set
    End Property
   
#End Region

#Region "Constructores"
    Public Sub New()
        m_control = 0
        m_calidad = 0
        m_agua = 0
        m_antibiograma = 0
        m_pal = 0
        m_parasitologia = 0
        m_productos = 0
        m_serologia_leucosis = 0
        m_patologia = 0
        m_ambiental = 0
        m_lactometros = 0
        m_nutricion = 0
        m_otros = 0
        m_suelos = 0
        m_serologia_brucelosis = 0
        m_serologia_otros = 0
        m_sp_salmonella_listeria = 0
        m_sp_mohos_levaduras = 0
        m_esporulados = 0
        m_brucelosis_leche = 0
        m_efluentes = 0

    End Sub
    Public Sub New(ByVal control As Integer, ByVal calidad As Integer, ByVal agua As Integer, ByVal antibiograma As Integer, ByVal pal As Integer, ByVal parasitologia As Integer, ByVal productos As Integer, ByVal serologia_leucosis As Integer, ByVal patologia As Integer, ByVal ambiental As Integer, ByVal lactometros As Integer, ByVal nutricion As Integer, ByVal otros As Integer, ByVal suelos As Integer, ByVal serologia_brucelosis As Integer, ByVal serologia_otros As Integer, ByVal sp_salmonella_listeria As Integer, ByVal sp_mohos_levaduras As Integer, ByVal esporulados As Integer, ByVal brucelosis_leche As Integer, ByVal efluentes As Integer)
        m_control = control
        m_calidad = calidad
        m_agua = agua
        m_antibiograma = antibiograma
        m_pal = pal
        m_parasitologia = parasitologia
        m_productos = productos
        m_serologia_leucosis = serologia_leucosis
        m_patologia = patologia
        m_ambiental = ambiental
        m_lactometros = lactometros
        m_nutricion = nutricion
        m_otros = otros
        m_suelos = suelos
        m_serologia_brucelosis = serologia_brucelosis
        m_serologia_otros = serologia_otros
        m_sp_salmonella_listeria = sp_salmonella_listeria
        m_sp_mohos_levaduras = sp_mohos_levaduras
        m_esporulados = esporulados
        m_brucelosis_leche = brucelosis_leche
        m_efluentes = efluentes
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTiempos
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTiempos
        Return p.modificar(Me, usuario)
    End Function

    Public Function buscar() As dTiempos
        Dim p As New pTiempos
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_control
    End Function

    Public Function listar() As ArrayList
        Dim p As New pTiempos
        Return p.listar
    End Function
End Class
