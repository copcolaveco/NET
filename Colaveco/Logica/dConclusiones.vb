Public Class dConclusiones
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_conclusion As String
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
    Public Property CONCLUSION() As String
        Get
            Return m_conclusion
        End Get
        Set(ByVal value As String)
            m_conclusion = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_conclusion = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal conclusion As String)
        m_id = id
        m_ficha = ficha
        m_conclusion = conclusion
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pConclusiones
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pConclusiones
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pConclusiones
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dConclusiones
        Dim p As New pConclusiones
        Return p.buscar(Me)
    End Function
  
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pConclusiones
        Return p.listar
    End Function
End Class
