Public Class dSinaveleFicha
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_sinavele As Long
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
    Public Property SINAVELE() As Long
        Get
            Return m_sinavele
        End Get
        Set(ByVal value As Long)
            m_sinavele = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_sinavele = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal sinavele As Long)
        m_id = id
        m_ficha = ficha
        m_sinavele = sinavele
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSinaveleFicha
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSinaveleFicha
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSinaveleFicha
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSinaveleFicha
        Dim p As New pSinaveleFicha
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pSinaveleFicha
        Return p.listar
    End Function
End Class
