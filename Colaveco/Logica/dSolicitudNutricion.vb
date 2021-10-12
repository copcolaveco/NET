Public Class dSolicitudNutricion
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_mga As Integer
    Private m_mgb As Integer
    Private m_ensilados As Integer
    Private m_pasturas As Integer
    Private m_extetereo As Integer
    Private m_nida As Integer
    Private m_micotoxinas As Integer
    Private m_don As Integer
    Private m_afla As Integer
    Private m_zeara As Integer
    Private m_proteinas As Integer
    Private m_materiaseca As Integer
    Private m_ph As Integer
    Private m_fibraefectiva As Integer
    Private m_clostridios As Integer
    Private m_timac As Integer
    Private m_timacproteina As Integer
    Private m_fibraneutra As Integer
    Private m_fibraacida As Integer
    
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
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property MGA() As Integer
        Get
            Return m_mga
        End Get
        Set(ByVal value As Integer)
            m_mga = value
        End Set
    End Property
    Public Property MGB() As Integer
        Get
            Return m_mgb
        End Get
        Set(ByVal value As Integer)
            m_mgb = value
        End Set
    End Property
    Public Property ENSILADOS() As Integer
        Get
            Return m_ensilados
        End Get
        Set(ByVal value As Integer)
            m_ensilados = value
        End Set
    End Property
    Public Property PASTURAS() As Integer
        Get
            Return m_pasturas
        End Get
        Set(ByVal value As Integer)
            m_pasturas = value
        End Set
    End Property
    Public Property EXTETEREO() As Integer
        Get
            Return m_extetereo
        End Get
        Set(ByVal value As Integer)
            m_extetereo = value
        End Set
    End Property
    Public Property NIDA() As Integer
        Get
            Return m_nida
        End Get
        Set(ByVal value As Integer)
            m_nida = value
        End Set
    End Property
    Public Property MICOTOXINAS() As Integer
        Get
            Return m_micotoxinas
        End Get
        Set(ByVal value As Integer)
            m_micotoxinas = value
        End Set
    End Property
    Public Property DON() As Integer
        Get
            Return m_don
        End Get
        Set(ByVal value As Integer)
            m_don = value
        End Set
    End Property
    Public Property AFLA() As Integer
        Get
            Return m_afla
        End Get
        Set(ByVal value As Integer)
            m_afla = value
        End Set
    End Property
    Public Property ZEARA() As Integer
        Get
            Return m_zeara
        End Get
        Set(ByVal value As Integer)
            m_zeara = value
        End Set
    End Property
    Public Property PROTEINAS() As Integer
        Get
            Return m_proteinas
        End Get
        Set(ByVal value As Integer)
            m_proteinas = value
        End Set
    End Property
    Public Property MATERIASECA() As Integer
        Get
            Return m_materiaseca
        End Get
        Set(ByVal value As Integer)
            m_materiaseca = value
        End Set
    End Property
    Public Property PH() As Integer
        Get
            Return m_ph
        End Get
        Set(ByVal value As Integer)
            m_ph = value
        End Set
    End Property
    Public Property FIBRAEFECTIVA() As Integer
        Get
            Return m_fibraefectiva
        End Get
        Set(ByVal value As Integer)
            m_fibraefectiva = value
        End Set
    End Property
    Public Property CLOSTRIDIOS() As Integer
        Get
            Return m_clostridios
        End Get
        Set(ByVal value As Integer)
            m_clostridios = value
        End Set
    End Property
    Public Property TIMAC() As Integer
        Get
            Return m_timac
        End Get
        Set(ByVal value As Integer)
            m_timac = value
        End Set
    End Property
    Public Property TIMACPROTEINA() As Integer
        Get
            Return m_timacproteina
        End Get
        Set(ByVal value As Integer)
            m_timacproteina = value
        End Set
    End Property
    Public Property FIBRANEUTRA() As Integer
        Get
            Return m_fibraneutra
        End Get
        Set(ByVal value As Integer)
            m_fibraneutra = value
        End Set
    End Property
    Public Property FIBRAACIDA() As Integer
        Get
            Return m_fibraacida
        End Get
        Set(ByVal value As Integer)
            m_fibraacida = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_muestra = ""
        m_mga = 0
        m_mgb = 0
        m_ensilados = 0
        m_pasturas = 0
        m_extetereo = 0
        m_nida = 0
        m_micotoxinas = 0
        m_don = 0
        m_afla = 0
        m_zeara = 0
        m_proteinas = 0
        m_materiaseca = 0
        m_ph = 0
        m_fibraefectiva = 0
        m_clostridios = 0
        m_timac = 0
        m_timacproteina = 0
        m_fibraneutra = 0
        m_fibraacida = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal mga As Integer, ByVal mgb As Integer, ByVal ensilados As Integer, ByVal pasturas As Integer, ByVal extetereo As Integer, ByVal nida As Integer, ByVal micotoxinas As Integer, ByVal don As Integer, ByVal afla As Integer, ByVal zeara As Integer, ByVal proteinas As Integer, ByVal materiaseca As Integer, ByVal ph As Integer, ByVal fibraefectiva As Integer, ByVal clostridios As Integer, ByVal timac As Integer, ByVal timacproteina As Integer, ByVal fibraneutra As Integer, ByVal fibraacida As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_mga = mga
        m_mgb = mgb
        m_ensilados = ensilados
        m_pasturas = pasturas
        m_extetereo = extetereo
        m_nida = nida
        m_micotoxinas = micotoxinas
        m_don = don
        m_afla = afla
        m_zeara = zeara
        m_proteinas = proteinas
        m_materiaseca = materiaseca
        m_ph = ph
        m_fibraefectiva = fibraefectiva
        m_clostridios = clostridios
        m_timac = timac
        m_timacproteina = timacproteina
        m_fibraneutra = fibraneutra
        m_fibraacida = fibraacida

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim sn As New pSolicitudNutricion
        Return sn.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim sn As New pSolicitudNutricion
        Return sn.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim sn As New pSolicitudNutricion
        Return sn.eliminar(Me, usuario)
    End Function
    Public Function eliminar2(ByVal usuario As dUsuario) As Boolean
        Dim sn As New pSolicitudNutricion
        Return sn.eliminar2(Me, usuario)
    End Function
    
    Public Function buscar() As dSolicitudNutricion
        Dim sn As New pSolicitudNutricion
        Return sn.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dSolicitudNutricion
        Dim sn As New pSolicitudNutricion
        Return sn.buscarxfichaxmuestra(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim sn As New pSolicitudNutricion
        Return sn.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim sn As New pSolicitudNutricion
        Return sn.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sn As New pSolicitudNutricion
        Return sn.listarporid(texto)
    End Function
    
    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sn As New pSolicitudNutricion
        Return sn.listarporsolicitud(texto)
    End Function
   
    
End Class
