Public Class dTecnicoMuestreo

    'Estatus
    'Eliminado = 1
    'Activo = 2

#Region "Atributos"
    Private m_tecnico_muestreo_id As Long
    Private m_nombre As String
    Private m_apellido As String
    Private m_estatus As Integer
#End Region

    Public Property TECNICO_MUESTREO_ID() As Long
        Get
            Return m_tecnico_muestreo_id
        End Get
        Set(ByVal value As Long)
            m_tecnico_muestreo_id = value
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

    Public Property APELLIDO() As String
        Get
            Return m_apellido
        End Get
        Set(ByVal value As String)
            m_apellido = value
        End Set
    End Property

    Public Property ESTATUS() As Integer
        Get
            Return m_estatus
        End Get
        Set(ByVal value As Integer)
            m_estatus = value
        End Set
    End Property

#Region "Constructores"
    Public Sub New()
        m_tecnico_muestreo_id = 0
        m_nombre = ""
        m_apellido = ""
        m_estatus = 0
    End Sub

    Public Sub New(ByVal tecnico_muestreo_id As Long, ByVal nombre As String, ByVal apellido As String, ByVal estatus As Integer)
        m_tecnico_muestreo_id = tecnico_muestreo_id
        m_nombre = nombre
        m_apellido = apellido
        m_estatus = estatus
    End Sub

    Public Overrides Function ToString() As String
        Return m_nombre + " " + m_apellido
    End Function

#End Region

    Public Function guardar(ByVal usuario As dUsuario) As Boolean 
        Dim p As New pTecnicoMuestreo
        Return p.guardar(Me)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTecnicoMuestreo
        Return p.modificar(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTecnicoMuestreo
        Return p.eliminar(Me)
    End Function
    Public Function buscarById() As dTecnicoMuestreo
        Dim p As New pTecnicoMuestreo
        Return p.buscarById(Me)
    End Function
    Public Function listarTodos() As ArrayList
        Dim p As New pTecnicoMuestreo
        Return p.listarTodos()
    End Function



End Class
