Public Class dTareas
#Region "Atributos"
    Private m_id As Integer
    Private m_fecha As String
    Private m_descripcion As String
    Private m_finalizacion As String
    Private m_usuario As Integer
    Private m_sector As Integer
    Private m_creador As Integer
    Private m_realizada As Integer
    Private m_eliminada As Integer
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
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property FINALIZACION() As String
        Get
            Return m_finalizacion
        End Get
        Set(ByVal value As String)
            m_finalizacion = value
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
    Public Property SECTOR() As Integer
        Get
            Return m_sector
        End Get
        Set(ByVal value As Integer)
            m_sector = value
        End Set
    End Property
    Public Property CREADOR() As Integer
        Get
            Return m_creador
        End Get
        Set(ByVal value As Integer)
            m_creador = value
        End Set
    End Property
    Public Property REALIZADA() As Integer
        Get
            Return m_realizada
        End Get
        Set(ByVal value As Integer)
            m_realizada = value
        End Set
    End Property
    Public Property ELIMINADA() As Integer
        Get
            Return m_eliminada
        End Get
        Set(ByVal value As Integer)
            m_eliminada = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_descripcion = ""
        m_finalizacion = ""
        m_usuario = 0
        m_sector = 0
        m_creador = 0
        m_realizada = 0
        m_eliminada = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal fecha As String, ByVal descripcion As String, ByVal finalizacion As String, ByVal usuario As Integer, ByVal sector As Integer, ByVal creador As Integer, ByVal realizada As Integer, ByVal eliminada As Integer)
        m_id = id
        m_fecha = fecha
        m_descripcion = descripcion
        m_finalizacion = finalizacion
        m_usuario = usuario
        m_sector = sector
        m_creador = creador
        m_realizada = realizada
        m_eliminada = eliminada
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTareas
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTareas
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTareas
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dTareas
        Dim p As New pTareas
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_descripcion
    End Function

    Public Function listar() As ArrayList
        Dim p As New pTareas
        Return p.listar
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer) As ArrayList
        Dim p As New pTareas
        Return p.listarxusuario(idusuario)
    End Function
    Public Function listarxusuarior(ByVal idusuario As Integer) As ArrayList
        Dim p As New pTareas
        Return p.listarxusuarior(idusuario)
    End Function
    Public Function listarxsector(ByVal idsector As Integer) As ArrayList
        Dim p As New pTareas
        Return p.listarxsector(idsector)
    End Function
    Public Function listarxsectorr(ByVal idsector As Integer) As ArrayList
        Dim p As New pTareas
        Return p.listarxsectorr(idsector)
    End Function
    Public Function listargenerales(ByVal hoy As String) As ArrayList
        Dim p As New pTareas
        Return p.listargenerales(hoy)
    End Function
    Public Function listarxusuarioxcreador(ByVal idusuario As Integer, ByVal idcreador As Integer, ByVal idsector As Integer) As ArrayList
        Dim p As New pTareas
        Return p.listarxusuarioxcreador(idusuario, idcreador, idsector)
    End Function
End Class
