Public Class dCotizacion
#Region "Atributos"
    Private m_id As Long
    Private m_proveedor As Integer
    Private m_email As String
    Private m_proveedor2 As Integer
    Private m_email2 As String
    Private m_proveedor3 As Integer
    Private m_email3 As String
    Private m_fecha As String
    Private m_usuariocreador As Integer
    Private m_enviado As Integer
    Private m_observaciones As String
    Private m_asociada As Integer
    Private m_anulada As Integer

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
    Public Property PROVEEDOR() As Integer
        Get
            Return m_proveedor
        End Get
        Set(ByVal value As Integer)
            m_proveedor = value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property PROVEEDOR2() As Integer
        Get
            Return m_proveedor2
        End Get
        Set(ByVal value As Integer)
            m_proveedor2 = value
        End Set
    End Property
    Public Property EMAIL2() As String
        Get
            Return m_email2
        End Get
        Set(ByVal value As String)
            m_email2 = value
        End Set
    End Property
    Public Property PROVEEDOR3() As Integer
        Get
            Return m_proveedor3
        End Get
        Set(ByVal value As Integer)
            m_proveedor3 = value
        End Set
    End Property
    Public Property EMAIL3() As String
        Get
            Return m_email3
        End Get
        Set(ByVal value As String)
            m_email3 = value
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
    Public Property USUARIOCREADOR() As Integer
        Get
            Return m_usuariocreador
        End Get
        Set(ByVal value As Integer)
            m_usuariocreador = value
        End Set
    End Property
    
    Public Property ENVIADO() As Integer
        Get
            Return m_enviado
        End Get
        Set(ByVal value As Integer)
            m_enviado = value
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
    Public Property ASOCIADA() As Integer
        Get
            Return m_asociada
        End Get
        Set(ByVal value As Integer)
            m_asociada = value
        End Set
    End Property
    Public Property ANULADA() As Integer
        Get
            Return m_anulada
        End Get
        Set(ByVal value As Integer)
            m_anulada = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_proveedor = 0
        m_email = ""
        m_proveedor2 = 0
        m_email2 = ""
        m_proveedor3 = 0
        m_email3 = ""
        m_fecha = ""
        m_usuariocreador = 0
        m_enviado = 0
        m_observaciones = ""
        m_asociada = 0
        m_anulada = 0

    End Sub
    Public Sub New(ByVal id As Integer, ByVal proveedor As Integer, ByVal email As String, ByVal proveedor2 As Integer, ByVal email2 As String, ByVal proveedor3 As Integer, ByVal email3 As String, ByVal fecha As String, ByVal usuariocreador As Integer, ByVal enviado As Integer, ByVal observaciones As String, ByVal asociada As Integer, ByVal anulada As Integer)
        m_id = id
        m_proveedor = proveedor
        m_email = email
        m_proveedor2 = proveedor2
        m_email2 = email2
        m_proveedor3 = proveedor3
        m_email3 = email3
        m_fecha = fecha
        m_usuariocreador = usuariocreador
        m_enviado = enviado
        m_observaciones = observaciones
        m_asociada = asociada
        m_anulada = anulada
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCotizacion
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCotizacion
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCotizacion
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCotizacion
        Dim p As New pCotizacion
        Return p.buscar(Me)
    End Function
    Public Function buscarultimoid() As dCotizacion
        Dim p As New pCotizacion
        Return p.buscarultimoid(Me)
    End Function
#End Region


    Public Overrides Function ToString() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim p As New pCotizacion
        Return p.listar
    End Function
    Public Function listarsinasociar() As ArrayList
        Dim p As New pCotizacion
        Return p.listarsinasociar
    End Function

   
    Public Function marcaranulada(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCotizacion
        Return p.marcaranulada(Me, usuario)
    End Function
   
    Public Function marcarenviado(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCotizacion
        Return p.marcarenviado(Me, usuario)
    End Function
    Public Function marcarasociada(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCotizacion
        Return p.marcarasociada(Me, usuario)
    End Function
End Class
