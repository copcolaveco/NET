Public Class dControlInformesDetalle

#Region "Atributos"
    Private m_ficha As Long
    Private m_fecha As String
    Private m_muestra As String
    Private m_tipo As String
    Private m_subtipo As String
    Private m_resultado As Integer
    Private m_coincide As Integer
    Private m_om As Integer
    Private m_nc As Integer
    Private m_observaciones As String
    Private m_controlador As String
    Private m_controlado As String
    Private m_cliente As String
#End Region

#Region "Propiedades"
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
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

    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property

    Public Property TIPO() As String
        Get
            Return m_tipo
        End Get
        Set(ByVal value As String)
            m_tipo = value
        End Set
    End Property

    Public Property SUBTIPO() As String
        Get
            Return m_subtipo
        End Get
        Set(ByVal value As String)
            m_subtipo = value
        End Set
    End Property

    Public Property RESULTADO() As Integer
        Get
            Return m_resultado
        End Get
        Set(ByVal value As Integer)
            m_resultado = value
        End Set
    End Property

    Public Property COINCIDE() As Integer
        Get
            Return m_coincide
        End Get
        Set(ByVal value As Integer)
            m_coincide = value
        End Set
    End Property

    Public Property OM() As Integer
        Get
            Return m_om
        End Get
        Set(ByVal value As Integer)
            m_om = value
        End Set
    End Property

    Public Property NC() As Integer
        Get
            Return m_nc
        End Get
        Set(ByVal value As Integer)
            m_nc = value
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

    Public Property CONTROLADOR() As String
        Get
            Return m_controlador
        End Get
        Set(ByVal value As String)
            m_controlador = value
        End Set
    End Property

    Public Property CONTROLADO() As String
        Get
            Return m_controlado
        End Get
        Set(ByVal value As String)
            m_controlado = value
        End Set
    End Property

    Public Property CLIENTE() As String
        Get
            Return m_cliente
        End Get
        Set(ByVal value As String)
            m_cliente = value
        End Set
    End Property
#End Region

    Public Function listar_detalle_controles(
    ByVal fechaDesde As String,
    ByVal fechaHasta As String,
    ByVal estado As String,
    ByVal sector As String,
    ByVal controlador As String,
    ByVal tipoInforme As String,
    ByVal ficha As String) As ArrayList

        Dim p As New pControlInformesDetalle
        Return p.GenerarConsultaControlInformesDetalleExtendida(fechaDesde, fechaHasta, estado, sector, controlador, tipoInforme, ficha)
    End Function

    Public Function GenerarResumenInformesPorSectorYTipo(
    ByVal fechaDesde As String,
    ByVal fechaHasta As String,
    ByVal estado As String,
    ByVal sector As String,
    ByVal controlador As String,
    ByVal tipoInforme As String,
    ByVal ficha As String) As DataTable

        Dim p As New pControlInformesDetalle
        Return p.GenerarResumenInformesPorSectorYTipo(fechaDesde, fechaHasta, estado, sector, controlador, tipoInforme, ficha)
    End Function


End Class
