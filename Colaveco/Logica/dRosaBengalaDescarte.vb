Public Class dRosaBengalaDescarte
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fecha As String
    Private m_descartada As Integer
    Private m_fechad As String
    Private m_marcada As Integer
    Private m_fecham As String
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
    Public Property DESCARTADA() As Integer
        Get
            Return m_descartada
        End Get
        Set(ByVal value As Integer)
            m_descartada = value
        End Set
    End Property
    Public Property FECHAD() As String
        Get
            Return m_fechad
        End Get
        Set(ByVal value As String)
            m_fechad = value
        End Set
    End Property
    Public Property MARCADA() As Integer
        Get
            Return m_marcada
        End Get
        Set(ByVal value As Integer)
            m_marcada = value
        End Set
    End Property
    Public Property FECHAM() As String
        Get
            Return m_fecham
        End Get
        Set(ByVal value As String)
            m_fecham = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_fecha = ""
        m_descartada = 0
        m_fechad = ""
        m_marcada = 0
        m_fecham = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fecha As String, ByVal descartada As Integer, ByVal fechad As String, ByVal marcada As Integer, ByVal fecham As String)
        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_descartada = descartada
        m_fechad = fechad
        m_marcada = marcada
        m_fecham = fecham
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRosaBengalaDescarte
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRosaBengalaDescarte
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRosaBengalaDescarte
        Return p.eliminar(Me, usuario)
    End Function
    Public Function marcar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRosaBengalaDescarte
        Return p.marcar(Me, usuario)
    End Function
    Public Function descartar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pRosaBengalaDescarte
        Return p.descartar(Me, usuario)
    End Function
    Public Function buscar() As dRosaBengalaDescarte
        Dim p As New pRosaBengalaDescarte
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pRosaBengalaDescarte
        Return p.listar
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim p As New pRosaBengalaDescarte
        Return p.listarsinmarcar
    End Function
    Public Function listarsindescartar() As ArrayList
        Dim p As New pRosaBengalaDescarte
        Return p.listarsindescartar
    End Function
End Class
