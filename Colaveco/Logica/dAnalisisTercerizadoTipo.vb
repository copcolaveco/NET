Public Class dAnalisisTercerizadoTipo
#Region "Atributos"
    Private m_id As Integer
    Private m_idtipoinforme As Integer
    Private m_nombre As String
    Private m_metodo As String
    Private m_unidad As String
    Private m_depende As Integer
    Private m_orden As Integer
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
    Public Property IDTIPOINFORME() As Integer
        Get
            Return m_idtipoinforme
        End Get
        Set(ByVal value As Integer)
            m_idtipoinforme = value
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
    Public Property METODO() As String
        Get
            Return m_metodo
        End Get
        Set(ByVal value As String)
            m_metodo = value
        End Set
    End Property
    Public Property UNIDAD() As String
        Get
            Return m_unidad
        End Get
        Set(ByVal value As String)
            m_unidad = value
        End Set
    End Property
    Public Property DEPENDE() As Integer
        Get
            Return m_depende
        End Get
        Set(ByVal value As Integer)
            m_depende = value
        End Set
    End Property
    Public Property ORDEN() As Integer
        Get
            Return m_orden
        End Get
        Set(ByVal value As Integer)
            m_orden = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idtipoinforme = 0
        m_nombre = ""
        m_metodo = ""
        m_unidad = ""
        m_depende = 0
        m_orden = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal idtipoinforme As Integer, ByVal nombre As String, ByVal metodo As String, ByVal unidad As String, ByVal depende As Integer, ByVal orden As Integer)
        m_id = id
        m_idtipoinforme = idtipoinforme
        m_nombre = nombre
        m_metodo = metodo
        m_unidad = unidad
        m_depende = depende
        m_orden = orden
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisTercerizadoTipo
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisTercerizadoTipo
        Return p.modificar(Me, usuario)
    End Function
   
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisTercerizadoTipo
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAnalisisTercerizadoTipo
        Dim p As New pAnalisisTercerizadoTipo
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pAnalisisTercerizadoTipo
        Return p.listar
    End Function
    Public Function listarportipoinforme(ByVal texto As Integer) As ArrayList
        Dim s As New pAnalisisTercerizadoTipo
        Return s.listarportipoinforme(texto)
    End Function
    Public Function listardependientes(ByVal id As Integer) As ArrayList
        Dim s As New pAnalisisTercerizadoTipo
        Return s.listardependientes(id)
    End Function
End Class
