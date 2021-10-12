Public Class dBacteriologia
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechasolicitud As String
    Private m_fechaproceso As String
    Private m_idmuestra As String
    Private m_rc As String
    Private m_rb As String
    Private m_coliformes As String
    Private m_termoduricos As String
    Private m_estreptococoag As String
    Private m_estreptococodys As String
    Private m_estreptococoub As String
    Private m_estreptococospp As String
    Private m_estafilococoau As String
    Private m_estapylocococoagneg As String
    Private m_psicrotrofos As String
    Private m_corynebacterium As String
    Private m_otros As String
    Private m_observaciones As String
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
    Public Property IDMUESTRA() As String
        Get
            Return m_idmuestra
        End Get
        Set(ByVal value As String)
            m_idmuestra = value
        End Set
    End Property
    Public Property RC() As String
        Get
            Return m_rc
        End Get
        Set(ByVal value As String)
            m_rc = value
        End Set
    End Property
    Public Property RB() As String
        Get
            Return m_rb
        End Get
        Set(ByVal value As String)
            m_rb = value
        End Set
    End Property
    Public Property COLIFORMES() As String
        Get
            Return m_coliformes
        End Get
        Set(ByVal value As String)
            m_coliformes = value
        End Set
    End Property
    Public Property TERMODURICOS() As String
        Get
            Return m_termoduricos
        End Get
        Set(ByVal value As String)
            m_termoduricos = value
        End Set
    End Property
    Public Property ESTREPTOCOCOAG() As String
        Get
            Return m_estreptococoag
        End Get
        Set(ByVal value As String)
            m_estreptococoag = value
        End Set
    End Property
    Public Property ESTREPTOCOCODYS() As String
        Get
            Return m_estreptococodys
        End Get
        Set(ByVal value As String)
            m_estreptococodys = value
        End Set
    End Property
    Public Property ESTREPTOCOCOUB() As String
        Get
            Return m_estreptococoub
        End Get
        Set(ByVal value As String)
            m_estreptococoub = value
        End Set
    End Property
    Public Property ESTREPTOCOCOSPP() As String
        Get
            Return m_estreptococospp
        End Get
        Set(ByVal value As String)
            m_estreptococospp = value
        End Set
    End Property
    Public Property ESTAFILOCOCOAU() As String
        Get
            Return m_estafilococoau
        End Get
        Set(ByVal value As String)
            m_estafilococoau = value
        End Set
    End Property
    Public Property ESTAPYLOCOCOCOAGNEG() As String
        Get
            Return m_estapylocococoagneg
        End Get
        Set(ByVal value As String)
            m_estapylocococoagneg = value
        End Set
    End Property
    Public Property PSICROTROFOS() As String
        Get
            Return m_psicrotrofos
        End Get
        Set(ByVal value As String)
            m_psicrotrofos = value
        End Set
    End Property
    Public Property CORYNEBACTERIUM() As String
        Get
            Return m_corynebacterium
        End Get
        Set(ByVal value As String)
            m_corynebacterium = value
        End Set
    End Property
    Public Property OTROS() As String
        Get
            Return m_otros
        End Get
        Set(ByVal value As String)
            m_otros = value
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
        m_idmuestra = 0
        m_rc = ""
        m_rb = ""
        m_coliformes = ""
        m_termoduricos = ""
        m_estreptococoag = ""
        m_estreptococodys = ""
        m_estreptococoub = ""
        m_estreptococospp = ""
        m_estafilococoau = ""
        m_estapylocococoagneg = ""
        m_psicrotrofos = ""
        m_corynebacterium = ""
        m_otros = ""
        m_observaciones = ""
        m_operador = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechasolicitud As String, ByVal fechaproceso As String, ByVal idmuestra As String, ByVal rc As String, ByVal rb As String, ByVal coliformes As String, ByVal termoduricos As String, ByVal estreptococoag As String, ByVal estreptococodys As String, ByVal estreptococoub As String, ByVal estreptococospp As String, ByVal estafilococoau As String, ByVal estapylocococoagneg As String, ByVal psicrotrofos As String, ByVal corynebacterium As String, ByVal otros As String, ByVal observaciones As String, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechasolicitud = fechasolicitud
        m_fechaproceso = fechaproceso
        m_idmuestra = idmuestra
        m_rc = rc
        m_rb = rb
        m_coliformes = coliformes
        m_termoduricos = termoduricos
        m_estreptococoag = estreptococoag
        m_estreptococodys = estreptococodys
        m_estreptococoub = estreptococoub
        m_estreptococospp = estreptococospp
        m_estafilococoau = estafilococoau
        m_estapylocococoagneg = estapylocococoagneg
        m_psicrotrofos = psicrotrofos
        m_corynebacterium = corynebacterium
        m_otros = otros
        m_observaciones = observaciones
        m_operador = operador
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pBacteriologia
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pBacteriologia
        Return a.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim a As New pBacteriologia
        Return a.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pBacteriologia
        Return a.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dBacteriologia
        Dim a As New pBacteriologia
        Return a.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha & Chr(9) & m_idmuestra
    End Function
    Public Function listar() As ArrayList
        Dim a As New pBacteriologia
        Return a.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim a As New pBacteriologia
        Return a.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a As New pBacteriologia
        Return a.listarporid(texto)
    End Function
    Public Function listarporid2(ByVal texto As Long) As ArrayList
        Dim a As New pBacteriologia
        Return a.listarporid2(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a As New pBacteriologia
        Return a.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a As New pBacteriologia
        Return a.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a As New pBacteriologia
        Return a.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
