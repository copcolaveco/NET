Public Class dCajas
#Region "Atributos"
    Private m_id As Long
    Private m_codigo As String
    Private m_estado As Integer
    Private m_idcliente As Long
    Private m_fecha As String
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
    
    Public Property CODIGO() As String
        Get
            Return m_codigo
        End Get
        Set(ByVal value As String)
            m_codigo = value
        End Set
    End Property
    Public Property ESTADO() As Integer
        Get
            Return m_estado
        End Get
        Set(ByVal value As Integer)
            m_estado = value
        End Set
    End Property
    Public Property IDCLIENTE() As Long
        Get
            Return m_idcliente
        End Get
        Set(ByVal value As Long)
            m_idcliente = value
        End Set
    End Property
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_codigo = ""
        m_estado = 0
        m_idcliente = 0
        m_fecha = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal codigo As String, ByVal estado As Integer, ByVal idcliente As Long, ByVal fecha As String)
        m_id = id
        m_codigo = codigo
        m_estado = estado
        m_idcliente = idcliente
        m_fecha = fecha
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificar2() As Boolean
        Dim c As New pCajas
        Return c.modificar2(Me)
    End Function
    Public Function marcarLaboratorio(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.marcarLaboratorio(Me, usuario)
    End Function
    Public Function marcarLaboratorioManual(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.marcarlaboratorioManual(Me, usuario)
    End Function
    Public Function marcarCliente(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.marcarCliente(Me, usuario)
    End Function
    Public Function marcarClienteFlorida(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.marcarclienteFlorida(Me, usuario)
    End Function
    Public Function marcarClienteCardal(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.marcarclienteCardal(Me, usuario)
    End Function
    Public Function marcarClienteCanelones(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.marcarclienteCanelones(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajas
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCajas
        Dim c As New pCajas
        Return c.buscar(Me)
    End Function
    Public Function buscarPorCodigo(ByVal codigo As String) As ArrayList
        Dim s As New pCajas
        Return s.buscarPorCodigo(codigo)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_codigo
    End Function

    Public Function listar() As ArrayList
        Dim c As New pCajas
        Return c.listar
    End Function
    Public Function listar2() As ArrayList
        Dim c As New pCajas
        Return c.listar2
    End Function
    Public Function listarenLaboratorio() As ArrayList
        Dim c As New pCajas
        Return c.listarenLaboratorio
    End Function
    Public Function listarenClientes() As ArrayList
        Dim c As New pCajas
        Return c.listarenClientes
    End Function
End Class
