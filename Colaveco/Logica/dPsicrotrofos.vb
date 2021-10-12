Public Class dPsicrotrofos
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_ficha As Long
    Private m_muestra As String
    Private m_valor1 As String
    Private m_valor2 As String
    Private m_promedio As String

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
    Public Property VALOR1() As String
        Get
            Return m_valor1
        End Get
        Set(ByVal value As String)
            m_valor1 = value
        End Set
    End Property
    Public Property VALOR2() As String
        Get
            Return m_valor2
        End Get
        Set(ByVal value As String)
            m_valor2 = value
        End Set
    End Property
   
    Public Property PROMEDIO() As String
        Get
            Return m_promedio
        End Get
        Set(ByVal value As String)
            m_promedio = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_ficha = 0
        m_muestra = ""
        m_valor1 = ""
        m_valor2 = ""
        m_promedio = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal ficha As Long, ByVal muestra As String, ByVal valor1 As String, ByVal valor2 As String, ByVal promedio As String)
        m_id = id
        m_fecha = fecha
        m_ficha = ficha
        m_muestra = muestra
        m_valor1 = valor1
        m_valor2 = valor2
        m_promedio = promedio

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pPsicrotrofos
        Return r.guardar(Me, usuario)
    End Function
    Public Function guardar2() As Boolean
        Dim r As New pPsicrotrofos
        Return r.guardar2(Me)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pPsicrotrofos
        Return r.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pPsicrotrofos
        Return r.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dPsicrotrofos
        Dim r As New pPsicrotrofos
        Return r.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dPsicrotrofos
        Dim r As New pPsicrotrofos
        Return r.buscarxfichaxmuestra(Me)
    End Function
#End Region

    Public Overrides Function tostring() As String
        Return m_id & " - " & m_fecha
    End Function
    Public Function listar(ByVal paginado As Integer) As ArrayList
        Dim r As New pPsicrotrofos
        Return r.listar(paginado)
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim r As New pPsicrotrofos
        Return r.listarporfecha(desde, hasta)
    End Function
    
End Class
