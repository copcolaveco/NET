Public Class dImpCalidad2
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As String
    Private m_fecha As String
    Private m_equipo As String
    Private m_producto As String
    Private m_muestra As String
    Private m_rc As Integer
    Private m_grasa As Double
    Private m_proteina As Double
    Private m_lactosa As Double
    Private m_st As Double
    Private m_crioscopia As Integer
    Private m_urea As Integer
    Private m_proteinav As Double
    Private m_caseina As Double
    Private m_densidad As Double
    Private m_ph As Double
    Private m_grasa_b As Double
    Private m_grasa_a As Double
    Private m_cit As Integer
    Private m_agl As Double
    Private m_sng As Double
    Private m_sfa As Double
    Private m_ufa As Double
    Private m_mufa As Double
    Private m_pufa As Double
    Private m_c16 As Double
    Private m_c180 As Double
    Private m_c181 As Double
    Private m_bhb As Double
    Private m_acetone As Double
    Private m_cisfat As Double
    Private m_transfat As Double
    Private m_denovofa As Double
    Private m_mixedfa As Double
    Private m_preformedfa As Double
    Private m_denovofa2 As Double
    Private m_mixedfa2 As Double
    Private m_preformedfa2 As Double
    Private m_nefa As Double

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
    Public Property FICHA() As String
        Get
            Return m_ficha
        End Get
        Set(ByVal value As String)
            m_ficha = value
        End Set
    End Property
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property EQUIPO() As String
        Get
            Return m_equipo
        End Get
        Set(ByVal value As String)
            m_equipo = value
        End Set
    End Property
    Public Property PRODUCTO() As String
        Get
            Return m_producto
        End Get
        Set(ByVal value As String)
            m_producto = value
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
    Public Property RC() As Integer
        Get
            Return m_rc
        End Get
        Set(ByVal value As Integer)
            m_rc = value
        End Set
    End Property
    Public Property GRASA() As Double
        Get
            Return m_grasa
        End Get
        Set(ByVal value As Double)
            m_grasa = value
        End Set
    End Property
    Public Property PROTEINA() As Double
        Get
            Return m_proteina
        End Get
        Set(ByVal value As Double)
            m_proteina = value
        End Set
    End Property
    Public Property LACTOSA() As Double
        Get
            Return m_lactosa
        End Get
        Set(ByVal value As Double)
            m_lactosa = value
        End Set
    End Property
    Public Property ST() As Double
        Get
            Return m_st
        End Get
        Set(ByVal value As Double)
            m_st = value
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
    Public Property UREA() As Integer
        Get
            Return m_urea
        End Get
        Set(ByVal value As Integer)
            m_urea = value
        End Set
    End Property
    Public Property PROTEINAV() As Double
        Get
            Return m_proteinav
        End Get
        Set(ByVal value As Double)
            m_proteinav = value
        End Set
    End Property
    Public Property CASEINA() As Double
        Get
            Return m_caseina
        End Get
        Set(ByVal value As Double)
            m_caseina = value
        End Set
    End Property
    Public Property DENSIDAD() As Double
        Get
            Return m_densidad
        End Get
        Set(ByVal value As Double)
            m_densidad = value
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
    Public Property GRASA_B() As Double
        Get
            Return m_grasa_b
        End Get
        Set(ByVal value As Double)
            m_grasa_b = value
        End Set
    End Property
    Public Property GRASA_A() As Double
        Get
            Return m_grasa_a
        End Get
        Set(ByVal value As Double)
            m_grasa_a = value
        End Set
    End Property
    Public Property CIT() As Double
        Get
            Return m_cit
        End Get
        Set(ByVal value As Double)
            m_cit = value
        End Set
    End Property
    Public Property AGL() As Double
        Get
            Return m_agl
        End Get
        Set(ByVal value As Double)
            m_agl = value
        End Set
    End Property
    Public Property SNG() As Double
        Get
            Return m_sng
        End Get
        Set(ByVal value As Double)
            m_sng = value
        End Set
    End Property
    Public Property SFA() As Double
        Get
            Return m_sfa
        End Get
        Set(ByVal value As Double)
            m_sfa = value
        End Set
    End Property
    Public Property UFA() As Double
        Get
            Return m_ufa
        End Get
        Set(ByVal value As Double)
            m_ufa = value
        End Set
    End Property
    Public Property MUFA() As Double
        Get
            Return m_mufa
        End Get
        Set(ByVal value As Double)
            m_mufa = value
        End Set
    End Property
    Public Property PUFA() As Double
        Get
            Return m_pufa
        End Get
        Set(ByVal value As Double)
            m_pufa = value
        End Set
    End Property
    Public Property C16() As Double
        Get
            Return m_c16
        End Get
        Set(ByVal value As Double)
            m_c16 = value
        End Set
    End Property
    Public Property C180() As Double
        Get
            Return m_c180
        End Get
        Set(ByVal value As Double)
            m_c180 = value
        End Set
    End Property
    Public Property C181() As Double
        Get
            Return m_c181
        End Get
        Set(ByVal value As Double)
            m_c181 = value
        End Set
    End Property
    Public Property BHB() As Double
        Get
            Return m_bhb
        End Get
        Set(ByVal value As Double)
            m_bhb = value
        End Set
    End Property
    Public Property ACETONE() As Double
        Get
            Return m_acetone
        End Get
        Set(ByVal value As Double)
            m_acetone = value
        End Set
    End Property
    Public Property CISFAT() As Double
        Get
            Return m_cisfat
        End Get
        Set(ByVal value As Double)
            m_cisfat = value
        End Set
    End Property
    Public Property TRANSFAT() As Double
        Get
            Return m_transfat
        End Get
        Set(ByVal value As Double)
            m_transfat = value
        End Set
    End Property
    Public Property DENOVOFA() As Double
        Get
            Return m_denovofa
        End Get
        Set(ByVal value As Double)
            m_denovofa = value
        End Set
    End Property
    Public Property MIXEDFA() As Double
        Get
            Return m_mixedfa
        End Get
        Set(ByVal value As Double)
            m_mixedfa = value
        End Set
    End Property
    Public Property PREFORMEDFA() As Double
        Get
            Return m_preformedfa
        End Get
        Set(ByVal value As Double)
            m_preformedfa = value
        End Set
    End Property
    Public Property DENOVOFA2() As Double
        Get
            Return m_denovofa2
        End Get
        Set(ByVal value As Double)
            m_denovofa2 = value
        End Set
    End Property
    Public Property MIXEDFA2() As Double
        Get
            Return m_mixedfa2
        End Get
        Set(ByVal value As Double)
            m_mixedfa2 = value
        End Set
    End Property
    Public Property PREFORMEDFA2() As Double
        Get
            Return m_preformedfa2
        End Get
        Set(ByVal value As Double)
            m_preformedfa2 = value
        End Set
    End Property
    Public Property NEFA() As Double
        Get
            Return m_nefa
        End Get
        Set(ByVal value As Double)
            m_nefa = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = ""
        m_fecha = ""
        m_equipo = ""
        m_producto = ""
        m_muestra = ""
        m_rc = 0
        m_grasa = 0
        m_proteina = 1
        m_lactosa = 0
        m_st = 0
        m_crioscopia = 0
        m_urea = 0
        m_proteinav = 0
        m_caseina = 0
        m_densidad = 0
        m_ph = 0
        m_grasa_b = 0
        m_grasa_a = 0
        m_cit = 0
        m_agl = 0
        m_sng = 0
        m_sfa = 0
        m_ufa = 0
        m_mufa = 0
        m_pufa = 0
        m_c16 = 0
        m_c180 = 0
        m_c181 = 0
        m_bhb = 0
        m_acetone = 0
        m_cisfat = 0
        m_transfat = 0
        m_denovofa = 0
        m_mixedfa = 0
        m_preformedfa = 0
        m_denovofa2 = 0
        m_mixedfa2 = 0
        m_preformedfa2 = 0
        m_nefa = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As String, ByVal fecha As String, ByVal equipo As String, ByVal producto As String, ByVal muestra As String, ByVal rc As Integer, ByVal grasa As Double, ByVal proteina As Double, ByVal lactosa As Double, ByVal st As Double, ByVal crioscopia As Integer, ByVal urea As Integer, ByVal proteinav As Double, ByVal caseina As Double, ByVal densidad As Double, ByVal ph As Double, ByVal grasa_b As Double, ByVal grasa_a As Double, ByVal cit As Integer, ByVal agl As Double, ByVal sng As Double, ByVal sfa As Double, ByVal ufa As Double, ByVal mufa As Double, ByVal pufa As Double, ByVal c16 As Double, ByVal c180 As Double, ByVal c181 As Double, ByVal bhb As Double, ByVal acetone As Double, ByVal cisfat As Double, ByVal transfat As Double, ByVal denovofa As Double, ByVal mixedfa As Double, ByVal preformedfa As Double, ByVal denovofa2 As Double, ByVal mixedfa2 As Double, ByVal preformedfa2 As Double, ByVal nefa As Double)
        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_equipo = equipo
        m_producto = producto
        m_muestra = muestra
        m_rc = rc
        m_grasa = grasa
        m_proteina = proteina
        m_lactosa = lactosa
        m_st = st
        m_crioscopia = crioscopia
        m_urea = urea
        m_proteinav = proteinav
        m_caseina = caseina
        m_densidad = densidad
        m_ph = ph
        m_grasa_b = grasa_b
        m_grasa_a = grasa_a
        m_cit = cit
        m_agl = agl
        m_sng = sng
        m_sfa = sfa
        m_ufa = ufa
        m_mufa = mufa
        m_pufa = pufa
        m_c16 = c16
        m_c180 = c180
        m_c181 = c181
        m_bhb = bhb
        m_acetone = acetone
        m_cisfat = cisfat
        m_transfat = transfat
        m_denovofa = denovofa
        m_mixedfa = mixedfa
        m_preformedfa = preformedfa
        m_denovofa2 = denovofa2
        m_mixedfa2 = mixedfa2
        m_preformedfa2 = preformedfa2
        m_nefa = nefa
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pImpCalidad2
        Return c.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim c As New pImpCalidad2
        Return c.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim c As New pImpCalidad2
        Return c.eliminar(Me)
    End Function
    Public Function buscar() As dImpCalidad2
        Dim c As New pImpCalidad2
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pImpCalidad2
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pImpCalidad2
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pImpCalidad2
        Return c.listarporsolicitud(texto)
    End Function
End Class
