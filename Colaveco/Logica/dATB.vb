Public Class dATB
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_aislamiento As Integer
    Private m_atb As Integer
    Private m_resistencia As String
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
    Public Property AISLAMIENTO() As Integer
        Get
            Return m_aislamiento
        End Get
        Set(ByVal value As Integer)
            m_aislamiento = value
        End Set
    End Property
    Public Property ATB() As Integer
        Get
            Return m_atb
        End Get
        Set(ByVal value As Integer)
            m_atb = value
        End Set
    End Property
    Public Property RESISTENCIA() As String
        Get
            Return m_resistencia
        End Get
        Set(ByVal value As String)
            m_resistencia = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_muestra = ""
        m_aislamiento = 0
        m_atb = 0
        m_resistencia = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal aislamiento As Integer, ByVal atb As Integer, ByVal resistencia As String)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_aislamiento = aislamiento
        m_atb = atb
        m_resistencia = resistencia
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pATB
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pATB
        Return s.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pATB
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dATB
        Dim s As New pATB
        Return s.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dATB
        Dim s As New pATB
        Return s.buscarxfichaxmuestra(Me)
    End Function
    Public Function buscarxfichaxmuestra2() As dATB
        Dim s As New pATB
        Return s.buscarxfichaxmuestra2(Me)
    End Function
#End Region

    Public Overrides Function tostring() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim s As New pATB
        Return s.listar
    End Function
    Public Function listardiferentes(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim s As New pATB
        Return s.listardiferentes(ficha, muestra)
    End Function
    Public Function listarxfichaxmuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim s As New pATB
        Return s.listarxfichaxmuestra(ficha, muestra)
    End Function
    Public Function listarxficha(ByVal ficha As Long) As ArrayList
        Dim s As New pATB
        Return s.listarxficha(ficha)
    End Function
    Public Function listarxfichaDesdeHasta(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim s As New pATB
        Return s.listarxfichaDesdeHasta(desde, hasta)
    End Function
    Public Function listar_muestras(ByVal idATB As Long) As ArrayList
        Dim s As New pATB
        Return s.listar_muestras(idATB)
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim s As New pATB
        Return s.listarporfecha(desde, hasta)
    End Function
End Class
