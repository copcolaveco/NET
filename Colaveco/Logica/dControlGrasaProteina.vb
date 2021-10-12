Public Class dControlGrasaProteina
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_bentleyg As Double
    Private m_deltag As Double
    Private m_rosegottliebg As Double
    Private m_gerberg As Double
    Private m_bentleyp As Double
    Private m_deltap As Double
    Private m_dumasp As Double
    Private m_kjeldahp As Double
    Private m_operador As Integer
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
    Public Property BENTLEYG() As Double
        Get
            Return m_bentleyg
        End Get
        Set(ByVal value As Double)
            m_bentleyg = value
        End Set
    End Property
    Public Property DELTAG() As Double
        Get
            Return m_deltag
        End Get
        Set(ByVal value As Double)
            m_deltag = value
        End Set
    End Property
    Public Property ROSEGOTTLIEBG() As Double
        Get
            Return m_rosegottliebg
        End Get
        Set(ByVal value As Double)
            m_rosegottliebg = value
        End Set
    End Property
    Public Property GERBERG() As Double
        Get
            Return m_gerberg
        End Get
        Set(ByVal value As Double)
            m_gerberg = value
        End Set
    End Property
    Public Property BENTLEYP() As Double
        Get
            Return m_bentleyp
        End Get
        Set(ByVal value As Double)
            m_bentleyp = value
        End Set
    End Property
    Public Property DELTAP() As Double
        Get
            Return m_deltap
        End Get
        Set(ByVal value As Double)
            m_deltap = value
        End Set
    End Property
    Public Property DUMASP() As Double
        Get
            Return m_dumasp
        End Get
        Set(ByVal value As Double)
            m_dumasp = value
        End Set
    End Property
    Public Property KJELDAHP() As Double
        Get
            Return m_kjeldahp
        End Get
        Set(ByVal value As Double)
            m_kjeldahp = value
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
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_bentleyg = 0
        m_deltag = 0
        m_rosegottliebg = 0
        m_gerberg = 0
        m_bentleyp = 0
        m_deltap = 0
        m_dumasp = 0
        m_kjeldahp = 0
        m_operador = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal bentleyg As Double, ByVal deltag As Double, ByVal rosegottliebg As Double, ByVal gerberg As Double, ByVal bentleyp As Double, ByVal deltap As Double, ByVal dumasp As Double, ByVal kjeldahp As Double, ByVal operador As Integer)
        m_id = id
        m_fecha = fecha
        m_bentleyg = bentleyg
        m_deltag = deltag
        m_rosegottliebg = rosegottliebg
        m_gerberg = gerberg
        m_bentleyp = bentleyp
        m_deltap = deltap
        m_dumasp = dumasp
        m_kjeldahp = kjeldahp
        m_operador = operador
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlGrasaProteina
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlGrasaProteina
        Return c.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlGrasaProteina
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dControlGrasaProteina
        Dim c As New pControlGrasaProteina
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pControlGrasaProteina
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pControlGrasaProteina
        Return c.listarporid(texto)
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControlGrasaProteina
        Return c.listarporfecha(desde, hasta)
    End Function
    
End Class
