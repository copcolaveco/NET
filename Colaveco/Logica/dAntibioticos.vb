Public Class dAntibioticos
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_abreviatura As String
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
    Public Property ABREVIATURA() As String
        Get
            Return m_abreviatura
        End Get
        Set(ByVal value As String)
            m_abreviatura = value
        End Set
    End Property
   
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_abreviatura = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal abreviatura As String)
        m_id = id
        m_nombre = nombre
        m_abreviatura = abreviatura
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pAntibioticos
        Return m.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pAntibioticos
        Return m.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pAntibioticos
        Return m.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAntibioticos
        Dim m As New pAntibioticos
        Return m.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim m As New pAntibioticos
        Return m.listar
    End Function
End Class
