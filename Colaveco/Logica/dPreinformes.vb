Public Class dPreinformes
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_tipo As Integer
    Private m_creado As Integer
    Private m_abonado As Integer
    Private m_comentario As String
    Private m_copia As String
    Private m_parasubir As Integer
    Private m_subido As Integer
    Private m_fecha As String
    Private m_control As Integer
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
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
    Public Property TIPO() As Integer
        Get
            Return m_tipo
        End Get
        Set(ByVal value As Integer)
            m_tipo = value
        End Set
    End Property
    Public Property CREADO() As Integer
        Get
            Return m_creado
        End Get
        Set(ByVal value As Integer)
            m_creado = value
        End Set
    End Property
    Public Property ABONADO() As Integer
        Get
            Return m_abonado
        End Get
        Set(ByVal value As Integer)
            m_abonado = value
        End Set
    End Property
    Public Property COMENTARIO() As String
        Get
            Return m_comentario
        End Get
        Set(ByVal value As String)
            m_comentario = value
        End Set
    End Property
    Public Property COPIA() As String
        Get
            Return m_copia
        End Get
        Set(ByVal value As String)
            m_copia = value
        End Set
    End Property
    Public Property PARASUBIR() As String
        Get
            Return m_parasubir
        End Get
        Set(ByVal value As String)
            m_parasubir = value
        End Set
    End Property
    Public Property SUBIDO() As Integer
        Get
            Return m_subido
        End Get
        Set(ByVal value As Integer)
            m_subido = value
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
    Public Property CONTROL() As Integer
        Get
            Return m_control
        End Get
        Set(ByVal value As Integer)
            m_control = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_tipo = 0
        m_creado = 0
        m_abonado = 0
        m_comentario = ""
        m_copia = ""
        m_parasubir = 0
        m_subido = 0
        m_fecha = ""
        m_control = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal tipo As Integer, ByVal creado As Integer, ByVal abonado As Integer, ByVal comentario As String, ByVal copia As String, ByVal parasubir As Integer, ByVal subido As Integer, ByVal fecha As String, ByVal control As Integer)
        m_id = id
        m_ficha = ficha
        m_tipo = tipo
        m_creado = creado
        m_abonado = abonado
        m_comentario = comentario
        m_copia = copia
        m_parasubir = parasubir
        m_subido = subido
        m_fecha = fecha
        m_control = control
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pPreinformes
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pPreinformes
        Return p.modificar(Me)
    End Function
    Public Function modificar2() As Boolean
        Dim p As New pPreinformes
        Return p.modificar2(Me)
    End Function
    Public Function modificar3() As Boolean
        Dim p As New pPreinformes
        Return p.modificar3(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPreinformes
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPreinformes
        Dim p As New pPreinformes
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pPreinformes
        Return p.listar
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim p As New pPreinformes
        Return p.listarsinmarcar
    End Function
    Public Function listarsinmarcarcalidad() As ArrayList
        Dim p As New pPreinformes
        Return p.listarsinmarcarcalidad
    End Function
    Public Function listarsinmarcarcontrol() As ArrayList
        Dim p As New pPreinformes
        Return p.listarsinmarcarcontrol
    End Function
    Public Function listarsincontrolclechero(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPreinformes
        Return p.listarsincontrolclechero(desde, hasta)
    End Function
    Public Function listarsincontrolcalidad(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPreinformes
        Return p.listarsincontrolcalidad(desde, hasta)
    End Function
    Public Function listarsincontrolagua(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPreinformes
        Return p.listarsincontrolagua(desde, hasta)
    End Function
    Public Function listarsincontrolsubproductos(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPreinformes
        Return p.listarsincontrolsubproductos(desde, hasta)
    End Function
    Public Function listarparasubir() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubir
    End Function
    Public Function listarparasubidos(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubidos(desde, hasta)
    End Function

    Public Function listarparasubircontrol() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubircontrol
    End Function
    Public Function listarparasubiragua() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubiragua
    End Function
    Public Function listarparasubiratb() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubiratb
    End Function
    Public Function listarparasubirsubproductos() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubirsubproductos
    End Function
    Public Function listarparasubircalidad() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubircalidad
    End Function
    Public Function listarparasubirbrucelosis() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubirbrucelosis
    End Function
    Public Function listarparasubirmicro() As ArrayList
        Dim p As New pPreinformes
        Return p.listarparasubirmicro
    End Function
    Public Function listarsubidas() As ArrayList
        Dim p As New pPreinformes
        Return p.listarsubidas
    End Function
    Public Function marcarcreado() As Boolean
        Dim p As New pPreinformes
        Return p.marcarcreado(Me)
    End Function
    Public Function desmarcarcreadoysubir() As Boolean
        Dim p As New pPreinformes
        Return p.desmarcarcreadoysubir(Me)
    End Function
    Public Function marcarsubido(ByVal fecha As String) As Boolean
        Dim p As New pPreinformes
        Return p.marcarsubido(Me, fecha)
    End Function
    Public Function marcarcontrolado() As Boolean
        Dim p As New pPreinformes
        Return p.marcarcontrolado(Me)
    End Function
    Public Function buscarPorId(ByVal ficha As Integer) As dPreinformes
        Dim p As New pPreinformes
        Return p.buscarPorId(ficha)
    End Function
    Public Function ListaControlCalidad() As ArrayList
        Dim p As New pPreinformes
        Return p.ListaControlCalidad()
    End Function
    Public Function ModificarPreinforme(ByVal idTI As Integer, ByVal ficha As Integer) As Boolean
        Dim p As New pPreinformes
        Return p.ModificarPreinforme(idTI, ficha)
    End Function
End Class
