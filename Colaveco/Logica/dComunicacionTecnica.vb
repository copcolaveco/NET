Public Class dComunicacionTecnica
#Region "Atributos"
    Private m_id As Long
    Private m_fecha As String
    Private m_tipocliente As String
    Private m_cliente As Integer
    Private m_tecnico As Integer
    Private m_descripcion As String
    Private m_tecnicoresp As Integer
    Private m_acciones As String
    Private m_respacciones As Integer
    Private m_observaciones As String
    Private m_visto As Integer
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
    Public Property TIPOCLIENTE() As String
        Get
            Return m_tipocliente
        End Get
        Set(ByVal value As String)
            m_tipocliente = value
        End Set
    End Property
    Public Property CLIENTE() As Integer
        Get
            Return m_cliente
        End Get
        Set(ByVal value As Integer)
            m_cliente = value
        End Set
    End Property
    Public Property TECNICO() As Integer
        Get
            Return m_tecnico
        End Get
        Set(ByVal value As Integer)
            m_tecnico = value
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
    Public Property TECNICORESP() As Integer
        Get
            Return m_tecnicoresp
        End Get
        Set(ByVal value As Integer)
            m_tecnicoresp = value
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
    Public Property RESPACCIONES() As Integer
        Get
            Return m_respacciones
        End Get
        Set(ByVal value As Integer)
            m_respacciones = value
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
    Public Property VISTO() As Integer
        Get
            Return m_visto
        End Get
        Set(ByVal value As Integer)
            m_visto = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fecha = ""
        m_tipocliente = ""
        m_cliente = 0
        m_tecnico = 0
        m_descripcion = ""
        m_tecnicoresp = 0
        m_acciones = ""
        m_respacciones = 0
        m_observaciones = ""
        m_visto = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fecha As String, ByVal tipocliente As String, ByVal cliente As Integer, ByVal tecnico As Integer, ByVal descripcion As String, ByVal tecnicoresp As Integer, ByVal acciones As String, ByVal respacciones As Integer, ByVal observaciones As String, ByVal visto As Integer)
        m_id = id
        m_fecha = fecha
        m_tipocliente = tipocliente
        m_cliente = cliente
        m_tecnico = tecnico
        m_descripcion = descripcion
        m_tecnicoresp = tecnicoresp
        m_acciones = acciones
        m_respacciones = respacciones
        m_observaciones = observaciones
        m_visto = visto
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pComunicacionTecnica
        Return r.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pComunicacionTecnica
        Return r.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim r As New pComunicacionTecnica
        Return r.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dComunicacionTecnica
        Dim r As New pComunicacionTecnica
        Return r.buscar(Me)
    End Function
    Public Function marcarvisto(ByVal usuario As dUsuario) As Boolean
        Dim r As New pComunicacionTecnica
        Return r.marcarvisto(Me, usuario)
    End Function
#End Region

    Public Overrides Function tostring() As String
        Return m_id & " - " & m_fecha
    End Function
    Public Function listar() As ArrayList
        Dim r As New pComunicacionTecnica
        Return r.listar
    End Function
    Public Function listarfinalizados() As ArrayList
        Dim r As New pComunicacionTecnica
        Return r.listarfinalizados
    End Function
    Public Function listarsinver(ByVal idusuario As Integer) As ArrayList
        Dim r As New pComunicacionTecnica
        Return r.listarsinver(idusuario)
    End Function
    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim r As New pComunicacionTecnica
        Return r.listarporfecha(desde, hasta)
    End Function
    Public Function listartodos(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal categoria As String, ByVal fuente As String) As ArrayList
        Dim r As New pComunicacionTecnica
        Return r.listartodos(desde, hasta, tipo, categoria, fuente)
    End Function
    Public Function listartipocliente(ByVal desde As String, ByVal hasta As String, ByVal tipocliente As String) As ArrayList
        Dim r As New pComunicacionTecnica
        Return r.listartipocliente(desde, hasta, tipocliente)
    End Function
   
End Class
