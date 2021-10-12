Public Class dGraficaRC
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_libre As Double
    Private m_posible As Double
    Private m_probable As Double
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
    Public Property LIBRE() As Double
        Get
            Return m_libre
        End Get
        Set(ByVal value As Double)
            m_libre = value
        End Set
    End Property
    Public Property POSIBLE() As Double
        Get
            Return m_posible
        End Get
        Set(ByVal value As Double)
            m_posible = value
        End Set
    End Property
    Public Property PROBABLE() As Double
        Get
            Return m_probable
        End Get
        Set(ByVal value As Double)
            m_probable = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_libre = 0
        m_posible = 0
        m_probable = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal libre As Double, ByVal posible As Double, ByVal probable As Double)
        m_id = id
        m_ficha = ficha
        m_libre = libre
        m_posible = posible
        m_probable = probable
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pGraficaRC
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pGraficaRC
        Return p.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim p As New pGraficaRC
        Return p.eliminar(Me)
    End Function
    Public Function buscar() As dGraficaRC
        Dim p As New pGraficaRC
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pGraficaRC
        Return p.listar
    End Function
End Class
