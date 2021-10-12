Public Class dSecale
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_empresa As String
    Private m_muestra As String
    Private m_grasa As Double
    Private m_proteina As Double
    Private m_lactosa As Double
    Private m_st As Double
    Private m_rc As Long
    Private m_rb As Long
    Private m_rbpetri As Long
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
    Public Property EMPRESA() As String
        Get
            Return m_empresa
        End Get
        Set(ByVal value As String)
            m_empresa = value
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
    Public Property RC() As Long
        Get
            Return m_rc
        End Get
        Set(ByVal value As Long)
            m_rc = value
        End Set
    End Property
    Public Property RB() As Long
        Get
            Return m_rb
        End Get
        Set(ByVal value As Long)
            m_rb = value
        End Set
    End Property
    Public Property RBPETRI() As Long
        Get
            Return m_rbpetri
        End Get
        Set(ByVal value As Long)
            m_rbpetri = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_empresa = ""
        m_muestra = ""
        m_grasa = 0
        m_proteina = 1
        m_lactosa = 0
        m_st = 0
        m_rc = 0
        m_rb = 0
        m_rbpetri = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal empresa As String, ByVal muestra As String, ByVal grasa As Double, ByVal proteina As Double, ByVal lactosa As Double, ByVal st As Double, ByVal rc As Long, ByVal rb As Long, ByVal rbpetri As Long)
        m_id = id
        m_fecha = fecha
        m_empresa = empresa
        m_muestra = muestra
        m_grasa = grasa
        m_proteina = proteina
        m_lactosa = lactosa
        m_st = st
        m_rc = rc
        m_rb = rb
        m_rbpetri = rbpetri
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSecale
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSecale
        Return c.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSecale
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSecale
        Dim c As New pSecale
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pSecale
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pSecale
        Return c.listarporid(texto)
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pSecale
        Return c.listarporfecha(desde, hasta)
    End Function
    Public Function listarcolaveco(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pSecale
        Return c.listarcolaveco(desde, hasta)
    End Function
    Public Function listarsecale(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pSecale
        Return c.listarsecale(desde, hasta)
    End Function
End Class
