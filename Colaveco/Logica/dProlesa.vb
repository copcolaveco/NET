Public Class dProlesa
#Region "Atributos"
    Private m_id As Integer
    Private m_nrosuc As Integer
    Private m_sucursal As String
    Private m_direccion As String
    Private m_telefono As String
    Private m_encargado As String
    Private m_mail As String

#End Region

#Region "Getters y Setters"
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Public Property NROSUC() As Integer
        Get
            Return m_nrosuc
        End Get
        Set(ByVal value As Integer)
            m_nrosuc = value
        End Set
    End Property
    Public Property SUCURSAL() As String
        Get
            Return m_sucursal
        End Get
        Set(ByVal value As String)
            m_sucursal = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property TELEFONO() As String
        Get
            Return m_telefono
        End Get
        Set(ByVal value As String)
            m_telefono = value
        End Set
    End Property
    Public Property ENCARGADO() As String
        Get
            Return m_encargado
        End Get
        Set(ByVal value As String)
            m_encargado = value
        End Set
    End Property
    Public Property MAIL() As String
        Get
            Return m_mail
        End Get
        Set(ByVal value As String)
            m_mail = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nrosuc = 0
        m_sucursal = ""
        m_direccion = ""
        m_telefono = ""
        m_encargado = ""
        m_mail = ""
    End Sub
    Public Sub New(ByVal id As Integer, ByVal nrosuc As Integer, ByVal sucursal As String, ByVal direccion As String, ByVal telefono As String, ByVal encargado As String, ByVal mail As String)
        m_id = id
        m_nrosuc = nrosuc
        m_sucursal = sucursal
        m_direccion = direccion
        m_telefono = telefono
        m_encargado = encargado
        m_mail = mail

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProlesa
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProlesa
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProlesa
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dProlesa
        Dim p As New pProlesa
        Return p.buscar(Me)
    End Function
    Public Function buscarxsuc() As dProlesa
        Dim p As New pProlesa
        Return p.buscarxsuc(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_sucursal
    End Function

    Public Function listar() As ArrayList
        Dim p As New pProlesa
        Return p.listar
    End Function
End Class
