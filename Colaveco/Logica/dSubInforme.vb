Public Class dSubInforme
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_idtipoinforme As Integer
    Private m_generaplanilla As Integer
    Private m_titulo As String

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
    Public Property IDTIPOINFORME() As Integer
        Get
            Return m_idtipoinforme
        End Get
        Set(ByVal value As Integer)
            m_idtipoinforme = value
        End Set
    End Property
    Public Property GENERARPLANILLA() As Integer
        Get
            Return m_generaplanilla
        End Get
        Set(ByVal value As Integer)
            m_generaplanilla = value
        End Set
    End Property
    Public Property TITULO() As String
        Get
            Return m_titulo
        End Get
        Set(ByVal value As String)
            m_titulo = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_idtipoinforme = 0
        m_generaplanilla = 0
        m_titulo = ""

    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal idtipoinforme As Integer, ByVal generaplanilla As Integer, ByVal titulo As String)
        m_id = id
        m_nombre = nombre
        m_idtipoinforme = idtipoinforme
        m_generaplanilla = generaplanilla
        m_titulo = titulo
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSubInforme
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSubInforme
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSubInforme
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSubInforme
        Dim p As New pSubInforme
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pSubInforme
        Return p.listar
    End Function
    Public Function listarportipoinforme(ByVal texto As Integer) As ArrayList
        Dim s As New pSubInforme
        Return s.listarportipoinforme(texto)
    End Function
End Class
