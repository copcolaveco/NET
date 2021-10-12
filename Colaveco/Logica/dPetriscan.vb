Public Class dPetriscan
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_ficha As Long
    Private m_muestra As String
    Private m_rb As Integer


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
    Public Property RB() As Integer
        Get
            Return m_rb
        End Get
        Set(ByVal value As Integer)
            m_rb = value
        End Set
    End Property
   

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_ficha = 0
        m_muestra = ""
        m_rb = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal ficha As Long, ByVal muestra As String, ByVal rb As Integer)
        m_id = id
        m_fecha = fecha
        m_ficha = ficha
        m_muestra = muestra
        m_rb = rb

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pPetriscan
        Return c.guardar(Me)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pPetriscan
        Return c.modificar(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pPetriscan
        Return c.eliminar(Me)
    End Function
    Public Function buscar() As dPetriscan
        Dim c As New pPetriscan
        Return c.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dPetriscan
        Dim c As New pPetriscan
        Return c.buscarxfichaxmuestra(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pPetriscan
        Return c.listar
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pPetriscan
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pPetriscan
        Return c.listarporsolicitud(texto)
    End Function

End Class
