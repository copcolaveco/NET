Public Class dPlanAC
#Region "Atributos"
    Private m_id As Long
    Private m_idac As Long
    Private m_accion As String
    Private m_responsable As Integer
    Private m_efectuado As Integer
    Private m_fecha As String

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
    Public Property IDAC() As Long
        Get
            Return m_idac
        End Get
        Set(ByVal value As Long)
            m_idac = value
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
    Public Property RESPONSABLE() As Integer
        Get
            Return m_responsable
        End Get
        Set(ByVal value As Integer)
            m_responsable = value
        End Set
    End Property
    Public Property EFECTUADO() As Integer
        Get
            Return m_efectuado
        End Get
        Set(ByVal value As Integer)
            m_efectuado = value
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
#End Region
#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idac = 0
        m_accion = ""
        m_responsable = 0
        m_efectuado = 0
        m_fecha = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal idac As Long, ByVal accion As String, ByVal responsable As Integer, ByVal efectuado As Integer, ByVal fecha As String)
        m_id = id
        m_idac = idac
        m_accion = accion
        m_responsable = responsable
        m_efectuado = efectuado
        m_fecha = fecha
    End Sub
#End Region
#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pPlanAC
        Return r.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pPlanAC
        Return r.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pPlanAC
        Return r.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPlanAC
        Dim r As New pPlanAC
        Return r.buscar(Me)
    End Function
#End Region
    Public Overrides Function tostring() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim r As New pPlanAC
        Return r.listar
    End Function
    Public Function listarxidac(ByVal idac As Long) As ArrayList
        Dim r As New pPlanAC
        Return r.listarxidac(idac)
    End Function
End Class
