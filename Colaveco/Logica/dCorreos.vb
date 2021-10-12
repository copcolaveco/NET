Public Class dCorreos
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_informe As String
    Private m_cliente As String
    Private m_email As String
    Private m_texto As String
    Private m_adjunto As String
    Private m_enviado As Integer

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
    Public Property INFORME() As String
        Get
            Return m_informe
        End Get
        Set(ByVal value As String)
            m_informe = value
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
    Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property TEXTO() As String
        Get
            Return m_texto
        End Get
        Set(ByVal value As String)
            m_texto = value
        End Set
    End Property
    Public Property ADJUNTO() As String
        Get
            Return m_adjunto
        End Get
        Set(ByVal value As String)
            m_adjunto = value
        End Set
    End Property
    Public Property ENVIADO() As Integer
        Get
            Return m_enviado
        End Get
        Set(ByVal value As Integer)
            m_enviado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_informe = ""
        m_cliente = ""
        m_email = ""
        m_texto = ""
        m_adjunto = ""
        m_enviado = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal informe As String, ByVal cliente As String, ByVal email As String, ByVal texto As String, ByVal adjunto As String, ByVal enviado As String)
        m_id = id
        m_ficha = ficha
        m_informe = informe
        m_cliente = cliente
        m_email = email
        m_texto = texto
        m_adjunto = adjunto
        m_enviado = enviado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pCorreos
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pCorreos
        Return s.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pCorreos
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCorreos
        Dim s As New pCorreos
        Return s.buscar(Me)
    End Function
#End Region
    Public Overrides Function tostring() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim s As New pCorreos
        Return s.listar
    End Function
End Class
