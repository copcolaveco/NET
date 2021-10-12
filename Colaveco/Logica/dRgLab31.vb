Public Class dRgLab31
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_hora As String
    Private m_equipo As String
    Private m_ficha As Long
    Private m_cantidad As Integer
    Private m_idtipoinforme As Integer
    Private m_operador As Integer
    Private m_temperatura As Double
    Private m_humedad As Double
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
    Public Property EQUIPO() As String
        Get
            Return m_equipo
        End Get
        Set(ByVal value As String)
            m_equipo = value
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
    Public Property CANTIDAD() As Integer
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Integer)
            m_cantidad = value
        End Set
    End Property
    Public Property IDTIPOINFORME() As Integer
        Get
            Return m_idtipoinforme
        End Get
        Set(ByVal value As Integer)
            m_idtipoinforme = value
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
    Public Property TEMPERATURA() As Double
        Get
            Return m_temperatura
        End Get
        Set(ByVal value As Double)
            m_temperatura = value
        End Set
    End Property
    Public Property HUMEDAD() As Double
        Get
            Return m_humedad
        End Get
        Set(ByVal value As Double)
            m_humedad = value
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
        m_equipo = ""
        m_ficha = 0
        m_cantidad = 0
        m_idtipoinforme = 0
        m_operador = 0
        m_temperatura = 0
        m_humedad = 0
        m_eliminado = 0
        m_observaciones = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal hora As String, ByVal equipo As String, ByVal ficha As Long, ByVal cantidad As Integer, ByVal idtipoinforme As Integer, ByVal operador As Integer, ByVal temperatura As Double, ByVal humedad As Double, ByVal eliminado As Integer, ByVal observaciones As String)
        m_id = id
        m_fecha = fecha
        m_hora = hora
        m_equipo = equipo
        m_ficha = ficha
        m_cantidad = cantidad
        m_idtipoinforme = idtipoinforme
        m_operador = operador
        m_temperatura = temperatura
        m_humedad = humedad
        m_eliminado = eliminado
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab31
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab31
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab31
        Return c.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab31
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dRgLab31
        Dim c As New pRgLab31
        Return c.buscar(Me)
    End Function
    Public Function buscarxficha() As dRgLab31
        Dim c As New pRgLab31
        Return c.buscarxficha(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pRgLab31
        Return c.listar
    End Function
End Class
