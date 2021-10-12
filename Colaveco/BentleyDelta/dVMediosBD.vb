Public Class dVMediosBD
    Private m_id As Long
    Private m_fecha As String
    Private m_grasa As Double
    Private m_grasa2 As Double
    Private m_proteina As Double
    Private m_proteina2 As Double
    Private m_lactosa As Double
    Private m_lactosa2 As Double
    Private m_soltotales As Double
    Private m_soltotales2 As Double
    Private m_celulas As Long
    Private m_celulas2 As Long
    Private m_crioscopia As Long
    Private m_crioscopia2 As Long
    Private m_urea As Integer
    Private m_urea2 As Integer
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
    Public Property GRASA() As Double
        Get
            Return m_grasa
        End Get
        Set(ByVal value As Double)
            m_grasa = value
        End Set
    End Property
    Public Property GRASA2() As Double
        Get
            Return m_grasa2
        End Get
        Set(ByVal value As Double)
            m_grasa2 = value
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
    Public Property PROTEINA2() As Double
        Get
            Return m_proteina2
        End Get
        Set(ByVal value As Double)
            m_proteina2 = value
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
    Public Property LACTOSA2() As Double
        Get
            Return m_lactosa2
        End Get
        Set(ByVal value As Double)
            m_lactosa2 = value
        End Set
    End Property
    Public Property SOLTOTALES() As Double
        Get
            Return m_soltotales
        End Get
        Set(ByVal value As Double)
            m_soltotales = value
        End Set
    End Property
    Public Property SOLTOTALES2() As Double
        Get
            Return m_soltotales2
        End Get
        Set(ByVal value As Double)
            m_soltotales2 = value
        End Set
    End Property
    Public Property CELULAS() As Long
        Get
            Return m_celulas
        End Get
        Set(ByVal value As Long)
            m_celulas = value
        End Set
    End Property
    Public Property CELULAS2() As Long
        Get
            Return m_celulas2
        End Get
        Set(ByVal value As Long)
            m_celulas2 = value
        End Set
    End Property
    Public Property CRIOSCOPIA() As Long
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Long)
            m_crioscopia = value
        End Set
    End Property
    Public Property CRIOSCOPIA2() As Long
        Get
            Return m_crioscopia2
        End Get
        Set(ByVal value As Long)
            m_crioscopia2 = value
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
    Public Property UREA2() As Integer
        Get
            Return m_urea2
        End Get
        Set(ByVal value As Integer)
            m_urea2 = value
        End Set
    End Property
    
#End Region
#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_grasa = 0
        m_grasa2 = 0
        m_proteina = 0
        m_proteina2 = 0
        m_lactosa = 0
        m_lactosa2 = 0
        m_soltotales = 0
        m_soltotales2 = 0
        m_celulas = 0
        m_celulas2 = 0
        m_crioscopia = 0
        m_crioscopia2 = 0
        m_urea = 0
        m_urea2 = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal grasa As Double, ByRef grasa2 As Double, ByVal proteina As Double, ByVal proteina2 As Double, ByVal lactosa As Double, ByVal lactosa2 As Double, ByVal soltotales As Double, ByVal soltotales2 As Double, ByVal celulas As Long, ByVal celulas2 As Long, ByVal crioscopia As Integer, ByVal crioscopia2 As Integer, ByVal urea As Integer, ByVal urea2 As Integer)
        m_id = id
        m_fecha = fecha
        m_grasa = grasa
        m_grasa2 = grasa2
        m_proteina = proteina
        m_proteina2 = m_proteina2
        m_lactosa = lactosa
        m_lactosa2 = lactosa2
        m_soltotales = soltotales
        m_soltotales2 = soltotales2
        m_celulas = celulas
        m_celulas2 = celulas2
        m_crioscopia = crioscopia
        m_crioscopia2 = crioscopia2
        m_urea = urea
        m_urea2 = urea2
    End Sub
#End Region
#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pVMediosBD
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pVMediosBD
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pVMediosBD
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dVMediosBD
        Dim p As New pVMediosBD
        Return p.buscar(Me)
    End Function
  
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pVMediosBD
        Return p.listar
    End Function
    Public Function listarultimos() As ArrayList
        Dim p As New pVMediosBD
        Return p.listarultimos
    End Function
    Public Function listarultimo() As ArrayList
        Dim p As New pVMediosBD
        Return p.listarultimo
    End Function
End Class
