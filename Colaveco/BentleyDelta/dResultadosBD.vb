Public Class dResultadosBD
#Region "Atributos"
    Private m_codigo As Long
    Private m_fecha As String
    Private m_hora As String
    Private m_id As Double
    Private m_equipo As String
    Private m_mgr As Double
    Private m_gr1 As Double
    Private m_gr2 As Double
    Private m_grasa As Double
    Private m_mpr As Double
    Private m_pr1 As Double
    Private m_pr2 As Double
    Private m_proteina As Double
    Private m_mla As Double
    Private m_la1 As Double
    Private m_la2 As Double
    Private m_lactosa As Double
    Private m_mst As Double
    Private m_st1 As Double
    Private m_st2 As Double
    Private m_soltotales As Double
    Private m_mce As Double
    Private m_ce1 As Double
    Private m_ce2 As Double
    Private m_celulas As Long
    Private m_mcr As Double
    Private m_cr1 As Double
    Private m_cr2 As Double
    Private m_crioscopia As Long
    Private m_mur As Double
    Private m_ur1 As Double
    Private m_ur2 As Double
    Private m_urea As Integer
    Private m_cgrasa As String
    Private m_cproteina As String
    Private m_clactosa As String
    Private m_cstotales As String
    Private m_ccelulas As String
    Private m_ccrioscopia As String
    Private m_curea As String
    Private m_valido As String
#End Region

#Region "Getters y Setters"
    Public Property CODIGO() As Long
        Get
            Return m_codigo
        End Get
        Set(ByVal value As Long)
            m_codigo = value
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
    Public Property HORA() As String
        Get
            Return m_hora
        End Get
        Set(ByVal value As String)
            m_hora = value
        End Set
    End Property
    Public Property ID() As Double
        Get
            Return m_id
        End Get
        Set(ByVal value As Double)
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
    Public Property MGR() As Double
        Get
            Return m_mgr
        End Get
        Set(ByVal value As Double)
            m_mgr = value
        End Set
    End Property
    Public Property GR1() As Double
        Get
            Return m_gr1
        End Get
        Set(ByVal value As Double)
            m_gr1 = value
        End Set
    End Property
    Public Property GR2() As Double
        Get
            Return m_gr2
        End Get
        Set(ByVal value As Double)
            m_gr2 = value
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
    Public Property MPR() As Double
        Get
            Return m_mpr
        End Get
        Set(ByVal value As Double)
            m_mpr = value
        End Set
    End Property
    Public Property PR1() As Double
        Get
            Return m_pr1
        End Get
        Set(ByVal value As Double)
            m_pr1 = value
        End Set
    End Property
    Public Property PR2() As Double
        Get
            Return m_pr2
        End Get
        Set(ByVal value As Double)
            m_pr2 = value
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
    Public Property MLA() As Double
        Get
            Return m_mla
        End Get
        Set(ByVal value As Double)
            m_mla = value
        End Set
    End Property
    Public Property LA1() As Double
        Get
            Return m_la1
        End Get
        Set(ByVal value As Double)
            m_la1 = value
        End Set
    End Property
    Public Property LA2() As Double
        Get
            Return m_la2
        End Get
        Set(ByVal value As Double)
            m_la2 = value
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
    Public Property MST() As Double
        Get
            Return m_mst
        End Get
        Set(ByVal value As Double)
            m_mst = value
        End Set
    End Property
    Public Property ST1() As Double
        Get
            Return m_st1
        End Get
        Set(ByVal value As Double)
            m_st1 = value
        End Set
    End Property
    Public Property ST2() As Double
        Get
            Return m_st2
        End Get
        Set(ByVal value As Double)
            m_st2 = value
        End Set
    End Property
    Public Property SOLTOTALES() As Double
        Get
            Return m_soltotales
        End Get
        Set(ByVal value As Double)
            m_soltotales = value
        End Set
    End Property
    Public Property MCE() As Double
        Get
            Return m_mce
        End Get
        Set(ByVal value As Double)
            m_mce = value
        End Set
    End Property
    Public Property CE1() As Double
        Get
            Return m_ce1
        End Get
        Set(ByVal value As Double)
            m_ce1 = value
        End Set
    End Property
    Public Property CE2() As Double
        Get
            Return m_ce2
        End Get
        Set(ByVal value As Double)
            m_ce2 = value
        End Set
    End Property
    Public Property CELULAS() As Long
        Get
            Return m_celulas
        End Get
        Set(ByVal value As Long)
            m_celulas = value
        End Set
    End Property
    Public Property MCR() As Double
        Get
            Return m_mcr
        End Get
        Set(ByVal value As Double)
            m_mcr = value
        End Set
    End Property
    Public Property CR1() As Double
        Get
            Return m_cr1
        End Get
        Set(ByVal value As Double)
            m_cr1 = value
        End Set
    End Property
    Public Property CR2() As Double
        Get
            Return m_cr2
        End Get
        Set(ByVal value As Double)
            m_cr2 = value
        End Set
    End Property
    Public Property CRIOSCOPIA() As Long
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Long)
            m_crioscopia = value
        End Set
    End Property
    Public Property MUR() As Double
        Get
            Return m_mur
        End Get
        Set(ByVal value As Double)
            m_mur = value
        End Set
    End Property
    Public Property UR1() As Double
        Get
            Return m_ur1
        End Get
        Set(ByVal value As Double)
            m_ur1 = value
        End Set
    End Property
    Public Property UR2() As Double
        Get
            Return m_ur2
        End Get
        Set(ByVal value As Double)
            m_ur2 = value
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
    Public Property CGRASA() As String
        Get
            Return m_cgrasa
        End Get
        Set(ByVal value As String)
            m_cgrasa = value
        End Set
    End Property
    Public Property CPROTEINA() As String
        Get
            Return m_cproteina
        End Get
        Set(ByVal value As String)
            m_cproteina = value
        End Set
    End Property
    Public Property CLACTOSA() As String
        Get
            Return m_clactosa
        End Get
        Set(ByVal value As String)
            m_clactosa = value
        End Set
    End Property
    Public Property CSTOTALES() As String
        Get
            Return m_cstotales
        End Get
        Set(ByVal value As String)
            m_cstotales = value
        End Set
    End Property
    Public Property CCELULAS() As String
        Get
            Return m_ccelulas
        End Get
        Set(ByVal value As String)
            m_ccelulas = value
        End Set
    End Property
    Public Property CCRIOSCOPIA() As String
        Get
            Return m_ccrioscopia
        End Get
        Set(ByVal value As String)
            m_ccrioscopia = value
        End Set
    End Property
    Public Property CUREA() As String
        Get
            Return m_curea
        End Get
        Set(ByVal value As String)
            m_curea = value
        End Set
    End Property
    Public Property VALIDO() As String
        Get
            Return m_valido
        End Get
        Set(ByVal value As String)
            m_valido = value
        End Set
    End Property
#End Region


#Region "Constructores"
    Public Sub New()
        m_codigo = 0
        m_fecha = ""
        m_hora = "" 'Now.TimeOfDay
        m_id = 0
        m_equipo = ""
        m_mgr = 0
        m_gr1 = 0
        m_gr2 = 0
        m_grasa = 0
        m_mpr = 0
        m_pr1 = 0
        m_pr2 = 0
        m_proteina = 0
        m_mla = 0
        m_la1 = 0
        m_la2 = 0
        m_lactosa = 0
        m_mst = 0
        m_st1 = 0
        m_st2 = 0
        m_soltotales = 0
        m_mce = 0
        m_ce1 = 0
        m_ce2 = 0
        m_celulas = 0
        m_mcr = 0
        m_cr1 = 0
        m_cr2 = 0
        m_crioscopia = 0
        m_mur = 0
        m_ur1 = 0
        m_ur2 = 0
        m_urea = 0
        m_cgrasa = ""
        m_cproteina = ""
        m_clactosa = ""
        m_cstotales = ""
        m_ccelulas = ""
        m_ccrioscopia = ""
        m_curea = ""
        m_valido = ""

    End Sub
    Public Sub New(ByVal codigo As Long, ByVal fecha As String, ByVal hora As String, ByVal id As Double, ByVal equipo As String, ByVal mgr As Double, ByVal gr1 As Double, ByVal gr2 As Double, ByVal grasa As Double, ByVal mpr As Double, ByVal pr1 As Double, ByVal pr2 As Double, ByVal proteina As Double, ByVal mla As Double, ByVal la1 As Double, ByVal la2 As Double, ByVal lactosa As Double, ByVal mst As Double, ByVal st1 As Double, ByVal st2 As Double, ByVal soltotales As Double, ByVal mce As Double, ByVal ce1 As Double, ByVal ce2 As Double, ByVal celulas As Long, ByVal mcr As Double, ByVal cr1 As Double, ByVal cr2 As Double, ByVal crioscopia As Long, ByVal mur As Double, ByVal ur1 As Double, ByVal ur2 As Double, ByVal urea As Integer, ByVal cgrasa As String, ByVal cproteina As String, ByVal clactosa As String, ByVal cstotales As String, ByVal ccelulas As String, ByVal ccrioscopia As String, ByVal curea As String, ByVal valido As String)
        m_codigo = codigo
        m_fecha = fecha
        m_hora = hora
        m_id = id
        m_equipo = equipo
        m_mgr = mgr
        m_gr1 = gr1
        m_gr2 = gr2
        m_grasa = grasa
        m_mpr = mpr
        m_pr1 = pr1
        m_pr2 = pr2
        m_proteina = proteina
        m_mla = mla
        m_la1 = la1
        m_la2 = la2
        m_lactosa = lactosa
        m_mst = mst
        m_st1 = st1
        m_st2 = st2
        m_soltotales = soltotales
        m_mce = mce
        m_ce1 = ce1
        m_ce2 = ce2
        m_celulas = celulas
        m_mcr = mcr
        m_cr1 = cr1
        m_cr2 = cr2
        m_crioscopia = crioscopia
        m_mur = mur
        m_ur1 = ur1
        m_ur2 = ur2
        m_urea = urea
        m_cgrasa = cgrasa
        m_cproteina = cproteina
        m_clactosa = clactosa
        m_cstotales = cstotales
        m_ccelulas = ccelulas
        m_ccrioscopia = ccrioscopia
        m_curea = curea
        m_valido = valido

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pResultadosBD
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pResultadosBD
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pResultadosBD
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dResultadosBD
        Dim p As New pResultadosBD
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_codigo
    End Function

    Public Function listar() As ArrayList
        Dim p As New pResultadosBD
        Return p.listar
    End Function
    Public Function listarultimos2() As ArrayList
        Dim p As New pResultadosBD
        Return p.listarultimos2
    End Function
    Public Function listarsinvalidar() As ArrayList
        Dim p As New pResultadosBD
        Return p.listarsinvalidar
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pResultadosBD
        Return p.listarporfecha(desde, hasta)
    End Function
    Public Function validar() As Boolean
        Dim p As New pResultadosBD
        Return p.validar(Me)
    End Function

End Class
