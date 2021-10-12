Public Class dFrascosRotos
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_cantidad As Integer
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property CANTIDAD() As Integer
        Get
            Return m_cantidad
        End Get
        Set(ByVal value As Integer)
            m_cantidad = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_cantidad = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal cantidad As Integer)
        m_id = id
        m_fecha = fecha
        m_cantidad = cantidad
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim f As New pFrascosRotos
        Return f.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim f As New pFrascosRotos
        Return f.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim f As New pFrascosRotos
        Return f.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dFrascosRotos
        Dim f As New pFrascosRotos
        Return f.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_fecha & " -  " & m_cantidad
    End Function

    Public Function listar() As ArrayList
        Dim f As New pFrascosRotos
        Return f.listar
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim f As New pFrascosRotos
        Return f.listarporfecha(desde, hasta)
    End Function
    Public Function listarfrascospormes(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim f As New pFrascosRotos
        Return f.listarfrascospormes(desde, hasta)
    End Function


End Class
