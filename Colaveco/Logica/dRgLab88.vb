Public Class dRgLab88
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_hora As String
    Private m_ficha As Long
    Private m_muestra As String
    Private m_crioscopo As Double
    Private m_delta As Double
    Private m_operador As Integer
    Private m_eliminado As Integer
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
    Public Property HORA() As String
        Get
            Return m_hora
        End Get
        Set(ByVal value As String)
            m_hora = value
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
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property CRIOSCOPO() As Double
        Get
            Return m_crioscopo
        End Get
        Set(ByVal value As Double)
            m_crioscopo = value
        End Set
    End Property
    Public Property DELTA() As Double
        Get
            Return m_delta
        End Get
        Set(ByVal value As Double)
            m_delta = value
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

    Public Property ELIMINADO() As Integer
        Get
            Return m_eliminado
        End Get
        Set(ByVal value As Integer)
            m_eliminado = value
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
        m_fecha = ""
        m_hora = ""
        m_ficha = 0
        m_muestra = ""
        m_crioscopo = 0
        m_delta = 0
        m_operador = 0
        m_eliminado = 0
        m_observaciones = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal hora As String, ByVal ficha As Long, ByVal muestra As String, ByVal crioscopo As Double, ByVal delta As Double, ByVal operador As Integer, ByVal eliminado As Integer, ByVal observaciones As String)
        m_id = id
        m_fecha = fecha
        m_hora = hora
        m_ficha = ficha
        m_muestra = muestra
        m_crioscopo = crioscopo
        m_delta = delta
        m_operador = operador
        m_eliminado = eliminado
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab88
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab88
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab88
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dRgLab88
        Dim c As New pRgLab88
        Return c.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dRgLab88
        Dim c As New pRgLab88
        Return c.buscarxfichaxmuestra(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pRgLab88
        Return c.listar
    End Function

End Class
