Public Class dProductos
#Region "Atributos"
    Private m_id As Integer
    Private m_codigo As String
    Private m_nombre As String
    Private m_detalle As String
    Private m_unidad As Integer
    Private m_categoria As Integer
    Private m_iva As Integer
    Private m_stock As Double
    Private m_eliminado As Integer
    
#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
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
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property DETALLE() As String
        Get
            Return m_detalle
        End Get
        Set(ByVal value As String)
            m_detalle = value
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
    Public Property CATEGORIA() As Integer
        Get
            Return m_categoria
        End Get
        Set(ByVal value As Integer)
            m_categoria = value
        End Set
    End Property
    Public Property IVA() As Integer
        Get
            Return m_iva
        End Get
        Set(ByVal value As Integer)
            m_iva = value
        End Set
    End Property
    Public Property STOCK() As Double
        Get
            Return m_stock
        End Get
        Set(ByVal value As Double)
            m_iva = value
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
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_codigo = ""
        m_nombre = ""
        m_detalle = ""
        m_unidad = 0
        m_categoria = 0
        m_iva = 0
        m_stock = 0
        m_eliminado = 0

    End Sub
    Public Sub New(ByVal id As Integer, ByVal codigo As String, ByVal nombre As String, ByVal detalle As String, ByVal unidad As Integer, ByVal categoria As Integer, ByVal iva As Integer, ByVal stock As Double, ByVal eliminado As Integer)
        m_id = id
        m_codigo = codigo
        m_nombre = nombre
        m_detalle = detalle
        m_unidad = unidad
        m_categoria = categoria
        m_iva = iva
        m_stock = stock
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProductos
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProductos
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProductos
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dProductos
        Dim p As New pProductos
        Return p.buscar(Me)
    End Function
    Public Function buscar2() As dProductos
        Dim p As New pProductos
        Return p.buscar2(Me)
    End Function

    Public Function buscarPorNombre(ByVal pnombre As String) As ArrayList
        Dim s As New pProductos
        Return s.buscarPorNombre(pnombre)
    End Function
    Public Function buscarPorCodigo(ByVal pcodigo As String) As ArrayList
        Dim s As New pProductos
        Return s.buscarPorCodigo(pcodigo)
    End Function

#End Region


    Public Overrides Function ToString() As String
        Return m_nombre
    End Function
    Public Function listar() As ArrayList
        Dim p As New pProductos
        Return p.listar
    End Function
    Public Function listarmedios() As ArrayList
        Dim p As New pProductos
        Return p.listarmedios
    End Function
End Class
