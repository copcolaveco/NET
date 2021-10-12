Public Class dCrioscopia_Control
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_delta As Integer
    Private m_crioscopo As Integer
    Private m_marca As Integer


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
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property DELTA() As Integer
        Get
            Return m_delta
        End Get
        Set(ByVal value As Integer)
            m_delta = value
        End Set
    End Property
    Public Property CRIOSCOPO() As Integer
        Get
            Return m_crioscopo
        End Get
        Set(ByVal value As Integer)
            m_crioscopo = value
        End Set
    End Property
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property


#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_muestra = ""
        m_delta = 0
        m_crioscopo = 0
        m_marca = 0


    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal delta As Integer, ByVal crioscopo As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_delta = delta
        m_crioscopo = crioscopo
        m_marca = marca

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Control
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Control
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Control
        Return c.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Control
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCrioscopia_Control
        Dim c As New pCrioscopia_Control
        Return c.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dCrioscopia_Control
        Dim c As New pCrioscopia_Control
        Return c.buscarxfichaxmuestra(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pCrioscopia_Control
        Return c.listar
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim c As New pCrioscopia_Control
        Return c.listarsinmarcar
    End Function
End Class
