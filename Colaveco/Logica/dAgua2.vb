Public Class dAgua2
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechaentrada As String
    Private m_fechaemision As String
    Private m_idmuestra As String
    Private m_observaciones As String
    Private m_coliformestotales As Integer
    Private m_coliformesfecales As Integer
    Private m_idaspecto As Integer
    Private m_idolor As Integer
    Private m_idcolor As Integer
    Private m_ph As Double
    Private m_idmateriaorganica As Integer
    Private m_conductividad As Double
    Private m_iddureza As Integer
    Private m_nitrato As String
    Private m_nitrito As String
    Private m_fechaprocesamiento As String
    Private m_heterotroficos As Double
    Private m_turbiedad As Double
    Private m_nitratotiras As Integer
    Private m_nitritotiras As Integer
    Private m_dureza As String
    Private m_volumendesiembra As Integer
    Private m_volumendesiembra2 As Integer
    Private m_tecnica As Integer
    Private m_heterotroficos37 As Double
    Private m_heterotroficos35 As Double
    Private m_clorolibre As Double
    Private m_clororesidual As Double
    Private m_pseudomonasaeruginosa As Integer
    Private m_pseudomonaspp As Integer
    Private m_endo35 As String
    Private m_mfc44_5 As String
    Private m_centrimide37 As String
    Private m_mhpc As String
    Private m_aguadedilucion As String
    Private m_ecoli As Integer
    Private m_sulfitoreductores As Integer
    Private m_enterococos As Integer
    Private m_estreptococos As Integer
    Private m_lotenitrato As String
    Private m_lotenitrito As String
    Private m_lotedureza As String
    Private m_operador As Integer
    Private m_medios As Integer
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
    Public Property FECHAENTRADA() As String
        Get
            Return m_fechaentrada
        End Get
        Set(ByVal value As String)
            m_fechaentrada = value
        End Set
    End Property
    Public Property FECHAEMISION() As String
        Get
            Return m_fechaemision
        End Get
        Set(ByVal value As String)
            m_fechaemision = value
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
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
    Public Property COLIFORMESTOTALES() As Integer
        Get
            Return m_coliformestotales
        End Get
        Set(ByVal value As Integer)
            m_coliformestotales = value
        End Set
    End Property
    Public Property COLIFORMESFECALES() As Integer
        Get
            Return m_coliformesfecales
        End Get
        Set(ByVal value As Integer)
            m_coliformesfecales = value
        End Set
    End Property
    
    Public Property IDASPECTO() As Integer
        Get
            Return m_idaspecto
        End Get
        Set(ByVal value As Integer)
            m_idaspecto = value
        End Set
    End Property
    Public Property IDOLOR() As Integer
        Get
            Return m_idolor
        End Get
        Set(ByVal value As Integer)
            m_idolor = value
        End Set
    End Property
    Public Property IDCOLOR() As Integer
        Get
            Return m_idcolor
        End Get
        Set(ByVal value As Integer)
            m_idcolor = value
        End Set
    End Property
    Public Property PH() As Double
        Get
            Return m_ph
        End Get
        Set(ByVal value As Double)
            m_ph = value
        End Set
    End Property
    Public Property IDMATERIAORGANICA() As Integer
        Get
            Return m_idmateriaorganica
        End Get
        Set(ByVal value As Integer)
            m_idmateriaorganica = value
        End Set
    End Property
    Public Property CONDUCTIVIDAD() As Double
        Get
            Return m_conductividad
        End Get
        Set(ByVal value As Double)
            m_conductividad = value
        End Set
    End Property
    Public Property IDDUREZA() As Integer
        Get
            Return m_iddureza
        End Get
        Set(ByVal value As Integer)
            m_iddureza = value
        End Set
    End Property
    Public Property NITRATO() As String
        Get
            Return m_nitrato
        End Get
        Set(ByVal value As String)
            m_nitrato = value
        End Set
    End Property
    Public Property NITRITO() As String
        Get
            Return m_nitrito
        End Get
        Set(ByVal value As String)
            m_nitrito = value
        End Set
    End Property
    Public Property FECHAPROCESAMIENTO() As String
        Get
            Return m_fechaprocesamiento
        End Get
        Set(ByVal value As String)
            m_fechaprocesamiento = value
        End Set
    End Property

    Public Property HETEROTROFICOS() As Double
        Get
            Return m_heterotroficos
        End Get
        Set(ByVal value As Double)
            m_heterotroficos = value
        End Set
    End Property
    Public Property TURBIEDAD() As Double
        Get
            Return m_turbiedad
        End Get
        Set(ByVal value As Double)
            m_turbiedad = value
        End Set
    End Property
   
    Public Property NITRATOTIRAS() As Integer
        Get
            Return m_nitratotiras
        End Get
        Set(ByVal value As Integer)
            m_nitratotiras = value
        End Set
    End Property
    Public Property NITRITOTIRAS() As Integer
        Get
            Return m_nitritotiras
        End Get
        Set(ByVal value As Integer)
            m_nitritotiras = value
        End Set
    End Property
    Public Property DUREZA() As String
        Get
            Return m_dureza
        End Get
        Set(ByVal value As String)
            m_dureza = value
        End Set
    End Property
    Public Property VOLUMENDESIEMBRA() As Integer
        Get
            Return m_volumendesiembra
        End Get
        Set(ByVal value As Integer)
            m_volumendesiembra = value
        End Set
    End Property
    Public Property VOLUMENDESIEMBRA2() As Integer
        Get
            Return m_volumendesiembra2
        End Get
        Set(ByVal value As Integer)
            m_volumendesiembra2 = value
        End Set
    End Property
    Public Property TECNICA() As Integer
        Get
            Return m_tecnica
        End Get
        Set(ByVal value As Integer)
            m_tecnica = value
        End Set
    End Property
   
    Public Property HETEROTROFICOS37() As Double
        Get
            Return m_heterotroficos37
        End Get
        Set(ByVal value As Double)
            m_heterotroficos37 = value
        End Set
    End Property
    Public Property HETEROTROFICOS35() As Double
        Get
            Return m_heterotroficos35
        End Get
        Set(ByVal value As Double)
            m_heterotroficos35 = value
        End Set
    End Property
    Public Property CLOROLIBRE() As Double
        Get
            Return m_clorolibre
        End Get
        Set(ByVal value As Double)
            m_clorolibre = value
        End Set
    End Property
    Public Property CLORORESIDUAL() As Double
        Get
            Return m_clororesidual
        End Get
        Set(ByVal value As Double)
            m_clororesidual = value
        End Set
    End Property
    Public Property PSEUDOMONASAERUGINOSA() As Integer
        Get
            Return m_pseudomonasaeruginosa
        End Get
        Set(ByVal value As Integer)
            m_pseudomonasaeruginosa = value
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
    Public Property ENDO35() As String
        Get
            Return m_endo35
        End Get
        Set(ByVal value As String)
            m_endo35 = value
        End Set
    End Property
    Public Property MFC44_5() As String
        Get
            Return m_mfc44_5
        End Get
        Set(ByVal value As String)
            m_mfc44_5 = value
        End Set
    End Property
    Public Property CENTRIMIDE37() As String
        Get
            Return m_centrimide37
        End Get
        Set(ByVal value As String)
            m_centrimide37 = value
        End Set
    End Property
    Public Property MHPC() As String
        Get
            Return m_mhpc
        End Get
        Set(ByVal value As String)
            m_mhpc = value
        End Set
    End Property
    
    Public Property AGUADEDILUCION() As String
        Get
            Return m_aguadedilucion
        End Get
        Set(ByVal value As String)
            m_aguadedilucion = value
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
    Public Property LOTENITRATO() As String
        Get
            Return m_lotenitrato
        End Get
        Set(ByVal value As String)
            m_lotenitrato = value
        End Set
    End Property
    Public Property LOTENITRITO() As String
        Get
            Return m_lotenitrito
        End Get
        Set(ByVal value As String)
            m_lotenitrito = value
        End Set
    End Property
    Public Property LOTEDUREZA() As String
        Get
            Return m_lotedureza
        End Get
        Set(ByVal value As String)
            m_lotedureza = value
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
    Public Property MEDIOS() As Integer
        Get
            Return m_medios
        End Get
        Set(ByVal value As Integer)
            m_medios = value
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
        m_fechaentrada = ""
        m_fechaemision = ""
        m_idmuestra = 0
        m_observaciones = ""
        m_coliformestotales = 0
        m_coliformesfecales = 0
        m_idaspecto = 0
        m_idolor = 0
        m_idcolor = 0
        m_ph = 0
        m_idmateriaorganica = 0
        m_conductividad = 0
        m_iddureza = 0
        m_nitrato = ""
        m_nitrito = ""
        m_fechaprocesamiento = ""
        m_heterotroficos = 0
        m_turbiedad = 0
        m_nitratotiras = 0
        m_nitritotiras = 0
        m_dureza = ""
        m_volumendesiembra = 0
        m_volumendesiembra2 = 0
        m_tecnica = 0
        m_heterotroficos37 = 0
        m_heterotroficos35 = 0
        m_clorolibre = 0
        m_clororesidual = 0
        m_pseudomonasaeruginosa = 0
        m_pseudomonaspp = 0
        m_endo35 = ""
        m_mfc44_5 = ""
        m_centrimide37 = ""
        m_mhpc = ""
        m_aguadedilucion = ""
        m_ecoli = 0
        m_sulfitoreductores = 0
        m_enterococos = 0
        m_estreptococos = 0
        m_lotenitrato = ""
        m_lotenitrito = ""
        m_lotedureza = ""
        m_operador = 0
        m_medios = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechaentrada As String, ByVal fechaemision As String, ByVal idmuestra As String, ByVal observaciones As String, ByVal coliformestotales As Integer, ByVal coliformesfecales As Integer, ByVal idaspecto As Integer, ByVal idolor As Integer, ByVal idcolor As Integer, ByVal ph As Double, ByVal idmateriaorganica As Integer, ByVal conductividad As Double, ByVal iddureza As Integer, ByVal nitrato As String, ByVal nitrito As String, ByVal fechaprocesamiento As String, ByVal heterotroficos As Double, ByVal turbiedad As Double, ByVal nitratotiras As Integer, ByVal nitritotiras As Integer, ByVal dureza As String, ByVal volumendesiembra As Integer, ByVal volumendesiembra2 As Integer, ByVal tecnica As Integer, ByVal heterotroficos37 As Double, ByVal heterotroficos35 As Double, ByVal clorolibre As Double, ByVal clororesidual As Double, ByVal pseudomonasaeruginosa As Integer, ByVal pseudomonaspp As Integer, ByVal endo35 As String, ByVal mfc44_5 As String, ByVal centrimide37 As String, ByVal mhpc As String, ByVal aguadedilucion As String, ByVal ecoli As Integer, ByVal sulfitoreductores As Integer, ByVal enterococos As Integer, ByVal estreptococos As Integer, ByVal lotenitrato As String, ByVal lotenitrito As String, ByVal lotedureza As String, ByVal operador As Integer, ByVal medios As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechaentrada = fechaentrada
        m_fechaemision = fechaemision
        m_idmuestra = idmuestra
        m_observaciones = observaciones
        m_coliformestotales = coliformestotales
        m_coliformesfecales = coliformesfecales
        m_idaspecto = idaspecto
        m_idolor = idolor
        m_idcolor = idcolor
        m_ph = ph
        m_idmateriaorganica = idmateriaorganica
        m_conductividad = conductividad
        m_iddureza = iddureza
        m_nitrato = nitrato
        m_nitrito = nitrito
        m_fechaprocesamiento = fechaprocesamiento
        m_heterotroficos = heterotroficos
        m_turbiedad = turbiedad
        m_nitratotiras = nitratotiras
        m_nitritotiras = nitritotiras
        m_dureza = dureza
        m_volumendesiembra = volumendesiembra
        m_volumendesiembra2 = volumendesiembra2
        m_tecnica = tecnica
        m_heterotroficos37 = heterotroficos37
        m_heterotroficos35 = heterotroficos35
        m_clorolibre = clorolibre
        m_clororesidual = clororesidual
        m_pseudomonasaeruginosa = pseudomonasaeruginosa
        m_pseudomonaspp = pseudomonaspp
        m_endo35 = endo35
        m_mfc44_5 = mfc44_5
        m_centrimide37 = centrimide37
        m_mhpc = mhpc
        m_aguadedilucion = aguadedilucion
        m_ecoli = ecoli
        m_sulfitoreductores = sulfitoreductores
        m_enterococos = enterococos
        m_estreptococos = estreptococos
        m_lotenitrato = lotenitrato
        m_lotenitrito = lotenitrito
        m_lotedureza = lotedureza
        m_operador = operador
        m_medios = medios
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua2
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua2
        Return a.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua2
        Return a.modificar2(Me, usuario)
    End Function
    Public Function desmarcarficha() As Boolean
        Dim a As New pAgua2
        Return a.desmarcarficha(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua2
        Return a.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAgua2
        Dim a As New pAgua2
        Return a.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha & Chr(9) & m_idmuestra
    End Function
    Public Function listar() As ArrayList
        Dim a As New pAgua2
        Return a.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim a As New pAgua2
        Return a.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a As New pAgua2
        Return a.listarporid(texto)
    End Function
    Public Function listarporid2(ByVal texto As Long) As ArrayList
        Dim a As New pAgua2
        Return a.listarporid2(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a As New pAgua2
        Return a.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a As New pAgua2
        Return a.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a As New pAgua2
        Return a.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
