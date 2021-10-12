Public Class dPedidosFlorida
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_idproductor As Long
    Private m_direccion As String
    Private m_idagencia As Integer
    Private m_celular As String
    Private m_telefono As String
    Private m_email As String
    Private m_cconservante As Integer
    Private m_sconservante As Integer
    Private m_agua As Integer
    Private m_sangre As Integer
    Private m_observaciones As String
    Private m_marca As Integer
    Private m_estado As String
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property

    Public Property IDPRODUCTOR() As Long
        Get
            Return m_idproductor
        End Get
        Set(ByVal value As Long)
            m_idproductor = value
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
    Public Property IDAGENCIA() As Integer
        Get
            Return m_idagencia
        End Get
        Set(ByVal value As Integer)
            m_idagencia = value
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
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
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
    Public Property CCONSERVANTE() As Integer
        Get
            Return m_cconservante
        End Get
        Set(ByVal value As Integer)
            m_cconservante = value
        End Set
    End Property
    Public Property SCONSERVANTE() As Integer
        Get
            Return m_sconservante
        End Get
        Set(ByVal value As Integer)
            m_sconservante = value
        End Set
    End Property
    Public Property AGUA() As Integer
        Get
            Return m_agua
        End Get
        Set(ByVal value As Integer)
            m_agua = value
        End Set
    End Property
    Public Property SANGRE() As Integer
        Get
            Return m_sangre
        End Get
        Set(ByVal value As Integer)
            m_sangre = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property
    Public Property ESTADO() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = Now
        m_idproductor = 0
        m_direccion = ""
        m_idagencia = 0
        m_celular = ""
        m_telefono = ""
        m_email = ""
        m_cconservante = 0
        m_sconservante = 0
        m_agua = 0
        m_sangre = 0
        m_observaciones = ""
        m_marca = 0
        m_estado = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal idproductor As Long, ByVal direccion As String, ByVal idagencia As Integer, ByVal celular As String, ByVal telefono As String, ByVal email As String, ByVal cconservante As Integer, ByVal sconservante As Integer, ByVal agua As Integer, ByVal sangre As Integer, ByVal observaciones As String, ByVal marca As Integer, ByVal estado As String)
        m_id = id
        m_fecha = fecha
        m_idproductor = idproductor
        m_direccion = direccion
        m_idagencia = idagencia
        m_celular = celular
        m_telefono = telefono
        m_email = email
        m_cconservante = cconservante
        m_sconservante = sconservante
        m_agua = agua
        m_sangre = sangre
        m_observaciones = observaciones
        m_marca = marca
        m_estado = estado

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosFlorida
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosFlorida
        Return p.modificar(Me, usuario)
    End Function
    Public Function marcar() As Boolean
        Dim p As New pPedidosFlorida
        Return p.marcar(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosFlorida
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPedidosFlorida
        Dim p As New pPedidosFlorida
        Return p.buscar(Me)
    End Function
    Public Function buscarultimo() As dPedidosFlorida
        Dim p As New pPedidosFlorida
        Return p.buscarultimo(Me)
    End Function

#End Region

    Public Overrides Function tostring() As String
        Dim pr As New dCliente
        pr.ID = m_idproductor
        pr = pr.buscar

        Return m_fecha & " " & "-" & " " & pr.NOMBRE
    End Function
    Public Function listar() As ArrayList
        Dim p As New pPedidosFlorida
        Return p.listar
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim p As New pPedidosFlorida
        Return p.listarsinenviar
    End Function
End Class
