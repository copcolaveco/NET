Public Class dEstadisticaCalidad
#Region "Atributos"
    Private m_id As Integer
    Private m_periodo As String
    Private m_rb As Double
    Private m_rb_m As Integer
    Private m_rc As Double
    Private m_rc_m As Integer
    Private m_gr As Double
    Private m_gr_m As Integer
    Private m_pr As Double
    Private m_pr_m As Integer
    Private m_la As Double
    Private m_la_m As Double
    Private m_st As Double
    Private m_st_m As Integer
    Private m_cr As Double
    Private m_cr_m As Integer
    Private m_ur As Double
    Private m_ur_m As Integer
#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Public Property PERIODO() As String
        Get
            Return m_periodo
        End Get
        Set(ByVal value As String)
            m_periodo = value
        End Set
    End Property
    Public Property RB() As Double
        Get
            Return m_rb
        End Get
        Set(ByVal value As Double)
            m_rb = value
        End Set
    End Property
    Public Property RB_M() As Integer
        Get
            Return m_rb_m
        End Get
        Set(ByVal value As Integer)
            m_rb_m = value
        End Set
    End Property
    Public Property RC() As Double
        Get
            Return m_rc
        End Get
        Set(ByVal value As Double)
            m_rc = value
        End Set
    End Property
    Public Property RC_M() As Integer
        Get
            Return m_rc_m
        End Get
        Set(ByVal value As Integer)
            m_rc_m = value
        End Set
    End Property
    Public Property GR() As Double
        Get
            Return m_gr
        End Get
        Set(ByVal value As Double)
            m_gr = value
        End Set
    End Property
    Public Property GR_M() As Integer
        Get
            Return m_gr_m
        End Get
        Set(ByVal value As Integer)
            m_gr_m = value
        End Set
    End Property
    Public Property PR() As Double
        Get
            Return m_pr
        End Get
        Set(ByVal value As Double)
            m_pr = value
        End Set
    End Property
    Public Property PR_M() As Integer
        Get
            Return m_pr_m
        End Get
        Set(ByVal value As Integer)
            m_pr_m = value
        End Set
    End Property
    Public Property LA() As Double
        Get
            Return m_la
        End Get
        Set(ByVal value As Double)
            m_la = value
        End Set
    End Property
    Public Property LA_M() As Integer
        Get
            Return m_la_m
        End Get
        Set(ByVal value As Integer)
            m_la_m = value
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
    Public Property ST_M() As Integer
        Get
            Return m_st_m
        End Get
        Set(ByVal value As Integer)
            m_st_m = value
        End Set
    End Property
    Public Property CR() As Double
        Get
            Return m_cr
        End Get
        Set(ByVal value As Double)
            m_cr = value
        End Set
    End Property
    Public Property CR_M() As Integer
        Get
            Return m_cr_m
        End Get
        Set(ByVal value As Integer)
            m_cr_m = value
        End Set
    End Property
    Public Property UR() As Double
        Get
            Return m_ur
        End Get
        Set(ByVal value As Double)
            m_ur = value
        End Set
    End Property
    Public Property UR_M() As Integer
        Get
            Return m_ur_m
        End Get
        Set(ByVal value As Integer)
            m_ur_m = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_periodo = ""
        m_rb = 0
        m_rb_m = 0
        m_rc = 0
        m_rc_m = 0
        m_gr = 0
        m_gr_m = 0
        m_pr = 0
        m_pr_m = 0
        m_la = 0
        m_la_m = 0
        m_st = 0
        m_st_m = 0
        m_cr = 0
        m_cr_m = 0
        m_ur = 0
        m_ur_m = 0

    End Sub
    Public Sub New(ByVal id As Integer, ByVal periodo As String, ByVal rb As Double, ByVal rb_m As Integer, ByVal rc As Double, ByVal rc_m As Integer, ByVal gr As Double, ByVal gr_m As Integer, ByVal pr As Double, ByVal pr_m As Integer, ByVal la As Double, ByVal la_m As Integer, ByVal st As Double, ByVal st_m As Integer, ByVal cr As Double, ByVal cr_m As Integer, ByVal ur As Double, ByVal ur_m As Integer)
        m_id = id
        m_periodo = periodo
        m_rb = rb
        m_rb_m = rb_m
        m_rc = rc
        m_rc_m = rc_m
        m_gr = gr
        m_gr_m = gr_m
        m_pr = pr
        m_pr_m = pr_m
        m_la = la
        m_la_m = la_m
        m_st = st
        m_st_m = st_m
        m_cr = cr
        m_cr_m = cr_m
        m_ur = ur
        m_ur_m = ur_m
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEstadisticaCalidad
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEstadisticaCalidad
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEstadisticaCalidad
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dEstadisticaCalidad
        Dim p As New pEstadisticaCalidad
        Return p.buscar(Me)
    End Function
    Public Function buscarultimo() As dEstadisticaCalidad
        Dim p As New pEstadisticaCalidad
        Return p.buscarultimo(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pEstadisticaCalidad
        Return p.listar
    End Function
End Class
