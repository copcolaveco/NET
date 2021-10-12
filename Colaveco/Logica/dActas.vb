Public Class dActas
#Region "Atributos"
    Private m_id As Long
    Private m_numero As String
    Private m_fecha As String
    Private m_hora As String
    Private m_grupo As Integer
    Private m_lugar As String
    Private m_presentes As String
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
    Public Property NUMERO() As String
        Get
            Return m_numero
        End Get
        Set(ByVal value As String)
            m_numero = value
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
    Public Property GRUPO() As Integer
        Get
            Return m_grupo
        End Get
        Set(ByVal value As Integer)
            m_grupo = value
        End Set
    End Property
    Public Property LUGAR() As String
        Get
            Return m_lugar
        End Get
        Set(ByVal value As String)
            m_lugar = value
        End Set
    End Property
    Public Property PRESENTES() As String
        Get
            Return m_presentes
        End Get
        Set(ByVal value As String)
            m_presentes = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_numero = ""
        m_fecha = Now
        m_hora = ""
        m_grupo = 0
        m_lugar = ""
        m_presentes = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal numero As String, ByVal fecha As String, ByVal hora As String, ByVal grupo As Integer, ByVal lugar As String, ByVal presentes As String)
        m_id = id
        m_numero = numero
        m_fecha = fecha
        m_hora = hora
        m_grupo = grupo
        m_lugar = lugar
        m_presentes = presentes
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActas
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActas
        Return s.modificar(Me, usuario)
    End Function
    
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActas
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dActas
        Dim s As New pActas
        Return s.buscar(Me)
    End Function
    Public Function buscarultimoid() As dActas
        Dim a As New pActas
        Return a.buscarultimoid(Me)
    End Function
#End Region

    Public Overrides Function tostring() As String
        Return m_fecha
    End Function
    Public Function listar() As ArrayList
        Dim s As New pActas
        Return s.listar
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim s As New pActas
        Return s.listarxfecha(desde, hasta)
    End Function
    Public Function listarxgrupo(ByVal idgrupo As Integer) As ArrayList
        Dim s As New pActas
        Return s.listarxgrupo(idgrupo)
    End Function
    Public Function listarxgrupoxano(ByVal grupo As Integer, ByVal ano As Integer) As ArrayList
        Dim s As New pActas
        Return s.listarxgrupoxano(grupo, ano)
    End Function
    Public Function listarxfechaxgrupo(ByVal desde As String, ByVal hasta As String, ByVal idgrupo As Integer) As ArrayList
        Dim s As New pActas
        Return s.listarxfechaxgrupo(desde, hasta, idgrupo)
    End Function
End Class
