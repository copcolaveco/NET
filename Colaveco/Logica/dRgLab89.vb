Public Class dRgLab89
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_hora As String
    Private m_muestra As String
    Private m_media As Integer
    Private m_resultado1 As Integer
    Private m_resultado2 As Integer
    Private m_diferencia As Integer
    Private m_operador As Integer
    Private m_observaciones As String

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
    Public Property HORA() As String
        Get
            Return m_hora
        End Get
        Set(ByVal value As String)
            m_hora = value
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
    Public Property MEDIA() As Integer
        Get
            Return m_media
        End Get
        Set(ByVal value As Integer)
            m_media = value
        End Set
    End Property
    Public Property RESULTADO1() As Integer
        Get
            Return m_resultado1
        End Get
        Set(ByVal value As Integer)
            m_resultado1 = value
        End Set
    End Property
    Public Property RESULTADO2() As Integer
        Get
            Return m_resultado2
        End Get
        Set(ByVal value As Integer)
            m_resultado2 = value
        End Set
    End Property
    Public Property DIFERENCIA() As Integer
        Get
            Return m_diferencia
        End Get
        Set(ByVal value As Integer)
            m_diferencia = value
        End Set
    End Property
    Public Property OPERADOR() As Integer
        Get
            Return m_operador
        End Get
        Set(ByVal value As Integer)
            m_operador = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_hora = ""
        m_muestra = ""
        m_media = 0
        m_resultado1 = 0
        m_resultado2 = 0
        m_diferencia = 0
        m_operador = 0
        m_observaciones = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal hora As String, ByVal muestra As String, ByVal media As Long, ByVal resultado1 As Integer, ByVal resultado2 As Integer, ByVal diferencia As Integer, ByVal operador As Integer, ByVal observaciones As String)
        m_id = id
        m_fecha = fecha
        m_hora = hora
        m_muestra = muestra
        m_media = media
        m_resultado1 = resultado1
        m_resultado2 = resultado2
        m_diferencia = diferencia
        m_operador = operador
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab89
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab89
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab89
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dRgLab89
        Dim c As New pRgLab89
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pRgLab89
        Return c.listar
    End Function
End Class
