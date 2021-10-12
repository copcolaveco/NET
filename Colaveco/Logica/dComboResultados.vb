Public Class dComboResultados
#Region "Atributos"
    Private m_id As Long
    Private m_analisis As Integer
    Private m_texto As String
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
    Public Property ANALISIS() As Integer
        Get
            Return m_analisis
        End Get
        Set(ByVal value As Integer)
            m_analisis = value
        End Set
    End Property
    Public Property TEXTO() As String
        Get
            Return m_texto
        End Get
        Set(ByVal value As String)
            m_texto = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_analisis = 0
        m_texto = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal analisis As Integer, ByVal texto As String)
        m_id = id
        m_analisis = analisis
        m_texto = texto
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pComboResultados
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pComboResultados
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pComboResultados
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dComboResultados
        Dim p As New pComboResultados
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_texto
    End Function

    Public Function listar() As ArrayList
        Dim p As New pComboResultados
        Return p.listar
    End Function
    Public Function listarxanalisis(ByVal idanalisis As Integer) As ArrayList
        Dim p As New pComboResultados
        Return p.listarxanalisis(idanalisis)
    End Function
End Class
