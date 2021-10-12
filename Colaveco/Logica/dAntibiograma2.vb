Public Class dAntibiograma2
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_aislamiento As Integer
    Private m_antibiograma As Integer
    Private m_marca As Integer

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

    Public Property AISLAMIENTO() As Integer
        Get
            Return m_aislamiento
        End Get
        Set(ByVal value As Integer)
            m_aislamiento = value
        End Set
    End Property
    Public Property ANTIBIOGRAMA() As Integer
        Get
            Return m_antibiograma
        End Get
        Set(ByVal value As Integer)
            m_antibiograma = value
        End Set
    End Property
   
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property
    
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_aislamiento = 0
        m_antibiograma = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal aislamiento As Integer, _
                   ByVal antibiograma As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_aislamiento = aislamiento
        m_antibiograma = antibiograma
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a2 As New pAntibiograma2
        Return a2.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a2 As New pAntibiograma2
        Return a2.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a2 As New pAntibiograma2
        Return a2.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAntibiograma2
        Dim a2 As New pAntibiograma2
        Return a2.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim a2 As New pAntibiograma2
        Return a2.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim a2 As New pAntibiograma2
        Return a2.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a2 As New pAntibiograma2
        Return a2.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a2 As New pAntibiograma2
        Return a2.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a2 As New pAntibiograma2
        Return a2.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a2 As New pAntibiograma2
        Return a2.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
