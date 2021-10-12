Public Class dCajasWeb
#Region "Atributos"
    Private m_id As Long
    Private m_codigo As String
    Private m_estado As Integer
    Private m_cliente As Long
    Private m_modcolaveco As Integer
    Private m_modflorida As Integer
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
    Public Property CLIENTE() As Long
        Get
            Return m_cliente
        End Get
        Set(ByVal value As Long)
            m_cliente = value
        End Set
    End Property
    Public Property MODCOLAVECO() As Integer
        Get
            Return m_modcolaveco
        End Get
        Set(ByVal value As Integer)
            m_modcolaveco = value
        End Set
    End Property
    Public Property MODFLORIDA() As Integer
        Get
            Return m_modflorida
        End Get
        Set(ByVal value As Integer)
            m_modflorida = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_codigo = ""
        m_estado = 0
        m_cliente = 0
        m_modcolaveco = 0
        m_modflorida = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal codigo As String, ByVal estado As Integer, ByVal cliente As Long, ByVal modcolaveco As Integer, ByVal modflorida As Integer)
        m_id = id
        m_codigo = codigo
        m_estado = estado
        m_cliente = cliente
        m_modcolaveco = modcolaveco
        m_modflorida = modflorida
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificarcaja(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.modificarcaja(Me, usuario)
    End Function
    Public Function marcarLaboratorio(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.marcarlaboratorio(Me, usuario)
    End Function
    Public Function marcarCliente(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.marcarCliente(Me, usuario)
    End Function
    Public Function marcarFlorida(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.marcarflorida(Me, usuario)
    End Function
    Public Function marcarCardal(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.marcarCardal(Me, usuario)
    End Function
    Public Function marcarCanelones(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.marcarCanelones(Me, usuario)
    End Function
    Public Function marcarDesaparecida(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.marcardesaparecida(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCajasWeb
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCajasWeb
        Dim c As New pCajasWeb
        Return c.buscar(Me)
    End Function
    Public Function buscarPorCodigo(ByVal codigo As String) As ArrayList
        Dim s As New pCajasWeb
        Return s.buscarPorCodigo(codigo)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_codigo
    End Function

    Public Function listar() As ArrayList
        Dim c As New pCajasWeb
        Return c.listar
    End Function
    Public Function listar2() As ArrayList
        Dim c As New pCajasWeb
        Return c.listar2
    End Function
    Public Function listarenLaboratorio() As ArrayList
        Dim c As New pCajasWeb
        Return c.listarenLaboratorio
    End Function
    Public Function listarenClientes() As ArrayList
        Dim c As New pCajasWeb
        Return c.listarenClientes
    End Function
    Public Function listarenFlorida() As ArrayList
        Dim c As New pCajasWeb
        Return c.listarenFlorida
    End Function
End Class
