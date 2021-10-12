Public Class dPreinformeCalidad
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As String
    Private m_creado As Integer
    Private m_abonado As Integer
    Private m_comentario As String
    Private m_copia As String
    Private m_parasubir As Integer
    Private m_subido As Integer
    Private m_fecha As String
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
    Public Property CREADO() As Integer
        Get
            Return m_creado
        End Get
        Set(ByVal value As Integer)
            m_creado = value
        End Set
    End Property
    Public Property ABONADO() As Integer
        Get
            Return m_abonado
        End Get
        Set(ByVal value As Integer)
            m_abonado = value
        End Set
    End Property
    Public Property COMENTARIO() As String
        Get
            Return m_comentario
        End Get
        Set(ByVal value As String)
            m_comentario = value
        End Set
    End Property
    Public Property COPIA() As String
        Get
            Return m_copia
        End Get
        Set(ByVal value As String)
            m_copia = value
        End Set
    End Property
    Public Property PARASUBIR() As String
        Get
            Return m_parasubir
        End Get
        Set(ByVal value As String)
            m_parasubir = value
        End Set
    End Property
    Public Property SUBIDO() As Integer
        Get
            Return m_subido
        End Get
        Set(ByVal value As Integer)
            m_subido = value
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
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_creado = 0
        m_abonado = 0
        m_comentario = ""
        m_copia = ""
        m_parasubir = 0
        m_subido = 0
        m_fecha = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal creado As Integer, ByVal abonado As Integer, ByVal comentario As String, ByVal copia As String, ByVal parasubir As Integer, ByVal subido As Integer, ByVal fecha As String)
        m_id = id
        m_ficha = ficha
        m_creado = creado
        m_abonado = abonado
        m_comentario = comentario
        m_copia = copia
        m_parasubir = parasubir
        m_subido = subido
        m_fecha = fecha
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pPreinformeCalidad
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pPreinformeCalidad
        Return p.modificar(Me)
    End Function
    Public Function modificar2() As Boolean
        Dim p As New pPreinformeCalidad
        Return p.modificar2(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pPreinformeCalidad
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPreinformeCalidad
        Dim p As New pPreinformeCalidad
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pPreinformeCalidad
        Return p.listar
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim p As New pPreinformeCalidad
        Return p.listarsinmarcar
    End Function
    Public Function listarparasubir() As ArrayList
        Dim p As New pPreinformeCalidad
        Return p.listarparasubir
    End Function
    Public Function listarsubidas() As ArrayList
        Dim p As New pPreinformeCalidad
        Return p.listarsubidas
    End Function
    Public Function marcarcreado() As Boolean
        Dim p As New pPreinformeCalidad
        Return p.marcarcreado(Me)
    End Function
    Public Function marcarsubido(ByVal fecha As String) As Boolean
        Dim p As New pPreinformeCalidad
        Return p.marcarsubido(Me, fecha)
    End Function
End Class
