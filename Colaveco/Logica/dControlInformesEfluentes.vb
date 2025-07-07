Public Class dControlInformesEfluentes

    Inherits dControlBase

    '#Region "Atributos"
    '    Private m_id As Long
    '    Private m_fechacontrol As String
    '    Private m_ficha As Long
    '    Private m_fecha As String
    '    Private m_tipo As Integer
    '    Private m_resultado As Integer
    '    Private m_coincide As Integer
    '    Private m_om As Integer
    '    Private m_nc As Integer
    '    Private m_observaciones As String
    '    Private m_controlador As Integer
    '    Private m_controlado As Integer
    '#End Region

    '#Region "Getters y Setters"
    '    Public Property ID() As Long
    '        Get
    '            Return m_id
    '        End Get
    '        Set(ByVal value As Long)
    '            m_id = value
    '        End Set
    '    End Property
    '    Public Property FECHACONTROL() As String
    '        Get
    '            Return m_fechacontrol
    '        End Get
    '        Set(ByVal value As String)
    '            m_fechacontrol = value
    '        End Set
    '    End Property
    '    Public Property FICHA() As Long
    '        Get
    '            Return m_ficha
    '        End Get
    '        Set(ByVal value As Long)
    '            m_ficha = value
    '        End Set
    '    End Property
    '    Public Property FECHA() As String
    '        Get
    '            Return m_fecha
    '        End Get
    '        Set(ByVal value As String)
    '            m_fecha = value
    '        End Set
    '    End Property
    '    Public Property TIPO() As Integer
    '        Get
    '            Return m_tipo
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_tipo = value
    '        End Set
    '    End Property
    '    Public Property RESULTADO() As Integer
    '        Get
    '            Return m_resultado
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_resultado = value
    '        End Set
    '    End Property
    '    Public Property COINCIDE() As Integer
    '        Get
    '            Return m_coincide
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_coincide = value
    '        End Set
    '    End Property
    '    Public Property OM() As Integer
    '        Get
    '            Return m_om
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_om = value
    '        End Set
    '    End Property
    '    Public Property NC() As Integer
    '        Get
    '            Return m_nc
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_nc = value
    '        End Set
    '    End Property
    '    Public Property OBSERVACIONES() As String
    '        Get
    '            Return m_observaciones
    '        End Get
    '        Set(ByVal value As String)
    '            m_observaciones = value
    '        End Set
    '    End Property
    '    Public Property CONTROLADOR() As Integer
    '        Get
    '            Return m_controlador
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_controlador = value
    '        End Set
    '    End Property
    '    Public Property CONTROLADO() As Integer
    '        Get
    '            Return m_controlado
    '        End Get
    '        Set(ByVal value As Integer)
    '            m_controlado = value
    '        End Set
    '    End Property

    '#End Region

    '#Region "Constructores"
    '    Public Sub New()
    '        m_id = 0
    '        m_fechacontrol = Now
    '        m_ficha = 0
    '        m_fecha = Now
    '        m_tipo = 0
    '        m_resultado = 0
    '        m_coincide = 0
    '        m_om = 0
    '        m_nc = 0
    '        m_observaciones = ""
    '        m_controlador = 0
    '        m_controlado = 0
    '    End Sub
    '    Public Sub New(ByVal id As Long, ByVal fechacontrol As String, ByVal ficha As Long, ByVal fecha As String, ByVal tipo As Integer, ByVal resultado As Integer, ByVal coincide As Integer, ByVal om As Integer, ByVal nc As Integer, ByVal observaciones As String, ByVal controlador As Integer, ByVal controlado As Integer)
    '        m_id = id
    '        m_fechacontrol = fechacontrol
    '        m_ficha = ficha
    '        m_fecha = fecha
    '        m_tipo = tipo
    '        m_resultado = resultado
    '        m_coincide = coincide
    '        m_om = om
    '        m_nc = nc
    '        m_observaciones = observaciones
    '        m_controlador = controlador
    '        m_controlado = controlado
    '    End Sub
    '#End Region

#Region "Métodos ABM"
    Public Overrides Function guardar() As Boolean
        Dim c As New pControlInformesEfluentes
        Return c.guardar(Me)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlInformesEfluentes
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlInformesEfluentes
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dControlInformesEfluentes
        Dim c As New pControlInformesEfluentes
        Return c.buscar(Me)
    End Function
    Public Function buscarxficha() As dControlInformesEfluentes
        Dim c As New pControlInformesEfluentes
        Return c.buscarxficha(Me)
    End Function

#End Region

    'Public Overrides Function tostring() As String
    '    Return m_ficha
    'End Function
    Public Function listar() As ArrayList
        Dim c As New pControlInformesEfluentes
        Return c.listar
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControlInformesEfluentes
        Return c.listarxfecha(desde, hasta)
    End Function
    Public Overrides Function listarxtipoxfecha(ByVal tipo As String, ByVal desde As String, ByVal hasta As String, ByVal ficha As Long) As ArrayList
        Dim c As New pControlInformesEfluentes
        Return c.listarxtipoxfecha(tipo, desde, hasta, ficha)
    End Function
    Public Function listarxfechanc(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControlInformesEfluentes
        Return c.listarxfechanc(desde, hasta)
    End Function
    Public Function listarxfechaom(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControlInformesEfluentes
        Return c.listarxfechaom(desde, hasta)
    End Function
    Public Function marcarresultado(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.marcarresultado(Me, usuario)
    End Function
    Public Function desmarcarresultado(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.desmarcarresultado(Me, usuario)
    End Function
    Public Function marcarcoincide(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.marcarcoincide(Me, usuario)
    End Function
    Public Function desmarcarcoincide(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.desmarcarcoincide(Me, usuario)
    End Function
    Public Function marcarom(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.marcarom(Me, usuario)
    End Function
    Public Function desmarcarom(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.desmarcarom(Me, usuario)
    End Function
    Public Function marcarnc(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.marcarnc(Me, usuario)
    End Function
    Public Function desmarcarnc(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.desmarcarnc(Me, usuario)
    End Function
    Public Function marcarcontrolada(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.marcarcontrolada(Me, usuario)
    End Function
    Public Function guardarobservaciones(ByVal usuario As dUsuario, ByVal obs As String) As Boolean
        Dim ci As New pControlInformesEfluentes
        Return ci.guardarobservaciones(Me, usuario, obs)
    End Function

    
End Class
