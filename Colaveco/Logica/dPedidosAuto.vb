Public Class dPedidosAuto
#Region "Atributos"
    Private m_id As Long
    Private m_dia As Integer
    Private m_idproductor As Long
    Private m_direccion As String
    Private m_telefono As String
    Private m_idagencia As Integer
    Private m_idtecnico As Integer
    Private m_rc_compos As Integer
    Private m_agua As Integer
    Private m_sangre As Integer
    Private m_esteriles As Integer
    Private m_otros As Integer
    Private m_observaciones As String
    Private m_factura As Long
    Private m_enviado As Integer
    Private m_convenio As Integer
    Private m_suspendido As Integer
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
    Public Property DIA() As Integer
        Get
            Return m_dia
        End Get
        Set(ByVal value As Integer)
            m_dia = value
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
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
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
    Public Property IDTECNICO() As Integer
        Get
            Return m_idtecnico
        End Get
        Set(ByVal value As Integer)
            m_idtecnico = value
        End Set
    End Property
    Public Property RC_COMPOS() As Integer
        Get
            Return m_rc_compos
        End Get
        Set(ByVal value As Integer)
            m_rc_compos = value
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
    Public Property ESTERILES() As Integer
        Get
            Return m_esteriles
        End Get
        Set(ByVal value As Integer)
            m_esteriles = value
        End Set
    End Property
    Public Property OTROS() As Integer
        Get
            Return m_otros
        End Get
        Set(ByVal value As Integer)
            m_otros = value
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
    Public Property FACTURA() As Long
        Get
            Return m_factura
        End Get
        Set(ByVal value As Long)
            m_factura = value
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
    Public Property CONVENIO() As Integer
        Get
            Return m_convenio
        End Get
        Set(ByVal value As Integer)
            m_convenio = value
        End Set
    End Property
    Public Property SUSPENDIDO() As Integer
        Get
            Return m_suspendido
        End Get
        Set(ByVal value As Integer)
            m_suspendido = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_dia = 0
        m_idproductor = 0
        m_direccion = ""
        m_telefono = ""
        m_idtecnico = 0
        m_idagencia = 0
        m_rc_compos = 0
        m_agua = 0
        m_sangre = 0
        m_esteriles = 0
        m_otros = 0
        m_observaciones = ""
        m_factura = 0
        m_enviado = 0
        m_convenio = 0
        m_suspendido = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal dia As Integer, ByVal idproductor As Long, ByVal direccion As String, ByVal telefono As String, ByVal idtecnico As Integer, ByVal idagencia As Integer, ByVal rc_compos As Integer, ByVal agua As Integer, ByVal sangre As Integer, ByVal esteriles As Integer, ByVal otros As Integer, ByVal observaciones As String, ByVal factura As Long, ByVal enviado As Integer, ByVal convenio As Integer, ByVal suspendido As Integer)
        m_id = id
        m_dia = dia
        m_idproductor = idproductor
        m_direccion = direccion
        m_telefono = telefono
        m_idtecnico = idtecnico
        m_idagencia = idagencia
        m_rc_compos = rc_compos
        m_agua = agua
        m_sangre = sangre
        m_esteriles = esteriles
        m_otros = otros
        m_observaciones = observaciones
        m_factura = factura
        m_enviado = enviado
        m_convenio = convenio
        m_suspendido = suspendido
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosAuto
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosAuto
        Return p.modificar(Me, usuario)
    End Function
    Public Function activar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosAuto
        Return p.activar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosAuto
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPedidosAuto
        Dim p As New pPedidosAuto
        Return p.buscar(Me)
    End Function
    Public Function buscarxproductor() As dPedidosAuto
        Dim p As New pPedidosAuto
        Return p.buscarxproductor(Me)
    End Function
    
#End Region

    Public Overrides Function tostring() As String
        Dim pr As New dCliente
        pr.ID = m_idproductor
        pr = pr.buscar

        Return m_dia & " " & "-" & " " & pr.NOMBRE
    End Function
    Public Function listar() As ArrayList
        Dim p As New pPedidosAuto
        Return p.listar
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim p As New pPedidosAuto
        Return p.listarsinmarcar
    End Function
    Public Function listarpordia(ByVal texto As Integer) As ArrayList
        Dim p As New pPedidosAuto
        Return p.listarpordia(texto)
    End Function
    Public Function marcarEnvio(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosAuto
        Return p.marcarEnvio(idPedido, usuario)
    End Function
    Public Function desmarcarEnvio(ByVal iddia As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidosAuto
        Return p.desmarcarEnvio(iddia, usuario)
    End Function
    Public Function desmarcartodos() As Boolean
        Dim p As New pPedidosAuto
        Return p.desmarcartodos()
    End Function
End Class
