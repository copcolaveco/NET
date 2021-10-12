Public Class dCapacitacionLin
#Region "Atributos"
    Private m_id As Long
    Private m_idcab As Long
    Private m_area As Integer
    Private m_tipo As Integer
    Private m_nombre As String
    Private m_descripcion As String
    Private m_idusuario As Integer
    Private m_desde As String
    Private m_hasta As String
    Private m_horas As String
    Private m_evaluacion1 As Integer
    Private m_evaluacion2 As Integer
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
    Public Property IDCAB() As Long
        Get
            Return m_idcab
        End Get
        Set(ByVal value As Long)
            m_idcab = value
        End Set
    End Property
    Public Property AREA() As Integer
        Get
            Return m_area
        End Get
        Set(ByVal value As Integer)
            m_area = value
        End Set
    End Property
    Public Property TIPO() As Integer
        Get
            Return m_tipo
        End Get
        Set(ByVal value As Integer)
            m_tipo = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property IDUSUARIO() As Integer
        Get
            Return m_idusuario
        End Get
        Set(ByVal value As Integer)
            m_idusuario = value
        End Set
    End Property
    Public Property DESDE() As String
        Get
            Return m_desde
        End Get
        Set(ByVal value As String)
            m_desde = value
        End Set
    End Property
    Public Property HASTA() As String
        Get
            Return m_hasta
        End Get
        Set(ByVal value As String)
            m_hasta = value
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
    Public Property EVALUACION1() As Integer
        Get
            Return m_evaluacion1
        End Get
        Set(ByVal value As Integer)
            m_evaluacion1 = value
        End Set
    End Property
    Public Property EVALUACION2() As Integer
        Get
            Return m_evaluacion2
        End Get
        Set(ByVal value As Integer)
            m_evaluacion2 = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idcab = 0
        m_area = 0
        m_tipo = 0
        m_nombre = ""
        m_descripcion = ""
        m_idusuario = 0
        m_desde = ""
        m_hasta = ""
        m_horas = ""
        m_evaluacion1 = 0
        m_evaluacion2 = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idcab As Long, ByVal area As Integer, ByVal tipo As Integer, ByVal nombre As String, ByVal descripcion As String, ByVal idusuario As Integer, ByVal desde As String, ByVal hasta As String, ByVal horas As String, ByVal evaluacion1 As Integer, ByVal evaluacion2 As Integer)
        m_id = id
        m_idcab = idcab
        m_area = area
        m_tipo = tipo
        m_nombre = nombre
        m_descripcion = descripcion
        m_idusuario = idusuario
        m_desde = desde
        m_hasta = hasta
        m_horas = horas
        m_evaluacion1 = evaluacion1
        m_evaluacion2 = evaluacion2
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCapacitacionLin
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCapacitacionLin
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCapacitacionLin
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCapacitacionLin
        Dim p As New pCapacitacionLin
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_idcab
    End Function

    Public Function listar() As ArrayList
        Dim p As New pCapacitacionLin
        Return p.listar
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pCapacitacionLin
        Return p.listarxfecha(desde, hasta)
    End Function
    Public Function listarxfechaxarea(ByVal desde As String, ByVal hasta As String, ByVal area As Integer) As ArrayList
        Dim p As New pCapacitacionLin
        Return p.listarxfechaxarea(desde, hasta, AREA)
    End Function
    Public Function listarxfechaxusuario(ByVal desde As String, ByVal hasta As String, ByVal user As Integer) As ArrayList
        Dim p As New pCapacitacionLin
        Return p.listarxfechaxusuario(desde, hasta, user)
    End Function
    Public Function listarxusuario(ByVal user As Integer) As ArrayList
        Dim p As New pCapacitacionLin
        Return p.listarxusuario(user)
    End Function
End Class
