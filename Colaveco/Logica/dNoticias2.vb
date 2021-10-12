Public Class dNoticias2
#Region "Atributos"
    Private m_id As Integer
    Private m_descripcion As String
    Private m_usuario As Integer
    Private m_mostrar As Integer
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
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property USUARIO() As Integer
        Get
            Return m_usuario
        End Get
        Set(ByVal value As Integer)
            m_usuario = value
        End Set
    End Property
    Public Property MOSTRAR() As Integer
        Get
            Return m_mostrar
        End Get
        Set(ByVal value As Integer)
            m_mostrar = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_descripcion = ""
        m_usuario = 0
        m_mostrar = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal usuario As Integer, ByVal mostrar As Integer)
        m_id = id
        m_descripcion = descripcion
        m_usuario = usuario
        m_mostrar = mostrar
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoticias2
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoticias2
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoticias2
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNoticias2
        Dim p As New pNoticias2
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Dim u As New dUsuario
        u.ID = m_usuario
        u = u.buscar
        Dim txt As String = ""
        If Not u Is Nothing Then
            txt = u.NOMBRE
        Else
            txt = "Todos"
        End If
        Return m_descripcion & " - " & txt
    End Function

    Public Function listar() As ArrayList
        Dim p As New pNoticias2
        Return p.listar
    End Function
    Public Function listargeneral() As ArrayList
        Dim p As New pNoticias2
        Return p.listargeneral
    End Function
    Public Function listarxusuario(ByVal usu As Integer) As ArrayList
        Dim p As New pNoticias2
        Return p.listarxusuario(usu)
    End Function
End Class
