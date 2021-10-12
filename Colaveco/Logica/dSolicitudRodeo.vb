Public Class dSolicitudRodeo
#Region "Atributos"
    Private m_id As Long
    Private m_mastitis As String
    Private m_ficha As Long
    Private m_rodeo As Integer
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
    Public Property MASTITIS() As String
        Get
            Return m_mastitis
        End Get
        Set(ByVal value As String)
            m_mastitis = value
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
    Public Property RODEO() As Integer
        Get
            Return m_rodeo
        End Get
        Set(ByVal value As Integer)
            m_rodeo = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_mastitis = ""
        m_ficha = 0
        m_rodeo = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal mastitis As String, ByVal ficha As Long, ByVal rodeo As Integer)
        m_id = id
        m_mastitis = mastitis
        m_ficha = ficha
        m_rodeo = rodeo
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudRodeo
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudRodeo
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSolicitudRodeo
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSolicitudRodeo
        Dim p As New pSolicitudRodeo
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pSolicitudRodeo
        Return p.listar
    End Function
   
End Class
