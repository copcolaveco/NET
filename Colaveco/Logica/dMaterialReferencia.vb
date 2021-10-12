Public Class dMaterialReferencia
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_operador As String
    Private m_equipo As String
    Private m_item As String
    Private m_lectura As Double
    Private m_valorref As Double
    Private m_diferencia As Double
    Private m_diferenciareal As Double
    Private m_difmaxpermitida As Double
    Private m_resultado As String
    Private m_pasada As Integer
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
    Public Property OPERADOR() As String
        Get
            Return m_operador
        End Get
        Set(ByVal value As String)
            m_operador = value
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
    Public Property ITEM() As String
        Get
            Return m_item
        End Get
        Set(ByVal value As String)
            m_item = value
        End Set
    End Property
    Public Property LECTURA() As Double
        Get
            Return m_lectura
        End Get
        Set(ByVal value As Double)
            m_lectura = value
        End Set
    End Property
    Public Property VALORREF() As Double
        Get
            Return m_valorref
        End Get
        Set(ByVal value As Double)
            m_valorref = value
        End Set
    End Property
    Public Property DIFERENCIA() As Double
        Get
            Return m_diferencia
        End Get
        Set(ByVal value As Double)
            m_diferencia = value
        End Set
    End Property
    Public Property DIFERENCIAREAL() As Double
        Get
            Return m_diferenciareal
        End Get
        Set(ByVal value As Double)
            m_diferenciareal = value
        End Set
    End Property
    Public Property DIFMAXPERMITIDA() As Double
        Get
            Return m_difmaxpermitida
        End Get
        Set(ByVal value As Double)
            m_difmaxpermitida = value
        End Set
    End Property
    Public Property RESULTADO() As String
        Get
            Return m_resultado
        End Get
        Set(ByVal value As String)
            m_resultado = value
        End Set
    End Property
    Public Property PASADA() As Integer
        Get
            Return m_pasada
        End Get
        Set(ByVal value As Integer)
            m_pasada = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_operador = ""
        m_equipo = ""
        m_item = ""
        m_lectura = 0
        m_valorref = 0
        m_diferencia = 0
        m_diferenciareal = 0
        m_difmaxpermitida = 0
        m_resultado = 0
        m_pasada = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal fecha As String, ByVal operador As String, ByVal equipo As String, ByVal item As String, ByVal lectura As Double, ByVal valorref As Double, ByVal diferencia As Double, ByVal diferenciareal As Double, ByVal difmaxpermitida As Double, ByVal resultado As String, ByVal pasada As Integer)
        m_id = id
        m_fecha = fecha
        m_operador = operador
        m_equipo = equipo
        m_item = item
        m_lectura = lectura
        m_valorref = valorref
        m_diferencia = diferencia
        m_diferenciareal = diferenciareal
        m_difmaxpermitida = difmaxpermitida
        m_resultado = resultado
        m_pasada = pasada
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMaterialReferencia
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMaterialReferencia
        Return p.modificar(Me, usuario)
    End Function
    Public Function guardardiferencia() As Boolean
        Dim p As New pMaterialReferencia
        Return p.guardardiferencia(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMaterialReferencia
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMaterialReferencia
        Dim p As New pMaterialReferencia
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_fecha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pMaterialReferencia
        Return p.listar
    End Function
    Public Function listarxitem(ByVal fechadesde As String, ByVal fechahasta As String, ByVal item As String, ByVal equipo As String) As ArrayList
        Dim p As New pMaterialReferencia
        Return p.listarxitem(fechadesde, fechahasta, item, equipo)
    End Function
    Public Function listarxitem2(ByVal fechadesde As String, ByVal fechahasta As String, ByVal item As String) As ArrayList
        Dim p As New pMaterialReferencia
        Return p.listarxitem2(fechadesde, fechahasta, item)
    End Function
End Class
