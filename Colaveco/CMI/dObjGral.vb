Public Class dObjGral
#Region "Atributos"
    Private m_id As Long
    Private m_iddimension As Long
    Private m_nombre As String
    Private m_ano As Integer
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
    Public Property IDDIMENSION() As Long
        Get
            Return m_iddimension
        End Get
        Set(ByVal value As Long)
            m_iddimension = value
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
    Public Property ANO() As Integer
        Get
            Return m_ano
        End Get
        Set(ByVal value As Integer)
            m_ano = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_iddimension = 0
        m_nombre = ""
        m_ano = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal iddimension As Long, ByVal nombre As String, ByVal ano As Integer)
        m_id = id
        m_iddimension = iddimension
        m_nombre = nombre
        m_ano = ano
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim og As New pObjGral
        Return og.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim og As New pObjGral
        Return og.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim og As New pObjGral
        Return og.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dObjGral
        Dim og As New pObjGral
        Return og.buscar(Me)
    End Function
    Public Function buscarxiddimension() As dObjGral
        Dim og As New pObjGral
        Return og.buscarxiddimension(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function

    Public Function listar() As ArrayList
        Dim og As New pObjGral
        Return og.listar
    End Function
    Public Function listarxano(ByVal ano As Integer) As ArrayList
        Dim og As New pObjGral
        Return og.listarxano(ano)
    End Function
    Public Function listarxdimension(ByVal iddimension As Long) As ArrayList
        Dim og As New pObjGral
        Return og.listarxdimension(iddimension)
    End Function
End Class
