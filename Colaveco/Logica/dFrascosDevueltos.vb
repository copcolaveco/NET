Public Class dFrascosDevueltos
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_idcliente As Long
    Private m_rc_compos As Integer
    Private m_agua As Integer
    Private m_sangre As Integer
    Private m_esteriles As Integer
    Private m_otros As Integer
    Private m_observaciones As String
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
    Public Property IDCLIENTE() As Long
        Get
            Return m_idcliente
        End Get
        Set(ByVal value As Long)
            m_idcliente = value
        End Set
    End Property
    Public Property RC_COMPOS() As Integer
        Get
            Return m_rc_compos
        End Get
        Set(ByVal value As Integer)
            m_rc_compos = value
        End Set
    End Property
    Public Property AGUA() As Integer
        Get
            Return m_agua
        End Get
        Set(ByVal value As Integer)
            m_agua = value
        End Set
    End Property
    Public Property SANGRE() As Integer
        Get
            Return m_sangre
        End Get
        Set(ByVal value As Integer)
            m_sangre = value
        End Set
    End Property
    Public Property ESTERILES() As Integer
        Get
            Return m_esteriles
        End Get
        Set(ByVal value As Integer)
            m_esteriles = value
        End Set
    End Property
    Public Property OTROS() As Integer
        Get
            Return m_otros
        End Get
        Set(ByVal value As Integer)
            m_otros = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_idcliente = 0
        m_rc_compos = 0
        m_agua = 0
        m_sangre = 0
        m_sangre = 0
        m_esteriles = 0
        m_otros = 0
        m_observaciones = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal idcliente As Long, ByVal rc_compos As Integer, ByVal agua As Integer, ByVal sangre As Integer, ByVal esteriles As Integer, ByVal otros As Integer, ByVal observaciones As String)
        m_id = id
        m_fecha = fecha
        m_idcliente = idcliente
        m_rc_compos = rc_compos
        m_agua = agua
        m_sangre = sangre
        m_esteriles = esteriles
        m_otros = otros
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim f As New pFrascosDevueltos
        Return f.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim f As New pFrascosDevueltos
        Return f.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim f As New pFrascosDevueltos
        Return f.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dFrascosDevueltos
        Dim f As New pFrascosDevueltos
        Return f.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Dim p As New dCliente
        p.ID = m_idcliente
        p = p.buscar
        Return m_fecha & " - " & p.NOMBRE
    End Function

    Public Function listar() As ArrayList
        Dim f As New pFrascosDevueltos
        Return f.listar
    End Function
End Class
