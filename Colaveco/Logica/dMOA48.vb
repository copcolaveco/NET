Public Class dMOA48
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_orden As Integer
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
    Public Property ORDEN() As Integer
        Get
            Return m_orden
        End Get
        Set(ByVal value As Integer)
            m_orden = value
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
        m_orden = 0
        m_eliminado = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal orden As Integer, ByVal eliminado As Integer)
        m_id = id
        m_nombre = nombre
        m_orden = orden
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMOA48
        Return m.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMOA48
        Return m.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMOA48
        Return m.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMOA48
        Dim m As New pMOA48
        Return m.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim m As New pMOA48
        Return m.listar
    End Function
End Class
