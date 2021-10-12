Public Class dActividades
#Region "Atributos"
    Private m_id As Long
    Private m_iddimension As Long
    Private m_idobjespecifico As Long
    Private m_nombre As String
    Private m_indicador As String
    Private m_meta As Integer
    Private m_aceptable As Integer
    Private m_responsable As String
    Private m_plazo As String
    Private m_ano As Integer
    Private m_finaliza As Integer
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
    Public Property IDDIMENSION() As Long
        Get
            Return m_iddimension
        End Get
        Set(ByVal value As Long)
            m_iddimension = value
        End Set
    End Property
    Public Property IDOBJESPECIFICO() As Long
        Get
            Return m_idobjespecifico
        End Get
        Set(ByVal value As Long)
            m_idobjespecifico = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property INDICADOR() As String
        Get
            Return m_indicador
        End Get
        Set(ByVal value As String)
            m_indicador = value
        End Set
    End Property
    Public Property META() As Integer
        Get
            Return m_meta
        End Get
        Set(ByVal value As Integer)
            m_meta = value
        End Set
    End Property
    Public Property ACEPTABLE() As Integer
        Get
            Return m_aceptable
        End Get
        Set(ByVal value As Integer)
            m_aceptable = value
        End Set
    End Property
    Public Property RESPONSABLE() As String
        Get
            Return m_responsable
        End Get
        Set(ByVal value As String)
            m_responsable = value
        End Set
    End Property
    Public Property PLAZO() As String
        Get
            Return m_plazo
        End Get
        Set(ByVal value As String)
            m_plazo = value
        End Set
    End Property
    Public Property ANO() As Integer
        Get
            Return m_ano
        End Get
        Set(ByVal value As Integer)
            m_ano = value
        End Set
    End Property
    Public Property FINALIZA() As Integer
        Get
            Return m_finaliza
        End Get
        Set(ByVal value As Integer)
            m_finaliza = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_iddimension = 0
        m_idobjespecifico = 0
        m_nombre = ""
        m_indicador = ""
        m_meta = 0
        m_aceptable = 0
        m_responsable = ""
        m_plazo = ""
        m_ano = 0
        m_finaliza = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal iddimension As Long, ByVal idobjespecifico As Long, ByVal nombre As String, ByVal indicador As String, ByVal meta As Integer, ByVal aceptable As Integer, ByVal responsable As String, ByVal plazo As String, ByVal ano As Integer, ByVal finaliza As Integer)
        m_id = id
        m_iddimension = iddimension
        m_idobjespecifico = idobjespecifico
        m_nombre = nombre
        m_indicador = indicador
        m_meta = meta
        m_aceptable = aceptable
        m_responsable = responsable
        m_plazo = plazo
        m_ano = ano
        m_finaliza = finaliza
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.modificar(Me, usuario)
    End Function
    Public Function modificaractividad(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.modificaractividad(Me, usuario)
    End Function
    Public Function modificarindicador(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.modificarindicador(Me, usuario)
    End Function
    Public Function modificarfinaliza(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.modificarfinaliza(Me, usuario)
    End Function
    Public Function modificarresponsable(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.modificarresponsable(Me, usuario)
    End Function
    Public Function modificaraceptable(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.modificaraceptable(Me, usuario)
    End Function
    Public Function modificarmeta(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.modificarmeta(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pActividades
        Return a.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dActividades
        Dim a As New pActividades
        Return a.buscar(Me)
    End Function
    Public Function buscarultima() As dActividades
        Dim a As New pActividades
        Return a.buscarultima(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim a As New pActividades
        Return a.listar
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim a As New pActividades
        Return a.listarxano(ano)
    End Function
    Public Function listarxobjesp(ByVal idobjesp As Long) As ArrayList
        Dim a As New pActividades
        Return a.listarxobjesp(idobjesp)
    End Function
    Public Function listarxdimension(ByVal iddimension As Long) As ArrayList
        Dim a As New pActividades
        Return a.listarxdimension(iddimension)
    End Function
End Class
