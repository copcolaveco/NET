Public Class dNoCumple
#Region "Atributos"
    Private m_id As Long
    Private m_idlineacompra As Long
    Private m_fecha As String
    Private m_puntualidad As Integer
    Private m_calidad As Integer
    Private m_cantidad As Integer
    Private m_precio As Integer
    Private m_factura As Integer
    Private m_descripcion As String
    Private m_usuario As Integer
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
    Public Property IDLINEACOMPRA() As Long
        Get
            Return m_idlineacompra
        End Get
        Set(ByVal value As Long)
            m_idlineacompra = value
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
    Public Property PUNTUALIDAD() As Integer
        Get
            Return m_puntualidad
        End Get
        Set(ByVal value As Integer)
            m_puntualidad = value
        End Set
    End Property
    Public Property CALIDAD() As Integer
        Get
            Return m_calidad
        End Get
        Set(ByVal value As Integer)
            m_calidad = value
        End Set
    End Property
    Public Property CANTIDAD() As Integer
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Integer)
            m_cantidad = value
        End Set
    End Property
    Public Property PRECIO() As Integer
        Get
            Return m_precio
        End Get
        Set(ByVal value As Integer)
            m_precio = value
        End Set
    End Property
    Public Property FACTURA() As Integer
        Get
            Return m_factura
        End Get
        Set(ByVal value As Integer)
            m_factura = value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property USUARIO() As Integer
        Get
            Return m_usuario
        End Get
        Set(ByVal value As Integer)
            m_usuario = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idlineacompra = 0
        m_fecha = ""
        m_puntualidad = 0
        m_calidad = 0
        m_cantidad = 0
        m_precio = 0
        m_factura = 0
        m_descripcion = ""
        m_usuario = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idlineacompra As Long, ByVal fecha As String, ByVal puntualidad As Integer, ByVal calidad As Integer, ByVal cantidad As Integer, ByVal precio As Integer, ByVal factura As Integer, ByVal descripcion As String, ByVal usuario As Integer)
        m_id = id
        m_idlineacompra = idlineacompra
        m_fecha = fecha
        m_puntualidad = puntualidad
        m_calidad = calidad
        m_cantidad = cantidad
        m_precio = precio
        m_factura = factura
        m_descripcion = descripcion
        m_usuario = usuario
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoCumple
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoCumple
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pNoCumple
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dNoCumple
        Dim p As New pNoCumple
        Return p.buscar(Me)
    End Function
    Public Function buscarxlineacompra() As dNoCumple
        Dim p As New pNoCumple
        Return p.buscarxlineacompra(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idlineacompra
    End Function

    Public Function listar() As ArrayList
        Dim p As New pNoCumple
        Return p.listar
    End Function
End Class
