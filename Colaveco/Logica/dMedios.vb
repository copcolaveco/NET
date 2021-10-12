Public Class dMedios
#Region "Atributos"
    Private m_endo35 As String
    Private m_mfc44_5 As String
    Private m_centrimide37 As String
    Private m_mhpc As String
    Private m_aguadedilucion As String
    Private m_nitrato As String
    Private m_nitrito As String
    Private m_dureza As String
#End Region

#Region "Getters y Setters"
    
    Public Property ENDO35() As String
        Get
            Return m_endo35
        End Get
        Set(ByVal value As String)
            m_endo35 = value
        End Set
    End Property
    Public Property MFC44_5() As String
        Get
            Return m_mfc44_5
        End Get
        Set(ByVal value As String)
            m_mfc44_5 = value
        End Set
    End Property
    Public Property CENTRIMIDE37() As String
        Get
            Return m_centrimide37
        End Get
        Set(ByVal value As String)
            m_centrimide37 = value
        End Set
    End Property
    Public Property MHPC() As String
        Get
            Return m_mhpc
        End Get
        Set(ByVal value As String)
            m_mhpc = value
        End Set
    End Property
    
    Public Property AGUADEDILUCION() As String
        Get
            Return m_aguadedilucion
        End Get
        Set(ByVal value As String)
            m_aguadedilucion = value
        End Set
    End Property
    Public Property NITRATO() As String
        Get
            Return m_nitrato
        End Get
        Set(ByVal value As String)
            m_nitrato = value
        End Set
    End Property
    Public Property NITRITO() As String
        Get
            Return m_nitrito
        End Get
        Set(ByVal value As String)
            m_nitrito = value
        End Set
    End Property
    Public Property DUREZA() As String
        Get
            Return m_dureza
        End Get
        Set(ByVal value As String)
            m_dureza = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_endo35 = ""
        m_mfc44_5 = ""
        m_centrimide37 = ""
        m_mhpc = ""
        m_aguadedilucion = ""
        m_nitrato = ""
        m_nitrito = ""
        m_dureza = ""
    End Sub
    Public Sub New(ByVal endo35 As String, ByVal mfc44_5 As String, ByVal centrimide37 As String, ByVal mhpc As String, ByVal aguadedilucion As String, ByVal nitrato As String, ByVal nitrito As String, ByVal dureza As String)
        m_endo35 = endo35
        m_mfc44_5 = mfc44_5
        m_centrimide37 = centrimide37
        m_mhpc = mhpc
        m_aguadedilucion = aguadedilucion
        m_nitrato = nitrato
        m_nitrito = nitrito
        m_dureza = dureza
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMedios
        Return m.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMedios
        Return m.modificar(Me, usuario)
    End Function
    
    Public Function buscar() As dMedios
        Dim m As New pMedios
        Return m.buscar(Me)
    End Function
#End Region


    Public Function listar() As ArrayList
        Dim m As New pMedios
        Return m.listar
    End Function
End Class
