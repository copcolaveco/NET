Public Class dMorosos
#Region "Atributos"
    Private m_cliente As String
    Private m_debe As Integer
#End Region

#Region "Getters y Setters"
    Public Property CLIENTE() As String
        Get
            Return m_cliente
        End Get
        Set(ByVal value As String)
            m_cliente = value
        End Set
    End Property
    Public Property DEBE() As Integer
        Get
            Return m_debe
        End Get
        Set(ByVal value As Integer)
            m_debe = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_cliente = ""
        m_debe = 0
    End Sub
    Public Sub New(ByVal cliente As String, ByVal debe As Integer)
        m_cliente = cliente
        m_debe = debe
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMorosos
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMorosos
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMorosos
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMorosos
        Dim p As New pMorosos
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_cliente
    End Function

    Public Function listar() As ArrayList
        Dim p As New pMorosos
        Return p.listar
    End Function
End Class
