Public Class dRgLab51
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_equipo As String
    Private m_operador As Integer
    Private m_muestra As Integer
    Private m_resultado As Double
    

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
    Public Property RESULTADO() As Double
        Get
            Return m_resultado
        End Get
        Set(ByVal value As Double)
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
        m_resultado = 0
        
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal equipoa As String, ByVal operador As Integer, ByVal muestra As Integer, ByVal resultado As Double)
        m_id = id
        m_fecha = fecha
        m_equipo = EQUIPO
        m_operador = operador
        m_muestra = muestra
        m_resultado = resultado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab51
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab51
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRgLab51
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dRgLab51
        Dim c As New pRgLab51
        Return c.buscar(Me)
    End Function
    Public Function buscarultimobentley() As dRgLab51
        Dim p As New pRgLab51
        Return p.buscarultimobentley(Me)
    End Function
    Public Function buscarultimodelta() As dRgLab51
        Dim p As New pRgLab51
        Return p.buscarultimodelta(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pRgLab51
        Return c.listar
    End Function
    Public Function listarfechas() As ArrayList
        Dim rg51 As New pRgLab51
        Return rg51.listarfechas
    End Function
    Public Function listarxfechaxequipo(ByVal fecha As String, ByVal equipo As String) As ArrayList
        Dim rg51 As New pRgLab51
        Return rg51.listarxfechaxequipo(fecha, equipo)
    End Function
End Class
