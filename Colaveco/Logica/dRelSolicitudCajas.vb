Public Class dRelSolicitudCajas
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_idenvio As Long
    Private m_idcaja As String
    Private m_gradilla1 As Integer
    Private m_gradilla2 As Integer
    Private m_gradilla3 As Integer
    Private m_frascos As Integer
    Private m_nocolaveco As Integer
    Private m_eliminado As Integer
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
    Public Property IDENVIO() As Long
        Get
            Return m_idenvio
        End Get
        Set(ByVal value As Long)
            m_idenvio = value
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
    Public Property GRADILLA1() As Integer
        Get
            Return m_gradilla1
        End Get
        Set(ByVal value As Integer)
            m_gradilla1 = value
        End Set
    End Property
    Public Property GRADILLA2() As Integer
        Get
            Return m_gradilla2
        End Get
        Set(ByVal value As Integer)
            m_gradilla2 = value
        End Set
    End Property
    Public Property GRADILLA3() As Integer
        Get
            Return m_gradilla3
        End Get
        Set(ByVal value As Integer)
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
    Public Property NOCOLAVECO() As Integer
        Get
            Return m_nocolaveco
        End Get
        Set(ByVal value As Integer)
            m_nocolaveco = value
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
        m_ficha = 0
        m_idenvio = 0
        m_idcaja = ""
        m_gradilla1 = 0
        m_gradilla2 = 0
        m_gradilla3 = 0
        m_frascos = 0
        m_nocolaveco = 0
        m_eliminado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal idenvio As Long, ByVal idcaja As String, ByVal gradilla1 As Integer, ByVal gradilla2 As Integer, ByVal gradilla3 As Integer, ByVal frascos As Integer, ByVal nocolaveco As Integer, ByVal eliminado As Integer)
        m_id = id
        m_ficha = ficha
        m_idenvio = idenvio
        m_idcaja = idcaja
        m_gradilla1 = gradilla1
        m_gradilla2 = gradilla2
        m_gradilla3 = gradilla3
        m_frascos = frascos
        m_nocolaveco = nocolaveco
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pRelSolicitudCajas
        Return e.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pRelSolicitudCajas
        Return e.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pRelSolicitudCajas
        Return e.eliminar(Me, usuario)
    End Function
    Public Function eliminarPorIdCaja(ByVal idCaja As String) As Boolean
        Dim e As New pRelSolicitudCajas
        Return e.eliminarPorIdCaja(Me, idCaja)
    End Function
    Public Function buscar() As dRelSolicitudCajas
        Dim e As New pRelSolicitudCajas
        Return e.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String

        'Return m_idcaja & Chr(9) & m_gradilla1 & Chr(9) & m_gradilla2 & Chr(9) & m_gradilla3 & Chr(9) & m_frascos
        Return m_idcaja & Chr(9) & m_frascos

    End Function
    Public Function listar() As ArrayList
        Dim e As New pRelSolicitudCajas
        Return e.listar
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim e As New pRelSolicitudCajas
        Return e.listarporid(texto)
    End Function
    Public Function listarCajasPendientesCliente(ByVal texto As Long) As ArrayList
        Dim e As New pRelSolicitudCajas
        Return e.listarCajasPendienteCliente(texto)
    End Function
    Public Function listarporficha(ByVal ficha As String) As ArrayList
        Dim e As New pRelSolicitudCajas
        Return e.listarporficha(ficha)
    End Function
End Class
