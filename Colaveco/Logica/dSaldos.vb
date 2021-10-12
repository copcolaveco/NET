Public Class dSaldos
#Region "Atributos"
    Private m_idcliente As Long
    Private m_saldo As Double
#End Region

#Region "Getters y Setters"
    Public Property IDCLIENTE() As Long
        Get
            Return m_idcliente
        End Get
        Set(ByVal value As Long)
            m_idcliente = value
        End Set
    End Property
    Public Property SALDO() As Double
        Get
            Return m_saldo
        End Get
        Set(ByVal value As Double)
            m_saldo = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_idcliente = 0
        m_saldo = 0
    End Sub
    Public Sub New(ByVal idcliente As Long, ByVal saldo As Double)
        m_idcliente = idcliente
        m_saldo = saldo
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSaldos
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSaldos
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSaldos
        Return p.eliminar(Me, usuario)
    End Function
    Public Function eliminartodos(ByVal usuario As dUsuario) As Boolean
        Dim p As New pSaldos
        Return p.eliminartodos(Me, usuario)
    End Function
    Public Function buscar() As dSaldos
        Dim p As New pSaldos
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idcliente
    End Function

    Public Function listar() As ArrayList
        Dim p As New pSaldos
        Return p.listar
    End Function
End Class
