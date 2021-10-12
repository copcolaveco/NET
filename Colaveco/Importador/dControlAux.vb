Public Class dControlAux
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As String
    Private m_fecha As String
    Private m_productor As Integer
    Private m_muestra As String
    Private m_rc As Integer
    Private m_tambo As Integer
    

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
    Public Property FICHA() As String
        Get
            Return m_ficha
        End Get
        Set(ByVal value As String)
            m_ficha = value
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
    Public Property PRODUCTOR() As Integer
        Get
            Return m_productor
        End Get
        Set(ByVal value As Integer)
            m_productor = value
        End Set
    End Property
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property RC() As Integer
        Get
            Return m_rc
        End Get
        Set(ByVal value As Integer)
            m_rc = value
        End Set
    End Property
    Public Property TAMBO() As Integer
        Get
            Return m_tambo
        End Get
        Set(ByVal value As Integer)
            m_tambo = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = ""
        m_fecha = ""
        m_productor = 0
        m_muestra = ""
        m_rc = 0
        m_tambo = 0
        
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As String, ByVal fecha As String, ByVal productor As Integer, ByVal muestra As String, ByVal rc As Integer, ByVal tambo As Integer)
        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_productor = productor
        m_muestra = muestra
        m_rc = rc
        m_tambo = tambo

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pControlAux
        Return c.guardar(Me)
    End Function
    Public Function modificar() As Boolean
        Dim c As New pControlAux
        Return c.modificar(Me)
    End Function
    Public Function eliminar() As Boolean
        Dim c As New pControlAux
        Return c.eliminar(Me)
    End Function
    Public Function buscar() As dControlAux
        Dim c As New pControlAux
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pControlAux
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pControlAux
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As String) As ArrayList
        Dim c As New pControlAux
        Return c.listarporsolicitud(texto)
    End Function
    Public Function listarsinsubir(ByVal ultimonumero As Long) As ArrayList
        Dim c As New pControlAux
        Return c.listarsinsubir(ultimonumero)
    End Function
    Public Function listarsinsubir2(ByVal ficha As Long) As ArrayList
        Dim c As New pControlAux
        Return c.listarsinsubir2(ficha)
    End Function
    Public Function listarsinrepetir(ByVal numficha As Long) As ArrayList
        Dim c As New pControlAux
        Return c.listarsinrepetir(numficha)
    End Function
    Public Function listarfichas() As ArrayList
        Dim c As New pControlAux
        Return c.listarfichas
    End Function
    Public Function listarfichassincontrolar(ByVal ultimaficha As Long) As ArrayList
        Dim c As New pControlAux
        Return c.listarfichassincontrolar(ultimaficha)
    End Function
End Class
