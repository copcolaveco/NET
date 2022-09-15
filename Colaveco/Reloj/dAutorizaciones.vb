Public Class dAutorizaciones
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_idusuario As Integer
    Private m_tipo As Integer
    Private m_fechaevento As String
    Private m_detalle As String
    Private m_autoriza As Integer
    Private m_observaciones As String
    Private m_autorizada As Integer
    Private m_email As String
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
    Public Property IDUSUARIO() As Integer
        Get
            Return m_idusuario
        End Get
        Set(ByVal value As Integer)
            m_idusuario = value
        End Set
    End Property
    Public Property TIPO() As Integer
        Get
            Return m_tipo
        End Get
        Set(ByVal value As Integer)
            m_tipo = value
        End Set
    End Property
    Public Property FECHAEVENTO() As String
        Get
            Return m_fechaevento
        End Get
        Set(ByVal value As String)
            m_fechaevento = value
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
    Public Property AUTORIZA() As Integer
        Get
            Return m_autoriza
        End Get
        Set(ByVal value As Integer)
            m_autoriza = value
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
    Public Property AUTORIZADA() As Integer
        Get
            Return m_autorizada
        End Get
        Set(ByVal value As Integer)
            m_autorizada = value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_idusuario = 0
        m_tipo = 0
        m_fechaevento = ""
        m_detalle = ""
        m_autoriza = 0
        m_observaciones = ""
        m_autorizada = 0
        m_email = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal idusuario As Integer, ByVal tipo As Integer, ByVal fechaevento As String, ByVal detalle As String, ByVal autoriza As Integer, ByVal observaciones As String, ByVal autorizada As Integer, ByVal email As String)
        m_id = id
        m_fecha = fecha
        m_idusuario = idusuario
        m_tipo = tipo
        m_fechaevento = fechaevento
        m_detalle = detalle
        m_autoriza = autoriza
        m_observaciones = observaciones
        m_autorizada = autorizada
        m_email = email
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAutorizaciones
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAutorizaciones
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAutorizaciones
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAutorizaciones
        Dim p As New pAutorizaciones
        Return p.buscar(Me)
    End Function
    Public Function marcarautorizada() As Boolean
        Dim p As New pAutorizaciones
        Return p.marcarautorizada(Me)
    End Function
    Public Function desmarcarautorizada() As Boolean
        Dim p As New pAutorizaciones
        Return p.desmarcarautorizada(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idusuario
    End Function

    Public Function listar() As ArrayList
        Dim p As New pAutorizaciones
        Return p.listar
    End Function
    Public Function listarxusuarioxfecha(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pAutorizaciones
        Return p.listarxusuarioxfecha(usu, desde, hasta)
    End Function
    Public Function listarsinautorizar() As ArrayList
        Dim p As New pAutorizaciones
        Return p.listarsinautorizar
    End Function
    Public Function listarultimos50() As ArrayList
        Dim p As New pAutorizaciones
        Return p.listarultimos50
    End Function
    Public Function listarsemana(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pAutorizaciones
        Return p.listarsemana(desde, hasta)
    End Function
    Public Function listarPorFiltros(ByVal desde As String, ByVal hasta As String, ByVal usu As Integer) As ArrayList
        Dim p As New pAutorizaciones
        Return p.listarPorFiltros(desde, hasta, usu)
    End Function
End Class
