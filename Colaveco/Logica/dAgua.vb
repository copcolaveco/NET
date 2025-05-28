Public Class dAgua
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechaentrada As String
    Private m_idtipopozo As Integer
    Private m_antiguedad As Double
    Private m_distanciapozonegro As Double
    Private m_distanciatambo As Integer
    Private m_envasada As Integer
    Private m_idmuestraextraida As Integer
    Private m_idmuestrafueracondicion As Integer
    Private m_profundidad As Integer
    Private m_idaguatratada As Integer
    Private m_idestadodeconservacion As Integer
    Private m_het22 As Integer
    Private m_het35 As Integer
    Private m_het37 As Integer
    Private m_cloro As Integer
    Private m_conductividad As Integer
    Private m_ph As Integer
    Private m_ecoli As Integer
    Private m_sulfitoreductores As Integer
    Private m_enterococos As Integer
    Private m_estreptococos As Integer
    Private m_marca As Integer
    Private m_muestraoficial As Integer
    Private m_precinto As String
    Private m_paqmacro As Integer
    Private m_ca As Integer
    Private m_mg As Integer
    Private m_na As Integer
    Private m_fe As Integer
    Private m_k As Integer
    Private m_al As Integer
    Private m_cd As Integer
    Private m_cr As Integer
    Private m_cu As Integer
    Private m_pb As Integer
    Private m_mn As Integer
    Private m_fem As Integer
    Private m_zn As Integer
    Private m_se As Integer
    Private m_alcalinidad As Integer
    Private m_refrendacion_tambo As Integer
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
    Public Property FECHAENTRADA() As String
        Get
            Return m_fechaentrada
        End Get
        Set(ByVal value As String)
            m_fechaentrada = value
        End Set
    End Property

    Public Property IDTIPOPOZO() As Integer
        Get
            Return m_idtipopozo
        End Get
        Set(ByVal value As Integer)
            m_idtipopozo = value
        End Set
    End Property
    Public Property ANTIGUEDAD() As Double
        Get
            Return m_antiguedad
        End Get
        Set(ByVal value As Double)
            m_antiguedad = value
        End Set
    End Property
    Public Property DISTANCIAPOZONEGRO() As Double
        Get
            Return m_distanciapozonegro
        End Get
        Set(ByVal value As Double)
            m_distanciapozonegro = value
        End Set
    End Property
    Public Property DISTANCIATAMBO() As Double
        Get
            Return m_distanciatambo
        End Get
        Set(ByVal value As Double)
            m_distanciatambo = value
        End Set
    End Property
    Public Property ENVASADA() As Integer
        Get
            Return m_envasada
        End Get
        Set(ByVal value As Integer)
            m_envasada = value
        End Set
    End Property
    Public Property IDMUESTRAEXTRAIDA() As Integer
        Get
            Return m_idmuestraextraida
        End Get
        Set(ByVal value As Integer)
            m_idmuestraextraida = value
        End Set
    End Property
    Public Property IDMUESTRAFUERACONDICION() As Integer
        Get
            Return m_idmuestrafueracondicion
        End Get
        Set(ByVal value As Integer)
            m_idmuestrafueracondicion = value
        End Set
    End Property
    
    Public Property PROFUNDIDAD() As Integer
        Get
            Return m_profundidad
        End Get
        Set(ByVal value As Integer)
            m_profundidad = value
        End Set
    End Property
    Public Property IDAGUATRATADA() As Integer
        Get
            Return m_idaguatratada
        End Get
        Set(ByVal value As Integer)
            m_idaguatratada = value
        End Set
    End Property
    Public Property IDESTADODECONSERVACION() As Integer
        Get
            Return m_idestadodeconservacion
        End Get
        Set(ByVal value As Integer)
            m_idestadodeconservacion = value
        End Set
    End Property
    Public Property HET22() As Integer
        Get
            Return m_het22
        End Get
        Set(ByVal value As Integer)
            m_het22 = value
        End Set
    End Property
    Public Property HET35() As Integer
        Get
            Return m_het35
        End Get
        Set(ByVal value As Integer)
            m_het35 = value
        End Set
    End Property
    Public Property HET37() As Integer
        Get
            Return m_het37
        End Get
        Set(ByVal value As Integer)
            m_het37 = value
        End Set
    End Property
    Public Property CLORO() As Integer
        Get
            Return m_cloro
        End Get
        Set(ByVal value As Integer)
            m_cloro = value
        End Set
    End Property
    Public Property CONDUCTIVIDAD() As Integer
        Get
            Return m_conductividad
        End Get
        Set(ByVal value As Integer)
            m_conductividad = value
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
    Public Property ECOLI() As Integer
        Get
            Return m_ecoli
        End Get
        Set(ByVal value As Integer)
            m_ecoli = value
        End Set
    End Property
    Public Property SULFITOREDUCTORES() As Integer
        Get
            Return m_sulfitoreductores
        End Get
        Set(ByVal value As Integer)
            m_sulfitoreductores = value
        End Set
    End Property
    Public Property ENTEROCOCOS() As Integer
        Get
            Return m_enterococos
        End Get
        Set(ByVal value As Integer)
            m_enterococos = value
        End Set
    End Property
    Public Property ESTREPTOCOCOS() As Integer
        Get
            Return m_estreptococos
        End Get
        Set(ByVal value As Integer)
            m_estreptococos = value
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
    Public Property MUESTRAOFICIAL() As Integer
        Get
            Return m_muestraoficial
        End Get
        Set(ByVal value As Integer)
            m_muestraoficial = value
        End Set
    End Property
    Public Property PRECINTO() As String
        Get
            Return m_precinto
        End Get
        Set(ByVal value As String)
            m_precinto = value
        End Set
    End Property
    Public Property PAQMACRO() As Integer
        Get
            Return m_paqmacro
        End Get
        Set(ByVal value As Integer)
            m_paqmacro = value
        End Set
    End Property
    Public Property CA() As Integer
        Get
            Return m_ca
        End Get
        Set(ByVal value As Integer)
            m_ca = value
        End Set
    End Property
    Public Property MG() As Integer
        Get
            Return m_mg
        End Get
        Set(ByVal value As Integer)
            m_mg = value
        End Set
    End Property
    Public Property NA() As Integer
        Get
            Return m_na
        End Get
        Set(ByVal value As Integer)
            m_na = value
        End Set
    End Property
    Public Property FE() As Integer
        Get
            Return m_fe
        End Get
        Set(ByVal value As Integer)
            m_fe = value
        End Set
    End Property
    Public Property K() As Integer
        Get
            Return m_k
        End Get
        Set(ByVal value As Integer)
            m_k = value
        End Set
    End Property
    Public Property AL() As Integer
        Get
            Return m_al
        End Get
        Set(ByVal value As Integer)
            m_al = value
        End Set
    End Property
    Public Property CD() As Integer
        Get
            Return m_cd
        End Get
        Set(ByVal value As Integer)
            m_cd = value
        End Set
    End Property
    Public Property CR() As Integer
        Get
            Return m_cr
        End Get
        Set(ByVal value As Integer)
            m_cr = value
        End Set
    End Property
    Public Property CU() As Integer
        Get
            Return m_cu
        End Get
        Set(ByVal value As Integer)
            m_cu = value
        End Set
    End Property
    Public Property PB() As Integer
        Get
            Return m_pb
        End Get
        Set(ByVal value As Integer)
            m_pb = value
        End Set
    End Property
    Public Property MN() As Integer
        Get
            Return m_mn
        End Get
        Set(ByVal value As Integer)
            m_mn = value
        End Set
    End Property
    Public Property FEM() As Integer
        Get
            Return m_fem
        End Get
        Set(ByVal value As Integer)
            m_fem = value
        End Set
    End Property
    Public Property ZN() As Integer
        Get
            Return m_zn
        End Get
        Set(ByVal value As Integer)
            m_zn = value
        End Set
    End Property
    Public Property SE() As Integer
        Get
            Return m_se
        End Get
        Set(ByVal value As Integer)
            m_se = value
        End Set
    End Property
    Public Property ALCALINIDAD() As Integer
        Get
            Return m_alcalinidad
        End Get
        Set(ByVal value As Integer)
            m_alcalinidad = value
        End Set
    End Property
    Public Property REFRENDACION_TAMBO() As Integer
        Get
            Return m_refrendacion_tambo
        End Get
        Set(ByVal value As Integer)
            m_refrendacion_tambo = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_fechaentrada = ""
        m_idtipopozo = 0
        m_antiguedad = 0
        m_distanciapozonegro = 0
        m_distanciatambo = 0
        m_envasada = 0
        m_idmuestraextraida = 0
        m_idmuestrafueracondicion = 1
        m_profundidad = 0
        m_idaguatratada = 0
        m_idestadodeconservacion = 0
        m_het22 = 0
        m_het35 = 0
        m_het37 = 0
        m_cloro = 0
        m_conductividad = 0
        m_ph = 0
        m_ecoli = 0
        m_sulfitoreductores = 0
        m_enterococos = 0
        m_estreptococos = 0
        m_marca = 0
        m_muestraoficial = 0
        m_precinto = ""
        m_paqmacro = 0
        m_ca = 0
        m_mg = 0
        m_na = 0
        m_fe = 0
        m_k = 0
        m_al = 0
        m_cd = 0
        m_cr = 0
        m_cu = 0
        m_pb = 0
        m_mn = 0
        m_fem = 0
        m_zn = 0
        m_se = 0
        m_alcalinidad = 0
        m_refrendacion_tambo = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechaentrada As String, ByVal idtipopozo As Integer, ByVal antiguedad As Double, ByVal distanciapozonegro As Double, ByVal distanciatambo As Double, ByVal envasada As Integer, ByVal idmuestraextraida As Integer, ByVal idmuestrafueracondicion As Integer, ByVal profundidad As Integer, ByVal idaguatratada As Integer, ByVal idestadodeconservacion As Integer, ByVal het22 As Integer, ByVal het35 As Integer, ByVal het37 As Integer, ByVal cloro As Integer, ByVal conductividad As Integer, ByVal ph As Integer, ByVal ecoli As Integer, ByVal sulfitoreductores As Integer, ByVal enterococos As Integer, ByVal estreptococos As Integer, ByVal marca As Integer, ByVal muestraoficial As Integer, ByVal precinto As String, ByVal paqmacro As Integer, ByVal ca As Integer, ByVal mg As Integer, ByVal na As Integer, ByVal fe As Integer, ByVal k As Integer, ByVal al As Integer, ByVal cd As Integer, ByVal cr As Integer, ByVal cu As Integer, ByVal pb As Integer, ByVal mn As Integer, ByVal fem As Integer, ByVal zn As Integer, ByVal se As Integer, ByVal alcalinidad As Integer, ByVal refrendacion_tambo As Integer)
        m_id = id
        m_ficha = ficha
        m_fechaentrada = fechaentrada
        m_idtipopozo = idtipopozo
        m_antiguedad = antiguedad
        m_distanciapozonegro = distanciapozonegro
        m_distanciatambo = distanciatambo
        m_envasada = envasada
        m_idmuestraextraida = idmuestraextraida
        m_idmuestrafueracondicion = idmuestrafueracondicion
        m_profundidad = profundidad
        m_idaguatratada = idaguatratada
        m_idestadodeconservacion = idestadodeconservacion
        m_het22 = het22
        m_het35 = het35
        m_het37 = het37
        m_cloro = cloro
        m_conductividad = conductividad
        m_ph = ph
        m_ecoli = ecoli
        m_sulfitoreductores = sulfitoreductores
        m_enterococos = enterococos
        m_estreptococos = estreptococos
        m_marca = marca
        m_muestraoficial = muestraoficial
        m_precinto = precinto
        m_paqmacro = paqmacro
        m_ca = ca
        m_mg = mg
        m_na = na
        m_fe = fe
        m_k = k
        m_al = al
        m_cd = cd
        m_cr = cr
        m_cu = cu
        m_pb = pb
        m_mn = mn
        m_fem = fem
        m_zn = zn
        m_se = se
        m_alcalinidad = alcalinidad
        m_refrendacion_tambo = refrendacion_tambo
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua
        Return a.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua
        Return a.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAgua
        Dim a As New pAgua
        Return a.buscar(Me)
    End Function
    Public Function buscarxficha() As dAgua
        Dim a As New pAgua
        Return a.buscarxficha(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim a As New pAgua
        Return a.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim a As New pAgua
        Return a.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a As New pAgua
        Return a.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a As New pAgua
        Return a.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a As New pAgua
        Return a.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a As New pAgua
        Return a.listarporfecha(fechadesde, fechahasta)
    End Function
    Public Function tieneRefrendacionTambo(ByVal fichaId As Long) As Boolean
        Dim a As New pAgua
        Return a.tieneRefrendacionTambo(fichaId)
    End Function
End Class
