Public Class dRegistrosAmbientales
#Region "Atributos"
    Private m_id As Long
    Private m_sector As String
    Private m_fecha As String
    Private m_hora As String
    Private m_temperatura As Double
    Private m_humedad As Double

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
    Public Property SECTOR() As String
        Get
            Return m_sector
        End Get
        Set(ByVal value As String)
            m_sector = value
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
    Public Property HORA() As String
        Get
            Return m_hora
        End Get
        Set(ByVal value As String)
            m_hora = value
        End Set
    End Property
    
    Public Property TEMPERATURA() As Double
        Get
            Return m_temperatura
        End Get
        Set(ByVal value As Double)
            m_temperatura = value
        End Set
    End Property
    Public Property HUMEDAD() As Double
        Get
            Return m_humedad
        End Get
        Set(ByVal value As Double)
            m_humedad = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_sector = ""
        m_fecha = ""
        m_hora = ""
        m_temperatura = 0
        m_humedad = 0
        

    End Sub
    Public Sub New(ByVal id As Long, ByVal sector As String, ByVal fecha As String, ByVal hora As String, ByVal temperatura As Double, ByVal humedad As Double)
        m_id = id
        m_sector = sector
        m_fecha = fecha
        m_hora = hora
        m_temperatura = temperatura
        m_humedad = humedad
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRegistrosAmbientales
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRegistrosAmbientales
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pRegistrosAmbientales
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dRegistrosAmbientales
        Dim c As New pRegistrosAmbientales
        Return c.buscar(Me)
    End Function
    Public Function buscarultimofq() As dRegistrosAmbientales
        Dim p As New pRegistrosAmbientales
        Return p.buscarultimofq(Me)
    End Function
    Public Function buscarultimomicro() As dRegistrosAmbientales
        Dim p As New pRegistrosAmbientales
        Return p.buscarultimomicro(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim c As New pRegistrosAmbientales
        Return c.listar
    End Function

End Class
