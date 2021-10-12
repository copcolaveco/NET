Public Class dLicenciaAnual
#Region "Atributos"
    Private m_id As Long
    Private m_funcionario As Integer
    Private m_dias As Integer
    Private m_ano As Integer
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
    Public Property FUNCIONARIO() As Integer
        Get
            Return m_funcionario
        End Get
        Set(ByVal value As Integer)
            m_funcionario = value
        End Set
    End Property
    Public Property DIAS() As Integer
        Get
            Return m_dias
        End Get
        Set(ByVal value As Integer)
            m_dias = value
        End Set
    End Property
    Public Property ANO() As Integer
        Get
            Return m_ano
        End Get
        Set(ByVal value As Integer)
            m_ano = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_funcionario = 0
        m_dias = 0
        m_ano = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal funcionario As Integer, ByVal dias As Integer, ByVal ano As Integer)
        m_id = id
        m_funcionario = funcionario
        m_dias = dias
        m_ano = ano
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLicenciaAnual
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLicenciaAnual
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLicenciaAnual
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dLicenciaAnual
        Dim p As New pLicenciaAnual
        Return p.buscar(Me)
    End Function
    Public Function buscarxanoxusuario() As dLicenciaAnual
        Dim p As New pLicenciaAnual
        Return p.buscarxanoxusuario(Me)
    End Function
   
#End Region

    Public Overrides Function ToString() As String
        Return m_funcionario
    End Function

    Public Function listar() As ArrayList
        Dim p As New pLicenciaAnual
        Return p.listar
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim p As New pLicenciaAnual
        Return p.listarxano(ano)
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer, ByVal ano As Integer) As ArrayList
        Dim p As New pLicenciaAnual
        Return p.listarxusuario(idusuario, ano)
    End Function
End Class
