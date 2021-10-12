Public Class dLecturasIbc
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_b1 As Double
    Private m_a1 As Double

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
    Public Property B1() As Double
        Get
            Return m_b1
        End Get
        Set(ByVal value As Double)
            m_b1 = value
        End Set
    End Property
   
    Public Property A1() As Double
        Get
            Return m_a1
        End Get
        Set(ByVal value As Double)
            m_a1 = value
        End Set
    End Property
   
    
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = Now
        m_b1 = 0
        m_a1 = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal b1 As Double, ByVal a1 As Double)
        m_id = id
        m_fecha = fecha
        m_b1 = b1
        m_a1 = a1
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim p As New pLecturasIbc
        Return p.guardar(Me)
    End Function
    
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pLecturasIbc
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dLecturasIbc
        Dim p As New pLecturasIbc
        Return p.buscar(Me)
    End Function
    
#End Region

    Public Overrides Function tostring() As String
        
        Return m_id & "" & m_fecha
    End Function
    Public Function listar() As ArrayList
        Dim p As New pLecturasIbc
        Return p.listar
    End Function
    
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim p As New pLecturasIbc
        Return p.listarporfecha(desde, hasta)
    End Function
    
End Class
