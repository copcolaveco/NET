Public Class dSolicitudesIT
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_descripcion As String
    Private m_solicitante As Integer
    Private m_prioridad As Integer
    Private m_estado As Integer
    Private m_autorizado As Integer
    Private m_autoriza As Integer
    Private m_validado As Integer
    Private m_valida As Integer
    Private m_fechavalidacion As String
    Private m_observaciones As String
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
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property SOLICITANTE() As Integer
        Get
            Return m_solicitante
        End Get
        Set(ByVal value As Integer)
            m_solicitante = value
        End Set
    End Property
    Public Property PRIORIDAD() As Integer
        Get
            Return m_prioridad
        End Get
        Set(ByVal value As Integer)
            m_prioridad = value
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
    Public Property AUTORIZADO() As Integer
        Get
            Return m_autorizado
        End Get
        Set(ByVal value As Integer)
            m_autorizado = value
        End Set
    End Property
    Public Property AUTORIZA() As Integer
        Get
            Return m_autoriza
        End Get
        Set(ByVal value As Integer)
            m_autoriza = value
        End Set
    End Property
    Public Property VALIDADO() As Integer
        Get
            Return m_validado
        End Get
        Set(ByVal value As Integer)
            m_validado = value
        End Set
    End Property
    Public Property VALIDA() As Integer
        Get
            Return m_valida
        End Get
        Set(ByVal value As Integer)
            m_valida = value
        End Set
    End Property
    Public Property FECHAVALIDACION() As String
        Get
            Return m_fechavalidacion
        End Get
        Set(ByVal value As String)
            m_fechavalidacion = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = Now
        m_descripcion = ""
        m_solicitante = 0
        m_prioridad = 0
        m_estado = 0
        m_autorizado = 0
        m_autoriza = 0
        m_validado = 0
        m_valida = 0
        m_fechavalidacion = ""
        m_observaciones = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal descripcion As String, ByVal solicitante As Integer, ByVal prioridad As Integer, ByVal estado As Integer, ByVal autorizado As Integer, ByVal autoriza As Integer, ByVal validado As Integer, ByVal valida As Integer, ByVal fechavalidacion As String, ByVal observaciones As String)
        m_id = id
        m_fecha = fecha
        m_descripcion = descripcion
        m_solicitante = solicitante
        m_prioridad = prioridad
        m_estado = estado
        m_autorizado = autorizado
        m_autoriza = autoriza
        m_validado = validado
        m_valida = valida
        m_fechavalidacion = fechavalidacion
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudesIT
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudesIT
        Return s.modificar(Me, usuario)
    End Function
    Public Function modificarObservaciones(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudesIT
        Return s.modificarobservaciones(Me, usuario)
    End Function
    Public Function modificarestado() As Boolean
        Dim s As New pSolicitudesIT
        Return s.modificarestado(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudesIT
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSolicitudesIT
        Dim s As New pSolicitudesIT
        Return s.buscar(Me)
    End Function

#End Region

    Public Overrides Function tostring() As String
        Return m_fecha
    End Function
    Public Function listar() As ArrayList
        Dim s As New pSolicitudesIT
        Return s.listar
    End Function
    Public Function listarpendientes() As ArrayList
        Dim s As New pSolicitudesIT
        Return s.listarpendientes
    End Function
    Public Function listarfinalizadas() As ArrayList
        Dim s As New pSolicitudesIT
        Return s.listarfinalizadas
    End Function
    Public Function listarenproceso() As ArrayList
        Dim s As New pSolicitudesIT
        Return s.listarenproceso
    End Function
    Public Function listarxusuario(ByVal usuario As Integer) As ArrayList
        Dim s As New pSolicitudesIT
        Return s.listarxusuario(usuario)
    End Function
    Public Function listarxestado(ByVal estado As Integer) As ArrayList
        Dim s As New pSolicitudesIT
        Return s.listarxestado(estado)
    End Function
    Public Function listarxestadousuario(ByVal estado As Integer, ByVal usuario As Integer) As ArrayList
        Dim s As New pSolicitudesIT
        Return s.listarxestadousuario(estado, usuario)
    End Function
    Public Function marcar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudesIT
        Return s.marcar(Me, usuario)
    End Function
End Class
