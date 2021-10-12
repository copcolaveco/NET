Public Class dEnviosFlorida
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_productor As Long
    Private m_tipoinforme As Integer
    Private m_subinforme As Integer
    Private m_observaciones As String
    Private m_nmuestras As Integer
    Private m_temperatura As String
    Private m_cajas As String
    Private m_muestra As Integer
    Private m_tecnico As Long
    Private m_razonsocial As String
    Private m_rut As String
    Private m_direccion As String
    Private m_marca As Integer

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
    Public Property PRODUCTOR() As Long
        Get
            Return m_productor
        End Get
        Set(ByVal value As Long)
            m_productor = value
        End Set
    End Property
    Public Property TIPOINFORME() As Integer
        Get
            Return m_tipoinforme
        End Get
        Set(ByVal value As Integer)
            m_tipoinforme = value
        End Set
    End Property
    Public Property SUBINFORME() As Integer
        Get
            Return m_subinforme
        End Get
        Set(ByVal value As Integer)
            m_subinforme = value
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
    Public Property NMUESTRAS() As Integer
        Get
            Return m_nmuestras
        End Get
        Set(ByVal value As Integer)
            m_nmuestras = value
        End Set
    End Property
    Public Property TEMPERATURA() As String
        Get
            Return m_temperatura
        End Get
        Set(ByVal value As String)
            m_temperatura = value
        End Set
    End Property
    Public Property CAJAS() As String
        Get
            Return m_cajas

        End Get
        Set(ByVal value As String)
            m_cajas = value
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
    Public Property TECNICO() As Long
        Get
            Return m_tecnico
        End Get
        Set(ByVal value As Long)
            m_tecnico = value
        End Set
    End Property
    Public Property RAZONSOCIAL() As String
        Get
            Return m_razonsocial

        End Get
        Set(ByVal value As String)
            m_razonsocial = value
        End Set
    End Property
    Public Property RUT() As String
        Get
            Return m_rut

        End Get
        Set(ByVal value As String)
            m_rut = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return m_direccion

        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_productor = 0
        m_tipoinforme = 0
        m_subinforme = 0
        m_observaciones = ""
        m_nmuestras = 0
        m_temperatura = ""
        m_cajas = ""
        m_muestra = 0
        m_tecnico = 0
        m_razonsocial = ""
        m_rut = ""
        m_direccion = ""
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal productor As Long, ByVal tipoinforme As Integer, ByVal subinforme As Integer, ByVal observaciones As String, ByVal nmuestras As Integer, ByVal temperatura As String, ByVal cajas As String, ByVal muestra As Integer, ByVal tecnico As Long, ByVal razonsocial As String, ByVal rut As String, ByVal direccion As String, ByVal marca As Integer)
        m_id = id
        m_fecha = fecha
        m_productor = productor
        m_tipoinforme = tipoinforme
        m_subinforme = subinforme
        m_observaciones = observaciones
        m_nmuestras = nmuestras
        m_temperatura = temperatura
        m_cajas = cajas
        m_muestra = muestra
        m_tecnico = tecnico
        m_razonsocial = razonsocial
        m_rut = rut
        m_direccion = direccion
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEnviosFlorida
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEnviosFlorida
        Return p.modificar(Me, usuario)
    End Function
    Public Function marcar() As Boolean
        Dim p As New pEnviosFlorida
        Return p.marcar(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEnviosFlorida
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dEnviosFlorida
        Dim p As New pEnviosFlorida
        Return p.buscar(Me)
    End Function
    Public Function buscarultimo() As dEnviosFlorida
        Dim p As New pEnviosFlorida
        Return p.buscarultimo(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pEnviosFlorida
        Return p.listar
    End Function

    Public Function listarsinenviar() As ArrayList
        Dim p As New pEnviosFlorida
        Return p.listarsinenviar
    End Function
End Class
