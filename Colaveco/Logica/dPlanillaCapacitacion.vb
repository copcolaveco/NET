Public Class dPlanillaCapacitacion
#Region "Atributos"
    Private m_id As Long
    Private m_idlin As Long
    Private m_participante As Integer
    Private m_tipoactividad As Integer
    Private m_instructor As String
    Private m_fechainicio As String
    Private m_fechafin As String
    Private m_local As String
    Private m_horas As String
    Private m_costo As String
    Private m_autorizacion As Integer
    Private m_fechaautorizacion As String
    Private m_b1 As Integer
    Private m_b2 As Integer
    Private m_b3 As Integer
    Private m_recomendar As String
    Private m_comentarios As String
    Private m_evaluaciondir As Integer
    Private m_comentariosdir As String
    Private m_evaluacion As String
    Private m_devolucion As String
    Private m_mejora As String
    Private m_repercusion As String
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
    Public Property IDLIN() As Long
        Get
            Return m_idlin
        End Get
        Set(ByVal value As Long)
            m_idlin = value
        End Set
    End Property
    Public Property PARTICIPANTE() As Integer
        Get
            Return m_participante
        End Get
        Set(ByVal value As Integer)
            m_participante = value
        End Set
    End Property
    Public Property TIPOACTIVIDAD() As Integer
        Get
            Return m_tipoactividad
        End Get
        Set(ByVal value As Integer)
            m_tipoactividad = value
        End Set
    End Property
    Public Property INSTRUCTOR() As String
        Get
            Return m_instructor
        End Get
        Set(ByVal value As String)
            m_instructor = value
        End Set
    End Property
    Public Property FECHAINICIO() As String
        Get
            Return m_fechainicio
        End Get
        Set(ByVal value As String)
            m_fechainicio = value
        End Set
    End Property
    Public Property FECHAFIN() As String
        Get
            Return m_fechafin
        End Get
        Set(ByVal value As String)
            m_fechafin = value
        End Set
    End Property
    Public Property LOCAL() As String
        Get
            Return m_local
        End Get
        Set(ByVal value As String)
            m_local = value
        End Set
    End Property
    Public Property HORAS() As String
        Get
            Return m_horas
        End Get
        Set(ByVal value As String)
            m_horas = value
        End Set
    End Property
    Public Property COSTO() As String
        Get
            Return m_costo
        End Get
        Set(ByVal value As String)
            m_costo = value
        End Set
    End Property
    Public Property AUTORIZACION() As Integer
        Get
            Return m_autorizacion
        End Get
        Set(ByVal value As Integer)
            m_autorizacion = value
        End Set
    End Property
    Public Property FECHAAUTORIZACION() As String
        Get
            Return m_fechaautorizacion
        End Get
        Set(ByVal value As String)
            m_fechaautorizacion = value
        End Set
    End Property
    Public Property B1() As Integer
        Get
            Return m_b1
        End Get
        Set(ByVal value As Integer)
            m_b1 = value
        End Set
    End Property
    Public Property B2() As Integer
        Get
            Return m_b2
        End Get
        Set(ByVal value As Integer)
            m_b2 = value
        End Set
    End Property
    Public Property B3() As Integer
        Get
            Return m_b3
        End Get
        Set(ByVal value As Integer)
            m_b3 = value
        End Set
    End Property
    Public Property RECOMENDAR() As String
        Get
            Return m_recomendar
        End Get
        Set(ByVal value As String)
            m_recomendar = value
        End Set
    End Property
    Public Property COMENTARIOS() As String
        Get
            Return m_comentarios
        End Get
        Set(ByVal value As String)
            m_comentarios = value
        End Set
    End Property
    Public Property EVALUACIONDIR() As Integer
        Get
            Return m_evaluaciondir
        End Get
        Set(ByVal value As Integer)
            m_evaluaciondir = value
        End Set
    End Property
    Public Property COMENTARIOSDIR() As String
        Get
            Return m_comentariosdir
        End Get
        Set(ByVal value As String)
            m_comentariosdir = value
        End Set
    End Property
    Public Property EVALUACION() As String
        Get
            Return m_evaluacion
        End Get
        Set(ByVal value As String)
            m_evaluacion = value
        End Set
    End Property
    Public Property DEVOLUCION() As String
        Get
            Return m_devolucion
        End Get
        Set(ByVal value As String)
            m_devolucion = value
        End Set
    End Property
    Public Property MEJORA() As String
        Get
            Return m_mejora
        End Get
        Set(ByVal value As String)
            m_mejora = value
        End Set
    End Property
    Public Property REPERCUSION() As String
        Get
            Return m_repercusion
        End Get
        Set(ByVal value As String)
            m_repercusion = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idlin = 0
        m_participante = 0
        m_tipoactividad = 0
        m_instructor = ""
        m_fechainicio = ""
        m_fechafin = ""
        m_local = ""
        m_horas = ""
        m_costo = ""
        m_autorizacion = 0
        m_fechaautorizacion = ""
        m_b1 = 0
        m_b2 = 0
        m_b3 = 0
        m_recomendar = ""
        m_comentarios = ""
        m_evaluaciondir = 0
        m_comentariosdir = ""
        m_evaluacion = ""
        m_devolucion = ""
        m_mejora = ""
        m_repercusion = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal idlin As Long, ByVal participante As Integer, ByVal tipoactividad As Integer, ByVal instructor As String, ByVal fechainicio As String, ByVal fechafin As String, ByVal local As String, ByVal horas As String, ByVal costo As String, ByVal autorizacion As Integer, ByVal fechaautorizacion As String, ByVal b1 As Integer, ByVal b2 As Integer, ByVal b3 As Integer, ByVal recomendar As String, ByVal comentarios As String, ByVal evaluaciondir As Integer, ByVal comentariosdir As String, ByVal evaluacion As String, ByVal devolucion As String, ByVal mejora As String, ByVal repercusion As String)
        m_id = id
        m_idlin = idlin
        m_participante = participante
        m_tipoactividad = tipoactividad
        m_instructor = instructor
        m_fechainicio = fechainicio
        m_fechafin = fechafin
        m_local = local
        m_horas = horas
        m_costo = costo
        m_autorizacion = autorizacion
        m_fechaautorizacion = fechaautorizacion
        m_b1 = b1
        m_b2 = b2
        m_b3 = b3
        m_recomendar = recomendar
        m_comentarios = comentarios
        m_evaluaciondir = evaluaciondir
        m_comentariosdir = comentariosdir
        m_evaluacion = evaluacion
        m_devolucion = devolucion
        m_mejora = mejora
        m_repercusion = repercusion

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPlanillaCapacitacion
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPlanillaCapacitacion
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPlanillaCapacitacion
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPlanillaCapacitacion
        Dim p As New pPlanillaCapacitacion
        Return p.buscar(Me)
    End Function
    Public Function buscarxcapacitacion() As dPlanillaCapacitacion
        Dim p As New pPlanillaCapacitacion
        Return p.buscarxcapacitacion(Me)
    End Function
   
#End Region

    Public Overrides Function tostring() As String
        Return m_id & " "
    End Function
    Public Function listar() As ArrayList
        Dim p As New pPlanillaCapacitacion
        Return p.listar
    End Function
End Class
