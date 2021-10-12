Public Class dDimension
#Region "Atributos"
    Private m_id As Long
    Private m_nombre As String
    Private m_ano As Integer
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
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property ANO() As Integer
        Get
            Return m_ano
        End Get
        Set(ByVal value As Integer)
            m_ano = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_ano = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal ano As Integer)
        m_id = id
        m_nombre = nombre
        m_ano = ano
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim d As New pDimension
        Return d.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim d As New pDimension
        Return d.modificar(Me, usuario)
    End Function
    Public Function modificarnombre(ByVal usuario As dUsuario) As Boolean
        Dim d As New pDimension
        Return d.modificarnombre(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim d As New pDimension
        Return d.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dDimension
        Dim d As New pDimension
        Return d.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre '& " - " & m_ano
    End Function

    Public Function listar() As ArrayList
        Dim d As New pDimension
        Return d.listar
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim d As New pDimension
        Return d.listarxano(ano)
    End Function
End Class
