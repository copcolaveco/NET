Public Class dCompras
#Region "Atributos"
    Private m_id As Long
    Private m_proveedor As Integer
    Private m_email As String
    Private m_fecha As String
    Private m_usuariocreador As Integer
    Private m_usuarioautoriza As Integer
    Private m_fechaautoriza As String
    Private m_autoriza As Integer
    Private m_envia As Integer
    Private m_enviado As Integer
    Private m_fecharecibo As String
    Private m_aceptado As Integer
    Private m_observaciones As String
    Private m_usuariorecibe As Integer
    Private m_recibido As Integer
    Private m_anulada As Integer
    Private m_cotizacion As Long

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
    Public Property PROVEEDOR() As Integer
        Get
            Return m_proveedor
        End Get
        Set(ByVal value As Integer)
            m_proveedor = value
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
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
    Public Property USUARIOAUTORIZA() As Integer
        Get
            Return m_usuarioautoriza
        End Get
        Set(ByVal value As Integer)
            m_usuarioautoriza = value
        End Set
    End Property
    Public Property FECHAAUTORIZA() As String
        Get
            Return m_fechaautoriza
        End Get
        Set(ByVal value As String)
            m_fechaautoriza = value
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
    Public Property ENVIA() As Integer
        Get
            Return m_envia
        End Get
        Set(ByVal value As Integer)
            m_envia = value
        End Set
    End Property
    Public Property ENVIADO() As Integer
        Get
            Return m_enviado
        End Get
        Set(ByVal value As Integer)
            m_enviado = value
        End Set
    End Property
    Public Property FECHARECIBO() As String
        Get
            Return m_fecharecibo
        End Get
        Set(ByVal value As String)
            m_fecharecibo = value
        End Set
    End Property
    Public Property ACEPTADO() As Integer
        Get
            Return m_aceptado
        End Get
        Set(ByVal value As Integer)
            m_aceptado = value
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
    Public Property USUARIORECIBE() As Integer
        Get
            Return m_usuariorecibe
        End Get
        Set(ByVal value As Integer)
            m_usuariorecibe = value
        End Set
    End Property
    Public Property RECIBIDO() As Integer
        Get
            Return m_recibido
        End Get
        Set(ByVal value As Integer)
            m_recibido = value
        End Set
    End Property
    Public Property ANULADA() As Integer
        Get
            Return m_anulada
        End Get
        Set(ByVal value As Integer)
            m_anulada = value
        End Set
    End Property
    Public Property COTIZACION() As Long
        Get
            Return m_cotizacion
        End Get
        Set(ByVal value As Long)
            m_cotizacion = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_proveedor = 0
        m_email = ""
        m_fecha = ""
        m_usuariocreador = 0
        m_usuarioautoriza = 0
        m_fechaautoriza = ""
        m_autoriza = 0
        m_envia = 0
        m_enviado = 0
        m_fecharecibo = ""
        m_aceptado = 0
        m_observaciones = ""
        m_usuariorecibe = 0
        m_recibido = 0
        m_anulada = 0
        m_cotizacion = 0

    End Sub
    Public Sub New(ByVal id As Integer, ByVal proveedor As Integer, ByVal email As String, ByVal fecha As String, ByVal usuariocreador As Integer, ByVal usuarioautoriza As Integer, ByVal fechaautoriza As String, ByVal autoriza As Integer, ByVal envia As Integer, ByVal enviado As Integer, ByVal fecharecibo As String, ByVal aceptado As Integer, ByVal observaciones As String, ByVal usuariorecibe As Integer, ByVal recibido As Integer, ByVal anulada As Integer, ByVal cotizacion As Long)
        m_id = id
        m_proveedor = proveedor
        m_email = email
        m_fecha = fecha
        m_usuariocreador = usuariocreador
        m_usuarioautoriza = usuarioautoriza
        m_fechaautoriza = fechaautoriza
        m_autoriza = autoriza
        m_envia = envia
        m_enviado = enviado
        m_fecharecibo = fecharecibo
        m_aceptado = aceptado
        m_observaciones = observaciones
        m_usuariorecibe = usuariorecibe
        m_recibido = recibido
        m_anulada = anulada
        m_cotizacion = cotizacion
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCompras
        Dim p As New pCompras
        Return p.buscar(Me)
    End Function
    Public Function buscarrecibido() As dCompras
        Dim p As New pCompras
        Return p.buscarrecibido(Me)
    End Function
    Public Function buscarsinrecibir() As dCompras
        Dim p As New pCompras
        Return p.buscarsinrecibir(Me)
    End Function
    Public Function buscarultimoid() As dCompras
        Dim p As New pCompras
        Return p.buscarultimoid(Me)
    End Function
#End Region


    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim p As New pCompras
        Return p.listar
    End Function
    Public Function listarporid(ByVal id As Long) As ArrayList
        Dim p As New pCompras
        Return p.listarporid(id)
    End Function
    Public Function listarxproveedor(ByVal idproveedor As Long) As ArrayList
        Dim p As New pCompras
        Return p.listarxproveedor(idproveedor)
    End Function
    Public Function listarxproveedorrecibido(ByVal idproveedor As Long) As ArrayList
        Dim p As New pCompras
        Return p.listarxproveedorrecibido(idproveedor)
    End Function
    Public Function listarxproveedorsinrecibir(ByVal idproveedor As Long) As ArrayList
        Dim p As New pCompras
        Return p.listarxproveedorsinrecibir(idproveedor)
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pCompras
        Return p.listarxfecha(desde, hasta)
    End Function
    Public Function listarxfecharecibido(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pCompras
        Return p.listarxfecharecibido(desde, hasta)
    End Function
    Public Function listarxfechasinrecibir(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pCompras
        Return p.listarxfechasinrecibir(desde, hasta)
    End Function
    Public Function listarsinrecibir() As ArrayList
        Dim p As New pCompras
        Return p.listarsinrecibir
    End Function
    Public Function listarsinautorizar() As ArrayList
        Dim p As New pCompras
        Return p.listarsinautorizar
    End Function
    Public Function listarautorizadas() As ArrayList
        Dim p As New pCompras
        Return p.listarautorizadas
    End Function
    Public Function listarsinenviar() As ArrayList
        Dim p As New pCompras
        Return p.listarsinenviar
    End Function
    Public Function marcarautoriza(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.marcarautoriza(Me, usuario)
    End Function
    Public Function marcaranulada(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.marcaranulada(Me, usuario)
    End Function
    Public Function marcarrecibido(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.marcarrecibido(Me, usuario)
    End Function
    Public Function marcarenviado() As Boolean
        Dim p As New pCompras
        Return p.marcarenviado(Me)
    End Function
    Public Function marcarenvia(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.marcarenvia(Me, usuario)
    End Function
    Public Function marcarnoenvia(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCompras
        Return p.marcarnoenvia(Me, usuario)
    End Function
End Class
