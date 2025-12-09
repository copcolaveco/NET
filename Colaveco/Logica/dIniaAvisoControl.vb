Public Class dIniaAvisoControl

#Region "Atributos"
    Private m_id As Long
    Private m_matriculaid As Long
    Private m_empresaid As Long
    Private m_mes As Integer
    Private m_anio As Integer
    Private m_fecharegistro As Date
#End Region

#Region "Constructores"

    Public Sub New()
        m_id = 0
        m_matriculaid = 0
        m_empresaid = 0
        m_mes = 0
        m_anio = 0
        m_fecharegistro = Now  'Fecha actual por defecto
    End Sub

    Public Sub New(ByVal id As Long, ByVal matriculaid As Long, ByVal empresaid As Long,
                   ByVal mes As Integer, ByVal anio As Integer,
                   ByVal fecharegistro As Date)

        m_id = id
        m_matriculaid = matriculaid
        m_empresaid = empresaid
        m_mes = mes
        m_anio = anio
        m_fecharegistro = fecharegistro

    End Sub

#End Region

#Region "Propiedades"

    Public Property ID() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property

    Public Property MATRICULAID() As Long
        Get
            Return m_matriculaid
        End Get
        Set(ByVal value As Long)
            m_matriculaid = value
        End Set
    End Property

    Public Property EMPRESAID() As Long
        Get
            Return m_empresaid
        End Get
        Set(ByVal value As Long)
            m_empresaid = value
        End Set
    End Property

    Public Property MES() As Integer
        Get
            Return m_mes
        End Get
        Set(ByVal value As Integer)
            m_mes = value
        End Set
    End Property

    Public Property ANIO() As Integer
        Get
            Return m_anio
        End Get
        Set(ByVal value As Integer)
            m_anio = value
        End Set
    End Property

    Public Property FECHAREGISTRO() As Date
        Get
            Return m_fecharegistro
        End Get
        Set(ByVal value As Date)
            m_fecharegistro = value
        End Set
    End Property

#End Region

#Region "Métodos"

    Public Overrides Function ToString() As String
        Return m_matriculaid & " - " & m_empresaid & " -> " & m_mes & "/" & m_anio
    End Function

    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pIniaAvisoControl
        Return p.guardar(Me, usuario)
    End Function

    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pIniaAvisoControl
        Return p.modificar(Me, usuario)
    End Function

    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pIniaAvisoControl
        Return p.eliminar(Me, usuario)
    End Function

    Public Function buscar() As dIniaAvisoControl
        Dim p As New pIniaAvisoControl
        Return p.buscar(Me.ID)
    End Function

    Public Shared Function listar() As ArrayList
        Dim p As New pIniaAvisoControl
        Return p.listar()
    End Function

    ' 🔎 Verifica si ya tiene registro en el Mes/Año → evitar mostrar aviso 2 veces
    Public Function ExisteRegistroMes(ByVal ClienteId As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As Boolean
        Dim p As New pIniaAvisoControl
        Return p.ExisteRegistroMes(ClienteId, Mes, Anio)
    End Function

#End Region

End Class
