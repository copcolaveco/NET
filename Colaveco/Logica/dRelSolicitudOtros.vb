Public Class dRelSolicitudOtros
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As String
    Private m_descripcion As String
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
    Public Property FICHA() As String
        Get
            Return m_ficha
        End Get
        Set(ByVal value As String)
            m_ficha = value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = ""
        m_descripcion = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal ficha As String, ByVal descripcion As String)
        m_id = id
        m_ficha = ficha
        m_descripcion = descripcion

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRelSolicitudOtros
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRelSolicitudOtros
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRelSolicitudOtros
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dRelSolicitudOtros
        Dim p As New pRelSolicitudOtros
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pRelSolicitudOtros
        Return p.listar
    End Function
    Public Function listarporficha(ByVal ficha As String) As ArrayList
        Dim e As New pRelSolicitudOtros
        Return e.listarporficha(ficha)
    End Function
End Class
