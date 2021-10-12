Public Class dRgLab51_informes
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_equipo As String
    Private m_operador As Integer
    Private m_muestra As Integer
    Private m_resultado1 As Integer
    Private m_resultado2 As Integer
    Private m_promedio As Double
    Private m_difmax As Integer
    Private m_dif As Integer
    Private m_alerta As Integer
    Private m_porcentaje As Double
    Private m_resultado As integer


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
    Public Property EQUIPO() As String
        Get
            Return m_equipo
        End Get
        Set(ByVal value As String)
            m_equipo = value
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
    Public Property MUESTRA() As Integer
        Get
            Return m_muestra
        End Get
        Set(ByVal value As Integer)
            m_muestra = value
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
    Public Property PROMEDIO() As Double
        Get
            Return m_promedio
        End Get
        Set(ByVal value As Double)
            m_promedio = value
        End Set
    End Property
    Public Property DIFMAX() As Integer
        Get
            Return m_difmax
        End Get
        Set(ByVal value As Integer)
            m_difmax = value
        End Set
    End Property
    Public Property DIF() As Integer
        Get
            Return m_dif
        End Get
        Set(ByVal value As Integer)
            m_dif = value
        End Set
    End Property
    Public Property ALERTA() As Integer
        Get
            Return m_alerta
        End Get
        Set(ByVal value As Integer)
            m_alerta = value
        End Set
    End Property
    Public Property PORCENTAJE() As Double
        Get
            Return m_porcentaje
        End Get
        Set(ByVal value As Double)
            m_porcentaje = value
        End Set
    End Property
    Public Property RESULTADO() As Integer
        Get
            Return m_resultado
        End Get
        Set(ByVal value As Integer)
            m_resultado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_equipo = ""
        m_operador = 0
        m_muestra = 0
        m_resultado1 = 0
        m_resultado2 = 0
        m_promedio = 0
        m_difmax = 0
        m_dif = 0
        m_alerta = 0
        m_porcentaje = 0
        m_resultado = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal equipo As String, ByVal operador As Integer, ByVal muestra As Integer, ByVal resultado1 As Integer, ByVal resultado2 As Integer, ByVal promedio As Integer, ByVal difmax As Integer, ByVal dif As Integer, ByVal alerta As Integer, ByVal porcentaje As Double, ByVal resultado As Integer)
        m_id = id
        m_fecha = fecha
        m_equipo = equipo
        m_operador = operador
        m_muestra = muestra
        m_resultado1 = resultado1
        m_resultado2 = resultado2
        m_promedio = promedio
        m_difmax = difmax
        m_dif = dif
        m_alerta = alerta
        m_porcentaje = porcentaje
        m_resultado = resultado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab51_informes
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab51_informes
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab51_informes
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dRgLab51_informes
        Dim c As New pRgLab51_informes
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pRgLab51_informes
        Return c.listar
    End Function
    Public Function listarfechas() As ArrayList
        Dim rg51 As New pRgLab51_informes
        Return rg51.listarfechas
    End Function
    Public Function listarxfechaxequipo(ByVal fecha As String, ByVal equipo As String) As ArrayList
        Dim rg51 As New pRgLab51_informes
        Return rg51.listarxfechaxequipo(fecha, equipo)
    End Function
    Public Function listarxfecha(ByVal fecha As String) As ArrayList
        Dim rg51 As New pRgLab51_informes
        Return rg51.listarxfecha(fecha)
    End Function
End Class
