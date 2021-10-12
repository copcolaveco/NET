Public Class dParasitologiaSolicitud
#Region "Atributos"

    Private m_id As Long
    Private m_ficha As Long
    Private m_gastrointestinales As Integer
    Private m_fasciola As Integer
    Private m_coccidias As Integer
    Private m_coproparasitario_can As Integer


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
    Public Property GASTROINTESTINALES() As Integer
        Get
            Return m_gastrointestinales
        End Get
        Set(ByVal value As Integer)
            m_gastrointestinales = value
        End Set
    End Property
    Public Property FASCIOLA() As Integer
        Get
            Return m_fasciola
        End Get
        Set(ByVal value As Integer)
            m_fasciola = value
        End Set
    End Property
    Public Property COCCIDIAS() As Integer
        Get
            Return m_coccidias
        End Get
        Set(ByVal value As Integer)
            m_coccidias = value
        End Set
    End Property
    Public Property COPROPARASITARIO_CAN() As Integer
        Get
            Return m_coproparasitario_can
        End Get
        Set(ByVal value As Integer)
            m_coproparasitario_can = value
        End Set
    End Property
    
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_gastrointestinales = 0
        m_fasciola = 0
        m_coccidias = 0
        m_coproparasitario_can = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal gastrointestinales As Integer, ByVal fasciola As Integer, ByVal coccidias As Integer, ByVal coproparasitario_can As Integer)
        m_id = id
        m_ficha = ficha
        m_gastrointestinales = gastrointestinales
        m_fasciola = fasciola
        m_coccidias = coccidias
        m_coproparasitario_can = coproparasitario_can

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pParasitologiaSolicitud
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pParasitologiaSolicitud
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pParasitologiaSolicitud
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dParasitologiaSolicitud
        Dim c As New pParasitologiaSolicitud
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pParasitologiaSolicitud
        Return c.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim c As New pParasitologiaSolicitud
        Return c.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pParasitologiaSolicitud
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pParasitologiaSolicitud
        Return c.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim c As New pParasitologiaSolicitud
        Return c.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim c As New pParasitologiaSolicitud
        Return c.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
