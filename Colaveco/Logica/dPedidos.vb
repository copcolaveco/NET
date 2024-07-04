Public Class dPedidos
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_fechaposenvio As String
    Private m_idproductor As Long
    Private m_direccion As String
    Private m_telefono As String
    Private m_idagencia As Integer
    Private m_idtecnico As Integer
    Private m_responsable As String
    Private m_rc_compos As Integer
    Private m_agua As Integer
    Private m_sangre As Integer
    Private m_esteriles As Integer
    Private m_otros As Integer
    Private m_observaciones As String
    Private m_factura1 As Long
    Private m_cantidad1 As Integer
    Private m_factura2 As Long
    Private m_cantidad2 As Integer
    Private m_factura3 As Long
    Private m_cantidad3 As Integer
    Private m_enviado As Integer
    Private m_facturado As Integer
    Private m_eliminado As Integer
    Private m_idusuario As Integer
    Private m_convenio As Integer
    Private m_pendiente As Integer
    Private m_marca As Integer
    Private m_status As Integer
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
    Public Property FECHAPOSENVIO() As String
        Get
            Return m_fechaposenvio
        End Get
        Set(ByVal value As String)
            m_fechaposenvio = value
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
    Public Property RESPONSABLE() As String
        Get
            Return m_responsable
        End Get
        Set(ByVal value As String)
            m_responsable = value
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
    Public Property FACTURA1() As Long
        Get
            Return m_factura1
        End Get
        Set(ByVal value As Long)
            m_factura1 = value
        End Set
    End Property
    Public Property CANTIDAD1() As Integer
        Get
            Return m_cantidad1
        End Get
        Set(ByVal value As Integer)
            m_cantidad1 = value
        End Set
    End Property
    Public Property FACTURA2() As Long
        Get
            Return m_factura2
        End Get
        Set(ByVal value As Long)
            m_factura2 = value
        End Set
    End Property
    Public Property CANTIDAD2() As Integer
        Get
            Return m_cantidad2
        End Get
        Set(ByVal value As Integer)
            m_cantidad2 = value
        End Set
    End Property
    Public Property FACTURA3() As Long
        Get
            Return m_factura3
        End Get
        Set(ByVal value As Long)
            m_factura3 = value
        End Set
    End Property
    Public Property CANTIDAD3() As Integer
        Get
            Return m_cantidad3
        End Get
        Set(ByVal value As Integer)
            m_cantidad3 = value
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
    Public Property FACTURADO() As Integer
        Get
            Return m_facturado
        End Get
        Set(ByVal value As Integer)
            m_facturado = value
        End Set
    End Property
    Public Property ELIMINADO() As Integer
        Get
            Return m_eliminado
        End Get
        Set(ByVal value As Integer)
            m_eliminado = value
        End Set
    End Property
    Public Property IDUSUARIO() As Integer
        Get
            Return m_idusuario
        End Get
        Set(ByVal value As Integer)
            m_idusuario = value
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
    Public Property PENDIENTE() As Integer
        Get
            Return m_pendiente
        End Get
        Set(ByVal value As Integer)
            m_pendiente = value
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
    Public Property STATUS() As Integer
        Get
            Return m_status
        End Get
        Set(ByVal value As Integer)
            m_status = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = Now
        m_fechaposenvio = Now
        m_idproductor = 0
        m_direccion = ""
        m_telefono = ""
        m_idtecnico = 0
        m_responsable = ""
        m_idagencia = 0
        m_rc_compos = 0
        m_agua = 0
        m_sangre = 0
        m_esteriles = 0
        m_otros = 0
        m_observaciones = ""
        m_factura1 = 0
        m_cantidad1 = 0
        m_factura2 = 0
        m_cantidad2 = 0
        m_factura3 = 0
        m_cantidad3 = 0
        m_enviado = 0
        m_facturado = 0
        m_eliminado = 0
        m_idusuario = 0
        m_convenio = 0
        m_pendiente = 0
        m_marca = 0
        m_status = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal fechaposenvio As String, ByVal idproductor As Long, ByVal direccion As String, ByVal telefono As String, ByVal idtecnico As Integer, ByVal responsable As String, ByVal idagencia As Integer, ByVal rc_compos As Integer, ByVal agua As Integer, ByVal sangre As Integer, ByVal esteriles As Integer, ByVal otros As Integer, ByVal observaciones As String, ByVal factura1 As Long, ByVal cantidad1 As Integer, ByVal factura2 As Long, ByVal cantidad2 As Integer, ByVal factura3 As Long, ByVal cantidad3 As Integer, ByVal enviado As Integer, ByVal facturado As Integer, ByVal eliminado As Integer, ByVal idusuario As Integer, ByVal convenio As Integer, ByVal pendiente As Integer, ByVal marca As Integer, ByVal status As Integer)
        m_id = id
        m_fecha = fecha
        m_fechaposenvio = fechaposenvio
        m_idproductor = idproductor
        m_direccion = direccion
        m_telefono = telefono
        m_idtecnico = idtecnico
        m_responsable = responsable
        m_idagencia = idagencia
        m_rc_compos = rc_compos
        m_agua = agua
        m_sangre = sangre
        m_esteriles = esteriles
        m_otros = otros
        m_observaciones = observaciones
        m_factura1 = factura1
        m_cantidad1 = cantidad1
        m_factura2 = factura2
        m_cantidad2 = cantidad2
        m_factura3 = factura3
        m_cantidad3 = cantidad3
        m_enviado = enviado
        m_facturado = facturado
        m_eliminado = eliminado
        m_idusuario = idusuario
        m_convenio = convenio
        m_pendiente = pendiente
        m_marca = marca
        m_status = status
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPedidos
        Dim p As New pPedidos
        Return p.buscar(Me)
    End Function
    Public Function buscarPorFecha(ByVal pfecha As String) As ArrayList
        Dim s As New pPedidos
        Return s.buscarPorFecha(pfecha)
    End Function
#End Region

    Public Overrides Function tostring() As String
        Dim pr As New dCliente
        pr.ID = m_idproductor
        pr = pr.buscar

        Return m_fechaposenvio & " " & "-" & " " & pr.NOMBRE
    End Function
    Public Function listar() As ArrayList
        Dim p As New pPedidos
        Return p.listar
    End Function
    Public Function listarpendientes() As ArrayList
        Dim p As New pPedidos
        Return p.listarpendientes
    End Function
    Public Function listarfrascospormes(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPedidos
        Return p.listarfrascospormes(desde, hasta)
    End Function
    Public Function marcarEnvio(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.marcarEnvio(idPedido, usuario)
    End Function
    Public Function desmarcarPedido(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.desmarcarPedido(idPedido, usuario)
    End Function
    Public Function marcar(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.marcar(idPedido, usuario)
    End Function
    Public Function marcarFacturado(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.marcarFacturado(idPedido, usuario)
    End Function
    Public Function marcarpendiente(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.marcarpendiente(idPedido, usuario)
    End Function
    Public Function desmarcarpendiente(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pPedidos
        Return p.desmarcarpendiente(idPedido, usuario)
    End Function
    Public Function listarxcliente(ByVal texto As Long) As ArrayList
        Dim p As New pPedidos
        Return p.listarxcliente(texto)
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPedidos
        Return p.listarporfecha(desde, hasta)
    End Function
    Public Function listarporfecharc(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pPedidos
        Return p.listarporfecharc(desde, hasta)
    End Function
    Public Function listarporfechaxcliente(ByVal desde As String, ByVal hasta As String, ByVal cliente As Long) As ArrayList
        Dim p As New pPedidos
        Return p.listarporfechaxcliente(desde, hasta, cliente)
    End Function
    Public Function listarporcliente(ByVal cliente As Long) As ArrayList
        Dim p As New pPedidos
        Return p.listarporcliente(cliente)
    End Function
    Public Function listarsinfacturarsangre() As ArrayList
        Dim p As New pPedidos
        Return p.listarsinfacturarsangre()
    End Function
    Public Function listarsinfacturaragua() As ArrayList
        Dim p As New pPedidos
        Return p.listarsinfacturaragua()
    End Function
    Public Function listarPedidosFinalizados() As ArrayList
        Dim p As New pPedidos
        Return p.listarPedidosFinalizados()
    End Function

End Class
