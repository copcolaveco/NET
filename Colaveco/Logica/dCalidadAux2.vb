Public Class dCalidadAux2
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As String
    Private m_muestra As String
    Private m_crioscopia As Integer
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
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property CRIOSCOPIA() As Integer
        Get
            Return m_crioscopia
        End Get
        Set(ByVal value As Integer)
            m_crioscopia = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = ""
        m_muestra = ""
        m_crioscopia = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As String, ByVal muestra As String, ByVal crioscopia As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_crioscopia = crioscopia
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadAux2
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadAux2
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadAux2
        Return c.eliminar(Me, usuario)
    End Function
    Public Function eliminartodo(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCalidadAux2
        Return c.eliminartodo(Me, usuario)
    End Function
    Public Function eliminarxficha() As Boolean
        Dim c As New pCalidadAux2
        Return c.eliminarxficha(Me)
    End Function
    Public Function buscar() As dCalidadAux2
        Dim c As New pCalidadAux2
        Return c.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dCalidadAux2
        Dim c As New pCalidadAux2
        Return c.buscarxfichaxmuestra(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pCalidadAux2
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadAux2
        Return c.listarporid(texto)
    End Function

    Public Function listarxficha(ByVal texto As Long) As ArrayList
        Dim c As New pCalidadAux2
        Return c.listarxficha(texto)
    End Function

End Class
