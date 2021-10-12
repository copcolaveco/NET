Public Class dReclamos
#Region "Atributos"
    Private m_id As Long
    Private m_tipo As String
    Private m_fecha As String
    Private m_categoria As String
    Private m_fuente As String
    Private m_descripcion As String
    Private m_analisis As String
    Private m_acciones As String
    Private m_responsable As String
    Private m_fechaaccion As String
    Private m_seguimiento As String
    Private m_cierreproblema As String
    Private m_observaciones As String
    Private m_acreditado As Integer
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
    Public Property TIPO() As String
        Get
            Return m_tipo
        End Get
        Set(ByVal value As String)
            m_tipo = value
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
    Public Property CATEGORIA() As String
        Get
            Return m_categoria
        End Get
        Set(ByVal value As String)
            m_categoria = value
        End Set
    End Property
    Public Property FUENTE() As String
        Get
            Return m_fuente
        End Get
        Set(ByVal value As String)
            m_fuente = value
        End Set
    End Property
    Public Property DESCRIPCION() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Public Property ANALISIS() As String
        Get
            Return m_analisis
        End Get
        Set(ByVal value As String)
            m_analisis = value
        End Set
    End Property
    Public Property ACCIONES() As String
        Get
            Return m_acciones
        End Get
        Set(ByVal value As String)
            m_acciones = value
        End Set
    End Property
    Public Property RESPONSABLE() As String
        Get
            Return m_responsable
        End Get
        Set(ByVal value As String)
            m_responsable = value
        End Set
    End Property
    Public Property FECHAACCION() As String
        Get
            Return m_fechaaccion
        End Get
        Set(ByVal value As String)
            m_fechaaccion = value
        End Set
    End Property
    Public Property SEGUIMIENTO() As String
        Get
            Return m_seguimiento
        End Get
        Set(ByVal value As String)
            m_seguimiento = value
        End Set
    End Property
    Public Property CIERREPROBLEMA() As String
        Get
            Return m_cierreproblema
        End Get
        Set(ByVal value As String)
            m_cierreproblema = value
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
    Public Property ACREDITADO() As Integer
        Get
            Return m_acreditado
        End Get
        Set(ByVal value As Integer)
            m_acreditado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_tipo = ""
        m_fecha = ""
        m_categoria = ""
        m_fuente = ""
        m_descripcion = ""
        m_analisis = ""
        m_acciones = ""
        m_responsable = ""
        m_fechaaccion = ""
        m_seguimiento = ""
        m_cierreproblema = ""
        m_observaciones = ""
        m_acreditado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal tipo As String, ByVal fecha As String, ByVal categoria As String, ByVal fuente As String, ByVal descripcion As String, ByVal analisis As String, ByVal acciones As String, ByVal responsable As String, ByVal fechaaccion As String, ByVal seguimiento As String, ByVal cierreproblema As String, ByVal observaciones As String, ByVal acreditado As Integer)
        m_id = id
        m_tipo = tipo
        m_fecha = fecha
        m_categoria = categoria
        m_fuente = fuente
        m_descripcion = descripcion
        m_analisis = analisis
        m_acciones = acciones
        m_responsable = responsable
        m_fechaaccion = fechaaccion
        m_seguimiento = seguimiento
        m_cierreproblema = cierreproblema
        m_observaciones = observaciones
        m_acreditado = acreditado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pReclamos
        Return r.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pReclamos
        Return r.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pReclamos
        Return r.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dReclamos
        Dim r As New pReclamos
        Return r.buscar(Me)
    End Function
    
#End Region

    Public Overrides Function tostring() As String
        Return m_id & " - " & m_fecha & " - " & m_categoria
    End Function
    Public Function listar() As ArrayList
        Dim r As New pReclamos
        Return r.listar
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim r As New pReclamos
        Return r.listarporfecha(desde, hasta)
    End Function
    Public Function listartodos(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal categoria As String, ByVal fuente As String) As ArrayList
        Dim r As New pReclamos
        Return r.listartodos(desde, hasta, tipo, categoria, fuente)
    End Function
    Public Function listartipocategoria(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal categoria As String) As ArrayList
        Dim r As New pReclamos
        Return r.listartipocategoria(desde, hasta, tipo, categoria)
    End Function
    Public Function listartipofuente(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal fuente As String) As ArrayList
        Dim r As New pReclamos
        Return r.listartipofuente(desde, hasta, tipo, fuente)
    End Function
    Public Function listarfuentecategoria(ByVal desde As String, ByVal hasta As String, ByVal fuente As String, ByVal categoria As String) As ArrayList
        Dim r As New pReclamos
        Return r.listarfuentecategoria(desde, hasta, fuente, categoria)
    End Function
    Public Function listartipo(ByVal desde As String, ByVal hasta As String, ByVal tipo As String) As ArrayList
        Dim r As New pReclamos
        Return r.listartipo(desde, hasta, tipo)
    End Function
    Public Function listarcategoria(ByVal desde As String, ByVal hasta As String, ByVal categoria As String) As ArrayList
        Dim r As New pReclamos
        Return r.listarcategoria(desde, hasta, categoria)
    End Function
    Public Function listarfuente(ByVal desde As String, ByVal hasta As String, ByVal fuente As String) As ArrayList
        Dim r As New pReclamos
        Return r.listarfuente(desde, hasta, fuente)
    End Function
End Class
