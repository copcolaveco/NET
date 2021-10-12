Public Class dEmpresaT
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_direccion As String
    Private m_telefono As String
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
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_direccion = ""
        m_telefono = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal direccion As String, ByVal telefono As String)
        m_id = id
        m_nombre = nombre
        m_direccion = direccion
        m_telefono = telefono
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEmpresaT
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEmpresaT
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pEmpresaT
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dEmpresaT
        Dim p As New pEmpresaT
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pEmpresaT
        Return p.listar
    End Function
End Class
