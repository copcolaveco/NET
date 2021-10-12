Public Class dActasItem
#Region "Atributos"
    Private m_id As Long
    Private m_idacta As Long
    Private m_tema As String
    Private m_resumen As String
    Private m_responsables As String
    Private m_titular As Integer
    Private m_titular2 As Integer
    Private m_plazo As String
    Private m_efectuado As Integer
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
    Public Property IDACTA() As Long
        Get
            Return m_idacta
        End Get
        Set(ByVal value As Long)
            m_idacta = value
        End Set
    End Property
    Public Property TEMA() As String
        Get
            Return m_tema
        End Get
        Set(ByVal value As String)
            m_tema = value
        End Set
    End Property
    Public Property RESUMEN() As String
        Get
            Return m_resumen
        End Get
        Set(ByVal value As String)
            m_resumen = value
        End Set
    End Property
    Public Property RESPONSABLES() As String
        Get
            Return m_responsables
        End Get
        Set(ByVal value As String)
            m_responsables = value
        End Set
    End Property
    Public Property TITULAR() As Integer
        Get
            Return m_titular
        End Get
        Set(ByVal value As Integer)
            m_titular = value
        End Set
    End Property
    Public Property TITULAR2() As Integer
        Get
            Return m_titular2
        End Get
        Set(ByVal value As Integer)
            m_titular2 = value
        End Set
    End Property
    Public Property PLAZO() As String
        Get
            Return m_plazo
        End Get
        Set(ByVal value As String)
            m_plazo = value
        End Set
    End Property
    Public Property EFECTUADO() As Integer
        Get
            Return m_efectuado
        End Get
        Set(ByVal value As Integer)
            m_efectuado = value
        End Set
    End Property

#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idacta = 0
        m_tema = ""
        m_resumen = ""
        m_responsables = 0
        m_titular = 0
        m_titular2 = 0
        m_plazo = 0
        m_efectuado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal idacta As Long, ByVal tema As String, ByVal resumen As String, ByVal responsables As String, ByVal titular As Integer, ByVal titular2 As Integer, ByVal plazo As String, ByVal efectuado As Integer)
        m_id = id
        m_idacta = idacta
        m_tema = tema
        m_resumen = resumen
        m_responsables = responsables
        m_titular = titular
        m_titular2 = titular2
        m_plazo = plazo
        m_efectuado = efectuado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActasItem
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActasItem
        Return s.modificar(Me, usuario)
    End Function
    Public Function marcarefectuada(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActasItem
        Return s.marcarefectuada(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pActasItem
        Return s.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dActasItem
        Dim s As New pActasItem
        Return s.buscar(Me)
    End Function

#End Region

    Public Overrides Function tostring() As String
        Return m_id
    End Function
    Public Function listar() As ArrayList
        Dim s As New pActasItem
        Return s.listar
    End Function
   
    Public Function listarxidacta(ByVal idacta As Long) As ArrayList
        Dim s As New pActasItem
        Return s.listarxidacta(idacta)
    End Function
    Public Function listarpendientes() As ArrayList
        Dim s As New pActasItem
        Return s.listarpendientes
    End Function
    Public Function listarvencidos(ByVal fecha As String) As ArrayList
        Dim s As New pActasItem
        Return s.listarvencidos(fecha)
    End Function
    Public Function listarefectuados() As ArrayList
        Dim s As New pActasItem
        Return s.listarefectuados
    End Function
    Public Function listarefectuadosxgrupo(ByVal idacta As Long) As ArrayList
        Dim s As New pActasItem
        Return s.listarefectuadosxgrupo(idacta)
    End Function
    Public Function listartodosxgrupo(ByVal idacta As Long) As ArrayList
        Dim s As New pActasItem
        Return s.listartodosxgrupo(idacta)
    End Function
    Public Function listarpendientesxgrupo(ByVal idacta As Long) As ArrayList
        Dim s As New pActasItem
        Return s.listarpendientesxgrupo(idacta)
    End Function
    Public Function listarvencidosxgrupo(ByVal idacta As Long, ByVal fec As String) As ArrayList
        Dim s As New pActasItem
        Return s.listarvencidosxgrupo(idacta, fec)
    End Function
    Public Function listarxtitular(ByVal idusuario As Integer) As ArrayList
        Dim s As New pActasItem
        Return s.listarxtitular(idusuario)
    End Function
End Class
