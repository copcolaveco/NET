Public Class dTipoAntibiograma
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_eliminado As Integer
#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
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
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_eliminado = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal eliminado As Integer)
        m_id = id
        m_nombre = nombre
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTipoAntibiograma
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTipoAntibiograma
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTipoAntibiograma
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dTipoAntibiograma
        Dim p As New pTipoAntibiograma
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pTipoAntibiograma
        Return p.listar
    End Function
    Public Function listarDS() As DataSet
        Dim p As New pTipoAnalisis
        Return p.listarDS
    End Function
End Class
