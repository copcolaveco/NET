Public Class dCrioscopia_Fichas
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
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
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
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
        m_muestra = ""
        m_marca = 0


    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal marca As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_marca = marca

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Fichas
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Fichas
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Fichas
        Return c.modificar2(Me, usuario)
    End Function
    Public Function marcarfichas(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Fichas
        Return c.marcarfichas(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pCrioscopia_Fichas
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCrioscopia_Fichas
        Dim c As New pCrioscopia_Fichas
        Return c.buscar(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pCrioscopia_Fichas
        Return c.listar
    End Function
    Public Function listarsinmarcar() As ArrayList
        Dim c As New pCrioscopia_Fichas
        Return c.listarsinmarcar
    End Function
End Class
