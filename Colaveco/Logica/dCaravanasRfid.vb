Public Class dCaravanasRfid
#Region "Atributos"
    Private m_id As Long
    Private m_equipo As String
    Private m_fecha As String
    Private m_productor As Long
    Private m_ficha As Long
    Private m_frasco As String
    Private m_caravana As String
    Private m_litros As Double
    Private m_excel As Integer
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
    Public Property EQUIPO() As String
        Get
            Return m_equipo
        End Get
        Set(ByVal value As String)
            m_equipo = value
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
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
    Public Property FRASCO() As String
        Get
            Return m_frasco
        End Get
        Set(ByVal value As String)
            m_frasco = value
        End Set
    End Property
    Public Property CARAVANA() As String
        Get
            Return m_caravana
        End Get
        Set(ByVal value As String)
            m_caravana = value
        End Set
    End Property
    Public Property LITROS() As Double
        Get
            Return m_litros
        End Get
        Set(ByVal value As Double)
            m_litros = value
        End Set
    End Property
    Public Property EXCEL() As Integer
        Get
            Return m_excel
        End Get
        Set(ByVal value As Integer)
            m_excel = value
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
        m_equipo = ""
        m_fecha = ""
        m_productor = 0
        m_ficha = 0
        m_frasco = ""
        m_caravana = ""
        m_litros = 0
        m_excel = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal equipo As String, ByVal fecha As String, ByVal productor As Long, ByVal ficha As Long, ByVal frasco As String, ByVal caravana As String, ByVal litros As Double, ByVal excel As Integer, ByVal marca As Integer)
        m_id = id
        m_equipo = equipo
        m_fecha = fecha
        m_productor = productor
        m_ficha = ficha
        m_frasco = frasco
        m_caravana = caravana
        m_litros = litros
        m_excel = excel
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pCaravanasRfid
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pCaravanasRfid
        Return p.modificar(Me)
    End Function
    Public Function asociarficha(ByVal idsol As Long) As Boolean
        Dim p As New pCaravanasRfid
        Return p.asociarficha(Me, idsol)
    End Function
    Public Function marcarexcel() As Boolean
        Dim p As New pCaravanasRfid
        Return p.marcarexcel(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim p As New pCaravanasRfid
        Return p.eliminar(Me)
    End Function
    Public Function eliminartodo() As Boolean
        Dim p As New pCaravanasRfid
        Return p.eliminartodo(Me)
    End Function
    Public Function buscar() As dCaravanasRfid
        Dim p As New pCaravanasRfid
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar(ByVal ideq As String, ByVal idpro As Long) As ArrayList
        Dim p As New pCaravanasRfid
        Return p.listar(ideq, idpro)
    End Function
    Public Function listarxproductor(ByVal idpro As Long) As ArrayList
        Dim p As New pCaravanasRfid
        Return p.listarxproductor(idpro)
    End Function
End Class
