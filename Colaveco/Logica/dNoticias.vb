Public Class dNoticias
#Region "Atributos"
    Private m_id As Integer
    Private m_descripcion As String
    Private m_mes As Integer
    Private m_dia As Integer
    Private m_diario As Integer
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
    Public Property MES() As Integer
        Get
            Return m_mes
        End Get
        Set(ByVal value As Integer)
            m_mes = value
        End Set
    End Property
    Public Property DIA() As Integer
        Get
            Return m_dia
        End Get
        Set(ByVal value As Integer)
            m_dia = value
        End Set
    End Property
    Public Property DIARIO() As Integer
        Get
            Return m_diario
        End Get
        Set(ByVal value As Integer)
            m_diario = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_descripcion = ""
        m_mes = 0
        m_dia = 0
        m_diario = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal mes As Integer, ByVal dia As Integer, ByVal diario As Integer)
        m_id = id
        m_descripcion = descripcion
        m_mes = mes
        m_dia = dia
        m_diario = diario
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoticias
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoticias
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoticias
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNoticias
        Dim p As New pNoticias
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_descripcion
    End Function

    Public Function listar() As ArrayList
        Dim p As New pNoticias
        Return p.listar
    End Function
    Public Function listarxfecha(ByVal dia As Integer, ByVal mes As Integer) As ArrayList
        Dim p As New pNoticias
        Return p.listarxfecha(dia, mes)
    End Function
End Class
