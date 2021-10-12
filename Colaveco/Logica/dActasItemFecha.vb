Public Class dActasItemFecha
#Region "Atributos"
    Private m_id As Long
    Private m_idacta As Long
    Private m_fecha As String
    Private m_usuario As Integer
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
    Public Property IDACTA() As Long
        Get
            Return m_idacta
        End Get
        Set(ByVal value As Long)
            m_idacta = value
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
    Public Property USUARIO() As Integer
        Get
            Return m_usuario
        End Get
        Set(ByVal value As Integer)
            m_usuario = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idacta = 0
        m_fecha = ""
        m_usuario = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idacta As Long, ByVal fecha As String, ByVal usuario As Integer)
        m_id = id
        m_idacta = idacta
        m_fecha = fecha
        m_usuario = usuario
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActasItemFecha
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActasItemFecha
        Return s.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActasItemFecha
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dActasItemFecha
        Dim s As New pActasItemFecha
        Return s.buscar(Me)
    End Function

#End Region

    Public Overrides Function tostring() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim s As New pActasItemfecha
        Return s.listar
    End Function

    Public Function listarxidacta(ByVal idacta As Long) As ArrayList
        Dim s As New pActasItemFecha
        Return s.listarxidacta(idacta)
    End Function
End Class
