Public Class dAgua3
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fechaentrada As String
    Private m_fechaemision As String
    Private m_idmuestra As String
    Private m_observaciones As String
    Private m_ca As Double
    Private m_mg As Double
    Private m_na As Double
    Private m_fe As Double
    Private m_k As Double
    Private m_al As Double
    Private m_cd As Double
    Private m_cr As Double
    Private m_cu As Double
    Private m_pb As Double
    Private m_mn As Double
    Private m_fem As Double
    Private m_zn As Double
    Private m_se As Double
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
    Public Property FECHAENTRADA() As String
        Get
            Return m_fechaentrada
        End Get
        Set(ByVal value As String)
            m_fechaentrada = value
        End Set
    End Property
    Public Property FECHAEMISION() As String
        Get
            Return m_fechaemision
        End Get
        Set(ByVal value As String)
            m_fechaemision = value
        End Set
    End Property
    Public Property IDMUESTRA() As String
        Get
            Return m_idmuestra
        End Get
        Set(ByVal value As String)
            m_idmuestra = value
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
    Public Property CA() As Double
        Get
            Return m_ca
        End Get
        Set(ByVal value As Double)
            m_ca = value
        End Set
    End Property
    Public Property MG() As Double
        Get
            Return m_mg
        End Get
        Set(ByVal value As Double)
            m_mg = value
        End Set
    End Property
    Public Property NA() As Double
        Get
            Return m_na
        End Get
        Set(ByVal value As Double)
            m_na = value
        End Set
    End Property
    Public Property FE() As Double
        Get
            Return m_fe
        End Get
        Set(ByVal value As Double)
            m_fe = value
        End Set
    End Property
    Public Property K() As Double
        Get
            Return m_k
        End Get
        Set(ByVal value As Double)
            m_k = value
        End Set
    End Property
    Public Property AL() As Double
        Get
            Return m_al
        End Get
        Set(ByVal value As Double)
            m_al = value
        End Set
    End Property
    Public Property CD() As Double
        Get
            Return m_cd
        End Get
        Set(ByVal value As Double)
            m_cd = value
        End Set
    End Property
    Public Property CR() As Double
        Get
            Return m_cr
        End Get
        Set(ByVal value As Double)
            m_cr = value
        End Set
    End Property
    Public Property CU() As Double
        Get
            Return m_cu
        End Get
        Set(ByVal value As Double)
            m_cu = value
        End Set
    End Property
    Public Property PB() As Double
        Get
            Return m_pb
        End Get
        Set(ByVal value As Double)
            m_pb = value
        End Set
    End Property
    Public Property MN() As Double
        Get
            Return m_mn
        End Get
        Set(ByVal value As Double)
            m_mn = value
        End Set
    End Property
    Public Property FEM() As Double
        Get
            Return m_fem
        End Get
        Set(ByVal value As Double)
            m_fem = value
        End Set
    End Property
    Public Property ZN() As Double
        Get
            Return m_zn
        End Get
        Set(ByVal value As Double)
            m_zn = value
        End Set
    End Property
    Public Property SE() As Double
        Get
            Return m_se
        End Get
        Set(ByVal value As Double)
            m_se = value
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
        m_fechaentrada = ""
        m_fechaemision = ""
        m_idmuestra = 0
        m_observaciones = ""
        m_ca = 0
        m_mg = 0
        m_na = 0
        m_fe = 0
        m_k = 0
        m_al = 0
        m_cd = 0
        m_cr = 0
        m_cu = 0
        m_pb = 0
        m_mn = 0
        m_fem = 0
        m_zn = 0
        m_se = 0
        m_operador = 0
        m_marca = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fechaentrada As String, ByVal fechaemision As String, ByVal idmuestra As String, ByVal observaciones As String, ByVal ca As Double, ByVal mg As Double, ByVal na As Double, ByVal fe As Double, ByVal k As Double, ByVal al As Double, ByVal cd As Double, ByVal cr As Double, ByVal cu As Double, ByVal pb As Double, ByVal mn As Double, ByVal fem As Double, ByVal zn As Double, ByVal se As Double, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_fechaentrada = fechaentrada
        m_fechaemision = fechaemision
        m_idmuestra = idmuestra
        m_observaciones = observaciones
        m_ca = ca
        m_mg = mg
        m_na = na
        m_fe = fe
        m_k = k
        m_al = al
        m_cd = cd
        m_cr = cr
        m_cu = cu
        m_pb = pb
        m_mn = mn
        m_fem = fem
        m_zn = zn
        m_se = se
        m_operador = operador
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua3
        Return a.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua3
        Return a.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua3
        Return a.modificar2(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim a As New pAgua3
        Return a.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dAgua3
        Dim a As New pAgua3
        Return a.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha & Chr(9) & m_idmuestra
    End Function
    Public Function listar() As ArrayList
        Dim a As New pAgua3
        Return a.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim a As New pAgua3
        Return a.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim a As New pAgua3
        Return a.listarporid(texto)
    End Function
    Public Function listarporid2(ByVal texto As Long) As ArrayList
        Dim a As New pAgua3
        Return a.listarporid2(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim a As New pAgua3
        Return a.listarporsolicitud(texto)
    End Function
    Public Function listarporsolicitud2(ByVal texto As Long) As ArrayList
        Dim a As New pAgua3
        Return a.listarporsolicitud2(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim a As New pAgua3
        Return a.listarporfecha(fechadesde, fechahasta)
    End Function
End Class
