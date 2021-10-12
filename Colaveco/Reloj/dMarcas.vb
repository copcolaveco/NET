Public Class dMarcas
#Region "Atributos"
    Private m_id As Long
    Private m_usuario As Integer
    Private m_marca As String
    Private m_tipomarca As Integer
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
    Public Property USUARIO() As Integer
        Get
            Return m_usuario
        End Get
        Set(ByVal value As Integer)
            m_usuario = value
        End Set
    End Property
    Public Property MARCA() As String
        Get
            Return m_marca
        End Get
        Set(ByVal value As String)
            m_marca = value
        End Set
    End Property
    Public Property TIPOMARCA() As Integer
        Get
            Return m_tipomarca
        End Get
        Set(ByVal value As Integer)
            m_tipomarca = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_usuario = 0
        m_marca = ""
        m_tipomarca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal usuario As Integer, ByVal marca As String, ByVal tipomarca As Integer)
        m_id = id
        m_usuario = usuario
        m_marca = marca
        m_tipomarca = tipomarca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pMarcas
        Return p.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim p As New pMarcas
        Return p.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim p As New pMarcas
        Return p.eliminar(Me)
    End Function
    Public Function buscar() As dMarcas
        Dim p As New pMarcas
        Return p.buscar(Me)
    End Function
    
#End Region

    Public Overrides Function ToString() As String
        Return m_usuario
    End Function

    Public Function listar() As ArrayList
        Dim p As New pMarcas
        Return p.listar
    End Function
    Public Function listarxusuario(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pMarcas
        Return p.listarxusuario(usu, desde, hasta)
    End Function
    Public Function listarxusuario2(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pMarcas
        Return p.listarxusuario2(usu, desde, hasta)
    End Function
    Public Function listarxusuario_bd(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pMarcas
        Return p.listarxusuario_bd(usu, desde, hasta)
    End Function
    Public Function buscarultima(ByVal idusuario As Integer) As ArrayList
        Dim p As New pMarcas
        Return p.buscarultima(idusuario)
    End Function
    Public Function buscarultimas200(ByVal idusuario As Integer) As ArrayList
        Dim p As New pMarcas
        Return p.buscarultimas200(idusuario)
    End Function
End Class
