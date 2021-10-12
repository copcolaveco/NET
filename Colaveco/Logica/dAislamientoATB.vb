Public Class dAislamientoATB
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_aislamiento As Integer
    Private m_atb As Integer
    Private m_resultado As Integer
    Private m_aislamiento2 As Integer
    Private m_atb2 As Integer
    Private m_resultado2 As Integer
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
    Public Property RESULTADO() As Integer
        Get
            Return m_resultado
        End Get
        Set(ByVal value As Integer)
            m_resultado = value
        End Set
    End Property
    Public Property AISLAMIENTO2() As Integer
        Get
            Return m_aislamiento2
        End Get
        Set(ByVal value As Integer)
            m_aislamiento2 = value
        End Set
    End Property
    Public Property ATB2() As Integer
        Get
            Return m_atb2
        End Get
        Set(ByVal value As Integer)
            m_atb2 = value
        End Set
    End Property
    Public Property RESULTADO2() As Integer
        Get
            Return m_resultado2
        End Get
        Set(ByVal value As Integer)
            m_resultado2 = value
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
        m_resultado = 0
        m_aislamiento2 = 0
        m_atb2 = 0
        m_resultado2 = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal aislamiento As Integer, ByVal atb As Integer, ByVal resultado As Integer, ByVal aislamiento2 As Integer, ByVal atb2 As Integer, ByVal resultado2 As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_aislamiento = aislamiento
        m_atb = atb
        m_resultado = resultado
        m_aislamiento = aislamiento
        m_atb = atb
        m_resultado = resultado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pAislamientoATB
        Return m.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pAislamientoATB
        Return m.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pAislamientoATB
        Return m.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAislamientoATB
        Dim m As New pAislamientoATB
        Return m.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim m As New pAislamientoATB
        Return m.listar
    End Function
End Class
