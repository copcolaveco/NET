Public Class dMicotoxinasLeche
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fecha As String
    Private m_muestra As String
    Private m_resultado As String
    Private m_operador As Integer
    Private m_marca As Integer

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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
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
    Public Property RESULTADO() As String
        Get
            Return m_resultado
        End Get
        Set(ByVal value As String)
            m_resultado = value
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
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_fecha = ""
        m_muestra = ""
        m_resultado = ""
        m_operador = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fecha As String, ByVal muestra As String, ByVal resultado As String, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_muestra = muestra
        m_resultado = resultado
        m_operador = operador
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicotoxinasLeche
        Return m.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicotoxinasLeche
        Return m.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicotoxinasLeche
        Return m.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicotoxinasLeche
        Return m.eliminar(Me, usuario)
    End Function
    Public Function eliminar2(ByVal usuario As dUsuario) As Boolean
        Dim m As New pMicotoxinasLeche
        Return m.eliminar2(Me, usuario)
    End Function
    Public Function buscar() As dMicotoxinasLeche
        Dim m As New pMicotoxinasLeche
        Return m.buscar(Me)
    End Function
    Public Function buscarxficha() As dMicotoxinasLeche
        Dim m As New pMicotoxinasLeche
        Return m.buscarxficha(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dMicotoxinasLeche
        Dim m As New pMicotoxinasLeche
        Return m.buscarxfichaxmuestra(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        'Return m_ficha
        Return m_ficha & Chr(9) & m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim m As New pMicotoxinasLeche
        Return m.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim m As New pMicotoxinasLeche
        Return m.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim m As New pMicotoxinasLeche
        Return m.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim m As New pMicotoxinasLeche
        Return m.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim m As New pMicotoxinasLeche
        Return m.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim m As New pMicotoxinasLeche
        Return m.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
