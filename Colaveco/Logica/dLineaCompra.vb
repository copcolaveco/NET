Public Class dLineaCompra
#Region "Atributos"
    Private m_id As Long
    Private m_idcompra As Long
    Private m_producto As Integer
    Private m_unidad As Integer
    Private m_cantidad As Double
    Private m_presentacion As Integer
    Private m_precioant As Double
    Private m_monedaant As Integer
    Private m_fechaprecioant As String
    Private m_recibido As String
    Private m_factura As String
    Private m_lote As String
    Private m_vencimiento As String
    Private m_locacion As Integer
    Private m_precio As Double
    Private m_moneda As Integer
    Private m_nocumple As Integer
    Private m_apertura As Integer
    Private m_fechaapertura As String
    Private m_consumido As Integer
    Private m_fechaconsumido As String
    Private m_descartado As Integer
    Private m_fechadescartado As String
    Private m_observaciones As String

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
    Public Property IDCOMPRA() As Long
        Get
            Return m_idcompra
        End Get
        Set(ByVal value As Long)
            m_idcompra = value
        End Set
    End Property
    Public Property PRODUCTO() As Integer
        Get
            Return m_producto
        End Get
        Set(ByVal value As Integer)
            m_producto = value
        End Set
    End Property
    Public Property UNIDAD() As Integer
        Get
            Return m_unidad
        End Get
        Set(ByVal value As Integer)
            m_unidad = value
        End Set
    End Property
    Public Property CANTIDAD() As Double
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Double)
            m_cantidad = value
        End Set
    End Property
    Public Property PRESENTACION() As Integer
        Get
            Return m_presentacion
        End Get
        Set(ByVal value As Integer)
            m_presentacion = value
        End Set
    End Property
    Public Property PRECIOANT() As Double
        Get
            Return m_precioant
        End Get
        Set(ByVal value As Double)
            m_precioant = value
        End Set
    End Property
    Public Property MONEDAANT() As Integer
        Get
            Return m_monedaant
        End Get
        Set(ByVal value As Integer)
            m_monedaant = value
        End Set
    End Property
    Public Property FECHAPRECIOANT() As String
        Get
            Return m_fechaprecioant
        End Get
        Set(ByVal value As String)
            m_fechaprecioant = value
        End Set
    End Property
    Public Property RECIBIDO() As String
        Get
            Return m_recibido
        End Get
        Set(ByVal value As String)
            m_recibido = value
        End Set
    End Property
    Public Property FACTURA() As String
        Get
            Return m_factura
        End Get
        Set(ByVal value As String)
            m_factura = value
        End Set
    End Property
    Public Property LOTE() As String
        Get
            Return m_lote
        End Get
        Set(ByVal value As String)
            m_lote = value
        End Set
    End Property
    Public Property VENCIMIENTO() As String
        Get
            Return m_vencimiento
        End Get
        Set(ByVal value As String)
            m_vencimiento = value
        End Set
    End Property
    Public Property LOCACION() As Integer
        Get
            Return m_locacion
        End Get
        Set(ByVal value As Integer)
            m_locacion = value
        End Set
    End Property
    Public Property PRECIO() As Double
        Get
            Return m_precio
        End Get
        Set(ByVal value As Double)
            m_precio = value
        End Set
    End Property
    Public Property MONEDA() As Integer
        Get
            Return m_moneda
        End Get
        Set(ByVal value As Integer)
            m_moneda = value
        End Set
    End Property
    Public Property NOCUMPLE() As Integer
        Get
            Return m_nocumple
        End Get
        Set(ByVal value As Integer)
            m_nocumple = value
        End Set
    End Property
    Public Property APERTURA() As Integer
        Get
            Return m_apertura
        End Get
        Set(ByVal value As Integer)
            m_apertura = value
        End Set
    End Property
    Public Property FECHAAPERTURA() As String
        Get
            Return m_fechaapertura
        End Get
        Set(ByVal value As String)
            m_fechaapertura = value
        End Set
    End Property
    Public Property CONSUMIDO() As Integer
        Get
            Return m_consumido
        End Get
        Set(ByVal value As Integer)
            m_consumido = value
        End Set
    End Property
    Public Property FECHACONSUMIDO() As String
        Get
            Return m_fechaconsumido
        End Get
        Set(ByVal value As String)
            m_fechaconsumido = value
        End Set
    End Property
    Public Property DESCARTADO() As Integer
        Get
            Return m_descartado
        End Get
        Set(ByVal value As Integer)
            m_descartado = value
        End Set
    End Property
    Public Property FECHADESCARTADO() As String
        Get
            Return m_fechadescartado
        End Get
        Set(ByVal value As String)
            m_fechadescartado = value
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
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idcompra = 0
        m_producto = 0
        m_unidad = 0
        m_cantidad = 0
        m_presentacion = 0
        m_precioant = 0
        m_monedaant = 0
        m_fechaprecioant = ""
        m_recibido = ""
        m_factura = ""
        m_lote = ""
        m_vencimiento = ""
        m_locacion = 0
        m_precio = 0
        m_moneda = 0
        m_nocumple = 0
        m_apertura = 0
        m_fechaapertura = ""
        m_consumido = 0
        m_fechaconsumido = ""
        m_descartado = 0
        m_fechadescartado = ""
        m_observaciones = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal idcompra As Long, ByVal producto As Integer, ByVal unidad As Integer, ByVal cantidad As Double, ByVal presentacion As Integer, ByVal precioant As Double, ByVal monedaant As Integer, ByVal fechaprecioant As String, ByVal recibido As String, ByVal factura As String, ByVal lote As String, ByVal vencimiento As String, ByVal locacion As Integer, ByVal precio As Double, ByVal moneda As Integer, ByVal nocumple As Integer, ByVal apertura As Integer, ByVal fechaapertura As String, ByVal consumido As Integer, ByVal fechaconsumido As String, ByVal descartado As Integer, ByVal fechadescartado As String, ByVal observaciones As String)
        m_id = id
        m_idcompra = idcompra
        m_producto = producto
        m_unidad = unidad
        m_cantidad = cantidad
        m_presentacion = presentacion
        m_precioant = precioant
        m_monedaant = monedaant
        m_fechaprecioant = fechaprecioant
        m_recibido = recibido
        m_factura = factura
        m_lote = lote
        m_vencimiento = vencimiento
        m_locacion = locacion
        m_precio = precio
        m_moneda = moneda
        m_nocumple = nocumple
        m_apertura = apertura
        m_fechaapertura = fechaapertura
        m_consumido = consumido
        m_fechaconsumido = fechaconsumido
        m_descartado = descartado
        m_fechadescartado = fechadescartado
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.modificar2(Me, usuario)
    End Function
    Public Function modificar3(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.modificar3(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.eliminar(Me, usuario)
    End Function
    Public Function eliminarxcompra(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.eliminarxcompra(Me, usuario)
    End Function
    Public Function buscar() As dLineaCompra
        Dim p As New pLineaCompra
        Return p.buscar(Me)
    End Function
    Public Function buscarxidcompra() As dLineaCompra
        Dim p As New pLineaCompra
        Return p.buscarxidcompra(Me)
    End Function
    Public Function buscarultimacompra() As dLineaCompra
        Dim p As New pLineaCompra
        Return p.buscarultimacompra(Me)
    End Function
    Public Function marcarnocumple(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.marcarnocumple(Me, usuario)
    End Function
    Public Function cambiarcantidad(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCompra
        Return p.cambiarcantidad(Me, usuario)
    End Function

#End Region


    Public Overrides Function ToString() As String
        Return m_idcompra
    End Function
    Public Function listar() As ArrayList
        Dim p As New pLineaCompra
        Return p.listar
    End Function
    Public Function listarultimos10(ByVal idproducto As Integer) As ArrayList
        Dim p As New pLineaCompra
        Return p.listarultimos10(idproducto)
    End Function
    Public Function listarxidcompra(ByVal idcompra As Long) As ArrayList
        Dim p As New pLineaCompra
        Return p.listarxidcompra(idcompra)
    End Function
    Public Function listarxidproducto(ByVal idproducto As Long) As ArrayList
        Dim p As New pLineaCompra
        Return p.listarxidproducto(idproducto)
    End Function
    Public Function listarxidproducto2(ByVal idproducto As Long) As ArrayList
        Dim p As New pLineaCompra
        Return p.listarxidproducto2(idproducto)
    End Function
    Public Function listarenuso(ByVal producto As Long) As ArrayList
        Dim p As New pLineaCompra
        Return p.listarenuso(producto)
    End Function
    Public Function listarsinabrir(ByVal producto As Long) As ArrayList
        Dim p As New pLineaCompra
        Return p.listarsinabrir(producto)
    End Function
    Public Function listarconsumidos(ByVal producto As Long) As ArrayList
        Dim p As New pLineaCompra
        Return p.listarconsumidos(producto)
    End Function
    Public Function listardescartados(ByVal producto As Long) As ArrayList
        Dim p As New pLineaCompra
        Return p.listardescartados(producto)
    End Function
End Class
