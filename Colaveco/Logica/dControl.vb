Public Class dControl
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As String
    Private m_fecha As String
    Private m_equipo As String
    Private m_producto As String
    Private m_muestra As String
    Private m_rc As Integer
    Private m_grasa As Double
    Private m_proteina As Double
    Private m_lactosa As Double
    Private m_st As Double
    Private m_crioscopia As Integer
    Private m_urea As Integer
    Private m_proteinav As Double
    Private m_caseina As Double
    Private m_densidad As Double
    Private m_ph As Double
    Private m_bhb As Double

    ' ----- Perfil de ácidos grasos -----
    Private m_SFA As Double
    Private m_UFA As Double
    Private m_MUFA As Double
    Private m_PUFA As Double

    Private m_C16_0 As Double
    Private m_C18_0 As Double
    Private m_C18_1C9 As Double

    ' ----- Otros metabolitos -----
    Private m_Acetone As Double

    ' ----- Grasas especiales -----
    Private m_CisFat As Double
    Private m_TransFat As Double

    ' ----- Fracciones FA -----
    Private m_DenovoFA As Double
    Private m_MixedFA As Double
    Private m_PreformedFA As Double

    Private m_DenovoRel As Double
    Private m_MixedRel As Double
    Private m_PreformedRel As Double

    ' ----- Final -----
    Private m_NEFA As Double

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
    Public Property FICHA() As String
        Get
            Return m_ficha
        End Get
        Set(ByVal value As String)
            m_ficha = value
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
    Public Property EQUIPO() As String
        Get
            Return m_equipo
        End Get
        Set(ByVal value As String)
            m_equipo = value
        End Set
    End Property
    Public Property PRODUCTO() As String
        Get
            Return m_producto
        End Get
        Set(ByVal value As String)
            m_producto = value
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
    Public Property RC() As Integer
        Get
            Return m_rc
        End Get
        Set(ByVal value As Integer)
            m_rc = value
        End Set
    End Property
    Public Property GRASA() As Double
        Get
            Return m_grasa
        End Get
        Set(ByVal value As Double)
            m_grasa = value
        End Set
    End Property
    Public Property PROTEINA() As Double
        Get
            Return m_proteina
        End Get
        Set(ByVal value As Double)
            m_proteina = value
        End Set
    End Property
    Public Property LACTOSA() As Double
        Get
            Return m_lactosa
        End Get
        Set(ByVal value As Double)
            m_lactosa = value
        End Set
    End Property
    Public Property ST() As Double
        Get
            Return m_st
        End Get
        Set(ByVal value As Double)
            m_st = value
        End Set
    End Property
    Public Property CRIOSCOPIA() As Integer
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Integer)
            m_crioscopia = value
        End Set
    End Property
    Public Property UREA() As Integer
        Get
            Return m_urea
        End Get
        Set(ByVal value As Integer)
            m_urea = value
        End Set
    End Property
    Public Property PROTEINAV() As Double
        Get
            Return m_proteinav
        End Get
        Set(ByVal value As Double)
            m_proteinav = value
        End Set
    End Property
    Public Property CASEINA() As Double
        Get
            Return m_caseina
        End Get
        Set(ByVal value As Double)
            m_caseina = value
        End Set
    End Property
    Public Property DENSIDAD() As Double
        Get
            Return m_densidad
        End Get
        Set(ByVal value As Double)
            m_densidad = value
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
    Public Property BHB() As Double
        Get
            Return m_bhb
        End Get
        Set(ByVal value As Double)
            m_bhb = value
        End Set
    End Property

    ' ----- Perfil de ácidos grasos -----
    Public Property SFA() As Double
        Get
            Return m_SFA
        End Get
        Set(ByVal value As Double)
            m_SFA = value
        End Set
    End Property

    Public Property UFA() As Double
        Get
            Return m_UFA
        End Get
        Set(ByVal value As Double)
            m_UFA = value
        End Set
    End Property

    Public Property MUFA() As Double
        Get
            Return m_MUFA
        End Get
        Set(ByVal value As Double)
            m_MUFA = value
        End Set
    End Property

    Public Property PUFA() As Double
        Get
            Return m_PUFA
        End Get
        Set(ByVal value As Double)
            m_PUFA = value
        End Set
    End Property

    Public Property C16_0() As Double
        Get
            Return m_C16_0
        End Get
        Set(ByVal value As Double)
            m_C16_0 = value
        End Set
    End Property

    Public Property C18_0() As Double
        Get
            Return m_C18_0
        End Get
        Set(ByVal value As Double)
            m_C18_0 = value
        End Set
    End Property

    Public Property C18_1C9() As Double
        Get
            Return m_C18_1C9
        End Get
        Set(ByVal value As Double)
            m_C18_1C9 = value
        End Set
    End Property

    ' ----- Otros metabolitos -----
    Public Property Acetone() As Double
        Get
            Return m_Acetone
        End Get
        Set(ByVal value As Double)
            m_Acetone = value
        End Set
    End Property

    ' ----- Grasas especiales -----
    Public Property CisFat() As Double
        Get
            Return m_CisFat
        End Get
        Set(ByVal value As Double)
            m_CisFat = value
        End Set
    End Property

    Public Property TransFat() As Double
        Get
            Return m_TransFat
        End Get
        Set(ByVal value As Double)
            m_TransFat = value
        End Set
    End Property

    ' ----- Fracciones FA -----
    Public Property DenovoFA() As Double
        Get
            Return m_DenovoFA
        End Get
        Set(ByVal value As Double)
            m_DenovoFA = value
        End Set
    End Property

    Public Property MixedFA() As Double
        Get
            Return m_MixedFA
        End Get
        Set(ByVal value As Double)
            m_MixedFA = value
        End Set
    End Property

    Public Property PreformedFA() As Double
        Get
            Return m_PreformedFA
        End Get
        Set(ByVal value As Double)
            m_PreformedFA = value
        End Set
    End Property

    Public Property DenovoRel() As Double
        Get
            Return m_DenovoRel
        End Get
        Set(ByVal value As Double)
            m_DenovoRel = value
        End Set
    End Property

    Public Property MixedRel() As Double
        Get
            Return m_MixedRel
        End Get
        Set(ByVal value As Double)
            m_MixedRel = value
        End Set
    End Property

    Public Property PreformedRel() As Double
        Get
            Return m_PreformedRel
        End Get
        Set(ByVal value As Double)
            m_PreformedRel = value
        End Set
    End Property

    ' ----- Final -----
    Public Property NEFA() As Double
        Get
            Return m_NEFA
        End Get
        Set(ByVal value As Double)
            m_NEFA = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = ""
        m_fecha = ""
        m_equipo = ""
        m_producto = ""
        m_muestra = ""
        m_rc = 0
        m_grasa = 0
        m_proteina = 1
        m_lactosa = 0
        m_st = 0
        m_crioscopia = 0
        m_urea = 0
        m_proteinav = 0
        m_caseina = 0
        m_densidad = 0
        m_ph = 0
        m_bhb = 0

        ' ----- Perfil de ácidos grasos -----
        m_SFA = 0
        m_UFA = 0
        m_MUFA = 0
        m_PUFA = 0

        m_C16_0 = 0
        m_C18_0 = 0
        m_C18_1C9 = 0

        ' ----- Otros metabolitos -----
        m_Acetone = 0

        ' ----- Grasas especiales -----
        m_CisFat = 0
        m_TransFat = 0

        ' ----- Fracciones FA -----
        m_DenovoFA = 0
        m_MixedFA = 0
        m_PreformedFA = 0

        m_DenovoRel = 0
        m_MixedRel = 0
        m_PreformedRel = 0

        ' ----- Final -----
        m_NEFA = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As String, ByVal fecha As String,
               ByVal equipo As String, ByVal producto As String, ByVal muestra As String,
               ByVal rc As Integer, ByVal grasa As Double, ByVal proteina As Double,
               ByVal lactosa As Double, ByVal st As Double, ByVal crioscopia As Integer,
               ByVal urea As Integer, ByVal proteinav As Double, ByVal caseina As Double,
               ByVal densidad As Double, ByVal ph As Double, ByVal bhb As Double,
               ByVal SFA As Double, ByVal UFA As Double, ByVal MUFA As Double,
               ByVal PUFA As Double, ByVal C16_0 As Double, ByVal C18_0 As Double,
               ByVal C18_1C9 As Double, ByVal Acetone As Double, ByVal CisFat As Double,
               ByVal TransFat As Double, ByVal DenovoFA As Double, ByVal MixedFA As Double,
               ByVal PreformedFA As Double, ByVal DenovoRel As Double,
               ByVal MixedRel As Double, ByVal PreformedRel As Double,
               ByVal NEFA As Double)

        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_equipo = equipo
        m_producto = producto
        m_muestra = muestra
        m_rc = rc
        m_grasa = grasa
        m_proteina = proteina
        m_lactosa = lactosa
        m_st = st
        m_crioscopia = crioscopia
        m_urea = urea
        m_proteinav = proteinav
        m_caseina = caseina
        m_densidad = densidad
        m_ph = ph
        m_bhb = bhb

        ' ---- Nuevos campos ----
        m_SFA = SFA
        m_UFA = UFA
        m_MUFA = MUFA
        m_PUFA = PUFA

        m_C16_0 = C16_0
        m_C18_0 = C18_0
        m_C18_1C9 = C18_1C9

        m_Acetone = Acetone

        m_CisFat = CisFat
        m_TransFat = TransFat

        m_DenovoFA = DenovoFA
        m_MixedFA = MixedFA
        m_PreformedFA = PreformedFA

        m_DenovoRel = DenovoRel
        m_MixedRel = MixedRel
        m_PreformedRel = PreformedRel

        m_NEFA = NEFA

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControl
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControl
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal ficha As String, ByVal id As String, ByVal muestra As String) As Boolean
        Dim c As New pControl
        Return c.modificar2(ficha, id, muestra)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControl
        Return c.eliminar(Me, usuario)
    End Function
    Public Function eliminarxficha() As Boolean
        Dim c As New pControl
        Return c.eliminarxficha(Me)
    End Function
    Public Function buscar() As dControl
        Dim c As New pControl
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pControl
        Return c.listar
    End Function
    Public Function listarfechaproceso(ByVal idficha As Long) As ArrayList
        Dim c As New pControl
        Return c.listarfechaproceso(idficha)
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pControl
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pControl
        Return c.listarporsolicitud(texto)
    End Function
    Public Function listarxficha(ByVal texto As Long) As ArrayList
        Dim c As New pControl
        Return c.listarxficha(texto)
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControl
        Return c.listarporfecha(desde, hasta)
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControl
        Return c.listarxfecha(desde, hasta)
    End Function
    Public Function listarporrc(ByVal texto As Long) As ArrayList
        Dim c As New pControl
        Return c.listarporrc(texto)
    End Function
    Public Function TieneAcidosGrasos(ByVal texto As Long) As Boolean
        Dim c As New pControl
        Return c.TieneAcidosGrasos(texto)
    End Function

End Class
