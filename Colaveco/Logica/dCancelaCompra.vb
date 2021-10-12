Public Class dCancelaCompra
#Region "Atributos"
    Private m_id As Long
    Private m_idcompra As Long
    Private m_fecha As String
    Private m_proveedor As Integer
    Private m_usuariocreador As Integer
    Private m_usuariocancela As Integer
    Private m_visto As Integer
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property PROVEEDOR() As Integer
        Get
            Return m_proveedor
        End Get
        Set(ByVal value As Integer)
            m_proveedor = value
        End Set
    End Property
    Public Property USUARIOCREADOR() As Integer
        Get
            Return m_usuariocreador
        End Get
        Set(ByVal value As Integer)
            m_usuariocreador = value
        End Set
    End Property
    Public Property USUARIOCANCELA() As Integer
        Get
            Return m_usuariocancela
        End Get
        Set(ByVal value As Integer)
            m_usuariocancela = value
        End Set
    End Property
    Public Property VISTO() As Integer
        Get
            Return m_visto
        End Get
        Set(ByVal value As Integer)
            m_visto = value
        End Set
    End Property
#End Region


#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idcompra = 0
        m_fecha = ""
        m_proveedor = 0
        m_usuariocreador = 0
        m_usuariocancela = 0
        m_visto = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal idcompra As Long, ByVal fecha As String, ByVal proveedor As Integer, ByVal usuariocreador As Integer, ByVal usuariocancela As Integer, ByVal visto As Integer)
        m_id = id
        m_idcompra = idcompra
        m_fecha = fecha
        m_proveedor = proveedor
        m_usuariocreador = usuariocreador
        m_usuariocancela = usuariocancela
        m_visto = visto
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCancelaCompra
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCancelaCompra
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCancelaCompra
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCancelaCompra
        Dim p As New pCancelaCompra
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idcompra
    End Function

    Public Function listar() As ArrayList
        Dim p As New pCancelaCompra
        Return p.listar
    End Function
    Public Function listarxusuario(ByVal idusuario As Integer) As ArrayList
        Dim p As New pCancelaCompra
        Return p.listarxusuario(idusuario)
    End Function
    Public Function marcarvisto() As Boolean
        Dim p As New pCancelaCompra
        Return p.marcarvisto(Me)
    End Function
End Class
