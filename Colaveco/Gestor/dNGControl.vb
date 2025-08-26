Public Class dNGControl
#Region "Atributos"
    Private m_ControlId As Long
    Private m_ControlFechaRealizado As String
    Private m_InformeId As Long
    Private m_ControlFechaIngreso As String
    Private m_ControlTipoId As Integer
    Private m_ControlResultado As Integer
    Private m_ControlCoincide As Integer
    Private m_ControlOpcMejora As Integer
    Private m_ControlNoConformidad As Integer
    Private m_ControlObservaciones As String
    Private m_UsuarioId As Integer
    Private m_ControlControlado As Integer
    Private m_ControlInformeTipo As Integer
#End Region

#Region "Getters y Setters"
    Public Property ControlId() As Long
        Get
            Return m_ControlId
        End Get
        Set(ByVal value As Long)
            m_ControlId = value
        End Set
    End Property
    Public Property ControlFechaRealizado() As String
        Get
            Return m_ControlFechaRealizado
        End Get
        Set(ByVal value As String)
            m_ControlFechaRealizado = value
        End Set
    End Property
    Public Property InformeId() As Long
        Get
            Return m_InformeId
        End Get
        Set(ByVal value As Long)
            m_InformeId = value
        End Set
    End Property
    Public Property ControlFechaIngreso() As String
        Get
            Return m_ControlFechaIngreso
        End Get
        Set(ByVal value As String)
            m_ControlFechaIngreso = value
        End Set
    End Property
    Public Property ControlTipoId() As Integer
        Get
            Return m_ControlTipoId
        End Get
        Set(ByVal value As Integer)
            m_ControlTipoId = value
        End Set
    End Property
    Public Property ControlResultado() As Integer
        Get
            Return m_ControlResultado
        End Get
        Set(ByVal value As Integer)
            m_ControlResultado = value
        End Set
    End Property
    Public Property ControlCoincide() As Integer
        Get
            Return m_ControlCoincide
        End Get
        Set(ByVal value As Integer)
            m_ControlCoincide = value
        End Set
    End Property
    Public Property ControlOpcMejora() As Integer
        Get
            Return m_ControlOpcMejora
        End Get
        Set(ByVal value As Integer)
            m_ControlOpcMejora = value
        End Set
    End Property
    Public Property ControlNoConformidad() As Integer
        Get
            Return m_ControlNoConformidad
        End Get
        Set(ByVal value As Integer)
            m_ControlNoConformidad = value
        End Set
    End Property
    Public Property ControlObservaciones() As String
        Get
            Return m_ControlObservaciones
        End Get
        Set(ByVal value As String)
            m_ControlObservaciones = value
        End Set
    End Property
    Public Property UsuarioId() As Integer
        Get
            Return m_UsuarioId
        End Get
        Set(ByVal value As Integer)
            m_UsuarioId = value
        End Set
    End Property
    Public Property ControlControlado() As Integer
        Get
            Return m_ControlControlado
        End Get
        Set(ByVal value As Integer)
            m_ControlControlado = value
        End Set
    End Property
    Public Property ControlInformeTipo() As Integer
        Get
            Return m_ControlInformeTipo
        End Get
        Set(ByVal value As Integer)
            m_ControlInformeTipo = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_ControlId = 0
        m_ControlFechaIngreso = Now
        m_InformeId = 0
        m_ControlFechaRealizado = Now
        m_ControlTipoId = 0
        m_ControlResultado = 0
        m_ControlCoincide = 0
        m_ControlOpcMejora = 0
        m_ControlNoConformidad = 0
        m_ControlObservaciones = ""
        m_UsuarioId = 0
        m_ControlControlado = 0
        m_ControlTipoId = 0
    End Sub
    Public Sub New(ByVal ControlId As Long, ByVal ControlFechaIngreso As String, ByVal InformeId As Long, ByVal ControlFechaRealizado As String, ByVal ControlTipoId As Integer, ByVal ControlResultad As Integer, ByVal ControlCoincide As Integer, ByVal ControlOpcMejora As Integer, ByVal ControlNoConformidad As Integer, ByVal ControlObservaciones As String, ByVal UsuarioId As Integer, ByVal ControlControlado As Integer, ByVal ControlInformeTipo As Integer)
        m_ControlId = ControlId
        m_ControlFechaIngreso = ControlFechaIngreso
        m_InformeId = InformeId
        m_ControlFechaRealizado = ControlFechaRealizado
        m_ControlTipoId = ControlTipoId
        m_ControlResultado = ControlResultado
        m_ControlCoincide = ControlCoincide
        m_ControlOpcMejora = ControlOpcMejora
        m_ControlNoConformidad = ControlNoConformidad
        m_ControlObservaciones = ControlObservaciones
        m_UsuarioId = UsuarioId
        m_ControlControlado = ControlControlado
        m_ControlInformeTipo = ControlInformeTipo
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pNGControl
        Return c.guardarControl(Me)
    End Function
    Public Function modificar() As Boolean
        Dim c As New pNGControl
        Return c.modificarControl(Me)
    End Function
    Public Function resultadoControl() As Boolean
        Dim c As New pNGControl
        Return c.resultadoControl(Me)
    End Function
    Public Function opcionMejoraControl() As Boolean
        Dim c As New pNGControl
        Return c.opcionMejoraControl(Me)
    End Function
    Public Function noConformidadControl() As Boolean
        Dim c As New pNGControl
        Return c.noConformidadControl(Me)
    End Function
    Public Function coincideControl() As Boolean
        Dim c As New pNGControl
        Return c.coincideControl(Me)
    End Function

#End Region
End Class
