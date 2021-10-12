Public Class dFeriados
#Region "Atributos"
    Private m_id As Integer
    Private m_fecha As String
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
   
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
   
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal fecha As String)
        m_id = id
        m_fecha = fecha

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pFeriados
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pFeriados
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pFeriados
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dFeriados
        Dim p As New pFeriados
        Return p.buscar(Me)
    End Function
   
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pFeriados
        Return p.listar
    End Function
   
End Class
