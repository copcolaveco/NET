Public Class dClienteConvenio
#Region "Atributos"
    Private m_id As Integer
    Private m_cliente As Integer
    Private m_convenio As Integer
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
    Public Property CLIENTE() As Integer
        Get
            Return m_cliente
        End Get
        Set(ByVal value As Integer)
            m_cliente = value
        End Set
    End Property
    Public Property CONVENIO() As Integer
        Get
            Return m_convenio
        End Get
        Set(ByVal value As Integer)
            m_convenio = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_cliente = 0
        m_convenio = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal cliente As Integer, ByVal convenio As Integer)
        m_id = id
        m_cliente = cliente
        m_convenio = convenio
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pClienteConvenio
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pClienteConvenio
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pClienteConvenio
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dClienteConvenio
        Dim p As New pClienteConvenio
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_cliente
    End Function

    Public Function listar() As ArrayList
        Dim p As New pClienteConvenio
        Return p.listar
    End Function
    Public Function listarporcliente(ByVal texto As Integer) As ArrayList
        Dim s As New pClienteConvenio
        Return s.listarporcliente(texto)
    End Function
End Class
