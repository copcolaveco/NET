Public Class dDetalleMuestreo
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_fecha As String
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
        m_fecha = ""
        m_observaciones = ""
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal fecha As String, ByVal observaciones As String)
        m_id = id
        m_ficha = ficha
        m_fecha = fecha
        m_observaciones = observaciones
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pDetalleMuestreo
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pDetalleMuestreo
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pDetalleMuestreo
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dDetalleMuestreo
        Dim p As New pDetalleMuestreo
        Return p.buscar(Me)
    End Function
    Public Function buscarultimo() As dDetalleMuestreo
        Dim p As New pDetalleMuestreo
        Return p.buscarultimo(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_id
    End Function

    Public Function listar() As ArrayList
        Dim p As New pDetalleMuestreo
        Return p.listar
    End Function
End Class
