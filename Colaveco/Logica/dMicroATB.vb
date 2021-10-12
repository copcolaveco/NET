Public Class dMicroATB
#Region "Atributos"
    Private m_id As Integer
    Private m_micro As Integer
    Private m_atb As Integer
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
    Public Property MICRO() As Integer
        Get
            Return m_micro
        End Get
        Set(ByVal value As Integer)
            m_micro = value
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

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_micro = 0
        m_atb = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal micro As Integer, ByVal atb As Integer)
        m_id = id
        m_micro = micro
        m_atb = atb
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicroATB
        Return m.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicroATB
        Return m.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicroATB
        Return m.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMicroATB
        Dim m As New pMicroATB
        Return m.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim m As New pMicroATB
        Return m.listar
    End Function
    Public Function listarxmicro(ByVal idaislam As Integer) As ArrayList
        Dim m As New pMicroATB
        Return m.listarxmicro(idaislam)
    End Function
End Class
