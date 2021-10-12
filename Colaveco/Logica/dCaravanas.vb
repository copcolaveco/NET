Public Class dCaravanas
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_numero As String
    Private m_caravana As String
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
    Public Property NUMERO() As String
        Get
            Return m_numero
        End Get
        Set(ByVal value As String)
            m_numero = value
        End Set
    End Property
    Public Property CARAVANA() As String
        Get
            Return m_caravana
        End Get
        Set(ByVal value As String)
            m_caravana = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_numero = ""
        m_caravana = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal numero As String, ByVal caravana As String)
        m_id = id
        m_ficha = ficha
        m_numero = numero
        m_caravana = caravana
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCaravanas
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCaravanas
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCaravanas
        Return p.eliminar(Me, usuario)
    End Function
    Public Function eliminarxficha(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCaravanas
        Return p.eliminarxficha(Me, usuario)
    End Function
    Public Function eliminartodo(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCaravanas
        Return p.eliminartodo(Me, usuario)
    End Function
    Public Function buscar() As dCaravanas
        Dim p As New pCaravanas
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pCaravanas
        Return p.listar
    End Function
    Public Function listarxficha(ByVal ficha As Long) As ArrayList
        Dim p As New pCaravanas
        Return p.listarxficha(ficha)
    End Function
End Class
