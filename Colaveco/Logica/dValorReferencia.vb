Public Class dValorReferencia
#Region "Atributos"
    Private m_id As Integer
    Private m_celulas As Double
    Private m_grasa As Double
    Private m_proteina As Double
    Private m_lactosa As Double
    Private m_st As Double
    Private m_crioscopia As Double
    Private m_urea As Double
    Private m_proteinav As Double
    Private m_caseina As Double
    Private m_densidad As Double
    Private m_ph As Double
    Private m_citratos As Double
#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Public Property CELULAS() As Double
        Get
            Return m_celulas
        End Get
        Set(ByVal value As Double)
            m_celulas = value
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
    Public Property CRIOSCOPIA() As Double
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Double)
            m_crioscopia = value
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
    Public Property CITRATOS() As Double
        Get
            Return m_citratos
        End Get
        Set(ByVal value As Double)
            m_citratos = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_celulas = 0
        m_grasa = 0
        m_proteina = 0
        m_lactosa = 0
        m_st = 0
        m_crioscopia = 0
        m_urea = 0
        m_proteinav = 0
        m_caseina = 0
        m_densidad = 0
        m_ph = 0
        m_citratos = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal celulas As Double, ByVal grasa As Double, ByVal proteina As Double, ByVal lactosa As Double, ByVal st As Double, ByVal crioscopia As Double, ByVal urea As Double, ByVal proteinav As Double, ByVal caseina As Double, ByVal densidad As Double, ByVal ph As Double, ByVal citratos As Double)
        m_id = id
        m_celulas = celulas
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
        m_citratos = citratos
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificar(Me, usuario)
    End Function
    Public Function modificarcelulas(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarcelulas(Me, usuario)
    End Function
    Public Function modificargrasa(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificargrasa(Me, usuario)
    End Function
    Public Function modificarproteina(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarproteina(Me, usuario)
    End Function
    Public Function modificarlactosa(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarlactosa(Me, usuario)
    End Function
    Public Function modificarst(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarst(Me, usuario)
    End Function
    Public Function modificarcrioscopia(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarcrioscopia(Me, usuario)
    End Function
    Public Function modificarurea(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarurea(Me, usuario)
    End Function
    Public Function modificarproteinav(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarproteinav(Me, usuario)
    End Function
    Public Function modificarcaseina(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarcaseina(Me, usuario)
    End Function
    Public Function modificardensidad(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificardensidad(Me, usuario)
    End Function
    Public Function modificarph(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarph(Me, usuario)
    End Function
    Public Function modificarcitratos(ByVal usuario As dUsuario) As Boolean
        Dim p As New pValorReferencia
        Return p.modificarcitratos(Me, usuario)
    End Function
    Public Function buscar() As dValorReferencia
        Dim p As New pValorReferencia
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_celulas
    End Function

    Public Function listar() As ArrayList
        Dim p As New pValorReferencia
        Return p.listar
    End Function
    Public Function listarcelulas() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarcelulas
    End Function
    Public Function listargrasa() As ArrayList
        Dim p As New pValorReferencia
        Return p.listargrasa
    End Function
    Public Function listarproteina() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarproteina
    End Function
    Public Function listarlactosa() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarlactosa
    End Function
    Public Function listarst() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarst
    End Function
    Public Function listarcrioscopia() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarcrioscopia
    End Function
    Public Function listarurea() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarurea
    End Function
    Public Function listarproteinav() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarproteinav
    End Function
    Public Function listarcaseina() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarcaseina
    End Function
    Public Function listardensidad() As ArrayList
        Dim p As New pValorReferencia
        Return p.listardensidad
    End Function
    Public Function listarph() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarph
    End Function
    Public Function listarcitratos() As ArrayList
        Dim p As New pValorReferencia
        Return p.listarcitratos
    End Function
End Class
