Public Class dErroresRobot
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_hora As String
    Private m_descripcion As String
    Private m_visto As Integer
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
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property VISTO() As Integer
        Get
            Return m_visto
        End Get
        Set(ByVal value As Integer)
            m_visto = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_hora = ""
        m_descripcion = ""
        m_visto = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal fecha As String, ByVal hora As String, ByVal descripcion As String, ByVal visto As Integer)
        m_id = id
        m_fecha = fecha
        m_hora = hora
        m_descripcion = descripcion
        m_visto = visto
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pErroresRobot
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pErroresRobot
        Return p.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim p As New pErroresRobot
        Return p.eliminar(Me)
    End Function
    Public Function buscar() As dErroresRobot
        Dim p As New pErroresRobot
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_descripcion
    End Function

    Public Function listar() As ArrayList
        Dim p As New pErroresRobot
        Return p.listar
    End Function
End Class
