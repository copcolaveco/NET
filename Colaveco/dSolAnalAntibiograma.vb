Public Class dSolAnalAntibiograma
#Region "Atributos"
    Private m_id As Long
    Private m_fechaingreso As String
    Private m_nummuestras As Integer
    Private m_muestra As Integer
    Private m_ssolicitud As Integer
    Private m_sinconservante As Integer
    Private m_temperatura As Double
    Private m_derramadas As Integer
    Private m_desvioautorizado As Integer
    Private m_conservadoras As Integer
    Private m_idcaja As Integer
    Private m_gradillas As Integer
    Private m_armazones As Integer
    Private m_otros As Integer
    Private m_aislamiento As Integer
    Private m_antibiograma As Integer
    Private m_fecha As String
    Private m_web As Integer
    Private m_personal As Integer
    Private m_email As Integer
    Private m_fechaenvio As String

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
    Public Property FECHAINGRESO() As String
        Get
            Return m_fechaingreso
        End Get
        Set(ByVal value As String)
            m_fechaingreso = value
        End Set
    End Property

    Public Property NUMMUESTRAS() As Integer
        Get
            Return m_nummuestras
        End Get
        Set(ByVal value As Integer)
            m_nummuestras = value
        End Set
    End Property
    Public Property MUESTRA() As Integer
        Get
            Return m_muestra
        End Get
        Set(ByVal value As Integer)
            m_muestra = value
        End Set
    End Property
    Public Property GRADILLAS() As Integer
        Get
            Return m_gradillas
        End Get
        Set(ByVal value As Integer)
            m_gradillas = value
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
    Public Property IDEMPRESA() As Integer
        Get
            Return m_idempresa
        End Get
        Set(ByVal value As Integer)
            m_idempresa = value
        End Set
    End Property
    Public Property ENVIO() As String
        Get
            Return m_envio
        End Get
        Set(ByVal value As String)
            m_envio = value
        End Set
    End Property
    Public Property FECHAENVIO() As String
        Get
            Return m_fechaenvio
        End Get
        Set(ByVal value As String)
            m_fechaenvio = value
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
    Public Property ENVIADO() As Integer
        Get
            Return m_enviado
        End Get
        Set(ByVal value As Integer)
            m_enviado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idpedido = 0
        m_idcaja = 0
        m_armazones = 0
        m_gradillas = 0
        m_frascos = 0
        m_idempresa = 0
        m_envio = ""
        m_fechaenvio = ""
        m_observaciones = ""
        m_enviado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idpedido As Long, ByVal idcaja As Integer, _
                   ByVal armazones As Integer, ByVal gradillas As Integer, ByVal frascos As Integer, ByVal idempresa As Integer, _
                   ByVal envio As String, ByVal fechaenvio As String, ByVal observaciones As String, ByVal enviado As Integer)
        m_id = id
        m_idpedido = idpedido
        m_idcaja = idcaja
        m_armazones = armazones
        m_gradillas = gradillas
        m_frascos = frascos
        m_idempresa = idempresa
        m_envio = envio
        m_fechaenvio = fechaenvio
        m_observaciones = observaciones
        m_enviado = enviado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pEnvioCajas
        Return e.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dEnvioCajas
        Dim e As New pEnvioCajas
        Return e.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idcaja & Chr(9) & m_armazones & Chr(9) & m_gradillas & Chr(9) & m_frascos & Chr(9) & Chr(9) & m_envio
    End Function
    Public Function listar() As ArrayList
        Dim e As New pEnvioCajas
        Return e.listar
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim e As New pEnvioCajas
        Return e.listarporid(texto)
    End Function
End Class
