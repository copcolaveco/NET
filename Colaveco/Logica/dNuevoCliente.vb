Public Class dNuevoCliente
#Region "Atributos"
    Private m_id As Long
    Private m_pedido As Long
    Private m_envio As Long
    Private m_tipousuario As Integer
    Private m_nombre As String
    Private m_razon_social As String
    Private m_rut As String
    Private m_direccion As String
    Private m_idlocalidad As Integer
    Private m_iddepartamento As Integer
    Private m_dicose As String
    Private m_telefono As String
    Private m_celular As String
    Private m_email As String
    Private m_tecnico As Long
    Private m_direccionenvio As String
    Private m_idagencia As Integer
    Private m_cnombre As String
    Private m_ccelular As String
    Private m_ctelefono As String
    Private m_cemail As String
    Private m_enviado As Integer
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
    Public Property PEDIDO() As Long
        Get
            Return m_pedido
        End Get
        Set(ByVal value As Long)
            m_pedido = value
        End Set
    End Property
    Public Property ENVIO() As Long
        Get
            Return m_envio
        End Get
        Set(ByVal value As Long)
            m_envio = value
        End Set
    End Property
    Public Property TIPOUSUARIO() As String
        Get
            Return m_tipousuario
        End Get
        Set(ByVal value As String)
            m_tipousuario = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property RAZON_SOCIAL() As String
        Get
            Return m_razon_social
        End Get
        Set(ByVal value As String)
            m_razon_social = value
        End Set
    End Property
    Public Property RUT() As String
        Get
            Return m_rut
        End Get
        Set(ByVal value As String)
            m_rut = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property IDLOCALIDAD() As Integer
        Get
            Return m_idlocalidad
        End Get
        Set(ByVal value As Integer)
            m_idlocalidad = value
        End Set
    End Property
    Public Property IDDEPARTAMENTO() As Integer
        Get
            Return m_iddepartamento
        End Get
        Set(ByVal value As Integer)
            m_iddepartamento = value
        End Set
    End Property
    Public Property DICOSE() As String
        Get
            Return m_dicose
        End Get
        Set(ByVal value As String)
            m_dicose = value
        End Set
    End Property
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
        End Set
    End Property
    Public Property CELULAR() As String
        Get
            Return m_celular
        End Get
        Set(ByVal value As String)
            m_celular = value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property TECNICO() As Long
        Get
            Return m_tecnico
        End Get
        Set(ByVal value As Long)
            m_tecnico = value
        End Set
    End Property
    Public Property DIRECCIONENVIO() As String
        Get
            Return m_direccionenvio
        End Get
        Set(ByVal value As String)
            m_direccionenvio = value
        End Set
    End Property
    Public Property IDAGENCIA() As Integer
        Get
            Return m_idagencia
        End Get
        Set(ByVal value As Integer)
            m_idagencia = value
        End Set
    End Property
    Public Property CNOMBRE() As String
        Get
            Return m_cnombre
        End Get
        Set(ByVal value As String)
            m_cnombre = value
        End Set
    End Property
    Public Property CCELULAR() As String
        Get
            Return m_ccelular
        End Get
        Set(ByVal value As String)
            m_ccelular = value
        End Set
    End Property
    Public Property CTELEFONO() As String
        Get
            Return m_ctelefono
        End Get
        Set(ByVal value As String)
            m_ctelefono = value
        End Set
    End Property
    Public Property CEMAIL() As String
        Get
            Return m_cemail
        End Get
        Set(ByVal value As String)
            m_cemail = value
        End Set
    End Property
    Public Property ENVIADO() As Integer
        Get
            Return m_enviado
        End Get
        Set(ByVal value As Integer)
            m_enviado = value
        End Set
    End Property
#End Region
#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_pedido = 0
        m_envio = 0
        m_tipousuario = 0
        m_nombre = ""
        m_razon_social = ""
        m_rut = ""
        m_direccion = ""
        m_idlocalidad = 0
        m_iddepartamento = 0
        m_dicose = ""
        m_telefono = ""
        m_celular = ""
        m_email = ""
        m_tecnico = 0
        m_direccionenvio = ""
        m_idagencia = 0
        m_cnombre = ""
        m_ccelular = ""
        m_ctelefono = ""
        m_cemail = ""
        m_enviado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal pedido As Long, ByVal envio As Long, ByVal tipousuario As Integer, ByVal nombre As String, ByVal razon_social As String, ByVal rut As String, ByVal direccion As String, ByVal idlocalidad As Integer, ByVal iddepartamento As Integer, ByVal dicose As String, ByVal telefono As String, ByVal celular As String, ByVal email As String, ByVal tecnico As Long, ByVal direccionenvio As String, ByVal idagencia As Integer, ByVal cnombre As String, ByVal ccelular As String, ByVal ctelefono As String, ByVal cemail As String, ByVal enviado As Integer)
        m_id = id
        m_pedido = pedido
        m_envio = envio
        m_tipousuario = tipousuario
        m_nombre = nombre
        m_razon_social = razon_social
        m_rut = rut
        m_direccion = direccion
        m_idlocalidad = idlocalidad
        m_iddepartamento = iddepartamento
        m_dicose = dicose
        m_telefono = telefono
        m_celular = celular
        m_email = email
        m_tecnico = tecnico
        m_direccionenvio = direccionenvio
        m_idagencia = idagencia
        m_cnombre = cnombre
        m_ccelular = ccelular
        m_ctelefono = ctelefono
        m_cemail = cemail
        m_enviado = enviado

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pNuevoCliente
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pNuevoCliente
        Return c.modificar(Me, usuario)
    End Function
    Public Function marcarenviado() As Boolean
        Dim c As New pNuevoCliente
        Return c.marcarenviado(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pNuevoCliente
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNuevoCliente
        Dim c As New pNuevoCliente
        Return c.buscar(Me)
    End Function
    Public Function buscarultimo() As dNuevoCliente
        Dim c As New pNuevoCliente
        Return c.buscarultimo(Me)
    End Function
    Public Function buscarPorNombreTodos(ByVal pnombre As String) As ArrayList
        Dim s As New pNuevoCliente
        Return s.buscarPorNombreTodos(pnombre)
    End Function
    Public Function buscarPorNombre(ByVal pnombre As String) As ArrayList
        Dim s As New pNuevoCliente
        Return s.buscarPorNombre(pnombre)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function
    Public Function listar() As ArrayList
        Dim c As New pNuevoCliente
        Return c.listar
    End Function
    Public Function marcar() As Boolean
        Dim c As New pNuevoCliente
        Return c.marcar(Me)
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim c As New pNuevoCliente
        Return c.listarsinenviar
    End Function
End Class
