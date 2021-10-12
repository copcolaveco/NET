Public Class dTipoInforme
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_nousar As Integer
    Private m_nomostrar As Integer
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
    Public Property NOUSAR() As Integer
        Get
            Return m_nousar
        End Get
        Set(ByVal value As Integer)
            m_nousar = value
        End Set
    End Property
    Public Property NOMOSTRAR() As Integer
        Get
            Return m_nomostrar
        End Get
        Set(ByVal value As Integer)
            m_nomostrar = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_nousar = 0
        m_nomostrar = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal nousar As Integer, ByVal nomostrar As Integer)
        m_id = id
        m_nombre = nombre
        m_nousar = nousar
        m_nomostrar = nomostrar
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTipoInforme
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTipoInforme
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pTipoInforme
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dTipoInforme
        Dim p As New pTipoInforme
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pTipoInforme
        Return p.listar
    End Function
    Public Function listar_viejos() As ArrayList
        Dim p As New pTipoInforme
        Return p.listar_viejos
    End Function
    Public Function listartodos() As ArrayList
        Dim p As New pTipoInforme
        Return p.listartodos
    End Function
End Class
