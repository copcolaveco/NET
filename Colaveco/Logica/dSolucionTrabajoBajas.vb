Public Class dSolucionTrabajoBajas
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_idsolucion As Integer
    Private m_cantidad As Double
    Private m_idunidad As Integer


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
    Public Property IDSOLUCION() As Integer
        Get
            Return m_idsolucion
        End Get
        Set(ByVal value As Integer)
            m_idsolucion = value
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
    Public Property IDUNIDAD() As Integer
        Get
            Return m_idunidad
        End Get
        Set(ByVal value As Integer)
            m_idunidad = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_idsolucion = 0
        m_cantidad = 0
        m_idunidad = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal idsolucion As Integer, ByVal cantidad As Double, ByVal idunidad As Integer)
        m_id = id
        m_fecha = fecha
        m_idsolucion = idsolucion
        m_cantidad = cantidad
        m_idunidad = idunidad
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSolucionTrabajoBajas
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSolucionTrabajoBajas
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSolucionTrabajoBajas
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSolucionTrabajoBajas
        Dim c As New pSolucionTrabajoBajas
        Return c.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pSolucionTrabajoBajas
        Return c.listar
    End Function
End Class
