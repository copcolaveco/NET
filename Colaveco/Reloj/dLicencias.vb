Public Class dLicencias
#Region "Atributos"
    Private m_id As Long
    Private m_idusuario As Integer
    Private m_desde As String
    Private m_hasta As String
    Private m_dias As Integer
    Private m_aprobada As Integer
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
    Public Property IDUSUARIO() As Integer
        Get
            Return m_idusuario
        End Get
        Set(ByVal value As Integer)
            m_idusuario = value
        End Set
    End Property
    Public Property DESDE() As String
        Get
            Return m_desde
        End Get
        Set(ByVal value As String)
            m_desde = value
        End Set
    End Property
    Public Property HASTA() As String
        Get
            Return m_hasta
        End Get
        Set(ByVal value As String)
            m_hasta = value
        End Set
    End Property
    Public Property DIAS() As Integer
        Get
            Return m_dias
        End Get
        Set(ByVal value As Integer)
            m_dias = value
        End Set
    End Property
    Public Property APROBADA() As Integer
        Get
            Return m_aprobada
        End Get
        Set(ByVal value As Integer)
            m_aprobada = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idusuario = 0
        m_desde = ""
        m_hasta = ""
        m_dias = 0
        m_aprobada = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idusuario As Integer, ByVal desde As String, ByVal hasta As String, ByVal dias As Integer, ByVal aprobada As Integer)
        m_id = id
        m_idusuario = idusuario
        m_desde = desde
        m_hasta = hasta
        m_dias = dias
        m_aprobada = aprobada
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLicencias
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLicencias
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLicencias
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dLicencias
        Dim p As New pLicencias
        Return p.buscar(Me)
    End Function
    Public Function marcaraprobada() As Boolean
        Dim p As New pLicencias
        Return p.marcaraprobada(Me)
    End Function
    Public Function desmarcaraprobada() As Boolean
        Dim p As New pLicencias
        Return p.desmarcaraprobada(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idusuario
    End Function

    Public Function listar() As ArrayList
        Dim p As New pLicencias
        Return p.listar
    End Function
    Public Function listarsinaprobar() As ArrayList
        Dim p As New pLicencias
        Return p.listarsinaprobar
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim p As New pLicencias
        Return p.listarxano(ano)
    End Function
    Public Function listarxanoxusuario(ByVal ano As Integer, ByVal idusuario As Integer) As ArrayList
        Dim p As New pLicencias
        Return p.listarxanoxusuario(ano, idusuario)
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer, ByVal ano As Integer) As ArrayList
        Dim p As New pLicencias
        Return p.listarxusuario(idusuario, ano)
    End Function
End Class
