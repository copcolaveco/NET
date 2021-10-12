Public Class dAmbientalSolicitud
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_enterobacterias As Integer
    Private m_listambiental As Integer
    Private m_listmono As Integer
    Private m_salmonella As Integer
    Private m_ecoli As Integer
    Private m_mohosylevaduras As Integer
    Private m_rb As Integer
    Private m_ct As Integer
    Private m_cf As Integer
    Private m_pseudomonaspp As Integer
    Private m_listspp As Integer
    Private m_estaf As Integer
    
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
    Public Property ENTEROBACTERIAS() As Integer
        Get
            Return m_enterobacterias
        End Get
        Set(ByVal value As Integer)
            m_enterobacterias = value
        End Set
    End Property
    Public Property LISTAMBIENTAL() As Integer
        Get
            Return m_listambiental
        End Get
        Set(ByVal value As Integer)
            m_listambiental = value
        End Set
    End Property
    Public Property LISTMONO() As Integer
        Get
            Return m_listmono
        End Get
        Set(ByVal value As Integer)
            m_listmono = value
        End Set
    End Property
    Public Property SALMONELLA() As Integer
        Get
            Return m_salmonella
        End Get
        Set(ByVal value As Integer)
            m_salmonella = value
        End Set
    End Property
    Public Property ECOLI() As Integer
        Get
            Return m_ecoli
        End Get
        Set(ByVal value As Integer)
            m_ecoli = value
        End Set
    End Property
    Public Property MOHOSYLEVADURAS() As Integer
        Get
            Return m_mohosylevaduras
        End Get
        Set(ByVal value As Integer)
            m_mohosylevaduras = value
        End Set
    End Property
    Public Property RB() As Integer
        Get
            Return m_rb
        End Get
        Set(ByVal value As Integer)
            m_rb = value
        End Set
    End Property
    Public Property CT() As Integer
        Get
            Return m_ct
        End Get
        Set(ByVal value As Integer)
            m_ct = value
        End Set
    End Property
    Public Property CF() As Integer
        Get
            Return m_cf
        End Get
        Set(ByVal value As Integer)
            m_cf = value
        End Set
    End Property
    Public Property PSEUDOMONASPP() As Integer
        Get
            Return m_pseudomonaspp
        End Get
        Set(ByVal value As Integer)
            m_pseudomonaspp = value
        End Set
    End Property
    Public Property LISTSPP() As Integer
        Get
            Return m_listspp
        End Get
        Set(ByVal value As Integer)
            m_listspp = value
        End Set
    End Property
    Public Property ESTAFCOAGPOS() As Integer
        Get
            Return m_estaf
        End Get
        Set(ByVal value As Integer)
            m_estaf = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_enterobacterias = 0
        m_listambiental = 0
        m_listmono = 0
        m_salmonella = 0
        m_ecoli = 0
        m_mohosylevaduras = 0
        m_rb = 0
        m_ct = 0
        m_cf = 0
        m_pseudomonaspp = 0
        m_listspp = 0
        m_estaf = 0
        
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal enterobacterias As Integer, ByVal listambiental As Integer, ByVal listmono As Integer, ByVal salmonella As Integer, ByVal ecoli As Integer, ByVal mohosylevaduras As Integer, ByVal rb As Integer, ByVal ct As Integer, ByVal cf As Integer, ByVal pseudomonaspp As Integer, ByVal listspp As Integer, ByVal estaf As Integer)
        m_id = id
        m_ficha = ficha
        m_enterobacterias = enterobacterias
        m_listambiental = listambiental
        m_listmono = listmono
        m_salmonella = salmonella
        m_ecoli = ecoli
        m_mohosylevaduras = mohosylevaduras
        m_rb = rb
        m_ct = ct
        m_cf = cf
        m_pseudomonaspp = pseudomonaspp
        m_listspp = listspp
        m_estaf = estaf

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbientalSolicitud
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbientalSolicitud
        Return a.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbientalSolicitud
        Return a.eliminar(Me, usuario)
    End Function
    Public Function eliminar2(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAmbientalSolicitud
        Return a.eliminar2(Me, usuario)
    End Function
    Public Function buscar() As dAmbientalSolicitud
        Dim a As New pAmbientalSolicitud
        Return a.buscar(Me)
    End Function
    Public Function buscarxsolicitud() As dAmbientalSolicitud
        Dim a As New pAmbientalSolicitud
        Return a.buscarxsolicitud(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim a As New pAmbientalSolicitud
        Return a.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim a As New pAmbientalSolicitud
        Return a.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a As New pAmbientalSolicitud
        Return a.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a As New pAmbientalSolicitud
        Return a.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a As New pAmbientalSolicitud
        Return a.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a As New pAmbientalSolicitud
        Return a.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
