Public Class dUltimoNumero
#Region "Atributos"
    Private m_inhibidores As Long
    Private m_fichas As Long
    Private m_pal As Long
    Private m_controlaux As Long
    Private m_leucosis As Long
    Private m_brucelosis As Long
    Private m_carpetapetri As String
    Private m_indexpetri As Integer
#End Region

#Region "Getters y Setters"
    Public Property INHIBIDORES() As Long
        Get
            Return m_inhibidores
        End Get
        Set(ByVal value As Long)
            m_inhibidores = value
        End Set
    End Property
    Public Property FICHAS() As Long
        Get
            Return m_fichas
        End Get
        Set(ByVal value As Long)
            m_fichas = value
        End Set
    End Property
    Public Property PAL() As Long
        Get
            Return m_pal
        End Get
        Set(ByVal value As Long)
            m_pal = value
        End Set
    End Property
    Public Property CONTROLAUX() As Long
        Get
            Return m_controlaux
        End Get
        Set(ByVal value As Long)
            m_controlaux = value
        End Set
    End Property
    Public Property LEUCOSIS() As Long
        Get
            Return m_leucosis
        End Get
        Set(ByVal value As Long)
            m_leucosis = value
        End Set
    End Property
    Public Property BRUCELOSIS() As Long
        Get
            Return m_brucelosis
        End Get
        Set(ByVal value As Long)
            m_brucelosis = value
        End Set
    End Property
    Public Property CARPETAPETRI() As String
        Get
            Return m_carpetapetri
        End Get
        Set(ByVal value As String)
            m_carpetapetri = value
        End Set
    End Property
    Public Property INDEXPETRI() As Integer
        Get
            Return m_indexpetri
        End Get
        Set(ByVal value As Integer)
            m_indexpetri = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_inhibidores = 0
        m_fichas = 0
        m_pal = 0
        m_controlaux = 0
        m_leucosis = 0
        m_brucelosis = 0
        m_carpetapetri = ""
        m_indexpetri = 0
    End Sub
    Public Sub New(ByVal fichas As Long, ByVal inhibidores As Long, ByVal pal As Long, ByVal controlaux As Long, ByVal leucosis As Long, ByVal brucelosis As Long, ByVal carpetapetri As String, ByVal indexpetri As Integer)
        m_fichas = fichas
        m_inhibidores = inhibidores
        m_pal = pal
        m_controlaux = controlaux
        m_leucosis = leucosis
        m_brucelosis = brucelosis
        m_carpetapetri = carpetapetri
        m_indexpetri = indexpetri

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pUltimoNumero
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pUltimoNumero
        Return p.modificar(Me)
    End Function
    Public Function modificarcontrol() As Boolean
        Dim p As New pUltimoNumero
        Return p.modificarcontrol(Me)
    End Function
    Public Function modificarleucosis() As Boolean
        Dim p As New pUltimoNumero
        Return p.modificarleucosis(Me)
    End Function
    Public Function modificarbrucelosis() As Boolean
        Dim p As New pUltimoNumero
        Return p.modificarbrucelosis(Me)
    End Function
    Public Function modificarpetri() As Boolean
        Dim p As New pUltimoNumero
        Return p.modificarpetri(Me)
    End Function
    
    Public Function buscar() As dUltimoNumero
        Dim p As New pUltimoNumero
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_fichas & " " & m_inhibidores
    End Function

    Public Function listar() As ArrayList
        Dim p As New pUltimoNumero
        Return p.listar
    End Function
End Class
