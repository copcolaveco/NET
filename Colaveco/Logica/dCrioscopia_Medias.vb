Public Class dCrioscopia_Medias
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_c1 As Integer
    Private m_c2 As Integer



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
    Public Property C1() As Integer
        Get
            Return m_c1
        End Get
        Set(ByVal value As Integer)
            m_c1 = value
        End Set
    End Property
    Public Property C2() As Integer
        Get
            Return m_c2
        End Get
        Set(ByVal value As Integer)
            m_c2 = value
        End Set
    End Property
    


#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_c1 = 0
        m_c2 = 0


    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal c1 As Integer, ByVal c2 As Integer)
        m_id = id
        m_fecha = fecha
        m_c1 = c1
        m_c2 = c2

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Medias
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Medias
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Medias
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCrioscopia_Medias
        Dim c As New pCrioscopia_Medias
        Return c.buscar(Me)
    End Function
    Public Function buscarultimo() As dCrioscopia_Medias
        Dim c As New pCrioscopia_Medias
        Return c.buscarultimo(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pCrioscopia_Medias
        Return c.listar
    End Function
   
End Class
