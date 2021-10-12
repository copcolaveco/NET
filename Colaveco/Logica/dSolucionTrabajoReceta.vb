Public Class dSolucionTrabajoReceta
#Region "Atributos"
    Private m_id As Integer
    Private m_idst As Integer
    Private m_idproducto As Integer
    Private m_cantidad As Double
    Private m_unidad As Integer


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
    Public Property IDST() As Integer
        Get
            Return m_idst
        End Get
        Set(ByVal value As Integer)
            m_idst = value
        End Set
    End Property
    Public Property IDPRODUCTO() As Integer
        Get
            Return m_idproducto
        End Get
        Set(ByVal value As Integer)
            m_idproducto = value
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

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idst = 0
        m_idproducto = 0
        m_cantidad = 0
        m_unidad = 0

    End Sub
    Public Sub New(ByVal id As Integer, ByVal idst As Integer, ByVal idproducto As Integer, ByVal cantidad As Double, ByVal unidad As Integer)
        m_id = id
        m_idst = idst
        m_idproducto = idproducto
        m_cantidad = cantidad
        m_unidad = unidad
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSolucionTrabajoReceta
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSolucionTrabajoReceta
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSolucionTrabajoReceta
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSolucionTrabajoReceta
        Dim c As New pSolucionTrabajoReceta
        Return c.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pSolucionTrabajoReceta
        Return c.listar
    End Function
    Public Function listarxid(ByVal id As Integer) As ArrayList
        Dim c As New pSolucionTrabajoReceta
        Return c.listarxid(id)
    End Function
End Class
