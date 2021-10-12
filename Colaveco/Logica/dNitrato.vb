Public Class dNitrato
#Region "Atributos"
    Private m_id As Integer
    Private m_valor As String
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
    Public Property VALOR() As String
        Get
            Return m_valor
        End Get
        Set(ByVal value As String)
            m_valor = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_valor = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal valor As String)
        m_id = id
        m_valor = valor
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNitrato
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNitrato
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNitrato
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNitrato
        Dim p As New pNitrato
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_valor
    End Function

    Public Function listar() As ArrayList
        Dim p As New pNitrato
        Return p.listar
    End Function
End Class
