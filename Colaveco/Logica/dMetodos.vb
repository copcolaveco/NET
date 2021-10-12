Public Class dMetodos
#Region "Atributos"
    Private m_id As Integer
    Private m_area As String
    Private m_analisis As String
    Private m_metodo As String
    Private m_aplicacion As String
    Private m_estandar As String
    Private m_temptiempo As String
    Private m_modificaciones As String

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
    Public Property AREA() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = value
        End Set
    End Property
    Public Property ANALISIS() As String
        Get
            Return m_analisis
        End Get
        Set(ByVal value As String)
            m_analisis = value
        End Set
    End Property
    Public Property METODO() As String
        Get
            Return m_metodo
        End Get
        Set(ByVal value As String)
            m_metodo = value
        End Set
    End Property
    Public Property APLICACION() As String
        Get
            Return m_aplicacion
        End Get
        Set(ByVal value As String)
            m_aplicacion = value
        End Set
    End Property
    Public Property ESTANDAR() As String
        Get
            Return m_estandar
        End Get
        Set(ByVal value As String)
            m_estandar = value
        End Set
    End Property
    Public Property TEMPTIEMPO() As String
        Get
            Return m_temptiempo
        End Get
        Set(ByVal value As String)
            m_temptiempo = value
        End Set
    End Property
    Public Property MODIFICACIONES() As String
        Get
            Return m_modificaciones
        End Get
        Set(ByVal value As String)
            m_modificaciones = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_area = ""
        m_analisis = ""
        m_metodo = ""
        m_aplicacion = ""
        m_estandar = ""
        m_temptiempo = ""
        m_modificaciones = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal area As String, ByVal analisis As String, _
                   ByVal metodo As String, ByVal aplicacion As String, ByVal estandar As String, _
                   ByVal temptiempo As String, ByVal modificaciones As String)
        m_id = id
        m_area = area
        m_analisis = analisis
        m_metodo = metodo
        m_aplicacion = aplicacion
        m_estandar = estandar
        m_temptiempo = temptiempo
        m_modificaciones = modificaciones

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMetodos
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMetodos
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMetodos
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMetodos
        Dim p As New pMetodos
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id & " / " & m_metodo & " / " & m_aplicacion & " / " & m_estandar & " / " & m_temptiempo & " / " & m_modificaciones
    End Function

    Public Function listar() As ArrayList
        Dim p As New pMetodos
        Return p.listar
    End Function
    Public Function listarporid(ByVal texto As String) As ArrayList
        Dim p As New pMetodos
        Return p.listarporid(texto)
    End Function
End Class
