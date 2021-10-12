Public Class dSinVisualizacion
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fecha As String
    Private m_muestras As Integer
    Private m_importe As Double
    Private m_abonado As Integer
    Private m_visualizacion As Integer
    Private m_fechavisualizacion As String
    Private m_observaciones As String
    
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
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property MUESTRAS() As Integer
        Get
            Return m_muestras
        End Get
        Set(ByVal value As Integer)
            m_muestras = value
        End Set
    End Property
    Public Property IMPORTE() As Double
        Get
            Return m_importe
        End Get
        Set(ByVal value As Double)
            m_importe = value
        End Set
    End Property
    Public Property ABONADO() As Integer
        Get
            Return m_abonado
        End Get
        Set(ByVal value As Integer)
            m_abonado = value
        End Set
    End Property
    Public Property VISUALIZACION() As Integer
        Get
            Return m_visualizacion
        End Get
        Set(ByVal value As Integer)
            m_visualizacion = value
        End Set
    End Property
    Public Property FECHAVISUALIZACION() As String
        Get
            Return m_fechavisualizacion
        End Get
        Set(ByVal value As String)
            m_fechavisualizacion = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_fecha = Now
        m_muestras = 0
        m_importe = 0
        m_abonado = 0
        m_visualizacion = 0
        m_fechavisualizacion = ""
        m_observaciones = ""
        
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fecha As String, ByVal muestras As Integer, ByVal importe As Double, ByVal abonado As Integer, ByVal visualizacion As Integer, ByVal fechavisualizacion As String, ByVal observaciones As String)
        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_muestras = muestras
        m_importe = importe
        m_abonado = abonado
        m_visualizacion = visualizacion
        m_fechavisualizacion = fechavisualizacion
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar() As Boolean
        Dim c As New pSinVisualizacion
        Return c.guardar(Me)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSinVisualizacion
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pSinVisualizacion
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dSinVisualizacion
        Dim c As New pSinVisualizacion
        Return c.buscar(Me)
    End Function
    Public Function buscarxficha() As dSinVisualizacion
        Dim c As New pSinVisualizacion
        Return c.buscarxficha(Me)
    End Function
    Public Function actualizarobservaciones() As Boolean
        Dim c As New pSinVisualizacion
        Return c.actualizarobservaciones(Me)
    End Function
#End Region

    Public Overrides Function tostring() As String
        Return m_ficha
    End Function
    Public Function listar() As ArrayList
        Dim c As New pSinVisualizacion
        Return c.listar
    End Function
    Public Function listarsv() As ArrayList
        Dim c As New pSinVisualizacion
        Return c.listarsv
    End Function
    Public Function listarcv() As ArrayList
        Dim c As New pSinVisualizacion
        Return c.listarcv
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pSinVisualizacion
        Return c.listarxfecha(desde, hasta)
    End Function
    Public Function marcarvisualizacion(ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim c As New pSinVisualizacion
        Return c.marcarvisualizacion(Me, usuario, fec)
    End Function
    Public Function desmarcarvisualizacion(ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim c As New pSinVisualizacion
        Return c.desmarcarvisualizacion(Me, usuario, fec)
    End Function
    Public Function guardarobservaciones(ByVal usuario As dUsuario, ByVal obs As String) As Boolean
        Dim c As New pSinVisualizacion
        Return c.guardarobservaciones(Me, usuario, obs)
    End Function
    Public Function guardarmuestras(ByVal usuario As dUsuario, ByVal muestras As Integer) As Boolean
        Dim c As New pSinVisualizacion
        Return c.guardarmuestras(Me, usuario, muestras)
    End Function
    Public Function guardarimporte(ByVal usuario As dUsuario, ByVal importe As Double) As Boolean
        Dim c As New pSinVisualizacion
        Return c.guardarimporte(Me, usuario, importe)
    End Function
    Public Function marcarabonado(ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim c As New pSinVisualizacion
        Return c.marcarabonado(Me, usuario, fec)
    End Function
    Public Function desmarcarabonado(ByVal usuario As dUsuario, ByVal fec As String) As Boolean
        Dim c As New pSinVisualizacion
        Return c.desmarcarabonado(Me, usuario, fec)
    End Function
End Class
