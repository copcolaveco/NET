Public Class dFacturacion
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_cantidad As Double
    Private m_analisis As Integer
    Private m_precio As Double
    Private m_subtotal As Double
    Private m_factura As Long
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
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
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
    Public Property ANALISIS() As Integer
        Get
            Return m_analisis
        End Get
        Set(ByVal value As Integer)
            m_analisis = value
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
    Public Property SUBTOTAL() As Double
        Get
            Return m_subtotal
        End Get
        Set(ByVal value As Double)
            m_subtotal = value
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
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_cantidad = 0
        m_analisis = 0
        m_precio = 0
        m_subtotal = 0
        m_factura = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal cantidad As Double, ByVal analisis As Integer, ByVal precio As Double, ByVal subtotal As Double, ByVal factura As Long)
        m_id = id
        m_ficha = ficha
        m_cantidad = cantidad
        m_analisis = analisis
        m_precio = precio
        m_subtotal = subtotal
        m_factura = factura
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pFacturacion
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pFacturacion
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pFacturacion
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dFacturacion
        Dim p As New pFacturacion
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pFacturacion
        Return p.listar
    End Function
    Public Function listarxficha(ByVal ficha As Long) As ArrayList
        Dim p As New pFacturacion
        Return p.listarxficha(ficha)
    End Function
End Class
