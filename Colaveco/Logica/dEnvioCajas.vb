Public Class dEnvioCajas
#Region "Atributos"
    Private m_id As Long
    Private m_idpedido As Long
    Private m_idproductor As Long
    Private m_idcaja As String
    Private m_gradilla1 As String
    Private m_gradilla2 As String
    Private m_gradilla3 As String
    Private m_frascos As Integer
    Private m_idempresa As Integer
    Private m_envio As String
    Private m_fechaenvio As String
    Private m_observaciones As String
    Private m_enviado As Integer
    Private m_idagencia As Integer
    Private m_recibo As String
    Private m_fecharecibo As String
    Private m_recibido As String
    Private m_cliente As Long
    Private m_obsrecibo As String
    Private m_responsable As Integer
    Private m_cargada As Integer
    Private m_convenio As Integer
    Private m_desembarcadas As Integer

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
    Public Property IDPEDIDO() As Long
        Get
            Return m_idpedido
        End Get
        Set(ByVal value As Long)
            m_idpedido = value
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
    Public Property IDCAJA() As String
        Get
            Return m_idcaja
        End Get
        Set(ByVal value As String)
            m_idcaja = value
        End Set
    End Property
    Public Property GRADILLA1() As String
        Get
            Return m_gradilla1
        End Get
        Set(ByVal value As String)
            m_gradilla1 = value
        End Set
    End Property
    Public Property GRADILLA2() As String
        Get
            Return m_gradilla2
        End Get
        Set(ByVal value As String)
            m_gradilla2 = value
        End Set
    End Property
    Public Property GRADILLA3() As String
        Get
            Return m_gradilla3
        End Get
        Set(ByVal value As String)
            m_gradilla3 = value
        End Set
    End Property
    Public Property FRASCOS() As Integer
        Get
            Return m_frascos
        End Get
        Set(ByVal value As Integer)
            m_frascos = value
        End Set
    End Property
    Public Property IDEMPRESA() As Integer
        Get
            Return m_idempresa
        End Get
        Set(ByVal value As Integer)
            m_idempresa = value
        End Set
    End Property
    Public Property ENVIO() As String
        Get
            Return m_envio
        End Get
        Set(ByVal value As String)
            m_envio = value
        End Set
    End Property
    Public Property FECHAENVIO() As String
        Get
            Return m_fechaenvio
        End Get
        Set(ByVal value As String)
            m_fechaenvio = value
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
    Public Property ENVIADO() As Integer
        Get
            Return m_enviado
        End Get
        Set(ByVal value As Integer)
            m_enviado = value
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
    Public Property RECIBO() As String
        Get
            Return m_recibo
        End Get
        Set(ByVal value As String)
            m_recibo = value
        End Set
    End Property
    Public Property FECHARECIBO() As String
        Get
            Return m_fecharecibo
        End Get
        Set(ByVal value As String)
            m_fecharecibo = value
        End Set
    End Property
    Public Property RECIBIDO() As Integer
        Get
            Return m_recibido
        End Get
        Set(ByVal value As Integer)
            m_recibido = value
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
    Public Property OBSRECIBO() As String
        Get
            Return m_obsrecibo
        End Get
        Set(ByVal value As String)
            m_obsrecibo = value
        End Set
    End Property
    Public Property RESPONSABLE() As Integer
        Get
            Return m_responsable
        End Get
        Set(ByVal value As Integer)
            m_responsable = value
        End Set
    End Property
    Public Property CARGADA() As Integer
        Get
            Return m_cargada
        End Get
        Set(ByVal value As Integer)
            m_cargada = value
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
    Public Property DESEMBARCADA() As Integer
        Get
            Return m_desembarcadas
        End Get
        Set(ByVal value As Integer)
            m_desembarcadas = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idpedido = 0
        m_idproductor = 0
        m_idcaja = ""
        m_gradilla1 = ""
        m_gradilla2 = ""
        m_gradilla3 = ""
        m_frascos = 0
        m_idempresa = 0
        m_envio = ""
        m_fechaenvio = ""
        m_observaciones = ""
        m_enviado = 0
        m_idagencia = 0
        m_recibo = ""
        m_fecharecibo = ""
        m_recibido = 0
        m_cliente = 0
        m_obsrecibo = ""
        m_responsable = 0
        m_cargada = 0
        m_convenio = 0
        m_desembarcadas = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idpedido As Long, ByVal idproductor As Long, ByVal idcaja As String, ByVal gradilla1 As String, ByVal gradilla2 As String, ByVal gradilla3 As String, ByVal frascos As Integer, ByVal idempresa As Integer, ByVal envio As String, ByVal fechaenvio As String, ByVal observaciones As String, ByVal enviado As Integer, ByVal idagencia As Integer, ByVal recibo As String, ByVal fecharecibo As String, ByVal recibido As Integer, ByVal cliente As Long, ByVal obsrecibo As String, ByVal responsable As Integer, ByVal cargada As Integer, ByVal convenio As Integer, ByVal desembarcada As Integer)
        m_id = id
        m_idpedido = idpedido
        m_idproductor = idproductor
        m_idcaja = idcaja
        m_gradilla1 = gradilla1
        m_gradilla2 = gradilla2
        m_gradilla3 = gradilla3
        m_frascos = frascos
        m_idempresa = idempresa
        m_envio = envio
        m_fechaenvio = fechaenvio
        m_observaciones = observaciones
        m_enviado = enviado
        m_idagencia = idagencia
        m_recibo = recibo
        m_fecharecibo = fecharecibo
        m_recibido = recibido
        m_cliente = cliente
        m_obsrecibo = obsrecibo
        m_responsable = responsable
        m_cargada = cargada
        m_convenio = convenio
        m_desembarcadas = desembarcada
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dEnvioCajas
        Dim e As New pEnvioCajas
        Return e.buscar(Me)
    End Function
    Public Function buscar2() As dEnvioCajas
        Dim e As New pEnvioCajas
        Return e.buscar2(Me)
    End Function
    Public Function buscarxenvio() As dEnvioCajas
        Dim e As New pEnvioCajas
        Return e.buscarxenvio(Me)
    End Function
  
#End Region

    Public Overrides Function ToString() As String

        Return m_idcaja & Chr(9) & m_gradilla1 & Chr(9) & m_gradilla2 & Chr(9) & m_gradilla3 & Chr(9) & m_frascos & Chr(9) & Chr(9) & m_envio

    End Function
    Public Function listar() As ArrayList
        Dim e As New pEnvioCajas
        Return e.listar
    End Function
    Public Function listarsinenvio() As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarsinenvio
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarporid(texto)
    End Function
    Public Function listarxcaja(ByVal caja As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarxcaja(caja)
    End Function
    Public Function listarxcaja_asc(ByVal caja As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarxcaja_asc(caja)
    End Function
    Public Function listarultimoenvio(ByVal caja As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarultimoenvio(caja)
    End Function
    Public Function listarxcajatodos(ByVal caja As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarxcajatodos(caja)
    End Function
    Public Function listarCajasEntradaManual(ByVal caja As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarCajasEntradaManual(caja)
    End Function
    Public Function listarPorFechaCajasEntradaManual(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarPorFechaCajasEntradaManual(desde, hasta)
    End Function
    Public Function listarxcajasindevolver(ByVal caja As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarxcajasindevolver(caja)
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarporfecha(desde, hasta)
    End Function
    Public Function listarporfechaxcliente(ByVal desde As String, ByVal hasta As String, ByVal cliente As Long) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarporfechaxcliente(desde, hasta, cliente)
    End Function
    Public Function listarporcliente(ByVal cliente As Long) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarporcliente(cliente)
    End Function
    Public Function listarxcliente(ByVal cliente As Long) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarxcliente(cliente)
    End Function

    Public Function marcarEnvio(ByVal idPedido As Integer, ByVal usuario As dUsuario) As Boolean
        Dim env As New pEnvioCajas
        Return env.marcarEnvio(idPedido, usuario)
    End Function
    Public Function buscarultimoenvio() As dEnvioCajas
        Dim e As New pEnvioCajas
        Return e.buscarultimoenvio(Me)
    End Function
    Public Function buscarultimoenvioxcaja() As dEnvioCajas
        Dim e As New pEnvioCajas
        Return e.buscarultimoenvioxcaja(Me)
    End Function
    Public Function listarsindevolver(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarsindevolver(desde, hasta)
    End Function
    Public Function listarsincargar() As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarsincargar()
    End Function
    Public Function listarsincargar2() As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarsincargar2()
    End Function
    Public Function listarcargadas() As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarcargadas()
    End Function
    Public Function listarcargadasPorFecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarcargadasPorFecha(desde, hasta)
    End Function
    Public Function listarverdessindevolver() As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarverdessindevolver()
    End Function
    Public Function listarsindevolver2(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarsindevolver2(desde, hasta)
    End Function
    Public Function marcarrecibido(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.marcarrecibido(Me, usuario)
    End Function
    Public Function completarenvio(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.completarenvio(Me, usuario)
    End Function
    Public Function marcarcargada(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.marcarcargada(Me, usuario)
    End Function
    Public Function desmarcarcargada(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.desmarcarcargada(Me, usuario)
    End Function

    Public Function modificarPedido(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.modificarPedido(Me, usuario)
    End Function
    Public Function cajaDesuso(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.cajaDesuso(Me, usuario)
    End Function

    Public Function modificarAgencia(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.modificarAgencia(Me, usuario)
    End Function
    Public Function finalizarPedido(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.finalizarPedido(Me, usuario)
    End Function

End Class
