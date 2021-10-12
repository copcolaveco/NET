Public Class dAcreditacion
#Region "Atributos"
    Private m_analisis As Integer
    Private m_descripcion As String
    Private m_desde As String
    Private m_hasta As String
#End Region

#Region "Getters y Setters"
    Public Property ANALISIS() As Integer
        Get
            Return m_analisis
        End Get
        Set(ByVal value As Integer)
            m_analisis = value
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
#End Region

#Region "Constructores"
    Public Sub New()
        m_analisis = 0
        m_descripcion = ""
        m_desde = ""
        m_hasta = ""
    End Sub
    Public Sub New(ByVal analisis As Integer, ByVal descripcion As String, ByVal desde As String, ByVal hasta As String)
        m_analisis = analisis
        m_descripcion = descripcion
        m_desde = desde
        m_hasta = hasta

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAcreditacion
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAcreditacion
        Return p.modificar(Me, usuario)
    End Function
  
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAcreditacion
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAcreditacion
        Dim p As New pAcreditacion
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_descripcion & " - " & m_desde & " / " & m_hasta
    End Function

    Public Function listar() As ArrayList
        Dim p As New pAcreditacion
        Return p.listar
    End Function
  
End Class
