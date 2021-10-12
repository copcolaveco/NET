Public Class dIndicadores
#Region "Atributos"
    Private m_id As Long
    Private m_idactividad As Long
    Private m_mes As Integer
    Private m_indicador As Integer
    
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
    Public Property IDACTIVIDAD() As Long
        Get
            Return m_idactividad
        End Get
        Set(ByVal value As Long)
            m_idactividad = value
        End Set
    End Property
    Public Property MES() As Integer
        Get
            Return m_mes
        End Get
        Set(ByVal value As Integer)
            m_mes = value
        End Set
    End Property
    Public Property INDICADOR() As Integer
        Get
            Return m_indicador
        End Get
        Set(ByVal value As Integer)
            m_indicador = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idactividad = 0
        m_mes = 0
        m_indicador = 0
        
    End Sub
    Public Sub New(ByVal id As Long, ByVal idactividad As Long, ByVal mes As Integer, ByVal indicador As Integer)
        m_id = id
        m_idactividad = idactividad
        m_mes = mes
        m_indicador = indicador
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim i As New pIndicadores
        Return i.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim i As New pIndicadores
        Return i.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim i As New pIndicadores
        Return i.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim i As New pIndicadores
        Return i.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dIndicadores
        Dim i As New pIndicadores
        Return i.buscar(Me)
    End Function
    Public Function buscarxactividad() As dIndicadores
        Dim i As New pIndicadores
        Return i.buscarxactividad(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim i As New pIndicadores
        Return i.listar
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim i As New pIndicadores
        Return i.listarxano(ano)
    End Function
    Public Function listarxactividad(ByVal idact As Long) As ArrayList
        Dim i As New pIndicadores
        Return i.listarxactividad(idact)
    End Function
End Class
