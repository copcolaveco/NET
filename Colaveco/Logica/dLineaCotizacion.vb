Public Class dLineaCotizacion
#Region "Atributos"
    Private m_id As Long
    Private m_idcotizacion As Long
    Private m_producto As Integer
    Private m_cantidad As Double
    Private m_unidad As Integer
    Private m_presentacion As Integer
    Private m_precio As Double
    Private m_moneda As Integer
    Private m_fechaprecio As String


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
    Public Property IDCOTIZACION() As Long
        Get
            Return m_idcotizacion
        End Get
        Set(ByVal value As Long)
            m_idcotizacion = value
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
    Public Property CANTIDAD() As Double
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Double)
            m_cantidad = value
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
    Public Property PRESENTACION() As Integer
        Get
            Return m_presentacion
        End Get
        Set(ByVal value As Integer)
            m_presentacion = value
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
    Public Property FECHAPRECIO() As String
        Get
            Return m_fechaprecio
        End Get
        Set(ByVal value As String)
            m_fechaprecio = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idcotizacion = 0
        m_producto = 0
        m_cantidad = 0
        m_unidad = 0
        m_presentacion = 0
        m_precio = 0
        m_moneda = 0
        m_fechaprecio = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal idcotizacion As Long, ByVal producto As Integer, ByVal cantidad As Double, ByVal unidad As Integer, ByVal presentacion As Integer, ByVal precio As Double, ByVal moneda As Integer, ByVal fechaprecio As String)
        m_id = id
        m_idcotizacion = idcotizacion
        m_producto = producto
        m_cantidad = cantidad
        m_unidad = unidad
        m_presentacion = presentacion
        m_precio = precio
        m_moneda = moneda
        m_fechaprecio = fechaprecio
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCotizacion
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCotizacion
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLineaCotizacion
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dLineaCotizacion
        Dim p As New pLineaCotizacion
        Return p.buscar(Me)
    End Function

#End Region


    Public Overrides Function ToString() As String
        Return m_idcotizacion
    End Function
    Public Function listar() As ArrayList
        Dim p As New pLineaCotizacion
        Return p.listar
    End Function
    Public Function listarxidcotizacion(ByVal idcotizacion As Long) As ArrayList
        Dim p As New pLineaCotizacion
        Return p.listarxidcotizacion(idcotizacion)
    End Function
End Class
