Public Class dRelSolicitudMuestras
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fecha As String
    Private m_idtipoinforme As Integer
    Private m_idmuestra As String
    Private m_nocolaveco As Integer
    Private m_eliminado As Integer
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
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
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
    Public Property IDTIPOINFORME() As Integer
        Get
            Return m_idtipoinforme
        End Get
        Set(ByVal value As Integer)
            m_idtipoinforme = value
        End Set
    End Property
    Public Property IDMUESTRA() As String
        Get
            Return m_idmuestra
        End Get
        Set(ByVal value As String)
            m_idmuestra = value
        End Set
    End Property
    Public Property NOCOLAVECO() As Integer
        Get
            Return m_nocolaveco
        End Get
        Set(ByVal value As Integer)
            m_nocolaveco = value
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
        m_ficha = 0
        m_fecha = ""
        m_idmuestra = ""
        m_nocolaveco = 0
        m_eliminado = 0
        
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fecha As String, ByVal idtipoinforme As Integer, _
                   ByVal idmuestra As String, ByVal nocolaveco As Integer, ByVal eliminado As Integer)
        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_idtipoinforme = idtipoinforme
        m_idmuestra = idmuestra
        m_nocolaveco = nocolaveco
        m_eliminado = eliminado

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pRelSolicitudMuestras
        Return e.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pRelSolicitudMuestras
        Return e.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pRelSolicitudMuestras
        Return e.eliminar(Me, usuario)
    End Function
    Public Function eliminarxmuestra(ByVal usuario As dUsuario) As Boolean
        Dim e As New pRelSolicitudMuestras
        Return e.eliminarxmuestra(Me, usuario)
    End Function
    Public Function buscar() As dRelSolicitudMuestras
        Dim e As New pRelSolicitudMuestras
        Return e.buscar(Me)
    End Function
    Public Function buscarrepetidas() As dRelSolicitudMuestras
        Dim e As New pRelSolicitudMuestras
        Return e.buscarrepetidas(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String

        Return m_idmuestra

    End Function
    Public Function listar() As ArrayList
        Dim e As New pRelSolicitudMuestras
        Return e.listar
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim e As New pRelSolicitudMuestras
        Return e.listarporid(texto)
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim e As New pRelSolicitudMuestras
        Return e.listarporficha(texto)
    End Function
End Class
