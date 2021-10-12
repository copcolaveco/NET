Public Class dPaquetes
#Region "Atributos"
    Private m_id As Integer
    Private m_idpadre As Integer
    Private m_idhijo As Integer
    Private m_preciopadre As Integer
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
    Public Property IDPADRE() As Integer
        Get
            Return m_idpadre
        End Get
        Set(ByVal value As Integer)
            m_idpadre = value
        End Set
    End Property
    Public Property IDHIJO() As Integer
        Get
            Return m_idhijo
        End Get
        Set(ByVal value As Integer)
            m_idhijo = value
        End Set
    End Property
    Public Property PRECIOPADRE() As Integer
        Get
            Return m_preciopadre
        End Get
        Set(ByVal value As Integer)
            m_preciopadre = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idpadre = 0
        m_idhijo = 0
        m_preciopadre = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal idpadre As Integer, ByVal idhijo As Integer, ByVal preciopadre As Integer)
        m_id = id
        m_idpadre = idpadre
        m_idhijo = idhijo
        m_preciopadre = preciopadre
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPaquetes
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPaquetes
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPaquetes
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPaquetes
        Dim p As New pPaquetes
        Return p.buscar(Me)
    End Function
    Public Function buscarxidpadre() As dPaquetes
        Dim p As New pPaquetes
        Return p.buscarxidpadre(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pPaquetes
        Return p.listar
    End Function
    Public Function listarxpadre(ByVal idpadre As Integer) As ArrayList
        Dim p As New pPaquetes
        Return p.listarxpadre(idpadre)
    End Function
End Class
