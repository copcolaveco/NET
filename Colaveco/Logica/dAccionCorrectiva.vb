Public Class dAccionCorrectiva
#Region "Atributos"
    Private m_id As Long
    Private m_numero As Long
    Private m_causa As String
    Private m_accion As String
    Private m_plan As Integer
    Private m_plazo As String
    Private m_responsable As Integer
    Private m_criterios As String
    Private m_eficaz As String
    Private m_fechaevaluacion As String
    Private m_estado As Integer
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
    Public Property NUMERO() As Long
        Get
            Return m_numero
        End Get
        Set(ByVal value As Long)
            m_numero = value
        End Set
    End Property
    Public Property CAUSA() As String
        Get
            Return m_causa
        End Get
        Set(ByVal value As String)
            m_causa = value
        End Set
    End Property
    Public Property ACCION() As String
        Get
            Return m_accion
        End Get
        Set(ByVal value As String)
            m_accion = value
        End Set
    End Property
    Public Property PLAN() As Integer
        Get
            Return m_plan
        End Get
        Set(ByVal value As Integer)
            m_plan = value
        End Set
    End Property
    Public Property PLAZO() As String
        Get
            Return m_plazo
        End Get
        Set(ByVal value As String)
            m_plazo = value
        End Set
    End Property
    Public Property RESPONSABLE() As Integer
        Get
            Return m_responsable
        End Get
        Set(ByVal value As Integer)
            m_responsable = value
        End Set
    End Property
    Public Property CRITERIOS() As String
        Get
            Return m_criterios
        End Get
        Set(ByVal value As String)
            m_criterios = value
        End Set
    End Property
    Public Property EFICAZ() As String
        Get
            Return m_eficaz
        End Get
        Set(ByVal value As String)
            m_eficaz = value
        End Set
    End Property
    Public Property FECHAEVALUACION() As String
        Get
            Return m_fechaevaluacion
        End Get
        Set(ByVal value As String)
            m_fechaevaluacion = value
        End Set
    End Property
    Public Property ESTADO() As Integer
        Get
            Return m_estado
        End Get
        Set(ByVal value As Integer)
            m_estado = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_numero = 0
        m_causa = ""
        m_accion = ""
        m_plan = 0
        m_plazo = ""
        m_responsable = 0
        m_criterios = ""
        m_eficaz = ""
        m_fechaevaluacion = ""
        m_estado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal numero As Long, ByVal causa As String, ByVal accion As String, ByVal plan As Integer, ByVal plazo As String, ByVal responsable As Integer, ByVal criterios As String, ByVal eficaz As String, ByVal fechaevaluacion As String, ByVal estado As Integer)
        m_id = id
        m_numero = numero
        m_causa = causa
        m_accion = accion
        m_plan = plan
        m_plazo = plazo
        m_responsable = responsable
        m_criterios = criterios
        m_eficaz = eficaz
        m_fechaevaluacion = fechaevaluacion
        m_estado = estado
    End Sub
#End Region
#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pAccionCorrectiva
        Return r.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pAccionCorrectiva
        Return r.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pAccionCorrectiva
        Return r.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAccionCorrectiva
        Dim r As New pAccionCorrectiva
        Return r.buscar(Me)
    End Function
#End Region
    Public Overrides Function tostring() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim r As New pAccionCorrectiva
        Return r.listar
    End Function
    Public Function listarxnum(ByVal n As Long) As ArrayList
        Dim r As New pAccionCorrectiva
        Return r.listarxnum(n)
    End Function
End Class
