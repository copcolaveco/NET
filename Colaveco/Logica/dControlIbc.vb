Public Class dControlIbc
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_bajo As Double
    Private m_alto As Double

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
    
    Public Property BAJO() As Double
        Get
            Return m_bajo
        End Get
        Set(ByVal value As Double)
            m_bajo = value
        End Set
    End Property
    
    Public Property ALTO() As Double
        Get
            Return m_alto
        End Get
        Set(ByVal value As Double)
            m_alto = value
        End Set
    End Property
   
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = Now
        m_bajo = 0
        m_alto = 0
       
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal bajo As Double, ByVal alto As Double)
        m_id = id
        m_fecha = fecha
        m_bajo = bajo
        m_alto = alto
       
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pControlIbc
        Return p.guardar(Me)
    End Function
    
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pControlIbc
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dControlIbc
        Dim p As New pControlIbc
        Return p.buscar(Me)
    End Function
    Public Function buscarultimo() As dControlIbc
        Dim p As New pControlIbc
        Return p.buscarultimo(Me)
    End Function
#End Region

    Public Overrides Function tostring() As String
        Return m_id & " " & m_fecha
    End Function
    Public Function listar() As ArrayList
        Dim p As New pControlIbc
        Return p.listar
    End Function
    
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pControlIbc
        Return p.listarporfecha(desde, hasta)
    End Function
    Public Function listarultimosdiez() As ArrayList
        Dim p As New pControlIbc
        Return p.listarultimosdiez
    End Function
End Class
