Public Class dProductorEmpresa
#Region "Atributos"
    Private m_id As Long
    Private m_idproductor As Long
    Private m_matricula As String
    Private m_idempresa As Long
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
    Public Property IDPRODUCTOR() As Long
        Get
            Return m_idproductor
        End Get
        Set(ByVal value As Long)
            m_idproductor = value
        End Set
    End Property
    Public Property MATRICULA() As String
        Get
            Return m_matricula
        End Get
        Set(ByVal value As String)
            m_matricula = value
        End Set
    End Property
    Public Property IDEMPRESA() As Long
        Get
            Return m_idempresa
        End Get
        Set(ByVal value As Long)
            m_idempresa = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idproductor = 0
        m_matricula = ""
        m_idempresa = 0
    End Sub
    Public Sub New(ByVal id As Integer, ByVal idproductor As Long, ByVal matricula As String, ByVal idempresa As Integer)
        m_id = id
        m_idproductor = idproductor
        m_matricula = matricula
        m_idempresa = idempresa
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim pe As New pProductorEmpresa
        Return pe.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim pe As New pProductorEmpresa
        Return pe.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim pe As New pProductorEmpresa
        Return pe.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dProductorEmpresa
        Dim pe As New pProductorEmpresa
        Return pe.buscar(Me)
    End Function
    Public Function buscarproductorempresa2() As dProductorEmpresa
        Dim pe As New pProductorEmpresa
        Return pe.buscarproductorempresa2(Me)
    End Function
    Public Function ListarBrucelosisPositivaPorFicha(ByVal ficha As Long) As List(Of dProductorEmpresaResultado)
        Dim pe As New pProductorEmpresa
        Return pe.AntecedentesBrucelosisPorFicha(ficha)
    End Function


#End Region

    Public Overrides Function ToString() As String
        Dim p As New dCliente
        p.ID = m_idempresa
        p = p.buscar
        Return m_idempresa & Chr(9) & p.NOMBRE
    End Function

    Public Function listar() As ArrayList
        Dim pe As New pProductorEmpresa
        Return pe.listar
    End Function
    Public Function listarxid(ByVal idprod As Long) As ArrayList
        Dim pe As New pProductorEmpresa
        Return pe.listarxid(idprod)
    End Function
    Public Function listarxempresa(ByVal idemp As Long) As ArrayList
        Dim pe As New pProductorEmpresa
        Return pe.listarxempresa(idemp)
    End Function
    Public Function buscarproductorempresa(ByVal empresa As Long, ByVal matricula As String) As ArrayList
        Dim pe As New pProductorEmpresa
        Return pe.buscarproductorempresa(empresa, matricula)
    End Function

#Region "Métodos de búsqueda por relación"

    ' Busca la relación productorempresa por idproductor
    Public Function buscarPorProductor() As dProductorEmpresa
        Dim p As New pProductorEmpresa
        Return p.buscarPorProductor(Me.IDPRODUCTOR)
    End Function

    ' Busca la relación productorempresa por matrícula
    Public Function buscarPorMatricula() As dProductorEmpresa
        Dim p As New pProductorEmpresa
        Return p.buscarPorMatricula(Me.MATRICULA)
    End Function

#End Region

End Class
