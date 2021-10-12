Public Class dImpControl
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
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As String, ByVal fecha As String, _
                   ByVal equipo As String, ByVal producto As String, ByVal muestra As String, _
                   ByVal rc As Integer, ByVal grasa As Double, ByVal proteina As Double, _
                   ByVal lactosa As Double, ByVal st As Double, ByVal crioscopia As Integer, _
                   ByVal urea As Integer, ByVal proteinav As Double, ByVal caseina As Double, ByVal densidad As Double, _
                   ByVal ph As Double)
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
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pImpControl
        Return c.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim c As New pImpControl
        Return c.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim c As New pImpControl
        Return c.eliminar(Me)
    End Function
    Public Function buscar() As dImpControl
        Dim c As New pImpControl
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pImpControl
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pImpControl
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pImpControl
        Return c.listarporsolicitud(texto)
    End Function
End Class
