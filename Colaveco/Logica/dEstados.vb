Public Class dEstados
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_estado As Integer
    Private m_fecha As String
   
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
    Public Property ESTADO() As Integer
        Get
            Return m_estado
        End Get
        Set(ByVal value As Integer)
            m_estado = value
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
  
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_estado = 0
        m_fecha = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal estado As Integer, ByVal fecha As String)
        m_id = id
        m_ficha = ficha
        m_estado = estado
        m_fecha = fecha

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pEstados
        Return s.guardar(Me, usuario)
    End Function
    Public Function guardar2() As Boolean
        Dim s As New pEstados
        Return s.guardar2(Me)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pEstados
        Return s.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pEstados
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dEstados
        Dim s As New pEstados
        Return s.buscar(Me)
    End Function
    Public Function buscarultimo() As dEstados
        Dim s As New pEstados
        Return s.buscarultimo(Me)
    End Function
    
#End Region

    Public Overrides Function tostring() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim s As New pEstados
        Return s.listar
    End Function
    
End Class
