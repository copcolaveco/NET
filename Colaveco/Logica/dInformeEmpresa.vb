Public Class dInformeEmpresa
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_productor As Long
    Private m_rc As Double
    Private m_grasa As Double
    Private m_proteina As Double
    Private m_lactosa As Double
    Private m_rb As Double
    Private m_inhibidores As Double
    Private m_crioscopia As Double
    Private m_fpd As Double
    Private m_urea As Double
    Private m_caseina As Double
    Private m_citrato As Double
    Private m_proteinav As Double
    Private m_st As Double
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property PRODUCTOR() As Long
        Get
            Return m_productor
        End Get
        Set(ByVal value As Long)
            m_productor = value
        End Set
    End Property
    Public Property RC() As Double
        Get
            Return m_rc
        End Get
        Set(ByVal value As Double)
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
    Public Property RB() As Double
        Get
            Return m_rb
        End Get
        Set(ByVal value As Double)
            m_rb = value
        End Set
    End Property
    Public Property INHIBIDORES() As Double
        Get
            Return m_inhibidores
        End Get
        Set(ByVal value As Double)
            m_inhibidores = value
        End Set
    End Property
    Public Property CRIOSCOPIA() As Double
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Double)
            m_crioscopia = value
        End Set
    End Property
    Public Property FPD() As Double
        Get
            Return m_fpd
        End Get
        Set(ByVal value As Double)
            m_fpd = value
        End Set
    End Property
    Public Property UREA() As Double
        Get
            Return m_urea
        End Get
        Set(ByVal value As Double)
            m_urea = value
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
    Public Property CITRATO() As Double
        Get
            Return m_citrato
        End Get
        Set(ByVal value As Double)
            m_citrato = value
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
    Public Property ST() As Double
        Get
            Return m_st
        End Get
        Set(ByVal value As Double)
            m_rc = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_productor = 0
        m_rc = 0
        m_grasa = 0
        m_proteina = 0
        m_lactosa = 0
        m_rb = 0
        m_inhibidores = 0
        m_crioscopia = 0
        m_fpd = 0
        m_urea = 0
        m_caseina = 0
        m_citrato = 0
        m_proteinav = 0
        m_st = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal productor As Long, ByVal rc As Double, ByVal grasa As Double, ByVal proteina As Double, ByVal lactosa As Double, ByVal rb As Double, ByVal inhibidores As Double, ByVal crioscopia As Double, ByVal fpd As Double, ByVal urea As Double, ByVal caseina As Double, ByVal citrato As Double, ByVal proteinav As Double, ByVal st As Double)
        m_id = id
        m_fecha = fecha
        m_productor = productor
        m_rc = rc
        m_grasa = grasa
        m_proteina = proteina
        m_lactosa = lactosa
        m_rb = rb
        m_inhibidores = inhibidores
        m_crioscopia = crioscopia
        m_fpd = fpd
        m_urea = urea
        m_caseina = caseina
        m_citrato = citrato
        m_proteinav = proteinav
        m_st = st
    End Sub
#End Region

#Region "Métodos ABM"
    
#End Region

    Public Overrides Function ToString() As String
        Return m_fecha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pInformeEmpresa
        Return p.listar
    End Function
End Class
