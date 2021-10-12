Public Class dAntibiograma
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechasolicitud As String
    Private m_fechaproceso As String
    Private m_idanimal As String
    Private m_tratado As Integer
    Private m_tratamiento As Integer
    Private m_idmicroorgaislado24 As Integer
    Private m_idmicroorgaislado48 As Integer
    Private m_rc As Integer
    Private m_idtipo As Integer
    Private m_combo As Integer
    Private m_p As Integer
    Private m_cf As Integer
    Private m_ox As Integer
    Private m_sxt As Integer
    Private m_amc As Integer
    Private m_ra As Integer
    Private m_e As Integer
    Private m_t As Integer
    Private m_eno As Integer
    Private m_gm As Integer
    Private m_am As Integer
    Private m_operador As Integer
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
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
    Public Property FECHASOLICITUD() As String
        Get
            Return m_fechasolicitud
        End Get
        Set(ByVal value As String)
            m_fechasolicitud = value
        End Set
    End Property
    Public Property FECHAPROCESO() As String
        Get
            Return m_fechaproceso
        End Get
        Set(ByVal value As String)
            m_fechaproceso = value
        End Set
    End Property
    Public Property IDANIMAL() As String
        Get
            Return m_idanimal
        End Get
        Set(ByVal value As String)
            m_idanimal = value
        End Set
    End Property
    Public Property TRATADO() As Integer
        Get
            Return m_tratado
        End Get
        Set(ByVal value As Integer)
            m_tratado = value
        End Set
    End Property
    Public Property TRATAMIENTO() As Integer
        Get
            Return m_tratamiento
        End Get
        Set(ByVal value As Integer)
            m_tratamiento = value
        End Set
    End Property
    Public Property IDMICROORGAISLADO24() As Integer
        Get
            Return m_idmicroorgaislado24
        End Get
        Set(ByVal value As Integer)
            m_idmicroorgaislado24 = value
        End Set
    End Property
    Public Property IDMICROORGAISLADO48() As Integer
        Get
            Return m_idmicroorgaislado48
        End Get
        Set(ByVal value As Integer)
            m_idmicroorgaislado48 = value
        End Set
    End Property
    Public Property RC() As Integer
        Get
            Return m_rc
        End Get
        Set(ByVal value As Integer)
            m_rc = value
        End Set
    End Property
    Public Property IDTIPO() As Integer
        Get
            Return m_idtipo
        End Get
        Set(ByVal value As Integer)
            m_idtipo = value
        End Set
    End Property
    Public Property COMBO() As Integer
        Get
            Return m_combo
        End Get
        Set(ByVal value As Integer)
            m_combo = value
        End Set
    End Property
    Public Property P() As Integer
        Get
            Return m_p
        End Get
        Set(ByVal value As Integer)
            m_p = value
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
    Public Property OX() As Integer
        Get
            Return m_ox
        End Get
        Set(ByVal value As Integer)
            m_ox = value
        End Set
    End Property
    Public Property SXT() As Integer
        Get
            Return m_sxt
        End Get
        Set(ByVal value As Integer)
            m_sxt = value
        End Set
    End Property
    Public Property AMC() As Integer
        Get
            Return m_amc
        End Get
        Set(ByVal value As Integer)
            m_amc = value
        End Set
    End Property
    Public Property RA() As Integer
        Get
            Return m_ra
        End Get
        Set(ByVal value As Integer)
            m_ra = value
        End Set
    End Property
    Public Property E() As Integer
        Get
            Return m_e
        End Get
        Set(ByVal value As Integer)
            m_e = value
        End Set
    End Property
    Public Property T() As Integer
        Get
            Return m_t
        End Get
        Set(ByVal value As Integer)
            m_t = value
        End Set
    End Property
    Public Property ENO() As Integer
        Get
            Return m_eno
        End Get
        Set(ByVal value As Integer)
            m_eno = value
        End Set
    End Property
    Public Property GM() As Integer
        Get
            Return m_gm
        End Get
        Set(ByVal value As Integer)
            m_gm = value
        End Set
    End Property
    Public Property AM() As Integer
        Get
            Return m_am
        End Get
        Set(ByVal value As Integer)
            m_am = value
        End Set
    End Property
    Public Property OPERADOR() As Integer
        Get
            Return m_operador
        End Get
        Set(ByVal value As Integer)
            m_operador = value
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
        m_ficha = 0
        m_fechasolicitud = ""
        m_fechaproceso = ""
        m_idanimal = 0
        m_tratado = 0
        m_tratamiento = 0
        m_idmicroorgaislado24 = 0
        m_idmicroorgaislado48 = 0
        m_rc = 0
        m_idtipo = 0
        m_combo = 0
        m_p = 0
        m_cf = 0
        m_ox = 0
        m_sxt = 0
        m_amc = 0
        m_ra = 0
        m_e = 0
        m_t = 0
        m_eno = 0
        m_gm = 0
        m_am = 0
        m_operador = 0
        m_marca = 0
        
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechasolicitud As String, ByVal fechaproceso As String, _
                   ByVal idanimal As String, ByVal tratado As Integer, ByVal tratamiento As Integer, ByVal idmicroorgaislado24 As Integer, ByVal idmicroorgaislado48 As Integer, ByVal rc As Integer, _
                   ByVal idtipo As Integer, ByVal combo As Integer, ByVal p As Integer, ByVal cf As Integer, ByVal ox As Integer, _
                   ByVal sxt As Integer, ByVal amc As Integer, ByVal ra As Integer, ByVal e As Integer, _
                   ByVal t As Integer, ByVal eno As Integer, ByVal gm As Integer, ByVal am As Integer, _
                   ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechasolicitud = fechasolicitud
        m_fechaproceso = fechaproceso
        m_idanimal = idanimal
        m_tratado = tratado
        m_tratamiento = tratamiento
        m_idmicroorgaislado24 = idmicroorgaislado24
        m_idmicroorgaislado48 = idmicroorgaislado48
        m_rc = rc
        m_idtipo = idtipo
        m_combo = combo
        m_p = p
        m_cf = cf
        m_ox = ox
        m_sxt = sxt
        m_amc = amc
        m_ra = ra
        m_e = e
        m_t = t
        m_eno = eno
        m_gm = gm
        m_am = am
        m_operador = operador
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAntibiograma
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAntibiograma
        Return a.modificar(Me, usuario)
    End Function
    Public Function desmarcarficha() As Boolean
        Dim a As New pAntibiograma
        Return a.desmarcarficha(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAntibiograma
        Return a.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAntibiograma
        Dim a As New pAntibiograma
        Return a.buscar(Me)
    End Function
    
#End Region

    Public Overrides Function ToString() As String
        
        Return m_ficha & Chr(9) & m_idanimal
    End Function
    Public Function listar() As ArrayList
        Dim a As New pAntibiograma
        Return a.listar
    End Function
    Public Function listarpormuestra(ByVal texto As Long) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarpormuestra(texto)
    End Function
    Public Function listarfichas() As ArrayList
        Dim a As New pAntibiograma
        Return a.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarporid(texto)
    End Function
    
    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarporsolicitud2(texto)
    End Function
    Public Function listarcaravanas(ByVal texto As Long) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarcaravanas(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarporfecha(fechadesde, fechahasta)
    End Function
    Public Function listaraislamientos(ByVal texto As Long) As ArrayList
        Dim a As New pAntibiograma
        Return a.listaraislamientos(texto)
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarxfecha(desde, hasta)
    End Function
    Public Function listar_fichas(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim a As New pAntibiograma
        Return a.listar_fichas(desde, hasta)
    End Function
    Public Function listar_muestras(ByVal idsolic As Long) As ArrayList
        Dim a As New pAntibiograma
        Return a.listar_muestras(idsolic)
    End Function
    Public Function listarxidanimal(ByVal idsol As Long, ByVal idanimal As String) As ArrayList
        Dim a As New pAntibiograma
        Return a.listarxidanimal(idsol, idanimal)
    End Function
End Class

