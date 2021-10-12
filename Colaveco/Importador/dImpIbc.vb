Public Class dImpIbc
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As String
    Private m_muestra As String
    Private m_idibc As Integer
    Private m_ibc As Long
    Private m_rb As Integer
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
    Public Property FICHA() As String
        Get
            Return m_ficha
        End Get
        Set(ByVal value As String)
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
    Public Property IDIBC() As Integer
        Get
            Return m_idibc
        End Get
        Set(ByVal value As Integer)
            m_idibc = value
        End Set
    End Property
    Public Property IBC() As Long
        Get
            Return m_ibc
        End Get
        Set(ByVal value As Long)
            m_ibc = value
        End Set
    End Property
    Public Property RB() As Integer
        Get
            Return m_rb
        End Get
        Set(ByVal value As Integer)
            m_rb = value
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
        m_ficha = ""
        m_muestra = ""
        m_idibc = 0
        m_ibc = 0
        m_rb = 0
        m_fecha = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As String, ByVal muestra As String, ByVal idibc As Integer, _
                   ByVal ibc As Long, ByVal rb As Integer, ByVal fecha As String)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_idibc = idibc
        m_ibc = ibc
        m_rb = rb
        m_fecha = fecha
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pImpIbc
        Return c.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim c As New pImpIbc
        Return c.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim c As New pImpIbc
        Return c.eliminar(Me)
    End Function
    Public Function buscar() As dImpIbc
        Dim c As New pImpIbc
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pImpIbc
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pImpIbc
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pImpIbc
        Return c.listarporsolicitud(texto)
    End Function
End Class
