Public Class dCapacitacionCab
#Region "Atributos"
    Private m_id As Integer
    Private m_ano As String
    Private m_area As Integer
    Private m_objetivos As String
    Private m_capacitacion As String
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
    Public Property ANO() As Integer
        Get
            Return m_ano
        End Get
        Set(ByVal value As Integer)
            m_ano = value
        End Set
    End Property
    Public Property AREA() As Integer
        Get
            Return m_area
        End Get
        Set(ByVal value As Integer)
            m_area = value
        End Set
    End Property
    Public Property OBJETIVOS() As String
        Get
            Return m_objetivos
        End Get
        Set(ByVal value As String)
            m_objetivos = value
        End Set
    End Property
    Public Property CAPACITACION() As String
        Get
            Return m_capacitacion
        End Get
        Set(ByVal value As String)
            m_capacitacion = value
        End Set
    End Property
   
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ano = 0
        m_area = 0
        m_objetivos = ""
        m_capacitacion = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal ano As Integer, ByVal area As Integer, ByVal objetivos As String, ByVal capacitacion As Integer, ByVal tipo As Integer)
        m_id = id
        m_ano = ano
        m_area = area
        m_objetivos = objetivos
        m_capacitacion = capacitacion
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCapacitacionCab
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCapacitacionCab
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCapacitacionCab
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCapacitacionCab
        Dim p As New pCapacitacionCab
        Return p.buscar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Dim a As New dAreas
        a.ID = m_area
        a = a.buscar
        Return a.NOMBRE & " - " & m_capacitacion
    End Function

    Public Function listar() As ArrayList
        Dim p As New pCapacitacionCab
        Return p.listar
    End Function
    Public Function listarxano(ByVal ano As Long) As ArrayList
        Dim p As New pCapacitacionCab
        Return p.listarxano(ano)
    End Function
End Class
