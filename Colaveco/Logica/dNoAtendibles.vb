Public Class dNoAtendibles
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_cliente As String
    Private m_telefono As String
    Private m_analisis As String
    Private m_cantidad As String
    Private m_observaciones As String
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property CLIENTE() As String
        Get
            Return m_cliente
        End Get
        Set(ByVal value As String)
            m_cliente = value
        End Set
    End Property
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
        End Set
    End Property
    Public Property ANALISIS() As String
        Get
            Return m_analisis
        End Get
        Set(ByVal value As String)
            m_analisis = value
        End Set
    End Property
    Public Property CANTIDAD() As String
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As String)
            m_cantidad = value
        End Set
    End Property
   
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
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
        m_fecha = ""
        m_cliente = ""
        m_telefono = ""
        m_analisis = ""
        m_cantidad = ""
        m_observaciones = ""
        m_usuario = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal cliente As String, ByVal telefono As String, ByVal analisis As String, ByVal cantidad As String, ByVal observaciones As String, ByVal usuario As Integer)
        m_id = id
        m_fecha = fecha
        m_cliente = cliente
        m_telefono = telefono
        m_analisis = analisis
        m_cantidad = cantidad
        m_observaciones = observaciones
        m_usuario = usuario
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoAtendibles
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoAtendibles
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoAtendibles
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNoAtendibles
        Dim p As New pNoAtendibles
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim p As New pNoAtendibles
        Return p.listar
    End Function
End Class
