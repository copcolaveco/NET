Public Class dMuestras
#Region "Atributos"
    Private m_id As Integer
    Private m_nombre As String
    Private m_tipoinforme As Integer
    Private m_nousar As Integer
    Private m_acreditado As Integer
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
    Public Property TIPOINFORME() As Integer
        Get
            Return m_tipoinforme
        End Get
        Set(ByVal value As Integer)
            m_tipoinforme = value
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
    Public Property ACREDITADO() As Integer
        Get
            Return m_acreditado
        End Get
        Set(ByVal value As Integer)
            m_acreditado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_tipoinforme = 0
        m_nousar = 0
        m_acreditado = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal tipoinforme As Integer, ByVal nousar As Integer, ByVal acreditado As Integer)
        m_id = id
        m_nombre = nombre
        m_tipoinforme = tipoinforme
        m_nousar = nousar
        m_acreditado = acreditado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMuestras
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMuestras
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pMuestras
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dMuestras
        Dim p As New pMuestras
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim p As New pMuestras
        Return p.listar
    End Function
    Public Function listarxinforme(ByVal informe As Integer) As ArrayList
        Dim p As New pMuestras
        Return p.listarxinforme(informe)
    End Function
End Class
